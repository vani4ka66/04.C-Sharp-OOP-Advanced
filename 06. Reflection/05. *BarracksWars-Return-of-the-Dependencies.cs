using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public interface IAttacker
    {
        int AttackDamage { get; }
    }

    public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(string[] data, string commandName);
    }

    public interface IDestroyable
    {
        int Health { get; set; }
    }

    public interface IExecutable
    {
        string Execute();
    }

    public interface IRepository
    {
        void AddUnit(IUnit unit);
        string Statistics { get; }
        void RemoveUnit(string unitType);
    }

    public interface IRunnable
    {
        void Run();
    }

    public interface IUnit : IDestroyable, IAttacker
    {

    }

    public interface IUnitFactory
    {
        IUnit CreateUnit(string unitType);
    }

    public class InjectAttribute : Attribute
    {
    }

    public abstract class Command : IExecutable //NEW
    {
        private string[] data;
        private IRepository repository;
        private IUnitFactory unitFactory;

        protected Command(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            this.Data = data;
            this.Repository = repository;
            this.UnitFactory = unitFactory;
        }

        protected string[] Data { get; private set; }

        protected IRepository Repository { get; private set; }

        protected IUnitFactory UnitFactory { get; private set; }

        public abstract string Execute();
    }

    public class AddCommand : Command //NEW
    {
        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            IUnit unit = UnitFactory.CreateUnit(Data[1]);
            Repository.AddUnit(unit);
            return $"{this.Data[1]} added!";
        }
    }

    public class FightCommand : Command //NEW
    {
        public FightCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return null;
        }
    }

    public class ReportCommand : Command //NEW
    {
        public ReportCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            return this.Repository.Statistics;
        }
    }

    public class RetireCommand : Command //NEW
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string result = string.Empty;
            this.Repository.RemoveUnit(this.Data[1]);
            return $"{this.Data[1]} retired!";
        }
    }

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {

            //TODO Problem 3 - DONE

            Type T = Assembly.GetExecutingAssembly().DefinedTypes.First(t => t.Name == unitType);
            IUnit unit = Activator.CreateInstance(T) as IUnit;
            //IEnumerable<TypeInfo> types = Assembly.GetExecutingAssembly().DefinedTypes;
            return unit;
        }
    }

    public class CommandManager : ICommandInterpreter
    {
        [Inject] private IRepository repository = new UnitRepository();
        [Inject] private IUnitFactory factory = new UnitFactory();

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Type typeOfCommand =
                Assembly.GetExecutingAssembly()
                    .DefinedTypes.FirstOrDefault(x => x.Name.ToLower() == commandName + "command");
            Command command = (Command) Activator.CreateInstance(typeOfCommand, new object[] {data});
            InjectDependencies(command);
            return command;
        }

        private void InjectDependencies(IExecutable command)
        {
            FieldInfo[] fieldsOfCommand = command.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            FieldInfo[] fieldsOfInterpreter = typeof(CommandManager)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in fieldsOfCommand)
            {
                var fieldAttribute = field.GetCustomAttribute(typeof(InjectAttribute));
                if (fieldAttribute != null)
                {
                    if (fieldsOfInterpreter.Any(x => x.FieldType == field.FieldType))
                    {
                        field.SetValue(command,
                            fieldsOfInterpreter.First(x => x.FieldType == field.FieldType)
                                .GetValue(this));
                    }
                }
            }
        }

        //todo 4
        class Engine : IRunnable
        {
            private IRepository repository;
            private IUnitFactory unitFactory;

            public Engine(IRepository repository, IUnitFactory unitFactory)
            {
                this.repository = repository;
                this.unitFactory = unitFactory;
            }

            public void Run()
            {
                while (true)
                {
                    try
                    {
                        string input = Console.ReadLine();
                        string[] data = input.Split();
                        string commandName = data[0];
                        string result = InterpredCommand(data, commandName).Execute();
                        Console.WriteLine(result);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            // TODO: refactor for Problem 4 - DONE

            private IExecutable InterpredCommand(string[] data, string commandName)
            {
                Type typeOfCommand =
                    Assembly.GetExecutingAssembly()
                        .DefinedTypes.FirstOrDefault(x => x.Name.ToLower() == commandName + "command");
                object[] parameters = new object[] {data, this.repository, this.unitFactory};
                Command command = (Command) Activator.CreateInstance(typeOfCommand, parameters);
                return command;

                //string result = string.Empty;
                //switch (commandName)
                //{
                //    case "add":
                //        result = this.AddUnitCommand(data);
                //        break;
                //    case "report":
                //        result = this.ReportCommand(data);
                //        break;
                //    case "fight":
                //        Environment.Exit(0);
                //        break;
                //    default:
                //        throw new InvalidOperationException("Invalid command!");
                //}
            }


            private string ReportCommand(string[] data)
            {
                string output = this.repository.Statistics;
                return output;
            }


            private string AddUnitCommand(string[] data)
            {
                string unitType = data[1];
                IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
                this.repository.AddUnit(unitToAdd);
                string output = unitType + " added!";
                return output;
            }
        }

        //todo 4
        class UnitRepository : IRepository
        {
            private IDictionary<string, int> amountOfUnits;

            public UnitRepository()
            {
                this.amountOfUnits = new SortedDictionary<string, int>();
            }

            public string Statistics
            {
                get
                {
                    StringBuilder statBuilder = new StringBuilder();
                    foreach (var entry in amountOfUnits)
                    {
                        string formatedEntry =
                            string.Format("{0} -> {1}", entry.Key, entry.Value);
                        statBuilder.AppendLine(formatedEntry);
                    }

                    return statBuilder.ToString().Trim();
                }
            }

            public void AddUnit(IUnit unit)
            {
                string unitType = unit.GetType().Name;
                if (!this.amountOfUnits.ContainsKey(unitType))
                {
                    this.amountOfUnits.Add(unitType, 0);
                }

                this.amountOfUnits[unitType]++;
            }

            public void RemoveUnit(string unitType)
            {
                //TODO: implement for Problem 4

                if (!this.amountOfUnits.ContainsKey(unitType) || this.amountOfUnits[unitType] == 0)
                {
                    throw new InvalidOperationException("No such units in repository.");
                }
                amountOfUnits[unitType]--;
            }
        }

        public class Archer : Unit
        {
            private const int DefaultHealth = 25;
            private const int DefaultDamage = 7;

            public Archer()
                : base(DefaultHealth, DefaultDamage)
            {
            }
        }

        public class Pikeman : Unit
        {
            private const int DefaultHealth = 30;
            private const int DefaultDamage = 15;

            public Pikeman()
                : base(DefaultHealth, DefaultDamage)
            {
            }
        }

        public class Swordsman : Unit
        {
            private const int DefaultHealth = 40;
            private const int DefaultDamage = 13;

            public Swordsman()
                : base(DefaultHealth, DefaultDamage)
            {

            }
        }

        public class Gunner : Unit
        {
            private const int DefaultHealth = 20;
            private const int DefaultDamage = 20;

            public Gunner() : base(DefaultHealth, DefaultDamage)
            {
            }
        }

        public class Horseman : Unit
        {
            private const int DefaultHealth = 50;
            private const int DefaultDamage = 10;

            public Horseman() : base(DefaultHealth, DefaultDamage)
            {
            }
        }

        public class Unit : IUnit
        {
            private int health;
            private int attackDamage;

            protected Unit(int health, int attackDamage)
            {
                this.SetInitialHealth(health);
                this.AttackDamage = attackDamage;
            }

            public int AttackDamage
            {
                get { return this.attackDamage; }

                private set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException("Attack damage should be positive.");
                    }

                    this.attackDamage = value;
                }
            }

            public int Health
            {
                get { return this.health; }

                set
                {
                    if (value < 0)
                    {
                        this.health = 0;
                    }
                    else
                    {
                        this.health = value;
                    }
                }
            }

            private void SetInitialHealth(int health)
            {
                if (health <= 0)
                {
                    throw new ArgumentException("Initial health should be positive.");
                }

                this.Health = health;
            }
        }


        class Program
        {
            static void Main(string[] args)
            {
                IRepository repository = new UnitRepository();
                IUnitFactory unitFactory = new UnitFactory();
                IRunnable engine = new Engine(repository, unitFactory);
                engine.Run();
            }
        }
    }
}

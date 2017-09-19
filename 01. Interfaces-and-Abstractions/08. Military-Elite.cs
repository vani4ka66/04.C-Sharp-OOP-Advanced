using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public interface ISpy
    {
        int CodeNumber { get; }
    }

    public interface ICommando
    {
        HashSet<Mission> Missions { get; }
    }

    public interface IMission
    {
        string CodeName { get; }
        string State { get; }
        void CompleteMission();
    }

    public interface IEngineer
    {
        HashSet<Repair> Repairs { get; }
    }

    public interface IRepair
    {
        string PartName { get; }
        int WorkedHours { get; }
    }

    public interface ISpecialisedSoldiers
    {
        string Corps { get; }
    }

    public interface ILeutenantGeneral
    {
        HashSet<Private> Privates { get; }
    }

    public interface ISoldier
    {
        string FirstName { get; }
        string LastName { get; }
        string Id { get; }
    }

    public interface IPrivate
    {
        double Salary { get; }
    }

    public abstract class Soldier : ISoldier
    {
        private string firstName;
        private string lastName;
        private string id;

        protected Soldier(string firstName, string lastName, string id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Id { get; protected set; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
        }
    }

    public class Private : Soldier, IPrivate
    {
        private double salary;

        public Private(string id, string firstName, string lastName, double salary)
            : base(firstName, lastName, id)
        {
            this.Salary = salary;
        }

        public double Salary { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} Salary: {this.Salary:F2}";
        }

    }

    public class LeutenantGeneral : Private, ILeutenantGeneral
    {
        public LeutenantGeneral(string id, string firstName, string lastName, double salary, HashSet<Private> privates)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }

        public HashSet<Private> Privates { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}\nPrivates:{1}",
            base.ToString(), this.Privates.Count != 0 ? "\n  " + string.Join("\n  ", this.Privates) : "");
        }

    }

    public abstract class SpecialisedSoldiers : Private, ISpecialisedSoldiers
    {
        private string corps;

        public SpecialisedSoldiers(string id, string firstName, string lastName, double salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get { return this.corps; }
            private set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new ArgumentException("Haven't this kind of corps");
                }
                this.corps = value;
            }
        }
        public override string ToString()
        {
            return $"{base.ToString()}\nCorps: {this.Corps}";
        }
    }

    public class Repair : IRepair
    {
        public Repair(string partName, int workedHours)
        {
            this.PartName = partName;
            this.WorkedHours = workedHours;
        }
        public string PartName { get; }
        public int WorkedHours { get; }

        public override string ToString()
        {
            return $"  Part Name: {this.PartName} Hours Worked: {this.WorkedHours}";
        }
    }

    public class Engineer : SpecialisedSoldiers, IEngineer
    {
        private HashSet<Repair> repairs;

        public Engineer(string id, string firstName, string lastName, double salary, string corps, HashSet<Repair> repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = repairs;
        }

        public HashSet<Repair> Repairs { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}\nRepairs:{1}",
                base.ToString(), this.Repairs.Count != 0 ? "\n" + string.Join("\n", this.Repairs) : "");
        }
    }

    public class Mission : IMission
    {
        private string codeName;
        private string state;

        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; private set; }

        public string State
        {
            get { return this.state; }
            private set
            {
                if (value != "inProgress" && value != "Finished")
                {
                    throw new ArgumentException("No such kind of mission state!");
                }
                this.state = value;
            }
        }

        public void CompleteMission()
        {
            this.state = "Finished";
        }

        public override string ToString()
        {
            return $"  Code Name: {this.CodeName} State: {this.State}";
        }
    }

    public class Commando : SpecialisedSoldiers, ICommando
    {
        public Commando(string id, string firstName, string lastName, double salary, string corps, HashSet<Mission> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = missions;
        }

        public HashSet<Mission> Missions { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}\nMissions:{1}",
                base.ToString(), this.Missions.Count != 0 ? "\n" + string.Join("\n", this.Missions) : "");
        }
    }

    public class Spy : Soldier, ISpy
    {
        public Spy(string firstName, string lastName, string id, int code)
            : base(firstName, lastName, id)
        {
            this.CodeNumber = code;
        }

        public int CodeNumber { get; }

        public override string ToString()
        {
            return $"{base.ToString()}\nCode Number: {this.CodeNumber}";
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            List<Soldier> soldiersList = new List<Soldier>();
            List<Private> privateList = new List<Private>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] lines = input.Split();
                try
                {
                    string soldierType = lines[0];
                    string id = lines[1];
                    string firstName = lines[2];
                    string lastName = lines[3];

                    switch (soldierType.ToLower())
                    {
                        case "private":
                            double salary = double.Parse(lines[4]);
                            soldiersList.Add(new Private(id, firstName, lastName, salary));
                            privateList.Add(new Private(id, firstName, lastName, salary));
                            break;
                        case "leutenantgeneral":
                            HashSet<Private> leutenantPrivates = new HashSet<Private>();
                            for (int i = 5; i < lines.Length; i++)
                            {
                                var currentPrivate = privateList.FirstOrDefault(s => s.Id == lines[i]);
                                if (currentPrivate != null)
                                {
                                    leutenantPrivates.Add(currentPrivate);
                                }
                            }
                            soldiersList.Add(new LeutenantGeneral(id, firstName, lastName, double.Parse(lines[4]), leutenantPrivates));
                            break;
                        case "engineer":
                            HashSet<Repair> repairParts = new HashSet<Repair>();
                            for (int i = 6; i < lines.Length; i += 2)
                            {
                                repairParts.Add(new Repair(lines[i], int.Parse(lines[i + 1])));
                            }
                            soldiersList.Add(new Engineer(id, firstName, lastName, double.Parse(lines[4]), lines[5], repairParts));
                            break;
                        case "commando":
                            HashSet<Mission> missions = new HashSet<Mission>();
                            for (int i = 6; i < lines.Length; i += 2)
                            {
                                try
                                {
                                    missions.Add(new Mission(lines[i], lines[i + 1]));
                                }
                                catch (Exception)
                                {

                                }
                            }
                            soldiersList.Add(new Commando(id, firstName, lastName, double.Parse(lines[4]), lines[5], missions));
                            break;
                        case "spy":
                            soldiersList.Add(new Spy(firstName, lastName, id, int.Parse(lines[4])));
                            break;
                    }
                }
                catch (Exception)
                {

                }

                input = Console.ReadLine();
            }

            foreach (var item in soldiersList)
            {
                Console.WriteLine(item);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public interface IKillable
    {
        string Name { get; set; }

        void OnKingAttack(object sender, EventArgs e);
    }

    public abstract class Person
    {
        protected Person(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }

    public delegate void KingAttackHandler(object sender, EventArgs e);

    public class King : Person
    {
        public event KingAttackHandler Attacked;

        public King(string name)
            : base(name)
        {
        }

        public void OnAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            OnKingsAttacked(new EventArgs());
        }

        protected void OnKingsAttacked(EventArgs e)
        {
            if (Attacked != null)
            {
                Attacked(this, e);
            }
        }
    }

    public class Footman : Person, IKillable
    {
        public Footman(string name)
            : base(name)
        {
        }

        public void OnKingAttack(object sender, EventArgs e)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }

    public class RoyalGuard : Person, IKillable
    {
        public RoyalGuard(string name)
            : base(name)
        {
        }

        public void OnKingAttack(object sender, EventArgs e)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<IKillable> persons = new List<IKillable>();

            King king = new King(Console.ReadLine());

            string[] royalGuards = Console.ReadLine().Split();
            for (int i = 0; i < royalGuards.Length; i++)
            {
                var guard = new RoyalGuard(royalGuards[i]);
                king.Attacked += guard.OnKingAttack;
                persons.Add(guard);
            }

            string[] footmen = Console.ReadLine().Split();
            for (int i = 0; i < footmen.Length; i++)
            {
                var footman = new Footman(footmen[i]);
                king.Attacked += footman.OnKingAttack;
                persons.Add(footman);
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputArgs = input.Split();
                switch (inputArgs[0])
                {
                    case "Attack":
                        king.OnAttack();
                        break;
                    case "Kill":
                        IKillable person = persons.FirstOrDefault(x => x.Name == inputArgs[1]);
                        king.Attacked -= person.OnKingAttack;
                        persons.Remove(person);
                        break;
                }

                input = Console.ReadLine();
            }

        }
    }
}

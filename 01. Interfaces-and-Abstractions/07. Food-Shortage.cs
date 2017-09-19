using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    interface IBuyer
    {
        int Food { get; }

        void BuyFood();
    }

    public abstract class Human : IBuyer
    {
        private string name;
        private int age;

        public Human(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Food = 0;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public int Food { get; protected set; }


        public abstract void BuyFood();
    }

    public class Citizen : Human
    {
        private string id;
        private string birthDate;

        public Citizen(string name, int age, string id, string birth)
            : base(name, age)
        {
            this.Id = id;
            this.BirthDate = birth;
        }

        public string Id { get; set; }

        public string BirthDate { get; set; }

        public override void BuyFood()
        {
            base.Food += 10;
        }
    }

    public class Rebel : Human
    {
        private string group;

        public Rebel(string name, int age, string group)
            : base(name, age)
        {
            this.Group = group;
        }

        public string Group { get; set; }

        public override void BuyFood()
        {
            base.Food += 5;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Human> humans = new List<Human>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] humanInfo = Console.ReadLine().Split();
                string name = humanInfo[0];
                int age = int.Parse(humanInfo[1]);
                if (humanInfo.Length > 3)
                {
                    string id = humanInfo[2];
                    string birthDate = humanInfo[3];
                    Citizen citizen = new Citizen(name, age, id, birthDate);
                    humans.Add(citizen);
                }
                else
                {
                    string group = humanInfo[2];
                    Rebel rebel = new Rebel(name, age, group);
                    humans.Add(rebel);
                }
            }
            string buyer = Console.ReadLine();

            while (buyer != "End")
            {
                var humanBuyer = humans.Find(h => h.Name == buyer);

                if (humanBuyer != null)
                {
                    humanBuyer.BuyFood();
                }
                buyer = Console.ReadLine();
            }

            int totalFoodBought = 0;

            foreach (var item in humans)
            {
                totalFoodBought += item.Food;
            }

            Console.WriteLine(totalFoodBought);

        }
    }
}

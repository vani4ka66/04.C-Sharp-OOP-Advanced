using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    interface IIdentifiable
    {
        string ID { get; set; }
    }

    public class Citizen : IIdentifiable
    {
        private string name;
        private int age;

        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string ID { get; set; }

        public override string ToString()
        {
            return this.ID;
        }
    }

    public class Robot : IIdentifiable
    {
        private string model;

        public Robot(string model, string id)
        {
            this.Model = model;
            this.ID = id;
        }

        public string Model { get; set; }

        public string ID { get; set; }

        public override string ToString()
        {
            return this.ID;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> identifiable = new List<IIdentifiable>();

            string entrants = Console.ReadLine();

            while (entrants != "End")
            {
                string[] entrantDetails = entrants.Split();
                if (entrantDetails.Length > 2)
                {
                    Citizen citizen = new Citizen(entrantDetails[0], int.Parse(entrantDetails[1]), entrantDetails[2]);
                    identifiable.Add(citizen);
                }
                else
                {
                    Robot robot = new Robot(entrantDetails[0], entrantDetails[1]);
                    identifiable.Add(robot);

                }
                entrants = Console.ReadLine();
            }
            string fakeides = Console.ReadLine();

            var detained = identifiable.Where(i => i.ID.EndsWith(fakeides)).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, detained));

        }
    }
}

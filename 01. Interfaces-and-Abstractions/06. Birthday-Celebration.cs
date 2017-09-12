using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public interface IName
    {
        string Name { get; set; }
    }

    public interface IBirth
    {
        string Birthday { get; set; }
    }

    public interface IId
    {
        string Id { get; set; }
    }

    public class Citizen : IName, IBirth, IId
    {

        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
        }
        public int Age { get; set; }

        public string Name { get; set; }
        public string Birthday { get; set; }
        public string Id { get; set; }
    }

    public class Robot : IId
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Model { get; set; }

        public string Id { get; set; }
    }

    public class Pet : IName, IBirth
    {
        public Pet(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }
        public string Name { get; set; }
        public string Birthday { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<IBirth> birthdayList = new List<IBirth>();

            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] input = line.Split();

                if (input[0] == "Citizen")
                {
                    string name = input[1];
                    int age = int.Parse(input[2]);
                    string id = input[3];
                    string birth = input[4];
                    Citizen citizen = new Citizen(name, age, id, birth);
                    birthdayList.Add(citizen);
                }
                else if (input[0] == "Pet")
                {
                    Pet pet = new Pet(input[1], input[2]);
                    birthdayList.Add(pet);
                }

                line = Console.ReadLine();
            }
            string year = Console.ReadLine();

            foreach (var item in birthdayList)
            {
                if (item.Birthday.EndsWith(year))
                {
                    Console.WriteLine(item.Birthday);
                }
            }

        }
    }
}

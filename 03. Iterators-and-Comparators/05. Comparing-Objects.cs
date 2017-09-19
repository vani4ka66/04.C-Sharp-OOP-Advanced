using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; }

        public int Age { get; }

        public string Town { get; }

        public int CompareTo(Person other)
        {
            int comparison = 0;
            if (this.Name.CompareTo(other.Name) != 0)
            {
                comparison = this.Name.CompareTo(other.Name);
            }
            if (this.Age.CompareTo(other.Age) != 0)
            {
                comparison = this.Age.CompareTo(other.Age);
            }
            if (this.Town.CompareTo(other.Town) != 0)
            {
                comparison = this.Town.CompareTo(other.Town);
            }
            return comparison;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> listPersons = new List<Person>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] arguments = input.Split();
                string name = arguments[0];
                int age = int.Parse(arguments[1]);
                string town = arguments[2];

                Person person = new Person(name, age, town);
                listPersons.Add(person);

                input = Console.ReadLine();
            }
            int number = int.Parse(Console.ReadLine());

            Person wanted = listPersons[number - 1];
            int matchPeople = 0;

            foreach (var item in listPersons)
            {
                if (item.CompareTo(wanted) == 0)
                {
                    matchPeople++;
                }
            }
            if (matchPeople == 1)
            {
                Console.WriteLine("No matches");
                return;
            }
            Console.WriteLine($"{matchPeople} {listPersons.Count - matchPeople} {listPersons.Count}");

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; }
        public int Age { get; }

        public class NameLengthComparator : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                int comparator = 0;
                if (x.Name.Length.CompareTo(y.Name.Length) != 0)
                {
                    comparator = x.Name.Length.CompareTo(y.Name.Length);
                }
                if (comparator == 0)
                {
                    comparator = x.Name[0].ToString().ToLower().CompareTo(y.Name[0].ToString().ToLower());
                }
                return comparator;
            }
        }

        public class AgeComparator : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return x.Age.CompareTo(y.Age);
            }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> names = new SortedSet<Person>(new Person.NameLengthComparator());
            SortedSet<Person> ages = new SortedSet<Person>(new Person.AgeComparator());

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Person person = new Person(input[0], int.Parse(input[1]));
                names.Add(person);
                ages.Add(person);
            }

            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
            foreach (var item in ages)
            {
                Console.WriteLine(item);
            }

        }
    }
}

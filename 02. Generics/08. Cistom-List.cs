using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{
    public class CustomList<T> where T : IComparable<T>
    {

        private List<T> elements;

        public CustomList()
        {
            this.elements = new List<T>();
        }

        public List<T> Elements => elements;

        public void Add(T element)
        {
            this.elements.Add(element);
        }

        public void Remove(int index)
        {
            this.elements.RemoveAt(index);
        }

        public bool Contains(T element)
        {
            return this.elements.Contains(element);
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            var first = this.elements[firstIndex];
            var second = this.elements[secondIndex];
            this.elements[firstIndex] = second;
            this.elements[secondIndex] = first;
        }

        public int CountGreaterThan(T element)
        {
            return this.elements.Count(x => x.CompareTo(element) > 0);
        }

        public T Max()
        {
            return this.elements.Max();
        }

        public T Min()
        {
            return this.elements.Min();
        }
    }

    public class CommandInterpreter
    {
        private static CustomList<string> customList = new CustomList<string>();

        public static void Interpreter(string input)
        {
            string[] commandInfo = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string command = commandInfo[0];

            switch (command.ToLower())
            {
                case "add":
                    string element = commandInfo[1];
                    customList.Add(element);
                    break;
                case "remove":
                    int index = int.Parse(commandInfo[1]);
                    customList.Remove(index);
                    break;
                case "contains":
                    string item = commandInfo[1];
                    bool ifContains = customList.Contains(item);
                    if (ifContains)
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                    break;
                case "swap":
                    int firstIndex = int.Parse(commandInfo[1]);
                    int secondIndex = int.Parse(commandInfo[2]);
                    customList.Swap(firstIndex, secondIndex);
                    break;
                case "greater":
                    item = commandInfo[1];
                    Console.WriteLine(customList.CountGreaterThan(item));
                    break;
                case "max":
                    Console.WriteLine(customList.Max());
                    break;
                case "min":
                    Console.WriteLine(customList.Min());
                    break;
                case "print":
                    customList.Elements.ToList().ForEach(Console.WriteLine);
                    break;
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                CommandInterpreter.Interpreter(input);

                input = Console.ReadLine();
            }

        }
    }
}

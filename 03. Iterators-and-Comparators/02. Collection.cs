using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> list;
        private int index;

        public ListyIterator()
        {
            list = new List<T>();
            index = 0;
        }

        public void Create(List<T> elements)
        {
            this.list = new List<T>();
            this.list.AddRange(elements);
            index = 0;
        }

        public bool Move()
        {
            if (index < list.Count - 1)
            {
                index++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if (index == list.Count - 1)
            {
                return false;
            }
            return true;
        }

        public void Print()
        {
            try
            {
                Console.WriteLine(list[index]);
            }
            catch (ArgumentException)
            {

                throw new ArgumentException("Invalid Operation!");
            }
        }

        public void PrintAll()
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            ListyIterator<string> collection = new ListyIterator<string>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] commandArgs = input.Split();
                string command = commandArgs[0];

                switch (command.ToLower())
                {
                    case "create":
                        List<string> list = new List<string>();
                        for (int i = 1; i < commandArgs.Length; i++)
                        {
                            list.Add(commandArgs[i]);
                        }
                        collection.Create(list);
                        break;
                    case "move":
                        Console.WriteLine(collection.Move());
                        break;
                    case "hasnext":
                        Console.WriteLine(collection.HasNext());
                        break;
                    case "print":
                        try
                        {
                            collection.Print();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "printall":
                        collection.PrintAll();
                        break;
                }
                input = Console.ReadLine();
            }

        }
    }
}

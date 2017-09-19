using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{
    public class MyStack<T> : IEnumerable<T>
    {
        private T[] collection;

        public MyStack()
        {
            this.collection = new T[0];
        }

        public void Push(T element)
        {
            T[] temporary = new T[collection.Length + 1];
            collection.CopyTo(temporary, 0);
            temporary[collection.Length] = element;
            this.collection = temporary;
        }

        public void Pop()
        {
            if (collection.Length == 0)
            {
                Console.WriteLine("No elements");
                return;
            }
            T[] temporary = new T[collection.Length - 1];
            for (int i = 0; i < temporary.Length; i++)
            {
                temporary[i] = collection[i];
            }
            collection = temporary;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = collection.Length - 1; i >= 0; i--)
            {
                yield return collection[i];
            }
            for (int i = collection.Length - 1; i >= 0; i--)
            {
                yield return collection[i];
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
            MyStack<string> myStack = new MyStack<string>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] line = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string command = line[0];
                if (command == "Push")
                {
                    for (int i = 1; i < line.Length; i++)
                    {
                        myStack.Push(line[i]);
                    }
                }
                else if (command == "Pop")
                {
                    myStack.Pop();
                }

                input = Console.ReadLine();
            }

            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }

        }
    }
}

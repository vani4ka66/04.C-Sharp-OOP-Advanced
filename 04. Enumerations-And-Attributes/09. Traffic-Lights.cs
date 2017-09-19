using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public enum Light
    {
        Red,
        Green,
        Yellow
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            int index = 0;

            for (int i = 0; i < n; i++)
            {
                foreach (var item in input)
                {
                    int nextIndex = (int)Enum.Parse(typeof(Light), item) + 1 + index;
                    Light next = (Light)(nextIndex % 3);
                    Console.Write(next + " ");

                }
                Console.WriteLine();
                index++;
            }

        }
    }
}

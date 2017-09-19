using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public class Box<T>
    {
        private T type;

        public Box(T type)
        {
            this.type = type;
        }

        public override string ToString()
        {
            return $"{this.type.GetType().FullName}: {this.type}";
        }

        public static void Swap<T>(List<Box<T>> list, int firstPosition, int secondPosition)
        {
            Box<T> oldFirstPositionValue = list[firstPosition];
            list[firstPosition] = list[secondPosition];
            list[secondPosition] = oldFirstPositionValue;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<int>> genericList = new List<Box<int>>();
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                Box<int> genericString = new Box<int>(input);
                genericList.Add(genericString);
            }
            int[] swapPositionsInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int startIndex = swapPositionsInfo[0];
            int lastIndex = swapPositionsInfo[1];
            Box<int>.Swap(genericList, startIndex, lastIndex);
            foreach (var generic in genericList)
            {
                Console.WriteLine(generic);
            }

        }
    }
}

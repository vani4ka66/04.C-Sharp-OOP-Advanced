using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public class Box<T> where T : IComparable<T>
    {
        private T value;

        public Box()
            : this(default(T))
        {

        }

        public Box(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }

    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Box<double>> boxes = new List<Box<double>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                boxes.Add(new Box<double>(double.Parse(Console.ReadLine())));
            }
            Box<double> comparableBox = new Box<double>(double.Parse(Console.ReadLine()));

            int countOfGreaterElements = CompareElements(boxes, comparableBox);

            Console.WriteLine(countOfGreaterElements);
        }

        static int CompareElements<T>(List<Box<T>> boxes, Box<T> comparaableBox)
            where T : IComparable<T>
        {
            int count = 0;
            foreach (var item in boxes)
            {
                if (item.Value.CompareTo(comparaableBox.Value) > 0)
                {
                    count++;
                }
            }
            return count;

        }
    }
}

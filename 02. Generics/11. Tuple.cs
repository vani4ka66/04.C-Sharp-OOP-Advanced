using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{
    public class Tuplee<TKey, TValue>
    {
        public Tuplee()
            : this(default(TKey), default(TValue))
        {
        }
        public Tuplee(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }
        public TKey Key { get; private set; }
        public TValue Value { get; private set; }

        public override string ToString()
        {
            return $"{this.Key} -> {this.Value}";
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Tuplee<string, string> tuplee = new Tuplee<string, string>(input[0] + " " + input[1], input[2]);
            Console.WriteLine(tuplee);

            string[] beers = Console.ReadLine().Split();
            Tuplee<string, int> beer = new Tuplee<string, int>(beers[0], int.Parse(beers[1]));
            Console.WriteLine(beer);

            string[] numbers = Console.ReadLine().Split();
            Tuplee<int, double> number = new Tuplee<int, double>(int.Parse(numbers[0]), double.Parse(numbers[1]));
            Console.WriteLine(number);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{
    public class Tuplee<TKey, TValue, TPair>
    {
        public Tuplee()
            : this(default(TKey), default(TValue), default(TPair))
        {
        }
        public Tuplee(TKey key, TValue value, TPair pair)
        {
            this.Key = key;
            this.Value = value;
            this.Pair = pair;
        }
        public TKey Key { get; private set; }
        public TValue Value { get; private set; }
        public TPair Pair { get; private set; }

        public override string ToString()
        {
            return $"{this.Key} -> {this.Value} -> {this.Pair}";
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Tuplee<string, string, string> tuplee = new Tuplee<string, string, string>(input[0] + " " + input[1], input[2], input[3]);
            Console.WriteLine(tuplee);

            string[] beers = Console.ReadLine().Split();
            string drunkStatus = beers[2];
            bool isDrunk = drunkStatus == "drunk";
            Tuplee<string, int, bool> beer = new Tuplee<string, int, bool>(beers[0], int.Parse(beers[1]), isDrunk);
            Console.WriteLine(beer);

            string[] numbers = Console.ReadLine().Split();
            Tuplee<string, double, string> number = new Tuplee<string, double, string>((numbers[0]), double.Parse(numbers[1]), numbers[2]);
            Console.WriteLine(number);

        }
    }
}

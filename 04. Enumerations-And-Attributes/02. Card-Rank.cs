using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public enum Cards
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var card = Enum.GetValues(typeof(Cards));

            Console.WriteLine(input + ":");
            foreach (var item in card)
            {
                Console.WriteLine($"Ordinal value: {(int)item}; Name value: {item}");
            }

        }
    }
}

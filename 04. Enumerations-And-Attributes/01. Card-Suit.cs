using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public enum Suits
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var card = Enum.GetValues(typeof(Suits));

            Console.WriteLine(input + ":");
            foreach (var item in card)
            {
                Console.WriteLine($"Ordinal value: {(int)item}; Name value: {item}");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public class Card
    {
        public enum Suit
        {
            Clubs,
            Diamonds = 13,
            Hearts = 26,
            Spades = 39
        }

        public enum Rank
        {
            Ace = 14,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13,
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string rank = Console.ReadLine();
            string suit = Console.ReadLine();

            int rankInt = (int)Enum.Parse(typeof(Card.Rank), rank);
            int suitkInt = (int)Enum.Parse(typeof(Card.Suit), suit);

            Console.WriteLine($"Card name: {rank} of {suit}; Card power: {rankInt + suitkInt}");

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
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

    public class Card : IComparable<Card>
    {
        private string Rank { get; }
        private string Suit { get; }

        public Card(string rank, string suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }

        public int CardPower
        {
            get { return (int)Enum.Parse(typeof(Rank), this.Rank) + (int)Enum.Parse(typeof(Suit), this.Suit); }
        }
        public int CompareTo(Card other)
        {
            return this.CardPower.CompareTo(other.CardPower);
        }

        public override string ToString()
        {
            int suit = (int)Enum.Parse(typeof(Rank), this.Rank);
            int rank = (int)Enum.Parse(typeof(Suit), this.Suit);

            return $"Card name: {this.Rank} of {this.Suit}; Card power: {suit + rank}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string firstRank = Console.ReadLine();
            string firstSuit = Console.ReadLine();
            string secondRank = Console.ReadLine();
            string secondSuit = Console.ReadLine();

            Card cardFirst = new Card(firstRank, firstSuit);
            Card cardSecond = new Card(secondRank, secondSuit);

            if (cardFirst.CompareTo(cardSecond) == 1)
            {
                Console.WriteLine(cardFirst);
            }
            else
            {
                Console.WriteLine(cardSecond);
            }


        }
    }
}

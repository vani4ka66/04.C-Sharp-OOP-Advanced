using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public class Card : IComparable<Card>
    {
        public Card(Rank rank, Suit suit, string player)
        {
            this.Rank = rank;
            this.Suit = suit;
            this.Player = player;
        }

        public Rank Rank { get; }
        public Suit Suit { get; }

        public int Power
        {
            get { return (int)this.Rank + (int)this.Suit; }
        }

        public string Player { get; }

        public int CompareTo(Card other)
        {
            return this.Power.CompareTo(other.Power);
        }

        public override int GetHashCode()
        {
            return this.Power + (int)this.Rank + (int)this.Suit;
        }

        public override bool Equals(object obj)
        {
            var thisObject = obj as Card;

            return this.GetHashCode() == thisObject.GetHashCode();
        }
    }

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

    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Card> cards = new HashSet<Card>();

            string playerOne = Console.ReadLine();
            string playerTwo = Console.ReadLine();

            while (cards.Count < 10)
            {
                string[] input = Console.ReadLine().Split();
                string rank = input[0];
                string suit = input[2];

                Rank ranks = Rank.Ace;
                Suit suits = Suit.Clubs;

                if (Enum.TryParse(rank, out ranks) && Enum.TryParse(suit, out suits))
                {
                    Card card = new Card(ranks, suits, playerOne);

                    if (cards.Count >= 5)
                    {
                        card = new Card(ranks, suits, playerTwo);
                    }
                    if (cards.Contains(card))
                    {
                        Console.WriteLine("Card is not in the deck.");
                        continue;
                    }
                    cards.Add(card);
                }
                else
                {
                    Console.WriteLine("No such card exists.");
                }
            }

            Card maxCard = cards.Max();
            Console.WriteLine($"{maxCard.Player} wins with {maxCard.Rank} of {maxCard.Suit}.");

        }
    }
}

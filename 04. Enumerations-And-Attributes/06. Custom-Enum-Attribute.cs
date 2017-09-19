using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    [Type("Enumeration", "Suit", "Provides suit constants for a Card class.")]
    public enum Suit
    {
        Clubs,
        Diamonds = 13,
        Hearts = 26,
        Spades = 39
    }

    [Type("Enumeration", "Rank", "Provides rank constants for a Card class.")]
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
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum)]
    public class TypeAttribute : Attribute
    {
        public TypeAttribute(string type, string category, string description)
        {
            this.Type = type;
            this.Category = category;
            this.Description = description;
        }

        public string Type { get; }

        public string Category { get; }

        public string Description { get; }

        public override string ToString()
        {
            return $"Type = {this.Type}, Description = {this.Description}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string target = Console.ReadLine();
            Type type = null;
            if (target == "Rank")
            {
                type = typeof(Rank);
            }
            else
            {
                type = typeof(Suit);
            }

            object[] attributes = type.GetCustomAttributes(false);

            foreach (TypeAttribute item in attributes)
            {
                Console.WriteLine(item);
            }

        }
    }
}

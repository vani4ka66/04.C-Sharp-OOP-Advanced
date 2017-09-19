using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace August2017
{

   
    class Program
    {
        class HarvestingFields
        {
            private int testInt;
            public double testDouble;
            protected string testString;
            private long testLong;
            protected double aDouble;
            public string aString;
            private Calendar aCalendar;
            public StringBuilder aBuilder;
            private char testChar;
            public short testShort;
            protected byte testByte;
            public byte aByte;
            protected StringBuilder aBuffer;
            private BigInteger testBigInt;
            protected BigInteger testBigNumber;
            protected float testFloat;
            public float aFloat;
            private Thread aThread;
            public Thread testThread;
            private object aPredicate;
            protected object testPredicate;
            public object anObject;
            private object hiddenObject;
            protected object fatherMotherObject;
            private string anotherString;
            protected string moarString;
            public int anotherIntBitesTheDust;
            private Exception internalException;
            protected Exception inheritableException;
            public Exception justException;
            public Stream aStream;
            protected Stream moarStreamz;
            private Stream secretStream;
        }

        public static String GetTheType(FieldInfo a)
        {
            if (a.IsPublic)
                return "public";
            else if (a.IsPrivate)
                return "private";
            else if (a.IsFamily)
                return "protected";
            return null;
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Type type = typeof(HarvestingFields);
            while (input != "HARVEST")
            {
                switch (input)
                {
                    case "protected":
                        FieldInfo[] protecteds = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
                        foreach (var item in protecteds)
                        {
                            if (item.IsFamily)
                            {
                                Console.WriteLine($"{GetTheType(item)} {item.FieldType.Name} {item.Name}");
                            }
                        }
                        break;
                    case "private":
                        FieldInfo[] privates = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
                        foreach (var item in privates)
                        {
                            if (item.IsPrivate)
                            {
                                Console.WriteLine($"{GetTheType(item)} {item.FieldType.Name} {item.Name}");
                            }
                        }
                        break;
                    case "public":
                        FieldInfo[] publics = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
                        foreach (var item in publics)
                        {
                            if (item.IsPublic)
                            {
                                Console.WriteLine($"{GetTheType(item)} {item.FieldType.Name} {item.Name}");
                            }
                        }
                        break;
                    case "all":
                        FieldInfo[] all = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                        foreach (var item in all)
                        {
                            Console.WriteLine($"{GetTheType(item)} {item.FieldType.Name} {item.Name}");
                        }
                        break;
                }

                input = Console.ReadLine();
            }

        }
    }
}

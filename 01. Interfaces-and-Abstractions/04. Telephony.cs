using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public interface ICallable
    {
        void Calling(string number);
    }

    public interface IBrawsable
    {
        void Browsing(string site);
    }

    public class Smartphone : ICallable, IBrawsable
    {
        public void Calling(string number)
        {
            bool isNumber = true;

            for (int i = 0; i < number.Length; i++)
            {
                if (!char.IsDigit(number[i]))
                {
                    isNumber = false;
                    break;
                }
            }

            if (isNumber)
            {
                Console.WriteLine($"Calling... {number}");
            }
            else
            {
                Console.WriteLine("Invalid number!");
            }
        }

        public void Browsing(string site)
        {
            bool isTrue = true;
            for (int i = 0; i < site.Length; i++)
            {
                if (char.IsDigit(site[i]))
                {
                    isTrue = false;
                    break;
                }
            }
            if (isTrue)
            {
                Console.WriteLine($"Browsing: {site}!");
            }
            else
            {
                Console.WriteLine("Invalid URL!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();

            Smartphone smartphone = new Smartphone();
            foreach (var item in numbers)
            {
                smartphone.Calling(item);
            }

            foreach (var item in sites)
            {
                smartphone.Browsing(item);
            }

        }
    }
}

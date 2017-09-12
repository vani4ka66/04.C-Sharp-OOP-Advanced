using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public interface ICar
    {
        string PrintBrakes();
        string PrintGasMessage();
    }

    public class Ferrari : ICar
    {
        private const string model = "488-Spider";

        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public string Driver { get; set; }

        public string Model = model;

        public string PrintBrakes()
        {
            return "Brakes!";
        }

        public string PrintGasMessage()
        {
            return "Zadu6avam sA!";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string ferrariName = typeof(Ferrari).Name;
            string iCarInterfaceName = typeof(ICar).Name;

            bool isCreated = typeof(ICar).IsInterface;
            if (!isCreated)
            {
                throw new Exception("No interface ICar was created");
            }
            string driverName = Console.ReadLine();
            Ferrari ferrari = new Ferrari(driverName);
            Console.WriteLine($"{ferrari.Model}/{ferrari.PrintBrakes()}/{ferrari.PrintGasMessage()}/{ferrari.Driver}");
        }

    }
}


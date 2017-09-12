using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public interface IIdentifiable
    {
        string Id { get; set; }
    }

    public interface IBirthable
    {
        string Birthdate { get; set; }
    }

    public interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }
    }

    public class Citizen : IPerson, IBirthable, IIdentifiable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
            this.Id = id;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Birthdate { get; set; }
        public string Id { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Type identifiableInterface = typeof(Citizen).GetInterface("IIdentifiable");
            Type birthableInterface = typeof(Citizen).GetInterface("IBirthable");
            PropertyInfo[] properties = identifiableInterface.GetProperties();
            Console.WriteLine(properties.Length);
            Console.WriteLine(properties[0].PropertyType.Name);
            properties = birthableInterface.GetProperties();
            Console.WriteLine(properties.Length);
            Console.WriteLine(properties[0].PropertyType.Name);
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string id = Console.ReadLine();
            string birthdate = Console.ReadLine();
            IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
            IBirthable birthable = new Citizen(name, age, id, birthdate);


        }
    }
}

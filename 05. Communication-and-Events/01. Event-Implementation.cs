using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs e);

    public class Dispatcher
    {
        private string name;


        public string Name
        {
            get { return this.name; }
            set
            {
                OnNameChange(new NameChangeEventArgs(value));
            }
        }

        public event NameChangeEventHandler NameChange;

        public void OnNameChange(NameChangeEventArgs e)
        {
            this.NameChange?.Invoke(this, e);
        }
    }

    public class Handler
    {
        public void OnDispatcherNameChange(object sender, NameChangeEventArgs e)
        {
            Console.WriteLine($"Dispatcher's name changed to {e.Name}.");
        }
    }

    public class NameChangeEventArgs : EventArgs
    {
        public NameChangeEventArgs(string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Handler handler = new Handler();
            Dispatcher dispatcher = new Dispatcher();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string input = Console.ReadLine();
            while (input != "End")
            {
                dispatcher.Name = input;
                input = Console.ReadLine();
            }

        }
    }
}

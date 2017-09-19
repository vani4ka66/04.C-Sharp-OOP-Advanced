using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public class ModifiedList : List<Job>
    {
        public void HandleJobCompletion(object sender, JobDoneEventArgs e)
        {
            this.Remove(e.Job);
        }
    }

    public class JobDoneEventArgs : EventArgs
    {
        private Job job;

        public JobDoneEventArgs(Job job)
        {
            this.Job = job;
        }

        public Job Job { get; set; }
    }

    public abstract class Employee
    {
        private string name;
        private int workHoursPerWeek;

        protected Employee(string name, int workHoursPerWeek)
        {
            this.Name = name;
            this.WorkHoursPerWeek = workHoursPerWeek;
        }

        public string Name { get; set; }

        public int WorkHoursPerWeek { get; set; }
    }

    public class StandartEmployee : Employee
    {
        private const int workHoursPerWeek = 40;

        public StandartEmployee(string name)
            : base(name, workHoursPerWeek)
        {
        }

    }

    public class PartTimeEmployee : Employee
    {
        private const int workHoursPerWeek = 20;

        public PartTimeEmployee(string name)
            : base(name, workHoursPerWeek)
        {
        }

    }

    public delegate void JobUpdateHandler(object sender, JobDoneEventArgs e);

    public class Job
    {
        private string name;
        private int workHoursRequired;
        private Employee employee;

        public Job(string name, int workHoursRequired, Employee employee)
        {
            this.Name = name;
            this.WorkHoursRequired = workHoursRequired;
            this.Employee = employee;
        }

        public event JobUpdateHandler JobUpdate;

        public Employee Employee
        {
            get { return this.employee; }
            set { this.employee = value; }
        }

        public string Name { get; set; }

        public int WorkHoursRequired { get; set; }

        public void Update()
        {
            this.WorkHoursRequired -= this.Employee.WorkHoursPerWeek;
            if (this.WorkHoursRequired <= 0)
            {
                Console.WriteLine($"Job {this.Name} done!");
                this.OnJobUpdate(new JobDoneEventArgs(this));
            }
        }

        public void OnJobUpdate(JobDoneEventArgs e)
        {
            if (this.JobUpdate != null)
            {
                this.JobUpdate(this, e); // == del()
            }
        }

        public override string ToString()
        {
            return string.Format($"Job: {this.Name} Hours Remaining: {this.WorkHoursRequired}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ModifiedList jobs = new ModifiedList();
            Dictionary<string, Employee> employeeByName = new Dictionary<string, Employee>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputArgs = input.Split();
                switch (inputArgs[0])
                {
                    case "StandartEmployee":
                        var standartEmployee = new StandartEmployee(inputArgs[1]);
                        employeeByName[inputArgs[1]] = standartEmployee;
                        break;
                    case "PartTimeEmployee":
                        var partTimeEmployee = new PartTimeEmployee(inputArgs[1]);
                        employeeByName[inputArgs[1]] = partTimeEmployee;
                        break;
                    case "Job":
                        var employee = employeeByName[inputArgs[3]];
                        var job = new Job(inputArgs[1], int.Parse(inputArgs[2]), employee);
                        jobs.Add(job);
                        job.JobUpdate += jobs.HandleJobCompletion;
                        break;
                    case "Pass":
                        List<Job> jobsToUpdate = new List<Job>(jobs);
                        foreach (var item in jobsToUpdate)
                        {
                            item.Update();
                        }
                        break;
                    case "Status":
                        foreach (var item in jobs)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                }

                input = Console.ReadLine();
            }

        }
    }
}

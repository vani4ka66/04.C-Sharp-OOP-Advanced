using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    interface IStrategy
    {
        int Calculate(int firstOperand, int secondOperand);
    }

    class PrimitiveCalculator
    {
        private IStrategy strategy;


        public PrimitiveCalculator()
            : this(new AdditionStrategy())
        {
            this.strategy = new AdditionStrategy();

        }

        public PrimitiveCalculator(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void ChangeStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.strategy.Calculate(firstOperand, secondOperand);
        }
    }

    class AdditionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }

    public class DivisionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }

    public class MultiplicationStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand * secondOperand;
        }
    }

    public class SubtractionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var calculator = new PrimitiveCalculator();

            while (input != "End")
            {
                string[] inputArgs = input.Split();
                if (inputArgs[0] == "mode")
                {
                    switch (inputArgs[1])
                    {
                        case "/":
                            IStrategy division = new DivisionStrategy();
                            calculator.ChangeStrategy(division);
                            break;
                        case "-":
                            IStrategy subtraction = new SubtractionStrategy();
                            calculator.ChangeStrategy(subtraction);
                            break;
                        case "+":
                            IStrategy addition = new AdditionStrategy();
                            calculator.ChangeStrategy(addition);
                            break;
                        case "*":
                            IStrategy multiplication = new MultiplicationStrategy();
                            calculator.ChangeStrategy(multiplication);
                            break;
                        default:
                            throw new InvalidOperationException("Unknown operator");
                    }
                }
                else
                {
                    int first = int.Parse(inputArgs[0]);
                    int second = int.Parse(inputArgs[1]);

                    int result = calculator.PerformCalculation(first, second);
                    Console.WriteLine(result);
                }

                input = Console.ReadLine();
            }

        }
    }
}

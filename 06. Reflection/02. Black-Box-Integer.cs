using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    class BlackBoxInt
    {
        private static int DefaultValue = 0;

        private int innerValue;

        private BlackBoxInt(int innerValue)
        {
            this.innerValue = innerValue;
        }

        private BlackBoxInt()
        {
            this.innerValue = DefaultValue;
        }

        private void Add(int addend)
        {
            this.innerValue += addend;
        }

        private void Subtract(int subtrahend)
        {
            this.innerValue -= subtrahend;
        }

        private void Multiply(int multiplier)
        {
            this.innerValue *= multiplier;
        }

        private void Divide(int divider)
        {
            this.innerValue /= divider;
        }

        private void LeftShift(int shifter)
        {
            this.innerValue <<= shifter;
        }

        private void RightShift(int shifter)
        {
            this.innerValue >>= shifter;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(BlackBoxInt);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo field = fields.First(x => x.Name == "innerValue");

            ConstructorInfo[] nonPublicCtors = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            ConstructorInfo currentConstructor = nonPublicCtors[0];
            BlackBoxInt box = (BlackBoxInt)currentConstructor.Invoke(new object[] { 0 });

            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputArgs = input.Split('_');
                object[] parameters = new object[] { int.Parse(inputArgs[1]) };

                switch (inputArgs[0])
                {
                    case "Add":
                        MethodInfo addMethod = methods.First(x => x.Name == "Add");
                        addMethod.Invoke(box, parameters);
                        break;
                    case "Subtract":
                        MethodInfo subtractMethod = methods.First(x => x.Name == "Subtract");
                        subtractMethod.Invoke(box, parameters);
                        break;
                    case "Divide":
                        MethodInfo divideMethod = methods.First(x => x.Name == "Divide");
                        divideMethod.Invoke(box, parameters);
                        break;
                    case "Multiply":
                        MethodInfo multiplyMethod = methods.First(m => m.Name == "Multiply");
                        multiplyMethod.Invoke(box, parameters);
                        break;
                    case "RightShift":
                        MethodInfo rightShiftMethod = methods.First(m => m.Name == "RightShift");
                        rightShiftMethod.Invoke(box, parameters);
                        break;
                    case "LeftShift":
                        MethodInfo leftShiftMethod = methods.First(m => m.Name == "LeftShift");
                        leftShiftMethod.Invoke(box, parameters);
                        break;
                }

                Console.WriteLine(field.GetValue(box));
                input = Console.ReadLine();
            }
        }

    }
}


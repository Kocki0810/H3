using System;
using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace console_calculator
{
    public class Program
    {
        
        public string input;
        string[] parameters;
        float value;
        float first;
        float sec;
        
        static void Main(string[] args)
        {

            Program x = new Program();
            
            Console.WriteLine("Hi welcome to my calculator, write some numbers seperated by spaces and then your addition \nExample 2 + 2");

            x.input = Console.ReadLine();
            
            //Console.WriteLine(x.Calculate(x.input));
            Console.ReadKey();
        }
        public string Calculate(string input)
        {
            parameters = input.Split(' ');
            first = Convert.ToInt32(parameters[0]);
            sec = Convert.ToInt32(parameters[2]);

            switch (parameters[1])
            {
                case "+":
                    value = first + sec;
                    break;
                case "-":
                    value = first - sec;
                    break;
                case "*":
                    value = first * sec;
                    break;
                case "/":
                    if (sec != 0 || first != 0)
                    {
                        value = first / sec;
                    }
                    else
                    {
                        return "Cannot divide by 0";
                    }
                    break;
                default:
                    value = first + sec;
                    break;
            }


            return value.ToString();
        }

    }
}

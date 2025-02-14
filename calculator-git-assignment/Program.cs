using System.Text.RegularExpressions;

namespace calculator_git_assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new();
            program.Start();
        }

        private void Start()
        {
            Console.WriteLine("Hello test");
            string input = string.Empty;

            do
            {
                Console.WriteLine("What do you want to calculate?");
                input = Console.ReadLine().Replace(" ", "");
                Match match = Regex.Match(input, @"(\d+)([+\-*/])(\d+)");

                if (match.Success)
                {
                    int a = int.Parse(match.Groups[1].Value);
                    string operation = match.Groups[2].Value;
                    int b = int.Parse(match.Groups[3].Value);

                    Calculate(operation, a, b);
                }

            } while (input != "stop");
        }

        private void Calculate(string operation, double a, double b)
        {
            Calculator calculator = new();
            switch (operation)
            {
                case "+":
                    calculator.Add(a, b);
                    break;
                case "-":
                    calculator.Subtract(a, b);
                    break;
                case "*":
                    calculator.Multiply(a, b);
                    break;
                case "/":
                    calculator.Divide(a, b);
                    break;
                default:
                    Console.WriteLine("Invalid operation");
                    break;
            }
        }
    }
}
using System;

namespace BasicCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple Arithmetic Calculator");

            while (true)
            {
                double num1 = ReadNumber("Enter First Number:");
                string op = ReadOperator("Enter Operator (+, -, *, /):");
                double num2 = ReadNumber("Enter Second Number:");
                //Result and result validation.
                double result = 0;
                bool valid = true;

                if (op == "+")
                    result = num1 + num2;
                else if (op == "-")
                    result = num1 - num2;
                else if (op == "*")
                    result = num1 * num2;
                else if (op == "/")
                {
                    if (num2 == 0)
                    {
                        Console.WriteLine("Error: Cannot divide by zero.");
                        valid = false;
                    }
                    else
                        result = num1 / num2;
                }
                else
                {
                    Console.WriteLine("Invalid operator.");
                    valid = false;
                }

                if (valid)
                    Console.WriteLine($"Result: {result}");

                Console.WriteLine("Do you want to perform another calculation? (y/n)");
                if (Console.ReadLine().Trim().ToLower() != "y")
                    break;
            }

            Console.WriteLine("Goodbye!");
        }

        static double ReadNumber(string prompt)
        {
            double number;
            while (true)
            {
                Console.WriteLine(prompt);
                if (double.TryParse(Console.ReadLine(), out number))
                    return number;
                Console.WriteLine("Invalid number. Please try again.");
            }
        }

        static string ReadOperator(string prompt)
        {
            string[] validOps = { "+", "-", "*", "/" };
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (Array.Exists(validOps, op => op == input))
                    return input;
                Console.WriteLine("Invalid operator. Please enter one of +, -, *, /.");
            }
        }
    }
}

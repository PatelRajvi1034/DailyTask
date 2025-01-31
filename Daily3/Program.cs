using System;

namespace DelegateExample
{
    // Define a delegate that takes two integers and returns an integer
    public delegate int OperationDelegate(int num1, int num2);

    class Program
    {
        // Method to add two numbers
        static int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        // Method to subtract two numbers
        static int Subtract(int num1, int num2)
        {
            return num1 - num2;
        }

        // Method to multiply two numbers
        static int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }

        static void Main(string[] args)
        {
            // Create a delegate instance
            OperationDelegate operationDelegate;

            Console.WriteLine("Select an operation:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Multiply");

            // Get user's choice
            int choice = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the first number:");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second number:");
            int num2 = int.Parse(Console.ReadLine());

            // Based on user choice, assign the appropriate method to the delegate
            switch (choice)
            {
                case 1:
                    operationDelegate = Add;
                    break;
                case 2:
                    operationDelegate = Subtract;
                    break;
                case 3:
                    operationDelegate = Multiply;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    return;
            }

            // Invoke the delegate to perform the operation
            int result = operationDelegate(num1, num2);

            // Output the result
            Console.WriteLine($"The result is: {result}");
        }
    }
}

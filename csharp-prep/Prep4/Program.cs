using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int userNumber = 1; 
        while (userNumber != 0)
        {
            Console.Write("Enter a number (0 to quit): ");

            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);

            // Only add the number to the list if it is not 0
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // Compute the sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        // Compute the average
        float average = (float)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Find the maximum number in the list
        int max = int.MinValue;
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The maximum number is: {max}");

        // Find the smallest positive number closest to zero
        int closestPositive = int.MaxValue;
        foreach (int number in numbers)
        {
            if (number > 0 && number < closestPositive)
            {
                closestPositive = number;
            }
        }

        if (closestPositive == int.MaxValue)
        {
            Console.WriteLine("No positive numbers were entered.");
        }
        else
        {
            Console.WriteLine($"The smallest positive number closest to zero is: {closestPositive}");
        }

        // Sort the list
        numbers.Sort();

        // Display the sorted list
        Console.WriteLine("Sorted list:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}

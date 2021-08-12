using System;
using System.IO;

namespace Day1
{
    class Hello {         
        static void Main()
        {
            string text = @"input.txt";                                       //put contents of the file in a string 
            string[] lines = File.ReadAllLines(text);                         // array of strings
            
            int[] numbers = Array.ConvertAll(lines, s => int.Parse(s));       // convert to ints
            int length = numbers.Length;                                      //get the number of numbers in the array

            for (int i = 0; i < length; i++) 
            {
                for (int j = 0; j < length; j++)
                {
                    int sum = numbers[i] + numbers[j];
                    if(sum == 2020)
                    {
                        int product = numbers[i] * numbers[j];
                        
                        Console.WriteLine($"The product is {product} and the numbers that sum to 2020 are");
                        Console.WriteLine(numbers[i]);
                        Console.WriteLine(" and ");
                        Console.WriteLine(numbers[j]);
                    }

                }
            }
        }
    }
}
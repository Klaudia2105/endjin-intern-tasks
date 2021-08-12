using System;
using System.IO;
using System.Linq;

namespace Day1
{
    class Part2 {         
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
                    for (int z = 0; z < length; z++)
                    {
                        int sum = numbers[i] + numbers[j] + numbers[z];
                        if(sum == 2020)
                        {
                            int product = numbers[i] * numbers[j] * numbers[z];
                            
                            Console.WriteLine($"The product is {product} and the numbers that sum to 2020 are");
                            Console.WriteLine(numbers[i]);
                            Console.WriteLine(" and ");
                            Console.WriteLine(numbers[j]);
                            Console.WriteLine(" and ");
                            Console.WriteLine(numbers[z]);
                            return;
                        }
                    }

                }
            }
        }

        static void newMain()
        {
            string text = @"input.txt";                                       //put contents of the file in a string 
            string[] lines = File.ReadAllLines(text);                         // array of strings
            
            int[] numbers = Array.ConvertAll(lines, s => int.Parse(s));       // convert to ints
            int length = numbers.Length;                                      //get the number of numbers in the array

            var result = 
                from i in Enumerable.Range(0, length)
                from j in Enumerable.Range(0, length)
                from z in Enumerable.Range(0, length)
                let sum = numbers[i] + numbers[j] + numbers[z]
                where sum == 2020
                select (i: numbers[i], j: numbers[j], z: numbers[z]);
            var match = result.First();
            int product2 = match.i * match.j * match.z;
            Console.WriteLine($"The product is {product2} and the numbers that sum to 2020 are {match}");

        }
    }
}
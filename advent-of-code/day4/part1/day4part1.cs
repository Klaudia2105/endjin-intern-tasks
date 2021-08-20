using System;
using System.IO;

namespace day3part1
{
    class Hello {         
        static void Main()
        {
            string text = @"input.txt";                       //open the file
            string[] lines = File.ReadAllLines(text);         //store contents in an array of strings
            
            int number_of_lines = lines.Length;              //get the number of lines in the array of strings including the empty lines

            int passport_number = GetNumberOfPassports(number_of_lines, lines);  //find number of passports
            
            string[] passport = new string[passport_number];
            int[] indices = new int[passport_number];
            
            int j = 0;
            for(int i = 0; i < number_of_lines; i++) 
            {
                if (lines[i] == "")  
                {   
                    indices[j] = i;  //get the indices of lines that are empty
                    j++;
                }
            }
            for(int i = 0; i < indices[0]; i++) //passport[0] = lines[0] + lines[1] + lines[2];
            {
                passport[0] = passport[0] + " " + lines[i]; //get the first passport
            }
            Console.WriteLine(passport[0]);
            
            int b = 1;       //passport[1] = lines[4] + lines[5] + lines[6] + lines[7]
            for(int i = 1; i < passport_number - 1; i++)
            {
                for(int z = indices[b-1]; z < indices[b]; z++)  //get the rest of the passports except the last one because there is no empty line at the end of the text file
                {
                    passport[b] = passport[b] + " " + lines[z+1];    
                }
                Console.WriteLine(" ");
                Console.WriteLine(passport[b]);
                b++;
            }
            for(int i = number_of_lines - 2; i < number_of_lines; i++)   //get the last passport
            {
                passport[indices.Length - 1] = passport[indices.Length - 1] + " " + lines[i];
            }
            Console.WriteLine(" ");
            Console.WriteLine(passport[indices.Length - 1]);

            int count = 0;

            for(int i = 0; i < passport_number; i++)  //check if each passport contains all required fields
            {
                bool valid = passport[i].Contains("byr") && 
                             passport[i].Contains("iyr") && 
                             passport[i].Contains("eyr") &&
                             passport[i].Contains("hgt") &&
                             passport[i].Contains("hcl") &&
                             passport[i].Contains("ecl") &&
                             passport[i].Contains("pid");
                if(valid)
                {
                    count++;
                }
            }   
            Console.WriteLine(count); //print how many valid passports there are
        }


        static public int GetNumberOfPassports(int number_of_lines, string[] lines)  //takes in the array of lines and the number of lines
        {
            int passport_number = 0;
            for(int i = 0; i < number_of_lines; i++)
            {
                if (lines[i] == "")               //checks how many empty lines there are which indicates the number of passports
                {   
                    passport_number++;
                }
            }
            return passport_number + 1; //plus one because after the last empty line there is another passport
        }

    }
}
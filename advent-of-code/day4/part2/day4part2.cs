using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace day3part1
{
    class Hello {         
        static void Main()
        {
            Debug.Assert(ValidateField("byr", "200") == false);
            Debug.Assert(ValidateField("byr", "20103") == false);

            Debug.Assert(ValidateField("byr", "1920") == true);

            Debug.Assert(ValidateField("byr", "2002") == true);
            Debug.Assert(ValidateField("byr", "2003") == false);
            Debug.Assert(ValidateField("hgt", "60in") == true);
            Debug.Assert(ValidateField("hgt", "190cm") == true);
            Debug.Assert(ValidateField("hgt", "190in") == false);
            Debug.Assert(ValidateField("hgt", "190") == false);





            string text = @"input.txt";                       //open the file
            string[] lines = File.ReadAllLines(text);         //store contents in an array of strings
            
            int number_of_lines = lines.Length;

            int passport_number = GetNumberOfPassports(number_of_lines, lines);
            
            string[] passport = new string[passport_number];
            int[] indeces = new int[passport_number];
            
            int j = 0;
            for(int i = 0; i < number_of_lines; i++) 
            {
                if (lines[i] == "")  
                {   
                    indeces[j] = i;  //get the indeces of lines that are empty
                    j++;
                }
            }
            for(int i = 0; i < indeces[0]; i++) //passport[0] = lines[0] + lines[1] + lines[2];
            {
                passport[0] = passport[0] + " " + lines[i]; //get the first passport
            }
            //Console.WriteLine(passport[0]);
            
            int b = 1;       //passport[1] = lines[4] + lines[5] + lines[6] + lines[7]
            for(int i = 1; i < passport_number - 1; i++)
            {
                for(int z = indeces[b-1]; z < indeces[b]; z++)  //get the rest of the passports except the last one because there is no empty line at the end of the text file
                {
                    passport[b] = passport[b] + " " + lines[z+1];    
                }
                //Console.WriteLine(" ");
                //Console.WriteLine(passport[b]);
                b++;
            }
            for(int i = number_of_lines - 2; i < number_of_lines; i++)   //get the last passport
            {
                passport[indeces.Length - 1] = passport[indeces.Length - 1] + " " + lines[i];
            }
            //Console.WriteLine(" ");
            // Console.WriteLine(passport[indeces.Length - 1]);

            int count = 0;

            for(int i = 0; i < passport_number; i++)  //check if each passport contains all reuired fields
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
            // Console.WriteLine(count); //print how many valid passports there are

            string[] fields = passport[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);  
            
            var fieldsByName = fields.ToDictionary(
                field => field.Substring(0, 3),
                field => field.Substring(4));

            string byr = fieldsByName["byr"];
            
            //Console.WriteLine(byr);
           
        }

        static bool ValidateField(string type, string value)
        {

            return type switch
            {
                "byr" => ValidateByr(value),
                "hgt" => ValidateHgt(value),
                _ => throw new ArgumentException("unsupported field type: " + type)
            };

            bool ValidateByr(string value)
            {
                if(value.Length != 4)
                {
                
                    return false;
                }
                return IsIntInRange(value, 1920, 2002);
                
            }
            bool ValidateHgt(string value)
            {
                if(value.EndsWith("in"))
                {
                    return IsIntInRange(value[..^2], 59, 76);
                }
                else if(value.EndsWith("cm"))
                {
                    return IsIntInRange(value[..^2], 150, 193); // page 246 in Ian's book
                }
                return false;
            }

            bool IsIntInRange(string value, int inclusiveMinimum, int inclusiveMaximum)
            {
                return int.TryParse(value, out int intValue) && intValue >= inclusiveMinimum && intValue <= inclusiveMaximum;
            }

        }


        static public int GetNumberOfPassports(int number_of_lines, string[] lines)
        {
            int passport_number = 0;
            for(int i = 0; i < number_of_lines; i++)
            {
                if (lines[i] == "") 
                {   
                    passport_number++;
                }
            }
            return passport_number + 1; //plus one because after the last empty line there is another passport
        }

    }
}
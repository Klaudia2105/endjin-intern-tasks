using System;
using System.IO;
using System.Linq;

namespace day7part1
{
    class Program {         
        static void Main()
        {   
            string text = @"input.txt";                       //open the file
            string[] lines = File.ReadAllLines(text);         //store contents in an array of strings

            string[] outer_bag = new string[lines.Length];
            string[] outer_bag_valid = new string[lines.Length];
            int count = 0;
            string[] words = new string[30];

            for (int i = 0; i < lines.Length; i++)
            {
                words = lines[i].Split(' '); 
                outer_bag[i] = words[0] + " " + words[1]; //the first 2 words are the colour of the outer bag
                if(lines[i].Contains("shiny gold") && outer_bag[i] != "shiny gold") //if the line contains "shiny gold" and the outer bag is not shiny gold 
                {
                    outer_bag_valid[count] = outer_bag[i];  //make the outer bag valid 
                    count++; 
                                  
                }
            }  
            for (int j = 0; j < lines.Length; j++)
            {
                words = lines[j].Split(' '); //split each line into words again
                for(int z = 0; z < 5; z++)
                {
                    if(lines[j].Contains(outer_bag_valid[z]) && outer_bag[j] != outer_bag_valid[z])
                    {
                        outer_bag_valid[count] = outer_bag[j];
                        count++;
                    }
                }
            }  
            for (int j = 0; j < lines.Length; j++)
            {
                words = lines[j].Split(' '); //split each line into words again
                for(int z = 5; z < 26; z++)
                {
                    if(lines[j].Contains(outer_bag_valid[z]) && outer_bag[j] != outer_bag_valid[z])
                    {
                        outer_bag_valid[count] = outer_bag[j];
                        count++;
                    }
                }
            }
            for (int j = 0; j < lines.Length; j++)
            {
                words = lines[j].Split(' '); //split each line into words again
                for(int z = 26; z < 62; z++)
                {
                    if(lines[j].Contains(outer_bag_valid[z]) && outer_bag[j] != outer_bag_valid[z])
                    {
                        outer_bag_valid[count] = outer_bag[j];
                        count++;
                    }
                }
            }
            for (int j = 0; j < lines.Length; j++)
            {
                words = lines[j].Split(' '); //split each line into words again
                for(int z = 62; z < 130; z++)
                {
                    if(lines[j].Contains(outer_bag_valid[z]) && outer_bag[j] != outer_bag_valid[z])
                    {
                        outer_bag_valid[count] = outer_bag[j];
                        count++;
                    }
                }
            }
            for (int j = 0; j < lines.Length; j++)
            {
                words = lines[j].Split(' '); //split each line into words again
                for(int z = 130; z < 236; z++)
                {
                    if(lines[j].Contains(outer_bag_valid[z]) && outer_bag[j] != outer_bag_valid[z])
                    {
                        outer_bag_valid[count] = outer_bag[j];
                        count++;
                    }
                }
            }
            for (int j = 0; j < lines.Length; j++)
            {
                words = lines[j].Split(' '); //split each line into words again
                for(int z = 236; z < 353; z++)
                {
                    if(lines[j].Contains(outer_bag_valid[z]) && outer_bag[j] != outer_bag_valid[z])
                    {
                        outer_bag_valid[count] = outer_bag[j];
                        count++;
                    }
                }
            }
            for (int j = 0; j < lines.Length; j++)
            {
                words = lines[j].Split(' '); //split each line into words again
                for(int z = 353; z < 432; z++)
                {
                    if(lines[j].Contains(outer_bag_valid[z]) && outer_bag[j] != outer_bag_valid[z])
                    {
                        outer_bag_valid[count] = outer_bag[j];
                        count++;
                    }
                }
            }
            for (int j = 0; j < lines.Length; j++)
            {
                words = lines[j].Split(' '); //split each line into words again
                for(int z = 432; z < 472; z++)
                {
                    if(lines[j].Contains(outer_bag_valid[z]) && outer_bag[j] != outer_bag_valid[z])
                    {
                        outer_bag_valid[count] = outer_bag[j];
                        count++;
                    }
                }
            }
            for (int j = 0; j < lines.Length; j++)
            {
                words = lines[j].Split(' '); //split each line into words again
                for(int z = 472; z < 484; z++)
                {
                    if(lines[j].Contains(outer_bag_valid[z]) && outer_bag[j] != outer_bag_valid[z])
                    {
                        outer_bag_valid[count] = outer_bag[j];
                        count++;
                    }
                }
            }
            string other_file = @"output_so_far.txt";
            using (StreamWriter output = new StreamWriter(other_file)) //write to output.txt
            {
                foreach (string s in outer_bag_valid)
                {
                    output.WriteLine(s);
                }
            }

            var final = outer_bag_valid.Distinct();  // in the result, discard colours that repeat
            foreach (string s in final)
            {
                System.Console.WriteLine(s);
            }

            string file = @"output.txt";

            using (StreamWriter outputFile = new StreamWriter(file)) //write to output.txt
            {
                foreach (string s in final)
                {
                    outputFile.WriteLine(s);
                }
            }
        }
    }
}

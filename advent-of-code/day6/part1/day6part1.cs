using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace day6part1
{
    class Hello {         
        static void Main()
        {   
            string text = @"input.txt";                       //open the file
            string[] lines = File.ReadAllLines(text);         //store contents in an array of strings
            
            int number_of_lines = lines.Length;          //get number of lines
            int number_of_groups = GetNumberOfGroups(number_of_lines, lines);
            string[] group = new string[number_of_groups];  //each member of the array is a whole group
            int[] indices = new int[number_of_groups + 1];  //plus 1 because there is one empty line more than the number of groups - the one at the end

            int a = 0;    
            for(int i = 0; i < number_of_lines; i++) //get the indices of lines that are empty
            {
                if (lines[i] == "")  
                {   
                    indices[a] = i;  
                    a++;
                }
            }
            for(int i = 0; i < number_of_groups; i++) //get each group's answer into separate string group[]
            {
                for(int z = indices[i]; z < indices[i+1]; z++) //put strings in the group until the next empty line
                {
                    group[i] += lines[z+1];    
                }
                // Console.WriteLine(group[i]);
                // Console.WriteLine(" ");
            }
            int count_yes = 0;
            for (int j = 0; j < number_of_groups; j++)  //check each group, i.e. each string
            {
                for (char i = 'a'; i <= 'z'; i++)   //check if it contains each letter
                {
                    if (group[j].Contains(i))
                    {
                        count_yes++;      //increase count if the group contains the letter
                    }
                }
            }
            System.Console.WriteLine(count_yes); //print the answer
        }

        static public int GetNumberOfGroups(int number_of_lines, string[] lines)  //takes in the array of lines and the number of lines
        {
            int group_number = 0;
            for(int i = 0; i < number_of_lines; i++)
            {
                if (lines[i] == "")               //checks how many empty lines there are which indicates the number of groups
                {   
                    group_number++;
                }
            }
            return group_number - 1;
        }
    }
}
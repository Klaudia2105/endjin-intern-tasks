using System;
using System.IO;

namespace day6part2
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
                    group[i] += lines[z+1] + " ";  
                }
            }
            int count_yes = 0;
            for (int j = 0; j < number_of_groups; j++)
            {
                string[] member = group[j].Split(' ', StringSplitOptions.RemoveEmptyEntries);  //split a group into seperate strings (one member per string)
                    for (char i = 'a'; i <= 'z'; i++)   //check if it contains each letter
                    {
                        int count_members_who_contain_the_letter = 0;   //initialize to 0 every time a new letter is checked
                        foreach (string x in member)                   //check if each string in the member array contains the letter
                        {
                            if (x.Contains(i)) 
                            {
                                count_members_who_contain_the_letter++;  //count is increased every time a string in member[] contains the letter
                            }
                        }
                        if (count_members_who_contain_the_letter == member.Length) //if each member has the letter, the count will be equal to the number of strings in member[]
                        {
                            count_yes++;  //count up when each string in member[j] contains the letter
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
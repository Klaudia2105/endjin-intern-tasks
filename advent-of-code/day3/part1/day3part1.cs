using System;
using System.IO;

namespace day3part1
{
    class Hello {         
        static void Main()
        {
            string text = @"input.txt";                       //open the file
            string[] lines = File.ReadAllLines(text);         //store contents in an array of strings

            //get the number of strings in the array and the length of each string
            int numberOfLines = lines.Length;       // it's 323
            int numberOfChars = lines[0].Length;     //it's 31
            
            int count = 0;
            int i = 3;

            for(int j = 1; j < numberOfLines; j++)       //loop through until the end of the last line
            {
                string line = lines[j];  //get line number j+1
                char check = line[i];     //get char number i+1
                //Console.WriteLine(check); //print the character encountered

                if(check == '#')    // if the character is # 
                {
                    count++;       // increase the counter
                }

                i = i + 3;   //move to the right by 3
                    
                if(i > (numberOfChars - 1)) //if the index is outside the last character in the line
                {
                    i = i - numberOfChars; //go back by the number of characters in the line
                }

                }

                Console.WriteLine(count); // print result
        }
    }
}
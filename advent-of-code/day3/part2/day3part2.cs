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
            
            int startChar = 0; //start from the first character
            
            int toRight1 = 1;
            int toRight2 = 3;
            int toRight3 = 5;
            int toRight4 = 7;
            int toRight5 = 1;

            int down1 = 1;
            int down2 = 2;


            Int64 count1 = Slope(startChar, numberOfLines, lines, numberOfChars, toRight1, down1);
            Int64 count2 = Slope(startChar, numberOfLines, lines, numberOfChars, toRight2, down1);
            Int64 count3 = Slope(startChar, numberOfLines, lines, numberOfChars, toRight3, down1);
            Int64 count4 = Slope(startChar, numberOfLines, lines, numberOfChars, toRight4, down1);
            Int64 count5 = Slope(startChar, numberOfLines, lines, numberOfChars, toRight5, down2);

            Int64 result = count1*count2*count3*count4*count5;  //result is too big so the numbers have to be stored as 64-bit numbers

            Console.WriteLine(count1);
            Console.WriteLine(count2);
            Console.WriteLine(count3);
            Console.WriteLine(count4);
            Console.WriteLine(count5);

            Console.WriteLine(result); // print result
        }

        static public int Slope(int start, int numOfLines, string[] lines, int numOfChars, int toRight, int down)
        {
            int count = 0;
            start = start + toRight;             //we don't check the position we're starting at but on the next one down

            for(int j = down; j < numOfLines; j = j + down)       //loop through until the end of the last line
            {
                if(start > (numOfChars - 1)) //if the index is outside the last character in the line
                {
                    start = start - numOfChars; //go back by the number of characters in the line
                }
                string line = lines[j];  //get line 
                char check = line[start];     //get char number i+1
                //Console.WriteLine(check);
                if(check == '#')    // if the character is # 
                {
                    count++;       // increase the counter
                }

                start = start + toRight;   //move to the right by toRight
                    
            }
            return count;
        }
    }
}
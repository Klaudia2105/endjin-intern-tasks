using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace day2part2
{
    class Hello
    {
        static void Main()
        {
            string text = @"input.txt";                                       //put contents of the file in a string 
            var lines = new List<string>();

            lines = File.ReadLines(text).ToList();                            //put text into a list

            int count = 0;

            for (int i = 0; i < lines.Count; i++)
            {
                string a = lines[i].Split('-')[0];   //get the minimum number
                int min = short.Parse(a);          //convert to int


                int start = lines[i].IndexOf("-") + "-".Length;
                int end = lines[i].IndexOf(" ") - 2;
                string b = lines[i].Substring(start, end);
                int max = short.Parse(b);                    // get the max number

                int space1 = lines[i].IndexOf(" ") + " ".Length;
                string letter = lines[i].Substring(space1, 1);  //get the letter required

                int colon = lines[i].IndexOf(":") + 1;
                string password = lines[i].Substring(colon);  //get passwords

                char theLetter = char.Parse(letter);

                int pos1 = min;
                int pos2 = max;

                bool valid = Other.isValid(password, theLetter, pos1, pos2);

                if (valid)
                {
                    count++;
                }
            }

            Console.WriteLine(count);

        }
    }
    class Other
    {
        public static bool isValid(string password, char theLetter, int pos1, int pos2)
        {
            char letterInPos1 = password[pos1];
            char letterInPos2 = password[pos2];
            
            //if letterFrompassword[pos1] and letterfrompassword[pos2] are both theLetter
            if (letterInPos1 == theLetter && letterInPos2 == theLetter)
            {
                return false;
            }
            //else if letterPos1 xor letterPos2
            else if (letterInPos1 == theLetter ^ letterInPos2 == theLetter)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
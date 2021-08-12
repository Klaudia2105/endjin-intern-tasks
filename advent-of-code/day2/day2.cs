using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Day2
{
    class Hello {         
        static void Main()
        {
            string text = @"input.txt";                                       //put contents of the file in a string 
            var lines = new List<string>();                          

            lines = File.ReadLines(text).ToList();                            //put text into a list

            for(int i = 0; i < lines.Count; i++)                              
            {
                string a = lines[i].Split('-')[0];   //get the minimum number
                int min = Int16.Parse(a);          //convert to int
                

                int start = lines[i].IndexOf("-") + "-".Length;
                int end = lines[i].IndexOf(" ") - 2;
                string b = lines[i].Substring(start, end);
                int max = Int16.Parse(b);                    // get the max number

                int space1 = lines[i].IndexOf(" ") + " ".Length;
                string letter = lines[i].Substring(space1, 1);  //get the letter required

                int colon = lines[i].IndexOf(":") + 1;
                string password = lines[i].Substring(colon);
                Console.WriteLine(password);
                
            }
           
            /*
            for(int i = 0; i < lines.Count; i++)
            {
                int start = lines[i].IndexOf("-");                           // first find the index of your starting point
                
                int end = lines[i].IndexOf("\"", start);                         // then find the index of your ending point
                
                string goods = lines[i].Substring(start, end - start);           // then retrieve that portion of the string
            }*/
        }
    }
}
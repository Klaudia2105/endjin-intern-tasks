using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace day5part1
{
    class Hello {         
        static void Main()
        {   
            string text = @"input.txt";                       //open the file
            string[] lines = File.ReadAllLines(text);         //store contents in an array of strings
            
            int number_of_lines = lines.Length;          //get number of lines
        
            char[] f_or_b = new char[7];
            char[] r_or_l = new char[3];

            double[] id = new double[lines.Length];
            double[] row = new double[lines.Length];
            double[] column = new double[lines.Length];

            //string test = "BBFFBBFRLL";

            for(int j = 0; j < lines.Length; j++)
            {
                double min_row = 0;
                double max_row = 127; 

                double min_column = 0;
                double max_column = 7;

                for(int i = 0; i < 7; i++)  // get the row number
                {
                    f_or_b[i] = lines[j][i]; 
                    //f_or_b[i] = test[i];
                    
                    if(f_or_b[i] == 'F')     // if F take the lower half so min stays the same
                    {
                        max_row = min_row + ((max_row - min_row) / 2);  // max gets updated
                        max_row = Math.Floor(max_row);        //round down
                    }
                    else if(f_or_b[i] == 'B')    //if B take upper half so max stays the same
                    {
                        min_row = min_row + ((max_row - min_row) / 2); //min gets updated
                        min_row = Math.Round(min_row, MidpointRounding.AwayFromZero);       // round up , the second parameter is to make sure it rounds up properly: https://docs.microsoft.com/en-us/dotnet/api/system.math.round?view=net-5.0#midpoint-values-and-rounding-conventions
                    }
                    if(min_row == max_row)
                    {
                        row[j] = min_row;
                    }
                } 

                for(int i = 0; i < 3; i++)
                {
                    r_or_l[i] = lines[j][7+i]; //start from char[7] up to char[9], i.e. last 3 characters

                    if(r_or_l[i] == 'L')     // if L take the lower half so min stays the same
                    {
                        max_column = min_column + ((max_column - min_column) / 2);  // max gets updated
                        max_column = Math.Floor(max_column);        //round down
                    }
                    else if(r_or_l[i] == 'R')    //if R take upper half so max stays the same
                    {
                        min_column = min_column + ((max_column - min_column) / 2); //min gets updated
                        min_column = Math.Round(min_column, MidpointRounding.AwayFromZero);         // round up , the second parameter is to make sure it rounds up properly: https://docs.microsoft.com/en-us/dotnet/api/system.math.round?view=net-5.0#midpoint-values-and-rounding-conventions
                    }
                    if(min_column == max_column)
                    {
                        column[j] = min_column;
                    }
                }
                id[j] = (row[j] * 8) + column[j];
            }
            for(int j = 0; j < 930; j++) //max id is 930 so check missing id's from 0 to 930
            {
                if(id.Contains(j) == false)
                {
                    System.Console.WriteLine(j); //print the ID number if it doesn't exist in the id[] array
                }
            }

        }
    }
}
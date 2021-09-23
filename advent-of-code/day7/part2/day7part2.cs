using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace day7part1
{
    class Program2
    {
        static void Main()
        {
            string text = @"input.txt";                       //open the file
            string[] lines = File.ReadAllLines(text);         //store contents in an array of strings

            Dictionary<string, string[]> bagContains = new Dictionary<string, string[]>();
            
            foreach (string line in lines)
            {
                //vibrant lavender bags contain 1 shiny coral bag, 4 dotted purple bags.
                string[] words = line.Split(' ');
                string outer_bag = words[0] + " " + words[1]; //the first 2 words are the colour of the outer bag
                string inner_bag_list = line.Split(" contain ")[1].Trim('.');   //get the string after contain and trim the dot at the end
                string[] inner_bags = inner_bag_list.Split(", ").Select(inner_bag_text =>   // split the list by comas
                {
                    int colour_index = inner_bag_text.IndexOf(" ") - 1;
                    int bag_index = inner_bag_text.IndexOf(" bag");
                    return inner_bag_text.Substring(colour_index, bag_index - colour_index); // get the string starting at colour index and for the length of second argument
                }).ToArray();
                bagContains.Add(outer_bag, inner_bags); //add outer and inner bags to dictionary
            }

            //shiny gold bags contain 4 posh coral bags, 2 clear violet bags
            string next_bag_to_check = "shiny gold";
            int result = CheckBagsInside(next_bag_to_check);
            System.Console.WriteLine(result);

            //shiny gold bags contain 4 posh coral bags, 2 clear violet bags.
            //posh coral bags contain 2 plaid olive bags, 2 shiny coral bags, 1 vibrant olive bag, 1 clear red bag.
            //clear violet bags contain no other bags.
            int CheckBagsInside(string bag_to_check)
            {
                int count = 0;
                string[] bags_inside = bagContains[bag_to_check];  //outer_bag is the key and inner bags are values
                int number = 0;
                
                foreach (string bag_inside in bags_inside)
                {
                    string next_bag_to_check = bag_inside.Substring(2); //have to trim the number to check for the colour key in the dictionary later

                    if (bag_inside != "o other" && next_bag_to_check != "other")
                    {
                        string colour_number = bag_inside.Substring(0, 1);  //get the number of bags in that colour
                        bool check_if_number = Int32.TryParse(colour_number, out number);
                        if (check_if_number == true)
                        {      
                            count = count + number;
                            
                            int bags_inside_this_bag = CheckBagsInside(next_bag_to_check);
                            count = count + bags_inside_this_bag * number;
                    
                        }
                    }
                }
                return count;
            }
        }
    }
}
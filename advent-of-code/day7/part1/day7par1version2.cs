using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

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
                    int colour_index = inner_bag_text.IndexOf(" ") + 1;
                    int bag_index = inner_bag_text.IndexOf(" bag");
                    return inner_bag_text.Substring(colour_index, bag_index - colour_index); // get the string starting at colour index and for the length of second argument
                }).ToArray();
                bagContains.Add(outer_bag, inner_bags); //add outer and inner bags to dictionary
            }
            Dictionary<string, string[]> bagContainedBy = 
                (from kv in bagContains                       //get all entries 
                 let outer_colour = kv.Key              //
                 from inner_colour in kv.Value
                 let x = new {inner_colour, outer_colour}
                 group x by x.inner_colour).ToDictionary(g => g.Key, g => g.Select(x => x.outer_colour).ToArray());

            void VisitContainingBags(string bag_colour, Action<string> bag)
            {
                if (!bagContainedBy.TryGetValue(bag_colour, out string[] containing_colours)) 
                {
                    return;    //exit if false
                }
                foreach (string containing_colour in containing_colours)
                {
                    bag (containing_colour);
                    VisitContainingBags(containing_colour, bag);
                }
            }
            HashSet<string> distinct_colours = new HashSet<string>();  //gets rid of repetition 
            VisitContainingBags("shiny gold", colour => distinct_colours.Add(colour)); //check for shiny gold and then every other outer colour related to it
            System.Console.WriteLine(distinct_colours.Count);
        }
    }
}
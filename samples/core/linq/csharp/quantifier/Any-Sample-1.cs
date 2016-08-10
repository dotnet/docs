using System;
using System.Linq;

namespace Quantifier
{
    public class AnySample1
    {
        //This sample uses Any to determine if any of the words in the array contain the substring 'ei'.
        //
        //Outputs:
        //There is a word in the list that contains 'ei': True
        public static void Example()
        {
            string[] words = {"believe", "relief", "receipt", "field"};

            bool iAfterE = words.Any(w => w.Contains("ei"));

            Console.WriteLine("There is a word in the list that contains 'ei': {0}", iAfterE);
        }
    }
}
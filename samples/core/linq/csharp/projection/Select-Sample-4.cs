using System.Linq;
using System;
namespace Projection
{
    public class SelectSample4
    {
        //This sample uses select and query syntax to produce a sequence of the uppercase and lowercase versions
        //of each word in the original array.
        //
        //Outputs:
        // Uppercase: APPLE, Lowercase: apple
        // Uppercase: BLUEBERRY, Lowercase: blueberry
        // Uppercase: CHERRY, Lowercase: cherry
        public static void QuerySyntaxExample()
        {
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            var upperLowerWords =
                from w in words
                select new { Upper = w.ToUpper(), Lower = w.ToLower() };

            foreach (var ul in upperLowerWords)
            {
                Console.WriteLine($"Uppercase: {ul.Upper}, Lowercase: {ul.Lower}");
            }
        }

        //This sample uses select and method syntax to produce a sequence of the uppercase and lowercase versions
        //of each word in the original array.
        //
        //Outputs:
        // Uppercase: APPLE, Lowercase: apple
        // Uppercase: BLUEBERRY, Lowercase: blueberry
        // Uppercase: CHERRY, Lowercase: cherry
        public static void MethodSyntaxExample()
        {
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            var upperLowerWords = words.Select(w => new {Upper = w.ToUpper(), Lower = w.ToLower()});

            foreach (var ul in upperLowerWords)
            {
                Console.WriteLine($"Uppercase: {ul.Upper}, Lowercase: {ul.Lower}");
            }
        }
    }
}
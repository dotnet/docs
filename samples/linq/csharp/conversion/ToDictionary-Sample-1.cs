using System;
using System.Linq;

namespace Conversion
{
    public static class ToDictionarySample1
    {
        //This sample uses ToDictionary to immediately evaluate a sequence and a 
        //related key expression into a dictionary.
        //
        //Output:
        //Bob's score: 40 
        public static void Example()
        {
            var scoreRecords = new[]
            {
                new {Name = "Alice", Score = 50},
                new {Name = "Bob", Score = 40},
                new {Name = "Cathy", Score = 45}
            };

            var scoreRecordsDict = scoreRecords.ToDictionary(sr => sr.Name);

            Console.WriteLine($"Bob's score: {scoreRecordsDict["Bob"].Score}");
        }
    }
}
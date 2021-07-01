using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace JsonNodeAverageGradeExample
{
    public class Program
    {
        public static DateTime[] DatesAvailable { get; set; }

        public static void Main()
        {
            string jsonString =
 @"{
  ""Class Name"": ""Science"",
  ""Teacher\u0027s Name"": ""Jane"",
  ""Semester"": ""2019-01-01"",
  ""Students"": [
    {
      ""Name"": ""John"",
      ""Grade"": 94.3
    },
    {
      ""Name"": ""James"",
      ""Grade"": 81.0
    },
    {
      ""Name"": ""Julia"",
      ""Grade"": 91.9
    },
    {
      ""Name"": ""Jessica"",
      ""Grade"": 72.4
    },
    {
      ""Name"": ""Johnathan""
    }
  ],
  ""Final"": true
}
";
            double sum = 0;
            int count = 0;

            JsonNode document = JsonNode.Parse(jsonString);

            JsonNode root = document.Root;
            JsonArray studentsArray = root["Students"].AsArray();

            count = studentsArray.Count;

            foreach (JsonNode student in studentsArray)
            {
                if (student["Grade"] is JsonNode gradeNode)
                {
                    sum += (double)gradeNode;
                }
                else
                {
                    sum += 70;
                }
            }

            double average = sum / count;
            Console.WriteLine($"Average grade : {average}");
        }
    }
}
// output:
//Average grade : 81.92

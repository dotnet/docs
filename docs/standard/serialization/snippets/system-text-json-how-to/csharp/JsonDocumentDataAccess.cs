﻿using System;
using System.IO;
using System.Text.Json;

namespace SystemTextJsonSamples
{
    public class JsonDocumentDataAccess
    {
        public static void Run()
        {
            string inputFileName = "Grades.json";
            string jsonString = File.ReadAllText(inputFileName);

            AverageGrades(jsonString);
            AverageGrades_Alternative(jsonString);
        }
        private static void AverageGrades(string jsonString)
        {
            // <AverageGrades1>
            double sum = 0;
            int count = 0;

            using (JsonDocument document = JsonDocument.Parse(jsonString))
            {
                JsonElement root = document.RootElement;
                JsonElement studentsElement = root.GetProperty("Students");
                foreach (JsonElement student in studentsElement.EnumerateArray())
                {
                    if (student.TryGetProperty("Grade", out JsonElement gradeElement))
                    {
                        sum += gradeElement.GetDouble();
                    }
                    else
                    {
                        sum += 70;
                    }
                    count++;
                }
            }

            double average = sum / count;
            Console.WriteLine($"Average grade : {average}");
            // </AverageGrades1>
        }
        private static void AverageGrades_Alternative(string jsonString)
        {
            // <AverageGrades2>
            double sum = 0;
            int count = 0;

            using (JsonDocument document = JsonDocument.Parse(jsonString))
            {
                JsonElement root = document.RootElement;
                JsonElement studentsElement = root.GetProperty("Students");

                count = studentsElement.GetArrayLength();

                foreach (JsonElement student in studentsElement.EnumerateArray())
                {
                    if (student.TryGetProperty("Grade", out JsonElement gradeElement))
                    {
                        sum += gradeElement.GetDouble();
                    }
                    else
                    {
                        sum += 70;
                    }
                }
            }

            double average = sum / count;
            Console.WriteLine($"Average grade : {average}");
            // </AverageGrades2>
        }
    }
}

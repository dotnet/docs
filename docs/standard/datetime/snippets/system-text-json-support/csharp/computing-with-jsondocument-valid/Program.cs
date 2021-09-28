using System;
using System.Text.Json;

public class Example
{
    private static double ComputeAverageTemperatures(string json)
    {
        JsonDocumentOptions options = new JsonDocumentOptions
        {
            AllowTrailingCommas = true
        };

        using (JsonDocument document = JsonDocument.Parse(json, options))
        {
            int sumOfAllTemperatures = 0;
            int count = 0;

            foreach (JsonElement element in document.RootElement.EnumerateArray())
            {
                DateTimeOffset date = element.GetProperty("date").GetDateTimeOffset();

                if (date.DayOfWeek == DayOfWeek.Monday)
                {
                    int temp = element.GetProperty("temp").GetInt32();
                    sumOfAllTemperatures += temp;
                    count++;
                }
            }

            double averageTemp = (double)sumOfAllTemperatures / count;
            return averageTemp;
        }
    }

    public static void Main(string[] args)
    {
        string json =
                @"[" +
                    @"{" +
                        @"""date"": ""2013-01-07T00:00:00Z""," +
                        @"""temp"": 23," +
                    @"}," +
                    @"{" +
                        @"""date"": ""2013-01-08T00:00:00Z""," +
                        @"""temp"": 28," +
                    @"}," +
                    @"{" +
                        @"""date"": ""2013-01-14T00:00:00Z""," +
                        @"""temp"": 8," +
                    @"}," +
                @"]";

        Console.WriteLine(ComputeAverageTemperatures(json));
    }
}

// The example displays the following output:
// 15.5

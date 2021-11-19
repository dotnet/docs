using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SystemTextJsonSamples
{
    // <WF>
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
    }
    // </WF>

    // <WFWithReqPptyConverterAttr>
    [JsonConverter(typeof(WeatherForecastRequiredPropertyConverterForAttributeRegistration))]
    public class WeatherForecastWithRequiredPropertyConverterAttribute
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
    }

    public class WeatherForecastWithoutRequiredPropertyConverterAttribute :
        WeatherForecastWithRequiredPropertyConverterAttribute
    {
    }
    // </WFWithReqPptyConverterAttr>

    // <WFWithPrevious>
    public class WeatherForecastWithPrevious
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
        public WeatherForecast PreviousForecast { get; set; }
    }
    // </WFWithPrevious>

    // <WFWithPreviousAsObject>
    public class WeatherForecastWithPreviousAsObject
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
        public object PreviousForecast { get; set; }
    }
    // </WFWithPreviousAsObject>

    // <WFWithLong>
    public class WeatherForecastWithLong
    {
        public DateTimeOffset Date { get; set; }
        [JsonConverter(typeof(LongToStringConverter))]
        public long TemperatureCelsius { get; set; }
        public string Summary { get; set; }
    }
    // </WFWithLong>

    // <WFWithDefault>
    public class WeatherForecastWithDefault
    {
        public WeatherForecastWithDefault()
        {
            Date = DateTimeOffset.Parse("2001-01-01");
            Summary = "No summary";
        }
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
    }
    // </WFWithDefault>

    // <WFWithExtensionData>
    public class WeatherForecastWithExtensionData
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
        [JsonExtensionData]
        public Dictionary<string, JsonElement> ExtensionData { get; set; }
    }
    // </WFWithExtensionData>

    // <WFWithConverterAttribute>
    public class WeatherForecastWithConverterAttribute
    {
        [JsonConverter(typeof(DateTimeOffsetJsonConverter))]
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
    }
    // </WFWithConverterAttribute>

    // <WFWithPropertyNameAttribute>
    public class WeatherForecastWithPropertyNameAttribute
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
        [JsonPropertyName("Wind")]
        public int WindSpeed { get; set; }
    }
    // </WFWithPropertyNameAttribute>

    // <WFWithIgnoreAttribute>
    public class WeatherForecastWithIgnoreAttribute
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        [JsonIgnore]
        public string Summary { get; set; }
    }
    // </WFWithIgnoreAttribute>

    // <WFDerived>
    public class WeatherForecastDerived : WeatherForecast
    {
        public int WindSpeed { get; set; }
    }
    // </WFDerived>

    // <WFWithObjectProperties>
    public class WeatherForecastWithObjectProperties
    {
        public object Date { get; set; }
        public object TemperatureCelsius { get; set; }
        public object Summary { get; set; }
    }
    // </WFWithObjectProperties>

    // <WFWithROProperty>
    public class WeatherForecastWithROProperty
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
        public int WindSpeedReadOnly { get; private set; } = 35;
    }
    // </WFWithROProperty>

    // <WFWithTemperatureStruct>
    public class WeatherForecastWithTemperatureStruct
    {
        public DateTimeOffset Date { get; set; }
        public Temperature TemperatureCelsius { get; set; }
        public string Summary { get; set; }
    }
    // </WFWithTemperatureStruct>

    // <WFWithDictionary>
    public class WeatherForecastWithDictionary
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
        public Dictionary<string, int> TemperatureRanges { get; set; }
    }
    // </WFWithDictionary>

    // <WFWithEnumDictionary>
    public class WeatherForecastWithEnumDictionary
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
        public Dictionary<SummaryWordsEnum, int> TemperatureRanges { get; set; }
    }

    public enum SummaryWordsEnum
    {
        Cold, Hot
    }
    // </WFWithEnumDictionary>

    // <WFWithPOCOs>
    public class WeatherForecastWithPOCOs
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
        public string SummaryField;
        public IList<DateTimeOffset> DatesAvailable { get; set; }
        public Dictionary<string, HighLowTemps> TemperatureRanges { get; set; }
        public string[] SummaryWords { get; set; }
    }

    public class HighLowTemps
    {
        public int High { get; set; }
        public int Low { get; set; }
    }
    // </WFWithPOCOs>

    // <WFWithEnum>
    public class WeatherForecastWithEnum
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public Summary Summary { get; set; }
    }

    public enum Summary
    {
        Cold, Cool, Warm, Hot
    }
    // </WFWithEnum>

    public static class WeatherForecastExtensions
    {
        public static void DisplayPropertyValues(this WeatherForecast wf)
        {
            Utilities.DisplayPropertyValues(wf);
            Console.WriteLine();
        }

        public static void DisplayPropertyValues(this WeatherForecastWithRequiredPropertyConverterAttribute wf)
        {
            Utilities.DisplayPropertyValues(wf);
            Console.WriteLine();
        }

        public static void DisplayPropertyValues(this WeatherForecastWithLong wf)
        {
            Utilities.DisplayPropertyValues(wf);
            Console.WriteLine();
        }

        public static void DisplayPropertyValues(this WeatherForecastWithDefault wf)
        {
            Utilities.DisplayPropertyValues(wf);
            Console.WriteLine();
        }

        public static void DisplayPropertyValues(this WeatherForecastWithROProperty wf)
        {
            Utilities.DisplayPropertyValues(wf);
            Console.WriteLine();
        }

        public static void DisplayPropertyValues(this WeatherForecastWithPropertyNameAttribute wf)
        {
            Utilities.DisplayPropertyValues(wf);
            Console.WriteLine();
        }

        public static void DisplayPropertyValues(this WeatherForecastWithIgnoreAttribute wf)
        {
            Utilities.DisplayPropertyValues(wf);
            Console.WriteLine();
        }

        public static void DisplayPropertyValues(this WeatherForecastWithEnum wf)
        {
            Utilities.DisplayPropertyValues(wf);
            Console.WriteLine();
        }

        public static void DisplayPropertyValues(this WeatherForecastWithExtensionData wf)
        {
            Console.WriteLine($"Date: {wf.Date}");
            Console.WriteLine($"TemperatureCelsius: {wf.TemperatureCelsius}");
            Console.WriteLine($"Summary: {wf.Summary}");
            Console.WriteLine($"ExtensionData:");
            if (wf.ExtensionData != null)
            {
                foreach (KeyValuePair<string, JsonElement> kvp in wf.ExtensionData)
                {
                    Console.WriteLine($"  {kvp.Key} {kvp.Value}");
                }
            }
            Console.WriteLine();
        }

        public static void DisplayPropertyValues(this WeatherForecastDerived wf)
        {
            Utilities.DisplayPropertyValues(wf);
            Console.WriteLine();
        }

        public static void DisplayPropertyValues(this WeatherForecastWithConverterAttribute wf)
        {
            Utilities.DisplayPropertyValues(wf);
            Console.WriteLine();
        }

        public static void DisplayPropertyValues(this WeatherForecastWithObjectProperties wf)
        {
            Utilities.DisplayPropertyValues(wf);
            Console.WriteLine();
        }

        public static void DisplayPropertyValues(this WeatherForecastWithTemperatureStruct wf)
        {
            Utilities.DisplayPropertyValues(wf);
            Console.WriteLine();
        }

        public static void DisplayPropertyValues(this WeatherForecastWithEnumDictionary wf)
        {
            Utilities.DisplayPropertyValues(wf);
            Console.Write($"TemperatureRanges:\n");
            foreach (KeyValuePair<SummaryWordsEnum, int> kvp in wf.TemperatureRanges)
            {
                Console.Write($"  {kvp.Key}, {kvp.Value}\n");
            }
            Console.WriteLine();
        }

        public static void DisplayPropertyValues(this WeatherForecastWithDictionary wf)
        {
            Utilities.DisplayPropertyValues(wf);
            Console.Write($"TemperatureRanges:\n");
            foreach (KeyValuePair<string, int> kvp in wf.TemperatureRanges)
            {
                Console.Write($"  {kvp.Key}, {kvp.Value}\n");
            }
            Console.WriteLine();
        }

        public static void DisplayPropertyValues(this WeatherForecastWithPOCOs wf)
        {
            Utilities.DisplayPropertyValues(wf);
            Console.WriteLine($"SummaryField: {wf.SummaryField}");
            Console.WriteLine($"TemperatureRanges:");
            foreach (KeyValuePair<string, HighLowTemps> kvp in wf.TemperatureRanges)
            {
                Console.WriteLine($"  {kvp.Key} {kvp.Value.Low} {kvp.Value.High}");
            }
            Console.WriteLine($"SummaryWords:");
            foreach (string word in wf.SummaryWords)
            {
                Console.WriteLine($"  {word}");
            }
            Console.WriteLine();
        }
    }

    public static class WeatherForecastFactories
    {
        public static WeatherForecast CreateWeatherForecast()
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };
            return weatherForecast;
        }

        public static WeatherForecastWithRequiredPropertyConverterAttribute CreateWeatherForecastAttrReg()
        {
            var weatherForecast = new WeatherForecastWithRequiredPropertyConverterAttribute
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };
            return weatherForecast;
        }

        public static WeatherForecastWithPrevious CreateWeatherForecastWithPrevious()
        {
            var weatherForecast = new WeatherForecastWithPrevious
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot",
                PreviousForecast = CreateWeatherForecastDerived()
            };
            return weatherForecast;
        }

        public static WeatherForecastWithPreviousAsObject CreateWeatherForecastWithPreviousAsObject()
        {
            var weatherForecast = new WeatherForecastWithPreviousAsObject
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot",
                PreviousForecast = CreateWeatherForecastDerived()
            };
            return weatherForecast;
        }

        public static WeatherForecastWithLong CreateWeatherForecastWithLong()
        {
            var weatherForecast = new WeatherForecastWithLong
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };
            return weatherForecast;
        }

        public static WeatherForecastWithROProperty CreateWeatherForecastWithROProperty()
        {
            var weatherForecast = new WeatherForecastWithROProperty
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };
            return weatherForecast;
        }

        public static WeatherForecastWithEnum CreateWeatherForecastWithEnum()
        {
            var weatherForecast = new WeatherForecastWithEnum
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = Summary.Hot
            };
            return weatherForecast;
        }

        public static WeatherForecastWithPropertyNameAttribute CreateWeatherForecastWithPropertyNameAttribute()
        {
            var weatherForecast = new WeatherForecastWithPropertyNameAttribute
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot",
                WindSpeed = 35
            };
            return weatherForecast;
        }

        public static WeatherForecastWithIgnoreAttribute CreateWeatherForecastWithIgnoreAttribute()
        {
            var weatherForecast = new WeatherForecastWithIgnoreAttribute
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };
            return weatherForecast;
        }

        public static WeatherForecast CreateWeatherForecastCyrillic()
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "жарко"
            };
            return weatherForecast;
        }

        public static WeatherForecastWithExtensionData CreateWeatherForecastWithExtensionData()
        {
            var weatherForecast = new WeatherForecastWithExtensionData
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };
            return weatherForecast;
        }

        public static WeatherForecastDerived CreateWeatherForecastDerived()
        {
            var weatherForecast = new WeatherForecastDerived
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot",
                WindSpeed = 35
            };
            return weatherForecast;
        }

        public static WeatherForecastWithConverterAttribute CreateWeatherForecastWithConverterAttribute()
        {
            var weatherForecast = new WeatherForecastWithConverterAttribute
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };
            return weatherForecast;
        }

        public static WeatherForecastWithObjectProperties CreateWeatherForecastWithObjectProperties()
        {
            var weatherForecast = new WeatherForecastWithObjectProperties
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };
            return weatherForecast;
        }

        public static WeatherForecastWithTemperatureStruct CreateWeatherForecastWithTemperatureStruct()
        {
            var weatherForecast = new WeatherForecastWithTemperatureStruct
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = new Temperature(25, true),
                Summary = "Hot"
            };
            return weatherForecast;
        }

        public static WeatherForecastWithEnumDictionary CreateWeatherForecastWithEnumDictionary()
        {
            var weatherForecast = new WeatherForecastWithEnumDictionary
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot",
                TemperatureRanges = new Dictionary<SummaryWordsEnum, int> { { SummaryWordsEnum.Cold, 20 }, { SummaryWordsEnum.Hot, 40 } }
            };
            return weatherForecast;
        }

        public static WeatherForecastWithDictionary CreateWeatherForecastWithDictionary()
        {
            var weatherForecast = new WeatherForecastWithDictionary
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot",
                TemperatureRanges = new Dictionary<string, int> { { "ColdMinTemp", 20 }, { "HotMinTemp", 40 } }
            };
            return weatherForecast;
        }

        public static WeatherForecastWithPOCOs CreateWeatherForecastWithPOCOs()
        {
            var weatherForecast = new WeatherForecastWithPOCOs
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot",
                SummaryField = "Hot",
                DatesAvailable = new List<DateTimeOffset>() { DateTime.Parse("2019-08-01"), DateTime.Parse("2019-08-02") },
                TemperatureRanges = new Dictionary<string, HighLowTemps>
                    {
                        { "Cold", new HighLowTemps { High = 20, Low = -10 } },
                        { "Hot", new HighLowTemps { High = 60 , Low = 20 } }
                    },
                SummaryWords = new string[] { "Cool", "Windy", "Humid" }
            };
            return weatherForecast;
        }
    }
}

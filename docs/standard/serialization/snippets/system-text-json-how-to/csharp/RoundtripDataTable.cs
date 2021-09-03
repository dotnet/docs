using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RoundtripDataTable
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
    }

    public static class Program
    {
        public static List<WeatherForecast> weatherForecasts = new()
        {
            new WeatherForecast { Date = new DateTime(2019, 8, 1), TemperatureCelsius = 25, Summary = "Hot" },
            new WeatherForecast { Date = new DateTime(2019, 8, 2), TemperatureCelsius = 20, Summary = "Warm" },
            new WeatherForecast { Date = new DateTime(2019, 8, 3), TemperatureCelsius = 10, Summary = "Cold" }
        };

        public static void Main()
        {
            // Register the custom converter
            JsonSerializerOptions options = new() 
                { Converters = { new DataTableJsonConverter() }, WriteIndented = true }; 

            // Serialize a List<T> object and display the JSON
            string jsonString = JsonSerializer.Serialize(weatherForecasts, options);
            Console.WriteLine(jsonString);

            // Deserialize to a DataTable
            var weatherForecastTable = JsonSerializer.Deserialize<DataTable>(jsonString, options);

            // Display the DataTable contents
            foreach (DataRow row in weatherForecastTable.Rows)
            {
                for (int i = 0; i < weatherForecastTable.Columns.Count; i++)
                {
                    Console.Write($"{row[i]} ");
                }
                Console.WriteLine();
            }

            // Serialize the DataTable and display the JSON
            jsonString = JsonSerializer.Serialize(weatherForecastTable, options);
            Console.WriteLine(jsonString);
        }
    }

    public class DataTableJsonConverter : JsonConverter<DataTable>
    {
        public override DataTable Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDoc = JsonDocument.ParseValue(ref reader);
            JsonElement rootElement = jsonDoc.RootElement;
            DataTable dataTable = rootElement.JsonElementToDataTable();
            return dataTable;
        }

        public override void Write(Utf8JsonWriter jsonWriter, DataTable value, JsonSerializerOptions options)
        {
            jsonWriter.WriteStartArray();
            foreach (DataRow dr in value.Rows)
            {
                jsonWriter.WriteStartObject();
                foreach (DataColumn col in value.Columns)
                {
                    string key = col.ColumnName.Trim();

                    Action<string> action = GetWriteAction(dr, col, jsonWriter);
                    action.Invoke(key);

                    static Action<string> GetWriteAction(
                        DataRow row, DataColumn column, Utf8JsonWriter writer) => row[column] switch
                        {
                            // bool
                            bool value => key => writer.WriteBoolean(key, value),

                            // numbers
                            byte value => key => writer.WriteNumber(key, value),
                            sbyte value => key => writer.WriteNumber(key, value),
                            decimal value => key => writer.WriteNumber(key, value),
                            double value => key => writer.WriteNumber(key, value),
                            float value => key => writer.WriteNumber(key, value),
                            short value => key => writer.WriteNumber(key, value),
                            int value => key => writer.WriteNumber(key, value),
                            ushort value => key => writer.WriteNumber(key, value),
                            uint value => key => writer.WriteNumber(key, value),
                            ulong value => key => writer.WriteNumber(key, value),

                            // strings
                            DateTime value => key => writer.WriteString(key, value),
                            Guid value => key => writer.WriteString(key, value),

                            _ => key => writer.WriteString(key, row[column].ToString())
                        };
                }
                jsonWriter.WriteEndObject();
            }
            jsonWriter.WriteEndArray();
        }
    }
    
    public static class Extensions
    {
        public static DataTable JsonElementToDataTable(this JsonElement dataRoot)
        {
            var dataTable = new DataTable();
            bool firstPass = true;
            foreach (JsonElement element in dataRoot.EnumerateArray())
            {
                DataRow row = dataTable.NewRow();
                dataTable.Rows.Add(row);
                foreach (JsonProperty col in element.EnumerateObject())
                {
                    if (firstPass)
                    {
                        JsonElement colValue = col.Value;
                        dataTable.Columns.Add(new DataColumn(col.Name, colValue.ValueKind.ValueKindToType(colValue.ToString())));
                    }
                    row[col.Name] = col.Value.JsonElementToTypedValue();
                }
                firstPass = false;
            }

            return dataTable;
        }

        private static Type ValueKindToType(this JsonValueKind valueKind, string value)
        {
            switch (valueKind)
            {
                case JsonValueKind.String:
                    return typeof(System.String);
                case JsonValueKind.Number:
                    if (Int64.TryParse(value, out Int64 intValue))
                    {
                        return typeof(System.Int64);
                    }
                    else
                    {
                        return typeof(System.Double);
                    }
                case JsonValueKind.True:
                case JsonValueKind.False:
                    return typeof(System.Boolean);
                case JsonValueKind.Undefined:
                    throw new NotSupportedException();
                case JsonValueKind.Object:
                    return typeof(System.Object);
                case JsonValueKind.Array:
                    return typeof(System.Array);
                case JsonValueKind.Null:
                    throw new NotSupportedException();
                default:
                    return typeof(System.Object);
            }
        }

        private static object JsonElementToTypedValue(this JsonElement jsonElement)
        {
            switch (jsonElement.ValueKind)
            {
                case JsonValueKind.Object:
                case JsonValueKind.Array:
                    throw new NotSupportedException();
                case JsonValueKind.String:
                    if (jsonElement.TryGetGuid(out Guid guidValue))
                    {
                        return guidValue;
                    }
                    else
                    {
                        if (jsonElement.TryGetDateTime(out DateTime datetime))
                        {
                            // If an offset was provided, use DateTimeOffset.
                            if (datetime.Kind == DateTimeKind.Local)
                            {
                                if (jsonElement.TryGetDateTimeOffset(out DateTimeOffset datetimeOffset))
                                {
                                    return datetimeOffset;
                                }
                            }
                            return datetime;
                        }
                        return jsonElement.ToString();
                    }
                case JsonValueKind.Number:
                    if (jsonElement.TryGetInt64(out long longValue))
                    {
                        return longValue;
                    }
                    else
                    {
                        return jsonElement.GetDouble();
                    }
                case JsonValueKind.True:
                case JsonValueKind.False:
                    return jsonElement.GetBoolean();
                case JsonValueKind.Undefined:
                case JsonValueKind.Null:
                    return null;
                default:
                    return jsonElement.ToString();
            }
        }
    }
}
//output:
//[
//  {
//    "Date": "2019-08-01T00:00:00",
//    "TemperatureCelsius": 25,
//    "Summary": "Hot"
//  },
//  {
//    "Date": "2019-08-02T00:00:00",
//    "TemperatureCelsius": 20,
//    "Summary": "Warm"
//  },
//  {
//    "Date": "2019-08-03T00:00:00",
//    "TemperatureCelsius": 10,
//    "Summary": "Cold"
//  }
//]
//8/1/2019 12:00:00 AM 25 Hot
//8/2/2019 12:00:00 AM 20 Warm
//8/3/2019 12:00:00 AM 10 Cold
//[
//  {
//    "Date": "8/1/2019 12:00:00 AM",
//    "TemperatureCelsius": 25,
//    "Summary": "Hot"
//  },
//  {
//    "Date": "8/2/2019 12:00:00 AM",
//    "TemperatureCelsius": 20,
//    "Summary": "Warm"
//  },
//  {
//    "Date": "8/3/2019 12:00:00 AM",
//    "TemperatureCelsius": 10,
//    "Summary": "Cold"
//  }
//]

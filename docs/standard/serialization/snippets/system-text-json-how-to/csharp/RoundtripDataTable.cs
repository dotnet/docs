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
        public static List<WeatherForecast> weatherForecasts = new List<WeatherForecast>()
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

                    if (col.DataType == typeof(bool))
                    {
                        jsonWriter.WriteBoolean(key, (bool)dr[col]);
                    }
                    else if (col.DataType == typeof(byte))
                    {
                        jsonWriter.WriteNumber(key, (byte)dr[col]);
                    }
                    else if (col.DataType == typeof(sbyte))
                    {
                        jsonWriter.WriteNumber(key, (sbyte)dr[col]);
                    }
                    else if (col.DataType == typeof(decimal))
                    {
                        jsonWriter.WriteNumber(key, (decimal)dr[col]);
                    }
                    else if (col.DataType == typeof(double))
                    {
                        jsonWriter.WriteNumber(key, (double)dr[col]);
                    }
                    else if (col.DataType == typeof(float))
                    {
                        jsonWriter.WriteNumber(key, (float)dr[col]);
                    }
                    else if (col.DataType == typeof(short))
                    {
                        jsonWriter.WriteNumber(key, (short)dr[col]);
                    }
                    else if (col.DataType == typeof(int))
                    {
                        jsonWriter.WriteNumber(key, (int)dr[col]);
                    }
                    else if (col.DataType == typeof(long))
                    {
                        jsonWriter.WriteNumber(key, (long)dr[col]);
                    }
                    else if (col.DataType == typeof(ushort))
                    {
                        jsonWriter.WriteNumber(key, (ushort)dr[col]);
                    }
                    else if (col.DataType == typeof(uint))
                    {
                        jsonWriter.WriteNumber(key, (uint)dr[col]);
                    }
                    else if (col.DataType == typeof(ulong))
                    {
                        jsonWriter.WriteNumber(key, (ulong)dr[col]);
                    }
                    else if (col.DataType == typeof(DateTime))
                    {
                        jsonWriter.WriteString(key, (DateTime)dr[col]);
                    }
                    else if (col.DataType == typeof(Guid))
                    {
                        jsonWriter.WriteString(key, (Guid)dr[col]);
                    }
                    else
                    {
                        jsonWriter.WriteString(key, dr[col].ToString());
                    }
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

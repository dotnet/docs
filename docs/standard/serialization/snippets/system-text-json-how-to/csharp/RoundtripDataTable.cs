using System;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RoundtripDataTable
{
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
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
            // Serialize a List<T> object and display the JSON
            string jsonString = JsonSerializer.Serialize(
                weatherForecasts,
                new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine(jsonString);

            // Deserialize to a DataTable
            var deserializeOptions = new JsonSerializerOptions();
            deserializeOptions.Converters.Add(new DataTableJsonConverter());
            var weatherForecastTable = JsonSerializer.Deserialize<DataTable>(jsonString, deserializeOptions);

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
            var serializeOptions = new JsonSerializerOptions();
            serializeOptions.WriteIndented = true;
            serializeOptions.Converters.Add(new DataTableJsonConverter());
            jsonString = JsonSerializer.Serialize(weatherForecasts, serializeOptions);
            Console.WriteLine(jsonString);
        }
    }

    public class DataTableJsonConverter : JsonConverter<DataTable>
    {
        public override DataTable Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var jsonDoc = JsonDocument.ParseValue(ref reader);
            var rootElement = jsonDoc.RootElement;
            var dataTable = rootElement.JsonElementToDataTable();
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
                    var key = col.ColumnName.Trim();
                    var valueString = dr[col].ToString();
                    switch (col.DataType.FullName)
                    {
                        case "System.Guid":
                            jsonWriter.WriteString(key, valueString);
                            break;
                        case "System.Char":
                        case "System.String":
                            jsonWriter.WriteString(key, valueString);
                            break;
                        case "System.Boolean":
                            Boolean.TryParse(valueString, out bool boolValue);
                            jsonWriter.WriteBoolean(key, boolValue);
                            break;
                        case "System.DateTime":
                            if (DateTime.TryParse(valueString, out DateTime dateValue))
                            {
                                jsonWriter.WriteString(key, dateValue);
                            }
                            else
                            {
                                jsonWriter.WriteString(key, "");
                            }
                            break;
                        case "System.TimeSpan":
                            if (DateTime.TryParse(valueString, out DateTime timeSpanValue))
                            {
                                jsonWriter.WriteString(key, timeSpanValue.ToString());
                            }
                            else
                            {
                                jsonWriter.WriteString(key, "");
                            }
                            break;
                        case "System.Byte":
                        case "System.SByte":
                        case "System.Decimal":
                        case "System.Double":
                        case "System.Single":
                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                        case "System.UInt16":
                        case "System.UInt32":
                        case "System.UInt64":
                            if (long.TryParse(valueString, out long intValue))
                            {
                                jsonWriter.WriteNumber(key, intValue);
                            }
                            else
                            {
                                double.TryParse(valueString, out double doubleValue);
                                jsonWriter.WriteNumber(key, doubleValue);
                            }
                            break;
                        default:
                            jsonWriter.WriteString(key, valueString);
                            break;
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
            var firstPass = true;
            foreach (var element in dataRoot.EnumerateArray())
            {
                if (firstPass)
                {
                    foreach (var col in element.EnumerateObject())
                    {
                        var colValue = col.Value;
                        dataTable.Columns.Add(new DataColumn(col.Name, colValue.ValueKind.ValueKindToType(colValue.ToString())));
                    }
                    firstPass = false;
                }
                var row = dataTable.NewRow();
                foreach (var col in element.EnumerateObject())
                {
                    row[col.Name] = col.Value.JsonElementToTypedValue();
                }
                dataTable.Rows.Add(row);
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
                    if (Int64.TryParse(value, out var intValue))
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
                    return null;
                case JsonValueKind.Object:
                    return typeof(System.Object);
                case JsonValueKind.Array:
                    return typeof(System.Array);
                case JsonValueKind.Null:
                    return null;
                default:
                    return typeof(System.Object);
            }
        }

        private static object JsonElementToTypedValue(this JsonElement jsonElement)
        {
            switch (jsonElement.ValueKind)
            {
                case JsonValueKind.Object:      // (these need special handling)?
                case JsonValueKind.Array:
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
//    "Date": "2019-08-01T00:00:00-07:00",
//    "TemperatureCelsius": 25,
//    "Summary": "Hot"
//  },
//  {
//    "Date": "2019-08-02T00:00:00-07:00",
//    "TemperatureCelsius": 20,
//    "Summary": "Warm"
//  },
//  {
//    "Date": "2019-08-03T00:00:00-07:00",
//    "TemperatureCelsius": 10,
//    "Summary": "Cold"
//  }
//]
//8/1/2019 12:00:00 AM -07:00 25 Hot
//8/2/2019 12:00:00 AM -07:00 20 Warm
//8/3/2019 12:00:00 AM -07:00 10 Cold
//[
//  {
//    "Date": "2019-08-01T00:00:00-07:00",
//    "TemperatureCelsius": 25,
//    "Summary": "Hot"
//  },
//  {
//    "Date": "2019-08-02T00:00:00-07:00",
//    "TemperatureCelsius": 20,
//    "Summary": "Warm"
//  },
//  {
//    "Date": "2019-08-03T00:00:00-07:00",
//    "TemperatureCelsius": 10,
//    "Summary": "Cold"
//  }
//]

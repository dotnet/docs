---
description: "Learn more about how to deserialize instance data properties. You do this when you want to manually inspect the state of a persisted workflow instance."
title: "How to: Deserialize Instance Data Properties"
ms.date: "10/23/2026"
ai-usage: ai-assisted
---
# How to: Deserialize instance data properties

There might be situations when a user or workflow administrator wants to manually inspect the state of a persisted workflow instance. <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> provides a view on the Instances table that exposes the following four columns:

- ReadWritePrimitiveDataProperties
- WriteOnlyPrimitiveDataProperties
- ReadWriteComplexDataProperties
- WriteOnlyComplexDataProperties

Primitive data properties refer to properties whose .NET types are considered to be "common" (for example, Int32 and String), while complex data properties refer to all other types. An exact enumeration of primitive types is found later in this code example.

*Read/write* properties refer to properties that are returned back to the Workflow Runtime when an instance is loaded. *WriteOnly* properties are written to the database and then never read again.

This example provides code that enables a user to deserialize primitive data properties. Given a byte array read from either the ReadWritePrimitiveDataProperties or WriteOnlyPrimitiveDataProperties column, this code will convert the binary large object (BLOB) into a <xref:System.Collections.Generic.Dictionary`2> of type `<XName, object>` where each key-value pair represents a property name and its corresponding value.

For the SQL queries, install the [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient) NuGet package. The reader runs on modern .NET or .NET Framework 4.6.2 and later. It reads an existing workflow persistence database; it doesn't host Windows Workflow Foundation or change the provider used by <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore>.

Set the `SQL_CONNECTION_STRING` environment variable to a connection string for the persistence database. Microsoft.Data.SqlClient encrypts connections and validates the server certificate by default. For more information, see [Encryption and certificate validation in Microsoft.Data.SqlClient](/sql/connect/ado-net/encryption-and-certificate-validation). For Microsoft Entra ID authentication with Microsoft.Data.SqlClient 7 and later versions, also install [Microsoft.Data.SqlClient.Extensions.Azure](https://www.nuget.org/packages/Microsoft.Data.SqlClient.Extensions.Azure).

[!INCLUDE [managed-identities](../../includes/managed-identities.md)]

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Xml.Linq;
using System.Xml;
using System.Globalization;
using Microsoft.Data.SqlClient;

namespace PropertyReader
{
    class Program
    {
        static readonly string ConnectionString =
            Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING")
            ?? throw new InvalidOperationException("Set SQL_CONNECTION_STRING to the persistence database connection string.");
        static void Main(string[] args)
        {
            string queryString = "SELECT TOP 10 * FROM [System.Activities.DurableInstancing].[Instances]";

            using (SqlConnection connection =
                       new SqlConnection(ConnectionString))
            {
                SqlCommand command =
                    new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                byte encodingOption;

                while (reader.Read())
                {
                    if (reader["ReadWritePrimitiveDataProperties"] != DBNull.Value)
                    {
                        encodingOption = (byte)reader["EncodingOption"];
                        Console.WriteLine("Printing the ReadWritePrimitiveDataProperties of the instance with Id:" + reader["InstanceId"]);
                        foreach (KeyValuePair<XName, object> pair in (Dictionary<XName, object>)ReadDataProperties((byte[])reader["ReadWritePrimitiveDataProperties"], encodingOption))
                        {
                            Console.WriteLine("{0}, {1}" , pair.Key, pair.Value);
                        }
                        Console.WriteLine();
                    }
                    if (reader["WriteOnlyPrimitiveDataProperties"] != DBNull.Value)
                    {
                        encodingOption = (byte)reader["EncodingOption"];
                        Console.WriteLine("Printing the WriteOnlyPrimitiveDataProperties of the instance with Id:" + reader["InstanceId"]);
                        foreach (KeyValuePair<XName, object> pair in (Dictionary<XName, object>)ReadDataProperties((byte[])reader["WriteOnlyPrimitiveDataProperties"], encodingOption))
                        {
                            Console.WriteLine("{0}, {1}", pair.Key, pair.Value);
                        }
                        Console.WriteLine();
                    }
                }

                // Call Close when done reading.
                reader.Close();
            }

            Console.ReadLine();

        }

        static Dictionary<XName, object> ReadDataProperties(byte[] serializedDataProperties, byte encodingOption)
        {
            if (serializedDataProperties != null)
            {
                Dictionary<XName, object> propertyBag = new Dictionary<XName, object>();
                bool isCompressed = (encodingOption == 1);

                using (MemoryStream memoryStream = new MemoryStream(serializedDataProperties))
                {
                    // if the instance state is compressed using GZip algorithm
                    if (isCompressed)
                    {
                        // decompress the data using the GZip
                        using (GZipStream stream = new GZipStream(memoryStream, CompressionMode.Decompress))
                        {
                            // create an XmlReader object and pass it on to the helper method ReadPrimitiveDataProperties
                            using (XmlReader reader = XmlDictionaryReader.CreateBinaryReader(stream, XmlDictionaryReaderQuotas.Max))
                            {
                                // invoke the helper method
                                ReadPrimitiveDataProperties(reader, propertyBag);
                            }
                        }
                    }
                    else
                    {
                        // if the instance data is not compressed
                        // create an XmlReader object and pass it on to the helper method ReadPrimitiveDataProperties
                        using (XmlReader reader = XmlDictionaryReader.CreateBinaryReader(memoryStream, XmlDictionaryReaderQuotas.Max))
                        {
                            // invoke the helper method
                            ReadPrimitiveDataProperties(reader, propertyBag);
                        }
                    }
                    return propertyBag;
                }
            }

            return null;
        }

        // Reads the primitive data properties from the XML stream.
        // Invoked by the ReadDataProperties method.
        static void ReadPrimitiveDataProperties(XmlReader reader, Dictionary<XName, object> propertyBag)
        {
            const string xmlElementName = "Property";

            if (reader.ReadToDescendant(xmlElementName))
            {
                do
                {
                    // get the name of the property
                    reader.MoveToFirstAttribute();
                    string propertyName = reader.Value;

                    // get the type of the property
                    reader.MoveToNextAttribute();
                    PrimitiveType type = (PrimitiveType)Int32.Parse(reader.Value, CultureInfo.InvariantCulture);

                    // get the value of the property
                    reader.MoveToNextAttribute();
                    object propertyValue = ConvertStringToNativeType(reader.Value, type);

                    // add the name and value of the property to the property bag
                    propertyBag.Add(propertyName, propertyValue);
                }

                while (reader.ReadToNextSibling(xmlElementName));
            }
        }

        // Invoked by the ReadPrimitiveDataProperties method.
        // Given a property value as parsed from an XML attribute, and the .NET Type of the Property, recreates the actual property value
        // (e.g. Given a property value of "1" and a PrimitiveType of Int32, this method returns an object of type Int32 with value 1).
        static object ConvertStringToNativeType(string value, PrimitiveType type)
        {
            switch (type)
            {
                case PrimitiveType.Bool:
                    return XmlConvert.ToBoolean(value);
                case PrimitiveType.Byte:
                    return XmlConvert.ToByte(value);
                case PrimitiveType.Char:
                    return XmlConvert.ToChar(value);
                case PrimitiveType.DateTime:
                    return XmlConvert.ToDateTime(value, XmlDateTimeSerializationMode.RoundtripKind);
                case PrimitiveType.DateTimeOffset:
                    return XmlConvert.ToDateTimeOffset(value);
                case PrimitiveType.Decimal:
                    return XmlConvert.ToDecimal(value);
                case PrimitiveType.Double:
                    return XmlConvert.ToDouble(value);
                case PrimitiveType.Float:
                    return float.Parse(value, CultureInfo.InvariantCulture);
                case PrimitiveType.Guid:
                    return XmlConvert.ToGuid(value);
                case PrimitiveType.Int:
                    return XmlConvert.ToInt32(value);
                case PrimitiveType.Long:
                    return XmlConvert.ToInt64(value);
                case PrimitiveType.SByte:
                    return XmlConvert.ToSByte(value);
                case PrimitiveType.Short:
                    return XmlConvert.ToInt16(value);
                case PrimitiveType.String:
                    return value;
                case PrimitiveType.TimeSpan:
                    return XmlConvert.ToTimeSpan(value);
                case PrimitiveType.Type:
                    return Type.GetType(value);
                case PrimitiveType.UInt:
                    return XmlConvert.ToUInt32(value);
                case PrimitiveType.ULong:
                    return XmlConvert.ToUInt64(value);
                case PrimitiveType.Uri:
                    return new Uri(value);
                case PrimitiveType.UShort:
                    return XmlConvert.ToUInt16(value);
                case PrimitiveType.XmlQualifiedName:
                    return new XmlQualifiedName(value);
                case PrimitiveType.Null:
                case PrimitiveType.Unavailable:
                default:
                    return null;
            }
        }

        // .NET Types that SQL Workflow Instance Store considers to be Primitive. Any other .NET type not listed in this enumeration is a "Complex" property.
        enum PrimitiveType
        {
            Bool = 0,
            Byte,
            Char,
            DateTime,
            DateTimeOffset,
            Decimal,
            Double,
            Float,
            Guid,
            Int,
            Null,
            Long,
            SByte,
            Short,
            String,
            TimeSpan,
            Type,
            UInt,
            ULong,
            Uri,
            UShort,
            XmlQualifiedName,
            Unavailable = 99
        }
    }
}
```

This example does not demonstrate how to deserialize complex data properties because that's an unsupported operation.

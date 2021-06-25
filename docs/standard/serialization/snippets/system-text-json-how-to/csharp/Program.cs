using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SystemTextJsonSamples
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("\n============================= Roundtrip to string\n");
            SerializeBasic.Program.Main();
            SerializeWithGenericParameter.Program.Main();
            SerializeWriteIndented.Program.Main();
            SerializeExtra.Program.Main();
            DeserializeExtra.Program.Main();

            Console.WriteLine("\n============================= Roundtrip to UTF-8 byte array\n");
            RoundtripToUtf8Bytes1.Program.Main();
            RoundtripToUtf8Bytes2.Program.Main();
            RoundtripToUtf8Bytes3.Program.Main();

            Console.WriteLine("\n============================= Roundtrip to file\n");
            SerializeToFile.Program.Main();
            DeserializeFromFile.Program.Main();

            Console.WriteLine("\n============================= Roundtrip to file async\n");
            await SerializeToFileAsync.Program.Main();
            await DeserializeFromFileAsync.Program.Main();

            Console.WriteLine("\n============================= Roundtrip camel case property names\n");
            RoundtripCamelCasePropertyNames.Run();

            Console.WriteLine("\n============================= Roundtrip custom property naming policy\n");
            RoundtripPropertyNamingPolicy.Run();

            Console.WriteLine("\n============================= Roundtrip custom property name by attribute\n");
            RoundtripPropertyNamesByAttribute.Run();

            Console.WriteLine("\n============================= Roundtrip extension data\n");
            RoundtripExtensionData.Program.Main();
            RoundtripJsonElement.Program.Main();

            Console.WriteLine("\n============================= Roundtrip enum as string\n");
            RoundtripEnumAsString.Run();

            Console.WriteLine("\n============================= Roundtrip Stack<T>\n");
            RoundtripStackOfT.Run();

            Console.WriteLine("\n============================= Serialize polymorphic\n");
            SerializePolymorphic.Run();

            Console.WriteLine("\n============================= Serialize custom encoding\n");
            SerializeCustomEncoding.Run();

            Console.WriteLine("\n============================= Serialize exclude null value properties\n");
            SerializeExcludeNullValueProperties.Run();

            Console.WriteLine("\n============================= Serialize exclude properties by attribute\n");
            SerializeExcludePropertiesByAttribute.Run();

            Console.WriteLine("\n============================= Serialize exclude read-only properties\n");
            SerializeExcludeReadOnlyProperties.Run();

            Console.WriteLine("\n============================= Serialize camel case Dictionary keys\n");
            SerializeCamelCaseDictionaryKeys.Run();

            Console.WriteLine("\n============================= Deserialize case-insensitive\n");
            DeserializeCaseInsensitive.Run();

            Console.WriteLine("\n============================= Deserialize ignore null\n");
            DeserializeIgnoreNull.Run();

            Console.WriteLine("\n============================= Deserialize trailing commas and comments\n");
            DeserializeCommasComments.Run();

            Console.WriteLine("\n============================= Custom converter registration - Converters collection\n");
            RegisterConverterWithConverterscollection.Run();

            Console.WriteLine("\n============================= Custom converter registration - Converters attribute on property\n");
            RegisterConverterWithAttributeOnProperty.Run();

            Console.WriteLine("\n============================= Custom converter registration - attribute on type\n");
            RegisterConverterWithAttributeOnType.Run();

            Console.WriteLine("\n============================= Custom converter Dictionary with TKey = Enum\n");
            RoundtripDictionaryTkeyEnumTValue.Run();

            Console.WriteLine("\n============================= Custom converter Polymorphic\n");
            RoundtripPolymorphic.Run();

            Console.WriteLine("\n============================= Custom converter inferred types to Object\n");
            DeserializeInferredTypesToObject.Run();

            Console.WriteLine("\n============================= Custom converter long to string\n");
            RoundtripLongToString.Run();

            Console.WriteLine("\n============================= Callbacks\n");
            RoundtripCallbacks.Run();

            Console.WriteLine("\n============================= Required property converter\n");
            DeserializeRequiredProperty.Run();

            Console.WriteLine("\n============================= Required property converter using attribute registration\n");
            DeserializeRequiredPropertyUsingAttributeRegistration.Run();

            Console.WriteLine("\n============================= Null value to nonnullable type\n");
            DeserializeNullToNonnullableType.Run();

            Console.WriteLine("\n============================= Immutable struct\n");
            RoundtripImmutableStruct.Run();

            Console.WriteLine("\n============================= Runtime property exclusion\n");
            SerializeRuntimePropertyExclusion.Run();

            Console.WriteLine("\n============================= JsonDocument data access\n");
            JsonDocumentDataAccess.Run();

            Console.WriteLine("\n============================= JsonDocument write JSON\n");
            JsonDocumentWriteJson.Run();

            Console.WriteLine("\n============================= Utf8Reader from file\n");
            Utf8ReaderFromFile.Run();

            string jsonString = File.ReadAllText("Universities.json");
            ValueTextEqualsExample.Run(Encoding.UTF8.GetBytes(jsonString));

            Console.WriteLine("\n============================= Utf8Reader from byte array\n");
            Utf8ReaderFromBytes.Run();

            Console.WriteLine("\n============================= Utf8Reader partial read\n");
            Utf8ReaderPartialRead.Run();

            Console.WriteLine("\n============================= Utf8Writer to Stream\n");
            Utf8WriterToStream.Run();

            Console.WriteLine("\n============================= Roundtrip to DataTable\n");
            RoundtripDataTable.Program.Main();


        }
    }
}

Imports System.IO
Imports System.Text

Namespace SystemTextJsonSamples
    ''<Obsolete("Ignore", False)>
    Module Program
        Sub Main(args As String())
            Console.WriteLine("Hello World!")
            Call Main1(args).Wait()
        End Sub

        Private Async Function Main1(args As String()) As Task
            Console.WriteLine(vbCrLf & "============================= Roundtrip to string" & vbCrLf)
            RoundtripToString.Run()

            Console.WriteLine(vbCrLf & "============================= Roundtrip to UTF-8 byte array" & vbCrLf)
            RoundtripToUtf8.Run()

            Console.WriteLine(vbCrLf & "============================= Roundtrip to file" & vbCrLf)
            RoundtripToFile.Run()

            Console.WriteLine(vbCrLf & "============================= Roundtrip to file async" & vbCrLf)
            Await RoundtripToFileAsync.RunAsync()

            Console.WriteLine(vbCrLf & "============================= Roundtrip camel case property names" & vbCrLf)
            RoundtripCamelCasePropertyNames.Run()

            Console.WriteLine(vbCrLf & "============================= Roundtrip custom property naming policy" & vbCrLf)
            RoundtripPropertyNamingPolicy.Run()

            Console.WriteLine(vbCrLf & "============================= Roundtrip custom property name by attribute" & vbCrLf)
            RoundtripPropertyNamesByAttribute.Run()

            Console.WriteLine(vbCrLf & "============================= Roundtrip extension data" & vbCrLf)
            RoundtripExtensionData.Run()

            Console.WriteLine(vbCrLf & "============================= Roundtrip enum as string" & vbCrLf)
            RoundtripEnumAsString.Run()

            'Console.WriteLine(vbCrLf & "============================= Roundtrip Stack<T>" & vbCrLf)
            'RoundtripStackOfT.Run()

            Console.WriteLine(vbCrLf & "============================= Serialize polymorphic" & vbCrLf)
            SerializePolymorphic.Run()

            Console.WriteLine(vbCrLf & "============================= Serialize custom encoding" & vbCrLf)
            SerializeCustomEncoding.Run()

            Console.WriteLine(vbCrLf & "============================= Serialize exclude null value properties" & vbCrLf)
            SerializeExcludeNullValueProperties.Run()

            Console.WriteLine(vbCrLf & "============================= Serialize exclude properties by attribute" & vbCrLf)
            SerializeExcludePropertiesByAttribute.Run()

            Console.WriteLine(vbCrLf & "============================= Serialize exclude read-only properties" & vbCrLf)
            SerializeExcludeReadOnlyProperties.Run()

            Console.WriteLine(vbCrLf & "============================= Serialize camel case Dictionary keys" & vbCrLf)
            SerializeCamelCaseDictionaryKeys.Run()

            Console.WriteLine(vbCrLf & "============================= Deserialize case-insensitive" & vbCrLf)
            DeserializeCaseInsensitive.Run()

            Console.WriteLine(vbCrLf & "============================= Deserialize ignore null" & vbCrLf)
            DeserializeIgnoreNull.Run()

            Console.WriteLine(vbCrLf & "============================= Deserialize trailing commas and comments" & vbCrLf)
            DeserializeCommasComments.Run()

            'Console.WriteLine(vbCrLf & "============================= Custom converter registration - Converters collection" & vbCrLf)
            'RegisterConverterWithConverterscollection.Run()

            'Console.WriteLine(vbCrLf & "============================= Custom converter registration - Converters attribute on property" & vbCrLf)
            'RegisterConverterWithAttributeOnProperty.Run()

            'Console.WriteLine(vbCrLf & "============================= Custom converter registration - attribute on type" & vbCrLf)
            'RegisterConverterWithAttributeOnType.Run()

            'Console.WriteLine(vbCrLf & "============================= Custom converter Dictionary with TKey = Enum" & vbCrLf)
            'RoundtripDictionaryTkeyEnumTValue.Run()

            'Console.WriteLine(vbCrLf & "============================= Custom converter Polymorphic" & vbCrLf)
            'RoundtripPolymorphic.Run()

            'Console.WriteLine(vbCrLf & "============================= Custom converter inferred types to Object" & vbCrLf)
            'DeserializeInferredTypesToObject.Run()

            'Console.WriteLine(vbCrLf & "============================= Custom converter long to string" & vbCrLf)
            'RoundtripLongToString.Run()

            'Console.WriteLine(vbCrLf & "============================= Callbacks" & vbCrLf)
            'RoundtripCallbacks.Run()

            'Console.WriteLine(vbCrLf & "============================= Required property converter" & vbCrLf)
            'DeserializeRequiredProperty.Run()

            'Console.WriteLine(vbCrLf & "============================= Required property converter using attribute registration" & vbCrLf)
            'DeserializeRequiredPropertyUsingAttributeRegistration.Run()

            'Console.WriteLine(vbCrLf & "============================= Null value to nonnullable type" & vbCrLf)
            'DeserializeNullToNonnullableType.Run()

            'Console.WriteLine(vbCrLf & "============================= Immutable struct" & vbCrLf)
            'RoundtripImmutableStruct.Run()

            'Console.WriteLine(vbCrLf & "============================= Runtime property exclusion" & vbCrLf)
            'SerializeRuntimePropertyExclusion.Run()

            Console.WriteLine(vbCrLf & "============================= JsonDocument data access" & vbCrLf)
            JsonDocumentDataAccess.Run()

            Console.WriteLine(vbCrLf & "============================= JsonDocument write JSON" & vbCrLf)
            JsonDocumentWriteJson.Run()

            'Console.WriteLine(vbCrLf & "============================= Utf8Reader from file" & vbCrLf)
            'Utf8ReaderFromFile.Run()

            'Dim jsonString As String = File.ReadAllText("Universities.json")
            'ValueTextEqualsExample.Run(Encoding.UTF8.GetBytes(jsonString))

            'Console.WriteLine(vbCrLf & "============================= Utf8Reader from byte array" & vbCrLf)
            'Utf8ReaderFromBytes.Run()

            'Console.WriteLine(vbCrLf & "============================= Utf8Reader partial read" & vbCrLf)
            'Utf8ReaderPartialRead.Run()

            Console.WriteLine(vbCrLf & "============================= Utf8Writer to Stream" & vbCrLf)
            Utf8WriterToStream.Run()
        End Function
    End Module
End Namespace

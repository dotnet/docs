Namespace SystemTextJsonSamples
    Module Program

        Sub Main(args As String())
            Console.WriteLine("Hello World!")
            Call Main1(args).Wait()
        End Sub

        Private Async Function Main1(_0 As String()) As Task
            Console.WriteLine(vbCrLf & "============================= Roundtrip to DateOnly and TimeOnly props" & vbCrLf)
            RoundTripDateOnly.Run()

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

            Console.WriteLine(vbCrLf & "============================= JsonDocument data access" & vbCrLf)
            JsonDocumentDataAccess.Run()

            Console.WriteLine(vbCrLf & "============================= JsonDocument write JSON" & vbCrLf)
            JsonDocumentWriteJson.Run()

            Console.WriteLine(vbCrLf & "============================= Utf8Writer to Stream" & vbCrLf)
            Utf8WriterToStream.Run()
        End Function

    End Module
End Namespace

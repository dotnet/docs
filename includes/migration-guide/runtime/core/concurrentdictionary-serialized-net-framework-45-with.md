### A ConcurrentDictionary serialized in .NET Framework 4.5 with NetDataContractSerializer cannot be deserialized by .NET Framework 4.5.1 or 4.5.2

|   |   |
|---|---|
|Details|Due to internal changes to the type, <xref:System.Collections.Concurrent.ConcurrentDictionary%602> objects that are serialized with the .NET Framework 4.5 using the <xref:System.Runtime.Serialization.NetDataContractSerializer?displayProperty=name> cannot be deserialized in the .NET Framework 4.5.1 or in the .NET Framework 4.5.2.Note that moving in the other direction (serializing with the .NET Framework 4.5.x and deserializing with the .NET Framework 4.5) works. Similarly, all 4.x cross-version serialization works with the .NET Framework 4.6.Serializing and deserializing with a single version of the .NET Framework is not affected.|
|Suggestion|If it is necessary to serialize and deserialize a <xref:System.Collections.Concurrent.ConcurrentDictionary%602?displayProperty=name> between the .NET Framework 4.5 and .NET Framework 4.5.1/4.5.2, an alternate serializer like the <xref:System.Runtime.Serialization.DataContractSerializer?displayProperty=name> or <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter?displayProperty=name> serializer should be used instead of the <xref:System.Runtime.Serialization.NetDataContractSerializer?displayProperty=name>.Alternatively, because this issue is addressed in the .NET Framework 4.6, it may be solved by upgrading to that version of the .NET Framework.|
|Scope|Minor|
|Version|4.5.1|
|Type|Runtime|

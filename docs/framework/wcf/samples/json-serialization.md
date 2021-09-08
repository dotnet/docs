---
description: "Learn more about: DataContractJsonSerializer sample"
title: "DataContractJsonSerializer sample"
ms.date: "03/30/2017"
ms.assetid: 3c2c4747-7510-4bdf-b4fe-64f98428ef4a
---
# DataContractJsonSerializer sample

This article describes the [JsonSerialization sample](https://github.com/dotnet/samples/tree/main/framework/wcf/Basic/Ajax/JsonSerialization).

> [!NOTE]
> This sample is for <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer>. For most scenarios that involve serializing and deserializing JSON, we recommend the APIs in the [System.Text.Json namespace](../../../standard/serialization/system-text-json-overview.md).

<xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> supports the same types as <xref:System.Runtime.Serialization.DataContractSerializer>. The JSON data format is especially useful when writing Asynchronous JavaScript and XML (AJAX)-style Web applications. AJAX support in Windows Communication Foundation (WCF) is optimized for use with ASP.NET AJAX through the ScriptManager control. For examples of how to use Windows Communication Foundation (WCF) with ASP.NET AJAX, see the [AJAX Samples](ajax.md).

The set-up procedure and build instructions for this sample are located at the end of this topic.

The sample uses a `Person` data contract to demonstrate serialization and deserialization.

```csharp
[DataContract]
class Person
{
    [DataMember]
    internal string name;

    [DataMember]
    internal int age;
}
```

To serialize an instance of the `Person` type to JSON, create the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> first and use the `WriteObject` method to write JSON data to a stream.

```csharp
Person p = new Person();
//Set up Person object...
MemoryStream stream1 = new MemoryStream();
DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Person));
ser.WriteObject(stream1, p);
```

The memory stream contains valid JSON data.

```json
{"age":42,"name":"John"}
```

The sample demonstrates deserializing from JSON data into an object. You then rewind the stream and call `ReadObject`.

```csharp
Person p2 = (Person)ser.ReadObject(stream1);
```

Examining the `p2` object reveals that the JSON data has been deserialized correctly.

#### To set up, build and run the sample

1. Build the solution JsonSerialization.sln as described in [Building the Windows Communication Foundation Samples](building-the-samples.md).

2. Run the resulting console application.

---
title: "DataContractSerializer Sample"
description: This sample demonstrates DataContractSerializer in WCF, which performs general serialization and deserialization services for the data contract classes.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "XML Formatter"
ms.assetid: e0a2fe89-3534-48c8-aa3c-819862224571
---
# DataContractSerializer Sample

The [DataContractSerializer sample](https://github.com/dotnet/samples/tree/main/framework/wcf) demonstrates the <xref:System.Runtime.Serialization.DataContractSerializer>, which performs general serialization and deserialization services for the data contract classes. The sample creates a `Record` object, serializes it to a memory stream and deserializes the memory stream back to another `Record` object to demonstrate the use of the <xref:System.Runtime.Serialization.DataContractSerializer>. The sample then serializes the `Record` object using a binary writer to demonstrate how the writer affects serialization.

> [!NOTE]
> The setup procedure and build instructions for this sample are located at the end of this topic.

The data contract for `Record` is shown in the following sample code.

```csharp
[DataContract(Namespace="http://Microsoft.ServiceModel.Samples")]
internal class Record
{
    private double n1;
    private double n2;
    private string operation;
    private double result;

    internal Record(double n1, double n2, string operation, double result)
    {
        this.n1 = n1;
        this.n2 = n2;
        this.operation = operation;
        this.result = result;
    }

    [DataMember]
    internal double OperandNumberOne
    {
        get { return n1; }
        set { n1 = value; }
    }

    [DataMember]
    internal double OperandNumberTwo
    {
        get { return n2; }
        set { n2 = value; }
    }

    [DataMember]
    internal string Operation
    {
        get { return operation; }
        set { operation = value; }
    }

    [DataMember]
    internal double Result
    {
        get { return result; }
        set { result = value; }
    }

    public override string ToString()
    {
        return $"Record: {n1} {operation} {n2} = {result}";
    }
}
```

The sample code creates a `Record` object named `record1` then displays the object.

```csharp
Record record1 = new Record(1, 2, "+", 3);
Console.WriteLine("Original record: {0}", record1.ToString());
```

The sample then uses the <xref:System.Runtime.Serialization.DataContractSerializer> to serialize `record1` into a memory stream.

```csharp
MemoryStream stream1 = new MemoryStream();

//Serialize the Record object to a memory stream using DataContractSerializer.
DataContractSerializer serializer = new DataContractSerializer(typeof(Record));
serializer.WriteObject(stream1, record1);
```

Next, the sample uses the <xref:System.Runtime.Serialization.DataContractSerializer> to deserialize the memory stream back into a new `Record` object and displays it.

```csharp
stream1.Position = 0;

//Deserialize the Record object back into a new record object.
Record record2 = (Record)serializer.ReadObject(stream1);

Console.WriteLine("Deserialized record: {0}", record2.ToString());
```

By default, the `DataContractSerializer` encodes objects into a stream using a textual representation of XML. However, you can influence the encoding of the XML by passing in a different writer. The sample creates a binary writer by calling <xref:System.Xml.XmlDictionaryWriter.CreateBinaryWriter%2A>. It then passes the writer and the record object to the serializer when it calls <xref:System.Runtime.Serialization.DataContractSerializer.WriteObjectContent%2A>. Finally, the sample flushes the writer and reports on the length of the streams.

```csharp
MemoryStream stream2 = new MemoryStream();

XmlDictionaryWriter binaryDictionaryWriter = XmlDictionaryWriter.CreateBinaryWriter(stream2);
serializer.WriteObject(binaryDictionaryWriter, record1);
binaryDictionaryWriter.Flush();

//report the length of the streams
Console.WriteLine("Text Stream is {0} bytes long", stream1.Length);
Console.WriteLine("Binary Stream is {0} bytes long", stream2.Length);
```

When you run the sample, the original record and the deserialized record are displayed, followed by the comparison between the length of the text encoding and the binary encoding. Press ENTER in the client window to shut down the client.

```console
Original record: Record: 1 + 2 = 3
Deserialized record: Record: 1 + 2 = 3
Text Stream is 233 bytes long
Binary Stream is 156 bytes long

Press <ENTER> to terminate client.
```

### To set up, build, and run the sample

1. Ensure that you have performed the [One-Time Setup Procedure for the Windows Communication Foundation Samples](one-time-setup-procedure-for-the-wcf-samples.md).

2. To build the C# or Visual Basic .NET edition of the solution, follow the instructions in [Building the Windows Communication Foundation Samples](building-the-samples.md).

3. To run the sample, start the client from the command prompt by typing client\bin\client.exe.

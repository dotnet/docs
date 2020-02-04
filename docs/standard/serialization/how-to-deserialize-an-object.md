---
title: How to deserialize an object using XmlSerializer
ms.date: 03/30/2017
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "deserializing objects"
  - "objects, deserializing steps"
ms.assetid: 287129c8-035a-4fea-b7b3-4790057ca076
---
# How to deserialize an object using XmlSerializer

When you deserialize an object, the transport format determines whether you will create a stream or file object. After the transport format is determined, you can call the <xref:System.Xml.Serialization.XmlSerializer.Serialize%2A> or <xref:System.Xml.Serialization.XmlSerializer.Deserialize%2A> methods, as required.

## To deserialize an object

1. Construct a <xref:System.Xml.Serialization.XmlSerializer> using the type of the object to deserialize.

1. Call the <xref:System.Xml.Serialization.XmlSerializer.Deserialize%2A> method to produce a replica of the object. When deserializing, you must cast the returned object to the type of the original, as shown in the following example, which deserializes the object from a file (although it could also be deserialized from a stream).

    ```vb
    ' Construct an instance of the XmlSerializer with the type
    ' of object that is being deserialized.
    Dim mySerializer As New XmlSerializer(GetType(MySerializableClass))
    ' To read the file, create a FileStream.
    Dim myFileStream As New FileStream("myFileName.xml", FileMode.Open)
    ' Call the Deserialize method and cast to the object type.
    Dim myObject = CType( _
    mySerializer.Deserialize(myFileStream), MySerializableClass)
    ```

    ```csharp
    // Construct an instance of the XmlSerializer with the type
    // of object that is being deserialized.
    var mySerializer = new XmlSerializer(typeof(MySerializableClass));
    // To read the file, create a FileStream.
    var myFileStream = new FileStream("myFileName.xml", FileMode.Open);
    // Call the Deserialize method and cast to the object type.
    var myObject = (MySerializableClass) mySerializer.Deserialize(myFileStream)
    ```

## See also

- [Introducing XML Serialization](introducing-xml-serialization.md)
- [How to: Serialize an Object](how-to-serialize-an-object.md)

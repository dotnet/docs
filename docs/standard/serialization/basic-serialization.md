---
title: "Basic serialization"
ms.date: "03/30/2017"
ms.prod: ".net"
ms.topic: "article"
helpviewer_keywords: 
  - "binary serialization, basic serialization"
  - "serialization, basic serialization"
ms.assetid: d899d43c-335a-433e-a589-cd187192984f
dev_langs: 
  - "CSharp"
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Basic serialization

[!INCLUDE [binary-serialization-warning](../../../includes/binary-serialization-warning.md)]

The easiest way to make a class serializable is to mark it with the <xref:System.SerializableAttribute> as follows.  
  
```csharp  
[Serializable]  
public class MyObject {  
  public int n1 = 0;  
  public int n2 = 0;  
  public String str = null;  
}  
```  
  
The following code example shows how an instance of this class can be serialized to a file.  
  
```csharp  
MyObject obj = new MyObject();  
obj.n1 = 1;  
obj.n2 = 24;  
obj.str = "Some String";  
IFormatter formatter = new BinaryFormatter();  
Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);  
formatter.Serialize(stream, obj);  
stream.Close();  
```  
  
This example uses a binary formatter to do the serialization. All you need to do is create an instance of the stream and the formatter you intend to use, and then call the **Serialize** method on the formatter. The stream and the object to serialize are provided as parameters to this call. Although it is not explicitly demonstrated in this example, all member variables of a class will be serialized—even variables marked as private. In this aspect, binary serialization differs from the <xref:System.Xml.Serialization.XmlSerializer> class, which only serializes public fields. For information on excluding member variables from binary serialization, see [Selective Serialization](selective-serialization.md).  
  
Restoring the object back to its former state is just as easy. First, create a stream for reading and a <xref:System.Runtime.Serialization.Formatter>, and then instruct the formatter to deserialize the object. The code example below shows how this is done.  
  
```csharp  
IFormatter formatter = new BinaryFormatter();  
Stream stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);  
MyObject obj = (MyObject) formatter.Deserialize(stream);  
stream.Close();  
  
// Here's the proof.  
Console.WriteLine("n1: {0}", obj.n1);  
Console.WriteLine("n2: {0}", obj.n2);  
Console.WriteLine("str: {0}", obj.str);  
```  
  
The <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> used above is very efficient and produces a compact byte stream. All objects serialized with this formatter can also be deserialized with it, which makes it an ideal tool for serializing objects that will be deserialized on the .NET Framework. It is important to note that constructors are not called when an object is deserialized. This constraint is placed on deserialization for performance reasons. However, this violates some of the usual contracts the runtime makes with the object writer, and developers should ensure that they understand the ramifications when marking an object as serializable.  
  
If portability is a requirement, use the <xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter> instead. Simply replace the **BinaryFormatter** in the code above with **SoapFormatter,** and call **Serialize** and **Deserialize** as before. This formatter produces the following output for the example used above.  
  
```xml  
<SOAP-ENV:Envelope  
  xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"  
  xmlns:xsd="http://www.w3.org/2001/XMLSchema"   
  xmlns:SOAP- ENC="http://schemas.xmlsoap.org/soap/encoding/"  
  xmlns:SOAP- ENV="http://schemas.xmlsoap.org/soap/envelope/"  
  SOAP-ENV:encodingStyle=  
  "http://schemas.microsoft.com/soap/encoding/clr/1.0"  
  "http://schemas.xmlsoap.org/soap/encoding/"  
  xmlns:a1="http://schemas.microsoft.com/clr/assem/ToFile">  
  
  <SOAP-ENV:Body>  
    <a1:MyObject id="ref-1">  
      <n1>1</n1>  
      <n2>24</n2>  
      <str id="ref-3">Some String</str>  
    </a1:MyObject>  
  </SOAP-ENV:Body>  
</SOAP-ENV:Envelope>  
```  
  
It's important to note that the [Serializable](xref:System.SerializableAttribute) attribute cannot be inherited. If you derive a new class from `MyObject`, the new class must be marked with the attribute as well, or it cannot be serialized. For example, when you attempt to serialize an instance of the class below, you'll get a <xref:System.Runtime.Serialization.SerializationException> informing you that the `MyStuff` type is not marked as serializable.  
  
```csharp  
public class MyStuff : MyObject   
{  
  public int n3;  
}  
```  
  
 Using the [Serializable](xref:System.SerializableAttribute) attribute is convenient, but it has limitations as previously demonstrated. Refer to the [Serialization Guidelines](serialization-guidelines.md) for information about when you should mark a class for serialization. Serialization cannot be added to a class after it has been compiled.  
  
## See also  
 [Binary Serialization](binary-serialization.md)  
 [XML and SOAP Serialization](xml-and-soap-serialization.md)

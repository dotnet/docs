---
title: "How to read object data from an XML file (C#)"
description: This C# example reads object data that was previously written to an XML file using the XmlSerializer class.
ms.date: 07/20/2015
ms.assetid: 6ad60d96-a4d9-48e6-a8b0-d7f6f803cafa
---
# How to read object data from an XML file (C#)

This example reads object data that was previously written to an XML file using the <xref:System.Xml.Serialization.XmlSerializer> class.  
  
## Example  
  
```csharp  
public class Book  
{  
    public String title;  
}
  
public void ReadXML()  
{  
    // First write something so that there is something to read ...  
    var b = new Book { title = "Serialization Overview" };  
    var writer = new System.Xml.Serialization.XmlSerializer(typeof(Book));  
    var wfile = new System.IO.StreamWriter(@"c:\temp\SerializationOverview.xml");  
    writer.Serialize(wfile, b);  
    wfile.Close();  
  
    // Now we can read the serialized book ...  
    System.Xml.Serialization.XmlSerializer reader =
        new System.Xml.Serialization.XmlSerializer(typeof(Book));  
    System.IO.StreamReader file = new System.IO.StreamReader(  
        @"c:\temp\SerializationOverview.xml");  
    Book overview =  (Book)reader.Deserialize(file);  
    file.Close();  
  
    Console.WriteLine(overview.title);  
  
}  
```  
  
## Compiling the Code  

Replace the file name "c:\temp\SerializationOverview.xml" with the name of the file containing the serialized data. For more information about serializing data, see [How to write object data to an XML file (C#)](./how-to-write-object-data-to-an-xml-file.md).
  
 The class must have a public constructor without parameters.  
  
 Only public properties and fields are deserialized.  
  
## Robust Programming  

 The following conditions may cause an exception:  
  
- The class being serialized does not have a public, parameterless constructor.  
  
- The data in the file does not represent data from the class to be deserialized.  
  
- The file does not exist (<xref:System.IO.IOException>).  
  
## .NET Security  

 Always verify inputs, and never deserialize data from an untrusted source. The re-created object runs on a local computer with the permissions of the code that deserialized it. Verify all inputs before using the data in your application.  
  
## See also

- <xref:System.IO.StreamWriter>
- [How to write object data to an XML file (C#)](./how-to-write-object-data-to-an-xml-file.md)
- [Serialization (C#)](./index.md)
- [C# Programming Guide](../../index.md)

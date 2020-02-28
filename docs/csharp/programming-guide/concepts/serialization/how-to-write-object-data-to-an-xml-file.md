---
title: "How to write object data to an XML file (C#)"
ms.date: 07/20/2015
ms.assetid: 7681eb98-703d-4005-a369-26a7bca0f894
---
# How to write object data to an XML file (C#)
This example writes the object from a class to an XML file using the <xref:System.Xml.Serialization.XmlSerializer> class.  
  
## Example  
  
```csharp  
public class XMLWrite  
{  
  
   static void Main(string[] args)  
    {  
        WriteXML();  
    }  
  
    public class Book  
    {  
        public String title;   
    }  
  
    public static void WriteXML()  
    {  
        Book overview = new Book();  
        overview.title = "Serialization Overview";  
        System.Xml.Serialization.XmlSerializer writer =   
            new System.Xml.Serialization.XmlSerializer(typeof(Book));  
  
        var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";  
        System.IO.FileStream file = System.IO.File.Create(path);  
  
        writer.Serialize(file, overview);  
        file.Close();  
    }  
}  
```  
  
## Compiling the Code  
 The class being serialized must have a public constructor without parameters.  
  
## Robust Programming  
 The following conditions may cause an exception:  
  
- The class being serialized does not have a public, parameterless constructor.  
  
- The file exists and is read-only (<xref:System.IO.IOException>).  
  
- The path is too long (<xref:System.IO.PathTooLongException>).  
  
- The disk is full (<xref:System.IO.IOException>).  
  
## .NET Framework Security  
 This example creates a new file, if the file does not already exist. If an application needs to create a file, that application needs `Create` access for the folder. If the file already exists, the application needs only `Write` access, a lesser privilege. Where possible, it is more secure to create the file during deployment, and only grant `Read` access to a single file, rather than `Create` access for a folder.  
  
## See also

- <xref:System.IO.StreamWriter>
- [How to read object data from an XML file (C#)](./how-to-read-object-data-from-an-xml-file.md)
- [Serialization (C#)](./index.md)

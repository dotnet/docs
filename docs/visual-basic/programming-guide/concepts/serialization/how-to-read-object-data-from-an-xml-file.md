---
title: "How to: Read Object Data from an XML File (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1e1423bf-74a4-4dde-a3bb-ae1bfc0a68ed
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Read Object Data from an XML File (Visual Basic)
This example reads object data that was previously written to an XML file using the <xref:System.Xml.Serialization.XmlSerializer> class.  
  
## Example  
  
```vb  
Public Class Book  
    Public Title As String  
End Class  
  
Public Sub ReadXML()  
    Dim reader As New System.Xml.Serialization.XmlSerializer(GetType(Book))  
    Dim file As New System.IO.StreamReader(  
        "c:\temp\SerializationOverview.xml")  
    Dim overview As Book  
    overview = CType(reader.Deserialize(file), Book)  
    Console.WriteLine(overview.Title)  
End Sub  
```  
  
## Compiling the Code  
 Replace the file name "c:\temp\SerializationOverview.xml" with the name of the file containing the serialized data. For more information about serializing data, see [How to: Write Object Data to an XML File (Visual Basic)](../../../../visual-basic/programming-guide/concepts/serialization/how-to-write-object-data-to-an-xml-file.md).  
  
 The class must have a public constructor without parameters.  
  
 Only public properties and fields are deserialized.  
  
## Robust Programming  
 The following conditions may cause an exception:  
  
-   The class being serialized does not have a public, parameterless constructor.  
  
-   The data in the file does not represent data from the class to be deserialized.  
  
-   The file does not exist (<xref:System.IO.IOException>).  
  
## .NET Framework Security  
 Always verify inputs, and never deserialize data from an untrusted source. The re-created object runs on a local computer with the permissions of the code that deserialized it. Verify all inputs before using the data in your application.  
  
## See Also  
 <xref:System.IO.StreamWriter>  
 [How to: Write Object Data to an XML File (Visual Basic)](../../../../visual-basic/programming-guide/concepts/serialization/how-to-write-object-data-to-an-xml-file.md)  
 [Serialization (Visual Basic)](../../../../visual-basic/programming-guide/concepts/serialization/index.md)  
 [Visual Basic Programming Guide](../../../../visual-basic/programming-guide/index.md)

---
title: "How to: Write Object Data to an XML File (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f7966480-5ed2-43ac-9894-33427436de2a
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Write Object Data to an XML File (Visual Basic)
This example writes the object from a class to an XML file using the <xref:System.Xml.Serialization.XmlSerializer> class.  
  
## Example  
  
```vb  
Public Module XMLWrite  
  
    Sub Main()  
        WriteXML()  
    End Sub  
  
    Public Class Book  
        Public Title As String  
    End Class  
  
    Public Sub WriteXML()  
        Dim overview As New Book  
        overview.Title = "Serialization Overview"  
        Dim writer As New System.Xml.Serialization.XmlSerializer(GetType(Book))  
        Dim file As New System.IO.StreamWriter(  
            "c:\temp\SerializationOverview.xml")  
        writer.Serialize(file, overview)  
        file.Close()  
    End Sub  
End Module  
```  
  
## Compiling the Code  
 The class must have a public constructor without parameters.  
  
## Robust Programming  
 The following conditions may cause an exception:  
  
-   The class being serialized does not have a public, parameterless constructor.  
  
-   The file exists and is read-only (<xref:System.IO.IOException>).  
  
-   The path is too long (<xref:System.IO.PathTooLongException>).  
  
-   The disk is full (<xref:System.IO.IOException>).  
  
## .NET Framework Security  
 This example creates a new file, if the file does not already exist. If an application needs to create a file, that application needs `Create` access for the folder. If the file already exists, the application needs only `Write` access, a lesser privilege. Where possible, it is more secure to create the file during deployment, and only grant `Read` access to a single file, rather than `Create` access for a folder.  
  
## See Also  
 <xref:System.IO.StreamWriter>  
 [How to: Read Object Data from an XML File (Visual Basic)](../../../../visual-basic/programming-guide/concepts/serialization/how-to-read-object-data-from-an-xml-file.md)  
 [Serialization (Visual Basic)](../../../../visual-basic/programming-guide/concepts/serialization/index.md)

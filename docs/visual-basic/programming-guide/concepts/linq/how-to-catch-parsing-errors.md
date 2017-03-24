---
title: "How to: Catch Parsing Errors (Visual Basic) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
ms.assetid: 22e9068e-ea58-447b-816e-cd1852c11787
caps.latest.revision: 3
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# How to: Catch Parsing Errors (Visual Basic)
[!INCLUDE[vs2017banner](../../../../includes/vs2017banner.md)]

This topic shows how to detect badly formed or invalid XML.  
  
 [!INCLUDE[sqltecxlinq](../../../../includes/sqltecxlinq-md.md)] is implemented using <xref:System.Xml.XmlReader>. If badly formed or invalid XML is passed to [!INCLUDE[sqltecxlinq](../../../../includes/sqltecxlinq-md.md)], the underlying <xref:System.Xml.XmlReader> class will throw an exception. The various methods that parse XML, such as <xref:System.Xml.Linq.XElement.Parse%2A?displayProperty=fullName>, do not catch the exception; the exception can then be caught by your application.  
  
 Note that you cannot get parse errors if you use XML literals. The Visual Basic compiler will catch errors of badly formed or invalid XML.  
  
## Example  
 The following code tries to parse invalid XML:  
  
```vb  
Try  
    Dim contacts As XElement = XElement.Parse("<Contacts>" & vbCrLf & _  
        "    <Contact>" & vbCrLf & _  
        "        <Name>Jim Wilson</Name>" & vbCrLf & _  
        "    </Contact>" & vbCrLf & _  
        "</Contcts>")  
  
    Console.WriteLine(contacts)  
Catch e As System.Xml.XmlException  
    Console.WriteLine(e.Message)  
End Try  
```  
  
 When you run this code, it throws the following exception:  
  
```  
The 'Contacts' start tag on line 1 does not match the end tag of 'Contcts'. Line 5, position 13.  
```  
  
 For information about the exceptions that you can expect the <xref:System.Xml.Linq.XElement.Parse%2A?displayProperty=fullName>, <xref:System.Xml.Linq.XDocument.Parse%2A?displayProperty=fullName>, <xref:System.Xml.Linq.XElement.Load%2A?displayProperty=fullName>, and <xref:System.Xml.Linq.XDocument.Load%2A?displayProperty=fullName> methods to throw, see the <xref:System.Xml.XmlReader> documentation.  
  
## See Also  
 [Parsing XML (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/parsing-xml.md)
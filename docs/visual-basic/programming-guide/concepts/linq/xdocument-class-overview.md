---
title: "XDocument Class Overview (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 45cb7e71-196a-47da-bfe9-7a5589db1eed
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# XDocument Class Overview (Visual Basic)
This topic introduces the <xref:System.Xml.Linq.XDocument> class.  
  
## Overview of the XDocument class  
 The <xref:System.Xml.Linq.XDocument> class contains the information necessary for a valid XML document. This includes an XML declaration, processing instructions, and comments.  
  
 Note that you only have to create <xref:System.Xml.Linq.XDocument> objects if you require the specific functionality provided by the <xref:System.Xml.Linq.XDocument> class. In many circumstances, you can work directly with <xref:System.Xml.Linq.XElement>. Working directly with <xref:System.Xml.Linq.XElement> is a simpler programming model.  
  
 <xref:System.Xml.Linq.XDocument> derives from <xref:System.Xml.Linq.XContainer>. Therefore, it can contain child nodes. However, <xref:System.Xml.Linq.XDocument> objects can have only one child <xref:System.Xml.Linq.XElement> node. This reflects the XML standard that there can be only one root element in an XML document.  
  
## Components of XDocument  
 An <xref:System.Xml.Linq.XDocument> can contain the following elements:  
  
-   One <xref:System.Xml.Linq.XDeclaration> object. <xref:System.Xml.Linq.XDeclaration> enables you to specify the pertinent parts of an XML declaration: the XML version, the encoding of the document, and whether the XML document is stand-alone.  
  
-   One <xref:System.Xml.Linq.XElement> object. This is the root node of the XML document.  
  
-   Any number of <xref:System.Xml.Linq.XProcessingInstruction> objects. A processing instruction communicates information to an application that processes the XML.  
  
-   Any number of <xref:System.Xml.Linq.XComment> objects. The comments will be siblings to the root element. The <xref:System.Xml.Linq.XComment> object cannot be the first argument in the list, because it is not valid for an XML document to start with a comment.  
  
-   One <xref:System.Xml.Linq.XDocumentType> for the DTD.  
  
 When you serialize an <xref:System.Xml.Linq.XDocument>, even if `XDocument.Declaration` is `null`, the output will have an XML declaration if the writer has `Writer.Settings.OmitXmlDeclaration` set to `false` (the default).  
  
 By default, [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] sets the version to "1.0", and sets the encoding to "utf-8".  
  
## Using XElement without XDocument  
 As previously mentioned, the <xref:System.Xml.Linq.XElement> class is the main class in the [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] programming interface. In many cases, your application will not require that you create a document. By using the <xref:System.Xml.Linq.XElement> class, you can create an XML tree, add other XML trees to it, modify the XML tree, and save it.  
  
## Using XDocument  
 To construct an <xref:System.Xml.Linq.XDocument>, use functional construction, just like you do to construct <xref:System.Xml.Linq.XElement> objects.  
  
 The following code creates an <xref:System.Xml.Linq.XDocument> object and its associated contained objects.  
  
```vb  
Dim doc As XDocument = <?xml version="1.0" encoding="utf-8"?>  
                       <!--This is a comment.-->  
                       <?xml-stylesheet href='mystyle.css' title='Compact' type='text/css'?>  
                       <Pubs>  
                           <Book>  
                               <Title>Artifacts of Roman Civilization</Title>  
                               <Author>Moreno, Jordao</Author>  
                           </Book>  
                           <Book>  
                               <Title>Midieval Tools and Implements</Title>  
                               <Author>Gazit, Inbar</Author>  
                           </Book>  
                       </Pubs>  
                       <!--This is another comment.-->  
doc.Save("test.xml")  
```  
  
 When you examine the file test.xml, you get the following output:  
  
```xml  
<?xml version="1.0" encoding="utf-8"?>  
<!--This is a comment.-->  
<?xml-stylesheet href='mystyle.css' title='Compact' type='text/css'?>  
<Pubs>  
  <Book>  
    <Title>Artifacts of Roman Civilization</Title>  
    <Author>Moreno, Jordao</Author>  
  </Book>  
  <Book>  
    <Title>Midieval Tools and Implements</Title>  
    <Author>Gazit, Inbar</Author>  
  </Book>  
</Pubs>  
<!--This is another comment.-->  
```  
  
## See Also  
 [LINQ to XML Programming Overview (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/linq-to-xml-programming-overview.md)

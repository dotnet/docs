---
title: "Saving and Writing a Document"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 097b0cb1-5743-4c3a-86ef-caf5cbe6750d
caps.latest.revision: 3
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Saving and Writing a Document
When you load and save an <xref:System.Xml.XmlDocument>, the saved document may differ from the original in the following ways:  
  
-   If the <xref:System.Xml.XmlDocument.PreserveWhitespace%2A> property is set to `true` before the <xref:System.Xml.XmlDocument.Save%2A> method is called, white space in the document is preserved in the output; if this property is `false`, <xref:System.Xml.XmlDocument> auto-indents the output.  
  
-   All the white space between attributes is reduced to a single space character.  
  
-   The white space between elements is changed. Significant white space is preserved and insignificant white space is not. But when the document is saved, it will use the <xref:System.Xml.XmlTextWriter> **Indenting** mode by default to neatly print the output to make it more readable.  
  
-   The quote character used around attribute values is changed to double quote by default. You can use the <xref:System.Xml.XmlTextReader.QuoteChar%2A> property on <xref:System.Xml.XmlTextWriter> to set the quote character to either double quote or single quote.  
  
-   By default, numeric character entities like `{` are expanded.  
  
-   The byte-order mark found in the input document is not preserved. UCS-2 is saved as UTF-8 unless you explicitly create an XML declaration that specifies a different encoding.  
  
-   If you want to write out the <xref:System.Xml.XmlDocument> into a file or stream, the output written out is the same as the content of the document. That is, the <xref:System.Xml.XmlDeclaration> is written out only if there is one contained in the document, and the encoding used when writing out the document is the same encoding given in the declaration node.  
  
## Writing an XmlDeclaration  
 The <xref:System.Xml.XmlDocument> and <xref:System.Xml.XmlDeclaration> members of <xref:System.Xml.XmlNode.OuterXml%2A>, <xref:System.Xml.XmlNode.InnerXml%2A>, and <xref:System.Xml.XmlNode.WriteTo%2A>, in addition to the <xref:System.Xml.XmlDocument> methods of <xref:System.Xml.XmlDocument.Save%2A> and <xref:System.Xml.XmlDocument.WriteContentTo%2A>, create an XML declaration.  
  
 For the <xref:System.Xml.XmlDocument> properties of <xref:System.Xml.XmlNode.OuterXml%2A>, <xref:System.Xml.XmlDocument.InnerXml%2A>, and the <xref:System.Xml.XmlDocument.Save%2A>, <xref:System.Xml.XmlDocument.WriteTo%2A>, and <xref:System.Xml.XmlDocument.WriteContentTo%2A> methods, the encoding written out in the XML declaration is taken from the <xref:System.Xml.XmlDeclaration> node. If there is no <xref:System.Xml.XmlDeclaration> node, <xref:System.Xml.XmlDeclaration> is not written out. If there is no encoding in the <xref:System.Xml.XmlDeclaration> node, encoding is not written out in the XML declaration.  
  
 The <xref:System.Xml.XmlDocument.Save%2A?displayProperty=nameWithType> and <xref:System.Xml.XmlDocument.Save%2A?displayProperty=nameWithType> methods always write out an <xref:System.Xml.XmlDeclaration>. These methods take the encoding from the writer that it is writing to. That is, the encoding value on the writer overrides the encoding on the document and in the <xref:System.Xml.XmlDeclaration>. For example, the following code does not write an encoding in the XML declaration found in the output file `out.xml`.  
  
```vb  
Dim doc As New XmlDocument()  
Dim tw As XmlTextWriter = New XmlTextWriter("out.xml", Nothing)  
doc.Load("text.xml")  
doc.Save(tw)  
```  
  
```csharp  
XmlDocument doc = new XmlDocument();  
XmlTextWriter tw = new XmlTextWriter("out.xml", null);  
doc.Load("text.xml");  
doc.Save(tw);  
```  
  
 For the <xref:System.Xml.XmlDocument.Save%2A> method, the XML declaration is written out using the <xref:System.Xml.XmlWriter.WriteStartDocument%2A> method in the <xref:System.Xml.XmlWriter> class. Therefore, overwriting the <xref:System.Xml.XmlWriter.WriteStartDocument%2A> method changes how the start of the document is written.  
  
 For the <xref:System.Xml.XmlDeclaration> members of <xref:System.Xml.XmlNode.OuterXml%2A>, <xref:System.Xml.XmlDeclaration.WriteTo%2A>, and <xref:System.Xml.XmlNode.InnerXml%2A>, if the <xref:System.Xml.XmlDeclaration.Encoding%2A> property is not set, no encoding is written out. Otherwise, the encoding written out in the XML declaration is the same as the encoding found in the <xref:System.Xml.XmlDeclaration.Encoding%2A> property.  
  
## Writing Document Content Using the OuterXml Property  
 The <xref:System.Xml.XmlNode.OuterXml%2A> property is a Microsoft extension to the World Wide Web Consortium (W3C) XML Document Object Model (DOM) standards. The <xref:System.Xml.XmlNode.OuterXml%2A> property is used to get the markup of the whole XML document, or just the markup of a single node and its child nodes. <xref:System.Xml.XmlNode.OuterXml%2A> returns the markup representing the given node and all its child nodes.  
  
 The following code sample shows how to save a document in its entirety as a string.  
  
```vb  
Dim mydoc As New XmlDocument()  
' Perform application needs here, like mydoc.Load("myfile");  
' Now save the entire document to a string variable called "xml".  
Dim xml As String = mydoc.OuterXml  
```  
  
```csharp  
XmlDocument mydoc = new XmlDocument();  
// Perform application needs here, like mydoc.Load("myfile");  
// Now save the entire document to a string variable called "xml".  
string xml = mydoc.OuterXml;  
```  
  
 The following code sample shows how to save only the document element.  
  
```vb  
' For the content of the Document Element only.  
Dim xml As String = mydoc.DocumentElement.OuterXml  
```  
  
```csharp  
// For the content of the Document Element only.  
string xml = mydoc.DocumentElement.OuterXml;  
```  
  
 In contrast, you can use the <xref:System.Xml.XmlNode.InnerText%2A> property if you want the content of child nodes.  
  
## See Also  
 [XML Document Object Model (DOM)](../../../../docs/standard/data/xml/xml-document-object-model-dom.md)

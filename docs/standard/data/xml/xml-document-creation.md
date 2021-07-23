---
description: "Learn more about: XML Document Creation"
title: "XML Document Creation"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.topic: how-to
---
# XML Document Creation

There are two ways to create an XML document. One way is to create an **XmlDocument** with no parameters. The other way is to create an **XmlDocument** and pass it an XmlNameTable as a parameter. The following example shows how to create a new, empty **XmlDocument** using no parameters.  
  
```vb  
Dim doc As New XmlDocument()  
```  
  
```csharp  
XmlDocument doc = new XmlDocument();  
```  
  
 Once a document is created, you can load it with data from a string, stream, URL, text reader, or an **XmlReader** derived class using the **Load** method. There is also another load method, the **LoadXML** method, which reads XML from a string. For more information on the various **Load** methods, see [Reading an XML Document into the DOM](reading-an-xml-document-into-the-dom.md).  
  
 There is a class called the **XmlNameTable**. This class is a table of atomized string objects. This table provides an efficient means for the XML parser to use the same string object for all repeated element and attribute names in an XML document. An **XmlNameTable** is automatically created when a document is created as shown above and is loaded with attribute and element names when the document is loaded. If you already have a document with a name table, and those names would be useful in another document, you can create a new document using the **Load** method that takes an **XmlNameTable** as a parameter. When the document is created with this method, it uses the existing **XmlNameTable** with all the attributes and elements already loaded into it from the other document. It can be used for efficiently comparing element and attribute names. For more information on the **XmlNameTable**, see [Object Comparison Using XmlNameTable](object-comparison-using-xmlnametable.md). For reference, see <xref:System.Xml.XmlNameTable>.  
  
## See also

- [XML Document Object Model (DOM)](xml-document-object-model-dom.md)

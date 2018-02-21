---
title: "Reading XML Data using XPathDocument and XmlDocument"
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
ms.assetid: 5711b225-6aa2-4e4f-9898-19f2d518ad1a
caps.latest.revision: 2
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Reading XML Data using XPathDocument and XmlDocument
There are two ways to read an XML document in the <xref:System.Xml.XPath?displayProperty=nameWithType> namespace. One is to read an XML document using the read-only <xref:System.Xml.XPath.XPathDocument> class and the other is to read an XML document using the editable <xref:System.Xml.XmlDocument> class in the <xref:System.Xml?displayProperty=nameWithType> namespace.  
  
## Reading XML Documents using the XPathDocument Class  
 The <xref:System.Xml.XPath.XPathDocument> class provides a fast, read-only, in-memory representation of an XML document using the XPath data model. Instances of the <xref:System.Xml.XPath.XPathDocument> class are created using one of its six constructors. These constructors allow you to read an XML document using a <xref:System.IO.Stream>, <xref:System.IO.TextReader>, or <xref:System.Xml.XmlReader> object, as well as the `string` path to an XML file.  
  
 The following example illustrates using the <xref:System.Xml.XPath.XPathDocument> class's `string` constructor to read an XML document.  
  
```vb  
Dim document As XPathDocument = New XPathDocument("books.xml")  
```  
  
```csharp  
XPathDocument document = new XPathDocument("books.xml");  
```  
  
## Reading XML Documents using the XmlDocument Class  
 The <xref:System.Xml.XmlDocument> class is an editable in-memory representation of an XML document implementing W3C Document Object Model (DOM) Level 1 Core and Core DOM Level 2. Instances of the <xref:System.Xml.XmlDocument> class are created using one of its three constructors. You can create a new, empty <xref:System.Xml.XmlDocument> object by calling the <xref:System.Xml.XmlDocument> class constructor with no parameters. After calling the constructor, use the <xref:System.Xml.XmlDocument.Load%2A> method to load XML data into the new <xref:System.Xml.XmlDocument> object from a <xref:System.IO.Stream>, <xref:System.IO.TextReader>, or <xref:System.Xml.XmlReader> object, as well as the `string` path to an XML file.  
  
 The following example illustrates using the <xref:System.Xml.XmlDocument> class constructor with no parameters and the <xref:System.Xml.XmlDocument.Load%2A> method to read an XML document.  
  
```vb  
Dim document As XmlDocument = New XmlDocument()  
document.Load("books.xml")  
```  
  
```csharp  
XmlDocument document = new XmlDocument();  
document.Load("books.xml");  
```  
  
## Determining the Encoding of an XML Document  
 An <xref:System.Xml.XmlReader> object can be used to read an XML document and to create <xref:System.Xml.XPath.XPathDocument> and <xref:System.Xml.XmlDocument> objects as shown in the previous sections. However, an <xref:System.Xml.XmlReader> object may read data that is not encoded and as a result does not provide any encoding information.  
  
 The <xref:System.Xml.XmlTextReader> class inherits from the <xref:System.Xml.XmlReader> class, provides encoding information using its <xref:System.Xml.XmlTextReader.Encoding%2A> property, and can be used to create an <xref:System.Xml.XPath.XPathDocument> object or <xref:System.Xml.XmlDocument> object.  
  
 For more information about the encoding information provided by the <xref:System.Xml.XmlTextReader> class, see the <xref:System.Xml.XmlTextReader.Encoding%2A> property in the <xref:System.Xml.XmlTextReader> class reference documentation.  
  
## Creating XPathNavigator Objects  
 After you have read an XML document into either an <xref:System.Xml.XPath.XPathDocument> or <xref:System.Xml.XmlDocument> object, you can create an <xref:System.Xml.XPath.XPathNavigator> object to select, evaluate, navigate, and in some cases, edit the underlying XML data.  
  
 Both the <xref:System.Xml.XPath.XPathDocument> and <xref:System.Xml.XmlDocument> classes, in addition to the <xref:System.Xml.XmlNode> class, implement the <xref:System.Xml.XPath.IXPathNavigable> interface of the <xref:System.Xml.XPath?displayProperty=nameWithType> namespace. As a result, all three classes provide a <xref:System.Xml.XPath.IXPathNavigable.CreateNavigator%2A> method that returns an <xref:System.Xml.XPath.XPathNavigator> object.  
  
### Editing XML Documents using the XPathNavigator Class  
 In addition to selecting, evaluating, and navigating XML data, the <xref:System.Xml.XPath.XPathNavigator> class can be used to edit an XML document in some cases, based on the object that created it.  
  
 The <xref:System.Xml.XPath.XPathDocument> class is read-only while the <xref:System.Xml.XmlDocument> class is editable and as a result, <xref:System.Xml.XPath.XPathNavigator> objects created from an <xref:System.Xml.XPath.XPathDocument> object cannot be used to edit an XML document while those created from an <xref:System.Xml.XmlDocument> object can. The <xref:System.Xml.XPath.XPathDocument> class should be used to read an XML document only. In cases where you need to edit an XML document, or require access to the additional functionality provided by the <xref:System.Xml.XmlDocument> class, like event handling, the <xref:System.Xml.XmlDocument> class should be used.  
  
 The <xref:System.Xml.XPath.XPathNavigator.CanEdit%2A> property of the <xref:System.Xml.XPath.XPathNavigator> class specifies if an <xref:System.Xml.XPath.XPathNavigator> object may edit XML data.  
  
 The following table describes the value of the <xref:System.Xml.XPath.XPathNavigator.CanEdit%2A> property for each class.  
  
|<xref:System.Xml.XPath.IXPathNavigable> Implementation|<xref:System.Xml.XPath.XPathNavigator.CanEdit%2A> Value|  
|--------------------------------------------------------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------|  
|<xref:System.Xml.XPath.XPathDocument>|`false`|  
|<xref:System.Xml.XmlDocument>|`true`|  
  
## See Also  
 <xref:System.Xml.XmlDocument>  
 <xref:System.Xml.XPath.XPathDocument>  
 <xref:System.Xml.XPath.XPathNavigator>  
 [Process XML Data Using the XPath Data Model](../../../../docs/standard/data/xml/process-xml-data-using-the-xpath-data-model.md)  
 [Accessing XML Data using XPathNavigator](../../../../docs/standard/data/xml/accessing-xml-data-using-xpathnavigator.md)  
 [Editing XML Data using XPathNavigator](../../../../docs/standard/data/xml/editing-xml-data-using-xpathnavigator.md)  
 [Schema Validation using XPathNavigator](../../../../docs/standard/data/xml/schema-validation-using-xpathnavigator.md)

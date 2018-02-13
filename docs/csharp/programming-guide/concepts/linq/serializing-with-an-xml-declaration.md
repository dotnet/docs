---
title: "Serializing with an XML Declaration (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: c237fa4a-a042-40fd-886f-17b54c66bb75
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# Serializing with an XML Declaration (C#)
This topic describes how to control whether serialization generates an XML declaration.  
  
## XML Declaration Generation  
 Serializing to a <xref:System.IO.File> or a <xref:System.IO.TextWriter> using the <xref:System.Xml.Linq.XElement.Save%2A?displayProperty=nameWithType> method or the <xref:System.Xml.Linq.XDocument.Save%2A?displayProperty=nameWithType> method generates an XML declaration. When you serialize to an <xref:System.Xml.XmlWriter>, the writer settings (specified in an <xref:System.Xml.XmlWriterSettings> object) determine whether an XML declaration is generated or not.  
  
 If you are serializing to a string using the `ToString` method, the resulting XML will not include an XML declaration.  
  
### Serializing with an XML Declaration  
 The following example creates an <xref:System.Xml.Linq.XElement>, saves the document to a file, and then prints the file to the console:  
  
```csharp  
XElement root = new XElement("Root",  
    new XElement("Child", "child content")  
);  
root.Save("Root.xml");  
string str = File.ReadAllText("Root.xml");  
Console.WriteLine(str);  
```  
  
 This example produces the following output:  
  
```xml  
<?xml version="1.0" encoding="utf-8"?>  
<Root>  
  <Child>child content</Child>  
</Root>  
```  
  
### Serializing without an XML Declaration  
 The following example shows how to save an <xref:System.Xml.Linq.XElement> to an <xref:System.Xml.XmlWriter>.  
  
```csharp  
StringBuilder sb = new StringBuilder();  
XmlWriterSettings xws = new XmlWriterSettings();  
xws.OmitXmlDeclaration = true;  
  
using (XmlWriter xw = XmlWriter.Create(sb, xws)) {  
    XElement root = new XElement("Root",  
        new XElement("Child", "child content")  
    );  
    root.Save(xw);  
}  
Console.WriteLine(sb.ToString());  
```  
  
 This example produces the following output:  
  
```xml  
<Root><Child>child content</Child></Root>  
```  
  
## See Also  
 [Serializing XML Trees (C#)](../../../../csharp/programming-guide/concepts/linq/serializing-xml-trees.md)

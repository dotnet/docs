---
title: "Changing Namespace Prefix Properties"
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
ms.assetid: d5c87cbe-4d69-429f-aad5-3103c2ca2770
caps.latest.revision: 3
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Changing Namespace Prefix Properties
The **XmlNode** class allows you to change the namespace prefix associated with a given node. For example, the following code shows the prefix of an element being changed.  
  
```vb  
Dim doc as XmlDocument = new XmlDocument()  
doc.LoadXml("<a:test xmlns:a='123' xmlns:b='456'/>")  
Dim e as XmlElement = doc.DocumentElement  
e.Prefix = "b"  
Console.WriteLine(doc.InnerXml)  
```  
  
```csharp  
XmlDocument doc = new XmlDocument();  
doc.LoadXml("<a:test xmlns:a='123' xmlns:b='456'/>");  
XmlElement e = doc.DocumentElement;         
e.Prefix = "b";  
Console.WriteLine(doc.InnerXml);  
```  
  
 **Output**  
  
```xml  
<b:test xmlns:a="123" xmlns:b="456" />  
```  
  
 Changing the prefix of a node does not change its namespace. The namespace can only be set when the node is created. When you persist the tree, new namespace attributes may be persisted out to satisfy the prefix you set. If the new namespace cannot be created, then the prefix is changed so the node preserves its local name and namespace. The following example shows a namespace attribute being added.  
  
```vb  
Dim doc as XmlDocument = new XmlDocument()  
doc.LoadXml("<test xmlns='123'/>")  
Dim e as XmlElement = doc.DocumentElement  
e.Prefix = "a"  
Console.WriteLine(doc.InnerXml)  
```  
  
```csharp  
XmlDocument doc = new XmlDocument();  
doc.LoadXml("<test xmlns='123'/>");  
XmlElement e = doc.DocumentElement;         
e.Prefix = "a";  
Console.WriteLine(doc.InnerXml);  
```  
  
 **Output**  
  
```xml  
<a:test xmlns="123" xmlns:a="123" />  
```  
  
 When the tree was persisted to a string as a result of the call to **doc.InnerXml**, the `xmlns:a='123'` attribute was added to preserve the namespace of the `test` element. It was `'123'`, and it remained `'123'`.  
  
## See Also  
 [XML Document Object Model (DOM)](../../../../docs/standard/data/xml/xml-document-object-model-dom.md)

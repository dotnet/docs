---
title: "Changing Namespace Declarations in an XML Document"
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
ms.assetid: a2758f40-e497-4964-8d8d-1bb68af14dcd
caps.latest.revision: 3
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Changing Namespace Declarations in an XML Document
The **XmlDocument** exposes namespace declarations and **xmlns** attributes as part of the document object model. These are stored in the **XmlDocument**, so when you save the document, it can preserve the location of those attributes. Changing these attributes has no affect on the **Name**, **NamespaceURI**, and **Prefix** properties of other nodes already in the tree. For example, if you load the following document, then the `test` element has **NamespaceURI** `123.`  
  
```xml  
<test xmlns="123"/>  
```  
  
 If you remove the `xmlns` attribute as follows, then the `test` element still has the **NamespaceURI** of `123`.  
  
```vb  
doc.documentElement.RemoveAttribute("xmlns")  
```  
  
```csharp  
doc.documentElement.RemoveAttribute("xmlns");  
```  
  
 Likewise, if you add a different `xmlns` attribute to the `doc` element as follows, then the `test` element still has **NamespaceURI** `123`.  
  
```vb  
doc.documentElement.SetAttribute("xmlns","456");  
```  
  
```csharp  
doc.documentElement.SetAttribute("xmlns","456");  
```  
  
 Therefore, changing `xmlns` attributes will have no affect until you save and reload the **XmlDocument** object.  
  
## See Also  
 [XML Document Object Model (DOM)](../../../../docs/standard/data/xml/xml-document-object-model-dom.md)

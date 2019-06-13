---
title: "XML Element and Attribute Name Verification when Creating New Nodes"
ms.date: "03/30/2017"
ms.technology: dotnet-standard
ms.assetid: b489f647-a175-4659-ada4-170058bb41d0
author: "mairaw"
ms.author: "mairaw"
---
# XML Element and Attribute Name Verification when Creating New Nodes
The XML Document Object Model (DOM) checks the validity of the names when creating new element nodes or attribute nodes. If the names contain illegal characters, an exception is thrown. To ensure that names are valid and encoded correctly, you need to use the **XmlConvert** class to encode the name and decode it back at an application level. The **XmlWriter** has methods that do additional work to ensure well-formed XML is generated.  
  
## See also

- [XML Document Object Model (DOM)](../../../../docs/standard/data/xml/xml-document-object-model-dom.md)

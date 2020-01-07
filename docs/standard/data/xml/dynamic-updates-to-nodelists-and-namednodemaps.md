---
title: "Dynamic Updates to NodeLists and NamedNodeMaps"
ms.date: "03/30/2017"
ms.technology: dotnet-standard
ms.assetid: 76c511fd-6704-4ca4-8078-860a68d898ad
---
# Dynamic Updates to NodeLists and NamedNodeMaps
Because the **XmlNodeList** and the **XmlNamedNodeMap** contain a set of nodes, yet the XML document is loaded into memory and is being modified, the World Wide Web Consortium (W3C) states that these objects that contain sets of nodes need to be dynamic. That is, if the underlying document changes, then the data in these two objects should change also. Therefore, if you have an **XmlNodeList** that contains all the child elements of a particular element (for example, element X), then you add an additional element, element Q, to the document under element X. The **XmlNodeList** should also have that new element Q added to its collection. The same is true in reverse. If a node is added to the **XmlNodeList**, the underlying document is updated as well.  
  
## See also

- [XML Document Object Model (DOM)](../../../../docs/standard/data/xml/xml-document-object-model-dom.md)

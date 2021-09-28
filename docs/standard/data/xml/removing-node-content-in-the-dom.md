---
description: "Learn more about: Removing Node Content in the DOM"
title: "Removing Node Content in the DOM"
ms.date: "03/30/2017"
ms.assetid: 615d81a7-f44f-416c-a9ab-bfe03f85e6e4
---
# Removing Node Content in the DOM

For node types that inherit from <xref:System.Xml.XmlCharacterData>, which are the <xref:System.Xml.XmlComment>, <xref:System.Xml.XmlText>, <xref:System.Xml.XmlCDataSection>, <xref:System.Xml.XmlWhitespace>, and <xref:System.Xml.XmlSignificantWhitespace> node types, you can remove characters using the <xref:System.Xml.XmlCharacterData.DeleteData%2A> method, which removes a range of characters from the node. If you want to remove content completely, you remove the node that contains the content. If you want to keep the node, but the content is incorrect, then modify the content. For information on modifying the content of a node, see [Modifying Nodes, Content, and Values in an XML Document](modifying-nodes-content-and-values-in-an-xml-document.md).  
  
## See also

- [XML Document Object Model (DOM)](xml-document-object-model-dom.md)

---
description: "Learn more about: White Space and Significant White Space Handling when Loading the DOM"
title: "White Space and Significant White Space Handling when Loading the DOM"
ms.date: "03/30/2017"
ms.assetid: 1b141a0a-50d8-4ebd-83cd-a84449bb22b2
---
# White Space and Significant White Space Handling when Loading the DOM

When loading the document, you can set the option to preserve white space and create **XmlWhitespace** nodes in the document tree. To create white space nodes, set the **PreserveWhitespace** property to true. If the property is set to **false**, which is the default, white space nodes are not created. Significant white spaces nodes are always preserved, and **XmlSignificantWhitespace** nodes are always created in memory to represent this data, regardless of the setting of the **PreserveWhitespace** flag.  
  
 If the document is loaded from a reader, then setting of the **PreserveWhitespace** flag property on the **XmlDocument** class affects the creation of **XmlWhitespace** nodes only when the **WhitespaceHandling** property on the **XmlTextReader** is not set to **WhitespaceHandling.None**. It is the value of the **WhitespaceHandling** property on the reader that takes precedence over the setting of that flag on the **XmlDocument**. For more information on **XmlSignificantWhitespace**, see <xref:System.Xml.XmlSignificantWhitespace>.  
  
## See also

- [XML Document Object Model (DOM)](xml-document-object-model-dom.md)

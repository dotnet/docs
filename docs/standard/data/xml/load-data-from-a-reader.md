---
title: "Load Data from a Reader"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 7e74918c-bc72-4977-a49b-e1520a6d8f60
caps.latest.revision: 4
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Load Data from a Reader
If an XML document is loaded using the <xref:System.Xml.XmlDocument.Load%2A> method and a parameter of an <xref:System.Xml.XmlReader>, there are differences in the behavior that occurs when compared to the behavior of loading data from the other formats. If the reader is in its initial state, <xref:System.Xml.XmlDocument.Load%2A> consumes the entire contents from the reader and builds the XML Document Object Model (DOM) from all the data in the reader.  
  
 If the reader is already positioned on a node somewhere in the document, and the reader is then passed to the <xref:System.Xml.XmlDocument.Load%2A> method, <xref:System.Xml.XmlDocument.Load%2A> attempts to read the current node and all of its siblings, up to the end tag that closes the current depth into memory. The success of the attempted <xref:System.Xml.XmlDocument.Load%2A> depends on the node that the reader is on when the load is attempted, as <xref:System.Xml.XmlDocument.Load%2A> verifies that the XML from the reader is well-formed. If the XML is not well-formed, the <xref:System.Xml.XmlDocument.Load%2A> throws an exception. For example, the following set of nodes contain two root-level elements, the XML is not well-formed, and <xref:System.Xml.XmlDocument.Load%2A> throws an exception.  
  
-   Comment node, followed by an Element node, followed by an Element node, followed by an EndElement node.  
  
 The following set of nodes creates an incomplete DOM, because there is no root-level element.  
  
-   Comment node followed by a ProcessingInstruction node followed by a Comment node followed by an EndElement node.  
  
 This does not throw an exception, and the data is loaded. You can add a root element to the top of these nodes and create well-formed XML that can be saved without error.  
  
 If the reader is positioned on a leaf node that is invalid for the root level of a document (for example, a white space or attribute node), the reader continues to read until it is positioned on a node that can be used for the root. The document begins loading at this point.  
  
 By default, <xref:System.Xml.XmlDocument.Load%2A> does not verify whether the XML is valid using document type definition (DTD) or schema validation. It only verifies whether the XML is well-formed. In order for validation to occur, you need to create an <xref:System.Xml.XmlReader> using the <xref:System.Xml.XmlReaderSettings> class. The <xref:System.Xml.XmlReader> class can enforce validation using a DTD or Schema definition language (XSD) schema. The <xref:System.Xml.ValidationType> property on the <xref:System.Xml.XmlReaderSettings> class determines whether the <xref:System.Xml.XmlReader> instance enforces validation. For more information about validating XML data, see the Remarks section of the <xref:System.Xml.XmlReader> reference page.  
  
## See Also  
 [XML Document Object Model (DOM)](../../../../docs/standard/data/xml/xml-document-object-model-dom.md)

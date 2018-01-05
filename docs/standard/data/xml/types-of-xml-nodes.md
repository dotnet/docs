---
title: "Types of XML Nodes"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 71d03b78-6898-4ce7-b0fc-1282573f31f7
caps.latest.revision: 4
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Types of XML Nodes
When an XML document is read into memory as a tree of nodes, the node types for the nodes are decided when the nodes are created. The XML Document Object Model (DOM) has several kinds of node types, determined by the World Wide Web Consortium (W3C) and listed in section 1.1.1 The DOM Structure Model. The following table lists the node types, the object assigned to that node type, and a short description of each.  
  
|DOM node type|Object|Description|  
|-------------------|------------|-----------------|  
|Document|<xref:System.Xml.XmlDocument>|The container of all the nodes in the tree. It is also known as the document root, which is not always the same as the root element.|  
|DocumentFragment|<xref:System.Xml.XmlDocumentFragment>|A temporary bag containing one or more nodes without any tree structure.|  
|DocumentType|<xref:System.Xml.XmlDocumentType>|Represents the `<!DOCTYPE…>` node.|  
|EntityReference|<xref:System.Xml.XmlEntityReference>|Represents the non-expanded entity reference text.|  
|Element|<xref:System.Xml.XmlElement>|Represents an element node.|  
|Attr|<xref:System.Xml.XmlAttribute>|Is an attribute of an element.|  
|ProcessingInstruction|<xref:System.Xml.XmlProcessingInstruction>|Is a processing instruction node.|  
|Comment|<xref:System.Xml.XmlComment>|A comment node.|  
|Text|<xref:System.Xml.XmlText>|Text belonging to an element or attribute.|  
|CDATASection|<xref:System.Xml.XmlCDataSection>|Represents CDATA.|  
|Entity|<xref:System.Xml.XmlEntity>|Represents the `<!ENTITY…>` declarations in an XML document, either from an internal document type definition (DTD) subset or from external DTDs and parameter entities.|  
|Notation|<xref:System.Xml.XmlNotation>|Represents a notation declared in the DTD.|  
  
 Even though an attribute (*attr*) is listed in the W3C DOM Level 1 section 1.2 Fundamental Interfaces as a node, it is not considered a child of any element node.  
  
 The following table shows additional node types not defined by the W3C, however they are available for use in the Microsoft .NET Framework object model as **XmlNodeType** enumerations. Therefore, there is no matching DOM node type column for these node types.  
  
|Node type|Description|  
|---------------|-----------------|  
|<xref:System.Xml.XmlDeclaration>|Represents the declaration node `<?xml version="1.0"…>`.|  
|<xref:System.Xml.XmlSignificantWhitespace>|Represents significant white space, which is white space in mixed content.|  
|<xref:System.Xml.XmlWhitespace>|Represents the white space in the content of an element.|  
|EndElement|Returned when **XmlReader** gets to the end of an element.<br /><br /> Example XML: **\</item>**<br /><br /> For more information, see <xref:System.Xml.XmlNodeType>.|  
|EndEntity|Returned when **XmlReader** gets to the end of the entity replacement as a result of a call to <xref:System.Xml.XmlReader.ResolveEntity%2A>. For more information, see <xref:System.Xml.XmlNodeType>.|  
  
 To view a code example that reads in XML and uses a case construct on the node types to print information about the node and its contents, see <xref:System.Xml.XmlSignificantWhitespace.NodeType%2A>.  
  
 For more information on the object hierarchy of the node types and their equivalent object name, see [XML Document Object Model (DOM) Hierarchy](../../../../docs/standard/data/xml/xml-document-object-model-dom-hierarchy.md). For more information on the objects created in the node tree, see [Mapping the Object Hierarchy to XML Data](../../../../docs/standard/data/xml/mapping-the-object-hierarchy-to-xml-data.md).  
  
## See Also  
 [XML Document Object Model (DOM)](../../../../docs/standard/data/xml/xml-document-object-model-dom.md)

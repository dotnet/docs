---
title: "Modifying Nodes, Content, and Values in an XML Document"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 761773e0-db72-4986-b9f5-a522213d8397
caps.latest.revision: 3
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Modifying Nodes, Content, and Values in an XML Document
There are many ways you can modify the nodes and content in a document. You can:  
  
-   Change the value of nodes using the <xref:System.Xml.XmlNode.Value%2A> property.  
  
-   Modify an entire set of nodes by replacing the nodes with new nodes. This is done using the <xref:System.Xml.XmlNode.InnerXml%2A> property.  
  
-   Replace existing nodes with new nodes using the <xref:System.Xml.XmlNode.RemoveChild%2A> method.  
  
-   Add additional characters to nodes that inherit from the <xref:System.Xml.XmlCharacterData> class using the <xref:System.Xml.XmlCharacterData.AppendData%2A>, <xref:System.Xml.XmlCharacterData.InsertData%2A>, or <xref:System.Xml.XmlCharacterData.ReplaceData%2A> methods.  
  
-   Modify the content by removing a range of characters using the <xref:System.Xml.XmlCharacterData.DeleteData%2A> method on node types that inherit from <xref:System.Xml.XmlCharacterData>.  
  
 A simple technique for changing the value of a node is to use `node.Value = "new value";`. The following table lists the node types that this single line of code works on and exactly what data for that node type is changed.  
  
|Node type|Data changed|  
|---------------|------------------|  
|Attribute|The value of the attribute.|  
|CDATASection|The content of the CDATASection.|  
|Comment|The content of the comment.|  
|ProcessingInstruction|The content, excluding the target.|  
|Text|The content of the text.|  
|XmlDeclaration|The content of the declaration, excluding the `<?xml` and `?>` markup.|  
|Whitespace|The value of the white space. You can set the value to be one of the four recognized XML white space characters: space, tab, CR, or LF.|  
|SignificantWhitespace|The value of the significant white space. You can set the value to be one of the four recognized XML white space characters: space, tab, CR, or LF.|  
  
 Any node type not listed in the table is not a valid node type to set a value on. Setting a value on any other node type throws an <xref:System.InvalidOperationException>.  
  
 The <xref:System.Xml.XmlNode.InnerXml%2A> property changes the markup of the child nodes for the current node. Setting this property replaces the child nodes with the parsed contents of the given string. The parsing is done in the current namespace context. In addition, <xref:System.Xml.XmlNode.InnerXml%2A> removes redundant namespace declarations. As a result, numerous cut and paste operations do not increase the size of your document with redundant namespace declarations. For a code example showing the effect of namespaces on the <xref:System.Xml.XmlNode.InnerXml%2A> operation, see the <xref:System.Xml.XmlDocument.InnerXml%2A> property.  
  
 When using the <xref:System.Xml.XmlCharacterData.ReplaceData%2A> and <xref:System.Xml.XmlNode.RemoveChild%2A> methods, the methods return the replaced or removed node. This node can then be reinserted somewhere else in the XML Document Object Model (DOM). The <xref:System.Xml.XmlCharacterData.ReplaceData%2A> method does two validation checks on the node being inserted into the document. The first check ensures that the node is becoming a child of a node that can have child nodes of its type. The second check ensures that the node being inserted is not an ancestor of the node it is becoming a child of. Violating either of these conditions throws an <xref:System.InvalidOperationException>.  
  
 It is valid to add or remove a read-only child from a node that can be edited. However, attempts to modify the read-only node itself throws an <xref:System.InvalidOperationException>. An example of this is modifying the children of an <xref:System.Xml.XmlEntityReference> node. The children are read-only and cannot be modified. Any attempt to modify them throws an <xref:System.InvalidOperationException>.  
  
## See Also  
 [XML Document Object Model (DOM)](../../../../docs/standard/data/xml/xml-document-object-model-dom.md)

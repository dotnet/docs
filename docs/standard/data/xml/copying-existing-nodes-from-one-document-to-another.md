---
title: "Copying Existing Nodes from One Document to Another"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3caa78c1-3448-4b7b-b83c-228ee857635e
caps.latest.revision: 4
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Copying Existing Nodes from One Document to Another
The **ImportNode** method is the mechanism by which a node or entire node subtree is copied from one **XmlDocument** to another. The node returned from the call is a copy of the node from the source document, including attribute values, the node name, node type, and all namespace-related attributes such as the prefix, local name, and namespace Uniform Resource Identifier (URI). The source document is not changed. After you have imported the node, you still have to add it to the tree using one of the methods used to insert nodes.  
  
 When the node is attached to its new document, the new document owns the node. The reason is that each node, when created, has an owning document, even if the nodes are created in separate document fragments. This is a requirement of the XML Document Object Model (DOM) and is enforced by the factory creation design on the **XmlDocument** class. For example, **CreateElement**, is the only way to create new nodes.  
  
 Depending on the node type of the imported node and the value of the *deep* parameter, additional information is copied as appropriate. This method attempts to mirror the behavior expected if a fragment of XML or HTML source was copied from one document to another, accounting for the fact that for XML, the two documents may have different document type definitions (DTDs).  
  
 The following table describes the specific behavior for each type of node that can be imported.  
  
|Node Type|*deep* parameter is true|*deep* parameter is false|  
|---------------|------------------------------|-------------------------------|  
|XmlAttribute|The <xref:System.Xml.XmlAttribute.Specified%2A> is set to **true** on the XmlAttribute. The descendants of the source **XmlAttribute** are recursively imported and the resulting nodes reassembled to form the corresponding subtree.|The *deep* parameter does not apply to **XmlAttribute** nodes, because they always carry their child nodes with them when imported.|  
|XmlCDataSection|Copies the node, including its data.|Copies the node, including its data.|  
|XmlComment|Copies the node, including its data.|Copies the node, including its data.|  
|XmlDocumentFragment|The descendants of the source node are recursively imported and the resulting nodes reassembled to form the corresponding subtree.|An empty **XmlDocumentFragment** is created.|  
|XmlDocumentType|Copies the node, including its data.*|Copies the node, including its data.*|  
|XmlElement|The descendants of the source element are recursively imported and the resulting nodes reassembled to form the corresponding subtree. **Note:**  Default attributes are not copied. If the document being imported into defines default attributes for this element name, those are assigned.|Specified attribute nodes of the source element are imported, and the generated **XmlAttribute** nodes are attached to the new element. The descendant nodes are not copied. **Note:**  Default attributes are not copied. If the document being imported into defines default attributes for this element name, those are assigned.|  
|XmlEntityReference|Because the source and destination documents could have the entities defined differently, this method only copies the **XmlEntityReference** node. The replacement text is not included. If the destination document has the entity defined, its value is assigned.|Because the source and destination documents could have the entities defined differently, this method only copies the **XmlEntityReference** node. The replacement text is not included. If the destination document has the entity defined, its value is assigned.|  
|XmlProcessingInstruction|Copies the target and data value from the imported node.|Copies the target and data value from the imported node.|  
|XmlText|Copies the node, including its data.|Copies the node, including its data.|  
|XmlSignificantWhitespace|Copies the node, including its data.|Copies the node, including its data.|  
|XmlWhitespace|Copies the node, including its data.|Copies the node, including its data.|  
|XmlDeclaration|Copies the target and data value from the imported node.|Copies the target and data value from the imported node.|  
|All other node types|These node types cannot be imported.|These node types cannot be imported.|  
  
> [!NOTE]
>  Although DocumentType nodes can be imported, a document can only have one DocumentType. So, once you have imported the document type, before inserting it into tree you have to make sure that there is no document type in the document. For information on removing nodes, see [Removing Nodes, Content, and Values from an XML Document](../../../../docs/standard/data/xml/removing-nodes-content-and-values-from-an-xml-document.md).  
  
## See Also  
 [XML Document Object Model (DOM)](../../../../docs/standard/data/xml/xml-document-object-model-dom.md)

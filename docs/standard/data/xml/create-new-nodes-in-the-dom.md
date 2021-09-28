---
description: "Learn more about: Create New Nodes in the DOM"
title: Create New Nodes in the DOM
ms.date: 09/02/2021
ms.assetid: 6c2b9789-b61a-49f9-b33f-db01a945edf2
---
# Create New Nodes in the DOM

The <xref:System.Xml.XmlDocument> class has a create method for all of the node types. To create a node, supply the method with a name, when required, and content or other parameters for those nodes that have content (for example, a text node). The following methods need a name and a few other parameters filled to create an appropriate node:
  
- <xref:System.Xml.XmlDocument.CreateCDataSection%2A>  
  
- <xref:System.Xml.XmlDocument.CreateComment%2A>  
  
- <xref:System.Xml.XmlDocument.CreateDocumentFragment%2A>  
  
- <xref:System.Xml.XmlDocument.CreateDocumentType%2A>  
  
- <xref:System.Xml.XmlDocument.CreateElement%2A>  
  
- <xref:System.Xml.XmlDocument.CreateNode%2A>  
  
- <xref:System.Xml.XmlDocument.CreateProcessingInstruction%2A>  
  
- <xref:System.Xml.XmlDocument.CreateSignificantWhitespace%2A>  
  
- <xref:System.Xml.XmlDocument.CreateTextNode%2A>  
  
- <xref:System.Xml.XmlDocument.CreateWhitespace%2A>  
  
- <xref:System.Xml.XmlDocument.CreateXmlDeclaration%2A>  
  
 Other node types have more requirements than just providing data to parameters.  
  
 For information on attributes, see [Creating New Attributes for Elements in the DOM](creating-new-attributes-for-elements-in-the-dom.md). For information on element and attribute name validation, see [XML Element and Attribute Name Verification when Creating New Nodes](xml-element-and-attribute-name-verification-when-creating-new-nodes.md). For creating entity references, see [Creating New Entity References](creating-new-entity-references.md). For information on how namespaces affect the expansion of entity references, see [Namespace Affect on Entity Reference Expansion for New Nodes Containing Elements and Attributes](namespace-affect-on-entity-ref-expansion-for-new-nodes.md).  
  
 Once new nodes are created, there are several methods available to insert them into the tree. The table lists the methods with a description of where the new node appears in the XML Document Object Model (DOM).  
  
|Method|Node placement|  
|------------|--------------------|  
|<xref:System.Xml.XmlNode.InsertBefore%2A>|Inserted before the reference node. For example, to insert the new node in position 5:<br /><br /> `XmlNode refChild = node.ChildNodes[4]; // The reference is zero-based.`<br/><br/>`node.InsertBefore(newChild, refChild);`<br /><br /> For more information, see the <xref:System.Xml.XmlNode.InsertBefore%2A> method.|  
|<xref:System.Xml.XmlNode.InsertAfter%2A>|Inserted after the reference node. For example:<br /><br /> `node.InsertAfter(newChild, refChild);`<br /><br /> For more information, see the <xref:System.Xml.XmlNode.InsertAfter%2A> method.|  
|<xref:System.Xml.XmlNode.AppendChild%2A>|Adds the node to the end of the list of child nodes for the given node. If the node being added is an <xref:System.Xml.XmlDocumentFragment>, the entire contents of the document fragment are moved into the child list of this node. For more information, see the <xref:System.Xml.XmlNode.AppendChild%2A> method.|  
|<xref:System.Xml.XmlNode.PrependChild%2A>|Adds the node to the beginning of the list of child nodes of the given node. If the node being added is an <xref:System.Xml.XmlDocumentFragment>, the entire contents of the document fragment are moved into the child list of this node. For more information, see the <xref:System.Xml.XmlNode.PrependChild%2A> method.|  
|<xref:System.Xml.XmlAttributeCollection.Append%2A>|Appends an <xref:System.Xml.XmlAttribute> node to the end of the attribute collection associated with an element. For more information, see the <xref:System.Xml.XmlAttributeCollection.Append%2A> method.|  
  
## See also

- [XML Document Object Model (DOM)](xml-document-object-model-dom.md)

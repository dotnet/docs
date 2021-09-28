---
description: "Learn more about: Removing Nodes from the DOM"
title: "Removing Nodes from the DOM"
ms.date: "03/30/2017"
ms.assetid: 0a98e0ca-0555-45c1-ab69-0d8d20ca1abd
---
# Removing Nodes from the DOM

To remove a node from the XML Document Object Model (DOM), use the <xref:System.Xml.XmlNode.RemoveChild%2A> method to remove a specific node. When you remove a node, the method removes the subtree belonging to the node being removed; that is, if it is not a leaf node.  
  
 To remove multiple nodes from the DOM, use the <xref:System.Xml.XmlNode.RemoveAll%2A> method to remove all the children and attributes, if applicable, of the current node.  
  
 If you are working with an <xref:System.Xml.XmlNamedNodeMap>, you can remove a node using the <xref:System.Xml.XmlNamedNodeMap.RemoveNamedItem%2A> method.  
  
 To remove attributes, see [Removing Attributes from an Element Node in the DOM](removing-attributes-from-an-element-node-in-the-dom.md).  
  
## See also

- [XML Document Object Model (DOM)](xml-document-object-model-dom.md)

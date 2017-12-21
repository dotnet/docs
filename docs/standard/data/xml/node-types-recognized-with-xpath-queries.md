---
title: "Node Types Recognized with XPath Queries"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1d33e22d-18e5-43f8-a466-2e3d0a8dd094
caps.latest.revision: 2
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Node Types Recognized with XPath Queries
The types of nodes recognized in an XPath query are not the same node types found in the Document Object Model (DOM).  
  
## W3C XPath Node Types  
 The types of nodes recognized in an XPath query are not the types of nodes found in the Document Object Model (DOM). The following are the XPath node types represented by the <xref:System.Xml.XPath.XPathNodeType> enumeration.  
  
-   <xref:System.Xml.XPath.XPathNodeType.All>  
  
-   <xref:System.Xml.XPath.XPathNodeType.Attribute>  
  
-   <xref:System.Xml.XPath.XPathNodeType.Comment>  
  
-   <xref:System.Xml.XPath.XPathNodeType.Element>  
  
-   <xref:System.Xml.XPath.XPathNodeType.Namespace>  
  
-   <xref:System.Xml.XPath.XPathNodeType.ProcessingInstruction>  
  
-   <xref:System.Xml.XPath.XPathNodeType.Root>  
  
-   <xref:System.Xml.XPath.XPathNodeType.SignificantWhitespace>  
  
-   <xref:System.Xml.XPath.XPathNodeType.Text>  
  
-   <xref:System.Xml.XPath.XPathNodeType.Whitespace>  
  
 These node types are based on the XPath data model, where the nodes are derived from the XML Information Set. The <xref:System.Xml.XPath.XPathNodeType.SignificantWhitespace> and <xref:System.Xml.XPath.XPathNodeType.Whitespace> node types are Microsoft .NET Framework extensions to the base node types described in the XPath data model.  
  
 The attribute node type is used differently in the XPath data model than it is in the DOM. In the XPath data model, the element node has a set of attribute nodes related to it and the element node is the parent of each attribute node. However, in the DOM, the element node is the owner and not the parent. In both models, attribute and namespace nodes are not considered child nodes of the element node.  
  
 The namespace node type is an addition to the XPath data model and is not a recognized DOM node type.  
  
 For more information about navigating element, attribute, and namespace nodes, see the [Node Set Navigation Using XPathNavigator](../../../../docs/standard/data/xml/node-set-navigation-using-xpathnavigator.md) and [Attribute and Namespace Node Navigation Using XPathNavigator](../../../../docs/standard/data/xml/attribute-and-namespace-node-navigation-using-xpathnavigator.md) topics.  
  
## See Also  
 <xref:System.Xml.XmlDocument>  
 <xref:System.Xml.XPath.XPathDocument>  
 <xref:System.Xml.XPath.XPathNavigator>  
 [Process XML Data Using the XPath Data Model](../../../../docs/standard/data/xml/process-xml-data-using-the-xpath-data-model.md)  
 [Select XML Data Using XPathNavigator](../../../../docs/standard/data/xml/select-xml-data-using-xpathnavigator.md)  
 [Evaluate XPath Expressions using XPathNavigator](../../../../docs/standard/data/xml/evaluate-xpath-expressions-using-xpathnavigator.md)  
 [Matching Nodes using XPathNavigator](../../../../docs/standard/data/xml/matching-nodes-using-xpathnavigator.md)  
 [XPath Queries and Namespaces](../../../../docs/standard/data/xml/xpath-queries-and-namespaces.md)  
 [Compiled XPath Expressions](../../../../docs/standard/data/xml/compiled-xpath-expressions.md)

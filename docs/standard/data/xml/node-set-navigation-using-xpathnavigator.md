---
title: "Node Set Navigation Using XPathNavigator"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1a954b41-7173-40bc-8544-d430f209b1e5
caps.latest.revision: 2
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Node Set Navigation Using XPathNavigator
You can navigate over nodes in an <xref:System.Xml.XPath.XPathDocument> or <xref:System.Xml.XmlDocument> object using the node set navigation methods of the <xref:System.Xml.XPath.XPathNavigator> class. You can navigate over all the nodes or over a selected set of nodes returned by one of the selection methods of the <xref:System.Xml.XPath.XPathNavigator> class.  
  
## Element Node Set Navigation  
 The <xref:System.Xml.XPath.XPathNavigator> class provides several methods used to navigate element nodes. The following table shows the navigation methods available and a description of how they move; this does not include methods used to navigate attribute and namespace nodes.  
  
 For more information about selecting nodes in an <xref:System.Xml.XPath.XPathNavigator> object, see [Selecting, Evaluating and Matching XML Data using XPathNavigator](../../../../docs/standard/data/xml/selecting-evaluating-and-matching-xml-data-using-xpathnavigator.md). For more information about navigating attribute and namespace nodes, see [Attribute and Namespace Node Navigation Using XPathNavigator](../../../../docs/standard/data/xml/attribute-and-namespace-node-navigation-using-xpathnavigator.md).  
  
|Method|Description|  
|------------|-----------------|  
|<xref:System.Xml.XPath.XPathNavigator.MoveTo%2A>|Moves the <xref:System.Xml.XPath.XPathNavigator> to the same position of the <xref:System.Xml.XPath.XPathNavigator> specified.|  
|<xref:System.Xml.XPath.XPathNavigator.MoveToChild%2A>|Moves the <xref:System.Xml.XPath.XPathNavigator> to a child node of the current node.|  
|<xref:System.Xml.XPath.XPathNavigator.MoveToFirst%2A>|Moves the <xref:System.Xml.XPath.XPathNavigator> to the first sibling node of the current node.|  
|<xref:System.Xml.XPath.XPathNavigator.MoveToFirstChild%2A>|Moves the <xref:System.Xml.XPath.XPathNavigator> to the first child node of the current node.|  
|<xref:System.Xml.XPath.XPathNavigator.MoveToFollowing%2A>|Moves the <xref:System.Xml.XPath.XPathNavigator> to the specified element in document order.|  
|<xref:System.Xml.XPath.XPathNavigator.MoveToId%2A>|Moves the <xref:System.Xml.XPath.XPathNavigator> to the node that has an attribute of type `ID` with a value that matches the given <xref:System.String>.|  
|<xref:System.Xml.XPath.XPathNavigator.MoveToNext%2A>|Moves the <xref:System.Xml.XPath.XPathNavigator> to the next sibling node of the current node.|  
|<xref:System.Xml.XPath.XPathNavigator.MoveToParent%2A>|Moves the <xref:System.Xml.XPath.XPathNavigator> to the parent node of the current node.|  
|<xref:System.Xml.XPath.XPathNavigator.MoveToPrevious%2A>|Moves the <xref:System.Xml.XPath.XPathNavigator> to the previous sibling node of the current node.|  
|<xref:System.Xml.XPath.XPathNavigator.MoveToRoot%2A>|Moves the <xref:System.Xml.XPath.XPathNavigator> to the root node of the XML document.|  
  
## Comments and Processing Instruction Node Navigation  
 The following <xref:System.Xml.XPath.XPathNavigator> class methods are valid for moving to comments or processing instructions from other nodes in an XML document.  
  
-   <xref:System.Xml.XPath.XPathNavigator.MoveTo%2A>  
  
-   <xref:System.Xml.XPath.XPathNavigator.MoveToNext%2A>  
  
-   <xref:System.Xml.XPath.XPathNavigator.MoveToPrevious%2A>  
  
-   <xref:System.Xml.XPath.XPathNavigator.MoveToFirst%2A>  
  
-   <xref:System.Xml.XPath.XPathNavigator.MoveToFirstChild%2A>  
  
-   <xref:System.Xml.XPath.XPathNavigator.MoveToChild%2A>  
  
-   <xref:System.Xml.XPath.XPathNavigator.MoveToParent%2A>  
  
-   <xref:System.Xml.XPath.XPathNavigator.MoveToId%2A>  
  
## See Also  
 <xref:System.Xml.XmlDocument>  
 <xref:System.Xml.XPath.XPathDocument>  
 <xref:System.Xml.XPath.XPathNavigator>  
 [Process XML Data Using the XPath Data Model](../../../../docs/standard/data/xml/process-xml-data-using-the-xpath-data-model.md)  
 [Attribute and Namespace Node Navigation Using XPathNavigator](../../../../docs/standard/data/xml/attribute-and-namespace-node-navigation-using-xpathnavigator.md)  
 [Extract XML Data Using XPathNavigator](../../../../docs/standard/data/xml/extract-xml-data-using-xpathnavigator.md)  
 [Accessing Strongly Typed XML Data Using XPathNavigator](../../../../docs/standard/data/xml/accessing-strongly-typed-xml-data-using-xpathnavigator.md)

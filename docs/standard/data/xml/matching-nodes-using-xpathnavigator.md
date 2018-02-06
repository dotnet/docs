---
title: "Matching Nodes using XPathNavigator"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: e6848c47-ee5d-401a-89a5-50b5eed40f30
caps.latest.revision: 2
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Matching Nodes using XPathNavigator
The <xref:System.Xml.XPath.XPathNavigator> class provides the <xref:System.Xml.XPath.XPathNavigator.Matches%2A> method to determine if a node matches an XPath expression. The <xref:System.Xml.XPath.XPathNavigator.Matches%2A> method takes an XPath expression as input and returns a <xref:System.Boolean> that indicates if the current node matches the given XPath expression or the given compiled <xref:System.Xml.XPath.XPathExpression> object.  
  
## Matching Nodes  
 The <xref:System.Xml.XPath.XPathNavigator.Matches%2A> method returns `true` if the current node matches the XPath expression specified. For example, in the code example that follows, the <xref:System.Xml.XPath.XPathNavigator.Matches%2A> method will return `true` if the current node is the element `b`, and element `b` has an attribute `c`.  
  
> [!NOTE]
>  The <xref:System.Xml.XPath.XPathNavigator.Matches%2A> method does not change the state of the <xref:System.Xml.XPath.XPathNavigator>.  
  
```vb  
Dim document as XPathDocument = New XPathDocument("input.xml")  
Dim navigator as XPathNavigator = document.CreateNavigator()  
  
navigator.Matches("b[@c]")  
```  
  
```csharp  
XPathDocument document = new XPathDocument("input.xml");  
XPathNavigator navigator = document.CreateNavigator();  
  
navigator.Matches("b[@c]");  
```  
  
## See Also  
 <xref:System.Xml.XmlDocument>  
 <xref:System.Xml.XPath.XPathDocument>  
 <xref:System.Xml.XPath.XPathNavigator>  
 [Process XML Data Using the XPath Data Model](../../../../docs/standard/data/xml/process-xml-data-using-the-xpath-data-model.md)  
 [Select XML Data Using XPathNavigator](../../../../docs/standard/data/xml/select-xml-data-using-xpathnavigator.md)  
 [Evaluate XPath Expressions using XPathNavigator](../../../../docs/standard/data/xml/evaluate-xpath-expressions-using-xpathnavigator.md)  
 [Node Types Recognized with XPath Queries](../../../../docs/standard/data/xml/node-types-recognized-with-xpath-queries.md)  
 [XPath Queries and Namespaces](../../../../docs/standard/data/xml/xpath-queries-and-namespaces.md)  
 [Compiled XPath Expressions](../../../../docs/standard/data/xml/compiled-xpath-expressions.md)

---
description: "Learn more about: Evaluate XPath Expressions using XPathNavigator"
title: "Evaluate XPath Expressions using XPathNavigator"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 2913ccf3-f932-4363-8028-9e2d22ce6093
---
# Evaluate XPath Expressions using XPathNavigator

The <xref:System.Xml.XPath.XPathNavigator> class provides the <xref:System.Xml.XPath.XPathNavigator.Evaluate%2A> method to evaluate an XPath expression. The <xref:System.Xml.XPath.XPathNavigator.Evaluate%2A> method takes an XPath expression, evaluates it and returns a W3C XPath type of Boolean, Number, String, or Node Set based on the result of the XPath expression.  
  
## The Evaluate Method  

 The <xref:System.Xml.XPath.XPathNavigator.Evaluate%2A> method takes an XPath expression, evaluates it, and returns a typed result of Boolean (<xref:System.Boolean>), Number (<xref:System.Double>), String (<xref:System.String>), or Node Set (<xref:System.Xml.XPath.XPathNodeIterator>). For example, the <xref:System.Xml.XPath.XPathNavigator.Evaluate%2A> method could be used in a mathematical method. The following example code calculates the total price of all the books in the `books.xml` file.  
  
```vb  
Dim document As XPathDocument = New XPathDocument("books.xml")  
Dim navigator As XPathNavigator = document.CreateNavigator()  
  
Dim query As XPathExpression = navigator.Compile("sum(//price/text())")  
Dim total As Double = CType(navigator.Evaluate(query), Double)  
Console.WriteLine(total)  
```  
  
```csharp  
XPathDocument document = new XPathDocument("books.xml");  
XPathNavigator navigator = document.CreateNavigator();  
  
XPathExpression query = navigator.Compile("sum(//price/text())");  
Double total = (Double)navigator.Evaluate(query);  
Console.WriteLine(total);  
```  
  
 The example takes the `books.xml` file as input.  
  
 [!code-xml[XPathXMLExamples#1](../../../../samples/snippets/xml/VS_Snippets_Data/XPathXMLExamples/XML/books.xml#1)]  
  
### position and last Functions  

 The <xref:System.Xml.XPath.XPathNavigator.Evaluate%2A> method is overloaded. One of the <xref:System.Xml.XPath.XPathNavigator.Evaluate%2A> methods takes an <xref:System.Xml.XPath.XPathNodeIterator> object as a parameter. This particular <xref:System.Xml.XPath.XPathNavigator.Evaluate%2A> method is identical to the <xref:System.Xml.XPath.XPathNavigator.Evaluate%2A> method that takes only an <xref:System.Xml.XPath.XPathExpression> object as a parameter, except that it allows a node set argument to specify the current context to perform the evaluation on. This context is required for the XPath `position()` and `last()` functions as they are relative to the current context node. Unless used as a predicate in a location step, the `position()` and `last()` functions require a reference to a node set in order to be evaluated otherwise, the `position` and `last` functions return `0`.  
  
## See also

- <xref:System.Xml.XmlDocument>
- <xref:System.Xml.XPath.XPathDocument>
- <xref:System.Xml.XPath.XPathNavigator>
- [Process XML Data Using the XPath Data Model](process-xml-data-using-the-xpath-data-model.md)
- [Select XML Data Using XPathNavigator](select-xml-data-using-xpathnavigator.md)
- [Matching Nodes using XPathNavigator](matching-nodes-using-xpathnavigator.md)
- [Node Types Recognized with XPath Queries](node-types-recognized-with-xpath-queries.md)
- [XPath Queries and Namespaces](xpath-queries-and-namespaces.md)
- [Compiled XPath Expressions](compiled-xpath-expressions.md)

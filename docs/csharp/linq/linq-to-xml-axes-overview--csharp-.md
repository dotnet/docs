---
title: "LINQ to XML Axes Overview (C#)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
ms.assetid: 516792fb-461d-40a8-8a50-9993a51258fc
caps.latest.revision: 4
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# LINQ to XML Axes Overview (C#)
After you have created an XML tree or loaded an XML document into an XML tree, you can query it to find elements and attributes and retrieve their values. You retrieve collections through the *axis methods*, also called *axes*. Some of the axes are methods in the <xref:System.Xml.Linq.XElement> and <xref:System.Xml.Linq.XDocument> classes that return <xref:System.Collections.Generic.IEnumerable`1> collections. Some of the axes are extension methods in the <xref:System.Xml.Linq.Extensions> class. The axes that are implemented as extension methods operate on collections, and return collections.  
  
 As described in [XElement Class Overview](../Topic/XElement%20Class%20Overview.md), an <xref:System.Xml.Linq.XElement> object represents a single element node. The content of an element can be complex (sometimes called structured content), or it can be a simple element. A simple element can be empty or can contain a value. If the node contains structured content, you can use the various axis methods to retrieve enumerations of descendant elements. The most commonly used axis methods are <xref:System.Xml.Linq.XContainer.Elements*> and <xref:System.Xml.Linq.XContainer.Descendants*>.  
  
 In addition to the axis methods, which return collections, there are two more methods that you will commonly use in [!INCLUDE[sqltecxlinq](../linq/includes/sqltecxlinq_md.md)] queries. The <xref:System.Xml.Linq.XContainer.Element*> method returns a single <xref:System.Xml.Linq.XElement>. The <xref:System.Xml.Linq.XElement.Attribute*> method returns a single <xref:System.Xml.Linq.XAttribute>.  
  
 For many purposes, [!INCLUDE[vbteclinq](../classes-and-structs/includes/vbteclinq_md.md)] queries provide the most powerful way to examine a tree, extract data from it, and transform it. [!INCLUDE[vbteclinq](../classes-and-structs/includes/vbteclinq_md.md)] queries operate on objects that implement <xref:System.Collections.Generic.IEnumerable`1>, and the [!INCLUDE[sqltecxlinq](../linq/includes/sqltecxlinq_md.md)] axes return <xref:System.Collections.Generic.IEnumerable`1> of <xref:System.Xml.Linq.XElement> collections, and <xref:System.Collections.Generic.IEnumerable`1> of <xref:System.Xml.Linq.XAttribute> collections. You need these collections to perform your queries.  
  
 In addition to the axis methods that retrieve collections of elements and attributes, there are axis methods that allow you to iterate through the tree in great detail. For example, instead of dealing with elements and attributes, you can work with the nodes of the tree. Nodes are a finer level of granularity than elements and attributes. When working with nodes, you can examine XML comments, text nodes, processing instructions, and more. This functionality is important, for example, to someone who is writing a word processor and wants to save documents as XML. However, the majority of XML programmers are primarily concerned with elements, attributes, and their values.  
  
## Methods for Retrieving a Collection of Elements  
 The following is a summary of the methods of the <xref:System.Xml.Linq.XElement> class (or its base classes) that you call on an <xref:System.Xml.Linq.XElement> to return a collection of elements.  
  
|Method|Description|  
|------------|-----------------|  
|<xref:System.Xml.Linq.XNode.Ancestors*?displayProperty=fullName>|Returns an <xref:System.Collections.Generic.IEnumerable`1> of <xref:System.Xml.Linq.XElement> of the ancestors of this element. An overload returns an <xref:System.Collections.Generic.IEnumerable`1> of <xref:System.Xml.Linq.XElement> of the ancestors that have the specified <xref:System.Xml.Linq.XName>.|  
|<xref:System.Xml.Linq.XContainer.Descendants*?displayProperty=fullName>|Returns an <xref:System.Collections.Generic.IEnumerable`1> of <xref:System.Xml.Linq.XElement> of the descendants of this element. An overload returns an <xref:System.Collections.Generic.IEnumerable`1> of <xref:System.Xml.Linq.XElement> of the descendants that have the specified <xref:System.Xml.Linq.XName>.|  
|<xref:System.Xml.Linq.XContainer.Elements*?displayProperty=fullName>|Returns an <xref:System.Collections.Generic.IEnumerable`1> of <xref:System.Xml.Linq.XElement> of the child elements of this element. An overload returns an <xref:System.Collections.Generic.IEnumerable`1> of <xref:System.Xml.Linq.XElement> of the child elements that have the specified <xref:System.Xml.Linq.XName>.|  
|<xref:System.Xml.Linq.XNode.ElementsAfterSelf*?displayProperty=fullName>|Returns an <xref:System.Collections.Generic.IEnumerable`1> of <xref:System.Xml.Linq.XElement> of the elements that come after this element. An overload returns an <xref:System.Collections.Generic.IEnumerable`1> of <xref:System.Xml.Linq.XElement> of the elements after this element that have the specified <xref:System.Xml.Linq.XName>.|  
|<xref:System.Xml.Linq.XNode.ElementsBeforeSelf*?displayProperty=fullName>|Returns an <xref:System.Collections.Generic.IEnumerable`1> of <xref:System.Xml.Linq.XElement> of the elements that come before this element. An overload returns an <xref:System.Collections.Generic.IEnumerable`1> of <xref:System.Xml.Linq.XElement> of the elements before this element that have the specified <xref:System.Xml.Linq.XName>.|  
|<xref:System.Xml.Linq.XElement.AncestorsAndSelf*?displayProperty=fullName>|Returns an <xref:System.Collections.Generic.IEnumerable`1> of <xref:System.Xml.Linq.XElement> of this element and its ancestors. An overload returns an <xref:System.Collections.Generic.IEnumerable`1> of <xref:System.Xml.Linq.XElement> of the elements that have the specified <xref:System.Xml.Linq.XName>.|  
|<xref:System.Xml.Linq.XElement.DescendantsAndSelf*?displayProperty=fullName>|Returns an <xref:System.Collections.Generic.IEnumerable`1> of <xref:System.Xml.Linq.XElement> of this element and its descendants. An overload returns an <xref:System.Collections.Generic.IEnumerable`1> of <xref:System.Xml.Linq.XElement> of the elements that have the specified <xref:System.Xml.Linq.XName>.|  
  
## Method for Retrieving a Single Element  
 The following method retrieves a single child from an <xref:System.Xml.Linq.XElement> object.  
  
|Method|Description|  
|------------|-----------------|  
|<xref:System.Xml.Linq.XContainer.Element*?displayProperty=fullName>|Returns the first child <xref:System.Xml.Linq.XElement> object that has the specified <xref:System.Xml.Linq.XName>.|  
  
## Method for Retrieving a Collection of Attributes  
 The following method retrieves attributes from an <xref:System.Xml.Linq.XElement> object.  
  
|Method|Description|  
|------------|-----------------|  
|<xref:System.Xml.Linq.XElement.Attributes*?displayProperty=fullName>|Returns an <xref:System.Collections.Generic.IEnumerable`1> of <xref:System.Xml.Linq.XAttribute> of all of the attributes.|  
  
## Method for Retrieving a Single Attribute  
 The following method retrieves a single attribute from an <xref:System.Xml.Linq.XElement> object.  
  
|Method|Description|  
|------------|-----------------|  
|<xref:System.Xml.Linq.XElement.Attribute*?displayProperty=fullName>|Returns the <xref:System.Xml.Linq.XAttribute> that has the specified <xref:System.Xml.Linq.XName>.|  
  
## See Also  
 [LINQ to XML Axes (C#)](../linq/linq-to-xml-axes--csharp-.md)
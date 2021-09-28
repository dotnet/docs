---
title: LINQ to XML axes overview - LINQ to XML
description: Use axis methods from the XElement, XDocument, and IEnumerable classes to find elements in an XML tree and retrieve their values.
ms.date: 07/20/2015
ms.assetid: 516792fb-461d-40a8-8a50-9993a51258fc
---
# LINQ to XML axes overview

After you've created an XML tree or loaded an XML document into an XML tree, you can query it to find elements and attributes and retrieve their values. You retrieve collections through the *axis methods*, also called *axes*. Some of the axes are methods in the <xref:System.Xml.Linq.XElement> and <xref:System.Xml.Linq.XDocument> classes that return <xref:System.Collections.Generic.IEnumerable%601> collections. Some of the axes are extension methods in the <xref:System.Xml.Linq.Extensions> class. The axes that are implemented as extension methods operate on collections and return collections.

As described in [XElement class overview](xelement-class-overview.md), an <xref:System.Xml.Linq.XElement> object represents a single element node. The content of an element can be complex (sometimes called structured content), or it can be a simple element. A simple element can be empty or can contain a value. If the node contains structured content, you can use the various axis methods to retrieve enumerations of descendant elements. The most commonly used axis methods are <xref:System.Xml.Linq.XContainer.Elements%2A> and <xref:System.Xml.Linq.XContainer.Descendants%2A>.

In addition to the axis methods, which return collections, there are two more methods that you'll commonly use in LINQ to XML queries. The <xref:System.Xml.Linq.XContainer.Element%2A> method returns a single <xref:System.Xml.Linq.XElement>. The <xref:System.Xml.Linq.XElement.Attribute%2A> method returns a single <xref:System.Xml.Linq.XAttribute>.

For many purposes, LINQ queries provide the most powerful way to examine a tree, extract data from it, and transform it. LINQ queries operate on objects that implement <xref:System.Collections.Generic.IEnumerable%601>, and the LINQ to XML axes return <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XElement> collections, and <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XAttribute> collections. You need these collections to do your queries.

In addition to the axis methods that retrieve collections of elements and attributes, there are axis methods that allow you to iterate through the tree in great detail. For example, instead of dealing with elements and attributes, you can work with the nodes of the tree. Nodes are a finer level of granularity than elements and attributes. When working with nodes, you can examine XML comments, text nodes, processing instructions, and more. This functionality is important, for example, to someone who is writing a word processor and wants to save documents as XML. However, the majority of XML programmers are primarily concerned with elements, attributes, and their values.

## Methods for retrieving a collection of elements

The following is a summary of the methods of the <xref:System.Xml.Linq.XElement> class (or its base classes) that you call on an <xref:System.Xml.Linq.XElement> to return a collection of elements.

|Method|Description|
|------------|-----------------|
|<xref:System.Xml.Linq.XNode.Ancestors%2A?displayProperty=nameWithType>|Returns an <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XElement> of the ancestors of this element. An overload returns an <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XElement> of the ancestors that have the specified <xref:System.Xml.Linq.XName>.|
|<xref:System.Xml.Linq.XContainer.Descendants%2A?displayProperty=nameWithType>|Returns an <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XElement> of the descendants of this element. An overload returns an <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XElement> of the descendants that have the specified <xref:System.Xml.Linq.XName>.|
|<xref:System.Xml.Linq.XContainer.Elements%2A?displayProperty=nameWithType>|Returns an <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XElement> of the child elements of this element. An overload returns an <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XElement> of the child elements that have the specified <xref:System.Xml.Linq.XName>.|
|<xref:System.Xml.Linq.XNode.ElementsAfterSelf%2A?displayProperty=nameWithType>|Returns an <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XElement> of the elements that come after this element. An overload returns an <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XElement> of the elements after this element that have the specified <xref:System.Xml.Linq.XName>.|
|<xref:System.Xml.Linq.XNode.ElementsBeforeSelf%2A?displayProperty=nameWithType>|Returns an <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XElement> of the elements that come before this element. An overload returns an <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XElement> of the elements before this element that have the specified <xref:System.Xml.Linq.XName>.|
|<xref:System.Xml.Linq.XElement.AncestorsAndSelf%2A?displayProperty=nameWithType>|Returns an <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XElement> of this element and its ancestors. An overload returns an <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XElement> of the elements that have the specified <xref:System.Xml.Linq.XName>.|
|<xref:System.Xml.Linq.XElement.DescendantsAndSelf%2A?displayProperty=nameWithType>|Returns an <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XElement> of this element and its descendants. An overload returns an <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XElement> of the elements that have the specified <xref:System.Xml.Linq.XName>.|

## Method for retrieving a single element

The following method retrieves a single child from an <xref:System.Xml.Linq.XElement> object.

|Method|Description|
|------------|-----------------|
|<xref:System.Xml.Linq.XContainer.Element%2A?displayProperty=nameWithType>|Returns the first child <xref:System.Xml.Linq.XElement> object that has the specified <xref:System.Xml.Linq.XName>.|

## Method for retrieving a collection of attributes

The following method retrieves attributes from an <xref:System.Xml.Linq.XElement> object.

|Method|Description|
|------------|-----------------|
|<xref:System.Xml.Linq.XElement.Attributes%2A?displayProperty=nameWithType>|Returns an <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XAttribute> of all of the attributes.|

## Method for retrieving a single attribute

The following method retrieves a single attribute from an <xref:System.Xml.Linq.XElement> object.

|Method|Description|
|------------|-----------------|
|<xref:System.Xml.Linq.XElement.Attribute%2A?displayProperty=nameWithType>|Returns the <xref:System.Xml.Linq.XAttribute> that has the specified <xref:System.Xml.Linq.XName>.|

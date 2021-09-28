---
title: "Modifying Elements, Attributes, and Nodes in an XML Tree"
description: Learn about methods and properties that you can use to modify an element, its child nodes, or its attributes.
ms.date: 07/20/2015
ms.topic: reference
---

# Modify elements, attributes, and nodes in an XML tree (LINQ to XML)

The following table summarizes the methods and properties that you can use to modify an element, its child elements, or its attributes.

The following methods modify an <xref:System.Xml.Linq.XElement>:

|Method|Description|
|------------|-----------------|
|<xref:System.Xml.Linq.XElement.Parse%2A?displayProperty=nameWithType>|Replaces an element with parsed XML.|
|<xref:System.Xml.Linq.XElement.RemoveAll%2A?displayProperty=nameWithType>|Removes all content (child nodes and attributes) of an element.|
|<xref:System.Xml.Linq.XElement.RemoveAttributes%2A?displayProperty=nameWithType>|Removes the attributes of an element.|
|<xref:System.Xml.Linq.XElement.ReplaceAll%2A?displayProperty=nameWithType>|Replaces all content (child nodes and attributes) of an element.|
|<xref:System.Xml.Linq.XElement.ReplaceAttributes%2A?displayProperty=nameWithType>|Replaces the attributes of an element.|
|<xref:System.Xml.Linq.XElement.SetAttributeValue%2A?displayProperty=nameWithType>|Sets the value of an attribute. Creates the attribute if it doesn't exist. If the value is set to `null`, removes the attribute.|
|<xref:System.Xml.Linq.XElement.SetElementValue%2A?displayProperty=nameWithType>|Sets the value of a child element. Creates the element if it doesn't exist. If the value is set to `null`, removes the element.|
|<xref:System.Xml.Linq.XElement.Value%2A?displayProperty=nameWithType>|Replaces the content (child nodes) of an element with the specified text.|
|<xref:System.Xml.Linq.XElement.SetValue%2A?displayProperty=nameWithType>|Sets the value of an element.|

The following methods modify an <xref:System.Xml.Linq.XAttribute>:

|Method|Description|
|------------|-----------------|
|<xref:System.Xml.Linq.XAttribute.Value%2A?displayProperty=nameWithType>|Sets the value of an attribute.|
|<xref:System.Xml.Linq.XAttribute.SetValue%2A?displayProperty=nameWithType>|Sets the value of an attribute.|

 The following methods modify an <xref:System.Xml.Linq.XNode> (including an <xref:System.Xml.Linq.XElement> or <xref:System.Xml.Linq.XDocument>):

|Method|Description|
|------------|-----------------|
|<xref:System.Xml.Linq.XNode.ReplaceWith%2A?displayProperty=nameWithType>|Replaces a node with new content.|

 The following methods modify an <xref:System.Xml.Linq.XContainer> (an <xref:System.Xml.Linq.XElement> or <xref:System.Xml.Linq.XDocument>):

|Method|Description|
|------------|-----------------|
|<xref:System.Xml.Linq.XContainer.ReplaceNodes%2A?displayProperty=nameWithType>|Replaces the children nodes with new content:|

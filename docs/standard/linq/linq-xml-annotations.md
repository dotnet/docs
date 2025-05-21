---
title: Annotations - LINQ to XML
description: Learn how to use annotations in LINQ to XML to associate any arbitrary object of any arbitrary type with any XML component in an XML tree.
ms.date: 07/20/2015
ms.assetid: 54e7b9d0-07f5-488f-9065-b6e6b870f810
ms.topic: article
---
# LINQ to XML annotations (LINQ to XML)

Annotations in LINQ to XML enable you to associate any arbitrary object of any arbitrary type with any XML component in an XML tree.

To add an annotation to an XML component, such as an <xref:System.Xml.Linq.XElement> or <xref:System.Xml.Linq.XAttribute>, you call the <xref:System.Xml.Linq.XObject.AddAnnotation%2A> method. You retrieve annotations by type.

Note that annotations aren't part of the XML infoset; they're not serialized or deserialized.

## Methods

You can use the following methods when working with annotations:

|Method|Description|
|------------|-----------------|
|<xref:System.Xml.Linq.XObject.AddAnnotation%2A>|Adds an object to the annotation list of an <xref:System.Xml.Linq.XObject>.|
|<xref:System.Xml.Linq.XObject.Annotation%2A>|Gets the first annotation object of the specified type from an <xref:System.Xml.Linq.XObject>.|
|<xref:System.Xml.Linq.XObject.Annotations%2A>|Gets a collection of annotations of the specified type for an <xref:System.Xml.Linq.XObject>.|
|<xref:System.Xml.Linq.XObject.RemoveAnnotations%2A>|Removes the annotations of the specified type from an <xref:System.Xml.Linq.XObject>.|

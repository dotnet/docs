---
title: LINQ to XML dynamic properties reference
ms.date: 10/22/2019
ms.topic: reference
---
# LINQ to XML dynamic properties

This section provides reference information about the dynamic properties in LINQ to XML. Specifically, these properties are exposed by the <xref:System.Xml.Linq.XAttribute> and <xref:System.Xml.Linq.XElement> classes, which are in the <xref:System.Xml.Linq> namespace.

As explained in the topic [Overview of WPF data binding with LINQ to XML](wpf-data-binding-with-linq-to-xml-overview.md), each of the dynamic properties is equivalent to a standard public property or method in the same class. These standard members should be used for most purposes; dynamic properties are provided specifically for LINQ to XML data binding scenarios. For more information about the standard members of these classes, see the <xref:System.Xml.Linq.XAttribute> and <xref:System.Xml.Linq.XElement> reference topics.

With respect to their resolved values, the dynamic properties in this section fall into two categories:

- Simple ones, such as the `Value` properties in the <xref:System.Xml.Linq.XAttribute> and <xref:System.Xml.Linq.XElement> classes, that resolve to a single value.

- Indexed values, such as the [Elements](elements-xelement-dynamic-property.md) and [Descendants](descendants-xelement-dynamic-property.md) properties of <xref:System.Xml.Linq.XElement>, that resolve into an indexer type. For indexer types to be resolved to the desired value or collection, an expanded name parameter must be passed to them.

All the dynamic properties that return an indexed value of type <xref:System.Collections.Generic.IEnumerable%601> use deferred execution. For more information about deferred execution, see [Introduction to LINQ queries (C#)](../../../csharp/programming-guide/concepts/linq/introduction-to-linq-queries.md).

## Reference

- <xref:System.Xml.Linq>
- <xref:System.Xml.Linq.XElement?displayProperty=fullName>
- <xref:System.Xml.Linq.XAttribute?displayProperty=fullName>

## See also

- [WPF data binding with LINQ to XML](wpf-data-binding-with-linq-to-xml-overview.md)
- [WPF data binding with LINQ to XML overview](wpf-data-binding-with-linq-to-xml-overview.md)
- [Introduction to LINQ queries (C#)](../../../csharp/programming-guide/concepts/linq/introduction-to-linq-queries.md)

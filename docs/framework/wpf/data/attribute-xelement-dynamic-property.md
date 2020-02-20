---
title: Attribute (XElement dynamic property)
ms.date: 10/22/2019
ms.topic: reference
---
# Attribute (XElement dynamic property)

Gets an indexer used to retrieve the attribute instance that corresponds to the specified expanded name.

## Syntax

```xaml
elem.Attribute[{namespaceName}attribName]
```

## Property value/return value

An indexer of the type `XAttribute Item(String expandedName)`. This indexer takes the expanded name of the specified attribute and returns the corresponding <xref:System.Xml.Linq.XAttribute>, or `null` if there is no attribute with the specified name.

## Remarks

This property is equivalent to the <xref:System.Xml.Linq.XElement.Attribute%2A> method of the <xref:System.Xml.Linq.XElement?displayProperty=fullName> class.

## See also

- <xref:System.Xml.Linq.XElement.Attribute%2A?displayProperty=fullName>
- [XElement Class Dynamic Properties](attribute-xelement-dynamic-property.md)
- [Value](value-xattribute-dynamic-property.md)

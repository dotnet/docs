---
title: Element (XElement dynamic property)
ms.date: 10/22/2019
ms.topic: reference
apiname:
  - "XElement.Element"
apitype: "Assembly"
---
# Element (XElement dynamic property)

Gets an indexer used to retrieve the child element instance that corresponds to the specified expanded name.

## Syntax

```xaml
elem.Element[{namespaceName}localName]
```

## Property value/return value

An indexer of the type `XElement Item(String expandedName)`. This indexer takes an expanded name parameter and returns the corresponding <xref:System.Xml.Linq.XElement>, or `null` if there is no element with the specified name.

## Remarks

This property is equivalent to <xref:System.Xml.Linq.XContainer.Element%2A> method of the <xref:System.Xml.Linq.XContainer?displayProperty=fullName> class.

## See also

- <xref:System.Xml.Linq.XContainer.Element%2A?displayProperty=fullName>
- [XElement class dynamic properties](attribute-xelement-dynamic-property.md)
- [Elements](elements-xelement-dynamic-property.md)

---
title: Elements (XElement dynamic property)
ms.date: 10/22/2019
ms.topic: reference
apiname:
  - "XElement.Elements"
apitype: "Assembly"
---
# Elements (XElement dynamic property)

Gets an indexer used to retrieve the child elements of the current element that match the specified expanded name.

## Syntax

```xaml
elem.Elements[{namespaceName}localName]
```

## Property value/return value

An indexer of the type `IEnumerable<XElement> Item(String expandedName)`. This indexer takes the expanded name of the desired child elements and returns the matching child elements in an <xref:System.Collections.IEnumerable>`<`<xref:System.Xml.Linq.XElement>`>` collection.

## Remarks

This property is equivalent to the <xref:System.Xml.Linq.XContainer.Elements(System.Xml.Linq.XName)?displayProperty=fullName> method of the <xref:System.Xml.Linq.XContainer> class.

The elements in the returned collection are in XML source document order.

This property uses deferred execution.

## See also

- [XElement class dynamic properties](attribute-xelement-dynamic-property.md)
- [Element](element-xelement-dynamic-property.md)
- [Descendants](descendants-xelement-dynamic-property.md)

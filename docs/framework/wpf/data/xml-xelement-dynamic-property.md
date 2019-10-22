---
title: Xml (XElement dynamic property)
ms.date: 10/22/2019
ms.topic: reference
apiname:
  - "XElement.Xml"
---
# Xml (XElement dynamic property)

Gets the unformatted XML content of the element.

## Syntax

```xaml
elem.Xml
```

## Property value/return value

A <xref:System.String> that represents the unformatted XML content of the element.

## Remarks

This property is equivalent to the <xref:System.Xml.Linq.XNode.ToString(System.Xml.Linq.SaveOptions)> method of the <xref:System.Xml.Linq.XNode?displayProperty=fullName> class, with the `SaveOptions` parameter set to <xref:System.Xml.Linq.SaveOptions>.

## See also

- [XElement class dynamic properties](attribute-xelement-dynamic-property.md)
- [Value](value-xelement-dynamic-property.md)

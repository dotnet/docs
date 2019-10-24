---
title: Value (XAttribute dynamic property)
ms.date: 10/22/2019
ms.topic: reference
apiname:
  - "XAttribute.Value"
apitype: "Assembly"
---
# Value (XAttribute dynamic property)

Gets or sets the value of the XML attribute.

## Syntax

```xaml
attrib.Value
```

## Property value/return value

A <xref:System.String> containing the value of this attribute.

## Exceptions

|Exception type|Condition|
| - |---------------|
|<xref:System.ArgumentNullException>|When setting, the `value` is `null`.|

## Remarks

This property is equivalent to the <xref:System.Xml.Linq.XAttribute.Value%2A> property of the <xref:System.Xml.Linq.XAttribute?displayProperty=fullName> class, but this dynamic property also supports change notifications.

## See also

- <xref:System.Xml.Linq.XAttribute.Value%2A?displayProperty=fullName>
- [XAttribute class dynamic properties](value-xattribute-dynamic-property.md)
- [Attribute](attribute-xelement-dynamic-property.md)

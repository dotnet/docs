---
title: "Breaking change: XmlDocument.XmlResolver nullability change"
description: Learn about the .NET 6 breaking change where the setter for XmlDocument.XmlResolver was made nullable.
ms.date: 11/04/2021
---
# XmlDocument.XmlResolver nullability change

The nullability for <xref:System.Xml.XmlDocument.XmlResolver?displayProperty=nameWithType> has changed in .NET 6. The property setter now accepts a nullable reference.

## Previous behavior

The setter for <xref:System.Xml.XmlDocument.XmlResolver?displayProperty=nameWithType> was annotated as not accepting `null`:

```csharp
public virtual System.Xml.XmlResolver XmlResolver { set { } }
```

## New behavior

The setter for <xref:System.Xml.XmlDocument.XmlResolver?displayProperty=nameWithType> is annotated as accepting `null`:

```csharp
public virtual System.Xml.XmlResolver? XmlResolver { set { } }
```

## Version introduced

6.0 RC 1

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility) if you've overridden this property in a derived type.

## Reason for change

The non-nullable annotation was incorrect.

## Recommended action

If you have overridden this property in a derived type, you'll need to update your code to handle `null` when setting the property value.

## Affected APIs

- <xref:System.Xml.XmlDocument.XmlResolver?displayProperty=fullName>

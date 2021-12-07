---
title: "Breaking change: XNodeReader.GetAttribute and invalid indices"
description: Learn about the .NET 6 breaking change where XNodeReader.GetAttribute now throws an exception for an invalid index.
ms.date: 10/19/2021
---
# XNodeReader.GetAttribute behavior for invalid index

`XNodeReader` is an internal class, but it's accessible through the <xref:System.Xml.XmlReader> class if you call <xref:System.Xml.Linq.XNode.CreateReader%2A?displayProperty=nameWithType>. All <xref:System.Xml.XmlReader> implementations except `XNodeReader` threw an <xref:System.ArgumentOutOfRangeException> for an invalid index in the <xref:System.Xml.XmlReader.GetAttribute(System.Int32)> method. With this change, `XNodeReader.GetAttribute(int)` now also throws an <xref:System.ArgumentOutOfRangeException> for an invalid index.

## Old behavior

`XNodeReader.GetAttribute(int)` returned `null` if the index was invalid.

## New behavior

`XNodeReader.GetAttribute(int)` throws an <xref:System.ArgumentOutOfRangeException> if the index is invalid.

## Version introduced

.NET 6

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

`XmlReader.GetAttribute(int)` is well documented, and `XNodeReader` was not behaving as documented. It's behavior for invalid indices was also inconsistent with other <xref:System.Xml.XmlReader> implementations.

## Recommended action

To avoid an invalid index:

- Call <xref:System.Xml.XmlReader.AttributeCount?displayProperty=nameWithType> to retrieve the number of attributes in the current node.
- Then, pass a value of range `0..XmlReader.AttributeCount-1` to <xref:System.Xml.XmlReader.GetAttribute(System.Int32)?displayProperty=nameWithType>.

## Affected APIs

- <xref:System.Xml.XmlReader.GetAttribute(System.Int32)?displayProperty=fullName>

---
title: "Breaking change: 'GetXmlNamespaceMaps' type change"
description: Learn about the breaking change in .NET 9 for WPF where the backing property of 'XmlNamespaceMaps' has been changed from 'String' to 'Hashtable'.
ms.date: 03/15/2024
ms.topic: concept-article
---
# `GetXmlNamespaceMaps` type change

The backing property of <xref:System.Windows.Markup.XmlAttributeProperties.XmlNamespaceMaps?displayProperty=nameWithType> has been changed from <xref:System.String> to <xref:System.Collections.Hashtable>.

## Version introduced

.NET 9 Preview 3

## Previous behavior

Previously, the backing property of <xref:System.Windows.Markup.XmlAttributeProperties.XmlNamespaceMaps> was <xref:System.String>. However, the value returned by `dependencyObject.GetValue(XmlNamespaceMapsProperty)` is of type <xref:System.Collections.Hashtable> and the <xref:System.Windows.Markup.XmlAttributeProperties.GetXmlNamespaceMaps(System.Windows.DependencyObject)> implementation tried to type cast it to <xref:System.String>, which resulted in an <xref:System.InvalidCastException>.

In addition, the <xref:System.Windows.Markup.XmlAttributeProperties.SetXmlNamespaceMaps(System.Windows.DependencyObject,System.String)> method accepted a <xref:System.String> argument.

## New behavior

Starting in .NET 9, the backing property of <xref:System.Windows.Markup.XmlAttributeProperties.XmlNamespaceMaps> is <xref:System.Collections.Hashtable>, and the <xref:System.InvalidCastException> is no longer thrown by <xref:System.Windows.Markup.XmlAttributeProperties.GetXmlNamespaceMaps(System.Windows.DependencyObject)>.

In addition, the <xref:System.Windows.Markup.XmlAttributeProperties.SetXmlNamespaceMaps(System.Windows.DependencyObject,System.Collections.Hashtable)> method now accepts a <xref:System.Collections.Hashtable> argument.

## Change category

This change is a [*behavioral change*](../../categories.md#behavioral-change) and can also affect [*source compatibility*](../../categories.md#source-compatibility).

## Reason for change

This change was made to prevent the <xref:System.InvalidCastException> from being thrown.

## Recommended action

Pass `Hashtable` instead of a string to the <xref:System.Windows.Markup.XmlAttributeProperties.SetXmlNamespaceMaps%2A> API.

## Affected APIs

- <xref:System.Windows.Markup.XmlAttributeProperties.GetXmlNamespaceMaps(System.Windows.DependencyObject)?displayProperty=fullName>
- <xref:System.Windows.Markup.XmlAttributeProperties.SetXmlNamespaceMaps%2A?displayProperty=fullName>

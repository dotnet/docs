---
title: "Breaking change: Renamed parameter in HtmlElement.InsertAdjacentElement"
description: Learn about the .NET 10 Preview 1 breaking change in core .NET libraries where the parameter `orient` was renamed to `orientation`.
ms.date: 01/30/2025
---

# Renamed parameter in HtmlElement.InsertAdjacentElement

<xref:System.Windows.Forms.HtmlElement.InsertAdjacentElement(System.Windows.Forms.HtmlElementInsertionOrientation,System.Windows.Forms.HtmlElement)?displayProperty=nameWithType> parameter `orient` was renamed to `orientation`.

## Previous behavior

Calls to <xref:System.Windows.Forms.HtmlElement.InsertAdjacentElement(System.Windows.Forms.HtmlElementInsertionOrientation,System.Windows.Forms.HtmlElement)?displayProperty=nameWithType> included the `orient` parameter:

```csharp
element.InsertAdjacentElement(orient: HtmlElementInsertionOrientation.AfterEnd, newElement);
```

## New behavior

Calls should be edited to have the new parameter name (`orientation`) or the parameter name should be removed:

```csharp
element.InsertAdjacentElement(orientation: HtmlElementInsertionOrientation.AfterEnd, newElement);
```

```csharp
element.InsertAdjacentElement(HtmlElementInsertionOrientation.AfterEnd, newElement);
```

## Version introduced

.NET 10 Preview 1

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

The parameter name was changed to provide a more descriptive name.

## Recommended action

Calls should be edited to have the new parameter name or the parameter name should be removed:

```csharp
element.InsertAdjacentElement(orientation: HtmlElementInsertionOrientation.AfterEnd, newElement);
```

```csharp
element.InsertAdjacentElement(HtmlElementInsertionOrientation.AfterEnd, newElement);
```

## Affected APIs

- <xref:System.Windows.Forms.HtmlElement.InsertAdjacentElement(System.Windows.Forms.HtmlElementInsertionOrientation,System.Windows.Forms.HtmlElement)?displayProperty=fullName>

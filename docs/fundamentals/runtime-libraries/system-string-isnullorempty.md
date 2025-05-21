---
title: System.String.IsNullOrEmpty method
description: Learn about the System.String.IsNullOrEmpty method.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.String.IsNullOrEmpty method

[!INCLUDE [context](includes/context.md)]

<xref:System.String.IsNullOrEmpty%2A> is a convenience method that enables you to simultaneously test whether a <xref:System.String> is `null` or its value is <xref:System.String.Empty?displayProperty=nameWithType>. It is equivalent to the following code:

:::code language="csharp" source="./snippets/System/String/IsNullOrEmpty/csharp/isnullorempty1.cs" interactive="try-dotnet-method" id="Snippet1":::
:::code language="vb" source="./snippets/System/String/IsNullOrEmpty/vb/isnullorempty1.vb" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/String/IsNullOrEmpty/fsharp/isnullorempty1.fs" id="Snippet1":::

You can use the <xref:System.String.IsNullOrWhiteSpace%2A> method to test whether a string is `null`, its value is <xref:System.String.Empty?displayProperty=nameWithType>,  or it consists only of white-space characters.

## What is a null string?

A string is `null` if it has not been assigned a value (in C++ and Visual Basic) or if it has explicitly been assigned a value of `null`. Although the [composite formatting](../../standard/base-types/composite-formatting.md) feature can gracefully handle a null string, as the following example shows, attempting to call one if its members throws a <xref:System.NullReferenceException>.

:::code language="csharp" source="./snippets/System/String/IsNullOrEmpty/csharp/NullString1.cs" interactive="try-dotnet-method" id="Snippet2":::
:::code language="vb" source="./snippets/System/String/IsNullOrEmpty/vb/NullString1.vb" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/String/IsNullOrEmpty/fsharp/NullString1.fs" id="Snippet2":::

## What is an empty string?

A string is empty if it  is explicitly assigned an empty string ("") or <xref:System.String.Empty?displayProperty=nameWithType>. An empty string has a <xref:System.String.Length%2A> of 0. The following example creates an empty string and displays its value and its length.

:::code language="csharp" source="./snippets/System/String/IsNullOrEmpty/csharp/NullString1.cs" interactive="try-dotnet-method" id="Snippet3":::
:::code language="vb" source="./snippets/System/String/IsNullOrEmpty/vb/NullString1.vb" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/String/IsNullOrEmpty/fsharp/NullString2.fs" id="Snippet3":::

---
title: How to handle termination in System.CommandLine
description: "Learn how to handle termination in apps that are built with the System.Commandline library."
ms.date: 01/25/2022
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
ms.topic: how-to
---
# How to handle termination in System.CommandLine

[!INCLUDE [scl-preview](../../../includes/scl-preview.md)]

To handle termination, inject a [CancellationToken](xref:System.Threading.CancellationToken) instance into your handler code. This token can then be passed along to async APIs that you call from within your handler, as shown in the following example:

:::code language="csharp" source="snippets/handle-termination/csharp/Program.cs" id="mainandhandler" :::

Cancellation actions can also be added directly using the <xref:System.Threading.CancellationToken.Register%2A?displayProperty=nameWithType> method.

## See also

[System.CommandLine overview](index.md)

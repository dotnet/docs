---
title: Basic String Manipulations in .NET
description: See an example that calls many string methods.
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "strings [.NET], examples"
ms.assetid: 121d1eae-251b-44c0-8818-57da04b8215e
---
# How to: Perform Basic String Manipulations in .NET

The following example uses some of the methods discussed in the [Basic String Operations](basic-string-operations.md) topics to construct a class that performs string manipulations in a manner that might be found in a real-world application. The `MailToData` class stores the name and address of an individual in separate properties and provides a way to combine the `City`, `State`, and `Zip` fields into a single string for display to the user. Furthermore, the class allows the user to enter the city, state, and zip code information as a single string. The application automatically parses the single string and enters the proper information into the corresponding property.

For simplicity, this example uses a console application with a command-line interface.

## Example

[!code-csharp[Conceptual.String.BasicOps#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.string.basicops/cs/basicops.cs#1)]
[!code-vb[Conceptual.String.BasicOps#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.string.basicops/vb/basicops.vb#1)]

When the preceding code is executed, the user is asked to enter their name and address. The application places the information in the appropriate properties and displays the information back to the user, creating a single string that displays the city, state, and zip code information.

## See also

- [Basic String Operations](basic-string-operations.md)

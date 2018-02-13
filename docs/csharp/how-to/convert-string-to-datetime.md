---
title: "How to: Convert a String to a DateTime: C# Guide"
ms.date: 02/14/2018
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "strings [C#], converting to DateTIme"
author: "BillWagner"
ms.author: "wiwagn"
---

# How to: Convert a String to a DateTime

It is common for programs to enable users to enter dates as string values. To convert a string-based date to a <xref:System.DateTime?displayProperty=nameWithType> object, you can use the <xref:System.Convert.ToDateTime%28System.String%29?displayProperty=nameWithType> method or the <xref:System.DateTime.Parse%28System.String%29?displayProperty=nameWithType> static method, as shown in the following example.

**Culture**.  Different cultures in the world write date strings in different ways.  For example, in the US 01/20/2008 is January 20th, 2008.  In France this will throw an InvalidFormatException. This is because France reads date-times as Day/Month/Year, and in the US it is Month/Day/Year.

Consequently, a string like 20/01/2008 will parse to January 20th, 2008 in France, and then throw an InvalidFormatException in the US.

To determine your current culture settings, you can use System.Globalization.CultureInfo.CurrentCulture.

See the example below for a simple example of converting a string to dateTime.

For more examples of date strings, see <xref:System.Convert.ToDateTime%28System.String%29?displayProperty=nameWithType>.

[!code-csharp-interactive[First Example](../../../samples/snippets/csharp/how-to-conversions/StringToDateTime.cs#1)]

This is a second sample:

[!code-csharp-interactive[First Example](../../../samples/snippets/csharp/how-to-conversions/StringToDateTime.cs#2)]

## See Also
 [Strings](../programming-guide/strings/index.md)

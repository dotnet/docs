---
title: Parsing other strings in .NET
description: Parsing other strings in .NET
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/29/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 67670b10-3df4-45ea-8908-5ba3f056887c
---

# Parsing other strings in .NET

In addition to numeric and [DateTime](xref:System.DateTime) strings, you can also parse strings that represent the types [Char](xref:System.Char), [Boolean](xref:System.Boolean), and [Enum](xref:System.Enum) into data types.

## Char

The static parse method associated with the [Char](xref:System.Char) data type is useful for converting a string that contains a single character into its Unicode value. The following code example parses a string into a Unicode character.

```csharp
string MyString1 = "A";
char MyChar = Char.Parse(MyString1);
// MyChar now contains a Unicode "A" character.
```

```vb
Dim MyString1 As String = "A"
Dim MyChar As Char = Char.Parse(MyString1)
' MyChar now contains a Unicode "A" character.
```

## Boolean

The [Boolean](xref:System.Boolean) data type contains a [Parse](xref:System.Boolean.Parse(System.String)) method that you can use to convert a string that represents a `Boolean` value into an actual `Boolean` type. This method is not case-sensitive and can successfully parse a string containing "True" or "False." The `Parse` method associated with the `Boolean` type can also parse strings that are surrounded by white spaces. If any other string is passed, a [FormatException](xref:System.FormatException) is thrown.

The following code example uses the `Parse` method to convert a string into a `Boolean` value.

```csharp
string MyString2 = "True";
bool MyBool = bool.Parse(MyString2);
// MyBool now contains a True Boolean value.
```

```vb
Dim MyString1 As String = "A"
Dim MyChar As Char = Char.Parse(MyString1)
' MyChar now contains a Unicode "A" character.
```

## Enumeration

You can use the static [Parse](xref:System.Enum.Parse(System.Type,System.String)) method to initialize an enumeration type to the value of a string. This method accepts the enumeration type you are parsing, the string to parse, and an optional `Boolean` flag indicating whether or not the parse is case-sensitive. The string you are parsing can contain several values separated by commas, which can be preceded or followed by one or more empty spaces (also called white spaces). When the string contains multiple values, the value of the returned object is the value of all specified values combined with a bitwise OR operation.

The following example uses the `Parse` method to convert a string representation into an enumeration value. The [DayOfWeek](xref:System.DayOfWeek) enumeration is initialized to Thursday from a string.

```csharp
string MyString3 = "Thursday";
DayOfWeek MyDays = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), MyString3);
Console.WriteLine(MyDays);
// The result is Thursday.
```

```vb
Dim MyString3 As String = "Thursday"
Dim MyDays As DayOfWeek = CType([Enum].Parse(GetType(DayOfWeek), MyString3), DayOfWeek)
Console.WriteLine("{0:G}", MyDays)
' The result is Thursday.
```

## See Also

[Parsing strings in .NET](parsing-strings.md)

[Formatting types in .NET](formatting-types.md)

[Type conversion in .NET](type-conversion.md)


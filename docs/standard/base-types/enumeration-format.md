---
title: Enumeration format strings
description: Enumeration format strings
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/25/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 4d581898-99bc-42c3-816c-d8238f45096f
---

# Enumeration format strings

You can use the [Enum.ToString](xref:System.Enum.ToString) method to create a new string object that represents the numeric, hexadecimal, or string value of an enumeration member. This method takes one of the enumeration formatting strings to specify the value that you want returned.

The following sections list the enumeration formatting strings and the values they return. These format specifiers are not case-sensitive.

## The G or g Format Strings

The G or g format strings display the enumeration entry as a string value, if possible, and otherwise displays the integer value of the current instance. If the enumeration is defined with the `Flags` attribute set, the string values of each valid entry are concatenated together, separated by commas. If the `Flags` attribute is not set, an invalid value is displayed as a numeric entry. The following example illustrates the G format specifier.

```csharp
Console.WriteLine(ConsoleColor.Red.ToString("G"));         // Displays Red
FileAttributes attributes = FileAttributes.Hidden |
                            FileAttributes.Archive;
Console.WriteLine(attributes.ToString("G"));   // Displays Hidden, Archive
```

```vb
Console.WriteLine(ConsoleColor.Red.ToString("G"))           ' Displays Red
Dim attributes As FileAttributes = FileAttributes.Hidden Or _
                                   FileAttributes.Archive
Console.WriteLine(attributes.ToString("G"))     ' Displays Hidden, Archive
```

## The F or f Format Strings

The F or f format strings display the enumeration entry as a string value, if possible. If the value can be completely displayed as a summation of the entries in the enumeration (even if the `Flags` attribute is not present), the string values of each valid entry are concatenated together, separated by commas. If the value cannot be completely determined by the enumeration entries, then the value is formatted as the integer value. The following example illustrates the F format specifier.

```csharp
Console.WriteLine(ConsoleColor.Blue.ToString("F"));       // Displays Blue
FileAttributes attributes = FileAttributes.Hidden | 
                            FileAttributes.Archive;
Console.WriteLine(attributes.ToString("F"));   // Displays Hidden, Archive
```

```vb
Console.WriteLine(ConsoleColor.Blue.ToString("F"))         ' Displays Blue
Dim attributes As FileAttributes = FileAttributes.Hidden Or _
                                   FileAttributes.Archive
Console.WriteLine(attributes.ToString("F"))     ' Displays Hidden, Archive
```

## The D or d Format Strings

The D or d format strings display the enumeration entry as an integer value in the shortest representation possible. The following example illustrates the D format specifier.

```csharp
Console.WriteLine(ConsoleColor.Cyan.ToString("D"));         // Displays 11
FileAttributes attributes = FileAttributes.Hidden |
                            FileAttributes.Archive;
Console.WriteLine(attributes.ToString("D"));                // Displays 34
````

```vb
Console.WriteLine(ConsoleColor.Cyan.ToString("D"))           ' Displays 11
Dim attributes As FileAttributes = FileAttributes.Hidden Or _
                                   FileAttributes.Archive
Console.WriteLine(attributes.ToString("D"))                  ' Displays 34 
```

## The X or x Format Strings

The X or x format strings display the enumeration entry as a hexadecimal value. The value is represented with leading zeros as necessary, to ensure that the value is a minimum eight digits in length. The following example illustrates the X format specifier.

```csharp
Console.WriteLine(ConsoleColor.Cyan.ToString("X"));   // Displays 0000000B
FileAttributes attributes = FileAttributes.Hidden |
                            FileAttributes.Archive;
Console.WriteLine(attributes.ToString("X"));          // Displays 00000022
```

```vb
Console.WriteLine(ConsoleColor.Cyan.ToString("X"))     ' Displays 0000000B
Dim attributes As FileAttributes = FileAttributes.Hidden Or _
                                   FileAttributes.Archive
Console.WriteLine(attributes.ToString("X"))            ' Displays 00000022 
```

## Example

The following example defines an enumeration called `Colors` that consists of three entries: `Red`, `Blue`, and `Green`.

 ```csharp
 public enum Color {Red = 1, Blue = 2, Green = 3}
```

```vb
Public Enum Color
   Red = 1
   Blue = 2
   Green = 3
End Enum
```

After the enumeration is defined, an instance can be declared in the following manner.

```csharp
Color myColor = Color.Green;
```

```vb
Dim myColor As Color = Color.Green
```

The `Color.ToString(System.String)` method can then be used to display the enumeration value in different ways, depending on the format specifier passed to it.

```csharp
Console.WriteLine("The value of myColor is {0}.", 
                  myColor.ToString("G"));
Console.WriteLine("The value of myColor is {0}.", 
                  myColor.ToString("F"));
Console.WriteLine("The value of myColor is {0}.", 
                  myColor.ToString("D"));
Console.WriteLine("The value of myColor is 0x{0}.", 
                  myColor.ToString("X"));
// The example displays the following output to the console:
//       The value of myColor is Green.
//       The value of myColor is Green.
//       The value of myColor is 3.
//       The value of myColor is 0x00000003.
```

```vb
Console.WriteLine("The value of myColor is {0}.", _
                  myColor.ToString("G"))
Console.WriteLine("The value of myColor is {0}.", _
                  myColor.ToString("F"))
Console.WriteLine("The value of myColor is {0}.", _
                  myColor.ToString("D"))
Console.WriteLine("The value of myColor is 0x{0}.", _
                  myColor.ToString("X"))
' The example displays the following output to the console:
'       The value of myColor is Green.
'       The value of myColor is Green.
'       The value of myColor is 3.
'       The value of myColor is 0x00000003. 
```

## See Also

[Formatting types](formatting-types.md)


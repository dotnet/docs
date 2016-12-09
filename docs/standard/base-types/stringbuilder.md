---
title: Using the StringBuilder class
description: Using the StringBuilder class
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/26/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: f4f5d1c7-d84d-4867-810f-2708cd6de0da
---

# Using the StringBuilder class

The [String](xref:System.String) object is immutable. Every time you use one of the methods in the [System.String](xref:System.String) class, you create a new string object in memory, which requires a new allocation of space for that new object. In situations where you need to perform repeated modifications to a string, the overhead associated with creating a new [String](xref:System.String) object can be costly. The [System.Text.StringBuilder](xref:System.Text.StringBuilder) class can be used when you want to modify a string without creating a new object. For example, using the [StringBuilder](xref:System.Text.StringBuilder) class can boost performance when concatenating many strings together in a loop.

## Importing the System.Text Namespace

The [StringBuilder](xref:System.Text.StringBuilder) class is found in the [System.Text](xref:System.Text) namespace. To avoid having to provide a fully qualified type name in your code, you can import the [System.Text](xref:System.Text) namespace: 

```csharp
using System;
using System.Text;
```

```vb
Imports System.Text
```

## Instantiating a StringBuilder Object

You can create a new instance of the [StringBuilder](xref:System.Text.StringBuilder) class by initializing your variable with one of the overloaded constructor methods, as illustrated in the following example.

```csharp
StringBuilder MyStringBuilder = new StringBuilder("Hello World!");
```

```vb
Dim MyStringBuilder As New StringBuilder("Hello World!")
```

## Setting the Capacity and Length

Although the [StringBuilder](xref:System.Text.StringBuilder) is a dynamic object that allows you to expand the number of characters in the string that it encapsulates, you can specify a value for the maximum number of characters that it can hold. This value is called the capacity of the object and should not be confused with the length of the string that the current [StringBuilder](xref:System.Text.StringBuilder) holds. For example, you might create a new instance of the [StringBuilder](xref:System.Text.StringBuilder) class with the string "Hello", which has a length of 5, and you might specify that the object has a maximum capacity of 25. When you modify the [StringBuilder](xref:System.Text.StringBuilder), it does not reallocate size for itself until the capacity is reached. When this occurs, the new space is allocated automatically and the capacity is doubled. You can specify the capacity of the [StringBuilder](xref:System.Text.StringBuilder) class using one of the overloaded constructors. The following example specifies that the `MyStringBuilder` object can be expanded to a maximum of 25 spaces.

```csharp
StringBuilder MyStringBuilder = new StringBuilder("Hello World!", 25);
```

```vb
Dim MyStringBuilder As New StringBuilder("Hello World!", 25) 
```

Additionally, you can use the read/write [Capacity](xref:System.Text.StringBuilder.Capacity) property to set the maximum length of your object. The following example uses the [Capacity](xref:System.Text.StringBuilder.Capacity) property to define the maximum object length.

```csharp
MyStringBuilder.Capacity = 25;
```

```vb
MyStringBuilder.Capacity = 25
```

The [EnsureCapacity](xref:System.Text.StringBuilder.EnsureCapacity(System.Int32)) method can be used to check the capacity of the current [StringBuilder](xref:System.Text.StringBuilder). If the capacity is greater than the passed value, no change is made; however, if the capacity is smaller than the passed value, the current capacity is changed to match the passed value.

The [Length](xref:System.Text.StringBuilder.Length) property can also be viewed or set. If you set the [Length](xref:System.Text.StringBuilder.Length) property to a value that is greater than the [Capacity](xref:System.Text.StringBuilder.Capacity) property, the [Capacity](xref:System.Text.StringBuilder.Capacity) property is automatically changed to the same value as the [Length](xref:System.Text.StringBuilder.Length) property. Setting the [Length](xref:System.Text.StringBuilder.Length) property to a value that is less than the length of the string within the current [StringBuilder](xref:System.Text.StringBuilder) shortens the string.

## Modifying the StringBuilder String

The following table lists the methods you can use to modify the contents of a [StringBuilder](xref:System.Text.StringBuilder).

Method name | Use
----------- | ---
[StringBuilder.Append](xref:System.Text.StringBuilder.Append(System.Char)) | Appends information to the end of the current [StringBuilder](xref:System.Text.StringBuilder).
[StringBuilder.AppendFormat](xref:System.Text.StringBuilder.AppendFormat(System.IFormatProvider,System.String,System.Object)) | Replaces a format specifier passed in a string with formatted text.
[StringBuilder.Insert](xref:System.Text.StringBuilder.Insert(System.Int32,System.Char)) | Inserts a string or object into the specified index of the current [StringBuilder](xref:System.Text.StringBuilder).
[StringBuilder.Remove](xref:System.Text.StringBuilder.Remove(System.Int32,System.Int32)) | Removes a specified number of characters from the current [StringBuilder](xref:System.Text.StringBuilder).
[StringBuilder.Replace](xref:System.Text.StringBuilder.Replace(System.Char,System.Char)) | Replaces a specified character at a specified index.

### Append

The [StringBuilder.Append](xref:System.Text.StringBuilder.Append(System.Char)) method can be used to add text or a string representation of an object to the end of a string represented by the current [StringBuilder](xref:System.Text.StringBuilder). The following example initializes a [StringBuilder](xref:System.Text.StringBuilder) to "Hello World" and then appends some text to the end of the object. Space is allocated automatically as needed.

```csharp
StringBuilder MyStringBuilder = new StringBuilder("Hello World!");
MyStringBuilder.Append(" What a beautiful day.");
Console.WriteLine(MyStringBuilder);
// The example displays the following output:
//       Hello World! What a beautiful day.
```

```vb
Dim MyStringBuilder As New StringBuilder("Hello World!")
MyStringBuilder.Append(" What a beautiful day.")
Console.WriteLine(MyStringBuilder)
' The example displays the following output:
'       Hello World! What a beautiful day.
```

### AppendFormat

The [StringBuilder.AppendFormat](xref:System.Text.StringBuilder.AppendFormat(System.IFormatProvider,System.String,System.Object)) method adds text to the end of the [StringBuilder](xref:System.Text.StringBuilder) object. It supports the composite formatting feature (for more information, see [Composite Formatting](composite-format.md)) by calling the [IFormattable](xref:System.IFormattable) implementation of the object or objects to be formatted. Therefore, it accepts the standard format strings for numeric, date and time, and enumeration values, the custom format strings for numeric and date and time values, and the format strings defined for custom types. (For information about formatting, see [Formatting Types](formatting-types.md).) You can use this method to customize the format of variables and append those values to a [StringBuilder](xref:System.Text.StringBuilder). The following example uses the AppendFormat method to place an integer value formatted as a currency value at the end of a [StringBuilder](xref:System.Text.StringBuilder) object.

```csharp
int MyInt = 25; 
StringBuilder MyStringBuilder = new StringBuilder("Your total is ");
MyStringBuilder.AppendFormat("{0:C} ", MyInt);
Console.WriteLine(MyStringBuilder);
// The example displays the following output:
//       Your total is $25.00
```

```vb
Dim MyInt As Integer = 25
Dim MyStringBuilder As New StringBuilder("Your total is ")
MyStringBuilder.AppendFormat("{0:C} ", MyInt)
Console.WriteLine(MyStringBuilder)
' The example displays the following output:
'     Your total is $25.00 
```

### Insert

The [StringBuilder.Insert](xref:System.Text.StringBuilder.Insert(System.Int32,System.Char)) method adds a string or object to a specified position in the current [StringBuilder](xref:System.Text.StringBuilder) object. The following example uses this method to insert a word into the sixth position of a [StringBuilder](xref:System.Text.StringBuilder) object.

```csharp
StringBuilder MyStringBuilder = new StringBuilder("Hello World!");
MyStringBuilder.Insert(6,"Beautiful ");
Console.WriteLine(MyStringBuilder);
// The example displays the following output:
//       Hello Beautiful World!
```

```vb
Dim MyStringBuilder As New StringBuilder("Hello World!")
MyStringBuilder.Insert(6, "Beautiful ")
Console.WriteLine(MyStringBuilder)
' The example displays the following output:
'      Hello Beautiful World!
```

### Remove

You can use the [StringBuilder.Remove](xref:System.Text.StringBuilder.Remove(System.Int32,System.Int32)) method to remove a specified number of characters from the current [StringBuilder](xref:System.Text.StringBuilder) object, beginning at a specified zero-based index. The following example uses the [Remove](xref:System.Text.StringBuilder.Remove(System.Int32,System.Int32)) method to shorten a [StringBuilder](xref:System.Text.StringBuilder) object.

```csharp
StringBuilder MyStringBuilder = new StringBuilder("Hello World!");
MyStringBuilder.Remove(5,7);
Console.WriteLine(MyStringBuilder);
// The example displays the following output:
//       Hello
```

```vb
Dim MyStringBuilder As New StringBuilder("Hello World!")
MyStringBuilder.Remove(5, 7)
Console.WriteLine(MyStringBuilder)
' The example displays the following output:
'       Hello
```

### Replace

The [StringBuilder.Replace](xref:System.Text.StringBuilder.Replace(System.Char,System.Char)) | Replaces a specified character at a specified index.
 method can be used to replace characters within the [StringBuilder](xref:System.Text.StringBuilder) object with another specified character. The following example uses the [Replace](xref:System.Text.StringBuilder.Replace(System.Char,System.Char)) | Replaces a specified character at a specified index.
 method to search a [StringBuilder](xref:System.Text.StringBuilder) object for all instances of the exclamation point character (!) and replace them with the question mark character (?).
 
 ```csharp
 StringBuilder MyStringBuilder = new StringBuilder("Hello World!");
MyStringBuilder.Replace('!', '?');
Console.WriteLine(MyStringBuilder);
// The example displays the following output:
//       Hello World?
```

```vb
Dim MyStringBuilder As New StringBuilder("Hello World!")
MyStringBuilder.Replace("!"c, "?"c)
Console.WriteLine(MyStringBuilder)
' The example displays the following output:
'       Hello World?
```

## Converting a StringBuilder Object to a String

You must convert the [StringBuilder](xref:System.Text.StringBuilder) object to a [String](xref:System.String) object before you can pass the string represented by the [StringBuilder](xref:System.Text.StringBuilder) object to a method that has a [String](xref:System.String) parameter or display it in the user interface. You do this conversion by calling the [StringBuilder.ToString](xref:System.Text.StringBuilder.ToString) method. The following example calls a number of [StringBuilder](xref:System.Text.StringBuilder) methods and then calls the [StringBuilder.ToString](xref:System.Text.StringBuilder.ToString) method to display the string.

```csharp
using System;
using System.Text;

public class Example
{
   public static void Main()
   {
      StringBuilder sb = new StringBuilder();
      bool flag = true;
      string[] spellings = { "recieve", "receeve", "receive" };
      sb.AppendFormat("Which of the following spellings is {0}:", flag);
      sb.AppendLine();
      for (int ctr = 0; ctr <= spellings.GetUpperBound(0); ctr++) {
         sb.AppendFormat("   {0}. {1}", ctr, spellings[ctr]);
         sb.AppendLine();
      }
      sb.AppendLine();
      Console.WriteLine(sb.ToString());
   }
}
// The example displays the following output:
//       Which of the following spellings is True:
//          0. recieve
//          1. receeve
//          2. receive
```

```vb
Imports System.Text

Module Example
   Public Sub Main()
      Dim sb As New StringBuilder()
      Dim flag As Boolean = True
      Dim spellings() As String = { "recieve", "receeve", "receive" }
      sb.AppendFormat("Which of the following spellings is {0}:", flag)
      sb.AppendLine()
      For ctr As Integer = 0 To spellings.GetUpperBound(0)
         sb.AppendFormat("   {0}. {1}", ctr, spellings(ctr))
         sb.AppendLine()
      Next
      sb.AppendLine()
      Console.WriteLine(sb.ToString())
   End Sub
End Module
' The example displays the following output:
'       Which of the following spellings is True:
'          0. recieve
'          1. receeve
'          2. receive
```

## See Also

[System.Text.StringBuilder](xref:System.Text.StringBuilder)

[Basic string operations](basic-string-operations.md)

[Formatting types](formatting-types.md)

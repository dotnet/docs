---
title: C# Enums | A tour of the C# language
description: Learn about enums, discrete named constants in C#
keywords: .NET, csharp 
author: BillWagner
manager: wpickett
ms.date: 08/10/2016
ms.topic: article
ms.prod: visual-studio-dev-14
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 7faba1cc-6ea9-4a19-adb9-0335e4b132e5
---
	
# Enums

An ***enum type*** is a distinct value type with a set of named constants. The following example declares and uses an enum type named `Color` with three constant values, `Red`, `Green`, and `Blue`.

```csharp
using System;
enum Color
{
	Red,
	Green,
	Blue
}
class EnumExample
{
	static void PrintColor(Color color) 
	{
		switch (color) 
		{
			case Color.Red:
				Console.WriteLine("Red");
				break;
			case Color.Green:
				Console.WriteLine("Green");
				break;
			case Color.Blue:
				Console.WriteLine("Blue");
				break;
			default:
				Console.WriteLine("Unknown color");
				break;
		}
	}
	static void Main() 
	{
		Color c = Color.Red;
		PrintColor(c);
		PrintColor(Color.Blue);
	}
}
```

Each enum type has a corresponding integral type called the ***underlying type*** of the enum type. An enum type that does not explicitly declare an underlying type has an underlying type of int. An enum type’s storage format and range of possible values are determined by its underlying type. The set of values that an enum type can take on is not limited by its enum members. In particular, any value of the underlying type of an enum can be cast to the enum type and is a distinct valid value of that enum type.

The following example declares an enum type named `Alignment` with an underlying type of `sbyte`.

```csharp
enum Alignment: sbyte
{
	Left = -1,
	Center = 0,
	Right = 1
}
```

As shown by the previous example, an enum member declaration can include a constant expression that specifies the value of the member. The constant value for each enum member must be in the range of the underlying type of the enum. When an enum member declaration does not explicitly specify a value, the member is given the value zero (if it is the first member in the enum type) or the value of the textually preceding enum member plus one.

`Enum` values can be converted to integral values and vice versa using type casts. For example

```csharp
int i = (int)Color.Blue;		// int i = 2;
Color c = (Color)2;				// Color c = Color.Blue;
```

The default value of any enum type is the integral value zero converted to the enum type. In cases where variables are automatically initialized to a default value, this is the value given to variables of enum types. In order for the default value of an enum type to be easily available, the literal `0` implicitly converts to any enum type. Thus, the following is permitted.

```csharp
Color c = 0;
```

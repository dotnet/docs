---
title: "Enumeration types (C# Programming Guide)"
ms.date: "09/10/2017"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "enumerations [C#]"
  - "enums [C#]"
  - "C# Language, enums"
  - "bit flags [C#]"
ms.assetid: 64a9b731-9e3c-4336-8a09-018db2aa10b7
caps.latest.revision: 17
author: "BillWagner"
ms.author: "wiwagn"
---
# Enumeration types (C# Programming Guide)

An enumeration type (also named an enumeration or an enum) provides an efficient way to define a set of named integral constants that may be assigned to a variable. For example, assume that you have to define a variable whose value will represent a day of the week. There are only seven meaningful values which that variable will ever store. To define those values, you can use an enumeration type, which is declared by using the [enum](../../csharp/language-reference/keywords/enum.md) keyword.

[!code-csharp[csProgGuideEnums#1](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideEnums/CS/Enums.cs#1)]

By default the underlying type of each element in the enum is [int](../../csharp/language-reference/keywords/int.md). You can specify another integral numeric type by using a colon, as shown in the previous example. For a full list of possible types, see [enum (C# Reference)](../../csharp/language-reference/keywords/enum.md).

You can verify the underlying numeric values by casting  to the underlying type, as the following example shows.

```csharp
Day today = Day.Monday;
int dayNumber =(int)today;
Console.WriteLine("{0} is day number #{1}.", today, dayNumber);

Month thisMonth = Month.Dec;
byte monthNumber = (byte)thisMonth;
Console.WriteLine("{0} is month number #{1}.", thisMonth, monthNumber);

// Output:
// Monday is day number #1.
// Dec is month number #11.
```

The following are advantages of using an enum instead of a numeric type:

- You clearly specify for client code which values are valid for the variable.

- In [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)], IntelliSense lists the defined values.

When you do not specify values for the elements in the enumerator list, the values are automatically incremented by 1. In the previous example, `Day.Sunday` has a value of 0, `Day.Monday` has a value of 1, and so on. When you create a new `Day` object, it will have a default value of `Day.Sunday` (0) if you do not explicitly assign it a value. When you create an enum, select the most logical default value and give it a value of zero. That will cause all enums to have that default value if they are not explicitly assigned a value when they are created.

If the variable `meetingDay` is of type `Day`, then (without an explicit cast) you can only assign it one of the values defined by `Day`. And if the meeting day changes, you can assign a new value from `Day` to `meetingDay`:

[!code-csharp[csProgGuideEnums#4](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideEnums/CS/Enums.cs#4)]

> [!NOTE]
> It's possible to assign any arbitrary integer value to `meetingDay`. For example, this line of code does not produce an error: `meetingDay = (Day) 42`. However, you should not do this because the implicit expectation is that an enum variable will only hold one of the values defined by the enum. To assign an arbitrary value to a variable of an enumeration type is to introduce a high risk for errors.

You can assign any values to the elements in the enumerator list of an enumeration type, and you can also use computed values:

[!code-csharp[csProgGuideEnums#3](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideEnums/CS/Enums.cs#3)]

## Enumeration types as bit flags

You can use an enumeration type to define bit flags, which enables an instance of the enumeration type to store any combination of the values that are defined in the enumerator list. (Of course, some combinations may not be meaningful or allowed in your program code.)

You create a bit flags enum by applying the <xref:System.FlagsAttribute?displayProperty=nameWithType> attribute and defining the values appropriately so that `AND`, `OR`, `NOT` and `XOR` bitwise operations can be performed on them. In a bit flags enum, include a named constant with a value of zero that means "no flags are set." Do not give a flag a value of zero if it does not mean "no flags are set".

In the following example, another version of the `Day` enum, which is named `Days`, is defined. `Days` has the `Flags` attribute, and each value is assigned the next greater power of 2. This enables you to create a `Days` variable whose value is `Days.Tuesday | Days.Thursday`.

[!code-csharp[csProgGuideEnums#2](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideEnums/CS/Enums.cs#2)]

To set a flag on an enum, use the bitwise `OR` operator as shown in the following example:

[!code-csharp[csProgGuideEnums#6](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideEnums/CS/Enums.cs#6)]

To determine whether a specific flag is set, use a bitwise `AND` operation, as shown in the following example:

[!code-csharp[csProgGuideEnums#7](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideEnums/CS/Enums.cs#7)]

For more information about what to consider when you define enumeration types with the <xref:System.FlagsAttribute?displayProperty=nameWithType> attribute, see <xref:System.Enum?displayProperty=nameWithType>.

## Using the System.Enum methods to discover and manipulate enum values

All enums are instances of the <xref:System.Enum?displayProperty=nameWithType> type. You cannot derive new classes from <xref:System.Enum?displayProperty=nameWithType>, but you can use its methods to discover information about and manipulate values in an enum instance.

[!code-csharp[csProgGuideEnums#5](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideEnums/CS/Enums.cs#5)]

For more information, see <xref:System.Enum?displayProperty=nameWithType>.

You can also create a new method for an enum by using an extension method. For more information, see [How to: Create a New Method for an Enumeration](../../csharp/programming-guide/classes-and-structs/how-to-create-a-new-method-for-an-enumeration.md).

## See also
 <xref:System.Enum?displayProperty=nameWithType>  
 [C# Programming Guide](../../csharp/programming-guide/index.md)  
 [enum](../../csharp/language-reference/keywords/enum.md)

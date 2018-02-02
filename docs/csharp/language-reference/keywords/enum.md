---
title: "enum (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "enum"
  - "enum_CSharpKeyword"
helpviewer_keywords: 
  - "enum keyword [C#]"
ms.assetid: bbeb9a0f-e9b3-41ab-b0a6-c41b1a08974c
caps.latest.revision: 36
author: "BillWagner"
ms.author: "wiwagn"
---
# enum (C# Reference)
The `enum` keyword is used to declare an enumeration, a distinct type that consists of a set of named constants called the enumerator list.  
  
 Usually it is best to define an enum directly within a namespace so that all classes in the namespace can access it with equal convenience. However, an enum can also be nested within a class or struct.  
  
 By default, the first enumerator has the value 0, and the value of each successive enumerator is increased by 1. For example, in the following enumeration, `Sat` is `0`, `Sun` is `1`, `Mon` is `2`, and so forth.  
  
```  
enum Day {Sat, Sun, Mon, Tue, Wed, Thu, Fri};  
```  
  
 Enumerators can use initializers to override the default values, as shown in the following example.  
  
```  
enum Day {Sat=1, Sun, Mon, Tue, Wed, Thu, Fri};  
```  
  
 In this enumeration, the sequence of elements is forced to start from `1` instead of `0`. However, including a constant that has the value of 0 is recommended. For more information, see [Enumeration Types](../../../csharp/programming-guide/enumeration-types.md).  
  
 Every enumeration type has an underlying type, which can be any integral type except [char](../../../csharp/language-reference/keywords/char.md). The default underlying type of enumeration elements is [int](../../../csharp/language-reference/keywords/int.md). To declare an enum of another integral type, such as [byte](../../../csharp/language-reference/keywords/byte.md), use a colon after the identifier followed by the type, as shown in the following example.  
  
```  
enum Day : byte {Sat=1, Sun, Mon, Tue, Wed, Thu, Fri};  
```  
  
 The approved types for an enum are [byte](../../../csharp/language-reference/keywords/byte.md), [sbyte](../../../csharp/language-reference/keywords/sbyte.md), [short](../../../csharp/language-reference/keywords/short.md), [ushort](../../../csharp/language-reference/keywords/ushort.md), [int](../../../csharp/language-reference/keywords/int.md), [uint](../../../csharp/language-reference/keywords/uint.md), [long](../../../csharp/language-reference/keywords/long.md), or [ulong](../../../csharp/language-reference/keywords/ulong.md).  
  
 A variable of type `Day` can be assigned any value in the range of the underlying type; the values are not limited to the named constants.  
  
 The default value of an `enum E` is the value produced by the expression `(E)0`.  
  
> [!NOTE]
>  An enumerator cannot contain white space in its name.  
  
 The underlying type specifies how much storage is allocated for each enumerator. However, an explicit cast is necessary to convert from `enum` type to an integral type. For example, the following statement assigns the enumerator `Sun` to a variable of the type [int](../../../csharp/language-reference/keywords/int.md) by using a cast to convert from `enum` to `int`.  
  
```  
int x = (int)Day.Sun;  
```  
  
 When you apply <xref:System.FlagsAttribute?displayProperty=nameWithType> to an enumeration that contains elements that can be combined with a bitwise `OR` operation, the attribute affects the behavior of the `enum` when it is used with some tools. You can notice these changes when you use tools such as the <xref:System.Console> class methods and the Expression Evaluator. (See the third example.)  
  
## Robust Programming  
 Just as with any constant, all references to the individual values of an enum are converted to numeric literals at compile time. This can create potential versioning issues as described in [Constants](../../../csharp/programming-guide/classes-and-structs/constants.md).  
  
 Assigning additional values to new versions of enums, or changing the values of the enum members in a new version, can cause problems for dependent source code. Enum values often are used in [switch](../../../csharp/language-reference/keywords/switch.md) statements. If additional elements have been added to the `enum` type, the default section of the switch statement can be selected unexpectedly.  
  
 If other developers use your code, you should provide guidelines about how their code should react if new elements are added to any `enum` types.  
  
## Example  
 In the following example, an enumeration, `Day`, is declared. Two enumerators are explicitly converted to integer and assigned to integer variables.  
  
 [!code-csharp[csrefKeywordsTypes#10](../../../csharp/language-reference/keywords/codesnippet/CSharp/enum_1.cs)]  
  
## Example  
 In the following example, the base-type option is used to declare an `enum` whose members are of type `long`. Notice that even though the underlying type of the enumeration is `long`, the enumeration members still must be explicitly converted to type `long` by using a cast.  
  
 [!code-csharp[csrefKeywordsTypes#11](../../../csharp/language-reference/keywords/codesnippet/CSharp/enum_2.cs)]  
  
## Example  
 The following code example illustrates the use and effect of the <xref:System.FlagsAttribute?displayProperty=nameWithType> attribute on an `enum` declaration.  
  
 [!code-csharp[csrefKeywordsTypes#12](../../../csharp/language-reference/keywords/codesnippet/CSharp/enum_3.cs)]  
  
## Comments  
 If you remove `Flags`, the example displays the following values:  
  
 `5`  
  
 `5`  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [Enumeration Types](../../../csharp/programming-guide/enumeration-types.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Integral Types Table](../../../csharp/language-reference/keywords/integral-types-table.md)  
 [Built-In Types Table](../../../csharp/language-reference/keywords/built-in-types-table.md)  
 [Implicit Numeric Conversions Table](../../../csharp/language-reference/keywords/implicit-numeric-conversions-table.md)  
 [Explicit Numeric Conversions Table](../../../csharp/language-reference/keywords/explicit-numeric-conversions-table.md)  
 [Enum Naming Conventions](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-classes-structs-and-interfaces#naming-enumerations)

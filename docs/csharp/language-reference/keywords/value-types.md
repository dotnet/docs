---
title: "Value Types (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "cs.valuetypes"
helpviewer_keywords: 
  - "value types [C#]"
  - "types [C#], value types"
  - "C# language, value types"
ms.assetid: 471eb994-2958-49d5-a6be-19b4313f80a3
caps.latest.revision: 18
author: "BillWagner"
ms.author: "wiwagn"
---
# Value Types (C# Reference)
The value types consist of two main categories:  
  
-   [Structs](../../../csharp/language-reference/keywords/struct.md)  
  
-   [Enumerations](../../../csharp/language-reference/keywords/enum.md)  
  
 Structs fall into these categories:  
  
-   Numeric types  
  
    -   [Integral types](../../../csharp/language-reference/keywords/integral-types-table.md)  
  
    -   [Floating-point types](../../../csharp/language-reference/keywords/floating-point-types-table.md)  
  
    -   [decimal](../../../csharp/language-reference/keywords/decimal.md)  
  
-   [bool](../../../csharp/language-reference/keywords/bool.md)  
  
-   User defined structs.  
  
## Main Features of Value Types  
 Variables that are based on value types directly contain values. Assigning one value type variable to another copies the contained value. This differs from the assignment of reference type variables, which copies a reference to the object but not the object itself.  
  
 All value types are derived implicitly from the <xref:System.ValueType?displayProperty=nameWithType>.  
  
 Unlike with reference types, you cannot derive a new type from a value type. However, like reference types, structs can implement interfaces.  
  
 Unlike reference types, a value type cannot contain the `null` value. However, the [nullable types](../../../csharp/programming-guide/nullable-types/index.md) feature does allow for value types to be assigned to `null`.  
  
 Each value type has an implicit default constructor that initializes the default value of that type. For information about default values of value types, see [Default Values Table](../../../csharp/language-reference/keywords/default-values-table.md).  
  
## Main Features of Simple Types  
 All of the simple types -- those integral to the C# language -- are aliases of the .NET Framework System types. For example, [int](../../../csharp/language-reference/keywords/int.md) is an alias of <xref:System.Int32?displayProperty=nameWithType>. For a complete list of aliases, see [Built-In Types Table](../../../csharp/language-reference/keywords/built-in-types-table.md).  
  
 Constant expressions, whose operands are all simple type constants, are evaluated at compilation time.  
  
 Simple types can be initialized by using literals. For example, 'A' is a literal of the type `char` and 2001 is a literal of the type `int`.  
  
## Initializing Value Types  
 Local variables in C# must be initialized before they are used. For example, you might declare a local variable without initialization as in the following example:  
  
```  
int myInt;  
```  
  
 You cannot use it before you initialize it. You can initialize it using the following statement:  
  
```  
myInt = new int();  // Invoke default constructor for int type.  
```  
  
 This statement is equivalent to the following statement:  
  
```  
myInt = 0;         // Assign an initial value, 0 in this example.  
```  
  
 You can, of course, have the declaration and the initialization in the same statement as in the following examples:  
  
```  
int myInt = new int();  
```  
  
 –or–  
  
```  
int myInt = 0;  
```  
  
 Using the [new](../../../csharp/language-reference/keywords/new.md) operator calls the default constructor of the specific type and assigns the default value to the variable. In the preceding example, the default constructor assigned the value `0` to `myInt`. For more information about values assigned by calling default constructors, see [Default Values Table](../../../csharp/language-reference/keywords/default-values-table.md).  
  
 With user-defined types, use [new](../../../csharp/language-reference/keywords/new.md) to invoke the default constructor. For example, the following statement invokes the default constructor of the `Point` struct:  
  
```  
Point p = new Point(); // Invoke default constructor for the struct.  
```  
  
 After this call, the struct is considered to be definitely assigned; that is, all its members are initialized to their default values.  
  
 For more information about the new operator, see [new](../../../csharp/language-reference/keywords/new.md).  
  
 For information about formatting the output of numeric types, see [Formatting Numeric Results Table](../../../csharp/language-reference/keywords/formatting-numeric-results-table.md).  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Types](../../../csharp/language-reference/keywords/types.md)  
 [Reference Tables for Types](../../../csharp/language-reference/keywords/reference-tables-for-types.md)  
 [Reference Types](../../../csharp/language-reference/keywords/reference-types.md)

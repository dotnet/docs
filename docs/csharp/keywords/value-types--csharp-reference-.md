---
title: "Value Types (C# Reference)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "cs.valuetypes"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "value types [C#]"
  - "types [C#], value types"
  - "C# language, value types"
ms.assetid: 471eb994-2958-49d5-a6be-19b4313f80a3
caps.latest.revision: 18
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# Value Types (C# Reference)
The value types consist of two main categories:  
  
-   [Structs](../keywords/struct--csharp-reference-.md)  
  
-   [Enumerations](../keywords/enum--csharp-reference-.md)  
  
 Structs fall into these categories:  
  
-   Numeric types  
  
    -   [Integral types](../keywords/integral-types-table--csharp-reference-.md)  
  
    -   [Floating-point types](../keywords/floating-point-types-table--csharp-reference-.md)  
  
    -   [decimal](../keywords/decimal--csharp-reference-.md)  
  
-   [bool](../keywords/bool--csharp-reference-.md)  
  
-   User defined structs.  
  
## Main Features of Value Types  
 Variables that are based on value types directly contain values. Assigning one value type variable to another copies the contained value. This differs from the assignment of reference type variables, which copies a reference to the object but not the object itself.  
  
 All value types are derived implicitly from the <xref:System.ValueType?displayProperty=fullName>.  
  
 Unlike with reference types, you cannot derive a new type from a value type. However, like reference types, structs can implement interfaces.  
  
 Unlike reference types, a value type cannot contain the `null` value. However, the [nullable types](../nullable-types/nullable-types--csharp-programming-guide-.md) feature does allow for value types to be assigned to `null`.  
  
 Each value type has an implicit default constructor that initializes the default value of that type. For information about default values of value types, see [Default Values Table](../keywords/default-values-table--csharp-reference-.md).  
  
## Main Features of Simple Types  
 All of the simple types -- those integral to the C# language -- are aliases of the .NET Framework System types. For example, [int](../keywords/int--csharp-reference-.md) is an alias of <xref:System.Int32?displayProperty=fullName>. For a complete list of aliases, see [Built-In Types Table](../keywords/built-in-types-table--csharp-reference-.md).  
  
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
  
 Using the [new](../keywords/new--csharp-reference-.md) operator calls the default constructor of the specific type and assigns the default value to the variable. In the preceding example, the default constructor assigned the value `0` to `myInt`. For more information about values assigned by calling default constructors, see [Default Values Table](../keywords/default-values-table--csharp-reference-.md).  
  
 With user-defined types, use [new](../keywords/new--csharp-reference-.md) to invoke the default constructor. For example, the following statement invokes the default constructor of the `Point` struct:  
  
```  
Point p = new Point(); // Invoke default constructor for the struct.  
```  
  
 After this call, the struct is considered to be definitely assigned; that is, all its members are initialized to their default values.  
  
 For more information about the new operator, see [new](../keywords/new--csharp-reference-.md).  
  
 For information about formatting the output of numeric types, see [Formatting Numeric Results Table](../keywords/formatting-numeric-results-table--csharp-reference-.md).  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Types](../keywords/types--csharp-reference-.md)   
 [Reference Tables for Types](../keywords/reference-tables-for-types--csharp-reference-.md)   
 [Reference Types](../keywords/reference-types--csharp-reference-.md)
---
title: "Value Types and Reference Types"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "reference data types [Visual Basic]"
  - "reference types [Visual Basic]"
  - "value types [Visual Basic]"
  - "value data types [Visual Basic]"
  - "types [Visual Basic]"
  - "data types [Visual Basic], value types"
  - "data types [Visual Basic], reference types"
ms.assetid: fc82ce15-5a40-4c5c-a1e1-a556830e7391
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
---
# Value Types and Reference Types
In Visual Basic, data types are implemented based on their classification. The [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] data types can be classified according to whether a variable of a particular type stores its own data or a pointer to the data. If it stores its own data it is a *value type*; if it holds a pointer to data elsewhere in memory it is a *reference type*.  
  
## Value Types  
 A data type is a *value type* if it holds the data within its own memory allocation. Value types include the following:  
  
-   All numeric data types  
  
-   `Boolean`, `Char`, and `Date`  
  
-   All structures, even if their members are reference types  
  
-   Enumerations, since their underlying type is always `SByte`, `Short`, `Integer`, `Long`, `Byte`, `UShort`, `UInteger`, or `ULong`  
  
 Every structure is a value type, even if it contains reference type members. For this reason, value types such as `Char` and `Integer` are implemented by .NET Framework structures.  
  
 You can declare a value type by using the reserved keyword, for example, `Decimal`. You can also use the `New` keyword to initialize a value type. This is especially useful if the type has a constructor that takes parameters. An example of this is the <xref:System.Decimal.%23ctor%28System.Int32%2CSystem.Int32%2CSystem.Int32%2CSystem.Boolean%2CSystem.Byte%29> constructor, which builds a new `Decimal` value from the supplied parts.  
  
## Reference Types  
 A *reference type* contains a pointer to another memory location that holds the data. Reference types include the following:  
  
-   `String`  
  
-   All arrays, even if their elements are value types  
  
-   Class types, such as <xref:System.Windows.Forms.Form>  
  
-   Delegates  
  
 A class is a *reference type*. For this reason, reference types such as `Object` and `String` are supported by [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] classes. Note that every array is a reference type, even if its members are value types.  
  
 Since every reference type represents an underlying .NET Framework class, you must use the [New Operator](../../../../visual-basic/language-reference/operators/new-operator.md) keyword when you initialize it. The following statement initializes an array.  
  
```  
Dim totals() As Single = New Single(8) {}  
```  
  
## Elements That Are Not Types  
 The following programming elements do not qualify as types, because you cannot specify any of them as a data type for a declared element:  
  
-   Namespaces  
  
-   Modules  
  
-   Events  
  
-   Properties and procedures  
  
-   Variables, constants, and fields  
  
## Working with the Object Data Type  
 You can assign either a reference type or a value type to a variable of the `Object` data type. An `Object` variable always holds a pointer to the data, never the data itself. However, if you assign a value type to an `Object` variable, it behaves as if it holds its own data. For more information, see [Object Data Type](../../../../visual-basic/language-reference/data-types/object-data-type.md).  
  
 You can find out whether an `Object` variable is acting as a reference type or a value type by passing it to the <xref:Microsoft.VisualBasic.Information.IsReference%2A> method in the <xref:Microsoft.VisualBasic.Information> class of the <xref:Microsoft.VisualBasic?displayProperty=nameWithType> namespace. <xref:Microsoft.VisualBasic.Information.IsReference%2A?displayProperty=nameWithType> returns `True` if the content of the `Object` variable represents a reference type.  
  
## See Also  
 [Nullable Value Types](../../../../visual-basic/programming-guide/language-features/data-types/nullable-value-types.md)  
 [Type Conversions in Visual Basic](../../../../visual-basic/programming-guide/language-features/data-types/type-conversions.md)  
 [Structure Statement](../../../../visual-basic/language-reference/statements/structure-statement.md)  
 [Efficient Use of Data Types](../../../../visual-basic/programming-guide/language-features/data-types/efficient-use-of-data-types.md)  
 [Object Data Type](../../../../visual-basic/language-reference/data-types/object-data-type.md)  
 [Data Types](../../../../visual-basic/programming-guide/language-features/data-types/index.md)

---
title: "Casting and Type Conversions (C# Programming Guide)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "type conversion [C#]"
  - "data type conversion [C#]"
  - "numeric conversions [C#]"
  - "conversions [C#], type"
  - "casting [C#]"
  - "converting types [C#]"
ms.assetid: 568df58a-d292-4b55-93ba-601578722878
caps.latest.revision: 52
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
# Casting and Type Conversions (C# Programming Guide)
Because C# is statically-typed at compile time, after a variable is declared, it cannot be declared again or used to store values of another type unless that type is convertible to the variable's type. For example, there is no conversion from an integer to any arbitrary string. Therefore, after you declare `i` as an integer, you cannot assign the string "Hello" to it, as is shown in the following code.  
  
```c#  
int i;  
i = "Hello"; // Error: "Cannot implicitly convert type 'string' to 'int'"  
```  
  
 However, you might sometimes need to copy a value into a variable or method parameter of another type. For example, you might have an integer variable that you need to pass to a method whose parameter is typed as `double`. Or you might need to assign a class variable to a variable of an interface type. These kinds of operations are called *type conversions*. In C#, you can perform the following kinds of conversions:  
  
-   **Implicit conversions**: No special syntax is required because the conversion is type safe and no data will be lost. Examples include conversions from smaller to larger integral types, and conversions from derived classes to base classes.  
  
-   **Explicit conversions (casts)**: Explicit conversions require a cast operator. Casting is required when information might be lost in the conversion, or when the conversion might not succeed for other reasons.  Typical examples include numeric conversion to a type that has less precision or a smaller range, and conversion of a base-class instance to a derived class.  
  
-   **User-defined conversions**: User-defined conversions are performed by special methods that you can define to enable explicit and implicit conversions between custom types that do not have a base class–derived class relationship. For more information, see [Conversion Operators](../statements-expressions-operators/conversion-operators--csharp-programming-guide-.md).  
  
-   **Conversions with helper classes**: To convert between non-compatible types, such as integers and <xref:System.DateTime?displayProperty=fullName> objects, or hexadecimal strings and byte arrays, you can use the <xref:System.BitConverter?displayProperty=fullName> class, the <xref:System.Convert?displayProperty=fullName> class, and the `Parse` methods of the built-in numeric types, such as <xref:System.Int32.Parse*?displayProperty=fullName>. For more information, see [How to: Convert a byte Array to an int](../types/how-to--convert-a-byte-array-to-an-int--csharp-programming-guide-.md), [How to: Convert a String to a Number](../types/how-to--convert-a-string-to-a-number--csharp-programming-guide-.md), and [How to: Convert Between Hexadecimal Strings and Numeric Types](../types/7115c49f-7d1d-40c3-8bd9-aae0cc1d46b6.md).  
  
## Implicit Conversions  
 For built-in numeric types, an implicit conversion can be made when the value to be stored can fit into the variable without being truncated or rounded off. For example, a variable of type [long](../keywords/long--csharp-reference-.md) (8 byte integer) can store any value that an [int](../keywords/int--csharp-reference-.md) (4 bytes on a 32-bit computer) can store. In the following example, the compiler implicitly converts the value on the right to a type `long` before assigning it to `bigNum`.  
  
 [!code[csProgGuideTypes#34](../nullable-types/codesnippet/CSharp/casting-and-type-conversions--csharp-programming-guide-_1.cs)]  
  
 For a complete list of all implicit numeric conversions, see [Implicit Numeric Conversions Table](../keywords/implicit-numeric-conversions-table--csharp-reference-.md).  
  
 For reference types, an implicit conversion always exists from a class to any one of its direct or indirect base classes or interfaces. No special syntax is necessary because a derived class always contains all the members of a base class.  
  
```  
Derived d = new Derived();  
Base b = d; // Always OK.  
```  
  
## Explicit Conversions  
 However, if a conversion cannot be made without a risk of losing information, the compiler requires that you perform an explicit conversion, which is called a *cast*. A cast is a way of explicitly informing the compiler that you intend to make the conversion and that you are aware that data loss might occur. To perform a cast, specify the type that you are casting to in parentheses in front of the value or variable to be converted. The following program casts a [double](../keywords/double--csharp-reference-.md) to an [int](../keywords/int--csharp-reference-.md). The program will not compile without the cast.  
  
 [!code[csProgGuideTypes#2](../nullable-types/codesnippet/CSharp/casting-and-type-conversions--csharp-programming-guide-_2.cs)]  
  
 For a list of the explicit numeric conversions that are allowed, see [Explicit Numeric Conversions Table](../keywords/explicit-numeric-conversions-table--csharp-reference-.md).  
  
 For reference types, an explicit cast is required if you need to convert from a base type to a derived type:  
  
```c#  
// Create a new derived type.  
Giraffe g = new Giraffe();  
  
// Implicit conversion to base type is safe.  
Animal a = g;  
  
// Explicit conversion is required to cast back  
// to derived type. Note: This will compile but will  
// throw an exception at run time if the right-side  
// object is not in fact a Giraffe.  
Giraffe g2 = (Giraffe) a;  
```  
  
 A cast operation between reference types does not change the run-time type of the underlying object; it only changes the type of the value that is being used as a reference to that object. For more information, see [Polymorphism](../classes-and-structs/polymorphism--csharp-programming-guide-.md).  
  
## Type Conversion Exceptions at Run Time  
 In some reference type conversions, the compiler cannot determine whether a cast will be valid. It is possible for a cast operation that compiles correctly to fail at run time. As shown in the following example, a type cast that fails at run time will cause an <xref:System.InvalidCastException> to be thrown.  
  
 [!code[csProgGuideTypes#41](../nullable-types/codesnippet/CSharp/casting-and-type-conversions--csharp-programming-guide-_3.cs)]  
  
 C# provides the [is](../keywords/is--csharp-reference-.md) and [as](../keywords/as--csharp-reference-.md) operators to enable you to test for compatibility before actually performing a cast. For more information, see [How to: Safely Cast by Using as and is Operators](../types/how-to--safely-cast-by-using-as-and-is-operators--csharp-programming-guide-.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## Featured Book Chapter  
 [More About Variables](http://go.microsoft.com/fwlink/?LinkId=221230) in [Beginning Visual C# 2010](http://go.microsoft.com/fwlink/?LinkId=221214)  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Types](../types/types--csharp-programming-guide-.md)   
 [() Operator](../operators/---operator--csharp-reference-.md)   
 [explicit](../keywords/explicit--csharp-reference-.md)   
 [implicit](../keywords/implicit--csharp-reference-.md)   
 [Conversion Operators](../statements-expressions-operators/conversion-operators--csharp-programming-guide-.md)   
 [Generalized Type Conversion](../Topic/Generalized%20Type%20Conversion.md)   
 [Exported Type Conversion](http://msdn.microsoft.com/en-us/1dfe55f4-07a2-4b61-aabf-a8cf65783a6b)   
 [How to: Convert a String to a Number](../types/how-to--convert-a-string-to-a-number--csharp-programming-guide-.md)
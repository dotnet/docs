---
title: "Casting and Type Conversions (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
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
---
# Casting and Type Conversions (C# Programming Guide)
Because C# is statically-typed at compile time, after a variable is declared, it cannot be declared again or used to store values of another type unless that type is convertible to the variable's type. For example, there is no conversion from an integer to any arbitrary string. Therefore, after you declare `i` as an integer, you cannot assign the string "Hello" to it, as is shown in the following code.  
  
```csharp  
int i;  
i = "Hello"; // Error: "Cannot implicitly convert type 'string' to 'int'"  
```  
  
 However, you might sometimes need to copy a value into a variable or method parameter of another type. For example, you might have an integer variable that you need to pass to a method whose parameter is typed as `double`. Or you might need to assign a class variable to a variable of an interface type. These kinds of operations are called *type conversions*. In C#, you can perform the following kinds of conversions:  
  
-   **Implicit conversions**: No special syntax is required because the conversion is type safe and no data will be lost. Examples include conversions from smaller to larger integral types, and conversions from derived classes to base classes.  
  
-   **Explicit conversions (casts)**: Explicit conversions require a cast operator. Casting is required when information might be lost in the conversion, or when the conversion might not succeed for other reasons.  Typical examples include numeric conversion to a type that has less precision or a smaller range, and conversion of a base-class instance to a derived class.  
  
-   **User-defined conversions**: User-defined conversions are performed by special methods that you can define to enable explicit and implicit conversions between custom types that do not have a base class–derived class relationship. For more information, see [Conversion Operators](../../../csharp/programming-guide/statements-expressions-operators/conversion-operators.md).  
  
-   **Conversions with helper classes**: To convert between non-compatible types, such as integers and <xref:System.DateTime?displayProperty=nameWithType> objects, or hexadecimal strings and byte arrays, you can use the <xref:System.BitConverter?displayProperty=nameWithType> class, the <xref:System.Convert?displayProperty=nameWithType> class, and the `Parse` methods of the built-in numeric types, such as <xref:System.Int32.Parse%2A?displayProperty=nameWithType>. For more information, see [How to: Convert a byte Array to an int](../../../csharp/programming-guide/types/how-to-convert-a-byte-array-to-an-int.md), [How to: Convert a String to a Number](../../../csharp/programming-guide/types/how-to-convert-a-string-to-a-number.md), and [How to: Convert Between Hexadecimal Strings and Numeric Types](../../../csharp/programming-guide/types/how-to-convert-between-hexadecimal-strings-and-numeric-types.md).  
  
## Implicit Conversions  
 For built-in numeric types, an implicit conversion can be made when the value to be stored can fit into the variable without being truncated or rounded off. For example, a variable of type [long](../../../csharp/language-reference/keywords/long.md) (8 byte integer) can store any value that an [int](../../../csharp/language-reference/keywords/int.md) (4 bytes on a 32-bit computer) can store. In the following example, the compiler implicitly converts the value on the right to a type `long` before assigning it to `bigNum`.  
  
 [!code-csharp[csProgGuideTypes#34](../../../csharp/programming-guide/nullable-types/codesnippet/CSharp/casting-and-type-conversions_1.cs)]  
  
 For a complete list of all implicit numeric conversions, see [Implicit Numeric Conversions Table](../../../csharp/language-reference/keywords/implicit-numeric-conversions-table.md).  
  
 For reference types, an implicit conversion always exists from a class to any one of its direct or indirect base classes or interfaces. No special syntax is necessary because a derived class always contains all the members of a base class.  
  
```  
Derived d = new Derived();  
Base b = d; // Always OK.  
```  
  
## Explicit Conversions  
 However, if a conversion cannot be made without a risk of losing information, the compiler requires that you perform an explicit conversion, which is called a *cast*. A cast is a way of explicitly informing the compiler that you intend to make the conversion and that you are aware that data loss might occur. To perform a cast, specify the type that you are casting to in parentheses in front of the value or variable to be converted. The following program casts a [double](../../../csharp/language-reference/keywords/double.md) to an [int](../../../csharp/language-reference/keywords/int.md). The program will not compile without the cast.  
  
 [!code-csharp[csProgGuideTypes#2](../../../csharp/programming-guide/nullable-types/codesnippet/CSharp/casting-and-type-conversions_2.cs)]  
  
 For a list of the explicit numeric conversions that are allowed, see [Explicit Numeric Conversions Table](../../../csharp/language-reference/keywords/explicit-numeric-conversions-table.md).  
  
 For reference types, an explicit cast is required if you need to convert from a base type to a derived type:  
  
```csharp  
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
  
 A cast operation between reference types does not change the run-time type of the underlying object; it only changes the type of the value that is being used as a reference to that object. For more information, see [Polymorphism](../../../csharp/programming-guide/classes-and-structs/polymorphism.md).  
  
## Type Conversion Exceptions at Run Time  
 In some reference type conversions, the compiler cannot determine whether a cast will be valid. It is possible for a cast operation that compiles correctly to fail at run time. As shown in the following example, a type cast that fails at run time will cause an <xref:System.InvalidCastException> to be thrown.  
  
 [!code-csharp[csProgGuideTypes#41](../../../csharp/programming-guide/nullable-types/codesnippet/CSharp/casting-and-type-conversions_3.cs)]  
  
 C# provides the [is](../../../csharp/language-reference/keywords/is.md) and [as](../../../csharp/language-reference/keywords/as.md) operators to enable you to test for compatibility before actually performing a cast. For more information, see [How to: Safely Cast by Using as and is Operators](../../../csharp/programming-guide/types/how-to-safely-cast-by-using-as-and-is-operators.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  

## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Types](../../../csharp/programming-guide/types/index.md)  
 [() Operator](../../../csharp/language-reference/operators/invocation-operator.md)  
 [explicit](../../../csharp/language-reference/keywords/explicit.md)  
 [implicit](../../../csharp/language-reference/keywords/implicit.md)  
 [Conversion Operators](../../../csharp/programming-guide/statements-expressions-operators/conversion-operators.md)  
 [Generalized Type Conversion](http://msdn.microsoft.com/library/49253ae6-7657-4810-82ab-1176a6feeada)  
 [Exported Type Conversion](http://msdn.microsoft.com/library/1dfe55f4-07a2-4b61-aabf-a8cf65783a6b)  
 [How to: Convert a String to a Number](../../../csharp/programming-guide/types/how-to-convert-a-string-to-a-number.md)

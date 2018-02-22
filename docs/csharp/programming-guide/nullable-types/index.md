---
title: "Nullable Types (C# Programming Guide)"
ms.date: 05/15/2017
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "nullable types [C#]"
  - "C# language, nullable types"
  - "types [C#], nullable"
ms.assetid: e473cb01-28ca-42be-9cea-f717055d72c6
caps.latest.revision: 44
author: "BillWagner"
ms.author: "wiwagn"
---
# Nullable Types (C# Programming Guide)
Nullable types are instances of the <xref:System.Nullable%601?displayProperty=nameWithType> struct. A nullable type can represent the correct range of values for its underlying value type, plus an additional `null` value. For example, a `Nullable<Int32>`, pronounced "Nullable of Int32," can be assigned any value from -2147483648 to 2147483647, or it can be assigned the `null` value. A `Nullable<bool>` can be assigned the values [true](../../../csharp/language-reference/keywords/true.md), [false](../../../csharp/language-reference/keywords/false.md), or [null](../../../csharp/language-reference/keywords/null.md). The ability to assign `null` to numeric and Boolean types is especially useful when you are dealing with databases and other data types that contain elements that may not be assigned a value. For example, a Boolean field in a database can store the values `true` or `false`, or it may be undefined. 
  
[!code-csharp[nullable-types](../../../../samples/snippets/csharp/programming-guide/nullable-types/nullable-ex1.cs)]  
  
For more examples, see [Using Nullable Types](../../../csharp/programming-guide/nullable-types/using-nullable-types.md)  
  
## Nullable Types Overview  
 Nullable types have the following characteristics:  
  
-   Nullable types represent value-type variables that can be assigned the value of `null`. You cannot create a nullable type based on a reference type. (Reference types already support the `null` value.)  
  
-   The syntax `T?` is shorthand for <xref:System.Nullable%601>, where `T` is a value type. The two forms are interchangeable.  
  
-   Assign a value to a nullable type just as you would for an ordinary value type, for example `int? x = 10;` or `double? d = 4.108`. A nullable type can also be assigned the value `null`: `int? x = null.`  
  
-   Use the <xref:System.Nullable%601.GetValueOrDefault%2A?displayProperty=nameWithType> method to return either the assigned value, or the default value for the underlying type if the value is `null`, for example `int j = x.GetValueOrDefault();`  
  
-   Use the <xref:System.Nullable%601.HasValue%2A> and <xref:System.Nullable%601.Value%2A> read-only properties to test for null and retrieve the value, as shown in the following example: `if(x.HasValue) j = x.Value;`  
  
    -   The `HasValue` property returns `true` if the variable contains a value, or `false` if it is `null`.  
  
    -   The `Value` property returns a value if one is assigned. Otherwise, a <xref:System.InvalidOperationException?displayProperty=nameWithType> is thrown.  
  
    -   The default value for `HasValue` is `false`. The `Value` property has no default value.  
  
    -   You can also use the `==` and `!=` operators with a nullable type, as shown in the following example: `if (x != null) y = x;`  
  
-   Use the `??` operator to assign a default value that will be applied when a nullable type whose current value is `null` is assigned to a non-nullable type, for example `int? x = null; int y = x ?? -1;`  
  
-   Nested nullable types are not allowed. The following line will not compile: `Nullable<Nullable<int>> n;`  
  
## Related Sections  
 For more information:  
  
-   [Using Nullable Types](../../../csharp/programming-guide/nullable-types/using-nullable-types.md)  
  
-   [Boxing Nullable Types](../../../csharp/programming-guide/nullable-types/boxing-nullable-types.md)  
  
-   [?? Operator](../../../csharp/language-reference/operators/null-conditional-operator.md)  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 <xref:System.Nullable>  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C#](../../../csharp/index.md)  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [What exactly does 'lifted' mean?](https://blogs.msdn.microsoft.com/ericlippert/2007/06/27/what-exactly-does-lifted-mean/)

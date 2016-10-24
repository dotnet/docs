---
title: "Nullable Types (C# Programming Guide)"
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
  - "nullable types [C#]"
  - "C# language, nullable types"
  - "types [C#], nullable"
ms.assetid: e473cb01-28ca-42be-9cea-f717055d72c6
caps.latest.revision: 44
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
# Nullable Types (C# Programming Guide)
Nullable types are instances of the <xref:System.Nullable`1?displayProperty=fullName> struct. A nullable type can represent the correct range of values for its underlying value type, plus an additional `null` value. For example, a `Nullable<Int32>`, pronounced "Nullable of Int32," can be assigned any value from -2147483648 to 2147483647, or it can be assigned the `null` value. A `Nullable<bool>` can be assigned the values [true](../keywords/true--csharp-reference-.md)[false](../keywords/false--csharp-reference-.md), or [null](../keywords/null--csharp-reference-.md). The ability to assign `null` to numeric and Boolean types is especially useful when you are dealing with databases and other data types that contain elements that may not be assigned a value. For example, a Boolean field in a database can store the values `true` or `false`, or it may be undefined.  
  
 [!code[csProgGuideTypes#3](../nullable-types/codesnippet/CSharp/nullable-types--csharp-programming-guide-_1.cs)]  
  
 The example will display the output:  
  
 `num = Null`  
  
 `Nullable object must have a value.`  
  
 For more examples, see [Using Nullable Types](../nullable-types/using-nullable-types--csharp-programming-guide-.md)  
  
## Nullable Types Overview  
 Nullable types have the following characteristics:  
  
-   Nullable types represent value-type variables that can be assigned the value of `null`. You cannot create a nullable type based on a reference type. (Reference types already support the `null` value.)  
  
-   The syntax `T?` is shorthand for <xref:System.Nullable`1>, where `T` is a value type. The two forms are interchangeable.  
  
-   Assign a value to a nullable type just as you would for an ordinary value type, for example `int? x = 10;` or `double? d = 4.108`. A nullable type can also be assigned the value `null`: `int? x = null.`  
  
-   Use the <xref:System.Nullable`1.GetValueOrDefault*?displayProperty=fullName> method to return either the assigned value, or the default value for the underlying type if the value is `null`, for example `int j = x.GetValueOrDefault();`  
  
-   Use the <xref:System.Nullable`1.HasValue*> and <xref:System.Nullable`1.Value*> read-only properties to test for null and retrieve the value, as shown in the following example: `if(x.HasValue) j = x.Value;`  
  
    -   The `HasValue` property returns `true` if the variable contains a value, or `false` if it is `null`.  
  
    -   The `Value` property returns a value if one is assigned. Otherwise, a <xref:System.InvalidOperationException?displayProperty=fullName> is thrown.  
  
    -   The default value for `HasValue` is `false`. The `Value` property has no default value.  
  
    -   You can also use the `==` and `!=` operators with a nullable type, as shown in the following example: `if (x != null) y = x;`  
  
-   Use the `??` operator to assign a default value that will be applied when a nullable type whose current value is `null` is assigned to a non-nullable type, for example `int? x = null; int y = x ?? -1;`  
  
-   Nested nullable types are not allowed. The following line will not compile: `Nullable<Nullable<int>> n;`  
  
## Related Sections  
 For more information:  
  
-   [Using Nullable Types](../nullable-types/using-nullable-types--csharp-programming-guide-.md)  
  
-   [Boxing Nullable Types](../nullable-types/boxing-nullable-types--csharp-programming-guide-.md)  
  
-   [?? Operator](../operators/---operator--csharp-reference-.md)  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 <xref:System.Nullable>   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C#](../root/csharp.md)   
 [C# Reference](../language-reference/csharp-reference.md)   
 [What exactly does 'lifted' mean?](http://go.microsoft.com/fwlink/?LinkId=112382)
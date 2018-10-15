---
title: "as (C# Reference)"
ms.date: 10/11/2018
f1_keywords: 
  - "as_CSharpKeyword"
  - "as"
helpviewer_keywords: 
  - "type conversion [C#], as keyword"
  - "as keyword [C#]"
ms.assetid: a9be126b-cbf4-4990-a70d-d0e1983cad0e
---
# as (C# Reference)
You can use the `as` operator to perform certain types of conversions between compatible reference types or [nullable types](../../../csharp/programming-guide/nullable-types/index.md). The following code shows an example.  
  
[!code-csharp[csrefKeywordsOperator#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsOperator/CS/csrefKeywordsOperators.cs#1)]

As the example shows, you need to compare the result of the `as` expression with `null` to check if a conversion is successful. Beginning with C# 7.0, you can use the [is](is.md) expression both to test that a conversion succeeds and conditionally assign a variable when the conversion succeeds. In many scenarios, it's more concise than using the `as` operator. For more information, see the [Type pattern](is.md#type) section of the [`is` operator](is.md) article.
  
## Remarks  
 The `as` operator is like a cast operation. However, if the conversion isn't possible, `as` returns `null` instead of raising an exception. Consider the following example:  
  
```csharp  
expression as type  
```  
  
 The code is equivalent to the following expression except that the `expression` variable is evaluated only one time.  
  
```csharp  
expression is type ? (type)expression : (type)null  
```  
  
 Note that the `as` operator performs only reference conversions, nullable conversions, and boxing conversions. The `as` operator can't perform other conversions, such as user-defined conversions, which should instead be performed by using cast expressions.  
  
## Example  

[!code-csharp[csrefKeywordsOperator#2](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsOperator/CS/csrefKeywordsOperators.cs#2)]
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
- [C# Reference](../../../csharp/language-reference/index.md)  
- [C# Programming Guide](../../../csharp/programming-guide/index.md)  
- [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
- [is](../../../csharp/language-reference/keywords/is.md)  
- [?: Operator](../../../csharp/language-reference/operators/conditional-operator.md)  
- [Operator Keywords](../../../csharp/language-reference/keywords/operator-keywords.md)

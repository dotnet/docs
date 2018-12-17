---
title: "typeof - C# Reference"
ms.custom: seodec18

ms.date: 07/20/2015
f1_keywords: 
  - "typeof"
  - "typeof_CSharpKeyword"
helpviewer_keywords: 
  - "typeof keyword [C#]"
ms.assetid: 0c08d880-515e-46bb-8cd2-48b8dd62c08d
---
# typeof (C# Reference)

Used to obtain the <xref:System.Type?displayProperty=nameWithType> object for a type. A `typeof` expression takes the following form:

```csharp
System.Type type = typeof(int);
```

## Remarks

To obtain the run-time type of an expression, you can use the .NET Framework method <xref:System.Object.GetType%2A>, as in the following example:

```csharp
int i = 0;
System.Type type = i.GetType();
```

The `typeof` operator cannot be overloaded.

The `typeof` operator can also be used on open generic types. Types with more than one type parameter must have the appropriate number of commas in the specification. The following example shows how to determine whether the return type of a method is a generic <xref:System.Collections.Generic.IEnumerable%601>. <xref:System.Type.GetInterface%2A?displayProperty=nameWithType> will return `null` if the return type is not an <xref:System.Collections.Generic.IEnumerable%601> generic type.

[!code-csharp[typeof_3.cs](~/samples/snippets/csharp/keywords/typeof/typeof_3.cs)]

## Example

[!code-csharp[csrefKeywordsOperator#12](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsOperator/CS/csrefKeywordsOperators.cs#12)] 

## Example

This sample uses the <xref:System.Object.GetType%2A> method to determine the type that is used to contain the result of a numeric calculation. This depends on the storage requirements of the resulting number.

[!code-csharp[csrefKeywordsOperator#13](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsOperator/CS/csrefKeywordsOperators.cs#13)]

## C# language specification

For more information, see [The typeof operator](~/_csharplang/spec/expressions.md#the-typeof-operator) in the [C# Language Specification](../language-specification/index.md). The language specification is the definitive source for C# syntax and usage.

## See also

- <xref:System.Type?displayProperty=nameWithType>
- [C# Reference](../../../csharp/language-reference/index.md)
- [C# Programming Guide](../../../csharp/programming-guide/index.md)
- [C# Keywords](../../../csharp/language-reference/keywords/index.md)
- [is](../../../csharp/language-reference/keywords/is.md)
- [Operator Keywords](../../../csharp/language-reference/keywords/operator-keywords.md)
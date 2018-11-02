---
title: "?: Operator (C# Reference)"
ms.date: "07/20/2015"
f1_keywords: 
  - "?:_CSharpKeyword"
  - "?_CSharpKeyword"
  - ":_CSharpKeyword"
helpviewer_keywords: 
  - "?: operator [C#]"
  - "conditional operator (?:) [C#]"
ms.assetid: e83a17f1-7500-48ba-8bee-2fbc4c847af4
---

# ?: Operator (C# Reference)

The conditional operator (`?:`), commonly known as the ternary conditional operator, returns one of two values depending on the value of a Boolean expression. Following is the syntax for the conditional operator.  

```csharp
condition ? first_expression : second_expression;  
```

Beginning with C# 7.2, the `first_expression` and `second_expression` my be [`ref` expressions](https://github.com/dotnet/csharplang/blob/master/proposals/csharp-7.2/conditional-ref.md):

```csharp
ref condition ? ref first_expression : ref second_expression;  
```

The result may be assigned to a `ref` or `ref readonly` variable, or to a variable with neither modifier.

## Remarks

The `condition` must evaluate to `true` or `false`. If `condition` is `true`, `first_expression` is evaluated and becomes the result. If `condition` is `false`, `second_expression` is evaluated and becomes the result. Only one of the two expressions is evaluated. This is particularly important for expressions where the result is a `ref`, as the following is valid:

```csharp
ref (storage != null) ? ref storage[3] : ref defaultValue;
```

The reference to `storage` is not evaluated when `storage` is null.

When the result is a value, the type of `first_expression` and `second_expression` must be the same, or there must be an implicit conversion from one type to the other. When the result is a `ref`, the type of `first_expression` and `second_expression` must be the same.

You can express calculations that might otherwise require an `if-else` construction more concisely by using the conditional operator. For example, the following code uses first an `if` statement and then a conditional operator to classify an integer as positive or negative.

```csharp
int input = Convert.ToInt32(Console.ReadLine());  
string classify;  
  
// if-else construction.  
if (input > 0)  
    classify = "positive";  
else  
    classify = "negative";  
  
// ?: conditional operator.  
classify = (input > 0) ? "positive" : "negative";  
```

The conditional operator is right-associative. The expression `a ? b : c ? d : e` is evaluated as `a ? b : (c ? d : e)`, not as `(a ? b : c) ? d : e`.  
  
The conditional operator cannot be overloaded.
  
## Example

The following example shows the conditional operator whose result is a value:

[!code-csharp[csRefOperators?:](~/samples/snippets/csharp/language-reference/operators/ConditionalExamples.cs#ConditionalValue)]

The following alternative shows the conditional operator where the result is a reference:

[!code-csharp[csRefOperatorsRef?:](~/samples/snippets/csharp/language-reference/operators/ConditionalExamples.cs#ConditionalRef)]

## See Also

- [C# Reference](../../../csharp/language-reference/index.md)  
- [C# Programming Guide](../../../csharp/programming-guide/index.md)  
- [C# Operators](../../../csharp/language-reference/operators/index.md)  
- [if-else](../../../csharp/language-reference/keywords/if-else.md)  
- [?. and ?[] Operators](../../../csharp/language-reference/operators/null-conditional-operators.md)  
- [?? Operator](../../../csharp/language-reference/operators/null-coalescing-operator.md)

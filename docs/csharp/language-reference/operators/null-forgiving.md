---
title: "! (null-forgiving) operator - C# reference"
ms.date: 10/09/2019
f1_keywords: 
  - "!_CSharpKeyword"
helpviewer_keywords: 
  - "null-forgiving operator [C#]"
  - "! operator [C#]"
---
# ! (null-forgiving) operator (C# reference)

Available in C# 8.0 and later, the unary postfix `!` operator is a null-forgiving operator. In an enabled [nullable annotation context](../../nullable-references.md#nullable-annotation-context), you use the null-forgiving operator to declare that expression `x` of a reference type isn't null: `x!`. The unary prefix `!` operator is a [logical negation operator](boolean-logical-operators.md#logical-negation-operator-).

The null-forgiving operator has no effect at run time. It only affects the compiler's static flow analysis by changing the null state of the expression. At run time, expression `x!` evaluates to the result of the underlying expression `x`.

One of the use cases of the null-forgiving operator is in testing the argument validation logic. For example, consider the following class:

```csharp
#nullable enable
using System;

public class Person
{
    public Person(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));

    public string Name { get; }
}
```

Using the [MSTest test framework](../../../core/testing/unit-testing-with-mstest.md), you can create the following test for the constructor argument validation logic:

```csharp
[TestMethod, ExpectedException(typeof(ArgumentNullException))]
public void NullNameShouldThrowTest()
{
    var person = new Person(null!);
}
```

Without the null-forgiving operator, the compiler generates the following warning for the preceding code: `Warning CS8625: Cannot convert null literal to non-nullable reference type`. With the use of the null-forgiving operator, you let the compiler know that passing `null` in the test code is expected and shouldn't be warned about.

For more information about the nullable reference types feature, see [Nullable reference types](../../nullable-references.md).

## See also

- [C# reference](../index.md)
- [C# operators](index.md)
- [Tutorial: Design with nullable reference types](../../tutorials/nullable-reference-types.md)

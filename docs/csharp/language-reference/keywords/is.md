---
title: "is - C# Reference"
ms.custom: seodec18
ms.date: 06/21/2019
f1_keywords: 
  - "is_CSharpKeyword"
  - "is"
helpviewer_keywords: 
  - "is keyword [C#]"
ms.assetid: bc62316a-d41f-4f90-8300-c6f4f0556e43
---
# is (C# Reference)

The `is` operator checks if the result of an expression is compatible with a given type, or (starting with C# 7.0) tests an expression against a pattern. For information about the type-testing `is` operator see the [is operator](../operators/type-testing-and-cast.md#is-operator) section of the [Type-testing and cast operators](../operators/type-testing-and-cast.md) article.

## Pattern matching with `is`

Starting with C# 7.0, the `is` and [switch](switch.md) statements support pattern matching. The `is` keyword supports the following patterns:

- [Type pattern](#type-pattern), which tests whether an expression can be converted to a specified type and, if it can be, casts it to a variable of that type.

- [Constant pattern](#constant-pattern), which tests whether an expression evaluates to a specified constant value.

- [var pattern](#var-pattern), a match that always succeeds and binds the value of an expression to a new local variable.

### Type pattern

When using the type pattern to perform pattern matching, `is` tests whether an expression can be converted to a specified type and, if it can be, casts it to a variable of that type. It's a straightforward extension of the `is` statement that enables concise type evaluation and conversion. The general form of the `is` type pattern is:

```csharp
   expr is type varname
```

where *expr* is an expression that evaluates to an instance of some type, *type* is the name of the type to which the result of *expr* is to be converted, and *varname* is the object to which the result of *expr* is converted if the `is` test is `true`. 

The `is` expression is `true` if *expr* isn't `null`, and any of the following is true:

- *expr* is an instance of the same type as *type*.

- *expr* is an instance of a type that derives from *type*. In other words, the result of *expr* can be upcast to an instance of *type*.

- *expr* has a compile-time type that is a base class of *type*, and *expr* has a runtime type that is *type* or is derived from *type*. The *compile-time type* of a variable is the variable's type as defined in its declaration. The *runtime type* of a variable is the type of the instance that is assigned to that variable.

- *expr* is an instance of a type that implements the *type* interface.

Beginning with C# 7.1, *expr* may have a compile-time type defined by a generic type parameter and its constraints.

If *expr* is `true` and `is` is used with an `if` statement, *varname* is assigned within the `if` statement only. The scope of *varname* is from the `is` expression to the end of the block enclosing the `if` statement. Using *varname* in any other location generates a compile-time error for use of a variable that has not been assigned.

The following example uses the `is` type pattern to provide the implementation of a type's <xref:System.IComparable.CompareTo(System.Object)?displayProperty=nameWithType> method.

[!code-csharp[is#5](../../../../samples/snippets/csharp/language-reference/keywords/is/is-type-pattern5.cs#5)]

Without pattern matching, this code might be written as follows. The use of type pattern matching produces more compact, readable code by eliminating the need to test whether the result of a conversion is a `null`.  

[!code-csharp[is#6](../../../../samples/snippets/csharp/language-reference/keywords/is/is-type-pattern6.cs#6)]

The `is` type pattern also produces more compact code when determining the type of a value type. The following example uses the `is` type pattern to determine whether an object is a `Person` or a `Dog` instance before displaying the value of an appropriate property.

[!code-csharp[is#9](../../../../samples/snippets/csharp/language-reference/keywords/is/is-type-pattern9.cs#9)]

The equivalent code without pattern matching requires a separate assignment that includes an explicit cast.

[!code-csharp[is#10](../../../../samples/snippets/csharp/language-reference/keywords/is/is-type-pattern10.cs#10)]

### Constant pattern

When performing pattern matching with the constant pattern, `is` tests whether an expression equals a specified constant. In C# 6 and earlier versions, the constant pattern is supported by the [switch](switch.md) statement. Starting with C# 7.0, it's supported by the `is` statement as well. Its syntax is:

```csharp
   expr is constant
```

where *expr* is the expression to evaluate, and *constant* is the value to test for. *constant* can be any of the following constant expressions:

- A literal value.

- The name of a declared `const` variable.

- An enumeration constant.

The constant expression is evaluated as follows:

- If *expr* and *constant* are integral types, the C# equality operator determines whether the expression returns `true` (that is, whether `expr == constant`).

- Otherwise, the value of the expression is determined by a call to the static [Object.Equals(expr, constant)](xref:System.Object.Equals(System.Object,System.Object)) method.  

The following example combines the type and constant patterns to test whether an object is a `Dice` instance and, if it is, to determine whether the value of a dice roll is 6.

[!code-csharp[is#7](../../../../samples/snippets/csharp/language-reference/keywords/is/is-const-pattern7.cs#7)]

Checking for `null` can be performed using the constant pattern. The `null` keyword is supported by the `is` statement. Its syntax is:

```csharp
   expr is null
```

The following example shows a comparison of `null` checks:

[!code-csharp[is#11](../../../../samples/snippets/csharp/language-reference/keywords/is/is-const-pattern11.cs#11)]

### var pattern

The `var` pattern is a catch-all for any type or value. The value of *expr* is always assigned to a local variable the same type as the compile time type of *expr*. The result of the `is` expression is always `true`. Its syntax is:

```csharp
   expr is var varname
```

The following example uses the var pattern to assign an expression to a variable named `obj`. It then displays the value and the type of `obj`.

[!code-csharp[is#8](../../../../samples/snippets/csharp/language-reference/keywords/is/is-var-pattern8.cs#8)]

## C# language specification
  
For more information, see [The is operator](~/_csharplang/spec/expressions.md#the-is-operator) section of the [C# language specification](~/_csharplang/spec/introduction.md) and the following C# language proposals:

- [Pattern matching](~/_csharplang/proposals/csharp-7.0/pattern-matching.md)
- [Pattern matching with generics](~/_csharplang/proposals/csharp-7.1/generics-pattern-match.md)
  
## See also

- [C# reference](../index.md)
- [C# keywords](index.md)
- [Type-testing and cast operators](../operators/type-testing-and-cast.md)

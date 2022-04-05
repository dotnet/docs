---
title: "!! (null validation) operator - C# reference"
description: "Learn about simplified null-parameter checks. This operator instructs the compiler to add runtime checks that the argument used for a parameter isn't null."
ms.date: 03/30/2022
f1_keywords: 
  - "!!_CSharpKeyword"
helpviewer_keywords:
  - "null validation operator [C#]"
  - "!! operator [C#]"
---
# !! (null validation) operator (C# reference)

The `!!` operator, introduced in C# 11, provides null validation parameter syntax. Adding `!!` to the parameter name in the declaration instructs the compiler to add a runtime check for that parameter. For example:

:::code language="csharp" source="./snippets/shared/NullParameterCheck.cs" id="BangBangExample":::

generates code similar to the following example:

:::code language="csharp" source="./snippets/shared/NullParameterCheck.cs" id="HandCodedExample":::

Multiple annotated parameters are checked in the order declared on the method. For example, the following code:

:::code language="csharp" source="./snippets/shared/NullParameterCheck.cs" id="MultipleParameters":::

generates code similar to the following example:

:::code language="csharp" source="./snippets/shared/NullParameterCheck.cs" id="HandCodedMultipleParms":::

It's intended for library authors to provide runtime checks. You should only add the `!!` operator on those parameters that require a null-check for safety. In the preceding example, the `message` parameter doesn't have a runtime null check.

## Where `!!` can be applied

There are a few rules that govern where you can add the `!!` operator on a parameter declaration:

- The `!!` operator directs the compiler to add runtime behavior. It can't be applied to a declaration without an implementation. You can't add `!!` to the parameter of an abstract member, an interface method without an implementation, or a parameter on a delegate type declaration.
- The parameter type must be a type that can be compared to `null`. For example, the parameter can't be a non-nullable value type. If the parameter is a type parameter, it can't be constrained to be a non-nullable type (for example the `struct`, `notnull`, and `unmanaged` constraints are disallowed.)

The following example demonstrates the preceding rules:

:::code language="csharp" source="./snippets/shared/NullParameterCheck.cs" id="NoAbstractMethods":::

## Constructors and !!

In almost all cases, the code the compiler generates for `!!` on an argument is consistent with the preceding example. However, the null check is inserted before any code you write in the method. There are observable differences between a hand-coded null check and adding `!!` on the parameter of a constructor. When you hand-write the null check in the body of a constructor, that null check runs after any field initializers, constructor chains, and base class constructors are called. Consider the following code:

:::code language="csharp" source="./snippets/shared/NullParameterCheck.cs" id="HandCodedConstruction":::

If you call `new D1(null!)`, you'll see the following output:

```dotnetcli
Creating identity string
In B constructor
Parameterless D constructor
```

The field initializer runs, the base constructor runs, and the chained constructor runs. All of them run before the check. Change the constructor to use the simplified null check operator, `!!` and none of the output will be printed:

:::code language="csharp" source="./snippets/shared/NullParameterCheck.cs" id="SimplifiedConstructorCheck":::

The compiler synthesizes the null check before the synthesized code that runs the field initializers and calls the chained and base constructors.

## iterator methods and !!

Iterator methods behave different when the `!!` operator provides the null check. Consider the following iterator method:

:::code language="csharp" source="./snippets/shared/NullParameterCheck.cs" id="IteratorMethod":::

When you call that method passing in a null argument as shows in the following example:

:::code language="csharp" source="./snippets/shared/NullParameterCheck.cs" id="Enumerate":::

The message "Call iterator" is displayed before the exception is thrown. That's because the null check doesn't run until the first element in the sequence is requested. Instead, if you use the `!!` operator, the exception is thrown when `CharsIn` is called, not when the first element of the sequence is requested.

:::code language="csharp" source="./snippets/shared/NullParameterCheck.cs" id="IteratorMethodSimplified":::

## async methods and !!

Async methods and async iterators also change the source of the exception. Consider the following method with a hand written null check:

:::code language="csharp" source="./snippets/shared/NullParameterCheck.cs" id="AsyncMethod":::

If you call that method using `null` as the argument, the return value is a `Task<int>` in the <xref:System.Threading.Tasks.TaskStatus.Faulted?displayProperty=nameWithType> state. The exception will be thrown when the `Task` is awaited. If you switch to a simplified null check, the exception is thrown when `SumCharsIn` is called, not when the returned task is awaited.

Finally, the same behavior occurs for an async enumerator method. In the following code, the null check runs when the first element is retrieved using `await foreach`:

:::code language="csharp" source="./snippets/shared/NullParameterCheck.cs" id="AsyncIteratorMethod":::

If you replace the hand-written null check with a `!!`, the exception is thrown as soon as `CharsInAsync` is called, even if the sequence isn't enumerated yet.

## Null parameter checks and nullable types

With null state analysis, any parameter annotated with `!!` has an initial null state of *not null*. The compiler has already added a null check. The compiler generates a warning when you write a method where a parameter is nullable and you've added a null check. Consider the following example:

```csharp
void Method(string? name!!)
{
    // ...
}
```

The compiler issues the warning *"Nullable type 'string?' is null-checked and will throw if null."* The signature indicates that the method should accept `null` as the argument for `name`, and yet throws when that argument is supplied.

The `!!` operator instructs the compiler to add runtime null checks on a parameter. This complements the compile time annotations provided by nullable reference types. It can provide more resilience in your code.

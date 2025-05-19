<!-- filepath: /Users/yufeih/docs/docs/csharp/language-reference/statements/declarations.md -->
---
title: "Declaration statements - local variables and constants, var, local reference variables (ref locals)"
description: "Declaration statements introduce a new local variable, local constant, or local reference variable (ref local). Local variables can be explicitly or implicitly typed. A declaration statement can also include initialization of a variable's value."
ms.date: 06/21/2023
f1_keywords: 
  - "var"
  - "var_CSharpKeyword"
  - "scoped"
  - "scoped_CSharpKeyword"
helpviewer_keywords: 
  - "var keyword [C#]"
---
# Declaration statements

A declaration statement declares a new local variable, local constant, or [local reference variable](#reference-variables). To declare a local variable, specify its type and provide its name. You can declare multiple variables of the same type in one statement, as the following example shows:

:::code language="csharp" source="snippets/declarations/Declaration.cs" id="Declare":::

In a declaration statement, you can also initialize a variable with its initial value:

:::code language="csharp" source="snippets/declarations/Declaration.cs" id="DeclareAndInit":::

The preceding examples explicitly specify the type of a variable. You can also let the compiler infer the type of a variable from its initialization expression. To do that, use the `var` keyword instead of a type's name. For more information, see the [Implicitly-typed local variables](#implicitly-typed-local-variables) section.

To declare a local constant, use the [`const` keyword](../keywords/const.md), as the following example shows:

:::code language="csharp" source="snippets/declarations/Declaration.cs" id="LocalConstant":::

When you declare a local constant, you must also initialize it.

For information about local reference variables, see the [Reference variables](#reference-variables) section.

## Implicitly-typed local variables

When you declare a local variable, you can let the compiler infer the type of the variable from the initialization expression. To do that use the `var` keyword instead of the name of a type:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/declarations/ImplicitlyTyped.cs" id="ImplicitlyTyped":::

As the preceding example shows, implicitly-typed local variables are strongly typed.

> [!NOTE]
> When you use `var` in the enabled [nullable aware context](../builtin-types/nullable-reference-types.md) and the type of an initialization expression is a reference type, the compiler always infers a **nullable** reference type even if the type of an initialization expression isn't nullable.

A common use of `var` is with a [constructor invocation expression](../operators/new-operator.md#constructor-invocation). The use of `var` allows you to not repeat a type name in a variable declaration and object instantiation, as the following example shows:

```csharp
var xs = new List<int>();
```

You can use a [target-typed `new` expression](../operators/new-operator.md#target-typed-new) as an alternative:

```csharp
List<int> xs = new();
List<int>? ys = new();
```

When you work with [anonymous types](../../fundamentals/types/anonymous-types.md), you must use implicitly-typed local variables. The following example shows a [query expression](../keywords/query-keywords.md) that uses an anonymous type to hold a customer's name and phone number:

:::code language="csharp" source="snippets/declarations/ImplicitlyTyped.cs" id="VarExample":::

In the preceding example, you can't explicitly specify the type of the `fromPhoenix` variable. The type is <xref:System.Collections.Generic.IEnumerable%601> but in this case `T` is an anonymous type and you can't provide its name. That's why you need to use `var`. For the same reason, you must use `var` when you declare the `customer` iteration variable in the `foreach` statement.

For more information about implicitly-typed local variables, see [Implicitly-typed local variables](../../programming-guide/classes-and-structs/implicitly-typed-local-variables.md).

In pattern matching, the `var` keyword is used in a [`var` pattern](../operators/patterns.md#var-pattern).

## Reference variables

When you declare a local variable and add the `ref` keyword before the variable's type, you declare a *reference variable*, or a `ref` local:

```csharp
ref int aliasOfvariable = ref variable;
```

A reference variable is a variable that refers to another variable, which is called the *referent*. That is, a reference variable is an *alias* to its referent. When you assign a value to a reference variable, that value is assigned to the referent. When you read the value of a reference variable, the referent's value is returned. The following example demonstrates that behavior:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/declarations/ReferenceVariables.cs" id="AliasToLocalVariable":::

Use the [`ref` assignment operator](../operators/assignment-operator.md#ref-assignment) `= ref` to change the referent of a reference variable, as the following example shows:

:::code language="csharp" source="snippets/declarations/ReferenceVariables.cs" id="RefReassign":::

In the preceding example, the `element` reference variable is initialized as an alias to the first array element. Then it's `ref` reassigned to refer to the last array element.

You can define a `ref readonly` local variable. You can't assign a value to a `ref readonly` variable. However you can `ref` reassign such a reference variable, as the following example shows:

:::code language="csharp" source="snippets/declarations/ReferenceVariables.cs" id="RefReadonly":::

You can assign a [reference return](jump-statements.md#ref-returns) to a reference variable, as the following example shows:

:::code language="csharp" source="snippets/declarations/NumberStore.cs" id="ReferenceReturns":::

In the preceding example, the `GetReferenceToMax` method is a *returns-by-ref* method. It doesn't return the maximum value itself, but a reference return that is an alias to the array element that holds the maximum value. The `Run` method assigns a reference return to the `max` reference variable. Then, by assigning to `max`, it updates the internal storage of the `store` instance. You can also define a `ref readonly` method. The callers of a `ref readonly` method can't assign a value to its reference return.

The iteration variable of the `foreach` statement can be a reference variable. For more information, see the [`foreach` statement](iteration-statements.md#the-foreach-statement) section of the [Iteration statements](iteration-statements.md) article.

In performance-critical scenarios, the use of reference variables and returns might increase performance by avoiding potentially expensive copy operations.

The compiler ensures that a reference variable doesn't outlive its referent and stays valid for the whole of its lifetime. For more information, see the [Ref safe contexts](~/_csharpstandard/standard/variables.md#972-ref-safe-contexts) section of the [C# language specification](~/_csharpstandard/standard/README.md).

For information about the `ref` fields, see the [`ref` fields](../builtin-types/ref-struct.md#ref-fields) section of the [`ref` structure types](../builtin-types/ref-struct.md) article.

## scoped ref

The contextual keyword `scoped` restricts the lifetime of a value. The `scoped` modifier restricts the [*ref-safe-to-escape* or *safe-to-escape* lifetime](../keywords/method-parameters.md#safe-context-of-references-and-values), respectively, to the current method. Effectively, adding the `scoped` modifier asserts that your code won't extend the lifetime of the variable.

You can apply `scoped` to a parameter or local variable. The `scoped` modifier may be applied to parameters and locals when the type is a [`ref struct`](../builtin-types/ref-struct.md). Otherwise, the `scoped` modifier may be applied only to local [reference variables](#reference-variables). That includes local variables declared with the `ref` modifier and parameters declared with the `in`, `ref` or `out` modifiers.

The `scoped` modifier is implicitly added to `this` in methods declared in a `struct`, `out` parameters, and `ref` parameters when the type is a `ref struct`.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharpstandard/standard/README.md):

- [Declaration statements](~/_csharpstandard/standard/statements.md#136-declaration-statements)
- [Reference variables and returns](~/_csharpstandard/standard/variables.md#97-reference-variables-and-returns)

For more information about the `scoped` modifier, see the [Low-level struct improvements](~/_csharplang/proposals/csharp-11.0/low-level-struct-improvements.md) proposal note.

## See also

- [Object and collection initializers](../../programming-guide/classes-and-structs/object-and-collection-initializers.md)
- [ref keyword](../keywords/ref.md)
- [Reduce memory allocations using new C# features](../../advanced-topics/performance/index.md)
- ['var' preferences (style rules IDE0007 and IDE0008)](../../../fundamentals/code-analysis/style-rules/ide0007-ide0008.md)

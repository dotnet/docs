---
title: "Using type dynamic"
description: Learn how to use the dynamic type. The dynamic type is a static type, but dynamic objects bypass static type checking.
ms.date: 02/17/2023
helpviewer_keywords: 
  - "dynamic [C#], about dynamic type"
  - "dynamic type [C#]"
ms.topic: concept-article
---
# Using type dynamic

The `dynamic` type is a static type, but an object of type `dynamic` bypasses static type checking. In most cases, it functions like it has type `object`. The compiler assumes a `dynamic` element supports any operation. Therefore, you don't have to determine whether the object gets its value from a COM API, from a dynamic language such as IronPython, from the HTML Document Object Model (DOM), from reflection, or from somewhere else in the program. However, if the code isn't valid, errors surface at run time.

For example, if instance method `exampleMethod1` in the following code has only one parameter, the compiler recognizes that the first call to the method, `ec.exampleMethod1(10, 4)`, isn't valid because it contains two arguments. The call causes a compiler error. The compiler doesn't check the second call to the method, `dynamic_ec.exampleMethod1(10, 4)`, because the type of `dynamic_ec` is `dynamic`. Therefore, no compiler error is reported. However, the error doesn't escape notice indefinitely. It appears at run time and causes a run-time exception.

:::code language="csharp" source="./snippets/using-dynamic/Program.cs" id="Snippet50":::

:::code language="csharp" source="./snippets/using-dynamic/Program.cs" id="Snippet56":::

The role of the compiler in these examples is to package together information about what each statement is proposing to do to the `dynamic` object or expression. The runtime examines the stored information and any statement that isn't valid causes a run-time exception.

The result of most dynamic operations is itself `dynamic`. For example, if you rest the mouse pointer over the use of `testSum` in the following example, IntelliSense displays the type **(local variable) dynamic testSum**.

:::code language="csharp" source="./snippets/using-dynamic/Program.cs" id="Snippet51":::

Operations in which the result isn't `dynamic` include:

* Conversions from `dynamic` to another type.
* Constructor calls that include arguments of type `dynamic`.

For example, the type of `testInstance` in the following declaration is `ExampleClass`, not `dynamic`:

:::code language="csharp" source="./snippets/using-dynamic/Program.cs" id="Snippet52":::

## Conversions

Conversions between dynamic objects and other types are easy. Conversions enable the developer to switch between dynamic and non-dynamic behavior.

You can convert any to `dynamic` implicitly, as shown in the following examples.

:::code language="csharp" source="./snippets/using-dynamic/Program.cs" id="Snippet53":::

Conversely, you can dynamically apply any implicit conversion to any expression of type `dynamic`.

:::code language="csharp" source="./snippets/using-dynamic/Program.cs" id="Snippet54":::

## Overload resolution with arguments of type dynamic

Overload resolution occurs at run time instead of at compile time if one or more of the arguments in a method call have the type `dynamic`, or if the receiver of the method call is of type `dynamic`. In the following example, if the only accessible `exampleMethod2` method takes a string argument, sending `d1` as the argument doesn't cause a compiler error, but it does cause a run-time exception. Overload resolution fails at run time because the run-time type of `d1` is `int`, and `exampleMethod2` requires a string.

:::code language="csharp" source="./snippets/using-dynamic/Program.cs" id="Snippet55":::

## Dynamic language runtime

The dynamic language runtime (DLR) provides the infrastructure that supports the `dynamic` type in C#, and also the implementation of dynamic programming languages such as IronPython and IronRuby. For more information about the DLR, see [Dynamic Language Runtime Overview](../../../framework/reflection-and-codedom/dynamic-language-runtime-overview.md).

## COM interop

Many COM methods allow for variation in argument types and return type by designating the types as `object`. COM interop necessitates explicit casting of the values to coordinate with strongly typed variables in C#. If you compile by using the [**EmbedInteropTypes** (C# Compiler Options)](../../language-reference/compiler-options/inputs.md#embedinteroptypes) option, the introduction of the `dynamic` type enables you to treat the occurrences of `object` in COM signatures as if they were of type `dynamic`, and thereby to avoid much of the casting. For more information on using the `dynamic` type with COM objects, see the article on [How to access Office interop objects by using C# features](./how-to-access-office-interop-objects.md).

## Related articles

|Title|Description|
|-----------|-----------------|
|[dynamic](../../language-reference/builtin-types/reference-types.md#the-dynamic-type)|Describes the usage of the `dynamic` keyword.|
|[Dynamic Language Runtime Overview](../../../framework/reflection-and-codedom/dynamic-language-runtime-overview.md)|Provides an overview of the DLR, which is a runtime environment that adds a set of services for dynamic languages to the common language runtime (CLR).|
|[Walkthrough: Creating and Using Dynamic Objects](walkthrough-creating-and-using-dynamic-objects.md)|Provides step-by-step instructions for creating a custom dynamic object and for creating a project that accesses an `IronPython` library.|

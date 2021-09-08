---
title: "Using type dynamic - C# Programming Guide"
description: Learn how to use the dynamic type. The dynamic type is a static type, but dynamic objects bypass static type checking.
ms.date: 07/20/2015
helpviewer_keywords: 
  - "dynamic [C#], about dynamic type"
  - "dynamic type [C#]"
ms.assetid: 3828989d-c967-4a51-b948-857ebc8fdf26
---
# Using type dynamic (C# Programming Guide)

C# 4 introduces a new type, `dynamic`. The type is a static type, but an object of type `dynamic` bypasses static type checking. In most cases, it functions like it has type `object`. At compile time, an element that is typed as `dynamic` is assumed to support any operation. Therefore, you do not have to be concerned about whether the object gets its value from a COM API, from a dynamic language such as IronPython, from the HTML Document Object Model (DOM), from reflection, or from somewhere else in the program. However, if the code is not valid, errors are caught at run time.

For example, if instance method `exampleMethod1` in the following code has only one parameter, the compiler recognizes that the first call to the method, `ec.exampleMethod1(10, 4)`, is not valid because it contains two arguments. The call causes a compiler error. The second call to the method, `dynamic_ec.exampleMethod1(10, 4)`, is not checked by the compiler because the type of `dynamic_ec` is `dynamic`. Therefore, no compiler error is reported. However, the error does not escape notice indefinitely. It is caught at run time and causes a run-time exception.

[!code-csharp[CsProgGuideTypes#50](~/samples/snippets/csharp/VS_Snippets_VBCSharp/CsProgGuideTypes/CS/usingdynamic.cs#50)]

[!code-csharp[CsProgGuideTypes#56](~/samples/snippets/csharp/VS_Snippets_VBCSharp/CsProgGuideTypes/CS/usingdynamic.cs#56)]

The role of the compiler in these examples is to package together information about what each statement is proposing to do to the object or expression that is typed as `dynamic`. At run time, the stored information is examined, and any statement that is not valid causes a run-time exception.

The result of most dynamic operations is itself `dynamic`. For example, if you rest the mouse pointer over the use of `testSum` in the following example, IntelliSense displays the type **(local variable) dynamic testSum**.

[!code-csharp[CsProgGuideTypes#51](~/samples/snippets/csharp/VS_Snippets_VBCSharp/CsProgGuideTypes/CS/usingdynamic.cs#51)]

Operations in which the result is not `dynamic` include:

* Conversions from `dynamic` to another type.
* Constructor calls that include arguments of type `dynamic`.

For example, the type of `testInstance` in the following declaration is `ExampleClass`, not `dynamic`:

[!code-csharp[CsProgGuideTypes#52](~/samples/snippets/csharp/VS_Snippets_VBCSharp/CsProgGuideTypes/CS/usingdynamic.cs#52)]

Conversion examples are shown in the following section, "Conversions."

## Conversions

Conversions between dynamic objects and other types are easy. This enables the developer to switch between dynamic and non-dynamic behavior.

Any object can be converted to dynamic type implicitly, as shown in the following examples.

[!code-csharp[CsProgGuideTypes#53](~/samples/snippets/csharp/VS_Snippets_VBCSharp/CsProgGuideTypes/CS/usingdynamic.cs#53)]

Conversely, an implicit conversion can be dynamically applied to any expression of type `dynamic`.

[!code-csharp[CsProgGuideTypes#54](~/samples/snippets/csharp/VS_Snippets_VBCSharp/CsProgGuideTypes/CS/usingdynamic.cs#54)]

## Overload resolution with arguments of type dynamic

Overload resolution occurs at run time instead of at compile time if one or more of the arguments in a method call have the type `dynamic`, or if the receiver of the method call is of type `dynamic`. In the following example, if the only accessible `exampleMethod2` method is defined to take a string argument, sending `d1` as the argument does not cause a compiler error, but it does cause a run-time exception. Overload resolution fails at run time because the run-time type of `d1` is `int`, and `exampleMethod2` requires a string.

[!code-csharp[CsProgGuideTypes#55](~/samples/snippets/csharp/VS_Snippets_VBCSharp/CsProgGuideTypes/CS/usingdynamic.cs#55)]

## Dynamic language runtime

The dynamic language runtime (DLR) is an API that was introduced in .NET Framework 4. It provides the infrastructure that supports the `dynamic` type in C#, and also the implementation of dynamic programming languages such as IronPython and IronRuby. For more information about the DLR, see [Dynamic Language Runtime Overview](../../../framework/reflection-and-codedom/dynamic-language-runtime-overview.md).

## COM interop

C# 4 includes several features that improve the experience of interoperating with COM APIs such as the Office Automation APIs. Among the improvements are the use of the `dynamic` type, and of [named and optional arguments](../classes-and-structs/named-and-optional-arguments.md).

Many COM methods allow for variation in argument types and return type by designating the types as `object`. This has necessitated explicit casting of the values to coordinate with strongly typed variables in C#. If you compile by using the [**EmbedInteropTypes** (C# Compiler Options)](../../language-reference/compiler-options/inputs.md#embedinteroptypes) option, the introduction of the `dynamic` type enables you to treat the occurrences of `object` in COM signatures as if they were of type `dynamic`, and thereby to avoid much of the casting. For example, the following statements contrast how you access a cell in a Microsoft Office Excel spreadsheet with the `dynamic` type and without the `dynamic` type.

[!code-csharp[csOfficeWalkthrough#12](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csofficewalkthrough/cs/thisaddin.cs#12)]

[!code-csharp[csOfficeWalkthrough#13](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csofficewalkthrough/cs/thisaddin.cs#13)]

## Related topics

|Title|Description|
|-----------|-----------------|
|[dynamic](../../language-reference/builtin-types/reference-types.md)|Describes the usage of the `dynamic` keyword.|
|[Dynamic Language Runtime Overview](../../../framework/reflection-and-codedom/dynamic-language-runtime-overview.md)|Provides an overview of the DLR, which is a runtime environment that adds a set of services for dynamic languages to the common language runtime (CLR).|
|[Walkthrough: Creating and Using Dynamic Objects](walkthrough-creating-and-using-dynamic-objects.md)|Provides step-by-step instructions for creating a custom dynamic object and for creating a project that accesses an `IronPython` library.|
|[How to access Office interop objects by using C# features](../interop/how-to-access-office-onterop-objects.md)|Demonstrates how to create a project that uses named and optional arguments, the `dynamic` type, and other enhancements that simplify access to Office API objects.|

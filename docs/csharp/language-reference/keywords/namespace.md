---
description: "namespace keyword - C# Reference"
title: "namespace keyword - C# Reference"
ms.date: 08/19/2021
f1_keywords: 
  - "namespace_CSharpKeyword"
  - "namespace"
helpviewer_keywords: 
  - "namespace keyword [C#]"
  - "scope [C#]"
ms.assetid: 0a788423-9110-42e0-97d9-bda41ca4870f
---
# namespace

The `namespace` keyword is used to declare a scope that contains a set of related objects. You can use a namespace to organize code elements and to create globally unique types.

:::code language="csharp" source="snippets/csrefKeywordsNamespace.cs" id="Snippet1":::

*File scoped namespace declarations* enable you to declare that all types in a file are in a single namespace. File scoped namespace declarations are available with C# 10. The following example is similar to the previous example, but uses a file scoped namespace declaration:

:::code language="csharp" source="snippets/filescopednamespace.cs" :::

The preceding example doesn't include a nested namespace. File scoped namespaces can't include additional namespace declarations. You cannot declare a nested namespace or a second file-scoped namespace:

```csharp
namespace SampleNamespace;

class AnotherSampleClass
{
    public void AnotherSampleMethod()
    {
        System.Console.WriteLine(
            "SampleMethod inside SampleNamespace");
    }
}

namespace AnotherNamespace; // Not allowed!

namespace ANestedNamespace // Not allowed!
{
   // declarations...
}
```

Within a namespace, you can declare zero or more of the following types:

- [class](class.md)
- [interface](interface.md)
- [struct](../builtin-types/struct.md)
- [enum](../builtin-types/enum.md)
- [delegate](../builtin-types/reference-types.md#the-delegate-type)
- nested namespaces can be declared except in file scoped namespace declarations

The compiler adds a default namespace. This unnamed namespace, sometimes referred to as the global namespace, is present in every file. It contains declarations not included in a declared namespace. Any identifier in the global namespace is available for use in a named namespace.

Namespaces implicitly have public access. For a discussion of the access modifiers you can assign to elements in a namespace, see [Access Modifiers](access-modifiers.md).

It's possible to define a namespace in two or more declarations. For example, the following example defines two classes as part of the `MyCompany` namespace:

:::code language="csharp" source="snippets/csrefKeywordsNamespace.cs" id="Snippet2":::

The following example shows how to call a static method in a nested namespace.

:::code language="csharp" source="snippets/csrefKeywordsNamespace.cs" id="Snippet3":::

## C# language specification

For more information, see the [Namespaces](~/_csharpstandard/standard/namespaces.md) section of the [C# language specification](~/_csharpstandard/standard/README.md).
For more information on file scoped namespace declarations, see the [feature specification](~/_csharplang/proposals/csharp-10.0/file-scoped-namespaces.md).

## See also

- [C# reference](../index.md)
- [C# keywords](index.md)
- [using](using-directive.md)
- [using static](using-directive.md)
- [Namespace alias qualifier `::`](../operators/namespace-alias-qualifier.md)
- [Namespaces](../../fundamentals/types/namespaces.md)

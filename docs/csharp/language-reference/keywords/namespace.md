---
description: "Organize related types and functionality using the namespace keyword - C# Reference"
title: "The namespace keyword"
ms.date: 11/22/2024
f1_keywords: 
  - "namespace_CSharpKeyword"
  - "namespace"
helpviewer_keywords: 
  - "namespace keyword [C#]"
  - "scope [C#]"
---
# The `namespace` keyword

The `namespace` keyword is used to declare a scope that contains a set of related objects. You can use a namespace to organize code elements and to create globally unique types.

:::code language="csharp" source="snippets/csrefKeywordsNamespace.cs" id="Snippet1":::

*File scoped namespace declarations* enable you to declare that all types in a file are in a single namespace. The following example is similar to the previous example, but uses a file scoped namespace declaration:

:::code language="csharp" source="snippets/filescopednamespace.cs" :::

## Using Statements in File Scoped Namespaces

When you use *file-scoped namespaces*, the placement of `using` statements affects their scope within the file. File-scoped namespaces lower to the equivalent traditional namespace declaration that ends with a closing bracket at the end of the file. This behavior determines where `using` directives are applied as follows:

- If the `using` statements are placed before the file-scoped namespace declaration, they're treated as being outside of the namespace and are interpreted as fully qualified namespaces.
- If the `using` statements are placed after the file-scoped namespace declaration, they're scoped within the namespace itself.

For example:

```csharp
// This using is outside the namespace scope, so it applies globally
using System;

namespace SampleNamespace; // File-scoped namespace declaration

// This using is inside the namespace scope
using System.Text;

public class SampleClass
{
    // Class members...
}
```

In the preceding example, `System` is globally accessible, while `System.Text` applies only within `SampleNamespace`.

The preceding example doesn't include a nested namespace. File scoped namespaces can't include more namespace declarations. You can't declare a nested namespace or a second file-scoped namespace:

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

- [Namespace declaration preferences (IDE0160 and IDE0161)](../../../fundamentals/code-analysis/style-rules/ide0160-ide0161.md)
- [C# keywords](index.md)
- [using](using-directive.md)
- [using static](using-directive.md)
- [Namespace alias qualifier `::`](../operators/namespace-alias-qualifier.md)
- [Namespaces](../../fundamentals/types/namespaces.md)

---
title: "using directive - C# Reference"
ms.custom: seodec18
ms.date: 07/20/2015
helpviewer_keywords:
  - "using directive [C#]"
ms.assetid: b42b8e61-5e7e-439c-bb71-370094b44ae8
---
# using directive (C# Reference)

The `using` directive has three uses:

- To allow the use of types in a namespace so that you do not have to qualify the use of a type in that namespace:

    ```csharp
    using System.Text;
    ```

- To allow you to access static members and nested types of a type without having to qualify the access with the type name.

    ```csharp
    using static System.Math;
    ```

    For more information, see the [using static directive](using-static.md).

- To create an alias for a namespace or a type. This is called a *using alias directive*.

    ```csharp
    using Project = PC.MyCompany.Project;
    ```

The `using` keyword is also used to create *using statements*, which help ensure that <xref:System.IDisposable> objects such as files and fonts are handled correctly. See [using Statement](using-statement.md) for more information.

## Using static type

You can access static members of a type without having to qualify the access with the type name:

```csharp
using static System.Console;
using static System.Math;
class Program
{
    static void Main()
    {
        WriteLine(Sqrt(3*3 + 4*4));
    }
}
```

## Remarks

The scope of a `using` directive is limited to the file in which it appears.

The `using` directive can appear:

- At the beginning of a source code file, before any namespace or type definitions.
- In any namespace, but before any namespace or types declared in this namespace.

Otherwise, compiler error [CS1529](../../misc/cs1529.md) is generated.

Create a `using` alias directive to make it easier to qualify an identifier to a namespace or type. In any `using` directive, the fully-qualified namespace or type must be used regardless of the `using` directives that come before it. No `using` alias can be used in the declaration of a `using` directive. For example, the following generates a compiler error:

```csharp
using s = System.Text;
using s.RegularExpressions;
```

Create a `using` directive to use the types in a namespace without having to specify the namespace. A `using` directive does not give you access to any namespaces that are nested in the namespace you specify.

Namespaces come in two categories: user-defined and system-defined. User-defined namespaces are namespaces defined in your code. For a list of the system-defined namespaces, see [.NET API Browser](https://docs.microsoft.com/dotnet/api/).

For examples on referencing methods in other assemblies, see [Create and Use Assemblies Using the Command Line](../../programming-guide/concepts/assemblies-gac/how-to-create-and-use-assemblies-using-the-command-line.md).

## Example 1

The following example shows how to define and use a `using` alias for a namespace:

[!code-csharp[csrefKeywordsNamespace#8](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsNamespace/CS/csrefKeywordsNamespace2.cs#8)]

A using alias directive cannot have an open generic type on the right hand side. For example, you cannot create a using alias for a `List<T>`, but you can create one for a `List<int>`.

## Example 2

The following example shows how to define a `using` directive and a `using` alias for a class:

[!code-csharp[csrefKeywordsNamespace#9](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsNamespace/CS/csrefKeywordsNamespace2.cs#9)]

## C# language specification

For more information, see [Using directives](~/_csharplang/spec/namespaces.md#using-directives) in the [C# Language Specification](../language-specification/index.md). The language specification is the definitive source for C# syntax and usage.

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [Using Namespaces](../../programming-guide/namespaces/using-namespaces.md)
- [C# Keywords](index.md)
- [Namespace Keywords](namespace-keywords.md)
- [Namespaces](../../programming-guide/namespaces/index.md)
- [using Statement](using-statement.md)

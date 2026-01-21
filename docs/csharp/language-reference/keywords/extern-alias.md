---
description: "extern alias - C# Reference"
title: "extern alias"
ms.date: 01/21/2026
f1_keywords: 
  - "alias_CSharpKeyword"
helpviewer_keywords: 
  - "extern alias keyword [C#]"
  - "aliases [C#], extern keyword"
  - "aliases, extern keyword"
---
# extern alias (C# Reference)

You might need to reference two versions of assemblies that have the same fully qualified type names. For example, you might need to use two or more versions of an assembly in the same application. By using an external assembly alias, you can wrap the namespaces from each assembly inside root-level namespaces named by the alias. This approach enables you to use both versions in the same file.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

> [!NOTE]
> The [extern](./extern.md) keyword is also used as a method modifier, declaring a method written in unmanaged code.

To reference two assemblies with the same fully qualified type names, specify an alias in your *.csproj* file, and add the following code:

```xml
<Reference Include="grid.dll"> 
    <Aliases>GridV1</Aliases>
</Reference>
<Reference Include="grid20.dll">
    <Aliases>GridV2</Aliases>
</Reference>
```

You can learn more in the article on the [CSC task](~/visualstudio/msbuild/csc-task) in the Visual Studio documentation.

This command creates the external aliases `GridV1` and `GridV2`. To use these aliases from within a program, reference them by using the `extern` keyword. For example:
  
`extern alias GridV1;`
`extern alias GridV2;`

Each extern alias declaration introduces an additional root-level namespace that parallels (but doesn't lie within) the global namespace. You can refer to types from each assembly without ambiguity by using their fully qualified name, rooted in the appropriate namespace-alias.

In the previous example, `GridV1::Grid` is the grid control from `grid.dll`, and `GridV2::Grid` is the grid control from `grid20.dll`.

## Using Visual Studio

If you're using Visual Studio, you can provide aliases in a similar way.

Add references to *grid.dll* and *grid20.dll* to your project in Visual Studio. Open the property tab and change the **Aliases** from `global` to `GridV1` and `GridV2` respectively.

Use these aliases the same way as described earlier.

```csharp
extern alias GridV1;  
extern alias GridV2;  
```

Now you can create an alias for a namespace or a type by using the *using alias directive*. For more information, see [using directive](using-directive.md).

```csharp
using Class1V1 = GridV1::Namespace.Class1;
using Class1V2 = GridV2::Namespace.Class1;
```

## C# Language Specification  

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See also

- [C# Keywords](./index.md)
- [:: Operator](../operators/namespace-alias-qualifier.md)
- [**References** (C# Compiler Options)](../compiler-options/inputs.md#references)

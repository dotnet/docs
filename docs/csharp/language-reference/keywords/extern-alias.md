---
description: "extern alias - C# Reference"
title: "extern alias - C# Reference"
ms.date: 07/20/2015
f1_keywords: 
  - "alias_CSharpKeyword"
helpviewer_keywords: 
  - "extern alias keyword [C#]"
  - "aliases [C#], extern keyword"
  - "aliases, extern keyword"
ms.assetid: f487bf4f-c943-4fca-851b-e540c83d9027
---
# extern alias (C# Reference)

You might have to reference two versions of assemblies that have the same fully-qualified type names. For example, you might have to use two or more versions of an assembly in the same application. By using an external assembly alias, the namespaces from each assembly can be wrapped inside root-level namespaces named by the alias, which enables them to be used in the same file.  
  
> [!NOTE]
> The [extern](./extern.md) keyword is also used as a method modifier, declaring a method written in unmanaged code.  
  
 To reference two assemblies with the same fully-qualified type names, an alias must be specified at a command prompt, as follows:  
  
 `/r:GridV1=grid.dll`  
  
 `/r:GridV2=grid20.dll`  
  
 This creates the external aliases `GridV1` and `GridV2`. To use these aliases from within a program, reference them by using the `extern` keyword. For example:  
  
 `extern alias GridV1;`  
  
 `extern alias GridV2;`  
  
 Each extern alias declaration introduces an additional root-level namespace that parallels (but does not lie within) the global namespace. Thus types from each assembly can be referred to without ambiguity by using their fully qualified name, rooted in the appropriate namespace-alias.  
  
 In the previous example, `GridV1::Grid` would be the grid control from `grid.dll`, and `GridV2::Grid` would be the grid control from `grid20.dll`.  
  
## Using Visual Studio

If you are using Visual Studio, aliases can be provided in similar way.

Add reference of *grid.dll* and *grid20.dll* to your project in Visual Studio. Open a property tab and change the Aliases from global to GridV1 and GridV2 respectively.

Use these aliases the same way above

```csharp
 extern alias GridV1;  
  
 extern alias GridV2;  
```

Now you can create alias for a namespace or a type by *using alias directive*. For more information, see [using directive](using-directive.md).

```csharp
using Class1V1 = GridV1::Namespace.Class1;

using Class1V2 = GridV2::Namespace.Class1;
```

## C# Language Specification  

 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](./index.md)
- [:: Operator](../operators/namespace-alias-qualifier.md)
- [**References** (C# Compiler Options)](../compiler-options/inputs.md#references)

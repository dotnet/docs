---
description: "-nullable (C# Compiler Options)"
title: "-nullable (C# Compiler Options)"
author: IEvangelist
ms.author: dapine
ms.date: 06/04/2020
f1_keywords:
  - "/nullable"
helpviewer_keywords:
  - "nullable compiler option [C#]"
  - "/nullable compiler option [C#]"
  - "-nullable compiler option [C#]"
---

# -nullable (C# Compiler Options)

The **-nullable** option lets you specify the desired nullable context.

## Syntax

```console
-nullable[+ | -]
-nullable:{enable | disable | warnings | annotations}
```

## Arguments

`+` &#124; `-`  
Specifying `+`, or just **-nullable**, causes the compiler to enable nullable context. Specifying `-`, which is in effect if you do not specify **-nullable**, disables nullable context.

`enable` &#124; `disable` &#124; `warnings` &#124; `annotations`  
Specifies the nullable context option. Similar to `+` or `-`, to enable and disable, but allows for more granularity of nullable context specificity. The `enable` argument, which is in effect the same as if you specify **-nullable**, enables the nullable context. Specifying `disable` will disable nullable context. When providing the `warnings` argument, **-nullable:warnings**, the nullable warning context is enabled. When specifying the `annotations` argument, **-nullable:annotations**, the nullable annotation context is enabled.

## Remarks

Flow analysis is used to infer the nullability of variables within executable code. The inferred nullability of a variable is independent of the variable's declared nullability. Method calls are analyzed even when they are conditionally omitted. For instance, <xref:System.Diagnostics.Debug.Assert%2A?displayProperty=nameWithType> in release mode.

Invocation of methods annotated with the following attributes will also affect flow analysis:

- Simple pre-conditions: <xref:System.Diagnostics.CodeAnalysis.AllowNullAttribute> and <xref:System.Diagnostics.CodeAnalysis.DisallowNullAttribute>
- Simple post-conditions: <xref:System.Diagnostics.CodeAnalysis.MaybeNullAttribute> and <xref:System.Diagnostics.CodeAnalysis.NotNullAttribute>
- Conditional post-conditions: <xref:System.Diagnostics.CodeAnalysis.MaybeNullWhenAttribute> and <xref:System.Diagnostics.CodeAnalysis.NotNullWhenAttribute>
- <xref:System.Diagnostics.CodeAnalysis.DoesNotReturnIfAttribute> (for example, `DoesNotReturnIf(false)` for <xref:System.Diagnostics.Debug.Assert%2A?displayProperty=nameWithType>) and <xref:System.Diagnostics.CodeAnalysis.DoesNotReturnAttribute>
- <xref:System.Diagnostics.CodeAnalysis.NotNullIfNotNullAttribute>
- Member post-conditions: <xref:System.Diagnostics.CodeAnalysis.MemberNotNullAttribute.%23ctor(System.String)> and <xref:System.Diagnostics.CodeAnalysis.MemberNotNullAttribute.%23ctor(System.String[])>

### To set this compiler option in a project

Edit the *.csproj* file to add the `<Nullable>` tag within a `Project/PropertyGroup` hierarchy:

```xml
<Project Sdk="...">

  <PropertyGroup>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

## See also

- [C# Compiler Options](./index.md)
- [Nullable reference types](../../nullable-references.md)

---
title: "Breaking change: CA1831: Use AsSpan instead of Range-based indexers for string"
description: Learn about the breaking change in .NET 5 caused by the enablement of code analysis rule CA1831.
ms.date: 08/21/2020
---
# Warning CA1831: Use AsSpan instead of Range-based indexers for string

.NET code analyzer rule [CA1831](/visualstudio/code-quality/ca1831) is enabled, by default, starting in .NET 5. It produces a build warning for any code where a <xref:System.Range>-based indexer is used on a string, but no copy was intended.

## Change description

Starting in .NET 5, the .NET SDK includes [.NET source code analyzers](../../../../fundamentals/code-analysis/overview.md). Several of these rules are enabled, by default, including [CA1831](/visualstudio/code-quality/ca1831). If your project contains code that violates this rule and is configured to treat warnings as errors, this change could break your build.

Rule CA1831 finds instances where a <xref:System.Range>-based indexer is used on a string, but no copy was intended. If the <xref:System.Range>-based indexer is used directly on a string to produce an implicit cast, then an unnecessary copy of the requested portion of the string is created. For example:

```csharp
ReadOnlySpan<char> slice = str[1..3];
```

CA1831 suggests using the <xref:System.Range>-based indexer on a *span* of the string, instead. For example:

```csharp
ReadOnlySpan<char> slice = str.AsSpan()[1..3];
```

## Version introduced

5.0

## Recommended action

- To correct your code and avoid unnecessary allocations, call <xref:System.MemoryExtensions.AsSpan(System.String)> or <xref:System.MemoryExtensions.AsMemory(System.String)> before using the <xref:System.Range>-based indexer. For example:

  ```csharp
  ReadOnlySpan<char> slice = str.AsSpan()[1..3];
  ```

- If you don't want to change your code, you can disable the rule by setting its severity to `suggestion` or `none`. For more information, see [Configure code analysis rules](../../../../fundamentals/code-analysis/configuration-options.md).

- To disable code analysis completely, set `EnableNETAnalyzers` to `false` in your project file. For more information, see [EnableNETAnalyzers](../../../project-sdk/msbuild-props.md#enablenetanalyzers).

## Affected APIs

- <xref:System.Range?displayProperty=fullName>

<!--

### Affected APIs

- `T:System.Range`

### Category

Code analysis

-->

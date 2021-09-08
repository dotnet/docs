---
title: "Breaking change: NETCOREAPP3_1 preprocessor symbol is not defined when targeting .NET 5"
description: Learn about the breaking change in .NET 5 where projects no longer define preprocessor symbols for earlier versions.
ms.date: 09/17/2020
---
# NETCOREAPP3_1 preprocessor symbol is not defined when targeting .NET 5

In .NET 5 RC2 and later versions, projects no longer define preprocessor symbols for earlier versions, but only for the version that they target. This is the same behavior as .NET Core 1.0 - 3.1.

## Version introduced

5.0 RC2

## Change description

In .NET 5 preview 7 through RC1, projects that target `net5.0` define both `NETCOREAPP3_1` and `NET5_0` preprocessor symbols. The intent behind this behavior change was that starting with .NET 5, conditional compilation [symbols would be cumulative](https://github.com/dotnet/designs/blob/main/accepted/2020/net5/net5.md#preprocessor-symbols).

In .NET 5 RC2 and later, projects only define symbols for the target framework monikers (TFM) that it targets and not for any earlier versions.

## Reason for change

The change from preview 7 was reverted due to customer feedback. Defining symbols for earlier versions surprised and confused customers, and some assumed it was a bug in the C# compiler.

## Recommended action

Make sure that your `#if` logic doesn't assume that `NETCOREAPP3_1` is defined when the project targets `net5.0` or higher. Instead, assume that `NETCOREAPP3_1` is only defined when the project explicitly targets `netcoreapp3.1`.

For example, if your project multitargets for .NET Core 2.1 and .NET Core 3.1 and you call APIs that were introduced in .NET Core 3.1, your `#if` logic should look as follows:

```csharp
#if NETCOREAPP2_1 || NETCOREAPP3_0
    // Fallback behavior for old versions.
#elif NETCOREAPP
    // Behavior for .NET Core 3.1 and later.
#endif
```

## Affected APIs

N/A

<!--

### Affected APIs

Not detectable via API analysis.

### Category

MSBuild

-->

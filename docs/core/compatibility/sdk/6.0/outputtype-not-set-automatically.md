---
title: "Breaking change: `OutputType` no longer automatically set to WinExe"
description: Learn about the breaking change in .NET 6 where `OutputType` for WPF and Windows Forms projects is no longer automatically set to `WinExe`.
ms.date: 08/17/2021
---
# OutputType not changed from Exe to WinExe for Windows Forms and WPF projects

In .NET 5, a change was made to automatically change `OutputType` from `Exe` to `WinExe` for WPF and Windows Forms apps. In .NET 6, we are reverting that change and `OutputType` will no longer be changed by the SDK.

## Version introduced

.NET 6 RC 1

## Previous behavior

If a project targeted .NET 5 or higher, `OutputType` was set to `Exe`, and `UseWindowsForms` or `UseWPF` was set to `true`, then the .NET SDK would change `OutputType` to `WinExe`.

## New behavior

`OutputType` is no longer changed from what's in the project file.

```xml
<PropertyGroup>
  <OutputType>Exe</OutputType>
</PropertyGroup>
```

## Change category

This change may affect [*source compatibility*](../../categories.md#source-compatibility).

## Reason for change

The [.NET 5 change](../5.0/automatically-infer-winexe-output-type.md) was intended to simplify .NET MAUI apps, so that `OutputType` wouldn't need to be conditioned on the target framework. However:

- Automatically inferring `OutputType` broke user expectations and frustrated developers. For more information, see [dotnet/sdk#16563](https://github.com/dotnet/sdk/issues/16563) and its linked issues.
- .NET MAUI apps will use WinUI by default, not Windows Forms or WPF, so the automatic inference doesn't even apply to .NET MAUI apps.

## Recommended action

If you relied on the fact that `OutputType` was changed from `Exe` to `WinExe`, you should explicitly set it to `WinExe` in the project file.

If you were impacted by the previous breaking change and had to set `DisableWinExeOutputInference` in order to disable the logic that was added in .NET 5, you can remove that property now.

## Affected APIs

N/A

## See also

- [OutputType set to WinExe for WPF and WinForms apps](../5.0/automatically-infer-winexe-output-type.md)

---
title: "Breaking change: Architecture option doesn't imply self-contained"
description: Learn about a breaking change in the .NET 8 SDK where the `--arch` option no longer implies that an app is self-contained.
ms.date: 10/05/2023
---
# --arch option doesn't imply self-contained

Up until now, the `--arch` option for `dotnet` CLI commands such as [dotnet publish](../../../tools/dotnet-publish.md) implied that the app was [self-contained](../../../deploying/index.md#publish-self-contained). The behavior of the `--arch` option has now been changed to match that of the `--runtime` option, and it no longer implies that an app is self-contained.

## Previous behavior

`--arch` implied `--self-contained`.

## New behavior

`--arch` doesn't imply anything about `--self-contained`.

## Version introduced

.NET 8 RC 2

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was made to unify the behavior of `--arch` with that of `--runtime`, which it's an alias for. The [behavior for `--runtime` was changed](runtimespecific-app-default.md) in an earlier preview version of .NET 8.

## Recommended action

If your application needs to be self contained, set `--self-contained` on your CLI calls, or set MSBuild properties such as `<SelfContained>true</SelfContained>` or `<PublishSelfContained>true</PublishSelfContained>`.

## See also

- [Runtime-specific apps no longer self-contained](runtimespecific-app-default.md)

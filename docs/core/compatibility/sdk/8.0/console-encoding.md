---
title: "Breaking change: CLI console output uses UTF-8"
description: Learn about a breaking change in the .NET 8 SDK where the encoding for console input and output is now UTF-8.
ms.date: 03/03/2023
---
# CLI console output uses UTF-8

If the [`DOTNET_CLI_UI_LANGUAGE`](../../../tools/dotnet-environment-variables.md#dotnet_cli_ui_language) or `VSLANG` environment variable is set, the .NET CLI console output and input encoding changes to UTF-8, so that the code page can change to UTF-8 as well. This new behavior allows characters from languages set by those environment variables to be rendered correctly.

This change only affects Windows operating systems (the encoding was okay on other platforms). Moreover, it only applies to Windows 10 and later versions where the UI culture set by the user is non-English.

## Previous behavior

Characters in certain languages, including Chinese, German, Japanese, and Russian, would sometimes display as garbled characters or as `?` in the console. For example:

```console
C:\>dotnet build
MSBuild version 17.3.0-preview[...] for .NET
  ???????????????...
```

## New behavior

Starting in .NET 7 (version 7.0.3xx) and .NET 8, characters render correctly. Both the encoding and the code page change. For example:

```console
C:\>dotnet build
MSBuild version 17.3.0-preview[...] for .NET
  正在确定要还原的项目…
```

Versions of Windows older than Windows 10 1909 don't fully support UTF-8 and may experience issues after this change.

In addition, there's [an existing bug](https://github.com/dotnet/sdk/issues/30170) where the SDK can affect the encoding of other commands and programs called in the same command prompt after the SDK has finished execution. Now that the SDK more frequently changes the encoding, the impact of this bug may increase.

## Version introduced

7.0.3xx
.NET 8 Preview 1

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility) and [binary compatibility](../../categories.md#binary-compatibility). It's also a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Using the .NET CLI in non-English languages provided a poor experience.

Developers that weren't already using the `VSLANG` and `DOTNET_CLI_UI_LANGUAGE` variables aren't impacted. The impact should be minimal, as this language setting wouldn't have worked well in the first place due to garbled characters. Also, only developers using Windows 10 or later might be impacted, most of which are likely using version 1909 or later.

The legacy scenarios are already less likely to support the broken languages, so it's unlikely you'd want to use another language that might expose this break anyway.

## Recommended action

- If you're using an older version of windows 10, upgrade to version 1909 or later.
- If you want to use a legacy console or are facing build issues or others due to the encoding change, unset `VSLANG` and `DOTNET_CLI_UI_LANGUAGE` to disable this change.

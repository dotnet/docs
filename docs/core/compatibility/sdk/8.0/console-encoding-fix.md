---
title: "Breaking change: SDK no longer changes console encoding after completion"
description: Learn about a breaking change where the .NET 8 SDK no longer changes the console encoding after running a command.
ms.date: 04/04/2023
---
# Console encoding doesn't remain UTF-8 after completion

The bug mentioned in the [CLI console output uses UTF-8](console-encoding.md) breaking change, where the .NET SDK changed the encoding of the entire console, has been fixed. The console encoding no longer remains UTF-8 after the .NET SDK executes a command. It's possible that users came to rely on that behavior, hence this is a breaking change.

In addition, the .NET SDK no longer changes the encoding to UTF-8 on older Windows 10 versions that don't fully support it.

## Previous behavior

- The SDK changed the encoding of a terminal after running a command such as `dotnet build`.
- The SDK used the UTF-8 encoding to correctly render non-English characters, even on versions of windows 10 that did not officially support UTF-8. The behavior was undefined on those versions.

## New behavior

- The SDK doesn't change the terminal encoding after exit for other programs.
- By default, the SDK no longer uses UTF-8 for Windows versions that don't support it.

## Version introduced

7.0.3xx
.NET 8 Preview 3

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility). It's also a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

There was an existing bug where the .NET SDK affected the encoding on the console for other programs. That was a bug that was fixed, resulting in this breaking change.

Older versions of Windows 10 (that is, versions before the November 2019 update) didn't support UTF-8, so the default behavior shouldn't be to use UTF-8 encoding. Instead, an opt-in is now available.

## Recommended action

If your app needs to change the code page on Windows, it can run a process to invoke the `chcp` command. Your app shouldn't rely on the .NET SDK to change the encoding.

For older Windows 10 versions that don't officially support UTF-8 where you want the .NET SDK to continue to change the encoding to UTF-8 for non-English languages, can you set the environment variable [`DOTNET_CLI_FORCE_UTF8_ENCODING`](../../../tools/dotnet-environment-variables.md#dotnet_cli_force_utf8_encoding) to `true` or 1.

## See also

- [SDK no longer changes console encoding after completion](console-encoding-fix.md)

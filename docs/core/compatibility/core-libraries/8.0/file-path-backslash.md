---
title: ".NET 8 breaking change: Backslash mapping in Unix file paths"
description: Learn about the .NET 8 breaking change in core .NET libraries where the CoreCLR native runtime no longer maps backslashes to forward slashes in file paths on Unix.
ms.date: 01/30/2023
ms.topic: article
---
# Backslash mapping in Unix file paths

Backslash (`\`) characters are valid in directory and file names on Unix. Starting in .NET 8, the native CoreCLR runtime no longer converts `\` characters to directory separators&mdash;forward slashes (`/`)&mdash;on Unix. This change enables .NET applications to be located on paths with names that contain backslash characters. It also allows the native runtime, `dotnet` host, and the `ilasm` and `ildasm` tools to access files on paths that contain backslash characters.

## Previous behavior

The native CoreCLR runtime automatically converted backslash (`\`) characters in file paths to forward slashes (`/`) on Unix.

## New behavior

The native CoreCLR runtime doesn't convert any file path characters on Unix.

## Version introduced

.NET 8 Preview 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Without this change, .NET apps located in directories that contain backslash characters fail to start.

## Recommended action

- Use <xref:System.IO.Path.DirectorySeparatorChar?displayProperty=nameWithType> as a directory separator in your app instead of hardcoding it to `\` or `/`.
- Use `/` as a directory separator on Unix in file paths that you pass to the `dotnet` host, hosting APIs, and `ilasm` and `ildasm` tools.
- Use `/` as a directory separator on Unix in file paths in various `DOTNET_xxx` [environment variables](../../../tools/dotnet-environment-variables.md).

## Affected APIs

- Hosting APIs
- <xref:System.Runtime.InteropServices.DllImportAttribute.Value?displayProperty=fullName>
- <xref:System.Runtime.InteropServices.NativeLibrary.Load%2A?displayProperty=fullName>
- <xref:System.Runtime.InteropServices.NativeLibrary.TryLoad%2A?displayProperty=fullName>
- <xref:System.Reflection.Assembly.LoadFrom%2A?displayProperty=fullName>
- <xref:System.Reflection.Assembly.LoadFile%2A?displayProperty=fullName>
- <xref:System.Reflection.Assembly.UnsafeLoadFrom(System.String)?displayProperty=fullName>
- <xref:System.Runtime.Loader.AssemblyLoadContext.LoadFromAssemblyPath(System.String)?displayProperty=fullName>
- <xref:System.Runtime.Loader.AssemblyLoadContext.LoadFromNativeImagePath(System.String,System.String)?displayProperty=fullName>
- <xref:System.Runtime.Loader.AssemblyLoadContext.LoadUnmanagedDllFromPath(System.String)?displayProperty=fullName>

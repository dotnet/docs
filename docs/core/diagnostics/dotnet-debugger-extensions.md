---
title: dotnet-debugger-extensions diagnostic tool - .NET CLI
description: Learn how to install and use the dotnet-debugger-extensions CLI tool to manage the .NET debugging extensions, which is used with native debuggers on Windows and Linux.
ms.date: 11/17/2020
ms.topic: reference
ms.custom: linux-related-content
---
# .NET debugger extensions installer (dotnet-debugger-extensions)

**This article applies to:** ✔️ .NET 6.0 SDK and later versions

## Install

To install the latest release version of the `dotnet-debugger-extensions` [NuGet package](https://www.nuget.org/packages/dotnet-debugger-extensions), use the [dotnet tool install](../tools/dotnet-tool-install.md) command:

  ```dotnetcli
  dotnet tool install --global dotnet-debugger-extensions
  ```

## Synopsis

```console
dotnet-debugger-extensions [-h|--help] [options] [command]]
```

## Description

The `dotnet-debugger-extensions` global tool installs the [.NET debugger extensions](debugger-extensions.md), which enable better debugging experience in native debuggers like WinDbg and LLDB.

> [!NOTE]
> The Windows Debugger (>= version 10.0.18317.1001 of WinDbg or cdb) automatically loads the extensions from the Microsoft extension gallery.

## Options

- **`--version`**

  Displays version information.

- **`-h|--help`**

  Shows command-line help.

## dotnet-debugger-extensions install

Installs the [.NET debugger extensions](debugger-extensions.md) locally for debugging .NET Core processes. On macOS and Linux, the *.lldbinit* file is updated so that the extension automatically loads at LLDB startup. If you're installing on Windows with older debugging tools (before version 10.0.18317.1001), you need to manually load the extension in WinDbg or cdb by running `.load %USERPROFILE%\.dotnet\sos\sos.dll` in the debugger.

This overwrites any previous installations from the dotnet-debugger-extensions or dotnet-sos installers.

### Synopsis

```console
dotnet-debugger-extensions install [--architecture <arch>]
```

### Options

- **`--architecture <arch>`**

  Specifies the processor architecture of the extension binaries to install. By default, `dotnet-debugger-extensions` installs the architecture of the host machine. Use this option when you want to install for an architecture that's different from the dotnet host architecture. For example, if you're running Arm32 binaries from an Arm64 host, you need to install with `dotnet-debugger-extensions install --architecture Arm`.

  The following architectures are available:

  - `Arm`
  - `Arm64`
  - `X86`
  - `X64`

- **`--accept-license-agreement`**
  
  This option accepts and agrees to the licensing agreement without manual keyboard interaction. For use when console input is redirected.

## dotnet-debugger-extensions uninstall

Uninstalls the [.NET debugger extensions](debugger-extensions.md) and, on Linux and macOS, removes it from LLDB configuration.

### Synopsis

```console
dotnet-debugger-extensions uninstall
```

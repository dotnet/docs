---
title: dotnet-sos diagnostic tool - .NET CLI
description: Learn how to install and use the dotnet-sos CLI tool to manage the SOS debugger extension, which is used with native debuggers on Windows and Linux. 
ms.date: 11/17/2020
ms.topic: reference
---
# SOS installer (dotnet-sos)

**This article applies to:** ✔️ .NET Core 2.1 SDK and later versions

## Install

There are two ways to download and install `dotnet-sos`:

- **dotnet global tool:**

  To install the latest release version of the `dotnet-sos` [NuGet package](https://www.nuget.org/packages/dotnet-sos), use the [dotnet tool install](../tools/dotnet-tool-install.md) command:

  ```dotnetcli
  dotnet tool install --global dotnet-sos
  ```

- **Direct download:**

  Download the tool executable that matches your platform:

  | OS  | Platform |
  | --- | -------- |
  | Windows | [x86](https://aka.ms/dotnet-sos/win-x86) \| [x64](https://aka.ms/dotnet-sos/win-x64) \| [arm](https://aka.ms/dotnet-sos/win-arm) \| [arm-x64](https://aka.ms/dotnet-sos/win-arm64) |
  | macOS   | [x64](https://aka.ms/dotnet-sos/osx-x64) |
  | Linux   | [x64](https://aka.ms/dotnet-sos/linux-x64) \| [arm](https://aka.ms/dotnet-sos/linux-arm) \| [arm64](https://aka.ms/dotnet-sos/linux-arm64) \| [musl-x64](https://aka.ms/dotnet-sos/linux-musl-x64) \| [musl-arm64](https://aka.ms/dotnet-sos/linux-musl-arm64) |

## Synopsis

```console
dotnet-sos [-h|--help] [options] [command]]
```

## Description

The `dotnet-sos` global tool installs the [SOS debugger extension](sos-debugging-extension.md). This extension lets you inspect managed .NET Core state from native debuggers like lldb and windbg.

> [!NOTE]
> Installing SOS via the `dotnet-sos` tool is only needed on Linux or macOS.  It may also be needed on Windows if you're using older debugging tools. Recent versions of the [Windows Debugger](/windows-hardware/drivers/debugger/debugger-download-tools) (>= version 10.0.18317.1001 of WinDbg or cdb) load SOS automatically from the Microsoft extension gallery.  

## Options

- **`--version`**

  Displays version information.

- **`-h|--help`**

  Shows command-line help.

## dotnet-sos install

Installs the [SOS extension](sos-debugging-extension.md) locally for debugging .NET Core processes. On macOS and Linux, the *.lldbinit* file will be updated so that the extension automatically loads at lldb startup. If you're installing SOS on Windows with older debugging tools (prior to version 10.0.18317.1001), you will need to manually load the extension in WinDbg or cdb by running `.load %USERPROFILE%\.dotnet\sos\sos.dll` in the debugger.

### Synopsis

```console
dotnet-sos install [--architecture <arch>]
```

### Options

- **`--architecture <arch>`**

  Specifies the processor architecture of the SOS binaries to install. By default, `dotnet-sos` installs the architecture of the host machine. Use this option when you want to install SOS for an architecture that's different from the dotnet host architecture. For example, if you're running Arm32 binaries from an Arm64 host, you will need to install SOS with `dotnet-sos install --architecture Arm`.

  The following architectures are available:

  - `Arm`
  - `Arm64`
  - `X86`
  - `X64`

## dotnet-sos uninstall

Uninstalls the [SOS extension](sos-debugging-extension.md) and, on Linux and macOS, removes it from lldb configuration.

### Synopsis

```console
dotnet-sos uninstall
```

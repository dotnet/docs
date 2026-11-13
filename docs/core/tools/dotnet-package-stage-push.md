---
title: dotnet package stage push command
description: The dotnet package stage push command uploads a NuGet package to a staging service without publishing it.
author: Nigusu-Allehu
ms.date: 11/10/2026
ai-usage: ai-generated
---
# dotnet package stage push

**This article applies to:** ✔️ .NET 11 SDK and later versions

## Name

`dotnet package stage push` - Uploads a NuGet package to a staging service without publishing it.

## Synopsis

```dotnetcli
dotnet package stage push <PACKAGE_PATH>
    [--configfile <FILE>] [--group <GROUP_ID>] [--interactive]
    [-k|--api-key <API_KEY>] [--no-symbols] [-s|--source <SOURCE>]

dotnet package stage push -h|--help
```

## Description

The `dotnet package stage push` command uploads a NuGet package to a staging service without publishing it.

## Arguments

- **`PACKAGE_PATH`**

  Specifies the file path to one existing `.nupkg`, `.snupkg`, or legacy `.symbols.nupkg` file. Multiple paths and file globs aren't supported.

## Options

- **`--configfile <FILE>`**

  The NuGet configuration file (`nuget.config`) to use. If specified, only the settings from this file are used. Otherwise, the normal NuGet configuration hierarchy is used. For more information, see [Common NuGet configurations](/nuget/consume-packages/configuring-nuget-behavior).

- **`--group <GROUP_ID>`**

  Uploads the package and its symbols into the specified existing staging group.

- [!INCLUDE [help](includes/cli-help.md)]

- [!INCLUDE [interactive](includes/cli-interactive.md)]

- **`-k|--api-key <API_KEY>`**

  The API key for the staging service. If omitted, the command checks the `NUGET_API_KEY` environment variable, then configured API keys.

- **`--no-symbols`**

  Prevents automatic upload of a symbol package from the same directory. By default, the command prefers a matching `.snupkg` file over a legacy `.symbols.nupkg` file.

- **`-s|--source <SOURCE>`**

  Specifies a configured source name or a V3 service-index URL. The source must support staging and use HTTPS. Required unless your NuGet configuration specifies a `DefaultPushSource` value.

## Examples

- Upload a package to a staging-capable source with an explicit API key:

  ```dotnetcli
  dotnet package stage push Contoso.1.0.0.nupkg --source https://packages.contoso.com/v3/index.json --api-key <API_KEY>
  ```

- Upload a package and any matching symbol package into an existing group:

  ```dotnetcli
  dotnet package stage push Contoso.1.0.0.nupkg --group contoso-1.0.0
  ```

- Upload a package without automatically uploading its symbol package:

  ```dotnetcli
  dotnet package stage push Contoso.1.0.0.nupkg --no-symbols
  ```

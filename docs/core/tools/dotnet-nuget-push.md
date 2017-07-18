---
title: dotnet nuget push command (.NET Core SDK 2.0 Preview 2) | Microsoft Docs
description: The 'dotnet nuget push' command pushes a package to the server and publishes it. 
keywords: dotnet nuget push, CLI, CLI command, .NET Core
author: guardrex
ms.author: mairaw
ms.date: 06/11/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: f54d9adf-94f8-41cc-bb52-42f7ca3be6ff
---

# dotnet nuget push (.NET Core SDK 2.0 Preview 2)

[!INCLUDE [core-preview-warning](~/includes/core-preview-warning.md)]

## Name

`dotnet nuget push` - Pushes a package to the server and publishes it.

## Synopsis

`dotnet nuget push [<ROOT>] [-d|--disable-buffering] [--force-english-output] [-h|--help] [-k|--api-key] [-n|--no-symbols] [-s|--source] [-sk|--symbol-api-key] [-ss|--symbol-source] [-t|--timeout]`

## Description

The `dotnet nuget push` command pushes a package to the server and publishes it. The push command uses server and credential details found in the system's NuGet config file or chain of config files. For more information on config files, see [Configuring NuGet Behavior](/nuget/consume-packages/configuring-nuget-behavior). NuGet's default configuration is obtained by loading *%AppData%\NuGet\NuGet.config* (Windows) or *$HOME/.local/share* (macOS/Linux), then loading any *nuget.config* or *.nuget\nuget.config* starting from the root of drive and ending in the current directory.

## Arguments

`ROOT`

Specifies the path to the package and your API key to push the package to the server.

## Options

`-d|--disable-buffering`

Disable buffering when pushing to an HTTP(S) server to decrease memory usage.

`--force-english-output`

Force command-line output in English.

`-h|--help`

Shows help information.

`-k|--api-key <API_KEY>`

The API key for the server.

`-n|--no-symbols`

Don't push symbols (even if present).

`-s|--source <SOURCE>`

Specifies the server URL. This option is required unless the `DefaultPushSource` config value is set in the NuGet config file.

`-sk|--symbol-api-key <API_KEY>`

The API key for the symbol server.

`-ss|--symbols-source <SOURCE>`

Specifies the symbol server URL.

`-t|--timeout <TIMEOUT>`

Specifies the timeout for pushing to a server in seconds. Defaults to 300 seconds (5 minutes). Specifying 0 (zero seconds) applies the default value.

## Examples

Push *foo.nupkg* to the default push source with an API key:

`dotnet nuget push foo.nupkg -k 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a`

Push *foo.nupkg* to the custom push source `http://customsource` with an API key:

`dotnet nuget push foo.nupkg -k 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a -s http://customsource/` 

Push *foo.nupkg* to the default push source:

`dotnet nuget push foo.nupkg` 

Push *foo.symbols.nupkg* to the default symbols source:

`dotnet nuget push foo.symbols.nupkg`

Push *foo.nupkg* to the default push source with a 360 second timeout:

`dotnet nuget push foo.nupkg --timeout 360`

Push all *nupkg* files in the current directory to the default push source:

`dotnet nuget push *.nupkg`

Push all *nupkg* files in the current directory to the default push source with a custom config file *./config/My.Config*:

`dotnet nuget push *.nupkg --config-file ./config/My.Config`

Push all *nupkg* files in the current directory to the default push source with maximum verbosity:

`dotnet nuget push *.nupkg --verbosity detailed`

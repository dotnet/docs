---
title: dotnet nuget push command - .NET Core CLI
description: The dotnet nuget push command pushes a package to the server and publishes it.
author: karann-msft
ms.author: mairaw
ms.date: 08/14/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.workload: 
  - dotnetcore
---
# dotnet nuget push

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet nuget push` - Pushes a package to the server and publishes it.

## Synopsis

`dotnet nuget push [<ROOT>] [-s|--source] [-ss|--symbol-source] [-t|--timeout] [-k|--api-key] [-sk|--symbol-api-key] [-d|--disable-buffering] [-n|--no-symbols] [--force-english-output] [-h|--help]`

## Description

The `dotnet nuget push` command pushes a package to the server and publishes it. The push command uses server and credential details found in the system's NuGet config file or chain of config files. For more information on config files, see [Configuring NuGet Behavior](/nuget/consume-packages/configuring-nuget-behavior). NuGet's default configuration is obtained by loading *%AppData%\NuGet\NuGet.config* (Windows) or *$HOME/.local/share* (Linux/macOS), then loading any *nuget.config* or *.nuget\nuget.config* starting from the root of drive and ending in the current directory.

## Arguments

`ROOT`

Specifies the file path to the package to be pushed.

## Options

`-h|--help`

Prints out a short help for the command.

`-s|--source <SOURCE>`

Specifies the server URL. This option is required unless `DefaultPushSource` config value is set in the NuGet config file.

`--symbol-source <SOURCE>`

Specifies the symbol server URL.

`-t|--timeout <TIMEOUT>`

Specifies the timeout for pushing to a server in seconds. Defaults to 300 seconds (5 minutes). Specifying 0 (zero seconds) applies the default value.

`-k|--api-key <API_KEY>`

The API key for the server.

`--symbol-api-key <API_KEY>`

The API key for the symbol server.

`-d|--disable-buffering`

Disables buffering when pushing to an HTTP(S) server to decrease memory usage.

`-n|--no-symbols`

Doesn't push symbols (even if present).

`--force-english-output`

Forces all logged output in English.

## Examples

Pushes *foo.nupkg* to the default push source, providing an API key:

`dotnet nuget push foo.nupkg -k 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a`

Push *foo.nupkg* to the custom push source `http://customsource`, providing an API key:

`dotnet nuget push foo.nupkg -k 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a -s http://customsource/`

Pushes *foo.nupkg* to the default push source:

`dotnet nuget push foo.nupkg`

Pushes *foo.symbols.nupkg* to the default symbols source:

`dotnet nuget push foo.symbols.nupkg`

Pushes *foo.nupkg* to the default push source, specifying a 360 second timeout:

`dotnet nuget push foo.nupkg --timeout 360`

Pushes all *.nupkg* files in the current directory to the default push source:

`dotnet nuget push *.nupkg`

Pushes all *.nupkg* files in the current directory to the default push source, specifying a custom config file *./config/My.Config*:

`dotnet nuget push *.nupkg --config-file ./config/My.Config`

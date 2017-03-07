---
title: dotnet-nuget-push command | Microsoft Docs
description: The dotnet-nuget-push command pushes a package to the server and publishes it. 
keywords: dotnet-nuget-push, CLI, CLI command, .NET Core
author: karann-msft
ms.author: mairaw
ms.date: 03/06/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: f54d9adf-94f8-41cc-bb52-42f7ca3be6ff
---
#dotnet-nuget-push

## Name

`dotnet-nuget-push` - Pushes a package to the server and publishes it. 

## Synopsis

```
dotnet nuget push [<package>] [-s|--source] [-ss|--symbol-source] [-t|--timeout] [-k|--api-key] [-sk|--symbol-api-key] [-d|--disable-buffering] [-n|--no-symbols] [--force-english-output] [-v|--verbosity]
dotnet nuget push [-h|--help]
```

## Description

The `dotnet nuget push` command pushes a package to the server and publishes it. The push command uses server and credential details found in the system's NuGet config file, or chain of config files. For more information on config files, see [Configuring NuGet Behavior](https://docs.microsoft.com/nuget/consume-packages/configuring-nuget-behavior). NuGet's default configuration is obtained by loading *%AppData%\NuGet\NuGet.config* (Windows) or *$HOME/.local/share* (Linux/macOS), then loading any *nuget.config* or *.nuget\nuget.config* 
starting from root of drive and ending in current directory.

## Options

`-h|--help`

Prints out a short help for the command.  

`-s|--source <SOURCE>`

Specifies the server URL. This option is required unless DefaultPushSource config value is set in the NuGet config file.

`--symbols-source <SOURCE>`

Specifies the symbol server URL.

`-t|--timeout <TIMEOUT>`

Specifies the timeout for pushing to a server in seconds. Defaults to 300 seconds (5 minutes). Specifying 0 also gives this default.

`-k|--api-key <API_KEY>`

The API key for the server.

`--symbol-api-key <API_KEY>`

The API key for the symbol server.

`-d|--disable-buffering`

Disables buffering when pushing to an HTTP(S) server to decrease memory usage.

`-n|--no-symbols`

Does not push symbols (even if present).

`--force-english-output`

Forces all logged output to be in English. As well as the flexibility of producing English output on a non-English machine, the consistency across platforms provided by this option is a helpful feature for 
automated tools which scrape the logs for text.

`--verbosity <LEVEL>`

Displays this amount of details in the output. Level can be `normal`, `quiet`, or `detailed`.

## Examples

Pushes foo.nupkg to default push source, providing API key:

`dotnet nuget push foo.nupkg -k 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a`

Push foo.nupkg to custom push source `http://customsource`, providing API key:

`dotnet nuget push foo.nupkg -k 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a -s http://customsource/` 

Pushes foo.nupkg to default push source:

`dotnet nuget push foo.nupkg` 

Pushes foo.symbols.nupkg to default symbols source:

`dotnet nuget push foo.symbols.nupkg`

Pushes foo.nupkg to default push source, specifying 360 second timeout:

`dotnet nuget push foo.nupkg --timeout 360`

Pushes all .nupkg files in current directory to default push source:

`dotnet nuget push *.nupkg`

Pushes all .nupkg files in current directory to default push source, specifying a custom config file *./config/My.Config*:

`dotnet nuget push *.nupkg --config-file ./config/My.Config`

Push all .nupkg files in current directory to default push source, with maximum verbosity:

`dotnet nuget push *.nupkg --verbosity detailed`

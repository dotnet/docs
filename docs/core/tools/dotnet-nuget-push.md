---
title: dotnet nuget push command - .NET Core CLI
description: The dotnet nuget push command pushes a package to the server and publishes it.
author: karann-msft
ms.author: mairaw
ms.date: 09/04/2018
---
# dotnet nuget push

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet nuget push` - Pushes a package to the server and publishes it.

## Synopsis

# [.NET Core 2.1](#tab/netcore21)
```
dotnet nuget push [<ROOT>] [-d|--disable-buffering] [--force-english-output] [-k|--api-key] [-n|--no-symbols]
    [--no-service-endpoint] [-s|--source] [-sk|--symbol-api-key] [-ss|--symbol-source] [-t|--timeout]
dotnet nuget push [-h|--help]
```
# [.NET Core 2.0](#tab/netcore20)
```
dotnet nuget push [<ROOT>] [-d|--disable-buffering] [--force-english-output] [-k|--api-key] [-n|--no-symbols]
    [-s|--source] [-sk|--symbol-api-key] [-ss|--symbol-source] [-t|--timeout]
dotnet nuget push [-h|--help]
```
# [.NET Core 1.x](#tab/netcore1x)
```
dotnet nuget push [<ROOT>] [-d|--disable-buffering] [--force-english-output] [-k|--api-key] [-n|--no-symbols]
    [-s|--source] [-sk|--symbol-api-key] [-ss|--symbol-source] [-t|--timeout]
dotnet nuget push [-h|--help]
```
---

## Description

The `dotnet nuget push` command pushes a package to the server and publishes it. The push command uses server and credential details found in the system's NuGet config file or chain of config files. For more information on config files, see [Configuring NuGet Behavior](/nuget/consume-packages/configuring-nuget-behavior). NuGet's default configuration is obtained by loading *%AppData%\NuGet\NuGet.config* (Windows) or *$HOME/.local/share* (Linux/macOS), then loading any *nuget.config* or *.nuget\nuget.config* starting from the root of drive and ending in the current directory.

## Arguments

`ROOT`

Specifies the file path to the package to be pushed.

## Options

# [.NET Core 2.1](#tab/netcore21)

`-d|--disable-buffering`

Disables buffering when pushing to an HTTP(S) server to reduce memory usage.

`--force-english-output`

Forces the application to run using an invariant, English-based culture.

`-h|--help`

Prints out a short help for the command.

`-k|--api-key <API_KEY>`

The API key for the server.

`-n|--no-symbols`

Doesn't push symbols (even if present).

`--no-service-endpoint`

Doesn't append "api/v2/package" to the source URL.

`-s|--source <SOURCE>`

Specifies the server URL. This option is required unless `DefaultPushSource` config value is set in the NuGet config file.

`-sk|--symbol-api-key <API_KEY>`

The API key for the symbol server.

`-ss|--symbol-source <SOURCE>`

Specifies the symbol server URL.

`-t|--timeout <TIMEOUT>`

Specifies the timeout for pushing to a server in seconds. Defaults to 300 seconds (5 minutes). Specifying 0 (zero seconds) applies the default value.

# [.NET Core 2.0](#tab/netcore20)

`-d|--disable-buffering`

Disables buffering when pushing to an HTTP(S) server to reduce memory usage.

`--force-english-output`

Forces the application to run using an invariant, English-based culture.

`-h|--help`

Prints out a short help for the command.

`-k|--api-key <API_KEY>`

The API key for the server.

`-n|--no-symbols`

Doesn't push symbols (even if present).

`-s|--source <SOURCE>`

Specifies the server URL. This option is required unless `DefaultPushSource` config value is set in the NuGet config file.

`-sk|--symbol-api-key <API_KEY>`

The API key for the symbol server.

`-ss|--symbol-source <SOURCE>`

Specifies the symbol server URL.

`-t|--timeout <TIMEOUT>`

Specifies the timeout for pushing to a server in seconds. Defaults to 300 seconds (5 minutes). Specifying 0 (zero seconds) applies the default value.

# [.NET Core 1.x](#tab/netcore1x)

`-d|--disable-buffering`

Disables buffering when pushing to an HTTP(S) server to reduce memory usage.

`--force-english-output`

Forces the application to run using an invariant, English-based culture.

`-h|--help`

Prints out a short help for the command.

`-k|--api-key <API_KEY>`

The API key for the server.

`-n|--no-symbols`

Doesn't push symbols (even if present).

`-s|--source <SOURCE>`

Specifies the server URL. This option is required unless `DefaultPushSource` config value is set in the NuGet config file.

`-sk|--symbol-api-key <API_KEY>`

The API key for the symbol server.

`-ss|--symbol-source <SOURCE>`

Specifies the symbol server URL.

`-t|--timeout <TIMEOUT>`

Specifies the timeout for pushing to a server in seconds. Defaults to 300 seconds (5 minutes). Specifying 0 (zero seconds) applies the default value.

---

## Examples

Pushes *foo.nupkg* to the default push source, specifying an API key:

`dotnet nuget push foo.nupkg -k 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a`

Push *foo.nupkg* to the custom push source `http://customsource`, specifying an API key:

`dotnet nuget push foo.nupkg -k 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a -s http://customsource/`

Pushes *foo.nupkg* to the default push source:

`dotnet nuget push foo.nupkg`

Pushes *foo.symbols.nupkg* to the default symbols source:

`dotnet nuget push foo.symbols.nupkg`

Pushes *foo.nupkg* to the default push source, specifying a 360-second timeout:

`dotnet nuget push foo.nupkg --timeout 360`

Pushes all *.nupkg* files in the current directory to the default push source:

`dotnet nuget push *.nupkg`

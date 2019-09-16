---
title: dotnet nuget push command
description: The dotnet nuget push command pushes a package to the server and publishes it.
author: karann-msft
ms.date: 06/26/2019
---
# dotnet nuget push

**This topic applies to: ✓** .NET Core 1.x SDK and later versions

<!-- todo: uncomment when all CLI commands are reviewed
[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]
-->

## Name

`dotnet nuget push` - Pushes a package to the server and publishes it.

## Synopsis

```console
dotnet nuget push [<ROOT>] [-d|--disable-buffering] [--force-english-output] [--interactive] [-k|--api-key] [-n|--no-symbols]
    [--no-service-endpoint] [-s|--source] [-sk|--symbol-api-key] [-ss|--symbol-source] [-t|--timeout]
dotnet nuget push [-h|--help]
```

## Description

The `dotnet nuget push` command pushes a package to the server and publishes it. The push command uses server and credential details found in the system's NuGet config file or chain of config files. For more information on config files, see [Configuring NuGet Behavior](/nuget/consume-packages/configuring-nuget-behavior). NuGet's default configuration is obtained by loading *%AppData%\NuGet\NuGet.config* (Windows) or *$HOME/.local/share* (Linux/macOS), then loading any *nuget.config* or *.nuget\nuget.config* starting from the root of drive and ending in the current directory.

## Arguments

* **`ROOT`**

  Specifies the file path to the package to be pushed.

## Options

* **`-d|--disable-buffering`**

  Disables buffering when pushing to an HTTP(S) server to reduce memory usage.

* **`--force-english-output`**

  Forces the application to run using an invariant, English-based culture.

* **`-h|--help`**

Prints out a short help for the command.

* **`--interactive`**

  Allows the command to block and requires manual action for operations like authentication. Option available since .NET Core 2.2 SDK.

* **`-k|--api-key <API_KEY>`**

  The API key for the server.

* **`-n|--no-symbols`**

  Doesn't push symbols (even if present).

* **`--no-service-endpoint`**

  Doesn't append "api/v2/package" to the source URL. Option available since .NET Core 2.1 SDK.

* **`-s|--source <SOURCE>`**

  Specifies the server URL. This option is required unless `DefaultPushSource` config value is set in the NuGet config file.

* **`-sk|--symbol-api-key <API_KEY>`**

  The API key for the symbol server.

* **`-ss|--symbol-source <SOURCE>`**

  Specifies the symbol server URL.

* **`-t|--timeout <TIMEOUT>`**

  Specifies the timeout for pushing to a server in seconds. Defaults to 300 seconds (5 minutes). Specifying 0 (zero seconds) applies the default value.

## Examples

* Pushes *foo.nupkg* to the default push source, specifying an API key:

  ```console
  dotnet nuget push foo.nupkg -k 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a
  ```

* Push *foo.nupkg* to the custom push source `https://customsource`, specifying an API key:

  ```console
  dotnet nuget push foo.nupkg -k 4003d786-cc37-4004-bfdf-c4f3e8ef9b3a -s https://customsource/
  ```

* Pushes *foo.nupkg* to the default push source:

  ```console
  dotnet nuget push foo.nupkg
  ```

* Pushes *foo.symbols.nupkg* to the default symbols source:

  ```console
  dotnet nuget push foo.symbols.nupkg
  ```

* Pushes *foo.nupkg* to the default push source, specifying a 360-second timeout:

  ```console
  dotnet nuget push foo.nupkg --timeout 360
  ```

* Pushes all *.nupkg* files in the current directory to the default push source:

  ```console
  dotnet nuget push *.nupkg
  ```
  
  > [!NOTE]
  > If this command doesn't work, it might be due to a bug that existed in older versions of the SDK (.NET Core 2.1 SDK and earlier versions).
  > To fix this, upgrade your SDK version or run the following command instead:
  > `dotnet nuget push **/*.nupkg`

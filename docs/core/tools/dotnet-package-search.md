---
title: dotnet package search command
description: Searches a given source using the query string provided. If no sources are specified, all sources defined in the NuGet.Config file are used.
author: Nigusu-Allehu
ms.date: 10/26/2023
---
# dotnet package search

**This article applies to:** ✔️ .NET 8.0.2xx SDK and later versions

## Name

`dotnet package search` - Searches for a NuGet package.

## Synopsis

```dotnetcli
dotnet package search <SEARCH TERM> [--configfile <FILE>] [--exact-match] [--format <FORMAT OPTION>]
    [--interactive] [--prerelease] [--skip <NUMBER>] [--source <SOURCE>] [--take <NUMBER>]
    [--verbosity <VERBOSITY VALUE>]

dotnet package search -h|--help
```

## Description

The `dotnet package search` command searches for a NuGet package.

## Arguments

- **`search terms`**

  Specifies the search term to filter results. Use this argument to search for packages matching the provided query. Example: `dotnet package search json`.

## Options

- **`--configfile`**

    The NuGet configuration file. If specified, only the settings from this file will be used. If not
    specified, the hierarchy of configuration files from the current directory will be used. For more
    information, see <https://docs.microsoft.com/nuget/consume-packages/configuring-nuget-behavior>.

- **`--exact-match`**

    This option narrows the search to only include packages whose IDs exactly match the specified search term, effectively filtering out any partial matches. It provides a concise list of all available versions for the identified package. Causes `--take` and `--skip`
    options to be ignored. Utilize this option to display all available versions of a specified package.

- **`--format`**

    Format the output accordingly. The format options are either `table` or `json`. The default is `table`.

- **`--interactive`**

    Allows the command to stop and wait for user input or action (for example to complete authentication).

- **`--prerelease`**

    Allow prerelease packages to be shown.

- **`--skip`**

    The number of results to skip, for pagination. The default value is 0.

- **`--source <SOURCE>`**

    The package source to search. You can pass multiple --source options to search multiple package sources.

- **`--take`**

    The number of results to return. The default value is 20.

- **`--verbosity`**

    Display this amount of details in the output: `normal`, `minimal`,`detailed`. The default is`normal`.

[!INCLUDE [help](../../../includes/cli-help.md)]

## Examples

- Search NuGet.org for packages using the search term "Newtonsoft.Json"

    ```dotnetcli
    dotnet package search Newtonsoft.Json --source https://api.nuget.org/v3/index.json
    ```

    output a list of 20 packages in the source matching the search term.

    ```output
        Source: https://api.nuget.org/v3/index.json
        | Package ID                                  | Latest Version | Owners | Downloads       |
        |---------------------------------------------|----------------|--------|-----------------|
        | Newtonsoft.Json                             | 13.0.3         |        | 3,829,822,911   |
        |---------------------------------------------|----------------|--------|-----------------|
        | Newtonsoft.Json.Bson                        | 1.0.2          |        | 554,641,545     |
        |---------------------------------------------|----------------|--------|-----------------|
        | Newtonsoft.Json.Schema                      | 3.0.15         |        | 39,648,430      |
        |---------------------------------------------|----------------|--------|-----------------|
        | Microsoft.AspNetCore.Mvc.NewtonsoftJson     | 7.0.12         |        | 317,067,823     |
        |---------------------------------------------|----------------|--------|-----------------|
        ...
    ```

- Search NuGet.org for packages using the search term "Newtonsoft.Json" and render the output as a json.

    ```dotnetcli
    dotnet package search Newtonsoft.Json --source https://api.nuget.org/v3/index.json --format json
    ```

    ```output
        {
        "version": 2,
        "problems": [],
        "searchResult": [
            {
            "sourceName": "https://api.nuget.org/v3/index.json",
            "packages": [
                {
                "id": "Newtonsoft.Json",
                "latestVersion": "13.0.3",
                "totalDownloads": 4456137550,
                "owners": "dotnetfoundation, jamesnk, newtonsoft"
                },
                {
                "id": "Newtonsoft.Json.Bson",
                "latestVersion": "1.0.2",
                "totalDownloads": 655362732,
                "owners": "dotnetfoundation, jamesnk, newtonsoft"
                },
                {
                "id": "Newtonsoft.Json.Schema",
                "latestVersion": "3.0.15",
                "totalDownloads": 46062119,
                "owners": "jamesnk, newtonsoft"
                },
                {
                "id": "Microsoft.AspNetCore.Mvc.NewtonsoftJson",
                "latestVersion": "8.0.3",
                "totalDownloads": 372202749,
                "owners": "aspnet, dotnetframework, Microsoft"
                },
                {
                "id": "Swashbuckle.AspNetCore.Newtonsoft",
                "latestVersion": "6.5.0",
                "totalDownloads": 81345453,
                "owners": "domaindrivendev"
                },
                {
                "id": "GraphQL.NewtonsoftJson",
                "latestVersion": "7.8.0",
                "totalDownloads": 11244179,
                "owners": "joemcbride"
                },
                {
                "id": "Refit.Newtonsoft.Json",
                "latestVersion": "7.0.0",
                "totalDownloads": 12583471,
                "owners": "dotnetfoundation, reactiveui"
                },
                {
                "id": "Microsoft.Azure.Core.NewtonsoftJson",
                "latestVersion": "2.0.0",
                "totalDownloads": 6593746,
                "owners": "azure-sdk, Microsoft"
                },
                {
                "id": "RestSharp.Serializers.NewtonsoftJson",
                "latestVersion": "110.2.0",
                "totalDownloads": 13462500,
                "owners": "alexey_zimarev, Ubiquitous"
                },
                {
                "id": "App.Metrics.Formatters.Json",
                "latestVersion": "4.3.0",
                "totalDownloads": 30385383,
                "owners": "al_hardy"
                },
                {
                "id": "NServiceBus.Newtonsoft.Json",
                "latestVersion": "3.0.0",
                "totalDownloads": 9386309,
                "owners": "ParticularSoftware"
                },
                {
                "id": "RestSharp.Newtonsoft.Json",
                "latestVersion": "1.5.1",
                "totalDownloads": 4295800,
                "owners": "adamfisher"
                },
                {
                "id": "Microsoft.AspNetCore.SignalR.Protocols.NewtonsoftJson",
                "latestVersion": "8.0.3",
                "totalDownloads": 17044287,
                "owners": "aspnet, dotnetframework, Microsoft"
                },
                {
                "id": "MassTransit.Newtonsoft",
                "latestVersion": "8.1.3",
                "totalDownloads": 5185238,
                "owners": "phatboyg"
                },
                {
                "id": "GraphQL.Client.Serializer.Newtonsoft",
                "latestVersion": "6.0.2",
                "totalDownloads": 13538118,
                "owners": "rose-a"
                },
                {
                "id": "StackExchange.Redis.Extensions.Newtonsoft",
                "latestVersion": "10.2.0",
                "totalDownloads": 11013705,
                "owners": "imperugo"
                },
                {
                "id": "CloudNative.CloudEvents.NewtonsoftJson",
                "latestVersion": "2.7.1",
                "totalDownloads": 2156165,
                "owners": "CloudNative.CloudEvents"
                },
                {
                "id": "h5.Newtonsoft.Json",
                "latestVersion": "24.2.45748",
                "totalDownloads": 3855727,
                "owners": "Curiosity"
                },
                {
                "id": "Newtonsoft.Json.FSharp",
                "latestVersion": "3.2.2",
                "totalDownloads": 245301,
                "owners": "henrik feldt"
                },
                {
                "id": "Newtonsoft.Json.Encryption",
                "latestVersion": "2.2.0",
                "totalDownloads": 113101,
                "owners": "simoncropp"
                }
            ]
            }
        ]
        }
    ```

- Search NuGet.org for packages using the search term "Newtonsoft.Json", show only two results and skip the first packages in the search result

    ```dotnetcli
    dotnet package search Newtonsoft.Json --source https://api.nuget.org/v3/index.json --skip 1 --take 2
    ```

    output a list of 2 packages after skipping 1 in the source matching the search term.

    ```output
        Source: https://api.nuget.org/v3/index.json
        | Package ID                                  | Latest Version | Owners | Downloads       |
        |---------------------------------------------|----------------|--------|-----------------|
        | Newtonsoft.Json.Bson                        | 1.0.2          |        | 554,641,545     |
        | Newtonsoft.Json.Schema                      | 3.0.15         |        | 39,648,430      |
    ```

- Search for packages that exactly match "Newtonsoft.Json" and list all available versions of it, ignoring any packages that contain "Newtonsoft.Json" as a part of their name or description but don't match it exactly.

    ```dotnetcli
    dotnet package search Newtonsoft.Json --source https://api.nuget.org/v3/index.json --exact-match
    ```

    output only an exact match.

    ```output
        Source: https://api.nuget.org/v3/index.json
        | Package ID                                  | Version | Owners | Downloads       |
        |---------------------------------------------|---------|--------|-----------------|
        | Newtonsoft.Json                             | 13.0.3  |        | 3,829,822,911   |
    ```

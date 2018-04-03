---
title: global.json reference
description: See the schema for the global.json file, which permits setting the .NET Core SDK version.
author: mairaw
ms.author: mairaw
ms.date: 03/19/2018
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.workload: 
  - dotnetcore
---
# global.json reference

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

The *global.json* file allows selection of the .NET Core SDK version being used through the `sdk` property.

.NET Core SDK looks for this file in the current working directory (which isn't necessarily the same as the project directory) or one of its parent directories.

## sdk

Type: Object

Specifies information about the .NET Core SDK.

### version

Type: String

The version of the .NET Core SDK to use.

Note that this field:

- Doesn't have globbing support, that is, the full version number has to be specified.
- Doesn't support version ranges.

The following example shows the contents of a *global.json* file:

```json
{
  "sdk": {
    "version": "2.1.300-preview1-008174"
  }
}
```

You can easily create this file by executing the [dotnet new](dotnet-new) command as follows:

```console
dotnet new globaljson --sdk-version 2.1.300-preview1-008174
```

## Matching rules

With .NET Core SDK 1.x, if you specified a version and no exact match was found, the latest installed SDK version was used. Latest SDK version can be either release or pre-release - the highest version number wins.

Starting with .NET Core SDK 2.0, the following rules apply when determining which version of the SDK to use:

- If *global.json* doesn't contain a version or a *global.json* file cannot be found, the latest installed SDK version is used (release or pre-release).
- If *global.json* does contain a version:
  - If the specified version is found on the machine, that exact version is used.
  - If the specified version cannot be found on the machine, the latest **patch** of the specified version is used (roll-forward along patch versions). For more information about versioning, see [Semantic versioning](../versions/index.md/#semantic-versioning).
  - If the specified version and its patch versions cannot be found, an error is thrown.
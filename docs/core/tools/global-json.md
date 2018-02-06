---
title: global.json reference
description: See the schema for the global.json file, which permits setting the .NET Core tools version.
keywords: .NET, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 04/05/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 96102f96-d403-4385-8ef6-5d80e406eb0c
ms.workload: 
  - dotnetcore
---

# global.json reference

The *global.json* file allows selection of the .NET Core tools version being used through the `sdk` property.

.NET Core CLI tools look for this file in the current working directory (which isn't necessarily the same as the project directory) or one of its parent directories.

## sdk
Type: Object

Specifies information about the SDK.

### version
Type: String

The version of the SDK to use.

For example:

```json
{
  "sdk": {
    "version": "1.0.0-preview2-003121"
  }
}
```

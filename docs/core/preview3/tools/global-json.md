---
title: global.json reference | Microsoft Docs
description: global.json reference
keywords: .NET, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 11/02/2016
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 96102f96-d403-4385-8ef6-5d80e406eb0c
---

# global.json reference (.NET Core Tools RC4)

> [!WARNING]
> This topic applies to .NET Core Tools RC4. For the .NET Core Tools Preview 2 version,
> see the [global.json reference](../../tools/global-json.md) topic.

The global.json file is still present in the .NET Core Command Line RC4. However, its main purpose is not to define 
solution metadata as in previous releases, but to allow selection of the CLI version being used through the `sdk` property. 

This reference reflects the above fact. 

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
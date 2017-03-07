---
title: global.json reference | Microsoft Docs
description: global.json reference
keywords: .NET, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 03/06/2016
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 96102f96-d403-4385-8ef6-5d80e406eb0c
---

# global.json reference

The global.json file allows selection of the .NET Core tools version being used through the `sdk` property. 

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
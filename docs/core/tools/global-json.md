---
title: Global.json reference
description: Global.json reference
keywords: .NET, .NET Core
author: aL3891
manager: wpickett
ms.date: 09/01/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: e1ac9659-425f-4486-a376-c12ca942ead8
---

# Global.json reference

## projects
Type: String[]

Specifies which folders the build system should search for projects when resolving dependencies. The build system will only search top-level child folders.

For example:

```json
{
    "projects": [ "src", "test" ]
}
```

## packages
Type: String

The location to store packages.

For example:
```json
{
    "packages": "packages-dir"
}
```

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

### architecture
Type: String

Specifies which processor architecture to target. Supported values: `x86` or `x64`.

For example:
```json
{
    "sdk": {
        "architecture": "x86"
    }
}
```

### runtime
Type: String

Determines which runtime to target. Supported values: `clr` or `coreclr`.

For example:
```json
{
    "sdk": {
        "runtime": "clr"
    }
}
```

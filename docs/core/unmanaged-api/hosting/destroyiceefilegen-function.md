---
description: "Learn more about: DestroyICeeFileGen Function"
title: "DestroyICeeFileGen Function"
ms.date: "03/30/2017"
api_name:
  - "DestroyICeeFileGen"
api_location:
  - "mscoree.dll"
  - "mscorpehost.dll"
  - "mscorpe.dll"
api_type:
  - "COM"
f1_keywords:
  - "DestroyICeeFileGen"
helpviewer_keywords:
  - "DestroyICeeFileGen function [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# DestroyICeeFileGen Function

Destroys an [ICeeFileGen](iceefilegen-class.md) object.

 This function has been deprecated in the .NET Framework 4.

## Syntax

```cpp
HRESULT DestroyICeeFileGen (
    [in] ICeeFileGen  **ceeFileGen
);
```

## Parameters

 `ceeFileGen`
 [in] The `ICeeFileGen` object to destroy.

## Return Value

 This method returns standard COM error codes.

## Remarks

 `DestroyICeeFileGen` destroys the `ICeeFileGen` object created by the [CreateICeeFileGen](createiceefilegen-function.md) function.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** ICeeFileGen.h

 **Library:** MSCorPE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md)

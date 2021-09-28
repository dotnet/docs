---
description: "Learn more about: GetAssemblyIdentityFromFile Function"
title: "GetAssemblyIdentityFromFile Function"
ms.date: "03/30/2017"
api_name:
  - "GetAssemblyIdentityFromFile"
api_location:
  - "fusion.dll"
  - "clr.dll"
  - "mscorwks.dll"
api_type:
  - "COM"
f1_keywords:
  - "GetAssemblyIdentityFromFile"
helpviewer_keywords:
  - "GetAssemblyIdentityFromFile function [.NET Framework fusion]"
ms.assetid: 2c32da53-76c7-4048-84d0-d05207333004
topic_type:
  - "apiref"
---
# GetAssemblyIdentityFromFile Function

Gets a pointer to an `IUnknown` object with the specified `IID` in the assembly at the specified file path.

## Syntax

```cpp
HRESULT GetAssemblyIdentityFromFile (
    [in]  LPCWSTR   pwzFilePath,
    [in]  REFIID    riid,
    [out] IUnknown  **ppIdentity
 );
```

## Parameters

 `pwzFilePath`
 [in] A valid path to the requested assembly.

 `riid`
 [in] The `IID` of the interface to return.

 `ppIdentity`
 [out] The returned interface pointer.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).

**Header:** Fusion.h

**Library:**

- Fusion.dll
- Clr.dll
- MSCorWks.dll

**.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]

## See also

- [IUnknown](/cpp/atl/iunknown)
- [Fusion Global Static Functions](fusion-global-static-functions.md)

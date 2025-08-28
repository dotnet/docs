---
description: "Learn more about: ICorDebugAppDomain::GetModuleFromMetaDataInterface Method"
title: "ICorDebugAppDomain::GetModuleFromMetaDataInterface Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugAppDomain.GetModuleFromMetaDataInterface"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugAppDomain::GetModuleFromMetaDataInterface"
helpviewer_keywords:
  - "ICorDebugAppDomain::GetModuleFromMetaDatainterface method [.NET debugging]"
  - "GetModuleFromMetaDatainterface method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugAppDomain::GetModuleFromMetaDataInterface Method

Gets the module that corresponds to the given metadata interface.

## Syntax

```cpp
HRESULT GetModuleFromMetaDataInterface (
    [in] IUnknown           *pIMetaData,
    [out] ICorDebugModule  **ppModule
);
```

## Parameters

 `pIMetaData`
 [in] A pointer to an object that is one of the [Metadata interfaces](../metadata/metadata-interfaces.md).

 `ppModule`
 [out] A pointer to the address of an ICorDebugModule object that represents the module corresponding to the given metadata interface.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

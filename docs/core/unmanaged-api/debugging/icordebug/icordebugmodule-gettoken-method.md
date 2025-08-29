---
description: "Learn more about: ICorDebugModule::GetToken Method"
title: "ICorDebugModule::GetToken Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugModule.GetToken"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugModule::GetToken"
helpviewer_keywords:
  - "ICorDebugModule::GetToken method [.NET debugging]"
  - "GetToken method, ICorDebugModule interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugModule::GetToken Method

Gets the token for the table entry for this module.

## Syntax

```cpp
HRESULT GetToken(
    [out] mdModule *pToken
);
```

## Parameters

 `pToken`
 [out] A pointer to the `mdModule` token that references the module's metadata.

## Remarks

The token can be passed to the [IMetaDataImport](../../metadata/interfaces/imetadataimport-interface.md), [IMetaDataImport2](../../metadata/interfaces/imetadataimport2-interface.md), and [IMetaDataAssemblyImport](../../metadata/interfaces/imetadataassemblyimport-interface.md) metadata import interfaces.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Metadata](../metadata/index.md)

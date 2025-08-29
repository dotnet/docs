---
description: "Learn more about: ICorDebugModule::GetMetaDataInterface Method"
title: "ICorDebugModule::GetMetaDataInterface Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugModule.GetMetaDataInterface"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugModule::GetMetaDataInterface"
helpviewer_keywords:
  - "ICorDebugModule::GetMetaDatainterface method [.NET debugging]"
  - "GetMetaDatainterface method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugModule::GetMetaDataInterface Method

Gets a metadata interface object that can be used to examine the metadata for the module.

## Syntax

```cpp
HRESULT GetMetaDataInterface (
    [in] REFIID      riid,
    [out] IUnknown **ppObj
);
```

## Parameters

 `riid`
 [in] The reference ID that specifies the metadata interface.

 `ppObj`
 [out] A pointer to the address of an `T:IUnknown` object that is one of the [metadata interfaces](../../metadata/interfaces/metadata-interfaces.md).

## Remarks

The debugger can use the `GetMetaDataInterface` method to make a copy of the original metadata for a module, which it must do in order to edit that module. The debugger calls `GetMetaDataInterface` to get an [IMetaDataEmit](../../metadata/interfaces/imetadataemit-interface.md) interface object for the module, then calls [IMetaDataEmit::SaveToMemory](../../metadata/interfaces/imetadataemit-savetomemory-method.md) to save a copy of the module's metadata to memory.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

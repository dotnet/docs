---
description: "Learn more about: ICorDebugSymbolProvider::GetAssemblyImageMetadata Method"
title: "ICorDebugSymbolProvider::GetAssemblyImageMetadata Method"
ms.date: "03/30/2017"
ms.assetid: c3c9de67-b865-4ecf-b887-1f1d0719a0c0
---
# ICorDebugSymbolProvider::GetAssemblyImageMetadata Method

Returns the metadata from a merged assembly.

## Syntax

```cpp
HRESULT GetAssemblyImageMetadata(
   [out] ICorDebugMemoryBuffer** ppMemoryBuffer
);
```

## Parameters

 `ppMemoryBuffer`
 [out] A pointer to the address of an [ICorDebugMemoryBuffer](icordebugmemorybuffer-interface.md) object that contains information about the size and address of the merged assembly's metadata.

## Remarks

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]

## See also

- [ICorDebugSymbolProvider Interface](icordebugsymbolprovider-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)

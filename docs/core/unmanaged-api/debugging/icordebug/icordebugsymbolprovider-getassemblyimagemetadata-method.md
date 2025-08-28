---
description: "Learn more about: ICorDebugSymbolProvider::GetAssemblyImageMetadata Method"
title: "ICorDebugSymbolProvider::GetAssemblyImageMetadata Method"
ms.date: "03/30/2017"
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

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugSymbolProvider Interface](icordebugsymbolprovider-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)

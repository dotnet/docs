---
description: "Learn more about: ICorDebugSymbolProvider2 Interface"
title: "ICorDebugSymbolProvider2 Interface"
ms.date: "03/30/2017"
---
# ICorDebugSymbolProvider2 Interface

Logically extends the [ICorDebugSymbolProvider](icordebugsymbolprovider-interface.md) interface to retrieve additional debug symbol information.

## Methods

|Method|Description|
|------------|-----------------|
|[GetFrameProps Method](icordebugsymbolprovider2-getframeprops-method.md)|Returns the method starting relative virtual address of a method and the parent frame given a code relative virtual address.|
|[GetGenericDictionaryInfo Method](icordebugsymbolprovider2-getgenericdictionaryinfo-method.md)|Retrieves a generic dictionary map.|

## Remarks

> [!NOTE]
> This interface is available with .NET Native only. If you implement this interface for ICorDebug scenarios outside of .NET Native, the common language runtime will ignore this interface.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugSymbolProvider Interface](icordebugsymbolprovider-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)

---
description: "Learn more about: ICorDebugStaticFieldSymbol::GetSize Method"
title: "ICorDebugStaticFieldSymbol::GetSize Method"
ms.date: "03/30/2017"
ms.assetid: 72389860-7e37-4656-ba46-b6aeee1860f8
---
# ICorDebugStaticFieldSymbol::GetSize Method

Gets the size in bytes of the static field.

## Syntax

```cpp
HRESULT GetSize(
   [out] ULONG32 *pcbSize
);
```

## Parameters

 `pcbSize`
 [out] A pointer to length of the field.

## Remarks

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]

## See also

- [ICorDebugStaticFieldSymbol Interface](icordebugstaticfieldsymbol-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)

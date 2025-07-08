---
description: "Learn more about: ICorDebugStaticFieldSymbol::GetAddress Method"
title: "ICorDebugStaticFieldSymbol::GetAddress Method"
ms.date: "03/30/2017"
ms.assetid: 5a6c9a5a-ec72-4c40-a9c3-cee7baa63687
---
# ICorDebugStaticFieldSymbol::GetAddress Method

Gets the address of a static field.

## Syntax

```cpp
HRESULT GetAddress(
   [out] CORDB_ADDRESS *pRVA
);
```

## Parameters

 pRVA
 [out] A pointer to the relative virtual address (RVA) of the static field.

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

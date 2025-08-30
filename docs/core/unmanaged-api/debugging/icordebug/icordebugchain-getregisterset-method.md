---
description: "Learn more about: ICorDebugChain::GetRegisterSet Method"
title: "ICorDebugChain::GetRegisterSet Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugChain.GetRegisterSet"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugChain::GetRegisterSet"
helpviewer_keywords:
  - "ICorDebugChain::GetRegisterSet method [.NET debugging]"
  - "GetRegisterSet method, ICorDebugChain interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugChain::GetRegisterSet Method

Gets the register set for the active part of this chain.

## Syntax

```cpp
HRESULT GetRegisterSet (
    [out] ICorDebugRegisterSet **ppRegisters
);
```

## Parameters

 `ppRegisters`
 [out] A pointer to the address of an [ICorDebugRegisterSet](icordebugregisterset-interface.md) object that represents the register set for the active part of this chain.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

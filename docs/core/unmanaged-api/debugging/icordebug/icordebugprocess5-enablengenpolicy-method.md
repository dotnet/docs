---
description: "Learn more about: ICorDebugProcess5::EnableNGENPolicy Method"
title: "ICorDebugProcess5::EnableNGENPolicy Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugProcess5::EnableNGenPolicy"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugProcess5::EnableNGENPolicy"
helpviewer_keywords:
  - "ICorDebugProcess5::EnableNGENPolicy method [.NET debugging]"
  - "EnableNGENPolicy method, ICorDebugProcess5 interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugProcess5::EnableNGENPolicy Method

Sets a value that determines how an application loads native images while running under a managed debugger.

## Syntax

```cpp
HRESULT EnableNGENPolicy(
    [in] CorDebugNGENPolicy ePolicy
);
```

## Parameters

 `ePolicy`
 [in] A [CorDebugNGenPolicy](cordebugngenpolicy-enumeration.md) constant that determines how an application loads native images while running under a managed debugger.

## Remarks

 If the policy is set successfully, the method returns `S_OK`. If `ePolicy` is outside the range of the enumerated values defined by [CorDebugNGenPolicy](cordebugngenpolicy-enumeration.md), the method returns `E_INVALIDARG` and the method call has no effect. If the policy of the Native Image Generator (Ngen.exe) cannot be updated, the method returns `E_FAIL`.

 The `ICorDebugProcess5::EnableNGenPolicy` method can be called at any time during the lifetime of the process. The policy is in effect for any modules that are loaded after the policy is set.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5

## See also

- [ICorDebugProcess5 Interface](icordebugprocess5-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)

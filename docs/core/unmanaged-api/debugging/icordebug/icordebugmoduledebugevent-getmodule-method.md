---
description: "Learn more about: ICorDebugModuleDebugEvent::GetModule Method"
title: "ICorDebugModuleDebugEvent::GetModule Method"
ms.date: "03/30/2017"
---
# ICorDebugModuleDebugEvent::GetModule Method

Gets the merged module that was just loaded or unloaded.

## Syntax

```cpp
HRESULT GetModule(
   [out]ICorDebugModule **ppModule
);
```

## Parameters

 `ppModule`
 [out] A pointer to the address of an ICorDebugModule object that represents the merged module that was just loaded or unloaded.

## Remarks

 You can call the [GetEventKind](icordebugdebugevent-geteventkind-method.md) method to determine whether the module was loaded or unloaded.

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugModuleDebugEvent Interface](icordebugmoduledebugevent-interface.md)

---
description: "Learn more about: ICorDebugAssembly3::GetContainerAssembly Method"
title: "ICorDebugAssembly3::GetContainerAssembly Method"
ms.date: "03/30/2017"
---
# ICorDebugAssembly3::GetContainerAssembly Method

Returns the container assembly of this `ICorDebugAssembly3` object.

## Syntax

```cpp
HRESULT GetContainerAssembly(
    ICorDebugAssembly **ppAssembly
);
```

## Parameters

 `ppAssembly`
A pointer to the address of an ICorDebugAssembly object that represents the container assembly, or **null** if the method call fails.

## Return Value

 `S_OK` if the method call succeeds; otherwise, `S_FALSE`, and `ppAssembly` is **null**.

## Remarks

If this assembly has been merged with others inside a single container assembly, this method returns the container assembly. For more information and terminology, see the [ICorDebugProcess6::EnableVirtualModuleSplitting](icordebugprocess6-enablevirtualmodulesplitting-method.md) topic.

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugAssembly3 Interface](icordebugassembly3-interface.md)

---
description: "Learn more about: ICorDebugAssembly3::EnumerateContainedAssemblies Method"
title: "ICorDebugAssembly3::EnumerateContainedAssemblies Method"
ms.date: "03/30/2017"
---
# ICorDebugAssembly3::EnumerateContainedAssemblies Method

Gets an enumerator for the assemblies contained in this assembly.

## Syntax

```cpp
HRESULT EnumerateContainedAssemblies(
    ICorDebugAssemblyEnum **ppAssemblies
);
```

## Parameters

 `ppAssemblies`
 [out] A pointer to the address of an ICorDebugAssemblyEnum interface object that is the enumerator.

## Return Value

 `S_OK` if this `ICorDebugAssembly3` object is a container; otherwise, `S_FALSE`, and the enumeration is empty.

## Remarks

 Symbols are needed to enumerate the contained assemblies. If they aren't present, the method returns `S_FALSE`, and no valid enumerator is provided.

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugAssembly3 Interface](icordebugassembly3-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)

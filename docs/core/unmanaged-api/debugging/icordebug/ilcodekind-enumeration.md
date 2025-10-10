---
description: "Learn more about: ILCodeKind Enumeration"
title: "ILCodeKind Enumeration"
ms.date: "03/30/2017"
dev_langs:
  - "cpp"
api_name:
  - "ILCodeKind"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
topic_type:
  - "apiref"
---
# ILCodeKind Enumeration

 Provides values that specify whether the debugger is able to access local variables or code added in profiler ReJIT instrumentation.

## Syntax

```cpp
typedef enum ILCodeKind {
   ILCODE_ORIGINAL_IL = 0x1,
   ILCODE_REJIT_IL = 0x2,
} ILCodeKind;
```

## Members

|Member name|Description|
|-----------------|-----------------|
|`ILCODE_ORIGINAL_IL`|The debugger does not have access to information from ReJIT instrumentation.|
|`ILCODE_REJIT_IL`|The debugger has access to information from ReJIT instrumentation.|

## Remarks

 A member of the `ILCodeKind` enumeration can be passed to the [EnumerateLocalVariablesEx](icordebugilframe4-enumeratelocalvariablesex-method.md) and [GetLocalVariableEx](icordebugilframe4-getlocalvariableex-method.md) methods to determine whether the debugger can access variables added in profiler ReJIT instrumentation, and to the [GetCodeEx](icordebugilframe4-getcodeex-method.md) method to determine whether the debugger can access instrumented IL.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5.2

## See also

- [ICorDebugILFrame4 Interface](icordebugilframe4-interface.md)
- [ReJIT: A How-To Guide](/archive/blogs/davbr/rejit-a-how-to-guide)

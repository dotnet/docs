---
description: "Learn more about: CorDebugCodeInvokePurpose Enumeration"
title: "CorDebugCodeInvokePurpose Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorDebugInvokePurpose"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
topic_type:
  - "apiref"
---
# CorDebugCodeInvokePurpose Enumeration

Describes why an exported function calls managed code.

## Syntax

```cpp
typedef enum CorDebugCodeInvokePurpose
{
    CODE_INVOKE_PURPOSE_NONE,
    CODE_INVOKE_PURPOSE_NATIVE_TO_MANAGED_TRANSITION,
    CODE_INVOKE_PURPOSE_CLASS_INIT,
    CODE_INVOKE_PURPOSE_INTERFACE_DISPATCH,
} CorDebugCodeInvokePurpose;
```

## Members

| Member                     | Description      |
|----------------------------|------------------|
| `CODE_INVOKE_PURPOSE_NONE` | None or unknown. |
|`CODE_INVOKE_PURPOSE_NATIVE_TO_MANAGED_TRANSITION`|The managed code will run any managed entry point, such as a reverse p-invoke. Any more detailed purpose is unknown by the runtime.|
|`CODE_INVOKE_PURPOSE_CLASS_INIT`|The managed code will run a static constructor.|
|`CODE_INVOKE_PURPOSE_INTERFACE_DISPATCH`|The managed code will run the implementation for some interface method that was called.|

## Remarks

 This enumeration is used by the [ICorDebugProcess6::GetExportStepInfo](icordebugprocess6-getexportstepinfo-method.md) method to provide information about stepping through managed code.

> [!NOTE]
> This enumeration is intended for use in .NET Native debugging scenarios only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

---
title: "DacpMethodDescData Structure"
ms.date: "02/01/2019"
api.name:
  - "DacpMethodDescData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpMethodDescData Structure"
helpviewer.keywords:
  - "DacpMethodDescData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "hoyosjs"
ms.author: "juhoyosa"
---
# DacpMethodDescData Structure

Defines a transport buffer for a method's runtime information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```
struct DacpMethodDescData
{
    int             bHasNativeCode;
    int             bIsDynamic;
    unsigned short  wSlotNumber;
    CLRDATA_ADDRESS NativeCodeAddr;
    CLRDATA_ADDRESS data;
    CLRDATA_ADDRESS MethodDescPtr;
    CLRDATA_ADDRESS nativeCodeInfo;
    CLRDATA_ADDRESS moduleInfo;
    mdToken         MDToken;
    CLRDATA_ADDRESS payloadGC;
    CLRDATA_ADDRESS payloadGC2;
    CLRDATA_ADDRESS managedDynamicMethodObject;
    CLRDATA_ADDRESS requestedIP;
    DacpReJitData   rejitDataCurrent;
    DacpReJitData   rejitDataRequested;
    unsigned long   cJittedRejitVersions;
};
```

## Members

| Member                       | Description                                                                                     |
| ---------------------------- | ----------------------------------------------------------------------------------------------- |
| `bHasNativeCode`             | Indicates if the runtime has native code available for the given instantiation of the method. |
| `bIsDynamic`                 | Indicates if the method is generated dynamically through lightweight code generation.           |
| `wSlotNumber`                | The method's slot number in the method table.                                                   |
| `NativeCodeAddr`             | The method's initial native address.                                                            |
| `data`                       | Pointer to a buffer used internally by the runtime.                                             |
| `MethodDescPtr`              | Pointer to the `MethodDesc` in the runtime.                                                     |
| `nativeCodeInfo`             | Pointer to a buffer used internally by the runtime to track methods.                            |
| `moduleInfo`                 | Pointer to a buffer used internally by the runtime for module information.                      |
| `MDToken`                    | Token associated with the given method.                                                         |
| `payloadGC`                  | Pointer to a garbage collection buffer used internally by the runtime.                          |
| `payloadGC2`                 | Pointer to a garbage collection buffer used internally by the runtime.                          |
| `managedDynamicMethodObject` | If the method is dynamic, the runtime uses this buffer internally for information tracking.     |
| `requestedIP`                | Used to populate the structure per request when given a native code address.                    |
| `rejitDataCurrent`           | Information about the latest instrumented version of the method.                                   |
| `rejitDataRequested`         | Rejit information for the requested native address.                                             |
| `cJittedRejitVersions`       | Number of times the method has been rejitted through instrumentation.                           |

## Remarks

This structure lives inside the runtime and is not exposed through any headers or library files. To use it, define the structure as specified above.

## Requirements
**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
- [Debugging Structures](../../../../docs/framework/unmanaged-api/debugging/debugging-structures.md)
- [Common Data Types](../../../../docs/framework/unmanaged-api/common-data-types-unmanaged-api-reference.md)

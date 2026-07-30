---
description: "Learn more about: DacpFieldDescData Structure"
title: "DacpFieldDescData Structure"
ms.date: "07/30/2026"
api.name:
  - "DacpFieldDescData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpFieldDescData Structure"
helpviewer.keywords:
  - "DacpFieldDescData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# DacpFieldDescData Structure

Defines a transport buffer for FieldDesc information.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpFieldDescData : ZeroInit<DacpFieldDescData>
{
    CorElementType Type;
    CorElementType sigType;     // ELEMENT_TYPE_XXX from signature. We need this to disply pretty name for String in minidump's case
    CLRDATA_ADDRESS MTOfType; // NULL if Type is not loaded
    
    CLRDATA_ADDRESS ModuleOfType;
    mdTypeDef TokenOfType;
    
    mdFieldDef mb;
    CLRDATA_ADDRESS MTOfEnclosingClass;
    DWORD dwOffset;
    BOOL bIsThreadLocal;
    BOOL bIsContextLocal;
    BOOL bIsStatic;
    CLRDATA_ADDRESS NextField;

    HRESULT Request(ISOSDacInterface *sos, CLRDATA_ADDRESS addr)
    {
        return sos->GetFieldDescData(addr, this);
    }
};
```

## Members

| Member | Description |
| ------ | ----------- |
| `Type` | The field type. |
| `sigType` | The `ELEMENT_TYPE_XXX` value from the field signature. The runtime uses this member to display a friendly name for `String` in minidump scenarios. |
| `MTOfType` | The address of the method table for the field type, or `NULL` if the type is not loaded. |
| `ModuleOfType` | The address of the module that contains the field type. |
| `TokenOfType` | The metadata token for the field type. |
| `mb` | The metadata token for the field. |
| `MTOfEnclosingClass` | The address of the method table for the enclosing class. |
| `dwOffset` | The field offset. |
| `bIsThreadLocal` | A value that indicates whether the field is thread local. |
| `bIsContextLocal` | A value that indicates whether the field is context local. |
| `bIsStatic` | A value that indicates whether the field is static. |
| `NextField` | The address of the next field. |
| `Request` | Populates the structure from a FieldDesc address by calling `ISOSDacInterface::GetFieldDescData`. |

## Remarks

This structure lives inside the runtime and is not exposed through any headers or library files. To use it, define the structure as specified above.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [Debugging Structures](debugging-structures.md)

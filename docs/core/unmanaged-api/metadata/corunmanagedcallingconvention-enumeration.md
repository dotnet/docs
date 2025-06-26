---
description: "Learn more about: CorUnmanagedCallingConvention Enumeration"
title: "CorUnmanagedCallingConvention Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorUnmanagedCallingConvention"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorUnmanagedCallingConvention"
helpviewer_keywords:
  - "CorUnmanagedCallingConvention enumeration [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# CorUnmanagedCallingConvention Enumeration

Specifies the calling conventions for unmanaged code.

## Syntax

```cpp
typedef enum CorUnmanagedCallingConvention {

    IMAGE_CEE_UNMANAGED_CALLCONV_C         = 0x1,
    IMAGE_CEE_UNMANAGED_CALLCONV_STDCALL   = 0x2,
    IMAGE_CEE_UNMANAGED_CALLCONV_THISCALL  = 0x3,
    IMAGE_CEE_UNMANAGED_CALLCONV_FASTCALL  = 0x4,

    IMAGE_CEE_CS_CALLCONV_C                = 0x1,
    IMAGE_CEE_CS_CALLCONV_STDCALL          = 0x2,
    IMAGE_CEE_CS_CALLCONV_THISCALL         = 0x3,
    IMAGE_CEE_CS_CALLCONV_FASTCALL         = 0x4

} CorUnmanagedCallingConvention;
```

## Members

|Member|Description|
|------------|-----------------|
|`IMAGE_CEE_UNMANAGED_CALLCONV_C`|The C language calling convention.|
|`IMAGE_CEE_UNMANAGED_CALLCONV_STDCALL`|The standard calling convention.|
|`IMAGE_CEE_UNMANAGED_CALLCONV_THISCALL`|The "this" calling convention.|
|`IMAGE_CEE_UNMANAGED_CALLCONV_FASTCALL`|The "fast" calling convention.|
|`IMAGE_CEE_CS_CALLCONV_C`|Not used.|
|`IMAGE_CEE_CS_CALLCONV_STDCALL`|Not used.|
|`IMAGE_CEE_CS_CALLCONV_THISCALL`|Not used.|
|`IMAGE_CEE_CS_CALLCONV_FASTCALL`|Not used.|

## Remarks

 The CLR does not support the "fast" calling convention in .NET Framework version 1.0.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** CorHdr.h

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Metadata Enumerations](metadata-enumerations.md)

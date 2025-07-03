---
description: "Learn more about: ICeeGen::EmitString Method"
title: "ICeeGen::EmitString Method"
ms.date: "03/30/2017"
api_name:
  - "ICeeGen.EmitString"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICeeGen::EmitString"
helpviewer_keywords:
  - "EmitString method [.NET Framework metadata]"
  - "ICeeGen::EmitString method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# ICeeGen::EmitString Method

Emits the specified string into the code base.

 This method is obsolete and should not be used.

## Syntax

```cpp
HRESULT EmitString (
    [in]  LPWSTR    lpString,
    [out] ULONG     *RVA
);
```

## Parameters

 `lpString`
 [in] The string to emit.

 `RVA`
 [out] The relative virtual address of the emitted string.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICeeGen Interface](iceegen-interface.md)

---
description: "Learn more about: ICeeGen::AllocateMethodBuffer Method"
title: "ICeeGen::AllocateMethodBuffer Method"
ms.date: "03/30/2017"
api_name:
  - "ICeeGen.AllocateMethodBuffer"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICeeGen::AllocateMethodBuffer"
helpviewer_keywords:
  - "AllocateMethodBuffer method [.NET Framework metadata]"
  - "ICeeGen::AllocateMethodBuffer method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# ICeeGen::AllocateMethodBuffer Method

Creates a buffer of the specified size for a method, and gets the relative virtual address of the method.

 This method is obsolete and should not be used.

## Syntax

```cpp
HRESULT AllocateMethodBuffer (
    [in]  ULONG    cchBuffer,
    [out] UCHAR    **lpBuffer,
    [out] ULONG    *RVA
);
```

## Parameters

 `cchBuffer`
 [in] The length of the buffer to create.

 `lpBuffer`
 [out] The returned buffer.

 `RVA`
 [out] The relative virtual address of the method.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICeeGen Interface](iceegen-interface.md)

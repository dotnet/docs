---
description: "Learn more about: ICeeGen::GetSectionBlock Method"
title: "ICeeGen::GetSectionBlock Method"
ms.date: "03/30/2017"
api_name:
  - "ICeeGen.GetSectionBlock"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICeeGen::GetSectionBlock"
helpviewer_keywords:
  - "GetSectionBlock method [.NET Framework metadata]"
  - "ICeeGen::GetSectionBlock method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# ICeeGen::GetSectionBlock Method

Gets a section block of the code base.

 This method is obsolete and should not be used.

## Syntax

```cpp
HRESULT GetSectionBlock (
    [in]  HCEESECTION    section,
    [in]  ULONG          len,
    [in]  ULONG          align     = 1,
    [out] void           **ppBytes = 0
);
```

## Parameters

 `section`
 [in] The section from which to retrieve a block of the code base.

 `len`
 [in] The length of the block to be retrieved.

 `align`
 [in] The byte, relative to the beginning of the section, with which to align the first byte of the block. This is the position of the block within the section.

 `ppBytes`
 [out] A pointer to a location that receives the address of the retrieved block.

## Remarks

 Call `GetSectionBlock` only if you have special section requirements that are not handled by other methods.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICeeGen Interface](iceegen-interface.md)

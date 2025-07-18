---
description: "Learn more about: ICeeGen::TruncateSection Method"
title: "ICeeGen::TruncateSection Method"
ms.date: "03/30/2017"
api_name:
  - "ICeeGen.TruncateSection"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICeeGen::TruncateSection"
helpviewer_keywords:
  - "TruncateSection method [.NET Framework metadata]"
  - "ICeeGen::TruncateSection method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# ICeeGen::TruncateSection Method

Truncates the specified code section by the specified length.

 This method is obsolete and should not be used.

## Syntax

```cpp
HRESULT TruncateSection (
    [in]  HCEESECTION     section,
    [in]  ULONG           len
);
```

## Parameters

 `section`
 [in] The section to truncate.

 `len`
 [in] The length, in bytes, by which to truncate the section.

## Remarks

 Call `TruncateSection` only if you have special section requirements that are not handled by other methods.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICeeGen Interface](iceegen-interface.md)

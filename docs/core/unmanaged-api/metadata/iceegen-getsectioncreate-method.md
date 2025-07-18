---
description: "Learn more about: ICeeGen::GetSectionCreate Method"
title: "ICeeGen::GetSectionCreate Method"
ms.date: "03/30/2017"
api_name:
  - "ICeeGen.GetSectionCreate"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICeeGen::GetSectionCreate"
helpviewer_keywords:
  - "ICeeGen::GetSectionCreate method [.NET Framework metadata]"
  - "GetSectionCreate method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# ICeeGen::GetSectionCreate Method

Generates and gets a code section using the specified name and flag values.

 This method is obsolete and should not be used.

## Syntax

```cpp
HRESULT GetSectionCreate (
    [in]  const char     *name,
    [in]  DWORD          flags,
    [out] HCEESECTION    *section
);
```

## Parameters

 `name`
 [in] A pointer to a string that specifies the name of the section to be created.

 `flags`
 [in] Flags that specify options.

 `section`
 [out] A pointer to the newly created code section.

## Remarks

 Call `GetSectionCreate` only if you have special section requirements that are not handled by other methods.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICeeGen Interface](iceegen-interface.md)

---
description: "Learn more about: ICeeGen::GetIlSection Method"
title: "ICeeGen::GetIlSection Method"
ms.date: "03/30/2017"
api_name:
  - "ICeeGen.GetIlSection"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICeeGen::GetIlSection"
helpviewer_keywords:
  - "GetIlSection method [.NET Framework metadata]"
  - "ICeeGen::GetIlSection method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# ICeeGen::GetIlSection Method

Gets the section of the intermediate language code base referenced by the specified handle.

 This method is obsolete and should not be used.

## Syntax

```cpp
HRESULT GetIlSection (
    [in] HCEESECTION  *section
);
```

## Parameters

 `section`
 [in] The handle to the section to get.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICeeGen Interface](iceegen-interface.md)

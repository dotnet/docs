---
description: "Learn more about: ICeeGen::GenerateCeeMemoryImage Method"
title: "ICeeGen::GenerateCeeMemoryImage Method"
ms.date: "03/30/2017"
api_name:
  - "ICeeGen.GenerateCeeMemoryImage"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICeeGen::GenerateCeeMemoryImage"
helpviewer_keywords:
  - "ICeeGen::GenerateCeeMemoryImage method [.NET Framework metadata]"
  - "GenerateCeeMemoryImage method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# ICeeGen::GenerateCeeMemoryImage Method

Generates an image in memory for the code base.

 This method is obsolete and should not be used.

## Syntax

```cpp
HRESULT GenerateCeeMemoryImage (
    [out] void    **ppImage
);
```

## Parameters

 `ppImage`
 [out] A pointer to the generated image.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICeeGen Interface](iceegen-interface.md)

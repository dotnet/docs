---
description: "Learn more about: ICeeGen::AddSectionReloc Method"
title: "ICeeGen::AddSectionReloc Method"
ms.date: "03/30/2017"
api_name:
  - "ICeeGen.AddSectionReloc"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICeeGen::AddSectionReloc"
helpviewer_keywords:
  - "AddSectionReloc method [.NET Framework metadata]"
  - "ICeeGen::AddSectionReloc method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# ICeeGen::AddSectionReloc Method

Adds a .reloc instruction to the code base.

 This method is obsolete and should not be used.

## Syntax

```cpp
HRESULT AddSectionReloc (
   [in] HCEESECTION            section,
   [in] ULONG                  offset,
   [in] HCEESECTION            relativeTo,
   [in] CeeSectionRelocType    relocType
);
```

## Parameters

 `section`
 [in] The section of in-memory code to which to add a .reloc instruction.

 `offset`
 [in] The offset of the section.

 `relativeTo`
 [in] The section to which `offset` refers.

 `relocType`
 [in] One of the [CeeSectionRelocType](ceesectionreloctype-enumeration.md) values, indicating the kind of .reloc instruction to add.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICeeGen Interface](iceegen-interface.md)

---
description: "Learn more about: CorFileFlags Enumeration"
title: "CorFileFlags Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorFileFlags"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorFileFlags"
helpviewer_keywords:
  - "CorFileFlags enumeration [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# CorFileFlags Enumeration

Contains values that describe the type of file defined in a call to [IMetaDataAssemblyEmit::DefineFile](imetadataassemblyemit-definefile-method.md).

## Syntax

```cpp
typedef enum CorFileFlags {

    ffContainsMetaData      =   0x0000,
    ffContainsNoMetaData    =   0x0001

} CorFileFlags;
```

## Members

|Member|Description|
|------------|-----------------|
|`ffContainsMetaData`|Indicates that the file is not a resource file.|
|`ffContainsNoMetaData`|Indicates that the file, possibly a resource file, does not contain metadata.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** CorHdr.h

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Metadata Enumerations](metadata-enumerations.md)

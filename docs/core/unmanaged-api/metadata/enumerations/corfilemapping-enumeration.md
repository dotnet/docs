---
description: "Learn more about: CorFileMapping Enumeration"
title: "CorFileMapping Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorFileMapping"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorFileMapping"
topic_type:
  - "apiref"
---
# CorFileMapping Enumeration

Contains values that describe the type of file mapping that is returned from a call to the [IMetaDataInfo::GetFileMapping](../interfaces/imetadatainfo-getfilemapping-method.md) method.

## Syntax

```cpp
typedef enum CorFileMapping {

    fmFlat                  =   0x0000,
    fmExecutableImage       =   0x0001

} CorFileMapping;
```

## Members

|Member|Description|
|------------|-----------------|
|`fmFlat`|The file is mapped as a data file. That is, the `SEC_IMAGE` flag was not passed to the Microsoft Win32 `CreateFileMapping` function.|
|`fmExecutableImage`|The file is mapped for execution, by using either the `LoadLibrary` function or the `CreateFileMapping` function with the `SEC_IMAGE` flag.|

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorHdr.h

 **.NET versions:** Available since .NET Framework 4.0

## See also

- [GetFileMapping Method](../interfaces/imetadatainfo-getfilemapping-method.md)

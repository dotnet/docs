---
description: "Learn more about: IMetaDataFilter Interface"
title: "IMetaDataFilter Interface"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataFilter"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataFilter"
topic_type:
  - "apiref"
---
# IMetaDataFilter Interface

Provides methods for marking and filtering metadata tokens to avoid repeating actions that have already been taken.

## Methods

|Method|Description|
|------------|-----------------|
|[IsTokenMarked Method](imetadatafilter-istokenmarked-method.md)|Gets a value indicating whether the specified metadata token has been processed.|
|[MarkToken Method](imetadatafilter-marktoken-method.md)|Sets a value indicating that the specified metadata token has been processed.|
|[UnmarkAll Method](imetadatafilter-unmarkall-method.md)|Removes the processing marks from all the tokens in the current metadata scope.|

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [Metadata Interfaces](metadata-interfaces.md)

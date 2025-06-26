---
description: "Learn more about: BucketParameters Structure"
title: "BucketParameters Structure"
ms.date: "03/30/2017"
api_name:
  - "BucketParameters"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "BucketParameters"
helpviewer_keywords:
  - "BucketParameters structure [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# BucketParameters Structure

Stores the type name of an event and the parameters for the current exception that is associated with the event.

## Syntax

```cpp
typedef struct _BucketParameters {
    BOOL  fInited;
    WCHAR pszEventTypeName[255];
    WCHAR pszParams[10][255];
} BucketParameters;
```

## Members

|Member|Description|
|------------|-----------------|
|`fInited`|`true`, if the rest of this structure is valid; otherwise, `false`.|
|`pszEventTypeName`|Name of the event type.|
|`pszParams`|An array of strings, each of which specifies a parameter for the current exception associated with the event.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.idl

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [Hosting Structures](hosting-structures.md)

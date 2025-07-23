---
description: "Learn more about: CorManifestResourceFlags Enumeration"
title: "CorManifestResourceFlags Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorManifestResourceFlags"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorManifestResourceFlags"
topic_type:
  - "apiref"
---
# CorManifestResourceFlags Enumeration

Indicates the visibility of resources encoded in an assembly manifest.

## Syntax

```cpp
typedef enum CorManifestResourceFlags {

    mrVisibilityMask        =   0x0007,
    mrPublic                =   0x0001,
    mrPrivate               =   0x0002

} CorManifestResourceFlags;
```

## Members

|Member|Description|
|------------|-----------------|
|`mrVisibilityMask`|Reserved.|
|`mrPublic`|The resources are public.|
|`mrPrivate`|The resources are private.|

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorHdr.h

 **.NET versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]

## See also

- [Metadata Enumerations](metadata-enumerations.md)

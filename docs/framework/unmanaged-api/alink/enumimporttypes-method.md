---
title: "EnumImportTypes Method"
ms.date: "03/30/2017"
api_name:
  - "EnumImportTypes"
  - "IALink.EnumImportTypes"
api_location:
  - "alink.dll"
api_type:
  - "COM"
f1_keywords:
  - "EnumImportTypes"
helpviewer_keywords:
  - "EnumImportTypes method"
ms.assetid: 83a0e4e7-ec06-40cb-9b63-700b9695bb04
topic_type:
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---

# EnumImportTypes Method

Enumerates each type in each scope.

## Syntax

```cpp
HRESULT EnumImportTypes(
    HALINKENUM   hEnum,
    DWORD        dwMax,
    mdTypeDef    aTypeDefs[],
    DWORD*       pdwCount
) PURE;
```

## Parameters

`hEnum`\
Handle for enumerator.

`dwMax`\
Maximum number of types to retrieve.

`aTypeDefs`\
Receives type tokens, not to exceed `dwMax`.

`pdwCount`\
Receives actual number of type in `aTypeDefs`.

## Return Value

Returns S_OK if the method succeeds.

## Requirements

Requires alink.h

## See also

- [IALink Interface](ialink-interface.md)
- [IALink2 Interface](ialink2-interface.md)
- [ALink API](index.md)
---
description: "Learn more about: CorDebugGuidToTypeMapping Structure"
title: "CorDebugGuidToTypeMapping Structure"
ms.date: "03/30/2017"
dev_langs:
  - "cpp"
api_name:
  - "CorDebugGuidToTypeMapping"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorDebugGuidToTypeMapping"
helpviewer_keywords:
  - "CorDebugGuidToTypeMapping structure [.NET debugging]"
topic_type:
  - "apiref"
---
# CorDebugGuidToTypeMapping Structure

Maps a Windows Runtime GUID to its corresponding ICorDebugType object.

## Syntax

```cpp
typedef struct CorDebugGuidToTypeMapping {
    GUID iid;
    ICorDebugType *pType;
} CorDebugGuidToTypeMapping;
```

## Members

|Member|Description|
|------------|-----------------|
|`iid`|The GUID of the cached Windows Runtime type.|
|`pType`|A pointer to an ICorDebugType object that provides information about the cached type.|

## Requirements

 **Platforms:** Windows Runtime.

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5

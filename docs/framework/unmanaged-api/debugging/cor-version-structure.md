---
description: "Learn more about: COR_VERSION Structure"
title: "COR_VERSION Structure"
ms.date: "03/30/2017"
api_name: 
  - "COR_VERSION"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_VERSION"
helpviewer_keywords: 
  - "COR_VERSION structure [.NET Framework debugging]"
ms.assetid: 5efaee1c-a001-4c73-9525-4160f4c71567
topic_type: 
  - "apiref"
---
# COR_VERSION Structure

Stores the standard four-part version number of the common language runtime.  
  
## Syntax  
  
```cpp  
typedef struct _COR_VERSION {  
    DWORD dwMajor;  
    DWORD dwMinor;  
    DWORD dwBuild;  
    DWORD dwSubBuild;  
} COR_VERSION;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`dwMajor`|The major version number.|  
|`dwMinor`|The minor version number.|  
|`dwBuild`|The build number.|  
|`dwSubBuild`|The sub-build number.|  
  
## Remarks  

 If the version number is 1.0.3705.288, 1 is the major version number, 0 is the minor version number, 3705 is the build number, and 288 is the sub-build number.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Debugging Structures](debugging-structures.md)
- [Debugging](index.md)

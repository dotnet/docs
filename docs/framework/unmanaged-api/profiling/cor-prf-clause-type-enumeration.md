---
description: "Learn more about: COR_PRF_CLAUSE_TYPE Enumeration"
title: "COR_PRF_CLAUSE_TYPE Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "COR_PRF_CLAUSE_TYPE"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_PRF_CLAUSE_TYPE"
helpviewer_keywords: 
  - "COR_PRF_CLAUSE_TYPE enumeration [.NET Framework profiling]"
ms.assetid: f64c325a-ed3a-4aaf-b847-a88edbc4fefc
topic_type: 
  - "apiref"
---
# COR_PRF_CLAUSE_TYPE Enumeration

Indicates the type of exception clause that the code has just entered or left.  
  
## Syntax  
  
```cpp  
typedef enum {  
    COR_PRF_CLAUSE_NONE = 0,  
    COR_PRF_CLAUSE_FILTER = 1,  
    COR_PRF_CLAUSE_CATCH = 2,  
    COR_PRF_CLAUSE_FINALLY = 3,  
} COR_PRF_CLAUSE_TYPE;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`COR_PRF_CLAUSE_NONE`|The exception clause is not valid.|  
|`COR_PRF_CLAUSE_FILTER`|The exception clause is a filter expression.|  
|`COR_PRF_CLAUSE_CATCH`|The exception clause is a `catch` statement.|  
|`COR_PRF_CLAUSE_FINALLY`|The exception clause is a `finally` statement.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Profiling Enumerations](profiling-enumerations.md)

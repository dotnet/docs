---
title: "CorSymVarFlag Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorSymVarFlag"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorSymVarFlag"
helpviewer_keywords: 
  - "CorSymVarFlag enumeration [.NET Framework debugging]"
ms.assetid: c3f7d307-4047-4f9a-be8c-f152fca42fd0
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# CorSymVarFlag Enumeration
Indicates whether a variable is compiler-generated.  
  
## Syntax  
  
```cpp  
typedef enum CorSymVarFlag   
{  
    VAR_IS_COMP_GEN = 1  
} CorSymVarFlag;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`VAR_IS_COMP_GEN`|Indicates that the given variable is compiler-generated.|  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [Diagnostics Symbol Store Enumerations](../../../../docs/framework/unmanaged-api/diagnostics/diagnostics-symbol-store-enumerations.md)

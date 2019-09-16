---
title: "EndMerge Method"
ms.date: "03/30/2017"
api_name: 
  - "IALink.EndMerge"
  - "EndMerge"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "EndMerge"
helpviewer_keywords: 
  - "EndMerge method"
ms.assetid: 1d03bb15-a2c8-4a04-8fc6-b126c89c3778
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# EndMerge Method
Indicates that all custom attributes have been merged into the emit scope.  
  
## Syntax  
  
```cpp  
HRESULT EndMerge(  
    mdAssembly AssemblyID  
) PURE;  
```  
  
## Parameters  
 `AssemblyID`  
 ID of the assembly.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h  
  
## See also

- [IALink Interface](ialink-interface.md)
- [IALink2 Interface](ialink2-interface.md)
- [ALink API](index.md)

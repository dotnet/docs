---
description: "Learn more about: GetAssemblyRefHash Method"
title: "GetAssemblyRefHash Method"
ms.date: "03/30/2017"
api_name: 
  - "IALink.GetAssemblyRefHash"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "GetAssemblyRefHash"
helpviewer_keywords: 
  - "GetAssemblyRefHash method"
ms.assetid: 091a18bd-e901-46f6-b999-74d71c8a7c41
topic_type: 
  - "apiref"
---
# GetAssemblyRefHash Method

Retrieves a hash blob for a given assembly.  
  
## Syntax  
  
```cpp  
HRESULT GetAssemblyRefHash(  
    mdToken FileToken,  
    const void** ppvHash,  
    DWORD* pcbHash  
) PURE;  
```  
  
## Parameters  

 `FileToken`  
 ID of assembly to which the hash will refer.  
  
 `ppvHash`  
 Receives the resulting hash blob.  
  
 `pcbHash`  
 Receives size, in bytes, of hash blob.  
  
## Return Value  

 Returns S_OK if the method succeeds.  
  
## Requirements  

 Requires alink.h  
  
## See also

- [IALink Interface](ialink-interface.md)
- [IALink2 Interface](ialink2-interface.md)
- [ALink API](index.md)

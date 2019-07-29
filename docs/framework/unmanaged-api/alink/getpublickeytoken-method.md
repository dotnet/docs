---
title: "GetPublicKeyToken Method"
ms.date: "03/30/2017"
api_name: 
  - "IALink2.GetPublicKeyToken"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "GetPublicKeyToken"
helpviewer_keywords: 
  - "GetPublicKeyToken method"
ms.assetid: 4a16374c-94b0-47b0-9fed-88c2b0cdccd4
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# GetPublicKeyToken Method
Retrieves the public key token for a given keyfile or key container.  
  
## Syntax  
  
```cpp  
HRESULT GetPublicKeyToken(  
    LPCWSTR pszKeyFile,  
    LPCWSTR pszKeyContainer,  
    void* pvPublicKeyToken,  
    DWORD* pcbPublicKeyToken  
) PURE;  
```  
  
## Parameters  
 `pszKeyFile`  
 Filename of the key.  
  
 `pszKeyContainer`  
 Name of the key container.  
  
 `pvPublicKeyToken`  
 Address where key token is to be stored.  
  
 `pcbPublicKeyToken`  
 Specifies the size, in bytes, of the buffer indicated by `pvPublicKeyToken`. Upon return, contains actual number of bytes used.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h.  
  
## See also

- [IALink2 Interface](../../../../docs/framework/unmanaged-api/alink/ialink2-interface.md)
- [IALink Interface](../../../../docs/framework/unmanaged-api/alink/ialink-interface.md)
- [ALink API](../../../../docs/framework/unmanaged-api/alink/index.md)

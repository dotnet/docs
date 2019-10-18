---
title: "LinkResource Method"
ms.date: "03/30/2017"
api_name: 
  - "IALink.LinkResource"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "LinkResource"
helpviewer_keywords: 
  - "LinkResource method"
ms.assetid: c404acb3-4c59-4100-9a4c-483cbdb1d736
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# LinkResource Method
Links in a resource.  
  
## Syntax  
  
```cpp  
HRESULT LinkResource(  
    mdAssembly  AssemblyID,  
    LPCWSTR     pszFileName,  
    LPCWSTR     pszNewLocation,  
    LPCWSTR     pszResourceName,  
    DWORD       dwFlags  
) PURE;  
```  
  
## Parameters  
 `AssemblyID`  
 ID of the assembly.  
  
 `pszFileName`  
 Name of the file.  
  
 `pszNewLocation`  
 Optional new file name. If non-NULL, `pszFileName` will be copied to pszNewLocation.  
  
 `pszResourceName`  
 Name of the resource.  
  
 `dwFlags`  
 Accessibility flags such as `mrPublic` and `mrPrivate`. This parameter may be passed to [DefineManifestResource Method](../metadata/imetadataassemblyemit-definemanifestresource-method.md).  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h.  
  
## See also

- [IALink Interface](ialink-interface.md)
- [IALink2 Interface](ialink2-interface.md)
- [ALink API](index.md)

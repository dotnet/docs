---
title: "LinkResource Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
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
caps.latest.revision: 6
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# LinkResource Method
Links in a resource.  
  
## Syntax  
  
```  
HRESULT LinkResource(  
    mdAssembly  AssemblyID,  
    LPCWSTR     pszFileName,  
    LPCWSTR     pszNewLocation,  
    LPCWSTR     pszResourceName,  
    DWORD       dwFlags  
) PURE;  
```  
  
#### Parameters  
 `AssemblyID`  
 ID of the assembly.  
  
 `pszFileName`  
 Name of the file.  
  
 `pszNewLocation`  
 Optional new file name. If non-NULL, `pszFileName` will be copied to pszNewLocation.  
  
 `pszResourceName`  
 Name of the resource.  
  
 `dwFlags`  
 Accessibility flags such as `mrPublic` and `mrPrivate`. This parameter may be passed to [DefineManifestResource Method](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-definemanifestresource-method.md).  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h.  
  
## See Also  
 [IALink Interface](../../../../docs/framework/unmanaged-api/alink/ialink-interface.md)  
 [IALink2 Interface](../../../../docs/framework/unmanaged-api/alink/ialink2-interface.md)  
 [ALink API](../../../../docs/framework/unmanaged-api/alink/index.md)

---
title: "SetManifestFile Method"
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
  - "IALink3.SetManifestFile"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "SetManifestFile"
helpviewer_keywords: 
  - "SetManifestFile method"
ms.assetid: 1b33de4c-19cb-4a36-a93f-8675b2a36d58
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# SetManifestFile Method
Enables you to specify or reset the manifest file that the linker uses when it creates the assembly.  
  
## Syntax  
  
```  
HRESULT SetManifestFile(  
    LPCWSTR pszFile  
) PURE;  
```  
  
#### Parameters  
 `pszFile`  
  
 The name of the manifest file whose contents are put into the Win32 resources blob.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Remarks  
 Call this before asking for the Win32ResBlob. The value of the `pszFile` parameter is the name of the manifest file whose contents are read and put in the Win32 resources with ID of RT_MANIFEST. When called by using a parameter of NULL, any previously read manifest is cleared. This enables one to reset the state of the linker to that of initialization time.  
  
## Requirements  
 Requires aLink.h  
  
## See Also  
 [IALink3 Interface](../../../../docs/framework/unmanaged-api/alink/ialink3-interface.md)  
 [ALink API](../../../../docs/framework/unmanaged-api/alink/index.md)  
 [IALink Interface](../../../../docs/framework/unmanaged-api/alink/ialink-interface.md)  
 [Al.exe (Assembly Linker)](../../../../docs/framework/tools/al-exe-assembly-linker.md)

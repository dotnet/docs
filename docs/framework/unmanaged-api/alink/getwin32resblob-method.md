---
title: "GetWin32ResBlob Method"
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
  - "IALink.GetWin32ResBlob"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "GetWin32ResBlob"
helpviewer_keywords: 
  - "GetWin32ResBlob method"
ms.assetid: 36997e04-f9f6-4254-a041-6767ac6c51d9
topic_type: 
  - "apiref"
caps.latest.revision: 5
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# GetWin32ResBlob Method
Retrieves Win32 resource blob. Call this method after setting assembly options.  
  
## Syntax  
  
```  
HRESULT GetWin32ResBlob(  
    mdAssembly    AssemblyID,  
    mdToken       FileToken,  
    BOOL          fDll,  
    LPCWSTR       pszIconFile,  
    const void**  ppResBlob,  
    DWORD*        pcbResBlob  
) PURE;  
```  
  
#### Parameters  
 `AssemblyID`  
 ID of the assembly.  
  
 `FileToken`  
 File token used to retrieve the filename to be used when constructing the Win32 Version resource  
  
 `fDll`  
 TRUE if file is a DLL, false for an EXE.  
  
 `pszIconFile`  
 Optional icon to insert into the resource blob.  
  
 `ppResBlob`  
 Receives the resource blob.  
  
 `pcbResBlob`  
 Receives the size of the blob.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h  
  
## See Also  
 [IALink Interface](../../../../docs/framework/unmanaged-api/alink/ialink-interface.md)  
 [IALink2 Interface](../../../../docs/framework/unmanaged-api/alink/ialink2-interface.md)  
 [ALink API](../../../../docs/framework/unmanaged-api/alink/index.md)

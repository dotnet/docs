---
title: "ICLRDebuggingLibraryProvider::ProvideLibrary Method"
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
  - "ICLRDebuggingLibraryProvider.ProvideLibrary Method"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDebuggingLibraryProvider::ProvideLibrary"
helpviewer_keywords: 
  - "ProvideLibrary method [.NET Framework debugging]"
  - "ICLRDebuggingLibraryProvider::ProvideLibrary method [.NET Framework debugging]"
ms.assetid: 86f06245-9517-49be-8d8c-ca5deaf34c02
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRDebuggingLibraryProvider::ProvideLibrary Method
Gets a library provider callback interface that allows common language runtime (CLR) version-specific debugging libraries to be located and loaded on demand.  
  
## Syntax  
  
```  
HRESULT ProvideLibrary(  
     [in] const WCHAR* pwszFileName,  
     [in] DWORD dwTimestamp,  
     [in] DWORD dwSizeOfImage,  
     [out] HMODULE* hModule);  
```  
  
#### Parameters  
 `pwszFilename`  
 [in] The name of the module being requested .  
  
 `dwTimestamp`  
 [in] The date time stamp stored in the COFF file header of PE files.  
  
 `pLibraryProvider`  
 [in] The `SizeOfImage` field stored in the COFF optional file header of PE files.  
  
 `hModule`  
 [out] The handle to the requested module.  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
  
## Exceptions  
  
## Remarks  
 `ProvideLibrary` allows the debugger to provide modules that are needed for debugging specific CLR files such as mscordbi.dll and mscordacwks.dll. The module handles have to remain valid until a call to the [ICLRDebugging::CanUnloadNow](../../../../docs/framework/unmanaged-api/debugging/iclrdebugging-canunloadnow-method.md) method indicates that they may be freed, at which point it is the caller’s responsibility to free the handles.  
  
 The debugger may use any available means to locate or procure the debugging module.  
  
> [!IMPORTANT]
>  This feature allows the API caller to provide modules that contain executable, and possibly malicious, code. As a security precaution, the caller should not use `ProvideLibrary` to distribute any code that it is not willing to execute itself.  
>   
>  If a serious security issue is discovered in an already released library, such as mscordbi.dll or mscordacwks.dll, the shim can be patched to recognize the bad versions of the files. The shim can then issue requests for the patched versions of the files and reject the bad versions if they are provided in response to any request. This can occur only if the user has patched to a new version of the shim. Unpatched versions will remain vulnerable.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)

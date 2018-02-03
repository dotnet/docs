---
title: "CreateVersionStringFromModule Function"
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
  - "CreateVersionStringFromModule"
api_location: 
  - "dbgshim.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CreateVersionStringFromModule"
helpviewer_keywords: 
  - "debugging API [Silverlight]"
  - "Silverlight, debugging"
  - "CreateVersionStringFromModule function"
ms.assetid: 3d2fe9bd-75ef-4364-84a6-da1e1994ac1a
topic_type: 
  - "apiref"
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CreateVersionStringFromModule Function
Creates a version string from a common language runtime (CLR) path in a target process.  
  
## Syntax  
  
```  
HRESULT CreateVersionStringFromModule (  
    [in]  DWORD      pidDebuggee,  
    [in]  LPCWSTR    szModuleName,  
    [out, size_is(cchBuffer),  
          length_is(*pdwLength)] LPWSTR Buffer,  
    [in]  DWORD      cchBuffer,  
    [out] DWORD*     pdwLength  
);  
```  
  
#### Parameters  
 `pidDebuggee`  
 [in] Identifier of the process in which the target CLR is loaded.  
  
 `szModuleName`  
 [in] Full or relative path to the target CLR that is loaded in the process.  
  
 `pBuffer`  
 [out] Return buffer for storing the version string for the target CLR.  
  
 `cchBuffer`  
 [in] Size of `pBuffer`.  
  
 `pdwLength`  
 [out] Length of the version string returned by `pBuffer`.  
  
## Return Value  
 S_OK  
 The version string for the target CLR was successfully returned in `pBuffer`.  
  
 E_INVALIDARG  
 `szModuleName` is null, or either `pBuffer` or `cchBuffer` is null. `pBuffer` and `cchBuffer` must both be null or non-null.  
  
 HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER)  
 `pdwLength` is greater than `cchBuffer`. This may be an expected result if you have passed null for both `pBuffer` and `cchBuffer`, and queried the necessary buffer size by using `pdwLength`.  
  
 HRESULT_FROM_WIN32(ERROR_MOD_NOT_FOUND)  
 `szModuleName` does not contain a path to a valid CLR in the target process.  
  
 E_FAIL (or other E_ return codes)  
 `pidDebuggee` does not refer to a valid process, or other failure.  
  
## Remarks  
 This function accepts a CLR process that is identified by `pidDebuggee` and a string path that is specified by `szModuleName`. The version string is returned in the buffer that `pBuffer` points to. This string is opaque to the function user; that is, there is no intrinsic meaning in the version string itself. It is used solely in the context of this function and the [CreateDebuggingInterfaceFromVersion function](../../../../docs/framework/unmanaged-api/debugging/createdebugginginterfacefromversion-function-for-silverlight.md).  
  
 This function should be called twice. When you call it the first time, pass null for both `pBuffer` and `cchBuffer`. When you do this, the size of the buffer necessary for `pBuffer` will be returned in `pdwLength`. You can then call the function a second time, and pass the buffer in `pBuffer` and its size in `cchBuffer`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** dbgshim.h  
  
 **Library:** dbgshim.dll  
  
 **.NET Framework Versions:** 3.5 SP1

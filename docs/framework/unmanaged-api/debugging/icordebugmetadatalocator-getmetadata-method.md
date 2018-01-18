---
title: "ICorDebugMetaDataLocator::GetMetaData Method"
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
  - "ICorDebugMetaDataLocator.GetMetaData"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugMetaDataLocator::GetMetaData"
helpviewer_keywords: 
  - "ICorDebugMetaDataLocator::GetMetaData method [.NET Framework debugging]"
  - "GetMetaData method, ICorDebugMetaDataLocator interface [.NET Framework debugging]"
ms.assetid: f9b0ff22-54db-45eb-9cc3-508000a3141d
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugMetaDataLocator::GetMetaData Method
Asks the debugger to return the full path to a module whose metadata is needed to complete an operation the debugger requested.  
  
## Syntax  
  
```  
HRESULT GetMetaData(  
      [in] LPCWSTR wszImagePath,  
      [in] DWORD   dwImageTimeStamp,  
      [in] DWORD   dwImageSize,  
      [in] ULONG32 cchPathBuffer,  
      [out] ULONG32 * pcchPathBuffer,  
      [out, size_is(cchPathBuffer), length_is(*pcchPathBuffer)]  
               WCHAR wszPathBuffer[]  
      );  
```  
  
#### Parameters  
 `wszImagePath`  
 [in] A null-terminated string that represents the full path to the file. If the full path is not available, the name and extension of the file (*filename*.*extension*).  
  
 `dwImageTimeStamp`  
 [in] The time stamp from the image's PE file headers. This parameter can potentially be used for a symbol server ([SymSrv](http://msdn.microsoft.com/library/cc266470.aspx)) lookup.  
  
 `dwImageSize`  
 [in] The image size from PE file headers. This parameter can potentially be used for a SymSrv lookup.  
  
 `cchPathBuffer`  
 [in] The character count in `wszPathBuffer`.  
  
 `pcchPathBuffer`  
 [out] The count of `WCHAR`s written to `wszPathBuffer`.  
  
 If the method returns E_NOT_SUFFICIENT_BUFFER, contains the count of `WCHAR`s needed to store the path.  
  
 `wszPathBuffer`  
 [out] Pointer to a buffer into which the debugger will copy the full path of the file that contains the requested metadata.  
  
 The `ofReadOnly` flag from the [CorOpenFlags](../../../../docs/framework/unmanaged-api/metadata/coropenflags-enumeration.md) enumeration is used to request read-only access to the metadata in this file.  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure. All other failure HRESULTs indicate that the file is not retrievable.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully. `wszPathBuffer` contains the full path to the file and is null-terminated.|  
|E_NOT_SUFFICIENT_BUFFER|The current size of `wszPathBuffer` is not sufficient to hold the full path. In this case, `pcchPathBuffer` contains the needed count of `WCHAR`s, including the terminating null character, and `GetMetaData` is called a second time with the requested buffer size.|  
  
## Remarks  
 If `wszImagePath` contains a full path for a module from a dump, it specifies the path from the computer where the dump was collected. The file may not exist at this location, or an incorrect file with the same name may be stored on the path.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICorDebugThread4 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugthread4-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)

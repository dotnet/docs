---
title: "ICorProfilerInfo3::GetRuntimeInformation Method"
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
  - "ICorProfilerInfo3.GetRuntimeInformation Method"
api_location: 
  - "Mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo3::GetRuntimeInformation"
helpviewer_keywords: 
  - "GetRuntimeInformation method [.NET Framework profiling]"
  - "ICorProfilerInfo3::GetRuntimeInformation method [.NET Framework profiling]"
ms.assetid: 4400fb8c-0407-4791-8557-f011fd2aee51
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo3::GetRuntimeInformation Method
Provides version information about the common language runtime (CLR) that is being profiled.  
  
## Syntax  
  
```  
HRESULT GetRuntimeInformation(  
       [out] USHORT *pClrInstanceId,  
       [out] COR_PRF_RUNTIME_TYPE *pRuntimeType,  
       [out] USHORT *pMajorVersion,  
       [out] USHORT *pMinorVersion,  
       [out] USHORT *pBuildNumber,  
       [out] USHORT *pQFEVersion,  
       [in]  ULONG  cchVersionString,  
       [out] ULONG  *pcchVersionString,  
       [out, size_is(cchVersionString), length_is(*pcchVersionString)]  
                   WCHAR  szVersionString[]);  
```  
  
#### Parameters  
 `pClrInstanceId`  
 [out] The representative ID of a running CLR instance in a process. This is the same as the `ClrInstanceID` that the event tracing for Windows (ETW) startup event reports.  
  
 `pRuntimeType`  
 [out] The runtime type. This parameter returns `COR_PRF_DESKTOP_CLR` for the desktop version of the CLR, or `COR_PRF_CORE_CLR` for the core version of the CLR used in Silverlight.  
  
 `pMajorVersion`  
 [out] The major version number of the CLR.  
  
 `pMinorVersion`  
 [out] The minor version number of the CLR.  
  
 `pBuildVersion`  
 [out] The build version number of the CLR.  
  
 `pQFEVersion`  
 [out] The version number of the CLR that is associated with a software update.  
  
 `cchVersionString`  
 [in] The length, in characters, of the buffer that `szVersionString` points to.  
  
 `pcchVersionString`  
 [out] The length, in characters, of `szVersionString`.  
  
 `szVersionString`  
 [out] The CLR version string.  
  
## Remarks  
 You may pass null for any parameter. However, `pcchVersionString` cannot be null unless `szVersionString` is also null.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo3 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo3-interface.md)  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)  
 [Profiling](../../../../docs/framework/unmanaged-api/profiling/index.md)

---
description: "Learn more about: ICorProfilerInfo::GetModuleMetaData Method"
title: "ICorProfilerInfo::GetModuleMetaData Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo.GetModuleMetaData"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::GetModuleMetaData"
helpviewer_keywords: 
  - "GetModuleMetaData method [.NET Framework profiling]"
  - "ICorProfilerInfo::GetModuleMetaData method [.NET Framework profiling]"
ms.assetid: 7a439d92-348a-44dd-b60f-cad7cba56379
topic_type: 
  - "apiref"
---
# ICorProfilerInfo::GetModuleMetaData Method

Gets a metadata interface instance that maps to the specified module.  
  
## Syntax  
  
```cpp  
HRESULT GetModuleMetaData(  
    [in]  ModuleID moduleId,  
    [in]  DWORD    dwOpenFlags,  
    [in]  REFIID   riid,  
    [out] IUnknown **ppOut);  
```  
  
## Parameters  

 `moduleId`  
 [in] The ID of the module to which the interface instance will be mapped.  
  
 `dwOpenFlags`  
 [in] A value of the [CorOpenFlags](../metadata/coropenflags-enumeration.md) enumeration that specifies the mode for opening manifest files. Only the `ofRead`, `ofWrite` and `ofNoTransform` bits are valid.  
  
 `riid`  
 [in] The reference ID (GUID) of the metadata interface whose instance will be retrieved. See [Metadata Interfaces](../metadata/metadata-interfaces.md) for a list of the interfaces.  
  
 `ppOut`  
 [out] A pointer to the address of the metadata interface instance.  
  
## Remarks  

 You may ask for the metadata to be opened in read/write mode, but this will result in slower metadata execution of the program, because changes made to the metadata cannot be optimized as they were from the compiler.  
  
 Some modules (such as resource modules) have no metadata. In those cases, `GetModuleMetaData` will return an HRESULT value of S_FALSE, and a null in *`ppOut`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)

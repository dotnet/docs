---
description: "Learn more about: ICorProfilerInfo3::GetStringLayout2 Method"
title: "ICorProfilerInfo3::GetStringLayout2 Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo3.GetStringLayout2 Method"
api_location: 
  - "Mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo3::GetStringLayout2"
helpviewer_keywords: 
  - "ICorProfilerInfo3::GetStringLayout2 method [.NET Framework profiling]"
  - "GetStringLayout2 method [.NET Framework profiling]"
ms.assetid: 1a268496-ee51-4d84-8700-ee56fd0c499d
topic_type: 
  - "apiref"
---
# ICorProfilerInfo3::GetStringLayout2 Method

Gets information about the layout of a string object. This method supersedes the [ICorProfilerInfo2::GetStringLayout](icorprofilerinfo2-getstringlayout-method.md) method.  
  
## Syntax  
  
```cpp  
HRESULT GetStringLayout2(  
    [out] ULONG *pStringLengthOffset,  
    [out] ULONG *pBufferOffset);  
```  
  
## Parameters  

 `pStringLengthOffset`  
 [out] A pointer to the offset of the location, relative to the `ObjectID` pointer, that stores the length of the string itself. The length is stored as a `DWORD`.  
  
 `pBufferOffset`  
 [out] A pointer to the offset of the buffer, relative to the `ObjectID` pointer, which stores the string of wide characters.  
  
## Remarks  

 Strings may or may not be null-terminated.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICorProfilerInfo3 Interface](icorprofilerinfo3-interface.md)
- [Profiling Interfaces](profiling-interfaces.md)

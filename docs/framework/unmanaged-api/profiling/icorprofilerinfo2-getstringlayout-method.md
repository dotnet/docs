---
description: "Learn more about: ICorProfilerInfo2::GetStringLayout Method"
title: "ICorProfilerInfo2::GetStringLayout Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo2.GetStringLayout"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo2::GetStringLayout"
helpviewer_keywords: 
  - "GetStringLayout method [.NET Framework profiling]"
  - "ICorProfilerInfo2::GetStringLayout method [.NET Framework profiling]"
ms.assetid: 43189651-a535-4803-a1d1-f1c427ace2ca
topic_type: 
  - "apiref"
---
# ICorProfilerInfo2::GetStringLayout Method

Gets information about the layout of a string object. This method is deprecated in the .NET Framework 4, and is superseded by the [ICorProfilerInfo3::GetStringLayout2](icorprofilerinfo3-getstringlayout2-method.md) method.  
  
## Syntax  
  
```cpp  
HRESULT GetStringLayout(  
    [out] ULONG *pBufferLengthOffset,  
    [out] ULONG *pStringLengthOffset,  
    [out] ULONG *pBufferOffset);  
```  
  
## Parameters  

 `pBufferLengthOffset`  
 [out] A pointer to the offset of the location, relative to the `ObjectID` pointer, that stores the length of the string. The length is stored as a `DWORD`.  
  
> [!NOTE]
> This parameter returns the length of the string itself, not the length of the buffer. The length of the buffer is no longer available.  
  
 `PStringLengthOffset`  
 [out] A pointer to the offset of the location, relative to the `ObjectID` pointer, that stores the length of the string itself. The length is stored as a `DWORD`.  
  
 `pBufferOffset`  
 [out] A pointer to the offset of the buffer, relative to the `ObjectID` pointer, that stores the string of wide characters.  
  
## Remarks  

 The `GetStringLayout` method gets the offsets, relative to the `ObjectID` pointer, of the locations in which the following are stored:  
  
- The length of the string's buffer.  
  
- The length of the string itself.  
  
- The buffer that contains the actual string of wide characters.  
  
 Strings may be null-terminated.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
- [ICorProfilerInfo2 Interface](icorprofilerinfo2-interface.md)

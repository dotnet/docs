---
description: "Learn more about: ICLRDataTarget3::GetExceptionThreadID Method"
title: "ICLRDataTarget3::GetExceptionThreadID Method"
ms.date: "03/30/2017"
dev_langs: 
  - "cpp"
api_name: 
  - "ICLRDataTarget3.GetExceptionThreadID"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid: 307d6ac7-4a86-45f3-999d-6b47004a68f2
topic_type: 
  - "apiref"
---
# ICLRDataTarget3::GetExceptionThreadID Method

Called by the common language runtime (CLR) data access services to get the ID of the thread that threw the exception.  
  
## Syntax  
  
```cpp  
HRESULT GetExceptionThreadID(  
    [out] ULONG32* threadID  
);  
```  
  
## Parameters  

 `threadID`  
 [out] The ID of the thread that threw the exception.  
  
## Return Value  

 The return value is `S_OK` on success, or a failure `HRESULT` code on failure. The `HRESULT` codes can include but are not limited to the following:  
  
|Return code|Description|  
|-----------------|-----------------|  
|`S_OK`|Method succeeded.|  
|`HRESULT_FROM_WIN32(ERROR_NOT_FOUND)`|Could not find a valid thread ID for the exception.|  
  
## Remarks  

 This method is implemented by the writer of the debugging application.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[v451_update](../../../../includes/net-current-v451-nov-plus.md)]  
  
## See also

- [ICLRDataTarget3 Interface](iclrdatatarget3-interface.md)
- [GetExceptionContextRecord Method](iclrdatatarget3-getexceptioncontextrecord-method.md)
- [GetExceptionRecord Method](iclrdatatarget3-getexceptionrecord-method.md)

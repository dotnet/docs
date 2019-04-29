---
title: "ICLRDataTarget3::GetExceptionRecord Method"
ms.date: "03/30/2017"
dev_langs: 
  - "cpp"
api_name: 
  - "ICLRDataTarget3.GetExceptionRecord"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid: 6643c2af-2ee6-4789-aa25-1d8eaf500c94
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICLRDataTarget3::GetExceptionRecord Method
Called by the common language runtime (CLR) data access services to retrieve the exception record associated with the target process. For example, for a dump target, this would be equivalent to the exception record passed in via the `ExceptionParam` argument to the [MiniDumpWriteDump](/windows/desktop/api/minidumpapiset/nf-minidumpapiset-minidumpwritedump) function in the Windows Debug Help Library (DbgHelp).  
  
## Syntax  
  
```cpp  
HRESULT GetExceptionRecord(  
    [in] ULONG32 bufferSize,  
    [out] ULONG32* bufferUsed,  
    [out, size_is(bufferSize] BYTE* buffer  
);  
```  
  
## Parameters  
 `bufferSize`  
 [in] The input buffer size, in bytes. This must be equal to `sizeof(`[MINIDUMP_EXCEPTION](/windows/desktop/api/minidumpapiset/ns-minidumpapiset-_minidump_exception)`)`.  
  
 `bufferUsed`  
 [out] A pointer to a `ULONG32` type that receives the number of bytes actually written to the buffer.  
  
 `buffer`  
 [out] A pointer to a memory buffer that receives a copy of the exception record. The exception record is returned as a [MINIDUMP_EXCEPTION](/windows/desktop/api/minidumpapiset/ns-minidumpapiset-_minidump_exception) type.  
  
## Return Value  
 The return value is `S_OK` on success, or a failure `HRESULT` code on failure. The `HRESULT` codes can include but are not limited to the following:  
  
|Return code|Description|  
|-----------------|-----------------|  
|`S_OK`|Method succeeded. The exception record has been copied to the output buffer.|  
|`HRESULT_FROM_WIN32(ERROR_NOT_FOUND)`|No exception record is associated with the target.|  
|`HRESULT_FROM_WIN32(ERROR_BAD_LENGTH)`|The input buffer size is not equal to `sizeof(MINIDUMP_EXCEPTION)`.|  
  
## Remarks  
 [MINIDUMP_EXCEPTION](/windows/desktop/api/minidumpapiset/ns-minidumpapiset-_minidump_exception) is a structure defined in dbghelp.h and imagehlp.h in the Windows SDK.  
  
 This method is implemented by the writer of the debugging application.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[v451_update](../../../../includes/net-current-v451-nov-plus.md)]  
  
## See also

- [ICLRDataTarget3 Interface](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget3-interface.md)
- [GetExceptionContextRecord Method](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget3-getexceptioncontextrecord-method.md)
- [GetExceptionThreadID Method](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget3-getexceptionthreadid-method.md)

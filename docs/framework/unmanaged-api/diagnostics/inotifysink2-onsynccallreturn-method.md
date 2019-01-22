---
title: "INotifySink2::OnSyncCallReturn Method"
ms.date: "03/30/2017"
api_name: 
  - "INotifySink2.OnSyncCallReturn"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "INotifySink2::OnSyncCallReturn"
helpviewer_keywords: 
  - "OnSyncCallReturn method [.NET Framework debugging]"
  - "INotifySink2::OnSyncCallReturn method [.NET Framework debugging]"
ms.assetid: c1bda761-6292-4750-a14b-7d5db8f33456
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# INotifySink2::OnSyncCallReturn Method
Gets invoked when a call returns.  
  
## Syntax  
  
```  
HRESULT OnSyncCallReturn  
(  
    [in]  CALL_ID   in_CallID,  
    [in, size_is(in_BufferSize)] BYTE*  in_pBuffer,  
    [in]  DWORD     in_BufferSize  
);  
```  
  
#### Parameters  
 `in_CallID`  
 [in] ID of the call being returned from. See [CALL_ID Structure](../../../../docs/framework/unmanaged-api/diagnostics/call-id-structure.md).  
  
 `in_pBuffer`  
 [in] Call buffer.  
  
 `in_BufferSize`  
 [in] Size of the call buffer, in bytes.  
  
## Return Value  
 S_OK if the method succeeds.  
  
## Requirements  
 **Header:** ProtocolNotify2.idl  
  
## See also
 [INotifySink2 Interface](../../../../docs/framework/unmanaged-api/diagnostics/inotifysink2-interface.md)  
 [INotifySource2 Interface](../../../../docs/framework/unmanaged-api/diagnostics/inotifysource2-interface.md)  
 [INotifyConnection2 Interface](../../../../docs/framework/unmanaged-api/diagnostics/inotifyconnection2-interface.md)

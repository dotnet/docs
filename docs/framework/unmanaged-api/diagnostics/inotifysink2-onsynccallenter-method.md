---
description: "Learn more about: INotifySink2::OnSyncCallEnter Method"
title: "INotifySink2::OnSyncCallEnter Method"
ms.date: "03/30/2017"
api_name: 
  - "INotifySink2.OnSyncCallEnter"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "INotifySink2::OnSyncCallEnter"
helpviewer_keywords: 
  - "INotifySink2::OnSyncCallEnter method [.NET Framework debugging]"
  - "OnSyncCallEnter method [.NET Framework debugging]"
ms.assetid: e33265be-c25d-4145-ad02-c3e89d6f26c1
topic_type: 
  - "apiref"
---
# INotifySink2::OnSyncCallEnter Method

Gets invoked when entering a call.  
  
## Syntax  
  
```cpp  
HRESULT OnSyncCallEnter  
(  
    [in]  CALL_ID   in_CallID,  
    [in, size_is(in_BufferSize)] BYTE*  in_pBuffer,  
    [in]  DWORD     in_BufferSize  
);  
```  
  
## Parameters  

 `in_CallID`  
 [in] ID of the call being entered. See [CALL_ID Structure](call-id-structure.md).  
  
 `in_pBuffer`  
 [in] Call buffer.  
  
 `in_BufferSize`  
 [in] Size of the call buffer, in bytes.  
  
## Return Value  

 S_OK if the method succeeds.  
  
## Requirements  

 **Header:** ProtocolNotify2.idl  
  
## See also

- [INotifySink2 Interface](inotifysink2-interface.md)
- [INotifySource2 Interface](inotifysource2-interface.md)
- [INotifyConnection2 Interface](inotifyconnection2-interface.md)

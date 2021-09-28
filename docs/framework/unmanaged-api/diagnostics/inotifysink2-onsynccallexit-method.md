---
description: "Learn more about: INotifySink2::OnSyncCallExit Method"
title: "INotifySink2::OnSyncCallExit Method"
ms.date: "03/30/2017"
api_name: 
  - "INotifySink2.OnSyncCallExit"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "INotifySink2::OnSyncCallExit"
helpviewer_keywords: 
  - "INotifySink2::OnSyncCallExit method [.NET Framework debugging]"
  - "OnSyncCallExit method [.NET Framework debugging]"
ms.assetid: d9d7600e-a8f5-443a-96de-67d26e130f2d
topic_type: 
  - "apiref"
---
# INotifySink2::OnSyncCallExit Method

Gets invoked when exiting a call.  
  
## Syntax  
  
```cpp  
HRESULT OnSyncCallExit  
(  
    [in]  CALL_ID   in_CallID,  
    [out, size_is(, *out_pBufferSize)] BYTE**  out_ppBuffer,  
    [out] DWORD*    out_pBufferSize  
);  
```  
  
## Parameters  

 `in_CallID`  
 [in] ID of the call being exited. See [CALL_ID Structure](call-id-structure.md).  
  
 `out_ppBuffer`  
 [out] Call buffer.  
  
 `out_pBufferSize`  
 [out] Size of the call buffer, in bytes.  
  
## Return Value  

 S_OK if the method succeeds.  
  
## Requirements  

 **Header:** ProtocolNotify2.idl  
  
## See also

- [INotifySink2 Interface](inotifysink2-interface.md)
- [INotifySource2 Interface](inotifysource2-interface.md)
- [INotifyConnection2 Interface](inotifyconnection2-interface.md)

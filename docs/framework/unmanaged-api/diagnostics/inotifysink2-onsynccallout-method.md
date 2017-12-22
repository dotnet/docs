---
title: "INotifySink2::OnSyncCallOut Method"
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
  - "INotifySink2.OnSyncCallOut"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "INotifySink2::OnSyncCallOut"
helpviewer_keywords: 
  - "INotifySink2::OnSyncCallOut method [.NET Framework debugging]"
  - "OnSyncCallOut method [.NET Framework debugging]"
ms.assetid: 97f15656-8677-4079-8553-a1d8603355d6
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# INotifySink2::OnSyncCallOut Method
Gets invoked when a call is out.  
  
## Syntax  
  
```  
HRESULT OnSyncCallOut  
(  
    [in]  CALL_ID  in_CallID,  
    [out, size_is(, *out_pBufferSize)] BYTE**  out_ppBuffer,  
    [out] DWORD*   out_pBufferSize  
);  
```  
  
#### Parameters  
 `in_CallID`  
 [in] ID of the call that is out. See [CALL_ID Structure](../../../../docs/framework/unmanaged-api/diagnostics/call-id-structure.md).  
  
 `out_ppBuffer`  
 [out] Call buffer.  
  
 `out_pBufferSize`  
 [out] Size of the call buffer, in bytes.  
  
## Return Value  
 S_OK if the method succeeds.  
  
## Requirements  
 **Header:** ProtocolNotify2.idl  
  
## See Also  
 [INotifySink2 Interface](../../../../docs/framework/unmanaged-api/diagnostics/inotifysink2-interface.md)  
 [INotifySource2 Interface](../../../../docs/framework/unmanaged-api/diagnostics/inotifysource2-interface.md)  
 [INotifyConnection2 Interface](../../../../docs/framework/unmanaged-api/diagnostics/inotifyconnection2-interface.md)

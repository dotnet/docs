---
title: "INotifyConnection2::RegisterNotifySource Method"
ms.date: "03/30/2017"
api_name: 
  - "INotifyConnection2.RegisterNotifySource"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "INotifyConnection2::RegisterNotifySource"
helpviewer_keywords: 
  - "INotifyConnection2::RegisterNotifySource method [.NET Framework debugging]"
  - "RegisterNotifySource method [.NET Framework debugging]"
ms.assetid: 2632da80-6e4b-4429-8dee-b382745a5f81
topic_type: 
  - "apiref"
---
# INotifyConnection2::RegisterNotifySource Method
Installs a specified notification source.  
  
## Syntax  
  
```cpp  
HRESULT RegisterNotifySource  
(  
    [in]  INotifySource2*  in_pNotifySource,  
    [out] INotifySink2**   out_ppNotifySink  
);  
```  
  
## Parameters  
 `in_pNotifySource`  
 [in] Specifies the object to be used as the notification source.  
  
 `out_ppNotifySink`  
 [out] Receives the object to be used as the notification sink.  
  
## Return Value  
 S_OK if the method succeeds.  
  
## Requirements  
 **Header:** ProtocolNotify2.idl  
  
## See also

- [INotifyConnection2 Interface](../../../../docs/framework/unmanaged-api/diagnostics/inotifyconnection2-interface.md)
- [INotifySource2 Interface](../../../../docs/framework/unmanaged-api/diagnostics/inotifysource2-interface.md)
- [INotifySink2 Interface](../../../../docs/framework/unmanaged-api/diagnostics/inotifysink2-interface.md)
- [UnregisterNotifySource Method](../../../../docs/framework/unmanaged-api/diagnostics/inotifyconnection2-unregisternotifysource-method.md)

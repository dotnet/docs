---
title: "INotifyConnection2::UnregisterNotifySource Method"
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
  - "INotifyConnection2.UnregisterNotifySource"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "INotifyConnection2::UnregisterNotifySource"
helpviewer_keywords: 
  - "INotifyConnection2::UnregisterNotifySource method [.NET Framework debugging]"
  - "UnregisterNotifySource method [.NET Framework debugging]"
ms.assetid: 2fc6c715-646f-41fd-9c12-c59b40575269
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# INotifyConnection2::UnregisterNotifySource Method
Removes a specified notification source object from the connection.  
  
## Syntax  
  
```  
HRESULT UnregisterNotifySource  
(  
    [in]  INotifySource2*  in_pNotifySource  
);  
```  
  
#### Parameters  
 `in_pNotifySource`  
 [in] Notification object to be unregistered.  
  
## Return Value  
 S_OK if the method succeeds.  
  
## Requirements  
 **Header:** ProtocolNotify2.idl  
  
## See Also  
 [INotifyConnection2 Interface](../../../../docs/framework/unmanaged-api/diagnostics/inotifyconnection2-interface.md)  
 [INotifySource2 Interface](../../../../docs/framework/unmanaged-api/diagnostics/inotifysource2-interface.md)  
 [INotifySink2 Interface](../../../../docs/framework/unmanaged-api/diagnostics/inotifysink2-interface.md)  
 [RegisterNotifySource Method](../../../../docs/framework/unmanaged-api/diagnostics/inotifyconnection2-registernotifysource-method.md)

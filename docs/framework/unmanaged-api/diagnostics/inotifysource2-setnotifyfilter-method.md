---
description: "Learn more about: INotifySource2::SetNotifyFilter Method"
title: "INotifySource2::SetNotifyFilter Method"
ms.date: "03/30/2017"
api_name: 
  - "INotifySource2.SetNotifyFilter"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "INotifySource2::SetNotifyFilter"
helpviewer_keywords: 
  - "INotifySource2::SetNotifyFilter method [.NET Framework debugging]"
  - "SetNotifyFilter method [.NET Framework debugging]"
ms.assetid: 6351fc92-b126-4af6-9bf3-0a8ce92845fc
topic_type: 
  - "apiref"
---
# INotifySource2::SetNotifyFilter Method

Assigns a notification filter for use with this source.  
  
## Syntax  
  
```cpp  
HRESULT SetNotifyFilter  
(  
    [in]  NOTIFY_FILTER   in_NotifyFilter,  
    [in]  USER_THREAD*    in_pUserThreadFilter  
);  
```  
  
## Parameters  

 `in_NotifyFilter`  
 [in] A bitwise combination of the [NOTIFY_FILTER](notify-filter-enumeration.md) enumeration values that identify callbacks for the debugger API.  
  
 `in_pUserThreadFilter`  
 [in] A pointer to a [USER_THREAD](user-thread-structure.md) structure that identifies threads for the debugger API.  
  
## Return Value  

 S_OK if the method succeeds.  
  
## Requirements  

 **Header:** ProtocolNotify2.idl  
  
## See also

- [INotifySource2 Interface](inotifysource2-interface.md)
- [INotifyConnection2 Interface](inotifyconnection2-interface.md)
- [INotifySink2 Interface](inotifysink2-interface.md)

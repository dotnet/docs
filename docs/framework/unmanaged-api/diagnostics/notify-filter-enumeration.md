---
description: "Learn more about: NOTIFY_FILTER Enumeration"
title: "NOTIFY_FILTER Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "NOTIFY_FILTER"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "NOTIFY_FILTER"
helpviewer_keywords: 
  - "NOTIFY_FILTER enumeration [.NET Framework debugging]"
ms.assetid: 4789d08f-8683-45d3-ac30-73d48c61e470
topic_type: 
  - "apiref"
---
# NOTIFY_FILTER Enumeration

Identifies callbacks for debugger functions. For more information, see the [INotifySource2::SetNotifyFilter](inotifysource2-setnotifyfilter-method.md) method.  
  
## Syntax  
  
```cpp  
enum tagNOTIFY_FILTER  
{  
    NOTIFY_FILTER_ONSYNCCALLOUT    = 0x1,  
    NOTIFY_FILTER_ONSYNCCALLENTER  = 0x2,  
    NOTIFY_FILTER_ONSYNCCALLEXIT   = 0x4,  
    NOTIFY_FILTER_ONSYNCCALLRETURN = 0x8,  
    NOTIFY_FILTER_ALLSYNC = NOTIFY_FILTER_ONSYNCCALLOUT | NOTIFY_FILTER_ONSYNCCALLENTER | NOTIFY_FILTER_ONSYNCCALLEXIT | NOTIFY_FILTER_ONSYNCCALLRETURN,  
    NOTIFY_FILTER_ALL              = 0xffffffff,  
    NOTIFY_FILTER_NONE             = 0  
};  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`NOTIFY_FILTER_ONSYNCCALLOUT`|Indicates that the [INotifySink2::OnSyncCallOut](inotifysink2-onsynccallout-method.md) method should be invoked.|  
|`NOTIFY_FILTER_ONSYNCCALLENTER`|Indicates that the [INotifySink2::OnSyncCallEnter](inotifysink2-onsynccallenter-method.md) method should be invoked.|  
|`NOTIFY_FILTER_ONSYNCCALLEXIT`|Indicates that the [INotifySink2::OnSyncCallExit](inotifysink2-onsynccallexit-method.md) method should be invoked.|  
|`NOTIFY_FILTER_ONSYNCCALLRETURN`|Indicates that the [INotifySink2::OnSyncCallReturn](inotifysink2-onsynccallreturn-method.md) method should be invoked.|  
|`NOTIFY_FILTER_ALLSYNC`|Indicates that all of the [INotifySink2](inotifysink2-interface.md) methods should be invoked.|  
|`NOTIFY_FILTER_ALL`|Activates all existing and future notifications.|  
|`NOTIFY_FILTER_NONE`|Indicates that no notification methods should be invoked.|  
  
## Requirements  

 **Header:** ProtocolNotify2.idl  
  
## See also

- [Diagnostics Symbol Store Enumerations](diagnostics-symbol-store-enumerations.md)

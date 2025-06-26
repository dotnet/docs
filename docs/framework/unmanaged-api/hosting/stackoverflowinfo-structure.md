---
description: "Learn more about: StackOverflowInfo Structure"
title: "StackOverflowInfo Structure"
ms.date: "03/30/2017"
api_name: 
  - "StackOverflowInfo"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "StackOverflowInfo"
helpviewer_keywords: 
  - "StackOverflowInfo structure [.NET Framework hosting]"
ms.assetid: 519389f2-0217-436c-99d4-93a76ebce5b5
topic_type: 
  - "apiref"
---
# StackOverflowInfo Structure

Stores the type of overflow that occurred and information on the exception that was thrown due to the overflow.  
  
## Syntax  
  
```cpp  
typedef struct _StackOverflowInfo {  
    StackOverflowType   soType;  
    EXCEPTION_POINTERS  *pExceptionInfo;  
} StackOverflowInfo;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`soType`|A value of the [StackOverflowType](stackoverflowtype-enumeration.md) enumeration that specifies the type of overflow.|  
|`pExceptionInfo`|A pointer to a Win32 `EXCEPTION_POINTERS` object, which contains an exception record with a machine-independent description of an exception and a context record with a machine-dependent description of the processor context at the time of the exception.|  
  
## Remarks  

 A `StackOverflowInfo` object is passed to the [IActionOnCLREvent::OnEvent](iactiononclrevent-onevent-method.md) method for `Event_StackOverflow` events.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.idl  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Hosting Structures](hosting-structures.md)

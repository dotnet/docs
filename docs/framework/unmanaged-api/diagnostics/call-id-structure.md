---
description: "Learn more about: CALL_ID Structure"
title: "CALL_ID Structure"
ms.date: "03/30/2017"
api_name: 
  - "CALL_ID"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CALL_ID"
helpviewer_keywords: 
  - "CALL_ID structure [.NET Framework debugging]"
ms.assetid: bfd46324-afec-4782-9c18-586d81fb4740
topic_type: 
  - "apiref"
---
# CALL_ID Structure

Provides information to a debugger about a function that is being called. See the [INotifySink2](inotifysink2-interface.md) interface for more information.  
  
## Syntax  
  
```cpp  
typedef struct tagCALL_ID  
{  
    LPCOLESTR       szMachine;  
    DWORD           dwPid;  
    USER_THREAD     *pUserThread;  
    STACK_ADDRESS   addrStackPointer;  
    LPCOLESTR       szEntryPoint;  
    LPCOLESTR       szDestinationMachine;  
} CALL_ID;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`szMachine`|Identifies the machine that is making the call.|  
|`dwPid`|Identifies the machine processor.|  
|`pUserThread`|Identifies the thread that is executing the call.|  
|`addrStackPointer`|Specifies the address of the call stack.|  
|`szEntryPoint`|Specifies the address of the call.|  
|`szDestinationMachine`|Identifies the machine that will execute the call.|  
  
## Requirements  

 **Header:** ProtocolNotify2.idl  
  
## See also

- [INotifySink2 Interface](inotifysink2-interface.md)
- [Diagnostics Symbol Store Structures](diagnostics-symbol-store-structures.md)

---
title: GetDemultiplexedStub function (Unmanaged API Reference)
description: The GetDemultiplexedStub function creates an object forwarder sink to assist a client in receiving asynchronous calls from Windows Management.
ms.date: "11/06/2017"
api_name: 
  - "GetDemultiplexedStub"
api_location: 
  - "WMINet_Utils.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetDemultiplexedStub"
helpviewer_keywords: 
  - "GetDemultiplexedStub function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
---
# GetDemultiplexedStub function
Creates an object forwarder sink to assist a client in receiving asynchronous calls from Windows Management.
  
[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]
  
## Syntax  
  
```cpp  
HRESULT GetDemultiplexedStub (
   [in] IUnknown*    pObject, 
   [in] boolean      isLocal, 
   [out] IUnknown**  ppObject
); 
```  

## Parameters

`pObject`  
[in] A pointer to the client's in-process implementation of [IWbemObjectSink](/windows/desktop/api/wbemcli/nn-wbemcli-iwbemobjectsink).

`isLocal`  
[in] A flag that indicates whether the event is local (`true`); otherwise, `false`.

`ppObject`  
[out] A object forwarder sink to assist a client in receiving asynchronous calls from Windows Management.

## Return value

If the function succeeds, the return value is `S_OK` (0).

If the function fails, the return value is a non-zero error code. To get extended error information, call the [GetErrorInfo](geterrorinfo.md) function.
    
## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** WMINet_Utils.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]  
  
## See also

- [WMI and Performance Counters (Unmanaged API Reference)](index.md)

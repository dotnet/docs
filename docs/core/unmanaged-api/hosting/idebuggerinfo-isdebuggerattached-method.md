---
description: "Learn more about: IDebuggerInfo::IsDebuggerAttached Method"
title: "IDebuggerInfo::IsDebuggerAttached Method"
ms.date: "03/30/2017"
api_name: 
  - "IDebuggerInfo.IsDebuggerAttached"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IsDebuggerAttached"
helpviewer_keywords: 
  - "IDebuggerInfo::IsDebuggerAttached method [.NET Framework hosting]"
  - "IsDebuggerAttached method, IDebuggerInfo interface [.NET Framework hosting]"
ms.assetid: 6e21872f-602f-411a-a423-bff5cdf27000
topic_type: 
  - "apiref"
---
# IDebuggerInfo::IsDebuggerAttached Method

Gets a value that indicates whether a managed debugger is attached to this process.  
  
## Syntax  
  
```cpp  
HRESULT IsDebuggerAttached (  
    [out] BOOL *pbAttached  
);  
```  
  
## Parameters  

 `pbAttached`  
 [out] A pointer to a value that is `true` if a managed debugger is attached to the process; otherwise, `false`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IDebuggerInfo Interface](idebuggerinfo-interface.md)

---
description: "Learn more about: CorMarkThreadInThreadPool Function"
title: "CorMarkThreadInThreadPool Function"
ms.date: "03/30/2017"
api_name: 
  - "CorMarkThreadInThreadPool"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CorMarkThreadInThreadPool"
helpviewer_keywords: 
  - "CorMarkThreadInThreadPool function [.NET Framework hosting]"
ms.assetid: 3f958d41-e82e-4ec3-ae6f-16c7b3b31e3e
topic_type: 
  - "apiref"
---
# CorMarkThreadInThreadPool Function

Marks the currently executing thread-pool thread for the execution of managed code. Starting with the .NET Framework version 2.0, this function has no effect. It is not required, and can be removed from your code. This function is deprecated in the .NET Framework 4.  
  
## Syntax  
  
```cpp  
void CorMarkThreadInThreadPool ();  
```  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md)

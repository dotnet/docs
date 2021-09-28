---
description: "Learn more about: EClrUnhandledException Enumeration"
title: "EClrUnhandledException Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "EClrUnhandledException"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "EClrUnhandledException"
helpviewer_keywords: 
  - "EClrUnhandledException enumeration [.NET Framework hosting]"
ms.assetid: d231044e-2b53-4836-93f9-8117ff0e5c3a
topic_type: 
  - "apiref"
---
# EClrUnhandledException Enumeration

Describes the available options for managing exceptions that are unhandled in user code.  
  
## Syntax  
  
```cpp  
typedef enum {  
    eRuntimeDeterminedPolicy,  
    eHostDeterminedPolicy  
} EClrUnhandledException;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`eRuntimeDeterminedPolicy`|Specifies that the default behavior occurs. The process is torn down.|  
|`eHostDeterminedPolicy`|Specifies that the common language runtime (CLR) ignores unhandled exceptions and lets the host determine any further action.|  
  
## Remarks  

 To specify that the CLR behave like earlier versions, use the `eHostDeterminedPolicy` member.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [EClrFailure Enumeration](eclrfailure-enumeration.md)
- [EClrOperation Enumeration](eclroperation-enumeration.md)
- [ICLRPolicyManager Interface](iclrpolicymanager-interface.md)
- [SetUnhandledExceptionPolicy Method](iclrpolicymanager-setunhandledexceptionpolicy-method.md)
- [IHostPolicyManager Interface](ihostpolicymanager-interface.md)
- [Hosting Enumerations](hosting-enumerations.md)

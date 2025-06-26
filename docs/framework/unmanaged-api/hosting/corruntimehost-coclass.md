---
description: "Learn more about: CorRuntimeHost Coclass"
title: "CorRuntimeHost Coclass"
ms.date: "03/30/2017"
api_name: 
  - "CorRuntimeHost Coclass"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorRuntimeHost"
helpviewer_keywords: 
  - "CoRuntimeHost coclass [.NET Framework hosting]"
ms.assetid: 5833740b-7d67-44b4-865c-b5bf45e291e3
topic_type: 
  - "apiref"
---
# CorRuntimeHost Coclass

Provides interfaces for managing applications that are being executed by the common language runtime.  
  
## Syntax  
  
```cpp  
coclass CorRuntimeHost {  
    [default] interface ICorRuntimeHost;  
    interface IGCHost;  
    interface ICorConfiguration;  
    interface IValidator;  
    interface IDebuggerInfo;  
};  
```  
  
## Interfaces  
  
|Interface|Description|  
|---------------|-----------------|  
|[ICorConfiguration Interface](icorconfiguration-interface.md)|Provides methods for configuring the common language runtime (CLR).|  
|[ICorRuntimeHost Interface](icorruntimehost-interface.md)|Provides methods that enable the host to start and stop the common language runtime explicitly, to create and configure application domains, to access the default domain, and to enumerate all domains running in the process.|  
|[IDebuggerInfo Interface](idebuggerinfo-interface.md)|Provides methods for obtaining information about the state of the debugging services.|  
|[IGCHost Interface](igchost-interface.md)|Provides methods for obtaining information about the garbage collection system and for controlling some aspects of garbage collection.|  
|"IValidator"|Provides methods for validation of portable executable images and detailed reporting of validation errors.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.idl  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Hosting Coclasses](hosting-coclasses.md)

---
title: "METAHOST_POLICY_FLAGS Enumeration"
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
  - "METAHOST_POLICY_FLAGS"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "METAHOST_POLICY_FLAGS"
helpviewer_keywords: 
  - "METAHOST_POLICY_FLAGS enumeration [.NET Framework hosting]"
ms.assetid: 3bb4b526-0118-42e2-ba59-c95648528ce9
topic_type: 
  - "apiref"
caps.latest.revision: 21
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# METAHOST_POLICY_FLAGS Enumeration
Provides binding policies that are common to most runtime hosts. This enumeration is used by the [ICLRMetaHostPolicy::GetRequestedRuntime](../../../../docs/framework/unmanaged-api/hosting/iclrmetahostpolicy-getrequestedruntime-method.md) method.  
  
## Syntax  
  
```  
typedef enum {  
    METAHOST_POLICY_HIGHCOMPAT              = 0x00,  
    METAHOST_POLICY_APPLY_UPGRADE_POLICY    = 0x08,  
    METAHOST_POLICY_EMULATE_EXE_LAUNCH      = 0x10,  
    METAHOST_POLICY_SHOW_ERROR_DIALOG       = 0x20,  
    METAHOST_POLICY_USE_PROCESS_IMAGE_PATH  = 0x40,  
    METAHOST_POLICY_ENSURE_SKU_SUPPORTED    = 0x80,  
    METAHOST_POLICY_IGNORE_ERROR_MODE       = 0x1000  
  
} METAHOST_POLICY_FLAGS;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`METAHOST_POLICY_HIGHCOMPAT`|Defines the high-compatibility policy, which does not consider any common language runtime (CLR) that is loaded into the current process. Instead, it considers only the installed CLRs and the preferences of the component, as derived from the assembly file itself, the declared built-against version, or the configuration file.|  
|`METAHOST_POLICY_APPLY_UPGRADE_POLICY`|Applies upgrade policy to the version bind result when an exact match is not found, based on the contents of HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\\.NETFramework\Policy\Upgrades. This has the same effect as [RUNTIME_INFO_UPGRADE_VERSION](../../../../docs/framework/unmanaged-api/hosting/runtime-info-flags-enumeration.md).|  
|`METAHOST_POLICY_EMULATE_EXE_LAUNCH`|Binding results are returned as if the image provided to the call were launched in a new process. Currently, `GetRequestedRuntime` ignores the set of loadable runtimes and binds against the set of installed runtimes. This flag allows a host to determine which runtime an EXE will bind to when it is launched.|  
|`METAHOST_POLICY_SHOW_ERROR_DIALOG`|An error dialog box is displayed if `GetRequestedRuntime` is unable to find a runtime that is compatible with the input parameters. Beginning with the [!INCLUDE[net_v45](../../../../includes/net-v45-md.md)], this error dialog box can take the form of a Windows feature dialog box that asks whether the user would like to enable the appropriate feature.|  
|`METAHOST_POLICY_USE_PROCESS_IMAGE_PATH`|`GetRequestedRuntime` uses the process image (and any corresponding configuration file) as additional input to the binding process. By default, `GetRequestedRuntime` does not fall back to the process image path (typically, the EXE that was used to launch the process) when determining the runtime to bind to.|  
|`METAHOST_POLICY_ENSURE_SKU_SUPPORTED`|`GetRequestedRuntime` must check whether the appropriate SKU is installed when no information is available in the configuration file. This allows applications that do not have configuration files to fail gracefully on smaller SKUs than the default installation of the .NET Framework. By default, `GetRequestedRuntime` does not check whether the appropriate SKU is installed unless the SKU attribute is specified in the configuration file `<supportedRuntime />` element.|  
|`METAHOST_POLICY_ENSURE_SKU_SUPPORTED`|`GetRequestedRuntime` must check whether the appropriate SKU is installed when no information is available in the configuration file. This allows applications that do not have configuration files to fail gracefully on smaller SKUs than the default installation of the .NET Framework. By default, `GetRequestedRuntime` does not check whether the appropriate SKU is installed unless the SKU attribute is specified in the configuration file `<supportedRuntime />` element.|  
|`METAHOST_POLICY_IGNORE_ERROR_MODE`|`GetRequestedRuntime` should ignore SEM_FAILCRITICALERRORS (which is set by calling the [SetErrorMode](http://go.microsoft.com/fwlink/p/?LinkId=255242) function), and show the error dialog box. By default, SEM_FAILCRITICALERRORS suppresses the error dialog box. It may have been inherited from another process, and the silent error may be undesirable in your scenario.|  
  
## Remarks  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Metahost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [Hosting Enumerations](../../../../docs/framework/unmanaged-api/hosting/hosting-enumerations.md)  
 [GetRequestedRuntime Method](../../../../docs/framework/unmanaged-api/hosting/iclrmetahostpolicy-getrequestedruntime-method.md)

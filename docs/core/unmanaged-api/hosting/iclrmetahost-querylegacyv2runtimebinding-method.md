---
description: "Learn more about: ICLRMetaHost::QueryLegacyV2RuntimeBinding Method"
title: "ICLRMetaHost::QueryLegacyV2RuntimeBinding Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRMetaHost.RequestRuntimeLoadedNotification"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRMetaHost::QueryLegacyV2RuntimeBinding"
helpviewer_keywords: 
  - "QueryLegacyV2RuntimeBinding method [.NET Framework hosting]"
  - "ICLRMetaHost::QueryLegacyV2RuntimeBinding method [.NET Framework hosting]"
ms.assetid: 9929817e-acc9-40b7-960c-598664e04b60
topic_type: 
  - "apiref"
---
# ICLRMetaHost::QueryLegacyV2RuntimeBinding Method

Returns an interface that represents a runtime to which legacy activation policy has been bound, for example, by using the `useLegacyV2RuntimeActivationPolicy` attribute on the [\<startup> element](../../configure-apps/file-schema/startup/startup-element.md) configuration file entry, by direct use of the legacy activation APIs, or by calling the [ICLRRuntimeInfo::BindAsLegacyV2Runtime](iclrruntimeinfo-bindaslegacyv2runtime-method.md) method.  
  
## Syntax  
  
```cpp  
HRESULT QueryLegacyV2RuntimeBinding (  
    [in] REFIID riid,  
    [out, iid_is(riid), retval] LPVOID *ppUnk);  
```  
  
## Parameters  

 `riid`  
 [in] Required.Currently the only valid value for this parameter is `IID_ICLRRuntimeInfo`.  
  
 `ppUnk`  
 [out] Required. When this method returns, contains a pointer to the [ICLRRuntimeInfo](iclrruntimeinfo-interface.md) interface that represents a runtime that has been bound to legacy activation policy.  
  
## Return Value  

 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully and returned a runtime that was bound to legacy activation policy.|  
|S_FALSE|The method completed successfully, but a legacy runtime has not yet been bound.|  
|E_NOINTERFACE|The method found a runtime that was bound to legacy activation policy, but `riid` is not supported by that runtime.|  
  
## Remarks  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICLRMetaHost Interface](iclrmetahost-interface.md)
- [Hosting](index.md)

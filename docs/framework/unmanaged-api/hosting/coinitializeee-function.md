---
description: "Learn more about: CoInitializeEE Function"
title: "CoInitializeEE Function"
ms.date: "03/30/2017"
api_name: 
  - "CoInitializeEE"
api_location: 
  - "mscoree.dll"
  - "mscorsvr.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CoInitializeEE"
helpviewer_keywords: 
  - "CoInitializeEE function [.NET Framework hosting]"
ms.assetid: 7e42a928-5068-4ba6-b8c3-806551a01fa8
topic_type: 
  - "apiref"
---
# CoInitializeEE Function

Ensures that the common language runtime execution engine is loaded into a process. This function is deprecated in the .NET Framework 4. Use the [ICLRRuntimeHost::Start](iclrruntimehost-start-method.md) method instead.  
  
## Syntax  
  
```cpp  
HRESULT CoInitializeEE (  
   [in] DWORD fFlags  
);  
```  
  
## Parameters  

 `fFlags`  
 [in] One of the [COINITIEE](../metadata/coinitiee-enumeration.md) enumeration constants.  
  
## Return Value  

 This method returns standard COM error codes as defined in Winerror.h, and the values in the following table.  
  
|Return code|Description|  
|-----------------|-----------------|  
|S_OK|The execution engine was loaded successfully.|  
|S_FALSE|The execution engine is already loaded.|  
|E_FAIL|The execution engine could not be loaded.|  
  
## Remarks  

 This method loads the execution engine if it has not been previously loaded.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Global Static Functions](../metadata/metadata-global-static-functions.md)

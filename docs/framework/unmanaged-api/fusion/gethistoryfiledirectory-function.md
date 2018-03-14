---
title: "GetHistoryFileDirectory Function"
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
  - "GetHistoryFileDirectory"
api_location: 
  - "fusion.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetHistoryFileDirectory"
helpviewer_keywords: 
  - "GetHistoryFileDirectory function [.NET Framework fusion]"
ms.assetid: 93232222-926e-42ac-b85d-8a6d33977672
topic_type: 
  - "apiref"
caps.latest.revision: 5
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# GetHistoryFileDirectory Function
Retrieves the path of the application history directory.  
  
## Syntax  
  
```  
HRESULT GetHistoryFileDirectory (  
    [in]      LPWSTR      wzDir,  
    [in,out]  LPCWSTR  *pdwsize,  
);  
```  
  
#### Parameters  
 `wzDir`  
 [out] A buffer to hold the path to the application history directory.  
  
 `pdwSize`  
 [in, out] The length of the buffer.  
  
## Return Value  
 This method returns standard COM error codes, as defined in the WinError.h file in addition to the following values.  
  
|Return code|Description|  
|-----------------|-----------------|  
|S_OK|The method completed successfully.|  
|E_INVALIDARG|`wzDir` or `pdwSize` is null, or the version string is incorrect.|  
  
## Remarks  
 On successful completion, the `pdwSize` argument is set to the length of the path string.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **Library:** Fusion.dll and Mscorwks.dll. Use Fusion.dll instead of Mscorwks.dll to ensure that you target the correct version of the .NET Framework.  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v11plus](../../../../includes/net-current-v11plus-md.md)]  
  
## See Also  
 [CreateHistoryReader Function](../../../../docs/framework/unmanaged-api/fusion/createhistoryreader-function.md)  
 [NukeDownloadedCache Function](../../../../docs/framework/unmanaged-api/fusion/nukedownloadedcache-function.md)  
 [Fusion Global Static Functions](../../../../docs/framework/unmanaged-api/fusion/fusion-global-static-functions.md)

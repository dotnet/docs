---
title: "CoUninitializeEE Function"
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
  - "CoUninitializeEE"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CoUninitializeEE"
helpviewer_keywords: 
  - "CoUninitializeEE function [.NET Framework hosting]"
ms.assetid: 5f5a311a-839a-465f-89d9-ff1c74da9736
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CoUninitializeEE Function
`CoUninitializeEE` is obsolete and provides no functionality.  
  
## Syntax  
  
```  
void CoUninitializeEE (  
    BOOL fFlags  
);  
```  
  
## Remarks  
 The common language runtime execution engine cannot be unloaded from a process. To shut down the execution engine call [CorExitProcess](../../../../docs/framework/unmanaged-api/hosting/corexitprocess-function.md).  
  
## See Also  
 [CoInitializeEE Function](../../../../docs/framework/unmanaged-api/hosting/coinitializeee-function.md)  
 [Metadata Global Static Functions](../../../../docs/framework/unmanaged-api/metadata/metadata-global-static-functions.md)

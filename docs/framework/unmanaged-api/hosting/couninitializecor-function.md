---
title: "CoUninitializeCor Function"
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
  - "CoUninitializeCor"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CoUninitializeCor"
helpviewer_keywords: 
  - "CoUninitializeCor function [.NET Framework hosting]"
ms.assetid: 50a95b8b-9766-470e-bb29-2c7ecddfd4a1
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CoUninitializeCor Function
`CoUninitializeCor` is obsolete.  
  
## Syntax  
  
```  
STDAPI_(void) CoUninitializeCor(void);  
```  
  
## Remarks  
 The common language runtime cannot be unloaded from a process. To completely remove the runtime from a running process, you must shut down that process.  
  
## See Also  
 [Metadata Global Static Functions](../../../../docs/framework/unmanaged-api/metadata/metadata-global-static-functions.md)

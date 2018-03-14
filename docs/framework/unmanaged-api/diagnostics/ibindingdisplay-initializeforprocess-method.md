---
title: "IBindingDisplay::InitializeForProcess Method"
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
  - "IBindingDisplay.InitializeForProcess"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IBindingDisplay::InitializeForProcess"
helpviewer_keywords: 
  - "IBindingDisplay::InitializeForProcess method [.NET Framework debugging]"
  - "InitializeForProcess method [.NET Framework debugging]"
ms.assetid: 59417acb-4e59-46ad-acfe-d827e6ab6078
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IBindingDisplay::InitializeForProcess Method
Initializes the [IBindingDisplay](../../../../docs/framework/unmanaged-api/diagnostics/ibindingdisplay-interface.md) object.  
  
## Syntax  
  
```  
HRESULT InitializeForProcess (  
    [in] ULONG32   pid  
);  
```  
  
#### Parameters  
 `pid`  
 [in] The process identifier.  
  
## Remarks  
 The debugger calls the `InitializeForProcess` method at creation time to initialize the binding display. `InitializeForProcess` must be called at creation time before any other method on `IBindingDisplay` is called.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** BindingDisplay.h  
  
 **Library:** BindingDisplay.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IBindingDisplay Interface](../../../../docs/framework/unmanaged-api/diagnostics/ibindingdisplay-interface.md)

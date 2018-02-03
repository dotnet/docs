---
title: "IBindingDisplay::GetCurrentDisplay Method"
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
  - "IBindingDisplay.GetCurrentDisplay"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IBindingDisplay::GetCurrentDisplay"
helpviewer_keywords: 
  - "IBindingDisplay::GetCurrentDisplay method [.NET Framework debugging]"
  - "GetCurrentDisplay method [.NET Framework debugging]"
ms.assetid: d28eeea4-c4e0-40d4-91de-198d98cfa13c
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IBindingDisplay::GetCurrentDisplay Method
Returns the current binding display information.  
  
## Syntax  
  
```  
HRESULT GetCurrentDisplay (  
    [out, retval] SAFEARRAY(struct BindingDisplayTabControl) *display  
);  
```  
  
#### Parameters  
 `display`  
 [out, retval] A pointer to a safearray containing the binding display information.  
  
## Remarks  
 The [IBindingDisplay::InitializeForProcess](../../../../docs/framework/unmanaged-api/diagnostics/ibindingdisplay-initializeforprocess-method.md) method must have previously succeeded, and the program must be stopped by a debugger.  
  
 The caller must deallocate the returned `SAFEARRAY` memory by using [SafeArrayDestroy](http://msdn.microsoft.com/library/fc94f7e7-b903-4c78-905c-54df1f8d13fa).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** BindingDisplay.h  
  
 **Library:** BindingDisplay.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IBindingDisplay Interface](../../../../docs/framework/unmanaged-api/diagnostics/ibindingdisplay-interface.md)  
 [InitializeForProcess Method](../../../../docs/framework/unmanaged-api/diagnostics/ibindingdisplay-initializeforprocess-method.md)

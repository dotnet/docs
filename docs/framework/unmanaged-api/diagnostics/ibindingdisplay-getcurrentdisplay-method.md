---
description: "Learn more about: IBindingDisplay::GetCurrentDisplay Method"
title: "IBindingDisplay::GetCurrentDisplay Method"
ms.date: "03/30/2017"
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
---
# IBindingDisplay::GetCurrentDisplay Method

Returns the current binding display information.  
  
## Syntax  
  
```cpp  
HRESULT GetCurrentDisplay (  
    [out, retval] SAFEARRAY(struct BindingDisplayTabControl) *display  
);  
```  
  
## Parameters  

 `display`  
 [out, retval] A pointer to a safearray containing the binding display information.  
  
## Remarks  

 The [IBindingDisplay::InitializeForProcess](ibindingdisplay-initializeforprocess-method.md) method must have previously succeeded, and the program must be stopped by a debugger.  
  
 The caller must deallocate the returned `SAFEARRAY` memory by using [SafeArrayDestroy](/previous-versions/windows/desktop/api/oleauto/nf-oleauto-safearraydestroy).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** BindingDisplay.h  
  
 **Library:** BindingDisplay.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IBindingDisplay Interface](ibindingdisplay-interface.md)
- [InitializeForProcess Method](ibindingdisplay-initializeforprocess-method.md)

---
description: "Learn more about: IBindingDisplay::InitializeForProcess Method"
title: "IBindingDisplay::InitializeForProcess Method"
ms.date: "03/30/2017"
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
---
# IBindingDisplay::InitializeForProcess Method

Initializes the [IBindingDisplay](ibindingdisplay-interface.md) object.  
  
## Syntax  
  
```cpp  
HRESULT InitializeForProcess (  
    [in] ULONG32   pid  
);  
```  
  
## Parameters  

 `pid`  
 [in] The process identifier.  
  
## Remarks  

 The debugger calls the `InitializeForProcess` method at creation time to initialize the binding display. `InitializeForProcess` must be called at creation time before any other method on `IBindingDisplay` is called.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** BindingDisplay.h  
  
 **Library:** BindingDisplay.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IBindingDisplay Interface](ibindingdisplay-interface.md)

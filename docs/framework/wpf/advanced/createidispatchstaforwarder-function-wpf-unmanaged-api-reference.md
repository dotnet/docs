---
title: "CreateIDispatchSTAForwarder Function (WPF Unmanaged API Reference)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "cpp"
api_name: 
  - "CreateIDispatchSTAForwarder"
api_location: 
  - "PresentationHost_v0400.dll"
ms.assetid: 57a02dfa-f091-4ace-9c06-1f4ab52b3527
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# CreateIDispatchSTAForwarder Function (WPF Unmanaged API Reference)
This API supports the Windows Presentation Foundation (WPF) infrastructure and is not intended to be used directly from your code.  
  
 Used by the Windows Presentation Foundation (WPF) infrastructure for thread and windows management.  
  
## Syntax  
  
```cpp  
HRESULT CreateIDispatchSTAForwarder(  
   __in IDispatch *pDispatchDelegate,   
   __deref_out IDispatch **ppForwarder  
)  
```  
  
#### Parameters  
  
## Property Value/Return Value  
 pDispatchDelegate  
 A pointer to an `IDispatch` interface.  
  
 ppForwarder  
 A pointer to the address of an `IDispatch` interface.  
  
## Requirements  
 **Platforms:** See [.NET Framework System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **DLL:**  
  
 In the .NET Framework 3.0 and 3.5: PresentationHostDLL.dll  
  
 In the .NET Framework 4 and later: PresentationHost_v0400.dll  
  
 **.NET Framework Version:** [!INCLUDE[net_current_v30plus](../../../../includes/net-current-v30plus-md.md)]  
  
## See Also  
 [WPF Unmanaged API Reference](../../../../docs/framework/wpf/advanced/wpf-unmanaged-api-reference.md)

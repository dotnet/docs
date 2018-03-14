---
title: "ProcessUnhandledException Function (WPF Unmanaged API Reference)"
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
  - "ProcessUnhandledException"
api_location: 
  - "PresentationHost_v0400.dll"
ms.assetid: 495ce5f6-bb4d-4b30-807a-c3c35f1ca95c
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# ProcessUnhandledException Function (WPF Unmanaged API Reference)
This API supports the Windows Presentation Foundation (WPF) infrastructure and is not intended to be used directly from your code.  
  
 Used by the Windows Presentation Foundation (WPF) infrastructure for exception handling.  
  
## Syntax  
  
```cpp  
void __stdcall ProcessUnhandledException(  
   __in_ecount(1) BSTR errorMsg  
)  
```  
  
#### Parameters  
 errorMsg  
 The error message.  
  
## Requirements  
 **Platforms:** See [.NET Framework System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **DLL:**  
  
 In the .NET Framework 3.0 and 3.5: PresentationHostDLL.dll  
  
 In the .NET Framework 4 and later: PresentationHost_v0400.dll  
  
 **.NET Framework Version:** [!INCLUDE[net_current_v30plus](../../../../includes/net-current-v30plus-md.md)]  
  
## See Also  
 [WPF Unmanaged API Reference](../../../../docs/framework/wpf/advanced/wpf-unmanaged-api-reference.md)

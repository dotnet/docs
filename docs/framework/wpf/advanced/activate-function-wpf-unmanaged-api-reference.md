---
title: "Activate Function (WPF Unmanaged API Reference)"
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
  - "Acrivate"
api_location: 
  - "PresentationHost_v0400.dll"
ms.assetid: 1400329c-b598-465f-80f2-e3dabf044811
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Activate Function (WPF Unmanaged API Reference)
This API supports the Windows Presentation Foundation (WPF) infrastructure and is not intended to be used directly from your code.  
  
 Used by the Windows Presentation Foundation (WPF) infrastructure for windows management.  
  
## Syntax  
  
```cpp  
void Activate(  
    const ActivateParameters* pParameters,  
    __deref_out_ecount(1) LPUNKNOWN* ppInner,  
    );  
```  
  
#### Parameters  
 pParameters  
 A pointer to the window's activation parameters.  
  
 ppInner  
 A pointer to the address of a single-element buffer that contains a pointer to an <xref:Microsoft.VisualStudio.OLE.Interop.IOleDocument> object.  
  
## Requirements  
 **Platforms:** See [.NET Framework System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **DLL:**  
  
 In the .NET Framework 3.0 and 3.5: PresentationHostDLL.dll  
  
 In the .NET Framework 4 and later: PresentationHost_v0400.dll  
  
 **.NET Framework Version:** [!INCLUDE[net_current_v30plus](../../../../includes/net-current-v30plus-md.md)]  
  
## See Also  
 [WPF Unmanaged API Reference](../../../../docs/framework/wpf/advanced/wpf-unmanaged-api-reference.md)

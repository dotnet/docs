---
title: "IEnumRAWINPUTDEVIC:Clone"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Clone method [WPF]"
ms.assetid: 2a6a1900-aa55-45fa-9382-241d569a2dc4
caps.latest.revision: 5
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# IEnumRAWINPUTDEVIC:Clone
Creates another raw input device enumerator with the same state as the current enumerator to iterate over the same list.  
  
## Syntax  
  
```  
HRESULT Clone( [out] IEnumRAWINPUTDEVICE **ppenum);  
```  
  
#### Parameters  
 `ppenum`  
  
 [out] Address of output variable that receives the [IEnumRAWINPUTDEVICE](../../../../docs/framework/wpf/app-development/ienumrawinputdevice.md) interface pointer. If the method is unsuccessful, the value of this output variable is undefined.  
  
## Property Value/Return Value  
 HRESULT: This method supports the standard return values E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED.  
  
## Remarks  
 This method makes it possible to record a point in the enumeration sequence in order to return to that point at a later time. The caller must release this new enumerator separately from the first enumerator.

---
title: "IEnumRAWINPUTDEVIC:Skip"
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
  - "Skip method [WPF]"
ms.assetid: c967b0f8-1c6a-459c-8c16-d4f08918ab65
caps.latest.revision: 5
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# IEnumRAWINPUTDEVIC:Skip
Instructs the enumerator to skip the next `celt` elements in the enumeration so that the next call to [IEnumRAWINPUTDEVIC:Next](../../../../docs/framework/wpf/app-development/ienumrawinputdevic-next.md) will not return those elements.  
  
## Syntax  
  
```  
HRESULT Skip( [in] ULONG celt);  
```  
  
#### Parameters  
 `celt`  
  
 [in] Number of elements to be skipped.  
  
## Property Value/Return Value  
 HRESULT: S_OK if the number of elements supplied is `celt`; S_FALSE otherwise.

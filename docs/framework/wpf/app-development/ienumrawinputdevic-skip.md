---
title: "IEnumRAWINPUTDEVIC:Skip"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Skip method [WPF]"
ms.assetid: c967b0f8-1c6a-459c-8c16-d4f08918ab65
---
# IEnumRAWINPUTDEVIC:Skip
Instructs the enumerator to skip the next `celt` elements in the enumeration so that the next call to [IEnumRAWINPUTDEVIC:Next](ienumrawinputdevic-next.md) will not return those elements.  
  
## Syntax  
  
```cpp  
HRESULT Skip( [in] ULONG celt);  
```  
  
## Parameters  
 `celt`  
  
 [in] Number of elements to be skipped.  
  
## Property Value/Return Value  
 HRESULT: S_OK if the number of elements supplied is `celt`; S_FALSE otherwise.

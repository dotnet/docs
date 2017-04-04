---
title: "ICorDebugStepper::Deactivate Method | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
apiname: 
  - "ICorDebugStepper.Deactivate"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorDebugStepper::Deactivate"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "Deactivate method [.NET Framework debugging]"
  - "ICorDebugStepper::Deactivate method [.NET Framework debugging]"
ms.assetid: 855f4199-b62d-40ce-998e-1eb4a1772142
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorDebugStepper::Deactivate Method
Causes this ICorDebugStepper to cancel the last step command that it received.  
  
## Syntax  
  
```  
HRESULT Deactivate ();  
```  
  
## Remarks  
 A new stepping command may be issued after the most recently received step command has been canceled.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
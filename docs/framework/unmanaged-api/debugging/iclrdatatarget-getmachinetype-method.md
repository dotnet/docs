---
title: "ICLRDataTarget::GetMachineType Method | Microsoft Docs"
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
  - "ICLRDataTarget.GetMachineType"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICLRDataTarget::GetMachineType"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ICLRDataTarget::GetMachineType method [.NET Framework debugging]"
  - "GetMachineType method [.NET Framework debugging]"
ms.assetid: 5f1f9c61-3e3b-48b2-b111-a4395f7623a7
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICLRDataTarget::GetMachineType Method
Gets the identifier for the kind of instruction set that the target process is using.  
  
## Syntax  
  
```  
HRESULT GetMachineType (  
    [out] ULONG32     *machineType  
);  
```  
  
#### Parameters  
 `machineType`  
 [out] A pointer to a value that indicates the instruction set that the target process is using. The returned `machineType` is one of the IMAGE_FILE_MACHINE constants, which are defined in the WinNT.h header file.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRDataTarget Interface](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget-interface.md)
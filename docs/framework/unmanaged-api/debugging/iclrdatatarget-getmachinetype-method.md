---
description: "Learn more about: ICLRDataTarget::GetMachineType Method"
title: "ICLRDataTarget::GetMachineType Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRDataTarget.GetMachineType"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDataTarget::GetMachineType"
helpviewer_keywords: 
  - "ICLRDataTarget::GetMachineType method [.NET Framework debugging]"
  - "GetMachineType method [.NET Framework debugging]"
ms.assetid: 5f1f9c61-3e3b-48b2-b111-a4395f7623a7
topic_type: 
  - "apiref"
---
# ICLRDataTarget::GetMachineType Method

Gets the identifier for the kind of instruction set that the target process is using.  
  
## Syntax  
  
```cpp  
HRESULT GetMachineType (  
    [out] ULONG32     *machineType  
);  
```  
  
## Parameters  

 `machineType`  
 [out] A pointer to a value that indicates the instruction set that the target process is using. The returned `machineType` is one of the IMAGE_FILE_MACHINE constants, which are defined in the WinNT.h header file.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRDataTarget Interface](iclrdatatarget-interface.md)

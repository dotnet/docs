---
description: "Learn more about: ICorDebugNativeFrame::CanSetIP Method"
title: "ICorDebugNativeFrame::CanSetIP Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugNativeFrame.CanSetIP"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugNativeFrame::CanSetIP"
helpviewer_keywords: 
  - "ICorDebugNativeFrame::CanSetIP method [.NET Framework debugging]"
  - "CanSetIP method, ICorDebugNativeFrame interface [.NET Framework debugging]"
ms.assetid: 13258ac6-f4e4-4f66-8fc3-f1244417a3c3
topic_type: 
  - "apiref"
---
# ICorDebugNativeFrame::CanSetIP Method

Gets an HRESULT that indicates whether it is safe to set the instruction pointer (IP) to the specified offset location in native code.  
  
## Syntax  
  
```cpp  
HRESULT CanSetIP (  
    [in] ULONG32            nOffset  
);  
```  
  
## Parameters  

 `nOffset`  
 [in] The desired setting for the instruction pointer.  
  
## Remarks  

 Use the `CanSetIP` method prior to calling the [ICorDebugNativeFrame::SetIP](icordebugnativeframe-setip-method.md) method. If `CanSetIP` returns any HRESULT other than S_OK, you can still invoke `ICorDebugNativeFrame::SetIP`, but there is no guarantee that the debugger will continue the safe and correct execution of the code being debugged.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

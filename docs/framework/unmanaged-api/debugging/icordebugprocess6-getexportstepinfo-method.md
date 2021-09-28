---
description: "Learn more about: ICorDebugProcess6::GetExportStepInfo Method"
title: "ICorDebugProcess6::GetExportStepInfo Method"
ms.date: "03/30/2017"
ms.assetid: a927e0ac-f110-426d-bbec-9377a29c8f17
---
# ICorDebugProcess6::GetExportStepInfo Method

Provides information on runtime exported functions to help step through managed code.  
  
## Syntax  
  
```cpp  
HRESULT GetExportStepInfo(  
    [in] LPCWSTR pszExportName,
    [out] CorDebugCodeInvokeKind* pInvokeKind,
    [out] CorDebugCodeInvokePurpose* pInvokePurpose);  
```  
  
## Parameters  

 pszExportName  
 [in] The name of a runtime export function as written in the PE export table.  
  
 invokeKind  
 [out] A pointer to a member of the [CorDebugCodeInvokeKind](cordebugcodeinvokekind-enumeration.md) enumeration that describes how the exported function will invoke managed code.  
  
 invokePurpose  
 [out] A pointer to a member of the [CorDebugCodeInvokePurpose](cordebugcodeinvokepurpose-enumeration.md) enumeration that describes why the exported function will call managed code.  
  
## Return Value  

 The method can return the values listed in the following table.  
  
|Return value|Description|  
|------------------|-----------------|  
|`S_OK`|The method call was successful.|  
|`E_POINTER`|`pInvokeKind` or `pInvokePurpose` is **null**.|  
|Other failing `HRESULT` values.|As appropriate.|  
  
## Remarks  
  
> [!NOTE]
> This method is available with .NET Native only.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugProcess6 Interface](icordebugprocess6-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)

---
description: "Learn more about: ICorDebugProcess6::MarkDebuggerAttached Method"
title: "ICorDebugProcess6::MarkDebuggerAttached Method"
ms.date: "03/30/2017"
ms.assetid: bf94f090-5265-4112-8e57-5b4e20e070d0
---
# ICorDebugProcess6::MarkDebuggerAttached Method

Changes the internal state of the debugee so that the <xref:System.Diagnostics.Debugger.IsAttached%2A?displayProperty=nameWithType> method in the .NET Framework Class Library returns `true`.  
  
## Syntax  
  
```cpp  
HRESULT MarkDebuggerAttached(  
    BOOL fIsAttached  
);  
```  
  
## Parameters  

 `fIsAttached`  
 `true` if the <xref:System.Diagnostics.Debugger.IsAttached%2A?displayProperty=nameWithType> method should indicate that a debugger is attached; `false` otherwise.  
  
## Return Value  

 The method can return the values listed in the following table.  
  
|Return value|Description|  
|------------------|-----------------|  
|`S_OK`|The debuggee was successfully updated.|  
|`CORDBG_E_MODULE_NOT_LOADED`|The assembly that contains the <xref:System.Diagnostics.Debugger.IsAttached%2A?displayProperty=nameWithType> method is not loaded, or some other error, such as missing metadata, is preventing it from being recognized.<br /><br /> This error is common and benign. You should call the method again when additional assemblies load.|  
|Other failing `HRESULT` values.|Other values likely indicate misbehaving debugger or compiler components.|  
  
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

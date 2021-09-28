---
description: "Learn more about: ICorDebugModule2::SetJITCompilerFlags Method"
title: "ICorDebugModule2::SetJITCompilerFlags Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugModule2.SetJITCompilerFlags"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugModule2::SetJITCompilerFlags"
helpviewer_keywords: 
  - "ICorDebugModule2::SetJITCompilerFlags method [.NET Framework debugging]"
  - "SetJITCompilerFlags method [.NET Framework debugging]"
ms.assetid: ea574c84-c622-4589-9a14-b55771af5e06
topic_type: 
  - "apiref"
---
# ICorDebugModule2::SetJITCompilerFlags Method

Sets the flags that control the just-in-time (JIT) compilation of this ICorDebugModule2.  
  
## Syntax  
  
```cpp  
HRESULT SetJITCompilerFlags (  
    [in] DWORD dwFlags  
);  
```  
  
## Parameters  

 `dwFlags`  
 [in] A bitwise combination of the [CorDebugJITCompilerFlags](cordebugjitcompilerflags-enumeration.md) enumeration values.  
  
## Remarks  

 If the `dwFlags` value is invalid, the `SetJITCompilerFlags` method will fail.  
  
 The `SetJITCompilerFlags` method can be called only from within the [ICorDebugManagedCallback::LoadModule](icordebugmanagedcallback-loadmodule-method.md) callback for this module. Attempts to call it after the `ICorDebugManagedCallback::LoadModule` callback has been delivered will fail.  
  
 Edit and Continue is not supported on 64-bit or Win9x platforms. Therefore, if you call the `SetJITCompilerFlags` method on either of these two platforms with the CORDEBUG_JIT_ENABLE_ENC flag set in `dwFlags`, the `SetJITCompilerFlags` method and all methods specific to Edit and Continue, such as [ICorDebugModule2::ApplyChanges](icordebugmodule2-applychanges-method.md), will fail.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]

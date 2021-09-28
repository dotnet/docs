---
description: "Learn more about: ICorDebugProcess2::SetDesiredNGENCompilerFlags Method"
title: "ICorDebugProcess2::SetDesiredNGENCompilerFlags Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugProcess2.SetDesiredNGENCompilerFlags"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess2::SetDesiredNGENCompilerFlags"
helpviewer_keywords: 
  - "ICorDebugProcess2::SetDesiredNGENCompilerFlags method [.NET Framework debugging]"
  - "SetDesiredNGENCompilerFlags method [.NET Framework debugging]"
ms.assetid: 98320175-7c5e-4dbb-8683-86fa82e2641f
topic_type: 
  - "apiref"
---
# ICorDebugProcess2::SetDesiredNGENCompilerFlags Method

Sets the flags that must be embedded in a precompiled image in order for the runtime to load that image into the current process.  
  
## Syntax  
  
```cpp  
HRESULT SetDesiredNGENCompilerFlags (  
    [in] DWORD    pdwFlags  
);  
```  
  
## Parameters  

 `pdwFlags`  
 [in] A value of the [CorDebugJITCompilerFlags](cordebugjitcompilerflags-enumeration.md) enumeration that specifies the compiler flags used to select the correct pre-compiled image.  
  
## Remarks  

 The `SetDesiredNGENCompilerFlags` method specifies the flags that must be embedded in a precompiled image so that the runtime will load that image into this process. The flags set by this method are used only to select the correct precompiled image. If no such image exists, the runtime will load the Microsoft intermediate language (MSIL) image and the just-in-time (JIT) compiler instead. In that case, the debugger must still use the [ICorDebugModule2::SetJITCompilerFlags](icordebugmodule2-setjitcompilerflags-method.md) method to set the flags as desired for the JIT compilation.  
  
 If an image is loaded, but some JIT compiling must take place for that image (which will be the case if the image contains generics), the compiler flags specified by the `SetDesiredNGENCompilerFlags` method will apply to the extra JIT compilation.  
  
 The `SetDesiredNGENCompilerFlags` method must be called during the [ICorDebugManagedCallback::CreateProcess](icordebugmanagedcallback-createprocess-method.md) callback. Attempts to call the `SetDesiredNGENCompilerFlags` method afterwards will fail. Also, attempts to set flags that are either not defined in the `CorDebugJITCompilerFlags` enumeration or are not legal for the given process will fail.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorDebug Interface](icordebug-interface.md)
- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)

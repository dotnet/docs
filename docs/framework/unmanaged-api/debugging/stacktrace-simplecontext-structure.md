---
description: "Learn more about: StackTrace_SimpleContext Structure"
title: "StackTrace_SimpleContext Structure"
ms.date: "03/30/2017"
api_name: 
  - "StackTrace_SimpleContext"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "SimpleContext"
helpviewer_keywords: 
  - "SimpleContext structure [.NET Framework debugging]"
  - "StackTrace_SimpleContext structure [.NET Framework debugging]"
ms.assetid: d4cef11f-a8ca-49bc-a1b8-6631f9e28f3e
topic_type: 
  - "apiref"
---
# StackTrace_SimpleContext Structure

Provides a simple context that can be used in place of a full `CONTEXT` structure.  
  
## Syntax  
  
```cpp  
struct StackTrace_SimpleContext  
{  
    ULONG64 StackOffset;       // ESP on x86  
    ULONG64 FrameOffset;       // EBP on x86  
    ULONG64 InstructionOffset; // EIP on x86  
};  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`StackOffset`|The stack pointer, or the enter stack pointer (ESP) on x86 platforms.|  
|`FrameOffset`|The frame offset, or the EBP register on x86 platforms.|  
|`InstructionOffset`|The instruction pointer, or the enter instruction pointer (EIP) on x86 platforms.|  
  
## Remarks  

 Because stack trace functions typically need to return only the address, frame offset, and stack address, you can optionally use the `SimpleContext` structure instead of a large `CONTEXT` structure.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** SOS_Stacktrace.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Debugging Structures](debugging-structures.md)
- [Debugging](index.md)

---
title: "CorDebugRegister Enumeration"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "CorDebugRegister"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorDebugRegister"
helpviewer_keywords: 
  - "CorDebugRegister enumeration [.NET Framework debugging]"
ms.assetid: 003bb138-7960-4291-ac88-0d87e470ff70
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorDebugRegister Enumeration
Specifies the registers associated with a given processor architecture.  
  
## Syntax  
  
```  
typedef enum CorDebugRegister {  
  
    REGISTER_INSTRUCTION_POINTER = 0,  
    REGISTER_STACK_POINTER,  
    REGISTER_FRAME_POINTER,  
  
    REGISTER_X86_EIP = 0,  
    REGISTER_X86_ESP,  
    REGISTER_X86_EBP,  
  
    REGISTER_X86_EAX,  
    REGISTER_X86_ECX,  
    REGISTER_X86_EDX,  
    REGISTER_X86_EBX,  
  
    REGISTER_X86_ESI,  
    REGISTER_X86_EDI,  
  
    REGISTER_X86_FPSTACK_0,  
    REGISTER_X86_FPSTACK_1,  
    REGISTER_X86_FPSTACK_2,  
    REGISTER_X86_FPSTACK_3,  
    REGISTER_X86_FPSTACK_4,  
    REGISTER_X86_FPSTACK_5,  
    REGISTER_X86_FPSTACK_6,  
    REGISTER_X86_FPSTACK_7,  
  
    REGISTER_AMD64_RIP = 0,  
    REGISTER_AMD64_RSP,  
    REGISTER_AMD64_RBP,  
    REGISTER_AMD64_RAX,  
    REGISTER_AMD64_RCX,  
    REGISTER_AMD64_RDX,  
    REGISTER_AMD64_RBX,  
    REGISTER_AMD64_RSI,  
    REGISTER_AMD64_RDI,  
    REGISTER_AMD64_R8,  
    REGISTER_AMD64_R9,  
    REGISTER_AMD64_R10,  
    REGISTER_AMD64_R11,  
    REGISTER_AMD64_R12,  
    REGISTER_AMD64_R13,  
    REGISTER_AMD64_R14,  
    REGISTER_AMD64_R15,  
  
    REGISTER_AMD64_XMM0,  
    REGISTER_AMD64_XMM1,  
    REGISTER_AMD64_XMM2,  
    REGISTER_AMD64_XMM3,  
    REGISTER_AMD64_XMM4,  
    REGISTER_AMD64_XMM5,  
    REGISTER_AMD64_XMM6,  
    REGISTER_AMD64_XMM7,  
    REGISTER_AMD64_XMM8,  
    REGISTER_AMD64_XMM9,  
    REGISTER_AMD64_XMM10,  
    REGISTER_AMD64_XMM11,  
    REGISTER_AMD64_XMM12,  
    REGISTER_AMD64_XMM13,  
    REGISTER_AMD64_XMM14,  
    REGISTER_AMD64_XMM15,  
  
    REGISTER_IA64_BSP = REGISTER_FRAME_POINTER,  
    REGISTER_IA64_R0  = REGISTER_IA64_BSP + 1,  
    REGISTER_IA64_F0  = REGISTER_IA64_R0  + 128,  
    REGISTER_ARM_PC = 0,  
    REGISTER_ARM_SP,  
    REGISTER_ARM_R0,  
    REGISTER_ARM_R1,  
    REGISTER_ARM_R2,  
    REGISTER_ARM_R3,  
    REGISTER_ARM_R4,  
    REGISTER_ARM_R5,  
    REGISTER_ARM_R6,  
    REGISTER_ARM_R7,  
    REGISTER_ARM_R8,  
    REGISTER_ARM_R9,  
    REGISTER_ARM_R10,  
    REGISTER_ARM_R11,  
    REGISTER_ARM_R12,  
    REGISTER_ARM_LR,  
  
} CorDebugRegister;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`REGISTER_INSTRUCTION_POINTER`|An instruction pointer register on any processor.|  
|`REGISTER_STACK_POINTER`|A stack pointer register on any processor.|  
|`REGISTER_FRAME_POINTER`|A frame pointer register on any processor.|  
|`REGISTER_X86_EIP`|The instruction pointer register on the x86 processor.|  
|`REGISTER_X86_ESP`|The stack pointer register on the x86 processor.|  
|`REGISTER_X86_EBP`|The base pointer register on the x86 processor.|  
|`REGISTER_X86_EAX`|The A data register on the x86 processor.|  
|`REGISTER_X86_ECX`|The C data register on the x86 processor.|  
|`REGISTER_X86_EDX`|The D data register on the x86 processor.|  
|`REGISTER_X86_EBX`|The B data register on the x86 processor.|  
|`REGISTER_X86_ESI`|The source index register on the x86 processor.|  
|`REGISTER_X86_EDI`|The destination index register on the x86 processor.|  
|`REGISTER_X86_FPSTACK_0`|The stack register 0 on the x86 floating-point (FP) processor.|  
|`REGISTER_X86_FPSTACK_1`|The #1 stack register on the x86 FP processor.|  
|`REGISTER_X86_FPSTACK_2`|The #2 stack register on the x86 FP processor.|  
|`REGISTER_X86_FPSTACK_3`|The #3 stack register on the x86 FP processor.|  
|`REGISTER_X86_FPSTACK_4`|The #4 stack register on the x86 FP processor.|  
|`REGISTER_X86_FPSTACK_5`|The #5 stack register on the x86 FP processor.|  
|`REGISTER_X86_FPSTACK_6`|The #6 stack register on the x86 FP processor.|  
|`REGISTER_X86_FPSTACK_7`|The #7 stack register on the x86 FP processor.|  
|`REGISTER_AMD64_RIP`|The instruction pointer register on the AMD64 processor.|  
|`REGISTER_AMD64_RSP`|The stack pointer register on the AMD64 processor.|  
|`REGISTER_AMD64_RBP`|The base pointer register on the AMD64 processor.|  
|`REGISTER_AMD64_RAX`|The A data register on the AMD64 processor.|  
|`REGISTER_AMD64_RCX`|The C data register on the AMD64 processor.|  
|`REGISTER_AMD64_RDX`|The D data register on the AMD64 processor.|  
|`REGISTER_AMD64_RBX`|The B data register on the AMD64 processor.|  
|`REGISTER_AMD64_RSI`|The source index register on the AMD64 processor.|  
|`REGISTER_AMD64_RDI`|The destination index register on the AMD64 processor.|  
|`REGISTER_AMD64_R8`|The #8 data register on the AMD64 processor.|  
|`REGISTER_AMD64_R9`|The #9 data register on the AMD64 processor.|  
|`REGISTER_AMD64_R10`|The #10 data register on the AMD64 processor.|  
|`REGISTER_AMD64_R11`|The #11 data register on the AMD64 processor.|  
|`REGISTER_AMD64_R12`|The #12 data register on the AMD64 processor.|  
|`REGISTER_AMD64_R13`|The #13 data register on the AMD64 processor.|  
|`REGISTER_AMD64_R14`|The #14 data register on the AMD64 processor.|  
|`REGISTER_AMD64_R15`|The #15 data register on the AMD64 processor.|  
|`REGISTER_AMD64_XMM0`|The #0 multimedia register on the AMD64 processor.|  
|`REGISTER_AMD64_XMM1`|The #1 multimedia register on the AMD64 processor.|  
|`REGISTER_AMD64_XMM2`|The #2 multimedia register on the AMD64 processor.|  
|`REGISTER_AMD64_XMM3`|The #3 multimedia register on the AMD64 processor.|  
|`REGISTER_AMD64_XMM4`|The #4 multimedia register on the AMD64 processor.|  
|`REGISTER_AMD64_XMM5`|The #5 multimedia register on the AMD64 processor.|  
|`REGISTER_AMD64_XMM6`|The #6 multimedia register on the AMD64 processor.|  
|`REGISTER_AMD64_XMM7`|The #7 multimedia register on the AMD64 processor.|  
|`REGISTER_AMD64_XMM8`|The #8 multimedia register on the AMD64 processor.|  
|`REGISTER_AMD64_XMM9`|The #9 multimedia register on the AMD64 processor.|  
|`REGISTER_AMD64_XMM10`|The #10 multimedia register on the AMD64 processor.|  
|`REGISTER_AMD64_XMM11`|The #11 multimedia register on the AMD64 processor.|  
|`REGISTER_AMD64_XMM12`|The #12 multimedia register on the AMD64 processor.|  
|`REGISTER_AMD64_XMM13`|The #13 multimedia register on the AMD64 processor.|  
|`REGISTER_AMD64_XMM14`|The #14 multimedia register on the AMD64 processor.|  
|`REGISTER_AMD64_XMM15`|The #15 multimedia register on the AMD64 processor.|  
|`REGISTER_IA64_BSP`|The stack pointer register on the IA-64 processor.|  
|`REGISTER_IA64_R0`|The #0 data register on the IA-64 processor.|  
|`REGISTER_IA64_F0`|The #0 FP data register on the IA-64 processor.|  
|`REGISTER_ARM_PC`|The program counter register (R15) on the ARM processor.|  
|`REGISTER_ARM_SP`|The stack pointer register (R13) on the ARM processor.|  
|`REGISTER_ARM_R0`|Data register R0 on the ARM processor.|  
|`REGISTER_ARM_R1`|Data register R1 on the ARM processor.|  
|`REGISTER_ARM_R2`|Data register R2 on the ARM processor.|  
|`REGISTER_ARM_R3`|Data register R3 on the ARM processor.|  
|`REGISTER_ARM_R4`|Register R4 on the ARM processor.|  
|`REGISTER_ARM_R5`|Register R5 on the ARM processor.|  
|`REGISTER_ARM_R6`|Register R6 on the ARM processor.|  
|`REGISTER_ARM_R7`|Register R7 (the THUMB frame pointer) on the ARM processor.|  
|`REGISTER_ARM_R8`|Register R8 on the ARM processor.|  
|`REGISTER_ARM_R9`|Register R9 on the ARM processor.|  
|`REGISTER_ARM_R10`|Register R10 on the ARM processor.|  
|`REGISTER_ARM_R11`|The frame pointer on the ARM processor.|  
|`REGISTER_ARM_R12`|Register R12 on the ARM processor.|  
|`REGISTER_ARM_LR`|The link register (R14) on the ARM processor.|  
  
## Remarks  
 There are 128 general-purpose data registers and 128 floating-point data registers on the IA-64 processor, but only values `REGISTER_IA64_R0` and `REGISTER_IA64_F0` are provided. The other values can be determined as follows:  
  
-   Add the register number to `REGISTER_IA64_R0` for values `REGISTER_IA64_R1` through `REGISTER_IA64_R127`, which correspond to the #1 data register through the #127 data register on the IA-64 processor.  
  
-   Add the register number to `REGISTER_IA64_F0` for values `REGISTER_IA64_F1` through `REGISTER_IA64_F127`, which correspond to the #1 FP data register through the #127 FP data register on the IA-64 processor.  
  
 For example, if you need to specify the #83 data register on the IA-64 processor, use `REGISTER_IA64_R0` + 83.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Debugging Enumerations](../../../../docs/framework/unmanaged-api/debugging/debugging-enumerations.md)

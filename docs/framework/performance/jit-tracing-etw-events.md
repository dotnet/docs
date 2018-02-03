---
title: "JIT Tracing ETW Events"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "JIT tracing events [.NET Framework]"
  - "ETW, JIT tracing events (CLR)"
ms.assetid: 926adde2-c123-452e-bf4f-4b977bf06ffb
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# JIT Tracing ETW Events
<a name="top"></a> These events collect information relating to the success or failure of just-in-time (JIT) inlining and JIT tail calls.  
  
 JIT tracing events consist of the following two categories:  
  
-   [JIT Inlining Events](#jit_inlining_events)  
  
-   [JIT Tail Call Events](#jit_tail_call_events)  
  
<a name="jit_inlining_events"></a>   
## JIT Inlining Events  
  
### MethodJitInliningFailed Event  
 The following table shows the keyword and level. (For more information, see [CLR ETW Keywords and Levels](../../../docs/framework/performance/clr-etw-keywords-and-levels.md).)  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`JITTracingKeyword` (0x10)|Verbose (5)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`MethodJitInliningFailed`|186|The JIT inlining failed.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|MethodBeingCompiledNameSpace|win:UnicodeString|Namespace of the method that is being compiled.|  
|MethodBeingCompiledName|win:UnicodeString|Name of the method that is being compiled.|  
|MethodBeingCompiledNameSignature|win:UnicodeString|Signature of the method that is being compiled.|  
|InlinerNamespace|win:UnicodeString|The namespace of the method the JIT compiler is trying to generate code for.|  
|InlinerName|win:UnicodeString|The name of the method the compiler is attempting to generate code for. This might not be the same as `MethodBeingCompiledName` if the compiler is attempting to inline code into `MethodBeingCompiledName` instead of generating a call to `InlinerName`.|  
|InlinerNameSignature|win:UnicodeString|The signature for the inliner.|  
|InlineeNamespace|win:UnicodeString|The namespace of the inlinee.|  
|InlineeName|win:UnicodeString|The method the compiler is trying to inline (not generate a call to).|  
|InlineeNameSignature|win:UnicodeString|The signature for the inlinee.|  
|FailAlways|win:Boolean|A hint to the JIT compiler that inlining will always fail for the inlinee.|  
|FailReason|win:UnicodeString|INLINE_NEVER means a previous inlining attempt determined that inlining will never succeed for some other reason; otherwise, free-form text.|  
|ClrInstanceID|win:UnicodeString|Unique ID for the instance of CLR or CoreCLR.|  
  
### MethodJitInliningSucceeded Event  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`JITTracingKeyword` (0x10)|Verbose (5)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`MethodJitInliningSucceeded`|185|The method inlining succeeded.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|MethodBeingCompiledNameSpace|win:UnicodeString|The namespace of the method that is being compiled.|  
|MethodBeingCompiledName|win:UnicodeString|The name of the method being that is compiled.|  
|MethodBeingCompiledNameSignature|win:UnicodeString|The signature of the method that is being compiled.|  
|InlinerNamespace|win:UnicodeString|The namespace of the method the JIT compiler is attempting to generate code for.|  
|InlinerName|win:UnicodeString|The name of the method the compiler is attempting to generate code for. This might not be the same as `MethodBeingCompiledName` if the compiler is attempting to inline code into `MethodBeingCompiledName` instead of generating a call to `InlinerName`.|  
|InlinerNameSignature|win:UnicodeString|The signature for the inliner.|  
|InlineeNamespace|win:UnicodeString|The namespace of the inlinee.|  
|InlineeName|win:UnicodeString|The method the compiler is trying to inline (not generate a call to).|  
|InlineeNameSignature|win:UnicodeString|The signature for the inlinee.|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
 [Back to top](#top)  
  
<a name="jit_tail_call_events"></a>   
## JIT Tail Call Events  
  
### MethodJITTailCallFailed Event  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`JITTracingKeyword` (0x10)|Verbose (5)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`MethodJitTailCallFailed`|189|The method tail call failed.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|MethodBeingCompiledNameSpace|win:UnicodeString|Namespace of the method that is being compiled.|  
|MethodBeingCompiledName|win:UnicodeString|Name of the method that is being compiled.|  
|MethodBeingCompiledNameSignature|win:UnicodeString|Signature of the method that is being compiled.|  
|CallerNamespace|win:UnicodeString|The namespace of the method the JIT compiler is attempting to generate code for.|  
|CallerName|win:UnicodeString|The name of the method the compiler is attempting to generate code for.|  
|CallerNameSignature|win:UnicodeString|The signature for the caller.|  
|CalleeNamespace|win:UnicodeString|The namespace of the callee.|  
|CalleeName|win:UnicodeString|The method the compiler is trying to tail call (not generate a call to).|  
|CalleeNameSignature|win:UnicodeString|The signature for the callee.|  
|TailPrefix|win:Boolean|The prefix for the tail call|  
|FailReason|win:UnicodeString|The reason the tail call failed.|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
### MethodJITTailCallSucceeded Event  
 The following table shows the keyword and level.  
  
|Keyword for raising the event|Level|  
|-----------------------------------|-----------|  
|`JITTracingKeyword` (0x10)|Verbose (5)|  
  
 The following table shows the event information.  
  
|Event|Event ID|Raised when|  
|-----------|--------------|-----------------|  
|`MethodJitTailCallSucceeded`|188|The method tail call succeeded.|  
  
 The following table shows the event data.  
  
|Field name|Data type|Description|  
|----------------|---------------|-----------------|  
|MethodBeingCompiledNameSpace|win:UnicodeString|Namespace of the method that is being compiled.|  
|MethodBeingCompiledName|win:UnicodeString|Name of the method that is being compiled.|  
|MethodBeingCompiledNameSignature|win:UnicodeString|Signature of the method that is being compiled.|  
|CallerNamespace|win:UnicodeString|The namespace of the method the JIT compiler is attempting to generate code for.|  
|CallerName|win:UnicodeString|The name of the method the compiler is attempting to generate code for.|  
|CallerNameSignature|win:UnicodeString|The signature for the caller.|  
|CalleeNamespace|win:UnicodeString|The namespace of the callee.|  
|CalleeName|win:UnicodeString|The method the compiler is trying to tail call (not generate a call to).|  
|CalleeNameSignature|win:UnicodeString|The signature for the callee.|  
|TailPrefix|win:Boolean|The prefix for the tail call.|  
|TailCallType|win:UnicodeString|The type of the tail call.|  
|ClrInstanceID|win:UInt16|Unique ID for the instance of CLR or CoreCLR.|  
  
## See Also  
 [CLR ETW Events](../../../docs/framework/performance/clr-etw-events.md)

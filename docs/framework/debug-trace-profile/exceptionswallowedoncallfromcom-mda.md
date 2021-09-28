---
title: "exceptionSwallowedOnCallFromCom MDA"
description: Review the exceptionSwallowedOnCallFromCOM managed debugging assistant in .NET. This MDA occurs if an exception was thrown but there's no good way to report it.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "messages, informational"
  - "informational messages"
  - "managed debugging assistants (MDAs), exceptions"
  - "exception handling, managed debugging assistants"
  - "MDAs (managed debugging assistants), exceptions"
  - "ExceptionSwallowedOnCallFromCOM MDA"
ms.assetid: 55d6ab12-f251-4aab-aa64-aacbe9d9f974
---
# exceptionSwallowedOnCallFromCom MDA

The `exceptionSwallowedOnCallFromCOM` managed debugging assistant (MDA) is activated when an exception is thrown from common language runtime (CLR) code called from COM via a method that does not have an unmanaged HRESULT return type.  
  
## Symptoms  

 A call to a managed component from COM returns with a value of FALSE or 0. Alternatively, if the method has a void return type, there may be no indication that an exception was thrown during the execution of the method. In this case, the exception will be silently caught and execution will return to the COM caller.  
  
## Cause  

 An exception was thrown, but there is no valid way to report it.  
  
## Resolution  

 Informational only, not necessarily indicative of a bug.  
  
## Effect on the Runtime  

 This MDA has no effect on the CLR. It only reports data about silently caught exceptions.  
  
## Output  

 Informational message containing the method name, type name, and exception message.  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <exceptionSwallowedOnCallFromCom />  
  </assistants>  
</mdaConfig>  
```  
  
## See also

- <xref:System.Runtime.InteropServices.MarshalAsAttribute>
- [Diagnosing Errors with Managed Debugging Assistants](diagnosing-errors-with-managed-debugging-assistants.md)
- [Interop Marshaling](../interop/interop-marshaling.md)

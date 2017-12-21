---
title: "reentrancy MDA"
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
  - "unmanaged code, debugging"
  - "transitioning threads unmanaged to managed code"
  - "reentrancy MDA"
  - "reentrancy without an orderly transition"
  - "managed debugging assistants (MDAs), reentrancy"
  - "illegal reentrancy"
  - "MDAs (managed debugging assistants), reentrancy"
  - "threading [.NET Framework], managed debugging assistants"
  - "managed code, debugging"
  - "native debugging, MDAs"
ms.assetid: 7240c3f3-7df8-4b03-bbf1-17cdce142d45
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# reentrancy MDA
The `reentrancy` managed debugging assistant (MDA) is activated when an attempt is made to transition from native to managed code in cases where a prior switch from managed to native code was not performed through an orderly transition.  
  
## Symptoms  
 The object heap is corrupted or other serious errors are occurring when transitioning from native to managed code.  
  
 Threads that switch between native and managed code in either direction must perform an orderly transition. However, certain low-level extensibility points in the operating system, such as the vectored exception handler, allow switches from managed to native code without performing an orderly transition.  These switches are under operating system control, rather than under common language runtime (CLR) control.  Any native code that executes inside these extensibility points must avoid calling back into managed code.  
  
## Cause  
 A low-level operating system extensibility point, such as the vectored exception handler, has activated while executing managed code.  The application code that is invoked through that extensibility point is attempting to call back into managed code.  
  
 This problem is always caused by application code.  
  
## Resolution  
 Examine the stack trace for the thread that has activated this MDA.  The thread is attempting to illegally call into managed code.  The stack trace should reveal the application code using this extensibility point, the operating system code that provides this extensibility point, and the managed code that was interrupted by the extensibility point.  
  
 For example, you will see the MDA activated in an attempt to call managed code from inside a vectored exception handler.  On the stack you will see the operating system exception handling code and some managed code triggering an exception such as a <xref:System.DivideByZeroException> or an <xref:System.AccessViolationException>.  
  
 In this example, the correct resolution is to implement the vectored exception handler completely in unmanaged code.  
  
## Effect on the Runtime  
 This MDA has no effect on the CLR.  
  
## Output  
 The MDA reports that illegal reentrancy is being attempted.  Examine the thread's stack to determine why this is happening and how to correct the problem. The following is sample output.  
  
```  
Additional Information: Attempting to call into managed code without   
transitioning out first.  Do not attempt to run managed code inside   
low-level native extensibility points. Managed Debugging Assistant   
'Reentrancy' has detected a problem in 'D:\ConsoleApplication1\  
ConsoleApplication1\bin\Debug\ConsoleApplication1.vshost.exe'.  
```  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <reentrancy />  
  </assistants>  
</mdaConfig>  
```  
  
## Example  
 The following code example causes an <xref:System.AccessViolationException> to be thrown.  On versions of Windows that support vectored exception handling, this will cause the managed vectored exception handler to be called.  If the `reentrancy` MDA is enabled, the MDA will activate during the attempted call to `MyHandler` from the operating system's vectored exception handling support code.  
  
```  
using System;  
public delegate int ExceptionHandler(IntPtr ptrExceptionInfo);  
  
public class Reenter   
{  
    public static ExceptionHandler keepAlive;  
  
    [System.Runtime.InteropServices.DllImport("kernel32", ExactSpelling=true,   
        CharSet=System.Runtime.InteropServices.CharSet.Auto)]  
    public static extern IntPtr AddVectoredExceptionHandler(int bFirst,   
        ExceptionHandler handler);  
  
    static int MyHandler(IntPtr ptrExceptionInfo)   
    {  
        // EXCEPTION_CONTINUE_SEARCH  
        return 0;  
    }  
    void Run() {}  
  
    static void Main()   
    {  
        keepAlive = new ExceptionHandler(Reenter.MyHandler);  
        IntPtr ret = AddVectoredExceptionHandler(1, keepAlive);  
        try   
        {  
            // Dispatch on null should AV.  
            Reenter r = null;   
            r.Run();  
        }   
        catch { }  
    }  
}  
```  
  
## See Also  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)

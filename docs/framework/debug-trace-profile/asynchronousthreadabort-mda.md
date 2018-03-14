---
title: "asynchronousThreadAbort MDA"
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
  - "asynchronous thread aborts"
  - "AsynchronousThreadAbort MDA"
  - "managed debugging assistants (MDAs), asynchronous thread aborts"
  - "threading [.NET Framework], managed debugging assistants"
  - "MDAs (managed debugging assistants), asynchronous thread aborts"
ms.assetid: 9ebe40b2-d703-421e-8660-984acc42bfe0
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# asynchronousThreadAbort MDA
The `asynchronousThreadAbort` managed debugging assistant (MDA) is activated when a thread attempts to introduce an asynchronous abort into another thread. Synchronous thread aborts do not activate the `asynchronousThreadAbort` MDA.

## Symptoms
 An application crashes with an unhandled <xref:System.Threading.ThreadAbortException> when the main application thread is aborted. If the application were to continue to execute, the consequences might be worse than the application crashing, possibly resulting in further data corruption.

 Operations meant to be atomic have likely been interrupted after partial completion, leaving application data in an unpredictable state. A <xref:System.Threading.ThreadAbortException> can be generated from seemingly random points in the execution of code, often in places from which an exception is not expected to arise. The code might not be capable of handling such an exception, resulting in a corrupt state.

 Symptoms can vary widely due to the randomness inherent to the problem.

## Cause
 Code in one thread called the <xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType> method on a target thread to introduce an asynchronous thread abort. The thread abort is asynchronous because the code that makes the call to <xref:System.Threading.Thread.Abort%2A> is running on a different thread than the target of the abort operation. Synchronous thread aborts should not cause a problem because the thread performing the <xref:System.Threading.Thread.Abort%2A> should have done so only at a safe checkpoint where application state is consistent.

 Asynchronous thread aborts present a problem because they are processed at unpredictable points in the target thread's execution. To avoid this, code written to run on a thread that might be aborted in this manner would need to handle a <xref:System.Threading.ThreadAbortException> at almost every line of code, taking care to put application data back into a consistent state. It is not realistic to expect code to be written with this problem in mind or to write code that protects against all possible circumstances.

 Calls into unmanaged code and `finally` blocks will not be aborted asynchronously but immediately upon exit from one of these categories.

 The cause might be difficult to determine due to the randomness inherent to the problem.

## Resolution
 Avoid code design that requires the use of asynchronous thread aborts. There are several approaches more appropriate for interruption of a target thread that do not require a call to <xref:System.Threading.Thread.Abort%2A>. The safest is to introduce a mechanism, such as a common property, that signals the target thread to request an interrupt. The target thread checks the signal at certain safe checkpoints. If it notices that an interrupt has been requested, it can shut down gracefully.

## Effect on the Runtime
 This MDA has no effect on the CLR. It only reports data about asynchronous thread aborts.

## Output
 The MDA reports the ID of the thread performing the abort and the ID of the thread that is the target of the abort. These will never be the same because this is limited to asynchronous aborts.

## Configuration

```xml
<mdaConfig>
  <assistants>
    <asynchronousThreadAbort />
  </assistants>
</mdaConfig>
```

## Example
 Activating the `asynchronousThreadAbort` MDA requires only a call to <xref:System.Threading.Thread.Abort%2A> on a separate running thread. Consider the consequences if the contents of the thread start function were a set of more complex operations which might be interrupted at any arbitrary point by the abort.

```csharp
using System.Threading;
void FireMda()
{
    Thread t = new Thread(delegate() { Thread.Sleep(1000); });
    t.Start();
    // The following line activates the MDA.
    t.Abort();
    t.Join();
}
```

## See Also
 <xref:System.Threading.Thread> 
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)

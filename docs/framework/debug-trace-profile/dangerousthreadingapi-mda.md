---
title: "dangerousThreadingAPI MDA"
description: Review the dangerousThreadingAPI managed debugging assistant (MDA), which is activated when Thread.Suspend is called on a thread other than the current thread.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "suspending threads"
  - "DangerousThreadingAPI MDA"
  - "managed debugging assistants (MDAs), dangerous threading operations"
  - "threading [.NET Framework], suspending"
  - "MDAs (managed debugging assistants), dangerous threading operations"
  - "Suspend method"
  - "threading [.NET Framework], managed debugging assistants"
ms.assetid: 3e5efbc5-92e4-4229-b31f-ce368a1adb96
---
# dangerousThreadingAPI MDA

[!INCLUDE [net-framework-specific](../includes/net-framework-specific.md)]

The `dangerousThreadingAPI` managed debugging assistant (MDA) is activated when the <xref:System.Threading.Thread.Suspend%2A?displayProperty=nameWithType> method is called on a thread other than the current thread.

## Symptoms

 An application is unresponsive. System or application data might be left in an unpredictable state temporarily or even after an application has been shut down. Some operations are not completing as expected.

 Symptoms can vary widely due to the randomness inherent to the problem.

## Cause

 A thread is asynchronously suspended by another thread using the <xref:System.Threading.Thread.Suspend%2A> method. There is no way to determine when it is safe to suspend another thread which might be in the middle of an operation. Suspending the thread can result in the corruption of data or the breaking of invariants. Should a thread be placed into a suspended state and never resumed using the <xref:System.Threading.Thread.Resume%2A> method, the application can stop responding and possibly damage application data. These methods have been marked as obsolete.

 If synchronization primitives are held by the target thread, they remain held during suspension. This can lead to deadlocks should another thread, for example the thread performing the <xref:System.Threading.Thread.Suspend%2A>, attempt to acquire a lock on the primitive. In this situation, the problem manifests itself as a deadlock.

## Resolution

 Avoid designs that require the use of <xref:System.Threading.Thread.Suspend%2A> and <xref:System.Threading.Thread.Resume%2A>. For cooperation between threads, use synchronization primitives such as <xref:System.Threading.Lock>, <xref:System.Threading.Monitor>, <xref:System.Threading.ReaderWriterLock>, <xref:System.Threading.Mutex>, or the C# `lock` statement. If you must use these methods, reduce the window of time and minimize the amount of code that executes while the thread is in a suspended state.

## Effect on the Runtime

 This MDA has no effect on the CLR. It only reports data about dangerous threading operations.

## Output

 The MDA identifies the dangerous threading method that caused it to be activated.

## Configuration

```xml
<mdaConfig>
  <assistants>
    <dangerousThreadingAPI />
  </assistants>
</mdaConfig>
```

## Example

 The following code example demonstrates a call to the <xref:System.Threading.Thread.Suspend%2A> method that causes the activation of the `dangerousThreadingAPI`.

```csharp
using System.Threading;
void FireMda()
{
Thread t = new Thread(delegate() { Thread.Sleep(1000); });
    t.Start();
    // The following line activates the MDA.
    t.Suspend();
    t.Resume();
    t.Join();
}
```

## See also

- <xref:System.Threading.Thread>
- [Diagnosing Errors with Managed Debugging Assistants](diagnosing-errors-with-managed-debugging-assistants.md)
- [lock Statement](../../csharp/language-reference/statements/lock.md)

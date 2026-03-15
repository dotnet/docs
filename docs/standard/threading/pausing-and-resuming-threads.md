---
title: "Pausing and interrupting threads"
description: Learn how to pause & interrupt threads in .NET. Learn how to use methods like Thread.Sleep & Thread.Interrupt, & exceptions such as ThreadInterruptedException.
ms.date: "02/20/2026"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "interrupting threads"
  - "threading [.NET], pausing"
  - "pausing threads"
ms.topic: how-to
ai-usage: ai-assisted
---
# Pausing and interrupting threads

The most common ways to synchronize the activities of threads are to block and release threads, or to lock objects or regions of code. For more information on these locking and blocking mechanisms, see [Overview of Synchronization Primitives](overview-of-synchronization-primitives.md).  
  
 You can also have threads put themselves to sleep. When threads are blocked or sleeping, you can use a <xref:System.Threading.ThreadInterruptedException> to break them out of their wait states.  
  
## The Thread.Sleep method

 Calling the <xref:System.Threading.Thread.Sleep%2A?displayProperty=nameWithType> method causes the current thread to immediately block for the number of milliseconds or the time interval you pass to the method, and yields the remainder of its time slice to another thread. Once that interval elapses, the sleeping thread resumes execution.  
  
 One thread cannot call <xref:System.Threading.Thread.Sleep%2A?displayProperty=nameWithType> on another thread.  <xref:System.Threading.Thread.Sleep%2A?displayProperty=nameWithType> is a static method that always causes the current thread to sleep.  
  
 Calling <xref:System.Threading.Thread.Sleep%2A?displayProperty=nameWithType> with a value of <xref:System.Threading.Timeout.Infinite?displayProperty=nameWithType> causes a thread to sleep until another thread calls the <xref:System.Threading.Thread.Interrupt%2A?displayProperty=nameWithType> method on the sleeping thread. The following example illustrates interrupting a sleeping thread.

:::code language="csharp" source="./snippets/pausing-and-resuming-threads/csharp/InterruptThread/Program.cs" id="Snippet1":::
:::code language="vb" source="./snippets/pausing-and-resuming-threads/vb/InterruptThread/Program.vb" id="Snippet1":::

The example calls <xref:System.Threading.Thread.Join%2A?displayProperty=nameWithType> to block the calling thread until the interrupted thread finishes execution.

## Interrupting threads

 You can interrupt a waiting thread by calling the <xref:System.Threading.Thread.Interrupt%2A?displayProperty=nameWithType> method on the blocked thread to throw a <xref:System.Threading.ThreadInterruptedException>, which breaks the thread out of the blocking call. The thread should catch the <xref:System.Threading.ThreadInterruptedException> and do whatever is appropriate to continue working. If the thread ignores the exception, the runtime catches the exception and stops the thread.  
  
> [!NOTE]
> If the target thread is not blocked when <xref:System.Threading.Thread.Interrupt%2A?displayProperty=nameWithType> is called, the thread is not interrupted until it blocks. If the thread never blocks, it could complete without ever being interrupted.  
  
 If a wait is a managed wait, then <xref:System.Threading.Thread.Interrupt%2A?displayProperty=nameWithType> wakes the thread immediately. If a wait is an unmanaged wait (for example, a platform invoke call to the Win32 [WaitForSingleObject](/windows/desktop/api/synchapi/nf-synchapi-waitforsingleobject) function), <xref:System.Threading.Thread.Interrupt%2A?displayProperty=nameWithType> can't take control of the thread until it returns to or calls into managed code. In managed code, the behavior is as follows:

- <xref:System.Threading.Thread.Interrupt%2A?displayProperty=nameWithType> wakes a thread out of any wait it might be in and causes a <xref:System.Threading.ThreadInterruptedException> to be thrown in the destination thread.

- .NET Framework only: <xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType> wakes a thread out of any wait it might be in and causes a <xref:System.Threading.ThreadAbortException> to be thrown on the thread. For details, see [Destroy threads](destroying-threads.md).
  
## See also

- <xref:System.Threading.Thread>
- <xref:System.Threading.ThreadInterruptedException>
- <xref:System.Threading.ThreadAbortException>
- [Threading](managed-threading-basics.md)
- [Using Threads and Threading](using-threads-and-threading.md)
- [Overview of Synchronization Primitives](overview-of-synchronization-primitives.md)
- [Canceling threads cooperatively](canceling-threads-cooperatively.md)

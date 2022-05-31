---
title: SYSLIB0006 warning
description: Learn about the obsoletions that generate compile-time warning SYSLIB0006.
ms.date: 10/20/2020
---
# SYSLIB0006: Thread.Abort is not supported

The following APIs are marked obsolete, starting in .NET 5. Use of these APIs generates warning `SYSLIB0006` at compile time and a <xref:System.PlatformNotSupportedException> at run time.

- <xref:System.Threading.Thread.Abort?displayProperty=nameWithType>
- <xref:System.Threading.Thread.Abort(System.Object)?displayProperty=nameWithType>

When you call <xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType> to abort a thread other than the current thread, you don't know what code has executed or failed to execute when the <xref:System.Threading.ThreadAbortException> is thrown. You also cannot be certain of the state of your application or any application and user state that it's responsible for preserving. For example, calling <xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType> may prevent the execution of static constructors or the release of managed or unmanaged resources. For this reason, <xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType> always throws a <xref:System.PlatformNotSupportedException> on .NET Core and .NET 5+.

## Workarounds

Use a <xref:System.Threading.CancellationToken> to abort processing of a unit of work instead of calling <xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType>. The following example illustrates the use of <xref:System.Threading.CancellationToken>.

```csharp
void ProcessPendingWorkItemsNew(CancellationToken cancellationToken)
{
    if (QueryIsMoreWorkPending())
    {
        // If the CancellationToken is marked as "needs to cancel",
        // this will throw the appropriate exception.
        cancellationToken.ThrowIfCancellationRequested();

        WorkItem work = DequeueWorkItem();
        ProcessWorkItem(work);
    }
}
```

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]

## See also

- [Thread.Abort is obsolete](../../core/compatibility/core-libraries/5.0/thread-abort-obsolete.md)
- [Cancellation in managed threads](../../standard/threading/cancellation-in-managed-threads.md)

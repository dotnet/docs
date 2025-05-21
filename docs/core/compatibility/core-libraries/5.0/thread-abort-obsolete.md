---
title: "Breaking change: Thread.Abort is obsolete"
description: Learn about the .NET 5 breaking change in core .NET libraries where the Thread.Abort APIs are obsolete.
ms.date: 11/01/2020
ms.topic: concept-article
---
# Thread.Abort is obsolete

The <xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType> APIs are obsolete. Projects that target .NET 5 or a later version will encounter compile-time warning `SYSLIB0006` if these methods are called.

## Change description

Previously, calls to <xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType> did not produce compile-time warnings, however, the method did throw a <xref:System.PlatformNotSupportedException> at run time.

Starting in .NET 5, <xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType> is marked obsolete as warning. Calling this method produces compiler warning `SYSLIB0006`. The implementation of the method is unchanged, and it continues to throw a <xref:System.PlatformNotSupportedException>.

## Reason for change

Given that <xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType> always throws a <xref:System.PlatformNotSupportedException> on all .NET implementations except .NET Framework, <xref:System.ObsoleteAttribute> was added to the method to draw attention to places where it's called.

When you call <xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType> to abort a thread other than the current thread, you don't know what code has executed or failed to execute when the <xref:System.Threading.ThreadAbortException> is thrown. You also cannot be certain of the state of your application or any application and user state that it's responsible for preserving. For example, calling <xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType> may prevent the execution of static constructors or the release of managed or unmanaged resources. For this reason, <xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType> always throws a <xref:System.PlatformNotSupportedException> on .NET Core and .NET 5+.

## Version introduced

5.0

## Recommended action

- Use a <xref:System.Threading.CancellationToken> to abort processing of a unit of work instead of calling <xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType>. The following example illustrates the use of <xref:System.Threading.CancellationToken>.

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

  For more information, see [Cancellation in managed threads](../../../../standard/threading/cancellation-in-managed-threads.md).

- To suppress the compile-time warning, suppress warning code `SYSLIB0006`. The warning code is specific to <xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType> and suppressing it doesn't suppress other obsoletion warnings in your code. However, we recommend that you remove calls to <xref:System.Threading.Thread.Abort%2A?displayProperty=nameWithType> instead of suppressing the warning.

  ```csharp
  void MyMethod()
  {
  #pragma warning disable SYSLIB0006
      Thread.CurrentThread.Abort();
  #pragma warning restore SYSLIB0006
  }
  ```

  You can also suppress the warning in the project file.

  ```xml
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net5.0</TargetFramework>
    <!-- Disable "Thread.Abort is obsolete" warnings for entire project. -->
    <NoWarn>$(NoWarn);SYSLIB0006</NoWarn>
  </PropertyGroup>
  ```

## Affected APIs

- <xref:System.Threading.Thread.Abort%2A?displayProperty=fullName>

---
title: System.AppDomain.UnhandledException event
description: Learn about the System.AppDomain.UnhandledException event.
ms.date: 01/24/2024
---
# System.AppDomain.UnhandledException event

[!INCLUDE [context](includes/context.md)]

The <xref:System.AppDomain.UnhandledException> event provides notification of uncaught exceptions. It allows the application to log information about the exception before the system default handler reports the exception to the user and terminates the application. If sufficient information about the state of the application is available, other actions may be undertaken - such as saving program data for later recovery. Caution is advised, because program data can become corrupted when exceptions are not handled. The handler will also be running while holding locks held when the exception was thrown, so care should be taken to avoid waiting on other resources which could introduce deadlocks.

This event can be handled in any application domain. However, the event is not necessarily raised in the application domain where the exception occurred. An exception is unhandled only if the entire stack for the thread has been unwound without finding an applicable exception handler, so the first place the event can be raised is in the application domain where the thread originated.

If the <xref:System.AppDomain.UnhandledException> event is handled in the default application domain, it is raised there for any unhandled exception in any thread, no matter what application domain the thread started in. If the thread started in an application domain that has an event handler for <xref:System.AppDomain.UnhandledException>, the event is raised in that application domain. If that application domain is not the default application domain, and there is also an event handler in the default application domain, the event is raised in both application domains.

For example, suppose a thread starts in application domain "AD1", calls a method in application domain "AD2", and from there calls a method in application domain "AD3", where it throws an exception. The first application domain in which the <xref:System.AppDomain.UnhandledException> event can be raised is "AD1". If that application domain is not the default application domain, the event can also be raised in the default application domain.

> [!NOTE]
> The common language runtime suspends thread aborts while event handlers for the <xref:System.AppDomain.UnhandledException> event are executing.

If the event handler has a <xref:System.Runtime.ConstrainedExecution.ReliabilityContractAttribute> attribute with the appropriate flags, the event handler is treated as a constrained execution region.

Starting with .NET Framework 4, this event is not raised for exceptions that corrupt the state of the process, such as stack overflows or access violations, unless the event handler is security-critical and has the <xref:System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptionsAttribute> attribute.

To register an event handler for this event, you must have the required permissions, or a <xref:System.Security.SecurityException> is thrown.

For more information about handling events, see [Handling and Raising Events](../../standard/events/index.md).

## Other events for unhandled exceptions

For certain application models, the <xref:System.AppDomain.UnhandledException> event can be preempted by other events if the unhandled exception occurs in the main application thread.

In applications that use Windows Forms, unhandled exceptions in the main application thread cause the <xref:System.Windows.Forms.Application.ThreadException?displayProperty=nameWithType> event to be raised. If this event is handled, the default behavior is that the unhandled exception does not terminate the application, although the application is left in an unknown state. In that case, the <xref:System.AppDomain.UnhandledException> event is not raised. This behavior can be changed by using the application configuration file, or by using the <xref:System.Windows.Forms.Application.SetUnhandledExceptionMode%2A?displayProperty=nameWithType> method to change the mode to <xref:System.Windows.Forms.UnhandledExceptionMode.ThrowException?displayProperty=nameWithType> before the <xref:System.Windows.Forms.Application.ThreadException> event handler is hooked up. This applies only to the main application thread. The <xref:System.AppDomain.UnhandledException> event is raised for unhandled exceptions thrown in other threads.

The Visual Basic application framework provides another event for unhandled exceptions in the main application thread&mdash;the <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase.UnhandledException?displayProperty=nameWithType> event. This event has an event arguments object with the same name as the event arguments object used by <xref:System.AppDomain.UnhandledException?displayProperty=nameWithType>, but with different properties. In particular, this event arguments object has an <xref:Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs.ExitApplication> property that allows the application to continue running, ignoring the unhandled exception (and leaving the application in an unknown state). In that case, the <xref:System.AppDomain.UnhandledException?displayProperty=nameWithType> event is not raised.

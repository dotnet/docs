---
title: System.Runtime.InteropServices.COMException class
description: Learn about the System.Runtime.InteropServices.COMException class.
ms.date: 12/31/2023
ms.topic: article
---
# System.Runtime.InteropServices.COMException class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Runtime.InteropServices.COMException> class is the exception that's thrown when an unrecognized HRESULT is returned from a COM method call.

The common language runtime transforms well-known HRESULTs to .NET exceptions, enabling COM objects to return meaningful error information to managed clients. The HRESULT-to-exception mapping also works in the other direction by returning specific HRESULTs to unmanaged clients. For mapping details, see [How to map HRESULTs and exceptions](../../framework/interop/how-to-map-hresults-and-exceptions.md).

When the runtime encounters an unfamiliar HRESULT (an HRESULT that lacks a specific, corresponding exception), it throws an instance of the <xref:System.Runtime.InteropServices.COMException> class. This all-purpose exception exposes the same members as any exception, and inherits a public <xref:System.Runtime.InteropServices.ExternalException.ErrorCode> property that contains the HRESULT returned by the callee. If an error message is available to the runtime (obtained from the [IErrorInfo](/previous-versions/windows/desktop/ms723041(v=vs.85)) interface or the `Err` object in Visual Basic, or in some cases from the operating system), the message is returned to the caller. However, if the COM component developer fails to include an error message, the runtime returns the eight-digit HRESULT in place of a message string. Having an HRESULT allows the caller to determine the cause of the generic exception.

## Handle a COMException exception

The following are some considerations for troubleshooting a <xref:System.Runtime.InteropServices.COMException> exception.

Check the <xref:System.Runtime.InteropServices.ExternalException.ErrorCode> property
When the runtime encounters an unfamiliar HRESULT and throws a <xref:System.Runtime.InteropServices.COMException> exception,  the <xref:System.Runtime.InteropServices.ExternalException.ErrorCode> property includes either the error message or, if an error message is unavailable, the eight-digit HRESULT value. The error message or the HRESULT value can help you determine the cause of the exception.

For a list of HRESULT values, see [Common HRESULT Values](/windows/win32/seccrypto/common-hresult-values).

When passing late-bound arguments to methods of Microsoft Office objects, a <xref:System.Runtime.InteropServices.COMException> exception may be thrown when the objects are COM objects. The late binder assumes that such method calls involve a `ByRef` parameter and that the property you pass has a `set` accessor. If the property does not, .NET generates a <xref:System.MissingMethodException> exception (with a `CORE_E_MISSINGMETHOD` HRESULT ). To work around this behavior, use early-bound objects or pass a variable instead of a property of the object.

COM is used to communicate between Visual Studio and the [hosting process](/visualstudio/ide/hosting-process-vshost-exe?preserve-view=vs-2015). Because it is used before code runs, a call to [CoInitializeSecurity](/windows/win32/api/combaseapi/nf-combaseapi-coinitializesecurity) causes this exception to be thrown. In some cases, running Visual Studio as Administrator may resolve the issue. You can also [disable the hosting process](/visualstudio/ide/how-to-disable-the-hosting-process?preserve-view=vs-2015).

## Throw a COMException exception

Although you can use the <xref:System.Runtime.InteropServices.COMException> class to return specific HRESULTs to unmanaged clients, throwing a specific .NET exception is better than using a generic exception. Consider that managed clients as well as unmanaged clients can use your .NET object, and throwing an HRESULT to a managed caller is less comprehensible than throwing an exception.

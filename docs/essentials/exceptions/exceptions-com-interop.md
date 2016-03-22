# Handling COM interop exceptions

Managed and unmanaged code can work together to handle exceptions. If a method throws an exception in managed code, the common language runtime can pass an HRESULT to a COM object. If a method fails in unmanaged code by returning a failure HRESULT, the runtime throws an exception that can be caught by managed code.

The runtime automatically maps the HRESULT from COM interop to more specific exceptions. For example, E_ACCESSDENIED becomes [UnauthorizedAccessException](https://msdn.microsoft.com/library/system.unauthorizedaccessexception), E_OUTOFMEMORY becomes [OutOfMemoryException](https://msdn.microsoft.com/library/system.outofmemoryexception), and so on.

If the HRESULT is a custom result or if it is unknown to the runtime, the runtime passes a generic [COMException](https://msdn.microsoft.com/library/system.runtime.interopservices.comexception) to the client. The **ErrorCode** property of the **COMException** contains the HRESULT value.

## Working with IErrorInfo

When an error is passed from COM to managed code, the runtime populates the exception object with error information. COM objects that support IErrorInfo and return HRESULTS provide this information to managed code exceptions. For example, the runtime maps the Description from the COM error to the exception's [Message](https://msdn.microsoft.com/library/system.exception.message) property. If the HRESULT provides no additional error information, the runtime fills many of the exception's properties with default values.

If a method fails in unmanaged code, an exception can be passed to a managed code segment. The topic [How to: Map HRESULTs and Exceptions](https://msdn.microsoft.com/library/9ztbc5s1) contains a table showing how HRESULTS map to runtime exception objects.

---
title: "Creating Prototypes in Managed Code"
description: Create prototypes in .NET managed code, so you can access unmanaged functions and use attribute fields that annotate method definition in managed code.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "prototypes in managed code"
  - "COM interop, DLL functions"
  - "unmanaged functions"
  - "platform invoke, creating prototypes"
  - "COM interop, platform invoke"
  - "interoperation with unmanaged code, DLL functions"
  - "interoperation with unmanaged code, platform invoke"
  - "platform invoke, object fields"
  - "DLL functions"
  - "object fields in platform invoke"
ms.assetid: ecdcf25d-cae3-4f07-a2b6-8397ac6dc42d
---

# Creating Prototypes in Managed Code

This topic describes how to access unmanaged functions and introduces several attribute fields that annotate method definition in managed code. For examples that demonstrate how to construct .NET-based declarations to be used with platform invoke, see [Marshaling Data with Platform Invoke](marshaling-data-with-platform-invoke.md).  
  
 Before you can access an unmanaged DLL function from managed code, you need to know the name of the function and the name of the DLL that exports it. With this information, you can begin to write the managed definition for an unmanaged function that is implemented in a DLL. Furthermore, you can adjust the way that platform invoke creates the function and marshals data to and from the function.  
  
> [!NOTE]
> Windows API functions that allocate a string enable you to free the string by using a method such as `LocalFree`. Platform invoke handles such parameters differently. For platform invoke calls, make the parameter an `IntPtr` type instead of a `String` type. Use methods that are provided by the <xref:System.Runtime.InteropServices.Marshal?displayProperty=nameWithType> class to convert the type to a string manually and free it manually.  
  
## Declaration Basics  

 Managed definitions to unmanaged functions are language-dependent, as you can see in the following examples. For more complete code examples, see [Platform Invoke Examples](platform-invoke-examples.md).  
  
```vb
Friend Class NativeMethods
    Friend Declare Auto Function MessageBox Lib "user32.dll" (
        ByVal hWnd As IntPtr,
        ByVal lpText As String,
        ByVal lpCaption As String,
        ByVal uType As UInteger) As Integer
End Class
```
  
 To apply the <xref:System.Runtime.InteropServices.DllImportAttribute.BestFitMapping?displayProperty=nameWithType>, <xref:System.Runtime.InteropServices.DllImportAttribute.CallingConvention?displayProperty=nameWithType>, <xref:System.Runtime.InteropServices.DllImportAttribute.ExactSpelling?displayProperty=nameWithType>, <xref:System.Runtime.InteropServices.DllImportAttribute.PreserveSig?displayProperty=nameWithType>, <xref:System.Runtime.InteropServices.DllImportAttribute.SetLastError?displayProperty=nameWithType>, or <xref:System.Runtime.InteropServices.DllImportAttribute.ThrowOnUnmappableChar?displayProperty=nameWithType> fields to a Visual Basic declaration, you must use the <xref:System.Runtime.InteropServices.DllImportAttribute> attribute instead of the `Declare` statement.  
  
```vb
Imports System.Runtime.InteropServices

Friend Class NativeMethods
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Friend Shared Function MessageBox(
        ByVal hWnd As IntPtr,
        ByVal lpText As String,
        ByVal lpCaption As String,
        ByVal uType As UInteger) As Integer
    End Function
End Class
```
  
```csharp
using System;
using System.Runtime.InteropServices;

internal static class NativeMethods
{
    [DllImport("user32.dll")]
    internal static extern int MessageBox(
        IntPtr hWnd, string lpText, string lpCaption, uint uType);
}
```
  
```cpp
using namespace System;
using namespace System::Runtime::InteropServices;

[DllImport("user32.dll")]
extern "C" int MessageBox(
    IntPtr hWnd, String* lpText, String* lpCaption, unsigned int uType);
```
  
## Adjusting the Definition  

 Whether you set them explicitly or not, attribute fields are at work defining the behavior of managed code. Platform invoke operates according to the default values set on various fields that exist as metadata in an assembly. You can alter this default behavior by adjusting the values of one or more fields. In many cases, you use the <xref:System.Runtime.InteropServices.DllImportAttribute> to set a value.  
  
 The following table lists the complete set of attribute fields that pertain to platform invoke. For each field, the table includes the default value and a link to information on how to use these fields to define unmanaged DLL functions.  
  
|Field|Description|  
|-----------|-----------------|  
|<xref:System.Runtime.InteropServices.DllImportAttribute.BestFitMapping>|Enables or disables best-fit mapping.|  
|<xref:System.Runtime.InteropServices.DllImportAttribute.CallingConvention>|Specifies the calling convention to use in passing method arguments. The default is `WinAPI`, which corresponds to `__stdcall` for the 32-bit Intel-based platforms.|  
|<xref:System.Runtime.InteropServices.DllImportAttribute.CharSet>|Controls name mangling and the way that string arguments should be marshaled to the function. The default is `CharSet.Ansi`.|  
|<xref:System.Runtime.InteropServices.DllImportAttribute.EntryPoint>|Specifies the DLL entry point to be called.|  
|<xref:System.Runtime.InteropServices.DllImportAttribute.ExactSpelling>|Controls whether an entry point should be modified to correspond to the character set. The default value varies by programming language.|  
|<xref:System.Runtime.InteropServices.DllImportAttribute.PreserveSig>|Controls whether the managed method signature should be transformed into an unmanaged signature that returns an HRESULT and has an additional [out, retval] argument for the return value.<br /><br /> The default is `true` (the signature should not be transformed).|  
|<xref:System.Runtime.InteropServices.DllImportAttribute.SetLastError>|Enables the caller to use the `Marshal.GetLastWin32Error` API function to determine whether an error occurred while executing the method. In Visual Basic, the default is `true`; in C# and C++, the default is `false`.|  
|<xref:System.Runtime.InteropServices.DllImportAttribute.ThrowOnUnmappableChar>|Controls throwing of an exception on an unmappable Unicode character that is converted to an ANSI "?" character.|  
  
 For detailed reference information, see <xref:System.Runtime.InteropServices.DllImportAttribute>.  
  
## Platform invoke security considerations  

 The `Assert`, `Deny`, and `PermitOnly` members of the <xref:System.Security.Permissions.SecurityAction> enumeration are referred to as *stack walk modifiers*. These members are ignored if they are used as declarative attributes on platform invoke declarations and COM Interface Definition Language (IDL) statements.  
  
### Platform Invoke Examples  

 The platform invoke samples in this section illustrate the use of the `RegistryPermission` attribute with the stack walk modifiers.  
  
 In the following example, the <xref:System.Security.Permissions.SecurityAction>`Assert`, `Deny`, and `PermitOnly` modifiers are ignored.  
  
```csharp  
[DllImport("MyClass.dll", EntryPoint = "CallRegistryPermission")]  
[RegistryPermission(SecurityAction.Assert, Unrestricted = true)]  
    private static extern bool CallRegistryPermissionAssert();  
  
[DllImport("MyClass.dll", EntryPoint = "CallRegistryPermission")]  
[RegistryPermission(SecurityAction.Deny, Unrestricted = true)]  
    private static extern bool CallRegistryPermissionDeny();  
  
[DllImport("MyClass.dll", EntryPoint = "CallRegistryPermission")]  
[RegistryPermission(SecurityAction.PermitOnly, Unrestricted = true)]  
    private static extern bool CallRegistryPermissionDeny();  
```  
  
 However, the `Demand` modifier in the following example is accepted.  
  
```csharp
[DllImport("MyClass.dll", EntryPoint = "CallRegistryPermission")]  
[RegistryPermission(SecurityAction.Demand, Unrestricted = true)]  
    private static extern bool CallRegistryPermissionDeny();  
```  
  
 <xref:System.Security.Permissions.SecurityAction> modifiers do work correctly if they are placed on a class that contains (wraps) the platform invoke call.  
  
```cpp  
      [RegistryPermission(SecurityAction.Demand, Unrestricted = true)]  
public ref class PInvokeWrapper  
{  
public:  
[DllImport("MyClass.dll", EntryPoint = "CallRegistryPermission")]  
    private static extern bool CallRegistryPermissionDeny();  
};  
```  
  
```csharp  
[RegistryPermission(SecurityAction.Demand, Unrestricted = true)]  
class PInvokeWrapper  
{  
[DllImport("MyClass.dll", EntryPoint = "CallRegistryPermission")]  
    private static extern bool CallRegistryPermissionDeny();  
}  
```  
  
 <xref:System.Security.Permissions.SecurityAction> modifiers also work correctly in a nested scenario where they are placed on the caller of the platform invoke call:  
  
```cpp  
      {  
public ref class PInvokeWrapper  
public:  
    [DllImport("MyClass.dll", EntryPoint = "CallRegistryPermission")]  
    private static extern bool CallRegistryPermissionDeny();  
  
    [RegistryPermission(SecurityAction.Demand, Unrestricted = true)]  
    public static bool CallRegistryPermission()  
    {  
     return CallRegistryPermissionInternal();  
    }  
};  
```  
  
```csharp  
class PInvokeScenario  
{  
    [DllImport("MyClass.dll", EntryPoint = "CallRegistryPermission")]  
    private static extern bool CallRegistryPermissionInternal();  
  
    [RegistryPermission(SecurityAction.Assert, Unrestricted = true)]  
    public static bool CallRegistryPermission()  
    {  
     return CallRegistryPermissionInternal();  
    }  
}  
```  
  
#### COM Interop Examples  

 The COM interop samples in this section illustrate the use of the `RegistryPermission` attribute with the stack walk modifiers.  
  
 The following COM interop interface declarations ignore the `Assert`, `Deny`, and `PermitOnly` modifiers, similarly to the platform invoke examples in the previous section.  
  
```csharp
[ComImport, Guid("12345678-43E6-43c9-9A13-47F40B338DE0")]  
interface IAssertStubsItf  
{  
[RegistryPermission(SecurityAction.Assert, Unrestricted = true)]  
    bool CallRegistryPermission();  
[FileIOPermission(SecurityAction.Assert, Unrestricted = true)]  
    bool CallFileIoPermission();  
}  
  
[ComImport, Guid("12345678-43E6-43c9-9A13-47F40B338DE0")]  
interface IDenyStubsItf  
{  
[RegistryPermission(SecurityAction.Deny, Unrestricted = true)]  
    bool CallRegistryPermission();  
[FileIOPermission(SecurityAction.Deny, Unrestricted = true)]  
    bool CallFileIoPermission();  
}  
  
[ComImport, Guid("12345678-43E6-43c9-9A13-47F40B338DE0")]  
interface IAssertStubsItf  
{  
[RegistryPermission(SecurityAction.PermitOnly, Unrestricted = true)]  
    bool CallRegistryPermission();  
[FileIOPermission(SecurityAction.PermitOnly, Unrestricted = true)]  
    bool CallFileIoPermission();  
}  
```  
  
 Additionally, the `Demand` modifier is not accepted in COM interop interface declaration scenarios, as shown in the following example.  
  
```csharp  
[ComImport, Guid("12345678-43E6-43c9-9A13-47F40B338DE0")]  
interface IDemandStubsItf  
{  
[RegistryPermission(SecurityAction.Demand, Unrestricted = true)]  
    bool CallRegistryPermission();  
[FileIOPermission(SecurityAction.Demand, Unrestricted = true)]  
    bool CallFileIoPermission();  
}  
```  
  
## See also

- [Consuming Unmanaged DLL Functions](consuming-unmanaged-dll-functions.md)
- [Specifying an Entry Point](specifying-an-entry-point.md)
- [Specifying a Character Set](specifying-a-character-set.md)
- [Platform Invoke Examples](platform-invoke-examples.md)
- [Platform Invoke Security Considerations](/previous-versions/dotnet/netframework-4.0/bb397754(v=vs.100))
- [Identifying Functions in DLLs](identifying-functions-in-dlls.md)
- [Creating a Class to Hold DLL Functions](creating-a-class-to-hold-dll-functions.md)
- [Calling a DLL Function](calling-a-dll-function.md)

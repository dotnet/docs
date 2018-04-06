---
title: "Default Marshaling for Strings"
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "strings, interop marshaling"
  - "interop marshaling, strings"
ms.assetid: 9baea3ce-27b3-4b4f-af98-9ad0f9467e6f
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Default Marshaling for Strings
Both the <xref:System.String?displayProperty=nameWithType> and <xref:System.Text.StringBuilder?displayProperty=nameWithType> classes have similar marshaling behavior.  
  
 Strings are marshaled as a COM-style `BSTR` type or as a null-terminated string (a character array that ends with a null character). The characters within the string can be marshaled as Unicode (the default on Windows systems) or ANSI.  
  
 This topic provides the following information on marshaling string types:  
  
-   [Strings Used in Interfaces](#cpcondefaultmarshalingforstringsanchor1)  
  
-   [Strings Used in Platform Invoke](#cpcondefaultmarshalingforstringsanchor5)  
  
-   [Strings Used in Structures](#cpcondefaultmarshalingforstringsanchor2)  
  
-   [Fixed-Length String Buffers](#cpcondefaultmarshalingforstringsanchor3)  
  
<a name="cpcondefaultmarshalingforstringsanchor1"></a>

## Strings Used in Interfaces  
 The following table shows the marshaling options for the string data type when marshaled as a method argument to unmanaged code. The <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute provides several <xref:System.Runtime.InteropServices.UnmanagedType> enumeration values to marshal strings to COM interfaces.  
  
|Enumeration type|Description of unmanaged format|  
|----------------------|-------------------------------------|  
|`UnmanagedType.BStr` (default)|A COM-style `BSTR` with a prefixed length and Unicode characters.|  
|`UnmanagedType.LPStr`|A pointer to a null-terminated array of ANSI characters.|  
|`UnmanagedType.LPWStr`|A pointer to a null-terminated array of Unicode characters.|  
  
 This table applies to strings. However, for <xref:System.Text.StringBuilder>, the only options allowed are `UnmanagedType.LPStr` and `UnmanagedType.LPWStr`.  
  
 The following example shows strings declared in the `IStringWorker` interface.  
  
```cpp  
public interface IStringWorker {  
void PassString1(String s);  
void PassString2([MarshalAs(UnmanagedType.BStr)]String s);  
void PassString3([MarshalAs(UnmanagedType.LPStr)]String s);  
void PassString4([MarshalAs(UnmanagedType.LPWStr)]String s);  
void PassStringRef1(ref String s);  
void PassStringRef2([MarshalAs(UnmanagedType.BStr)]ref String s);  
void PassStringRef3([MarshalAs(UnmanagedType.LPStr)]ref String s);  
void PassStringRef4([MarshalAs(UnmanagedType.LPWStr)]ref String s);  
);
```

The following example shows the corresponding interface described in a type library.

```
[…]  
interface IStringWorker : IDispatch {  
HRESULT PassString1([in] BSTR s);  
HRESULT PassString2([in] BSTR s);  
HRESULT PassString3([in] LPStr s);  
HRESULT PassString4([in] LPWStr s);  
HRESULT PassStringRef1([in, out] BSTR *s);  
HRESULT PassStringRef2([in, out] BSTR *s);  
HRESULT PassStringRef3([in, out] LPStr *s);  
HRESULT PassStringRef4([in, out] LPWStr *s);  
);
```

<a name="cpcondefaultmarshalingforstringsanchor5"></a>

## Strings Used in Platform Invoke  
 Platform invoke copies string arguments, converting from the .NET Framework format (Unicode) to the platform unmanaged format. Strings are immutable and are not copied back from unmanaged memory to managed memory when the call returns.  
  
 The following table lists the marshaling options for strings when marshaled as a method argument of a platform invoke call. The <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute provides several <xref:System.Runtime.InteropServices.UnmanagedType> enumeration values to marshal strings.  
  
|Enumeration type|Description of unmanaged format|  
|----------------------|-------------------------------------|  
|`UnmanagedType.AnsiBStr`|A COM-style `BSTR` with a prefixed length and ANSI characters.|  
|`UnmanagedType.BStr`|A COM-style `BSTR` with a prefixed length and Unicode characters.|  
|`UnmanagedType.LPStr`|A pointer to a null-terminated array of ANSI characters.|  
|`UnmanagedType.LPTStr`|A pointer to a null-terminated array of platform-dependent characters.|  
|`UnmanagedType.LPWStr`|A pointer to a null-terminated array of Unicode characters.|  
|`UnmanagedType.TBStr`|A COM-style `BSTR` with a prefixed length and platform-dependent characters.|  
|`VBByRefStr`|A value that enables Visual Basic .NET to change a string in unmanaged code, and have the results reflected in managed code. This value is supported only for platform invoke. This is default value in Visual Basic for `ByVal` strings.|  
  
 This table applies to strings. However, for <xref:System.Text.StringBuilder>, the only options allowed are `LPStr`, `LPTStr`, and `LPWStr`.  
  
 The following type definition shows the correct use of `MarshalAsAttribute` for platform invoke calls.  
  
```vb  
Class StringLibAPI      
Public Declare Auto Sub PassLPStr Lib "StringLib.Dll" _  
(<MarshalAs(UnmanagedType.LPStr)> s As String)      
Public Declare Auto Sub PassLPWStr Lib "StringLib.Dll" _  
(<MarshalAs(UnmanagedType.LPWStr)> s As String)      
Public Declare Auto Sub PassLPTStr Lib "StringLib.Dll" _  
(<MarshalAs(UnmanagedType.LPTStr)> s As String)      
Public Declare Auto Sub PassBStr Lib "StringLib.Dll" _  
(<MarshalAs(UnmanagedType.BStr)> s As String)      
Public Declare Auto Sub PassAnsiBStr Lib "StringLib.Dll" _  
(<MarshalAs(UnmanagedType.AnsiBStr)> s As String)      
Public Declare Auto Sub PassTBStr Lib "StringLib.Dll" _  
(<MarshalAs(UnmanagedType.TBStr)> s As String)  
End Class  
```

```csharp
class StringLibAPI {  
[DllImport("StringLib.Dll")]  
public static extern void PassLPStr([MarshalAs(UnmanagedType.LPStr)]  
String s);  
[DllImport("StringLib.Dll")]  
public static extern void   
PassLPWStr([MarshalAs(UnmanagedType.LPWStr)]String s);  
[DllImport("StringLib.Dll")]  
public static extern void   
PassLPTStr([MarshalAs(UnmanagedType.LPTStr)]String s);  
[DllImport("StringLib.Dll")]  
public static extern void PassBStr([MarshalAs(UnmanagedType.BStr)]  
String s);  
[DllImport("StringLib.Dll")]  
public static extern void   
PassAnsiBStr([MarshalAs(UnmanagedType.AnsiBStr)]String s);  
[DllImport("StringLib.Dll")]  
public static extern void PassTBStr([MarshalAs(UnmanagedType.TBStr)]  
String s);  
}  
```  
  
<a name="cpcondefaultmarshalingforstringsanchor2"></a>   
## Strings Used in Structures  
 Strings are valid members of structures; however, <xref:System.Text.StringBuilder> buffers are invalid in structures. The following table shows the marshaling options for the string data type when the type is marshaled as a field. The <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute provides several <xref:System.Runtime.InteropServices.UnmanagedType> enumeration values to marshal strings to a field.  
  
|Enumeration type|Description of unmanaged format|  
|----------------------|-------------------------------------|  
|`UnmanagedType.BStr`|A COM-style `BSTR` with a prefixed length and Unicode characters.|  
|`UnmanagedType.LPStr`|A pointer to a null-terminated array of ANSI characters.|  
|`UnmanagedType.LPTStr`|A pointer to a null-terminated array of platform-dependent characters.|  
|`UnmanagedType.LPWStr`|A pointer to a null-terminated array of Unicode characters.|  
|`UnmanagedType.ByValTStr`|A fixed-length array of characters; the array's type is determined by the character set of the containing structure.|  
  
 The `ByValTStr` type is used for inline, fixed-length character arrays that appear within a structure. Other types apply to string references contained within structures that contain pointers to strings.  
  
 The `CharSet` argument of the <xref:System.Runtime.InteropServices.StructLayoutAttribute> attribute that is applied to the containing structure determines the character format of strings in structures. The following example structures contain string references and inline strings, as well as ANSI, Unicode, and platform-dependent characters.  
  
### Type Library Representation  
  
```
struct StringInfoA {  
   char *    f1;  
   char      f2[256];  
};  
struct StringInfoW {  
   WCHAR *   f1;  
   WCHAR     f2[256];  
   BSTR      f3;  
};  
struct StringInfoT {  
   TCHAR *   f1;  
   TCHAR     f2[256];  
};  
```  
  
 The following code example shows how to use the <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute to define the same structure in different formats.  
  
```vb  
<StructLayout(LayoutKind.Sequential, CharSet := CharSet.Ansi)> _  
Structure StringInfoA  
<MarshalAs(UnmanagedType.LPStr)> Public f1 As String  
<MarshalAs(UnmanagedType.ByValTStr, SizeConst := 256)> _  
Public f2 As String  
End Structure  
<StructLayout(LayoutKind.Sequential, CharSet := CharSet.Unicode)> _  
Structure StringInfoW  
<MarshalAs(UnmanagedType.LPWStr)> Public f1 As String  
<MarshalAs(UnmanagedType.ByValTStr, SizeConst := 256)> _  
Public f2 As String  
<MarshalAs(UnmanagedType.BStr)> Public f3 As String  
End Structure  
<StructLayout(LayoutKind.Sequential, CharSet := CharSet.Auto)> _  
Structure StringInfoT  
<MarshalAs(UnmanagedType.LPTStr)> Public f1 As String  
<MarshalAs(UnmanagedType.ByValTStr, SizeConst := 256)> _  
Public f2 As String  
End Structure  
```  
  
```csharp  
[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]  
struct StringInfoA {  
   [MarshalAs(UnmanagedType.LPStr)] public String f1;  
   [MarshalAs(UnmanagedType.ByValTStr, SizeConst=256)] public String f2;  
}  
[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]  
struct StringInfoW {  
   [MarshalAs(UnmanagedType.LPWStr)] public String f1;  
   [MarshalAs(UnmanagedType.ByValTStr, SizeConst=256)] public String f2;  
   [MarshalAs(UnmanagedType.BStr)] public String f3;  
}  
[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]  
struct StringInfoT {  
   [MarshalAs(UnmanagedType.LPTStr)] public String f1;  
   [MarshalAs(UnmanagedType.ByValTStr, SizeConst=256)] public String f2;  
}  
```  
  
<a name="cpcondefaultmarshalingforstringsanchor3"></a>   
## Fixed-Length String Buffers  
 In some circumstances, a fixed-length character buffer must be passed into unmanaged code to be manipulated. Simply passing a string does not work in this case because the callee cannot modify the contents of the passed buffer. Even if the string is passed by reference, there is no way to initialize the buffer to a given size.  
  
 The solution is to pass a <xref:System.Text.StringBuilder> buffer as the argument instead of a string. A `StringBuilder` can be dereferenced and modified by the callee, provided it does not exceed the capacity of the `StringBuilder`. It can also be initialized to a fixed length. For example, if you initialize a `StringBuilder` buffer to a capacity of `N`, the marshaler provides a buffer of size (`N`+1) characters. The +1 accounts for the fact that the unmanaged string has a null terminator while `StringBuilder` does not.  
  
 For example, the Microsoft Win32 API `GetWindowText` function (defined in Windows.h) is a fixed-length character buffer that must be passed into unmanaged code to be manipulated. `LpString` points to a caller-allocated buffer of size `nMaxCount`. The caller is expected to allocate the buffer and set the `nMaxCount` argument to the size of the allocated buffer. The following code shows the `GetWindowText` function declaration as defined in Windows.h.  
  
```  
int GetWindowText(  
HWND hWnd,        // Handle to window or control.  
LPTStr lpString,  // Text buffer.  
int nMaxCount     // Maximum number of characters to copy.  
);  
```  
  
 A `StringBuilder` can be dereferenced and modified by the callee, provided it does not exceed the capacity of the `StringBuilder`. The following code example demonstrates how `StringBuilder` can be initialized to a fixed length.  
  
```vb  
Public Class Win32API  
Public Declare Auto Sub GetWindowText Lib "User32.Dll" _  
(h As Integer, s As StringBuilder, nMaxCount As Integer)  
End Class  
Public Class Window  
   Friend h As Integer ' Friend handle to Window.  
   Public Function GetText() As String  
      Dim sb As New StringBuilder(256)  
      Win32API.GetWindowText(h, sb, sb.Capacity + 1)  
   Return sb.ToString()  
   End Function  
End Class  
```  
  
```csharp  
public class Win32API {  
[DllImport("User32.Dll")]  
public static extern void GetWindowText(int h, StringBuilder s,   
int nMaxCount);  
}  
public class Window {  
   internal int h;        // Internal handle to Window.  
   public String GetText() {  
      StringBuilder sb = new StringBuilder(256);  
      Win32API.GetWindowText(h, sb, sb.Capacity + 1);  
   return sb.ToString();  
   }  
}  
```  
  
## See Also  
 [Default Marshaling Behavior](default-marshaling-behavior.md)  
 [Blittable and Non-Blittable Types](blittable-and-non-blittable-types.md)  
 [Directional Attributes](https://msdn.microsoft.com/library/241ac5b5-928e-4969-8f58-1dbc048f9ea2(v=vs.100))  
 [Copying and Pinning](copying-and-pinning.md)

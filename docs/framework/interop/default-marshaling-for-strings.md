---
title: "Default Marshaling for Strings"
description: Review the default marshaling behavior for strings in interfaces, platform invoke, structures, & fixed-length string buffers in .NET.
ms.date: 10/04/2021
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "strings, interop marshaling"
  - "interop marshaling, strings"
ms.assetid: 9baea3ce-27b3-4b4f-af98-9ad0f9467e6f
---
# Default marshaling for strings

Both the <xref:System.String?displayProperty=nameWithType> and <xref:System.Text.StringBuilder?displayProperty=nameWithType> classes have similar marshaling behavior.

Strings are marshaled as a COM-style `BSTR` type or as a null-terminated string (a character array that ends with a null character). The characters within the string can be marshaled as Unicode (the default on Windows systems) or ANSI.

## Strings Used in Interfaces

The following table shows the marshaling options for the string data type when marshaled as a method argument to unmanaged code. The <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute provides several <xref:System.Runtime.InteropServices.UnmanagedType> enumeration values to marshal strings to COM interfaces.

|Enumeration type|Description of unmanaged format|
|----------------------|-------------------------------------|
|`UnmanagedType.BStr` (default)|A COM-style `BSTR` with a prefixed length and Unicode characters.|
|`UnmanagedType.LPStr`|A pointer to a null-terminated array of ANSI characters.|
|`UnmanagedType.LPWStr`|A pointer to a null-terminated array of Unicode characters.|

This table applies to <xref:System.String>. For <xref:System.Text.StringBuilder>, the only options allowed are `UnmanagedType.LPStr` and `UnmanagedType.LPWStr`.

The following example shows strings declared in the `IStringWorker` interface.

```csharp
public interface IStringWorker
{
    void PassString1(string s);
    void PassString2([MarshalAs(UnmanagedType.BStr)] string s);
    void PassString3([MarshalAs(UnmanagedType.LPStr)] string s);
    void PassString4([MarshalAs(UnmanagedType.LPWStr)] string s);
    void PassStringRef1(ref string s);
    void PassStringRef2([MarshalAs(UnmanagedType.BStr)] ref string s);
    void PassStringRef3([MarshalAs(UnmanagedType.LPStr)] ref string s);
    void PassStringRef4([MarshalAs(UnmanagedType.LPWStr)] ref string s);
}
```

```vb
Public Interface IStringWorker
    Sub PassString1(s As String)
    Sub PassString2(<MarshalAs(UnmanagedType.BStr)> s As String)
    Sub PassString3(<MarshalAs(UnmanagedType.LPStr)> s As String)
    Sub PassString4(<MarshalAs(UnmanagedType.LPWStr)> s As String)
    Sub PassStringRef1(ByRef s As String)
    Sub PassStringRef2(<MarshalAs(UnmanagedType.BStr)> ByRef s As String)
    Sub PassStringRef3(<MarshalAs(UnmanagedType.LPStr)> ByRef s As String)
    Sub PassStringRef4(<MarshalAs(UnmanagedType.LPWStr)> ByRef s As String)
End Interface
```

The following example shows the corresponding interface described in a type library.

```cpp
interface IStringWorker : IDispatch
{
    HRESULT PassString1([in] BSTR s);
    HRESULT PassString2([in] BSTR s);
    HRESULT PassString3([in] LPStr s);
    HRESULT PassString4([in] LPWStr s);
    HRESULT PassStringRef1([in, out] BSTR *s);
    HRESULT PassStringRef2([in, out] BSTR *s);
    HRESULT PassStringRef3([in, out] LPStr *s);
    HRESULT PassStringRef4([in, out] LPWStr *s);
};
```

## Strings Used in Platform Invoke

When the CharSet is Unicode or a string argument is explicitly marked as [MarshalAs(UnmanagedType.LPWSTR)] and the string is passed by value (not `ref` or `out`), the string is pinned and used directly by native code. Otherwise, platform invoke copies string arguments, converting from the .NET Framework format (Unicode) to the platform unmanaged format. Strings are immutable and are not copied back from unmanaged memory to managed memory when the call returns.

Native code is only responsible for releasing the memory when the string is passed by reference and it assigns a new value. Otherwise, the .NET runtime owns the memory and will release it after the call.

The following table lists the marshaling options for strings when marshaled as a method argument of a platform invoke call. The <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute provides several <xref:System.Runtime.InteropServices.UnmanagedType> enumeration values to marshal strings.

|Enumeration type|Description of unmanaged format|
|----------------------|-------------------------------------|
|`UnmanagedType.AnsiBStr`|A COM-style `BSTR` with a prefixed length and ANSI characters.|
|`UnmanagedType.BStr`|A COM-style `BSTR` with a prefixed length and Unicode characters.|
|`UnmanagedType.LPStr` (default)|A pointer to a null-terminated array of ANSI characters.|
|`UnmanagedType.LPTStr`|A pointer to a null-terminated array of platform-dependent characters.|
|`UnmanagedType.LPUTF8Str`|A pointer to a null-terminated array of UTF-8 encoded characters.|
|`UnmanagedType.LPWStr`|A pointer to a null-terminated array of Unicode characters.|
|`UnmanagedType.TBStr`|A COM-style `BSTR` with a prefixed length and platform-dependent characters.|
|`VBByRefStr`|A value that enables Visual Basic .NET to change a string in unmanaged code and have the results reflected in managed code. This value is supported only for platform invoke. This is the default value in Visual Basic for `ByVal` strings.|

This table applies to <xref:System.String>. For <xref:System.Text.StringBuilder>, the only options allowed are `LPStr`, `LPTStr`, and `LPWStr`.

The following type definition shows the correct use of `MarshalAsAttribute` for platform invoke calls.

```csharp
class StringLibAPI
{
    [DllImport("StringLib.dll")]
    public static extern void PassLPStr([MarshalAs(UnmanagedType.LPStr)] string s);
    [DllImport("StringLib.dll")]
    public static extern void PassLPWStr([MarshalAs(UnmanagedType.LPWStr)] string s);
    [DllImport("StringLib.dll")]
    public static extern void PassLPTStr([MarshalAs(UnmanagedType.LPTStr)] string s);
    [DllImport("StringLib.dll")]
    public static extern void PassLPUTF8Str([MarshalAs(UnmanagedType.LPUTF8Str)] string s);
    [DllImport("StringLib.dll")]
    public static extern void PassBStr([MarshalAs(UnmanagedType.BStr)] string s);
    [DllImport("StringLib.dll")]
    public static extern void PassAnsiBStr([MarshalAs(UnmanagedType.AnsiBStr)] string s);
    [DllImport("StringLib.dll")]
    public static extern void PassTBStr([MarshalAs(UnmanagedType.TBStr)] string s);
}
```

```vb
Class StringLibAPI
    Public Declare Auto Sub PassLPStr Lib "StringLib.dll" (
        <MarshalAs(UnmanagedType.LPStr)> s As String)
    Public Declare Auto Sub PassLPWStr Lib "StringLib.dll" (
        <MarshalAs(UnmanagedType.LPWStr)> s As String)
    Public Declare Auto Sub PassLPTStr Lib "StringLib.dll" (
        <MarshalAs(UnmanagedType.LPTStr)> s As String)
    Public Declare Auto Sub PassLPUTF8Str Lib "StringLib.dll" (
        <MarshalAs(UnmanagedType.LPUTF8Str)> s As String)
    Public Declare Auto Sub PassBStr Lib "StringLib.dll" (
        <MarshalAs(UnmanagedType.BStr)> s As String)
    Public Declare Auto Sub PassAnsiBStr Lib "StringLib.dll" (
        <MarshalAs(UnmanagedType.AnsiBStr)> s As String)
    Public Declare Auto Sub PassTBStr Lib "StringLib.dll" (
        <MarshalAs(UnmanagedType.TBStr)> s As String)
End Class
```

## Strings Used in Structures

Strings are valid members of structures; however, <xref:System.Text.StringBuilder> buffers are invalid in structures. The following table shows the marshaling options for the <xref:System.String> data type when the type is marshaled as a field. The <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute provides several <xref:System.Runtime.InteropServices.UnmanagedType> enumeration values to marshal strings to a field.

|Enumeration type|Description of unmanaged format|
|----------------------|-------------------------------------|
|`UnmanagedType.BStr`|A COM-style `BSTR` with a prefixed length and Unicode characters.|
|`UnmanagedType.LPStr` (default)|A pointer to a null-terminated array of ANSI characters.|
|`UnmanagedType.LPTStr`|A pointer to a null-terminated array of platform-dependent characters.|
|`UnmanagedType.LPUTF8Str`|A pointer to a null-terminated array of UTF-8 encoded characters.|
|`UnmanagedType.LPWStr`|A pointer to a null-terminated array of Unicode characters.|
|`UnmanagedType.ByValTStr`|A fixed-length array of characters; the array's type is determined by the character set of the containing structure.|

The `ByValTStr` type is used for inline, fixed-length character arrays that appear within a structure. Other types apply to string references contained within structures that contain pointers to strings.

The `CharSet` argument of the <xref:System.Runtime.InteropServices.StructLayoutAttribute> that is applied to the containing structure determines the character format of strings in structures. The following example structures contain string references and inline strings, as well as ANSI, Unicode, and platform-dependent characters. The representation of these structures in a type library is shown in the following C++ code:

```cpp
struct StringInfoA
{
    char *  f1;
    char    f2[256];
};

struct StringInfoW
{
    WCHAR * f1;
    WCHAR   f2[256];
    BSTR    f3;
};

struct StringInfoT
{
    TCHAR * f1;
    TCHAR   f2[256];
};
```

The following example shows how to use the <xref:System.Runtime.InteropServices.MarshalAsAttribute> to define the same structure in different formats.

```csharp
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
struct StringInfoA
{
    [MarshalAs(UnmanagedType.LPStr)] public string f1;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)] public string f2;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
struct StringInfoW
{
    [MarshalAs(UnmanagedType.LPWStr)] public string f1;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)] public string f2;
    [MarshalAs(UnmanagedType.BStr)] public string f3;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
struct StringInfoT
{
    [MarshalAs(UnmanagedType.LPTStr)] public string f1;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)] public string f2;
}
```

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

## Fixed-Length String Buffers

In some circumstances, a fixed-length character buffer must be passed into unmanaged code to be manipulated. Simply passing a string does not work in this case because the callee cannot modify the contents of the passed buffer. Even if the string is passed by reference, there is no way to initialize the buffer to a given size.

The solution is to pass a <xref:System.Text.StringBuilder> as the argument instead of a <xref:System.String>. The buffer created when marshaling a `StringBuilder` can be dereferenced and modified by the callee, provided it does not exceed the capacity of the `StringBuilder`. It can also be initialized to a fixed length. For example, if you initialize a `StringBuilder` buffer to a capacity of `N`, the marshaler provides a buffer of size (`N`+1) characters. The +1 accounts for the fact that the unmanaged string has a null terminator while `StringBuilder` does not.

For example, the Windows [`GetWindowText`](/windows/desktop/api/winuser/nf-winuser-getwindowtextw) API function (defined in *winuser.h*) requires that the caller pass a fixed-length character buffer to which the function writes the window's text. `LpString` points to a caller-allocated buffer of size `nMaxCount`. The caller is expected to allocate the buffer and set the `nMaxCount` argument to the size of the allocated buffer. The following example shows the `GetWindowText` function declaration as defined in *winuser.h*.

```cpp
int GetWindowText(
    HWND hWnd,        // Handle to window or control.
    LPTStr lpString,  // Text buffer.
    int nMaxCount     // Maximum number of characters to copy.
);
```

A `StringBuilder` can be dereferenced and modified by the callee, provided it does not exceed the capacity of the `StringBuilder`. The following code example demonstrates how `StringBuilder` can be initialized to a fixed length.

```csharp
using System;
using System.Runtime.InteropServices;
using System.Text;

internal static class NativeMethods
{
    [DllImport("User32.dll")]
    internal static extern void GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
}

public class Window
{
    internal IntPtr h;        // Internal handle to Window.
    public String GetText()
    {
        StringBuilder sb = new StringBuilder(256);
        NativeMethods.GetWindowText(h, sb, sb.Capacity + 1);
        return sb.ToString();
    }
}
```

```vb
Imports System.Text

Friend Class NativeMethods
    Friend Declare Auto Sub GetWindowText Lib "User32.dll" _
        (hWnd As IntPtr, lpString As StringBuilder, nMaxCount As Integer)
End Class

Public Class Window
    Friend h As IntPtr ' Friend handle to Window.
    Public Function GetText() As String
        Dim sb As New StringBuilder(256)
        NativeMethods.GetWindowText(h, sb, sb.Capacity + 1)
        Return sb.ToString()
   End Function
End Class
```

## See also

- [Default Marshaling Behavior](default-marshaling-behavior.md)
- [Marshaling Strings](marshaling-strings.md)
- [Blittable and Non-Blittable Types](blittable-and-non-blittable-types.md)
- [Directional Attributes](/previous-versions/dotnet/netframework-4.0/77e6taeh(v=vs.100))
- [Copying and Pinning](copying-and-pinning.md)

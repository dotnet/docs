---
title: "Specifying a Character Set"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "platform invoke, attribute fields"
  - "attribute fields in platform invoke, CharSet"
  - "CharSet field"
ms.assetid: a8347eb1-295f-46b9-8a78-63331f9ecc50
author: "rpetrusha"
ms.author: "ronpet"
---
# Specifying a Character Set
The <xref:System.Runtime.InteropServices.DllImportAttribute.CharSet?displayProperty=nameWithType> field controls string marshaling and determines how platform invoke finds function names in a DLL. This topic describes both behaviors.  
  
 Some APIs export two versions of functions that take string arguments: narrow (ANSI) and wide (Unicode). The Windows API, for instance, includes the following entry-point names for the **MessageBox** function:  
  
-   **MessageBoxA**  
  
     Provides 1-byte character ANSI formatting, distinguished by an "A" appended to the entry-point name. Calls to **MessageBoxA** always marshal strings in ANSI format.  
  
-   **MessageBoxW**  
  
     Provides 2-byte character Unicode formatting, distinguished by a "W" appended to the entry-point name. Calls to **MessageBoxW** always marshal strings in Unicode format.  
  
## String Marshaling and Name Matching  
 The `CharSet` field accepts the following values:  
  
 <xref:System.Runtime.InteropServices.CharSet.Ansi> (default value)  
  
-   String marshaling  
  
     Platform invoke marshals strings from their managed format (Unicode) to ANSI format.  
  
-   Name matching  
  
     When the <xref:System.Runtime.InteropServices.DllImportAttribute.ExactSpelling?displayProperty=nameWithType> field is `true`, as it is by default in [!INCLUDE[vbprvblong](../../../includes/vbprvblong-md.md)], platform invoke searches only for the name you specify. For example, if you specify **MessageBox**, platform invoke searches for **MessageBox** and fails when it cannot locate the exact spelling.  
  
     When the `ExactSpelling` field is `false`, as it is by default in C++ and C#, platform invoke searches for the unmangled alias first (**MessageBox**), then the mangled name (**MessageBoxA**) if the unmangled alias is not found. Notice that ANSI name-matching behavior differs from Unicode name-matching behavior.  
  
 <xref:System.Runtime.InteropServices.CharSet.Unicode>  
  
-   String marshaling  
  
     Platform invoke copies strings from their managed format (Unicode) to Unicode format.  
  
-   Name matching  
  
     When the `ExactSpelling` field is `true`, as it is by default in [!INCLUDE[vbprvblong](../../../includes/vbprvblong-md.md)], platform invoke searches only for the name you specify. For example, if you specify **MessageBox**, platform invoke searches for **MessageBox** and fails if it cannot locate the exact spelling.  
  
     When the `ExactSpelling` field is `false`, as it is by default in C++ and C#, platform invoke searches for the mangled name first (**MessageBoxW**), then the unmangled alias (**MessageBox**) if the mangled name is not found. Notice that Unicode name-matching behavior differs from ANSI name-matching behavior.  
  
 <xref:System.Runtime.InteropServices.CharSet.Auto>  
  
-   Platform invoke chooses between ANSI and Unicode formats at run time, based on the target platform.  
  
## Specifying a Character Set in Visual Basic  
 The following example declares the **MessageBox** function three times, each time with different character-set behavior. You can specify character-set behavior in Visual Basic by adding the **Ansi**, **Unicode**, or **Auto** keyword to the declaration statement.  
  
 If you omit the character-set keyword, as is done in the first declaration statement, the <xref:System.Runtime.InteropServices.DllImportAttribute.CharSet?displayProperty=nameWithType> field defaults to the ANSI character set. The second and third statements in the example explicitly specify a character set with a keyword.  
  
```vb
Imports System

Friend Class WindowsAPI
    Friend Shared Declare Function MessageBoxA Lib "user32.dll" (
        ByVal hWnd As IntPtr,
        ByVal lpText As String,
        ByVal lpCaption As String,
        ByVal uType As UInteger) As Integer

    Friend Shared Declare Unicode Function MessageBoxW Lib "user32.dll" (
        ByVal hWnd As IntPtr,
        ByVal lpText As String,
        ByVal lpCaption As String,
        ByVal uType As UInteger) As Integer

    Friend Shared Declare Auto Function MessageBox Lib "user32.dll" (
        ByVal hWnd As IntPtr,
        ByVal lpText As String,
        ByVal lpCaption As String,
        ByVal uType As UInteger) As Integer
End Class
```
  
## Specifying a Character Set in C# and C++  
 The <xref:System.Runtime.InteropServices.DllImportAttribute.CharSet?displayProperty=nameWithType> field identifies the underlying character set as ANSI or Unicode. The character set controls how string arguments to a method should be marshaled. Use one of the following forms to indicate the character set:  
  
```csharp
[DllImport("DllName", CharSet = CharSet.Ansi)]
[DllImport("DllName", CharSet = CharSet.Unicode)]
[DllImport("DllName", CharSet = CharSet.Auto)]
```
  
```cpp
[DllImport("DllName", CharSet = CharSet::Ansi)]
[DllImport("DllName", CharSet = CharSet::Unicode)]
[DllImport("DllName", CharSet = CharSet::Auto)]
```
  
 The following example shows three managed definitions of the **MessageBox** function attributed to specify a character set. In the first definition, by its omission, the `CharSet` field defaults to the ANSI character set.  
  
```csharp  
using System;
using System.Runtime.InteropServices;

internal static class WindowsAPI
{
    [DllImport("user32.dll")]
    internal static extern int MessageBoxA(
        IntPtr hWnd, string lpText, string lpCaption, uint uType);

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    internal static extern int MessageBoxW(
        IntPtr hWnd, string lpText, string lpCaption, uint uType);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    internal static extern int MessageBox(
        IntPtr hWnd, string lpText, string lpCaption, uint uType);
}
```  
  
```cpp
typedef void* HWND;

// Can use MessageBox or MessageBoxA.
[DllImport("user32")]
extern "C" int MessageBox(
    HWND hWnd, String* lpText, String* lpCaption, unsigned int uType);

// Can use MessageBox or MessageBoxW.
[DllImport("user32", CharSet = CharSet::Unicode)]
extern "C" int MessageBoxW(
    HWND hWnd, String* lpText, String* lpCaption, unsigned int uType);

// Must use MessageBox.
[DllImport("user32", CharSet = CharSet::Auto)]
extern "C" int MessageBox(
    HWND hWnd, String* lpText, String* lpCaption, unsigned int uType);
```
  
## See also

- <xref:System.Runtime.InteropServices.DllImportAttribute>
- [Creating Prototypes in Managed Code](../../../docs/framework/interop/creating-prototypes-in-managed-code.md)
- [Platform Invoke Examples](../../../docs/framework/interop/platform-invoke-examples.md)
- [Marshaling Data with Platform Invoke](../../../docs/framework/interop/marshaling-data-with-platform-invoke.md)

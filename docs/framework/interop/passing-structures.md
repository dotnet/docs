---
title: "Passing Structures"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "platform invoke, calling unmanaged functions"
ms.assetid: 9b92ac73-32b7-4e1b-862e-6d8d950cf169
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Passing Structures
Many unmanaged functions expect you to pass, as a parameter to the function, members of structures (user-defined types in Visual Basic) or members of classes that are defined in managed code. When passing structures or classes to unmanaged code using platform invoke, you must provide additional information to preserve the original layout and alignment. This topic introduces the <xref:System.Runtime.InteropServices.StructLayoutAttribute> attribute, which you use to define formatted types. For managed structures and classes, you can select from several predictable layout behaviors supplied by the **LayoutKind** enumeration.  
  
 Central to the concepts presented in this topic is an important difference between structure and class types. Structures are value types and classes are reference types — classes always provide at least one level of memory indirection (a pointer to a value). This difference is important because unmanaged functions often demand indirection, as shown by the signatures in the first column of the following table. The managed structure and class declarations in the remaining columns show the degree to which you can adjust the level of indirection in your declaration.Declarations are provided for both Visual Basic and Visual C#.  
  
|Unmanaged signature|Managed declaration: <br />no indirection<br />`Structure MyType`<br />`struct MyType;`|Managed declaration: <br />one level of indirection<br />`Class MyType`<br />`class MyType;`|  
|-------------------------|---------------------------------------------------------------------------------|--------------------------------------------------------------------------------------|  
|`DoWork(MyType x);`<br /><br /> Demands zero levels of indirection.|`DoWork(ByVal x As MyType)` <br /> `DoWork(MyType x)`<br /><br /> Adds zero levels of indirection.|Not possible because there is already one level of indirection.|  
|`DoWork(MyType* x);`<br /><br /> Demands one level of indirection.|`DoWork(ByRef x As MyType)` <br /> `DoWork(ref MyType x)`<br /><br /> Adds one level of indirection.|`DoWork(ByVal x As MyType)` <br /> `DoWork(MyType x)`<br /><br /> Adds zero levels of indirection.|  
|`DoWork(MyType** x);`<br /><br /> Demands two levels of indirection.|Not possible because **ByRef** **ByRef** or `ref` `ref` cannot be used.|`DoWork(ByRef x As MyType)` <br /> `DoWork(ref MyType x)`<br /><br /> Adds one level of indirection.|  
  
 The table describes the following guidelines for platform invoke declarations:  
  
-   Use a structure passed by value when the unmanaged function demands no indirection.  
  
-   Use either a structure passed by reference or a class passed by value when the unmanaged function demands one level of indirection.  
  
-   Use a class passed by reference when the unmanaged function demands two levels of indirection.  
  
## Declaring and Passing Structures  
 The following example shows how to define the `Point` and `Rect` structures in managed code, and pass the types as parameter to the **PtInRect** function in the User32.dll file. **PtInRect** has the following unmanaged signature:  
  
```  
BOOL PtInRect(const RECT *lprc, POINT pt);  
```  
  
 Notice that you must pass the Rect structure by reference, since the function expects a pointer to a RECT type.  
  
```vb  
Imports System.Runtime.InteropServices  
  
<StructLayout(LayoutKind.Sequential)> Public Structure Point  
    Public x As Integer  
    Public y As Integer  
End Structure  
  
Public Structure <StructLayout(LayoutKind.Explicit)> Rect  
    <FieldOffset(0)> Public left As Integer  
    <FieldOffset(4)> Public top As Integer  
    <FieldOffset(8)> Public right As Integer  
    <FieldOffset(12)> Public bottom As Integer  
End Structure  
  
Class Win32API      
    Declare Auto Function PtInRect Lib "user32.dll" _  
    (ByRef r As Rect, p As Point) As Boolean  
End Class  
```  
  
```csharp  
using System.Runtime.InteropServices;  
  
[StructLayout(LayoutKind.Sequential)]  
public struct Point {  
    public int x;  
    public int y;  
}     
  
[StructLayout(LayoutKind.Explicit)]  
public struct Rect {  
    [FieldOffset(0)] public int left;  
    [FieldOffset(4)] public int top;  
    [FieldOffset(8)] public int right;  
    [FieldOffset(12)] public int bottom;  
}     
  
class Win32API {  
    [DllImport("User32.dll")]  
    public static extern bool PtInRect(ref Rect r, Point p);  
}  
```  
  
## Declaring and Passing Classes  
 You can pass members of a class to an unmanaged DLL function, as long as the class has a fixed member layout. The following example demonstrates how to pass members of the `MySystemTime` class, which are defined in sequential order, to the **GetSystemTime** in the User32.dll file. **GetSystemTime** has the following unmanaged signature:  
  
```  
void GetSystemTime(SYSTEMTIME* SystemTime);  
```  
  
 Unlike value types, classes always have at least one level of indirection.  
  
```vb  
Imports System  
Imports System.Runtime.InteropServices  
Imports Microsoft.VisualBasic  
  
<StructLayout(LayoutKind.Sequential)> Public Class MySystemTime  
    Public wYear As Short  
    Public wMonth As Short  
    Public wDayOfWeek As Short   
    Public wDay As Short  
    Public wHour As Short  
    Public wMinute As Short  
    Public wSecond As Short  
    Public wMiliseconds As Short  
End Class  
  
Public Class Win32  
    Declare Auto Sub GetSystemTime Lib "Kernel32.dll"(sysTime _  
        As MySystemTime)  
    Declare Auto Function MessageBox Lib "User32.dll"(hWnd As IntPtr, _  
        txt As String, caption As String, Typ As Integer) As Integer  
End Class  
  
Public Class TestPlatformInvoke      
    Public Shared Sub Main()  
        Dim sysTime As New MySystemTime()  
        Win32.GetSystemTime(sysTime)  
  
        Dim dt As String  
        dt = "System time is:" & ControlChars.CrLf & _  
              "Year: " & sysTime.wYear & _  
              ControlChars.CrLf & "Month: " & sysTime.wMonth & _  
              ControlChars.CrLf & "DayOfWeek: " & sysTime.wDayOfWeek & _  
              ControlChars.CrLf & "Day: " & sysTime.wDay  
        Win32.MessageBox(IntPtr.Zero, dt, "Platform Invoke Sample", 0)        
    End Sub  
End Class  
```  
  
```csharp  
[StructLayout(LayoutKind.Sequential)]  
public class MySystemTime {  
    public ushort wYear;   
    public ushort wMonth;  
    public ushort wDayOfWeek;   
    public ushort wDay;   
    public ushort wHour;   
    public ushort wMinute;   
    public ushort wSecond;   
    public ushort wMilliseconds;   
}  
class Win32API {  
    [DllImport("Kernel32.dll")]  
    public static extern void GetSystemTime(MySystemTime st);  
  
    [DllImport("user32.dll", CharSet=CharSet.Auto)]  
     public static extern int MessageBox(IntPtr hWnd,  
         string text, string caption, int options);  
}  
  
public class TestPlatformInvoke  
{  
    public static void Main()  
    {  
        MySystemTime sysTime = new MySystemTime();  
        Win32API.GetSystemTime(sysTime);  
  
        string dt;  
        dt = "System time is: \n" +  
              "Year: " + sysTime.wYear + "\n" +  
              "Month: " + sysTime.wMonth + "\n" +  
              "DayOfWeek: " + sysTime.wDayOfWeek + "\n" +  
              "Day: " + sysTime.wDay;  
        Win32API.MessageBox(IntPtr.Zero, dt, "Platform Invoke Sample", 0);  
    }  
}  
```  
  
## See Also  
 [Calling a DLL Function](../../../docs/framework/interop/calling-a-dll-function.md)  
 <xref:System.Runtime.InteropServices.StructLayoutAttribute>  
 <xref:System.Runtime.InteropServices.StructLayoutAttribute>  
 <xref:System.Runtime.InteropServices.FieldOffsetAttribute>

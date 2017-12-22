---
title: "Specifying an Entry Point"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "EntryPoint field"
  - "platform invoke, attribute fields"
  - "attribute fields in platform invoke, EntryPoint"
ms.assetid: d1247f08-0965-416a-b978-e0b50652dfe3
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Specifying an Entry Point
An entry point identifies the location of a function in a DLL. Within a managed project, the original name or ordinal entry point of a target function identifies that function across the interoperation boundary. Further, you can map the entry point to a different name, effectively renaming the function.  
  
 Following is a list of possible reasons to rename a DLL function:  
  
-   To avoid using case-sensitive API function names  
  
-   To comply with existing naming standards  
  
-   To accommodate functions that take different data types (by declaring multiple versions of the same DLL function)  
  
-   To simplify using APIs that contain ANSI and Unicode versions  
  
 This topic demonstrates how to rename a DLL function in managed code.  
  
## Renaming a Function in Visual Basic  
 Visual Basic uses the **Function** keyword in the **Declare** statement to set the <xref:System.Runtime.InteropServices.DllImportAttribute.EntryPoint?displayProperty=nameWithType> field. The following example shows a basic declaration.  
  
```vb  
Imports System.Runtime.InteropServices  
  
Public Class Win32  
    Declare Auto Function MessageBox Lib "user32.dll" _  
       (ByVal hWnd As Integer, ByVal txt As String,_  
       ByVal caption As String, ByVal Typ As Integer) As Integer  
End Class  
```  
  
 You can replace the **MessageBox** entry point with **MsgBox** by including the **Alias** keyword in your definition, as shown in the following example. In both examples the **Auto** keyword eliminates the need to specify the character-set version of the entry point. For more information about selecting a character set, see [Specifying a Character Set](../../../docs/framework/interop/specifying-a-character-set.md).  
  
```vb  
Imports System.Runtime.InteropServices  
  
Public Class Win32  
    Declare Auto Function MsgBox Lib "user32.dll" _  
       Alias "MessageBox" (ByVal hWnd As Integer, ByVal txt As String,_  
       ByVal caption As String, ByVal Typ As Integer) As Integer  
End Class  
```  
  
## Renaming a Function in C# and C++  
 You can use the <xref:System.Runtime.InteropServices.DllImportAttribute.EntryPoint?displayProperty=nameWithType> field to specify a DLL function by name or ordinal. If the name of the function in your method definition is the same as the entry point in the DLL, you do not have to explicitly identify the function with the **EntryPoint** field. Otherwise, use one of the following attribute forms to indicate a name or ordinal:  
  
```  
[DllImport("dllname", EntryPoint="Functionname")]  
[DllImport("dllname", EntryPoint="#123")]  
```  
  
 Notice that you must prefix an ordinal with the pound sign (#).  
  
 The following example demonstrates how to replace **MessageBoxA** with **MsgBox** in your code by using the **EntryPoint** field.  
  
```csharp  
using System.Runtime.InteropServices;  
  
public class Win32 {  
    [DllImport("user32.dll", EntryPoint="MessageBoxA")]  
    public static extern int MsgBox(int hWnd, String text, String caption,  
                                    uint type);  
}  
```  
  
```cpp  
using namespace System::Runtime::InteropServices;  
  
typedef void* HWND;  
[DllImport("user32", EntryPoint="MessageBoxA")]  
extern "C" int MsgBox(HWND hWnd,  
                      String*  pText,  
                      String*  pCaption,  
                      unsigned int uType);  
```  
  
## See Also  
 <xref:System.Runtime.InteropServices.DllImportAttribute>  
 [Creating Prototypes in Managed Code](../../../docs/framework/interop/creating-prototypes-in-managed-code.md)  
 [Platform Invoke Examples](../../../docs/framework/interop/platform-invoke-examples.md)  
 [Marshaling Data with Platform Invoke](../../../docs/framework/interop/marshaling-data-with-platform-invoke.md)

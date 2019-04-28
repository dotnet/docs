---
title: "How to: Call Windows APIs (Visual Basic)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "API calls [Visual Basic]"
  - "Windows API, calling"
  - "API calls [Visual Basic], platform invoke"
  - "calls [Visual Basic], stored procedures"
ms.assetid: 27d75f0a-54ab-4ee1-b91d-43513a19b12d
---
# How to: Call Windows APIs (Visual Basic)
This example defines and calls the `MessageBox` function in user32.dll and then passes a string to it.  
  
## Example  
 [!code-vb[VbVbalrInterop#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrInterop/VB/Class1.vb#1)]  
  
## Compiling the Code  
 This example requires:  
  
- A reference to the <xref:System> namespace.  
  
## Robust Programming  
 The following conditions may cause an exception:  
  
- The method is not static, is abstract, or has been previously defined. The parent type is an interface, or the length of *name* or *dllName* is zero. (<xref:System.ArgumentException>)  
  
- The *name* or *dllName* is `Nothing`. (<xref:System.ArgumentNullException>)  
  
- The containing type has been previously created using `CreateType`. (<xref:System.InvalidOperationException>)  
  
## See also

- [A Closer Look at Platform Invoke](../../../framework/interop/consuming-unmanaged-dll-functions.md#a-closer-look-at-platform-invoke)
- [Platform Invoke Examples](../../../framework/interop/platform-invoke-examples.md)
- [Consuming Unmanaged DLL Functions](../../../framework/interop/consuming-unmanaged-dll-functions.md)
- [Defining a Method with Reflection Emit](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/w63y4d4f(v=vs.100))
- [Walkthrough: Calling Windows APIs](../../../visual-basic/programming-guide/com-interop/walkthrough-calling-windows-apis.md)
- [COM Interop](../../../visual-basic/programming-guide/com-interop/index.md)

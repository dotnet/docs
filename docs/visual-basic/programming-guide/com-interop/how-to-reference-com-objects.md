---
title: "How to: Reference COM Objects from Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "COM interop [Visual Basic], referencing COM objects"
  - "referencing objects, COM objects from Visual Basic"
  - "objects [Visual Basic], referencing"
  - "COM objects, referencing"
  - "interop assemblies"
ms.assetid: 9c518fb4-27d9-4112-9e6a-5a7d0210af6f
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Reference COM Objects from Visual Basic
In [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)], adding references to COM objects that have type libraries requires the creation of an interop assembly for the COM library. References to the members of the COM object are routed to the interop assembly and then forwarded to the actual COM object. Responses from the COM object are routed to the interop assembly and forwarded to your [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] application.  
  
 You can reference a COM object without using an interop assembly by embedding the type information for the COM object in a .NET assembly. To embed type information, set the `Embed Interop Types` property to `True` for the reference to the COM object. If you are compiling by using the command-line compiler, use the `/link` option to reference the COM library. For more information, see [/link (Visual Basic)](../../../visual-basic/reference/command-line-compiler/link.md).  
  
 [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] automatically creates interop assemblies when you add a reference to a type library from the integrated development environment (IDE). When working from the command line, you can use the Tlbimp utility to manually create interop assemblies.  
  
### To add references to COM objects  
  
1.  On the **Project** menu, choose **Add Reference** and then click the **COM** tab in the dialog box.  
  
2.  Select the component you want to use from the list of COM objects.  
  
3.  To simplify access to the interop assembly, add an `Imports` statement to the top of the class or module in which you will use the COM object. For example, the following code example imports the namespace `INKEDLib` for objects referenced in the `Microsoft InkEdit Control 1.0` library.  
  
     [!code-vb[VbVbalrInterop#40](../../../visual-basic/programming-guide/com-interop/codesnippet/VisualBasic/how-to-reference-com-objects_1.vb)]  
  
### To create an interop assembly using Tlbimp  
  
1.  Add the location of Tlbimp to the search path, if it is not already part of the search path and you are not currently in the directory where it is located.  
  
2.  Call Tlbimp from a command prompt, providing the following information:  
  
    -   Name and location of the DLL that contains the type library  
  
    -   Name and location of the namespace where the information should be placed  
  
    -   Name and location of the target interop assembly  
  
     The following code provides an example:  
  
    ```  
    Tlbimp test3.dll /out:NameSpace1 /out:Interop1.dll  
    ```  
  
     You can use Tlbimp to create interop assemblies for type libraries, even for unregistered COM objects. However, the COM objects referred to by interop assemblies must be properly registered on the computer where they are to be used. You can register a COM object by using the Regsvr32 utility included with the Windows operating system.  
  
## See Also  
 [COM Interop](../../../visual-basic/programming-guide/com-interop/index.md)  
 [Tlbimp.exe (Type Library Importer)](../../../framework/tools/tlbimp-exe-type-library-importer.md)  
 [Tlbexp.exe (Type Library Exporter)](http://msdn.microsoft.com/library/a487d61b-d166-467b-a7ca-d8b52fbff42d)  
 [Walkthrough: Implementing Inheritance with COM Objects](../../../visual-basic/programming-guide/com-interop/walkthrough-implementing-inheritance-with-com-objects.md)  
 [Troubleshooting Interoperability](../../../visual-basic/programming-guide/com-interop/troubleshooting-interoperability.md)  
 [Imports Statement (.NET Namespace and Type)](../../../visual-basic/language-reference/statements/imports-statement-net-namespace-and-type.md)

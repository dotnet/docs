---
title: "Walkthrough: Creating COM Objects with Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "COM interop [Visual Basic], creating COM objects"
  - "COM objects, creating"
  - "COM interop [Visual Basic], walkthroughs"
  - "object creation [Visual Basic], COM objects"
  - "COM objects, walkthroughs"
ms.assetid: 7b07a463-bc72-4392-9ba0-9dfcb697a44f
caps.latest.revision: 30
author: dotnet-bot
ms.author: dotnetcontent
---
# Walkthrough: Creating COM Objects with Visual Basic
When creating new applications or components, it is best to create .NET Framework assemblies. However, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] also makes it easy to expose a .NET Framework component to COM. This enables you to provide new components for earlier application suites that require COM components. This walkthrough demonstrates how to use [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] to expose [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] objects as COM objects, both with and without the COM class template.  
  
 The easiest way to expose COM objects is by using the COM class template. The COM class template creates a new class, and then configures your project to generate the class and interoperability layer as a COM object and register it with the operating system.  
  
> [!NOTE]
>  Although you can also expose a class created in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] as a COM object for unmanaged code to use, it is not a true COM object and cannot be used by [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)]. For more information, see [COM Interoperability in .NET Framework Applications](../../../visual-basic/programming-guide/com-interop/com-interoperability-in-net-framework-applications.md).  
  
[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]  
  
### To create a COM object by using the COM class template  
  
1.  Open a new Windows Application project from the **File** menu by clicking **New Project**.  
  
2.  In the **New Project** dialog box under the **Project Types** field, check that Windows is selected. Select **Class Library** from the **Templates** list, and then click **OK**. The new project is displayed.  
  
3.  Select **Add New Item** from the **Project** menu. The **Add New Item** dialog box is displayed.  
  
4.  Select **COM Class** from the **Templates** list, and then click **Add**. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] adds a new class and configures the new project for COM interop.  
  
5.  Add code such as properties, methods, and events to the COM class.  
  
6.  Select **Build ClassLibrary1** from the **Build** menu. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] builds the assembly and registers the COM object with the operating system.  
  
## Creating COM Objects without the COM Class Template  
 You can also create a COM class manually instead of using the COM class template. This procedure is helpful when you are working from the command line or when you want more control over how COM objects are defined.  
  
#### To set up your project to generate a COM object  
  
1.  Open a new Windows Application project from the **File** menu by clicking **NewProject**.  
  
2.  In the **New Project** dialog box under the **Project Types** field, check that Windows is selected. Select **Class Library** from the **Templates** list, and then click **OK**. The new project is displayed.  
  
3.  In **Solution Explorer**, right-click your project, and then click **Properties**. The **Project Designer** is displayed.  
  
4.  Click the **Compile** tab.  
  
5.  Select the **Register for COM Interop** check box.  
  
#### To set up the code in your class to create a COM object  
  
1.  In **Solution Explorer**, double-click **Class1.vb** to display its code.  
  
2.  Rename the class to `ComClass1`.  
  
3.  Add the following constants to `ComClass1`. They will store the Globally Unique Identifier (GUID) constants that the COM objects are required to have.  
  
     [!code-vb[VbVbalrInterop#2](../../../visual-basic/programming-guide/com-interop/codesnippet/VisualBasic/walkthrough-creating-com-objects_1.vb)]  
  
4.  On the **Tools** menu, click **Create Guid**. In the **Create GUID** dialog box, click **Registry Format** and then click **Copy**. Click **Exit**.  
  
5.  Replace the empty string for the `ClassId` with the GUID, removing the leading and trailing braces. For example, if the GUID provided by Guidgen is `"{2C8B0AEE-02C9-486e-B809-C780A11530FE}"` then your code should appear as follows.  
  
     [!code-vb[VbVbalrInterop#3](../../../visual-basic/programming-guide/com-interop/codesnippet/VisualBasic/walkthrough-creating-com-objects_2.vb)]  
  
6.  Repeat the previous steps for the `InterfaceId` and `EventsId` constants, as in the following example.  
  
     [!code-vb[VbVbalrInterop#4](../../../visual-basic/programming-guide/com-interop/codesnippet/VisualBasic/walkthrough-creating-com-objects_3.vb)]  
  
    > [!NOTE]
    >  Make sure that the GUIDs are new and unique; otherwise, your COM component could conflict with other COM components.  
  
7.  Add the `ComClass` attribute to `ComClass1`, specifying the GUIDs for the Class ID, Interface ID, and Events ID as in the following example:  
  
     [!code-vb[VbVbalrInterop#5](../../../visual-basic/programming-guide/com-interop/codesnippet/VisualBasic/walkthrough-creating-com-objects_4.vb)]  
  
8.  COM classes must have a parameterless `Public Sub New()` constructor, or the class will not register correctly. Add a parameterless constructor to the class:  
  
     [!code-vb[VbVbalrInterop#6](../../../visual-basic/programming-guide/com-interop/codesnippet/VisualBasic/walkthrough-creating-com-objects_5.vb)]  
  
9. Add properties, methods, and events to the class, ending it with an `End Class` statement. Select **Build Solution** from the **Build** menu. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] builds the assembly and registers the COM object with the operating system.  
  
    > [!NOTE]
    >  The COM objects you generate with [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] cannot be used by other [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] applications because they are not true COM objects. Attempts to add references to such COM objects will raise an error. For details, see [COM Interoperability in .NET Framework Applications](../../../visual-basic/programming-guide/com-interop/com-interoperability-in-net-framework-applications.md).  
  
## See Also  
 <xref:Microsoft.VisualBasic.ComClassAttribute>  
 [COM Interop](../../../visual-basic/programming-guide/com-interop/index.md)  
 [Walkthrough: Implementing Inheritance with COM Objects](../../../visual-basic/programming-guide/com-interop/walkthrough-implementing-inheritance-with-com-objects.md)  
 [#Region Directive](../../../visual-basic/language-reference/directives/region-directive.md)  
 [COM Interoperability in .NET Framework Applications](../../../visual-basic/programming-guide/com-interop/com-interoperability-in-net-framework-applications.md)  
 [Troubleshooting Interoperability](../../../visual-basic/programming-guide/com-interop/troubleshooting-interoperability.md)

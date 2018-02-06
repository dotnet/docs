---
title: "Walkthrough: Automatically Populating the Toolbox with Custom Components"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "IToolboxService interface"
  - "Toolbox [Windows Forms], populating"
  - "custom components [Windows Forms], adding to Toolbox"
ms.assetid: 2fa1e3e8-6b9f-42b2-97c0-2be57444dba4
caps.latest.revision: 22
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Automatically Populating the Toolbox with Custom Components
If your components are defined by a project in the currently open solution, they will automatically appear in the **Toolbox**, with no action required by you. You can also manually populate the **Toolbox** with your custom components by using the [Choose Toolbox Items Dialog Box (Visual Studio)](http://msdn.microsoft.com/library/bd07835f-18a8-433e-bccc-7141f65263bb), but the **Toolbox** takes account of items in your solution's build outputs with all the following characteristics:  
  
-   Implements <xref:System.ComponentModel.IComponent>;  
  
-   Does not have <xref:System.ComponentModel.ToolboxItemAttribute> set to `false`;  
  
-   Does not have <xref:System.ComponentModel.DesignTimeVisibleAttribute> set to `false`.  
  
> [!NOTE]
>  The **Toolbox** does not follow reference chains, so it will not display items that are not built by a project in your solution.  
  
 This walkthrough demonstrates how a custom component automatically appears in the **Toolbox** once the component is built. Tasks illustrated in this walkthrough include:  
  
-   Creating a Windows Forms project.  
  
-   Creating a custom component.  
  
-   Creating an instance of a custom component.  
  
-   Unloading and reloading a custom component.  
  
 When you are finished, you will see that the **Toolbox** is populated with a component that you have created.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
## Creating the Project  
 The first step is to create the project and to set up the form.  
  
#### To create the project  
  
1.  Create a Windows-based application project called `ToolboxExample`.  
  
     For more information, see [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa).  
  
2.  Add a new component to the project. Call it `DemoComponent`.  
  
     For more information, see [NIB:How to: Add New Project Items](http://msdn.microsoft.com/library/63d3e16b-de6e-4bb5-a0e3-ecec762201ce).  
  
3.  Build the project.  
  
4.  From the **Tools** menu, click the **Options** item. Click **General** under the **Windows Forms Designer** item and ensure that the **AutoToolboxPopulate** option is set to **True**.  
  
## Creating an Instance of a Custom Component  
 The next step is to create an instance of the custom component on the form. Because the **Toolbox** automatically accounts for the new component, this is as easy as creating any other component or control.  
  
#### To create an instance of a custom component  
  
1.  Open the project's form in the **Forms Designer**.  
  
2.  In the **Toolbox**, click the new tab called **ToolboxExample Components**.  
  
     Once you click the tab, you will see **DemoComponent**.  
  
    > [!NOTE]
    >  For performance reasons, components in the auto-populated area of the **Toolbox** do not display custom bitmaps, and the <xref:System.Drawing.ToolboxBitmapAttribute> is not supported. To display an icon for a custom component in the **Toolbox**, use the **Choose Toolbox Items** dialog box to load your component.  
  
3.  Drag your component onto your form.  
  
     An instance of the component is created and added to the **Component Tray**.  
  
## Unloading and Reloading a Custom Component  
 The **Toolbox** takes account of the components in each loaded project, and when a project is unloaded, it removes references to the project's components.  
  
#### To experiment with the effect on the Toolbox of unloading and reloading components  
  
1.  Unload the project from the solution.  
  
     For more information about unloading projects, see [NIB:How to: Unload and Reload Projects](http://msdn.microsoft.com/library/abc0155b-8fcb-4ffc-95b6-698518a7100b). If you are prompted to save, choose **Yes**.  
  
2.  Add a new **Windows Application** project to the solution. Open the form in the **Designer**.  
  
     The **ToolboxExample Components** tab from the previous project is now gone.  
  
3.  Reload the `ToolboxExample` project.  
  
     The **ToolboxExample Components** tab now reappears.  
  
## Next Steps  
 This walkthrough demonstrates that the **Toolbox** takes account of a project's components, but the **Toolbox** is also takes account of controls. Experiment with your own custom controls by adding and removing control projects from your solution.  
  
## See Also  
 [General, Windows Forms Designer, Options Dialog Box](http://msdn.microsoft.com/library/8dd170af-72f0-4212-b04b-034ceee92834)  
 [How to: Manipulate Toolbox Tabs](http://msdn.microsoft.com/library/21285050-cadd-455a-b1f5-a2289a89c4db)  
 [Choose Toolbox Items Dialog Box (Visual Studio)](http://msdn.microsoft.com/library/bd07835f-18a8-433e-bccc-7141f65263bb)  
 [Putting Controls on Windows Forms](../../../../docs/framework/winforms/controls/putting-controls-on-windows-forms.md)

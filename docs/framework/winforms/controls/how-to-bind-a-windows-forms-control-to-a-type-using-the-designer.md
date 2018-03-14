---
title: "How to: Bind a Windows Forms Control to a Type Using the Designer"
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
  - "controls [Windows Forms], binding to a type"
  - "BindingSource component [Windows Forms], binding to a type"
  - "types [Windows Forms], binding controls to"
ms.assetid: 5ab984b5-c2d0-4638-a572-1c84013e8746
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Bind a Windows Forms Control to a Type Using the Designer
When you are building controls that interact with data, you sometimes need to bind a control to a type, rather than an object. You typically need to bind a control to a type at design time, when data may not be available, but you still want your data-bound controls to display data from a type's public interface. The following procedures demonstrate how to create a new <xref:System.Windows.Forms.BindingSource> that is bound to a type, and then how to bind one of the type's properties to the <xref:System.Windows.Forms.TextBox.Text%2A> property of a <xref:System.Windows.Forms.TextBox>.  
  
### To bind the BindingSource to a type  
  
1.  Create a Windows Forms project.  
  
     For more information, see [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa).  
  
2.  In **Design** view, drag a <xref:System.Windows.Forms.BindingSource> component onto the form.  
  
3.  In the **Properties** window, click the arrow for the <xref:System.Windows.Forms.BindingSource.DataSource%2A> property.  
  
4.  In the **DataSource UI Type Editor**, click **Add Project Data Source**.  
  
5.  On the **Choose a Data Source Type** page, select **Object** and click **Next**.  
  
6.  Select the type to bind to:  
  
    -   If the type you want to bind to is in the current project, or the assembly that contains the type is already added as a reference, expand the nodes to find the type you want, and then select it.  
  
         -or-  
  
    -   If the type you want to bind to is in another assembly, not currently in the list of references, click **Add Reference**, and then click the **Projects** tab. Select the project that contains the business object you want and click **OK**. This project will appear in the list of assemblies, so you can expand the nodes to find the type you want, and then select it.  
  
        > [!NOTE]
        >  If you want to bind to a type in a framework or Microsoft assembly, clear the **Hide assemblies that begin with Microsoft or System** check box.  
  
7.  Click **Next**, and then click **Finish**.  
  
### To bind the control to the BindingSource  
  
1.  Add a <xref:System.Windows.Forms.TextBox> to the form.  
  
2.  In the **Properties** window, expand the **(DataBindings)** node.  
  
3.  Click the arrow next to the <xref:System.Windows.Forms.TextBox.Text%2A> property.  
  
4.  In the **DataSource UI Type Editor**, expand the node for the <xref:System.Windows.Forms.BindingSource> added previously, and select the property of the bound type you want to bind to the <xref:System.Windows.Forms.TextBox.Text%2A> property of the <xref:System.Windows.Forms.TextBox>.  
  
## See Also  
 [BindingSource Component](../../../../docs/framework/winforms/controls/bindingsource-component.md)  
 [How to: Bind a Windows Forms Control to a Type](../../../../docs/framework/winforms/controls/how-to-bind-a-windows-forms-control-to-a-type.md)  
 [Bind controls to data in Visual Studio](/visualstudio/data-tools/bind-controls-to-data-in-visual-studio)

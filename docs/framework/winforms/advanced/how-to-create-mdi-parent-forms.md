---
title: "How to: Create MDI Parent Forms"
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
  - "parent forms"
  - "MDI [Windows Forms], creating forms"
ms.assetid: 12c71221-2377-4bb6-b10b-7b4b300fd462
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create MDI Parent Forms
> [!IMPORTANT]
>  This topic uses the <xref:System.Windows.Forms.MainMenu> control, which has been replaced by the <xref:System.Windows.Forms.MenuStrip> control. The <xref:System.Windows.Forms.MainMenu> control is retained for both backward compatibility and future use, if you choose.  For information about creating a MDI parent Form by using a <xref:System.Windows.Forms.MenuStrip>, see [How to: Create an MDI Window List with MenuStrip](../../../../docs/framework/winforms/controls/how-to-create-an-mdi-window-list-with-menustrip-windows-forms.md).  
  
 The foundation of a Multiple-Document Interface (MDI) application is the MDI parent form. This is the form that contains the MDI child windows, which are the sub-windows wherein the user interacts with the MDI application. Creating an MDI parent form is easy, both in the Windows Forms Designer and programmatically.  
  
### To create an MDI parent form at design time  
  
1.  Create a Windows Application project.  
  
2.  In the **Properties** window, set the <xref:System.Windows.Forms.Form.IsMdiContainer%2A> property to **true**.  
  
     This designates the form as an MDI container for child windows.  
  
    > [!NOTE]
    >  While setting properties in the **Properties** window, you can also set the `WindowState` property to **Maximized**, if you like, as it is easiest to manipulate MDI child windows when the parent form is maximized. Additionally, be aware that the edge of the MDI parent form will pick up the system color (set in the Windows System Control Panel), rather than the back color you set using the <xref:System.Windows.Forms.Control.BackColor%2A?displayProperty=nameWithType> property.  
  
3.  From the **Toolbox**, drag a **MenuStrip** control to the form. Create a top-level menu item with the **Text** property set to **&File** with submenu items called **&New** and **&Close**. Also create a top-level menu item called **&Window**.  
  
     The first menu will create and hide menu items at run time, and the second menu will keep track of the open MDI child windows. At this point, you have created an MDI parent window.  
  
4.  Press **F5** to run the application. For information about creating MDI child windows that operate within the MDI parent form, see [How to: Create MDI Child Forms](../../../../docs/framework/winforms/advanced/how-to-create-mdi-child-forms.md).  
  
## See Also  
 [Multiple-Document Interface (MDI) Applications](../../../../docs/framework/winforms/advanced/multiple-document-interface-mdi-applications.md)  
 [How to: Create MDI Child Forms](../../../../docs/framework/winforms/advanced/how-to-create-mdi-child-forms.md)  
 [How to: Determine the Active MDI Child](../../../../docs/framework/winforms/advanced/how-to-determine-the-active-mdi-child.md)  
 [How to: Send Data to the Active MDI Child](../../../../docs/framework/winforms/advanced/how-to-send-data-to-the-active-mdi-child.md)  
 [How to: Arrange MDI Child Forms](../../../../docs/framework/winforms/advanced/how-to-arrange-mdi-child-forms.md)

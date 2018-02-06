---
title: "How to: Inherit from the UserControl Class"
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
  - "inheritance [Windows Forms], Windows Forms custom controls"
  - "UserControl class [Windows Forms], inheriting from"
  - "user controls [Windows Forms], creating"
  - "composite controls [Windows Forms], creating"
ms.assetid: 67713625-e2e4-4f6a-bce7-0855ee5043d9
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Inherit from the UserControl Class
To combine the functionality of one or more Windows Forms controls with custom code, you can create a *user control*. User controls combine rapid control development, standard Windows Forms control functionality, and the versatility of custom properties and methods. When you begin creating a user control, you are presented with a visible designer, upon which you can place standard Windows Forms controls. These controls retain all of their inherent functionality, as well as the appearance and behavior (look and feel) of standard controls. Once these controls are built into the user control, however, they are no longer available to you through code. The user control does its own painting and also handles all of the basic functionality associated with controls.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To create a user control  
  
1.  Create a new **Windows Control Library** project.  
  
     A new project is created with a blank user control.  
  
2.  Drag controls from the **Windows Forms** tab of the **Toolbox** onto your designer.  
  
3.  These controls should be positioned and designed as you want them to appear in the final user control. If you want to allow developers to access the constituent controls, you must declare them as public, or selectively expose properties of the constituent control. For details, see [How to: Expose Properties of Constituent Controls](../../../../docs/framework/winforms/controls/how-to-expose-properties-of-constituent-controls.md).  
  
4.  Implement any custom methods or properties that your control will incorporate.  
  
5.  Press F5 to build the project and run your control in the **UserControl Test Container**. For more information, see [How to: Test the Run-Time Behavior of a UserControl](../../../../docs/framework/winforms/controls/how-to-test-the-run-time-behavior-of-a-usercontrol.md).  
  
## See Also  
 [Varieties of Custom Controls](../../../../docs/framework/winforms/controls/varieties-of-custom-controls.md)  
 [How to: Inherit from the Control Class](../../../../docs/framework/winforms/controls/how-to-inherit-from-the-control-class.md)  
 [How to: Inherit from Existing Windows Forms Controls](../../../../docs/framework/winforms/controls/how-to-inherit-from-existing-windows-forms-controls.md)  
 [How to: Author Controls for Windows Forms](../../../../docs/framework/winforms/controls/how-to-author-controls-for-windows-forms.md)  
 [Troubleshooting Inherited Event Handlers in Visual Basic](~/docs/visual-basic/programming-guide/language-features/events/troubleshooting-inherited-event-handlers.md)  
 [How to: Test the Run-Time Behavior of a UserControl](../../../../docs/framework/winforms/controls/how-to-test-the-run-time-behavior-of-a-usercontrol.md)

---
title: "How to: Inherit from the Control Class"
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
  - "Control class [Windows Forms], inheriting from"
  - "custom controls [Windows Forms], inheritance"
  - "OnPaint method [Windows Forms]"
  - "custom controls [Windows Forms], creating"
ms.assetid: 46ba0df3-5cf7-443c-a3b4-a72660172476
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Inherit from the Control Class
If you want to create a completely custom control to use on a Windows Form, you should inherit from the <xref:System.Windows.Forms.Control> class. While inheriting from the <xref:System.Windows.Forms.Control> class requires that you perform more planning and implementation, it also provides you with the largest range of options. When inheriting from <xref:System.Windows.Forms.Control>, you inherit the very basic functionality that makes controls work. The functionality inherent in the <xref:System.Windows.Forms.Control> class handles user input through the keyboard and mouse, defines the bounds and size of the control, provides a windows handle, and provides message handling and security. It does not incorporate any painting, which in this case is the actual rendering of the graphical interface of the control, nor does it incorporate any specific user interaction functionality. You must provide all of these aspects through custom code.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To create a custom control  
  
1.  Create a new **Windows Application** or **Windows Control Library** project.  
  
2.  From the **Project** menu, choose **Add Class**.  
  
3.  In the **Add New Item** dialog box, click **Custom Control**.  
  
     A new custom control is added to your project.  
  
4.  Press F7 to open the **Code Editor** for your custom control.  
  
5.  Locate the <xref:System.Windows.Forms.Control.OnPaint%2A> method, which will be empty except for a call to the <xref:System.Windows.Forms.Control.OnPaint%2A> method of the base class.  
  
6.  Modify the code to incorporate any custom painting you want for your control.  
  
     For information about writing code to render graphics for controls, see [Custom Control Painting and Rendering](../../../../docs/framework/winforms/controls/custom-control-painting-and-rendering.md).  
  
7.  Implement any custom methods, properties, or events that your control will incorporate.  
  
8.  Save and test your control.  
  
## See Also  
 [Varieties of Custom Controls](../../../../docs/framework/winforms/controls/varieties-of-custom-controls.md)  
 [How to: Inherit from the UserControl Class](../../../../docs/framework/winforms/controls/how-to-inherit-from-the-usercontrol-class.md)  
 [How to: Inherit from Existing Windows Forms Controls](../../../../docs/framework/winforms/controls/how-to-inherit-from-existing-windows-forms-controls.md)  
 [How to: Author Controls for Windows Forms](../../../../docs/framework/winforms/controls/how-to-author-controls-for-windows-forms.md)  
 [Troubleshooting Inherited Event Handlers in Visual Basic](~/docs/visual-basic/programming-guide/language-features/events/troubleshooting-inherited-event-handlers.md)  
 [Developing Windows Forms Controls at Design Time](../../../../docs/framework/winforms/controls/developing-windows-forms-controls-at-design-time.md)

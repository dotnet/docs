---
title: "Varieties of Custom Controls"
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
  - "controls [Windows Forms], user controls"
  - "controls [Windows Forms], types of"
  - "composite controls [Windows Forms]"
  - "extended controls [Windows Forms]"
  - "controls [Windows Forms], extended"
  - "user controls [Windows Forms]"
  - "custom controls [Windows Forms]"
  - "controls [Windows Forms], composite"
ms.assetid: 3cea09e5-4344-4ccb-9858-b66ccac210ff
caps.latest.revision: 20
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Varieties of Custom Controls
With the .NET Framework, you can develop and implement new controls. You can extend the functionality of the familiar user control as well as existing controls through inheritance. You can also write custom controls that perform their own painting.  
  
 Deciding which kind of control to create can be confusing. This topic highlights the differences among the various kinds of controls from which you can inherit, and provides you with information about how to choose a particular kind of control for your project.  
  
> [!NOTE]
>  For information about authoring a control to use on Web Forms, see [Developing Custom ASP.NET Server Controls](http://msdn.microsoft.com/library/fbe26c16-cff4-4089-b3dd-877411f0c0ef).  
  
## Base Control Class  
 The <xref:System.Windows.Forms.Control> class is the base class for Windows Forms controls. It provides the infrastructure required for visual display in Windows Forms applications.  
  
 The <xref:System.Windows.Forms.Control> class performs the following tasks to provide visual display in Windows Forms applications:  
  
-   Exposes a window handle.  
  
-   Manages message routing.  
  
-   Provides mouse and keyboard events, and many other user interface events.  
  
-   Provides advanced layout features.  
  
-   Contains many properties specific to visual display, such as <xref:System.Windows.Forms.Control.ForeColor%2A>, <xref:System.Windows.Forms.Control.BackColor%2A>, <xref:System.Windows.Forms.Control.Height%2A>, and <xref:System.Windows.Forms.Control.Width%2A>.  
  
-   Provides the security and threading support necessary for a Windows Forms control to act as a Microsoft® ActiveX® control.  
  
 Because so much of the infrastructure is provided by the base class, it is relatively easy to develop your own Windows Forms controls.  
  
## Kinds of Controls  
 Windows Forms supports three kinds of user-defined controls: *composite*, *extended*, and *custom*. The following sections describe each kind of control and give recommendations for choosing the kind to use in your projects.  
  
### Composite Controls  
 A composite control is a collection of Windows Forms controls encapsulated in a common container. This kind of control is sometimes called a *user control*. The contained controls are called *constituent controls*.  
  
 A composite control holds all of the inherent functionality associated with each of the contained Windows Forms controls and enables you to selectively expose and bind their properties. A composite control also provides a great deal of default keyboard handling functionality with no extra development effort on your part.  
  
 For example, a composite control could be built to display customer address data from a database. This control could include a <xref:System.Windows.Forms.DataGridView> control to display the database fields, a <xref:System.Windows.Forms.BindingSource> to handle binding to a data source, and a <xref:System.Windows.Forms.BindingNavigator> control to move through the records. You could selectively expose data binding properties, and you could package and reuse the entire control from application to application. For an example of this kind of composite control, see [How to: Apply Attributes in Windows Forms Controls](../../../../docs/framework/winforms/controls/how-to-apply-attributes-in-windows-forms-controls.md).  
  
 To author a composite control, derive from the <xref:System.Windows.Forms.UserControl> class. The <xref:System.Windows.Forms.UserControl> base class provides keyboard routing for child controls and enables child controls to work as a group. For more information, see [Developing a Composite Windows Forms Control](../../../../docs/framework/winforms/controls/developing-a-composite-windows-forms-control.md).  
  
 **Recommendation**  
  
 Inherit from the <xref:System.Windows.Forms.UserControl> class if:  
  
-   You want to combine the functionality of several Windows Forms controls into a single reusable unit.  
  
### Extended Controls  
 You can derive an inherited control from any existing Windows Forms control. With this approach, you can retain all of the inherent functionality of a Windows Forms control, and then extend that functionality by adding custom properties, methods, or other features. With this option, you can override the base control's paint logic, and then extend its user interface by changing its appearance.  
  
 For example, you can create a control derived from the <xref:System.Windows.Forms.Button> control that tracks how many times a user has clicked it.  
  
 In some controls, you can also add a custom appearance to the graphical user interface of your control by overriding the <xref:System.Windows.Forms.Control.OnPaint%2A> method of the base class. For an extended button that tracks clicks, you can override the <xref:System.Windows.Forms.Control.OnPaint%2A> method to call the base implementation of <xref:System.Windows.Forms.Control.OnPaint%2A>, and then draw the click count in one corner of the <xref:System.Windows.Forms.Button> control's client area.  
  
 **Recommendation**  
  
 Inherit from a Windows Forms control if:  
  
-   Most of the functionality you need is already identical to an existing Windows Forms control.  
  
-   You do not need a custom graphical user interface, or you want to design a new graphical user interface for an existing control.  
  
### Custom Controls  
 Another way to create a control is to create one substantially from the beginning by inheriting from <xref:System.Windows.Forms.Control>. The <xref:System.Windows.Forms.Control> class provides all of the basic functionality required by controls, including mouse and keyboard handling events, but no control-specific functionality or graphical interface.  
  
 Creating a control by inheriting from the <xref:System.Windows.Forms.Control> class requires much more thought and effort than inheriting from <xref:System.Windows.Forms.UserControl> or an existing Windows Forms control. Because a great deal of implementation is left for you, your control can have greater flexibility than a composite or extended control, and you can tailor your control to suit your exact needs.  
  
 To implement a custom control, you must write code for the <xref:System.Windows.Forms.Control.OnPaint%2A> event of the control, as well as any feature-specific code you need. You can also override the <xref:System.Windows.Forms.Control.WndProc%2A> method and handle windows messages directly. This is the most powerful way to create a control, but to use this technique effectively, you need to be familiar with the Microsoft Win32® API.  
  
 An example of a custom control is a clock control that duplicates the appearance and behavior of an analog clock. Custom painting is invoked to cause the hands of the clock to move in response to <xref:System.Windows.Forms.Timer.Tick> events from an internal <xref:System.Windows.Forms.Timer> component. For more information, see [How to: Develop a Simple Windows Forms Control](../../../../docs/framework/winforms/controls/how-to-develop-a-simple-windows-forms-control.md).  
  
 **Recommendation**  
  
 Inherit from the <xref:System.Windows.Forms.Control> class if:  
  
-   You want to provide a custom graphical representation of your control.  
  
-   You need to implement custom functionality that is not available through standard controls.  
  
### ActiveX Controls  
 Although the Windows Forms infrastructure has been optimized to host Windows Forms controls, you can still use ActiveX controls. There is support for this task in Visual Studio. For more information, see [How to: Add ActiveX Controls to Windows Forms](../../../../docs/framework/winforms/controls/how-to-add-activex-controls-to-windows-forms.md).  
  
### Windowless Controls  
 The Microsoft Visual Basic® 6.0and ActiveX technologies support *windowless* controls. Windowless controls are not supported in Windows Forms.  
  
## Custom Design Experience  
 If you need to implement a custom design-time experience, you can author your own designer. For composite controls, derive your custom designer class from the <xref:System.Windows.Forms.Design.ParentControlDesigner> or the <xref:System.Windows.Forms.Design.DocumentDesigner> classes. For extended and custom controls, derive your custom designer class from the <xref:System.Windows.Forms.Design.ControlDesigner> class.  
  
 Use the <xref:System.ComponentModel.DesignerAttribute> to associate your control with your designer. For more information, see [Extending Design-Time Support](http://msdn.microsoft.com/library/d6ac8a6a-42fd-4bc8-bf33-b212811297e2) and [How to: Create a Windows Forms Control That Takes Advantage of Design-Time Features](http://msdn.microsoft.com/library/8e0bad0e-56f3-43d2-bf63-a945c654d97c).  
  
## See Also  
 [Developing Custom Windows Forms Controls with the .NET Framework](../../../../docs/framework/winforms/controls/developing-custom-windows-forms-controls.md)  
 [How to: Develop a Simple Windows Forms Control](../../../../docs/framework/winforms/controls/how-to-develop-a-simple-windows-forms-control.md)  
 [Developing a Composite Windows Forms Control](../../../../docs/framework/winforms/controls/developing-a-composite-windows-forms-control.md)  
 [Extending Design-Time Support](http://msdn.microsoft.com/library/d6ac8a6a-42fd-4bc8-bf33-b212811297e2)  
 [How to: Create a Windows Forms Control That Takes Advantage of Design-Time Features](http://msdn.microsoft.com/library/8e0bad0e-56f3-43d2-bf63-a945c654d97c)

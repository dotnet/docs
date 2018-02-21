---
title: "Developing Windows Forms Controls at Design Time"
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
  - "Windows Forms controls [Windows Forms]"
  - "Windows Forms controls, creating"
  - "controls [Windows Forms]"
  - "controls [Windows Forms], creating"
  - "user controls [Windows Forms]"
  - "custom controls [Windows Forms]"
ms.assetid: e5a8e088-7ec8-4fd9-bcb3-9078fd134829
caps.latest.revision: 22
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Developing Windows Forms Controls at Design Time
For control authors, the .NET Framework provides a wealth of control authoring technology. Authors are no longer limited to designing composite controls that act as a collection of preexisting controls. Through inheritance, you can create your own controls from preexisting composite controls or preexisting Windows Forms controls. You can also design your own controls that implement custom painting. These options enable a great deal of flexibility to the design and functionality of the visual interface. To take advantage of these features, you should be familiar with object-based programming concepts.  
  
> [!NOTE]
>  It is not necessary to have a thorough understanding of inheritance, but you may find it useful to refer to [Inheritance basics (Visual Basic)](~/docs/visual-basic/programming-guide/language-features/objects-and-classes/inheritance-basics.md).  
  
 If you want to create custom controls to use on Web Forms, see [Developing Custom ASP.NET Server Controls](http://msdn.microsoft.com/library/fbe26c16-cff4-4089-b3dd-877411f0c0ef).  
  
## In This Section  
 [Walkthrough: Authoring a Composite Control with Visual Basic](../../../../docs/framework/winforms/controls/walkthrough-authoring-a-composite-control-with-visual-basic.md)  
 Shows how to create a simple composite control in Visual Basic.  
  
 [Walkthrough: Authoring a Composite Control with Visual C#](../../../../docs/framework/winforms/controls/walkthrough-authoring-a-composite-control-with-visual-csharp.md)  
 Shows how to create a simple composite control in C#.  
  
 [Walkthrough: Inheriting from a Windows Forms Control with Visual Basic](../../../../docs/framework/winforms/controls/walkthrough-inheriting-from-a-windows-forms-control-with-visual-basic.md)  
 Shows how to create a simple Windows Forms control using inheritance in Visual Basic.  
  
 [Walkthrough: Inheriting from a Windows Forms Control with Visual C#](../../../../docs/framework/winforms/controls/walkthrough-inheriting-from-a-windows-forms-control-with-visual-csharp.md)  
 Shows how to create a simple Windows Forms control using inheritance in C#.  
  
 [Walkthrough: Performing Common Tasks Using Smart Tags on Windows Forms Controls](../../../../docs/framework/winforms/controls/performing-common-tasks-using-smart-tags-on-wf-controls.md)  
 Shows how to use the smart tag feature on Windows Forms controls.  
  
 [Walkthrough: Serializing Collections of Standard Types with the DesignerSerializationVisibilityAttribute](../../../../docs/framework/winforms/controls/serializing-collections-designerserializationvisibilityattribute.md)  
 Shows how to use the <xref:System.ComponentModel.DesignerSerializationVisibilityAttribute.Content?displayProperty=nameWithType> attribute to serialize a collection.  
  
 [Walkthrough: Debugging Custom Windows Forms Controls at Design Time](../../../../docs/framework/winforms/controls/walkthrough-debugging-custom-windows-forms-controls-at-design-time.md)  
 Shows how to debug the design-time behavior of a Windows Forms control.  
  
 [Walkthrough: Creating a Windows Forms Control That Takes Advantage of Visual Studio Design-Time Features](../../../../docs/framework/winforms/controls/creating-a-wf-control-design-time-features.md)  
 Shows how to tightly integrate a composite control into the design environment.  
  
 [How to: Author Controls for Windows Forms](../../../../docs/framework/winforms/controls/how-to-author-controls-for-windows-forms.md)  
 Provides an overview of considerations for implementing a Windows Forms control.  
  
 [How to: Author Composite Controls](../../../../docs/framework/winforms/controls/how-to-author-composite-controls.md)  
 Shows how to create a control by inheriting from a composite control.  
  
 [How to: Inherit from the UserControl Class](../../../../docs/framework/winforms/controls/how-to-inherit-from-the-usercontrol-class.md)  
 Provides an overview of the procedure for creating a composite control.  
  
 [How to: Inherit from Existing Windows Forms Controls](../../../../docs/framework/winforms/controls/how-to-inherit-from-existing-windows-forms-controls.md)  
 Shows how to create an extended control by inheriting from the <xref:System.Windows.Forms.Button> control class.  
  
 [How to: Inherit from the Control Class](../../../../docs/framework/winforms/controls/how-to-inherit-from-the-control-class.md)  
 Provides an overview of creating an extended control.  
  
 [How to: Align a Control to the Edges of Forms at Design Time](../../../../docs/framework/winforms/controls/how-to-align-a-control-to-the-edges-of-forms-at-design-time.md)  
 Shows how to use the <xref:System.Windows.Forms.Control.Dock%2A> property to align your control to the edge of the form it occupies.  
  
 [How to: Display a Control in the Choose Toolbox Items Dialog Box](../../../../docs/framework/winforms/controls/how-to-display-a-control-in-the-choose-toolbox-items-dialog-box.md)  
 Shows the procedure for installing your control so that it appears in the **Customize Toolbox** dialog box.  
  
 [How to: Provide a Toolbox Bitmap for a Control](../../../../docs/framework/winforms/controls/how-to-provide-a-toolbox-bitmap-for-a-control.md)  
 Shows how to use the <xref:System.Drawing.ToolboxBitmapAttribute> to display an icon next to your custom control in the **Toolbox**.  
  
 [How to: Test the Run-Time Behavior of a UserControl](../../../../docs/framework/winforms/controls/how-to-test-the-run-time-behavior-of-a-usercontrol.md)  
 Shows how to use the **UserControl Test Container** to test the behavior of a composite control.  
  
 [Design-Time Errors in the Windows Forms Designer](../../../../docs/framework/winforms/controls/design-time-errors-in-the-windows-forms-designer.md)  
 Explains the meaning and use of the Design-Time Error List that appears in Microsoft Visual Studio when the Windows Forms designer fails to load.  
  
 [Troubleshooting Control and Component Authoring](../../../../docs/framework/winforms/controls/troubleshooting-control-and-component-authoring.md)  
 Shows how to diagnose and fix common issues that can occur when you author a custom component or control.  
  
## Reference  
 <xref:System.Windows.Forms.Control?displayProperty=nameWithType>  
 Describes this class and has links to all of its members.  
  
 <xref:System.Windows.Forms.UserControl?displayProperty=nameWithType>  
 Describes this class and has links to all of its members.  
  
## Related Sections  
 [Developing Custom Windows Forms Controls with the .NET Framework](../../../../docs/framework/winforms/controls/developing-custom-windows-forms-controls.md)  
 Discusses how to create your own custom controls with the .NET Framework.  
  
 [Language Independence and Language-Independent Components](../../../../docs/standard/language-independence-and-language-independent-components.md)  
 Introduces the common language runtime, which is designed to simplify the creation and use of components. An important aspect of this simplification is enhanced interoperability between components written using different programming languages. The Common Language Specification (CLS) makes it possible to create tools and components that work with multiple programming languages.  
  
 [Walkthrough: Automatically Populating the Toolbox with Custom Components](../../../../docs/framework/winforms/controls/walkthrough-automatically-populating-the-toolbox-with-custom-components.md)  
 Describes how to enable your component or control to be displayed in the **Customize Toolbox** dialog box.

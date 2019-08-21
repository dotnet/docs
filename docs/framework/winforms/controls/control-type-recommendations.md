---
title: "Control Type Recommendations"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "inheritance [Windows Forms], Windows Forms custom controls"
  - "user controls [Windows Forms], when to use"
  - "custom controls [Windows Forms], types"
  - "controls [Windows Forms], creating"
ms.assetid: 5235fe9d-c36a-4c08-ae76-6cb90b50085e
---
# Control Type Recommendations
The .NET Framework gives you power to develop and implement new controls. In addition to the familiar user control, you will now find that you are able to write custom controls that perform their own painting, and are even able to extend the functionality of existing controls through inheritance. Deciding which type of control to create can be confusing. This section highlights the differences between the various types of controls from which you can inherit, and gives considerations regarding the type to choose for your project.  
  
> [!NOTE]
> If you want to author a control to use on Web Forms, see [Developing Custom ASP.NET Server Controls](https://docs.microsoft.com/previous-versions/aspnet/zt27tfhy(v=vs.100)).  
  
## Inheriting from a Windows Forms Control  
 You can derive an inherited control from any existing Windows Forms control. This approach allows you to retain all of the inherent functionality of a Windows Forms control, and to then extend that functionality by adding custom properties, methods, or other functionality. For example, you might create a control derived from <xref:System.Windows.Forms.TextBox> that can accept only numbers and automatically converts input into a value. Such a control might contain validation code that was called whenever the text in the text box changed, and could have an additional property, Value. In some controls, you can also add a custom appearance to the graphical interface of your control by overriding the <xref:System.Windows.Forms.Control.OnPaint%2A> method of the base class.  
  
 Inherit from a Windows Forms control if:  
  
- Most of the functionality you need is already identical to an existing Windows Forms control.  
  
- You do not need a custom graphical interface, or you want to design a new graphical front end for an existing control.  
  
## Inheriting from the UserControl Class  
 A user control is a collection of Windows Forms controls encapsulated into a common container. The container holds all of the inherent functionality associated with each of the Windows Forms controls and allows you to selectively expose and bind their properties. An example of a user control might be a control built to display customer address data from a database. This control would include several textboxes to display each field, and button controls to navigate through the records. Data-binding properties could be selectively exposed, and the entire control could be packaged and reused from application to application.  
  
 Inherit from the <xref:System.Windows.Forms.UserControl> class if:  
  
- You want to combine the functionality of several Windows Forms controls into a single reusable unit.  
  
## Inheriting from the Control Class  
 Another way to create a control is to create one substantially from scratch by inheriting from <xref:System.Windows.Forms.Control>. The <xref:System.Windows.Forms.Control> class provides all of the basic functionality required by controls (for example, events), but no control-specific functionality or graphical interface. Creating a control by inheriting from the <xref:System.Windows.Forms.Control> class requires a lot more thought and effort than inheriting from user control or an existing Windows Forms control. The author must write code for the <xref:System.Windows.Forms.Control.OnPaint%2A> event of the control, as well as any functionality specific code that is needed. Greater flexibility is allowed, however, and you can custom tailor a control to suit your exact needs. An example of a custom control is a clock control that duplicates the look and action of an analog clock. Custom painting would be invoked to cause the hands of the clock to move in response to <xref:System.Windows.Forms.Timer.Tick> events from an internal timer component.  
  
 Inherit from the <xref:System.Windows.Forms.Control> class if:  
  
- You want to provide a custom graphical representation of your control.  
  
- You need to implement custom functionality that is not available through standard controls.  
  
- [How to: Display a Control in the Choose Toolbox Items Dialog Box](how-to-display-a-control-in-the-choose-toolbox-items-dialog-box.md)  
  
- [Walkthrough: Serializing Collections of Standard Types with the DesignerSerializationVisibilityAttribute](serializing-collections-designerserializationvisibilityattribute.md)  
  
- [Walkthrough: Inheriting from a Windows Forms Control with Visual C#](walkthrough-inheriting-from-a-windows-forms-control-with-visual-csharp.md)  
  
- [How to: Provide a Toolbox Bitmap for a Control](how-to-provide-a-toolbox-bitmap-for-a-control.md)  
  
- [How to: Inherit from Existing Windows Forms Controls](how-to-inherit-from-existing-windows-forms-controls.md)  
  
- [Walkthrough: Debugging Custom Windows Forms Controls at Design Time](walkthrough-debugging-custom-windows-forms-controls-at-design-time.md)  
  
- [How to: Inherit from the Control Class](how-to-inherit-from-the-control-class.md)  
  
- [How to: Test the Run-Time Behavior of a UserControl](how-to-test-the-run-time-behavior-of-a-usercontrol.md)  
  
- [How to: Align a Control to the Edges of Forms at Design Time](how-to-align-a-control-to-the-edges-of-forms-at-design-time.md)  
  
- [How to: Inherit from the UserControl Class](how-to-inherit-from-the-usercontrol-class.md)  
  
- [How to: Author Controls for Windows Forms](how-to-author-controls-for-windows-forms.md)  
  
- [How to: Author Composite Controls](how-to-author-composite-controls.md)  
  
- [Walkthrough: Authoring a Composite Control with Visual Basic](walkthrough-authoring-a-composite-control-with-visual-basic.md)  
  
- [Walkthrough: Authoring a Composite Control with Visual C#](walkthrough-authoring-a-composite-control-with-visual-csharp.md)  
  
- [Walkthrough: Inheriting from a Windows Forms Control with Visual Basic](walkthrough-inheriting-from-a-windows-forms-control-with-visual-basic.md)  
  
- [Walkthrough: Creating a Windows Forms Control That Takes Advantage of Visual Studio Design-Time Features](creating-a-wf-control-design-time-features.md)  
  
- [How to: Create a Windows Forms Control That Takes Advantage of Design-Time Features](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2013/307hck25(v=vs.120))  
  
## See also

- [How to: Develop a Simple Windows Forms Control](how-to-develop-a-simple-windows-forms-control.md)
- [Varieties of Custom Controls](varieties-of-custom-controls.md)

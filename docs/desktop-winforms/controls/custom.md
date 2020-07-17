---
title: Types of custom controls
description: Learn about the different types of custom controls you can create in Windows Forms for .NET.
ms.date: 06/15/2020
ms.topic: overview
f1_keywords: 
  - "UserControl"
helpviewer_keywords: 
  - "controls [Windows Forms], user controls"
  - "controls [Windows Forms], types of"
  - "composite controls [Windows Forms]"
  - "extended controls [Windows Forms]"
  - "controls [Windows Forms], extended"
  - "user controls [Windows Forms]"
  - "custom controls [Windows Forms]"
  - "controls [Windows Forms], composite"
---

# Types of custom controls

With Windows Forms, you can develop and implement new controls. You can create a new user control, modify existing controls through inheritance, and write a custom control that does its own painting.

Deciding which kind of control to create can be confusing. This article highlights the differences among the various kinds of controls from which you can inherit, and provides you with information about how to choose a particular type of control for your project.

<table>
<thead>
  <tr>
    <th>If ...</th>
    <th>Create a ...</th>
  </tr>
</thead>
<tbody>
  <tr>
    <td>
        <ul>
            <li>You want to combine the functionality of several Windows Forms controls into a single reusable unit.</li>
        </ul>
    </td>
    <td><a href="#composite-controls">Composite control</a> by inheriting from <a href="https://docs.microsoft.com/dotnet/api/system.windows.forms.usercontrol">System.Windows.Forms.UserControl</a>.</td>
  </tr>
  <tr>
    <td>
        <ul>
            <li>Most of the functionality you need is already identical to an existing Windows Forms control.</li>
            <li>You don't need a custom graphical user interface, or you want to design a new graphical user interface for an existing control.</li>
        </ul>
    </td>
    <td><a href="#extended-controls">Extended control</a> by inheriting from a specific Windows Forms control.</td>
  </tr>
  <tr>
    <td>
        <ul>
            <li>You want to provide a custom graphical representation of your control.</li>
            <li>You need to implement custom functionality that isn't available through standard controls.</li>
        </ul>
    </td>
    <td><a href="#custom-controls">Custom control</a> by inheriting from <a href="https://docs.microsoft.com/dotnet/api/system.windows.forms.control">System.Windows.Forms.Control</a>.</td>
  </tr>
</tbody>
</table>

## Base Control Class

The <xref:System.Windows.Forms.Control> class is the base class for Windows Forms controls. It provides the infrastructure required for visual display in Windows Forms applications and provides the following capabilities:

- Exposes a window handle.
- Manages message routing.
- Provides mouse and keyboard events, and many other user interface events.
- Provides advanced layout features.
- Contains many properties specific to visual display, such as <xref:System.Windows.Forms.Control.ForeColor%2A>, <xref:System.Windows.Forms.Control.BackColor%2A>, <xref:System.Windows.Forms.Control.Height%2A>, and <xref:System.Windows.Forms.Control.Width%2A>.
- Provides the security and threading support necessary for a Windows Forms control to act as a Microsoft® ActiveX® control.

Because so much of the infrastructure is provided by the base class, it's relatively easy to develop your own Windows Forms controls.

## Composite Controls

A composite control is a collection of Windows Forms controls encapsulated in a common container. This kind of control is sometimes called a *user control*. The contained controls are called *constituent controls*.

A composite control holds all of the inherent functionality associated with each of the contained Windows Forms controls and enables you to selectively expose and bind their properties. A composite control also provides a great deal of default keyboard handling functionality with no extra development effort on your part.

For example, a composite control could be built to display customer address data from a database. This control would include a <xref:System.Windows.Forms.DataGridView> control to display the database fields, a <xref:System.Windows.Forms.BindingSource> to handle binding to a data source, and a <xref:System.Windows.Forms.BindingNavigator> control to move through the records. You could selectively expose data binding properties, and you could package and reuse the entire control from application to application. For an example of this kind of composite control, see [How to: Apply Attributes in Windows Forms Controls](how-to-apply-attributes-in-windows-forms-controls.md).

To author a composite control, derive from the <xref:System.Windows.Forms.UserControl> class. The <xref:System.Windows.Forms.UserControl> base class provides keyboard routing for child controls and enables child controls to work as a group. For more information, see [Developing a Composite Windows Forms Control](developing-a-composite-windows-forms-control.md).

## Extended Controls

You can derive an inherited control from any existing Windows Forms control. With this approach, you can keep all of the inherent functionality of a Windows Forms control, and then extend that functionality by adding custom properties, methods, or other features. With this option, you can override the base control's paint logic, and then extend its user interface by changing its appearance.

For example, you can create a control derived from the <xref:System.Windows.Forms.Button> control that tracks how many times a user has clicked it.

In some controls, you can also add a custom appearance to the graphical user interface of your control by overriding the <xref:System.Windows.Forms.Control.OnPaint%2A> method of the base class. For an extended button that tracks clicks, you can override the <xref:System.Windows.Forms.Control.OnPaint%2A> method to call the base implementation of <xref:System.Windows.Forms.Control.OnPaint%2A>, and then draw the click count in one corner of the <xref:System.Windows.Forms.Button> control's client area.

## Custom Controls

Another way to create a control is to create one substantially from the beginning by inheriting from <xref:System.Windows.Forms.Control>. The <xref:System.Windows.Forms.Control> class provides all of the basic functionality required by controls, including mouse and keyboard handling events, but no control-specific functionality or graphical interface.

Creating a control by inheriting from the <xref:System.Windows.Forms.Control> class requires much more thought and effort than inheriting from <xref:System.Windows.Forms.UserControl> or an existing Windows Forms control. Because a great deal of implementation is left for you, your control can have greater flexibility than a composite or extended control, and you can tailor your control to suit your exact needs.

To implement a custom control, you must write code for the <xref:System.Windows.Forms.Control.OnPaint%2A> event of the control, as well as any feature-specific code you need. You can also override the <xref:System.Windows.Forms.Control.WndProc%2A> method and handle windows messages directly. This is the most powerful way to create a control, but to use this technique effectively, you need to be familiar with the Microsoft Win32® API.

An example of a custom control is a clock control that duplicates the appearance and behavior of an analog clock. Custom painting is invoked to cause the hands of the clock to move in response to <xref:System.Windows.Forms.Timer.Tick> events from an internal <xref:System.Windows.Forms.Timer> component. For more information, see [How to: Develop a Simple Windows Forms Control](how-to-develop-a-simple-windows-forms-control.md).

## ActiveX Controls

Although the Windows Forms infrastructure has been optimized to host Windows Forms controls, you can still use ActiveX controls. There's support for this task in Visual Studio. For more information, see [How to: Add ActiveX Controls to Windows Forms](how-to-add-activex-controls-to-windows-forms.md).

## Windowless Controls

The Microsoft Visual Basic® 6.0 and ActiveX technologies support *windowless* controls. Windowless controls aren't supported in Windows Forms.

## Custom Design Experience

If you need to implement a custom design-time experience, you can author your own designer. For composite controls, derive your custom designer class from the <xref:System.Windows.Forms.Design.ParentControlDesigner> or the <xref:System.Windows.Forms.Design.DocumentDesigner> classes. For extended and custom controls, derive your custom designer class from the <xref:System.Windows.Forms.Design.ControlDesigner> class.

Use the <xref:System.ComponentModel.DesignerAttribute> to associate your control with your designer.

The following information is out of date but may help you.

- [(Visual Studio 2013) Extending Design-Time Support](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2013/37899azc(v=vs.120)).
- [(Visual Studio 2013) How to: Create a Windows Forms Control That Takes Advantage of Design-Time Features](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2013/307hck25(v=vs.120)).

## See also

- [Developing Custom Windows Forms Controls](developing-custom-windows-forms-controls.md)
- [How to: Develop a Simple Windows Forms Control](how-to-develop-a-simple-windows-forms-control.md)
- [Developing a Composite Windows Forms Control](developing-a-composite-windows-forms-control.md)

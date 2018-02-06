---
title: "Mouse Events in Windows Forms"
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
  - "MouseLeave event [Windows Forms]"
  - "events [Windows Forms], mouse"
  - "Click event [Windows Forms], raising order"
  - "Windows Forms controls, click events"
  - "MouseDoubleClick event [Windows Forms]"
  - "MouseEnter event [Windows Forms]"
  - "MouseHover event [Windows Forms]"
  - "MouseDown event [Windows Forms]"
  - "MouseClick event [Windows Forms]"
  - "MouseMove event [Windows Forms]"
  - "mouse [Windows Forms], events"
  - "MouseUp event"
ms.assetid: 8cf0070d-793b-4876-b09e-d20d28280fab
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Mouse Events in Windows Forms
When you handle mouse input, you usually want to know the location of the mouse pointer and the state of the mouse buttons. This topic provides details on how to get this information from mouse events, and explains the order in which mouse click events are raised in Windows Forms controls. For a list and description of all of the mouse events, see [How Mouse Input Works in Windows Forms](../../../docs/framework/winforms/how-mouse-input-works-in-windows-forms.md).  Also see [Event Handlers Overview (Windows Forms)](http://msdn.microsoft.com/library/be6fx1bb\(v=vs.110\)), [Events Overview (Windows Forms)](http://msdn.microsoft.com/library/1h12f09z\(v=vs.110\))  
  
## Mouse Information  
 A <xref:System.Windows.Forms.MouseEventArgs> is sent to the handlers of mouse events related to clicking a mouse button and tracking mouse movements. <xref:System.Windows.Forms.MouseEventArgs> provides information about the current state of the mouse, including the location of the mouse pointer in client coordinates, which mouse buttons are pressed, and whether the mouse wheel has scrolled. Several mouse events, such as those that simply notify when the mouse pointer has entered or left the bounds of a control, send an <xref:System.EventArgs> to the event handler with no further information.  
  
 If you want to know the current state of the mouse buttons or the location of the mouse pointer, and you want to avoid handling a mouse event, you can also use the <xref:System.Windows.Forms.Control.MouseButtons%2A> and <xref:System.Windows.Forms.Control.MousePosition%2A> properties of the <xref:System.Windows.Forms.Control> class. <xref:System.Windows.Forms.Control.MouseButtons%2A> returns information about which mouse buttons are currently pressed. The <xref:System.Windows.Forms.Control.MousePosition%2A> returns the screen coordinates of the mouse pointer and is equivalent to the value returned by <xref:System.Windows.Forms.Cursor.Position%2A>.  
  
## Converting Between Screen and Client Coordinates  
 Because some mouse location information is in client coordinates and some is in screen coordinates, you may need to convert a point from one coordinate system to the other. You can do this easily by using the <xref:System.Windows.Forms.Control.PointToClient%2A> and <xref:System.Windows.Forms.Control.PointToScreen%2A> methods available on the <xref:System.Windows.Forms.Control> class.  
  
## Standard Click Event Behavior  
 If you want to handle mouse click events in the proper order, you need to know the order in which click events are raised in Windows Forms controls. All Windows Forms controls raise click events in the same order when a mouse button is pressed and released (regardless of which mouse button), except where noted in the following list for individual controls. The following list shows the order of events raised for a single mouse-button click:  
  
1.  <xref:System.Windows.Forms.Control.MouseDown> event.  
  
2.  <xref:System.Windows.Forms.Control.Click> event.  
  
3.  <xref:System.Windows.Forms.Control.MouseClick> event.  
  
4.  <xref:System.Windows.Forms.Control.MouseUp> event.  
  
 Following is the order of events raised for a double mouse-button click:  
  
1.  <xref:System.Windows.Forms.Control.MouseDown> event.  
  
2.  <xref:System.Windows.Forms.Control.Click> event.  
  
3.  <xref:System.Windows.Forms.Control.MouseClick> event.  
  
4.  <xref:System.Windows.Forms.Control.MouseUp> event.  
  
5.  <xref:System.Windows.Forms.Control.MouseDown> event.  
  
6.  <xref:System.Windows.Forms.Control.DoubleClick> event. (This can vary, depending on whether the control in question has the <xref:System.Windows.Forms.ControlStyles.StandardDoubleClick> style bit set to `true`. For more information about how to set a <xref:System.Windows.Forms.ControlStyles> bit, see the <xref:System.Windows.Forms.Control.SetStyle%2A> method.)  
  
7.  <xref:System.Windows.Forms.Control.MouseDoubleClick> event.  
  
8.  <xref:System.Windows.Forms.Control.MouseUp> event.  
  
 For a code example that demonstrates the order of the mouse click events, see [How to: Handle User Input Events in Windows Forms Controls](../../../docs/framework/winforms/how-to-handle-user-input-events-in-windows-forms-controls.md).  
  
### Individual Controls  
 The following controls do not conform to the standard mouse click event behavior:  
  
-   <xref:System.Windows.Forms.Button>, <xref:System.Windows.Forms.CheckBox>, <xref:System.Windows.Forms.ComboBox>, and <xref:System.Windows.Forms.RadioButton> controls  
  
    > [!NOTE]
    >  For the <xref:System.Windows.Forms.ComboBox> control, the event behavior detailed later occurs if the user clicks on the edit field, the button, or on an item within the list.  
  
    -   Left click: <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>  
  
    -   Right click: No click events raised  
  
    -   Left double-click: <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>; <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>  
  
    -   Right double-click: No click events raised  
  
-   <xref:System.Windows.Forms.TextBox>, <xref:System.Windows.Forms.RichTextBox>, <xref:System.Windows.Forms.ListBox>, <xref:System.Windows.Forms.MaskedTextBox>, and <xref:System.Windows.Forms.CheckedListBox> controls  
  
    > [!NOTE]
    >  The event behavior detailed later occurs when the user clicks anywhere within these controls.  
  
    -   Left click: <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>  
  
    -   Right click: No click events raised  
  
    -   Left double-click: <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>, <xref:System.Windows.Forms.Control.DoubleClick>, <xref:System.Windows.Forms.Control.MouseDoubleClick>  
  
    -   Right double-click: No click events raised  
  
-   <xref:System.Windows.Forms.ListView> control  
  
    > [!NOTE]
    >  The event behavior detailed later occurs only when the user clicks on the items in the <xref:System.Windows.Forms.ListView> control. No events are raised for clicks anywhere else on the control. In addition to the events described later, there are the <xref:System.Windows.Forms.ListView.BeforeLabelEdit> and <xref:System.Windows.Forms.ListView.AfterLabelEdit> events, which may be of interest to you if you want to use validation with the <xref:System.Windows.Forms.ListView> control.  
  
    -   Left click: <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>  
  
    -   Right click: <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>  
  
    -   Left double-click: <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>; <xref:System.Windows.Forms.Control.DoubleClick>, <xref:System.Windows.Forms.Control.MouseDoubleClick>  
  
    -   Right double-click: <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>; <xref:System.Windows.Forms.Control.DoubleClick>, <xref:System.Windows.Forms.Control.MouseDoubleClick>  
  
-   <xref:System.Windows.Forms.TreeView> control  
  
    > [!NOTE]
    >  The event behavior detailed later occurs only when the user clicks on the items themselves or to the right of the items in the <xref:System.Windows.Forms.TreeView> control. No events are raised for clicks anywhere else on the control. In addition to those described later, there are the <xref:System.Windows.Forms.TreeView.BeforeCheck>, <xref:System.Windows.Forms.TreeView.BeforeSelect>, <xref:System.Windows.Forms.TreeView.BeforeLabelEdit>, <xref:System.Windows.Forms.TreeView.AfterSelect>, <xref:System.Windows.Forms.TreeView.AfterCheck>, and <xref:System.Windows.Forms.TreeView.AfterLabelEdit> events, which may be of interest to you if you want to use validation with the <xref:System.Windows.Forms.TreeView> control.  
  
    -   Left click: <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>  
  
    -   Right click: <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>  
  
    -   Left double-click: <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>; <xref:System.Windows.Forms.Control.DoubleClick>, <xref:System.Windows.Forms.Control.MouseDoubleClick>  
  
    -   Right double-click: <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>; <xref:System.Windows.Forms.Control.DoubleClick>, <xref:System.Windows.Forms.Control.MouseDoubleClick>  
  
### Painting Behavior of Toggle Controls  
 Toggle controls, such as the controls deriving from the <xref:System.Windows.Forms.ButtonBase> class, have the following distinctive painting behavior in combination with mouse click events:  
  
1.  The user presses the mouse button.  
  
2.  The control paints in the pressed state.  
  
3.  The <xref:System.Windows.Forms.Control.MouseDown> event is raised.  
  
4.  The user releases the mouse button.  
  
5.  The control paints in the raised state.  
  
6.  The <xref:System.Windows.Forms.Control.Click> event is raised.  
  
7.  The <xref:System.Windows.Forms.Control.MouseClick> event is raised.  
  
8.  The <xref:System.Windows.Forms.Control.MouseUp> event is raised.  
  
    > [!NOTE]
    >  If the user moves the pointer out of the toggle control while the mouse button is down (such as moving the mouse off the <xref:System.Windows.Forms.Button> control while it is pressed), the toggle control will paint in the raised state and only the <xref:System.Windows.Forms.Control.MouseUp> event occurs. The <xref:System.Windows.Forms.Control.Click> or <xref:System.Windows.Forms.Control.MouseClick> events will not occur in this situation.  
  
## See Also  
 [Mouse Input in a Windows Forms Application](../../../docs/framework/winforms/mouse-input-in-a-windows-forms-application.md)

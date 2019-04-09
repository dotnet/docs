---
title: "Events in Windows Forms Controls"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "events [Windows Forms], custom controls (using code)"
  - "custom controls [Windows Forms], events overview (using code)"
ms.assetid: 7e3d1379-87aa-437c-afce-c99454eff30e
---
# Events in Windows Forms Controls
A Windows Forms control inherits more than sixty events from <xref:System.Windows.Forms.Control?displayProperty=nameWithType>. These include the <xref:System.Windows.Forms.Control.Paint> event, which causes a control to be drawn, events related to displaying a window, such as the <xref:System.Windows.Forms.Control.Resize> and <xref:System.Windows.Forms.Control.Layout> events, and low-level mouse and keyboard events. Some low-level events are synthesized by <xref:System.Windows.Forms.Control> into semantic events such as <xref:System.Windows.Forms.Control.Click> and <xref:System.Windows.Forms.Control.DoubleClick>. For details about inherited events, see <xref:System.Windows.Forms.Control>.  
  
 If your custom control needs to override inherited event functionality, override the inherited `On`*EventName* method instead of attaching a delegate. If you are not familiar with the event model in the .NET Framework, see [Raising Events from a Component](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2013/sh2e3k5z(v=vs.120)).  
  
## See also

- [Overriding the OnPaint Method](overriding-the-onpaint-method.md)
- [Handling User Input](handling-user-input.md)
- [Defining an Event](defining-an-event-in-windows-forms-controls.md)
- [Events](../../../standard/events/index.md)

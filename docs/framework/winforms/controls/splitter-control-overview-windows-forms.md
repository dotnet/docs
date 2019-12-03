---
title: "Splitter Control Overview (Windows Forms)"
ms.date: "03/30/2017"
f1_keywords: 
  - "Splitter"
helpviewer_keywords: 
  - "Splitter control [Windows Forms], about Splitter control"
ms.assetid: e2b6ab83-dfdd-40ec-9762-850702c82dcb
---
# Splitter Control Overview (Windows Forms)
> [!IMPORTANT]
> Although <xref:System.Windows.Forms.SplitContainer> replaces and adds functionality to the <xref:System.Windows.Forms.Splitter> control of previous versions, <xref:System.Windows.Forms.Splitter> is retained for both backward compatibility and future use if you choose.  
  
 Windows Forms <xref:System.Windows.Forms.Splitter> controls are used to resize docked controls at run time. The <xref:System.Windows.Forms.Splitter> control is often used on forms with controls that have varying lengths of data to present, like Windows Explorer, whose data panes contain information of varying widths at different times.  
  
## Working with the Splitter Control  
 When the user points the mouse pointer at the undocked edge of a control that can be resized by a splitter control, the pointer changes its appearance to indicate that the control can be resized. With the splitter control, the user can resize the docked control that is immediately before it. Therefore, to enable the user to resize a docked control at run time, dock the control to be resized to an edge of a container, and then dock a splitter control to the same side of that container.  
  
## See also

- <xref:System.Windows.Forms.SplitContainer>
- [How to: Dock Controls on Windows Forms](how-to-dock-controls-on-windows-forms.md)
- [Controls to Use on Windows Forms](controls-to-use-on-windows-forms.md)

---
title: "How to: Add Buttons to a ToolBar Control Using the Designer"
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
  - "toolbars [Windows Forms], adding buttons"
  - "ToolBar control [Windows Forms], adding buttons"
  - "ToolBar control [Windows Forms], adding separators"
  - "examples [Windows Forms], toolbars"
  - "ToolBar control [Windows Forms], adding drop-down menus"
ms.assetid: d9ce3040-3e21-4e2d-80ae-b430982b2db8
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Add Buttons to a ToolBar Control Using the Designer
> [!NOTE]
>  The <xref:System.Windows.Forms.ToolStrip> control replaces and adds functionality to the <xref:System.Windows.Forms.ToolBar> control; however, the <xref:System.Windows.Forms.ToolBar> control is retained for both backward compatibility and future use, if you choose.  
  
 An integral part of the <xref:System.Windows.Forms.ToolBar> control is the buttons you add to it. These can be used to provide easy access to menu commands or, alternately, they can be placed in another area of the user interface of your application to expose commands to your users that are not available in the menu structure.  
  
 The following procedure requires a **Windows Application** project with a form containing a <xref:System.Windows.Forms.ToolBar> control. For information about setting up such a project, see [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa) and [How to: Add Controls to Windows Forms](../../../../docs/framework/winforms/controls/how-to-add-controls-to-windows-forms.md).  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To add buttons at design time  
  
1.  Select the <xref:System.Windows.Forms.ToolBar> control.  
  
2.  In the **Properties** window, click the <xref:System.Windows.Forms.ToolBar.Buttons%2A> property to select it and click the **Ellipsis** (![VisualStudioEllipsesButton screenshot](../../../../docs/framework/winforms/media/vbellipsesbutton.png "vbEllipsesButton")) button to open the **ToolBarButton Collection Editor**.  
  
3.  Use the **Add** and **Remove** buttons to add and remove buttons from the <xref:System.Windows.Forms.ToolBar> control.  
  
4.  Configure the properties of the individual buttons in the **Properties** window that appears in the pane on the right side of the editor. The following table shows some important properties to consider.  
  
    |Property|Description|  
    |--------------|-----------------|  
    |<xref:System.Windows.Forms.ToolBarButton.DropDownMenu%2A>|Sets the menu to be displayed in the drop-down toolbar button. The toolbar button's <xref:System.Windows.Forms.ToolBarButton.Style%2A> property must be set to <xref:System.Windows.Forms.ToolBarButtonStyle.DropDownButton>. This property takes an instance of the <xref:System.Windows.Forms.ContextMenu> class as a reference.|  
    |<xref:System.Windows.Forms.ToolBarButton.PartialPush%2A>|Sets whether a toggle-style toolbar button is partially pushed. The toolbar button's <xref:System.Windows.Forms.ToolBarButton.Style%2A> property must be set to <xref:System.Windows.Forms.ToolBarButtonStyle.ToggleButton>.|  
    |<xref:System.Windows.Forms.ToolBarButton.Pushed%2A>|Sets whether a toggle-style toolbar button is currently in the pushed state. The toolbar button's <xref:System.Windows.Forms.ToolBarButton.Style%2A> property must be set to <xref:System.Windows.Forms.ToolBarButtonStyle.ToggleButton> or <xref:System.Windows.Forms.ToolBarButtonStyle.PushButton>.|  
    |<xref:System.Windows.Forms.ToolBarButton.Style%2A>|Sets the style of the toolbar button. Must be one of the values in the <xref:System.Windows.Forms.ToolBarButtonStyle> enumeration.|  
    |<xref:System.Windows.Forms.ToolBarButton.Text%2A>|The text string displayed by the button.|  
    |<xref:System.Windows.Forms.ToolBarButton.ToolTipText%2A>|The text that appears as a ToolTip for the button.|  
  
5.  Click **OK** to close the dialog box and create the panels you specified.  
  
## See Also  
 <xref:System.Windows.Forms.ToolBar>  
 [How to: Define an Icon for a ToolBar Button](../../../../docs/framework/winforms/controls/how-to-define-an-icon-for-a-toolbar-button.md)  
 [How to: Trigger Menu Events for Toolbar Buttons](../../../../docs/framework/winforms/controls/how-to-trigger-menu-events-for-toolbar-buttons.md)  
 [ToolBar Control Overview](../../../../docs/framework/winforms/controls/toolbar-control-overview-windows-forms.md)  
 [ToolBar Control](../../../../docs/framework/winforms/controls/toolbar-control-windows-forms.md)

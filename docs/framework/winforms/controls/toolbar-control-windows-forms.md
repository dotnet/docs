---
title: "ToolBar Control (Windows Forms)"
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
  - "toolbars [Windows Forms]"
  - "ToolBar control [Windows Forms]"
ms.assetid: 6b40e9ce-6a7a-4784-bfc9-7f1d36b7462e
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# ToolBar Control (Windows Forms)
> [!NOTE]
>  The <xref:System.Windows.Forms.ToolStrip> control replaces and adds functionality to the `ToolBar` control; however, the `ToolBar` control is retained for both backward compatibility and future use, if you choose.  
  
 The Windows Forms `ToolBar` control is used on forms as a control bar that displays a row of drop-down menus and bitmapped buttons that activate commands. Thus, clicking a toolbar button is equivalent to choosing a menu command. The buttons can be configured to appear and behave as push buttons, drop-down menus, or separators. Typically, a toolbar contains buttons and menus that correspond to items in an application's menu structure, providing quick access to an application's most frequently used functions and commands.  
  
> [!NOTE]
>  The `ToolBar` control's <xref:System.Windows.Forms.ToolBarButton.DropDownMenu%2A> property takes an instance of the <xref:System.Windows.Forms.ContextMenu> class as a reference. Carefully consider the reference you pass when implementing this sort of button on toolbars in your application, as the property will accept any object that inherits from the <xref:System.Windows.Forms.Menu> class.  
  
## In This Section  
 [ToolBar Control Overview](../../../../docs/framework/winforms/controls/toolbar-control-overview-windows-forms.md)  
 Introduces the general concepts of the `ToolBar` control, which allows you to design custom toolbars that your users can work with.  
  
 [How to: Add Buttons to a ToolBar Control](../../../../docs/framework/winforms/controls/how-to-add-buttons-to-a-toolbar-control.md)  
 Describes how to add buttons to a `ToolBar` control.  
  
 [How to: Define an Icon for a ToolBar Button](../../../../docs/framework/winforms/controls/how-to-define-an-icon-for-a-toolbar-button.md)  
 Describes how to display icons within a `ToolBar` control's buttons.  
  
 [How to: Trigger Menu Events for Toolbar Buttons](../../../../docs/framework/winforms/controls/how-to-trigger-menu-events-for-toolbar-buttons.md)  
 Gives directions on writing code to interpret which button the user clicks in a `ToolBar` control.  
  
 Also see [How to: Define an Icon for a ToolBar Button Using the Designer](http://msdn.microsoft.com/library/ms233659\(v=vs.110\)), [How to: Add Buttons to a ToolBar Control Using the Designer](http://msdn.microsoft.com/library/ms233650\(v=vs.110\)).  
  
## Reference  
 <xref:System.Windows.Forms.ToolBar> class  
 Provides reference information on the class and its members.  
  
## Related Sections  
 [Controls to Use on Windows Forms](../../../../docs/framework/winforms/controls/controls-to-use-on-windows-forms.md)  
 Provides a complete list of Windows Forms controls, with links to information on their use.  
  
 [ToolStrip Control](../../../../docs/framework/winforms/controls/toolstrip-control-windows-forms.md)  
 Describes toolbars that can host menus, controls, and user controls in Windows Forms applications.

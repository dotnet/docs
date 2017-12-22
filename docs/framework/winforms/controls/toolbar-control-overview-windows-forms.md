---
title: "ToolBar Control Overview (Windows Forms)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "ToolBar"
helpviewer_keywords: 
  - "toolbars [Windows Forms], about toolbars"
  - "ToolBar control [Windows Forms], about ToolBar controls"
ms.assetid: d426b203-0216-4dbe-b834-1641e50a9c29
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# ToolBar Control Overview (Windows Forms)
> [!NOTE]
>  The <xref:System.Windows.Forms.ToolStrip> control replaces and adds functionality to the <xref:System.Windows.Forms.ToolBar> control; however, the <xref:System.Windows.Forms.ToolBar> control is retained for both backward compatibility and future use, if you choose.  
  
 The Windows Forms <xref:System.Windows.Forms.ToolBar> control is used on forms as a control bar that displays a row of drop-down menus and bitmapped buttons that activate commands. Thus, clicking a toolbar button can be an equivalent to choosing a menu command. The buttons can be configured to appear and behave as pushbuttons, drop-down menus, or separators. Typically, a toolbar contains buttons and menus that correspond to items in an application's menu structure, providing quick access to an application's most frequently used functions and commands.  
  
## Working with the ToolBar Control  
 A <xref:System.Windows.Forms.ToolBar> control is usually "docked" along the top of its parent window, but it can also be docked to any side of the window. A toolbar can display tooltips when the user points the mouse pointer at a toolbar button. A ToolTip is a small pop-up window that briefly describes the button or menu's purpose. To display ToolTips, the <xref:System.Windows.Forms.ToolBar.ShowToolTips%2A> property must be set to `true`.  
  
> [!NOTE]
>  Certain applications feature controls very similar to the toolbar that have the ability to "float" above the application window and be repositioned. The Windows Forms ToolBar control is not able to do these actions.  
  
 When the <xref:System.Windows.Forms.ToolBar.Appearance%2A> property is set to <xref:System.Windows.Forms.ToolBarAppearance>, the toolbar buttons appear raised and three-dimensional. You can set the <xref:System.Windows.Forms.ToolBar.Appearance%2A> property of the toolbar to <xref:System.Windows.Forms.ToolBarAppearance> to give the toolbar and its buttons a flat appearance. When the mouse pointer moves over a flat button, the button's appearance changes to three-dimensional. Toolbar buttons can be divided into logical groups by using separators. A separator is a toolbar button with the <xref:System.Windows.Forms.ToolBarButton.Style%2A> property set to <xref:System.Windows.Forms.ToolBarButtonStyle>. It appears as empty space on the toolbar. When the toolbar has a flat appearance, button separators appear as lines rather than spaces between the buttons.  
  
 The <xref:System.Windows.Forms.ToolBar> control allows you to create toolbars by adding <xref:System.Windows.Forms.Button> objects to a <xref:System.Windows.Forms.ToolBar.Buttons%2A> collection. You can use the Collection Editor to add buttons to a <xref:System.Windows.Forms.ToolBar> control; each <xref:System.Windows.Forms.Button> object should have text or an image assigned, although you can assign both. The image is supplied by an associated [ImageList](../../../../docs/framework/winforms/controls/imagelist-component-windows-forms.md) component. At run time, you can add or remove buttons from the <xref:System.Windows.Forms.ToolBar.ToolBarButtonCollection> using the <xref:System.Windows.Forms.ToolBar.ToolBarButtonCollection.Add%2A> and <xref:System.Windows.Forms.ToolBar.ToolBarButtonCollection.Remove%2A> methods. To program the buttons of a <xref:System.Windows.Forms.ToolBar>, add code to the <xref:System.Windows.Forms.ToolBar.ButtonClick> events of the <xref:System.Windows.Forms.ToolBar>, using the <xref:System.Windows.Forms.ToolBarButtonClickEventArgs.Button%2A> property of the <xref:System.Windows.Forms.ToolBarButtonClickEventArgs> class to determine which button was clicked.  
  
## See Also  
 <xref:System.Windows.Forms.ToolBar>  
 [ToolBar Control](../../../../docs/framework/winforms/controls/toolbar-control-windows-forms.md)  
 [How to: Add Buttons to a ToolBar Control](../../../../docs/framework/winforms/controls/how-to-add-buttons-to-a-toolbar-control.md)  
 [How to: Define an Icon for a ToolBar Button](../../../../docs/framework/winforms/controls/how-to-define-an-icon-for-a-toolbar-button.md)  
 [How to: Trigger Menu Events for Toolbar Buttons](../../../../docs/framework/winforms/controls/how-to-trigger-menu-events-for-toolbar-buttons.md)

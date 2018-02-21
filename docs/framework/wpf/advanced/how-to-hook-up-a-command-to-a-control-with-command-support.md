---
title: "How to: Hook Up a Command to a Control with Command Support"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Control class [WPF], attaching a RoutedCommand"
  - "classes [WPF], Control [WPF], attaching a RoutedCommand"
  - "RoutedCommand class [WPF], attaching to a Control"
  - "classes [WPF], RoutedCommand [WPF], attaching to a Control"
ms.assetid: 8d8592ae-0c91-469e-a1cd-d179c4544548
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Hook Up a Command to a Control with Command Support
The following example shows how to hook up a <xref:System.Windows.Input.RoutedCommand> to a <xref:System.Windows.Controls.Control> which has built in support for the command.  For a complete sample which hooks up commands to multiple sources, see the [Create a Custom RoutedCommand Sample](http://go.microsoft.com/fwlink/?LinkID=159980) sample.  
  
## Example  
 [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] provides a library of common commands which application programmers encounter regularly.  The classes which comprise the command library are: <xref:System.Windows.Input.ApplicationCommands>, <xref:System.Windows.Input.ComponentCommands>, <xref:System.Windows.Input.NavigationCommands>, <xref:System.Windows.Input.MediaCommands>, and <xref:System.Windows.Documents.EditingCommands>.  
  
 The static <xref:System.Windows.Input.RoutedCommand> objects which make up these classes do not supply command logic.  The logic for the command is associated with the command with a <xref:System.Windows.Input.CommandBinding>.  Some controls have built in CommandBindings for some commands.  This mechanism allows the semantics of a command to stay the same, while the actual implementation is can change.  A <xref:System.Windows.Controls.TextBox>, for example, handles the <xref:System.Windows.Input.ApplicationCommands.Paste%2A> command differently than a control designed to support images, but the basic idea of what it means to paste something stays the same.  The command logic cannot be supplied by the command, but rather must be supplied by the control or the application.  
  
 Many controls in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] do have built in support for some of the commands in the command library.  <xref:System.Windows.Controls.TextBox>, for example, supports many of the application edit commands such as <xref:System.Windows.Input.ApplicationCommands.Paste%2A>, <xref:System.Windows.Input.ApplicationCommands.Copy%2A>, <xref:System.Windows.Input.ApplicationCommands.Cut%2A>, <xref:System.Windows.Input.ApplicationCommands.Redo%2A>, and <xref:System.Windows.Input.ApplicationCommands.Undo%2A>.  The application developer does not have to do anything special to get these commands to work with these controls.  If the <xref:System.Windows.Controls.TextBox> is the command target when the command is executed, it will handle the command using the <xref:System.Windows.Input.CommandBinding> that is built into the control.  
  
 The following shows how to use a <xref:System.Windows.Controls.MenuItem> as the command source for the <xref:System.Windows.Input.ApplicationCommands.Paste%2A> command, where a <xref:System.Windows.Controls.TextBox> is the target of the command.  All the logic that defines how the <xref:System.Windows.Controls.TextBox> performs the paste is built into the <xref:System.Windows.Controls.TextBox> control.  
  
 A <xref:System.Windows.Controls.MenuItem> is created and it's <xref:System.Windows.Controls.MenuItem.Command%2A> property is set to the <xref:System.Windows.Input.ApplicationCommands.Paste%2A> command.  The <xref:System.Windows.Controls.MenuItem.CommandTarget%2A> is not explicitly set to the <xref:System.Windows.Controls.TextBox> object.  When the  <xref:System.Windows.Controls.MenuItem.CommandTarget%2A> is not set, the target for the command is the element which has keyboard focus.  If the element which has keyboard focus does not support the <xref:System.Windows.Input.ApplicationCommands.Paste%2A> command or cannot currently execute the paste command (the clipboard is empty, for example) then the <xref:System.Windows.Controls.MenuItem> would be grayed out.  
  
 [!code-xaml[MenuItemCommandTask_XAML#MenuItemCommanding](../../../../samples/snippets/csharp/VS_Snippets_Wpf/MenuItemCommandTask_XAML/CS/Window1.xaml#menuitemcommanding)]  
  
 [!code-csharp[MenuItemCommandTask#MenuItemCommandingCodeBehind](../../../../samples/snippets/csharp/VS_Snippets_Wpf/MenuItemCommandTask/CSharp/Window1.xaml.cs#menuitemcommandingcodebehind)]
 [!code-vb[MenuItemCommandTask#MenuItemCommandingCodeBehind](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/MenuItemCommandTask/VisualBasic/Window1.xaml.vb#menuitemcommandingcodebehind)]  
  
## See Also  
 [Commanding Overview](../../../../docs/framework/wpf/advanced/commanding-overview.md)  
 [Hook Up a Command to a Control with No Command Support](../../../../docs/framework/wpf/advanced/how-to-hook-up-a-command-to-a-control-with-no-command-support.md)

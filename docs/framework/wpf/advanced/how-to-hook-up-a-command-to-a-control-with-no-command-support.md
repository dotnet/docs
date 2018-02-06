---
title: "How to: Hook Up a Command to a Control with No Command Support"
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
ms.assetid: dad08f64-700b-46fb-ad3f-fbfee95f0dfe
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Hook Up a Command to a Control with No Command Support
The following example shows how to hook up a <xref:System.Windows.Input.RoutedCommand> to a <xref:System.Windows.Controls.Control> which does not have built in support for the command.  For a complete sample which hooks up commands to multiple sources, see the [Create a Custom RoutedCommand Sample](http://go.microsoft.com/fwlink/?LinkID=159980) sample.  
  
## Example  
 [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] provides a library of common commands which application programmers encounter regularly.  The classes which comprise the command library are: <xref:System.Windows.Input.ApplicationCommands>, <xref:System.Windows.Input.ComponentCommands>, <xref:System.Windows.Input.NavigationCommands>, <xref:System.Windows.Input.MediaCommands>, and <xref:System.Windows.Documents.EditingCommands>.  
  
 The static <xref:System.Windows.Input.RoutedCommand> objects which make up these classes do not supply command logic.  The logic for the command is associated with the command with a <xref:System.Windows.Input.CommandBinding>.  Many controls in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] have built in support for some of the commands in the command library.  <xref:System.Windows.Controls.TextBox>, for example, supports many of the application edit commands such as <xref:System.Windows.Input.ApplicationCommands.Paste%2A>, <xref:System.Windows.Input.ApplicationCommands.Copy%2A>, <xref:System.Windows.Input.ApplicationCommands.Cut%2A>, <xref:System.Windows.Input.ApplicationCommands.Redo%2A>, and <xref:System.Windows.Input.ApplicationCommands.Undo%2A>.  The application developer does not have to do anything special to get these commands to work with these controls.  If the <xref:System.Windows.Controls.TextBox> is the command target when the command is executed, it will handle the command using the <xref:System.Windows.Input.CommandBinding> that is built into the control.  
  
 The following shows how to use a <xref:System.Windows.Controls.Button> as the command source for the <xref:System.Windows.Input.ApplicationCommands.Open%2A> command.  A <xref:System.Windows.Input.CommandBinding> is created that associates the specified <xref:System.Windows.Input.CanExecuteRoutedEventHandler> and the <xref:System.Windows.Input.CanExecuteRoutedEventHandler> with the <xref:System.Windows.Input.RoutedCommand>.  
  
 First, the command source is created.  A <xref:System.Windows.Controls.Button> is used as the command source.  
  
 [!code-xaml[commandWithHandler#CommandHandlerCommandSource](../../../../samples/snippets/csharp/VS_Snippets_Wpf/commandWithHandler/CSharp/Window1.xaml#commandhandlercommandsource)]  
  
 [!code-csharp[CommandHandlerProcedural#CommandHandlerButtonCommandSource](../../../../samples/snippets/csharp/VS_Snippets_Wpf/CommandHandlerProcedural/CSharp/Window1.xaml.cs#commandhandlerbuttoncommandsource)]
 [!code-vb[CommandHandlerProcedural#CommandHandlerButtonCommandSource](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/CommandHandlerProcedural/visualbasic/window1.xaml.vb#commandhandlerbuttoncommandsource)]  
  
 Next, the <xref:System.Windows.Input.ExecutedRoutedEventHandler> and the <xref:System.Windows.Input.CanExecuteRoutedEventHandler> are created.  The <xref:System.Windows.Input.ExecutedRoutedEventHandler> simply opens a <xref:System.Windows.MessageBox> to signify that the command executed.  The <xref:System.Windows.Input.CanExecuteRoutedEventHandler> sets the <xref:System.Windows.Input.CanExecuteRoutedEventArgs.CanExecute%2A> property to `true`.  Normally, the can execute handler would perform more robust checks to see if the command could execute on the current command target.  
  
 [!code-csharp[commandWithHandler#CommandHandlerBothHandlers](../../../../samples/snippets/csharp/VS_Snippets_Wpf/commandWithHandler/CSharp/Window1.xaml.cs#commandhandlerbothhandlers)]
 [!code-vb[commandWithHandler#CommandHandlerBothHandlers](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/commandWithHandler/VisualBasic/Window1.xaml.vb#commandhandlerbothhandlers)]  
  
 Finally, a <xref:System.Windows.Input.CommandBinding> is created on the root <xref:System.Windows.Window> of the application that associates the routed events handlers to the <xref:System.Windows.Input.ApplicationCommands.Open%2A> command.  
  
 [!code-xaml[commandWithHandler#CommandHandlerCommandBinding](../../../../samples/snippets/csharp/VS_Snippets_Wpf/commandWithHandler/CSharp/Window1.xaml#commandhandlercommandbinding)]  
  
 [!code-csharp[CommandHandlerProcedural#CommandHandlerBindingInit](../../../../samples/snippets/csharp/VS_Snippets_Wpf/CommandHandlerProcedural/CSharp/Window1.xaml.cs#commandhandlerbindinginit)]
 [!code-vb[CommandHandlerProcedural#CommandHandlerBindingInit](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/CommandHandlerProcedural/visualbasic/window1.xaml.vb#commandhandlerbindinginit)]  
  
## See Also  
 [Commanding Overview](../../../../docs/framework/wpf/advanced/commanding-overview.md)  
 [Hook Up a Command to a Control with Command Support](../../../../docs/framework/wpf/advanced/how-to-hook-up-a-command-to-a-control-with-command-support.md)

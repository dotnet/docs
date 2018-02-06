---
title: "Commanding Overview"
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
  - "interfaces [WPF], ICommandSource"
  - "command library [WPF]"
  - "commands [WPF], definition of"
  - "CommandBindings [WPF]"
  - "ICommandSource interfaces [WPF]"
  - "commanding [WPF]"
  - "CommandManager [WPF]"
ms.assetid: bc208dfe-367d-426a-99de-52b7e7511e81
caps.latest.revision: 35
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Commanding Overview
<a name="introduction"></a> Commanding is an input mechanism in [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] which provides input handling at a more semantic level than device input. Examples of commands are the **Copy**, **Cut**, and **Paste** operations found on many applications.  
  
 This overview defines what commands are in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)], which classes are part of the commanding model, and how to use and create commands in your applications.  
  
 This topic contains the following sections:  
  
-   [What Are Commands?](#commands_at_10000_feet)  
  
-   [Simple Command Example in WPF](#simple_command)  
  
-   [Four Main Concepts in WPF Commanding](#Four_main_Concepts)  
  
-   [Command Library](#Command_Library)  
  
-   [Creating Custom Commands](#creating_commands)  
  
<a name="commands_at_10000_feet"></a>   
## What Are Commands?  
 Commands have several purposes. The first purpose is to separate the semantics and the object that invokes a command from the logic that executes the command. This allows for multiple and disparate sources to invoke the same command logic, and it allows the command logic to be customized for different targets. For example, the editing operations **Copy**, **Cut**, and **Paste**, which are found in many applications, can be invoked by using different user actions if they are implemented by using commands. An application might allow a user to cut selected objects or text by either clicking a button, choosing an item in a menu, or using a key combination, such as CTRL+X. By using commands, you can bind each type of user action to the same logic.  
  
 Another purpose of commands is to indicate whether an action is available. To continue the example of cutting an object or text, the action only makes sense when something is selected. If a user tries to cut an object or text without having anything selected, nothing would happen. To indicate this to the user, many applications disable buttons and menu items so that the user knows whether it is possible to perform an action. A command can indicate whether an action is possible by implementing the <xref:System.Windows.Input.ICommand.CanExecute%2A> method. A button can subscribe to the <xref:System.Windows.Input.ICommand.CanExecuteChanged> event and be disabled if <xref:System.Windows.Input.ICommand.CanExecute%2A> returns `false` or be enabled if <xref:System.Windows.Input.ICommand.CanExecute%2A> returns `true`.  
  
 The semantics of a command can be consistent across applications and classes, but the logic of the action is specific to the particular object acted upon. The key combination CTRL+X invokes the **Cut** command in text classes, image classes, and Web browsers, but the actual logic for performing the **Cut** operation is defined by the application that performs the cut. A <xref:System.Windows.Input.RoutedCommand> enables clients to implement the logic. A text object may cut the selected text into the clipboard, while an image object may cut the selected image. When an application handles the <xref:System.Windows.Input.CommandManager.Executed> event, it has access to the target of the command and can take appropriate action depending on the target's type.  
  
<a name="simple_command"></a>   
## Simple Command Example in WPF  
 The simplest way to use a command in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] is to use a predefined <xref:System.Windows.Input.RoutedCommand> from one of the command library classes; use a control that has native support for handling the command; and use a control that has native support for invoking a command.  The <xref:System.Windows.Input.ApplicationCommands.Paste%2A> command is one of the predefined commands in the <xref:System.Windows.Input.ApplicationCommands> class.  The <xref:System.Windows.Controls.TextBox> control has built in logic for handling the <xref:System.Windows.Input.ApplicationCommands.Paste%2A> command.  And the <xref:System.Windows.Controls.MenuItem> class has native support for invoking commands.  
  
 The following example shows how to set up a <xref:System.Windows.Controls.MenuItem> so that when it is clicked it will invoke the <xref:System.Windows.Input.ApplicationCommands.Paste%2A> command on a <xref:System.Windows.Controls.TextBox>, assuming the <xref:System.Windows.Controls.TextBox> has keyboard focus.  
  
 [!code-xaml[CommandingOverviewSnippets#CommandingOverviewSimpleCommand](../../../../samples/snippets/csharp/VS_Snippets_Wpf/CommandingOverviewSnippets/CSharp/Window1.xaml#commandingoverviewsimplecommand)]  
  
 [!code-csharp[CommandingOverviewSnippets#CommandingOverviewCommandTargetCodeBehind](../../../../samples/snippets/csharp/VS_Snippets_Wpf/CommandingOverviewSnippets/CSharp/Window1.xaml.cs#commandingoverviewcommandtargetcodebehind)]
 [!code-vb[CommandingOverviewSnippets#CommandingOverviewCommandTargetCodeBehind](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/CommandingOverviewSnippets/visualbasic/window1.xaml.vb#commandingoverviewcommandtargetcodebehind)]  
  
<a name="Four_main_Concepts"></a>   
## Four Main Concepts in WPF Commanding  
 The routed command model in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] can be broken up into four main concepts: the command, the command source, the command target, and the command binding:  
  
-   The *command* is the action to be executed.  
  
-   The *command source* is the object which invokes the command.  
  
-   The *command target* is the object that the command is being executed on.  
  
-   The *command binding* is the object which maps the command logic to the command.  
  
 In the previous example, the <xref:System.Windows.Input.ApplicationCommands.Paste%2A> command is the command, the <xref:System.Windows.Controls.MenuItem> is the command source, the <xref:System.Windows.Controls.TextBox> is the command target, and the command binding is supplied by the <xref:System.Windows.Controls.TextBox> control.  It is worth noting that it is not always the case that the <xref:System.Windows.Input.CommandBinding> is supplied by the control that is the command target class.  Quite often the <xref:System.Windows.Input.CommandBinding> must be created by the application developer, or the <xref:System.Windows.Input.CommandBinding> might be attached to an ancestor of the command target.  
  
<a name="Commands"></a>   
### Commands  
 Commands in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] are created by implementing the <xref:System.Windows.Input.ICommand> interface.  <xref:System.Windows.Input.ICommand> exposes two methods, <xref:System.Windows.Input.ICommand.Execute%2A>, and <xref:System.Windows.Input.ICommand.CanExecute%2A>, and an event, <xref:System.Windows.Input.ICommand.CanExecuteChanged>. <xref:System.Windows.Input.ICommand.Execute%2A> performs the actions that are associated with the command. <xref:System.Windows.Input.ICommand.CanExecute%2A> determines whether the command can execute on the current command target. <xref:System.Windows.Input.ICommand.CanExecuteChanged> is raised if the command manager that centralizes the commanding operations detects a change in the command source that might invalidate a command that has been raised but not yet executed by the command binding.  The [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] implementation of <xref:System.Windows.Input.ICommand> is the <xref:System.Windows.Input.RoutedCommand> class and is the focus of this overview.  
  
 The main sources of input in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] are the mouse, the keyboard, ink, and routed commands.  The more device-oriented inputs use a <xref:System.Windows.RoutedEvent> to notify objects in an application page that an input event has occurred.  A <xref:System.Windows.Input.RoutedCommand> is no different.  The <xref:System.Windows.Input.RoutedCommand.Execute%2A> and <xref:System.Windows.Input.RoutedCommand.CanExecute%2A> methods of a <xref:System.Windows.Input.RoutedCommand> do not contain the application logic for the command, but rather they raise routed events that tunnel and bubble through the element tree until they encounter an object with a <xref:System.Windows.Input.CommandBinding>.  The <xref:System.Windows.Input.CommandBinding> contains the handlers for these events and it is the handlers that perform the command.  For more information on event routing in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)], see [Routed Events Overview](../../../../docs/framework/wpf/advanced/routed-events-overview.md).  
  
 The <xref:System.Windows.Input.RoutedCommand.Execute%2A> method on a <xref:System.Windows.Input.RoutedCommand> raises the <xref:System.Windows.Input.CommandManager.PreviewExecuted> and the <xref:System.Windows.Input.CommandManager.Executed> events on the command target.  The <xref:System.Windows.Input.RoutedCommand.CanExecute%2A> method on a <xref:System.Windows.Input.RoutedCommand> raises the <xref:System.Windows.Input.CommandManager.CanExecute> and <xref:System.Windows.Input.CommandManager.PreviewCanExecute> events on the command target.  These events tunnel and bubble through the element tree until they encounter an object which has a <xref:System.Windows.Input.CommandBinding> for that particular command.  
  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] supplies a set of common routed commands spread across several classes: <xref:System.Windows.Input.MediaCommands>, <xref:System.Windows.Input.ApplicationCommands>, <xref:System.Windows.Input.NavigationCommands>, <xref:System.Windows.Input.ComponentCommands>, and <xref:System.Windows.Documents.EditingCommands>.  These classes consist only of the <xref:System.Windows.Input.RoutedCommand> objects and not the implementation logic of the command.  The implementation logic is the responsibility of the object on which the command is being executed on.  
  
<a name="Command_Sources"></a>   
### Command Sources  
 A command source is the object which invokes the command.  Examples of command sources are <xref:System.Windows.Controls.MenuItem>, <xref:System.Windows.Controls.Button>, and <xref:System.Windows.Input.KeyGesture>.  
  
 Command sources in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] generally implement the <xref:System.Windows.Input.ICommandSource> interface.  
  
 <xref:System.Windows.Input.ICommandSource> exposes three properties: <xref:System.Windows.Input.ICommandSource.Command%2A>, <xref:System.Windows.Input.ICommandSource.CommandTarget%2A>, and <xref:System.Windows.Input.ICommandSource.CommandParameter%2A>:  
  
-   <xref:System.Windows.Input.ICommandSource.Command%2A> is the command to execute when the command source is invoked.  
  
-   <xref:System.Windows.Input.ICommandSource.CommandTarget%2A> is the object on which to execute the command.  It is worth noting that in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] the <xref:System.Windows.Input.ICommandSource.CommandTarget%2A> property on <xref:System.Windows.Input.ICommandSource> is only applicable when the <xref:System.Windows.Input.ICommand> is a <xref:System.Windows.Input.RoutedCommand>.  If the <xref:System.Windows.Input.ICommandSource.CommandTarget%2A> is set on an <xref:System.Windows.Input.ICommandSource> and the corresponding command is not a <xref:System.Windows.Input.RoutedCommand>, the command target is ignored. If the <xref:System.Windows.Input.ICommandSource.CommandTarget%2A> is not set, the element with keyboard focus will be the command target.  
  
-   <xref:System.Windows.Input.ICommandSource.CommandParameter%2A> is a user-defined data type used to pass information to the handlers implementing the command.  
  
 The [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] classes that implement <xref:System.Windows.Input.ICommandSource> are <xref:System.Windows.Controls.Primitives.ButtonBase>, <xref:System.Windows.Controls.MenuItem>, <xref:System.Windows.Documents.Hyperlink>, and <xref:System.Windows.Input.InputBinding>.  <xref:System.Windows.Controls.Primitives.ButtonBase>, <xref:System.Windows.Controls.MenuItem>, and <xref:System.Windows.Documents.Hyperlink> invoke a command when they are clicked, and an <xref:System.Windows.Input.InputBinding> invokes a command when the <xref:System.Windows.Input.InputGesture> associated with it is performed.  
  
 The following example shows how to use a <xref:System.Windows.Controls.MenuItem> in a <xref:System.Windows.Controls.ContextMenu> as a command source for the <xref:System.Windows.Input.ApplicationCommands.Properties%2A> command.  
  
 [!code-xaml[CommandingOverviewSnippets#CommandingOverviewCmdSourceXAML](../../../../samples/snippets/csharp/VS_Snippets_Wpf/CommandingOverviewSnippets/CSharp/Window1.xaml#commandingoverviewcmdsourcexaml)]  
  
 [!code-csharp[CommandingOverviewSnippets#CommandingOverviewCmdSource](../../../../samples/snippets/csharp/VS_Snippets_Wpf/CommandingOverviewSnippets/CSharp/Window1.xaml.cs#commandingoverviewcmdsource)]
 [!code-vb[CommandingOverviewSnippets#CommandingOverviewCmdSource](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/CommandingOverviewSnippets/visualbasic/window1.xaml.vb#commandingoverviewcmdsource)]  
  
 Typically, a command source will listen to the <xref:System.Windows.Input.RoutedCommand.CanExecuteChanged> event.  This event informs the command source that the ability of the command to execute on the current command target may have changed.  The command source can query the current status of the <xref:System.Windows.Input.RoutedCommand> by using the <xref:System.Windows.Input.RoutedCommand.CanExecute%2A> method.  The command source can then disable itself if the command cannot execute.  An example of this is a <xref:System.Windows.Controls.MenuItem> graying itself out when a command cannot execute.  
  
 An <xref:System.Windows.Input.InputGesture> can be used as a command source.  Two types of input gestures in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] are the <xref:System.Windows.Input.KeyGesture> and <xref:System.Windows.Input.MouseGesture>.  You can think of a <xref:System.Windows.Input.KeyGesture> as a keyboard shortcut, such as CTRL+C.  A <xref:System.Windows.Input.KeyGesture> is comprised of a <xref:System.Windows.Input.Key> and a set of <xref:System.Windows.Input.ModifierKeys>.  A <xref:System.Windows.Input.MouseGesture> is comprised of a <xref:System.Windows.Input.MouseAction> and an optional set of <xref:System.Windows.Input.ModifierKeys>.  
  
 In order for an <xref:System.Windows.Input.InputGesture> to act as a command source, it must be associated with a command. There are a few ways to accomplish this.  One way is to use an <xref:System.Windows.Input.InputBinding>.  
  
 The following example shows how to create a <xref:System.Windows.Input.KeyBinding> between a <xref:System.Windows.Input.KeyGesture> and a <xref:System.Windows.Input.RoutedCommand>.  
  
 [!code-xaml[CommandingOverviewSnippets#CommandingOverviewXAMLKeyBinding](../../../../samples/snippets/csharp/VS_Snippets_Wpf/CommandingOverviewSnippets/CSharp/Window1.xaml#commandingoverviewxamlkeybinding)]  
  
 [!code-csharp[CommandingOverviewSnippets#CommandingOverviewKeyBinding](../../../../samples/snippets/csharp/VS_Snippets_Wpf/CommandingOverviewSnippets/CSharp/Window1.xaml.cs#commandingoverviewkeybinding)]
 [!code-vb[CommandingOverviewSnippets#CommandingOverviewKeyBinding](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/CommandingOverviewSnippets/visualbasic/window1.xaml.vb#commandingoverviewkeybinding)]  
  
 Another way to associate an <xref:System.Windows.Input.InputGesture> to a <xref:System.Windows.Input.RoutedCommand> is to add the <xref:System.Windows.Input.InputGesture> to the <xref:System.Windows.Input.InputGestureCollection> on the <xref:System.Windows.Input.RoutedCommand>.  
  
 The following example shows how to add a <xref:System.Windows.Input.KeyGesture> to the <xref:System.Windows.Input.InputGestureCollection> of a <xref:System.Windows.Input.RoutedCommand>.  
  
 [!code-csharp[CommandingOverviewSnippets#CommandingOverviewKeyGestureOnCmd](../../../../samples/snippets/csharp/VS_Snippets_Wpf/CommandingOverviewSnippets/CSharp/Window1.xaml.cs#commandingoverviewkeygestureoncmd)]
 [!code-vb[CommandingOverviewSnippets#CommandingOverviewKeyGestureOnCmd](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/CommandingOverviewSnippets/visualbasic/window1.xaml.vb#commandingoverviewkeygestureoncmd)]  
  
<a name="Command_Binding"></a>   
### CommandBinding  
 A <xref:System.Windows.Input.CommandBinding> associates a command with the event handlers that implement the command.  
  
 The <xref:System.Windows.Input.CommandBinding> class contains a <xref:System.Windows.Input.CommandBinding.Command%2A> property, and <xref:System.Windows.Input.CommandBinding.PreviewExecuted>, <xref:System.Windows.Input.CommandBinding.Executed>, <xref:System.Windows.Input.CommandBinding.PreviewCanExecute>, and <xref:System.Windows.Input.CommandBinding.CanExecute> events.  
  
 <xref:System.Windows.Input.CommandBinding.Command%2A> is the command that the <xref:System.Windows.Input.CommandBinding> is being associated with.  The event handlers which are attached to the <xref:System.Windows.Input.CommandBinding.PreviewExecuted> and <xref:System.Windows.Input.CommandBinding.Executed> events implement the command logic.  The event handlers attached to the <xref:System.Windows.Input.CommandBinding.PreviewCanExecute> and <xref:System.Windows.Input.CommandBinding.CanExecute> events determine if the command can execute on the current command target.  
  
 The following example shows how to create a <xref:System.Windows.Input.CommandBinding> on the root <xref:System.Windows.Window> of an application.  The <xref:System.Windows.Input.CommandBinding> associates the <xref:System.Windows.Input.ApplicationCommands.Open%2A> command with <xref:System.Windows.Input.CommandManager.Executed> and <xref:System.Windows.Input.CommandBinding.CanExecute> handlers.  
  
 [!code-xaml[commandwithhandler#CommandHandlerCommandBinding](../../../../samples/snippets/csharp/VS_Snippets_Wpf/commandWithHandler/CSharp/Window1.xaml#commandhandlercommandbinding)]  
  
 [!code-csharp[CommandHandlerProcedural#CommandHandlerBindingInit](../../../../samples/snippets/csharp/VS_Snippets_Wpf/CommandHandlerProcedural/CSharp/Window1.xaml.cs#commandhandlerbindinginit)]
 [!code-vb[CommandHandlerProcedural#CommandHandlerBindingInit](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/CommandHandlerProcedural/visualbasic/window1.xaml.vb#commandhandlerbindinginit)]  
  
 Next, the <xref:System.Windows.Input.ExecutedRoutedEventHandler> and a <xref:System.Windows.Input.CanExecuteRoutedEventHandler> are created.  The <xref:System.Windows.Input.ExecutedRoutedEventHandler> opens a <xref:System.Windows.MessageBox> that displays a string saying the command has been executed.  The <xref:System.Windows.Input.CanExecuteRoutedEventHandler> sets the <xref:System.Windows.Input.CanExecuteRoutedEventArgs.CanExecute%2A> property to `true`.  
  
 [!code-csharp[commandwithhandler#CommandHandlerExecutedHandler](../../../../samples/snippets/csharp/VS_Snippets_Wpf/commandWithHandler/CSharp/Window1.xaml.cs#commandhandlerexecutedhandler)]
 [!code-vb[commandwithhandler#CommandHandlerExecutedHandler](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/commandWithHandler/VisualBasic/Window1.xaml.vb#commandhandlerexecutedhandler)]  
  
 [!code-csharp[commandwithhandler#CommandHandlerCanExecuteHandler](../../../../samples/snippets/csharp/VS_Snippets_Wpf/commandWithHandler/CSharp/Window1.xaml.cs#commandhandlercanexecutehandler)]
 [!code-vb[commandwithhandler#CommandHandlerCanExecuteHandler](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/commandWithHandler/VisualBasic/Window1.xaml.vb#commandhandlercanexecutehandler)]  
  
 A <xref:System.Windows.Input.CommandBinding> is attached to a specific object, such as the root <xref:System.Windows.Window> of the application or a control.  The object that the <xref:System.Windows.Input.CommandBinding> is attached to defines the scope of the binding.  For example, a <xref:System.Windows.Input.CommandBinding> attached to an ancestor of the command target can be reached by the <xref:System.Windows.Input.CommandBinding.Executed> event, but a <xref:System.Windows.Input.CommandBinding> attached to a descendant of the command target cannot be reached.  This is a direct consequence of the way a <xref:System.Windows.RoutedEvent> tunnels and bubbles from the object that raises the event.  
  
 In some situations the <xref:System.Windows.Input.CommandBinding> is attached to the command target itself, such as with the <xref:System.Windows.Controls.TextBox> class and the <xref:System.Windows.Input.ApplicationCommands.Cut%2A>, <xref:System.Windows.Input.ApplicationCommands.Copy%2A>, and <xref:System.Windows.Input.ApplicationCommands.Paste%2A> commands. Quite often though, it is more convenient to attach the <xref:System.Windows.Input.CommandBinding> to an ancestor of the command target, such as the main <xref:System.Windows.Window> or the Application object, especially if the same <xref:System.Windows.Input.CommandBinding> can be used for multiple command targets.  These are design decisions you will want to consider when you are creating your commanding infrastructure.  
  
<a name="Commane_Target"></a>   
### Command Target  
 The command target is the element on which the command is executed.  With regards to a <xref:System.Windows.Input.RoutedCommand>, the command target is the element at which routing of the <xref:System.Windows.Input.CommandManager.Executed> and <xref:System.Windows.Input.CommandManager.CanExecute> starts.  As noted previously, in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] the <xref:System.Windows.Input.ICommandSource.CommandTarget%2A> property on <xref:System.Windows.Input.ICommandSource> is only applicable when the <xref:System.Windows.Input.ICommand> is a <xref:System.Windows.Input.RoutedCommand>.  If the <xref:System.Windows.Input.ICommandSource.CommandTarget%2A> is set on an <xref:System.Windows.Input.ICommandSource> and the corresponding command is not a <xref:System.Windows.Input.RoutedCommand>, the command target is ignored.  
  
 The command source can explicitly set the command target.  If the command target is not defined, the element with keyboard focus will be used as the command target.  One of the benefits of using the element with keyboard focus as the command target is that it allows the application developer to use the same command source to invoke a command on multiple targets without having to keep track of the command target.  For example, if a <xref:System.Windows.Controls.MenuItem> invokes the **Paste** command in an application that has a <xref:System.Windows.Controls.TextBox> control and a <xref:System.Windows.Controls.PasswordBox> control, the target can be either the <xref:System.Windows.Controls.TextBox> or <xref:System.Windows.Controls.PasswordBox> depending on which control has keyboard focus.  
  
 The following example shows how to explicitly set the command target in markup and in code behind.  
  
 [!code-xaml[CommandingOverviewSnippets#CommandingOverviewXAMLCommandTarget](../../../../samples/snippets/csharp/VS_Snippets_Wpf/CommandingOverviewSnippets/CSharp/Window1.xaml#commandingoverviewxamlcommandtarget)]  
  
 [!code-csharp[CommandingOverviewSnippets#CommandingOverviewCommandTargetCodeBehind](../../../../samples/snippets/csharp/VS_Snippets_Wpf/CommandingOverviewSnippets/CSharp/Window1.xaml.cs#commandingoverviewcommandtargetcodebehind)]
 [!code-vb[CommandingOverviewSnippets#CommandingOverviewCommandTargetCodeBehind](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/CommandingOverviewSnippets/visualbasic/window1.xaml.vb#commandingoverviewcommandtargetcodebehind)]  
  
<a name="Command_Manager"></a>   
### The CommandManager  
 The <xref:System.Windows.Input.CommandManager> serves a number of command related functions.  It provides a set of static methods for adding and removing <xref:System.Windows.Input.CommandManager.PreviewExecuted>, <xref:System.Windows.Input.CommandManager.Executed>, <xref:System.Windows.Input.CommandManager.PreviewCanExecute>, and <xref:System.Windows.Input.CommandManager.CanExecute> event handlers to and from a specific element.  It provides a means to register <xref:System.Windows.Input.CommandBinding> and <xref:System.Windows.Input.InputBinding> objects onto a specific class.  The <xref:System.Windows.Input.CommandManager> also provides a means, through the <xref:System.Windows.Input.CommandManager.RequerySuggested> event, to notify a command when it should raise the <xref:System.Windows.Input.ICommand.CanExecuteChanged> event.  
  
 The <xref:System.Windows.Input.CommandManager.InvalidateRequerySuggested%2A> method forces the <xref:System.Windows.Input.CommandManager> to raise the <xref:System.Windows.Input.CommandManager.RequerySuggested> event.  This is useful for conditions that should disable/enable a command but are not conditions that the <xref:System.Windows.Input.CommandManager> is aware of.  
  
<a name="Command_Library"></a>   
## Command Library  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] provides a set of predefined commands.  The command library consists of the following classes: <xref:System.Windows.Input.ApplicationCommands>, <xref:System.Windows.Input.NavigationCommands>, <xref:System.Windows.Input.MediaCommands>, <xref:System.Windows.Documents.EditingCommands>, and the <xref:System.Windows.Input.ComponentCommands>.  These classes provide commands such as <xref:System.Windows.Input.ApplicationCommands.Cut%2A>, <xref:System.Windows.Input.NavigationCommands.BrowseBack%2A> and <xref:System.Windows.Input.NavigationCommands.BrowseForward%2A>, <xref:System.Windows.Input.MediaCommands.Play%2A>, <xref:System.Windows.Input.MediaCommands.Stop%2A>, and <xref:System.Windows.Input.MediaCommands.Pause%2A>.  
  
 Many of these commands include a set of default input bindings.  For example, if you specify that your application handles the copy command, you automatically get the keyboard binding "CTRL+C" You also get bindings for other input devices, such as [!INCLUDE[TLA2#tla_tpc](../../../../includes/tla2sharptla-tpc-md.md)] pen gestures and speech information.  
  
 When you reference commands in the various command libraries using [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], you can usually omit the class name of the library class that exposes the static command property. Generally, the command names are unambiguous as strings, and the owning types exist to provide a logical grouping of commands but are not necessary for disambiguation. For instance, you can specify `Command="Cut"` rather than the more verbose `Command="ApplicationCommands.Cut"`. This is a convenience mechanism that is built in to the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] processor for commands (more precisely, it is a type converter behavior of <xref:System.Windows.Input.ICommand>, which the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] processor references at load time).  
  
<a name="creating_commands"></a>   
## Creating Custom Commands  
 If the commands in the command library classes do not meet your needs, then you can create your own commands.  There are two ways to create a custom command.  The first is to start from the ground up and implement the <xref:System.Windows.Input.ICommand> interface.  The other way, and the more common approach, is to create a <xref:System.Windows.Input.RoutedCommand> or a <xref:System.Windows.Input.RoutedUICommand>.  
  
 For an example of creating a custom <xref:System.Windows.Input.RoutedCommand>, see [Create a Custom RoutedCommand Sample](http://go.microsoft.com/fwlink/?LinkID=159980).  
  
## See Also  
 <xref:System.Windows.Input.RoutedCommand>  
 <xref:System.Windows.Input.CommandBinding>  
 <xref:System.Windows.Input.InputBinding>  
 <xref:System.Windows.Input.CommandManager>  
 [Input Overview](../../../../docs/framework/wpf/advanced/input-overview.md)  
 [Routed Events Overview](../../../../docs/framework/wpf/advanced/routed-events-overview.md)  
 [Implement ICommandSource](../../../../docs/framework/wpf/advanced/how-to-implement-icommandsource.md)  
 [How to: Add a Command to a MenuItem](http://msdn.microsoft.com/library/013d68a0-5373-4a68-bd91-5de574307370)  
 [Create a Custom RoutedCommand Sample](http://go.microsoft.com/fwlink/?LinkID=159980)

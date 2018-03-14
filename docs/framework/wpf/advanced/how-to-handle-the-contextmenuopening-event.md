---
title: "How to: Handle the ContextMenuOpening Event"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "ContextMenuOpening properties [WPF]"
ms.assetid: 789652fb-1951-4217-934a-7843e355adf4
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Handle the ContextMenuOpening Event
The <xref:System.Windows.FrameworkElement.ContextMenuOpening> event can be handled in an application to either adjust an existing context menu prior to display or to suppress the menu that would otherwise be displayed by setting the <xref:System.Windows.RoutedEventArgs.Handled%2A> property to `true` in the event data. The typical reason for setting <xref:System.Windows.RoutedEventArgs.Handled%2A> to `true` in the event data is to replace the menu entirely with a new <xref:System.Windows.Controls.ContextMenu> object, which sometimes requires canceling the operation and starting a new open. If you write handlers for the <xref:System.Windows.FrameworkElement.ContextMenuOpening> event, you should be aware of timing issues between a <xref:System.Windows.Controls.ContextMenu> control and the service that is responsible for opening and positioning context menus for controls in general. This topic illustrates some of the code techniques for various context menu opening scenarios and illustrates a case where the timing issue comes into play.  
  
 There are several scenarios for handling the <xref:System.Windows.FrameworkElement.ContextMenuOpening> event:  
  
-   Adjusting the menu items before display.  
  
-   Replacing the entire menu before display.  
  
-   Completely suppressing any existing context menu and displaying no context menu.  
  
## Example  
  
## Adjusting the Menu Items Before Display  
 Adjusting the existing menu items is fairly simple and is probably the most common scenario. You might do this in order to add or subtract context menu options in response to current state information in your application or particular state information that is available as a property on the object where the context menu is requested.  
  
 The general technique is to get the source of the event, which is the specific control that was right-clicked, and get the <xref:System.Windows.FrameworkElement.ContextMenu%2A> property from it. You typically want to check the <xref:System.Windows.Controls.ItemsControl.Items%2A> collection to see what context menu items already exist in the menu, and then add or remove appropriate new <xref:System.Windows.Controls.MenuItem> items to or from the collection.  
  
 [!code-csharp[ContextMenuOpeningHandlers#AddItemNoHandle](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ContextMenuOpeningHandlers/CSharp/Pane1.xaml.cs#additemnohandle)]  
  
## Replacing the Entire Menu Before Display  
 An alternative scenario is if you want to replace the entire context menu. You could of course also use a variation of the preceding code, to remove every item of an existing context menu and add new ones starting with item zero. But the more intuitive approach for replacing all items in the context menu is to create a new <xref:System.Windows.Controls.ContextMenu>, populate it with items, and then set the <xref:System.Windows.FrameworkElement.ContextMenu%2A?displayProperty=nameWithType> property of a control to be the new <xref:System.Windows.Controls.ContextMenu>.  
  
 The following is the simple handler code for replacing a <xref:System.Windows.Controls.ContextMenu>. The code references a custom `BuildMenu` method, which is separated out because it is called by more than one of the example handlers.  
  
 [!code-csharp[ContextMenuOpeningHandlers#ReplaceNoReopen](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ContextMenuOpeningHandlers/CSharp/Pane1.xaml.cs#replacenoreopen)]  
  
 [!code-csharp[ContextMenuOpeningHandlers#BuildMenu](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ContextMenuOpeningHandlers/CSharp/Pane1.xaml.cs#buildmenu)]  
  
 However, if you use this style of handler for <xref:System.Windows.FrameworkElement.ContextMenuOpening>, you can potentially expose a timing issue if the object where you are setting the <xref:System.Windows.Controls.ContextMenu> does not have a preexisting context menu. When a user right-clicks a control, <xref:System.Windows.FrameworkElement.ContextMenuOpening> is raised even if the existing <xref:System.Windows.Controls.ContextMenu> is empty or null. But in this case, whatever new <xref:System.Windows.Controls.ContextMenu> you set on the source element arrives too late to be displayed. Also, if the user happens to right-click a second time, this time your new <xref:System.Windows.Controls.ContextMenu> appears, the value is non null, and your handler will properly replace and display the menu when the handler runs a second time. This suggests two possible workarounds:  
  
1.  Insure that <xref:System.Windows.FrameworkElement.ContextMenuOpening> handlers always run against controls that have at least a placeholder <xref:System.Windows.Controls.ContextMenu> available, which you intend to be replaced by the handler code. In this case, you can still use the handler shown in the previous example, but you typically want to assign a placeholder <xref:System.Windows.Controls.ContextMenu> in the initial markup:  
  
     [!code-xaml[ContextMenuOpeningHandlers#XAMLWithInitCM](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ContextMenuOpeningHandlers/CSharp/Pane1.xaml#xamlwithinitcm)]  
  
2.  Assume that the initial <xref:System.Windows.Controls.ContextMenu> value might be null, based on some preliminary logic. You could either check <xref:System.Windows.Controls.ContextMenu> for null, or use a flag in your code to check whether your handler has been run at least once. Because you assume that the <xref:System.Windows.Controls.ContextMenu> is about to be displayed, your handler then sets <xref:System.Windows.RoutedEventArgs.Handled%2A> to `true` in the event data. To the <xref:System.Windows.Controls.ContextMenuService> that is responsible for context menu display, a `true` value for <xref:System.Windows.RoutedEventArgs.Handled%2A> in the event data represents a request to cancel the display for the context menu / control combination that raised the event.  
  
 Now that you have suppressed the potentially suspect context menu, the next step is to supply a new one, then display it. Setting the new one is basically the same as the previous handler: you build a new <xref:System.Windows.Controls.ContextMenu> and set the control source's <xref:System.Windows.FrameworkElement.ContextMenu%2A?displayProperty=nameWithType> property with it. The additional step is that you must now force the display of the context menu, because you suppressed the first attempt. To force the display, you set the <xref:System.Windows.Controls.Primitives.Popup.IsOpen%2A?displayProperty=nameWithType> property to `true` within the handler. Be careful when you do this, because opening the context menu in the handler raises the <xref:System.Windows.FrameworkElement.ContextMenuOpening> event again. If you reenter your handler, it becomes infinitely recursive. This is why you always need to check for `null` or use a flag if you open a context menu from within a <xref:System.Windows.FrameworkElement.ContextMenuOpening> event handler.  
  
## Suppressing Any Existing Context Menu and Displaying No Context Menu  
 The final scenario, writing a handler that suppresses a menu totally, is uncommon. If a given control is not supposed to display a context menu, there are probably more appropriate ways to assure this than by suppressing the menu just when a user requests it. But if you want to use the handler to suppress a context menu and show nothing, then your handler should simply set <xref:System.Windows.RoutedEventArgs.Handled%2A> to `true` in the event data. The <xref:System.Windows.Controls.ContextMenuService> that is responsible for displaying a context menu will check the event data of the event it raised on the control. If the event was marked <xref:System.Windows.RoutedEventArgs.Handled%2A> anywhere along the route, then the context menu open action that initiated the event is suppressed.  
  
 [!code-csharp[ContextMenuOpeningHandlers#ReplaceReopen](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ContextMenuOpeningHandlers/CSharp/Pane1.xaml.cs#replacereopen)]  
  
## See Also  
 <xref:System.Windows.Controls.ContextMenu>  
 <xref:System.Windows.FrameworkElement.ContextMenu%2A?displayProperty=nameWithType>  
 [Base Elements Overview](../../../../docs/framework/wpf/advanced/base-elements-overview.md)  
 [ContextMenu Overview](../../../../docs/framework/wpf/controls/contextmenu-overview.md)

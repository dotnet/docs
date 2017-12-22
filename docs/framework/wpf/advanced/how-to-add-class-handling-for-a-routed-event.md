---
title: "How to: Add Class Handling for a Routed Event"
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
  - "routed events [WPF], class handlers"
  - "task_core_add_class_handling_routed_properties [WPF]"
  - "class handlers [WPF], routed events"
ms.assetid: 15b7b06c-9112-4ee5-b30a-65d10c5c5df6
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Add Class Handling for a Routed Event
Routed events can be handled either by class handlers or instance handlers on any given node in the route. Class handlers are invoked first, and can be used by class implementations to suppress events from instance handling or introduce other event specific behaviors on events that are owned by base classes. This example illustrates two closely related techniques for implementing class handlers.  
  
## Example  
 This example uses a custom class based on the <xref:System.Windows.Controls.Canvas> panel. The basic premise of the application is that the custom class introduces behaviors on its child elements, including intercepting any left mouse button clicks and marking them handled, before the child element class or any instance handlers on it will be invoked.  
  
 The <xref:System.Windows.UIElement> class exposes a virtual method that enables class handling on the <xref:System.Windows.UIElement.PreviewMouseLeftButtonDown> event, by simply overriding the event. This is the simplest way to implement class handling if such a virtual method is available somewhere in your class' hierarchy. The following code shows the <xref:System.Windows.UIElement.OnPreviewMouseLeftButtonDown%2A> implementation in the "MyEditContainer" that is derived from <xref:System.Windows.Controls.Canvas>. The implementation marks the event as handled in the arguments, and then adds some code to give the source element a basic visible change.  
  
 [!code-csharp[ClassHandling#OnStarClassHandler](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ClassHandling/CSharp/SDKSampleLibrary/class1.cs#onstarclasshandler)]
 [!code-vb[ClassHandling#OnStarClassHandler](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/ClassHandling/visualbasic/sdksamplelibrary/class1.vb#onstarclasshandler)]  
  
 If no virtual is available on base classes or for that particular method, class handling can be added directly using a utility method of the <xref:System.Windows.EventManager> class, <xref:System.Windows.EventManager.RegisterClassHandler%2A>. This method should only be called within the static initialization of classes that are adding class handling. This example adds another handler for <xref:System.Windows.UIElement.PreviewMouseLeftButtonDown> , and in this case the registered class is the custom class. In contrast, when using the virtuals, the registered class is really the <xref:System.Windows.UIElement> base class. In cases where base classes and subclass each register class handling, the subclass handlers are invoked first. The behavior in an application would be that first this handler would show its message box and then the visual change in the virtual method's handler would be shown.  
  
 [!code-csharp[ClassHandling#StaticAndRegisterClassHandler](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ClassHandling/CSharp/SDKSampleLibrary/class1.cs#staticandregisterclasshandler)]
 [!code-vb[ClassHandling#StaticAndRegisterClassHandler](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/ClassHandling/visualbasic/sdksamplelibrary/class1.vb#staticandregisterclasshandler)]  
  
## See Also  
 <xref:System.Windows.EventManager>  
 [Marking Routed Events as Handled, and Class Handling](../../../../docs/framework/wpf/advanced/marking-routed-events-as-handled-and-class-handling.md)  
 [Handle a Routed Event](../../../../docs/framework/wpf/advanced/how-to-handle-a-routed-event.md)  
 [Routed Events Overview](../../../../docs/framework/wpf/advanced/routed-events-overview.md)

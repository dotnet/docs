---
title: "Walkthrough: Creating Your First Touch Application"
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
  - "creating a touch-sensitive application [WPF]"
  - "touchscreen applications [WPF], creating"
  - "touch-sensitive applications [WPF], creating"
  - "creating a touchscreen application [WPF]"
ms.assetid: d69e602e-9a25-4e24-950b-e89eaa2a906b
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Creating Your First Touch Application
[!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] enables applications to respond to touch. For example, you can interact with an application by using one or more fingers on a touch-sensitive device, such as a touchscreen This walkthrough creates an application that enables the user to move, resize, or rotate a single object by using touch.  
  
## Prerequisites  
 You need the following components to complete this walkthrough:  
  
-   [!INCLUDE[vs_dev10_ext](../../../../includes/vs-dev10-ext-md.md)].  
  
-   Windows 7.  
  
-   A device that accepts touch input, such as a touchscreen, that supports Windows Touch.  
  
 Additionally, you should have a basic understanding of how to create an application in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)], especially how to subscribe to and handle an event. For more information, see [Walkthrough: My first WPF desktop application](../../../../docs/framework/wpf/getting-started/walkthrough-my-first-wpf-desktop-application.md).  
  
## Creating the Application  
  
#### To create the application  
  
1.  Create a new WPF Application project in Visual Basic or Visual C# named `BasicManipulation`. For more information, see [How to: Create a New WPF Application Project](http://msdn.microsoft.com/library/1f6aea7a-33e1-4d3f-8555-1daa42e95d82).  
  
2.  Replace the contents of MainWindow.xaml with the following XAML.  
  
     This markup creates a simple application that contains a red <xref:System.Windows.Shapes.Rectangle> on a <xref:System.Windows.Controls.Canvas>. The <xref:System.Windows.UIElement.IsManipulationEnabled%2A> property of the <xref:System.Windows.Shapes.Rectangle> is set to true so that it will receive manipulation events. The application subscribes to the <xref:System.Windows.UIElement.ManipulationStarting>, <xref:System.Windows.UIElement.ManipulationDelta>, and <xref:System.Windows.UIElement.ManipulationInertiaStarting> events. These events contain the logic to move the <xref:System.Windows.Shapes.Rectangle> when the user manipulates it.  
  
     [!code-xaml[BasicManipulation#UI](../../../../samples/snippets/csharp/VS_Snippets_Wpf/basicmanipulation/csharp/mainwindow.xaml#ui)]  
  
3.  If you are using Visual Basic, in the first line of MainWindow.xaml, replace `x:Class="BasicManipulation.MainWindow"` with `x:Class="MainWindow"`.  
  
4.  In the `MainWindow` class, add the following <xref:System.Windows.UIElement.ManipulationStarting> event handler.  
  
     The <xref:System.Windows.UIElement.ManipulationStarting> event occurs when [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] detects that touch input begins to manipulate an object. The code specifies that the position of the manipulation should be relative to the <xref:System.Windows.Window> by setting the <xref:System.Windows.Input.ManipulationStartingEventArgs.ManipulationContainer%2A> property.  
  
     [!code-csharp[BasicManipulation#ManipulationStarting](../../../../samples/snippets/csharp/VS_Snippets_Wpf/basicmanipulation/csharp/mainwindow.xaml.cs#manipulationstarting)]
     [!code-vb[BasicManipulation#ManipulationStarting](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/basicmanipulation/visualbasic/mainwindow.xaml.vb#manipulationstarting)]  
  
5.  In the `MainWindow` class, add the following <xref:System.Windows.Input.ManipulationDelta> event handler.  
  
     The <xref:System.Windows.Input.ManipulationDelta> event occurs when the touch input changes position and can occur multiple times during a manipulation. The event can also occur after a finger is raised. For example, if the user drags a finger across a screen, the <xref:System.Windows.Input.ManipulationDelta> event occurs multiple times as the finger moves. When the user raises a finger from the screen, the <xref:System.Windows.Input.ManipulationDelta> event keeps occurring to simulate inertia.  
  
     The code applies the <xref:System.Windows.Input.ManipulationDeltaEventArgs.DeltaManipulation%2A> to the <xref:System.Windows.UIElement.RenderTransform%2A> of the <xref:System.Windows.Shapes.Rectangle> to move it as the user moves the touch input. It also checks whether the <xref:System.Windows.Shapes.Rectangle> is outside the bounds of the <xref:System.Windows.Window> when the event occurs during inertia. If so, the application calls the <xref:System.Windows.Input.ManipulationDeltaEventArgs.Complete%2A?displayProperty=nameWithType> method to end the manipulation.  
  
     [!code-csharp[BasicManipulation#ManipulationDelta](../../../../samples/snippets/csharp/VS_Snippets_Wpf/basicmanipulation/csharp/mainwindow.xaml.cs#manipulationdelta)]
     [!code-vb[BasicManipulation#ManipulationDelta](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/basicmanipulation/visualbasic/mainwindow.xaml.vb#manipulationdelta)]  
  
6.  In the `MainWindow` class, add the following <xref:System.Windows.UIElement.ManipulationInertiaStarting> event handler.  
  
     The <xref:System.Windows.UIElement.ManipulationInertiaStarting> event occurs when the user raises all fingers from the screen. The code sets the initial velocity and deceleration for the movement, expansion, and rotation of the rectangle.  
  
     [!code-csharp[BasicManipulation#ManipulationInertiaStarting](../../../../samples/snippets/csharp/VS_Snippets_Wpf/basicmanipulation/csharp/mainwindow.xaml.cs#manipulationinertiastarting)]
     [!code-vb[BasicManipulation#ManipulationInertiaStarting](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/basicmanipulation/visualbasic/mainwindow.xaml.vb#manipulationinertiastarting)]  
  
7.  Build and run the project.  
  
     You should see a red square appear in the window.  
  
## Testing the Application  
 To test the application, try the following manipulations. Note that you can do more than one of the following at the same time.  
  
-   To move the <xref:System.Windows.Shapes.Rectangle>, put a finger on the <xref:System.Windows.Shapes.Rectangle> and move the finger across the screen.  
  
-   To resize the <xref:System.Windows.Shapes.Rectangle>, put two fingers on the <xref:System.Windows.Shapes.Rectangle> and move the fingers closer together or farther apart from each other.  
  
-   To rotate the <xref:System.Windows.Shapes.Rectangle>, put two fingers on the <xref:System.Windows.Shapes.Rectangle> and rotate the fingers around each other.  
  
 To cause inertia, quickly raise your fingers from the screen as you perform the previous manipulations. The <xref:System.Windows.Shapes.Rectangle> will continue to move, resize, or rotate for a few seconds before it stops.  
  
## See Also  
 <xref:System.Windows.UIElement.ManipulationStarting?displayProperty=nameWithType>  
 <xref:System.Windows.UIElement.ManipulationDelta?displayProperty=nameWithType>  
 <xref:System.Windows.UIElement.ManipulationInertiaStarting?displayProperty=nameWithType>

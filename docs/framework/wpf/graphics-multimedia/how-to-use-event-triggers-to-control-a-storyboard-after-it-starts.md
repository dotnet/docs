---
title: "How to: Use Event Triggers to Control a Storyboard After It Starts"
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
  - "triggers [WPF], controlling Storyboards"
  - "event triggers [WPF], controlling Storyboards"
  - "Storyboards [WPF], controlling after start"
ms.assetid: 3b115594-6a93-4972-b24d-61aa16f1c15f
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Use Event Triggers to Control a Storyboard After It Starts
This example shows how to control a <xref:System.Windows.Media.Animation.Storyboard> after it starts. To start a <xref:System.Windows.Media.Animation.Storyboard> by using [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], use <xref:System.Windows.Media.Animation.BeginStoryboard>, which distributes the animations to the objects and properties they animate and then starts the storyboard. If you give <xref:System.Windows.Media.Animation.BeginStoryboard> a name by specifying its <xref:System.Windows.Media.Animation.BeginStoryboard.Name%2A> property, you make it a controllable storyboard. You can then interactively control the storyboard after it starts.  
  
 Use the following storyboard actions together with <xref:System.Windows.EventTrigger> objects to control a storyboard.  
  
-   <xref:System.Windows.Media.Animation.PauseStoryboard>: Pauses the storyboard.  
  
-   <xref:System.Windows.Media.Animation.ResumeStoryboard>: Resumes a paused storyboard.  
  
-   <xref:System.Windows.Media.Animation.SetStoryboardSpeedRatio>: Changes the storyboard speed.  
  
-   <xref:System.Windows.Media.Animation.SkipStoryboardToFill>: Advances a storyboard to the end of its fill period, if it has one.  
  
-   <xref:System.Windows.Media.Animation.StopStoryboard>: Stops the storyboard.  
  
-   <xref:System.Windows.Media.Animation.RemoveStoryboard>: Removes the storyboard, freeing resources.  
  
## Example  
 The following example uses controllable storyboard actions to interactively control a storyboard.  
  
 **Note:** To see an example of controlling a storyboard by using code, see [Control a Storyboard After It Starts Using Its Interactive Methods](../../../../docs/framework/wpf/graphics-multimedia/how-to-control-a-storyboard-after-it-starts.md).  
  
 [!code-xaml[timingbehaviors_snip#ControlStoryboardExampleUsingWholePage](../../../../samples/snippets/csharp/VS_Snippets_Wpf/timingbehaviors_snip/CSharp/ControlStoryboardExample.xaml#controlstoryboardexampleusingwholepage)]  
  
 For additional examples, see the [Animation Example Gallery](http://go.microsoft.com/fwlink/?LinkID=159969).  
  
## See Also  
 <xref:System.Windows.Media.Animation.ResumeStoryboard>  
 <xref:System.Windows.Media.Animation.SetStoryboardSpeedRatio>  
 <xref:System.Windows.Media.Animation.SkipStoryboardToFill>  
 <xref:System.Windows.Media.Animation.PauseStoryboard>  
 <xref:System.Windows.Media.Animation.StopStoryboard>  
 <xref:System.Windows.Media.Animation.SeekStoryboard>  
 [Control a Storyboard After It Starts Using Its Interactive Methods](../../../../docs/framework/wpf/graphics-multimedia/how-to-control-a-storyboard-after-it-starts.md)  
 [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md)  
 [Storyboards Overview](../../../../docs/framework/wpf/graphics-multimedia/storyboards-overview.md)

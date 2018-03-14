---
title: "How to: Simplify Animations by Using Child Timelines"
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
  - "simplifying animations by child timelines [WPF]"
  - "animation [WPF], simplifying by child timelines"
  - "child timelines [WPF]"
ms.assetid: 8335d770-d13d-42bd-8dfa-63f92c0327e2
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Simplify Animations by Using Child Timelines
This example shows how to simplify animations by using child <xref:System.Windows.Media.Animation.ParallelTimeline> objects. A <xref:System.Windows.Media.Animation.Storyboard> is a type of <xref:System.Windows.Media.Animation.Timeline> that provides targeting information for the timelines it contains. Use a <xref:System.Windows.Media.Animation.Storyboard> to provide timeline targeting information, including object and property information.  
  
 To begin an animation, use one or more <xref:System.Windows.Media.Animation.ParallelTimeline> objects as nested child elements of a <xref:System.Windows.Media.Animation.Storyboard>. These <xref:System.Windows.Media.Animation.ParallelTimeline> objects can contain other animations and therefore, can better encapsulate the timing sequences in complex animations. For example, if you are animating a <xref:System.Windows.Controls.TextBlock> and several shapes in the same <xref:System.Windows.Media.Animation.Storyboard>, you can separate the animations for the <xref:System.Windows.Controls.TextBlock> and the shapes, putting each into a separate <xref:System.Windows.Media.Animation.ParallelTimeline>. Because each <xref:System.Windows.Media.Animation.ParallelTimeline> has its own <xref:System.Windows.Media.Animation.Timeline.BeginTime%2A> and all child elements of the <xref:System.Windows.Media.Animation.ParallelTimeline> begin relative to this <xref:System.Windows.Media.Animation.Timeline.BeginTime%2A>, timing is better encapsulated.  
  
 The following example animates two pieces of text (<xref:System.Windows.Controls.TextBlock> objects) from within the same <xref:System.Windows.Media.Animation.Storyboard>. A <xref:System.Windows.Media.Animation.ParallelTimeline> encapsulates the animations of one of the <xref:System.Windows.Controls.TextBlock> objects.  
  
 **Performance Note:** Although you can nest <xref:System.Windows.Media.Animation.Storyboard> timelines inside each other, <xref:System.Windows.Media.Animation.ParallelTimeline>s are more suitable for nesting because they require less overhead. (The <xref:System.Windows.Media.Animation.Storyboard> class inherits from the <xref:System.Windows.Media.Animation.ParallelTimeline> class.)  
  
## Example  
 [!code-xaml[Timelines_snip#ParallelTimelineWholePage](../../../../samples/snippets/csharp/VS_Snippets_Wpf/Timelines_snip/CS/ParallelTimelineExample.xaml#paralleltimelinewholepage)]  
  
## See Also  
 [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md)  
 [Specify HandoffBehavior Between Storyboard Animations](../../../../docs/framework/wpf/graphics-multimedia/how-to-specify-handoffbehavior-between-storyboard-animations.md)

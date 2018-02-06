---
title: "Timing Events Overview"
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
  - "timelines [WPF]"
  - "timing events [WPF]"
ms.assetid: 597e3280-0867-4359-a97b-5b2f4149e350
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Timing Events Overview
This topic describes how to use the five timing events available on <xref:System.Windows.Media.Animation.Timeline> and <xref:System.Windows.Media.Animation.Clock> objects.  
  
## Prerequisites  
 To understand this topic, you should understand how to create and use animations. To get started with animation, see the [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md).  
  
 There are multiple ways to animate properties in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)]:  
  
-   **Using storyboard objects** (markup and code): You can use <xref:System.Windows.Media.Animation.Storyboard> objects to arrange and distribute animations to one or more objects. For an example, see [Animate a Property by Using a Storyboard](../../../../docs/framework/wpf/graphics-multimedia/how-to-animate-a-property-by-using-a-storyboard.md).  
  
-   **Using local animations** (code only): You can apply <xref:System.Windows.Media.Animation.AnimationTimeline> objects directly to the properties they animate. For an example, see [Animate a Property Without Using a Storyboard](../../../../docs/framework/wpf/graphics-multimedia/how-to-animate-a-property-without-using-a-storyboard.md).  
  
-   **Using clocks** (code only): You can explicitly manage clock creation and distribute the animation clocks yourself.  For an example, see [Animate a Property by Using an AnimationClock](../../../../docs/framework/wpf/graphics-multimedia/how-to-animate-a-property-by-using-an-animationclock.md).  
  
 Because you can use them in markup and code, the examples in this overview use <xref:System.Windows.Media.Animation.Storyboard> objects. However, the concepts described can be applied to the other methods of animating properties.  
  
### What is a clock?  
 A timeline, by itself, doesn't actually do anything other than describe a segment of time. It's the timeline's <xref:System.Windows.Media.Animation.Clock> object that does the real work: it maintains timing-related run-time state for the timeline. In most cases, such as when using storyboards, a clock is created automatically for your timeline. You can also create a <xref:System.Windows.Media.Animation.Clock> explicitly by using the <xref:System.Windows.Media.Animation.Timeline.CreateClock%2A> method. For more information about <xref:System.Windows.Media.Animation.Clock> objects, see the [Animation and Timing System Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-and-timing-system-overview.md).  
  
## Why Use Events?  
 With the exception of one (seek aligned to last tick), all interactive timing operations are asynchronous. There is no way for you to know exactly when they will execute. That can be a problem when you have other code that's dependent upon your timing operation. Suppose that you wanted to stop a timeline that animated a rectangle. After the timeline stops, you change the color of the rectangle.  
  
 [!code-csharp[events_procedural#NeedForEventsFragment](../../../../samples/snippets/csharp/VS_Snippets_Wpf/events_procedural/CSharp/EventExample.cs#needforeventsfragment)]
 [!code-vb[events_procedural#NeedForEventsFragment](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/events_procedural/VisualBasic/EventExample.vb#needforeventsfragment)]  
  
 In the previous example, the second line of code might execute before the storyboard stops. That's because stopping is an asynchronous operation. Telling a timeline or clock to stop creates a "stop request" of sorts that isn't processed until the timing engine's next tick.  
  
 To execute commands after a timeline completes, use timing events. In the following example, an event handler is used to change the color of a rectangle after the storyboard stops playing.  
  
 [!code-csharp[events_procedural#RegisterForStoryboardCurrentStateInvalidatedEvent](../../../../samples/snippets/csharp/VS_Snippets_Wpf/events_procedural/CSharp/EventExample.cs#registerforstoryboardcurrentstateinvalidatedevent)]
 [!code-vb[events_procedural#RegisterForStoryboardCurrentStateInvalidatedEvent](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/events_procedural/VisualBasic/EventExample.vb#registerforstoryboardcurrentstateinvalidatedevent)]  
[!code-csharp[events_procedural#StoryboardCurrentStateInvalidatedEvent2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/events_procedural/CSharp/EventExample.cs#storyboardcurrentstateinvalidatedevent2)]
[!code-vb[events_procedural#StoryboardCurrentStateInvalidatedEvent2](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/events_procedural/VisualBasic/EventExample.vb#storyboardcurrentstateinvalidatedevent2)]  
  
 For a more complete example, see [Receive Notification When a Clock's State Changes](../../../../docs/framework/wpf/graphics-multimedia/how-to-receive-notification-when-clock-state-changes.md).  
  
## Public Events  
 The <xref:System.Windows.Media.Animation.Timeline> and <xref:System.Windows.Media.Animation.Clock> classes both provide five timing events. The following table lists these events and the conditions that trigger them.  
  
|Event|Triggering interactive operation|Other triggers|  
|-----------|--------------------------------------|--------------------|  
|**Completed**|Skip to fill|The clock completes.|  
|**CurrentGlobalSpeedInvalidated**|Pause, resume, seek, set speed ratio, skip to fill, stop|The clock reverses, accelerates, starts, or stops.|  
|**CurrentStateInvalidated**|Begin, skip to fill, stop|The clock starts, stops, or fills.|  
|**CurrentTimeInvalidated**|Begin, seek, skip to fill, stop|The clock progresses.|  
|**RemoveRequested**|Remove||  
  
## Ticking and Event Consolidation  
 When you animate objects in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)], it’s the timing engine that manages your animations. The timing engine tracks the progression of time and computes the state of each animation. It makes many such evaluation passes in a second. These evaluation passes are known as "ticks."  
  
 While ticks occur frequently, it's possible for a lot of things to happen between ticks. For example, a timeline might be stopped, started, and stopped again, in which case its current state will have changed three times. In theory, the event could be raised multiple times in a single tick; however, the timing engine consolidates events, so that each event can be raised at most once per tick.  
  
## Registering for Events  
 There are two ways to register for timing events: you can register with the timeline or with the clock created from the timeline. Registering for an event directly with a clock is fairly straightforward, although it can only be done from code. You can register for events with a timeline from markup or code. The next section describes how to register for clock events with a timeline.  
  
<a name="registeringforclockeventswithatimeline"></a>   
## Registering for Clock Events with a Timeline  
 Although a timeline's <xref:System.Windows.Media.Animation.Timeline.Completed>, <xref:System.Windows.Media.Animation.Timeline.CurrentGlobalSpeedInvalidated>, <xref:System.Windows.Media.Animation.Timeline.CurrentStateInvalidated>, <xref:System.Windows.Media.Animation.Timeline.CurrentTimeInvalidated>, and <xref:System.Windows.Media.Animation.Timeline.RemoveRequested> events appear to be associated with the timeline, registering for these events actually associates an event handler with the <xref:System.Windows.Media.Animation.Clock> created for the timeline.  
  
 When you register for the <xref:System.Windows.Media.Animation.Timeline.Completed> event on a timeline, for example, you're actually telling the system to register for the <xref:System.Windows.Media.Animation.Clock.Completed> event of each clock that is created for the timeline. In code, you must register for this event before the <xref:System.Windows.Media.Animation.Clock> is created for this timeline; otherwise, you won't receive notification. This happens automatically in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)]; the parser automatically registers for the event before the <xref:System.Windows.Media.Animation.Clock> is created.  
  
## See Also  
 [Animation and Timing System Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-and-timing-system-overview.md)  
 [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md)  
 [Timing Behaviors Overview](../../../../docs/framework/wpf/graphics-multimedia/timing-behaviors-overview.md)

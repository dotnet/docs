---
title: "Timing Behaviors Overview"
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
  - "timing behaviors [WPF]"
  - "behaviors [WPF], timing"
ms.assetid: 5b714d46-bd46-48b8-b467-b4be89ba3091
caps.latest.revision: 20
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Timing Behaviors Overview
This topic describes the timing behaviors of animations and other <xref:System.Windows.Media.Animation.Timeline> objects.  
  
<a name="prerequisites"></a>   
## Prerequisites  
 To understand this topic, you should be familiar with basic animation features. For more information, see the [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md).  
  
<a name="timelinetypes"></a>   
## Timeline Types  
 A <xref:System.Windows.Media.Animation.Timeline> represents a segment of time. It provides properties that enable you to specify the length of that segment, when it should start, how many times it will repeat, how fast time progresses in that segment, and more.  
  
 Classes that inherit from the timeline class provide additional functionality, such as animation and media playback. [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] provides the following <xref:System.Windows.Media.Animation.Timeline> types.  
  
|Timeline type|Description|  
|-------------------|-----------------|  
|<xref:System.Windows.Media.Animation.AnimationTimeline>|Abstract base class for <xref:System.Windows.Media.Animation.Timeline> objects that generate output values for animating properties.|  
|<xref:System.Windows.Media.MediaTimeline>|Generates output from a media file.|  
|<xref:System.Windows.Media.Animation.ParallelTimeline>|A type of <xref:System.Windows.Media.Animation.TimelineGroup> that groups and controls child <xref:System.Windows.Media.Animation.Timeline> objects.|  
|<xref:System.Windows.Media.Animation.Storyboard>|A type of <xref:System.Windows.Media.Animation.ParallelTimeline> that provides targeting information for the Timeline objects it contains.|  
|<xref:System.Windows.Media.Animation.Timeline>|Abstract base class that defines timing behaviors.|  
|<xref:System.Windows.Media.Animation.TimelineGroup>|Abstract class for <xref:System.Windows.Media.Animation.Timeline> objects that can contain other <xref:System.Windows.Media.Animation.Timeline> objects.|  
  
<a name="propertiesthatcontroltimelinelength"></a>   
## Properties that Control the Length of a Timeline  
 A <xref:System.Windows.Media.Animation.Timeline> represents a segment of time, and the length of a timeline can be described in different ways. The following table defines several terms for describing the length of a timeline.  
  
|Term|Description|Properties||||  
|----------|-----------------|----------------|-|-|-|  
|Simple duration|The length of time a timeline takes to make a single forward iteration.|<xref:System.Windows.Media.Animation.Timeline.Duration%2A>||||  
|One repetition|The length of time it takes for a timeline to play forward once and, if the <xref:System.Windows.Media.Animation.Timeline.AutoReverse%2A> property is true, play backwards once.|<xref:System.Windows.Media.Animation.Timeline.Duration%2A>, <xref:System.Windows.Media.Animation.Timeline.AutoReverse%2A>||||  
|Active period|The length of time it takes for a timeline to complete all the repetitions specified by its <xref:System.Windows.Media.Animation.RepeatBehavior> property.|<xref:System.Windows.Media.Animation.Timeline.Duration%2A>, <xref:System.Windows.Media.Animation.Timeline.AutoReverse%2A>, <xref:System.Windows.Media.Animation.RepeatBehavior>||||  
  
<a name="duration"></a>   
### The Duration Property  
 As previously mentioned, a timeline represents a segment of time. The length of that segment is determined by the timeline's <xref:System.Windows.Media.Animation.Timeline.Duration%2A>. When a timeline reaches the end of its duration, it stops playing. If the timeline has child timelines, they stop playing as well. In the case of an animation, the <xref:System.Windows.Media.Animation.Timeline.Duration%2A> specifies how long the animation takes to transition from its starting value to its ending value. A timeline's duration is sometimes called its *simple duration*, to distinguish between the duration of a single iteration and the total length of time the animation plays including repetitions. You can specify a duration using a finite time value or the special values <xref:System.Windows.Duration.Automatic%2A> or <xref:System.Windows.Duration.Forever%2A>. An animation's duration should resolve to a <xref:System.Windows.Duration.TimeSpan%2A> value, so it can transition between values.  
  
 The following example shows a <xref:System.Windows.Media.Animation.DoubleAnimation> with a <xref:System.Windows.Media.Animation.Timeline.Duration%2A> of five seconds.  
  
 [!code-xaml[animation_ovws_snippet#AnimationWith5SecondDurationInline](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws_snippet/CS/TimingBehaviorsExample1.xaml#animationwith5seconddurationinline)]  
  
 Container timelines, such as <xref:System.Windows.Media.Animation.Storyboard> and <xref:System.Windows.Media.Animation.ParallelTimeline>, have a default duration of <xref:System.Windows.Duration.Automatic%2A>, which means they automatically end when their last child stops playing. The following example shows a <xref:System.Windows.Media.Animation.Storyboard> whose <xref:System.Windows.Media.Animation.Timeline.Duration%2A> resolves to five seconds, the length of time it takes all its child <xref:System.Windows.Media.Animation.DoubleAnimation> objects to complete.  
  
 [!code-xaml[animation_ovws_snippet#ContainerTimelineExampleInline](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws_snippet/CS/TimingBehaviorsExample1.xaml#containertimelineexampleinline)]  
  
 By setting the <xref:System.Windows.Media.Animation.Timeline.Duration%2A> of a container timeline to a <xref:System.Windows.Duration.TimeSpan%2A> value, you can force to play longer or shorter than its child <xref:System.Windows.Media.Animation.Timeline> objects would play. If you set the <xref:System.Windows.Media.Animation.Timeline.Duration%2A> to a value that's smaller than the length of the container timeline's child <xref:System.Windows.Media.Animation.Timeline> objects, the child <xref:System.Windows.Media.Animation.Timeline> objects stop playing when the container timeline does. The following example sets the <xref:System.Windows.Media.Animation.Timeline.Duration%2A> of the <xref:System.Windows.Media.Animation.Storyboard> from the preceding examples to three seconds. As a result, the first <xref:System.Windows.Media.Animation.DoubleAnimation> stops progressing after three seconds, when it has animated the target rectangle's width to 60.  
  
 [!code-xaml[animation_ovws_snippet#ContainerTimelineWithShorterDurationExampleInline](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws_snippet/CS/TimingBehaviorsExample1.xaml#containertimelinewithshorterdurationexampleinline)]  
  
<a name="repeatinganimations"></a>   
### The RepeatBehavior Property  
 The <xref:System.Windows.Media.Animation.Timeline.RepeatBehavior%2A> property of a <xref:System.Windows.Media.Animation.Timeline> controls how many times it repeats its simple duration. Using the <xref:System.Windows.Media.Animation.Timeline.RepeatBehavior%2A> property, you can specify how many times the timeline plays (an iteration <xref:System.Windows.Media.Animation.RepeatBehavior.Count%2A>) or the total length of time it should play (a repeat <xref:System.Windows.Media.Animation.RepeatBehavior.Duration%2A>). In either case, the animation goes through as many beginning-to-end runs as necessary to fill the requested count or duration. By default, timelines have an iteration count of `1.0`, which means they play once and do not repeat at all.  
  
 The following example uses the <xref:System.Windows.Media.Animation.Timeline.RepeatBehavior%2A> property to make a <xref:System.Windows.Media.Animation.DoubleAnimation> play for twice its simple duration by specifying an iteration count.  
  
 [!code-xaml[animation_ovws_snippet#TBRepeatBehavior2xExampleInline](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws_snippet/CS/TimingBehaviorsExample1.xaml#tbrepeatbehavior2xexampleinline)]  
  
 The next example uses the <xref:System.Windows.Media.Animation.Timeline.RepeatBehavior%2A> property to make the <xref:System.Windows.Media.Animation.DoubleAnimation> play for half its simple duration.  
  
 [!code-xaml[animation_ovws_snippet#TBRepeatBehavior05xExampleInline](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws_snippet/CS/TimingBehaviorsExample1.xaml#tbrepeatbehavior05xexampleinline)]  
  
 If you set the <xref:System.Windows.Media.Animation.Timeline.RepeatBehavior%2A> property of a <xref:System.Windows.Media.Animation.Timeline> to <xref:System.Windows.Media.Animation.RepeatBehavior.Forever%2A>, the <xref:System.Windows.Media.Animation.Timeline> repeats until stopped interactively or by the timing system. The following example uses the <xref:System.Windows.Media.Animation.Timeline.RepeatBehavior%2A> property to make the <xref:System.Windows.Media.Animation.DoubleAnimation> play indefinitely.  
  
 [!code-xaml[animation_ovws_snippet#TBRepeatBehaviorForeverExampleInline](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws_snippet/CS/TimingBehaviorsExample1.xaml#tbrepeatbehaviorforeverexampleinline)]  
  
 For an additional example, see [Repeat an Animation](../../../../docs/framework/wpf/graphics-multimedia/how-to-repeat-an-animation.md).  
  
<a name="autoreverseproperty"></a>   
### The AutoReverse Property  
 The <xref:System.Windows.Media.Animation.Timeline.AutoReverse%2A> property specifies whether a <xref:System.Windows.Media.Animation.Timeline> will play backwards at the end of each forward iteration. The following example sets to the <xref:System.Windows.Media.Animation.Timeline.AutoReverse%2A> property of a <xref:System.Windows.Media.Animation.DoubleAnimation> to `true`; as a result, it animates from zero to 100, and then from 100 to zero. It plays for a total of 10 seconds.  
  
 [!code-xaml[animation_ovws_snippet#TBAutoReverseExampleInline](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws_snippet/CS/TimingBehaviorsExample1.xaml#tbautoreverseexampleinline)]  
  
 When you use a <xref:System.Windows.Media.Animation.RepeatBehavior.Count%2A> value to specify the <xref:System.Windows.Media.Animation.Timeline.RepeatBehavior%2A> of a <xref:System.Windows.Media.Animation.Timeline> and the <xref:System.Windows.Media.Animation.Timeline.AutoReverse%2A> property of that <xref:System.Windows.Media.Animation.Timeline> is `true`, a single repetition consists of one forward iteration followed by one backwards iteration.  The following example sets the <xref:System.Windows.Media.Animation.Timeline.RepeatBehavior%2A> of the <xref:System.Windows.Media.Animation.DoubleAnimation> from the preceding example to a <xref:System.Windows.Media.Animation.RepeatBehavior.Count%2A> of two. As a result, the <xref:System.Windows.Media.Animation.DoubleAnimation> plays for 20 seconds: forward for five seconds, backwards for five seconds, forward for 5 seconds again, and then backwards for five seconds.  
  
 [!code-xaml[animation_ovws_snippet#TBAutoReverseRepeatExampleInline](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws_snippet/CS/TimingBehaviorsExample1.xaml#tbautoreverserepeatexampleinline)]  
  
 If a container timeline has child <xref:System.Windows.Media.Animation.Timeline> objects, they reverse when the container timeline does. For additional examples, see [Specify Whether a Timeline Automatically Reverses](../../../../docs/framework/wpf/graphics-multimedia/how-to-specify-whether-a-timeline-automatically-reverses.md).  
  
<a name="timelinebegin"></a>   
## The BeginTime Property  
 The <xref:System.Windows.Media.Animation.Timeline.BeginTime%2A> property enables you to specify when a timeline starts.  A timeline's begin time is relative to its parent timeline. A begin time of zero seconds means the timeline starts as soon as it parent starts; any other value creates an offset between when the parent timeline starts playing and when the child timeline plays. For example, a begin time of two seconds means the timeline starts playing when its parent has reached a time of two seconds. By default, all timelines have a begin time of zero seconds. You may also set a timeline's begin time to `null`, which prevents the timeline from starting. In [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)], you specify null using the [x:Null Markup Extension](../../../../docs/framework/xaml-services/x-null-markup-extension.md).  
  
 Note that the begin time is not applied each time a timeline repeats because of its <xref:System.Windows.Media.Animation.Timeline.RepeatBehavior%2A> setting. If you were to create an animation with a <xref:System.Windows.Media.Animation.Timeline.BeginTime%2A> of 10 seconds and a <xref:System.Windows.Media.Animation.RepeatBehavior> of <xref:System.Windows.Media.Animation.RepeatBehavior.Forever%2A>, there would be a 10-second delay before the animation played for the first time, but not for each successive repetition. However, if the animation's parent timeline were to restart or repeat, the 10-second delay would occur.  
  
 The <xref:System.Windows.Media.Animation.Timeline.BeginTime%2A> property is useful for staggering timelines. The following example creates a <xref:System.Windows.Media.Animation.Storyboard> that has two child <xref:System.Windows.Media.Animation.DoubleAnimation> objects. The first animation has a <xref:System.Windows.Media.Animation.Timeline.Duration%2A> of five seconds, and the second has a <xref:System.Windows.Media.Animation.Timeline.Duration%2A> of 3 seconds. The example sets the <xref:System.Windows.Media.Animation.Timeline.BeginTime%2A> of the second <xref:System.Windows.Media.Animation.DoubleAnimation> to 5 seconds, so that it begins playing after the first <xref:System.Windows.Media.Animation.DoubleAnimation> ends.  
  
 [!code-xaml[animation_ovws_snippet#TBBeginTimeExampleInline](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws_snippet/CS/TimingBehaviorsExample1.xaml#tbbegintimeexampleinline)]  
  
<a name="fillbehaviorproperty"></a>   
## The FillBehavior Property  
 When a <xref:System.Windows.Media.Animation.Timeline> reaches the end of its total active duration, the <xref:System.Windows.Media.Animation.Timeline.FillBehavior%2A> property specifies whether it stops or holds its last value. An animation with a <xref:System.Windows.Media.Animation.Timeline.FillBehavior%2A> of <xref:System.Windows.Media.Animation.FillBehavior.HoldEnd> "holds" its output value: the property being animated retains the last value of the animation. A value of <xref:System.Windows.Media.Animation.FillBehavior.Stop> causes that the animation stop affecting its target property after it ends.  
  
 The following example creates a <xref:System.Windows.Media.Animation.Storyboard> that has two child <xref:System.Windows.Media.Animation.DoubleAnimation> objects. Both <xref:System.Windows.Media.Animation.DoubleAnimation> objects animate the <xref:System.Windows.FrameworkElement.Width%2A> of a <xref:System.Windows.Shapes.Rectangle> from 0 to 100. The <xref:System.Windows.Shapes.Rectangle> elements have non-animated <xref:System.Windows.FrameworkElement.Width%2A> values of 500 [device independent pixels].  
  
-   The <xref:System.Windows.Media.Animation.Timeline.FillBehavior%2A> property of the first <xref:System.Windows.Media.Animation.DoubleAnimation> is set to <xref:System.Windows.Media.Animation.FillBehavior.HoldEnd>, the default value. As a result, the Width of the Rectangle stays at 100 after the <xref:System.Windows.Media.Animation.DoubleAnimation> ends.  
  
-   The <xref:System.Windows.Media.Animation.Timeline.FillBehavior%2A> property of the second <xref:System.Windows.Media.Animation.DoubleAnimation> is set to <xref:System.Windows.Media.Animation.FillBehavior.Stop>. As a result, the <xref:System.Windows.FrameworkElement.Width%2A> of the second <xref:System.Windows.Shapes.Rectangle> reverts to 500 after the <xref:System.Windows.Media.Animation.DoubleAnimation> ends.  
  
 [!code-xaml[animation_ovws_snippet#TBFillBehaviorExample](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws_snippet/CS/TimingBehaviorsExample1.xaml#tbfillbehaviorexample)]  
  
<a name="speedproperties"></a>   
## Properties that Control the Speed of a Timeline  
 The <xref:System.Windows.Media.Animation.Timeline> class provides three properties for specifying its speed:  
  
-   <xref:System.Windows.Media.Animation.Timeline.SpeedRatio%2A> – Specifies that rate, relative to its parent, at which time progresses for a <xref:System.Windows.Media.Animation.Timeline>. Values greater than one increase the speed of the <xref:System.Windows.Media.Animation.Timeline> and its child <xref:System.Windows.Media.Animation.Timeline> objects; values between zero and one slow it down. A value of one indicates that <xref:System.Windows.Media.Animation.Timeline> progresses at the same rate as its parent. The <xref:System.Windows.Media.Animation.Timeline.SpeedRatio%2A> setting  of a container timeline affects all of its child <xref:System.Windows.Media.Animation.Timeline> objects as well.  
  
-   <xref:System.Windows.Media.Animation.Timeline.AccelerationRatio%2A> – Specifies the percentage of the <xref:System.Windows.Media.Animation.Timeline.Duration%2A> of a Timeline spent accelerating. For an example, see [How to: Accelerate or Decelerate an Animation](../../../../docs/framework/wpf/graphics-multimedia/how-to-accelerate-or-decelerate-an-animation.md). 
  
-   <xref:System.Windows.Media.Animation.Timeline.DecelerationRatio%2A> - Specifies the percentage of the <xref:System.Windows.Media.Animation.Timeline.Duration%2A> of a Timeline spent decelerating. For an example, see [How to: Accelerate or Decelerate an Animation](../../../../docs/framework/wpf/graphics-multimedia/how-to-accelerate-or-decelerate-an-animation.md).  
  
## See Also  
 [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md)  
 [Animation and Timing System Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-and-timing-system-overview.md)  
 [Timing Events Overview](../../../../docs/framework/wpf/graphics-multimedia/timing-events-overview.md)  
 [How-to Topics](../../../../docs/framework/wpf/graphics-multimedia/animation-and-timing-how-to-topics.md)  
 [Animation Timing Behavior Sample](http://go.microsoft.com/fwlink/?LinkID=159970)

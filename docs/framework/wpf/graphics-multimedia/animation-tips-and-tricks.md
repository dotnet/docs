---
title: "Animation Tips and Tricks"
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
  - "troubleshooting [WPF], animation"
  - "animations [WPF], FillBehavior property"
  - "troubleshooting animation [WPF]"
  - "animating objects [WPF], troubleshooting"
  - "animation tips and tricks [WPF]"
  - "tips and tricks [WPF], animation"
  - "performance troubleshooting [WPF], animation"
  - "animations [WPF], use of system resources"
ms.assetid: e467796b-d5d4-45a6-a108-8c5d7ff69a0f
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Animation Tips and Tricks
When working with animations in [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)], there are a number of tips and tricks that can make your animations perform better and save you frustration.  
  
<a name="generalissuessection"></a>   
## General Issues  
  
### Animating the Position of a Scroll Bar or Slider Freezes It  
 If you animate the position of a scroll bar or slider using an animation that has a <xref:System.Windows.Media.Animation.FillBehavior> of <xref:System.Windows.Media.Animation.FillBehavior.HoldEnd> (the default value), the user will no longer be able to move the scroll bar or slider. That's because, even though the animation ended, it's still overriding the target property's base value. To stop the animation from overriding the property's current value, remove it, or give it a <xref:System.Windows.Media.Animation.FillBehavior> of <xref:System.Windows.Media.Animation.FillBehavior.Stop>. For more information and an example, see [Set a Property After Animating It with a Storyboard](../../../../docs/framework/wpf/graphics-multimedia/how-to-set-a-property-after-animating-it-with-a-storyboard.md).  
  
### Animating the Output of an Animation Has No Effect  
 You can't animate an object that is the output of another animation. For example, if you use an <xref:System.Windows.Media.Animation.ObjectAnimationUsingKeyFrames> to animate the <xref:System.Windows.Shapes.Shape.Fill%2A> of a <xref:System.Windows.Shapes.Rectangle> from a <xref:System.Windows.Media.RadialGradientBrush> to a <xref:System.Windows.Media.SolidColorBrush>, you can't animate any properties of the <xref:System.Windows.Media.RadialGradientBrush> or <xref:System.Windows.Media.SolidColorBrush>.  
  
### Can't Change the Value of a Property after Animating it  
 In some cases, it might appear that you can't change the value of a property after it's been animated, even after the animation has ended. That's because, even though the animation ended, it's still overriding the property's base value. To stop the animation from overriding the property's current value, remove it, or give it a <xref:System.Windows.Media.Animation.FillBehavior> of <xref:System.Windows.Media.Animation.FillBehavior.Stop>. For more information and an example, see [Set a Property After Animating It with a Storyboard](../../../../docs/framework/wpf/graphics-multimedia/how-to-set-a-property-after-animating-it-with-a-storyboard.md).  
  
### Changing a Timeline Has No Effect  
 Although most <xref:System.Windows.Media.Animation.Timeline> properties are animatable and can be data bound, changing the property values of an active <xref:System.Windows.Media.Animation.Timeline> seems to have no effect. That's because, when a <xref:System.Windows.Media.Animation.Timeline> is begun, the timing system makes a copy of the <xref:System.Windows.Media.Animation.Timeline> and uses it to create a <xref:System.Windows.Media.Animation.Clock> object. Modifying the original has no effect on the system's copy.  
  
 For a <xref:System.Windows.Media.Animation.Timeline> to reflect changes, its clock must be regenerated and used to replace the previously created clock. Clocks are not regenerated for you automatically. The following are several ways to apply timeline changes:  
  
-   If the timeline is or belongs to a <xref:System.Windows.Media.Animation.Storyboard>, you can make it reflect changes by reapplying its storyboard using a <xref:System.Windows.Media.Animation.BeginStoryboard> or the <xref:System.Windows.Media.Animation.Storyboard.Begin%2A> method. This has the side effect of also restarting the animation. In code, you can use the <xref:System.Windows.Media.Animation.Storyboard.Seek%2A> method to advance the storyboard back to its previous position.  
  
-   If you applied an animation directly to a property using the <xref:System.Windows.Media.Animation.Animatable.BeginAnimation%2A> method, call the <xref:System.Windows.Media.Animation.Animatable.BeginAnimation%2A> method again and pass it the animation that has been modified.  
  
-   If you are working directly at the clock level, create and apply a new set of clocks and use them to replace the previous set of generated clocks.  
  
 For more information about timelines and clocks, see [Animation and Timing System Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-and-timing-system-overview.md).  
  
### FillBehavior.Stop Doesn't Work as Expected  
 There are times when setting the <xref:System.Windows.Media.Animation.Timeline.FillBehavior%2A> property to <xref:System.Windows.Media.Animation.FillBehavior.Stop> seems to have no effect, such as when one animation "hands off" to another because it has a <xref:System.Windows.Media.Animation.BeginStoryboard.HandoffBehavior%2A> setting of <xref:System.Windows.Media.Animation.HandoffBehavior.SnapshotAndReplace>.  
  
 The following example creates a <xref:System.Windows.Controls.Canvas>, a <xref:System.Windows.Shapes.Rectangle> and a <xref:System.Windows.Media.TranslateTransform>. The <xref:System.Windows.Media.TranslateTransform> will be animated to move the <xref:System.Windows.Shapes.Rectangle> around the <xref:System.Windows.Controls.Canvas>.  
  
 [!code-xaml[AnimationTipsAndTricksSample_snip#FillBehaviorTipAnimatedObject](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AnimationTipsAndTricksSample_snip/CSharp/FillBehaviorTip.xaml#fillbehaviortipanimatedobject)]  
  
 The examples in this section use the preceding objects to demonstrate several cases where the <xref:System.Windows.Media.Animation.Timeline.FillBehavior%2A> property doesn't behave as you might expect it to.  
  
#### FillBehavior="Stop" and HandoffBehavior with Multiple Animations  
 Sometimes it seems as though an animation ignores its <xref:System.Windows.Media.Animation.Timeline.FillBehavior%2A> property when it is replaced by a second animation. Take the following example, which creates two <xref:System.Windows.Media.Animation.Storyboard> objects and uses them to animate the same <xref:System.Windows.Media.TranslateTransform> shown in the preceding example.  
  
 The first <xref:System.Windows.Media.Animation.Storyboard>, `B1`, animates the <xref:System.Windows.Media.TranslateTransform.X%2A> property of the <xref:System.Windows.Media.TranslateTransform> from 0 to 350, which moves the rectangle 350 pixels to the right. When the animation reaches the end of its duration and stops playing, the <xref:System.Windows.Media.TranslateTransform.X%2A> property reverts to its original value, 0. As a result, the rectangle moves to the right 350 pixels and then jumps back to its original position.  
  
 [!code-xaml[AnimationTipsAndTricksSample_snip#FillBehaviorTipStoryboardB1Button](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AnimationTipsAndTricksSample_snip/CSharp/FillBehaviorTip.xaml#fillbehaviortipstoryboardb1button)]  
  
 The second <xref:System.Windows.Media.Animation.Storyboard>, `B2`, also animates the <xref:System.Windows.Media.TranslateTransform.X%2A> property of the same <xref:System.Windows.Media.TranslateTransform>. Because only the <xref:System.Windows.Media.Animation.DoubleAnimation.To%2A> property of the animation in this <xref:System.Windows.Media.Animation.Storyboard> is set, the animation uses the current value of the property it animates as its starting value.  
  
 [!code-xaml[AnimationTipsAndTricksSample_snip#FillBehaviorTipStoryboardB2Button](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AnimationTipsAndTricksSample_snip/CSharp/FillBehaviorTip.xaml#fillbehaviortipstoryboardb2button)]  
  
 If you click the second button while the first <xref:System.Windows.Media.Animation.Storyboard> is playing, you might expect the following behavior:  
  
1.  The first storyboard ends and sends the rectangle back to its original position, because the animation has a <xref:System.Windows.Media.Animation.Timeline.FillBehavior%2A> of <xref:System.Windows.Media.Animation.FillBehavior.Stop>.  
  
2.  The second storyboard takes effect and animates from the current position, which is now 0, to 500.  
  
 **But that's not what happens.** Instead, the rectangle does not jump back; it continues moving to the right. That's because the second animation uses the current value of the first animation as its starting value and animates from that value to 500. When the second animation replaces the first because the <xref:System.Windows.Media.Animation.HandoffBehavior.SnapshotAndReplace><xref:System.Windows.Media.Animation.HandoffBehavior> is used, the <xref:System.Windows.Media.Animation.FillBehavior> of the first animation does not matter.  
  
#### FillBehavior and the Completed Event  
 The next examples demonstrate another scenario in which the <xref:System.Windows.Media.Animation.FillBehavior.Stop><xref:System.Windows.Media.Animation.Timeline.FillBehavior%2A> seems to have no effect. Again, the example uses a Storyboard to animate the <xref:System.Windows.Media.TranslateTransform.X%2A> property of the <xref:System.Windows.Media.TranslateTransform> from 0 to 350. However, this time the example registers for the <xref:System.Windows.Media.Animation.Timeline.Completed> event.  
  
 [!code-xaml[AnimationTipsAndTricksSample_snip#FillBehaviorTipStoryboardCButton](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AnimationTipsAndTricksSample_snip/CSharp/FillBehaviorTip.xaml#fillbehaviortipstoryboardcbutton)]  
  
 The <xref:System.Windows.Media.Animation.Timeline.Completed> event handler starts another <xref:System.Windows.Media.Animation.Storyboard> that animates the same property from its current value to 500.  
  
 [!code-csharp[AnimationTipsAndTricksSample_snip#FillBehaviorTipStoryboardC1CompletedHandler](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AnimationTipsAndTricksSample_snip/CSharp/FillBehaviorTip.xaml.cs#fillbehaviortipstoryboardc1completedhandler)]
 [!code-vb[AnimationTipsAndTricksSample_snip#FillBehaviorTipStoryboardC1CompletedHandler](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/AnimationTipsAndTricksSample_snip/VisualBasic/FillBehaviorTip.xaml.vb#fillbehaviortipstoryboardc1completedhandler)]  
  
 The following is the markup that defines the second <xref:System.Windows.Media.Animation.Storyboard> as a resource.  
  
 [!code-xaml[AnimationTipsAndTricksSample_snip#FillBehaviorTipResources](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AnimationTipsAndTricksSample_snip/CSharp/FillBehaviorTip.xaml#fillbehaviortipresources)]  
  
 When you run the <xref:System.Windows.Media.Animation.Storyboard>, you might expect the <xref:System.Windows.Media.TranslateTransform.X%2A> property of the <xref:System.Windows.Media.TranslateTransform> to animate from 0 to 350, then revert to 0 after it completes (because it has a <xref:System.Windows.Media.Animation.FillBehavior> setting of <xref:System.Windows.Media.Animation.FillBehavior.Stop>), and then animate from 0 to 500. Instead, the <xref:System.Windows.Media.TranslateTransform> animates from 0 to 350 and then to 500.  
  
 That's because of the order in which [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] raises events and because property values are cached and are not recalculated unless the property is invalidated. The <xref:System.Windows.Media.Animation.Timeline.Completed> event is processed first because it was triggered by the root timeline (the first <xref:System.Windows.Media.Animation.Storyboard>). At this time, the <xref:System.Windows.Media.TranslateTransform.X%2A> property still returns its animated value because it hasn't been invalidated yet. The second <xref:System.Windows.Media.Animation.Storyboard> uses the cached value as its starting value and begins animating.  
  
<a name="performancesection"></a>   
## Performance  
  
### Animations Continue to Run After Navigating Away from a Page  
 When you navigate away from a <xref:System.Windows.Controls.Page> that contains running animations, those animations will continue to play until the <xref:System.Windows.Controls.Page> is garbage collected. Depending on the navigation system you're using, a page that you navigate away from might stay in memory for an indefinite amount of time, all the while consuming resources with its animations. This is most noticeable when a page contains constantly running ("ambient") animations.  
  
 For this reason, it's a good idea to use the <xref:System.Windows.FrameworkElement.Unloaded> event to remove animations when you navigate away from a page.  
  
 There are different ways to remove an animation. The following techniques can be used to remove animations that belong to a <xref:System.Windows.Media.Animation.Storyboard>.  
  
-   To remove a <xref:System.Windows.Media.Animation.Storyboard> you started with an event trigger, see [How to: Remove a Storyboard](http://msdn.microsoft.com/library/7fe39531-de2f-46a0-a69f-b783d04235ee).  
  
-   To use code to remove a <xref:System.Windows.Media.Animation.Storyboard>, see the <xref:System.Windows.Media.Animation.Storyboard.Remove%2A> method.  
  
 The next technique may be used regardless of how the animation was started.  
  
-   To remove animations from a specific property, use the <xref:System.Windows.Media.Animation.Animatable.BeginAnimation%28System.Windows.DependencyProperty%2CSystem.Windows.Media.Animation.AnimationTimeline%29> method. Specify the property being animated as the first parameter, and `null` as the second. This will remove all animation clocks from the property.  
  
 For more information about the different ways to animate properties, see [Property Animation Techniques Overview](../../../../docs/framework/wpf/graphics-multimedia/property-animation-techniques-overview.md).  
  
### Using the Compose HandoffBehavior Consumes System Resources  
 When you apply a <xref:System.Windows.Media.Animation.Storyboard>, <xref:System.Windows.Media.Animation.AnimationTimeline>, or <xref:System.Windows.Media.Animation.AnimationClock> to a property using the <xref:System.Windows.Media.Animation.HandoffBehavior.Compose><xref:System.Windows.Media.Animation.HandoffBehavior>, any <xref:System.Windows.Media.Animation.Clock> objects previously associated with that property continue to consume system resources; the timing system will not remove these clocks automatically.  
  
 To avoid performance issues when you apply a large number of clocks using <xref:System.Windows.Media.Animation.HandoffBehavior.Compose>, you should remove composing clocks from the animated property after they complete. There are several ways to remove a clock.  
  
-   To remove all clocks from a property, use the <xref:System.Windows.Media.Animation.Animatable.ApplyAnimationClock%28System.Windows.DependencyProperty%2CSystem.Windows.Media.Animation.AnimationClock%29> or <xref:System.Windows.Media.Animation.Animatable.BeginAnimation%28System.Windows.DependencyProperty%2CSystem.Windows.Media.Animation.AnimationTimeline%29> method of the animated object. Specify the property being animated as the first parameter, and `null` as the second. This will remove all animation clocks from the property.  
  
-   To remove a specific <xref:System.Windows.Media.Animation.AnimationClock> from a list of clocks, use the <xref:System.Windows.Media.Animation.Clock.Controller%2A> property of the <xref:System.Windows.Media.Animation.AnimationClock> to retrieve a <xref:System.Windows.Media.Animation.ClockController>, then call the <xref:System.Windows.Media.Animation.ClockController.Remove%2A> method of the <xref:System.Windows.Media.Animation.ClockController>. This is typically done in the <xref:System.Windows.Media.Animation.Clock.Completed> event handler for a clock. Note that only root clocks can be controlled by a <xref:System.Windows.Media.Animation.ClockController>; the <xref:System.Windows.Media.Animation.Clock.Controller%2A> property of a child clock will return `null`. Note also that the <xref:System.Windows.Media.Animation.Clock.Completed> event will not be called if the effective duration of the clock is forever.  In that case, the user will need to determine when to call <xref:System.Windows.Media.Animation.ClockController.Remove%2A>.  
  
 This is primarily an issue for animations on objects that have a long lifetime.  When an object is garbage collected, its clocks will also be disconnected and garbage collected.  
  
 For more information about clock objects, see [Animation and Timing System Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-and-timing-system-overview.md).  
  
## See Also  
 [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md)

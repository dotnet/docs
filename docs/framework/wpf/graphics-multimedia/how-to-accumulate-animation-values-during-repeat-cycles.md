---
title: "How to: Accumulate Animation Values During Repeat Cycles"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "accumulating animation values across repeating cycles [WPF]"
  - "animation [WPF], accumulating values across repeating cycles"
ms.assetid: 548df369-c7cc-4dab-b569-08b95ced2e7e
---
# How to: Accumulate Animation Values During Repeat Cycles
This example shows how to use the <xref:System.Windows.Media.Animation.DoubleAnimation.IsCumulative%2A> property to accumulate animation values across repeating cycles.  
  
## Example  
 Use the <xref:System.Windows.Media.Animation.DoubleAnimation.IsCumulative%2A> property to accumulate base values of an animation across repeating cycles. For example, if you set an animation to repeat 9 times (<xref:System.Windows.Media.Animation.Timeline.RepeatBehavior%2A> = "9x") and you set the property to animate between 10 and 15 (From = 10 To = 15), the property animates from 10 to 15 during the first cycle, from 15 to 20 during the second cycle, from 20 to 25 during the third cycle, and so on. Hence, each animation cycle uses the ending animation value from the previous animation cycle as its base value.  
  
 You can use the `IsCumulative` property with most basic animations and most key frame animations. For more information, see [Animation Overview](animation-overview.md) and [Key-Frame Animations Overview](key-frame-animations-overview.md).  
  
 The following example shows this behavior by animating the width of four rectangles. The example:  
  
- Animates the first rectangle with <xref:System.Windows.Media.Animation.DoubleAnimation> and sets the <xref:System.Windows.Media.Animation.DoubleAnimation.IsCumulative%2A> property to `true`.  
  
- Animates the second rectangle with <xref:System.Windows.Media.Animation.DoubleAnimation> and sets the <xref:System.Windows.Media.Animation.DoubleAnimation.IsCumulative%2A> property to the default value of `false`.  
  
- Animates the third rectangle with <xref:System.Windows.Media.Animation.DoubleAnimationUsingKeyFrames> and sets the <xref:System.Windows.Media.Animation.DoubleAnimationUsingKeyFrames.IsCumulative%2A> property to `true`.  
  
- Animates the last rectangle with <xref:System.Windows.Media.Animation.DoubleAnimationUsingKeyFrames> and sets the <xref:System.Windows.Media.Animation.DoubleAnimationUsingKeyFrames.IsCumulative%2A> property to `false`.  
  
 [!code-xaml[timingbehaviors_snip#IsCumulativeWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/timingbehaviors_snip/CSharp/IsCumulativeExample.xaml#iscumulativewholepage)]  
  
## See also

- [Add an Animation Output Value to an Animation Starting Value](how-to-add-an-animation-output-value-to-an-animation-starting-value.md)
- [Repeat an Animation](how-to-repeat-an-animation.md)
- [Animation Overview](animation-overview.md)
- [Key-Frame Animations Overview](key-frame-animations-overview.md)
- [How-to Topics](animation-and-timing-how-to-topics.md)

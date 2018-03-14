---
title: "Multimedia Overview"
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
  - "multimedia [WPF]"
  - "media [WPF]"
ms.assetid: feb25b15-d741-4ac3-818f-1b19f63a3562
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Multimedia Overview
The multimedia features in [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] enable you to integrate audio and video into your applications to enhance the user experience. This topic introduces the multimedia features of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)].  
  
 
  
<a name="mediaapi"></a>   
## Media API  
 The <xref:System.Windows.Controls.MediaElement> and <xref:System.Windows.Media.MediaPlayer> classes are used to present audio or video content. These classes can be controlled interactively or by a clock. These classes can use on the [!INCLUDE[TLA#tla_wmp](../../../../includes/tlasharptla-wmp-md.md)] 10 control for media playback. Which class you use, depends on the scenario.  
  
 <xref:System.Windows.Controls.MediaElement> is a <xref:System.Windows.UIElement> that is supported by the [Layout](../../../../docs/framework/wpf/advanced/layout.md) and can be consumed as the content of many controls. It is also usable in [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] as well as code. <xref:System.Windows.Media.MediaPlayer>, on the other hand, is designed for <xref:System.Windows.Media.Drawing> objects and lacks layout support. Media loaded using a <xref:System.Windows.Media.MediaPlayer> can only be presented using a <xref:System.Windows.Media.VideoDrawing> or by directly interacting with a <xref:System.Windows.Media.DrawingContext>. <xref:System.Windows.Media.MediaPlayer> cannot be used in XAML.  
  
 For more information about drawing objects and drawing context, see [Drawing Objects Overview](../../../../docs/framework/wpf/graphics-multimedia/drawing-objects-overview.md).  
  
> [!NOTE]
>  When distributing media with your application, you cannot use a media file as a project resource. In your project file, you must instead set the media type to `Content` and set `CopyToOutputDirectory` to `PreserveNewest` or `Always`.  
  
<a name="mediaplaybackmodes"></a>   
## Media Playback Modes  
  
> [!NOTE]
>  Both <xref:System.Windows.Controls.MediaElement> and <xref:System.Windows.Media.MediaPlayer> have similar members. The links in this section refer to the <xref:System.Windows.Controls.MediaElement> class members. Unless specifically noted, members linked to in the <xref:System.Windows.Controls.MediaElement> class can also be found in the <xref:System.Windows.Media.MediaPlayer> class.  
  
 To understand media playback in [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)], an understanding of the different modes in which media can be played is required. Both <xref:System.Windows.Controls.MediaElement> and <xref:System.Windows.Media.MediaPlayer> can be used in two different media modes, independent mode and clock mode. The media mode is determined by the <xref:System.Windows.Controls.MediaElement.Clock%2A> property. When <xref:System.Windows.Controls.MediaElement.Clock%2A> is `null`, the media object is in independent mode. When the <xref:System.Windows.Controls.MediaElement.Clock%2A> is non-null, the media object is in clock mode. By default, media objects are in independent mode.  
  
### Independent Mode  
 In independent mode, the media content drives media playback. Independent mode enables the following options:  
  
-   Media's <xref:System.Uri> can be directly specified.  
  
-   Media playback can be directly controlled.  
  
-   Media's <xref:System.Windows.Controls.MediaElement.Position%2A> and <xref:System.Windows.Controls.MediaElement.SpeedRatio%2A> properties can be modified.  
  
 Media is loaded by either setting the <xref:System.Windows.Controls.MediaElement> object's <xref:System.Windows.Controls.MediaElement.Source%2A> property or by calling the <xref:System.Windows.Media.MediaPlayer> object's <xref:System.Windows.Media.MediaPlayer.Open%2A> method.  
  
 To control media playback in independent mode, the media object's control methods can be used. The control methods available are <xref:System.Windows.Controls.MediaElement.Play%2A>, <xref:System.Windows.Controls.MediaElement.Pause%2A>, <xref:System.Windows.Controls.MediaElement.Close%2A>, and <xref:System.Windows.Controls.MediaElement.Stop%2A>. For <xref:System.Windows.Controls.MediaElement>, interactive control using these methods is only available when the <xref:System.Windows.Controls.MediaElement.LoadedBehavior%2A> is set to <xref:System.Windows.Controls.MediaState.Manual>. These methods are unavailable when the media object is in clock mode.  
  
 See [Control a MediaElement (Play, Pause, Stop, Volume, and Speed)](../../../../docs/framework/wpf/graphics-multimedia/how-to-control-a-mediaelement-play-pause-stop-volume-and-speed.md) for an example of independent mode.  
  
### Clock Mode  
 In clock mode, a <xref:System.Windows.Media.MediaTimeline> drives media playback. Clock mode has the following characteristics:  
  
-   Media's <xref:System.Uri> is indirectly set through a <xref:System.Windows.Media.MediaTimeline>.  
  
-   Media playback can be controlled by the clock. The media object's control methods cannot be used.  
  
-   Media is loaded by setting a <xref:System.Windows.Media.MediaTimeline> object's <xref:System.Windows.Media.MediaTimeline.Source%2A> property, creating the clock from the timeline, and assigning the clock to the media object. Media is also loaded this way when a <xref:System.Windows.Media.MediaTimeline> inside a <xref:System.Windows.Media.Animation.Storyboard> targets a <xref:System.Windows.Controls.MediaElement>.  
  
 To control media playback in clock mode, the <xref:System.Windows.Media.Animation.ClockController> control methods must be used. A <xref:System.Windows.Media.Animation.ClockController> is obtained from the <xref:System.Windows.Media.Animation.ClockController> property of the <xref:System.Windows.Media.MediaClock>. If you attempt to use the control methods of either a <xref:System.Windows.Controls.MediaElement> or <xref:System.Windows.Media.MediaPlayer> object while in clock mode, an <xref:System.InvalidOperationException> will be thrown.  
  
 See the [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md) for more information about clocks and timelines.  
  
 See [Control a MediaElement by Using a Storyboard](../../../../docs/framework/wpf/graphics-multimedia/how-to-control-a-mediaelement-by-using-a-storyboard.md) for an example of clock mode.  
  
<a name="mediaelement"></a>   
## MediaElement Class  
 Adding media to an application is as simple as adding a <xref:System.Windows.Controls.MediaElement> control to the [!INCLUDE[TLA#tla_ui](../../../../includes/tlasharptla-ui-md.md)] of the application and providing a <xref:System.Uri> to the media you wish to include. All media types supported by [!INCLUDE[TLA#tla_wmp](../../../../includes/tlasharptla-wmp-md.md)] 10 are supported in [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)]. The following example shows a simple usage of the <xref:System.Windows.Controls.MediaElement> in [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)].  
  
 [!code-xaml[MediaElement_snip#SimpleMediaElementUsageWholePage](../../../../samples/snippets/csharp/VS_Snippets_Wpf/MediaElement_snip/CSharp/SimpleUsage.xaml#simplemediaelementusagewholepage)]  
  
 In this sample, media is played automatically as soon as it is loaded. Once the media has finished playing, the media is closed and all media resources are release (including video memory). This is the default behavior of the <xref:System.Windows.Controls.MediaElement> object and is controlled by the <xref:System.Windows.Controls.MediaElement.LoadedBehavior%2A> and <xref:System.Windows.Controls.MediaElement.UnloadedBehavior%2A> properties.  
  
### Controlling a MediaElement  
 The <xref:System.Windows.Controls.MediaElement.LoadedBehavior%2A> and <xref:System.Windows.Controls.MediaElement.UnloadedBehavior%2A> properties control the behavior of the <xref:System.Windows.Controls.MediaElement> when <xref:System.Windows.FrameworkElement.IsLoaded%2A> is `true` or `false`, respectively. The <xref:System.Windows.Controls.MediaState> the properties are set to affect the media playback behavior. For example, the default <xref:System.Windows.Controls.MediaElement.LoadedBehavior%2A> is <xref:System.Windows.Controls.MediaState.Play> and the default <xref:System.Windows.Controls.MediaElement.UnloadedBehavior%2A> is <xref:System.Windows.Controls.MediaState.Close>. This means that as soon as the <xref:System.Windows.Controls.MediaElement> is loaded and the preroll is complete, the media begins to play. Once playback is complete, media is closed and all media resources are released.  
  
 The <xref:System.Windows.Controls.MediaElement.LoadedBehavior%2A> and <xref:System.Windows.Controls.MediaElement.UnloadedBehavior%2A> properties are not the only way to control media playback. In clock mode, the clock can control the <xref:System.Windows.Controls.MediaElement> and the interactive control methods have control when the <xref:System.Windows.Controls.MediaElement.LoadedBehavior%2A> is <xref:System.Windows.Controls.MediaState.Manual>. <xref:System.Windows.Controls.MediaElement> handles this competition for control by evaluating the following priorities.  
  
1.  <xref:System.Windows.Controls.MediaElement.UnloadedBehavior%2A>. In place when media is unloaded. This ensures that all media resources are released by default, even when a <xref:System.Windows.Media.MediaClock> is associated with the <xref:System.Windows.Controls.MediaElement>.  
  
2.  <xref:System.Windows.Media.MediaClock>. In place when media has a <xref:System.Windows.Controls.MediaElement.Clock%2A>. If media is unloaded, the <xref:System.Windows.Media.MediaClock> will take effect as long as the <xref:System.Windows.Controls.MediaElement.UnloadedBehavior%2A> is <xref:System.Windows.Controls.MediaState.Manual>. Clock mode always overrides the loaded behavior of the <xref:System.Windows.Controls.MediaElement>.  
  
3.  <xref:System.Windows.Controls.MediaElement.LoadedBehavior%2A>. In place when media is loaded.  
  
4.  Interactive control methods. In place when <xref:System.Windows.Controls.MediaElement.LoadedBehavior%2A> is <xref:System.Windows.Controls.MediaState.Manual>. The control methods available are <xref:System.Windows.Controls.MediaElement.Play%2A>, <xref:System.Windows.Controls.MediaElement.Pause%2A>, <xref:System.Windows.Controls.MediaElement.Close%2A>, and <xref:System.Windows.Controls.MediaElement.Stop%2A>.  
  
### Displaying a MediaElement  
 To display a <xref:System.Windows.Controls.MediaElement> it must have content to render and it will have its <xref:System.Windows.FrameworkElement.ActualWidth%2A> and <xref:System.Windows.FrameworkElement.ActualHeight%2A> properties set to zero until content is loaded. For audio only content, these properties are always zero. For video content, once the <xref:System.Windows.Controls.MediaElement.MediaOpened> event has been raised the <xref:System.Windows.FrameworkElement.ActualWidth%2A> and <xref:System.Windows.FrameworkElement.ActualHeight%2A> will report the size of the loaded media. This means that until media is loaded, the <xref:System.Windows.Controls.MediaElement> will not take up any physical space in the [!INCLUDE[TLA#tla_ui](../../../../includes/tlasharptla-ui-md.md)] unless the <xref:System.Windows.FrameworkElement.Width%2A> or <xref:System.Windows.FrameworkElement.Height%2A> properties are set.  
  
 Setting both the <xref:System.Windows.FrameworkElement.Width%2A> and <xref:System.Windows.FrameworkElement.Height%2A> properties will cause the media to stretch to fill the area provided for the <xref:System.Windows.Controls.MediaElement>. To preserve the media's original aspect ratio, either the <xref:System.Windows.FrameworkElement.Width%2A> or <xref:System.Windows.FrameworkElement.Height%2A> property should be set but not both. Setting both the <xref:System.Windows.FrameworkElement.Width%2A> and <xref:System.Windows.FrameworkElement.Height%2A> properties will cause the media to present in a fixed element size that may not be desirable.  
  
 To avoid having a fixed size element which, [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] can preroll the media. This is done by setting the <xref:System.Windows.Controls.MediaElement.LoadedBehavior%2A> to either <xref:System.Windows.Controls.MediaState.Play> or <xref:System.Windows.Controls.MediaState.Pause>. In a <xref:System.Windows.Controls.MediaState.Pause> state, the media will preroll and will present the first frame. In a <xref:System.Windows.Controls.MediaState.Play> state, the media will preroll and begin to play.  
  
<a name="mediaplayer"></a>   
## MediaPlayer Class  
 Where as the <xref:System.Windows.Controls.MediaElement> class is a framework element, the <xref:System.Windows.Media.MediaPlayer> class is designed to be used in <xref:System.Windows.Media.Drawing> objects. Drawing objects are used when you can sacrifice framework level features to gain performance benefits or when you need <xref:System.Windows.Freezable> features. <xref:System.Windows.Media.MediaPlayer> enables you to take advantage of these features while providing media content in your applications. Like <xref:System.Windows.Controls.MediaElement>, <xref:System.Windows.Media.MediaPlayer> can be used in independent or clock mode but does not have the <xref:System.Windows.Controls.MediaElement> object's unloaded and loaded states. This reduces the playback control complexity of the <xref:System.Windows.Media.MediaPlayer>.  
  
### Controlling MediaPlayer  
 Because <xref:System.Windows.Media.MediaPlayer> is stateless, there are only two ways to control media playback.  
  
1.  Interactive control methods. In place when in independent mode (`null`<xref:System.Windows.Media.MediaPlayer.Clock%2A> property).  
  
2.  <xref:System.Windows.Media.MediaClock>. In place when media has a <xref:System.Windows.Media.MediaPlayer.Clock%2A>.  
  
### Displaying a MediaPlayer  
 Technically, a <xref:System.Windows.Media.MediaPlayer> cannot be displayed since it has no physical representation. However, it can be used to present media in a <xref:System.Windows.Media.Drawing> using the <xref:System.Windows.Media.VideoDrawing> class. The following example demonstrates the use of a <xref:System.Windows.Media.VideoDrawing> to display media.  
  
 [!code-csharp[DrawingMiscSnippets_snip#VideoDrawingExampleInline](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DrawingMiscSnippets_snip/CSharp/VideoDrawingExample.cs#videodrawingexampleinline)]  
  
 See the [Drawing Objects Overview](../../../../docs/framework/wpf/graphics-multimedia/drawing-objects-overview.md) for more information about <xref:System.Windows.Media.Drawing> objects.  
  
## See Also  
 <xref:System.Windows.Media.DrawingGroup>  
 [Layout](../../../../docs/framework/wpf/advanced/layout.md)  
 [How-to Topics](../../../../docs/framework/wpf/graphics-multimedia/audio-and-video-how-to-topics.md)

---
title: "Popup Overview"
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
  - "controls [WPF], Popup"
  - "Popup control [WPF], about Popup control"
ms.assetid: 774f53ca-bff8-470e-9ce9-3928b4cf3d4c
caps.latest.revision: 34
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Popup Overview
The <xref:System.Windows.Controls.Primitives.Popup> control provides a way to display content in a separate window that floats over the current application window relative to a designated element or screen coordinate. This topic introduces the <xref:System.Windows.Controls.Primitives.Popup> control and provides information about its use.  
  
 
  
<a name="What_Is_a_Popup_"></a>   
## What Is a Popup?  
 A <xref:System.Windows.Controls.Primitives.Popup> control displays content in a separate window relative to an element or point on the screen. When the <xref:System.Windows.Controls.Primitives.Popup> is visible, the <xref:System.Windows.Controls.Primitives.Popup.IsOpen%2A> property is set to `true`.  
  
> [!NOTE]
>  A <xref:System.Windows.Controls.Primitives.Popup> does not automatically open when the mouse pointer moves over its parent object. If you want a <xref:System.Windows.Controls.Primitives.Popup> to automatically open, use the <xref:System.Windows.Controls.ToolTip> or <xref:System.Windows.Controls.ToolTipService> class. For more information, see [ToolTip Overview](../../../../docs/framework/wpf/controls/tooltip-overview.md).  
  
<a name="APopupExample"></a>   
## Creating a Popup  
 The following example shows how to define a <xref:System.Windows.Controls.Primitives.Popup> control that is the child element of a <xref:System.Windows.Controls.Button> control. Because a <xref:System.Windows.Controls.Button> can have only one child element, this example places the text for the <xref:System.Windows.Controls.Button> and the <xref:System.Windows.Controls.Primitives.Popup> controls in a <xref:System.Windows.Controls.StackPanel>. The content of the <xref:System.Windows.Controls.Primitives.Popup> appears in a <xref:System.Windows.Controls.TextBlock> control, which displays its text in a separate window that floats over the application window near the related <xref:System.Windows.Controls.Button> control.  
  
 [!code-xaml[PopupSimple#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/PopupSimple/CSharp/Window1.xaml#1)]  
  
 [!code-xaml[PopupSimple#CreatePopupCodeXAML](../../../../samples/snippets/csharp/VS_Snippets_Wpf/PopupSimple/CSharp/Window1.xaml#createpopupcodexaml)]  
  
<a name="PopupUses"></a>   
## Controls That Implement a Popup  
 You can build <xref:System.Windows.Controls.Primitives.Popup> controls into other controls. The following controls implement the <xref:System.Windows.Controls.Primitives.Popup> control for specific uses:  
  
-   <xref:System.Windows.Controls.ToolTip>. If you want to create a tooltip for an element, use the <xref:System.Windows.Controls.ToolTip> and <xref:System.Windows.Controls.ToolTipService> classes. For more information, see [ToolTip Overview](../../../../docs/framework/wpf/controls/tooltip-overview.md).  
  
-   <xref:System.Windows.Controls.ContextMenu>. If you want to create a context menu for an element, use the <xref:System.Windows.Controls.ContextMenu> control. For more information, see [ContextMenu Overview](../../../../docs/framework/wpf/controls/contextmenu-overview.md).  
  
-   <xref:System.Windows.Controls.ComboBox>. If you want to create a selection control that has a drop-down list box that can be shown or hidden, use the <xref:System.Windows.Controls.ComboBox> control.  
  
-   <xref:System.Windows.Controls.Expander>. If you want to create a control that displays a header with a collapsible area that displays content, use the <xref:System.Windows.Controls.Expander> control. For more information, see [Expander Overview](../../../../docs/framework/wpf/controls/expander-overview.md).  
  
<a name="PopupBehaviorandAppearance"></a>   
## Popup Behavior and Appearance  
 The <xref:System.Windows.Controls.Primitives.Popup> control provides functionality that enables you to customize its behavior and appearance. For example, you can set open and close behavior, animation, opacity and bitmap effects, and <xref:System.Windows.Controls.Primitives.Popup> size and position.  
  
<a name="OpenandCloseBehavior"></a>   
### Open and Close Behavior  
 A <xref:System.Windows.Controls.Primitives.Popup> control displays its content when the <xref:System.Windows.Controls.Primitives.Popup.IsOpen%2A> property is set to `true`. By default, <xref:System.Windows.Controls.Primitives.Popup> stays open until the <xref:System.Windows.Controls.Primitives.Popup.IsOpen%2A> property is set to `false`. However, you can change the default behavior by setting the <xref:System.Windows.Controls.Primitives.Popup.StaysOpen%2A> property to `false`. When you set this property to `false`, the <xref:System.Windows.Controls.Primitives.Popup> content window has mouse capture. The <xref:System.Windows.Controls.Primitives.Popup> loses mouse capture and the window closes when a mouse event occurs outside the <xref:System.Windows.Controls.Primitives.Popup> window.  
  
 The <xref:System.Windows.Controls.Primitives.Popup.Opened> and <xref:System.Windows.Controls.Primitives.Popup.Closed> events are raised when the <xref:System.Windows.Controls.Primitives.Popup> content window is open or closed.  
  
<a name="Animation"></a>   
### Animation  
 The <xref:System.Windows.Controls.Primitives.Popup> control has built-in support for the animations that are typically associated with behaviors like fade-in and slide-in. You can turn on these animations by setting the <xref:System.Windows.Controls.Primitives.Popup.PopupAnimation%2A> property to a <xref:System.Windows.Controls.Primitives.PopupAnimation> enumeration value. For <xref:System.Windows.Controls.Primitives.Popup> animations to work correctly, you must set the <xref:System.Windows.Controls.Primitives.Popup.AllowsTransparency%2A> property to `true`.  
  
 You can also apply animations like <xref:System.Windows.Media.Animation.Storyboard> to the <xref:System.Windows.Controls.Primitives.Popup> control.  
  
<a name="OpacityandBitmapEffects"></a>   
### Opacity and Bitmap Effects  
 The <xref:System.Windows.UIElement.Opacity%2A> property for a <xref:System.Windows.Controls.Primitives.Popup> control has no effect on its content. By default, the <xref:System.Windows.Controls.Primitives.Popup> content window is opaque. To create a transparent <xref:System.Windows.Controls.Primitives.Popup>, set the <xref:System.Windows.Controls.Primitives.Popup.AllowsTransparency%2A> property to `true`.  
  
 The content of a <xref:System.Windows.Controls.Primitives.Popup> does not inherit bitmap effects, such as <xref:System.Windows.Media.Effects.DropShadowBitmapEffect>, that you directly set on the <xref:System.Windows.Controls.Primitives.Popup> control or on any other element in the parent window. For bitmap effects to appear on the content of a <xref:System.Windows.Controls.Primitives.Popup>, you must set the bitmap effect directly on its content. For example, if the child of a <xref:System.Windows.Controls.Primitives.Popup> is a <xref:System.Windows.Controls.StackPanel>, set the bitmap effect on the <xref:System.Windows.Controls.StackPanel>.  
  
<a name="PopupSize"></a>   
### Popup Size  
 By default, a <xref:System.Windows.Controls.Primitives.Popup> is automatically sized to its content. When auto-sizing occurs, some bitmap effects may be hidden because the default size of the screen area that is defined for the <xref:System.Windows.Controls.Primitives.Popup> content does not provide enough space for the bitmap effects to display.  
  
 <xref:System.Windows.Controls.Primitives.Popup> content can also be obscured when you set a <xref:System.Windows.UIElement.RenderTransform%2A> on the content. In this scenario, some content might be hidden if the content of the transformed <xref:System.Windows.Controls.Primitives.Popup> extends beyond the area of the original <xref:System.Windows.Controls.Primitives.Popup>. If a bitmap effect or transform requires more space, you can define a margin around the <xref:System.Windows.Controls.Primitives.Popup> content in order to provide more area for the control.  
  
<a name="DefiningPopupPosition"></a>   
## Defining the Popup Position  
 You can position a popup by setting the <xref:System.Windows.Controls.Primitives.Popup.PlacementTarget%2A>, <xref:System.Windows.Controls.Primitives.Popup.PlacementRectangle%2A>, <xref:System.Windows.Controls.Primitives.Popup.Placement%2A>, <xref:System.Windows.Controls.Primitives.Popup.HorizontalOffset%2A>, and <xref:System.Windows.Controls.Primitives.Popup.VerticalOffsetProperty> properties. For more information, see [Popup Placement Behavior](../../../../docs/framework/wpf/controls/popup-placement-behavior.md). When <xref:System.Windows.Controls.Primitives.Popup> is displayed on the screen, it does not reposition itself if its parent is repositioned.  
  
<a name="CustomizingPopupPlacement"></a>   
### Customizing Popup Placement  
 You can customize the placement of a <xref:System.Windows.Controls.Primitives.Popup> control by specifying a set of coordinates that are relative to the <xref:System.Windows.Controls.Primitives.Popup.PlacementTarget%2A> where you want the <xref:System.Windows.Controls.Primitives.Popup> to appear.  
  
 To customize placement, set the <xref:System.Windows.Controls.Primitives.Popup.Placement%2A> property to <xref:System.Windows.Controls.Primitives.PlacementMode.Custom>. Then define a <xref:System.Windows.Controls.Primitives.CustomPopupPlacementCallback> delegate that returns a set of possible placement points and primary axes (in order of preference) for the <xref:System.Windows.Controls.Primitives.Popup>. The point that shows the largest part of the <xref:System.Windows.Controls.Primitives.Popup> is automatically selected. For an example, see [Specify a Custom Popup Position](../../../../docs/framework/wpf/controls/how-to-specify-a-custom-popup-position.md).  
  
<a name="PopupandtheVisualTree"></a>   
## Popup and the Visual Tree  
 A <xref:System.Windows.Controls.Primitives.Popup> control does not have its own visual tree; it instead returns a size of 0 (zero) when the <xref:System.Windows.Controls.Primitives.Popup.MeasureOverride%2A> method for <xref:System.Windows.Controls.Primitives.Popup> is called. However, when you set the <xref:System.Windows.Controls.Primitives.Popup.IsOpen%2A> property of <xref:System.Windows.Controls.Primitives.Popup> to `true`, a new window with its own visual tree is created. The new window contains the <xref:System.Windows.Controls.Primitives.Popup.Child%2A> content of <xref:System.Windows.Controls.Primitives.Popup>. The width and height of the new window cannot be larger than 75 percent of the width or height of the screen.  
  
 The <xref:System.Windows.Controls.Primitives.Popup> control maintains a reference to its <xref:System.Windows.Controls.Primitives.Popup.Child%2A> content as a logical child. When the new window is created, the content of <xref:System.Windows.Controls.Primitives.Popup> becomes a visual child of the window and remains the logical child of <xref:System.Windows.Controls.Primitives.Popup>. Conversely, <xref:System.Windows.Controls.Primitives.Popup> remains the logical parent of its <xref:System.Windows.Controls.Primitives.Popup.Child%2A> content.  
  
## See Also  
 <xref:System.Windows.Controls.Primitives.Popup>  
 <xref:System.Windows.Controls.Primitives.PopupPrimaryAxis>  
 <xref:System.Windows.Controls.Primitives.PlacementMode>  
 <xref:System.Windows.Controls.Primitives.CustomPopupPlacement>  
 <xref:System.Windows.Controls.Primitives.CustomPopupPlacementCallback>  
 <xref:System.Windows.Controls.ToolTip>  
 <xref:System.Windows.Controls.ToolTipService>  
 [How-to Topics](../../../../docs/framework/wpf/controls/popup-how-to-topics.md)  
 [How-to Topics](../../../../docs/framework/wpf/controls/tooltip-how-to-topics.md)

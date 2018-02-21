---
title: "How to: Create a Windows Forms Control That Shows Progress"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "controls [Windows Forms], progress tracking"
  - "controls [Windows Forms], creating"
  - "progress [Windows Forms], reporting [Windows Forms]"
  - "FlashTrackBar custom control"
ms.assetid: 24c5a2e3-058c-4b8d-a217-c06e6a130c2f
caps.latest.revision: 6
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create a Windows Forms Control That Shows Progress
The following code example shows a custom control called `FlashTrackBar` that can be used to show the user the level or the progress of an application. It uses a gradient to visually represent progress.  
  
 The `FlashTrackBar` control illustrates the following concepts:  
  
-   Defining custom properties.  
  
-   Defining custom events. (`FlashTrackBar` defines the `ValueChanged` event.)  
  
-   Overriding the <xref:System.Windows.Forms.Control.OnPaint%2A> method to provide logic to draw the control.  
  
-   Computing the area available for drawing the control by using its <xref:System.Windows.Forms.Control.ClientRectangle%2A> property. `FlashTrackBar` does this in its `OptimizedInvalidate` method.  
  
-   Implementing serialization or persistence for a property when it is changed in the Windows Forms Designer. `FlashTrackBar` defines the `ShouldSerializeStartColor` and `ShouldSerializeEndColor` methods for serializing its `StartColor` and `EndColor` properties.  
  
 The following table shows the custom properties defined by `FlashTrackBar`.  
  
|Property|Description|  
|--------------|-----------------|  
|`AllowUserEdit`|Indicates whether the user can change the value of the flash track bar by clicking and dragging it.|  
|`EndColor`|Specifies the ending color of the track bar.|  
|`DarkenBy`|Specifies how much to darken the background with respect to the foreground gradient.|  
|`Max`|Specifies the maximum value of the track bar.|  
|`Min`|Specifies the minimum value of the track bar.|  
|`StartColor`|Specifies the starting color of the gradient.|  
|`ShowPercentage`|Indicates whether to display a percentage over the gradient.|  
|`ShowValue`|Indicates whether to display the current value over the gradient.|  
|`ShowGradient`|Indicates whether the track bar should display a color gradient showing the current value.|  
|-   `Value`|Specifies the current value of the track bar.|  
  
 The following table shows additional members defined by `FlashTrackBar:` the property-changed event and the method that raises the event.  
  
|Member|Description|  
|------------|-----------------|  
|`ValueChanged`|The event that is raised when the `Value` property of the track bar changes.|  
|`OnValueChanged`|The method that raises the `ValueChanged` event.|  
  
> [!NOTE]
>  `FlashTrackBar` uses the <xref:System.EventArgs> class for event data and <xref:System.EventHandler> for the event delegate.  
  
 To handle the corresponding *EventName* events, `FlashTrackBar` overrides the following methods that it inherits from <xref:System.Windows.Forms.Control?displayProperty=nameWithType>:  
  
-   <xref:System.Windows.Forms.Control.OnPaint%2A>  
  
-   <xref:System.Windows.Forms.Control.OnMouseDown%2A>  
  
-   <xref:System.Windows.Forms.Control.OnMouseMove%2A>  
  
-   <xref:System.Windows.Forms.Control.OnMouseUp%2A>  
  
-   <xref:System.Windows.Forms.Control.OnResize%2A>  
  
 To handle the corresponding property-changed events, `FlashTrackBar` overrides the following methods that it inherits from <xref:System.Windows.Forms.Control?displayProperty=nameWithType>:  
  
-   <xref:System.Windows.Forms.Control.OnBackColorChanged%2A>  
  
-   <xref:System.Windows.Forms.Control.OnBackgroundImageChanged%2A>  
  
-   <xref:System.Windows.Forms.Control.OnTextChanged%2A>  
  
## Example  
 The `FlashTrackBar` control defines two UI type editors, `FlashTrackBarValueEditor` and `FlashTrackBarDarkenByEditor`, which are shown in the following code listings. The `HostApp` class uses the `FlashTrackBar` control on a Windows Form.  
  
 [!code-csharp[System.Windows.Forms.FlashTrackBar#1](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.FlashTrackBar/CS/FlashTrackBar.cs#1)]
 [!code-vb[System.Windows.Forms.FlashTrackBar#1](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.FlashTrackBar/VB/FlashTrackBar.vb#1)]  
  
 [!code-csharp[System.Windows.Forms.FlashTrackBar#10](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.FlashTrackBar/CS/FlashTrackBarDarkenByEditor.cs#10)]
 [!code-vb[System.Windows.Forms.FlashTrackBar#10](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.FlashTrackBar/VB/FlashTrackBarDarkenByEditor.vb#10)]  
  
 [!code-csharp[System.Windows.Forms.FlashTrackBar#20](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.FlashTrackBar/CS/FlashTrackBarValueEditor.cs#20)]
 [!code-vb[System.Windows.Forms.FlashTrackBar#20](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.FlashTrackBar/VB/FlashTrackBarValueEditor.vb#20)]  
  
 [!code-csharp[System.Windows.Forms.FlashTrackBar#30](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.FlashTrackBar/CS/HostApp.cs#30)]
 [!code-vb[System.Windows.Forms.FlashTrackBar#30](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.FlashTrackBar/VB/HostApp.vb#30)]  
  
## See Also  
 [Extending Design-Time Support](http://msdn.microsoft.com/library/d6ac8a6a-42fd-4bc8-bf33-b212811297e2)  
 [Windows Forms Control Development Basics](../../../../docs/framework/winforms/controls/windows-forms-control-development-basics.md)

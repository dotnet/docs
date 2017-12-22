---
title: "How to: Create Outlined Text"
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
  - "typography [WPF], linear gradient brush"
  - "outlined text [WPF]"
  - "gradient brush [WPF]"
  - "linear gradient brush [WPF]"
  - "typography [WPF], outline effects"
ms.assetid: 4aa3cf6e-1953-4f26-8230-7c1409e5f28d
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create Outlined Text
In most cases, when you are adding ornamentation to text strings in your [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] application, you are using text in terms of a collection of discrete characters, or glyphs. For example, you could create a linear gradient brush and apply it to the <xref:System.Windows.Controls.Control.Foreground%2A> property of a <xref:System.Windows.Controls.TextBox> object. When you display or edit the text box, the linear gradient brush is automatically applied to the current set of characters in the text string.  
  
 ![Text displayed with a linear gradient brush](../../../../docs/framework/wpf/advanced/media/outlinedtext01.jpg "OutlinedText01")  
Example of a linear gradient brush applied to a text box  
  
 However, you can also convert text into <xref:System.Windows.Media.Geometry> objects, allowing you to create other types of visually rich text. For example, you could create a <xref:System.Windows.Media.Geometry> object based on the outline of a text string.  
  
 ![Text outline using a linear gradient brush](../../../../docs/framework/wpf/advanced/media/outlinedtext02.jpg "OutlinedText02")  
Example of a linear gradient brush applied to the outline geometry of text  
  
 When text is converted to a <xref:System.Windows.Media.Geometry> object, it is no longer a collection of characters—you cannot modify the characters in the text string. However, you can affect the appearance of the converted text by modifying its stroke and fill properties. The stroke refers to the outline of the converted text; the fill refers to the area inside the outline of the converted text.  
  
 The following examples illustrate several ways of creating visual effects by modifying the stroke and fill of converted text.  
  
 ![Text with different colors for fill and stroke](../../../../docs/framework/wpf/advanced/media/outlinedtext03.jpg "OutlinedText03")  
Example of setting stroke and fill to different colors  
  
 ![Text with image brush applied to stroke](../../../../docs/framework/wpf/advanced/media/outlinedtext04.jpg "OutlinedText04")  
Example of an image brush applied to the stroke  
  
 It is also possible to modify the bounding box rectangle, or highlight, of the converted text. The following example illustrates a way to creating visual effects by modifying the stroke and highlight of converted text.  
  
 ![Text with image brush applied to stroke](../../../../docs/framework/wpf/advanced/media/outlinedtext05.jpg "OutlinedText05")  
Example of an image brush applied to the stroke and highlight  
  
## Example  
 The key to converting text to a <xref:System.Windows.Media.Geometry> object is to use the <xref:System.Windows.Media.FormattedText> object. Once you have created this object, you can use the <xref:System.Windows.Media.FormattedText.BuildGeometry%2A> and <xref:System.Windows.Media.FormattedText.BuildHighlightGeometry%2A> methods to convert the text to <xref:System.Windows.Media.Geometry> objects. The first method returns the geometry of the formatted text; the second method returns the geometry of the formatted text's bounding box. The following code example shows how to create a <xref:System.Windows.Media.FormattedText> object and to retrieve the geometries of the formatted text and its bounding box.  
  
 [!code-csharp[OutlineTextControlViewer#CreateText](../../../../samples/snippets/csharp/VS_Snippets_Wpf/OutlineTextControlViewer/CSharp/OutlineTextControl.cs#createtext)]
 [!code-vb[OutlineTextControlViewer#CreateText](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/OutlineTextControlViewer/visualbasic/outlinetextcontrol.vb#createtext)]  
  
 In order to display the retrieved the <xref:System.Windows.Media.Geometry> objects, you need to access the <xref:System.Windows.Media.DrawingContext> of the object that is displaying the converted text. In these code examples, this is done by creating a custom control object that is derived from a class that supports user-defined rendering.  
  
 To display <xref:System.Windows.Media.Geometry> objects in the custom control, provide an override for the <xref:System.Windows.UIElement.OnRender%2A> method. Your overridden method should use the <xref:System.Windows.Media.DrawingContext.DrawGeometry%2A> method to draw the <xref:System.Windows.Media.Geometry> objects.  
  
 [!code-csharp[OutlineTextControlViewer#OnRender](../../../../samples/snippets/csharp/VS_Snippets_Wpf/OutlineTextControlViewer/CSharp/OutlineTextControl.cs#onrender)]
 [!code-vb[OutlineTextControlViewer#OnRender](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/OutlineTextControlViewer/visualbasic/outlinetextcontrol.vb#onrender)]  
  
## See Also  
 [Drawing Formatted Text](../../../../docs/framework/wpf/advanced/drawing-formatted-text.md)

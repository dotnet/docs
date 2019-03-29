---
title: "How to: Create Text with a Shadow"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "typography [WPF], shadow effects"
  - "shadow effects in text [WPF]"
  - "text [WPF], shadowed"
ms.assetid: 6ab9c754-6001-4708-b479-5367f2fd1a35
---
# How to: Create Text with a Shadow
The examples in this section show how to create a shadow effect for displayed text.  
  
## Example  
 The <xref:System.Windows.Media.Effects.DropShadowEffect> object allows you to create a variety of drop shadow effects for [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] objects. The following example shows a drop shadow effect applied to text. In this case, the shadow is a soft shadow, which means the shadow color blurs.  
  
 ![Text shadow with Softness &#61; 0.25](./media/how-to-create-text-with-a-shadow/drop-shadow-text-effect.jpg) 
  
 You can control the width of a shadow by setting the <xref:System.Windows.Media.Effects.DropShadowEffect.ShadowDepth%2A> property. A value of `4.0` indicates a shadow width of 4 pixels. You can control the softness, or blur, of a shadow by modifying the <xref:System.Windows.Media.Effects.DropShadowEffect.BlurRadius%2A> property. A value of `0.0` indicates no blurring. The following code example shows how to create a soft shadow.  
  
 [!code-xaml[TextShadowSnippets#TextShadowSnippet1](~/samples/snippets/csharp/VS_Snippets_Wpf/TextShadowSnippets/CS/SingleShadows.xaml#textshadowsnippet1)]  
  
> [!NOTE]
>  These shadow effects do not go through the [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] text rendering pipeline. As a result, ClearType is disabled when using these effects.  
  
 The following example shows a hard drop shadow effect applied to text. In this case, the shadow is not blurred.  
  
 ![Text shadow with Softness &#61; 0](./media/how-to-create-text-with-a-shadow/text-shadow-softness.jpg) 
  
 You can create a hard shadow by setting the <xref:System.Windows.Media.Effects.DropShadowEffect.BlurRadius%2A> property to `0.0`, which indicates that no blurring is used. You can control the direction of the shadow by modifying the <xref:System.Windows.Media.Effects.DropShadowEffect.Direction%2A> property. Set the directional value of this property to a degree between `0` and `360`. The following illustration shows the directional values of the <xref:System.Windows.Media.Effects.DropShadowEffect.Direction%2A> property setting.  
  
 ![DropShadow degree setting of shadow](./media/how-to-create-text-with-a-shadow/drop-shadow-degree-setting.png)
  
 The following code example shows how to create a hard shadow.  
  
 [!code-xaml[TextShadowSnippets#TextShadowSnippet2](~/samples/snippets/csharp/VS_Snippets_Wpf/TextShadowSnippets/CS/SingleShadows.xaml#textshadowsnippet2)]  
  
## Using a Blur Effect  
 A <xref:System.Windows.Media.Effects.BlurBitmapEffect> can be used to create a shadow-like effect that can be placed behind a text object. A blur bitmap effect applied to text blurs the text evenly in all directions.  
  
 The following example shows a blur effect applied to text.  
  
 ![Text shadow using a BlurBitmapEffect](./media/how-to-create-text-with-a-shadow/text-shadow-blur-effect.jpg)  
  
 The following code example shows how to create a blur effect.  
  
 [!code-xaml[TextShadowSnippets#TextShadowSnippet6](~/samples/snippets/csharp/VS_Snippets_Wpf/TextShadowSnippets/CS/BlurShadows.xaml#textshadowsnippet6)]  
  
## Using a Translate Transform  
 A <xref:System.Windows.Media.TranslateTransform> can be used to create a shadow-like effect that can be placed behind a text object.  
  
 The following code example uses a <xref:System.Windows.Media.TranslateTransform> to offset text. In this example, a slightly offset copy of text below the primary text creates a shadow effect.  
  
 ![Text shadow using a TranslateTransform](./media/how-to-create-text-with-a-shadow/text-transform-shadow-effect.jpg)    
  
 The following code example shows how to create a transform for a shadow effect.  
  
 [!code-xaml[TextShadowSnippets#TextShadowSnippet7](~/samples/snippets/csharp/VS_Snippets_Wpf/TextShadowSnippets/CS/TransformShadows.xaml#textshadowsnippet7)]

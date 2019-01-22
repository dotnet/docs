---
title: "How to: Paint an Area with a Solid Color"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "solid colors [WPF], painting with"
  - "brushes [WPF], painting with solid colors"
  - "painting [WPF], with solid colors"
ms.assetid: 5d27d8a7-4bd7-4063-bdf3-2c5c0f19f9d3
---
# How to: Paint an Area with a Solid Color
To paint an area with a solid color, you can use a predefined system brush, such as <xref:System.Windows.Media.Brushes.Red%2A> or <xref:System.Windows.Media.Brushes.Blue%2A>, or you can create a new <xref:System.Windows.Media.SolidColorBrush> and describe its <xref:System.Windows.Media.SolidColorBrush.Color%2A> using alpha, red, green, and blue values. In XAML, you may also paint an area with a solid color by using hexidecimal notation.  
  
 The following examples uses each of these techniques to paint a <xref:System.Windows.Shapes.Rectangle> blue.  
  
## Example  
 **Using a Predefined Brush**  
  
 In the following example uses the predefined brush <xref:System.Windows.Media.Brushes.Blue%2A> to paint a rectangle blue.  
  
 [!code-xaml[brushsamples_snip#_graphicsmm_PredefinedBrush1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/brushsamples_snip/CS/SolidColorBrushExample.xaml#_graphicsmm_predefinedbrush1)]  
  
 [!code-csharp[brushsamples_procedural_snip#_graphicsmm_PredefinedBrush1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/brushsamples_procedural_snip/CSharp/SolidColorBrushExample.cs#_graphicsmm_predefinedbrush1)]  
  
 **Using Hexadecimal Notation**  
  
 The next example uses 8-digit hexadecimal notation to paint a rectangle blue.  
  
 [!code-xaml[brushsamples_snip#_graphicsmm_HexNotation8Digit1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/brushsamples_snip/CS/SolidColorBrushExample.xaml#_graphicsmm_hexnotation8digit1)]  
  
 **Using ARGB Values**  
  
 The next example creates a <xref:System.Windows.Media.SolidColorBrush> and describes its <xref:System.Windows.Media.SolidColorBrush.Color%2A> using the ARGB values for the color blue.  
  
 [!code-xaml[brushsamples_snip#_graphicsmm_RgbNotation1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/brushsamples_snip/CS/SolidColorBrushExample.xaml#_graphicsmm_rgbnotation1)]  
  
 [!code-csharp[brushsamples_procedural_snip#_graphicsmm_RgbNotation1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/brushsamples_procedural_snip/CSharp/SolidColorBrushExample.cs#_graphicsmm_rgbnotation1)]  
  
 For other ways of describing color, see the <xref:System.Windows.Media.Color> structure.  
  
 **Related Topics**  
  
 For more information about <xref:System.Windows.Media.SolidColorBrush> and additional examples, see the [Painting with Solid Colors and Gradients Overview](../../../../docs/framework/wpf/graphics-multimedia/painting-with-solid-colors-and-gradients-overview.md) overview.  
  
 This code example is part of a larger example provided for the <xref:System.Windows.Media.SolidColorBrush> class. For the complete sample, see the [Brushes Sample](https://go.microsoft.com/fwlink/?LinkID=159973).  
  
## See also
- <xref:System.Windows.Media.Brushes>

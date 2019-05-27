---
title: "How to: Use a Drawing as an Image Source"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "graphics [WPF], drawings [WPF], as image sources"
  - "image sources [WPF], drawings"
  - "drawings [WPF], as image sources"
ms.assetid: dcf71c7b-9e86-4b8e-8e39-0d0ce0389ef4
---
# How to: Use a Drawing as an Image Source
This example shows how to use a <xref:System.Windows.Media.Drawing> as the <xref:System.Windows.Controls.Image.Source%2A> for an <xref:System.Windows.Controls.Image> control. To display a <xref:System.Windows.Media.Drawing> with an <xref:System.Windows.Controls.Image> control, use a <xref:System.Windows.Media.DrawingImage> as the <xref:System.Windows.Controls.Image> control's <xref:System.Windows.Controls.Image.Source%2A> and set the <xref:System.Windows.Media.DrawingImage> object's <xref:System.Windows.Media.DrawingImage.Drawing%2A?displayProperty=nameWithType> property to the drawing you want to display.  
  
## Example  
 The following example uses a <xref:System.Windows.Media.DrawingImage> and an <xref:System.Windows.Controls.Image> control to display a <xref:System.Windows.Media.GeometryDrawing>. This example produces the following output:  
  
 ![A GeometryDrawing of two ellipses](./media/graphicsmm-geodraw.jpg "graphicsmm_geodraw")  
A DrawingImage  
  
 [!code-csharp[DrawingMiscSnippets_snip#DrawingImageExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/DrawingMiscSnippets_snip/CSharp/DrawingImageExample.cs#drawingimageexamplewholepage)]
 [!code-xaml[DrawingMiscSnippets_snip#DrawingImageExampleWholePage](~/samples/snippets/xaml/VS_Snippets_Wpf/DrawingMiscSnippets_snip/XAML/DrawingImageExample.xaml#drawingimageexamplewholepage)]  
  
## See also

- <xref:System.Windows.Freezable.Freeze%2A>
- [Draw an Image Using ImageDrawing](how-to-draw-an-image-using-imagedrawing.md)
- [Drawing Objects Overview](drawing-objects-overview.md)
- [Freezable Objects Overview](../advanced/freezable-objects-overview.md)
- [PresentationOptions:Freeze Attribute](../advanced/presentationoptions-freeze-attribute.md)

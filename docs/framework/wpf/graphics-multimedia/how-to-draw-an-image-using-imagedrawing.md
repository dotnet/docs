---
title: "How to: Draw an Image Using ImageDrawing"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "drawing [WPF], images"
  - "graphics [WPF], drawing images"
  - "images [WPF], drawing"
ms.assetid: df28ab41-25fb-4ab3-b51d-7f695b24f55e
---
# How to: Draw an Image Using ImageDrawing
This example shows how to use an <xref:System.Windows.Media.ImageDrawing> to draw an image. An <xref:System.Windows.Media.ImageDrawing> enables you display an <xref:System.Windows.Media.ImageSource> with a <xref:System.Windows.Media.DrawingBrush>, <xref:System.Windows.Media.DrawingImage>, or <xref:System.Windows.Media.Visual>. To draw an image, you create an <xref:System.Windows.Media.ImageDrawing> and set its <xref:System.Windows.Media.ImageDrawing.ImageSource%2A?displayProperty=nameWithType> and <xref:System.Windows.Media.ImageDrawing.Rect%2A?displayProperty=nameWithType> properties. The <xref:System.Windows.Media.ImageDrawing.ImageSource%2A?displayProperty=nameWithType> property specifies the image to draw, and the <xref:System.Windows.Media.ImageDrawing.Rect%2A?displayProperty=nameWithType> property specifies the position and size of each image.  
  
## Example  
 The following example creates a composite drawing using four <xref:System.Windows.Media.ImageDrawing> objects. This example produces the following image:  
  
 ![Several DrawingImage objects](./media/graphicsmm-imagedrawingexample.jpg "graphicsmm_ImageDrawingExample")  
Four ImageDrawing objects  
  
 [!code-csharp[DrawingMiscSnippets_snip#ImageDrawingExample](~/samples/snippets/csharp/VS_Snippets_Wpf/DrawingMiscSnippets_snip/CSharp/ImageDrawingExample.cs#imagedrawingexample)]
 [!code-xaml[DrawingMiscSnippets_snip#ImageDrawingExample](~/samples/snippets/xaml/VS_Snippets_Wpf/DrawingMiscSnippets_snip/XAML/ImageDrawingExample.xaml#imagedrawingexample)]  
  
 For an example showing a simple way to display an image without using <xref:System.Windows.Media.ImageDrawing>, see [Use the Image Element](../controls/how-to-use-the-image-element.md).  
  
## See also

- <xref:System.Windows.Freezable.Freeze%2A>
- <xref:System.Windows.Controls.Image>
- [Drawing Objects Overview](drawing-objects-overview.md)
- [Freezable Objects Overview](../advanced/freezable-objects-overview.md)
- [PresentationOptions:Freeze Attribute](../advanced/presentationoptions-freeze-attribute.md)

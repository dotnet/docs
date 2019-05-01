---
title: "How to: Create a Bitmap from a Visual"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "bitmaps [WPF], rendering from visuals"
  - "visuals [WPF], rendering to bitmaps"
ms.assetid: 103fc7f5-7306-4026-9d61-2005e79959f3
---
# How to: Create a Bitmap from a Visual
This example shows how you can create a bitmap from a <xref:System.Windows.Media.Visual>. A <xref:System.Windows.Media.DrawingVisual> is rendered with <xref:System.Windows.Media.FormattedText>. The <xref:System.Windows.Media.Visual> is then rendered to the <xref:System.Windows.Media.Imaging.RenderTargetBitmap> creating a bitmap of the given text.  
  
## Example  
 [!code-csharp[ImagingSnippetGallery_procedural_snip#CreateRTBImage](~/samples/snippets/csharp/VS_Snippets_Wpf/ImagingSnippetGallery_procedural_snip/CSharp/RenderTargetBitmapExample.cs#creatertbimage)]
 [!code-vb[ImagingSnippetGallery_procedural_snip#CreateRTBImage](~/samples/snippets/visualbasic/VS_Snippets_Wpf/ImagingSnippetGallery_procedural_snip/VB/RenderTargetBitmapExample.vb#creatertbimage)]  
  
## See also

- <xref:System.Windows.Media.DrawingContext>
- [Imaging Overview](imaging-overview.md)
- [Drawing Objects Overview](drawing-objects-overview.md)
- [Using DrawingVisual Objects](using-drawingvisual-objects.md)

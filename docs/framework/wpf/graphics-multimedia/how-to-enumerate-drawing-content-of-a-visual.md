---
title: "How to: Enumerate Drawing Content of a Visual"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "retrieving the DrawingGroup value of a Visual [WPF]"
  - "enumerating the contents of a Visual [WPF]"
ms.assetid: 2974ddb3-2997-4713-8fd2-e93d549c58a8
---
# How to: Enumerate Drawing Content of a Visual
The <xref:System.Windows.Media.Drawing> object provide an object model for enumerating the contents of a <xref:System.Windows.Media.Visual>.  
  
## Example  
 The following example uses the <xref:System.Windows.Media.VisualTreeHelper.GetDrawing%2A> method to retrieve the <xref:System.Windows.Media.DrawingGroup> value of a <xref:System.Windows.Media.Visual> and enumerate it.  
  
> [!NOTE]
>  When you are enumerating the contents of the visual, you are retrieving <xref:System.Windows.Media.Drawing> objects, and not the underlying representation of the render data as a vector graphics instruction list. For more information, see [WPF Graphics Rendering Overview](wpf-graphics-rendering-overview.md).  
  
 [!code-csharp[DrawingMiscSnippets_snip#GraphicsMMRetrieveDrawings](~/samples/snippets/csharp/VS_Snippets_Wpf/DrawingMiscSnippets_snip/CSharp/EnumerateDrawingsExample.xaml.cs#graphicsmmretrievedrawings)]  
  
## See also

- <xref:System.Windows.Media.Drawing>
- <xref:System.Windows.Media.DrawingGroup>
- <xref:System.Windows.Media.VisualTreeHelper>
- [Drawing Objects Overview](drawing-objects-overview.md)
- [WPF Graphics Rendering Overview](wpf-graphics-rendering-overview.md)

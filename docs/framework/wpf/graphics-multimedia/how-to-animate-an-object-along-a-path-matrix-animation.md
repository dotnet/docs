---
title: "How to: Animate an Object Along a Path (Matrix Animation)"
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
  - "animation [WPF], objects along paths (matrix animation)"
  - "matrix animation [WPF]"
ms.assetid: 7000e697-1414-468c-b915-cf66062fc49e
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Animate an Object Along a Path (Matrix Animation)
This example shows how to use the <xref:System.Windows.Media.Animation.MatrixAnimationUsingPath> class to animate an object along a path that is defined by a <xref:System.Windows.Media.PathGeometry>.  
  
## Example  
 The following example animates an object along a path by doing the following:  
  
-   Applies a <xref:System.Windows.Media.MatrixTransform> to the object in order to move it.  
  
-   Defines the path by using a <xref:System.Windows.Media.PathGeometry>.  
  
-   Creates a <xref:System.Windows.Media.Animation.MatrixAnimationUsingPath> and uses it to animate the <xref:System.Windows.Media.Matrix> property of the <xref:System.Windows.Media.MatrixTransform>. The <xref:System.Windows.Media.Animation.MatrixAnimationUsingPath> takes the <xref:System.Windows.Media.PathGeometry> and uses it to generate <xref:System.Windows.Media.Matrix> values.  
  
 [!code-xaml[PathAnimationGallery_snippet#MatrixAnimationUsingPathWholePage](../../../../samples/snippets/csharp/VS_Snippets_Wpf/PathAnimationGallery_snippet/CS/matrixanimationusingpathexample.xaml#matrixanimationusingpathwholepage)]  
  
 [!code-csharp[PathAnimationGallery_procedural_snip#MatrixAnimationUsingPathWholePage](../../../../samples/snippets/csharp/VS_Snippets_Wpf/PathAnimationGallery_procedural_snip/CSharp/MatrixAnimationUsingPathExample.cs#matrixanimationusingpathwholepage)]
 [!code-vb[PathAnimationGallery_procedural_snip#MatrixAnimationUsingPathWholePage](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/PathAnimationGallery_procedural_snip/VisualBasic/MatrixAnimationUsingPathExample.vb#matrixanimationusingpathwholepage)]  
  
 For the complete sample, see [Path Animation Sample](http://go.microsoft.com/fwlink/?LinkID=160028). For more information about geometric paths, see the [Geometry Overview](../../../../docs/framework/wpf/graphics-multimedia/geometry-overview.md).  
  
## See Also  
 [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md)  
 [Path Animation Sample](http://go.microsoft.com/fwlink/?LinkID=160028)  
 [Path Animation How-to Topics](../../../../docs/framework/wpf/graphics-multimedia/path-animation-how-to-topics.md)

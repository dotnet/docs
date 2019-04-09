---
title: "How to: Animate a 3-D Rotation Using Quaternions"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "quaternions [WPF]"
  - "animation [WPF], 3-D translations [WPF], with quaternions"
  - "3-D translations [WPF], animating [WPF], with quaternions"
ms.assetid: adca9cb1-066b-4de8-abbb-6b4007579ee7
---
# How to: Animate a 3-D Rotation Using Quaternions
This example shows how to animate a rotation of a 3-D object using quaternions.  
  
 The code below shows a <xref:System.Windows.Media.Media3D.QuaternionRotation3D> used as the value for the <xref:System.Windows.Media.Media3D.RotateTransform3D.Rotation%2A> property of a <xref:System.Windows.Media.Media3D.RotateTransform3D>.  
  
 [!code-xaml[Animation3DGallery_snip#QuaternionAnimationExampleInline1](~/samples/snippets/csharp/VS_Snippets_Wpf/Animation3DGallery_snip/CS/QuaternionAnimationExample.xaml#quaternionanimationexampleinline1)]  
  
 This <xref:System.Windows.Media.Media3D.QuaternionRotation3D> is animated with a <xref:System.Windows.Media.Animation.QuaternionAnimation> within a <xref:System.Windows.Media.Animation.Storyboard> using the code below.  
  
 [!code-xaml[Animation3DGallery_snip#QuaternionAnimationExampleInline2](~/samples/snippets/csharp/VS_Snippets_Wpf/Animation3DGallery_snip/CS/QuaternionAnimationExample.xaml#quaternionanimationexampleinline2)]  
  
## Example  
 The following code shows the entire sample.  
  
 [!code-xaml[Animation3DGallery_snip#QuaternionAnimationExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/Animation3DGallery_snip/CS/QuaternionAnimationExample.xaml#quaternionanimationexamplewholepage)]  
  
## See also

- [Animation Overview](animation-overview.md)
- [Create a 3-D Scene](how-to-create-a-3-d-scene.md)
- [3-D Graphics Overview](3-d-graphics-overview.md)
- [Transforms Overview](transforms-overview.md)
- [Animate a 3-D Rotation Using Storyboards](how-to-animate-a-3-d-rotation-using-storyboards.md)
- [Animate a 3-D Rotation Using Rotation3DAnimation](how-to-animate-a-3-d-rotation-using-rotation3danimation.md)

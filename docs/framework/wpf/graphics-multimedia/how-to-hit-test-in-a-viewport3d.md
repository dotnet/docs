---
title: "How to: Hit Test in a Viewport3D"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "3-D visuals [WPF], hit-testing for"
  - "hit tests [WPF], for 3-D visuals"
  - "Viewport3D [WPF]"
ms.assetid: 42bfbd99-c7c6-43f1-940b-90448faa412e
---
# How to: Hit Test in a Viewport3D
This example shows how to hit test for 3D Visuals in a <xref:System.Windows.Controls.Viewport3D>.  
  
 Because <xref:System.Windows.Media.VisualTreeHelper.HitTest%2A> returns 2D and 3D information, it is possible to iterate through the test results to read only 3D results.  
  
 [!code-csharp[HitTest3D#HitTest3D3DN4](~/samples/snippets/csharp/VS_Snippets_Wpf/HitTest3D/CSharp/Window1.xaml.cs#hittest3d3dn4)]
 [!code-vb[HitTest3D#HitTest3D3DN4](~/samples/snippets/visualbasic/VS_Snippets_Wpf/HitTest3D/visualbasic/window1.xaml.vb#hittest3d3dn4)]  
  
 The <xref:System.Windows.Media.HitTestResultBehavior> in the following code determines how the hit test results are processed.  `UpdateResultInfo` and `UpdateMaterial` are locally defined methods.  
  
 [!code-csharp[HitTest3D#HitTest3D3DN5](~/samples/snippets/csharp/VS_Snippets_Wpf/HitTest3D/CSharp/Window1.xaml.cs#hittest3d3dn5)]
 [!code-vb[HitTest3D#HitTest3D3DN5](~/samples/snippets/visualbasic/VS_Snippets_Wpf/HitTest3D/visualbasic/window1.xaml.vb#hittest3d3dn5)]  
 

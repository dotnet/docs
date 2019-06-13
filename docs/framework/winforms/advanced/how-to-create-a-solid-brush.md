---
title: "How to: Create a Solid Brush"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "solid color brushes"
  - "brushes [Windows Forms], examples"
  - "brushes [Windows Forms], creating solid"
ms.assetid: 85c3fe7d-fb1d-4591-8a9f-d75b556b90af
---
# How to: Create a Solid Brush
This example creates a <xref:System.Drawing.SolidBrush> object that can be used by a <xref:System.Drawing.Graphics> object for filling shapes.  
  
## Example  
 [!code-cpp[System.Drawing.ConceptualHowTos#1](~/samples/snippets/cpp/VS_Snippets_Winforms/System.Drawing.ConceptualHowTos/cpp/form1.cpp#1)]
 [!code-csharp[System.Drawing.ConceptualHowTos#1](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.ConceptualHowTos/CS/form1.cs#1)]
 [!code-vb[System.Drawing.ConceptualHowTos#1](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.ConceptualHowTos/VB/form1.vb#1)]  
  
## Robust Programming  
 After you have finished using them, you should call <xref:System.IDisposable.Dispose%2A> on objects that consume system resources, such as brush objects.  
  
## See also

- <xref:System.Drawing.SolidBrush>
- <xref:System.Drawing.Brush>
- [Getting Started with Graphics Programming](getting-started-with-graphics-programming.md)
- [Brushes and Filled Shapes in GDI+](brushes-and-filled-shapes-in-gdi.md)
- [Using a Brush to Fill Shapes](using-a-brush-to-fill-shapes.md)

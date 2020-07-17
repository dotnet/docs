---
title: "How to: Draw an Outlined Shape"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
f1_keywords: 
  - "Graphics.DrawEllipse"
helpviewer_keywords: 
  - "ellipses [Windows Forms], drawing"
  - "circles [Windows Forms], drawing"
  - "drawing [Windows Forms], shapes"
  - "circular shapes"
  - "forms [Windows Forms], drawing circular shapes"
  - "circles"
  - "outlined shapes [Windows Forms], examples"
  - "outlined shapes [Windows Forms], drawing"
  - "drawing [Windows Forms], circular shapes"
  - "shapes [Windows Forms], drawing"
ms.assetid: f4f9214c-607e-407d-8cdd-6549f0278451
---
# How to: Draw an Outlined Shape
This example draws outlined ellipses and rectangles on a form.  
  
## Example  
 [!code-cpp[System.Drawing.ConceptualHowTos#6](~/samples/snippets/cpp/VS_Snippets_Winforms/System.Drawing.ConceptualHowTos/cpp/form1.cpp#6)]
 [!code-csharp[System.Drawing.ConceptualHowTos#6](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.ConceptualHowTos/CS/form1.cs#6)]
 [!code-vb[System.Drawing.ConceptualHowTos#6](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.ConceptualHowTos/VB/form1.vb#6)]  
  
## Compiling the Code  
 You cannot call this method in the <xref:System.Windows.Forms.Form.Load> event handler. The drawn content will not be redrawn if the form is resized or obscured by another form. To make your content automatically repaint, you should override the <xref:System.Windows.Forms.Control.OnPaint%2A> method.  
  
## Robust Programming  
 You should always call <xref:System.IDisposable.Dispose%2A> on any objects that consume system resources, such as <xref:System.Drawing.Pen> and <xref:System.Drawing.Graphics> objects.  
  
## See also

- <xref:System.Drawing.Graphics.DrawEllipse%2A>
- <xref:System.Windows.Forms.Control.OnPaint%2A>
- <xref:System.Drawing.Graphics.DrawRectangle%2A>
- [Getting Started with Graphics Programming](getting-started-with-graphics-programming.md)
- [Using a Pen to Draw Lines and Shapes](using-a-pen-to-draw-lines-and-shapes.md)
- [Graphics and Drawing in Windows Forms](graphics-and-drawing-in-windows-forms.md)

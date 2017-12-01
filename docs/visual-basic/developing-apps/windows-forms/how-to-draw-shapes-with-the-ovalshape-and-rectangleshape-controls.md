---
title: "How to: Draw Shapes with the OvalShape and RectangleShape Controls (Visual Studio)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "OvalShape control [Visual Basic]"
  - "shapes, drawing"
  - "RectangleShape control [Visual Basic]"
ms.assetid: 0275b4c6-7a13-46c8-90f3-61db308c6b5d
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Draw Shapes with the OvalShape and RectangleShape Controls (Visual Studio)
You can use the <xref:Microsoft.VisualBasic.PowerPacks.OvalShape> control to draw circles or ovals on a form or container, both at design time and at run time. You can use the <xref:Microsoft.VisualBasic.PowerPacks.RectangleShape> control to draw squares, rectangles, or rectangles with rounded corners on a form or container. You can also use this control to draw shapes both at design time and at run time.  
  
 You can customize the appearance of a shape by changing the width, color, and style of the border. The background of a shape is transparent by default; you can customize the background to display a solid color, a pattern, a gradient fill (transitioning from one color to another), or an image.  
  
### To draw a simple shape at design time  
  
1.  Drag the <xref:Microsoft.VisualBasic.PowerPacks.OvalShape> or <xref:Microsoft.VisualBasic.PowerPacks.RectangleShape> control from the **Visual Basic PowerPacks** tab (to install, see [Visual Basic Power Packs Controls](../../../visual-basic/developing-apps/windows-forms/power-packs-controls.md))in the **Toolbox** to a form or container control.  
  
2.  Drag the sizing and move handles to size and position the shape.  
  
     You can also size and position the shape by changing the `Size` and `Position` properties in the **Properties** window.  
  
     To create a rectangle with rounded corners, select the `CornerRadius` property in the **Properties** window and set it to a value that is greater than 0.  
  
3.  In the **Properties** window, optionally set additional properties to change the appearance of the shape.  
  
### To draw a simple shape at run time  
  
1.  On the **Project** menu, click **Add Reference**.  
  
2.  In the **Add Reference** dialog box, select **Microsoft.VisualBasic.PowerPacks.VS**, and then click **OK**.  
  
3.  In the **Code Editor**, add an `Imports` or `using` statement at the top of the module:  
  
```vb  
Imports Microsoft.VisualBasic.PowerPacks  
```  
  
```csharp  
using Microsoft.VisualBasic.PowerPacks;  
```  
  
4.  Add the following code in an `Event` procedure:  
  
     [!code-csharp[VbPowerpacksShape#1](../../../visual-basic/developing-apps/windows-forms/codesnippet/CSharp/how-to-draw-shapes-with-the-ovalshape-and-rectangleshape-controls_1.cs)]
     [!code-vb[VbPowerpacksShape#1](../../../visual-basic/developing-apps/windows-forms/codesnippet/VisualBasic/how-to-draw-shapes-with-the-ovalshape-and-rectangleshape-controls_1.vb)]  
  
## Customizing Shapes  
 When you use the default settings, the <xref:Microsoft.VisualBasic.PowerPacks.OvalShape> and <xref:Microsoft.VisualBasic.PowerPacks.RectangleShape> controls are displayed with a solid black border that is one pixel wide and a transparent background. You can change the width, style, and color of the border by setting properties. Additional properties enable you to change the background of a shape to a solid color, a pattern, a gradient fill, or an image.  
  
 Before you change the background of a shape, you should know how several of the properties interact.  
  
-   The <xref:Microsoft.VisualBasic.PowerPacks.SimpleShape.BackColor%2A> property setting has no effect unless the <xref:Microsoft.VisualBasic.PowerPacks.SimpleShape.BackStyle%2A> property is set to <xref:Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque>.  
  
-   If the <xref:Microsoft.VisualBasic.PowerPacks.SimpleShape.FillStyle%2A> property is set to <xref:Microsoft.VisualBasic.PowerPacks.FillStyle.Solid>, the <xref:Microsoft.VisualBasic.PowerPacks.SimpleShape.FillColor%2A> overrides the <xref:Microsoft.VisualBasic.PowerPacks.SimpleShape.BackColor%2A>.  
  
-   If the <xref:Microsoft.VisualBasic.PowerPacks.SimpleShape.FillStyle%2A> property is set to a pattern value such as <xref:Microsoft.VisualBasic.PowerPacks.FillStyle.Horizontal> or <xref:Microsoft.VisualBasic.PowerPacks.FillStyle.Vertical>, the pattern will be displayed in the <xref:Microsoft.VisualBasic.PowerPacks.SimpleShape.FillColor%2A>. The background will be displayed in the <xref:Microsoft.VisualBasic.PowerPacks.SimpleShape.BackColor%2A>, provided that the <xref:Microsoft.VisualBasic.PowerPacks.SimpleShape.BackStyle%2A> property is set to <xref:Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque>.  
  
-   In order to display a gradient fill, the <xref:Microsoft.VisualBasic.PowerPacks.SimpleShape.FillStyle%2A> property must be set to <xref:Microsoft.VisualBasic.PowerPacks.FillStyle.Solid> and the <xref:Microsoft.VisualBasic.PowerPacks.SimpleShape.FillGradientStyle%2A> property must be set to a value other than <xref:Microsoft.VisualBasic.PowerPacks.FillGradientStyle.None>.  
  
-   Setting the <xref:Microsoft.VisualBasic.PowerPacks.SimpleShape.BackgroundImage%2A> property to an image overrides all other background settings.  
  
#### To draw a circle that has a custom border  
  
1.  Drag the `OvalShape` control from the **Visual Basic PowerPacks** tab in the **Toolbox** to a form or container control.  
  
2.  In the **Properties** window, in the `Size` property, set `Height` and `Width` to equal values.  
  
3.  Set the `BorderColor` property to the color that you want.  
  
4.  Set the `BorderStyle` property to any value other than `Solid`.  
  
5.  Set the `BorderWidth` to the size that you want, in pixels.  
  
#### To draw a circle that has a solid fill  
  
1.  Drag the `OvalShape` control from the **Visual Basic PowerPacks** tab in the **Toolbox** to a form or container control.  
  
2.  In the **Properties** window, in the `Size` property, set `Height` and `Width` to equal values.  
  
3.  Set the `BackColor` property to the color that you want.  
  
4.  Set the `BackStyle` property to `Opaque`.  
  
#### To draw a circle that has a patterned fill  
  
1.  Drag the `OvalShape` control from the **Visual Basic PowerPacks** tab in the **Toolbox** to a form or container control.  
  
2.  In the **Properties** window, in the `Size` property, set `Height` and `Width` to equal values.  
  
3.  Set the `BackColor` property to the color that you want for the background.  
  
4.  Set the `BackStyle` property to `Opaque`.  
  
5.  Set the `FillColor` property to the color that you want for the pattern.  
  
6.  Set the `FillStyle` property to any value other than `Transparent` or `Solid`.  
  
#### To draw a circle that has a gradient fill  
  
1.  Drag the `OvalShape` control from the **Visual Basic PowerPacks** tab in the **Toolbox** to a form or container control.  
  
2.  In the **Properties** window, in the `Size` property, set `Height` and `Width` to equal values.  
  
3.  Set the `FillColor` property to the color that you want for the starting color.  
  
4.  Set the `FillGradientColor` property to the color that you want for the ending color.  
  
5.  Set the `FillGradientStyle` property to a value other than `None`.  
  
#### To draw a circle that is filled with an image  
  
1.  Drag the `OvalShape` control from the **Visual Basic PowerPacks** tab in the **Toolbox** to a form or container control.  
  
2.  In the **Properties** window, in the `Size` property, set `Height` and `Width` to equal values.  
  
3.  Select the `BackgroundImage` property and click the **ellipsis** button (...).  
  
4.  In the **Select Resource** dialog box, select an image to display. If no image resources are listed, click **Import** to browse to the location of an image.  
  
5.  Click **OK** to insert the image.  
  
## See Also  
 <xref:Microsoft.VisualBasic.PowerPacks.OvalShape>  
 <xref:Microsoft.VisualBasic.PowerPacks.RectangleShape>  
 [Introduction to the Line and Shape Controls](../../../visual-basic/developing-apps/windows-forms/introduction-to-the-line-and-shape-controls-visual-studio.md)  
 [How to: Draw Lines with the LineShape Control](../../../visual-basic/developing-apps/windows-forms/how-to-draw-lines-with-the-lineshape-control-visual-studio.md)

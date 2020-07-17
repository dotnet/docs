---
title: Custom painting for a control 
description: Learn about how to customize the appearance of a control through the OnPaint method and Paint event in Windows Forms for .NET.
ms.date: 06/15/2020
ms.topic: overview
dev_langs:
  - "csharp"
  - "vb"
f1_keywords: 
  - "OnPaint"
helpviewer_keywords: 
  - "controls [Windows Forms], user controls"
  - "controls [Windows Forms], types of"
  - "composite controls [Windows Forms]"
  - "extended controls [Windows Forms]"
  - "controls [Windows Forms], extended"
  - "user controls [Windows Forms]"
  - "custom controls [Windows Forms]"
  - "controls [Windows Forms], composite"
---

# Painting and drawing on controls (Windows Forms .NET)

Custom painting of controls is one of the many complicated tasks made easy by Windows Forms.

When authoring a custom control, you have many options available to handle your control's graphical appearance. If you're authoring a [custom control](custom.md#custom-controls), that is, a control that inherits from <xref:System.Windows.Forms.Control>, you must provide code to render its graphical representation.

If you're creating a [composite control](custom.md#composite-controls), that is a control that inherits from <xref:System.Windows.Forms.UserControl> or one of the existing Windows Forms controls, you may override the standard graphical representation and provide your own graphics code.

If you want to provide custom rendering for an existing control without creating a new control, your options become more limited. However, there are still a wide range of graphical possibilities for your controls and applications.

The following elements are involved in control rendering:

- The drawing functionality provided by the base class <xref:System.Windows.Forms.Control?displayProperty=nameWithType>.
- The essential elements of the GDI graphics library.
- The geometry of the drawing region.
- The procedure for freeing graphics resources.

## Drawing provided by control

The base class <xref:System.Windows.Forms.Control> provides drawing functionality through its <xref:System.Windows.Forms.Control.Paint> event. A control raises the <xref:System.Windows.Forms.Control.Paint> event whenever it needs to update its display. For more information about events in the .NET, see [Handling and raising events](../../standard/events/index.md).

The event data class for the <xref:System.Windows.Forms.Control.Paint> event, <xref:System.Windows.Forms.PaintEventArgs>, holds the data needed for drawing a control - a handle to a graphics object and a rectangle that represents the region to draw in.

```csharp
public class PaintEventArgs : EventArgs, IDisposable
{

    public System.Drawing.Rectangle ClipRectangle {get;}
    public System.Drawing.Graphics Graphics {get;}

    // Other properties and methods.
}
```

```vb
Public Class PaintEventArgs
    Inherits EventArgs
    Implements IDisposable

    Public ReadOnly Property ClipRectangle As System.Drawing.Rectangle
    Public ReadOnly Property Graphics() As System.Drawing.Graphics

    ' Other properties and methods.
End Class
```

<xref:System.Drawing.Graphics> is a managed class that encapsulates drawing functionality, as described in the discussion of GDI later in this article. The <xref:System.Windows.Forms.PaintEventArgs.ClipRectangle%2A> is an instance of the <xref:System.Drawing.Rectangle> structure and defines the available area in which a control can draw. A control developer can compute the <xref:System.Windows.Forms.PaintEventArgs.ClipRectangle%2A> using the <xref:System.Windows.Forms.PaintEventArgs.ClipRectangle%2A> property of a control, as described in the discussion of geometry later in this article.

### OnPaint

A control must provide rendering logic by overriding the <xref:System.Windows.Forms.Control.OnPaint%2A> method that it inherits from <xref:System.Windows.Forms.Control>. <xref:System.Windows.Forms.Control.OnPaint%2A> gets access to a graphics object and a rectangle to draw in through the <xref:System.Drawing.Design.PaintValueEventArgs.Graphics%2A> and the <xref:System.Windows.Forms.PaintEventArgs.ClipRectangle%2A> properties of the <xref:System.Windows.Forms.PaintEventArgs> instance passed to it.

The following code uses the `System.Drawing` namespace:

:::code language="csharp" source="./snippets/custom-painting-drawing/cs/UserControl1.cs" id="OnPaintMethod":::

:::code language="vb" source="./snippets/custom-painting-drawing/vb/UserControl1.vb" id="OnPaintMethod":::

The <xref:System.Windows.Forms.Control.OnPaint%2A> method of the base <xref:System.Windows.Forms.Control> class doesn't implement any drawing functionality but merely invokes the event delegates that are registered with the <xref:System.Windows.Forms.Control.Paint> event. When you override <xref:System.Windows.Forms.Control.OnPaint%2A>, you should typically invoke the <xref:System.Windows.Forms.Control.OnPaint%2A> method of the base class so that registered delegates receive the <xref:System.Windows.Forms.Control.Paint> event. However, controls that paint their entire surface shouldn't invoke the base class's <xref:System.Windows.Forms.Control.OnPaint%2A>, as this introduces flicker.

> [!NOTE]
> Don't invoke <xref:System.Windows.Forms.Control.OnPaint%2A> directly from your control; instead, invoke the <xref:System.Windows.Forms.Control.Invalidate%2A> method (inherited from <xref:System.Windows.Forms.Control>) or some other method that invokes <xref:System.Windows.Forms.Control.Invalidate%2A>. The <xref:System.Windows.Forms.Control.Invalidate%2A> method in turn invokes <xref:System.Windows.Forms.Control.OnPaint%2A>. The <xref:System.Windows.Forms.Control.Invalidate%2A> method is overloaded, and, depending on the arguments supplied to <xref:System.Windows.Forms.Control.Invalidate%2A> `e`, redraws either some or all of its screen area.

The code in the <xref:System.Windows.Forms.Control.OnPaint%2A> method of your control will execute when the control is first drawn, and whenever it is refreshed. To ensure that your control is redrawn every time it is resized, add the following line to the constructor of your control:

```csharp
SetStyle(ControlStyles.ResizeRedraw, true);
```

```vb
SetStyle(ControlStyles.ResizeRedraw, True)
```

### OnPaintBackground

The base <xref:System.Windows.Forms.Control> class defines another method that is useful for drawing, the <xref:System.Windows.Forms.Control.OnPaintBackground%2A> method.

```csharp
protected virtual void OnPaintBackground(PaintEventArgs e);
```

```vb
Protected Overridable Sub OnPaintBackground(e As PaintEventArgs)
```

<xref:System.Windows.Forms.Control.OnPaintBackground%2A> paints the background (and in that way, the shape) of the window and is guaranteed to be fast, while <xref:System.Windows.Forms.Control.OnPaint%2A> paints the details and might be slower because individual paint requests are combined into one <xref:System.Windows.Forms.Control.Paint> event that covers all areas that have to be redrawn. You might want to invoke the <xref:System.Windows.Forms.Control.OnPaintBackground%2A> if, for instance, you want to draw a gradient-colored background for your control.

While <xref:System.Windows.Forms.Control.OnPaintBackground%2A> has an event-like nomenclature and takes the same argument as the `OnPaint` method, `OnPaintBackground` is not a true event method. There is no `PaintBackground` event and `OnPaintBackground` doesn't invoke event delegates. When overriding the `OnPaintBackground` method, a derived class is not required to invoke the `OnPaintBackground` method of its base class.

## GDI+ Basics

The <xref:System.Drawing.Graphics> class provides methods for drawing various shapes such as circles, triangles, arcs, and ellipses, and methods for displaying text. The <xref:System.Drawing?displayProperty=nameWithType> namespace contains namespaces and classes that encapsulate graphics elements such as shapes (circles, rectangles, arcs, and others), colors, fonts, brushes, and so on. For more information about GDI, see [Using Managed Graphics Classes](../advanced/using-managed-graphics-classes.md).

## Geometry of the Drawing Region

The <xref:System.Windows.Forms.Control.ClientRectangle%2A> property of a control specifies the rectangular region available to the control on the user's screen, while the <xref:System.Windows.Forms.PaintEventArgs.ClipRectangle%2A> property of <xref:System.Windows.Forms.PaintEventArgs> specifies the area that is painted. A control might need to paint only a portion of its available area, as is the case when a small section of the control's display changes. In those situations, a control developer must compute the actual rectangle to draw in and pass that to <xref:System.Windows.Forms.Control.Invalidate%2A>. The overloaded versions of <xref:System.Windows.Forms.Control.Invalidate%2A> that take a <xref:System.Drawing.Rectangle> or <xref:System.Drawing.Region> as an argument use that argument to generate the <xref:System.Windows.Forms.PaintEventArgs.ClipRectangle%2A> property of <xref:System.Windows.Forms.PaintEventArgs>.

## Freeing Graphics Resources

Graphics objects are expensive because they use system resources. Such objects include instances of the <xref:System.Drawing.Graphics?displayProperty=nameWithType> class and instances of <xref:System.Drawing.Brush?displayProperty=nameWithType>, <xref:System.Drawing.Pen?displayProperty=nameWithType>, and other graphics classes. It's important that you create a graphics resource only when you need it and release it soon as you're finished using it. If you create an instance of a type that implements the <xref:System.IDisposable> interface, call its <xref:System.IDisposable.Dispose%2A> method when you're finished with it to free resources.

## See also

- [Types of custom controls](custom.md)

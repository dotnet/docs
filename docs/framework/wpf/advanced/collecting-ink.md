---
title: Collect ink in WPF apps
ms.date: 08/15/2018
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "ink [WPF], collecting"
  - "InkCanvas element [WPF]"
  - "properties [WPF], DrawingAttributes"
  - "collecting digital ink [WPF]"
  - "digital ink [WPF], collecting"
  - "properties [WPF], DefaultDrawingAttributes"
  - "DefaultDrawingAttributes property [WPF]"
ms.assetid: 66a3129d-9577-43eb-acbd-56c147282016
---
# Collect Ink

The [Windows Presentation Foundation](../index.md) platform collects digital ink as a core part of its functionality. This topic discusses methods for collection of ink in Windows Presentation Foundation (WPF).

## Prerequisites

To use the following examples, you must first install Visual Studio and the Windows SDK. You should also understand how to write applications for the WPF. For more information about getting started with WPF, see [Walkthrough: My first WPF desktop application](../getting-started/walkthrough-my-first-wpf-desktop-application.md).

## Use the InkCanvas Element

The <xref:System.Windows.Controls.InkCanvas?displayProperty=fullName> element provides the easiest way to collect ink in WPF. Use an <xref:System.Windows.Controls.InkCanvas> element to receive and display ink input. You commonly input ink through the use of a stylus, which interacts with a digitizer to produce ink strokes. In addition, a mouse can be used in place of a stylus. The created strokes are represented as <xref:System.Windows.Ink.Stroke> objects, and they can be manipulated both programmatically and by user input. The <xref:System.Windows.Controls.InkCanvas> enables users to select, modify, or delete an existing <xref:System.Windows.Ink.Stroke>.

By using XAML, you can set up ink collection as easily as adding an **InkCanvas** element to your tree. The following example adds an <xref:System.Windows.Controls.InkCanvas> to a default WPF project created in Visual Studio:

[!code-xaml[DigitalInkTopics#6](~/samples/snippets/csharp/VS_Snippets_Wpf/DigitalInkTopics/CSharp/Window2.xaml#6)]

The **InkCanvas** element can also contain child elements, making it possible to add ink annotation capabilities to almost any type of XAML element. For example, to add inking capabilities to a text element, simply make it a child of an <xref:System.Windows.Controls.InkCanvas>:

[!code-xaml[DigitalInkTopics#5](~/samples/snippets/csharp/VS_Snippets_Wpf/DigitalInkTopics/CSharp/Window2.xaml#5)]

Adding support for marking up an image with ink is just as easy:

[!code-xaml[DigitalInkTopics#7](~/samples/snippets/csharp/VS_Snippets_Wpf/DigitalInkTopics/CSharp/Window2.xaml#7)]

### InkCollection Modes

The <xref:System.Windows.Controls.InkCanvas> provides support for various input modes through its <xref:System.Windows.Controls.InkCanvas.EditingMode%2A> property.

### Manipulate Ink

The <xref:System.Windows.Controls.InkCanvas> provides support for many ink editing operations. For example, <xref:System.Windows.Controls.InkCanvas> supports back-of-pen erase, and no additional code is needed to add the functionality to the element.

#### Selection

Setting selection mode is as simple as setting the <xref:System.Windows.Controls.InkCanvasEditingMode> property to **Select**.

The following code sets the editing mode based on the value of a <xref:System.Windows.Forms.CheckBox>:

[!code-csharp[DigitalInkTopics#8](~/samples/snippets/csharp/VS_Snippets_Wpf/DigitalInkTopics/CSharp/Window1.xaml.cs#8)]
[!code-vb[DigitalInkTopics#8](~/samples/snippets/visualbasic/VS_Snippets_Wpf/DigitalInkTopics/VisualBasic/Window1.xaml.vb#8)]

#### DrawingAttributes

Use the <xref:System.Windows.Ink.Stroke.DrawingAttributes%2A> property to change the appearance of ink strokes. For instance, the <xref:System.Windows.Ink.DrawingAttributes.Color%2A> member of <xref:System.Windows.Ink.DrawingAttributes> sets the color of the rendered <xref:System.Windows.Ink.Stroke>.

The following example changes the color of the selected strokes to red:

[!code-csharp[DigitalInkTopics#9](~/samples/snippets/csharp/VS_Snippets_Wpf/DigitalInkTopics/CSharp/Window1.xaml.cs#9)]
[!code-vb[DigitalInkTopics#9](~/samples/snippets/visualbasic/VS_Snippets_Wpf/DigitalInkTopics/VisualBasic/Window1.xaml.vb#9)]

### DefaultDrawingAttributes

The <xref:System.Windows.Controls.InkCanvas.DefaultDrawingAttributes%2A> property provides access to properties such as the height, width, and color of the strokes to be created in an <xref:System.Windows.Controls.InkCanvas>. Once you change the <xref:System.Windows.Controls.InkCanvas.DefaultDrawingAttributes%2A>, all future strokes entered into the <xref:System.Windows.Controls.InkCanvas> are rendered with the new property values.

In addition to modifying the <xref:System.Windows.Controls.InkCanvas.DefaultDrawingAttributes%2A> in the code-behind file, you can use XAML syntax for specifying <xref:System.Windows.Controls.InkCanvas.DefaultDrawingAttributes%2A> properties.

The next example demonstrates how to set the <xref:System.Windows.Ink.DrawingAttributes.Color%2A> property. To use this code, create a new WPF project called "HelloInkCanvas" in Visual Studio. Replace the code in the *MainWindow.xaml* file with the following code:

[!code-xaml[HelloInkCanvas#1](~/samples/snippets/csharp/VS_Snippets_Wpf/HelloInkCanvas/CSharp/Window1.xaml#1)]

Next, add the following button event handlers to the code behind file, inside the MainWindow class:

[!code-csharp[HelloInkCanvas#2](~/samples/snippets/csharp/VS_Snippets_Wpf/HelloInkCanvas/CSharp/Window1.xaml.cs#2)]

After copying this code, press **F5** in Visual Studio to run the program in the debugger.

Notice how the <xref:System.Windows.Controls.StackPanel> places the buttons on top of the <xref:System.Windows.Controls.InkCanvas>. If you try to ink over the top of the buttons, the <xref:System.Windows.Controls.InkCanvas> collects and renders the ink behind the buttons. This is because the buttons are siblings of the <xref:System.Windows.Controls.InkCanvas> as opposed to children. Also, the buttons are higher in the z-order, so the ink is rendered behind them.

## See also

- <xref:System.Windows.Ink.DrawingAttributes>
- <xref:System.Windows.Controls.InkCanvas.DefaultDrawingAttributes%2A>
- <xref:System.Windows.Ink>

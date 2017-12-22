---
title: "Optimizing Performance: Text"
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
  - "rendering text [WPF]"
  - "hyperlinks [WPF]"
  - "formatted text [WPF]"
  - "text [WPF], performance"
  - "glyphs [WPF]"
ms.assetid: 66b1b9a7-8618-48db-b616-c57ea4327b98
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Optimizing Performance: Text
[!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] includes support for the presentation of text content through the use of feature-rich [!INCLUDE[TLA#tla_ui](../../../../includes/tlasharptla-ui-md.md)] controls. In general you can divide text rendering in three layers:  
  
1.  Using the <xref:System.Windows.Documents.Glyphs> and <xref:System.Windows.Media.GlyphRun> objects directly.  
  
2.  Using the <xref:System.Windows.Media.FormattedText> object.  
  
3.  Using high-level controls, such as the <xref:System.Windows.Controls.TextBlock> and <xref:System.Windows.Documents.FlowDocument> objects.  
  
 This topic provides text rendering performance recommendations.  
  
  
<a name="Glyph_Level"></a>   
## Rendering Text at the Glyph Level  
 [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] provides advanced text support including glyph-level markup with direct access to <xref:System.Windows.Documents.Glyphs> for customers who want to intercept and persist text after formatting. These features provide critical support for the different text rendering requirements in each of the following scenarios.  
  
-   Screen display of fixed-format documents.  
  
-   Print scenarios.  
  
    -   [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] as a device printer language.  
  
    -   [!INCLUDE[TLA#tla_mxdw](../../../../includes/tlasharptla-mxdw-md.md)].  
  
    -   Previous printer drivers, output from [!INCLUDE[TLA#tla_win32](../../../../includes/tlasharptla-win32-md.md)] applications to the fixed format.  
  
    -   Print spool format.  
  
-   Fixed-format document representation, including clients for previous versions of [!INCLUDE[TLA#tla_mswin](../../../../includes/tlasharptla-mswin-md.md)] and other computing devices.  
  
> [!NOTE]
>  <xref:System.Windows.Documents.Glyphs> and <xref:System.Windows.Media.GlyphRun> are designed for fixed-format document presentation and print scenarios. [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] provides several elements for general layout and [!INCLUDE[TLA#tla_ui](../../../../includes/tlasharptla-ui-md.md)] scenarios such as <xref:System.Windows.Controls.Label> and <xref:System.Windows.Controls.TextBlock>. For more information on layout and [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] scenarios, see the [Typography in WPF](../../../../docs/framework/wpf/advanced/typography-in-wpf.md).  
  
 The following examples show how to define properties for a <xref:System.Windows.Documents.Glyphs> object in [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)]. The <xref:System.Windows.Documents.Glyphs> object represents the output of a <xref:System.Windows.Media.GlyphRun> in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)]. The examples assume that the Arial, Courier New, and Times New Roman fonts are installed in the **C:\WINDOWS\Fonts** folder on the local computer.  
  
 [!code-xaml[GlyphsOvwSample1#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/GlyphsOvwSample1/CS/default.xaml#1)]  
  
### Using DrawGlyphRun  
 If you have custom control and you want to render glyphs, use the <xref:System.Windows.Media.DrawingContext.DrawGlyphRun%2A> method.  
  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] also provides lower-level services for custom text formatting through the use of the <xref:System.Windows.Media.FormattedText> object. The most efficient way of rendering text in [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] is by generating text content at the glyph level using <xref:System.Windows.Documents.Glyphs> and <xref:System.Windows.Media.GlyphRun>. However, the cost of this efficiency is the loss of easy to use rich text formatting, which are built-in features of [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] controls, such as <xref:System.Windows.Controls.TextBlock> and <xref:System.Windows.Documents.FlowDocument>.  
  
<a name="FormattedText_Object"></a>   
## FormattedText Object  
 The <xref:System.Windows.Media.FormattedText> object allows you to draw multi-line text, in which each character in the text can be individually formatted. For more information, see [Drawing Formatted Text](../../../../docs/framework/wpf/advanced/drawing-formatted-text.md).  
  
 To create formatted text, call the <xref:System.Windows.Media.FormattedText.%23ctor%2A> constructor to create a <xref:System.Windows.Media.FormattedText> object. Once you have created the initial formatted text string, you can apply a range of formatting styles. If your application wants to implement its own layout, then the <xref:System.Windows.Media.FormattedText> object is better choice than using a control, such as <xref:System.Windows.Controls.TextBlock>. For more information on the <xref:System.Windows.Media.FormattedText> object, see [Drawing Formatted Text](../../../../docs/framework/wpf/advanced/drawing-formatted-text.md) .  
  
 The <xref:System.Windows.Media.FormattedText> object provides low-level text formatting capability. You can apply multiple formatting styles to one or more characters. For example, you could call both the <xref:System.Windows.Media.FormattedText.SetFontSize%2A> and <xref:System.Windows.Media.FormattedText.SetForegroundBrush%2A> methods to change the formatting of the first five characters in the text.  
  
 The following code example creates a <xref:System.Windows.Media.FormattedText> object and renders it.  
  
 [!code-csharp[formattedtextsnippets#FormattedTextSnippets1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FormattedTextSnippets/CSharp/Window1.xaml.cs#formattedtextsnippets1)]
 [!code-vb[formattedtextsnippets#FormattedTextSnippets1](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/FormattedTextSnippets/visualbasic/window1.xaml.vb#formattedtextsnippets1)]  
  
<a name="FlowDocument_TextBlock_Label"></a>   
## FlowDocument, TextBlock, and Label Controls  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] includes multiple controls for drawing text to the screen. Each control is targeted to a different scenario and has its own list of features and limitations.  
  
### FlowDocument Impacts Performance More than TextBlock or Label  
 In general, the <xref:System.Windows.Controls.TextBlock> element should be used when limited text support is required, such as a brief sentence in a [!INCLUDE[TLA#tla_ui](../../../../includes/tlasharptla-ui-md.md)]. <xref:System.Windows.Controls.Label> can be used when minimal text support is required. The <xref:System.Windows.Documents.FlowDocument> element is a container for re-flowable documents that support rich presentation of content, and therefore, has a greater performance impact than using the <xref:System.Windows.Controls.TextBlock> or <xref:System.Windows.Controls.Label> controls.  
  
 For more information on <xref:System.Windows.Documents.FlowDocument>, see [Flow Document Overview](../../../../docs/framework/wpf/advanced/flow-document-overview.md).  
  
### Avoid Using TextBlock in FlowDocument  
 The <xref:System.Windows.Controls.TextBlock> element is derived from <xref:System.Windows.UIElement>. The <xref:System.Windows.Documents.Run> element is derived from <xref:System.Windows.Documents.TextElement>, which is less costly to use than a <xref:System.Windows.UIElement>-derived object. When possible, use <xref:System.Windows.Documents.Run> rather than <xref:System.Windows.Controls.TextBlock> for displaying text content in a <xref:System.Windows.Documents.FlowDocument>.  
  
 The following markup sample illustrates two ways of setting text content within a <xref:System.Windows.Documents.FlowDocument>:  
  
 [!code-xaml[Performance#PerformanceSnippet13](../../../../samples/snippets/csharp/VS_Snippets_Wpf/Performance/CSharp/FlowDocument.xaml#performancesnippet13)]  
  
### Avoid Using Run to Set Text Properties  
 In general, using a <xref:System.Windows.Documents.Run> within a <xref:System.Windows.Controls.TextBlock> is more performance intensive than not using an explicit <xref:System.Windows.Documents.Run> object at all. If you are using a <xref:System.Windows.Documents.Run> in order to set text properties, set those properties directly on the <xref:System.Windows.Controls.TextBlock> instead.  
  
 The following markup sample illustrates these two ways of setting a text property, in this case, the <xref:System.Windows.Controls.TextBlock.FontWeight%2A> property:  
  
 [!code-xaml[Performance#PerformanceSnippet12](../../../../samples/snippets/csharp/VS_Snippets_Wpf/Performance/CSharp/Window1.xaml#performancesnippet12)]  
  
 The following table shows the cost of displaying 1000 <xref:System.Windows.Controls.TextBlock> objects with and without an explicit <xref:System.Windows.Documents.Run>.  
  
|**TextBlock type**|**Creation time (ms)**|**Render time (ms)**|  
|------------------------|------------------------------|----------------------------|  
|Run setting text properties|146|540|  
|TextBlock setting text properties|43|453|  
  
### Avoid Databinding to the Label.Content Property  
 Imagine a scenario where you have a <xref:System.Windows.Controls.Label> object that is updated frequently from a <xref:System.String> source. When data binding the <xref:System.Windows.Controls.Label> element's <xref:System.Windows.Controls.ContentControl.Content%2A> property to the <xref:System.String> source object, you may experience poor performance. Each time the source <xref:System.String> is updated, the old <xref:System.String> object is discarded and a new <xref:System.String> is recreated—because a <xref:System.String> object is immutable, it cannot be modified. This, in turn, causes the <xref:System.Windows.Controls.ContentPresenter> of the <xref:System.Windows.Controls.Label> object to discard its old content and regenerate the new content to display the new <xref:System.String>.  
  
 The solution to this problem is simple. If the <xref:System.Windows.Controls.Label> is not set to a custom <xref:System.Windows.Controls.ContentControl.ContentTemplate%2A> value, replace the <xref:System.Windows.Controls.Label> with a <xref:System.Windows.Controls.TextBlock> and data bind its <xref:System.Windows.Controls.TextBlock.Text%2A> property to the source string.  
  
|**Data bound property**|**Update time (ms)**|  
|-----------------------------|----------------------------|  
|Label.Content|835|  
|TextBlock.Text|242|  
  
<a name="Hyperlink"></a>   
## Hyperlink  
 The <xref:System.Windows.Documents.Hyperlink> object is an inline-level flow content element that allows you to host hyperlinks within the flow content.  
  
### Combine Hyperlinks in One TextBlock Object  
 You can optimize the use of multiple <xref:System.Windows.Documents.Hyperlink> elements by grouping them together within the same <xref:System.Windows.Controls.TextBlock>. This helps to minimize the number of objects you create in your application. For example, you may want to display multiple hyperlinks, such as the following:  
  
 MSN Home &#124; My MSN  
  
 The following markup example shows multiple <xref:System.Windows.Controls.TextBlock> elements used to display the hyperlinks:  
  
 [!code-xaml[Performance#PerformanceSnippet9](../../../../samples/snippets/csharp/VS_Snippets_Wpf/Performance/CSharp/Hyperlink.xaml#performancesnippet9)]  
  
 The following markup example shows a more efficient way of displaying the hyperlinks, this time, using a single <xref:System.Windows.Controls.TextBlock>:  
  
 [!code-xaml[Performance#PerformanceSnippet10](../../../../samples/snippets/csharp/VS_Snippets_Wpf/Performance/CSharp/Hyperlink.xaml#performancesnippet10)]  
  
### Showing Underlines on Hyperlinks Only on MouseEnter Events  
 A <xref:System.Windows.TextDecoration> object is a visual ornamentation that you can add to text; however, it can be performance intensive to instantiate. If you make extensive use of <xref:System.Windows.Documents.Hyperlink> elements, consider showing an underline only when triggering an event, such as the <xref:System.Windows.ContentElement.MouseEnter> event. For more information, see [Specify Whether a Hyperlink is Underlined](../../../../docs/framework/wpf/advanced/how-to-specify-whether-a-hyperlink-is-underlined.md).  
  
 ![Hyperlinks displaying TextDecorations](../../../../docs/framework/wpf/advanced/media/textdecoration03.png "TextDecoration03")  
Hyperlink appearing on MouseEnter  
  
 The following markup sample shows a <xref:System.Windows.Documents.Hyperlink> defined with and without an underline:  
  
 [!code-xaml[Performance#PerformanceSnippet11](../../../../samples/snippets/csharp/VS_Snippets_Wpf/Performance/CSharp/Hyperlink.xaml#performancesnippet11)]  
  
 The following table shows the performance cost of displaying 1000 <xref:System.Windows.Documents.Hyperlink> elements with and without an underline.  
  
|**Hyperlink**|**Creation time (ms)**|**Render time (ms)**|  
|-------------------|------------------------------|----------------------------|  
|With underline|289|1130|  
|Without underline|299|776|  
  
<a name="Text_Formatting_Features"></a>   
## Text Formatting Features  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] provides rich text formatting services, such as automatic hyphenations. These services may impact application performance and should only be used when needed.  
  
### Avoid Unnecessary Use of Hyphenation  
 Automatic hyphenation finds hyphen breakpoints for lines of text, and allows additional break positions for lines in <xref:System.Windows.Controls.TextBlock> and <xref:System.Windows.Documents.FlowDocument> objects. By default, the automatic hyphenation feature is disabled in these objects. You can enable this feature by setting the object's IsHyphenationEnabled property to `true`. However, enabling this feature causes [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] to initiate [!INCLUDE[TLA#tla_com](../../../../includes/tlasharptla-com-md.md)] interoperability, which can impact application performance. It is recommended that you do not use automatic hyphenation unless you need it.  
  
### Use Figures Carefully  
 A <xref:System.Windows.Documents.Figure> element represents a portion of flow content that can be absolutely-positioned within a page of content. In some cases, a <xref:System.Windows.Documents.Figure> may cause an entire page to automatically reformat if its position collides with content that has already been laid-out. You can minimize the possibility of unnecessary reformatting by either grouping <xref:System.Windows.Documents.Figure> elements next to each other, or declaring them near the top of content in a fixed page size scenario.  
  
### Optimal Paragraph  
 The optimal paragraph feature of the <xref:System.Windows.Documents.FlowDocument> object lays out paragraphs so that white space is distributed as evenly as possible. By default, the optimal paragraph feature is disabled. You can enable this feature by setting the object's <xref:System.Windows.Documents.FlowDocument.IsOptimalParagraphEnabled%2A> property to `true`. However, enabling this feature impacts application performance. It is recommended that you do not use the optimal paragraph feature unless you need it.  
  
## See Also  
 [Optimizing WPF Application Performance](../../../../docs/framework/wpf/advanced/optimizing-wpf-application-performance.md)  
 [Planning for Application Performance](../../../../docs/framework/wpf/advanced/planning-for-application-performance.md)  
 [Taking Advantage of Hardware](../../../../docs/framework/wpf/advanced/optimizing-performance-taking-advantage-of-hardware.md)  
 [Layout and Design](../../../../docs/framework/wpf/advanced/optimizing-performance-layout-and-design.md)  
 [2D Graphics and Imaging](../../../../docs/framework/wpf/advanced/optimizing-performance-2d-graphics-and-imaging.md)  
 [Object Behavior](../../../../docs/framework/wpf/advanced/optimizing-performance-object-behavior.md)  
 [Application Resources](../../../../docs/framework/wpf/advanced/optimizing-performance-application-resources.md)  
 [Data Binding](../../../../docs/framework/wpf/advanced/optimizing-performance-data-binding.md)  
 [Other Performance Recommendations](../../../../docs/framework/wpf/advanced/optimizing-performance-other-recommendations.md)

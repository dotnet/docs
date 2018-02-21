---
title: "Advanced Text Formatting"
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
  - "formatting [WPF]"
  - "text [WPF]"
  - "typography [WPF], text formatting"
ms.assetid: f0a7986e-f5b2-485c-a27d-f8e922022212
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Advanced Text Formatting
The [!INCLUDE[TLA#tla_wpf](../../../../includes/tlasharptla-wpf-md.md)] provides a robust set of [!INCLUDE[TLA#tla_api#plural](../../../../includes/tlasharptla-apisharpplural-md.md)] for including text in your application. Layout and [!INCLUDE[TLA#tla_ui](../../../../includes/tlasharptla-ui-md.md)][!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)], such as <xref:System.Windows.Controls.TextBlock>, provide the most common and general use elements for text presentation. Drawing [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)], such as <xref:System.Windows.Media.GlyphRunDrawing> and <xref:System.Windows.Media.FormattedText>, provide a means for including formatted text in drawings. At the most advanced level, [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] provides an extensible text formatting engine to control every aspect of text presentation, such as text store management, text run formatting management, and embedded object management.  
  
 This topic provides an introduction to [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] text formatting. It focuses on client implementation and use of the [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] text formatting engine.  
  
> [!NOTE]
>  All code examples within this document can be found in the [Advanced Text Formatting Sample](http://go.microsoft.com/fwlink/?LinkID=159965).  
  

  
<a name="prereq"></a>   
## Prerequisites  
 This topic assumes that you are familiar with the higher level [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)] used for text presentation. Most user scenarios will not require the advanced text formatting [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)] discussed in this topic. For an introduction to the different text [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)], see [Documents in WPF](../../../../docs/framework/wpf/advanced/documents-in-wpf.md).  
  
<a name="section1"></a>   
## Advanced Text Formatting  
 The text layout and [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] controls in [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] provide formatting properties that allow you to easily include formatted text in your application. These controls expose a number of properties to handle the presentation of text, which includes its typeface, size, and color. Under ordinary circumstances, these controls can handle the majority of text presentation in your application. However, some advanced scenarios require the control of text storage as well as text presentation. [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] provides an extensible text formatting engine for this purpose.  
  
 The advanced text formatting features found in [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] consist of a text formatting engine, a text store, text runs, and formatting properties. The text formatting engine, <xref:System.Windows.Media.TextFormatting.TextFormatter>, creates lines of text to be used for presentation. This is achieved by initiating the line formatting process and calling the text formatter's <xref:System.Windows.Media.TextFormatting.TextFormatter.FormatLine%2A>. The text formatter retrieves text runs from your text store by calling the store's <xref:System.Windows.Media.TextFormatting.TextSource.GetTextRun%2A> method. The <xref:System.Windows.Media.TextFormatting.TextRun> objects are then formed into <xref:System.Windows.Media.TextFormatting.TextLine> objects by the text formatter and given to your application for inspection or display.  
  
<a name="section2"></a>   
## Using the Text Formatter  
 <xref:System.Windows.Media.TextFormatting.TextFormatter> is the [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] text formatting engine and provides services for formatting and breaking text lines. The text formatter can handle different text character formats and paragraph styles, and includes support for international text layout.  
  
 Unlike a traditional text [!INCLUDE[TLA#tla_api](../../../../includes/tlasharptla-api-md.md)], the <xref:System.Windows.Media.TextFormatting.TextFormatter> interacts with a text layout client through a set of callback methods. It requires the client to provide these methods in an implementation of the <xref:System.Windows.Media.TextFormatting.TextSource> class. The following diagram illustrates the text layout interaction between the client application and <xref:System.Windows.Media.TextFormatting.TextFormatter>.  
  
 ![Diagram of text layout client and TextFormatter](../../../../docs/framework/wpf/advanced/media/textformatter01.png "TextFormatter01")  
Interaction between application and TextFormatter  
  
 The text formatter is used to retrieve formatted text lines from the text store, which is an implementation of <xref:System.Windows.Media.TextFormatting.TextSource>. This is done by first creating an instance of the text formatter by using the <xref:System.Windows.Media.TextFormatting.TextFormatter.Create%2A> method. This method creates an instance of the text formatter and sets the maximum line height and width values. As soon as an instance of the text formatter is created, the line creation process is started by calling the <xref:System.Windows.Media.TextFormatting.TextFormatter.FormatLine%2A> method. <xref:System.Windows.Media.TextFormatting.TextFormatter> calls back to the text source to retrieve the text and formatting parameters for the runs of text that form a line.  
  
 In the following example, the process of formatting a text store is shown. The <xref:System.Windows.Media.TextFormatting.TextFormatter> object is used to retrieve text lines from the text store and then format the text line for drawing into the <xref:System.Windows.Media.DrawingContext>.  
  
 [!code-csharp[TextFormatterExample#100](../../../../samples/snippets/csharp/VS_Snippets_Wpf/TextFormatterExample/CSharp/Window1.xaml.cs#100)]
 [!code-vb[TextFormatterExample#100](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/TextFormatterExample/VisualBasic/Window1.xaml.vb#100)]  
  
<a name="section3"></a>   
## Implementing the Client Text Store  
 When you extend the text formatting engine, you are required to implement and manage all aspects of the text store. This is not a trivial task. The text store is responsible for tracking text run properties, paragraph properties, embedded objects, and other similar content. It also provides the text formatter with individual <xref:System.Windows.Media.TextFormatting.TextRun> objects which the text formatter uses to create <xref:System.Windows.Media.TextFormatting.TextLine> objects.  
  
 To handle the virtualization of the text store, the text store must be derived from <xref:System.Windows.Media.TextFormatting.TextSource>. <xref:System.Windows.Media.TextFormatting.TextSource> defines the method the text formatter uses to retrieve text runs from the text store. <xref:System.Windows.Media.TextFormatting.TextSource.GetTextRun%2A> is the method used by the text formatter to retrieve text runs used in line formatting. The call to <xref:System.Windows.Media.TextFormatting.TextSource.GetTextRun%2A> is repeatedly made by the text formatter until one of the following conditions occurs:  
  
-   A <xref:System.Windows.Media.TextFormatting.TextEndOfLine> or a subclass is returned.  
  
-   The accumulated width of text runs exceeds the maximum line width specified in either the call to create the text formatter or the call to the text formatter's <xref:System.Windows.Media.TextFormatting.TextFormatter.FormatLine%2A> method.  
  
-   A [!INCLUDE[TLA#tla_unicode](../../../../includes/tlasharptla-unicode-md.md)] newline sequence, such as "CF", "LF", or "CRLF", is returned.  
  
<a name="section4"></a>   
## Providing Text Runs  
 The core of the text formatting process is the interaction between the text formatter and the text store. Your implementation of <xref:System.Windows.Media.TextFormatting.TextSource> provides the text formatter with the <xref:System.Windows.Media.TextFormatting.TextRun> objects and the properties with which to format the text runs. This interaction is handled by the <xref:System.Windows.Media.TextFormatting.TextSource.GetTextRun%2A> method, which is called by the text formatter.  
  
 The following table shows some of the predefined <xref:System.Windows.Media.TextFormatting.TextRun> objects.  
  
|TextRun Type|Usage|  
|------------------|-----------|  
|<xref:System.Windows.Media.TextFormatting.TextCharacters>|The specialized text run used to pass a representation of character glyphs back to the text formatter.|  
|<xref:System.Windows.Media.TextFormatting.TextEmbeddedObject>|The specialized text run used to provide content in which measuring, hit testing, and drawing is done in whole, such as a button or image within the text.|  
|<xref:System.Windows.Media.TextFormatting.TextEndOfLine>|The specialized text run used to mark the end of a line.|  
|<xref:System.Windows.Media.TextFormatting.TextEndOfParagraph>|The specialized text run used to mark the end of a paragraph.|  
|<xref:System.Windows.Media.TextFormatting.TextEndOfSegment>|The specialized text run used to mark the end of a segment, such as to end the scope affected by a previous <xref:System.Windows.Media.TextFormatting.TextModifier> run.|  
|<xref:System.Windows.Media.TextFormatting.TextHidden>|The specialized text run used to mark a range of hidden characters.|  
|<xref:System.Windows.Media.TextFormatting.TextModifier>|The specialized text run used to modify properties of text runs in its scope. The scope extends to the next matching <xref:System.Windows.Media.TextFormatting.TextEndOfSegment> text run, or the next <xref:System.Windows.Media.TextFormatting.TextEndOfParagraph>.|  
  
 Any of the predefined <xref:System.Windows.Media.TextFormatting.TextRun> objects can be subclassed. This allows your text source to provide the text formatter with text runs that include custom data.  
  
 The following example demonstrates a <xref:System.Windows.Media.TextFormatting.TextSource.GetTextRun%2A> method. This text store returns <xref:System.Windows.Media.TextFormatting.TextRun> objects to the text formatter for processing.  
  
 [!code-csharp[TextFormatterExample#101](../../../../samples/snippets/csharp/VS_Snippets_Wpf/TextFormatterExample/CSharp/CustomTextSource.cs#101)]
 [!code-vb[TextFormatterExample#101](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/TextFormatterExample/VisualBasic/CustomTextSource.vb#101)]  
  
> [!NOTE]
>  In this example, the text store provides the same text properties to all of the text. Advanced text stores would need to implement their own span management to allow individual characters to have different properties.  
  
<a name="section5"></a>   
## Specifying Formatting Properties  
 <xref:System.Windows.Media.TextFormatting.TextRun> objects are formatted by using properties provided by the text store. These properties come in two types, <xref:System.Windows.Media.TextFormatting.TextParagraphProperties> and <xref:System.Windows.Media.TextFormatting.TextRunProperties>. <xref:System.Windows.Media.TextFormatting.TextParagraphProperties> handle paragraph inclusive properties such as <xref:System.Windows.TextAlignment> and <xref:System.Windows.FlowDirection>. <xref:System.Windows.Media.TextFormatting.TextRunProperties> are properties that can be different for each text run within a paragraph, such as foreground brush, <xref:System.Windows.Media.Typeface>, and font size. To implement custom paragraph and custom text run property types, your application must create classes that derive from <xref:System.Windows.Media.TextFormatting.TextParagraphProperties> and <xref:System.Windows.Media.TextFormatting.TextRunProperties> respectively.  
  
## See Also  
 [Typography in WPF](../../../../docs/framework/wpf/advanced/typography-in-wpf.md)  
 [Documents in WPF](../../../../docs/framework/wpf/advanced/documents-in-wpf.md)

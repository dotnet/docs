---
title: "Introduction to the GlyphRun Object and Glyphs Element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "typography [WPF], Glyphs element"
  - "Glyphs elements [WPF]"
  - "GlyphRun object [WPF]"
  - "text [WPF], glyphs"
  - "glyphs [WPF]"
  - "typography [WPF], GlyphRun object"
ms.assetid: 746ca769-a331-4435-9b95-f72a883b67c1
caps.latest.revision: 21
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Introduction to the GlyphRun Object and Glyphs Element
This topic describes the <xref:System.Windows.Media.GlyphRun> object and the <xref:System.Windows.Documents.Glyphs> element.  
  
  
<a name="text_glyphrunovw_intro"></a>   
## Introduction to GlyphRun  
 [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] provides advanced text support including glyph-level markup with direct access to <xref:System.Windows.Documents.Glyphs> for customers who want to intercept and persist text after formatting. These features provide critical support for the different text rendering requirements in each of the following scenarios.  
  
1.  Screen display of fixed-format documents.  
  
2.  Print scenarios.  
  
    -   [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] as a device printer language.  
  
    -   [!INCLUDE[TLA#tla_mxdw](../../../../includes/tlasharptla-mxdw-md.md)].  
  
    -   Previous printer drivers, output from [!INCLUDE[TLA#tla_win32](../../../../includes/tlasharptla-win32-md.md)] applications to the fixed format.  
  
    -   Print spool format.  
  
3.  Fixed-format document representation, including clients for previous versions of [!INCLUDE[TLA#tla_mswin](../../../../includes/tlasharptla-mswin-md.md)] and other computing devices.  
  
> [!NOTE]
>  <xref:System.Windows.Documents.Glyphs> and <xref:System.Windows.Media.GlyphRun> are designed for fixed-format document presentation and print scenarios. [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] provides several elements for general layout and [!INCLUDE[TLA#tla_ui](../../../../includes/tlasharptla-ui-md.md)] scenarios such as <xref:System.Windows.Controls.Label> and <xref:System.Windows.Controls.TextBlock>. For more information on layout and [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] scenarios, see the [Typography in WPF](../../../../docs/framework/wpf/advanced/typography-in-wpf.md).  
  
<a name="text_glyphrunovw_glyphrunobject"></a>   
## The GlyphRun Object  
 The <xref:System.Windows.Media.GlyphRun> object represents a sequence of glyphs from a single face of a single font at a single size, and with a single rendering style.  
  
 <xref:System.Windows.Media.GlyphRun> includes both font details such as glyph <xref:System.Windows.Documents.Glyphs.Indices%2A> and individual glyph positions. It also includes the original [!INCLUDE[TLA#tla_unicode](../../../../includes/tlasharptla-unicode-md.md)] code points the run was generated from, character-to-glyph buffer offset mapping information, and per-character and per-glyph flags.  
  
 <xref:System.Windows.Media.GlyphRun> has a corresponding high-level <xref:System.Windows.FrameworkElement>, <xref:System.Windows.Documents.Glyphs>. <xref:System.Windows.Documents.Glyphs> can be used in the element tree and in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] markup to represent <xref:System.Windows.Media.GlyphRun> output.  
  
<a name="text_glyphrunovw_glyphselement"></a>   
## The Glyphs Element  
 The <xref:System.Windows.Documents.Glyphs> element represents the output of a <xref:System.Windows.Media.GlyphRun> in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)]. The following markup syntax is used to describe the <xref:System.Windows.Documents.Glyphs> element.  
  
 [!code-xaml[GlyphsOvwSample1#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/GlyphsOvwSample1/CS/default.xaml#1)]  
  
 The following property definitions correspond to the first four attributes in the sample markup.  
  
|Property|Description|  
|--------------|-----------------|  
|<xref:System.Windows.Documents.Glyphs.FontUri%2A>|Specifies a resource identifier: file name, Web [!INCLUDE[TLA#tla_uri](../../../../includes/tlasharptla-uri-md.md)], or resource reference in the application .exe or container.|  
|<xref:System.Windows.Documents.Glyphs.FontRenderingEmSize%2A>|Specifies the font size in drawing surface units (default is .96 inches).|  
|<xref:System.Windows.Documents.Glyphs.StyleSimulations%2A>|Specifies flags for bold and Italic styles.|  
|<xref:System.Windows.Documents.Glyphs.BidiLevel%2A>|Specifies the bidirectional layout level. Even-numbered and zero values imply left-to-right layout; odd-numbered values imply right-to-left layout.|  
  
<a name="text_glyphrunovw_indicesproperty"></a>   
### Indices property  
 The <xref:System.Windows.Documents.Glyphs.Indices%2A> property is a string of glyph specifications. Where a sequence of glyphs forms a single cluster, the specification of the first glyph in the cluster is preceded by a specification of how many glyphs and how many code points combine to form the cluster. The <xref:System.Windows.Documents.Glyphs.Indices%2A> property collects in one string the following properties.  
  
-   Glyph indices  
  
-   Glyph advance widths  
  
-   Combining glyph attachment vectors  
  
-   Cluster mapping from code points to glyphs  
  
-   Glyph flags  
  
 Each glyph specification has the following form.  
  
 `[GlyphIndex][,[Advance][,[uOffset][,[vOffset][,[Flags]]]]]`  
  
<a name="text_glyphrunovw_glyphmetrics"></a>   
## Glyph Metrics  
 Each glyph defines metrics that specify how it aligns with other <xref:System.Windows.Documents.Glyphs>. The following graphic defines the various typographic qualities of two different glyph characters.  
  
 ![Diagraph of glyph measurements](../../../../docs/framework/wpf/advanced/media/glyph-example.png "glyph_example")  
  
<a name="text_glyphrunovw_glyphsmarkup"></a>   
## Glyphs Markup  
 The following code example shows how to use various properties of the <xref:System.Windows.Documents.Glyphs> element in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)].  
  
 [!code-xaml[GlyphsOvwSamp2#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/GlyphsOvwSamp2/CS/default.xaml#1)]  
  
## See Also  
 [Typography in WPF](../../../../docs/framework/wpf/advanced/typography-in-wpf.md)  
 [Documents in WPF](../../../../docs/framework/wpf/advanced/documents-in-wpf.md)  
 [Text](../../../../docs/framework/wpf/advanced/optimizing-performance-text.md)

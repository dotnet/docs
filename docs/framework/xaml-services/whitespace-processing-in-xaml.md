---
title: "Whitespace Processing in XAML"
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
  - "East Asian characters [XAML Services]"
  - "XAML [XAML Services], whitespace processing"
  - "whitespace processing in XAML [XAML Services]"
  - "characters [XAML Services], East Asian"
ms.assetid: cc9cc377-7544-4fd0-b65b-117b90bb0b23
caps.latest.revision: 20
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Whitespace Processing in XAML
The language rules for XAML state that significant whitespace must be processed by a [!INCLUDE[TLA2#tla_xaml](../../../includes/tla2sharptla-xaml-md.md)] processor implementation. This topic documents these XAML language rules. It also documents additional whitespace handling that is defined by the [!INCLUDE[TLA#tla_winclient](../../../includes/tlasharptla-winclient-md.md)] implementation of the XAML processor and the XAML writer for serialization.  
  
<a name="whitespace_definition"></a>   
## Whitespace Definition  
 Consistent with [!INCLUDE[TLA2#tla_xml](../../../includes/tla2sharptla-xml-md.md)], whitespace characters in [!INCLUDE[TLA2#tla_xaml](../../../includes/tla2sharptla-xaml-md.md)] are space, linefeed, and tab. These correspond to the [!INCLUDE[TLA#tla_unicode](../../../includes/tlasharptla-unicode-md.md)] values 0020, 000A, and 0009 respectively.  
  
<a name="whitespace_normalization"></a>   
## Whitespace Normalization  
 By default the following whitespace normalization occurs when a [!INCLUDE[TLA2#tla_xaml](../../../includes/tla2sharptla-xaml-md.md)] processor processes a [!INCLUDE[TLA2#tla_xaml](../../../includes/tla2sharptla-xaml-md.md)] file:  
  
1.  Linefeed characters between East Asian characters are removed. See the "East Asian Characters" section later in this topic for a definition of this term.  
  
2.  All whitespace characters (space, linefeed, tab) are converted into spaces.  
  
3.  All consecutive spaces are deleted and replaced by one space.  
  
4.  A space immediately following the start tag is deleted.  
  
5.  A space immediately before the end tag is deleted.  
  
 "Default" corresponds to the state denoted by the default value of the [xml:space](../../../docs/framework/xaml-services/xml-space-handling-in-xaml.md) attribute.  
  
<a name="whitespace_in_inner_text_and_string_primitives"></a>   
## Whitespace in Inner Text, and String Primitives  
 The previous normalization rules apply to inner text that is found within XAML  elements. After normalization, a XAML  processor converts any inner text into an appropriate type as follows:  
  
-   If the type of the property is not a collection but is not directly an <xref:System.Object> type, the XAML  processor attempts to convert to that type by using its type converter. A failed conversion here causes a compile-time error.  
  
-   If the type of the property is a collection and the inner text is contiguous (no intervening element tags), the inner text is parsed as a single <xref:System.String>. If the collection type cannot accept <xref:System.String>, this also causes a compile-time error.  
  
-   If the type of the property is <xref:System.Object>, the inner text is parsed as a single <xref:System.String>. If there are intervening element tags, this causes a compile-time error because the <xref:System.Object> type implies a single object (<xref:System.String> or otherwise).  
  
-   If the type of the property is a collection, and the inner text is not contiguous, the first substring is converted into a <xref:System.String> and added as a collection item, the intervening element is added as a collection item, and finally the trailing substring (if any) is added to the collection as a third <xref:System.String> item.  
  
<a name="preserving_whitespace"></a>   
## Preserving Whitespace  
 There are several techniques for preserving whitespace in the source [!INCLUDE[TLA2#tla_xaml](../../../includes/tla2sharptla-xaml-md.md)] for eventual presentation that are not affected by [!INCLUDE[TLA2#tla_xaml](../../../includes/tla2sharptla-xaml-md.md)] processor whitespace normalization.  
  
 **xml:space="preserve"**: Specify this attribute at the level of the element where whitespace preservation is desired. This preserves all white space, which includes the spaces that might be added by code-editing applications to "pretty-print" align elements as a visually intuitive nesting. However, whether those spaces render is determined by the content model for the containing element. Avoid specifying `xml:space="preserve"` at the root level because most object models do not consider whitespace as significant regardless of how you set the attribute. Setting `xml:space` globally may have performance consequences on XAML processing (particularly serialization) in some implementations. It is a better practice to only set the attribute specifically at the level of elements that render whitespace within strings, or are whitespace significant collections.  
  
 **Entities and non breaking spaces**: [!INCLUDE[TLA2#tla_xaml](../../../includes/tla2sharptla-xaml-md.md)] supports placing any [!INCLUDE[TLA#tla_unicode](../../../includes/tlasharptla-unicode-md.md)] entity within a text object model. You can use dedicated entities such as nonbreaking space (&\#160; in UTF-8 encoding). You can also use rich text controls that support nonbreaking space characters. You should be cautious if you are using entities to simulate layout characteristics such as indention, because the run-time output of the entities will vary based on a greater number of factors than would the capabilities for producing indention results in a typical layout system, such as proper use of panels and margins. For instance, entities are mapped to fonts and can change size in response to user font selection.  
  
<a name="east_asian_characters"></a>   
## East Asian Characters  
 "East Asian characters" is defined as a set of [!INCLUDE[TLA2#tla_unicode](../../../includes/tla2sharptla-unicode-md.md)] character ranges U+20000 to U+2FFFD and U+30000 to U+3FFFD. This subset is also sometimes referred to as "CJK ideographs". For more information, see [http://www.unicode.org](http://www.unicode.org/).  
  
<a name="whitespace_and_text_content_models"></a>   
## Whitespace and Text Content Models  
 In practice, preserving whitespace is only of concern for a subset of all possible content models. That subset is composed of content models that can take a singleton <xref:System.String> type in some form, a dedicated <xref:System.String> collection, or a mixture of <xref:System.String> and other types in an <xref:System.Collections.IList> or <xref:System.Collections.Generic.ICollection%601> collection.  
  
### Whitespace and Text Content Models in WPF  
 For illustration purposes, the remainder of this section references particular types that are defined by WPF. The whitespace handling features that are described in this topic are generally pertinent to both .NET Framework XAML Services and WPF. To see this behavior in action, you might experiment with some WPF XAML markup, view the results in an object graph, and then serialize back to markup again.  
  
 Even for content models that can take strings, the default behavior within these content models is that any whitespace that remains is not treated as significant. For example, <xref:System.Windows.Controls.ListBox> takes an <xref:System.Collections.IList>, but the whitespace (such as linefeeds between each <xref:System.Windows.Controls.ListBoxItem>) is not preserved and not rendered. If you attempt to use linefeeds as separators between strings for <xref:System.Windows.Controls.ListBoxItem> items, it does not work at all; the strings that are separated by the linefeeds are treated as one string and one item.  
  
 Those collections that do treat whitespace as significant are typically part of the flow document model. The primary collection that supports whitespace preservation behavior is <xref:System.Windows.Documents.InlineCollection>. This collection class is declared with the <xref:System.Windows.Markup.WhitespaceSignificantCollectionAttribute>; when this attribute is found, the [!INCLUDE[TLA2#tla_xaml](../../../includes/tla2sharptla-xaml-md.md)] processor will treat whitespace within the collection as significant. The combination of `xml:space="preserve"` and whitespace within a <xref:System.Windows.Markup.WhitespaceSignificantCollectionAttribute> denoted collection is that all white space is preserved and rendered. The combination of `xml:space="default"` and whitespace within a <xref:System.Windows.Markup.WhitespaceSignificantCollectionAttribute> causes the initial whitespace normalization described earlier, which leaves one space in certain positions, and those spaces are preserved and rendered. Which behavior is desirable is up to you, and you should use `xml:space` selectively to enable the behavior that you want.  
  
 Also, certain inline elements that connote a linebreak in a flow document model should deliberately not introduce an extra space even in a whitespace significant collection. For example, the <xref:System.Windows.Documents.LineBreak> element has the same purpose as the \<BR/> tag in [!INCLUDE[TLA2#tla_html](../../../includes/tla2sharptla-html-md.md)], and for readability in markup, typically a <xref:System.Windows.Documents.LineBreak> is separated from any subsequent text by an authored linefeed. That linefeed should not be normalized to become a leading space in the subsequent line. To enable that behavior, the class definition for the <xref:System.Windows.Documents.LineBreak> element applies the <xref:System.Windows.Markup.TrimSurroundingWhitespaceAttribute>, which is then interpreted by the [!INCLUDE[TLA2#tla_xaml](../../../includes/tla2sharptla-xaml-md.md)] processor to mean that whitespace surrounding <xref:System.Windows.Documents.LineBreak> is always trimmed.  
  
## See Also  
 [XAML Overview (WPF)](../../../docs/framework/wpf/advanced/xaml-overview-wpf.md)  
 [XML Character Entities and XAML](../../../docs/framework/xaml-services/xml-character-entities-and-xaml.md)  
 [xml:space Handling in XAML](../../../docs/framework/xaml-services/xml-space-handling-in-xaml.md)

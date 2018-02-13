---
title: "XML Character Entities and XAML"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "&"
  - "&amp"
  - "&gt"
  - "&lt"
helpviewer_keywords: 
  - "XAML [XAML Services], special characters"
  - "ampersand (&) [XAML Services]"
  - "special characters [XAML Services]"
  - "apostrophe (') [XAML Services]"
  - "greater-than (>) character [XAML Services]"
  - "XAML [XAML Services], quotation mark (\")"
  - "XAML [XAML Services], apostrophe (')"
  - "& (ampersand) [XAML Services]"
  - "XAML [XAML Services], & (ampersand)"
  - "XAML [XAML Services], escape sequence"
  - "quotation mark (\") [XAML Services]"
  - "less-than (<) character [XAML Services]"
ms.assetid: 6896d0ce-74f7-420a-9ab4-de9bbf390e8d
caps.latest.revision: 23
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# XML Character Entities and XAML
XAML uses character entities defined in XML for special characters. This topic describes some specific character entities and general considerations for other XML concepts in XAML.  
  
<a name="character_entities_and_escaping_issues_that_are_unique_to_xaml"></a>   
## Character Entities and Escaping Issues That Are Unique to XAML  
 XAML markup typically uses the same character entities and escape sequences that are defined in XML.  
  
 The main exception is that braces ({ and }) have significance in XAML because these characters inform a XAML processor that a character sequence enclosed by braces must be interpreted as a markup extension. For more information about markup extensions, see [Markup Extensions for XAML Overview](../../../docs/framework/xaml-services/markup-extensions-for-xaml-overview.md).  
  
 However, you can still display the braces as literal characters by using an escape sequence that is particular to XAML instead of XML. For more information, see [{} Escape Sequence - Markup Extension](escape-sequence-markup-extension.md).  
  
 Note that a backslash (\\) does not require an escape sequence when it is handled as a string.  
  
<a name="xml_character_entities"></a>   
## XML Character Entities  
 As mentioned previously, most character entities and escape sequences that are typically used to write XAML markup are defined by XML. This topic does not provide the complete list of these entities; a detailed reference for the entities can be found in external documentation, such as in XML specifications. However, for convenience, this topic lists some of the specific XML character entities that are typically used in XAML markup.  
  
|Character|Entity|Notes|  
|---------------|------------|-----------|  
|& (ampersand)|\&amp;|Must be used both for attribute values and for content of an element.|  
|> (greater-than character)|\&gt;|Must be used for an attribute value, but > is acceptable as the content of an element as long as < does not precede it.|  
|< (less-than character)|\&lt;|Must be used for an attribute value, but \< is acceptable as the content of an element as long as > does not follow it.|  
|" (straight quotation mark)|\&quot;|Must be used for an attribute value, but a straight quotation mark (") is acceptable as the content of an element. Note that attribute values may be enclosed either by a single straight quotation mark (') or by a straight quotation mark ("); whichever character appears first defines the attribute value enclosure, and the alternative quote can then be used as a literal within the value.|  
|' (single straight quotation mark)|\&apos;|Must be used for an attribute value, but a single straight quotation mark (') is acceptable as the content of an element. Note that attribute values may be enclosed either by a single straight quotation mark (') or by a straight quotation mark ("); whichever character appears first defines the attribute value enclosure, and the alternative quote can then be used as a literal within the value.|  
|(numeric character mappings)|&#*[integer]*; or &#x*[hex]*;|XAML supports numeric character mappings into the encoding that is active.|  
|(nonbreaking space)|&\#160; (assuming UTF-8 encoding)|For flow document elements, or elements that take text such as the WPF <xref:System.Windows.Controls.TextBox>, nonbreaking spaces are not normalized out of the markup, even for `xml:space="default"`. (For more information, see [Whitespace Processing in XAML](../../../docs/framework/xaml-services/whitespace-processing-in-xaml.md).)|  
  
<a name="xml_comment_format"></a>   
## XML Comment Format  
 XAML uses the XML comment format: the start of the comment is `<!--`, the end of comment is `-->,` and the sequence `--` must not occur within the comment.  
  
<a name="xml_processing_instructions"></a>   
## XML Processing Instructions  
 XAML handles XML processing instructions according to XML specifications, which state that the instructions must be passed through. XAML processing in .NET Framework XAML Services  does not use any processing instructions. Other existing frameworks that use XAML also do not use processing instructions from XAML.  
  
## See Also  
 [XAML Overview (WPF)](../../../docs/framework/wpf/advanced/xaml-overview-wpf.md)  
 [Markup Extensions and WPF XAML](../../../docs/framework/wpf/advanced/markup-extensions-and-wpf-xaml.md)  
 [XamlName Grammar](../../../docs/framework/xaml-services/xamlname-grammar.md)  
 [Whitespace Processing in XAML](../../../docs/framework/xaml-services/whitespace-processing-in-xaml.md)

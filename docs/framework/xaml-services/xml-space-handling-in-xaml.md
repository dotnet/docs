---
title: "xml:space Handling in XAML"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "XAML [XAML Services], xml:space attribute"
  - "XAML [XAML Services], white-space processing"
  - "xml:space attribute [XAML Services]"
  - "white-space processing [XAML Services]"
ms.assetid: 5e1814f0-5b30-43d5-8c88-dede335a89d7
---
# xml:space Handling in XAML
The `xml:space` attribute is an XML-defined attribute that declares the significant white-space processing behavior within an object element. This behavior is relevant for all content (inner text) contained within the element where `xml:space` is declared, and also scopes to child elements.  
  
## XAML Attribute Usage  
  
```xaml  
<object xml:space="preserve" />  
```  
  
 \- or -  
  
```xaml  
<object xml:space="default" />  
```  
  
## Remarks  
 The definition for the `xml:space` attribute in XAML including its two possible values is derived from `xml:space` as defined as a "special attribute" by W3C specifications for XML.  
  
 The default value of the `xml:space` attribute is the literal value `"default"`. For the value `"default"`, or if `xml:space` is not indicated at all, the behavior of significant white-space parsing is the default handling, as defined in the topic [White-space processing in XAML](../../../docs/framework/xaml-services/whitespace-processing-in-xaml.md).  
  
 To preserve white space within object element content, specify `xml:space="preserve"` on that object element.  
  
 Under most interpretations, the `xml:space` attribute effects and the value of the attribute are scoped to child elements.  
  
 For a complete discussion of white-space processing in XAML, see [White-space processing in XAML](../../../docs/framework/xaml-services/whitespace-processing-in-xaml.md).  
  
## See Also  
 [White-space processing in XAML](../../../docs/framework/xaml-services/whitespace-processing-in-xaml.md)  
 [XAML Overview (WPF)](../../../docs/framework/wpf/advanced/xaml-overview-wpf.md)

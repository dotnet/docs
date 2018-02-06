---
title: "{} Escape Sequence - Markup Extension"
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
  - "{}"
helpviewer_keywords: 
  - "XAML [XAML Services], quotation mark (\")"
  - "{} escape sequence [XAML Services]"
  - "XAML [XAML Services], {} escape sequence"
  - "XAML [XAML Services], escape sequence"
  - "quotation mark (\") [XAML Services]"
  - "escape sequence [XAML Services]"
ms.assetid: 3ce3e2ad-a868-43f9-9c98-b29561cb146e
caps.latest.revision: 21
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# {} Escape Sequence / Markup Extension
Provides the XAML escape sequence for attribute values. The escape sequence allows the subsequent values in the attribute to be interpreted as a literal.  
  
## XAML Attribute Usage  
  
```xml  
<object property="{} literalValue" .../>  
```  
  
## XAML Property Element Usage  
  
```  
<object>  
  <object.property>  
    {} literalValue  
  </object.property>  
</object>  
```  
  
## XAML Values  
  
|||  
|-|-|  
|*literalValue*|The literal string that follows the escape sequence. Typically this string contains an open or close brace ({ or }).|  
  
## Remarks  
 The escape sequence ({}) is used so that an open brace ({)can be used as a literal character in XAML.  
  
 XAML readers typically use the open brace ({) to denote the entry point of a markup extension; however, they first check the next character to determine whether it is a closing brace (}). Only when the two braces ({}) are adjacent, are they considered an escape sequence.  
  
 If the escape sequence is encountered, the XAML reader should process the remainder of the string as a string. However, if the escape sequence is applied to a member that has a type converter, the string might undergo type conversion when it is interpreted by a XAML writer.  
  
 The escape sequence is not a markup extension and is not backed by a class. However, it is a convention that XAML readers (including custom XAML readers) should respect.  
  
 A quotation mark (") cannot be used as an escape sequence in this manner. If you need to set a quotation mark as a property value for a noncontent property, use property element syntax and place the quotation mark as a string inside the property element, or use an XML character entity. For a content property, the quotation mark can be the entire content.  
  
 The escape sequence ({}) is frequently required when specifying an XML type that must include a namespace qualifier in a location where a XAML markup extension might appear. This includes the start of a XAML attribute value, and in a markup extension, immediately after an equal sign (=). The following example shows escape sequences for an XML namespace that appears at the start of a XAML attribute value.  
  
 [!code-xaml[XLINQExample#StackPanelResources](../../../samples/snippets/csharp/VS_Snippets_Wpf/XLinqExample/CSharp/Window1.xaml#stackpanelresources)]  
  
## See Also  
 [Type Converters and Markup Extensions for XAML](../../../docs/framework/xaml-services/type-converters-and-markup-extensions-for-xaml.md)  
 [XML Character Entities and XAML](../../../docs/framework/xaml-services/xml-character-entities-and-xaml.md)

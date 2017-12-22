---
title: "XamlName Grammar"
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
  - "DottedXamlName grammar [XAML Services]"
  - "grammar [XAML Services], DottedXamlName"
  - "grammar [XAML Services], XamlName"
  - "names in XAML [XAML Services]"
  - "XamlName grammar [XAML Services]"
ms.assetid: 11e4cada-41d2-494d-9531-0d3df4dfcbe3
caps.latest.revision: 13
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# XamlName Grammar
XamlName Grammar is a specific grammar that is defined in the XAML language specification [MS-XAML], which is reproduced here for convenience.  
  
## From the XAML Specification  
 The [MS-XAML] specification defines the grammar XamlName to identify the set of legal symbolic identifiers used for types and properties.  
  
 String values that are of type XamlName must conform to the following grammar:  
  
```  
XamlName ::= NameStartChar ( NameChar )*   
NameStartChar ::= LetterCharacter | '_'   
NameChar ::= NameStartChar | DecimalDigit | CombiningCharacter   
LetterCharacter ::= UnicodeLu | UnicodeLl | UnicodeLo | UnicodeLt | UnicodeNl   
DecimalDigit ::= UnicodeNd   
CombiningCharacter ::= UnicodeMn | UnicodeMc  
```  
  
 Which assumes the following general category values as defined in the Unicode Character Database  
  
```  
Lu  
Letter, Uppercase  
Ll  
Letter, Lowercase  
Lt  
Letter, Titlecase  
Lm  
Letter, Modifier  
Lo  
Letter, Other  
Mn  
Mark, Non-Spacing  
Mc  
Mark, Spacing Combining  
Nd  
Number, Decimal  
Nl  
Number, Letter  
```  
  
 XAML defines a second grammar, DottedXamlName, that is used for property and event qualified references, and also for attached members. For more information, see <xref:System.Windows.DependencyProperty> and [XAML Overview (WPF)](../../../docs/framework/wpf/advanced/xaml-overview-wpf.md).  
  
 String values that are of type DottedXamlName must conform to the following grammar:  
  
```  
DottedXamlName ::= XamlName '.' XamlName  
```  
  
## Remarks  
 For the complete specification, see [\[MS-XAML\]](http://go.microsoft.com/fwlink/?LinkId=114525).

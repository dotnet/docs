---
title: "How to: Use Special Characters in XAML"
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
  - "Unicode UTF-8 file format"
  - "UTF-8 file format"
  - "characters [WPF], special"
  - "typography [WPF], special characters"
  - "special characters [WPF]"
ms.assetid: a57776d1-f353-4794-afa0-bfa3c712ed1c
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Use Special Characters in XAML
Markup files that are created in [!INCLUDE[TLA#tla_visualstu](../../../../includes/tlasharptla-visualstu-md.md)] are automatically saved in the [!INCLUDE[TLA#tla_unicode](../../../../includes/tlasharptla-unicode-md.md)] UTF-8 file format, which means that most special characters, such as accent marks, are encoded correctly. However, there is a set of commonly-used special characters that are handled differently. These special characters follow the [!INCLUDE[TLA#tla_w3c](../../../../includes/tlasharptla-w3c-md.md)][!INCLUDE[TLA#tla_xml](../../../../includes/tlasharptla-xml-md.md)] standard for encoding.  
  
 The following table shows the syntax for encoding this set of special characters:  
  
|Character|Syntax|Description|  
|---------------|------------|-----------------|  
|<|`<`|Less than symbol.|  
|>|`>`|Greater than sign.|  
|&|`&`|Ampersand symbol.|  
|"|`"`|Double quote symbol.|  
  
> [!NOTE]
>  If you create a markup file using a text editor, such as [!INCLUDE[TLA#tla_mswin](../../../../includes/tlasharptla-mswin-md.md)] Notepad, you must save the file in the [!INCLUDE[TLA#tla_unicode](../../../../includes/tlasharptla-unicode-md.md)] UTF-8 file format in order to preserve any encoded special characters.  
  
 The following example shows how you can use special characters in text when creating markup.  
  
## Example  
 [!code-xaml[SpecialCharsSnippets#SpecialCharsSnippet1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/SpecialCharsSnippets/CS/Window1.xaml#specialcharssnippet1)]

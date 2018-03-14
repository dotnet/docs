---
title: "x:Reference Markup Extension"
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
  - "x:Reference markup extension [XAML Services]"
  - "XAML [XAML Services], x:Reference Markup Extension"
  - "Reference markup extension [XAML Services]"
ms.assetid: 2982e68b-d26b-4aa3-826a-34c57a9c5199
caps.latest.revision: 8
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# x:Reference Markup Extension
References an instance that is declared elsewhere in XAML markup. The reference refers to an element's `x:Name`.  
  
## XAML Attribute Usage  
  
```xaml  
<object property="{x:Reference instancexName}" .../>  
```  
  
## XAML Object Element Usage  
  
```xaml  
<object>  
  <object.property>  
    <x:Reference Name="instancexName"/>  
  </object.property>  
</object>  
```  
  
## XAML Values  
  
|||  
|-|-|  
|`instancexName`|The `x:Name` value (or value of the <xref:System.Windows.Markup.RuntimeNamePropertyAttribute>-identified property) of the referenced instance.|  
  
## Remarks  
 `x:Reference` provides XAML language-level support for an element reference concept that was otherwise implemented in specific frameworks such as WPF.  
  
## x:Reference and WPF  
 In WPF and XAML 2006, element references are addressed by the framework-level feature of <xref:System.Windows.Data.Binding.ElementName%2A> binding. For most WPF applications and scenarios, <xref:System.Windows.Data.Binding.ElementName%2A> binding should still be used. Exceptions to this general guidance might include cases where there are data context or other scoping considerations that make data binding impractical and where markup compilation is not involved.  
  
 `x:Reference` is a construct defined in XAML 2009. In WPF, you can use XAML 2009 features, but only for XAML that is not WPF markup-compiled. Markup-compiled XAML and the BAML form of XAML do not currently support the XAML 2009 language keywords and features.

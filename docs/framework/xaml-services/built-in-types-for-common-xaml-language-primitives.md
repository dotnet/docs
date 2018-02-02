---
title: "Built-in Types for Common XAML Language Primitives"
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
  - "XAML language primitives [XAML Services]"
  - "XAML [XAML Services], built-in types"
  - "x:String [XAML Services]"
  - "x:TimeSpan [XAML Services]"
  - "x:Byte [XAML Services]"
  - "x:Double [XAML Services]"
  - "XAML [XAML Services], types"
  - "x:Uri [XAML Services]"
  - "XAML built-in types [XAML Services]"
  - "x:Int64 [XAML Services]"
  - "x:Single [XAML Services]"
  - "x:Int32 [XAML Services]"
ms.assetid: 11de2f08-5b95-4989-b5ec-5178eb968184
caps.latest.revision: 11
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Built-in Types for Common XAML Language Primitives
XAML 2009 introduces XAML language-level support for several data types that are frequently used primitives in the common language runtime (CLR) and in other programming languages. XAML 2009 adds support for these primitives: `x:Object`, `x:Boolean`, `x:Char`, `x:String`, `x:Decimal`, `x:Single`, `x:Double`, `x:Int16`, `x:Int32`, `x:Int64`, `x:TimeSpan`, `x:Uri`, `x:Byte`, and `x:Array`  
  
<a name="previous_techniques_for_language_primitives_in_xaml_markup"></a>   
## Previous Techniques for Language Primitives in XAML Markup  
 In XAML for previous WPF versions, you could reference the CLR language primitives by mapping the assembly and namespace that contained a CLR primitive definition class for the .NET Framework. Most of these are in the mscorlib assembly and <xref:System> namespace. For example, to use <xref:System.Int32>, you could declare the following mapping (with an example usage shown thereafter):  
  
```  
<Application xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"  
xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"   
xmlns:sys="clr-namespace:System;assembly=mscorlib">  
  <Application.Resources>  
    <sys:Int32 x:Key="intMeaning">42</sys:Int32>  
  </Application.Resources>  
</Application>  
```  
  
<a name="xaml_2009_language_primitives"></a>   
## XAML 2009 Language Primitives  
 By convention, the language primitives for XAML and all other XAML language elements are shown, including the `x:` prefix. This is how XAML language elements are typically used in real-world markup. This convention is followed in the conceptual documentation for XAML in WPF and also in the XAML specification.  
  
### x:Object  
 For CLR backing, the `x:Object` primitive corresponds to <xref:System.Object>.  
  
 This primitive is not typically used in application markup, but might be useful for some scenarios such as checking assignability in a XAML type system.  
  
### x:Boolean  
 For CLR backing, the `x:Boolean` primitive corresponds to <xref:System.Boolean>.  
  
 XAML parses values for `x:Boolean` as case insensitive. Note that `x:Bool` is not an accepted alternative. For the XAML language specification definition, see [\[MS-XAML\] Sections 5.2.17 and 5.4.11](http://go.microsoft.com/fwlink/?LinkId=114525).  
  
### x:Char  
 For CLR backing, the `x:Char` primitive corresponds to <xref:System.Char>.  
  
 String and char types have interaction with the overall encoding of the file at the XML level. For the XAML language specification definition, see [\[MS-XAML\] Sections 5.2.7 and 5.4.1](http://go.microsoft.com/fwlink/?LinkId=114525).  
  
### x:String  
 For CLR backing, the `x:String` primitive corresponds to <xref:System.String>.  
  
 String and char types have interaction with the overall encoding of the file at the XML level. For the XAML language specification definition, see [\[MS-XAML\] Sections 5.2.6](http://go.microsoft.com/fwlink/?LinkId=114525).  
  
### x:Decimal  
 For CLR backing, the `x:Decimal` primitive corresponds to <xref:System.Decimal>.  
  
 Note that XAML parsing is inherently done under `en-US` culture. Under `en-US` culture, the correct separator for the components of a decimal is always a period (`.`) regardless of culture settings of the development environment, or of the eventual client target where the XAML is loaded at run time.  
  
 For the XAML language specification definition, see [\[MS-XAML\] Sections 5.2.14 and 5.4.8](http://go.microsoft.com/fwlink/?LinkId=114525).  
  
### x:Single  
 For CLR backing, the `x:Single` primitive corresponds to <xref:System.Single>.  
  
 In addition to the numeric values, text syntax for `x:Single` also permits the tokens `Infinity`, `-Infinity`, and `NaN`. These tokens are treated as case sensitive.  
  
 `x:Single` can support values in scientific notation form, if the first character in text syntax is `e` or `E`.  
  
 For the XAML language specification definition, see [\[MS-XAML\] Sections 5.2.8 and 5.4.2](http://go.microsoft.com/fwlink/?LinkId=114525).  
  
### x:Double  
 For CLR backing, the `x:Double` primitive corresponds to <xref:System.Double>.  
  
 In addition to the numeric values, text syntax for `x:Double` permits the tokens `Infinity`, `-Infinity`, and `NaN`. These tokens are treated as case sensitive.  
  
 `x:Double` can support values in scientific notation form. Use the character `e` or `E` to introduce the exponent portion.  
  
 For the XAML language specification definition, see [\[MS-XAML\] Sections 5.2.9 and 5.4.3](http://go.microsoft.com/fwlink/?LinkId=114525).  
  
### x:Int16  
 For CLR backing, the `x:Int16` primitive corresponds to <xref:System.Int16> and `x:Int16` is treated as signed. In XAML, the absence of a plus (`+`) sign in text syntax is implied as a positive signed value.  
  
 For the XAML language specification definition, see [\[MS-XAML\] Sections 5.2.11 and 5.4.5](http://go.microsoft.com/fwlink/?LinkId=114525).  
  
### x:Int32  
 For CLR backing, the `x:Int32` primitive corresponds to <xref:System.Int32>. `x:Int32` is treated as signed. In XAML, the absence of a plus (`+`) sign in text syntax is implied as a positive signed value.  
  
 For the XAML language specification definition, see [\[MS-XAML\] Sections 5.2.12 and 5.4.6](http://go.microsoft.com/fwlink/?LinkId=114525).  
  
### x:Int64  
 For CLR backing, the `x:Int64` primitive corresponds to <xref:System.Int64>. `x:Int64` is treated as signed. In XAML, the absence of a plus (`+`) sign in text syntax is implied as a positive signed value.  
  
 For the XAML language specification definition, see [\[MS-XAML\] Sections 5.2.13 and 5.4.7](http://go.microsoft.com/fwlink/?LinkId=114525).  
  
### x:TimeSpan  
 For CLR backing, the `x:TimeSpan` primitive corresponds to <xref:System.TimeSpan>.  
  
 Note that XAML parsing for time-date format is inherently done under `en-US` culture.  
  
 For the XAML language specification definition, see [\[MS-XAML\] Sections 5.2.16 and 5.4.10](http://go.microsoft.com/fwlink/?LinkId=114525).  
  
### x:Uri  
 For CLR backing, the `x:Uri` primitive corresponds to <xref:System.Uri>.  
  
 Checking for protocols is not part of the XAML definition for `x:Uri`.  
  
 For the XAML language specification definition, see [\[MS-XAML\] Sections 5.2.15 and 5.4.9](http://go.microsoft.com/fwlink/?LinkId=114525).  
  
### x:Byte  
 For CLR backing, the `x:Byte` primitive corresponds to <xref:System.Byte>. A <xref:System.Byte> / `x:Byte` is treated as unsigned.  
  
 For the XAML language specification definition, see [\[MS-XAML\] Sections 5.2.10 and 5.4.4](http://go.microsoft.com/fwlink/?LinkId=114525).  
  
### x:Array  
 For CLR backing, the `x:Array` primitive corresponds to <xref:System.Array>.  
  
 You can define an array in XAML 2006  by using a markup extension syntax; however, the XAML 2009 syntax is a language-defined primitive that does not require accessing a markup extension. For more information about XAML 2006 support, see [x:Array Markup Extension](../../../docs/framework/xaml-services/x-array-markup-extension.md).  
  
 For the XAML language specification definition, see [\[MS-XAML\] Sections 5.2.18](http://go.microsoft.com/fwlink/?LinkId=114525).  
  
<a name="wpf_support"></a>   
## WPF Support  
 In WPF, you can use XAML 2009 features but only for XAML that is not markup-compiled. Markup-compiled XAML for WPF and the BAML form of XAML do not currently support the XAML 2009 keywords and features.  
  
 A scenario where you can use XAML 2009 features together with WPF is if you author loose XAML and you then load that XAML into a WPF runtime and object graph with <xref:System.Windows.Markup.XamlReader.Load%2A?displayProperty=nameWithType>. The WPF <xref:System.Windows.Markup.XamlReader?displayProperty=nameWithType> and its <xref:System.Windows.Markup.XamlReader.Load%2A> can process XAML 2009 language keywords and features into a valid object graph representation.

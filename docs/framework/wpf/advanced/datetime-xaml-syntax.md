---
title: "DateTime XAML Syntax"
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
  - "DateTime XAML syntax [WPF], strings for"
  - "DateTime XAML syntax [WPF], where used"
  - "short date format [WPF], DateTime"
  - "DateTime XAML syntax [WPF]"
  - "DateTime XAML text [WPF]"
  - "DateTime XAML syntax [WPF], format strings for"
ms.assetid: 5901710a-609b-40c8-9d65-f0016cd9090b
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# DateTime XAML Syntax
Some controls, such as <xref:System.Windows.Controls.Calendar> and <xref:System.Windows.Controls.DatePicker>, have properties that use the <xref:System.DateTime> type. Although you typically specify an initial date or time for these controls in the code-behind at run time, you can specify an initial date or time in XAML. The WPF XAML parser handles parsing of <xref:System.DateTime> values using a built-in XAML text syntax. This topic describes the specifics of the <xref:System.DateTime> XAML text syntax.  
  
  
<a name="where_datetime_xaml_syntax_is_used"></a>   
## When To Use DateTime XAML Syntax  
 Setting dates in XAML is not always necessary and may not even be desirable. For example, you could use the <xref:System.DateTime.Now%2A?displayProperty=nameWithType> property to initialize a date at run time, or you could do all your date adjustments for a calendar in the code-behind based on user input. However, there are scenarios where you may want to hard-code dates into a <xref:System.Windows.Controls.Calendar> and <xref:System.Windows.Controls.DatePicker> in a control template. The <xref:System.DateTime> XAML syntax must be used for these scenarios.  
  
### DateTime XAML Syntax is a Native Behavior  
 <xref:System.DateTime> is a class that is defined in the base class libraries of the CLR. Because of how the base class libraries relate to the rest of the CLR, it is not possible to apply <xref:System.ComponentModel.TypeConverterAttribute> to the class and use a type converter to process strings from XAML and convert them to <xref:System.DateTime> in the run time object model. There is no `DateTimeConverter` class that provides the conversion behavior; the conversion behavior described in this topic is native to the WPF XAML parser.  
  
<a name="format_strings_for_datetime_xaml_syntax"></a>   
## Format Strings for DateTime XAML Syntax  
 You can specify the format of a <xref:System.DateTime> with a format string. Format strings formalize the text syntax that can be used to create a value. <xref:System.DateTime> values for the existing WPF controls generally only use the date components of <xref:System.DateTime> and not the time components.  
  
 When specifying a <xref:System.DateTime> in XAML, you can use any of the format strings interchangeably.  
  
 You can also use formats and format strings that are not specifically shown in this topic. Technically, the XAML for any <xref:System.DateTime> value that is specified and then parsed by the WPF XAML parser uses an internal  call to <xref:System.DateTime.Parse%2A?displayProperty=nameWithType>, therefore you could use any string accepted by <xref:System.DateTime.Parse%2A?displayProperty=nameWithType> for your XAML input. For more information, see <xref:System.DateTime.Parse%2A?displayProperty=nameWithType>.  
  
> [!IMPORTANT]
>  The DateTime XAML syntax always uses `en-us` as the <xref:System.Globalization.CultureInfo> for its native conversion. This is not influenced by <xref:System.Windows.FrameworkElement.Language%2A> value or `xml:lang` value in the XAML, because XAML attribute-level type conversion acts without that context. Do not attempt to interpolate the format strings shown here due to cultural variations, such as the order in which day and month appear. The format strings shown here are the exact format strings used when parsing the XAML regardless of other culture settings.  
  
 The following sections describe some of the common <xref:System.DateTime> format strings.  
  
### Short Date Pattern ("d")  
 The following shows the short date format for a <xref:System.DateTime> in XAML:  
  
 `M/d/YYYY`  
  
 This is the simplest form that specifies all necessary information for typical usages by WPF controls, and cannot be influenced by accidental time zone offsets versus a time component, and is therefore recommended over the other formats.  
  
 For example, to specify the date of June 1, 2010, use the following string:  
  
 `3/1/2010`  
  
 For more information, see <xref:System.Globalization.DateTimeFormatInfo.ShortDatePattern%2A?displayProperty=nameWithType>.  
  
### Sortable DateTime Pattern ("s")  
 The following shows the sortable <xref:System.DateTime> pattern in XAML:  
  
 `yyyy'-'MM'-'dd'T'HH':'mm':'ss`  
  
 For example, to specify the date of June 1, 2010, use the following string (time components are all entered as 0):  
  
 `2010-06-01T000:00:00`  
  
### RFC1123 Pattern ("r")  
 The RFC1123 pattern is useful because it could be a string input from other date generators that also use the RFC1123 pattern for culture invariant reasons. The following shows the RFC1123 <xref:System.DateTime> pattern in XAML:  
  
 `ddd, dd MMM yyyy HH':'mm':'ss 'UTC'`  
  
 For example, to specify the date of June 1, 2010, use the following string (time components are all entered as 0):  
  
 `Mon, 01 Jun 2010 00:00:00 UTC`  
  
### Other Formats and Patterns  
 As stated previously, a <xref:System.DateTime> in XAML can be specified as any string that is acceptable as input for <xref:System.DateTime.Parse%2A?displayProperty=nameWithType>. This includes other formalized formats (for example <xref:System.Globalization.DateTimeFormatInfo.UniversalSortableDateTimePattern%2A>), and formats that are not formalized as a particular <xref:System.Globalization.DateTimeFormatInfo> form. For example, the form `YYYY/mm/dd` is acceptable as input for <xref:System.DateTime.Parse%2A?displayProperty=nameWithType>. This topic does not attempt to describe all possible formats that work, and instead recommends the short date pattern as a standard practice.  
  
## See Also  
 [XAML Overview (WPF)](../../../../docs/framework/wpf/advanced/xaml-overview-wpf.md)

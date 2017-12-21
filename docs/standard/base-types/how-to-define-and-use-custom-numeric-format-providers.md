---
title: "How to: Define and Use Custom Numeric Format Providers"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "numeric format strings [.NET Framework]"
  - "formatting [.NET Framework], numbers"
  - "number formatting [.NET Framework]"
  - "custom numeric format strings"
  - "numbers [.NET Framework], custom numeric format strings"
  - "displaying date and time data"
  - "format providers [.NET Framework]"
  - "custom format strings"
ms.assetid: a281bfbf-6596-45ed-a2d6-3782d535ada2
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Define and Use Custom Numeric Format Providers
The [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] gives you extensive control over the string representation of numeric values. It supports the following features for customizing the format of numeric values:  
  
-   Standard numeric format strings, which provide a predefined set of formats for converting numbers to their string representation. You can use them with any numeric formatting method, such as <xref:System.Decimal.ToString%28System.String%29?displayProperty=nameWithType>, that has a `format` parameter. For details, see [Standard Numeric Format Strings](../../../docs/standard/base-types/standard-numeric-format-strings.md).  
  
-   Custom numeric format strings, which provide a set of symbols that can be combined to define custom numeric format specifiers. They can also be used with any numeric formatting method, such as <xref:System.Decimal.ToString%28System.String%29?displayProperty=nameWithType>, that has a `format` parameter. For details, see [Custom Numeric Format Strings](../../../docs/standard/base-types/custom-numeric-format-strings.md).  
  
-   Custom <xref:System.Globalization.CultureInfo> or <xref:System.Globalization.NumberFormatInfo> objects, which define the symbols and format patterns used in displaying the string representations of numeric values. You can use them with any numeric formatting method, such as <xref:System.Int32.ToString%2A>, that has a `provider` parameter. Typically, the `provider` parameter is used to specify culture-specific formatting.  
  
 In some cases (such as when an application must display a formatted account number, an identification number, or a postal code) these three techniques are inappropriate. The [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] also enables you to define a formatting object that is neither a <xref:System.Globalization.CultureInfo> nor a <xref:System.Globalization.NumberFormatInfo> object to determine how a numeric value is formatted. This topic provides the step-by-step instructions for implementing such an object, and provides an example that formats telephone numbers.  
  
### To define a custom format provider  
  
1.  Define a class that implements the <xref:System.IFormatProvider> and <xref:System.ICustomFormatter> interfaces.  
  
2.  Implement the <xref:System.IFormatProvider.GetFormat%2A?displayProperty=nameWithType> method. <xref:System.IFormatProvider.GetFormat%2A> is a callback method that the formatting method (such as the <xref:System.String.Format%28System.IFormatProvider%2CSystem.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType> method) invokes to retrieve the object that is actually responsible for performing custom formatting. A typical implementation of <xref:System.IFormatProvider.GetFormat%2A> does the following:  
  
    1.  Determines whether the <xref:System.Type> object passed as a method parameter represents an <xref:System.ICustomFormatter> interface.  
  
    2.  If the parameter does represent the <xref:System.ICustomFormatter> interface, <xref:System.IFormatProvider.GetFormat%2A> returns an object that implements the <xref:System.ICustomFormatter> interface that is responsible for providing custom formatting. Typically, the custom formatting object returns itself.  
  
    3.  If the parameter does not represent the <xref:System.ICustomFormatter> interface, <xref:System.IFormatProvider.GetFormat%2A> returns `null`.  
  
3.  Implement the <xref:System.ICustomFormatter.Format%2A> method. This method is called by the <xref:System.String.Format%28System.IFormatProvider%2CSystem.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType> method and is responsible for returning the string representation of a number. Implementing the method typically involves the following:  
  
    1.  Optionally, make sure that the method is legitimately intended to provide formatting services by examining the `provider` parameter. For formatting objects that implement both <xref:System.IFormatProvider> and <xref:System.ICustomFormatter>, this involves testing the `provider` parameter for equality with the current formatting object.  
  
    2.  Determine whether the formatting object should support custom format specifiers. (For example, an "N" format specifier might indicate that a U.S. telephone number should be output in NANP format, and an "I" might indicate output in ITU-T Recommendation E.123 format.) If format specifiers are used, the method should handle the specific format specifier. It is passed to the method in the `format` parameter. If no specifier is present, the value of the `format` parameter is <xref:System.String.Empty?displayProperty=nameWithType>.  
  
    3.  Retrieve the numeric value passed to the method as the `arg` parameter. Perform whatever manipulations are required to convert it to its string representation.  
  
    4.  Return the string representation of the `arg` parameter.  
  
### To use a custom numeric formatting object  
  
1.  Create a new instance of the custom formatting class.  
  
2.  Call the <xref:System.String.Format%28System.IFormatProvider%2CSystem.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType> formatting method, passing it the custom formatting object, the formatting specifier (or <xref:System.String.Empty?displayProperty=nameWithType>, if one is not used), and the numeric value to be formatted.  
  
## Example  
 The following example defines a custom numeric format provider named `TelephoneFormatter` that converts a number that represents a U.S. telephone number to its NANP or E.123 format. The method handles two format specifiers, "N" (which outputs the NANP format) and "I" (which outputs the international E.123 format).  
  
 [!code-csharp[Formatting.HowTo.NumericValue#1](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.HowTo.NumericValue/cs/Telephone1.cs#1)]
 [!code-vb[Formatting.HowTo.NumericValue#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.HowTo.NumericValue/vb/Telephone1.vb#1)]  
  
 The custom numeric format provider can be used only with the <xref:System.String.Format%28System.IFormatProvider%2CSystem.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType> method. The other overloads of numeric formatting methods (such as `ToString`) that have a parameter of type <xref:System.IFormatProvider> all pass the <xref:System.IFormatProvider.GetFormat%2A?displayProperty=nameWithType> implementation a <xref:System.Type> object that represents the <xref:System.Globalization.NumberFormatInfo> type. In return, they expect the method to return a <xref:System.Globalization.NumberFormatInfo> object. If it does not, the custom numeric format provider is ignored, and the <xref:System.Globalization.NumberFormatInfo> object for the current culture is used in its place. In the example, the `TelephoneFormatter.GetFormat` method handles the possibility that it may be inappropriately passed to a numeric formatting method by examining the method parameter and returning `null` if it represents a type other than <xref:System.ICustomFormatter>.  
  
 If a custom numeric format provider supports a set of format specifiers, make sure you provide a default behavior if no format specifier is supplied in the format item used in the <xref:System.String.Format%28System.IFormatProvider%2CSystem.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType> method call. In the example, "N" is the default format specifier. This allows for a number to be converted to a formatted telephone number by providing an explicit format specifier. The following example illustrates such a method call.  
  
 [!code-csharp[Formatting.HowTo.NumericValue#2](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.HowTo.NumericValue/cs/Telephone1.cs#2)]
 [!code-vb[Formatting.HowTo.NumericValue#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.HowTo.NumericValue/vb/Telephone1.vb#2)]  
  
 But it also allows the conversion to occur if no format specifier is present. The following example illustrates such a method call.  
  
 [!code-csharp[Formatting.HowTo.NumericValue#3](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.HowTo.NumericValue/cs/Telephone1.cs#3)]
 [!code-vb[Formatting.HowTo.NumericValue#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.HowTo.NumericValue/vb/Telephone1.vb#3)]  
  
 If no default format specifier is defined, your implementation of the <xref:System.ICustomFormatter.Format%2A?displayProperty=nameWithType> method should include code such as the following so that .NET can provide formatting that your code does not support.  
  
 [!code-csharp[System.ICustomFormatter.Format#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.ICustomFormatter.Format/cs/format.cs#1)]
 [!code-vb[System.ICustomFormatter.Format#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.ICustomFormatter.Format/vb/Format.vb#1)]  
  
 In the case of this example, the method that implements <xref:System.ICustomFormatter.Format%2A?displayProperty=nameWithType> is intended to serve as a callback method for the <xref:System.String.Format%28System.IFormatProvider%2CSystem.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType> method. Therefore, it examines the `formatProvider` parameter to determine whether it contains a reference to the current `TelephoneFormatter` object. However, the method can also be called directly from code. In that case, you can use the `formatProvider` parameter to provide a <xref:System.Globalization.CultureInfo> or <xref:System.Globalization.NumberFormatInfo> object that supplies culture-specific formatting information.  
  
## Compiling the Code  
 Compile the code at the command line using csc.exe or vb.exe. To compile the code in [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)], put it in a console application project template.  
  
## See Also  
 [Performing Formatting Operations](../../../docs/standard/base-types/performing-formatting-operations.md)

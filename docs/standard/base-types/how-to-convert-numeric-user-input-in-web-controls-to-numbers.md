---
title: "How to: Convert Numeric User Input in Web Controls to Numbers"
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
  - "parsing strings [.NET Framework], numeric strings"
  - "converting numeric user input to number"
  - "numbers [.NET Framework], converting numeric user input to number"
ms.assetid: f27ddfb8-7479-4b79-8879-02a3bd8402d4
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Convert Numeric User Input in Web Controls to Numbers
Because a Web page can be displayed anywhere in the world, users can input numeric data into a <xref:System.Web.UI.WebControls.TextBox> control in an almost unlimited number of formats. As a result, it is very important to determine the locale and culture of the Web page's user. When you parse user input, you can then apply the formatting conventions defined by the user's locale and culture.  
  
### To convert numeric input from a Web TextBox control to a number  
  
1.  Determine whether the string array returned by the <xref:System.Web.HttpRequest.UserLanguages%2A?displayProperty=nameWithType> property is populated. If it is not, continue to step 6.  
  
2.  If the string array returned by the <xref:System.Web.HttpRequest.UserLanguages%2A> property is populated, retrieve its first element. The first element indicates the user's default or preferred language and region.  
  
3.  Instantiate a <xref:System.Globalization.CultureInfo> object that represents the user's preferred culture by calling the <xref:System.Globalization.CultureInfo.%23ctor%28System.String%2CSystem.Boolean%29?displayProperty=nameWithType> constructor.  
  
4.  Call either the `TryParse` or the `Parse` method of the numeric type that you want to convert the user's input to. Use an overload of the `TryParse` or the `Parse` method with a `provider` parameter, and pass it either of the following:  
  
    -   The <xref:System.Globalization.CultureInfo> object created in step 3.  
  
    -   The <xref:System.Globalization.NumberFormatInfo> object that is returned by the <xref:System.Globalization.CultureInfo.NumberFormat%2A> property of the <xref:System.Globalization.CultureInfo> object created in step 3.  
  
5.  If the conversion fails, repeat steps 2 through 4 for each remaining element in the string array returned by the <xref:System.Web.HttpRequest.UserLanguages%2A> property.  
  
6.  If the conversion still fails or if the string array returned by the <xref:System.Web.HttpRequest.UserLanguages%2A> property is empty, parse the string by using the invariant culture, which is returned by the <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType> property.  
  
## Example  
 The following example is the complete code-behind page for a Web form that asks the user to enter a numeric value in a <xref:System.Web.UI.WebControls.TextBox> control and converts it to a number. That number is then doubled and displayed by using the same formatting rules as the original input.  
  
 [!code-csharp[Formatting.HowTo.ParseNumericInput#1](../../../samples/snippets/csharp/VS_Snippets_CLR/Formatting.HowTo.ParseNumericInput/cs/NumericUserInput1.aspx.cs#1)]
 [!code-vb[Formatting.HowTo.ParseNumericInput#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Formatting.HowTo.ParseNumericInput/vb/NumericUserInput1.aspx.vb#1)]  
  
 The <xref:System.Web.HttpRequest.UserLanguages%2A?displayProperty=nameWithType> property is populated from the culture names that are contained in `Accept-Language` headers included in an HTTP request. However, not all browsers include `Accept-Language` headers in their requests, and users can also suppress the headers completely. This makes it important to have a fallback culture when parsing user input. Typically, the fallback culture is the invariant culture returned by <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType>. Users can also provide Internet Explorer with culture names that they input in a text box, which creates the possibility that the culture names may not be valid. This makes it important to use exception handling when instantiating a <xref:System.Globalization.CultureInfo> object.  
  
 When retrieved from an HTTP request submitted by Internet Explorer, the <xref:System.Web.HttpRequest.UserLanguages%2A?displayProperty=nameWithType> array is populated in order of user preference. The first element in the array contains the name of the user's primary culture/region. If the array contains any additional items, Internet Explorer arbitrarily assigns them a quality specifier, which is delimited from the culture name by a semicolon. For example, an entry for the fr-FR culture might take the form `fr-FR;q=0.7`.  
  
 The example calls the <xref:System.Globalization.CultureInfo.%23ctor%2A> constructor with its `useUserOverride` parameter set to `false` to create a new <xref:System.Globalization.CultureInfo> object. This ensures that, if the culture name is the default culture name on the server, the new <xref:System.Globalization.CultureInfo> object created by the class constructor contains a culture's default settings and does not reflect any settings overridden by using the server's **Regional and Language Options** application. The values from any overridden settings on the server are unlikely to exist on the user's system or to be reflected in the user's input.  
  
 Your code can call either the `Parse` or the `TryParse` method of the numeric type that the user's input will be converted to. Repeated calls to a parse method may be required for a single parsing operation. As a result, the `TryParse` method is better, because it returns `false` if a parse operation fails. In contrast, handling the repeated exceptions that may be thrown by the `Parse` method can be a very expensive proposition in a Web application.  
  
## Compiling the Code  
 To compile the code, copy it into an [!INCLUDE[vstecasp](../../../includes/vstecasp-md.md)] code-behind page so that it replaces all the existing code. The [!INCLUDE[vstecasp](../../../includes/vstecasp-md.md)] Web page should contain the following controls:  
  
-   A <xref:System.Web.UI.WebControls.Label> control, which is not referenced in code. Set its <xref:System.Web.UI.WebControls.TextBox.Text%2A> property to "Enter a Number:".  
  
-   A <xref:System.Web.UI.WebControls.TextBox> control named `NumericString`.  
  
-   A <xref:System.Web.UI.WebControls.Button> control named `OKButton`. Set its <xref:System.Web.UI.WebControls.Button.Text%2A> property to "OK".  
  
 Change the name of the class from `NumericUserInput` to the name of the class that is defined by the `Inherits` attribute of the [!INCLUDE[vstecasp](../../../includes/vstecasp-md.md)] page's `Page` directive. Change the name of the `NumericInput` object reference to the name defined by the `id` attribute of the [!INCLUDE[vstecasp](../../../includes/vstecasp-md.md)] page's `form` tag.  
  
## .NET Framework Security  
 To prevent a user from injecting script into the HTML stream, user input should never be directly echoed back in the server response. Instead, it should be encoded by using the <xref:System.Web.HttpServerUtility.HtmlEncode%2A?displayProperty=nameWithType> method.  
  
## See Also  
 [Performing Formatting Operations](../../../docs/standard/base-types/performing-formatting-operations.md)  
 [Parsing Numeric Strings](../../../docs/standard/base-types/parsing-numeric.md)

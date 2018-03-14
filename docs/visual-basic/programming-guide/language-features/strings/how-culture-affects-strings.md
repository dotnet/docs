---
title: "How Culture Affects Strings in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "locale [Visual Basic], effect on strings"
  - "strings [Visual Basic], locale dependence"
ms.assetid: c4664444-ee0d-47bf-bef1-eaa3c54bdd7f
caps.latest.revision: 20
author: dotnet-bot
ms.author: dotnetcontent
---
# How Culture Affects Strings in Visual Basic
This Help page discusses how [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] uses culture information to perform string conversions and comparisons.  
  
## When to Use Culture-Specific Strings  
 Typically, you should use culture-specific strings for all data presented to and read from users, and use culture-invariant strings for your application's internal data.  
  
 For example, if your application asks users to enter a date as a string, it should expect users to format the strings according to their culture, and the application should convert the string appropriately. If your application then presents that date in its user interface, it should present it in the user's culture.  
  
 However, if the application uploads the date to a central server, it should format the string according to one specific culture, to prevent confusion between potentially different date formats.  
  
## Culture-Sensitive Functions  
 All of the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] string-conversion functions (except for the `Str` and `Val` functions) use the application's culture information to make sure that the conversions and comparisons are appropriate for the culture of the application's user.  
  
 The key to successfully using string-conversion functions in applications that run on computers with different culture settings is to understand which functions use a specific culture setting, and which use the current culture setting. Notice that the application's culture settings are, by default, inherited from the culture settings of the operating system. For more information, see <xref:Microsoft.VisualBasic.Strings.Asc%2A>, <xref:Microsoft.VisualBasic.Strings.AscW%2A>, <xref:Microsoft.VisualBasic.Strings.Chr%2A>, <xref:Microsoft.VisualBasic.Strings.ChrW%2A>, <xref:Microsoft.VisualBasic.Strings.Format%2A>, <xref:Microsoft.VisualBasic.Conversion.Hex%2A>, <xref:Microsoft.VisualBasic.Conversion.Oct%2A>, and [Type Conversion Functions](../../../../visual-basic/language-reference/functions/type-conversion-functions.md).  
  
 The `Str` (converts numbers to strings) and `Val` (converts strings to numbers) functions do not use the application's culture information when converting between strings and numbers. Instead, they recognize only the period (.) as a valid decimal separator. The culturally-aware analogues of these functions are:  
  
-   **Conversions that use the current culture.** The `CStr` and `Format` functions convert a number to a string, and the `CDbl` and `CInt` functions convert a string to a number.  
  
-   **Conversions that use a specific culture.** Each number object has a `ToString(IFormatProvider)` method that converts a number to a string, and a `Parse(String, IFormatProvider)` method that converts a string to a number. For example, the `Double` type provides the <xref:System.Double.ToString%28System.IFormatProvider%29> and <xref:System.Double.Parse%28System.String%2CSystem.IFormatProvider%29> methods.  
  
 For more information, see <xref:Microsoft.VisualBasic.Conversion.Str%2A> and <xref:Microsoft.VisualBasic.Conversion.Val%2A>.  
  
## Using a Specific Culture  
 Imagine that you are developing an application that sends a date (formatted as a string) to a Web service. In this case, your application must use a specific culture for the string conversion. To illustrate why, consider the result of using the date's <xref:System.DateTime.ToString> method: If your application uses that method to format the date July 4, 2005, it returns "7/4/2005 12:00:00 AM" when run with the United States English (en-US) culture, but it returns "04.07.2005 00:00:00" when run with the German (de-DE) culture.  
  
 When you need to perform a string conversion in a specific culture format, you should use the `CultureInfo` class that is built into the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)]. You can create a new `CultureInfo` object for a specific culture by passing the culture's name to the <xref:System.Globalization.CultureInfo.%23ctor%2A> constructor. The supported culture names are listed in the <xref:System.Globalization.CultureInfo> class Help page.  
  
 Alternatively, you can get an instance of the *invariant culture* from the <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType> property. The invariant culture is based on the English culture, but there are some differences. For example, the invariant culture specifies a 24-hour clock instead of a 12-hour clock.  
  
 To convert a date to the culture's string, pass the <xref:System.Globalization.CultureInfo> object to the date object's <xref:System.DateTime.ToString%28System.IFormatProvider%29> method. For example, the following code displays "07/04/2005 00:00:00", regardless of the application's culture settings.  
  
 [!code-vb[VbVbalrConcepts#1](../../../../visual-basic/programming-guide/language-features/operators-and-expressions/codesnippet/VisualBasic/how-culture-affects-strings_1.vb)]  
  
> [!NOTE]
>  Date literals are always interpreted according to the English culture.  
  
## Comparing Strings  
 There are two important situations where string comparisons are needed:  
  
-   **Sorting data for display to the user.** Use operations based on the current culture so the strings sort appropriately.  
  
-   **Determining if two application-internal strings exactly match (typically for security purposes).** Use operations that disregard the current culture.  
  
 You can perform both types of comparisons with the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] <xref:Microsoft.VisualBasic.Strings.StrComp%2A> function. Specify the optional `Compare` argument to control the type of comparison: `Text` for most input and output `Binary` for determining exact matches.  
  
 The `StrComp` function returns an integer that indicates the relationship between the two compared strings based on the sorting order. A positive value for the result indicates that the first string is greater than the second string. A negative result indicates the first string is smaller, and zero indicates equality between the strings.  
  
 [!code-vb[VbVbalrStrings#22](../../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/how-culture-affects-strings_2.vb)]  
  
 You can also use the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] partner of the `StrComp` function, the <xref:System.String.Compare%2A?displayProperty=nameWithType> method. This is a static, overloaded method of the base string class. The following example illustrates how this method is used:  
  
 [!code-vb[VbVbalrStrings#48](../../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/how-culture-affects-strings_3.vb)]  
  
 For finer control over how the comparisons are performed, you can use additional overloads of the <xref:System.String.Compare%2A> method. With the <xref:System.String.Compare%2A?displayProperty=nameWithType> method, you can use the `comparisonType` argument to specify which type of comparison to use.  
  
|Value for `comparisonType` argument|Type of comparison|When to use|  
|---|---|---|  
|`Ordinal`|Comparison based on strings' component bytes.|Use this value when comparing: case-sensitive identifiers, security-related settings, or other non-linguistic identifiers where the bytes must match exactly.|  
|`OrdinalIgnoreCase`|Comparison based on strings' component bytes.<br /><br /> `OrdinalIgnoreCase` uses the invariant culture information to determine when two characters differ only in capitalization.|Use this value when comparing: case-insensitive identifiers, security-related settings, and data stored in Windows.|  
|`CurrentCulture` or `CurrentCultureIgnoreCase`|Comparison based on the strings' interpretation in the current culture.|Use these values when comparing: data that is displayed to the user, most user input, and other data that requires linguistic interpretation.|  
|`InvariantCulture` or `InvariantCultureIgnoreCase`|Comparison based on the strings' interpretation in the invariant culture.<br /><br /> This is different than the `Ordinal` and `OrdinalIgnoreCase`, because the invariant culture treats characters outside its accepted range as equivalent invariant characters.|Use these values only when comparing persisting data or displaying linguistically-relevant data that requires a fixed sort order.|  
  
### Security Considerations  
 If your application makes security decisions based on the result of a comparison or case-change operation, then the operation should use the <xref:System.String.Compare%2A?displayProperty=nameWithType> method, and pass `Ordinal` or `OrdinalIgnoreCase` for the `comparisonType` argument.  
  
## See Also  
 <xref:System.Globalization.CultureInfo>  
 [Introduction to Strings in Visual Basic](../../../../visual-basic/programming-guide/language-features/strings/introduction-to-strings.md)  
 [Type Conversion Functions](../../../../visual-basic/language-reference/functions/type-conversion-functions.md)

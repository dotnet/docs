---
title: "Best Practices for Using Strings in .NET"
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
  - "strings [.NET Framework],searching"
  - "best practices,string comparison and sorting"
  - "strings [.NET Framework],best practices"
  - "strings [.NET Framework],basic string operations"
  - "sorting strings"
  - "strings [.NET Framework],sorting"
  - "string comparison [.NET Framework],best practices"
  - "string sorting"
  - "comparing strings"
  - "strings [.NET Framework],comparing"
ms.assetid: b9f0bf53-e2de-4116-8ce9-d4f91a1df4f7
caps.latest.revision: 35
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Best Practices for Using Strings in .NET
<a name="top"></a> .NET provides extensive support for developing localized and globalized applications, and makes it easy to apply the conventions of either the current culture or a specific culture when performing common operations such as sorting and displaying strings. But sorting or comparing strings is not always a culture-sensitive operation. For example, strings that are used internally by an application typically should be handled identically across all cultures. When culturally independent string data, such as XML tags, HTML tags, user names, file paths, and the names of system objects, are interpreted as if they were culture-sensitive, application code can be subject to subtle bugs, poor performance, and, in some cases, security issues.  
  
 This topic examines the string sorting, comparison, and casing methods in .NET, presents recommendations for selecting an appropriate string-handling method, and provides additional information about string-handling methods. It also examines how formatted data, such as numeric data and date and time data, is handled for display and for storage.  
  
 This topic contains the following sections:  
  
-   [Recommendations for String Usage](#recommendations_for_string_usage)  
  
-   [Specifying String Comparisons Explicitly](#specifying_string_comparisons_explicitly)  
  
-   [The Details of String Comparison](#the_details_of_string_comparison)  
  
-   [Choosing a StringComparison Member for Your Method Call](#choosing_a_stringcomparison_member_for_your_method_call)  
  
-   [Common String Comparison Methods in .NET](#common_string_comparison_methods_in_the_net_framework)  
  
-   [Methods that Perform String Comparison Indirectly](#methods_that_perform_string_comparison_indirectly)  
  
-   [Displaying and Persisting Formatted Data](#Formatted)  
  
<a name="recommendations_for_string_usage"></a>   
## Recommendations for String Usage  
 When you develop with .NET, follow these simple recommendations when you use strings:  
  
-   Use overloads that explicitly specify the string comparison rules for string operations. Typically, this involves calling a method overload that has a parameter of type <xref:System.StringComparison>.  
  
-   Use <xref:System.StringComparison.Ordinal?displayProperty=nameWithType> or <xref:System.StringComparison.OrdinalIgnoreCase?displayProperty=nameWithType> for comparisons as your safe default for culture-agnostic string matching.  
  
-   Use comparisons with <xref:System.StringComparison.Ordinal?displayProperty=nameWithType> or <xref:System.StringComparison.OrdinalIgnoreCase?displayProperty=nameWithType> for better performance.  
  
-   Use string operations that are based on <xref:System.StringComparison.CurrentCulture?displayProperty=nameWithType> when you display output to the user.  
  
-   Use the non-linguistic <xref:System.StringComparison.Ordinal?displayProperty=nameWithType> or <xref:System.StringComparison.OrdinalIgnoreCase?displayProperty=nameWithType> values instead of string operations based on <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType> when the comparison is linguistically irrelevant (symbolic, for example).  
  
-   Use the <xref:System.String.ToUpperInvariant%2A?displayProperty=nameWithType> method instead of the <xref:System.String.ToLowerInvariant%2A?displayProperty=nameWithType> method when you normalize strings for comparison.  
  
-   Use an overload of the <xref:System.String.Equals%2A?displayProperty=nameWithType> method to test whether two strings are equal.  
  
-   Use the <xref:System.String.Compare%2A?displayProperty=nameWithType> and <xref:System.String.CompareTo%2A?displayProperty=nameWithType> methods to sort strings, not to check for equality.  
  
-   Use culture-sensitive formatting to display non-string data, such as numbers and dates, in a user interface. Use formatting with the invariant culture to persist non-string data in string form.  
  
 Avoid the following practices when you use strings:  
  
-   Do not use overloads that do not explicitly or implicitly specify the string comparison rules for string operations.  
  
-   Do not use string operations based on <xref:System.StringComparison.InvariantCulture?displayProperty=nameWithType> in most cases. One of the few exceptions is when you are persisting linguistically meaningful but culturally agnostic data.  
  
-   Do not use an overload of the <xref:System.String.Compare%2A?displayProperty=nameWithType> or <xref:System.String.CompareTo%2A> method and test for a return value of zero to determine whether two strings are equal.  
  
-   Do not use culture-sensitive formatting to persist numeric data or date and time data in string form.  
  
 [Back to top](#top)  
  
<a name="specifying_string_comparisons_explicitly"></a>   
## Specifying String Comparisons Explicitly  
 Most of the string manipulation methods in .NET are overloaded. Typically, one or more overloads accept default settings, whereas others accept no defaults and instead define the precise way in which strings are to be compared or manipulated. Most of the methods that do not rely on defaults include a parameter of type <xref:System.StringComparison>, which is an enumeration that explicitly specifies rules for string comparison by culture and case. The following table describes the <xref:System.StringComparison> enumeration members.  
  
|StringComparison member|Description|  
|-----------------------------|-----------------|  
|<xref:System.StringComparison.CurrentCulture>|Performs a case-sensitive comparison using the current culture.|  
|<xref:System.StringComparison.CurrentCultureIgnoreCase>|Performs a case-insensitive comparison using the current culture.|  
|<xref:System.StringComparison.InvariantCulture>|Performs a case-sensitive comparison using the invariant culture.|  
|<xref:System.StringComparison.InvariantCultureIgnoreCase>|Performs a case-insensitive comparison using the invariant culture.|  
|<xref:System.StringComparison.Ordinal>|Performs an ordinal comparison.|  
|<xref:System.StringComparison.OrdinalIgnoreCase>|Performs a case-insensitive ordinal comparison.|  
  
 For example, the <xref:System.String.IndexOf%2A> method, which returns the index of a substring in a <xref:System.String> object that matches either a character or a string, has nine overloads:  
  
-   <xref:System.String.IndexOf%28System.Char%29>, <xref:System.String.IndexOf%28System.Char%2CSystem.Int32%29>, and <xref:System.String.IndexOf%28System.Char%2CSystem.Int32%2CSystem.Int32%29>, which by default perform an ordinal (case-sensitive and culture-insensitive) search for a character in the string.  
  
-   <xref:System.String.IndexOf%28System.String%29>, <xref:System.String.IndexOf%28System.String%2CSystem.Int32%29>, and <xref:System.String.IndexOf%28System.String%2CSystem.Int32%2CSystem.Int32%29>, which by default perform a case-sensitive and culture-sensitive search for a substring in the string.  
  
-   <xref:System.String.IndexOf%28System.String%2CSystem.StringComparison%29>, <xref:System.String.IndexOf%28System.String%2CSystem.Int32%2CSystem.StringComparison%29>, and <xref:System.String.IndexOf%28System.String%2CSystem.Int32%2CSystem.Int32%2CSystem.StringComparison%29>, which include a parameter of type <xref:System.StringComparison> that allows the form of the comparison to be specified.  
  
 We recommend that you select an overload that does not use default values, for the following reasons:  
  
-   Some overloads with default parameters (those that search for a <xref:System.Char> in the string instance) perform an ordinal comparison, whereas others (those that search for a string in the string instance) are culture-sensitive. It is difficult to remember which method uses which default value, and easy to confuse the overloads.  
  
-   The intent of the code that relies on default values for method calls is not clear. In the following example, which relies on defaults, it is difficult to know whether the developer actually intended an ordinal or a linguistic comparison of two strings, or whether a case difference between `protocol` and "http" might cause the test for equality to return `false`.  
  
     [!code-csharp[Conceptual.Strings.BestPractices#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.strings.bestpractices/cs/explicitargs1.cs#1)]
     [!code-vb[Conceptual.Strings.BestPractices#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.strings.bestpractices/vb/explicitargs1.vb#1)]  
  
 In general, we recommend that you call a method that does not rely on defaults, because it makes the intent of the code unambiguous. This, in turn, makes the code more readable and easier to debug and maintain. The following example addresses the questions raised about the previous example. It makes it clear that ordinal comparison is used and that differences in case are ignored.  
  
 [!code-csharp[Conceptual.Strings.BestPractices#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.strings.bestpractices/cs/explicitargs1.cs#2)]
 [!code-vb[Conceptual.Strings.BestPractices#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.strings.bestpractices/vb/explicitargs1.vb#2)]  
  
 [Back to top](#top)  
  
<a name="the_details_of_string_comparison"></a>   
## The Details of String Comparison  
 String comparison is the heart of many string-related operations, particularly sorting and testing for equality. Strings sort in a determined order: If "my" appears before "string" in a sorted list of strings, "my" must compare less than or equal to "string". Additionally, comparison implicitly defines equality. The comparison operation returns zero for strings it deems equal. A good interpretation is that neither string is less than the other. Most meaningful operations involving strings include one or both of these procedures: comparing with another string, and executing a well-defined sort operation.  
  
 However, evaluating two strings for equality or sort order does not yield a single, correct result; the outcome depends on the criteria used to compare the strings. In particular, string comparisons that are ordinal or that are based on the casing and sorting conventions of the current culture or the invariant culture (a locale-agnostic culture based on the English language) may produce different results.  
  
<a name="current_culture"></a>   
### String Comparisons that Use the Current Culture  
 One criterion involves using the conventions of the current culture when comparing strings. Comparisons that are based on the current culture use the thread's current culture or locale. If the culture is not set by the user, it defaults to the setting in the **Regional Options** window in Control Panel. You should always use comparisons that are based on the current culture when data is linguistically relevant, and when it reflects culture-sensitive user interaction.  
  
 However, comparison and casing behavior in .NET changes when the culture changes. This happens when an application executes on a computer that has a different culture than the computer on which the application was developed, or when the executing thread changes its culture. This behavior is intentional, but it remains non-obvious to many developers. The following example illustrates differences in sort order between the U.S. English ("en-US") and Swedish ("sv-SE") cultures. Note that the words "ångström", "Windows", and "Visual Studio" appear in different positions in the sorted string arrays.  
  
 [!code-csharp[Conceptual.Strings.BestPractices#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.strings.bestpractices/cs/comparison1.cs#3)]
 [!code-vb[Conceptual.Strings.BestPractices#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.strings.bestpractices/vb/comparison1.vb#3)]  
  
 Case-insensitive comparisons that use the current culture are the same as culture-sensitive comparisons, except that they ignore case as dictated by the thread's current culture. This behavior may manifest itself in sort orders as well.  
  
 Comparisons that use current culture semantics are the default for the following methods:  
  
-   <xref:System.String.Compare%2A?displayProperty=nameWithType> overloads that do not include a <xref:System.StringComparison> parameter.  
  
-   <xref:System.String.CompareTo%2A?displayProperty=nameWithType> overloads.  
  
-   The default <xref:System.String.StartsWith%28System.String%29?displayProperty=nameWithType> method, and the <xref:System.String.StartsWith%28System.String%2CSystem.Boolean%2CSystem.Globalization.CultureInfo%29?displayProperty=nameWithType> method with a `null`<xref:System.Globalization.CultureInfo> parameter.  
  
-   The default <xref:System.String.EndsWith%28System.String%29?displayProperty=nameWithType> method, and the <xref:System.String.EndsWith%28System.String%2CSystem.Boolean%2CSystem.Globalization.CultureInfo%29?displayProperty=nameWithType> method with a `null`<xref:System.Globalization.CultureInfo> parameter.  
  
-   <xref:System.String.IndexOf%2A?displayProperty=nameWithType> overloads that accept a <xref:System.String> as a search parameter and that do not have a <xref:System.StringComparison> parameter.  
  
-   <xref:System.String.LastIndexOf%2A?displayProperty=nameWithType> overloads that accept a <xref:System.String> as a search parameter and that do not have a <xref:System.StringComparison> parameter.  
  
 In any case, we recommend that you call an overload that has a <xref:System.StringComparison> parameter to make the intent of the method call clear.  
  
 Subtle and not so subtle bugs can emerge when non-linguistic string data is interpreted linguistically, or when string data from a particular culture is interpreted using the conventions of another culture. The canonical example is the Turkish-I problem.  
  
 For nearly all Latin alphabets, including U.S. English, the character "i" (\u0069) is the lowercase version of the character "I" (\u0049). This casing rule quickly becomes the default for someone programming in such a culture. However, the Turkish ("tr-TR") alphabet includes an "I with a dot" character "İ" (\u0130), which is the capital version of "i". Turkish also includes a lowercase "i without a dot" character, "ı" (\u0131), which capitalizes to "I". This behavior occurs in the Azerbaijani ("az") culture as well.  
  
 Therefore, assumptions made about capitalizing "i" or lowercasing "I" are not valid among all cultures. If you use the default overloads for string comparison routines, they will be subject to variance between cultures. If the data to be compared is non-linguistic, using the default overloads can produce undesirable results, as the following attempt to perform a case-insensitive comparison of the strings "file" and "FILE" illustrates.  
  
 [!code-csharp[Conceptual.Strings.BestPractices#11](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.strings.bestpractices/cs/turkish1.cs#11)]
 [!code-vb[Conceptual.Strings.BestPractices#11](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.strings.bestpractices/vb/turkish1.vb#11)]  
  
 This comparison could cause significant problems if the culture is inadvertently used in security-sensitive settings, as in the following example. A method call such as `IsFileURI("file:")` returns `true` if the current culture is U.S. English, but `false` if the current culture is Turkish. Thus, on Turkish systems, someone could circumvent security measures that block access to case-insensitive URIs that begin with "FILE:".  
  
 [!code-csharp[Conceptual.Strings.BestPractices#12](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.strings.bestpractices/cs/turkish1.cs#12)]
 [!code-vb[Conceptual.Strings.BestPractices#12](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.strings.bestpractices/vb/turkish1.vb#12)]  
  
 In this case, because "file:" is meant to be interpreted as a non-linguistic, culture-insensitive identifier, the code should instead be written as shown in the following example.  
  
 [!code-csharp[Conceptual.Strings.BestPractices#13](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.strings.bestpractices/cs/turkish1.cs#13)]
 [!code-vb[Conceptual.Strings.BestPractices#13](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.strings.bestpractices/vb/turkish1.vb#13)]  
  
### Ordinal String Operations  
 Specifying the <xref:System.StringComparison.Ordinal?displayProperty=nameWithType> or <xref:System.StringComparison.OrdinalIgnoreCase?displayProperty=nameWithType> value in a method call signifies a non-linguistic comparison in which the features of natural languages are ignored. Methods that are invoked with these <xref:System.StringComparison> values base string operation decisions on simple byte comparisons instead of casing or equivalence tables that are parameterized by culture. In most cases, this approach best fits the intended interpretation of strings while making code faster and more reliable.  
  
 Ordinal comparisons are string comparisons in which each byte of each string is compared without linguistic interpretation; for example, "windows" does not match "Windows". This is essentially a call to the C runtime `strcmp` function. Use this comparison when the context dictates that strings should be matched exactly or demands conservative matching policy. Additionally, ordinal comparison is the fastest comparison operation because it applies no linguistic rules when determining a result.  
  
 Strings in .NET can contain embedded null characters. One of the clearest differences between ordinal and culture-sensitive comparison (including comparisons that use the invariant culture) concerns the handling of embedded null characters in a string. These characters are ignored when you use the <xref:System.String.Compare%2A?displayProperty=nameWithType> and <xref:System.String.Equals%2A?displayProperty=nameWithType> methods to perform culture-sensitive comparisons (including comparisons that use the invariant culture). As a result, in culture-sensitive comparisons, strings that contain embedded null characters can be considered equal to strings that do not.  
  
> [!IMPORTANT]
>  Although string comparison methods disregard embedded null characters, string search methods such as <xref:System.String.Contains%2A?displayProperty=nameWithType>, <xref:System.String.EndsWith%2A?displayProperty=nameWithType>, <xref:System.String.IndexOf%2A?displayProperty=nameWithType>, <xref:System.String.LastIndexOf%2A?displayProperty=nameWithType>, and <xref:System.String.StartsWith%2A?displayProperty=nameWithType> do not.  
  
 The following example performs a culture-sensitive comparison of the string "Aa" with a similar string that contains several embedded null characters between "A" and "a", and shows how the two strings are considered equal.  
  
 [!code-csharp[Conceptual.Strings.BestPractices#19](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.strings.bestpractices/cs/embeddednulls1.cs#19)]
 [!code-vb[Conceptual.Strings.BestPractices#19](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.strings.bestpractices/vb/embeddednulls1.vb#19)]  
  
 However, the strings are not considered equal when you use ordinal comparison, as the following example shows.  
  
 [!code-csharp[Conceptual.Strings.BestPractices#20](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.strings.bestpractices/cs/embeddednulls2.cs#20)]
 [!code-vb[Conceptual.Strings.BestPractices#20](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.strings.bestpractices/vb/embeddednulls2.vb#20)]  
  
 Case-insensitive ordinal comparisons are the next most conservative approach. These comparisons ignore most casing; for example, "windows" matches "Windows". When dealing with ASCII characters, this policy is equivalent to <xref:System.StringComparison.Ordinal?displayProperty=nameWithType>, except that it ignores the usual ASCII casing. Therefore, any character in [A, Z] (\u0041-\u005A) matches the corresponding character in [a,z] (\u0061-\007A). Casing outside the ASCII range uses the invariant culture's tables. Therefore, the following comparison:  
  
 [!code-csharp[Conceptual.Strings.BestPractices#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.strings.bestpractices/cs/comparison2.cs#4)]
 [!code-vb[Conceptual.Strings.BestPractices#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.strings.bestpractices/vb/comparison2.vb#4)]  
  
 is equivalent to (but faster than) this comparison:  
  
 [!code-csharp[Conceptual.Strings.BestPractices#5](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.strings.bestpractices/cs/comparison2.cs#5)]
 [!code-vb[Conceptual.Strings.BestPractices#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.strings.bestpractices/vb/comparison2.vb#5)]  
  
 These comparisons are still very fast.  
  
> [!NOTE]
>  The string behavior of the file system, registry keys and values, and environment variables is best represented by <xref:System.StringComparison.OrdinalIgnoreCase?displayProperty=nameWithType>.  
  
 Both <xref:System.StringComparison.Ordinal?displayProperty=nameWithType> and <xref:System.StringComparison.OrdinalIgnoreCase?displayProperty=nameWithType> use the binary values directly, and are best suited for matching. When you are not sure about your comparison settings, use one of these two values. However, because they perform a byte-by-byte comparison, they do not sort by a linguistic sort order (like an English dictionary) but by a binary sort order. The results may look odd in most contexts if displayed to users.  
  
 Ordinal semantics are the default for <xref:System.String.Equals%2A?displayProperty=nameWithType> overloads that do not include a <xref:System.StringComparison> argument (including the equality operator). In any case, we recommend that you call an overload that has a <xref:System.StringComparison> parameter.  
  
### String Operations that Use the Invariant Culture  
 Comparisons with the invariant culture use the <xref:System.Globalization.CultureInfo.CompareInfo%2A> property returned by the static <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType> property. This behavior is the same on all systems; it translates any characters outside its range into what it believes are equivalent invariant characters. This policy can be useful for maintaining one set of string behavior across cultures, but it often provides unexpected results.  
  
 Case-insensitive comparisons with the invariant culture use the static <xref:System.Globalization.CultureInfo.CompareInfo%2A> property returned by the static <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType> property for comparison information as well. Any case differences among these translated characters are ignored.  
  
 Comparisons that use <xref:System.StringComparison.InvariantCulture?displayProperty=nameWithType> and <xref:System.StringComparison.Ordinal?displayProperty=nameWithType> work identically on ASCII strings. However, <xref:System.StringComparison.InvariantCulture?displayProperty=nameWithType> makes linguistic decisions that might not be appropriate for strings that have to be interpreted as a set of bytes. The `CultureInfo.InvariantCulture.CompareInfo` object makes the <xref:System.String.Compare%2A> method interpret certain sets of characters as equivalent. For example, the following equivalence is valid under the invariant culture:  
  
 InvariantCulture: a + ̊ = å  
  
 The LATIN SMALL LETTER A character "a"  (\u0061), when it is next to the COMBINING RING ABOVE character "+ " ̊" (\u030a), is interpreted as the LATIN SMALL LETTER A WITH RING ABOVE character "å" (\u00e5). As the following example shows, this behavior differs from ordinal comparison.  
  
 [!code-csharp[Conceptual.Strings.BestPractices#15](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.strings.bestpractices/cs/comparison3.cs#15)]
 [!code-vb[Conceptual.Strings.BestPractices#15](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.strings.bestpractices/vb/comparison3.vb#15)]  
  
 When interpreting file names, cookies, or anything else where a combination such as "å" can appear, ordinal comparisons still offer the most transparent and fitting behavior.  
  
 On balance, the invariant culture has very few properties that make it useful for comparison. It does comparison in a linguistically relevant manner, which prevents it from guaranteeing full symbolic equivalence, but it is not the choice for display in any culture. One of the few reasons to use <xref:System.StringComparison.InvariantCulture?displayProperty=nameWithType> for comparison is to persist ordered data for a cross-culturally identical display. For example, if a large data file that contains a list of sorted identifiers for display accompanies an application, adding to this list would require an insertion with invariant-style sorting.  
  
 [Back to top](#top)  
  
<a name="choosing_a_stringcomparison_member_for_your_method_call"></a>   
## Choosing a StringComparison Member for Your Method Call  
 The following table outlines the mapping from semantic string context to a <xref:System.StringComparison> enumeration member.  
  
|Data|Behavior|Corresponding System.StringComparison<br /><br /> value|  
|----------|--------------|-----------------------------------------------------|  
|Case-sensitive internal identifiers.<br /><br /> Case-sensitive identifiers in standards such as XML and HTTP.<br /><br /> Case-sensitive security-related settings.|A non-linguistic identifier, where bytes match exactly.|<xref:System.StringComparison.Ordinal>|  
|Case-insensitive internal identifiers.<br /><br /> Case-insensitive identifiers in standards such as XML and HTTP.<br /><br /> File paths.<br /><br /> Registry keys and values.<br /><br /> Environment variables.<br /><br /> Resource identifiers (for example, handle names).<br /><br /> Case-insensitive security-related settings.|A non-linguistic identifier, where case is irrelevant; especially data stored in most Windows system services.|<xref:System.StringComparison.OrdinalIgnoreCase>|  
|Some persisted, linguistically relevant data.<br /><br /> Display of linguistic data that requires a fixed sort order.|Culturally agnostic data that still is linguistically relevant.|<xref:System.StringComparison.InvariantCulture><br /><br /> -or-<br /><br /> <xref:System.StringComparison.InvariantCultureIgnoreCase>|  
|Data displayed to the user.<br /><br /> Most user input.|Data that requires local linguistic customs.|<xref:System.StringComparison.CurrentCulture><br /><br /> -or-<br /><br /> <xref:System.StringComparison.CurrentCultureIgnoreCase>|  
  
 [Back to top](#top)  
  
<a name="common_string_comparison_methods_in_the_net_framework"></a>   
## Common String Comparison Methods in .NET  
 The following sections describe the methods that are most commonly used for string comparison.  
  
### String.Compare  
 Default interpretation: <xref:System.StringComparison.CurrentCulture?displayProperty=nameWithType>.  
  
 As the operation most central to string interpretation, all instances of these method calls should be examined to determine whether strings should be interpreted according to the current culture, or dissociated from the culture (symbolically). Typically, it is the latter, and a <xref:System.StringComparison.Ordinal?displayProperty=nameWithType> comparison should be used instead.  
  
 The <xref:System.Globalization.CompareInfo?displayProperty=nameWithType> class, which is returned by the <xref:System.Globalization.CultureInfo.CompareInfo%2A?displayProperty=nameWithType> property, also includes a <xref:System.Globalization.CompareInfo.Compare%2A> method that provides a large number of matching options (ordinal, ignoring white space, ignoring kana type, and so on) by means of the <xref:System.Globalization.CompareOptions> flag enumeration.  
  
### String.CompareTo  
 Default interpretation: <xref:System.StringComparison.CurrentCulture?displayProperty=nameWithType>.  
  
 This method does not currently offer an overload that specifies a <xref:System.StringComparison> type. It is usually possible to convert this method to the recommended <xref:System.String.Compare%28System.String%2CSystem.String%2CSystem.StringComparison%29?displayProperty=nameWithType> form.  
  
 Types that implement the <xref:System.IComparable> and <xref:System.IComparable%601> interfaces implement this method. Because it does not offer the option of a <xref:System.StringComparison> parameter, implementing types often let the user specify a <xref:System.StringComparer> in their constructor. The following example defines a `FileName` class whose class constructor includes a <xref:System.StringComparer> parameter. This <xref:System.StringComparer> object is then used in the `FileName.CompareTo` method.  
  
 [!code-csharp[Conceptual.Strings.BestPractices#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.strings.bestpractices/cs/api1.cs#6)]
 [!code-vb[Conceptual.Strings.BestPractices#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.strings.bestpractices/vb/api1.vb#6)]  
  
### String.Equals  
 Default interpretation: <xref:System.StringComparison.Ordinal?displayProperty=nameWithType>.  
  
 The <xref:System.String> class lets you test for equality by calling either the static or instance <xref:System.String.Equals%2A> method overloads, or by using the static equality operator. The overloads and operator use ordinal comparison by default. However, we still recommend that you call an overload that explicitly specifies the <xref:System.StringComparison> type even if you want to perform an ordinal comparison; this makes it easier to search code for a certain string interpretation.  
  
### String.ToUpper and String.ToLower  
 Default interpretation: <xref:System.StringComparison.CurrentCulture?displayProperty=nameWithType>.  
  
 You should be careful when you use these methods, because forcing a string to a uppercase or lowercase is often used as a small normalization for comparing strings regardless of case. If so, consider using a case-insensitive comparison.  
  
 The <xref:System.String.ToUpperInvariant%2A?displayProperty=nameWithType> and <xref:System.String.ToLowerInvariant%2A?displayProperty=nameWithType> methods are also available. <xref:System.String.ToUpperInvariant%2A> is the standard way to normalize case. Comparisons made using <xref:System.StringComparison.OrdinalIgnoreCase?displayProperty=nameWithType> are behaviorally the composition of two calls: calling <xref:System.String.ToUpperInvariant%2A> on both string arguments, and doing a comparison using <xref:System.StringComparison.Ordinal?displayProperty=nameWithType>.  
  
 Overloads are also available for converting to uppercase and lowercase in a specific culture, by passing a <xref:System.Globalization.CultureInfo> object that represents that culture to the method.  
  
### Char.ToUpper and Char.ToLower  
 Default interpretation: <xref:System.StringComparison.CurrentCulture?displayProperty=nameWithType>.  
  
 These methods work similarly to the <xref:System.String.ToUpper%2A?displayProperty=nameWithType> and <xref:System.String.ToLower%2A?displayProperty=nameWithType> methods described in the previous section.  
  
### String.StartsWith and String.EndsWith  
 Default interpretation: <xref:System.StringComparison.CurrentCulture?displayProperty=nameWithType>.  
  
 By default, both of these methods perform a culture-sensitive comparison.  
  
### String.IndexOf and String.LastIndexOf  
 Default interpretation: <xref:System.StringComparison.CurrentCulture?displayProperty=nameWithType>.  
  
 There is a lack of consistency in how the default overloads of these methods perform comparisons. All <xref:System.String.IndexOf%2A?displayProperty=nameWithType> and <xref:System.String.LastIndexOf%2A?displayProperty=nameWithType> methods that include a <xref:System.Char> parameter perform an ordinal comparison, but the default <xref:System.String.IndexOf%2A?displayProperty=nameWithType> and <xref:System.String.LastIndexOf%2A?displayProperty=nameWithType> methods that include a <xref:System.String> parameter perform a culture-sensitive comparison.  
  
 If you call the <xref:System.String.IndexOf%28System.String%29?displayProperty=nameWithType> or <xref:System.String.LastIndexOf%28System.String%29?displayProperty=nameWithType> method and pass it a string to locate in the current instance, we recommend that you call an overload that explicitly specifies the <xref:System.StringComparison> type. The overloads that include a <xref:System.Char> argument do not allow you to specify a <xref:System.StringComparison> type.  
  
 [Back to top](#top)  
  
<a name="methods_that_perform_string_comparison_indirectly"></a>   
## Methods that Perform String Comparison Indirectly  
 Some non-string methods that have string comparison as a central operation use the <xref:System.StringComparer> type. The <xref:System.StringComparer> class includes six static properties that return <xref:System.StringComparer> instances whose <xref:System.StringComparer.Compare%2A?displayProperty=nameWithType> methods perform the following types of string comparisons:  
  
-   Culture-sensitive string comparisons using the current culture. This <xref:System.StringComparer> object is returned by the <xref:System.StringComparer.CurrentCulture%2A?displayProperty=nameWithType> property.  
  
-   Case-insensitive comparisons using the current culture. This <xref:System.StringComparer> object is returned by the <xref:System.StringComparer.CurrentCultureIgnoreCase%2A?displayProperty=nameWithType> property.  
  
-   Culture-insensitive comparisons using the word comparison rules of the invariant culture. This <xref:System.StringComparer> object is returned by the <xref:System.StringComparer.InvariantCulture%2A?displayProperty=nameWithType> property.  
  
-   Case-insensitive and culture-insensitive comparisons using the word comparison rules of the invariant culture. This <xref:System.StringComparer> object is returned by the <xref:System.StringComparer.InvariantCultureIgnoreCase%2A?displayProperty=nameWithType> property.  
  
-   Ordinal comparison. This <xref:System.StringComparer> object is returned by the <xref:System.StringComparer.Ordinal%2A?displayProperty=nameWithType> property.  
  
-   Case-insensitive ordinal comparison. This <xref:System.StringComparer> object is returned by the <xref:System.StringComparer.OrdinalIgnoreCase%2A?displayProperty=nameWithType> property.  
  
### Array.Sort and Array.BinarySearch  
 Default interpretation: <xref:System.StringComparison.CurrentCulture?displayProperty=nameWithType>.  
  
 When you store any data in a collection, or read persisted data from a file or database into a collection, switching the current culture can invalidate the invariants in the collection. The <xref:System.Array.BinarySearch%2A?displayProperty=nameWithType> method assumes that the elements in the array to be searched are already sorted. To sort any string element in the array, the <xref:System.Array.Sort%2A?displayProperty=nameWithType> method calls the <xref:System.String.Compare%2A?displayProperty=nameWithType> method to order individual elements. Using a culture-sensitive comparer can be dangerous if the culture changes between the time that the array is sorted and its contents are searched. For example, in the following code, storage and retrieval operate on the comparer that is provided implicitly by the `Thread.CurrentThread.CurrentCulture` property. If the culture can change between the calls to `StoreNames` and `DoesNameExist`, and especially if the array contents are persisted somewhere between the two method calls, the binary search may fail.  
  
 [!code-csharp[Conceptual.Strings.BestPractices#7](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.strings.bestpractices/cs/indirect1.cs#7)]
 [!code-vb[Conceptual.Strings.BestPractices#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.strings.bestpractices/vb/indirect1.vb#7)]  
  
 A recommended variation appears in the following example, which uses the same ordinal (culture-insensitive) comparison method both to sort and to search the array. The change code is reflected in the lines labeled `Line A` and `Line B` in the two examples.  
  
 [!code-csharp[Conceptual.Strings.BestPractices#8](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.strings.bestpractices/cs/indirect1.cs#8)]
 [!code-vb[Conceptual.Strings.BestPractices#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.strings.bestpractices/vb/indirect1.vb#8)]  
  
 If this data is persisted and moved across cultures, and sorting is used to present this data to the user, you might consider using <xref:System.StringComparison.InvariantCulture?displayProperty=nameWithType>, which operates linguistically for better user output but is unaffected by changes in culture. The following example modifies the two previous examples to use the invariant culture for sorting and searching the array.  
  
 [!code-csharp[Conceptual.Strings.BestPractices#9](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.strings.bestpractices/cs/indirect1.cs#9)]
 [!code-vb[Conceptual.Strings.BestPractices#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.strings.bestpractices/vb/indirect1.vb#9)]  
  
### Collections Example: Hashtable Constructor  
 Hashing strings provides a second example of an operation that is affected by the way in which strings are compared.  
  
 The following example instantiates a <xref:System.Collections.Hashtable> object by passing it the <xref:System.StringComparer> object that is returned by the <xref:System.StringComparer.OrdinalIgnoreCase%2A?displayProperty=nameWithType> property. Because a class <xref:System.StringComparer> that is derived from <xref:System.StringComparer> implements the <xref:System.Collections.IEqualityComparer> interface, its <xref:System.Collections.IEqualityComparer.GetHashCode%2A> method is used to compute the hash code of strings in the hash table.  
  
 [!code-csharp[Conceptual.Strings.BestPractices#10](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.strings.bestpractices/cs/indirect2.cs#10)]
 [!code-vb[Conceptual.Strings.BestPractices#10](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.strings.bestpractices/vb/indirect2.vb#10)]  
  
 [Back to top](#top)  
  
<a name="Formatted"></a>   
## Displaying and Persisting Formatted Data  
 When you display non-string data such as numbers and dates and times to users, format them by using the user's cultural settings. By default, the <xref:System.String.Format%2A?displayProperty=nameWithType> method and the `ToString` methods of the numeric types and the date and time types use the current thread culture for formatting operations. To explicitly specify that the formatting method should use the current culture, you can call an overload of a formatting method that has a `provider` parameter, such as <xref:System.String.Format%28System.IFormatProvider%2CSystem.String%2CSystem.Object%5B%5D%29?displayProperty=nameWithType> or <xref:System.DateTime.ToString%28System.IFormatProvider%29?displayProperty=nameWithType>, and pass it the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> property.  
  
 You can persist non-string data either as binary data or as formatted data. If you choose to save it as formatted data, you should call a formatting method overload that includes a `provider` parameter and pass it the <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType> property. The invariant culture provides a consistent format for formatted data that is independent of culture and machine. In contrast, persisting data that is formatted by using cultures other than the invariant culture has a number of limitations:  
  
-   The data is likely to be unusable if it is retrieved on a system that has a different culture, or if the user of the current system changes the current culture and tries to retrieve the data.  
  
-   The properties of a culture on a specific computer can differ from standard values. At any time, a user can customize culture-sensitive display settings. Because of this, formatted data that is saved on a system may not be readable after the user customizes cultural settings. The portability of formatted data across computers is likely to be even more limited.  
  
-   International, regional, or national standards that govern the formatting of numbers or dates and times change over time, and these changes are incorporated into Windows operating system updates. When formatting conventions change, data that was formatted by using the previous conventions may become unreadable.  
  
 The following example illustrates the limited portability that results from using culture-sensitive formatting to persist data. The example saves an array of date and time values to a file. These are formatted by using the conventions of the English (United States) culture. After the application changes the current thread culture to French (Switzerland), it tries to read the saved values by using the formatting conventions of the current culture. The attempt to read two of the data items throws a <xref:System.FormatException> exception, and the array of dates now contains two incorrect elements that are equal to <xref:System.DateTime.MinValue>.  
  
 [!code-csharp[Conceptual.Strings.BestPractices#21](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.strings.bestpractices/cs/persistence.cs#21)]
 [!code-vb[Conceptual.Strings.BestPractices#21](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.strings.bestpractices/vb/persistence.vb#21)]  
  
 However, if you replace the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> property with <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType> in the calls to <xref:System.DateTime.ToString%28System.String%2CSystem.IFormatProvider%29?displayProperty=nameWithType> and <xref:System.DateTime.Parse%28System.String%2CSystem.IFormatProvider%29?displayProperty=nameWithType>,   the persisted date and time data is successfully restored, as the following output shows.  
  
```  
06.05.1758 21:26  
05.05.1818 07:19  
22.04.1870 23:54  
08.09.1890 06:47  
18.02.1905 15:12  
```  
  
## See Also  
 [Manipulating Strings](../../../docs/standard/base-types/manipulating-strings.md)

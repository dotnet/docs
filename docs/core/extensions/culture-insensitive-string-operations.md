---
description: "Learn more about: Culture-insensitive string operations"
title: "Culture-Insensitive String Operations"
ms.date: 08/11/2021
helpviewer_keywords:
  - "culture, culture-insensitive string operations"
  - "case-sensitive comparisons"
  - "globalization [.NET], culture-insensitive string operations"
  - "strings [.NET], culture-insensitive string operations"
  - "localization [.NET], culture-insensitive string operations"
  - "world-ready applications, culture-insensitive string operations"
  - "culture-sensitive string operations"
  - "culture-insensitive string operations"
ms.assetid: e6e2bb94-a95d-44e2-b68c-cfdd1db77784
---

# Culture-insensitive string operations

Culture-sensitive string operations can be an advantage if you are creating applications designed to display results to users on a per-culture basis. By default, culture-sensitive methods obtain the culture to use from the <xref:System.Globalization.CultureInfo.CurrentCulture%2A> property for the current thread.

Sometimes, culture-sensitive string operations are not the desired behavior. Using culture-sensitive operations when results should be independent of culture can cause application code to fail on cultures with custom case mappings and sorting rules. For an example, see the ["String Comparisons that Use the Current Culture"](../base-types/best-practices-strings.md#string-comparisons-that-use-the-current-culture) section in the [Best Practices for Using Strings](../base-types/best-practices-strings.md) article.

Whether string operations should be culture-sensitive or culture-insensitive depends on how your application uses the results. String operations that display results to the user should typically be culture-sensitive. For example, if an application displays a sorted list of localized strings in a list box, the application should perform a culture-sensitive sort.

Results of string operations that are used internally should typically be culture-insensitive. In general, if the application is working with file names, persistence formats, or symbolic information that is not displayed to the user, results of string operations should not vary by culture. For example, if an application compares a string to determine whether it is a recognized XML tag, the comparison should not be culture-sensitive. In addition, if a security decision is based on the result of a string comparison or case change operation, the operation should be culture-insensitive to ensure that the result is not affected by the value of <xref:System.Globalization.CultureInfo.CurrentCulture%2A>.

Whether or not you're developing an application that includes code to handle localization and globalization issues, you should be aware of the .NET methods that retrieve culture-sensitive results by default.

## See also

- [Globalization and Localization](globalization-and-localization.md)

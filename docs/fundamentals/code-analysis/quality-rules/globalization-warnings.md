---
title: Globalization rules (code analysis)
description: "Learn about code analysis rule Globalization rules"
ms.date: 11/04/2016
f1_keywords:
- vs.codeanalysis.globalizationrules
helpviewer_keywords:
- rules, globalization
- globalization rules
- globalization [Visual Studio], rules
- managed code analysis rules, globalization rules
author: gewarren
ms.author: gewarren
---
# Globalization rules

Globalization rules support world-ready libraries and applications.

## In this section

|Rule|Description|
|----------|-----------------|
|[CA1303: Do not pass literals as localized parameters](ca1303.md)|An externally visible method passes a string literal as a parameter to a .NET constructor or method, and that string should be localizable.|
|[CA1304: Specify CultureInfo](ca1304.md)|A method or constructor calls a member that has an overload that accepts a System.Globalization.CultureInfo parameter, and the method or constructor does not call the overload that takes the CultureInfo parameter. When a CultureInfo or System.IFormatProvider object is not supplied, the default value that is supplied by the overloaded member might not have the effect that you want in all locales.|
|[CA1305: Specify IFormatProvider](ca1305.md)|A method or constructor calls one or more members that have overloads that accept a System.IFormatProvider parameter, and the method or constructor does not call the overload that takes the IFormatProvider parameter. When a System.Globalization.CultureInfo or IFormatProvider object is not supplied, the default value that is supplied by the overloaded member might not have the effect that you want in all locales.|
|[CA1307: Specify StringComparison for clarity](ca1307.md)|A string comparison operation uses a method overload that does not set a StringComparison parameter.|
|[CA1308: Normalize strings to uppercase](ca1308.md)|Strings should be normalized to uppercase. A small group of characters cannot make a round trip when they are converted to lowercase.|
|[CA1309: Use ordinal StringComparison](ca1309.md)|A string comparison operation that is nonlinguistic does not set the StringComparison parameter to either Ordinal or OrdinalIgnoreCase. By explicitly setting the parameter to either StringComparison.Ordinal or StringComparison.OrdinalIgnoreCase, your code often gains speed, becomes more correct, and becomes more reliable.|
|[CA1310: Specify StringComparison for correctness](ca1310.md)|A string comparison operation uses a method overload that does not set a StringComparison parameter and uses culture-specific string comparison by default.|
|[CA1311: Specify a culture or use an invariant version](ca1311.md)|Specify a culture or use an invariant culture to avoid implicit dependency on the current culture when calling `ToUpper` or `ToLower`.|
|[CA2101: Specify marshalling for P/Invoke string arguments](ca2101.md)|A platform invoke member allows for partially trusted callers, has a string parameter, and does not explicitly marshal the string. This can cause a potential security vulnerability.|

---
title: Globalization Rules rule set for managed code
ms.date: 11/04/2016
ms.topic: reference
ms.assetid: 3c4032ee-0805-4581-8c48-b1827cd6b213
author: mikejo5000
ms.author: mikejo
manager: jillfra
ms.workload:
- dotnet
---
# Globalization Rules rule set for managed code

Use the Microsoft Globalization Rules rule set to focus on problems that might prevent data in your application from appearing correctly in different languages, locales, and cultures. You should include this rule set if your application is localized, globalized, or both.

|Rule|Description|
|----------|-----------------|
|[CA1303](../code-quality/ca1303.md)|Do not pass literals as localized parameters|
|[CA1304](../code-quality/ca1304.md)|Specify CultureInfo|
|[CA1305](../code-quality/ca1305.md)|Specify IFormatProvider|
|[CA1307](../code-quality/ca1307.md)|Specify StringComparison for clarity|
|[CA1308](../code-quality/ca1308.md)|Normalize strings to uppercase|
|[CA1309](../code-quality/ca1309.md)|Use ordinal StringComparison|
|[CA1310](../code-quality/ca1310.md)|Specify StringComparison for correctness|
|[CA2101](../code-quality/ca2101.md)|Specify marshaling for P/Invoke string arguments|

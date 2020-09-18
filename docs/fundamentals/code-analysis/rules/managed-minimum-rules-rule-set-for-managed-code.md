---
title: Managed Minimum Rules rule set for managed code
ms.date: 11/04/2016
ms.topic: reference
ms.assetid: 44a50c54-8dd3-42b2-8387-532a150e5a6c
author: mikejo5000
ms.author: mikejo
manager: jillfra
ms.workload:
- dotnet
---
# Managed Minimum Rules rule set for managed code

The Managed Minimum rules focus on the most critical problems in your code, including potential security holes, application crashes, and other important logic and design errors. Include this rule set in any custom rule set you create for your projects.

|Rule|Description|
|----------|-----------------|
|[CA1001](../code-quality/ca1001.md)|Types that own disposable fields should be disposable|
|[CA1821](../code-quality/ca1821.md)|Remove empty finalizers|
|[CA2213](../code-quality/ca2213.md)|Disposable fields should be disposed|
|[CA2231](../code-quality/ca2231.md)|Overload operator equals on overriding `ValueType.Equals`|

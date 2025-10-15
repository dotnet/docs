---
title: Errors and warnings related to user defined operator declarations
description: This article helps you diagnose and correct compiler errors and warnings when you declare user defined operators in your types
f1_keywords:
  - "CS9308"
  - "CS9310"
  - "CS9311"
  - "CS9312"
  - "CS9313"
helpviewer_keywords:
  - "CS9308"
  - "CS9310"
  - "CS9311"
  - "CS9312"
  - "CS9313"
ms.date: 10/15/2025
ai-usage: ai-assisted
---
# Errors and warnings for overloaded, or user-defined operator declarations

There are several errors related to declaring overloaded operators. Overloaded operators are also referred to as user-defined operators

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- **CS9308**: *User-defined operator must be declared public.*
- **CS9310**: *The return type for this operator must be void.*
- **CS9311**: *Type does not implement interface member. The type cannot implement member because one of them is not an operator.*
- **CS9312**: *Type cannot override inherited member because one of them is not an operator.*
- **CS9313**: *Overloaded compound assignment operator takes one parameter.*

The following sections provide examples of common issues and how to fix them.


---
title: Compiler Errors on partial type and member declarations
description: Use this article to diagnose and correct compiler errors and warnings when you write `partial` types and `partial` members.
f1_keywords:
  - "CS9248"
  - "CS9249"
  - "CS9250"
  - "CS9251"
  - "CS9152"
  - "CS9253"
  - "CS9254"
  - "CS9255"
  - "CS9256"
  - "CS9257"
helpviewer_keywords:
ms.date: 08/21/2024
---
# Errors and warnings related to `partial` type and `partial` member declarations

There are numerous *errors* related to `partial` type and `partial` member declarations:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS9248**](#partial-properties): *Partial property must have an implementation part.*
- [**CS9249**](#partial-properties): *Partial property must have a definition part.*
- [**CS9250**](#partial-properties): *A partial property may not have multiple defining declarations, and cannot be an auto-property.*
- [**CS9251**](#partial-properties): *A partial property may not have multiple implementing declarations*
- [**CS9252**](#partial-properties): *Property accessor must be implemented because it is declared on the definition part*
- [**CS9253**](#partial-properties): *Property accessor does not implement any accessor declared on the definition part*
- [**CS9254**](#partial-properties): *Property accessor must match the definition part*
- [**CS9255**](#partial-properties): *Both partial property declarations must have the same type.*
- [**CS9256**](#partial-properties): *Partial property declarations have signature differences.*
- [**CS9257**](#partial-properties): *Both partial property declarations must be required or neither may be required*

## Partial properties

The following errors and warnings are issued when a partial property or indexer is declared incorrectly:

- **CS9248**: *Partial property must have an implementation part.*
- **CS9249**: *Partial property must have a definition part.*
- **CS9250**: *A partial property may not have multiple defining declarations, and cannot be an auto-property.*
- **CS9251**: *A partial property may not have multiple implementing declarations*
- **CS9252**: *Property accessor must be implemented because it is declared on the definition part*
- **CS9253**: *Property accessor does not implement any accessor declared on the definition part*
- **CS9254**: *Property accessor must match the definition part*
- **CS9255**: *Both partial property declarations must have the same type.*
- **CS9257**: *Both partial property declarations must be required or neither may be required*

The following warning indicates signature differences in the partial property declarations:

- **CS9256**: *Partial property declarations have signature differences.*

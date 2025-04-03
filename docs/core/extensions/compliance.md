---
title: Compliance libraries in .NET
description: Learn how to use compliance libraries to implement compliance features in .NET applications.
ms.date: 03/21/2025
---

# Compliance libraries in .NET

.NET provides libraries that offer foundational components and abstractions for implementing compliance features, such as data classification and redaction, in .NET applications. These abstractions help developers create and manage data in a standardized way. In this article, you get an overview on the data classification and redaction compliance libraries.

## Data classification in .NET

Data classification helps categorize data based on its sensitivity and protection level using the <xref:Microsoft.Extensions.Compliance.Classification.DataClassification> structure. This allows you to label sensitive information and enforce policies based on these labels. You can create custom classifications and attributes to tag your data appropriately.

For more information about .NET's data classification library, see [Data classification in .NET](data-classification.md).

## Data redaction in .NET

Data redaction helps protect sensitive information in logs, error messages, or other outputs to comply with privacy rules and protect sensitive data. The <xref:Microsoft.Extensions.Compliance.Redaction> library provides various redactors, such as the <xref:Microsoft.Extensions.Compliance.Redaction.ErasingRedactor> and <xref:Microsoft.Extensions.Compliance.Redaction.HmacRedactor>. You can configure these redactors and register them using the `AddRedaction` methods. Additionally, you can create custom redactors and redactor providers to suit your specific needs.

For more information about .NET's data redaction library, see [Data redaction in .NET](data-redaction.md).

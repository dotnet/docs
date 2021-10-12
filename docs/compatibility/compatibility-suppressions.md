---
title: Suppressing Compatibility Errors
description: How to suppress the compatibility errors.
ms.date: 09/29/2021
---

# Suppress compatibility errors

To suppress compatibility errors for intentional changes, add a *CompatibilitySuppressions.xml* file to your project.
You can generate this file automatically by passing `/p:GenerateCompatibilitySuppressionFile=true` if you're building the project from the command line, or by adding the following property to your project: `<GenerateCompatibilitySuppressionFile>true</GenerateCompatibilitySuppressionFile>`

The suppression file looks like this.

```xml
<?xml version="1.0" encoding="utf-8"?>
<Suppressions xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Suppression>
    <DiagnosticId>CP0002</DiagnosticId>
    <Target>M:A.B.DoStringManipulation(System.String)</Target>
    <Left>lib/netstandard2.0/A.dll</Left>
    <Right>lib/net6.0/A.dll</Right>
  </Suppression>
</Suppressions>
```

- `DiagnosticID` specifies the [ID](diagnostic-ids.md) of the error to suppress.

- `Target` specifies where in the code to suppress the diagnostic IDs

- `Left` specifies the left operand of an APICompat comparison.

- `Right` specifies the right operand of an APICompat comparison.

`isBaseline`: set to `true` to apply the suppression to a baseline validation; otherwise, set to `false`.

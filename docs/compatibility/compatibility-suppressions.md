---
title: Suppressing Compatibility Errors
description: How to suppress the compatibility errors.
ms.date: 09/29/2021
---

## Suprresing compatibilty errors

The compatibility errors for intentional changes can be suppressed by adding the ```CompatibilitySuppressions.xml``` file to your project.
You can generate this file automatically by passing ```/p:GenerateCompatibilitySuppressionFile=true``` while building the project from the commandline or setting ```<GenerateCompatibilitySuppressionFile>true</GenerateCompatibilitySuppressionFile>``` in your project.

The suppression file will look like this
```
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

where
DiagnosticID =  The DiagnosticId representing the error to be suppressed. The detailed list could be found [here](diagnostic-ids.md).

Target = The target of where to suppress the diagnostic ids.

Left = Left operand of an APICompat comparison.

Right = Right operand of an APICompat comparison.

isBaseline =  true if the suppression is to be applied to a baseline validation. false otherwise.
---
title: "IL2053: Invalid value used in property element in custom attribute annotations file"
description: "Learn about trim warning IL2053: CustomAttributeAnnotationsPropertyInvalidValue"
ms.date: 08/25/2021
author: mateoatr
f1_keywords:
  - "IL2053"
---
# IL2053: Invalid value used in property element in custom attribute annotations file

> [!NOTE]
> This warning code is obsolete in .NET 7 and no longer produced by the tools.

## Cause

Value used in a `property` element in a custom attribute annotations file does not match the type of the attribute's property.

## Example

```xml
<!-- IL2053: Invalid value 'StringValue' for property 'IntProperty' -->
<linker>
  <assembly fullname="MyAssembly">
    <type fullname="MyType">
      <attribute fullname="MyAttribute">
        <property name="IntProperty">StringValue</property>
      </attribute>
    </type>
  </assembly>
</linker>
```

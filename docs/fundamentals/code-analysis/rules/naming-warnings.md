---
title: Naming Warnings
ms.date: 11/04/2016
ms.topic: reference
f1_keywords:
- vs.codeanalysis.namingrules
helpviewer_keywords:
- managed code analysis warnings, naming warnings
- naming warnings
- warnings, naming
ms.assetid: f97223ce-1d39-4134-81c9-fff2c75d979b
author: mikejo5000
ms.author: mikejo
manager: jillfra
ms.workload:
- multiple
---
# Naming Warnings

Naming warnings support adherence to the naming conventions of the .NET Design Guidelines.

## In This Section

|Rule|Description|
|----------|-----------------|
|[CA1700: Do not name enum values 'Reserved'](../code-quality/ca1700.md)|This rule assumes that an enumeration member that has a name that contains "reserved" is not currently used but is a placeholder to be renamed or removed in a future version. Renaming or removing a member is a breaking change.|
|[CA1707: Identifiers should not contain underscores](../code-quality/ca1707.md)|By convention, identifier names do not contain the underscore (_) character. This rule checks namespaces, types, members, and parameters.|
|[CA1708: Identifiers should differ by more than case](../code-quality/ca1708.md)|Identifiers for namespaces, types, members, and parameters cannot differ only by case because languages that target the common language runtime are not required to be case-sensitive.|
|[CA1710: Identifiers should have correct suffix](../code-quality/ca1710.md)|By convention, the names of types that extend certain base types or that implement certain interfaces, or types derived from these types, have a suffix that is associated with the base type or interface.|
|[CA1711: Identifiers should not have incorrect suffix](../code-quality/ca1711.md)|By convention, only the names of types that extend certain base types or that implement certain interfaces, or types that are derived from these types, should end with specific reserved suffixes. Other type names should not use these reserved suffixes.|
|[CA1712: Do not prefix enum values with type name](../code-quality/ca1712.md)|Names of enumeration members are not prefixed with the type name because type information is expected to be provided by development tools.|
|[CA1713: Events should not have before or after prefix](../code-quality/ca1713.md)|The name of an event starts with "Before" or "After". To name related events that are raised in a specific sequence, use the present or past tense to indicate the relative position in the sequence of actions.|
|[CA1714: Flags enums should have plural names](../code-quality/ca1714.md)|A public enumeration has the System.FlagsAttribute attribute and its name does not end in "s". Types that are marked with FlagsAttribute have names that are plural because the attribute indicates that more than one value can be specified.|
|[CA1715: Identifiers should have correct prefix](../code-quality/ca1715.md)|The name of an externally visible interface does not start with a capital "I".  The name of a generic type parameter on an externally visible type or method does not start with a capital "T".|
|[CA1716: Identifiers should not match keywords](../code-quality/ca1716.md)|A namespace name or a type name matches a reserved keyword in a programming language. Identifiers for namespaces and types should not match keywords that are defined by languages that target the common language runtime.|
|[CA1717: Only FlagsAttribute enums should have plural names](../code-quality/ca1717.md)|Naming conventions dictate that a plural name for an enumeration indicates that more than one value of the enumeration can be specified at the same time.|
|[CA1720: Identifiers should not contain type names](../code-quality/ca1720.md)|The name of a parameter in an externally visible member contains a data type name, or the name of an externally visible member contains a language-specific data type name.|
|[CA1721: Property names should not match get methods](../code-quality/ca1721.md)|The name of a public or protected member starts with "Get" and otherwise matches the name of a public or protected property. "Get" methods and properties should have names that clearly distinguish their function.|
|[CA1724: Type Names Should Not Match Namespaces](../code-quality/ca1724.md)|Type names should not match the names of .NET namespaces. Violation of this rule can reduce the usability of the library.|
|[CA1725: Parameter names should match base declaration](../code-quality/ca1725.md)|Consistent naming of parameters in an override hierarchy increases the usability of the method overrides. A parameter name in a derived method that differs from the name in the base declaration can cause confusion about whether the method is an override of the base method or a new overload of the method.|

---
title: ".NET docs: What's new for December 2021"
description: "What's new in the .NET docs for December 2021."
ms.date: 01/03/2022
---

# .NET docs: What's new for December 2021

Welcome to what's new in the .NET docs in December 2021. This article lists some of the major changes to docs during this period.

## .NET fundamentals

### New articles

- [SYSLIB1030: `System.Text.Json` source generator did not generate output for type](../fundamentals/syslib-diagnostics/syslib1030.md)
- [SYSLIB1031: `System.Text.Json` source generator encountered a duplicate type info property name](../fundamentals/syslib-diagnostics/syslib1031.md)
- [SYSLIB1032: Context classes to be augmented by the `System.Text.Json` source generator must be declared as partial](../fundamentals/syslib-diagnostics/syslib1032.md)
- [SYSLIB1033: `System.Text.Json` source generator encountered a type with multiple `[JsonConstructor]` annotations](../fundamentals/syslib-diagnostics/syslib1033.md)
- [SYSLIB1035: `System.Text.Json` source generator encountered a type with multiple `[JsonExtensionData]` annotations](../fundamentals/syslib-diagnostics/syslib1035.md)
- [SYSLIB1036: `System.Text.Json` source generator encountered an invalid `[JsonExtensionData]` annotation](../fundamentals/syslib-diagnostics/syslib1036.md)
- [SYSLIB1037: `System.Text.Json` source generator encountered a type with init-only properties which are not supported for deserialization](../fundamentals/syslib-diagnostics/syslib1037.md)
- [SYSLIB1038: `System.Text.Json` source generator encountered a property annotated with `[JsonInclude]` but with inaccessible accessors](../fundamentals/syslib-diagnostics/syslib1038.md)
- [IL2061: Assembly name passed to method 'Assembly.CreateInstance' references an assembly that could not be resolved](../core/deploying/trimming/trim-warnings/il2061.md)
- [IL2062: Value passed to a method parameter annotated with 'DynamicallyAccessedMembersAttribute' cannot be statically determined and may not meet the attribute's requirements](../core/deploying/trimming/trim-warnings/il2062.md)
- [IL2063: Value returned from a method whose return type is annotated with 'DynamicallyAccessedMembersAttribute' cannot be statically determined and may not meet the attribute's requirements](../core/deploying/trimming/trim-warnings/il2063.md)
- [IL2064: Value assigned to a field annotated with 'DynamicallyAccessedMembersAttribute' cannot be statically determined and may not meet the attribute's requirements.](../core/deploying/trimming/trim-warnings/il2064.md)
- [IL2065: Value passed to the implicit `this` parameter of a method annotated with 'DynamicallyAccessedMembersAttribute' cannot be statically determined and may not meet the attribute's requirements.](../core/deploying/trimming/trim-warnings/il2065.md)
- [IL2066: Type passed to generic parameter 'parameter' of 'type' (or 'method') cannot be statically determined and may not meet 'DynamicallyAccessedMembersAttribute' requirements](../core/deploying/trimming/trim-warnings/il2066.md)
- [IL2067: 'target parameter' argument does not satisfy 'DynamicallyAccessedMembersAttribute' in call to 'target method'. The parameter 'source parameter' of method 'source method' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to](../core/deploying/trimming/trim-warnings/il2067.md)
- [IL2068: 'target method' method return value does not satisfy 'DynamicallyAccessedMembersAttribute' requirements. The parameter 'source parameter' of method 'source method' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to](../core/deploying/trimming/trim-warnings/il2068.md)
- [IL2069: Value stored in field 'target field' does not satisfy 'DynamicallyAccessedMembersAttribute' requirements. The parameter 'source parameter' of method 'source method' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to](../core/deploying/trimming/trim-warnings/il2069.md)
- [IL2070: 'this' argument does not satisfy 'DynamicallyAccessedMembersAttribute' in call to 'target method'. The parameter 'source parameter' of method 'source method' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to](../core/deploying/trimming/trim-warnings/il2070.md)
- [IL2072: 'target parameter' argument does not satisfy 'DynamicallyAccessedMembersAttribute' in call to 'target method'. The return value of method 'source method' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to](../core/deploying/trimming/trim-warnings/il2072.md)
- [IL2073: 'target method' method return value does not satisfy 'DynamicallyAccessedMembersAttribute' requirements. The return value of method 'source method' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to](../core/deploying/trimming/trim-warnings/il2073.md)
- [IL2074: Value stored in field 'target field' does not satisfy 'DynamicallyAccessedMembersAttribute' requirements. The return value of method 'source method' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to](../core/deploying/trimming/trim-warnings/il2074.md)
- [IL2075: 'this' argument does not satisfy 'DynamicallyAccessedMembersAttribute' in call to 'target method'. The return value of method 'source method' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to](../core/deploying/trimming/trim-warnings/il2075.md)
- [IL2077: 'target parameter' argument does not satisfy 'DynamicallyAccessedMembersAttribute' in call to 'target method'. The field 'source field' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to](../core/deploying/trimming/trim-warnings/il2077.md)
- [IL2078: 'target method' method return value does not satisfy 'DynamicallyAccessedMembersAttribute' requirements. The field 'source field' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to](../core/deploying/trimming/trim-warnings/il2078.md)
- [IL2079: Value stored in field 'target field' does not satisfy 'DynamicallyAccessedMembersAttribute' requirements. The field 'source field' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to](../core/deploying/trimming/trim-warnings/il2079.md)
- [IL2080: 'this' argument does not satisfy 'DynamicallyAccessedMembersAttribute' in call to 'target method'. The field 'source field' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to](../core/deploying/trimming/trim-warnings/il2080.md)
- [IL2082: 'target parameter' argument does not satisfy 'DynamicallyAccessedMembersAttribute' in call to 'target method'. The implicit 'this' argument of method 'source method' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to](../core/deploying/trimming/trim-warnings/il2082.md)
- [IL2083: 'target method' method return value does not satisfy 'DynamicallyAccessedMembersAttribute' requirements. The implicit 'this' argument of method 'source method' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to](../core/deploying/trimming/trim-warnings/il2083.md)
- [IL2084: Value stored in field 'target field' does not satisfy 'DynamicallyAccessedMembersAttribute' requirements. The implicit 'this' argument of method 'source method' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to](../core/deploying/trimming/trim-warnings/il2084.md)
- [IL2085: 'this' argument does not satisfy 'DynamicallyAccessedMembersAttribute' in call to 'target method'. The implicit 'this' argument of method 'source method' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to](../core/deploying/trimming/trim-warnings/il2085.md)
- [IL2087: 'target parameter' argument does not satisfy 'DynamicallyAccessedMembersAttribute' in call to 'target method'. The generic parameter 'source generic parameter' of 'source method or type' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to](../core/deploying/trimming/trim-warnings/il2087.md)
- [IL2088: 'target method' method return value does not satisfy 'DynamicallyAccessedMembersAttribute' requirements. The generic parameter 'source generic parameter' of 'source method or type' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to](../core/deploying/trimming/trim-warnings/il2088.md)
- [IL2089: Value stored in field 'target field' does not satisfy 'DynamicallyAccessedMembersAttribute' requirements. The generic parameter 'source generic parameter' of 'source method or type' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to](../core/deploying/trimming/trim-warnings/il2089.md)
- [IL2090: 'this' argument does not satisfy 'DynamicallyAccessedMembersAttribute' in call to 'target method'. The generic parameter 'source generic parameter' of 'source method or type' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to](../core/deploying/trimming/trim-warnings/il2090.md)
- [IL2091: 'target generic parameter' generic argument does not satisfy 'DynamicallyAccessedMembersAttribute' in 'target method or type'. The generic parameter 'source target parameter' of 'source method or type' does not have matching annotations. The source value must declare at least the same requirements as those declared on the target location it is assigned to](../core/deploying/trimming/trim-warnings/il2091.md)
- [IL2092: The 'DynamicallyAccessedMemberTypes' value used in a 'DynamicallyAccessedMembersAttribute' annotation on a method's parameter does not match the 'DynamicallyAccessedMemberTypes' value of the overridden parameter annotation. All overridden members must have the same attribute's usage](../core/deploying/trimming/trim-warnings/il2092.md)
- [IL2093: The 'DynamicallyAccessedMemberTypes' value used in a 'DynamicallyAccessedMembersAttribute' annotation on a method's return type does not match the 'DynamicallyAccessedMemberTypes' value of the overridden return type annotation. All overridden members must have the same attribute's usage](../core/deploying/trimming/trim-warnings/il2093.md)
- [IL2094: The 'DynamicallyAccessedMemberTypes' value used in a 'DynamicallyAccessedMembersAttribute' annotation on a method's implicit `this` parameter does not match the 'DynamicallyAccessedMemberTypes' value of the overridden `this` parameter annotation. All overridden members must have the same attribute's usage](../core/deploying/trimming/trim-warnings/il2094.md)
- [IL2095: The 'DynamicallyAccessedMemberTypes' value used in a 'DynamicallyAccessedMembersAttribute' annotation on a method's generic parameter does not match the 'DynamicallyAccessedMemberTypes' value of the overridden generic parameter annotation. All overridden members must have the same attribute's usage](../core/deploying/trimming/trim-warnings/il2095.md)
- [IL2096: Call to 'Type.GetType(System.String,System.Boolean,System.Boolean)' can perform case insensitive lookup of the type. Currently, Trimmer cannot guarantee presence of all the matching types](../core/deploying/trimming/trim-warnings/il2096.md)
- [IL2097: Field annotated with 'DynamicallyAccessedMembersAttribute' is not of type 'System.Type', 'System.String', or derived](../core/deploying/trimming/trim-warnings/il2097.md)
- [IL2098: Method's parameter annotated with 'DynamicallyAccessedMembersAttribute' is not of type 'System.Type', 'System.String', or derived](../core/deploying/trimming/trim-warnings/il2098.md)
- [IL2099: Property annotated with 'DynamicallyAccessedMembersAttribute' is not of type 'System.Type;, 'System.String', or derived](../core/deploying/trimming/trim-warnings/il2099.md)
- [IL2100: Trimmer XML contains unsupported wildcard on argument `fullname` of an assembly element](../core/deploying/trimming/trim-warnings/il2100.md)
- [IL2101: Assembly's embedded XML references a different assembly in `fullname` argument of an assembly element](../core/deploying/trimming/trim-warnings/il2101.md)
- [IL2102: Invalid 'Reflection.AssemblyMetadataAttribute' attribute found in assembly. Value must be `True`](../core/deploying/trimming/trim-warnings/il2102.md)
- [IL2103: Value passed to the 'propertyAccessor' parameter of method 'System.Linq.Expressions.Expression.Property(Expression, MethodInfo)' cannot be statically determined as a property accessor](../core/deploying/trimming/trim-warnings/il2103.md)
- [IL2104: Assembly produced trim warnings](../core/deploying/trimming/trim-warnings/il2104.md)
- [IL2105: Type 'type' was not found in the caller assembly nor in the base library. Type name strings used for dynamically accessing a type should be assembly qualified](../core/deploying/trimming/trim-warnings/il2105.md)
- [IL2106: Return type of method 'method' has 'DynamicallyAccessedMembersAttribute', but that attribute can only be applied to properties of type 'System.Type' or 'System.String'](../core/deploying/trimming/trim-warnings/il2106.md)
- [IL2107: Methods 'method1' and 'method2' are both associated with state machine type 'type'. This is currently unsupported and may lead to incorrectly reported warnings](../core/deploying/trimming/trim-warnings/il2107.md)
- [IL2108: Invalid scope 'scope' used in 'UnconditionalSuppressMessageAttribute' on module 'module' with target 'target'](../core/deploying/trimming/trim-warnings/il2108.md)
- [IL2109: Type derives from base type that has 'RequiresUnreferencedCodeAttribute'](../core/deploying/trimming/trim-warnings/il2109.md)
- [IL2110: Field with 'DynamicallyAccessedMembersAttribute' is accessed via reflection. Trimmer cannot guarantee availability of the requirements of the field](../core/deploying/trimming/trim-warnings/il2110.md)
- [IL2111: Method with parameters or return value with 'DynamicallyAccessedMembersAttribute' is accessed via reflection. Trimmer cannot guarantee availability of the requirements of the method](../core/deploying/trimming/trim-warnings/il2111.md)
- [IL2112: 'DynamicallyAccessedMembersAttribute' on 'type' or one of its base types references 'member', which requires unreferenced code](../core/deploying/trimming/trim-warnings/il2112.md)
- [IL2113: 'DynamicallyAccessedMembersAttribute' on 'type' or one of its base types references 'member', which requires unreferenced code](../core/deploying/trimming/trim-warnings/il2113.md)
- [IL2114: 'DynamicallyAccessedMembersAttribute' on 'type' or one of its base types references 'member' which has 'DynamicallyAccessedMembersAttribute' requirements](../core/deploying/trimming/trim-warnings/il2114.md)
- [IL2115: 'DynamicallyAccessedMembersAttribute' on 'type' or one of its base types references 'member' which has 'DynamicallyAccessedMembersAttribute' requirements](../core/deploying/trimming/trim-warnings/il2115.md)
- [IL2116: 'RequiresUnreferencedCodeAttribute' cannot be placed directly on a static constructor. Consider placing it on the type declaration instead](../core/deploying/trimming/trim-warnings/il2116.md)

## Architecture guides

### Updated articles

- [Develop ASP.NET Core MVC apps](../architecture/modern-web-apps-azure/develop-asp-net-core-mvc-apps.md) - Upgrade Architecting Modern Web Apps Azure eBook to .NET 6
- [Test ASP.NET Core MVC apps](../architecture/modern-web-apps-azure/test-asp-net-core-mvc-apps.md) - Upgrade Architecting Modern Web Apps Azure eBook to .NET 6
- [Working with Data in ASP.NET Core Apps](../architecture/modern-web-apps-azure/work-with-data-in-asp-net-core-apps.md) - Upgrade Architecting Modern Web Apps Azure eBook to .NET 6
- [Migrate from ASP.NET Web Forms to Blazor](../architecture/blazor-for-web-forms-developers/migration.md) - Blazor ebook net6
- [Project structure for Blazor apps](../architecture/blazor-for-web-forms-developers/project-structure.md) - Blazor ebook net6

## C# language

### New articles

- [Jump statements (C# reference)](../csharp/language-reference/statements/jump-statements.md)

## Community contributors

The following people contributed to the .NET docs during this period. Thank you! Learn how to contribute by following the links under "Get involved" in the [what's new landing page](index.yml).

- [pkulikov](https://github.com/pkulikov) - Petr Kulikov (10)
- [GitHubPang](https://github.com/GitHubPang) (7)
- [PhilipYordanov](https://github.com/PhilipYordanov) - Filip Yordanov (3)
- [sughosneo](https://github.com/sughosneo) - Sumit Ghosh (3)
- [ardalis](https://github.com/ardalis) - Steve Smith (2)
- [sguitardude](https://github.com/sguitardude) (2)
- [BaruaSourav](https://github.com/BaruaSourav) - Sourav Barua (1)
- [belyaevsa](https://github.com/belyaevsa) - Stanislav Belyaev (1)
- [cartermp](https://github.com/cartermp) - Phillip Carter (1)
- [colindembovsky](https://github.com/colindembovsky) - Colin Dembovsky (1)
- [DiskCrasher](https://github.com/DiskCrasher) - Mike (1)
- [GregoryShields](https://github.com/GregoryShields) - Gregory Shields (1)
- [Happypig375](https://github.com/Happypig375) - Hadrian Tang (1)
- [hrkeni](https://github.com/hrkeni) - Harshith Keni (1)
- [icyfire0573](https://github.com/icyfire0573) (1)
- [jwood803](https://github.com/jwood803) - Jon Wood (1)
- [LevShisterov](https://github.com/LevShisterov) - Lev (1)
- [madelson](https://github.com/madelson) (1)
- [mateoatr](https://github.com/mateoatr) - Mateo Torres-Ruiz (1)
- [say25](https://github.com/say25) - Steven Yeh (1)
- [shadow-cs](https://github.com/shadow-cs) - Honza Rameš (1)
- [veloek](https://github.com/veloek) - Vegard Løkken (1)
- [vishallama](https://github.com/vishallama) - Vishal Lama (1)
- [VladSabre](https://github.com/VladSabre) - Vladislav Musidze (1)
- [vmandic](https://github.com/vmandic) - Vedran Mandić (1)
- [willd1985](https://github.com/willd1985) (1)
- [zbalkan](https://github.com/zbalkan) - Zafer Balkan (1)

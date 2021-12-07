---
title: ".NET docs: What's new for September 1, 2021 - September 30, 2021"
description: "What's new in the .NET docs for September 1, 2021 - September 30, 2021."
ms.date: 10/01/2021
---

# .NET docs: What's new for September 1, 2021 - September 30, 2021

Welcome to what's new in the .NET docs from September 1, 2021 through September 30, 2021. This article lists some of the major changes to docs during this period.

## .NET fundamentals

### New articles

- [ListViewGroupCollection methods throw new InvalidOperationException](../core/compatibility/windows-forms/6.0/listview-invalidoperationexception.md)
- [JSON source-generation API refactoring](../core/compatibility/serialization/6.0/json-source-gen-api-refactor.md)
- [TryParse and BindAsync methods are validated](../core/compatibility/aspnet-core/6.0/tryparse-bindasync-validation.md)
- [New nullable annotation in AssociatedMetadataTypeTypeDescriptionProvider](../core/compatibility/core-libraries/6.0/nullable-ref-type-annotations-added.md)
- [RuntimeIdentifier warning if self-contained is unspecified](../core/compatibility/sdk/6.0/runtimeidentifier-self-contained.md)
- [CA2252: Opt in to preview features before using them](../fundamentals/code-analysis/quality-rules/ca2252.md)
- [MSBuild no longer supports calling GetType()](../core/compatibility/sdk/6.0/calling-gettype-property-functions.md)
- [New JsonSerializer source generator overloads](../core/compatibility/serialization/6.0/jsonserializer-source-generator-overloads.md)
- [Static abstract members in interfaces](../core/compatibility/core-libraries/6.0/static-abstract-interface-methods.md)
- [Introduction to trim warnings](../core/deploying/trimming/fixing-warnings.md)
- [SYSLIB0032: Recovery from corrupted process state exceptions is not supported](../fundamentals/syslib-diagnostics/syslib0032.md)
- [SYSLIB0033: Rfc2898DeriveBytes.CryptDeriveKey is obsolete](../fundamentals/syslib-diagnostics/syslib0033.md)
- [SYSLIB0034: CmsSigner(CspParameters) constructor is obsolete](../fundamentals/syslib-diagnostics/syslib0034.md)
- [SYSLIB0035: ComputeCounterSignature without specifying a CmsSigner is obsolete](../fundamentals/syslib-diagnostics/syslib0035.md)
- [Use HTTP/3 with HttpClient](../core/extensions/httpclient-http3.md)
- [Tutorial: Use the `ComWrappers` API](../standard/native-interop/tutorial-comwrappers.md)
- [Razor: Logging ID changes](../core/compatibility/aspnet-core/6.0/razor-pages-logging-ids.md)
- [CA5404: Do not disable token validation checks](../fundamentals/code-analysis/quality-rules/ca5404.md)
- [CA5405: Do not always skip token validation in delegates](../fundamentals/code-analysis/quality-rules/ca5405.md)
- [CA1418: Validate platform compatibility](../fundamentals/code-analysis/quality-rules/ca1418.md)
- [CA1849: Call async methods when in an async method](../fundamentals/code-analysis/quality-rules/ca1849.md)
- [IL2001: Descriptor file tried to preserve fields on type that has no fields](../core/deploying/trimming/trim-warnings/il2001.md)
- [IL2002: Descriptor file tried to preserve methods on type that has no methods](../core/deploying/trimming/trim-warnings/il2002.md)
- [IL2003: Could not resolve dependency assembly specified in a 'PreserveDependency' attribute](../core/deploying/trimming/trim-warnings/il2003.md)
- [IL2004: Could not resolve dependency type specified in a 'PreserveDependency' attribute](../core/deploying/trimming/trim-warnings/il2004.md)
- [IL2005: Could not resolve dependency member specified in a 'PreserveDependency' attribute](../core/deploying/trimming/trim-warnings/il2005.md)
- [IL2007: Could not resolve assembly specified in descriptor file](../core/deploying/trimming/trim-warnings/il2007.md)
- [IL2008: Could not resolve type specified in descriptor file](../core/deploying/trimming/trim-warnings/il2008.md)
- [IL2009: Could not resolve method specified in descriptor file](../core/deploying/trimming/trim-warnings/il2009.md)
- [IL2010: Invalid value on a method substitution](../core/deploying/trimming/trim-warnings/il2010.md)
- [IL2011: Unknown body modification action](../core/deploying/trimming/trim-warnings/il2011.md)
- [IL2012: Could not find field on type in substitution file](../core/deploying/trimming/trim-warnings/il2012.md)
- [IL2013: Substituted fields must be static or constant](../core/deploying/trimming/trim-warnings/il2013.md)
- [IL2014: Missing value for field substitution](../core/deploying/trimming/trim-warnings/il2014.md)
- [IL2015: Invalid value for field substitution](../core/deploying/trimming/trim-warnings/il2015.md)
- [IL2016: Could not find event on type](../core/deploying/trimming/trim-warnings/il2016.md)
- [IL2017: Could not find property on type](../core/deploying/trimming/trim-warnings/il2017.md)
- [IL2018: Could not find the get accessor of property on type in descriptor file](../core/deploying/trimming/trim-warnings/il2018.md)
- [IL2019: Could not find the set accessor of property on type in descriptor file](../core/deploying/trimming/trim-warnings/il2019.md)
- [IL2022: Could not find matching constructor for custom attribute specified in custom attribute annotations file](../core/deploying/trimming/trim-warnings/il2022.md)
- [IL2023: There is more than one `return` child element specified for a method in a custom attribute annotations file](../core/deploying/trimming/trim-warnings/il2023.md)
- [IL2024: There is more than one value specified for the same method parameter in a custom attribute annotations file](../core/deploying/trimming/trim-warnings/il2024.md)
- [IL2025: Duplicate preserve of a member in a descriptor file](../core/deploying/trimming/trim-warnings/il2025.md)
- [IL2027: Known trimmer attribute used more than once on a single member](../core/deploying/trimming/trim-warnings/il2027.md)
- [IL2028: Known trimmer attribute does not have the required number of parameters](../core/deploying/trimming/trim-warnings/il2028.md)
- [IL2029: Attribute element in custom attribute annotations file does not have required argument `fullname` or it is empty](../core/deploying/trimming/trim-warnings/il2029.md)
- [IL2030: Could not resolve an assembly specified in a custom attribute annotations file](../core/deploying/trimming/trim-warnings/il2030.md)
- [IL2031: Could not resolve custom attribute specified in a custom attribute annotations file](../core/deploying/trimming/trim-warnings/il2031.md)
- [IL2032: Unrecognized value passed to the parameter 'parameter' of 'System.Activator.CreateInstance' method](../core/deploying/trimming/trim-warnings/il2032.md)
- [IL2033: 'PreserveDependencyAttribute' is deprecated](../core/deploying/trimming/trim-warnings/il2033.md)
- [IL2034: 'DynamicDependencyAttribute' could not be analyzed](../core/deploying/trimming/trim-warnings/il2034.md)
- [IL2035: Unresolved assembly in 'DynamicDependencyAttribute'](../core/deploying/trimming/trim-warnings/il2035.md)
- [IL2036: Unresolved type in 'DynamicDependencyAttribute'](../core/deploying/trimming/trim-warnings/il2036.md)
- [IL2037: Unresolved member in 'DynamicDependencyAttribute'](../core/deploying/trimming/trim-warnings/il2037.md)
- [IL2038: Missing `name` argument on a resource element in a substitution file](../core/deploying/trimming/trim-warnings/il2038.md)
- [IL2039: Invalid `action` value on resource element in a substitution file](../core/deploying/trimming/trim-warnings/il2039.md)
- [IL2040: Could not find embedded resource specified in a substitution file](../core/deploying/trimming/trim-warnings/il2040.md)
- [IL2041: 'DynamicallyAccessedMembersAttribute' is not allowed on methods](../core/deploying/trimming/trim-warnings/il2041.md)
- [IL2042: Could not find a unique backing field to propagate the 'DynamicallyAccessedMembersAttribute' annotation on a property](../core/deploying/trimming/trim-warnings/il2042.md)
- [IL2043: 'DynamicallyAccessedMembersAttribute' on property conflicts with the same attribute on its accessor method](../core/deploying/trimming/trim-warnings/il2043.md)
- [IL2044: Could not find any type in a namespace specified in a descriptor file](../core/deploying/trimming/trim-warnings/il2044.md)
- [IL2045: Custom attribute is referenced in code but the trimmer was instructed to remove all of its instances](../core/deploying/trimming/trim-warnings/il2045.md)
- [IL2046: All interface implementations and method overrides must have annotations matching the interface or overriden virtual method 'RequiresUnreferencedCodeAttribute' annotations](../core/deploying/trimming/trim-warnings/il2046.md)
- [IL2048: Internal trimmer attribute 'RemoveAttributeInstances' is being used on a member](../core/deploying/trimming/trim-warnings/il2048.md)
- [IL2049: Unrecognized internal attribute](../core/deploying/trimming/trim-warnings/il2049.md)
- [IL2050: Correctness of COM interop cannot be guaranteed](../core/deploying/trimming/trim-warnings/il2050.md)
- [IL2051: Property element does not have required argument `name` in custom attribute annotations file](../core/deploying/trimming/trim-warnings/il2051.md)
- [IL2052: Could not find property specified in custom attribute annotations file](../core/deploying/trimming/trim-warnings/il2052.md)
- [IL2053: Invalid value used in property element in custom attribute annotations file](../core/deploying/trimming/trim-warnings/il2053.md)
- [IL2054: Invalid argument value in custom attribute annotations file](../core/deploying/trimming/trim-warnings/il2054.md)
- [IL2055: Call to 'System.Type.MakeGenericType' cannot be statically analyzed by the trimmer](../core/deploying/trimming/trim-warnings/il2055.md)
- [IL2056: A 'System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute' annotation on a property conflicts with the same attribute on its backing field](../core/deploying/trimming/trim-warnings/il2056.md)
- [IL2057: Unrecognized value passed to the `typeName` parameter of 'System.Type.GetType(String)'](../core/deploying/trimming/trim-warnings/il2057.md)
- [IL2058: Parameters passed to 'Assembly.CreateInstance' cannot be statically analyzed](../core/deploying/trimming/trim-warnings/il2058.md)
- [IL2059: Unrecognized value passed to the `type` parameter of 'System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor'](../core/deploying/trimming/trim-warnings/il2059.md)
- [IL2060: Call to 'System.Reflection.MethodInfo.MakeGenericMethod' cannot be statically analyzed by the trimmer](../core/deploying/trimming/trim-warnings/il2060.md)

### Updated articles

- [Code style rule options](../fundamentals/code-analysis/code-style-rule-options.md) - Update editorconfig example
- [Deploy a Worker Service to Azure](../core/extensions/cloud-service.md) - Update Deploy a Worker Service to Azure article
- [Tutorial: Debug a .NET console application using Visual Studio](../core/tutorials/debugging-with-visual-studio.md) - .NET 6 update
- [Tutorial: Create a .NET class library using Visual Studio](../core/tutorials/library-with-visual-studio.md) - .NET 6 update
- [Tutorial: Publish a .NET console application using Visual Studio](../core/tutorials/publishing-with-visual-studio.md) - .NET 6 update
- [Tutorial: Test a .NET class library with .NET using Visual Studio](../core/tutorials/testing-library-with-visual-studio.md) - .NET 6 update
- [Tutorial: Create a .NET console application using Visual Studio](../core/tutorials/with-visual-studio.md) - .NET 6 update
- [Breaking changes in .NET 5](../core/compatibility/5.0.md) - Add compatibility columns
- [Breaking changes in .NET 6](../core/compatibility/6.0.md) - Add compatibility columns
- [MSBuild reference for .NET SDK projects](../core/project-sdk/msbuild-props.md) - Added EnablePreviewFeatures, GenerateRequiresPreviewFeaturesAttribute, SatelliteResourceLanguages, AssemblyMetadata, InternalsVisibleTo, GenerateRuntimeConfigurationFiles, OptimizeImplicitlyTriggeredBuild

## C# language

### New articles

- [Learn techniques to resolve nullable warnings](../csharp/nullable-warnings.md)

### Updated articles

- [Projection operations (C#)](../csharp/programming-guide/concepts/linq/projection-operations.md) - Add code for set operators, and update existing doc
- [Set operations (C#)](../csharp/programming-guide/concepts/linq/set-operations.md) - Add code for set operators, and update existing doc
- [Nullable reference types](../csharp/nullable-references.md) - Update nullable reference types for C# 10

## F# language

### Updated articles

- [F# code formatting guidelines](../fsharp/style-guide/formatting.md)
  - Update formatting.md
  - Revise F# formatting guide
- [Symbol and operator reference](../fsharp/language-reference/symbol-and-operator-reference/index.md) - Remove overkill bulled list

## ML.NET

### New articles

- [Train an image classification model in Azure using Model Builder](../machine-learning/tutorials/image-classification-model-builder.md)

## Community contributors

The following people contributed to the .NET docs during this period. Thank you! Learn how to contribute by following the links under "Get involved" in the [what's new landing page](index.yml).

- [Uzivatel919](https://github.com/Uzivatel919) (7)
- [pkulikov](https://github.com/pkulikov) - Petr Kulikov (6)
- [GitHubPang](https://github.com/GitHubPang) (5)
- [Youssef1313](https://github.com/Youssef1313) - Youssef Victor (4)
- [dulanov](https://github.com/dulanov) - Daulet Dulanov (3)
- [bergerb](https://github.com/bergerb) - Brent (2)
- [knocte](https://github.com/knocte) - Andres G. Aragoneses (2)
- [omajid](https://github.com/omajid) - Omair Majid (2)
- [AdrianEdelen](https://github.com/AdrianEdelen) - Adrian Edelen (1)
- [arturohernandez10](https://github.com/arturohernandez10) (1)
- [bb-froggy](https://github.com/bb-froggy) (1)
- [DejanPopovic1](https://github.com/DejanPopovic1) - Dean Popovic (1)
- [dunkyl](https://github.com/dunkyl) (1)
- [gamingrobot](https://github.com/gamingrobot) - Morgan Creekmore (1)
- [Gh0stWalk3r](https://github.com/Gh0stWalk3r) - Gregor Dostal (1)
- [jaroldwong](https://github.com/jaroldwong) - Jarold Wong (1)
- [jwood803](https://github.com/jwood803) - Jon Wood (1)
- [jzabroski](https://github.com/jzabroski) - John Zabroski (1)
- [jzsampaio](https://github.com/jzsampaio) - Juarez Sampaio (1)
- [kcootedinh](https://github.com/kcootedinh) - Kieran Coote-Dinh (1)
- [kthompson](https://github.com/kthompson) - Kevin Thompson (1)
- [limuyuan](https://github.com/limuyuan) - Morris Li (1)
- [mahdiva](https://github.com/mahdiva) - Mahdi Varposhti (1)
- [marzo23](https://github.com/marzo23) (1)
- [MSDN-WhiteKnight](https://github.com/MSDN-WhiteKnight) - MSDN.WhiteKnight (1)
- [okyrylchuk](https://github.com/okyrylchuk) - Oleg Kyrylchuk (1)
- [Pentiminax](https://github.com/Pentiminax) - Pentiminax (1)
- [Psycho900](https://github.com/Psycho900) (1)
- [ranma42](https://github.com/ranma42) - Andrea Canciani (1)
- [rstm-sf](https://github.com/rstm-sf) - Rustam (1)
- [smoothdeveloper](https://github.com/smoothdeveloper) - Gauthier Segay (1)
- [StingyJack](https://github.com/StingyJack) - Andrew Stanton (1)
- [usewits](https://github.com/usewits) - Abe Wits (1)
- [zanaptak](https://github.com/zanaptak) (1)
- [zedy-wj](https://github.com/zedy-wj) - Wenjie Yu（MSFT） (1)

---
title: Resolve errors related to language version and features
description: Several compiler errors indicate that your configured language version doesn't support a feature you're using. This article shows how to fix those errors and warnings.
f1_keywords:
  - "CS0171"
  - "CS0188"
  - "CS0843"
  - "CS1617" # ERR_BadCompatMode  Invalid option for /langversion. Use '/langversion:?' to list supported values.
  - "CS1638" # ERR_ReservedIdentifier  'identifier' is a reserved identifier and cannot be used when ISO language version mode is used
  - "CS8904" # ERR_UnexpectedVarianceStaticMember  Invalid variance: The type parameter '{1}' must be {3} valid on '{0}' unless language version '{4}' or greater is used. '{1}' is {2}.
  - "CS1738" # ERR_NamedArgumentSpecificationBeforeFixedArgument  Named argument specifications must appear after all fixed arguments have been specified. Please use language version {0} or greater to allow non-trailing named arguments
  - "CS8022" # ERR_FeatureNotAvailableInVersion1  Feature is not available in C# 1. Please use language version.
  - "CS8023" # ERR_FeatureNotAvailableInVersion2  Feature is not available in C# 2. Please use language version.
  - "CS8024" # ERR_FeatureNotAvailableInVersion3  Feature is not available in C# 3. Please use language version.
  - "CS8025" # ERR_FeatureNotAvailableInVersion4  Feature is not available in C# 4. Please use language version.
  - "CS8021" # WRN_NoRuntimeMetadataVersion  No value for RuntimeMetadataVersion found.
  - "CS8026" # ERR_FeatureNotAvailableInVersion5  Feature is not available in C# 5. Please use language version.
  - "CS8059" # ERR_FeatureNotAvailableInVersion6  Feature is not available in C# 6. Please use language version.
  - "CS8107" # ERR_FeatureNotAvailableInVersion7  Feature is not available in C# 7. Please use language version.
  - "CS8302" # ERR_FeatureNotAvailableInVersion7_1  Feature is not available in C# 7.1. Please use language version.
  - "CS8320" # ERR_FeatureNotAvailableInVersion7_2  Feature is not available in C# 7.2. Please use language version.
  - "CS8370" # ERR_FeatureNotAvailableInVersion7_3  Feature is not available in C# 7.3. Please use language version.
  - "CS8400" # ERR_FeatureNotAvailableInVersion8  Feature is not available in C# 8. Please use language version.
  - "CS8773" # ERR_FeatureNotAvailableInVersion9  Feature is not available in C# 9. Please use language version.
  - "CS8936" # ERR_FeatureNotAvailableInVersion10  Feature is not available in C# 10. Please use language version.
  - "CS9058" # ERR_FeatureNotAvailableInVersion11  Feature is not available in C# 11. Please use language version.
  - "CS8303" # ERR_LanguageVersionCannotHaveLeadingZeroes  Specified language version cannot have leading zeroes
  - "CS8304" # ERR_CompilerAndLanguageVersion  Compiler version is lower than Language version
  - "CS8306" # ERR_TupleInferredNamesNotAvailable Tuple element name '{0}' is inferred. Please use language version {1} or greater to access an element by its inferred name.
  - "CS8371" # WRN_AttributesOnBackingFieldsNotAvailable  Field-targeted attributes on auto-properties are not supported in language version
  - "CS8401" # ERR_AltInterpolatedVerbatimStringsNotAvailable  To use '@$' instead of '$@' for an interpolated verbatim string, please use language version '{0}' or greater.
  - "CS8511" # ERR_ConstantPatternVsOpenType  An expression of type '{0}' cannot be handled by a pattern of type '{1}'
  - "CS8192" # ERR_BadLanguageVersion   Provided language version is unsupported or invalid
  - "CS8627" # ERR_NullableUnconstrainedTypeParameter  A nullable type parameter must be known to be a value type or non-nullable reference type
  - "CS8630" # ERR_NullableOptionNotAvailable  Invalid '{0}' value: '{1}' for C# {2}. Please use language version '{3}' or greater
  - "CS8314" # ERR_PatternWrongGenericTypeInVersion  An expression of type '{0}' cannot be handled by a pattern of type
  - "CS8652" # ERR_FeatureInPreview  The feature '{0}' is currently in Preview and *unsupported*. To use Preview features, use the 'preview' language version
  - "CS8701" # ERR_RuntimeDoesNotSupportDefaultInterfaceImplementation  Target runtime doesn't support default interface implementation.
  - "CS8702" # ERR_RuntimeDoesNotSupportDefaultInterfaceImplementationForMember  'member' cannot implement interface member because the target runtime doesn't support default interface implementation.
  - "CS8703" # ERR_InvalidModifierForLanguageVersion  The modifier '{0}' is not valid for this item in C# {1}. Please use language version '{2}' or greater.
  - "CS8704" # ERR_ImplicitImplementationOfNonPublicInterfaceMember  Type does not implement interface member. Type cannot implicitly implement a non-public member in selected version.
  - "CS8706" # ERR_LanguageVersionDoesNotSupportInterfaceImplementationForMember  Type cannot implement interface member '{1}' in type '{2}' because feature '{3}' is not available in 
  - "CS8707" # ERR_RuntimeDoesNotSupportProtectedAccessForInterfaceMember  Target runtime doesn't support 'protected', 'protected internal', or 'private protected' accessibility for a member of an interface.
  - "CS8830" # ERR_RuntimeDoesNotSupportCovariantReturnsOfClasses  Target runtime doesn't support covariant return types in overrides.
  - "CS8831" # ERR_RuntimeDoesNotSupportCovariantPropertiesOfClasses  Target runtime doesn't support covariant types in overrides.
  - "CS8888" # ERR_CannotSpecifyManagedWithUnmanagedSpecifiers  'managed' calling convention cannot be combined with unmanaged calling convention specifiers.
  - "CS8889" # ERR_RuntimeDoesNotSupportUnmanagedDefaultCallConv  The target runtime doesn't support extensible or runtime-environment default calling conventions.
  - "CS8890" # ERR_TypeNotFound  Type is not defined.
  - "CS8891" # ERR_TypeMustBePublic  Type must be public to be used as a calling convention.
  - "CS8919"
  - "CS8929"
  - "CS8957" # ERR_NoImplicitConvTargetTypedConditional  Conditional expression is not valid in language version {0} because a common type was not found between '{1}' and '{2}'
  - "CS8912" # ERR_InheritingFromRecordWithSealedToString  Inheriting from a record with a sealed 'Object.ToString' is not supported
  - "CS9041" # ERR_UnsupportedCompilerFeature  '{0}' requires compiler feature '{1}', which is not supported by this version of the C# compiler.
  - "CS9014" # ERR_UseDefViolationPropertyUnsupportedVersion  Use of possibly unassigned property
  - "CS9015" # ERR_UseDefViolationFieldUnsupportedVersion  Use of possibly unassigned field
  - "CS9016" # WRN_UseDefViolationPropertyUnsupportedVersion  Use of possibly unassigned property
  - "CS9017" # WRN_UseDefViolationFieldUnsupportedVersion  Use of possibly unassigned field
  - "CS8967" # ERR_NewlinesAreNotAllowedInsideANonVerbatimInterpolatedString  Newlines inside a non-verbatim interpolated string are not supported in C#
  - "CS9064"
  - "CS9103"
  - "CS9171"
  - "CS8058"
  - "CS8305"
  - "CS9204"
  - "CS9194"
  - "CS9202"
  - "CS9211"
  - "CS9240"
  - "CS9260"
  - "CS9268"
  - "CS9269"
  - "CS9271"
  - "CS9327"
  - "CS9328"
  - "CS9346" # ERR_EncUpdateRequiresEmittingExplicitInterfaceImplementationNotSupportedByTheRuntime
  - "CS9352" # ERR_RuntimeDoesNotSupportExtendedLayoutTypes  The target runtime does not support extended layout types.
helpviewer_keywords:
  - "CS0171"
  - "CS0188"
  - "CS0843"
  - "CS1617"
  - "CS1638"
  - "CS8904"
  - "CS1738"
  - "CS8022"
  - "CS8023"
  - "CS8024"
  - "CS8025"
  - "CS8026"
  - "CS8021"
  - "CS8059"
  - "CS8107"
  - "CS8302"
  - "CS8320"
  - "CS8370"
  - "CS8400"
  - "CS8773"
  - "CS8936"
  - "CS9058"
  - "CS8303"
  - "CS8304"
  - "CS8306"
  - "CS8371"
  - "CS8401"
  - "CS8511"
  - "CS8192"
  - "CS8627"
  - "CS8630"
  - "CS8314"
  - "CS8652"
  - "CS8701"
  - "CS8702"
  - "CS8703"
  - "CS8704"
  - "CS8706"
  - "CS8707"
  - "CS8830"
  - "CS8831"
  - "CS8888"
  - "CS8889"
  - "CS8890"
  - "CS8891"
  - "CS8957"
  - "CS8912"
  - "CS8919"
  - "CS8929"
  - "CS9041"
  - "CS9014"
  - "CS9015"
  - "CS9016"
  - "CS9017"
  - "CS8967"
  - "CS9064"
  - "CS9103"
  - "CS9171"
  - "CS8058"
  - "CS8305"
  - "CS9204"
  - "CS9194"
  - "CS9202"
  - "CS9211"
  - "CS9240"
  - "CS9260"
  - "CS9268"
  - "CS9269"
  - "CS9271"
  - "CS9327"
  - "CS9328"
  - "CS9346"
  - "CS9352"
ms.date: 05/07/2026
---
# Resolve errors and warnings for language features and versions

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0171**](#breaking-changes-on-struct-initialization): *Field 'name' must be fully assigned before control is returned to the caller. Consider updating to language version 'version' to auto-default the field.*
- [**CS0188**](#breaking-changes-on-struct-initialization): *The 'this' object cannot be used before all of its fields have been assigned. Consider updating to language version 'version' to auto-default the unassigned fields.*
- [**CS0843**](#breaking-changes-on-struct-initialization): *Auto-implemented property 'name' must be fully assigned before control is returned to the caller. Consider updating to language version 'version' to auto-default the property.*
- [**CS1617**](#language-version-configuration-errors): *Invalid option 'option' for /langversion. Use '/langversion:?' to list supported values.*
- [**CS1638**](#language-version-configuration-errors): *'identifier' is a reserved identifier and cannot be used when ISO language version mode is used*
- [**CS1738**](#feature-not-available-in-language-version): *Named argument specifications must appear after all fixed arguments have been specified. Please use language version 7.2 or greater to allow non-trailing named arguments.*
- [**CS8021**](#target-runtime-doesnt-support-feature): *No value for RuntimeMetadataVersion found. No assembly containing System.Object was found nor was a value for RuntimeMetadataVersion specified through options.*
- [**CS8022**](#feature-not-available-in-language-version): *Feature is not available in C# 1. Please use language version 2 or greater.*
- [**CS8023**](#feature-not-available-in-language-version): *Feature is not available in C# 2. Please use language version 3 or greater.*
- [**CS8024**](#feature-not-available-in-language-version): *Feature is not available in C# 3. Please use language version 4 or greater.*
- [**CS8025**](#feature-not-available-in-language-version): *Feature is not available in C# 4. Please use language version 5 or greater.*
- [**CS8026**](#feature-not-available-in-language-version): *Feature is not available in C# 5. Please use language version 6 or greater.*
- [**CS8058**](#experimental-and-preview-features): *Feature 'feature' is experimental and unsupported; use '/features:feature' to enable.*
- [**CS8059**](#feature-not-available-in-language-version): *Feature is not available in C# 6. Please use language version 7 or greater.*
- [**CS8107**](#feature-not-available-in-language-version): *Feature is not available in C# 7.0. Please use language version 7.1 or greater.*
- [**CS8192**](#language-version-configuration-errors): *Provided language version is unsupported or invalid: 'value'.*
- [**CS8302**](#feature-not-available-in-language-version): *Feature is not available in C# 7.1. Please use language version 7.2 or greater.*
- [**CS8303**](#language-version-configuration-errors): *Specified language version 'value' cannot have leading zeroes*
- [**CS8304**](#language-version-configuration-errors): *Compiler version: 'version'. Language version: version.*
- [**CS8305**](#experimental-and-preview-features): *'type' is for evaluation purposes only and is subject to change or removal in future updates.*
- [**CS8306**](#feature-not-available-in-language-version): *Tuple element name 'name' is inferred. Please use language version 7.1 or greater to access an element by its inferred name.*
- [**CS8314**](#feature-not-available-in-language-version): *An expression of type 'type' cannot be handled by a pattern of type 'type' in C# version. Please use language version 'version' or greater.*
- [**CS8320**](#feature-not-available-in-language-version): *Feature is not available in C# 7.2. Please use language version 7.3 or greater.*
- [**CS8370**](#feature-not-available-in-language-version): *Feature is not available in C# 7.3. Please use language version 8 or greater.*
- [**CS8371**](#feature-not-available-in-language-version): *Field-targeted attributes on auto-properties are not supported in language version 7.3. Please use language version 8.0 or greater.*
- [**CS8400**](#feature-not-available-in-language-version): *Feature is not available in C# 8. Please use language version 9 or greater.*
- [**CS8401**](#feature-not-available-in-language-version): *To use '@$' instead of '$@' for an interpolated verbatim string, please use language version 8.0 or greater.*
- [**CS8511**](#feature-not-available-in-language-version): *An expression of type 'type' cannot be handled by a pattern of type 'type'. Please use language version 'version' or greater to match an open type with a constant pattern.*
- [**CS8627**](#feature-not-available-in-language-version): *A nullable type parameter must be known to be a value type or non-nullable reference type unless language version 'version' or greater is used. Consider changing the language version or adding a 'class', 'struct', or type constraint.*
- [**CS8630**](#feature-not-available-in-language-version): *Invalid 'option' value: 'value' for C# version. Please use language version 'version' or greater.*
- [**CS8652**](#experimental-and-preview-features): *The feature is currently in Preview and unsupported. To use Preview features, use the 'preview' language version.*
- [**CS8701**](#target-runtime-doesnt-support-feature): *Target runtime doesn't support default interface implementation.*
- [**CS8702**](#target-runtime-doesnt-support-feature): *'member' cannot implement interface member 'member' in type 'type' because the target runtime doesn't support default interface implementation.*
- [**CS8703**](#feature-not-available-in-language-version): *The modifier 'modifier' is not valid for this item in C# version. Please use language version 8.0 or greater.*
- [**CS8704**](#feature-not-available-in-language-version): *'type' does not implement interface member 'member'. 'type' cannot implicitly implement a non-public member in C# version. Please use language version 'version' or greater.*
- [**CS8706**](#feature-not-available-in-language-version): *Type cannot implement interface member in type because feature is not available in C# 7.3.*
- [**CS8707**](#target-runtime-doesnt-support-feature): *Target runtime doesn't support 'protected', 'protected internal', or 'private protected' accessibility for a member of an interface.*
- [**CS8773**](#feature-not-available-in-language-version): *Feature is not available in C# 9. Please use language version 10 or greater.*
- [**CS8830**](#target-runtime-doesnt-support-feature): *Target runtime doesn't support covariant return types in overrides. Return type must be 'type' to match overridden member 'member'.*
- [**CS8831**](#target-runtime-doesnt-support-feature): *Target runtime doesn't support covariant types in overrides. Type must be 'type' to match overridden member 'member'.*
- [**CS8888**](#function-pointer-and-calling-convention-errors): *'managed' calling convention cannot be combined with unmanaged calling convention specifiers.*
- [**CS8889**](#function-pointer-and-calling-convention-errors): *The target runtime doesn't support extensible or runtime-environment default calling conventions.*
- [**CS8890**](#function-pointer-and-calling-convention-errors): *Type 'type' is not defined.*
- [**CS8891**](#function-pointer-and-calling-convention-errors): *Type 'type' must be public to be used as a calling convention.*
- [**CS8904**](#feature-not-available-in-language-version): *Invalid variance: The type parameter must be invariantly valid on 'member' unless language version 9.0 or greater is used.*
- [**CS8912**](#feature-not-available-in-language-version): *Inheriting from a record with a sealed 'Object.ToString' is not supported in C# 9.0. Please use language version 10.0 or greater.*
- [**CS8919**](#target-runtime-doesnt-support-feature): *Target runtime doesn't support static abstract members in interfaces.*
- [**CS8929**](#target-runtime-doesnt-support-feature): *'method' cannot implement interface member 'member' in type 'type' because the target runtime doesn't support static abstract members in interfaces.*
- [**CS8936**](#feature-not-available-in-language-version): *Feature is not available in C# 10. Please use language version 11 or greater.*
- [**CS8957**](#feature-not-available-in-language-version): *Conditional expression is not valid in language version 8.0 because a common type was not found between 'type' and 'type'. To use a target-typed conversion, upgrade to language version 9.0 or greater.*
- [**CS8967**](#feature-not-available-in-language-version): *Newlines inside a non-verbatim interpolated string are not supported in C# 10.0. Please use language version 11.0 or greater.*
- [**CS9014**](#breaking-changes-on-struct-initialization): *Use of possibly unassigned auto-implemented property 'name'. Consider updating to language version 'version' to auto-default the property.*
- [**CS9015**](#breaking-changes-on-struct-initialization): *Use of possibly unassigned field 'name'. Consider updating to language version 'version' to auto-default the field.*
- [**CS9016**](#breaking-changes-on-struct-initialization): *Use of possibly unassigned auto-implemented property 'name'. Consider updating to language version 'version' to auto-default the property.*
- [**CS9017**](#breaking-changes-on-struct-initialization): *Use of possibly unassigned field 'name'. Consider updating to language version 'version' to auto-default the field.*
- [**CS9041**](#target-runtime-doesnt-support-feature): *'type' requires compiler feature 'feature', which is not supported by this version of the C# compiler.*
- [**CS9058**](#feature-not-available-in-language-version): *Feature is not available in C# 11. Please use language version 12 or greater.*
- [**CS9064**](#target-runtime-doesnt-support-feature): *Target runtime doesn't support ref fields.*
- [**CS9103**](#target-runtime-doesnt-support-feature): *'type' is defined in a module with an unrecognized RefSafetyRulesAttribute version, expecting '11'.*
- [**CS9171**](#target-runtime-doesnt-support-feature): *Target runtime doesn't support inline array types.*
- [**CS9194**](#feature-not-available-in-language-version): *Argument may not be passed with the 'ref' keyword. To pass 'ref' arguments to 'in' parameters, upgrade to language version 12 or greater.*
- [**CS9202**](#feature-not-available-in-language-version): *Feature is not available in C# 12.0. Please use language version 13 or greater.*
- [**CS9204**](#experimental-and-preview-features): *'type' is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.*
- [**CS9211**](#experimental-and-preview-features): *The diagnosticId argument to the 'Experimental' attribute must be a valid identifier.*
- [**CS9240**](#target-runtime-doesnt-support-feature): *Target runtime doesn't support by-ref-like generics.*
- [**CS9260**](#feature-not-available-in-language-version): *Feature is not available in C# 13.0. Please use language version 14 or greater.*
- [**CS9268**](#experimental-and-preview-features): *'type' is for evaluation purposes only and is subject to change or removal in future updates: 'message'. Suppress this diagnostic to proceed.*
- [**CS9269**](#implementation-specific-attributes): *UnscopedRefAttribute is only valid in C# 11 or later or when targeting net7.0 or later.*
- [**CS9271**](#implementation-specific-attributes): *The type 'Microsoft.CodeAnalysis.EmbeddedAttribute' must be non-generic, internal, non-file, sealed, non-static, have a parameterless constructor, inherit from System.Attribute, and be able to be applied to any type.*
- [**CS9327**](#feature-not-available-in-language-version): *Feature is not available in C# 14.0. Please use language version 'version' or greater.*
- [**CS9328**](#target-runtime-doesnt-support-feature): *Method 'method' uses a feature that is not supported by runtime async currently. Opt the method out of runtime async by attributing it with 'System.Runtime.CompilerServices.RuntimeAsyncMethodGenerationAttribute(false)'.*
- [**CS9346**](#target-runtime-doesnt-support-feature): *Update requires emitting explicit interface implementation, which is not supported by the runtime without restarting the application.*
- [**CS9352**](#target-runtime-doesnt-support-feature): *The target runtime does not support extended layout types.*

The cause behind all these errors and warnings is that either the compiler or the runtime doesn't support a feature you're using. The resolution depends on whether the issue is a language version configuration problem, a language version mismatch, a runtime limitation, or an experimental feature.

## Language version configuration errors

- **CS1617**: *Invalid option 'option' for /langversion. Use '/langversion:?' to list supported values.*
- **CS1638**: *'identifier' is a reserved identifier and cannot be used when ISO language version mode is used*
- **CS8192**: *Provided language version is unsupported or invalid: 'value'.*
- **CS8303**: *Specified language version 'value' cannot have leading zeroes*
- **CS8304**: *Compiler version: 'version'. Language version: version.*

These errors indicate that the `<LangVersion>` setting in your project file or the `-langversion` compiler option is invalid or incompatible with the installed compiler.

Correct the `<LangVersion>` value in your project file to a valid language version string (**CS1617**, **CS8192**, **CS8303**). The valid values include `default`, `latest`, `preview`, `latestMajor`, or a specific version number such as `7.3`, `8.0`, `9.0`, `10`, `11`, `12`, `13`, or `14`. Don't include leading zeroes in the version number. See [C# language versioning](../language-versioning.md) for the full list of supported values.

> [!TIP]
> To see a list of supported language versions, you reference the table in this article, compile with `-langversion:?`, or temporarily set `<LangVersion>?</LangVersion>` in your project file before building.

Update the .NET SDK to a version whose compiler supports the language version you specified (**CS8304**). Each version of the C# compiler supports language versions up to a specific maximum. If you specify a language version newer than the compiler supports, upgrade the SDK.

Remove double-underscore identifiers or change the language version from `ISO-1` or `ISO-2` to a newer version (**CS1638**). The ISO language modes reserve identifiers containing `__` (double underscores) because they're not compliant with the ISO C# specification.

> [!NOTE]
> The current C# compiler no longer produces **CS1638**. Older compilers emitted this error when using the `ISO-1` or `ISO-2` language versions.

The compiler determines its default language version from the target framework:

[!INCLUDE [langversion-table](../includes/default-langversion-table.md)]

If you remove the `LangVersion` element from your project file, the compiler uses the default for your target framework. You can also specify a specific version to enable newer features:

[!INCLUDE [langversion-table](../includes/langversion-table.md)]

To learn more about the language versions supported for each framework version, see [Configure language version](../configure-language-version.md) in the language reference section.

## Feature not available in language version

- **CS1738**: *Named argument specifications must appear after all fixed arguments have been specified.*
- **CS8022, CS8023, CS8024, CS8025, CS8026, CS8059, CS8107, CS8302, CS8320, CS8370, CS8400, CS8773, CS8936, CS9058, CS9202, CS9260, CS9327**: *Feature is not available in C# X. Please use language version Y or greater.*
- **CS8306**: *Tuple element name is inferred. Please use language version 7.1 or greater to access an element by its inferred name.*
- **CS8314**: *An expression of type 'type' cannot be handled by a pattern of type 'type' in C# version. Please use language version 'version' or greater.*
- **CS8371**: *Field-targeted attributes on auto-properties are not supported in language version 7.3.*
- **CS8401**: *To use '@$' instead of '$@' for an interpolated verbatim string, please use language version 8.0 or greater.*
- **CS8511**: *An expression of type 'type' cannot be handled by a pattern of type 'type'. Please use language version 'version' or greater to match an open type with a constant pattern.*
- **CS8627**: *A nullable type parameter must be known to be a value type or non-nullable reference type unless language version 'version' or greater is used. Consider changing the language version or adding a 'class', 'struct', or type constraint.*
- **CS8630**: *Invalid 'option' value: 'value' for C# version. Please use language version 'version' or greater.*
- **CS8703**: *The modifier 'modifier' is not valid for this item in C# version.*
- **CS8704**: *'type' does not implement interface member 'member'. 'type' cannot implicitly implement a non-public member.*
- **CS8706**: *Type cannot implement interface member because feature is not available in this version.*
- **CS8904**: *Invalid variance: The type parameter must be invariantly valid on 'member' unless language version 9.0 or greater is used.*
- **CS8912**: *Inheriting from a record with a sealed 'Object.ToString' is not supported in C# 9.0.*
- **CS8957**: *Conditional expression is not valid in language version 8.0 because a common type was not found between types.*
- **CS8967**: *Newlines inside a non-verbatim interpolated string are not supported in C# 10.0.*
- **CS9194**: *Argument may not be passed with the 'ref' keyword. To pass 'ref' arguments to 'in' parameters, upgrade to language version 12 or greater.*

These errors all indicate that you're using a language feature that requires a newer C# version than your project currently targets. To resolve these errors, use one of the following options:

Upgrade the target framework so the compiler automatically selects the required language version. Each target framework maps to a default C# version. For example, .NET 8 defaults to C# 12, .NET 9 defaults to C# 13, and .NET 10 defaults to C# 14. See the table in [Language version configuration errors](#language-version-configuration-errors) for the full mapping.

Set the `<LangVersion>` element in your project file to the required version or higher. For example, to enable C# 12 features, add `<LangVersion>12</LangVersion>` to a `<PropertyGroup>` in your project file.

If you can't upgrade, avoid the feature that triggered the error. The error message names the feature and the required version. The following list provides additional context for specific errors:

- Use explicitly named arguments for all arguments, or upgrade to C# 7.2 or later to use non-trailing named arguments (**CS1738**).
- Access tuple elements by their declared name rather than the inferred name, or upgrade to C# 7.1 or later (**CS8306**).
- Use `$@"..."` instead of `@$"..."` for interpolated verbatim strings in C# versions before 8.0 (**CS8401**).
- Add explicit type constraints to nullable type parameters, or upgrade to C# 9 or later which relaxes this requirement (**CS8627**).
- Upgrade to C# 8.0 or later to enable nullable annotations and the nullable context (**CS8630**).
- Add explicit casts in conditional expressions where the two branches have no common type, or upgrade to C# 9 or later for target-typed conditional expressions (**CS8957**).
- Move newlines outside of interpolated string expressions, or upgrade to C# 11 or later (**CS8967**).
- Use the `in` keyword instead of `ref` when passing arguments to `in` parameters, or upgrade to C# 12 or later (**CS9194**).
- Implement non-public interface members explicitly rather than implicitly, or upgrade to C# 9 or later (**CS8704**).

## Target runtime doesn't support feature

- **CS8021**: *No value for RuntimeMetadataVersion found.*
- **CS8701**: *Target runtime doesn't support default interface implementation.*
- **CS8702**: *'member' cannot implement interface member in type because the target runtime doesn't support default interface implementation.*
- **CS8707**: *Target runtime doesn't support 'protected', 'protected internal', or 'private protected' accessibility for a member of an interface.*
- **CS8830**: *Target runtime doesn't support covariant return types in overrides.*
- **CS8831**: *Target runtime doesn't support covariant types in overrides.*
- **CS8889**: *The target runtime doesn't support extensible or runtime-environment default calling conventions.*
- **CS8919**: *Target runtime doesn't support static abstract members in interfaces.*
- **CS8929**: *'method' cannot implement interface member 'member' in type 'type' because the target runtime doesn't support static abstract members in interfaces.*
- **CS9041**: *'type' requires compiler feature 'feature', which is not supported by this version of the C# compiler.*
- **CS9064**: *Target runtime doesn't support ref fields.*
- **CS9103**: *'type' is defined in a module with an unrecognized RefSafetyRulesAttribute version, expecting '11'.*
- **CS9171**: *Target runtime doesn't support inline array types.*
- **CS9240**: *Target runtime doesn't support by-ref-like generics.*
- **CS9328**: *Method 'method' uses a feature that is not supported by runtime async currently. Opt the method out of runtime async by attributing it with 'System.Runtime.CompilerServices.RuntimeAsyncMethodGenerationAttribute(false)'.*
- **CS9346**: *Update requires emitting explicit interface implementation, which is not supported by the runtime without restarting the application.*
- **CS9352**: *The target runtime does not support extended layout types.*

These errors differ from language version errors because upgrading the `<LangVersion>` alone doesn't resolve them. The target runtime (specified by `<TargetFramework>`) must also support the feature at the CLR/runtime level.

Upgrade the `<TargetFramework>` in your project file to a version that supports the required feature. The following list shows which features require which minimum runtime:

- Default interface implementation, including protected access (**CS8701**, **CS8702**, **CS8707**): Requires .NET Core 3.0 / .NET 5+.
- Static abstract members in interfaces (**CS8919**, **CS8929**): Requires .NET 7+.
- Covariant return types (**CS8830**, **CS8831**): Requires .NET 5+.
- Ref fields (**CS9064**): Requires .NET 7+.
- Inline array types (**CS9171**): Requires .NET 8+.
- By-ref-like generics (**CS9240**): Requires .NET 9+.
- Extended layout types (**CS9352**): Requires .NET 10+.
- Extensible calling conventions (**CS8889**): Requires .NET 5+.
- Runtime async features (**CS9328**): Requires .NET 10+.

Update the .NET SDK if the compiler itself doesn't support a required compiler feature (**CS9041**). This error indicates that a referenced library uses metadata features that require a newer compiler version.

Ensure a valid reference to the core runtime library exists (**CS8021**). This warning typically appears when building without a standard runtime reference. Specify a `RuntimeMetadataVersion` option or add a reference to an assembly containing `System.Object`.

Resolve `RefSafetyRulesAttribute` version mismatches by recompiling dependent modules with a compatible compiler version (**CS9103**).

Restart the application if you encounter this error during hot reload (**CS9346**). Some edit-and-continue changes require restarting because the runtime can't emit the required explicit interface implementations dynamically.

## Function pointer and calling convention errors

- **CS8888**: *'managed' calling convention cannot be combined with unmanaged calling convention specifiers.*
- **CS8889**: *The target runtime doesn't support extensible or runtime-environment default calling conventions.*
- **CS8890**: *Type 'type' is not defined.*
- **CS8891**: *Type 'type' must be public to be used as a calling convention.*

These errors relate to [function pointer](../unsafe-code.md#function-pointers) declarations and their calling convention specifiers, introduced in C# 9.

Remove `managed` from calling convention specifier lists that also include unmanaged specifiers (**CS8888**). The `managed` calling convention is the default and can't be combined with `unmanaged` specifiers such as `Cdecl`, `Stdcall`, `Thiscall`, or `Fastcall`.

Upgrade the target framework to .NET 5 or later to use extensible or runtime-default calling conventions (**CS8889**). The `UnmanagedCallersOnly` attribute and extensible calling convention types require runtime support that isn't available in .NET Core 3.1 or earlier.

Ensure the calling convention type exists in the referenced assemblies (**CS8890**). Calling convention types such as `CallConvCdecl`, `CallConvStdcall`, `CallConvThiscall`, and `CallConvFastcall` are defined in `System.Runtime.CompilerServices`. If the type isn't found, add a reference to the correct runtime library.

Make custom calling convention types `public` (**CS8891**). If you define a custom calling convention type, declare it as `public` to use it in a function pointer type declaration.

## Experimental and preview features

- **CS8058**: *Feature 'feature' is experimental and unsupported; use '/features:feature' to enable.*
- **CS8305**: *'type' is for evaluation purposes only and is subject to change or removal in future updates.*
- **CS8652**: *The feature is currently in Preview and unsupported. To use Preview features, use the 'preview' language version.*
- **CS9204**: *'type' is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.*
- **CS9211**: *The diagnosticId argument to the 'Experimental' attribute must be a valid identifier.*
- **CS9268**: *'type' is for evaluation purposes only and is subject to change or removal in future updates: 'message'. Suppress this diagnostic to proceed.*

These diagnostics indicate that you're using a feature or type that's marked as experimental or is only available in the preview language version.

> [!WARNING]
> Experimental features are subject to change. The APIs might change, or they might be removed in future updates. Including experimental features is a way for library authors to get feedback on ideas and concepts for future development. Use extreme caution when using any feature marked as experimental.

Set `<LangVersion>preview</LangVersion>` in your project file to use preview language features (**CS8652**). Preview features aren't yet finalized and might change in future releases.

Suppress the specific diagnostic ID to acknowledge the experimental nature of the API (**CS8058**, **CS8305**, **CS9204**, **CS9268**). Library authors mark APIs with <xref:System.Diagnostics.CodeAnalysis.ExperimentalAttribute?displayProperty=fullName> to indicate they're subject to change. You can suppress the diagnostic by using `#pragma warning disable` or by adding the diagnostic ID to `<NoWarn>` in your project file.

Ensure the `diagnosticId` argument to `[Experimental]` is a valid C# identifier (**CS9211**). The identifier must follow standard naming rules. It can't contain spaces, special characters, or start with a digit. You can also declare your own experimental features by using the <xref:System.Diagnostics.CodeAnalysis.ExperimentalAttribute?displayProperty=fullName>.

## Breaking changes on struct initialization

- **CS0171**, **CS8881**: *Field 'name' must be fully assigned before control is returned to the caller. Consider updating to language version 'version' to auto-default the field.*
- **CS0188**, **CS8885**: *The 'this' object cannot be used before all of its fields have been assigned. Consider updating to language version 'version' to auto-default the unassigned fields.*
- **CS0843**, **CS8880**: *Auto-implemented property 'name' must be fully assigned before control is returned to the caller. Consider updating to language version 'version' to auto-default the property.*
- **CS9014**: *Use of possibly unassigned auto-implemented property 'name'. Consider updating to language version 'version' to auto-default the property.*
- **CS9015**: *Use of possibly unassigned field 'name'. Consider updating to language version 'version' to auto-default the field.*
- **CS9016**: *Use of possibly unassigned auto-implemented property 'name'. Consider updating to language version 'version' to auto-default the property.*
- **CS9017**: *Use of possibly unassigned field 'name'. Consider updating to language version 'version' to auto-default the field.*

These errors and warnings help ensure that `struct` types are properly initialized before their fields are accessed. In earlier versions of C#, you must explicitly assign all fields in a struct in any constructor. The parameterless constructor initializes all fields to their default value. In later versions, all constructors initialize all fields. Either the field is explicitly set, set in a field initializer, or set to its default value.

Upgrade to C# 11 or later so that all `struct` constructors auto-default all fields (**CS0171**, **CS0188**, **CS0843**, and their newer counterparts **CS8880**, **CS8881**, **CS8885**). Starting in C# 11, the compiler automatically initializes any fields not explicitly set in a constructor to their default values.

Explicitly call the default constructor by using `: this()` in your struct constructor if you can't upgrade to C# 11 (**CS0171**, **CS0188**, **CS0843**). This approach ensures all fields receive their default values before your constructor body runs:

```csharp
struct S
{
    public int AIProp { get; set; }
    public S(int i) : this() // Ensures all fields are initialized
    {
        AIProp = i;
    }
}
```

Assign all fields and auto-properties before using `this` or before the constructor returns (**CS9014**, **CS9015**, **CS9016**, **CS9017**). These diagnostics appear when a newer compiler detects that you might be reading a property or field before it has been assigned. Either explicitly assign a value or upgrade to a version where auto-defaulting eliminates the warning.

## Implementation-specific attributes

- **CS9269**: *UnscopedRefAttribute is only valid in C# 11 or later or when targeting net7.0 or later.*
- **CS9271**: *The type 'Microsoft.CodeAnalysis.EmbeddedAttribute' must be non-generic, internal, non-file, sealed, non-static, have a parameterless constructor, inherit from System.Attribute, and be able to be applied to any type.*

These errors relate to attributes that are either compiler-generated or tied to specific runtime versions.

Upgrade to C# 11 and .NET 7 or later to use `UnscopedRefAttribute` (**CS9269**). This attribute indicates that a `ref` return or `ref struct` parameter doesn't have a scoped lifetime. It requires both the language version and the target framework to meet the minimum requirements.

Don't manually declare `Microsoft.CodeAnalysis.EmbeddedAttribute` (**CS9271**). The compiler generates the source for this attribute automatically when needed. If you have a manually declared type with this name, remove it or rename it to avoid conflicting with the compiler-generated version.

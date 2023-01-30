---
title: Resolve errors related to language version and features
description: Several compiler errors indicate that your configured language version doesn't support a feature you're using. This article shows how to fix those errors and warnings.
f1_keywords:
  - "CS0171"
  - "CS0188"
  - "CS0843"
  - "CS8904" # ERR_UnexpectedVarianceStaticMember  Invalid variance: The type parameter '{1}' must be {3} valid on '{0}' unless language version '{4}' or greater is used. '{1}' is {2}.
  - "CS1738" # ERR_NamedArgumentSpecificationBeforeFixedArgument  Named argument specifications must appear after all fixed arguments have been specified. Please use language version {0} or greater to allow non-trailing named arguments
  - "CS8022" # ERR_FeatureNotAvailableInVersion1  Feature is not available in C# 1. Please use language version.
  - "CS8023" # ERR_FeatureNotAvailableInVersion2  Feature is not available in C# 2. Please use language version.
  - "CS8024" # ERR_FeatureNotAvailableInVersion3  Feature is not available in C# 3. Please use language version.
  - "CS8025" # ERR_FeatureNotAvailableInVersion4  Feature is not available in C# 4. Please use language version.
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
  - "CS8703" # ERR_InvalidModifierForLanguageVersion  The modifier '{0}' is not valid for this item in C# {1}. Please use language version '{2}' or greater.
  - "CS8704" # ERR_ImplicitImplementationOfNonPublicInterfaceMember  Type does not implement interface member. Type cannot implicitly implement a non-public member in selected version.
  - "CS8706" # ERR_LanguageVersionDoesNotSupportInterfaceImplementationForMember  Type cannot implement interface member '{1}' in type '{2}' because feature '{3}' is not available in 
  - "CS8957" # ERR_NoImplicitConvTargetTypedConditional  Conditional expression is not valid in language version {0} because a common type was not found between '{1}' and '{2}'
  - "CS8912" # ERR_InheritingFromRecordWithSealedToString  Inheriting from a record with a sealed 'Object.ToString' is not supported
  - "CS9014" # ERR_UseDefViolationPropertyUnsupportedVersion  Use of possibly unassigned property
  - "CS9015" # ERR_UseDefViolationFieldUnsupportedVersion  Use of possibly unassigned field
  - "CS9016" # WRN_UseDefViolationPropertyUnsupportedVersion  Use of possibly unassigned property
  - "CS9017" # WRN_UseDefViolationFieldUnsupportedVersion  Use of possibly unassigned field
  - "CS8967" # ERR_NewlinesAreNotAllowedInsideANonVerbatimInterpolatedString  Newlines inside a non-verbatim interpolated string are not supported in C#
helpviewer_keywords:
  - "CS0171"
  - "CS0188"
  - "CS0843"
  - "CS8904"
  - "CS1738"
  - "CS8022"
  - "CS8023"
  - "CS8024"
  - "CS8025"
  - "CS8026"
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
  - "CS8703"
  - "CS8704"
  - "CS8706"
  - "CS8957"
  - "CS8912"
  - "CS9014"
  - "CS9015"
  - "CS9016"
  - "CS9017"
  - "CS8967"
ms.date: 01/30/2023
---
# Resolve warnings related to language features and versions

This article covers the following compiler warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's be design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- **CS8022, CS8023, CS8024, CS8025, CS8026, CS8059, CS8107, CS8302, CS8320, CS8370, CS8400, CS8773, CS8936, CS9058** - *Feature is not available. Use newer language version.*
- **CS8192** - *Provided language version is unsupported or invalid*
- **CS8303** - *Specified language version cannot have leading zeroes*
- **CS8304** - *Compiler version is less than language version*
- **CS1738** - *Named argument specifications must appear after all fixed arguments have been specified.*
- **CS8306** - *Tuple element name is inferred.*
- **CS8314** - *An expression of type cannot be handled by a pattern of type*
- **CS8371** - *Field-targeted attributes on auto-properties are not supported in language version*
- **CS8401** - *To use `@$` instead of `$@` for an interpolated verbatim string, use newer language version.*
- **CS8511** - *An expression of type cannot be handled by a pattern of type.*
- **CS8627** - *A nullable type parameter must be known to be a value type or non-nullable reference type*
- **CS8630** - *Invalid nullable options. Use newer language version*
- **CS8652** - *The modifier is not valid for this item.*
- **CS8704** - *Type does not implement interface member. It cannot implicitly implement a non-public member.*
- **CS8706** - *Type cannot implement interface member because a feature is not available in this version.*
- **CS8904** - *Invalid variance: The type parameter must be valid.*
- **CS8912** - *Inheriting from a record with a sealed 'Object.ToString' is not supported.*
- **CS8957** - *Conditional expression is not valid in language version because a common type was not found between types.*
- **CS8967** - *Newlines inside a non-verbatim interpolated string are not supported in C#*
- **CS9014** - *Error: Use of possibly unassigned property. Upgrade to auto-default the property.*
- **CS9015** - *Error: Use of possibly unassigned field. Upgrade to auto-default the field.*
- **CS9016** - *Warning: Use of possibly unassigned property. Upgrade to auto-default the property.*
- **CS9017** - *Warning: Use of possibly unassigned field. Upgrade to auto-default the field.*

In addition, the following errors and warnings relate to struct initialization changes in recent versions:

- [**CS0171**, **CS8881**](#breaking-changes-on-struct-initialization): *Backing field for automatically implemented property 'name' must be fully assigned before control is returned to the caller.*
- [**CS0188**, **CS8885**](#breaking-changes-on-struct-initialization): *The 'this' object cannot be used before all of its fields are assigned to*
- [**CS0843**, **CS8880**](#breaking-changes-on-struct-initialization): *Backing field for automatically implemented property 'name' must be fully assigned before control is returned to the caller*

The cause behind all these errors and warnings is that the compiler installed supports a newer version of C# than the version your project has selected. The C# compiler can conform to any previous version. You can validate syntax against an earlier version of C#, or because your project must support older libraries or runtimes.

There are two possible causes and three ways to address these errors and warnings.

## Update your target framework

The compiler determines a default based on these rules:

[!INCLUDE [langversion-table](../includes/default-langversion-table.md)]

If your selected framework doesn't match the language version required, you can upgrade the target framework.

## Select the matching language version

You may have an older target framework selected in your project file. If you remove the `LangVersion` element from your project file, the compiler will use the default value listed in the preceding section. The following table shows all current C# language versions. You can also specify a specific language version to enable newer features.

[!INCLUDE [langversion-table](../includes/langversion-table.md)]

You can learn more about the language versions supported for each framework version in the article on [Configure langage version](../configure-language-version.md) in the language reference section.

## Avoid the updated feature

If you must support older libraries or runtimes, you may need to avoid using newer features.

## Breaking changes on struct initialization

All these errors and warnings help ensure that `struct` types are properly initialized before their fields are accessed. In earlier versions of C#, you must explicitly assign all fields in a struct in any constructor. The parameterless constructor initializes all fields to their default value. In later versions, all constructors initialize all fields. Either the field is explicitly set, set in a field initializer, or set to its default value.

- **CS0171**, **CS8881**: *Backing field for automatically implemented property 'name' must be fully assigned before control is returned to the caller.*
- **CS0188**, **CS8885**: *The 'this' object cannot be used before all of its fields are assigned to*
- **CS0843**, **CS8880**: *Backing field for automatically implemented property 'name' must be fully assigned before control is returned to the caller*

You can address this error by upgrading your language version to C# 11, when all fields are initialized by every `struct` constructor. If that's not a possible option, you must explicitly call the default constructor, as shown in the following example:

```csharp
struct S
{
    public int AIProp { get; set; }
    public S(int i){} //CS0843
    // Try the following lines instead.
    // public S(int i) : this()
    // {
    //     AIProp = i;
    // }
}

class Test
{
    static int Main()
    {
        return 1;
    }
}
```

---
title: Resolve errors and warnings that involve attribute declaration and attribute use in your code.
description: These compiler errors and warnings indicate errors in attribute declarations, or attribute use in your code.
f1_keywords:
  - "CS0181"
  - "CS0243"
  - "CS0404"
  - "CS0415"
  - "CS0416"
  - "CS0447"
  - "CS0577"
  - "CS0578"
  - "CS0579"
  - "CS0582"
  - "CS0592"
  - "CS0609"
  - "CS0616"
  - "CS0625"
  - "CS0629"
  - "CS0636"
  - "CS0637"
  - "CS0641"
  - "CS0646"
  - "CS0647"
  - "CS0653"
  - "CS0657"
  - "CS0658"
  - "CS0668"
  - "CS0685"
  - "CS0735"
  - "CS0739"
  - "CS1608"
  - "CS1614"
  - "CS1618"
  - "CS1667"
  - "CS1689"
  - "CS7014"
  - "CS7046"
  - "CS7047"
  - "CS7067"
  - "CS8959"
  - "CS8960"
  - "CS8961"
  - "CS8962"
  - "CS8963"
  - "CS8968"
  - "CS8970"
  - "CS9331"
helpviewer_keywords:
  - "CS0181"
  - "CS0243"
  - "CS0404"
  - "CS0415"
  - "CS0416"
  - "CS0447"
  - "CS0577"
  - "CS0578"
  - "CS0579"
  - "CS0582"
  - "CS0592"
  - "CS0609"
  - "CS0616"
  - "CS0625"
  - "CS0629"
  - "CS0636"
  - "CS0637"
  - "CS0641"
  - "CS0646"
  - "CS0647"
  - "CS0653"
  - "CS0657"
  - "CS0658"
  - "CS0668"
  - "CS0685"
  - "CS0735"
  - "CS0739"
  - "CS1608"
  - "CS1614"
  - "CS1618"
  - "CS1667"
  - "CS1689"
  - "CS7014"
  - "CS7046"
  - "CS7047"
  - "CS7067"
  - "CS8959"
  - "CS8960"
  - "CS8961"
  - "CS8962"
  - "CS8963"
  - "CS8968"
  - "CS8970"
  - "CS9331"
ms.date: 02/13/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings related to attribute declarations or attribute use in your code

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0181**](#attribute-arguments-and-parameters): *Attribute constructor parameter has a type, which is not a valid attribute parameter type*
- [**CS0243**](#conditional-attribute-usage): *The Conditional attribute is not valid on 'method' because it is an override method.*
- [**CS0404**](#attribute-class-requirements): *Attribute is not valid on this declaration type.*
- [**CS0415**](#predefined-attributes): *This attribute is valid only on an indexer that is not an explicit interface member declaration.*
- [**CS0416**](#attribute-arguments-and-parameters): *'type parameter': an attribute argument cannot use type parameters.*
- [**CS0447**](#attribute-arguments-and-parameters): *Attribute cannot be used with type arguments.*
- [**CS0577**](#conditional-attribute-usage): *The Conditional attribute is not valid because it is a constructor, destructor, operator, lambda expression, or explicit interface implementation.*
- [**CS0578**](#conditional-attribute-usage): *The Conditional attribute is not valid on 'function' because its return type is not void.*
- [**CS0579**](#attribute-class-requirements): *Duplicate attribute*
- [**CS0582**](#conditional-attribute-usage): *The Conditional attribute is not valid on interface members.*
- [**CS0592**](#attribute-location-context): *Attribute is not valid on this declaration type. It is only valid on specific declarations.*
- [**CS0609**](#predefined-attributes): *Cannot set the attribute on an indexer marked override.*
- [**CS0616**](#attribute-class-requirements): *Type is not an attribute class*
- [**CS0625**](#predefined-attributes): *Instance field in types marked with StructLayout(LayoutKind.Explicit) must have a FieldOffset attribute.*
- [**CS0629**](#conditional-attribute-usage): *Conditional member 'member' cannot implement interface member 'base class member' in type 'Type Name'.*
- [**CS0636**](#predefined-attributes): *The FieldOffset attribute can only be placed on members of types marked with the StructLayout(LayoutKind.Explicit).*
- [**CS0637**](#predefined-attributes): *The FieldOffset attribute is not allowed on static or const fields.*
- [**CS0641**](#attribute-class-requirements): *This attribute is only valid on classes derived from System.Attribute`.*
- [**CS0646**](#predefined-attributes): *Cannot specify the DefaultMember attribute on a type containing an indexer.*
- [**CS0647**](#attribute-arguments-and-parameters): *Error emitting attribute*
- [**CS0653**](#attribute-class-requirements): *Cannot apply attribute class 'class' because it is abstract.*
- [**CS0657**](#attribute-location-context): *Location is not a valid attribute location for this declaration. Valid attribute locations for this declaration are listed. All attributes in this block will be ignored.*
- [**CS0658**](#attribute-location-context): *Location is not a recognized attribute location. Valid attribute locations for this declaration are listed. All attributes in this block will be ignored.*
- [**CS0668**](#predefined-attributes): *Two indexers have different names; the IndexerName attribute must be used with the same name on every indexer within a type*
- [**CS0685**](#conditional-attribute-usage): *Conditional member 'member' cannot have an out parameter.*
- [**CS0735**](#predefined-attributes): *Invalid type specified as an argument for TypeForwardedTo attribute*
- [**CS0739**](#predefined-attributes): *Duplicate TypeForwardedToAttribute*
- [**CS1608**](#predefined-attributes): *The RequiredAttribute attribute is not permitted on C# types*
- [**CS1614**](#attribute-class-requirements): *Attribute name is ambiguous. Either use '@name' or explicitly include the 'Attribute' suffix.*
- [**CS1618**](#conditional-attribute-usage): *Cannot create delegate with method because it or a method it overrides has a Conditional attribute*
- [**CS1667**](#attribute-location-context): *Attribute is not valid on property or event accessors. It is only valid on specific declarations.*
- [**CS1689**](#conditional-attribute-usage): *Attribute is only valid on methods or attribute classes*
- [**CS7014**](#attribute-location-context): *Attributes are not valid in this context.*
- [**CS7046**](#attribute-arguments-and-parameters): *Attribute parameter must be specified.*
- [**CS7047**](#attribute-arguments-and-parameters): *Attribute parameter 'parameter1' or 'parameter2' must be specified.*
- [**CS7067**](#attribute-arguments-and-parameters): *Attribute constructor parameter is optional, but no default parameter value was specified.*
- [**CS8959**](#callerargumentexpression-attribute-usage): *CallerArgumentExpressionAttribute cannot be applied because there are no standard conversions from type1 to type2*
- [**CS8960**](#callerargumentexpression-attribute-usage): *The CallerArgumentExpressionAttribute applied to parameter will have no effect. It is overridden by the CallerLineNumberAttribute.*
- [**CS8961**](#callerargumentexpression-attribute-usage): *The CallerArgumentExpressionAttribute applied to parameter will have no effect. It is overridden by the CallerFilePathAttribute.*
- [**CS8962**](#callerargumentexpression-attribute-usage): *The CallerArgumentExpressionAttribute applied to parameter will have no effect. It is overridden by the CallerMemberNameAttribute.*
- [**CS8963**](#callerargumentexpression-attribute-usage): *The CallerArgumentExpressionAttribute applied to parameter will have no effect. It is applied with an invalid parameter name.*
- [**CS8968**](#attribute-arguments-and-parameters): *An attribute type argument cannot use type parameters*
- [**CS8970**](#attribute-arguments-and-parameters): *Type cannot be used in this context because it cannot be represented in metadata.*
- [**CS9331**](#predefined-attributes): *Attribute cannot be applied manually.*

## Attribute arguments and parameters

The following errors occur when you use attribute arguments or parameters incorrectly:

- **CS0181**: *Attribute constructor parameter has a type, which is not a valid attribute parameter type*
- **CS0416**: *'type parameter': an attribute argument cannot use type parameters.*
- **CS0447**: *Attribute cannot be used with type arguments.*
- **CS0647**: *Error emitting attribute*
- **CS7046**: *Attribute parameter must be specified.*
- **CS7047**: *Attribute parameter 'parameter1' or 'parameter2' must be specified.*
- **CS7067**: *Attribute constructor parameter is optional, but no default parameter value was specified.*
- **CS8968**: *An attribute type argument cannot use type parameters*
- **CS8970**: *Type cannot be used in this context because it cannot be represented in metadata.*

To correct these errors, follow these rules.

- Use only valid attribute parameter types (**CS0181**). Valid types include primitive types (`bool`, `byte`, `char`, `double`, `float`, `int`, `long`, `short`, `string`), `object`, `System.Type`, enum types, and single-dimensional arrays of these types. Function pointers and other non-metadata types aren't valid attribute parameter types.
- Use compile-time constant values for attribute arguments instead of type parameters (**CS0416**). Attribute arguments must be evaluated at compile time.
- Don't use type arguments with attributes (**CS0447**). Type arguments aren't allowed in attribute usage.
- Ensure attribute arguments are valid for the attribute type (**CS0647**). Check that values passed to the attribute constructor are correctly formatted and within the valid range for each parameter.
- Provide all required attribute parameters when you apply the attribute (**CS7046**, **CS7047**). Check the attribute's constructor to see which parameters are mandatory.
- Specify default values for optional constructor parameters when you define custom attributes (**CS7067**). Use the syntax `parameterType parameterName = defaultValue` in the attribute constructor.
- Use concrete types instead of type parameters as generic attribute type arguments (**CS8968**). Generic attributes require type arguments that are fully determined at compile time.
- Ensure types used in attribute arguments can be represented in metadata (**CS8970**). Some constructed types, such as those involving `dynamic` or certain tuple element names, can't be encoded in metadata and aren't permitted as attribute type arguments.

For more information, see [Attributes](../../advanced-topics/reflection-and-attributes/index.md) and [Generics](../../fundamentals/types/generics.md).

> [!NOTE]
> **CS0447** and **CS0647** are no longer used in Roslyn.

## Attribute class requirements

The following errors occur when you define attribute classes that don't meet the required constraints:

- **CS0404**: *Attribute is not valid on this declaration type.*
- **CS0579**: *Duplicate attribute*
- **CS0616**: *Type is not an attribute class*
- **CS0641**: *This attribute is only valid on classes derived from System.Attribute`.*
- **CS0653**: *Cannot apply attribute class 'class' because it is abstract.*
- **CS1614**: *Attribute name is ambiguous. Either use '@name' or explicitly include the 'Attribute' suffix.*

To correct these errors, follow these rules.

- Apply attributes only to valid declaration types (**CS0404**). Check the attribute's `AttributeUsage` to see which targets are allowed.
- Either remove the duplicate attribute, or set `AllowMultiple = true` in the attribute's <xref:System.AttributeUsageAttribute> (**CS0579**). By default, attributes can only be applied once to a single target.
- Ensure the type used as an attribute inherits from <xref:System.Attribute?displayProperty=nameWithType> (**CS0616**). Only classes derived from `System.Attribute` can be used in attribute syntax.
- Apply <xref:System.AttributeUsageAttribute> only to classes that derive from `Attribute` (**CS0641**). This attribute controls how other attributes are used.
- Remove the `abstract` modifier from attribute classes, or derive from a non-abstract attribute class (**CS0653**). Attributes must be instantiable.
- Disambiguate attribute names by using `@name` to refer to the shorter class name, or by specifying the full name with the `Attribute` suffix (**CS1614**). This ambiguity arises when both `Example` and `ExampleAttribute` classes exist.

For more information, see [Create custom attributes](../../advanced-topics/reflection-and-attributes/creating-custom-attributes.md).

## Attribute location context

The following errors occur when you apply attributes in invalid locations or with incorrect target specifiers:

- **CS0592**: *Attribute is not valid on this declaration type. It is only valid on specific declarations.*
- **CS0657**: *Location is not a valid attribute location for this declaration. Valid attribute locations for this declaration are listed. All attributes in this block will be ignored.*
- **CS0658**: *Location is not a recognized attribute location. Valid attribute locations for this declaration are listed. All attributes in this block will be ignored.*
- **CS1667**: *Attribute is not valid on property or event accessors. It is only valid on specific declarations.*
- **CS7014**: *Attributes are not valid in this context.*

To correct these errors, follow these rules. For more information, see [Attribute Targets](../../advanced-topics/reflection-and-attributes/index.md#attribute-targets).

- Check the attribute's <xref:System.AttributeUsageAttribute> to see which declaration types it targets, and apply it only to those types (**CS0592**). For example, an attribute targeting `AttributeTargets.Interface` can't be applied to a class.
- Use valid attribute target specifiers for the declaration (**CS0657**). Check the error message to see which targets are valid for the specific declaration.
- Remove invalid attribute target specifiers (**CS0658**). Valid specifiers include `assembly:`, `module:`, `type:`, `method:`, `property:`, `field:`, `event:`, `param:`, and `return:`.
- Move attributes from property or event accessors to the property or event declaration itself (**CS1667**). Some attributes, such as <xref:System.ObsoleteAttribute> and <xref:System.CLSCompliantAttribute>, aren't valid on accessors.
- Move attributes to valid contexts (**CS7014**). Attributes can only be applied to program elements that support them, as defined by <xref:System.AttributeUsageAttribute>.
- Apply attributes at the appropriate scope level. Use `assembly:` or `module:` prefixes for assembly-level or module-level attributes.

## Predefined attributes

The following errors occur when you use specific predefined .NET attributes incorrectly:

- **CS0415**: *This attribute is valid only on an indexer that is not an explicit interface member declaration.*
- **CS0609**: *Cannot set the attribute on an indexer marked override.*
- **CS0625**: *Instance field in types marked with StructLayout(LayoutKind.Explicit) must have a FieldOffset attribute.*
- **CS0636**: *The FieldOffset attribute can only be placed on members of types marked with the StructLayout(LayoutKind.Explicit).*
- **CS0637**: *The FieldOffset attribute is not allowed on static or const fields.*
- **CS0646**: *Cannot specify the DefaultMember attribute on a type containing an indexer.*
- **CS0668**: *Two indexers have different names; the IndexerName attribute must be used with the same name on every indexer within a type*
- **CS0735**: *Invalid type specified as an argument for TypeForwardedTo attribute*
- **CS0739**: *Duplicate TypeForwardedToAttribute*
- **CS1608**: *The RequiredAttribute attribute is not permitted on C# types*
- **CS9331**: *Attribute cannot be applied manually.*

To correct these errors, follow these rules. For more information, see [Indexers](../../programming-guide/indexers/index.md) and [Platform Invoke (P/Invoke)](../../../standard/native-interop/pinvoke.md).

- Remove <xref:System.Runtime.CompilerServices.IndexerNameAttribute> from explicit interface implementations (**CS0415**). Apply it only to public indexers.
- Remove `IndexerName` from indexers marked with `override` (**CS0609**). Override indexers inherit the name from the base class.
- Add <xref:System.Runtime.InteropServices.FieldOffsetAttribute> to all instance fields in types with <xref:System.Runtime.InteropServices.StructLayoutAttribute> set to `LayoutKind.Explicit` (**CS0625**). Explicit layout requires explicit field positions.
- Apply `FieldOffset` only to types with `StructLayout(LayoutKind.Explicit)` (**CS0636**). Add the `StructLayout` attribute to the type declaration.
- Remove `FieldOffset` from `static` or `const` fields (**CS0637**). Explicit layout applies only to instance fields.
- Remove <xref:System.Reflection.DefaultMemberAttribute> from types that contain indexers (**CS0646**). Indexers automatically define the default member.
- Use the same name in all <xref:System.Runtime.CompilerServices.IndexerNameAttribute> attributes within a type (**CS0668**). All indexers in a type must share the same `IndexerName` value.
- Use only valid types as arguments for <xref:System.Runtime.CompilerServices.TypeForwardedToAttribute> (**CS0735**). Non-generic, non-nested, non-pointer, and non-array types are the only valid forwarding targets.
- Remove duplicate <xref:System.Runtime.CompilerServices.TypeForwardedToAttribute> declarations for the same type (**CS0739**). An assembly can have only one `TypeForwardedTo` for each external type.
- Remove <xref:System.Runtime.CompilerServices.RequiredAttributeAttribute> from C# type definitions (**CS1608**). This attribute is used by other languages and isn't permitted in C#.
- Replace compiler-generated attributes with the equivalent C# syntax (**CS9331**). Use language keywords instead of manually applying reserved attributes.

## Conditional attribute usage

The following errors occur when you apply the <xref:System.Diagnostics.ConditionalAttribute> in ways that violate its usage restrictions:

- **CS0243**: *The Conditional attribute is not valid on 'method' because it is an override method.*
- **CS0577**: *The Conditional attribute is not valid because it is a constructor, destructor, operator, lambda expression, or explicit interface implementation.*
- **CS0578**: *The Conditional attribute is not valid on 'function' because its return type is not void.*
- **CS0582**: *The Conditional attribute is not valid on interface members.*
- **CS0629**: *Conditional member 'member' cannot implement interface member 'base class member' in type 'Type Name'.*
- **CS0685**: *Conditional member 'member' cannot have an out parameter.*
- **CS1618**: *Cannot create delegate with method because it or a method it overrides has a Conditional attribute*
- **CS1689**: *Attribute is only valid on methods or attribute classes*

To correct these errors, follow these rules. For more information, see <xref:System.Diagnostics.ConditionalAttribute> and [Attributes](../../advanced-topics/reflection-and-attributes/index.md).

- Remove the `Conditional` attribute from [override](../keywords/override.md) methods, or remove the `override` keyword (**CS0243**). The compiler binds to the base method, not the override.
- Don't apply `Conditional` to constructors, [finalizers](../../programming-guide/classes-and-structs/finalizers.md), operators, lambda expressions, or explicit interface implementations (**CS0577**). These member types don't support conditional compilation.
- Change the method's return type to `void`, or remove the `Conditional` attribute (**CS0578**). Conditional methods must return `void` because calls may be compiled out.
- Remove the `Conditional` attribute from interface member declarations (**CS0582**). Interface members can't be conditional.
- Remove the `Conditional` attribute from interface member implementations (**CS0629**). Methods implementing interface members can't be conditional.
- Remove `out` parameters from conditional methods, or remove the `Conditional` attribute (**CS0685**). The `out` variable value would be undefined when the method call is compiled out.
- Don't create delegates with conditional methods (**CS1618**). Because conditional methods might not exist in some builds, delegate references to them are invalid. Remove the `Conditional` attribute from the method, or don't use it as a delegate target.
- Apply the `Conditional` attribute only to methods or attribute classes (**CS1689**). The `Conditional` attribute isn't valid on other declaration types such as classes, structs, or interfaces.

## CallerArgumentExpression attribute usage

The following errors occur when you apply <xref:System.Runtime.CompilerServices.CallerArgumentExpressionAttribute> incorrectly or in conflict with other caller info attributes:

- **CS8959**: *CallerArgumentExpressionAttribute cannot be applied because there are no standard conversions from type1 to type 2*
- **CS8960**: *The CallerArgumentExpressionAttribute applied to parameter will have no effect. It is overridden by the CallerLineNumberAttribute.*
- **CS8961**: *The CallerArgumentExpressionAttribute applied to parameter will have no effect. It is overridden by the CallerFilePathAttribute.*
- **CS8962**: *The CallerArgumentExpressionAttribute applied to parameter will have no effect. It is overridden by the CallerMemberNameAttribute.*
- **CS8963**: *The CallerArgumentExpressionAttribute applied to parameter will have no effect. It is applied with an invalid parameter name.*

To correct these errors, follow these rules. For more information, see [Caller information attributes](../../language-reference/attributes/caller-information.md).

- Ensure the parameter type is `string` or has a standard conversion from `string` when applying `CallerArgumentExpression` (**CS8959**). The attribute injects a `string` representation of the caller's argument expression, so the target parameter must be compatible with `string`.
- Remove `CallerArgumentExpression` from parameters that also have <xref:System.Runtime.CompilerServices.CallerLineNumberAttribute>, <xref:System.Runtime.CompilerServices.CallerFilePathAttribute>, or <xref:System.Runtime.CompilerServices.CallerMemberNameAttribute> (**CS8960**, **CS8961**, **CS8962**). These caller info attributes take precedence over `CallerArgumentExpression`, so the `CallerArgumentExpression` attribute has no effect when combined with them.
- Specify a valid parameter name in the `CallerArgumentExpression` constructor (**CS8963**). The string argument must match the name of another parameter in the same method signature.

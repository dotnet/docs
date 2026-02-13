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

You see the following errors when you use attribute arguments or parameters incorrectly:

- **CS0181**: *Attribute constructor parameter has a type, which is not a valid attribute parameter type*
- **CS0416**: *'type parameter': an attribute argument cannot use type parameters.*
- **CS0447**: *Attribute cannot be used with type arguments.*
- **CS0647**: *Error emitting attribute*
- **CS7046**: *Attribute parameter must be specified.*
- **CS7047**: *Attribute parameter 'parameter1' or 'parameter2' must be specified.*
- **CS7067**: *Attribute constructor parameter is optional, but no default parameter value was specified.*
- **CS8968**: *An attribute type argument cannot use type parameters*
- **CS8970**: *Type cannot be used in this context because it cannot be represented in metadata.*

To correct these errors, follow these rules:

- Attribute constructor parameters must use valid attribute parameter types (**CS0181**). The C# language specification restricts attribute parameter types to primitive types (`bool`, `byte`, `char`, `double`, `float`, `int`, `long`, `short`, and `string`), `object`, `System.Type`, enum types, and single-dimensional arrays of these types. Function pointers and other types that can't be represented in metadata aren't valid attribute parameter types.
- Attribute arguments must be compile-time constant values, so you can't use type parameters as attribute arguments (**CS0416**). The compiler must resolve attribute arguments at compile time, and type parameters aren't known until the generic type is constructed.
- You can't apply type arguments to a non-generic attribute (**CS0447**). If an attribute class isn't generic, its usage can't include type arguments in angle brackets.
- All values passed to an attribute constructor must be correctly formatted and within the valid range for each parameter (**CS0647**). For example, a <xref:System.Runtime.InteropServices.GuidAttribute> requires a valid GUID format string.
- You must provide all required attribute parameters when you apply the attribute (**CS7046**, **CS7047**). Check the attribute's constructor signature to determine which parameters are mandatory, and supply valid arguments for each parameter.
- When you define a custom attribute with optional constructor parameters, specify default values for those parameters (**CS7067**). Use the syntax `parameterType parameterName = defaultValue` in the attribute constructor so callers can omit those arguments.
- Generic attribute type arguments must be concrete types, not type parameters (**CS8968**). The compiler must fully determine generic attribute type arguments at compile time, so open type parameters aren't permitted.
- Types used as attribute arguments must be representable in metadata (**CS8970**). Some constructed types, such as those involving `dynamic` or certain tuple element names, can't be encoded in metadata and aren't permitted as attribute type arguments.

For more information, see [Attributes](../../advanced-topics/reflection-and-attributes/index.md), [Generics](../../fundamentals/types/generics.md), and the [C# language specification section on attributes](~/_csharpstandard/standard/attributes.md).

> [!NOTE]
> **CS0447** and **CS0647** are deprecated. The current compiler doesn't emit these errors.

## Attribute class requirements

You see the following errors when you define attribute classes that don't meet the required constraints:

- **CS0404**: *Attribute is not valid on this declaration type.*
- **CS0579**: *Duplicate attribute*
- **CS0616**: *Type is not an attribute class*
- **CS0641**: *This attribute is only valid on classes derived from System.Attribute`.*
- **CS0653**: *Cannot apply attribute class 'class' because it is abstract.*
- **CS1614**: *Attribute name is ambiguous. Either use '@name' or explicitly include the 'Attribute' suffix.*

To correct these errors, follow these rules:

- Apply attributes only to declaration types that the attribute's <xref:System.AttributeUsageAttribute> allows (**CS0404**). Check the `AttributeTargets` value specified in the attribute's `AttributeUsage` to see which targets are valid.
- If you apply the same attribute more than once to a single target, either remove the duplicate or set `AllowMultiple = true` in the attribute's <xref:System.AttributeUsageAttribute> (**CS0579**). By default, attributes can only appear once on each target.
- The type used in attribute syntax must inherit from <xref:System.Attribute?displayProperty=nameWithType> (**CS0616**). Only classes derived from `System.Attribute` can be used as attributes. Other types cause this error even if they have a similar name.
- You can apply <xref:System.AttributeUsageAttribute> only to classes that derive from `Attribute` (**CS0641**). The `AttributeUsage` attribute controls how other attributes are used, and is itself restricted to attribute classes.
- Attribute classes can't be `abstract` because the compiler must instantiate them (**CS0653**). Remove the `abstract` modifier from the attribute class, or derive a concrete class from the abstract base.
- When both `Example` and `ExampleAttribute` attribute classes exist, the compiler can't determine which one `[Example]` refers to (**CS1614**). Disambiguate by using `[@Example]` for the shorter name, or `[ExampleAttribute]` for the longer name.

For more information, see [Create custom attributes](../../advanced-topics/reflection-and-attributes/creating-custom-attributes.md) and the [C# language specification section on attributes](~/_csharpstandard/standard/attributes.md).

## Attribute location context

The following errors occur when you apply attributes in invalid locations or use incorrect target specifiers:

- **CS0592**: *Attribute is not valid on this declaration type. It is only valid on specific declarations.*
- **CS0657**: *Location is not a valid attribute location for this declaration. Valid attribute locations for this declaration are listed. All attributes in this block will be ignored.*
- **CS0658**: *Location is not a recognized attribute location. Valid attribute locations for this declaration are listed. All attributes in this block will be ignored.*
- **CS1667**: *Attribute is not valid on property or event accessors. It is only valid on specific declarations.*
- **CS7014**: *Attributes are not valid in this context.*

To correct these errors, follow these rules. For more information, see [Attribute Targets](../../advanced-topics/reflection-and-attributes/index.md#attribute-targets) and the [C# language specification section on attribute specification](~/_csharpstandard/standard/attributes.md#233-attribute-specification).

- Each attribute's <xref:System.AttributeUsageAttribute> specifies which declaration types it targets. You must apply the attribute only to those types (**CS0592**). For example, you can't apply an attribute defined with `AttributeTargets.Interface` to a class.
- When you use an attribute target specifier such as `method:` or `property:`, the specifier must be valid for the declaration where it appears (**CS0657**). Check the error message to see which target specifiers are allowed for the specific declaration.
- The attribute target specifier you used isn't a recognized specifier (**CS0658**). Valid specifiers include `assembly:`, `module:`, `type:`, `method:`, `property:`, `field:`, `event:`, `param:`, and `return:`.
- Some attributes, such as <xref:System.ObsoleteAttribute> and <xref:System.CLSCompliantAttribute>, aren't valid on property or event accessors (**CS1667**). Move the attribute from the accessor to the property or event declaration itself.
- Attributes can only appear on program elements that support them (**CS7014**). If you're applying assembly-level or module-level attributes, use the `assembly:` or `module:` target specifiers and place them at the top of the file.

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

To correct these errors, follow these rules. For more information, see [Indexers](../../programming-guide/indexers/index.md), [Structure types](../builtin-types/struct.md), <xref:System.Runtime.CompilerServices.TypeForwardedToAttribute>, and [Platform Invoke (P/Invoke)](../../../standard/native-interop/pinvoke.md).

- The <xref:System.Runtime.CompilerServices.IndexerNameAttribute> can only be applied to indexers that aren't explicit interface member declarations (**CS0415**). Remove the attribute from explicit interface indexers, because the interface already defines the indexer name.
- You can't apply `IndexerName` to indexers marked with `override` because override indexers inherit their name from the base class (**CS0609**). Remove the `IndexerName` attribute from the override indexer.
- Every instance field in a type marked with `StructLayout(LayoutKind.Explicit)` must have a <xref:System.Runtime.InteropServices.FieldOffsetAttribute> (**CS0625**). Explicit layout requires that you specify the byte offset for each instance field.
- The <xref:System.Runtime.InteropServices.FieldOffsetAttribute> can only be placed on members of types that have <xref:System.Runtime.InteropServices.StructLayoutAttribute> set to `LayoutKind.Explicit` (**CS0636**). Add the `StructLayout` attribute to the containing type declaration.
- The `FieldOffset` attribute isn't allowed on `static` or `const` fields because explicit layout applies only to instance fields (**CS0637**). Remove the `FieldOffset` attribute from the static or const field.
- You can't apply <xref:System.Reflection.DefaultMemberAttribute> to a type that already contains an indexer because the compiler automatically defines the default member for types with indexers (**CS0646**). Remove the `DefaultMember` attribute.
- All <xref:System.Runtime.CompilerServices.IndexerNameAttribute> attributes within a type must specify the same name (**CS0668**). Change the names to match, because the runtime uses a single name for all indexers on a type.
- The type specified as an argument for <xref:System.Runtime.CompilerServices.TypeForwardedToAttribute> must be a non-generic, non-nested, non-pointer, non-array type (**CS0735**). Only top-level named types are valid forwarding targets.
- An assembly can have only one <xref:System.Runtime.CompilerServices.TypeForwardedToAttribute> for each external type (**CS0739**). Locate and remove the duplicate `TypeForwardedTo` declaration.
- The <xref:System.Runtime.CompilerServices.RequiredAttributeAttribute> isn't permitted on types defined in C# (**CS1608**). This attribute is reserved for other languages that need to force compilers to require a particular feature.
- Some attributes are reserved for the compiler and can't be applied manually in source code (**CS9331**). Replace the attribute with the equivalent C# language syntax that causes the compiler to generate it.

## Conditional attribute usage

You see the following errors when you apply the <xref:System.Diagnostics.ConditionalAttribute> in ways that violate its usage restrictions:

- **CS0243**: *The Conditional attribute is not valid on 'method' because it is an override method.*
- **CS0577**: *The Conditional attribute is not valid because it is a constructor, destructor, operator, lambda expression, or explicit interface implementation.*
- **CS0578**: *The Conditional attribute is not valid on 'function' because its return type is not void.*
- **CS0582**: *The Conditional attribute is not valid on interface members.*
- **CS0629**: *Conditional member 'member' cannot implement interface member 'base class member' in type 'Type Name'.*
- **CS0685**: *Conditional member 'member' cannot have an out parameter.*
- **CS1618**: *Cannot create delegate with method because it or a method it overrides has a Conditional attribute*
- **CS1689**: *Attribute is only valid on methods or attribute classes*

To correct these errors, follow these rules. For more information, see <xref:System.Diagnostics.ConditionalAttribute>, [Conditional methods](~/_csharpstandard/standard/attributes.md#23532-conditional-methods), and [Attributes](../../advanced-topics/reflection-and-attributes/index.md).

- The compiler binds calls to the base method declaration, not the override, so you can't apply the `Conditional` attribute to [override](../keywords/override.md) methods (**CS0243**). Remove the `Conditional` attribute from the override method, or remove the `override` keyword.
- The `Conditional` attribute isn't valid on constructors, [finalizers](../../programming-guide/classes-and-structs/finalizers.md), operators, lambda expressions, or explicit interface implementations (**CS0577**). These member types can't be conditionally omitted because they have required roles in the type's lifecycle or contract.
- Conditional methods must return `void` because the compiler might omit the call entirely, and no return value would be available to the caller (**CS0578**). Change the method's return type to `void`, or remove the `Conditional` attribute.
- Interface members can't be conditional because all interface members must be implemented (**CS0582**). Remove the `Conditional` attribute from the interface member declaration.
- Methods that implement interface members can't be conditional because the interface contract requires them to be present in all builds (**CS0629**). Remove the `Conditional` attribute from the implementing method.
- Conditional methods can't have `out` parameters because the `out` variable value would be undefined when the compiler omits the method call (**CS0685**). Remove the `out` parameters from the method, or remove the `Conditional` attribute.
- You can't create a delegate that references a conditional method because the method might not exist in builds where the condition symbol isn't defined (**CS1618**). Remove the `Conditional` attribute from the method, or don't use it as a delegate target.
- The `Conditional` attribute is only valid on methods and attribute classes (**CS1689**). It isn't valid on other declaration types such as non-attribute classes, structs, or interfaces.

## CallerArgumentExpression attribute usage

The following errors occur when you apply <xref:System.Runtime.CompilerServices.CallerArgumentExpressionAttribute> incorrectly or in conflict with other caller info attributes:

- **CS8959**: *CallerArgumentExpressionAttribute cannot be applied because there are no standard conversions from type1 to type2*
- **CS8960**: *The CallerArgumentExpressionAttribute applied to parameter will have no effect. It is overridden by the CallerLineNumberAttribute.*
- **CS8961**: *The CallerArgumentExpressionAttribute applied to parameter will have no effect. It is overridden by the CallerFilePathAttribute.*
- **CS8962**: *The CallerArgumentExpressionAttribute applied to parameter will have no effect. It is overridden by the CallerMemberNameAttribute.*
- **CS8963**: *The CallerArgumentExpressionAttribute applied to parameter will have no effect. It is applied with an invalid parameter name.*

To correct these errors, follow these rules. For more information, see [Caller information attributes](../../language-reference/attributes/caller-information.md) and <xref:System.Runtime.CompilerServices.CallerArgumentExpressionAttribute>.

- The parameter decorated with `CallerArgumentExpression` must have type `string` or a type with a standard conversion from `string`, because the attribute injects a `string` representation of the caller's argument expression (**CS8959**). Change the parameter type to `string` or a compatible type.
- The `CallerArgumentExpression` attribute has no effect on a parameter that also has <xref:System.Runtime.CompilerServices.CallerLineNumberAttribute>, <xref:System.Runtime.CompilerServices.CallerFilePathAttribute>, or <xref:System.Runtime.CompilerServices.CallerMemberNameAttribute> (**CS8960**, **CS8961**, **CS8962**). Those caller info attributes take precedence, so remove the `CallerArgumentExpression` attribute from the parameter.
- The string argument passed to the `CallerArgumentExpression` constructor must match the name of another parameter in the same method signature (**CS8963**). If the parameter name is misspelled or refers to a nonexistent parameter, the attribute has no effect.

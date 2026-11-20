---
title: Resolve errors and warnings that involve attribute declaration and attribute use in your code.
description: These compiler errors and warnings indicate errors in attribute declarations, or attribute use in your code.
f1_keywords:
  - "CS0036"
  - "CS0181"
  - "CS0243"
  - "CS0404"
  - "CS0415"
  - "CS0416"
  - "CS0423"
  - "CS0424"
  - "CS0447"
  - "CS0577"
  - "CS0578"
  - "CS0579"
  - "CS0582"
  - "CS0592"
  - "CS0596"
  - "CS0601"
  - "CS0609"
  - "CS0616"
  - "CS0625"
  - "CS0626"
  - "CS0629"
  - "CS0636"
  - "CS0637"
  - "CS0641"
  - "CS0646"
  - "CS0647"
  - "CS0653"
  - "CS0657"
  - "CS0658"
  - "CS0662"
  - "CS0668"
  - "CS0669"
  - "CS0684"
  - "CS0685"
  - "CS0735"
  - "CS0739"
  - "CS1608"
  - "CS1614"
  - "CS1618"
  - "CS1667"
  - "CS1689"
  - "CS7014"
  - "CS7042"
  - "CS7045"
  - "CS7046"
  - "CS7047"
  - "CS7054"
  - "CS7055"
  - "CS7067"
  - "CS7080"
  - "CS7081"
  - "CS7082"
  - "CS8028"
  - "CS8335"
  - "CS8336"
  - "CS8355"
  - "CS8423"
  - "CS8783"
  - "CS8959"
  - "CS8960"
  - "CS8961"
  - "CS8962"
  - "CS8963"
  - "CS8968"
  - "CS8970"
  - "CS9331"
  - "CS9351"
helpviewer_keywords:
  - "CS0036"
  - "CS0181"
  - "CS0243"
  - "CS0404"
  - "CS0415"
  - "CS0416"
  - "CS0423"
  - "CS0424"
  - "CS0447"
  - "CS0577"
  - "CS0578"
  - "CS0579"
  - "CS0582"
  - "CS0592"
  - "CS0596"
  - "CS0601"
  - "CS0609"
  - "CS0616"
  - "CS0625"
  - "CS0626"
  - "CS0629"
  - "CS0636"
  - "CS0637"
  - "CS0641"
  - "CS0646"
  - "CS0647"
  - "CS0653"
  - "CS0657"
  - "CS0658"
  - "CS0662"
  - "CS0668"
  - "CS0669"
  - "CS0684"
  - "CS0685"
  - "CS0735"
  - "CS0739"
  - "CS1608"
  - "CS1614"
  - "CS1618"
  - "CS1667"
  - "CS1689"
  - "CS7014"
  - "CS7042"
  - "CS7045"
  - "CS7046"
  - "CS7047"
  - "CS7054"
  - "CS7055"
  - "CS7067"
  - "CS7080"
  - "CS7081"
  - "CS7082"
  - "CS8028"
  - "CS8335"
  - "CS8336"
  - "CS8355"
  - "CS8423"
  - "CS8783"
  - "CS8959"
  - "CS8960"
  - "CS8961"
  - "CS8962"
  - "CS8963"
  - "CS8968"
  - "CS8970"
  - "CS9331"
  - "CS9351"
ms.date: 11/09/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings related to attribute declarations or attribute use in your code

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error or warning for SEO purposes.
 -->
- [**CS0036**](#marshaling-attribute-validity): *An out parameter cannot have the In attribute*
- [**CS0181**](#attribute-arguments-and-parameters): *Attribute constructor parameter 'parameter' has type 'type', which is not a valid attribute parameter type*
- [**CS0243**](#conditional-attribute-usage): *The Conditional attribute is not valid on 'method' because it is an override method*
- [**CS0404**](#attribute-class-requirements): *Attribute is not valid on this declaration type.*
- [**CS0415**](#predefined-attributes): *The 'attribute' attribute is valid only on an indexer that is not an explicit interface member declaration*
- [**CS0416**](#attribute-arguments-and-parameters): *'type parameter': an attribute argument cannot use type parameters*
- [**CS0423**](#imported-declarations): *Since 'class' has the ComImport attribute, 'method' must be extern or abstract*
- [**CS0424**](#imported-declarations): *'type': a class with the ComImport attribute cannot specify a base class*
- [**CS0447**](#attribute-arguments-and-parameters): *Attribute cannot be used with type arguments.*
- [**CS0577**](#conditional-attribute-usage): *The Conditional attribute is not valid on 'method' because it is a constructor, destructor, operator, lambda expression, or explicit interface implementation*
- [**CS0578**](#conditional-attribute-usage): *The Conditional attribute is not valid on 'function' because its return type is not void*
- [**CS0579**](#attribute-class-requirements): *Duplicate 'attribute' attribute*
- [**CS0582**](#conditional-attribute-usage): *The Conditional attribute is not valid on interface members*
- [**CS0592**](#attribute-location-context): *Attribute 'attribute' is not valid on this declaration type. It is only valid on 'declaration' declarations.*
- [**CS0596**](#imported-declarations): *The Guid attribute must be specified with the ComImport attribute*
- [**CS0601**](#imported-declarations): *The DllImport attribute must be specified on a method marked 'extern' that is either 'static' or an extension member*
- [**CS0609**](#predefined-attributes): *Cannot set the attribute on an indexer marked override.*
- [**CS0616**](#attribute-class-requirements): *'Type' is not an attribute class*
- [**CS0625**](#predefined-attributes): *'field': instance field in types marked with StructLayout(LayoutKind.Explicit) must have a FieldOffset attribute*
- [**CS0626**](#imported-declarations): *Method, operator, or accessor 'method' is marked external and has no attributes on it. Consider adding a DllImport attribute to specify the external implementation.*
- [**CS0629**](#conditional-attribute-usage): *Conditional member 'member' cannot implement interface member 'base class member' in type 'Type Name'*
- [**CS0636**](#predefined-attributes): *The FieldOffset attribute can only be placed on members of types marked with the StructLayout(LayoutKind.Explicit)*
- [**CS0637**](#predefined-attributes): *The FieldOffset attribute is not allowed on static or const fields*
- [**CS0641**](#attribute-class-requirements): *Attribute 'attribute' is only valid on classes derived from System.Attribute*
- [**CS0646**](#predefined-attributes): *Cannot specify the DefaultMember attribute on a type containing an indexer*
- [**CS0647**](#attribute-arguments-and-parameters): *Error emitting attribute*
- [**CS0653**](#attribute-class-requirements): *Cannot apply attribute class 'class' because it is abstract*
- [**CS0657**](#attribute-location-context): *'Location' is not a valid attribute location for this declaration. Valid attribute locations for this declaration are 'valid locations'. All attributes in this block will be ignored.*
- [**CS0658**](#attribute-location-context): *'Location' is not a recognized attribute location. Valid attribute locations for this declaration are 'valid locations'. All attributes in this block will be ignored.*
- [**CS0662**](#marshaling-attribute-validity): *Cannot specify the Out attribute on a ref parameter without also specifying the In attribute.*
- [**CS0668**](#predefined-attributes): *Two indexers have different names; the IndexerName attribute must be used with the same name on every indexer within a type*
- [**CS0669**](#imported-declarations): *A class with the ComImport attribute cannot have a user-defined constructor*
- [**CS0684**](#imported-declarations): *'interface' interface marked with 'CoClassAttribute' not marked with 'ComImportAttribute'*
- [**CS0685**](#conditional-attribute-usage): *Conditional member 'member' cannot have an out parameter*
- [**CS0735**](#predefined-attributes): *Invalid type specified as an argument for TypeForwardedTo attribute*
- [**CS0739**](#predefined-attributes): *'type' duplicate TypeForwardedToAttribute*
- [**CS1608**](#predefined-attributes): *The RequiredAttribute attribute is not permitted on C# types*
- [**CS1614**](#attribute-class-requirements): *'name' is ambiguous between 'attribute' and 'other attribute'. Either use '@name' or explicitly include the 'Attribute' suffix.*
- [**CS1618**](#conditional-attribute-usage): *Cannot create delegate with 'method' because it or a method it overrides has a Conditional attribute*
- [**CS1667**](#attribute-location-context): *Attribute 'attribute' is not valid on property or event accessors. It is only valid on 'declaration' declarations.*
- [**CS1689**](#conditional-attribute-usage): *Attribute 'attribute' is only valid on methods or attribute classes*
- [**CS7014**](#attribute-location-context): *Attributes are not valid in this context.*
- [**CS7042**](#imported-declarations): *The DllImport attribute cannot be applied to a method that is generic or contained in a generic method or type.*
- [**CS7045**](#marshaling-attribute-validity): *Parameter not valid for the specified unmanaged type.*
- [**CS7046**](#attribute-arguments-and-parameters): *Attribute parameter 'parameter' must be specified.*
- [**CS7047**](#attribute-arguments-and-parameters): *Attribute parameter 'parameter1' or 'parameter2' must be specified.*
- [**CS7054**](#marshaling-attribute-validity): *Unmanaged type 'type' not valid for fields.*
- [**CS7055**](#marshaling-attribute-validity): *Unmanaged type 'type' is only valid for fields.*
- [**CS7067**](#attribute-arguments-and-parameters): *Attribute constructor parameter 'parameter' is optional, but no default parameter value was specified.*
- [**CS7080**](#caller-information-attribute-precedence): *The CallerMemberNameAttribute applied to parameter 'parameter name' will have no effect. It is overridden by the CallerFilePathAttribute.*
- [**CS7081**](#caller-information-attribute-precedence): *The CallerMemberNameAttribute applied to parameter 'parameter name' will have no effect. It is overridden by the CallerLineNumberAttribute.*
- [**CS7082**](#caller-information-attribute-precedence): *The CallerFilePathAttribute applied to parameter 'parameter name' will have no effect. It is overridden by the CallerLineNumberAttribute.*
- [**CS8028**](#imported-declarations): *'type': a class with the ComImport attribute cannot specify field initializers.*
- [**CS8335**](#compiler-reserved-attributes-and-types): *Do not use 'attribute name'. This is reserved for compiler usage.*
- [**CS8336**](#compiler-reserved-attributes-and-types): *The type name 'type' is reserved to be used by the compiler.*
- [**CS8355**](#marshaling-attribute-validity): *An in parameter cannot have the Out attribute.*
- [**CS8423**](#attribute-location-context): *Attribute 'attribute' is not valid on event accessors. It is only valid on 'declaration' declarations.*
- [**CS8783**](#conditional-attribute-usage): *Local function 'method' must be 'static' in order to use the Conditional attribute*
- [**CS8959**](#callerargumentexpression-attribute-usage): *CallerArgumentExpressionAttribute cannot be applied because there are no standard conversions from type 'type1' to type 'type2'*
- [**CS8960**](#callerargumentexpression-attribute-usage): *The CallerArgumentExpressionAttribute applied to parameter 'parameter' will have no effect. It is overridden by the CallerLineNumberAttribute.*
- [**CS8961**](#callerargumentexpression-attribute-usage): *The CallerArgumentExpressionAttribute applied to parameter 'parameter' will have no effect. It is overridden by the CallerFilePathAttribute.*
- [**CS8962**](#callerargumentexpression-attribute-usage): *The CallerArgumentExpressionAttribute applied to parameter 'parameter' will have no effect. It is overridden by the CallerMemberNameAttribute.*
- [**CS8963**](#callerargumentexpression-attribute-usage): *The CallerArgumentExpressionAttribute applied to parameter 'parameter' will have no effect. It is applied with an invalid parameter name.*
- [**CS8968**](#attribute-arguments-and-parameters): *'type parameter': an attribute type argument cannot use type parameters*
- [**CS8970**](#attribute-arguments-and-parameters): *Type 'type' cannot be used in this context because it cannot be represented in metadata.*
- [**CS9331**](#predefined-attributes): *'attribute' cannot be applied manually.*
- [**CS9351**](#predefined-attributes): *Use of 'StructLayoutAttribute' and 'ExtendedLayoutAttribute' on the same type is not allowed.*

## Attribute arguments and parameters

You see the following errors when you use attribute arguments or parameters incorrectly:

- **CS0181**: *Attribute constructor parameter 'parameter' has type 'type', which is not a valid attribute parameter type*
- **CS0416**: *'type parameter': an attribute argument cannot use type parameters*
- **CS0447**: *Attribute cannot be used with type arguments.*
- **CS0647**: *Error emitting attribute*
- **CS7046**: *Attribute parameter 'parameter' must be specified.*
- **CS7047**: *Attribute parameter 'parameter1' or 'parameter2' must be specified.*
- **CS7067**: *Attribute constructor parameter 'parameter' is optional, but no default parameter value was specified.*
- **CS8968**: *'type parameter': an attribute type argument cannot use type parameters*
- **CS8970**: *Type 'type' cannot be used in this context because it cannot be represented in metadata.*

To correct these errors, follow these rules:

- Attribute constructor parameters must use valid attribute parameter types (**CS0181**). The C# language specification restricts attribute parameter types to primitive types (`bool`, `byte`, `char`, `double`, `float`, `int`, `long`, `sbyte`, `short`, `string`, `uint`, `ulong`, and `ushort`), `object`, `System.Type`, enum types, and single-dimensional arrays of these types. Function pointers aren't valid attribute parameter types.
- Don't use a type parameter in an attribute's `typeof` argument (**CS0416**). Replace it with a type that doesn't depend on a type parameter, such as `typeof(string)` or `typeof(List<>)`.
- You can't apply type arguments to a non-generic attribute (**CS0447**). If an attribute class isn't generic, its usage can't include type arguments in angle brackets.
- All values passed to an attribute constructor must be correctly formatted and within the valid range for each parameter (**CS0647**). For example, a <xref:System.Runtime.InteropServices.GuidAttribute> requires a valid GUID format string.
- Supply the required named arguments for the selected `MarshalAs` representation (**CS7046**, **CS7047**). For `ByValTStr`, specify `SizeConst`; for `CustomMarshaler`, specify `MarshalType` or `MarshalTypeRef`. These requirements aren't expressed by the attribute's constructor signature.
- When you define a custom attribute with optional constructor parameters, specify default values for those parameters (**CS7067**). Use the syntax `parameterType parameterName = defaultValue` in the attribute constructor so callers can omit those arguments.
- Generic attribute type arguments must be concrete types, not type parameters (**CS8968**). The compiler must fully determine generic attribute type arguments at compile time, so open type parameters aren't permitted.
- Generic attribute type arguments can't require additional attributes to represent their types in metadata (**CS8970**). Replace `dynamic` with `object`, remove nullable reference annotations or tuple element names, or use `IntPtr` or `UIntPtr` instead of `nint` or `nuint`.

For more information, see [Attributes](../../advanced-topics/reflection-and-attributes/index.md), [Generics](../../fundamentals/types/generics.md), and the [C# language specification section on attributes](~/_csharpstandard/standard/attributes.md).

> [!NOTE]
> **CS0404**, **CS0447**, **CS0609**, and **CS0647** are historical diagnostics. The current compiler doesn't emit these errors.

## Attribute class requirements

You see the following errors when you define attribute classes that don't meet the required constraints:

- **CS0404**: *Attribute is not valid on this declaration type.*
- **CS0579**: *Duplicate 'attribute' attribute*
- **CS0616**: *'Type' is not an attribute class*
- **CS0641**: *Attribute 'attribute' is only valid on classes derived from System.Attribute*
- **CS0653**: *Cannot apply attribute class 'class' because it is abstract*
- **CS1614**: *'name' is ambiguous between 'attribute' and 'other attribute'. Either use '@name' or explicitly include the 'Attribute' suffix.*

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

- **CS0592**: *Attribute 'attribute' is not valid on this declaration type. It is only valid on 'declaration' declarations.*
- **CS0657**: *'Location' is not a valid attribute location for this declaration. Valid attribute locations for this declaration are 'valid locations'. All attributes in this block will be ignored.*
- **CS0658**: *'Location' is not a recognized attribute location. Valid attribute locations for this declaration are 'valid locations'. All attributes in this block will be ignored.*
- **CS1667**: *Attribute 'attribute' is not valid on property or event accessors. It is only valid on 'declaration' declarations.*
- **CS7014**: *Attributes are not valid in this context.*
- **CS8423**: *Attribute 'attribute' is not valid on event accessors. It is only valid on 'declaration' declarations.*

To correct these errors, follow these rules. For more information, see [Attribute Targets](../../advanced-topics/reflection-and-attributes/index.md#attribute-targets) and the [C# language specification section on attribute specification](~/_csharpstandard/standard/attributes.md#233-attribute-specification).

- Each attribute's <xref:System.AttributeUsageAttribute> specifies which declaration types it targets. You must apply the attribute only to those types (**CS0592**). For example, you can't apply an attribute defined with `AttributeTargets.Interface` to a class.
- When you use an attribute target specifier such as `method:` or `property:`, the specifier must be valid for the declaration where it appears (**CS0657**). Check the error message to see which target specifiers are allowed for the specific declaration.
- The attribute target specifier you used isn't a recognized specifier (**CS0658**). Valid specifiers include `assembly:`, `module:`, `type:`, `method:`, `property:`, `field:`, `event:`, `param:`, and `return:`.
- Some attributes, such as <xref:System.Diagnostics.ConditionalAttribute> and <xref:System.CLSCompliantAttribute>, aren't valid on property or event accessors (**CS1667**). Remove `Conditional` from the accessor, or move `CLSCompliant` to the property or event declaration itself.
- Attributes can only appear on program elements that support them (**CS7014**). If you're applying assembly-level or module-level attributes, use the `assembly:` or `module:` target specifiers and place them at the top of the file.
- Attributes such as <xref:System.ObsoleteAttribute> aren't valid on event `add` and `remove` accessors (**CS8423**). Move the attribute to the event declaration. Other attributes can be valid on event accessors.

## Predefined attributes

The following errors occur when you use specific predefined .NET attributes incorrectly:

- **CS0415**: *The 'attribute' attribute is valid only on an indexer that is not an explicit interface member declaration*
- **CS0609**: *Cannot set the attribute on an indexer marked override.*
- **CS0625**: *'field': instance field in types marked with StructLayout(LayoutKind.Explicit) must have a FieldOffset attribute*
- **CS0636**: *The FieldOffset attribute can only be placed on members of types marked with the StructLayout(LayoutKind.Explicit)*
- **CS0637**: *The FieldOffset attribute is not allowed on static or const fields*
- **CS0646**: *Cannot specify the DefaultMember attribute on a type containing an indexer*
- **CS0668**: *Two indexers have different names; the IndexerName attribute must be used with the same name on every indexer within a type*
- **CS0735**: *Invalid type specified as an argument for TypeForwardedTo attribute*
- **CS0739**: *'type' duplicate TypeForwardedToAttribute*
- **CS1608**: *The RequiredAttribute attribute is not permitted on C# types*
- **CS9331**: *'attribute' cannot be applied manually.*
- **CS9351**: *Use of 'StructLayoutAttribute' and 'ExtendedLayoutAttribute' on the same type is not allowed.*

To correct these errors, follow these rules. For more information, see [Indexers](../../programming-guide/indexers/index.md), [Structure types](../builtin-types/struct.md), <xref:System.Runtime.CompilerServices.TypeForwardedToAttribute>, [Unsafe code and pointers](../unsafe-code.md#the-updated-memory-safety-model-preview), and [Platform Invoke (P/Invoke)](../../../standard/native-interop/pinvoke.md).

- You can apply <xref:System.Runtime.CompilerServices.IndexerNameAttribute> only to indexers that aren't explicit interface member declarations (**CS0415**). Remove the attribute from explicit interface indexers, because the interface already defines the indexer name.
- You can't apply `IndexerName` to indexers marked with `override` because override indexers inherit their name from the base class (**CS0609**). Remove the `IndexerName` attribute from the override indexer.
- Every instance field in a type marked with `StructLayout(LayoutKind.Explicit)` must have a <xref:System.Runtime.InteropServices.FieldOffsetAttribute> (**CS0625**). Explicit layout requires that you specify the byte offset for each instance field.
- You can place the <xref:System.Runtime.InteropServices.FieldOffsetAttribute> only on members of types that have <xref:System.Runtime.InteropServices.StructLayoutAttribute> set to `LayoutKind.Explicit` (**CS0636**). Add the `StructLayout` attribute to the containing type declaration.
- The `FieldOffset` attribute isn't allowed on `static` or `const` fields because explicit layout applies only to instance fields (**CS0637**). Remove the `FieldOffset` attribute from the static or const field.
- You can't apply <xref:System.Reflection.DefaultMemberAttribute> to a type that already contains an indexer because the compiler automatically defines the default member for types with indexers (**CS0646**). Remove the `DefaultMember` attribute.
- All <xref:System.Runtime.CompilerServices.IndexerNameAttribute> attributes within a type must specify the same name (**CS0668**). Change the names to match, because the runtime uses a single name for all indexers on a type.
- Specify a top-level named type from another assembly as the argument for <xref:System.Runtime.CompilerServices.TypeForwardedToAttribute> (**CS0735**). Don't pass `null`, an array type, or a pointer type. Generic type definitions such as `typeof(List<>)` are valid forwarding targets.
- An assembly can have only one <xref:System.Runtime.CompilerServices.TypeForwardedToAttribute> for each external type (**CS0739**). Locate and remove the duplicate `TypeForwardedTo` declaration.
- You can't use the <xref:System.Runtime.CompilerServices.RequiredAttributeAttribute> on types defined in C# (**CS1608**). This attribute is reserved for other languages that need to force compilers to require a particular feature.
- Remove a manually applied `MetadataUpdateDeletedAttribute` (**CS9331**). This attribute is reserved for compiler-generated metadata and has no equivalent source-level attribute application.
- Don't apply both <xref:System.Runtime.InteropServices.StructLayoutAttribute> and `ExtendedLayoutAttribute` to the same type (**CS9351**). These two layout attributes represent mutually exclusive layout strategies under the [updated memory safety model](../unsafe-code.md#the-updated-memory-safety-model-preview): explicit layout requires a `FieldOffset` on every instance field, while extended layout lets the runtime choose field offsets while still requiring each field to be marked `safe` or `unsafe`. Remove one of the two attributes from the type declaration.

## Compiler-reserved attributes and types

The following errors occur when source code explicitly declares or applies names or attributes reserved for compiler-generated metadata:

- **CS8335**: *Do not use 'attribute name'. This is reserved for compiler usage.*
- **CS8336**: *The type name 'type' is reserved to be used by the compiler.*

Remove the explicit declaration or attribute application. Use the corresponding C# language feature instead, and let the compiler generate the required metadata.

## Conditional attribute usage

You see the following errors when you apply the <xref:System.Diagnostics.ConditionalAttribute> in ways that violate its usage restrictions:

- **CS0243**: *The Conditional attribute is not valid on 'method' because it is an override method*
- **CS0577**: *The Conditional attribute is not valid on 'method' because it is a constructor, destructor, operator, lambda expression, or explicit interface implementation*
- **CS0578**: *The Conditional attribute is not valid on 'function' because its return type is not void*
- **CS0582**: *The Conditional attribute is not valid on interface members*
- **CS0629**: *Conditional member 'member' cannot implement interface member 'base class member' in type 'Type Name'*
- **CS0685**: *Conditional member 'member' cannot have an out parameter*
- **CS1618**: *Cannot create delegate with 'method' because it or a method it overrides has a Conditional attribute*
- **CS1689**: *Attribute 'attribute' is only valid on methods or attribute classes*
- **CS8783**: *Local function 'method' must be 'static' in order to use the Conditional attribute*

To correct these errors, follow these rules. For more information, see <xref:System.Diagnostics.ConditionalAttribute>, [Conditional methods](~/_csharpstandard/standard/attributes.md#23532-conditional-methods), and [Attributes](../../advanced-topics/reflection-and-attributes/index.md).

- The compiler binds calls to the base method declaration, not the override, so you can't apply the `Conditional` attribute to [override](../keywords/override.md) methods (**CS0243**). Remove the `Conditional` attribute from the override method, or remove the `override` keyword.
- The `Conditional` attribute isn't valid on constructors, [finalizers](../../programming-guide/classes-and-structs/finalizers.md), operators, lambda expressions, or explicit interface implementations (**CS0577**). These member types can't be conditionally omitted because they have required roles in the type's lifecycle or contract.
- Conditional methods must return `void` because the compiler might omit the call entirely, and no return value would be available to the caller (**CS0578**). Change the method's return type to `void`, or remove the `Conditional` attribute.
- Interface members can't be conditional, even when they have a default implementation (**CS0582**). Remove the `Conditional` attribute from the interface member declaration.
- Methods that implement interface members can't be conditional (**CS0629**). Remove the `Conditional` attribute from the implementing method; calls through an interface aren't conditionally omitted.
- Conditional methods can't have `out` parameters because the `out` variable value would be undefined when the compiler omits the method call (**CS0685**). Remove the `out` parameters from the method, or remove the `Conditional` attribute.
- You can't create a delegate that references a conditional method (**CS1618**). The compiler conditionally omits direct calls, not the method declaration; a delegate invocation wouldn't preserve that behavior. Remove the `Conditional` attribute from the method, or don't use it as a delegate target.
- The `Conditional` attribute is only valid on methods and attribute classes (**CS1689**). It isn't valid on other declaration types such as non-attribute classes, structs, or interfaces.
- A local function must be declared `static` to use the `Conditional` attribute, even if it doesn't capture state from the enclosing method (**CS8783**). Add the `static` modifier to the local function, or remove the `[Conditional]` attribute.

## Caller-information attribute precedence

- **CS7080**: *The CallerMemberNameAttribute applied to parameter 'parameter name' will have no effect. It is overridden by the CallerFilePathAttribute.*
- **CS7081**: *The CallerMemberNameAttribute applied to parameter 'parameter name' will have no effect. It is overridden by the CallerLineNumberAttribute.*
- **CS7082**: *The CallerFilePathAttribute applied to parameter 'parameter name' will have no effect. It is overridden by the CallerLineNumberAttribute.*

To select the value supplied for an omitted argument, keep only the intended caller-information attribute on the parameter. `CallerLineNumber` overrides `CallerFilePath` (**CS7082**) and `CallerMemberName` (**CS7081**); `CallerFilePath` overrides `CallerMemberName` (**CS7080**), regardless of attribute order. Remove the overridden attribute, or remove the higher-precedence attributes if you want a different caller-information value.

For more information, see [Caller information attributes](../attributes/caller-information.md) and [Caller-info attributes in the C# language specification](~/_csharpstandard/standard/attributes.md#2356-caller-info-attributes).

## CallerArgumentExpression attribute usage

The following errors occur when you apply <xref:System.Runtime.CompilerServices.CallerArgumentExpressionAttribute> incorrectly or in conflict with other caller info attributes:

- **CS8959**: *CallerArgumentExpressionAttribute cannot be applied because there are no standard conversions from type 'type1' to type 'type2'*
- **CS8960**: *The CallerArgumentExpressionAttribute applied to parameter 'parameter' will have no effect. It is overridden by the CallerLineNumberAttribute.*
- **CS8961**: *The CallerArgumentExpressionAttribute applied to parameter 'parameter' will have no effect. It is overridden by the CallerFilePathAttribute.*
- **CS8962**: *The CallerArgumentExpressionAttribute applied to parameter 'parameter' will have no effect. It is overridden by the CallerMemberNameAttribute.*
- **CS8963**: *The CallerArgumentExpressionAttribute applied to parameter 'parameter' will have no effect. It is applied with an invalid parameter name.*

To correct these errors, follow these rules. For more information, see [Caller information attributes](../../language-reference/attributes/caller-information.md) and <xref:System.Runtime.CompilerServices.CallerArgumentExpressionAttribute>.

- The parameter decorated with `CallerArgumentExpression` must have type `string` or a type with a standard conversion from `string`, because the attribute injects a `string` representation of the caller's argument expression (**CS8959**). Change the parameter type to `string` or a compatible type.
- The `CallerArgumentExpression` attribute has no effect on a parameter that also has <xref:System.Runtime.CompilerServices.CallerLineNumberAttribute>, <xref:System.Runtime.CompilerServices.CallerFilePathAttribute>, or <xref:System.Runtime.CompilerServices.CallerMemberNameAttribute> (**CS8960**, **CS8961**, **CS8962**). Those caller info attributes take precedence, so remove the `CallerArgumentExpression` attribute from the parameter.
- The string argument passed to the `CallerArgumentExpression` constructor must match the name of another parameter in the same method signature (**CS8963**). If the parameter name is misspelled or refers to a nonexistent parameter, the attribute has no effect.

## Imported declarations

- **CS0423**: *Since 'class' has the ComImport attribute, 'method' must be extern or abstract*
- **CS0424**: *'type': a class with the ComImport attribute cannot specify a base class*
- **CS0596**: *The Guid attribute must be specified with the ComImport attribute*
- **CS0601**: *The DllImport attribute must be specified on a method marked 'extern' that is either 'static' or an extension member*
- **CS0626**: *Method, operator, or accessor 'method' is marked external and has no attributes on it. Consider adding a DllImport attribute to specify the external implementation.*
- **CS0669**: *A class with the ComImport attribute cannot have a user-defined constructor*
- **CS0684**: *'interface' interface marked with 'CoClassAttribute' not marked with 'ComImportAttribute'*
- **CS7042**: *The DllImport attribute cannot be applied to a method that is generic or contained in a generic method or type.*
- **CS8028**: *'type': a class with the ComImport attribute cannot specify field initializers.*

Because a <xref:System.Runtime.InteropServices.ComImportAttribute> class imports its implementation from COM, remove managed method bodies from the class. Declare the imported method `extern`, or use an `abstract` method in an abstract imported class (**CS0423**).

The following example produces **CS0423**:

```csharp
using System.Runtime.InteropServices;
[ComImport, Guid("7ab770c7-0e23-4d7a-8aa2-19bfad479829")]
class ImageProperties
{
    public void Refresh() { }
}
```

Replace the method with `public extern void Refresh();`.

Remove the base class from a class marked with `ComImport`. The imported COM implementation can't gain additional implementation from a managed base class (**CS0424**).

The following example produces **CS0424**:

```csharp
using System.Runtime.InteropServices;
class BaseClass { }
[ComImport, Guid("7ab770c7-0e23-4d7a-8aa2-19bfad479829")]
class ImageProperties : BaseClass { }
```

Change the imported declaration to `class ImageProperties { }`.

Add <xref:System.Runtime.InteropServices.GuidAttribute> when you apply `ComImport` (**CS0596**).

The following example produces **CS0596**:

```csharp
using System.Runtime.InteropServices;
[ComImport]
class ImageProperties { }
```

Replace the attribute list with `[ComImport, Guid("00000000-0000-0000-0000-000000000001")]`. Use the GUID of the COM type that you intend to import.

Apply <xref:System.Runtime.InteropServices.DllImportAttribute> only to an `extern` method that is `static` or an extension member. For an ordinary method declared directly in a class, add any missing `static` or `extern` modifier (**CS0601**).

The following example produces **CS0601** because the method isn't `static`:

```csharp
using System.Runtime.InteropServices;
class NativeMethods
{
    [DllImport("kernel32.dll")]
    extern int GetCurrentDirectory(int size, System.Text.StringBuilder buffer);
}
```

Add `static` to the method declaration: `static extern int GetCurrentDirectory(int size, System.Text.StringBuilder buffer);`.

Specify the external implementation with an appropriate attribute (**CS0626**). For a platform-invoke declaration, add `DllImport`. Other external implementation mechanisms can require different attributes.

The following example produces **CS0626**:

```csharp
using System.Runtime.InteropServices;
class NativeMethods
{
    public static extern void M();
}
```

For a method implemented by a native library, add `[DllImport("mydll.dll")]` to `M`, replacing `mydll.dll` with the library name.

Remove user-defined instance constructors from a class marked with `ComImport`. The COM interop layer supplies the instance constructor (**CS0669**).

The following example produces **CS0669**:

```csharp
using System.Runtime.InteropServices;
[ComImport, Guid("00000000-0000-0000-0000-000000000001")]
class ImportedClass
{
    public ImportedClass() { }
}
```

Delete `public ImportedClass() { }` to correct the class declaration.

Add `ComImport` to an interface that specifies <xref:System.Runtime.InteropServices.CoClassAttribute> (**CS0684**).

The following example produces **CS0684**:

```csharp
using System.Runtime.InteropServices;
[CoClass(typeof(Implementation)), Guid("00000000-0000-0000-0000-000000000001")]
interface IImported { }
class Implementation : IImported { }
```

Add `ComImport` to the interface's attribute list: `[CoClass(typeof(Implementation)), ComImport, Guid("00000000-0000-0000-0000-000000000001")]`.

Move `DllImport` declarations into a nongeneric type, place them outside generic methods, and remove any type parameters from the imported method (**CS7042**). A type nested in a generic type is also a generic context. Call the nongeneric import from your generic code instead.

The following example produces **CS7042**:

```csharp
using System.Runtime.InteropServices;
class NativeMethods<T>
{
    [DllImport("native.dll")]
    public static extern void Run();
}
```

Change `class NativeMethods<T>` to `class NativeMethods`.

Remove instance and static field initializers that require runtime initialization from a `ComImport` class (**CS8028**). Don't move the initialization into a managed instance constructor, because the imported class can't declare one (**CS0669**).

The following example produces **CS8028**:

```csharp
using System.Runtime.InteropServices;
[ComImport, Guid("00000000-0000-0000-0000-000000000001")]
public class ImportedClass
{
    public int Value = 1;
}
```

Change the field declaration to `public int Value;`. Any required initialization belongs in the COM implementation or the code that uses it, not in the imported class declaration.

For more information, see the [`extern` modifier](../keywords/extern.md), [Platform invoke](../../../standard/native-interop/pinvoke.md), and [External methods in the C# language specification](~/_csharpstandard/standard/classes.md#1568-external-methods).

## Marshaling attribute validity

- **CS0036**: *An out parameter cannot have the In attribute*
- **CS0662**: *Cannot specify the Out attribute on a ref parameter without also specifying the In attribute.*
- **CS7045**: *Parameter not valid for the specified unmanaged type.*
- **CS7054**: *Unmanaged type 'type' not valid for fields.*
- **CS7055**: *Unmanaged type 'type' is only valid for fields.*
- **CS8355**: *An in parameter cannot have the Out attribute.*

Remove <xref:System.Runtime.InteropServices.InAttribute> from an [out](../keywords/method-parameters.md#out-parameter-modifier) parameter (**CS0036**).

The following example produces **CS0036**:

```csharp
using System.Runtime.InteropServices;
class Example
{
    static void GetValue([In] out char value) => value = 'b';
}
```

To correct the declaration, change `[In] out char value` to `out char value`.

For a `ref` parameter, either apply both `In` and <xref:System.Runtime.InteropServices.OutAttribute>, or apply neither attribute (**CS0662**).

The following example produces **CS0662**:

```csharp
using System.Runtime.InteropServices;
interface IExample
{
    void Update([Out] ref int value);
}
```

Change the parameter to `[In, Out] ref int value` or `ref int value`.

Match each <xref:System.Runtime.InteropServices.MarshalAsAttribute> named argument to the selected <xref:System.Runtime.InteropServices.UnmanagedType> (**CS7045**). These restrictions differ by unmanaged type:

- For `SafeArray`, remove `ArraySubType`, `SizeConst`, and `SizeParamIndex`. Use `SafeArraySubType` to specify the SAFEARRAY element variant.
- For `ByValArray`, remove `SizeParamIndex` and `SafeArraySubType`. Use `SizeConst` to specify the number of elements in the inline array.
- For `ByValTStr`, remove `ArraySubType` and `SizeParamIndex`. Use `SizeConst` to specify the inline string buffer size.

The following example produces **CS7045**:

```csharp
using System.Runtime.InteropServices;
interface IExample
{
    void Read([MarshalAs(UnmanagedType.SafeArray, SizeConst = 4)] int[] values);
}
```

Remove `SizeConst = 4` from the attribute. A SAFEARRAY carries its own size information; `SizeConst` isn't valid for this representation.

Select a field-compatible unmanaged representation instead of the obsolete `VBByRefStr` (**CS7054**). This diagnostic specifically rejects `VBByRefStr` on fields; compiler acceptance on a parameter or return target doesn't establish runtime support.

The following example produces **CS7054**, along with an obsolete-member warning:

```csharp
using System.Runtime.InteropServices;
public class NativeRecord
{
    [MarshalAs(UnmanagedType.VBByRefStr)]
    public string Text = "";
}
```

If the native field is a pointer to a UTF-16 string, replace `UnmanagedType.VBByRefStr` with `UnmanagedType.LPWStr`. Choose the replacement to match the native field's actual representation.

Use `ByValArray` and `ByValTStr` only on fields (**CS7055**). Both represent inline storage in a containing type, so neither is valid on a parameter or a return value. Keep these attributes on the corresponding field with an appropriate `SizeConst`, or select a different representation for the parameter or return value.

The following example produces **CS7055**:

```csharp
using System.Runtime.InteropServices;
interface IExample
{
    void Read([MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] int[] values);
}
```

If the native parameter is a pointer to an array of four elements, replace `UnmanagedType.ByValArray` with `UnmanagedType.LPArray`. An inline array field and a pointer parameter have different native layouts.

To keep a parameter read-only, remove `Out` from the `in` parameter. The attribute's outbound marshaling direction conflicts with the parameter's `in` modifier (**CS8355**).

The following example produces **CS8355**:

```csharp
using System.Runtime.InteropServices;
class Example
{
    public static void Read([Out] in int value) { }
}
```

Change the parameter to `in int value`.

For more information, see [Type marshalling](../../../standard/native-interop/type-marshalling.md), [Default marshalling behavior](../../../standard/native-interop/default-marshalling-behavior.md), and [Reference parameters](../keywords/method-parameters.md#reference-parameters).

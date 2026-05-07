---
title: Compiler Errors on property declarations
description: Use this article to diagnose and correct compiler errors and warnings when you define properties in your types.
f1_keywords:
  - "CS0200"
  - "CS0273"
  - "CS0274"
  - "CS0275"
  - "CS0276"
  - "CS0442"
  - "CS0544"
  - "CS0545"
  - "CS0546"
  - "CS0547"
  - "CS0548"
  - "CS0571"
  - "CS0610"
  - "CS0840"
  - "CS1014"
  - "CS1043"
  - "CS1715"
  - "CS8050"
  - "CS8051"
  - "CS8053"
  - "CS8080"
  - "CS8145"
  - "CS8147"
  - "CS8341"
  - "CS8657"
  - "CS8658"
  - "CS8659"
  - "CS8660"
  - "CS8661"
  - "CS8664"
  - "CS8852"
  - "CS8853"
  - "CS8855"
  - "CS8856"
  - "CS8903"
  - "CS9029"
  - "CS9030"
  - "CS9031"
  - "CS9032"
  - "CS9033"
  - "CS9034"
  - "CS9035"
  - "CS9036"
  - "CS9037"
  - "CS9038"
  - "CS9039"
  - "CS9040"
  - "CS9042"
  - "CS9045"
  - "CS9258"
  - "CS9263"
  - "CS9264"
  - "CS9266"
  - "CS9273"
helpviewer_keywords:
  - "CS0200"
  - "CS0273"
  - "CS0274"
  - "CS0275"
  - "CS0276"
  - "CS0442"
  - "CS0544"
  - "CS0545"
  - "CS0546"
  - "CS0547"
  - "CS0548"
  - "CS0571"
  - "CS0610"
  - "CS0840"
  - "CS1014"
  - "CS1043"
  - "CS1715"
  - "CS8050"
  - "CS8051"
  - "CS8053"
  - "CS8080"
  - "CS8145"
  - "CS8147"
  - "CS8341"
  - "CS8657"
  - "CS8658"
  - "CS8659"
  - "CS8660"
  - "CS8661"
  - "CS8664"
  - "CS8852"
  - "CS8853"
  - "CS8855"
  - "CS8856"
  - "CS8903"
  - "CS9029"
  - "CS9030"
  - "CS9031"
  - "CS9032"
  - "CS9033"
  - "CS9034"
  - "CS9035"
  - "CS9036"
  - "CS9037"
  - "CS9038"
  - "CS9039"
  - "CS9040"
  - "CS9042"
  - "CS9045"
  - "CS9258"
  - "CS9263"
  - "CS9264"
  - "CS9266"
  - "CS9273"
ms.date: 04/30/2026
ai-usage: ai-assisted
---
# Errors and warnings related to property declarations

You can encounter the following errors related to property declarations:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0200**](#readonly-properties): *Property or indexer 'property' cannot be assigned to -- it is read only*
- [**CS0273**](#accessor-accessibility): *The accessibility modifier of the 'accessor' accessor must be more restrictive than the property or indexer 'property'*
- [**CS0274**](#accessor-accessibility): *Cannot specify accessibility modifiers for both accessors of the property or indexer 'property'*
- [**CS0275**](#accessor-accessibility): *'accessor': accessibility modifiers may not be used on accessors in an interface*
- [**CS0276**](#accessor-accessibility): *'property': accessibility modifiers on accessors may only be used if the property or indexer has both a get and a set accessor*
- [**CS0442**](#accessor-accessibility): *'property': abstract properties cannot have private accessors*
- [**CS0544**](#property-overrides): *'property': cannot override because 'member' is not a property*
- [**CS0545**](#property-overrides): *'function' : cannot override because 'property' does not have an overridable get accessor*
- [**CS0546**](#property-overrides): *'accessor': cannot override because 'property' does not have an overridable set accessor*
- [**CS0547**](#property-declaration-syntax): *'property': property or indexer cannot have void type*
- [**CS0548**](#property-declaration-syntax): *'property': property or indexer must have at least one accessor*
- [**CS0571**](#property-declaration-syntax): *'function' : cannot explicitly call operator or accessor*
- [**CS0610**](#property-declaration-syntax): *Field or property cannot be of type 'type'*
- [**CS0840**](#property-declaration-syntax): *'Property name' must declare a body because it is not marked abstract or extern. Automatically implemented properties must define both get and set accessors.*
- [**CS1014**](#property-declaration-syntax): *A get or set accessor expected*
- [**CS1043**](#property-declaration-syntax): *{ or ; expected*
- [**CS1715**](#property-overrides): *'type': type must be 'type' to match overridden member 'member'*
- [**CS8050**](#property-initializers): *Only auto-implemented properties, or properties that use the 'field' keyword, can have initializers.*
- [**CS8051**](#property-initializers): *Auto-implemented properties must have get accessors.*
- [**CS8053**](#property-initializers): *Instance properties in interfaces cannot have initializers.*
- [**CS8080**](#property-overrides): *Auto-implemented properties must override all accessors of the overridden property.*
- [**CS8145**](#ref-returning-properties): *Auto-implemented properties cannot return by reference*
- [**CS8147**](#ref-returning-properties): *Properties which return by reference cannot have set accessors*
- [**CS8341**](#readonly-properties): *Auto-implemented instance properties in readonly structs must be readonly.*
- [**CS8657**](#readonly-properties): *Static member 'member' cannot be marked 'readonly'.*
- [**CS8658**](#readonly-properties): *Auto-implemented 'set' accessor 'accessor' cannot be marked 'readonly'.*
- [**CS8659**](#readonly-properties): *Auto-implemented property 'property' cannot be marked 'readonly' because it has a 'set' accessor.*
- [**CS8660**](#readonly-properties): *Cannot specify 'readonly' modifiers on both property or indexer 'property' and its accessor. Remove one of them.*
- [**CS8661**](#readonly-properties): *Cannot specify 'readonly' modifiers on both accessors of property or indexer 'property'. Instead, put a 'readonly' modifier on the property itself.*
- [**CS8664**](#readonly-properties): *'property': 'readonly' can only be used on accessors if the property or indexer has both a get and a set accessor*
- [**CS8852**](#init-only-properties): *Init-only property or indexer 'property' can only be assigned in an object initializer, or on 'this' or 'base' in an instance constructor or an 'init' accessor.*
- [**CS8853**](#init-only-properties): *'member' must match by init-only of overridden member 'member'*
- [**CS8855**](#init-only-properties): *Accessors 'accessor' and 'accessor' should both be init-only or neither*
- [**CS8856**](#init-only-properties): *The 'init' accessor is not valid on static members*
- [**CS8903**](#init-only-properties): *'init' accessors cannot be marked 'readonly'. Mark 'property' readonly instead.*
- [**CS9029**](#required-members): *Types and aliases cannot be named 'required'.*
- [**CS9030**](#required-members): *'member' must be required because it overrides required member 'member'*
- [**CS9031**](#required-members): *Required member 'member' cannot be hidden by 'member'.*
- [**CS9032**](#required-members): *Required member cannot be less visible or have a setter less visible than the containing type.*
- [**CS9033**](#required-members): *Do not use '`System.Runtime.CompilerServices.RequiredMemberAttribute'`. Use the 'required' keyword on required fields and properties instead.*
- [**CS9034**](#required-members): *Required member must be settable.*
- [**CS9035**](#required-members): *Required member must be set in the object initializer or attribute constructor.*
- [**CS9036**](#required-members): *Required member 'memberName' must be assigned a value, it cannot use a nested member or collection initializer.*
- [**CS9037**](#required-members): *The required members list for 'type' is malformed and cannot be interpreted.*
- [**CS9038**](#required-members): *The required members list for the base type 'type' is malformed and cannot be interpreted. To use this constructor, apply the '`SetsRequiredMembers`' attribute.*
- [**CS9039**](#required-members): *This constructor must add '`SetsRequiredMembers`' because it chains to a constructor that has that attribute.*
- [**CS9040**](#required-members): *Type cannot satisfy the '`new()`' constraint on parameter in the generic type or method because it has required members.*
- [**CS9042**](#required-members): *Required member should not be attributed with '`ObsoleteAttribute`' unless the containing type is obsolete or all constructors are obsolete.*
- [**CS9045**](#required-members): *Required members are not allowed on the top level of a script or submission.*
- [**CS9258**](#field-backed-properties): *In this language version, the '`field`' keyword binds to a synthesized backing field for the property. To avoid generating a synthesized backing field, and to refer to the existing member, use '`this.field`' or '`@field`' instead.*
- [**CS9263**](#field-backed-properties): *A partial property cannot have an initializer on both the definition and implementation.*

The following warnings can be generated for field-backed properties:

- [**CS9264**](#field-backed-properties): *Non-nullable property 'property' must contain a non-null value when exiting constructor. Consider adding the 'required' modifier, or declaring the property as nullable, or safely handling the case where '`field`' is null in the '`get`' accessor.*
- [**CS9266**](#field-backed-properties): *The 'accessor' accessor of property 'property' should use '`field`' because the other accessor is using it.*
- [**CS9273**](#field-backed-properties): *In this language version, '`field`' is a keyword within a property accessor. Rename the variable or use the identifier '`@field`' instead.*

The following sections explain the cause and fixes for these errors and warnings.

## Accessor accessibility

- **CS0273**: *The accessibility modifier of the 'accessor' accessor must be more restrictive than the property or indexer 'property'*
- **CS0274**: *Cannot specify accessibility modifiers for both accessors of the property or indexer 'property'*
- **CS0275**: *'accessor': accessibility modifiers may not be used on accessors in an interface*
- **CS0276**: *'property': accessibility modifiers on accessors may only be used if the property or indexer has both a get and a set accessor*
- **CS0442**: *'property': abstract properties cannot have private accessors*

These errors enforce the rules for access modifiers on property and indexer accessors. For the full rules, see [Restricting Accessor Accessibility](../../programming-guide/classes-and-structs/restricting-accessor-accessibility.md) and [Accessors](~/_csharpstandard/standard/classes.md#1573-accessors) in the C# specification. To correct these errors, apply one of the following changes based on the specific diagnostic:

- Use an access modifier that's more restrictive than the property's declared accessibility (**CS0273**). For example, an `internal` property can have a `private` set accessor, but not a `public` one. The accessor's accessibility must be a proper subset of the property's accessibility.
- Apply an access modifier to only one of the two accessors (**CS0274**). The property declaration itself establishes the default accessibility for both accessors, and only one accessor can differ from that default. Place the access modifier on whichever accessor needs restricted access.
- Remove access modifiers from accessors in interface property declarations (**CS0275**). Interface members define a public contract, and access modifiers on individual accessors aren't permitted. If you need to restrict access, apply the restriction in the implementing class instead.
- Add both a `get` and a `set` accessor to the property before applying an access modifier to either one (**CS0276**). Access modifiers on accessors distinguish one accessor's visibility from the other, which requires both accessors to be present. If the property has only one accessor, remove the access modifier from it.
- Change the access modifier on abstract property accessors from `private` to a less restrictive modifier (**CS0442**). Abstract members must be accessible to derived classes so those classes can provide implementations. Use `protected`, `internal`, or `protected internal` instead of `private`.

For more information, see [Restricting Accessor Accessibility](../../programming-guide/classes-and-structs/restricting-accessor-accessibility.md) and [Properties](../../programming-guide/classes-and-structs/properties.md).

## Property declaration syntax

- **CS0547**: *'property': property or indexer cannot have void type*
- **CS0548**: *'property': property or indexer must have at least one accessor*
- **CS0571**: *'function' : cannot explicitly call operator or accessor*
- **CS0610**: *Field or property cannot be of type 'type'*
- **CS0840**: *'Property name' must declare a body because it is not marked abstract or extern. Automatically implemented properties must define both get and set accessors.*
- **CS1014**: *A get or set accessor expected*
- **CS1043**: *{ or ; expected*

These errors enforce the structural requirements of property and indexer declarations. For the full rules, see [Properties](../../programming-guide/classes-and-structs/properties.md) and the [Properties](~/_csharpstandard/standard/classes.md#157-properties) section of the C# specification. To correct these errors, apply one of the following changes based on the specific diagnostic:

- Change the property type from `void` to a valid type (**CS0547**). Properties and indexers represent expressions, and [`void`](../builtin-types/void.md) isn't a valid expression type. Choose the appropriate type for the data the property represents.
- Add at least one accessor (`get`, `set`, or `init`) to the property declaration (**CS0548**). A property without any accessors has no way to read or write its value. Include a `get` accessor, a `set` or `init` accessor, or both.
- Access properties using property syntax rather than calling accessor methods directly (**CS0571**). Property accessors compile to methods named `get_PropertyName` and `set_PropertyName`, but invoke these methods through property syntax (`obj.Property` and `obj.Property = value`). The same principle applies to operators. Use operator syntax (`++obj`) rather than calling methods like `op_Increment`.
- Change the field or property type from a restricted type to an allowed type (**CS0610**). Certain types like <xref:System.TypedReference> and <xref:System.ArgIterator> can't be used as fields or properties. These types can still be used as method parameters or local variables.
- For a read-only property, declare a `get`-only auto-implemented property. Otherwise, add both `get` and `set` accessors to auto-implemented property declarations, or provide explicit accessor bodies (**CS0840**). For a property that needs custom logic, use the `field` keyword, added in C# 13 to access the compiler-synthesized backing field in your accessor body. For `abstract` or `extern` properties, remove the accessor bodies because the implementation is provided elsewhere. For `partial` properties, split the declaration and implementation across partial type declarations.
- Ensure the property body contains only valid accessor keywords—`get`, `set`, or `init` (**CS1014**). Property bodies can't contain arbitrary statements or member declarations. Move fields and methods outside the property to the class or struct body.
- Use proper property accessor syntax with braces or expression bodies (**CS1043**). Accessor bodies must use curly braces `{ }`, expression-bodied accessors must use `=>` syntax, and auto-implemented properties must end with a semicolon after the accessor token.

For more information, see [Properties](../../programming-guide/classes-and-structs/properties.md), [Auto-Implemented Properties](../../programming-guide/classes-and-structs/auto-implemented-properties.md), and [Using Properties](../../programming-guide/classes-and-structs/using-properties.md).

## Property overrides

- **CS0544**: *'property': cannot override because 'member' is not a property*
- **CS0545**: *'function' : cannot override because 'property' does not have an overridable get accessor*
- **CS0546**: *'accessor': cannot override because 'property' does not have an overridable set accessor*
- **CS1715**: *'type': type must be 'type' to match overridden member 'member'*
- **CS8080**: *Auto-implemented properties must override all accessors of the overridden property.*

These errors enforce the rules for overriding properties in derived classes. For the full rules, see [Inheritance](../../fundamentals/object-oriented/inheritance.md) and the [Virtual, sealed, override, and abstract accessors](~/_csharpstandard/standard/classes.md#1576-virtual-sealed-override-and-abstract-accessors) section of the C# specification. To correct these errors, apply one of the following changes based on the specific diagnostic:

- Ensure the member you're overriding is a property, not a field or method (**CS0544**). The `override` keyword on a property can only target a `virtual`, `abstract`, or `override` property in a base class. To shadow a non-property member with a property, use the `new` keyword instead of `override`.
- Override only the accessors that exist in the base class property declaration (**CS0545**, **CS0546**). You can't override a property accessor that isn't present or accessible in the base class because there's no virtual method to override. If the base class property has only a `get` accessor, you can't add a `set` accessor through an override. Either add the missing accessor to the base class and mark it `virtual`, or use `new` to hide the base class property with a new property definition.
- Match the type of the overriding property to the type of the overridden member (**CS1715**). Read-only (`get`-only) properties support covariant return types beginning with C# 9, so the override can return a more derived type. However, properties that have a `set` or `init` accessor require an exact type match because the setter accepts values of the declared type. If you need a different type on a property with a setter, change the property type in the derived class to match the base class declaration, or remove the setter and use a covariant return type instead.
- Include all accessors from the base property when overriding with an auto-implemented property (**CS8080**). Auto-implemented properties generate both storage and accessor implementations, so they must override all accessors present in the base class. If the base property has both `get` and `set`, the auto-implemented override must also have both. To override only specific accessors, implement the property with explicit accessor bodies and an explicit backing field instead of using auto-implementation.

For more information, see [Inheritance](../../fundamentals/object-oriented/inheritance.md), [Properties](../../programming-guide/classes-and-structs/properties.md), and [Using Properties](../../programming-guide/classes-and-structs/using-properties.md).

## Field-backed properties

- **CS9258**: *In this language version, the '`field`' keyword binds to a synthesized backing field for the property. To avoid generating a synthesized backing field, and to refer to the existing member, use '`this.field`' or '`@field`' instead.*
- **CS9263**: *A partial property cannot have an initializer on both the definition and implementation.*
- **CS9264**: *Non-nullable property 'property' must contain a non-null value when exiting constructor. Consider adding the 'required' modifier, or declaring the property as nullable, or safely handling the case where '`field`' is null in the '`get`' accessor.*
- **CS9266**: *The 'accessor' accessor of property 'property' should use '`field`' because the other accessor is using it.*
- **CS9273**: *In this language version, '`field`' is a keyword within a property accessor. Rename the variable or use the identifier '`@field`' instead.*

To correct field-backed property errors, apply one of the following changes based on the specific diagnostic:

- Rename any variable named `field` to a different identifier, or use the `@field` escape syntax to refer to your variable (**CS9258**, **CS9273**). This correction is necessary because `field` is a contextual keyword within property accessors in C# 13 and later, where it refers to the compiler-synthesized backing field. If you want to access an existing member named `field` instead of the synthesized backing field, qualify it with `this.field` to disambiguate the reference.
- Remove the initializer from either the partial property definition or the implementation, keeping only one (**CS9263**). This correction is required because allowing initializers in both locations would create ambiguity about which value should be used and could lead to the backing field being initialized twice with potentially different values.
- Add the `[field: MaybeNull, AllowNull]` attributes to the property declaration to indicate that the backing field should be treated as nullable (**CS9264**). This correction aligns the nullability expectations between the property type and the compiler-synthesized backing field, resolving the mismatch where the property is declared as non-nullable but the `field` keyword usage suggests it could be null. Alternatively, change the property type to nullable, add the `required` modifier to ensure initialization, or initialize the property in the constructor.
- Consistently use either the `field` keyword in both accessors or use an explicit backing field in both accessors (**CS9266**). This correction prevents potential bugs where one accessor modifies the compiler-synthesized backing field while the other accessor modifies a different storage location, leading to inconsistent property behavior.

For more information, see [field keyword](../../programming-guide/classes-and-structs/properties.md#field-backed-properties) and [Partial properties](../../programming-guide/classes-and-structs/partial-classes-and-methods.md#partial-members).

## Readonly properties

- **CS0200**: *Property or indexer 'property' cannot be assigned to -- it is read only*
- **CS8341**: *Auto-implemented instance properties in readonly structs must be readonly.*
- **CS8657**: *Static member 'member' cannot be marked 'readonly'.*
- **CS8658**: *Auto-implemented 'set' accessor 'accessor' cannot be marked 'readonly'.*
- **CS8659**: *Auto-implemented property 'property' cannot be marked 'readonly' because it has a 'set' accessor.*
- **CS8660**: *Cannot specify 'readonly' modifiers on both property or indexer 'property' and its accessor. Remove one of them.*
- **CS8661**: *Cannot specify 'readonly' modifiers on both accessors of property or indexer 'property'. Instead, put a 'readonly' modifier on the property itself.*
- **CS8664**: *'property': 'readonly' can only be used on accessors if the property or indexer has both a get and a set accessor*

To correct readonly property errors, apply one of the following changes based on the specific diagnostic:

- Add a `set` or `init` accessor to the property to make it writable (**CS0200**). This correction is necessary because properties without set accessors are read-only and can only be assigned in the declaring type's constructor or field initializer. If you need the property to be set during object initialization but immutable afterward, use an `init` accessor instead of a `set` accessor. If the property should remain read-only, move the assignment into the constructor where initialization is permitted, or reconsider whether the assignment is necessary at all.
- Mark auto-implemented instance properties as `readonly` when you declare them within a `readonly struct` (**CS8341**). This correction enforces the immutability contract of the containing struct, ensuring that all instance members respect the `readonly` guarantee. If the property needs to be mutable, either remove the `readonly` modifier from the struct declaration or implement the property with an explicit backing field and accessor bodies that don't modify instance state.
- Remove the `readonly` modifier from static property or accessor declarations (**CS8657**). This correction is required because the `readonly` modifier only applies to instance members of structs to indicate they don't modify instance state, and static members don't have instance state to protect. If you need a read-only static property, simply omit the `set` accessor rather than using the `readonly` modifier.
- Remove the `readonly` modifier from auto-implemented `set` accessors, or apply it to the `get` accessor only (**CS8658**). This correction is necessary because `set` accessors inherently modify state, which contradicts the purpose of the `readonly` modifier that guarantees no modification of instance state. If you need a property that can be set during initialization but is read-only afterward, use an `init` accessor instead of a `set` accessor.
- Remove the `readonly` modifier from the property declaration when the property has a `set` accessor (**CS8659**). This correction is required because properties with `set` accessors can modify instance state, which violates the `readonly` guarantee. If you need initialization-time setting only, replace the `set` accessor with an `init` accessor, or remove the `set` accessor entirely to make the property truly read-only.
- Place the `readonly` modifier either on the property declaration or on individual accessors, but not both (**CS8660**, **CS8661**). This correction prevents redundant modifier declarations that could create confusion about which modifier takes precedence. If you want to mark specific accessors as `readonly`, remove the modifier from the property declaration and place it only on the accessors. Alternatively, if all accessors should be `readonly`, mark the property itself rather than individual accessors.
- Ensure both `get` and `set` accessors are present when marking individual accessors as `readonly` (**CS8664**). This correction is necessary because the `readonly` modifier on individual accessors distinguishes between accessors that modify state and those that don't, which only makes sense when both accessor types exist. If the property has only a `get` accessor, mark the entire property as `readonly` instead of the individual accessor.

For more information, see [readonly instance members](../builtin-types/struct.md#readonly-instance-members), [init keyword](../keywords/init.md), and [Properties](../../programming-guide/classes-and-structs/properties.md).

## Init-only properties

- **CS8852**: *Init-only property or indexer 'property' can only be assigned in an object initializer, or on 'this' or 'base' in an instance constructor or an 'init' accessor.*
- **CS8853**: *'member' must match by init-only of overridden member 'member'*
- **CS8855**: *Accessors 'accessor' and 'accessor' should both be init-only or neither*
- **CS8856**: *The 'init' accessor is not valid on static members*
- **CS8903**: *'init' accessors cannot be marked 'readonly'. Mark 'property' readonly instead.*

These errors enforce the rules for the `init` accessor, which enables immutable object initialization. For the full rules, see [init keyword](../keywords/init.md). To correct these errors, apply one of the following changes based on the specific diagnostic:

- Move assignments to init-only properties into an object initializer, a constructor, or an `init` accessor (**CS8852**). Init-only properties can't be assigned after object construction completes. Assign the value in the constructor body, an `init` accessor, or an object initializer expression (`new MyType { Property = value }`). If you need to assign the property after construction, change the `init` accessor to a `set` accessor.
- Match the `init` or `set` accessor kind when overriding a property (**CS8853**). If the base class property uses an `init` accessor, the overriding property must also use `init`. Similarly, if the base uses `set`, the override must use `set`. This consistency ensures that the immutability contract established by the base type is preserved in derived types.
- Use the same accessor kind (`init` or `set`) on both accessors in an explicit interface implementation (**CS8855**). When a type explicitly implements two interfaces that declare the same property, both accessor implementations must agree: either both use `init` or both use `set`.
- Remove the `init` accessor from static property declarations, or change it to a `set` accessor (**CS8856**). The `init` accessor is designed for instance initialization patterns tied to object construction, and static members don't participate in object initialization. Use a `set` accessor for mutable static properties, or remove the setter entirely for read-only static properties.
- Remove the `readonly` modifier from the `init` accessor (**CS8903**). The `readonly` modifier on a struct member guarantees that the member doesn't mutate the struct instance. Because an `init` accessor assigns to instance state, it inherently mutates the struct and can't be marked `readonly`. To make the `get` accessor `readonly`, apply the `readonly` modifier to the `get` accessor only.

For more information, see [init keyword](../keywords/init.md) and [Object and Collection Initializers](../../programming-guide/classes-and-structs/object-and-collection-initializers.md).

## Property initializers

- **CS8050**: *Only auto-implemented properties, or properties that use the 'field' keyword, can have initializers.*
- **CS8051**: *Auto-implemented properties must have get accessors.*
- **CS8053**: *Instance properties in interfaces cannot have initializers.*

To correct property initializer errors, apply one of the following changes based on the specific diagnostic:

- Convert the property to use auto-implemented syntax by removing the accessor bodies and letting the compiler generate the backing field (**CS8050**). This correction is needed because only properties with compiler-managed storage can have initializers, ensuring the initialization occurs before any accessor logic executes. Alternatively, modify the accessor implementations to use the `field` keyword to access the compiler-synthesized backing field. This approach enables the initializer while maintaining custom accessor logic. If neither approach is suitable, remove the initializer and assign the value in a constructor instead, where you have full control over the initialization sequence.
- Add a `get` accessor to the auto-implemented property to enable reading the initialized value (**CS8051**). This correction is required because initializers set a value that must be retrievable, and a write-only property violates this fundamental expectation of property initialization. If you truly need a write-only property, implement the accessors explicitly with a backing field and assign the field directly in a constructor rather than using a property initializer.
- Remove the initializer from interface property declarations (**CS8053**). This correction is necessary because interfaces define contracts for implementing types rather than providing concrete implementations with initial values. If you need to provide default values, implement the property in a class that implements the interface, or use default interface methods (available in C# 8.0 and later) to supply a default implementation.

For more information, see [Properties](../../programming-guide/classes-and-structs/properties.md), [Auto-Implemented Properties](../../programming-guide/classes-and-structs/auto-implemented-properties.md), and [field keyword](../../programming-guide/classes-and-structs/properties.md#field-backed-properties).

## Required members

- **CS9029**: *Types and aliases cannot be named 'required'.*
- **CS9030**: *'member' must be required because it overrides required member 'member'*
- **CS9031**: *Required member 'member' cannot be hidden by 'member'.*
- **CS9032**: *Required member cannot be less visible or have a setter less visible than the containing type.*
- **CS9033**: *Do not use '`System.Runtime.CompilerServices.RequiredMemberAttribute'`. Use the 'required' keyword on required fields and properties instead.*
- **CS9034**: *Required member must be settable.*
- **CS9035**: *Required member must be set in the object initializer or attribute constructor.*
- **CS9036**: *Required member 'memberName' must be assigned a value, it cannot use a nested member or collection initializer.*
- **CS9037**: *The required members list for 'type' is malformed and cannot be interpreted.*
- **CS9038**: *The required members list for the base type 'type' is malformed and cannot be interpreted. To use this constructor, apply the '`SetsRequiredMembers`' attribute.*
- **CS9039**: *This constructor must add '`SetsRequiredMembers`' because it chains to a constructor that has that attribute.*
- **CS9040**: *Type cannot satisfy the '`new()`' constraint on parameter in the generic type or method because it has required members.*
- **CS9042**: *Required member should not be attributed with '`ObsoleteAttribute`' unless the containing type is obsolete or all constructors are obsolete.*
- **CS9045**: *Required members are not allowed on the top level of a script or submission.*

To correct required member errors, apply one of the following changes based on the specific diagnostic:

- Avoid using `required` as a type or alias name (**CS9029**). This correction is necessary because `required` is a contextual keyword in C# 11 and later, and using it as a type name creates ambiguity in code where the keyword might appear.
- Ensure derived members maintain the `required` modifier when overriding required members (**CS9030**). This correction enforces the contract established by the base class, guaranteeing that all derived types maintain the same initialization requirements. Avoid hiding required members with non-required members in derived classes (**CS9031**), as this action breaks the initialization contract that consumers expect from the base type.
- Make required members at least as visible as their containing type, and ensure property setters are also sufficiently visible (**CS9032**). This correction prevents situations where a type is publicly accessible but its required members can't be initialized from all contexts where the type is constructed.
- Use the `required` keyword instead of manually applying <xref:System.Runtime.CompilerServices.RequiredMemberAttribute> (**CS9033**). This correction ensures the compiler generates the correct metadata and enforces all required member rules, which manual attribute application might not do correctly.
- Ensure required members have set accessors or are otherwise settable (**CS9034**). This correction is necessary because required members must be initialized during object creation, which requires write access. When creating instances, initialize required members directly in object initializers (**CS9035**, **CS9036**). You must assign a value to each required member rather than using nested member initializers or collection initializers, because the required member itself must be set before accessing its properties.
- Apply the `SetsRequiredMembers` attribute to constructors that initialize all required members in their bodies (**CS9038**, **CS9039**). This correction informs the compiler that the constructor fulfills the required member contract, allowing object creation without object initializers. If a constructor chains to another constructor with `SetsRequiredMembers`, it must also have the attribute.
- Avoid using required members in types that must satisfy the `new()` constraint (**CS9040**), as the parameterless constructor can't guarantee required member initialization without an object initializer. Don't mark required members as obsolete unless the containing type or all constructors are obsolete (**CS9042**), to prevent situations where members are required but their use is discouraged. Required members aren't allowed in top-level statements or script contexts (**CS9045**) because these contexts don't support the object initialization syntax needed to set required members.

For more information, see the [required modifier](../keywords/required.md) reference article and [Object and Collection Initializers](../../programming-guide/classes-and-structs/object-and-collection-initializers.md) guide.

## Ref-returning properties

- **CS8145**: *Auto-implemented properties cannot return by reference*
- **CS8147**: *Properties which return by reference cannot have set accessors*

To correct ref-returning property errors, apply one of the following changes based on the specific diagnostic:

- Implement the property explicitly with a backing field and use the `ref` keyword in the `get` accessor's return expression (**CS8145**). This correction is necessary because auto-implemented properties generate a private backing field that the compiler manages internally. Returning a reference to a private field would expose internal storage that callers shouldn't access directly. To create a ref-returning property, declare an explicit field and return it with `=> ref backingField` syntax. Alternatively, if you don't need to return a reference to allow direct modification of the storage, remove the `ref` modifier from the property declaration.
- Remove the `set` accessor from ref-returning properties (**CS8147**). This correction is required because a ref-returning property already provides both read and write access through the returned reference itself. Callers can directly modify the value through the reference without needing a separate setter method. Including a `set` accessor would create two different mechanisms for modifying the same storage, which is redundant and could lead to confusion about which modification path should be used.

For more information, see [ref returns and ref locals](../statements/jump-statements.md#ref-returns) and [Properties](../../programming-guide/classes-and-structs/properties.md).

---
title: Resolve errors related to constructor declarations
description: These compiler errors and warnings indicate violations when declaring constructors in classes or structs, including records. This article provides guidance on resolving those errors.
f1_keywords:
 - "CS0132"
 - "CS0514"
 - "CS0515"
 - "CS0516"
 - "CS0517"
 - "CS0522"
 - "CS0526"
 - "CS0568"
 - "CS0573"
 - "CS0710"
 - "CS0768"
 - "CS0824" # WRN_ExternCtorNoImplementation
 - "CS1018" # ERR_ThisOrBaseExpected
 - "CS8054" # ERR_EnumsCantContainDefaultConstructor
 - "CS8091" # ERR_ExternHasConstructorInitializer
 - "CS8358" # ERR_AttributeCtorInParameter
 - "CS8861"
 - "CS8862" # ERR_UnexpectedOrMissingConstructorInitializerInRecord
 - "CS8867" # ERR_NoCopyConstructorInBaseType
 - "CS8868" # ERR_CopyConstructorMustInvokeBaseCopyConstructor 
 - "CS8878" # ERR_CopyConstructorWrongAccessibility
 - "CS8910" # ERR_RecordAmbigCtor
 - "CS8958" # ERR_NonPublicParameterlessStructConstructor
 - "CS8982" # ERR_RecordStructConstructorCallsDefaultConstructor
 - "CS8983" # ERR_StructHasInitializersAndNoDeclaredConstructor
 - "CS9018" # WRN_UseDefViolationPropertySupportedVersion - Auto-implemented property '{0}' is read before being explicitly assigned, causing a preceding implicit assignment of 'default'.
 - "CS9019" # WRN_UseDefViolationFieldSupportedVersion - Field '{0}' is read before being explicitly assigned, causing a preceding implicit assignment of 'default'.
 - "CS9020" # WRN_UseDefViolationThisSupportedVersion - The 'this' object is read before all of its fields have been assigned, causing preceding implicit assignments of 'default' to non-explicitly assigned fields.
 - "CS9021" # WRN_UnassignedThisAutoPropertySupportedVersion - Control is returned to caller before auto-implemented property '{0}' is explicitly assigned, causing a preceding implicit assignment of 'default'.
 - "CS9022" # WRN_UnassignedThisSupportedVersion - Control is returned to caller before field '{0}' is explicitly assigned, causing a preceding implicit assignment of 'default'.
 - "CS9105" # ERR_InvalidPrimaryConstructorParameterReference - Cannot use primary constructor parameter '{0}' in this context.
 - "CS9106" # ERR_AmbiguousPrimaryConstructorParameterAsColorColorReceiver - Identifier '{0}' is ambiguous between type '{1}' and parameter '{2}' in this context.
 - "CS9107" # WRN_CapturedPrimaryConstructorParameterPassedToBase - Parameter '{0}' is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.
 - "CS9108" # ERR_AnonDelegateCantUseRefLike - Cannot use parameter '{0}' that has ref-like type inside an anonymous method, lambda expression, query expression, or local function
 - "CS9109" # ERR_UnsupportedPrimaryConstructorParameterCapturingRef - Cannot use ref, out, or in primary constructor parameter '{0}' inside an instance member
 - "CS9110" # ERR_UnsupportedPrimaryConstructorParameterCapturingRefLike - Cannot use primary constructor parameter '{0}' that has ref-like type inside an instance member
 - "CS9111" # ERR_AnonDelegateCantUseStructPrimaryConstructorParameterInMember - Anonymous methods, lambda expressions, query expressions, and local functions inside an instance member of a struct cannot access primary constructor parameter
 - "CS9112" # ERR_AnonDelegateCantUseStructPrimaryConstructorParameterCaptured - Anonymous methods, lambda expressions, query expressions, and local functions inside a struct cannot access primary constructor parameter also used inside an instance member
 - "CS9113" # WRN_UnreadPrimaryConstructorParameter - Parameter '{0}' is unread.
 - "CS9114" # ERR_AssgReadonlyPrimaryConstructorParameter - A primary constructor parameter of a readonly type cannot be assigned to (except in init-only setter of the type or a variable initializer)
 - "CS9115" # ERR_RefReturnReadonlyPrimaryConstructorParameter - A primary constructor parameter of a readonly type cannot be returned by writable reference
 - "CS9116" # ERR_RefReadonlyPrimaryConstructorParameter - A primary constructor parameter of a readonly type cannot be used as a ref or out value (except in init-only setter of the type or a variable initializer)
 - "CS9117" # ERR_AssgReadonlyPrimaryConstructorParameter2 - Members of primary constructor parameter '{0}' of a readonly type cannot be modified (except in init-only setter of the type or a variable initializer)
 - "CS9118" # ERR_RefReturnReadonlyPrimaryConstructorParameter2 - Members of primary constructor parameter '{0}' of a readonly type cannot be returned by writable reference
 - "CS9119" # ERR_RefReadonlyPrimaryConstructorParameter2 - Members of primary constructor parameter '{0}' of a readonly type cannot be used as a ref or out value (except in init-only setter of the type or a variable initializer)
 - "CS9120" # ERR_RefReturnPrimaryConstructorParameter - Cannot return primary constructor parameter '{0}' by reference.
 - "CS9121" # ERR_StructLayoutCyclePrimaryConstructorParameter - Struct primary constructor parameter '{0}' of type '{1}' causes a cycle in the struct layout
 - "CS9122" # ERR_UnexpectedParameterList - Unexpected parameter list. Test: Interfaces can't have primary constructors.
 - "CS9124"
 - "CS9136"
 - "CS9179"
helpviewer_keywords:
 - "CS0132"
 - "CS0514"
 - "CS0515"
 - "CS0516"
 - "CS0517"
 - "CS0522"
 - "CS0526"
 - "CS0568"
 - "CS0573"
 - "CS0710"
 - "CS0768"
 - "CS0824"
 - "CS1018"
 - "CS8054"
 - "CS8091"
 - "CS8358"
 - "CS8861"
 - "CS8862"
 - "CS8867"
 - "CS8868"
 - "CS8878"
 - "CS8910"
 - "CS8958"
 - "CS8982"
 - "CS8983"
 - "CS9018"
 - "CS9019"
 - "CS9020"
 - "CS9021"
 - "CS9022"
 - "CS9105"
 - "CS9106"
 - "CS9107"
 - "CS9108"
 - "CS9109"
 - "CS9110"
 - "CS9111"
 - "CS9112"
 - "CS9113"
 - "CS9114"
 - "CS9115"
 - "CS9116"
 - "CS9117"
 - "CS9118"
 - "CS9119"
 - "CS9120"
 - "CS9121"
 - "CS9122"
 - "CS9124"
 - "CS9136"
 - "CS9179"
ms.date: 01/28/2026
---
# Resolve errors and warnings in constructor declarations

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0132**](#static-constructors): *'constructor': a static constructor must be parameterless.*
- [**CS0514**](#static-constructors): *static constructor cannot have an explicit 'this' or 'base' constructor call.*
- [**CS0515**](#static-constructors): *access modifiers are not allowed on static constructors.*
- [**CS0516**](#constructor-calls-with-base-and-this): *Constructor 'constructor' can not call itself.*
- [**CS0517**](#constructor-calls-with-base-and-this): *'class' has no base class and cannot call a base constructor.*
- [**CS0522**](#constructor-calls-with-base-and-this): *structs cannot call base class constructors.*
- [**CS0526**](#constructor-declaration): *Interfaces cannot contain constructors.*
- [**CS0568**](#constructors-in-struct-types): *Structs cannot contain explicit parameterless constructors.*
- [**CS0573**](#constructors-in-struct-types): *'field declaration': cannot have instance field initializers in structs.*
- [**CS0710**](#constructor-declaration): *Static classes cannot have instance constructors.*
- [**CS0768**](#constructor-calls-with-base-and-this): *Constructor cannot call itself through another constructor.*
- [**CS1018**](#constructor-calls-with-base-and-this): *Keyword 'this' or 'base' expected.*
- [**CS8054**](#constructor-declaration): *Enums cannot contain explicit parameterless constructors.*
- [**CS8091**](#constructor-declaration): *cannot be extern and have a constructor initializer.*
- [**CS8861**](#primary-constructor-declaration): *Unexpected argument list.*
- [**CS8862**](#primary-constructor-declaration): *A constructor declared in a type with parameter list must have 'this' constructor initializer.*
- [**CS8358**](#constructor-declaration): *Cannot use attribute constructor because it has 'in' parameters.*
- [**CS8867**](#records-and-copy-constructors): *No accessible copy constructor found in base type '{0}'.*
- [**CS8868**](#records-and-copy-constructors): *A copy constructor in a record must call a copy constructor of the base, or a parameterless object constructor if the record inherits from object.*
- [**CS8878**](#records-and-copy-constructors): *A copy constructor '{0}' must be public or protected because the record is not sealed.*
- [**CS8910**](#records-and-copy-constructors): *The primary constructor conflicts with the synthesized copy constructor.*
- [**CS8958**](#constructors-in-struct-types): *The parameterless struct constructor must be 'public'.*
- [**CS8982**](#constructors-in-struct-types): *A constructor declared in a 'struct' with parameter list must have a 'this' initializer that calls the primary constructor or an explicitly declared constructor.*
- [**CS8983**](#constructors-in-struct-types): *A 'struct' with field initializers must include an explicitly declared constructor.*
- [**CS9105**](#primary-constructor-declaration): *Cannot use primary constructor parameter in this context.*
- [**CS9106**](#primary-constructor-declaration): *Identifier is ambiguous between type and parameter in this context.*
- [**CS9108**](#primary-constructor-declaration): *Cannot use parameter that has ref-like type inside an anonymous method, lambda expression, query expression, or local function.*
- [**CS9109**](#primary-constructor-declaration): *Cannot use `ref`, `out`, or `in` primary constructor parameter inside an instance member.*
- [**CS9110**](#primary-constructor-declaration): *Cannot use primary constructor parameter that has ref-like type inside an instance member.*
- [**CS9111**](#primary-constructor-declaration): *Anonymous methods, lambda expressions, query expressions, and local functions inside an instance member of a struct cannot access primary constructor parameter.*
- [**CS9112**](#primary-constructor-declaration): *Anonymous methods, lambda expressions, query expressions, and local functions inside a struct cannot access primary constructor parameter also used inside an instance member.*
- [**CS9114**](#primary-constructor-declaration): *A primary constructor parameter of a readonly type cannot be assigned to (except in init-only setter of the type or a variable initializer).*
- [**CS9115**](#primary-constructor-declaration): *A primary constructor parameter of a readonly type cannot be returned by writable reference.*
- [**CS9116**](#primary-constructor-declaration): *A primary constructor parameter of a readonly type cannot be used as a ref or out value (except in init-only setter of the type or a variable initializer).*
- [**CS9117**](#primary-constructor-declaration): *Members of primary constructor parameter of a readonly type cannot be modified (except in init-only setter of the type or a variable initializer).*
- [**CS9118**](#primary-constructor-declaration): *Members of primary constructor parameter of a readonly type cannot be returned by writable reference.*
- [**CS9119**](#primary-constructor-declaration): *Members of primary constructor parameter of a readonly type cannot be used as a `ref` or `out` value (except in init-only setter of the type or a variable initializer).*
- [**CS9120**](#primary-constructor-declaration): *Cannot return primary constructor parameter by reference.*
- [**CS9121**](#primary-constructor-declaration): *Struct primary constructor parameter of type causes a cycle in the struct layout.*
- [**CS9122**](#primary-constructor-declaration): *Unexpected parameter list.*
- [**CS9136**](#primary-constructor-declaration): *Cannot use primary constructor parameter of type inside an instance member.*

In addition, the following warnings are covered in this article:

- [**CS0824**](#constructor-declaration): *Constructor 'name' is marked external.*
- [**CS9107**](#primary-constructor-declaration): *Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.*
- [**CS9113**](#primary-constructor-declaration): *Parameter is unread.*
- [**CS9124**](#primary-constructor-declaration): *Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.*
- [**CS9179**](#primary-constructor-declaration): *Primary constructor parameter is shadowed by a member from base*
- [**CS9018**](#constructors-in-struct-types): *Auto-implemented property is read before being explicitly assigned, causing a preceding implicit assignment of 'default'.*
- [**CS9019**](#constructors-in-struct-types): *Field is read before being explicitly assigned, causing a preceding implicit assignment of 'default'.*
- [**CS9020**](#constructors-in-struct-types): *The 'this' object is read before all of its fields have been assigned, causing preceding implicit assignments of 'default' to non-explicitly assigned fields.*
- [**CS9021**](#constructors-in-struct-types): *Control is returned to caller before auto-implemented property is explicitly assigned, causing a preceding implicit assignment of 'default'.*
- [**CS9022**](#constructors-in-struct-types): *Control is returned to caller before field is explicitly assigned, causing a preceding implicit assignment of 'default'.*

## Static constructors

- **CS0132**: *'constructor': a static constructor must be parameterless.*
- **CS0514**: *Static constructor cannot have an explicit 'this' or 'base' constructor call.*
- **CS0515**: *Access modifiers are not allowed on static constructors.*

Static constructors initialize static data for a type. For more information, see [Static Constructors](../../programming-guide/classes-and-structs/static-constructors.md).

To correct these errors, ensure your static constructor declaration follows these rules:

- Remove any parameters from the static constructor declaration, because a static constructor must be parameterless (**CS0132**). If you need to pass initialization values, consider using static fields or properties that are set before the static constructor runs.
- Remove any access modifiers such as `public`, `protected`, `private`, or `internal` from the static constructor, because the runtime controls when the static constructor executes and access modifiers aren't meaningful (**CS0515**).
- Remove any `: base()` or `: this()` constructor initializer calls from the static constructor, because static constructors can't chain to other constructors (**CS0514**). The runtime automatically invokes the base class static constructor if one exists.

## Constructor declaration

- **CS0526**: *Interfaces cannot contain constructors.*
- **CS0710**: *Static classes cannot have instance constructors.*
- **CS8054**: *Enums cannot contain explicit parameterless constructors.*
- **CS8358**: *Cannot use attribute constructor because it has 'in' parameters.*
- **CS8091**: *A constructor cannot be extern and have a constructor initializer.*

Constructors are allowed only in `class` and `struct` types, including `record class` and `record struct` types. For more information, see [Instance Constructors](../../programming-guide/classes-and-structs/instance-constructors.md).

To correct these errors, consider the following guidance:

Move the constructor to a `class` or `struct` type, because constructors can't be declared in `interface` or `enum` types (**CS0526**, **CS8054**). Interfaces define contracts but don't provide initialization logic, and enum types have their values defined at compile time.

Remove instance constructors from static classes, because static classes can't be instantiated and therefore can't have instance constructors (**CS0710**). If you need initialization logic, use a static constructor instead.

Change `in` parameters to pass-by-value parameters in attribute constructors, because attribute constructors don't support `in` parameter modifiers (**CS8358**). Attributes are instantiated by the runtime using reflection, which doesn't support the `in` modifier.

Remove the `: base()` or `: this()` constructor initializer from an `extern` constructor, because extern constructors can't chain to other constructors (**CS8091**). The implementation of an extern constructor is provided externally, so constructor chaining isn't possible.

The following warning can be generated for constructor declarations:

- **CS0824**: *Constructor is marked external.*

When a constructor is marked `extern`, the compiler can't verify that an implementation exists. To suppress this warning, either provide a non-extern implementation or ensure the external implementation is correctly linked.

## Constructors in struct types

- **CS0568**: *Structs cannot contain explicit parameterless constructors.*
- **CS0573**: *'field declaration': cannot have instance field initializers in structs.*
- **CS8958**: *The parameterless struct constructor must be 'public'.*
- **CS8982**: *A constructor declared in a 'struct' with parameter list must have a 'this' initializer that calls the primary constructor or an explicitly declared constructor.*
- **CS8983**: *A 'struct' with field initializers must include an explicitly declared constructor.*

Struct types have specific rules for constructors and field initialization. For more information, see the [Struct initialization and default values](../builtin-types/struct.md#struct-initialization-and-default-values) section of the [Structure types](../builtin-types/struct.md) article.

To correct these errors, consider the following guidance:

- Upgrade to C# 10 or later if you encounter **CS0568** or **CS0573**, because these errors are generated only in older versions of C#. Modern C# allows explicit parameterless constructors and field initializers in structs.
- Add the `public` access modifier to any parameterless struct constructor, because parameterless struct constructors must be public to ensure the `default` expression and array allocation can properly initialize struct instances (**CS8958**).
- Add a `: this(...)` initializer to explicitly declared constructors in a struct that has a primary constructor, because all non-parameterless constructors must chain to the primary constructor or another explicitly declared constructor to ensure consistent initialization (**CS8982**).
- Declare an explicit constructor when your struct uses field initializers, because the compiler requires an explicit constructor to ensure field initializers are invoked (**CS8983**). This constructor can be a parameterless constructor with an empty body.

The following warnings indicate that a field or property isn't explicitly assigned before being read or before control returns to the caller:

- **CS9018**: *Auto-implemented property is read before being explicitly assigned, causing a preceding implicit assignment of 'default'.*
- **CS9019**: *Field is read before being explicitly assigned, causing a preceding implicit assignment of 'default'.*
- **CS9020**: *The 'this' object is read before all of its fields have been assigned, causing preceding implicit assignments of 'default' to non-explicitly assigned fields.*
- **CS9021**: *Control is returned to caller before auto-implemented property is explicitly assigned, causing a preceding implicit assignment of 'default'.*
- **CS9022**: *Control is returned to caller before field is explicitly assigned, causing a preceding implicit assignment of 'default'.*

To silence these warnings, explicitly assign all fields and auto-implemented properties before reading them or before control returns from the constructor (**CS9018**, **CS9019**, **CS9020**, **CS9021**, **CS9022**). When unassigned members are read, the compiler implicitly assigns `default` to them, which may not be the intended behavior.

## Constructor calls with `base` and `this`

- **CS0516**: *Constructor can not call itself.*
- **CS0517**: *'class' has no base class and cannot call a base constructor.*
- **CS0522**: *Structs cannot call base class constructors.*
- **CS0768**: *Constructor cannot call itself through another constructor.*
- **CS1018**: *Keyword 'this' or 'base' expected.*

Constructor initializers allow one constructor to call another using `: this()` or `: base()`. For more information, see [Using Constructors](../../programming-guide/classes-and-structs/using-constructors.md).

To correct these errors, consider the following guidance:

- Break any circular constructor call chains, because a constructor can't call itself either directly or indirectly through another constructor (**CS0516**, **CS0768**). Ensure that constructor chaining eventually terminates at a constructor that doesn't call another constructor in the same type.
- Remove the `: base()` initializer from constructors in struct types or from constructors in <xref:System.Object?displayProperty=nameWithType>, because these types have no base class constructor to call (**CS0517**, **CS0522**). Struct types implicitly inherit from <xref:System.ValueType?displayProperty=nameWithType>, but you can't explicitly call its constructor.
- Complete the constructor initializer or remove the colon (`:`) from the constructor declaration, because when a colon follows a constructor signature, the compiler expects either `this()` or `base()` (**CS1018**). Either add the appropriate constructor call or remove the colon entirely if no chaining is intended.

## Records and copy constructors

- **CS8867**: *No accessible copy constructor found in base type.*
- **CS8868**: *A copy constructor in a record must call a copy constructor of the base, or a parameterless object constructor if the record inherits from object.*
- **CS8878**: *A copy constructor must be public or protected because the record is not sealed.*
- **CS8910**: *The primary constructor conflicts with the synthesized copy constructor.*
In a derived record type, your explicit copy constructor must call the base type's copy constructor using the `: this()` initializer. If the record directly inherits from <xref:System.Object?displayProperty=nameWithType>, it can call the parameterless object constructor instead (**CS8868**).

[Records](../builtin-types/record.md) include a compiler-synthesized [copy constructor](../builtin-types/record.md#nondestructive-mutation). You can write an explicit copy constructor, but it must meet specific requirements. The compiler issues errors when record copy constructors violate these requirements:

- The base type must have an accessible copy constructor. All `record` types have a copy constructor. Ensure the base type is a `record`, or add an accessible copy constructor to it (**CS8867**).
- In a derived record type, your explicit copy constructor must call the base type's copy constructor using the `: this()` initializer. If the record directly inherits from <xref:System.Object?displayProperty=nameWithType>, it can call the parameterless object constructor instead (**CS8868**).
- Copy constructors must be `public` or `protected` unless the record type is [`sealed`](../keywords/sealed.md). Add the appropriate access modifier to the copy constructor (**CS8878**).
- If your explicit copy constructor has the same signature as the synthesized copy constructor, the definitions conflict. Remove your explicit copy constructor or modify its signature (**CS8910**).

## Primary constructor declaration

[Primary constructors](../../programming-guide/classes-and-structs/instance-constructors.md#primary-constructors) declare parameters directly in the type declaration. The compiler synthesizes a field to store a primary constructor parameter when it's used in members or field initializers. The compiler issues errors when code violates rules for primary constructor usage.

- **CS8861**: *Unexpected argument list.*
- **CS8862**: *A constructor declared in a type with parameter list must have 'this' constructor initializer.*
- **CS9105**: *Cannot use primary constructor parameter in this context.*
- **CS9106**: *Identifier is ambiguous between type and parameter in this context.*
- **CS9108**: *Cannot use parameter that has ref-like type inside an anonymous method, lambda expression, query expression, or local function.*
- **CS9109**: *Cannot use `ref`, `out`, or `in` primary constructor parameter inside an instance member.*
- **CS9110**: *Cannot use primary constructor parameter that has ref-like type inside an instance member.*
- **CS9111**: *Anonymous methods, lambda expressions, query expressions, and local functions inside an instance member of a struct cannot access primary constructor parameter.*
- **CS9112**: *Anonymous methods, lambda expressions, query expressions, and local functions inside a struct cannot access primary constructor parameter also used inside an instance member.*
- **CS9114**: *A primary constructor parameter of a readonly type cannot be assigned to (except in init-only setter of the type or a variable initializer).*
- **CS9115**: *A primary constructor parameter of a readonly type cannot be returned by writable reference.*
- **CS9116**: *A primary constructor parameter of a readonly type cannot be used as a `ref` or `out` value (except in init-only setter of the type or a variable initializer).*
- **CS9117**: *Members of primary constructor parameter of a readonly type cannot be modified (except in init-only setter of the type or a variable initializer).*
- **CS9118**: *Members of primary constructor parameter of a readonly type cannot be returned by writable reference.*
- **CS9119**: *Members of primary constructor parameter of a readonly type cannot be used as a `ref` or `out` value (except in init-only setter of the type or a variable initializer).*
- **CS9120**: *Cannot return primary constructor parameter by reference.*
- **CS9121**: *Struct primary constructor parameter of type causes a cycle in the struct layout.*
- **CS9122**: *Unexpected parameter list.*
- **CS9124**: *Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.*
- **CS9136**: *Cannot use primary constructor parameter of type inside an instance member.*

[Primary constructors](../../programming-guide/classes-and-structs/instance-constructors.md#primary-constructors) declare parameters directly in the type declaration. The compiler synthesizes a field to store a primary constructor parameter when it's used in members or field initializers. The compiler issues errors when code violates rules for primary constructor usage.

### Constructor chaining

When a type has a primary constructor, all other explicitly declared constructors must chain to it using `: this(...)`. Add a `: this(...)` initializer that passes appropriate arguments to the primary constructor (**CS8862**).

Remove a parameter list from the base type reference when the base type doesn't have a primary constructor. The syntax `class Derived : Base(args)` is only valid when `Base` has a primary constructor (**CS8861**). Similarly, remove a primary constructor parameter list from an `interface` declaration, because interfaces can't have primary constructors (**CS9122**).

### Parameter usage in base constructor calls

Primary constructor parameters can only be used in the base constructor call when passed as part of the primary constructor declaration. Move the parameter usage to the type declaration's base clause rather than using it in an explicitly declared constructor's `: base()` call (**CS9105**).

When a type and a primary constructor parameter have the same name, the reference is ambiguous. Rename either the type or the parameter to resolve the ambiguity (**CS9106**).

### Ref-like type parameters

Primary constructor parameters of `ref struct` type have restrictions on where they can be used. Move the parameter access out of lambda expressions, query expressions, or local functions (**CS9108**). In types that aren't `ref struct`, access `ref struct` parameters only in field initializers or the constructor body, not in instance members (**CS9110**, **CS9136**).

For `ref struct` types, primary constructor parameters with `in`, `ref`, or `out` modifiers can't be used in instance methods or property accessors. Copy the parameter value to a field in the constructor and use that field in instance members instead (**CS9109**).

### Struct type restrictions

In struct types, primary constructor parameters can't be captured in lambda expressions, query expressions, or local functions inside instance members. Copy the parameter to a local variable or field before using it in these contexts (**CS9111**, **CS9112**).

Primary constructor parameters in struct types can't be returned by reference. Store the value in a field and return that field by reference if needed (**CS9120**).

Ensure that a primary constructor parameter's type doesn't create a cycle in the struct layout. A struct can't contain a field of its own type either directly or indirectly (**CS9121**).

### Readonly struct restrictions

In `readonly struct` types, primary constructor parameters and their members can't be modified outside of init-only setters or variable initializers. Move assignments to field initializers or init-only property setters (**CS9114**, **CS9117**).

Primary constructor parameters and their members in `readonly struct` types can't be returned by writable reference. Return by `readonly ref` or by value instead (**CS9115**, **CS9118**).

Primary constructor parameters and their members in `readonly struct` types can't be passed as `ref` or `out` arguments. Pass them by value or as `in` arguments instead (**CS9116**, **CS9119**).

### Warnings for captured and shadowed parameters

The following warnings indicate potential issues with how primary constructor parameters are stored or accessed:

A parameter that's both passed to the base constructor and accessed in the derived type may be stored twice—once in the base class and once in the derived class. Consider whether both copies are necessary, or restructure your code to avoid the duplication (**CS9107**).

A primary constructor parameter that's never read isn't needed. Remove unused parameters from the primary constructor declaration (**CS9113**).

A parameter that's both captured by the enclosing type and used to initialize a field, property, or event may be stored twice. Consider using the captured parameter directly instead of initializing a separate member (**CS9124**).

When a base type member has the same name as a primary constructor parameter, the base member shadows the parameter. Rename the parameter to avoid confusion (**CS9179**).

---
title: Compiler Errors on partial type and member declarations
description: Use this article to diagnose and correct compiler errors and warnings when you write `partial` types and `partial` members.
f1_keywords:
  - "CS0260"
  - "CS0261"
  - "CS0262"
  - "CS0263"
  - "CS0264"
  - "CS0265"
  - "CS0267"
  - "CS0282"
  - "CS0501"
  - "CS0750"
  - "CS0751"
  - "CS0754"
  - "CS0755"
  - "CS0756"
  - "CS0757"
  - "CS0759"
  - "CS0761"
  - "CS0762"
  - "CS0763"
  - "CS0764"
  - "CS1067"
  - "CS8142"
  - "CS8663"
  - "CS8796"
  - "CS8795"
  - "CS8797"
  - "CS8798"
  - "CS8799"
  - "CS8800"
  - "CS8817"
  - "CS8818"
  - "CS8863"
  - "CS8988"
  - "CS9248"
  - "CS9249"
  - "CS9250"
  - "CS9251"
  - "CS9152"
  - "CS9253"
  - "CS9254"
  - "CS9255"
  - "CS9256"
  - "CS9257"
  - "CS9258"
  - "CS9263"
  - "CS9264"
  - "CS9266"
  - "CS9273"
  - "CS9275"
  - "CS9276"
  - "CS9277"
  - "CS9278"
  - "CS9279"
  - "CS9280"
helpviewer_keywords:
  - "CS0260"
  - "CS0261"
  - "CS0262"
  - "CS0263"
  - "CS0264"
  - "CS0265"
  - "CS0267"
  - "CS0282"
  - "CS0501"
  - "CS0750"
  - "CS0751"
  - "CS0754"
  - "CS0755"
  - "CS0756"
  - "CS0757"
  - "CS0759"
  - "CS0761"
  - "CS0762"
  - "CS0763"
  - "CS0764"
  - "CS1067"
  - "CS8142"
  - "CS8663"
  - "CS8796"
  - "CS8795"
  - "CS8797"
  - "CS8798"
  - "CS8799"
  - "CS8800"
  - "CS8817"
  - "CS8818"
  - "CS8863"
  - "CS8988"
  - "CS9248"
  - "CS9249"
  - "CS9250"
  - "CS9251"
  - "CS9152"
  - "CS9253"
  - "CS9254"
  - "CS9255"
  - "CS9256"
  - "CS9257"
  - "CS9258"
  - "CS9263"
  - "CS9266"
  - "CS9273"
  - "CS9275"
  - "CS9276"
  - "CS9277"
  - "CS9278"
  - "CS9279"
  - "CS9280"
ms.date: 12/12/2025
ai-usage: ai-assisted
---
# Errors and warnings related to `partial` type and `partial` member declarations

You can encounter the following errors related to `partial` type and `partial` member declarations:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0260**](#partial-types): *Missing partial modifier on declaration of type; another partial declaration of this type exists*
- [**CS0261**](#partial-types): *Partial declarations of type must be all classes, all structs, or all interfaces*
- [**CS0262**](#partial-types): *Partial declarations of type have conflicting accessibility modifiers*
- [**CS0263**](#partial-types): *Partial declarations of type must not specify different base classes*
- [**CS0264**](#partial-types): *Partial declarations of type must have the same type parameter names in the same order*
- [**CS0265**](#partial-types): *Partial declarations of type have inconsistent constraints for type parameter 'type parameter'*
- [**CS0267**](#partial-types): *The '`partial`' modifier can only appear immediately before '`class`', '`record`', '`struct`', '`interface`', or a method or property return type.*
- [**CS0282**](#partial-types): *There is no defined ordering between fields in multiple declarations of partial class or struct 'type'. To specify an ordering, all instance fields must be in the same declaration.*
- [**CS0501**](#partial-methods): *'member function' must declare a body because it is not marked `abstract`, `extern`, or `partial`*
- [**CS0750**](#partial-members): *A partial member cannot have the '`abstract`' modifier.*
- [**CS0751**](#partial-members): *A partial member must be declared in a partial `class` or partial `struct`*
- [**CS0754**](#partial-members): *A partial member may not explicitly implement an interface method.*
- [**CS0755**](#partial-methods): *Both partial method declarations must be extension methods or neither may be an extension method.*
- [**CS0756**](#partial-methods): *A partial method may not have multiple defining declarations.*
- [**CS0757**](#partial-methods): *A partial method may not have multiple implementing declarations.*
- [**CS0759**](#partial-methods): *No defining declaration found for implementing declaration of partial method.*
- [**CS0761**](#partial-methods): *Partial method declarations of `method<T>` have inconsistent type parameter constraints.*
- [**CS0762**](#partial-methods): *Cannot create delegate from method because it is a partial method without an implementing declaration*
- [**CS0763**](#partial-members): *Both partial method declarations must be `static` or neither may be `static`.*
- [**CS0764**](#partial-members): *Both partial method declarations must be `unsafe` or neither may be `unsafe`*
- [**CS1067**](#partial-methods): *Partial declarations must have the same type parameter names and variance modifiers in the same order.*
- [**CS8142**](#partial-members): *Both partial member declarations must use the same tuple element names.*
- [**CS8663**](#partial-members): *Both partial member declarations must be readonly or neither may be readonly*
- [**CS8796**](#partial-methods): *Partial method must have accessibility modifiers because it has a non-void return type.*
- [**CS8795**](#partial-methods): *Partial member must have an implementation part because it has accessibility modifiers.*
- [**CS8797**](#partial-methods): *Partial method  must have accessibility modifiers because it has '`out`' parameters.*
- [**CS8798**](#partial-methods): *Partial method must have accessibility modifiers because it has a '`virtual`', '`override`', '`sealed`', '`new`', or '`extern`' modifier.*
- [**CS8799**](#partial-members): *Both partial member declarations must have identical accessibility modifiers.*
- [**CS8800**](#partial-members): *Both partial member declarations must have identical combinations of `virtual`, `override`, `sealed`, and `new` modifiers.*
- [**CS8817**](#partial-methods): *Both partial method declarations must have the same return type.*
- [**CS8818**](#partial-members): *Partial member declarations must have matching `ref` return values.*
- [**CS8863**](#partial-types): *Only a single partial type declaration may have a parameter list*
- [**CS8988**](#partial-members): *The `scoped` modifier of parameter doesn't match partial definition.*
- [**CS9248**](#partial-properties): *Partial property must have an implementation part.*
- [**CS9249**](#partial-properties): *Partial property must have a definition part.*
- [**CS9250**](#partial-properties): *A partial property may not have multiple defining declarations, and cannot be an auto-property.*
- [**CS9251**](#partial-properties): *A partial property may not have multiple implementing declarations*
- [**CS9252**](#partial-properties): *Property accessor must be implemented because it is declared on the definition part*
- [**CS9253**](#partial-properties): *Property accessor does not implement any accessor declared on the definition part*
- [**CS9254**](#partial-properties): *Property accessor must match the definition part*
- [**CS9255**](#partial-properties): *Both partial property declarations must have the same type.*
- [**CS9256**](#partial-properties): *Partial property declarations have signature differences.*
- [**CS9257**](#partial-properties): *Both partial property declarations must be required or neither may be required*
- [**CS9275**](#partial-members): *Partial member  must have an implementation part.*
- [**CS9276**](#partial-members): *Partial member  must have a definition part.*
- [**CS9277**](#partial-members): *Partial member may not have multiple defining declarations.*
- [**CS9278**](#partial-members): *Partial member may not have multiple implementing declarations.*
- [**CS9279**](#partial-events-and-constructors): *Partial event cannot have initializer.*
- [**CS9280**](#partial-events-and-constructors): *Only the implementing declaration of a partial constructor can have an initializer.*

The following sections explain the cause and fixes for these errors and warnings.

## Partial types

- **CS0260**: *Missing partial modifier on declaration of type; another partial declaration of this type exists*
- **CS0261**: *Partial declarations of type must be all classes, all structs, or all interfaces*
- **CS0262**: *Partial declarations of type have conflicting accessibility modifiers*
- **CS0263**: *Partial declarations of type must not specify different base classes*
- **CS0264**: *Partial declarations of type must have the same type parameter names in the same order*
- **CS0265**: *Partial declarations of type have inconsistent constraints for type parameter 'type parameter'*
- **CS0267**: *The '`partial`' modifier can only appear immediately before '`class`', '`record`', '`struct`', '`interface`', or a method or property return type.*
- **CS8863**: *Only a single partial type declaration may have a parameter list*

Your partial type declaration can cause the compiler to emit the following warning:

- **CS0282**: *There is no defined ordering between fields in multiple declarations of partial `class` or `struct` 'type'. To specify an ordering, all instance fields must be in the same declaration.*

These errors occur when your [partial type declarations](../keywords/partial-type.md) violate the rules for partial types.

- Add the `partial` modifier to all declarations of the type, because once you split a type across multiple declarations, every part must include the keyword (**CS0260**).
- Ensure all declarations use the same type keyword, because mixing `class`, `struct`, `record`, and `interface` in different parts of the same type isn't allowed (**CS0261**). You should ensure consistent access modifiers across all declarations, such as making all parts `public` or all parts `internal`, because conflicting accessibility on different declarations creates ambiguity about the type's intended visibility (**CS0262**).
- Verify that all declarations specify the same base class, because a type can inherit from only one base class, so multiple different base classes conflict (**CS0263**).
- For generic partial types, ensure all declarations list the same type parameters in the same order, because the type parameter names must match exactly across all parts (**CS0264**).
- Verify that constraints on type parameters remain consistent across all declarations, because inconsistent constraints would create ambiguity about what types can be used for the type parameters (**CS0265**).
- Place the `partial` keyword immediately before the type keyword (`class`, `record`, `struct`, or `interface`), because the language syntax requires this specific ordering (**CS0267**).
- Declare a primary constructor on only one partial declaration, because multiple primary constructors would conflict about which constructor parameters and initialization logic to use (**CS8863**).

When you declare fields in multiple files for a partial struct type, you should consolidate all field declarations into a single file if the memory layout order matters, because the compiler can't guarantee a specific ordering when fields are split across multiple files (**CS0282**). Alternatively, if the layout order doesn't matter, you can apply the <xref:System.Runtime.InteropServices.StructLayoutAttribute?displayProperty=fullName> with the <xref:System.Runtime.InteropServices.LayoutKind.Auto?displayProperty=nameWithType> value to allow the runtime to optimize the layout automatically.

## Partial members

- **CS0750**: *A partial member cannot have the '`abstract`' modifier.*
- **CS0751**: *A partial member must be declared in a partial `class` or partial `struct`*
- **CS0754**: *A partial member may not explicitly implement an interface method.*
- **CS0763**: *Both partial method declarations must be `static` or neither may be `static`.*
- **CS0764**: *Both partial method declarations must be `unsafe` or neither may be `unsafe`*
- **CS8142**: *Both partial member declarations must use the same tuple element names.*
- **CS8663**: *Both partial member declarations must be readonly or neither may be readonly*
- **CS8799**: *Both partial member declarations must have identical accessibility modifiers.*
- **CS8800**: *Both partial member declarations must have identical combinations of `virtual`, `override`, `sealed`, and `new` modifiers.*
- **CS8818**: *Partial member declarations must have matching `ref` return values.*
- **CS8988**: *The `scoped` modifier of parameter doesn't match partial definition.*
- **CS9275**: *Partial member  must have an implementation part.*
- **CS9276**: *Partial member  must have a definition part.*
- **CS9277**: *Partial member may not have multiple defining declarations.*
- **CS9278**: *Partial member may not have multiple implementing declarations.*

These errors occur when your [partial member declarations](../keywords/partial-member.md) violate the rules for partial methods, properties, indexers, and events.

- Remove the `abstract` modifier from partial members, because abstract members require derived classes to provide implementations. This requirement conflicts with the partial member pattern where the implementation is provided in the implementing declaration (**CS0750**).
- Declare partial members within a type that includes the `partial` modifier, because partial members can only exist in partial types (**CS0751**).
- Remove explicit interface implementations from partial members, because the two-part declaration pattern isn't compatible with explicit interface implementation syntax (**CS0754**).
- Include or omit the `static` modifier consistently in both declarations, because mixing static and instance members would create ambiguity about how the member is invoked (**CS0763**).
- Include or omit the `unsafe` modifier consistently in both declarations, because inconsistent unsafe contexts could create safety issues or compilation errors (**CS0764**).
- Use identical tuple element names in both declarations, because different names would create confusion about which names are available in consuming code (**CS8142**).
- Include or omit the `readonly` modifier consistently in both declarations, because mixing readonly and non-readonly declarations creates ambiguity about whether the member can modify instance state (**CS8663**).
- Use identical accessibility modifiers (such as `public`, `private`, `protected`, or `internal`) on both declarations, because different accessibility levels would conflict about the member's visibility (**CS8799**).
- Apply the same combination of `virtual`, `override`, `sealed`, and `new` modifiers to both declarations, because these modifiers control inheritance and polymorphism behavior that must be consistent (**CS8800**).
- Use matching `ref` return modifiers in both declarations, because inconsistent return-by-reference behavior would create type safety issues (**CS8818**).
- Apply the `scoped` modifier consistently to parameters in both declarations, because this modifier controls the lifetime of ref parameters and must match to ensure memory safety (**CS8988**).
- Provide an implementing declaration for every partial member that has a defining declaration, because partial members require both parts to be complete (**CS9275**, **CS9276**).
- Ensure each partial member has exactly one defining declaration and one implementing declaration, because multiple declarations would create ambiguity about which definition or implementation to use (**CS9277**, **CS9278**).

## Partial methods

- **CS0501**: *'member function' must declare a body because it is not marked `abstract`, `extern`, or `partial`*
- **CS0755**: *Both partial method declarations must be extension methods or neither may be an extension method.*
- **CS0756**: *A partial method may not have multiple defining declarations.*
- **CS0757**: *A partial method may not have multiple implementing declarations.*
- **CS0759**: *No defining declaration found for implementing declaration of partial method.*
- **CS0761**: *Partial method declarations of `method<T>` have inconsistent type parameter constraints.*
- **CS0762**: *Cannot create delegate from method because it is a partial method without an implementing declaration*
- **CS1067**: *Partial declarations must have the same type parameter names and variance modifiers in the same order.*
- **CS8796**: *Partial method must have accessibility modifiers because it has a non-void return type.*
- **CS8795**: *Partial member must have an implementation part because it has accessibility modifiers.*
- **CS8797**: *Partial method  must have accessibility modifiers because it has '`out`' parameters.*
- **CS8798**: *Partial method must have accessibility modifiers because it has a '`virtual`', '`override`', '`sealed`', '`new`', or '`extern`' modifier.*
- **CS8817**: *Both partial method declarations must have the same return type.*

These errors occur when your [partial method declarations](../keywords/partial-method.md) violate the rules for partial methods.

- Add the `partial` modifier to the method declaration, or provide a method body, because methods without implementations must be marked as `abstract`, `extern`, or `partial` (**CS0501**).
- Ensure both declarations include or omit the extension method syntax (`this` modifier on the first parameter) consistently, because mixing extension and non-extension declarations creates incompatible method signatures (**CS0755**).
- Remove duplicate defining declarations (the declarations without method bodies), because each partial method can have only one definition (**CS0756**).
- Remove duplicate implementing declarations (the declarations with method bodies), because each partial method can have only one implementation (**CS0757**).
- Add a corresponding defining declaration for each implementing declaration, because every partial method with a body must have a matching signature declaration without a body (**CS0759**).
- Ensure type parameter constraints match across both declarations, because inconsistent constraints create ambiguity about which types are valid for the generic method (**CS0761**).
- Provide an implementing declaration before creating a delegate from the method, because delegates require a concrete method implementation to reference (**CS0762**).
- For generic partial methods, ensure both declarations use the same type parameter names and variance modifiers in the same order, because mismatched generic signatures create incompatible method declarations (**CS1067**).
- Add explicit accessibility modifiers (such as `public`, `private`, `protected`, or `internal`) when the method returns a non-`void` type, because non-void partial methods must have defined accessibility to be callable from other code (**CS8796**).
- Provide an implementing declaration when accessibility modifiers are specified, because accessible partial methods must have implementations to be invoked (**CS8795**).
- Add explicit accessibility modifiers when the method has `out` parameters, because methods with out parameters must have defined accessibility to be callable (**CS8797**).
- Add explicit accessibility modifiers when using `virtual`, `override`, `sealed`, `new`, or `extern` modifiers, because these modifiers affect method visibility and require explicit accessibility specification (**CS8798**).
- Ensure both declarations specify the same return type, because different return types create incompatible method signatures (**CS8817**).

## Partial properties

- **CS9248**: *Partial property must have an implementation part.*
- **CS9249**: *Partial property must have a definition part.*
- **CS9250**: *A partial property may not have multiple defining declarations, and cannot be an auto-property.*
- **CS9251**: *A partial property may not have multiple implementing declarations*
- **CS9252**: *Property accessor must be implemented because it is declared on the definition part*
- **CS9253**: *Property accessor does not implement any accessor declared on the definition part*
- **CS9254**: *Property accessor must match the definition part*
- **CS9255**: *Both partial property declarations must have the same type.*
- **CS9257**: *Both partial property declarations must be required or neither may be required*

Your partial property or indexer declaration can cause the compiler to emit the following warning:

- **CS9256**: *Partial property declarations have signature differences.*

These errors and warnings occur when your [partial property or indexer declarations](../keywords/partial-member.md) violate the rules for partial properties.

- Provide an implementing declaration for each partial property defining declaration, because partial properties require both parts to be complete (**CS9248**).
- Provide a defining declaration for each partial property implementing declaration, because every implementation must have a corresponding definition (**CS9249**).
- Remove duplicate defining declarations and avoid using auto-property syntax in the implementing declaration, because each partial property can have only one definition and the implementation must include explicit accessor bodies (**CS9250**).
- Remove duplicate implementing declarations, because each partial property can have only one implementation (**CS9251**).
- Implement all accessors declared in the defining declaration, because the implementing declaration must provide bodies for every accessor (get, set, or init) specified in the definition (**CS9252**).
- Remove accessors from the implementing declaration that weren't declared in the defining declaration, because you can only implement accessors that were declared in the definition part (**CS9253**).
- Ensure accessor signatures match between both declarations, including the accessor type (get, set, or init) and any modifiers, because inconsistent accessor definitions create incompatible property declarations (**CS9254**).
- Ensure both declarations specify the same property type, because different types create incompatible property signatures (**CS9255**).
- Ensure both declarations include or omit the `required` modifier consistently, because mixing required and non-required declarations creates ambiguity about whether the property must be initialized (**CS9257**).
- Review and correct any signature mismatches between the declaring and implementing declarations, because differences in accessibility modifiers, return types, or parameter lists (for indexers) can cause unexpected behavior (**CS9256**).

## Partial events and constructors

- **CS9279**: *Partial event cannot have initializer.*
- **CS9280**: *Only the implementing declaration of a partial constructor can have an initializer.*

You declared an initializer on the defining declaration of a partial constructor or on a partial event declaration. Remove the initializer.

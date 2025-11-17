---
title: "Resolve errors and warnings related to extension declarations"
description: "These errors and warnings indicate that you need to modify the declaration of an extension method using the `this` modifier on the first parameter, or an extension declaration"
ms.date: 11/07/2025
ai-usage: ai-assisted
f1_keywords:
  - "CS1100"
  - "CS1101"
  - "CS1102"
  - "CS1103"
  - "CS1105"
  - "CS1106"
  - "CS1109"
  - "CS1110"
  - "CS1112"
  - "CS1113"
  - "CS1743"
  - "CS9281"
  - "CS9282"
  - "CS9283"
  - "CS9284"
  - "CS9285"
  - "CS9287"
  - "CS9288"
  - "CS9289"
  - "CS9290"
  - "CS9292"
  - "CS9293"
  - "CS9295"
  - "CS9300"
  - "CS9301"
  - "CS9302"
  - "CS9303"
  - "CS9304"
  - "CS9305"
  - "CS9306"
  - "CS9309"
  - "CS9316"
  - "CS9317"
  - "CS9318"
  - "CS9319"
  - "CS9320"
  - "CS9321"
  - "CS9322"
  - "CS9323"
  - "CS9326"
  - "CS9329"
  - "CS9339"
helpviewer_keywords: 
  - "CS1100"
  - "CS1101"
  - "CS1102"
  - "CS1103"
  - "CS1105"
  - "CS1106"
  - "CS1109"
  - "CS1110"
  - "CS1112"
  - "CS1113"
  - "CS1743"
  - "CS9281"
  - "CS9282"
  - "CS9283"
  - "CS9284"
  - "CS9285"
  - "CS9287"
  - "CS9288"
  - "CS9289"
  - "CS9290"
  - "CS9291"
  - "CS9292"
  - "CS9293"
  - "CS9294"
  - "CS9295"
  - "CS9300"
  - "CS9301"
  - "CS9302"
  - "CS9303"
  - "CS9304"
  - "CS9305"
  - "CS9306"
  - "CS9309"
  - "CS9316"
  - "CS9317"
  - "CS9318"
  - "CS9319"
  - "CS9320"
  - "CS9321"
  - "CS9322"
  - "CS9323"
  - "CS9326"
  - "CS9329"
  - "CS9339"
---
# Resolve errors and warnings in extension member declarations

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS1100**](#errors-related-to-this-parameter-extension-methods): *Method has a parameter modifier '`this`' which is not on the first parameter*
- [**CS1101**](#errors-related-to-this-parameter-extension-methods): *The parameter modifier '`ref`' cannot be used with '`this`'.*
- [**CS1102**](#common-errors-on-extension-declarations): *The parameter modifier '`out`' cannot be used with '`this`'.*
- [**CS1103**](#common-errors-on-extension-declarations): *The first parameter of an extension method cannot be of a pointer type.*
- [**CS1105**](#errors-related-to-this-parameter-extension-methods): *Extension methods must be static.*
- [**CS1106**](#common-errors-on-extension-declarations): *Extension methods must be defined in a non generic static class.*
- [**CS1109**](#common-errors-on-extension-declarations): *Extension Methods must be defined on top level static classes, 'name' is a nested class.*
- [**CS1110**](#errors-related-to-this-parameter-extension-methods): *Cannot define a new extension because the compiler required type <xref:System.Runtime.CompilerServices.ExtensionAttribute> cannot be found. Are you missing a reference to System.Core.dll?*
- [**CS1112**](#errors-related-to-this-parameter-extension-methods): *Do not use '<xref:System.Runtime.CompilerServices.ExtensionAttribute>'. Use the '`this`' keyword instead.*
- [**CS1113**](#errors-related-to-this-parameter-extension-methods): *Extension method defined on a value type cannot be used to create delegates.*
- [**CS1743**](#common-errors-on-extension-declarations): *Cannot specify a default value for the 'this' parameter.*
- [**CS9281**](#errors-related-to-extension-block-declarations): *Extension declarations may not have a name.*
- [**CS9282**](#errors-related-to-extension-block-declarations): *Extension declarations can include only methods or properties.*
- [**CS9283**](#common-errors-on-extension-declarations): *Extensions must be declared in a top-level, non-generic, static class.*
- [**CS9284**](#common-errors-on-extension-declarations): *The receiver parameter of an extension cannot have a default value.*
- [**CS9285**](#common-errors-on-extension-declarations): *An extension container can have only one receiver parameter.*
- [**CS9287**](#errors-related-to-extension-block-declarations): *A receiver parameter cannot have the same name as an extension container type parameter.*
- [**CS9288**](#errors-related-to-extension-block-declarations): *A parameter, local variable, or local function cannot have the same name as an extension container type parameter.*
- [**CS9289**](#errors-related-to-extension-block-declarations): *Member type parameter has the same name as an extension container type parameter.*
- [**CS9290**](#errors-related-to-extension-block-declarations): *A parameter, local variable, or local function cannot have the same name as an extension parameter.*
- [**CS9291**](#errors-related-to-extension-block-declarations): *'`value`': an automatically-generated parameter name conflicts with an extension parameter name.*
- [**CS9292**](#errors-related-to-extension-block-declarations): *A type parameter has the same name as an extension parameter.*
- [**CS9293**](#errors-related-to-extension-block-declarations): *Cannot use an extension parameter in this context.*
- [**CS9294**](#errors-related-to-extension-block-declarations): *'`value`': an automatically-generated parameter name conflicts with an extension type parameter name.*
- [**CS9295**](#errors-related-to-extension-block-declarations): *The extended type must reference all the type parameters declared by the extension, but a type parameter is not referenced.*
- [**CS9300**](#errors-related-to-extension-block-declarations): *The '`ref`' receiver parameter of an extension block must be a value type or a generic type constrained to struct.*
- [**CS9301**](#errors-related-to-extension-block-declarations): *The '`in`' or '`ref readonly`' receiver parameter of extension must be a concrete (non-generic) value type.*
- [**CS9302**](#errors-related-to-extension-block-declarations): *new protected member declared in an extension block.*
- [**CS9303**](#errors-related-to-extension-block-declarations): *Cannot declare instance members in an extension block with an unnamed receiver parameter.*
- [**CS9304**](#errors-related-to-extension-block-declarations): *Cannot declare init-only accessors in an extension block.*
- [**CS9305**](#errors-related-to-extension-block-declarations): *Cannot use modifiers on the unnamed receiver parameter of extension block.*
- [**CS9306**](#errors-related-to-extension-block-declarations): *Types and aliases cannot be named 'extension'.*
- [**CS9309**](#errors-related-to-extension-block-declarations): *An extension member syntax is disallowed in nested position within an extension member syntax.*
- [**CS9316**](#errors-related-to-extension-block-declarations): *Extension members are not allowed as an argument to '`nameof`'.*
- [**CS9317**](#errors-related-to-extension-block-declarations): *The parameter of a unary operator must be the extended type.*
- [**CS9318**](#errors-related-to-extension-block-declarations): *The parameter type for ++ or -- operator must be the extended type.*
- [**CS9319**](#errors-related-to-extension-block-declarations): *One of the parameters of a binary operator must be the extended type.*
- [**CS9320**](#errors-related-to-extension-block-declarations): *The first operand of an overloaded shift operator must have the same type as the extended type.*
- [**CS9321**](#errors-related-to-extension-block-declarations): *An extension block extending a static class cannot contain user-defined operators.*
- [**CS9322**](#errors-related-to-extension-block-declarations): *Cannot declare instance operator for a struct unless containing extension block receiver parameter is a '`ref`' parameter.*
- [**CS9323**](#errors-related-to-extension-block-declarations): *Cannot declare instance extension operator for a type that is not known to be a struct and is not known to be a class.*
- [**CS9326**](#errors-related-to-extension-block-declarations): *'`name`': extension member names cannot be the same as their extended type.*
- [**CS9329**](#errors-related-to-extension-block-declarations): *This extension block collides with another extension block. They result in conflicting content-based type names in metadata.*
- [**CS9339**](#errors-related-to-extension-block-declarations): *The extension resolution is ambiguous between the following members.*

## Common errors on extension declarations

- **CS1102**: *The parameter modifier '`out`' cannot be used with '`this`'.*
- **CS1103**: *The first parameter of an extension method cannot be of a pointer type.*
- **CS1106**: *Extension methods must be defined in a non generic static class.*
- **CS1109**: *Extension Methods must be defined on top level static classes, 'name' is a nested class.*
- **CS1113**: *Extension method defined on a value type cannot be used to create delegates.*
- **CS1743**: *Cannot specify a default value for the 'this' parameter.*
- **CS9283**: *Extensions must be declared in a top-level, non-generic, static class.*
- **CS9284**: *The receiver parameter of an extension cannot have a default value.*
- **CS9285**: *An extension container can have only one receiver parameter.*

The compiler emits these errors when you violate rules that apply to all extension member declarations, regardless of the syntax chosen. For more information, see [Extension methods](../../programming-guide/classes-and-structs/extension-methods.md).

To declare extension members correctly, follow these requirements:

- Declare the containing type as a non-generic `static` class or struct (**CS1106**, **CS9283**).
- Declare the containing type at the top level, not nested within another type (**CS1109**, **CS9283**).
- Don't convert extension methods on value types to delegates (**CS1113**). Create a regular method instead.
- Don't use the `out` parameter modifier on the receiver parameter (**CS1102**).
- Don't provide default values for the receiver parameter (**CS1743**, **CS9284**).
- Don't extend pointer types (**CS1103**). The parameter you apply the `this` modifier to can't be a pointer type.
- Declare only one receiver parameter per extension container (**CS9285**).

## Errors related to extension block declarations

- **CS9281**: *Extension declarations may not have a name.*
- **CS9282**: *Extension declarations can include only methods or properties.*
- **CS9287**: *A receiver parameter cannot have the same name as an extension container type parameter.*
- **CS9288**: *A parameter, local variable, or local function cannot have the same name as an extension container type parameter.*
- **CS9289**: *Member type parameter has the same name as an extension container type parameter.*
- **CS9290**: *A parameter, local variable, or local function cannot have the same name as an extension parameter.*
- **CS9291**: *'`value`': an automatically-generated parameter name conflicts with an extension parameter name.*
- **CS9292**: *A type parameter has the same name as an extension parameter.*
- **CS9293**: *Cannot use an extension parameter in this context.*
- **CS9294**: *'`value`': an automatically-generated parameter name conflicts with an extension type parameter name.*
- **CS9295**: *The extended type must reference all the type parameters declared by the extension, but a type parameter is not referenced.*
- **CS9300**: *The '`ref`' receiver parameter of an extension block must be a value type or a generic type constrained to struct.*
- **CS9301**: *The '`in`' or '`ref readonly`' receiver parameter of extension must be a concrete (non-generic) value type.*
- **CS9302**: *new protected member declared in an extension block.*
- **CS9303**: *Cannot declare instance members in an extension block with an unnamed receiver parameter.*
- **CS9304**: *Cannot declare init-only accessors in an extension block.*
- **CS9305**: *Cannot use modifiers on the unnamed receiver parameter of extension block.*
- **CS9306**: *Types and aliases cannot be named 'extension'.*
- **CS9309**: *An extension member syntax is disallowed in nested position within an extension member syntax.*
- **CS9316**: *Extension members are not allowed as an argument to '`nameof`'.*
- **CS9317**: *The parameter of a unary operator must be the extended type.*
- **CS9318**: *The parameter type for ++ or -- operator must be the extended type.*
- **CS9319**: *One of the parameters of a binary operator must be the extended type.*
- **CS9320**: *The first operand of an overloaded shift operator must have the same type as the extended type.*
- **CS9321**: *An extension block extending a static class cannot contain user-defined operators.*
- **CS9322**: *Cannot declare instance operator for a struct unless containing extension block receiver parameter is a '`ref`' parameter.*
- **CS9323**: *Cannot declare instance extension operator for a type that is not known to be a struct and is not known to be a class.*
- **CS9326**: *'`name`': extension member names cannot be the same as their extended type.*
- **CS9329**: *This extension block collides with another extension block. They result in conflicting content-based type names in metadata.*
- **CS9339**: *The extension resolution is ambiguous between the following members.*

These errors are specific to extension blocks, a C# 14 feature. Extension blocks are declared using the [`extension`](../keywords/extension.md) contextual keyword in a static class. For more information, see [Extension methods](../../programming-guide/classes-and-structs/extension-methods.md).

To declare extension blocks correctly, follow these requirements:

- Don't include a name token in the extension declaration (**CS9281**). The extension declares the receiver only.
- Don't provide default values for the receiver parameter (**CS9284**, covered in [common errors](#common-errors-on-extension-declarations)).
- Don't use the `extension` keyword for types or aliases (**CS9306**). It's a contextual keyword for extension blocks only.

To declare extension members in extension blocks correctly, follow these requirements in addition to the [common rules](#common-errors-on-extension-declarations):

- Include only methods or properties as extension members (**CS9282**). Other member types aren't supported.
- Provide a parameter name for the receiver to contain instance extension members (**CS9303**).
- Ensure the receiver parameter name is unique within the extension block and doesn't conflict with type parameters (**CS9287**, **CS9288**, **CS9289**, **CS9290**, **CS9291**, **CS9292**, **CS9294**).
- Reference all type parameters declared on the extension in the extended type (**CS9295**). Additional type parameters can be added on individual members.
- Don't nest extension blocks within other extension blocks (**CS9309**).
- Use the `ref` modifier on the receiver parameter only with value types or generic types constrained to struct (**CS9300**).
- Use the `in` or `ref readonly` modifier on the receiver parameter only with concrete (non-generic) value types (**CS9301**).
- Don't use modifiers on unnamed receiver parameters (**CS9305**).
- Don't declare `protected` members in extension blocks (**CS9302**). Extension members must be accessible where the extension is in scope.
- Don't declare `init`-only accessors in extension blocks (**CS9304**). Use regular property setters instead.
- Don't use extension members as arguments to the `nameof` operator (**CS9316**).
- Choose member names that differ from the extended type name (**CS9326**).
- Ensure extension blocks have unique content-based type names in metadata (**CS9329**). Consolidate or differentiate extension blocks to avoid conflicts.
- Resolve ambiguous extension member calls by providing more specific type information or using qualified names (**CS9339**).

### Extension block operator requirements

Extension blocks support user-defined operators with specific requirements:

- Unary operators must have the extended type as their parameter (**CS9317**).
- Increment (`++`) and decrement (`--`) operators must have the extended type as their parameter (**CS9318**).
- Binary operators must have at least one parameter that is the extended type (**CS9319**).
- Shift operators must have the extended type as their first operand (**CS9320**).
- Don't declare user-defined operators in extension blocks that extend static classes (**CS9321**).
- When extending a struct with instance operators, use the `ref` modifier on the receiver parameter (**CS9322**).
- Don't declare instance operators for types that aren't constrained to be either a struct or a class (**CS9323**).

## Errors related to `this` parameter extension methods

- **CS1100**: *Method has a parameter modifier '`this`' which is not on the first parameter*
- **CS1101**: *The parameter modifier '`ref`' cannot be used with '`this`'.*
- **CS1105**: *Extension methods must be static.*
- **CS1110**: *Cannot define a new extension because the compiler required type <xref:System.Runtime.CompilerServices.ExtensionAttribute> cannot be found. Are you missing a reference to System.Core.dll?*
- **CS1112**: *Do not use '<xref:System.Runtime.CompilerServices.ExtensionAttribute>'. Use the '`this`' keyword instead.*

These errors are specific to extension methods where you declare the receiver by adding the `this` modifier to the first parameter. For more information, see [Extension methods](../../programming-guide/classes-and-structs/extension-methods.md).

To declare `this` parameter extension methods correctly, follow these requirements in addition to the [common rules](#common-errors-on-extension-declarations):

- Add the `static` modifier to the method (**CS1105**).
- Apply the `this` parameter modifier only to the first parameter (**CS1100**).
- Don't combine the `ref` modifier with the `this` modifier (**CS1101**). To use `ref`, convert to an extension block.
- Add a reference to `System.Core.dll` in .NET Framework apps (**CS1110**).
- Use the `this` modifier on the first parameter instead of directly applying the <xref:System.Runtime.CompilerServices.ExtensionAttribute> attribute (**CS1112**).

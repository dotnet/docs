---
title: "Errors and warnings related to extension declarations"
description: "These errors and warnings indicate that you need to modify the declaration of an extension method using the `this` modifier on the first parameter, or an extension declaration"
ms.date: 05/23/2025
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
---
# Errors and warnings related to extension methods declared with `this` parameters or `extension` blocks

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
- [**CS9282**](#errors-related-to-extension-container-declarations): *Extension declarations can include only methods or properties.*
- [**CS9283**](#common-errors-on-extension-declarations): *Extensions must be declared in a top-level, non-generic, static class.*
- [**CS9284**](#common-errors-on-extension-declarations): *The receiver parameter of an extension cannot have a default value.*
- [**CS9285**](#common-errors-on-extension-declarations): *An extension container can have only one receiver parameter.*
- [**CS9287**](#errors-related-to-extension-container-declarations): *A receiver parameter cannot have the same name as an extension container type parameter.*
- [**CS9288**](#errors-related-to-extension-container-declarations): *A parameter, local variable, or local function cannot have the same name as an extension container type parameter.*
- [**CS9289**](#errors-related-to-extension-container-declarations): *Member type parameter has the same name as an extension container type parameter.*
- [**CS9290**](#errors-related-to-extension-container-declarations): *A parameter, local variable, or local function cannot have the same name as an extension parameter.*
- [**CS9291**](#errors-related-to-extension-container-declarations): *'`value`': an automatically-generated parameter name conflicts with an extension parameter name.*
- [**CS9292**](#errors-related-to-extension-container-declarations): *A type parameter has the same name as an extension parameter.*
- [**CS9293**](#errors-related-to-extension-container-declarations): *Cannot use an extension parameter in this context.*
- [**CS9294**](#errors-related-to-extension-container-declarations): *'`value`': an automatically-generated parameter name conflicts with an extension type parameter name.*
- [**CS9295**](#errors-related-to-extension-container-declarations): *The extended type must reference all the type parameters declared by the extension, but a type parameter is not referenced.*
- [**CS9300**](#errors-related-to-extension-container-declarations): *The '`ref`' receiver parameter of an extension block must be a value type or a generic type constrained to struct.*
- [**CS9301**](#errors-related-to-extension-container-declarations): *The '`in`' or '`ref readonly`' receiver parameter of extension must be a concrete (non-generic) value type.*
- [**CS9302**](#errors-related-to-extension-container-declarations): *new protected member declared in an extension block.*
- [**CS9303**](#errors-related-to-extension-container-declarations): *Cannot declare instance members in an extension block with an unnamed receiver parameter.*
- [**CS9304**](#errors-related-to-extension-container-declarations): *Cannot declare init-only accessors in an extension block.*
- [**CS9305**](#errors-related-to-extension-container-declarations): *Cannot use modifiers on the unnamed receiver parameter of extension block.*

## Common errors on extension declarations

The compiler emits these errors when you violate rules that apply to all extension member declarations, regardless of the syntax chosen:

- **CS1102**: *The parameter modifier '`out`' cannot be used with '`this`'.*
- **CS1106**: *Extension methods must be defined in a non generic static class.*
- **CS1103**: *The first parameter of an extension method cannot be of a pointer type.*
- **CS1109**: *Extension Methods must be defined on top level static classes, 'name' is a nested class.*
- **CS1113**: *Extension method defined on a value type cannot be used to create delegates.*
- **CS1743**: *Cannot specify a default value for the 'this' parameter.*
- **CS9283**: *Extensions must be declared in a top-level, non-generic, static class.*
- **CS9284**: *The receiver parameter of an extension cannot have a default value.*
- **CS9285**: *An extension container can have only one receiver parameter.*

Any extension declaration must follow these rules:

- Its containing type (`class` or `struct`) must be non-generic and `static`.
- Its containing type must be a top-level type. It can't be nested in another type.
- Members that extend an instance of a value type can't be converted to delegates.
- The receiver parameter can't include the `out` parameter modifier.
- The receiver parameter can't have a default argument value.
- Pointer types can't be extended. In other words, the parameter you apply the `this` modifier to can't be a pointer type.

## Errors related to extension block declarations

These errors are specific to extension blocks, a C# 14 feature. Extension blocks are declared using the `extension` keyword in a static class. The `extension` declares the type and name of the receiver. All members inside the block declared with `extension` are extension members for that receiver:

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

Extension declarations must follow these rules:

- The extension can't include a name token. The extension declares the receiver only.
- The receiver parameter can't have a default value.

Extension members declared in an extension block must follow these rules, in addition to the [common rules](#common-errors-on-extension-declarations):

- Only methods and properties are valid extension member types. Extension members can extend an instance, or a type.
- The extension must provide a parameter name for the receiver in order to contain members that extend an instance.
- The receiver parameter name must be unique in that extension block.
- All extension members must use all type parameters declared on the extension. They can add more type parameters.

## Errors related to `this` parameter extension methods

These errors are specific to extension methods where you declare the receiver by adding the `this` modifier to the first parameter of the method:

- **CS1100**: *Method has a parameter modifier '`this`' which is not on the first parameter*
- **CS1101**: *The parameter modifier '`ref`' cannot be used with '`this`'.*
- **CS1105**: *Extension methods must be static.*
- **CS1110**: *Cannot define a new extension because the compiler required type <xref:System.Runtime.CompilerServices.ExtensionAttribute> cannot be found. Are you missing a reference to System.Core.dll?*
- **CS1112**: *Do not use '<xref:System.Runtime.CompilerServices.ExtensionAttribute>'. Use the '`this`' keyword instead.*

An extension method where the receiver instance includes the `this` modifier must follow these rules, in addition to the [common rules](#common-errors-on-extension-declarations):

- The method must have the `static` modifier.
- The `this` parameter modifier must be applied to the first parameter. It can't be applied to any other parameters on the method.
- The `ref` `out` parameter modifier can't be applied to the first parameter. To apply `ref`, you need to convert to an extension block.
- In .NET Framework apps, `System.Core.dll` must be added as a reference.
- You must specify the `this` modifier on the first parameter. You can't directly use the <xref:System.Runtime.CompilerServices.ExtensionAttribute> attribute instead.

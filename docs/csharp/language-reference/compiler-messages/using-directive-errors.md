---
title: "Resolve compiler errors and warnings related to using directives and using alias directives"
description: "These errors and warnings indicate problems with using directives and using directive aliases. This information helps diagnose and fix those issues."
ms.date: 02/10/2026
f1_keywords:
  - "CS0104"
  - "CS0105"
  - "CS0116"
  - "CS0138"
  - "CS0430"
  - "CS0431"
  - "CS0432"
  - "CS0434"
  - "CS0435"
  - "CS0436"
  - "CS0437"
  - "CS0438"
  - "CS0439"
  - "CS0440"
  - "CS0518"
  - "CS0576"
  - "CS0687"
  - "CS1022"
  - "CS1529"
  - "CS1537"
  - "CS1671"
  - "CS1679"
  - "CS1680"
  - "CS1681"
  - "CS1730"
  - "CS2034"
  - "CS7000"
  - "CS7007"
  - "CS7015"
  - "CS7021"
  - "CS8019"
  - "CS8020"
  - "CS8083"
  - "CS8085"
  - "CS8914"
  - "CS8915"
  - "CS8933"
  - "CS8954"
  - "CS8955"
  - "CS8956"
  - "CS9130"
  - "CS9131"
  - "CS9132"
  - "CS9133"
  - "CS9162"
helpviewer_keywords:
  - "CS0104"
  - "CS0105"
  - "CS0116"
  - "CS0138"
  - "CS0430"
  - "CS0431"
  - "CS0432"
  - "CS0434"
  - "CS0435"
  - "CS0436"
  - "CS0437"
  - "CS0438"
  - "CS0439"
  - "CS0440"
  - "CS0518"
  - "CS0576"
  - "CS0687"
  - "CS1022"
  - "CS1529"
  - "CS1537"
  - "CS1671"
  - "CS1679"
  - "CS1680"
  - "CS1681"
  - "CS1730"
  - "CS2034"
  - "CS7000"
  - "CS7007"
  - "CS7015"
  - "CS7021"
  - "CS8019"
  - "CS8020"
  - "CS8083"
  - "CS8085"
  - "CS8914"
  - "CS8915"
  - "CS8933"
  - "CS8954"
  - "CS8955"
  - "CS8956"
  - "CS9130"
  - "CS9131"
  - "CS9132"
  - "CS9133"
  - "CS9162"
---
# Resolve warnings related to using and declaring namespaces

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0104**](#namespace-and-type-naming-conflicts): *Error: 'reference' is an ambiguous reference between 'identifier' and 'identifier'.*
- [**CS0116**](#namespace-declarations): *Error: A namespace cannot directly contain members such as fields, methods or statements.*
- [**CS0138**](#using-static-directive): *Error: A using namespace directive can only be applied to namespaces; 'type' is a type not a namespace.*
- [**CS0430**](#using-directive): *Error: The extern alias 'alias' was not specified in a /reference option.*
- [**CS0431**](#alias-qualifier): *Error: Cannot use alias 'identifier' with `::` since the alias references a type. Use `.` instead*.
- [**CS0432**](#alias-qualifier): *Error: Alias 'identifier' not found.*
- [**CS0434**](#namespace-and-type-naming-conflicts): *Error: The namespace NamespaceName1 in NamespaceName2 conflicts with the type TypeName1 in NamespaceName3.*
- [**CS0438**](#namespace-and-type-naming-conflicts): *Error: The type 'type' in 'module_1' conflicts with the namespace 'namespace' in 'module_2'.*
- [**CS0439**](#using-directive): *Error: An extern alias declaration must precede all other elements defined in the namespace.*
- [**CS0518**](#predefined-type-imports): *Error: Predefined type 'type' is not defined or imported.*
- [**CS0576**](#using-alias-restrictions): *Error: Namespace 'namespace' contains a definition conflicting with alias 'identifier'.*
- [**CS0687**](#alias-qualifier): *Error: The namespace alias qualifier `::` always resolves to a type or namespace so is illegal here. Consider using `.` instead.*
- [**CS1022**](#namespace-declarations): *Error: Type or namespace definition, or end-of-file expected.*
- [**CS1529**](#using-directive): *Error: A using clause must precede all other elements defined in the namespace except extern alias declarations.*
- [**CS1537**](#using-alias-restrictions): *Error: The using alias 'alias' appeared previously in this namespace.*
- [**CS1671**](#namespace-declarations): *Error: A namespace declaration cannot have modifiers or attributes.*
- [**CS1679**](#using-directive): *Error: Invalid extern alias for '/reference'; 'identifier' is not a valid identifier.*
- [**CS1680**](#using-directive): *Error: Invalid reference alias option: 'alias=' -- missing filename.*
- [**CS1681**](#using-directive): *Error: You cannot redefine the global extern alias.*
- [**CS1730**](#using-directive): *Error: Assembly and module attributes must precede all other elements defined in a file except using clauses and extern alias declarations.*
- [**CS2034**](#using-directive): *Error: A /reference option that declares an extern alias can only have one filename. To specify multiple aliases or filenames, use multiple /reference options.*
- [**CS7000**](#alias-qualifier): *Error: Unexpected use of an aliased name.*
- [**CS7007**](#using-static-directive): *Error: A `using static` directive can only be applied to types. Consider a `using namespace` directive instead*
- [**CS7015**](#using-directive): *Error: 'extern alias' is not valid in this context.*
- [**CS7021**](#namespace-declarations): *Error: Cannot declare namespace in script code.*
- [**CS8083**](#alias-qualifier): *Error: An alias-qualified name is not an expression.*
- [**CS8085**](#using-alias-restrictions): *Error: A 'using static' directive cannot be used to declare an alias.*
- [**CS8914**](#global-using-directive): *Error: A global using directive cannot be used in a namespace declaration.*
- [**CS8915**](#global-using-directive): *Error: A global using directive must precede all non-global using directives.*
- [**CS8954**](#file-scoped-namespace): *Error: Source file can only contain one file-scoped namespace declaration.*
- [**CS8955**](#file-scoped-namespace): *Error: Source file can not contain both file-scoped and normal namespace declarations.*
- [**CS8956**](#file-scoped-namespace): *Error: File-scoped namespace must precede all other members in a file.*
- [**CS9130**](#using-alias-restrictions): *Error: Using alias cannot be a `ref` type.*
- [**CS9131**](#using-alias-restrictions): *Error: Only a using alias can be `unsafe`.*
- [**CS9132**](#using-alias-restrictions): *Error: Using alias cannot be a nullable reference type.*
- [**CS9133**](#using-static-directive): *Error: `static` modifier must precede `unsafe` modifier.*
- [**CS9162**](#using-static-directive): *Type is not valid for 'using static'. Only a class, struct, interface, enum, delegate, or namespace can be used.*

And the following compiler warnings:

- [**CS0105**](#using-directive): *Warning: The using directive for 'namespace' appeared previously in this namespace.*
- [**CS0435**](#namespace-and-type-naming-conflicts): *Warning: The namespace 'namespace' in 'assembly' conflicts with the imported type 'type' in 'assembly'. Using the namespace defined in 'assembly'.*
- [**CS0436**](#namespace-and-type-naming-conflicts): *Warning: The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.*
- [**CS0437**](#namespace-and-type-naming-conflicts): *Warning: The type 'type' in 'assembly2' conflicts with the imported namespace 'namespace' in 'assembly1'. Using the type defined in 'assembly'.*
- [**CS0440**](#alias-qualifier): *Warning: Defining an alias named `global` is ill-advised since `global::` always references the global namespace and not an alias.*
- [**CS8019**](#using-directive): *Info: Unnecessary using directive.*
- [**CS8020**](#using-directive): *Info: Unused extern alias.*
- [**CS8933**](#using-directive): *Info: The using directive appeared previously as global using.*

These errors and warnings indicate issues with `using` directives, namespace declarations, or naming conflicts between types and namespaces. The following sections cover these errors and how to correct them.

## Using directive

The following errors relate to `using` directives:

- **CS0105**: *The using directive for 'namespace' appeared previously in this namespace.*
- **CS0430**: *The extern alias 'alias' was not specified in a /reference option.*
- **CS0439**: *An extern alias declaration must precede all other elements defined in the namespace.*
- **CS1529**: *A using clause must precede all other elements defined in the namespace except extern alias declarations.*
- **CS1679**: *Invalid extern alias for '/reference'; 'identifier' is not a valid identifier.*
- **CS1680**: *Invalid reference alias option: 'alias=' -- missing filename.*
- **CS1681**: *You cannot redefine the global extern alias.*
- **CS1730**: *Assembly and module attributes must precede all other elements defined in a file except using clauses and extern alias declarations.*
- **CS2034**: *A /reference option that declares an extern alias can only have one filename. To specify multiple aliases or filenames, use multiple /reference options.*
- **CS7015**: *'extern alias' is not valid in this context.*
- **CS8019**: *Unnecessary using directive.*
- **CS8020**: *Unused extern alias.*
- **CS8933**: *The using directive appeared previously as global using.*

See the [using directive](../keywords/using-directive.md) and [extern alias](../keywords/extern-alias.md) language reference for the rules that govern these diagnostics.

Move all `using` directives to the top of the file, or to the top of the namespace declaration, because the C# language requires `using` directives to come before other elements in a namespace (**CS1529**). Move all `extern alias` declarations before any `using` directives, because the language requires extern aliases to come before all other elements including `using` directives (**CS0439**, **CS7015**). Move all assembly and module level attributes after `using` clauses and `extern alias` declarations but before any type declarations, because attributes must follow directives but precede types (**CS1730**).

Ensure that every `extern alias` declaration in your source code has a corresponding alias defined in your project's [reference options](../compiler-options/inputs.md#references), because the compiler can't resolve an alias that wasn't specified (**CS0430**). Use a separate `/reference` option for each extern alias rather than combining multiple aliases in a single option, because the compiler requires one alias per reference option (**CS2034**). Ensure the alias in your `/reference` option is a valid C# identifier, because the alias must follow identifier naming rules (**CS1679**). Include a filename after the `=` sign in your alias reference option, because the compiler needs to know which assembly the alias refers to (**CS1680**). Don't attempt to redefine the `global` extern alias, because `global` is a predefined alias that refers to all unaliased references (**CS1681**).

Remove duplicate `using` directives, because the compiler warns when the same namespace is imported multiple times (**CS0105**, **CS8019**, **CS8933**). Remove unused `extern alias` declarations, because the compiler issues a diagnostic when an extern alias is declared but never referenced in your code (**CS8020**).

## Using static directive

The following errors relate to `using static` directives:

- **CS0138**: *A using namespace directive can only be applied to namespaces; 'type' is a type not a namespace.*
- **CS7007**: *A `using static` directive can only be applied to types. Consider a `using namespace` directive instead.*
- **CS9133**: *`static` modifier must precede `unsafe` modifier.*
- **CS9162**: *Type is not valid for 'using static'. Only a class, struct, interface, enum, delegate, or namespace can be used.*

See the [using static directive](../keywords/using-directive.md#the-static-modifier) language reference for the rules that govern these diagnostics.

Add the `static` modifier when importing a type's members directly, because omitting `static` tells the compiler you're importing a namespace rather than a type (**CS0138**). Remove the `static` modifier when importing a namespace, because `using static` can only be applied to types, not namespaces (**CS7007**). Ensure the target of a `using static` directive is a class, struct, interface, enum, or delegate, because other types aren't valid targets for static imports (**CS9162**). Place the `static` modifier before the `unsafe` modifier when combining both, because the language requires modifiers in a specific order (**CS9133**).

## Global using directive

The following errors relate to `global using` directives:

- **CS8914**: *A global using directive cannot be used in a namespace declaration.*
- **CS8915**: *A global using directive must precede all non-global using directives.*

See the [global using directive](../keywords/using-directive.md#the-global-modifier) language reference for the rules that govern these diagnostics.

Move `global using` directives outside of any namespace declaration to file scope, because global usings apply project-wide and can't be scoped to a namespace (**CS8914**). Place all `global using` directives before any non-global `using` directives in the file, because the language requires global directives to precede local ones (**CS8915**). Note that a `static global using` directive can't reference a [file-local](../keywords/file.md) type.

## File-scoped namespace

The following errors relate to file-scoped namespaces:

- **CS8954**: *Source file can only contain one file-scoped namespace declaration.*
- **CS8955**: *Source file can not contain both file-scoped and normal namespace declarations.*
- **CS8956**: *File-scoped namespace must precede all other members in a file.*

See the [file-scoped namespace](../keywords/namespace.md) language reference for the rules that govern these diagnostics.

Use only one file-scoped namespace declaration per file, because the language allows only a single file-scoped namespace to set the namespace for all types in a file (**CS8954**). Choose either file-scoped or block-scoped namespace declarations within a single file, because the language doesn't allow mixing both styles (**CS8955**). Move the file-scoped namespace declaration before any type declarations, because the namespace must be established before types are declared (**CS8956**).

## Alias qualifier

The following errors relate to the alias qualifier:

- **CS0431**: *Cannot use alias 'identifier' with `::` since the alias references a type. Use `.` instead.*
- **CS0432**: *Alias 'identifier' not found.*
- **CS0440**: *Defining an alias named `global` is ill-advised since `global::` always references the global namespace and not an alias.*
- **CS0687**: *The namespace alias qualifier `::` always resolves to a type or namespace so is illegal here. Consider using `.` instead.*
- **CS7000**: *Unexpected use of an aliased name.*
- **CS8083**: *An alias-qualified name is not an expression.*

See the [namespace alias qualifier](../operators/namespace-alias-qualifier.md) language reference for the rules that govern these diagnostics.

Replace the `::` operator with the `.` operator when you access members of a type alias, because the `::` qualifier is only valid for namespace aliases, not type aliases (**CS0431**, **CS0687**). Ensure the alias you're referencing is declared with a `using` directive or `extern alias`, because the compiler can't resolve an undefined alias (**CS0432**). Use the alias qualifier only in contexts where a type or namespace name is expected, because alias-qualified names aren't valid as expressions (**CS7000**, **CS8083**). Choose a different name for your alias instead of `global`, because `global` is reserved to refer to the global namespace and can't be redefined (**CS0440**).

## Using alias restrictions

The following errors relate to restrictions on using aliases:

- **CS0576**: *Namespace 'namespace' contains a definition conflicting with alias 'identifier'.*
- **CS1537**: *The using alias 'alias' appeared previously in this namespace.*
- **CS8085**: *A 'using static' directive cannot be used to declare an alias.*
- **CS9130**: *Using alias cannot be a `ref` type.*
- **CS9131**: *Only a using alias can be `unsafe`.*
- **CS9132**: *Using alias cannot be a nullable reference type.*

See the [using alias](../keywords/using-directive.md#the-using-alias) language reference for the rules that govern these diagnostics.

Choose a unique name for your alias that doesn't conflict with existing type or namespace names in scope, because the compiler can't distinguish between the alias and the existing definition (**CS0576**). Use each alias name only once within a namespace, because duplicate alias declarations create ambiguity (**CS1537**). Remove the `static` modifier when declaring an alias, because aliases and static imports are mutually exclusive—use either `using static` to import members or `using Alias =` to create an alias, but not both together (**CS8085**).

Starting with C# 12, the following restrictions apply to using aliases: Don't use `ref`, `in`, or `out` modifiers in a using alias, because these parameter modifiers aren't valid in type alias contexts (**CS9130**). Use the `unsafe` modifier only with aliases that reference pointer types or with `using static` directives, because `unsafe` without an alias or static import isn't permitted (**CS9131**). Use a non-nullable reference type when creating an alias to a reference type, because nullable reference types can't be aliased directly (**CS9132**).

## Namespace declarations

The following errors relate to namespace declaration rules:

- **CS0116**: *A namespace cannot directly contain members such as fields, methods or statements.*
- **CS1022**: *Type or namespace definition, or end-of-file expected.*
- **CS1671**: *A namespace declaration cannot have modifiers or attributes.*
- **CS7021**: *Cannot declare namespace in script code.*

See the [namespace keyword](../keywords/namespace.md) and [General Structure of a C# Program](../../fundamentals/program-structure/index.md) language reference for the rules that govern these diagnostics.

Ensure all methods, fields, and properties are declared inside a type (class, struct, record, or interface) rather than directly inside a namespace, because namespaces can only contain type declarations, nested namespaces, and `using` directives (**CS0116**). Check for mismatched braces in your source file, because an extra closing brace after a namespace or type definition produces an error when the compiler encounters unexpected content at the end of the file (**CS1022**). Remove any access modifiers or attributes from namespace declarations, because namespaces don't support modifiers like `public` or `private`, and attributes can't be applied to them (**CS1671**). Move namespace declarations out of C# script files (`.csx`) and into regular source files (`.cs`), because script code evaluates in a single execution context that doesn't support namespace declarations (**CS7021**).

## Namespace and type naming conflicts

The following errors and warnings relate to naming conflicts between namespaces and types:

- **CS0104**: *'reference' is an ambiguous reference between 'identifier' and 'identifier'.*
- **CS0434**: *The namespace NamespaceName1 in NamespaceName2 conflicts with the type TypeName1 in NamespaceName3.*
- **CS0435**: *The namespace 'namespace' in 'assembly' conflicts with the imported type 'type' in 'assembly'. Using the namespace defined in 'assembly'.*
- **CS0436**: *The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.*
- **CS0437**: *The type 'type' in 'assembly2' conflicts with the imported namespace 'namespace' in 'assembly1'. Using the type defined in 'assembly'.*
- **CS0438**: *The type 'type' in 'module_1' conflicts with the namespace 'namespace' in 'module_2'.*

See the [using directive](../keywords/using-directive.md), [extern alias](../keywords/extern-alias.md), and [namespace alias qualifier](../operators/namespace-alias-qualifier.md) language reference for the rules that govern these diagnostics.

Use a fully qualified name or a [namespace alias](../operators/namespace-alias-qualifier.md) when your code references a name that exists in multiple imported namespaces, because the compiler can't determine which type you intend to use when the same name appears in two or more namespaces imported by `using` directives (**CS0104**). Rename either the type or the namespace when an imported type and an imported nested namespace share the same fully qualified name, because the compiler can't distinguish between them when the name is referenced (**CS0434**, **CS0438**).

To resolve the naming conflict warnings, rename one of the conflicting declarations, use a different namespace, remove the unnecessary assembly reference, or use an [extern alias](../keywords/extern-alias.md) to disambiguate between the two definitions. The compiler resolves these conflicts automatically—using the locally defined namespace over the imported type (**CS0435**), the locally defined type over the imported type (**CS0436**), or the locally defined type over the imported namespace (**CS0437**)—but the warnings indicate a potential source of confusion that you should address.

## Predefined type imports

The following error relates to missing predefined type definitions:

- **CS0518**: *Predefined type 'type' is not defined or imported.*

[!INCLUDE[csharp-build-only-diagnostic-note](~/includes/csharp-build-only-diagnostic-note.md)]

See the [NoStandardLib compiler option](../compiler-options/advanced.md#nostandardlib) language reference for the rules that govern this diagnostic.

Verify that your project targets the correct .NET runtime, because predefined types like `System.Int32` and `System.String` come from the runtime library and an incorrect or missing `<TargetFramework>` specification prevents the compiler from finding them (**CS0518**). Ensure the `<TargetFramework>` property in your `.csproj` file specifies the intended runtime (for example, `net10.0`). Don't specify the [**NoStandardLib**](../compiler-options/advanced.md#nostandardlib) compiler option unless you intend to define your own `System` namespace, because this option prevents importing the standard library that defines all predefined types (**CS0518**). If the error persists, try reloading the project in Visual Studio, deleting the `obj` and `bin` folders and rebuilding, or reinstalling the .NET runtime (**CS0518**).

---
title: Resolve errors for incorrect or missing assembly references
description: These compiler errors and warnings indicate incorrect or missing assembly references. These errors cause missing or incorrect definitions for types in your program.
f1_keywords:
 - "CS0012"
 - "CS0234"
 - "CS0246"
 - "CS0400"
 - "CS1068"
 - "CS1069"
 - "CS1070"
 - "CS1683"
 - "CS1704"
 - "CS1714"
 - "CS1760"
 - "CS7008"
 - "CS7068"
 - "CS7069"
 - "CS7071"
 - "CS7079"
 - "CS8090"
 - "CS8203"
 - "CS9286"
helpviewer_keywords:
 - "CS0012"
 - "CS0234"
 - "CS0246"
 - "CS0400"
 - "CS1068"
 - "CS1069"
 - "CS1070"
 - "CS1683"
 - "CS1704"
 - "CS1714"
 - "CS1760"
 - "CS7008"
 - "CS7068"
 - "CS7069"
 - "CS7071"
 - "CS7079"
 - "CS8090"
 - "CS8203"
 - "CS9286"
ms.date: 05/27/2025
---
# Resolve errors and warnings related to assembly references

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0012**](#missing-references): *The type 'type' is defined in an assembly that is not referenced. You must add a reference to assembly 'assembly'.*
- [**CS0234**](#missing-references): *The type or namespace name does not exist in the namespace (are you missing an assembly reference?)*
- [**CS0246**](#missing-references): *The type or namespace name could not be found (are you missing a using directive or an assembly reference?)*
- [**CS0400**](#missing-references): *The type or namespace name could not be found in the global namespace (are you missing an assembly reference?)*
- [**CS0735**](#type-forwarding): *Invalid type specified as an argument for <xref:System.Runtime.CompilerServices.TypeForwardedToAttribute> attribute.*
- [**CS1068**](#type-forwarding): *The type name could not be found in the global namespace. This type has been forwarded to another assembly. Consider adding a reference to that assembly.*
- [**CS1069**](#type-forwarding): *The type name could not be found in the namespace. This type has been forwarded to another assembly. Consider adding a reference to that assembly.*
- [**CS1070**](#type-forwarding): *The type name could not be found. This type has been forwarded to another assembly. Consider adding a reference to that assembly.*
- [**CS1704**](#duplicate-references): *An assembly with the same simple name has already been imported. Try removing one of the references or sign them to enable side-by-side.*
- [**CS1714**](#missing-references): *The base class or interface of this type could not be resolved or is invalid.*
- [**CS1760**](#duplicate-references): *Multiple assemblies refer to the same metadata but only one is a linked reference (specified using /link option); consider removing one of the references.*
- [**CS7008**](#invalid-assembly-reference): *The assembly name is reserved and cannot be used as a reference in an interactive session.*
- [**CS7068**](#invalid-assembly-reference): *Reference to type claims it is defined in this assembly, but it is not defined in source or any added modules.*
- [**CS7069**](#invalid-assembly-reference): *Reference to type claims it is defined in another assembly, but it could not be found.*
- [**CS7071**](#invalid-assembly-reference): *Assembly reference is invalid and cannot be resolved.*
- [**CS7079**](#invalid-assembly-reference): *The type is defined in a module that has not been added. You must add the module.*
- [**CS8090**](#invalid-assembly-reference): *There is an error in a referenced assembly.*
- [**CS8203**](#invalid-assembly-reference): *Invalid assembly name.*
- [**CS9286**](#missing-references): *Type does not contain a definition and no accessible extension member for receiver type could be found (are you missing a using directive or an assembly reference?)*

In addition, the following warnings are covered in this article:

- [**CS1683**](#invalid-assembly-reference): *Reference to type 'Type Name' claims it is defined in this assembly, but it is not defined in source or any added modules.*

## Missing references

The following errors and warnings indicate that you're missing an assembly reference:

- **CS0012**: *The type 'type' is defined in an assembly that is not referenced. You must add a reference to assembly 'assembly'.*
- **CS0234**: *The type or namespace name does not exist in the namespace (are you missing an assembly reference?)*
- **CS0246**: *The type or namespace name could not be found (are you missing a using directive or an assembly reference?)*
- **CS9286**: *Type does not contain a definition and no accessible extension member for receiver type could be found (are you missing a using directive or an assembly reference?)*

These compiler errors indicate one of these problems in your code:

- The project doesn't reference the required assembly. To fix this error, [add a reference to the required assembly](../../../standard/assembly/index.md#add-a-reference-to-an-assembly).
- You misspelled the name of a type. Check the name of the type.
- You used a variable name where the name of a <xref:System.Type?displayProperty=nameWithType> was expected, such as in the [`typeof` operator](../operators/type-testing-and-cast.md#the-typeof-operator) or the [`is` operator](../operators/type-testing-and-cast.md#the-is-operator).
- You used the [global scope operator, (`::`)](../operators/namespace-alias-qualifier.md) when the type isn't in the global namespace.
- You're accessing an extension member and either the namespace isn't specified in a `using` directive, or you're not referencing the assembly that contains the extension.

## Type forwarding

- **CS1068**: *The type name could not be found in the global namespace. This type has been forwarded to another assembly. Consider adding a reference to that assembly.*
- **CS1069**: *The type name could not be found in the namespace. This type has been forwarded to another assembly. Consider adding a reference to that assembly.*
- **CS1070**: *The type name could not be found. This type has been forwarded to another assembly. Consider adding a reference to that assembly.*

These errors indicate an error referencing a type forwarded to a different assembly. To address any of these errors, add a reference to the assembly indicated in the error message.

## Duplicate references

The following errors indicate a duplicate assembly reference:

- **CS1704**: *An assembly with the same simple name has already been imported. Try removing one of the references or sign them to enable side-by-side.*
- **CS1760**: *Multiple assemblies refer to the same metadata but only one is a linked reference (specified using /link option); consider removing one of the references.*

To fix these errors, you must either remove one of the references, or resolve the duplication. Causes for duplication include:

- Multiple unsigned assemblies have the same name.
- Your project references multiple versions of the same assembly.

## Invalid assembly reference

The following errors indicate that an assembly reference is invalid:

- **CS7008**: *The assembly name is reserved and cannot be used as a reference in an interactive session.*
- **CS7069**: *Reference to type claims it is defined in another assembly, but it could not be found.*
- **CS7071**: *Assembly reference is invalid and cannot be resolved.*
- **CS7079**: *The type is defined in a module that has not been added. You must add the module.*
- **CS8090**: *There is an error in a referenced assembly.*
- **CS8203**: *Invalid assembly name.*

The following warning also indicates an invalid reference assembly:

- **CS1683**: *Reference to type 'Type Name' claims it is defined in this assembly, but it is not defined in source or any added modules*

Check that the assembly name is spelled correctly. The referenced assembly file might be invalid.

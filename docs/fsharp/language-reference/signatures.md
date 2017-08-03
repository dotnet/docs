---
title: Signatures (F#)
description: Learn how to use an F# signature file to hold information about the public signatures of a set of F# program elements, such as types, namespaces, and modules.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 76c84a62-b2f6-44ec-8238-e687e2f7d18e 
---

# Signatures

A signature file contains information about the public signatures of a set of F# program elements, such as types, namespaces, and modules. It can be used to specify the accessibility of these program elements.


## Remarks
For each F# code file, you can have a *signature file*, which is a file that has the same name as the code file but with the extension .fsi instead of .fs. Signature files can also be added to the compilation command-line if you are using the command line directly. To distinguish between code files and signature files, code files are sometimes referred to as *implementation files*. In a project, the signature file should precede the associated code file.

A signature file describes the namespaces, modules, types, and members in the corresponding implementation file. You use the information in a signature file to specify what parts of the code in the corresponding implementation file can be accessed from code outside the implementation file, and what parts are internal to the implementation file. The namespaces, modules, and types that are included in the signature file must be a subset of the namespaces, modules, and types that are included in the implementation file. With some exceptions noted later in this topic, those language elements that are not listed in the signature file are considered private to the implementation file. If no signature file is found in the project or command line, the default accessibility is used.

For more information about the default accessibility, see [Access Control](access-control.md).

In a signature file, you do not repeat the definition of the types and the implementations of each method or function. Instead, you use the signature for each method and function, which acts as a complete specification of the functionality that is implemented by a module or namespace fragment. The syntax for a type signature is the same as that used in abstract method declarations in interfaces and abstract classes, and is also shown by IntelliSense and by the F# interpreter fsi.exe when it displays correctly compiled input.

If there is not enough information in the type signature to indicate whether a type is sealed, or whether it is an interface type, you must add an attribute that indicates the nature of the type to the compiler. Attributes that you use for this purpose are described in the following table.



|Attribute|Description|
|---------|-----------|
|`[<Sealed>]`|For a type that has no abstract members, or that should not be extended.|
|`[<Interface>]`|For a type that is an interface.|
The compiler produces an error if the attributes are not consistent between the signature and the declaration in the implementation file.

Use the keyword `val` to create a signature for a value or function value. The keyword `type` introduces a type signature.

You can generate a signature file by using the `--sig` compiler option. Generally, you do not write .fsi files manually. Instead, you generate .fsi files by using the compiler, add them to your project, if you have one, and edit them by removing methods and functions that you do not want to be accessible.

There are several rules for type signatures:


- Type abbreviations in an implementation file must not match a type without an abbreviation in a signature file.


- Records and discriminated unions must expose either all or none of their fields and constructors, and the order in the signature must match the order in the implementation file. Classes can reveal some, all, or none of their fields and methods in the signature.


- Classes and structures that have constructors must expose the declarations of their base classes (the `inherits` declaration). Also, classes and structures that have constructors must expose all of their abstract methods and interface declarations.


- Interface types must reveal all their methods and interfaces.


The rules for value signatures are as follows:


- Modifiers for accessibility (`public`, `internal`, and so on) and the `inline` and `mutable` modifiers in the signature must match those in the implementation.


- The number of generic type parameters (either implicitly inferred or explicitly declared) must match, and the types and type constraints in generic type parameters must match.


- If the `Literal` attribute is used, it must appear in both the signature and the implementation, and the same literal value must be used for both.


- The pattern of parameters (also known as the *arity*) of signatures and implementations must be consistent.


The following code example shows an example of a signature file that has namespace, module, function value, and type signatures together with the appropriate attributes. It also shows the corresponding implementation file.

[!code-fsharp[Main](../../../samples/snippets/fsharp/fssignatures/snippet9002.fs)]

The following code shows the implementation file.

[!code-fsharp[Main](../../../samples/snippets/fsharp/fssignatures/snippet9001.fs)]
    
## See Also
[F# Language Reference](index.md)

[Access Control](access-control.md)

[Compiler Options](compiler-options.md)

---
title: "-refonly (C# Compiler Options)"
ms.date: 07/08/2017
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/refonly"
helpviewer_keywords: 
  - "/refonly compiler option [C#]"
  - "-refonly compiler option [C#]"
  - "refonly compiler option [C#]"
author: "BillWagner"
ms.author: "wiwagn"
---

# -refonly (C# Compiler Options)

The **-refonly** option indicates that a reference assembly should be output instead of an implementation assembly, as the primary output. The `-refonly` parameter silently disables outputting PDBs, as reference assemblies cannot be executed.

## Syntax

```console
-refonly
```

## Remarks

Metadata-only assemblies have their method bodies replaced with a single `throw null` body, but include all members except anonymous types. The reason for using `throw null` bodies (as opposed to no bodies) is so that PEVerify could run and pass (thus validating the completeness of the metadata).

Reference assemblies include an assembly-level `ReferenceAssembly` attribute. This attribute may be specified in source (then the compiler won't need to synthesize it). Because of this attribute, runtimes will refuse to load reference assemblies for execution (but they can still be loaded in reflection-only mode). Tools that reflect on assemblies need to ensure they load reference assemblies as reflection-only, otherwise they will receive a typeload error from the runtime.

Reference assemblies further remove metadata (private members) from metadata-only assemblies:

- A reference assembly only has references for what it needs in the API surface. The real assembly may have additional references related to specific implementations. For instance, the reference assembly for `class C { private void M() { dynamic d = 1; ... } }` does not reference any types required for `dynamic`.
- Private function-members (methods, properties, and events) are removed in cases where their removal doesn't observably impact compilation. If there are no `InternalsVisibleTo` attributes, do the same for internal function-members.
- But all types (including private or nested types) are kept in reference assemblies. All attributes are kept (even internal ones).
- All virtual methods are kept. Explicit interface implementations are kept. Explicitly implemented properties and events are kept, as their accessors are virtual (and are therefore kept).
- All fields of a struct are kept. (This is a candidate for post-C#-7.1 refinement)

The `-refonly` and [`-refout`](refout-compiler-option.md) options are mutually exclusive.

## See also
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)  
 [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)

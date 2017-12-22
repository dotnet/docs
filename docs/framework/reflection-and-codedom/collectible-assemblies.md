---
title: Collectible assemblies for dynamic type generation
description: 
ms.date: "08/29/2017"
ms.prod: ".net"
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "reflection, dynamic assembly"
  - "assemblies, collectible"
  - "collectible assemblies, retrieving"
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Collectible assemblies for dynamic type generation

*Collectible assemblies* are dynamic assemblies that can be unloaded without unloading the application domain in which they were created. All managed and unmanaged memory used by a collectible assembly and the types it contains can be reclaimed. Information such as the assembly name is removed from internal tables.

To enable unloading, use the <xref:System.Reflection.Emit.AssemblyBuilderAccess.RunAndCollect?displayProperty=nameWithType> flag when you create a dynamic assembly. The assembly is transient (that is, it cannot be saved) and is subject to limitations described in the [Restrictions on Collectible Assemblies](#restrictions-on-collectible-assemblies) section. The common language runtime (CLR) unloads a collectible assembly automatically when you release all objects associated with the assembly. In all other respects, collectible assemblies are created and used in the same way as other dynamic assemblies.

## Lifetime of collectible assemblies

The lifetime of a collectible assembly is controlled by the existence of references to the types it contains and the objects that are created from those types. The common language runtime does not unload an assembly as long as one or more of the following exist (`T` is any type that is defined in the assembly): 

- An instance of `T`.

- An instance of an array of `T`.
 
- An instance of a generic type that has `T` as one of its type arguments. This includes generic collections of `T`, even if that collection is empty.

- An instance of <xref:System.Type> or <xref:System.Reflection.Emit.TypeBuilder> that represents `T`. 

   > [!IMPORTANT]
   > You must release all objects that represent parts of the assembly. The <xref:System.Reflection.Emit.ModuleBuilder> that defines `T` keeps a reference to the <xref:System.Reflection.Emit.TypeBuilder>, and the <xref:System.Reflection.Emit.AssemblyBuilder> object keeps a reference to the <xref:System.Reflection.Emit.ModuleBuilder>, so references to these objects must be released. Even the existence of a <xref:System.Reflection.Emit.LocalBuilder> or an <xref:System.Reflection.Emit.ILGenerator> used in the construction of `T` prevents unloading.

- A static reference to `T` by another dynamically defined type `T1` that is still reachable by executing code. For example, `T1` might derive from `T`, or `T` might be the type of a parameter in a method of `T1`.
 
- A **ByRef** to a static field that belongs to `T`.

- A <xref:System.RuntimeTypeHandle>, <xref:System.RuntimeFieldHandle>, or <xref:System.RuntimeMethodHandle> that refers to `T` or to a component of `T`.

- An instance of any reflection object that could be used indirectly or directly to access the <xref:System.Type> object that represents `T`. For example, the <xref:System.Type> object for `T` can be obtained from an array type whose element type is `T`, or from a generic type that has `T` as a type argument. 

- A method `M` on the call stack of any thread, where `M` is a method of `T` or a module-level method that is defined in the assembly.

- A delegate to a static method that is defined in a module of the assembly.

If only one item from this list exists for only one type or one method in the assembly, the runtime cannot unload the assembly.

> [!NOTE]
> The runtime does not actually unload the assembly until finalizers have run for all items in the list.

For purposes of tracking lifetime, a constructed generic type such as `List<int>` (in C#) or `List(Of Integer)` (in Visual Basic) that is created and used in the generation of a collectible assembly is considered to have been defined either in the assembly that contains the generic type definition or in an assembly that contains the definition of one of its type arguments. The exact assembly that is used is an implementation detail and subject to change.
 
## Restrictions on collectible assemblies

The following restrictions apply to collectible assemblies: 

- **Static references**   
  Types in an ordinary dynamic assembly cannot have static references to types that are defined in a collectible assembly. For example, if you define an ordinary type that inherits from a type in a collectible assembly, a <xref:System.NotSupportedException> exception is thrown. A type in a collectible assembly can have static references to a type in another collectible assembly, but this extends the lifetime of the referenced assembly to the lifetime of the referencing assembly.

- **COM interop**   
   No COM interfaces can be defined within a collectible assembly, and no instances of types within a collectible assembly can be converted into COM objects. A type in a collectible assembly cannot serve as a COM callable wrapper (CCW) or runtime callable wrapper (RCW). However, types in collectible assemblies can use objects that implement COM interfaces.

- **Platform invoke**   
   Methods that have the <xref:System.Runtime.InteropServices.DllImportAttribute> attribute will not compile when they are declared in a collectible assembly. The <xref:System.Reflection.Emit.OpCodes.Calli?displayProperty=nameWithType> instruction cannot be used in the implementation of a type in a collectible assembly, and such types cannot be marshaled to unmanaged code. However, you can call into native code by using an entry point that is declared in a non-collectible assembly.
 
- **Marshaling**   
   Objects (in particular, delegates) that are defined in collectible assemblies cannot be marshaled. This is a restriction on all transient emitted types.

- **Assembly loading**   
   Reflection emit is the only mechanism that is supported for loading collectible assemblies. Assemblies that are loaded by using any other form of assembly loading cannot be unloaded.
 
- **Context-bound objects**    
   Context-static variables are not supported. Types in a collectible assembly cannot extend <xref:System.ContextBoundObject>. However, code in collectible assemblies can use context-bound objects that are defined elsewhere.

- **Thread-static data**       
   Thread-static variables are not supported.

## See also

[Emitting Dynamic Methods and Assemblies](emitting-dynamic-methods-and-assemblies.md)

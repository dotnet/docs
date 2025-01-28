---
title: "Attributes interpreted by the compiler: Pseudo-attributes"
ms.date: 01/28/2025
description: "Learn about attributes you can add to code that are written to IL as modifiers. These custom attributes aren't emitted as attributes in the compiled output."
---
# Custom attributes that generate flags or options in the Intermediate Language (IL) output

You add these attributes to your code for the compiler to emit a specified Intermediate Language (IL) modifier. These attributes instruct the compiler to include the corresponding IL modifier in the output.

| Attribute                                                                            | Modifier        | Comments  |
|--------------------------------------------------------------------------------------|-----------------|-----------|
| <xref:System.Runtime.InteropServices.ComImportAttribute?displayProperty=fullName>    | `import`        |           |
| <xref:System.Runtime.InteropServices.DllImportAttribute?displayProperty=fullName>    | `pinvokeimpl`   | You can add options listed in the constructor. |
| <xref:System.Runtime.InteropServices.FieldOffsetAttribute?displayProperty=fullName>  | `.field`        | This sets the field offset for memory layout.  |
| <xref:System.Runtime.InteropServices.MarshalAsAttribute>                             | `marshal`       | You can set options listed in the constructor. |
| <xref:System.Runtime.CompilerServices.MethodImplAttribute?displayProperty=fullName>  | `flag`          | Constructor arguments specify specific named flags such as `aggressiveinlining` or `forwardref`. These flags also specify the `native`, `managed`, or `optil` modifiers for the <xref:System.Runtime.CompilerServices.MethodCodeType?displayProperty=fullName> field. |
| <xref:System.NonSerializedAttribute?displayProperty=fullName>                        | `notserialized` |           |
| <xref:System.Runtime.InteropServices.OptionalAttribute?displayProperty=fullName>     | `[opt]`         |           |
| <xref:System.Runtime.InteropServices.PreserveSigAttribute?displayProperty=fullName>  | `preservesig`   |           |
| <xref:System.SerializableAttribute?displayProperty=fullName>                         | `serializable`  |           |
| <xref:System.Runtime.InteropServices.StructLayoutAttribute?displayProperty=fullName> | `auto`, `sequential`, or `explicit` | Layout options can be set using the parameters. |
| <xref:System.Runtime.CompilerServices.IndexerNameAttribute?displayProperty=fullName> |                 | You add this attribute to an indexer to set a different method name. By default, indexers are compiled to a property named `Item`. You can specify a different name using this attribute. |

Some of these custom attributes are applied using other C# syntax rather than adding the attribute to your source code.

| Attribute                                                                                        | Comments |
|--------------------------------------------------------------------------------------------------|----------|
| <xref:System.Runtime.InteropServices.DefaultParameterValueAttribute?displayProperty=fullName>    | Specifies the default value for the parameter. Use the [default parameter syntax](../../methods.md#optional-parameters-and-arguments). |
| <xref:System.Runtime.InteropServices.InAttribute?displayProperty=fullName>                       | Specifies the IL `[in]` modifier. Use the [`in`](../keywords/method-parameters.md#in-parameter-modifier) or [`ref readonly`](../keywords/method-parameters.md#ref-readonly-modifier) modifiers. |
| <xref:System.Runtime.InteropServices.OutAttribute?displayProperty=fullName>                       | Specifies the IL `[out]` modifier. Use the [`out`](../keywords/method-parameters.md#out-parameter-modifier) modifier. |
| <xref:System.Runtime.CompilerServices.SpecialNameAttribute?displayProperty=fullName>             | Specifies the IL `specialname` modifier. The compiler automatically adds this modifier for methods that require it. |
| <xref:System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute?displayProperty=nameWithType> | This attribute is required for the `delegate*` feature. The compiler adds it to any [`delegate*`](../unsafe-code.md#function-pointers) that requires its use. However, you must add this attribute to any method declaration when that method is assigned to a function pointer. |

The following attributes are generally disallowed in C# source. They're listed here to aid library authors who use reflection, and to ensure you don't create custom attributes with the same fully qualified name.

| Attribute                                                                                        | Comments  |
|--------------------------------------------------------------------------------------------------|---------|
| <xref:System.Runtime.CompilerServices.CompilerFeatureRequiredAttribute?displayProperty=fullName> | Prevents downlevel compilers from using metadata it can't safely understand. |
| <xref:System.Runtime.CompilerServices.DecimalConstantAttribute?displayProperty=fullName>         | Encodes `const decimal` fields. The runtime doesn't support `decimal` values as constant values. |
| <xref:System.Reflection.DefaultMemberAttribute?displayProperty=fullName>                         | Encodes indexers with <xref:System.Runtime.CompilerServices.IndexerNameAttribute?displayProperty=fullName>. This attribute notes the default indexer when its name is different than `Item`. This attribute is allowed in source. |
| <xref:System.Runtime.CompilerServices.DynamicAttribute?displayProperty=fullName>                 | Encodes whether a type in a signature is `dynamic` (versus `object`). |
| <xref:System.Runtime.CompilerServices.ExtensionAttribute?displayProperty=fullName>               | This attribute notes extension methods. The compiler also places this attribute on the containing classes. |
| <xref:System.Runtime.CompilerServices.FixedBufferAttribute?displayProperty=fullName>             | This attribute specifies `fixed` struct fields. |
| <xref:System.Runtime.CompilerServices.IsByRefLikeAttribute?displayProperty=fullName>             | This attribute specifies a `ref` struct. |
| <xref:System.Runtime.CompilerServices.IsReadOnlyAttribute?displayProperty=fullName>              | This attribute indicates that a parameter has the `in` modifier. It distinguishes `in` parameters from `readonly ref` or `[In] ref`. |
| <xref:System.Runtime.CompilerServices.RequiresLocationAttribute?displayProperty=fullName>        | This attribute indicates that a parameter has the `readonly ref` modifier. It distinguishes `readonly ref` from `in` or `[In] ref`. |
| <xref:System.Runtime.CompilerServices.IsUnmanagedAttribute?displayProperty=fullName>             | This attribute specifies the `unmanaged` constraint on a type parameter. |
| <xref:System.Runtime.CompilerServices.NullableAttribute?displayProperty=fullName>, <xref:System.Runtime.CompilerServices.NullableContextAttribute?displayProperty=fullName>, <xref:System.Runtime.CompilerServices.NullablePublicOnlyAttribute?displayProperty=fullName> | These attributes encode nullable annotations in your source code. |
| <xref:System.ParamArrayAttribute?displayProperty=fullName>                                       | This attribute encodes the `params` modifier on array parameters. |
| <xref:System.Runtime.CompilerServices.ParamCollectionAttribute?displayProperty=fullName>         | This attribute encodes the `params` modifier on non-array parameters. |
| <xref:System.Runtime.CompilerServices.RefSafetyRulesAttribute?displayProperty=fullName>          | This attribute specifies the C# version that is required in order to understand ref safety annotations in the assembly. Ref safety rules evolve as C# gets new features. |
| <xref:System.Runtime.CompilerServices.RequiredMemberAttribute?displayProperty=fullName>          | This attribute indicates that the `required` modifier was placed on a member declaration. It's the encoding of the [required members](../keywords/required.md) language feature. |
| <xref:System.Runtime.CompilerServices.TupleElementNamesAttribute?displayProperty=fullName>       | This attribute encodes tuple element names used in signatures. |

In addition, the compiler can generate a declaration for other attributes used internally. The compiler generates these attributes in the <xref:System.Runtime.CompilerServices> namespace for its own use. Some aren't in the .NET Runtime libraries. Instead, the compiler synthesizes a definition for an `internal` type declaration in any assembly where the attribute is needed.

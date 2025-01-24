---
title: "Attributes interpreted by the compiler: Pseudo-attributes"
ms.date: 01/23/2025
description: "Learn about attributes you can add to code that are written to IL as modifiers. These custom attributes aren't emitted as attributes in the compiled output."
---
# Custom attributes that generate flags or options in the Intermediate Language (IL) output

You add these attributes to your code for the compiler to emit specified Intermediate Language (IL) modifier. These attributes instruct the compiler to include the corresponding IL modifier in the output. These IL modifiers can be controlled in C# using these attributes:

- <xref:System.Runtime.InteropServices.ComImportAttribute?displayProperty=fullName>: Specifies the `import` modifier.
- <xref:System.Runtime.InteropServices.DllImportAttribute?displayProperty=fullName>: Specifies the `pinvokeimpl` modifier. You can add options listed in the constructor.
- <xref:System.Runtime.InteropServices.FieldOffsetAttribute?displayProperty=fullName>: Specifies the `.field` offset modifier.
- <xref:System.Runtime.InteropServices.MarshalAsAttribute>: Specifies the IL `marshal` modifier. You can set options listed in the constructor.
- <xref:System.Runtime.CompilerServices.MethodImplAttribute?displayProperty=fullName>: maps to the IL `flag` modifier. Constructor arguments specify specific named flags such as `aggressiveinlining` or `forwardref`, as well as `native`, `managed`, or `optil` modifiers for the <xref:System.Runtime.CompilerServices.MethodCodeType?displayProperty=fullName> field.
- <xref:System.NonSerializedAttribute?displayProperty=fullName>: Specifies the IL `notserialized` modifier.
- <xref:System.Runtime.InteropServices.OptionalAttribute?displayProperty=fullName>: Specifies the IL `[opt]` modifier.
- <xref:System.Runtime.InteropServices.OutAttribute?displayProperty=fullName>: Specifies the IL `[out]` modifier.
- <xref:System.Runtime.InteropServices.PreserveSigAttribute?displayProperty=fullName>: Specifies the IL `preservesig` modifier.
- <xref:System.SerializableAttribute?displayProperty=fullName>: Specifies the IL `serializable` modifier.
- <xref:System.Runtime.InteropServices.StructLayoutAttribute?displayProperty=fullName>: Specifies the IL `auto`, `sequential`, or `explicit` modifiers. Layout options can be set using the parameters.
- <xref:System.Runtime.CompilerServices.IndexerNameAttribute?displayProperty=fullName>: You add this attribute to an indexer to set a different method name. By default, indexers are compiled to a property named `Item`. You can specify a different name using this attribute.

Other custom attributes are generally applied using other C# syntax rather than adding the attribute to your source code.

- <xref:System.Runtime.InteropServices.DefaultParameterValueAttribute?displayProperty=fullName>: Specifies the default value for the parameter. Use the [default parameter syntax](../../methods.md#optional-parameters-and-arguments)
- <xref:System.Runtime.InteropServices.InAttribute?displayProperty=fullName>: Specifies the IL `[in]` modifier. Use the [`in`](../keywords/method-parameters.md#in-parameter-modifier) or [`ref readonly`](../keywords/method-parameters.md#ref-readonly-modifier).
- <xref:System.Runtime.CompilerServices.SpecialNameAttribute?displayProperty=fullName>: Specifies the IL `specialname` modifier. The compiler automatically uses the for methods that require the `specialname` modifier.
- <xref:System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute?displayProperty=nameWithType>: This attribute is required for the `delegate*` feature. The compiler adds it to any [`delegate*`](../unsafe-code.md#function-pointers) requires its use.

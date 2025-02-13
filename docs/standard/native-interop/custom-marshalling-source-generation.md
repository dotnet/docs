---
title: Custom marshalling source generation
description: Learn about compile-time source generation for custom marshalling for interop in .NET.
ms.date: 08/09/2022
---

# Source generation for custom marshalling

.NET 7 introduces a new mechanism for customization of how a type is marshalled when using source-generated interop. The [source generator for P/Invokes](pinvoke-source-generation.md) recognizes <xref:System.Runtime.InteropServices.Marshalling.MarshalUsingAttribute> and <xref:System.Runtime.InteropServices.Marshalling.NativeMarshallingAttribute> as indicators for custom marshalling of a type.

<xref:System.Runtime.InteropServices.Marshalling.NativeMarshallingAttribute> can be applied to a type to indicate the default custom marshalling for that type. The <xref:System.Runtime.InteropServices.Marshalling.MarshalUsingAttribute> can be applied to a parameter or return value to indicate the custom marshalling for that particular usage of the type, taking precedence over any <xref:System.Runtime.InteropServices.Marshalling.NativeMarshallingAttribute> that may be on the type itself. Both of these attributes expect a <xref:System.Type>&mdash;the entry-point marshaller type&mdash;that's marked with one or more <xref:System.Runtime.InteropServices.Marshalling.CustomMarshallerAttribute> attributes. Each <xref:System.Runtime.InteropServices.Marshalling.CustomMarshallerAttribute> indicates which marshaller implementation should be used to marshal the specified managed type for the specified <xref:System.Runtime.InteropServices.Marshalling.MarshalMode>.

## Marshaller implementation

Marshaller implementations can either be stateless or stateful. If the marshaller type is a `static` class, it's considered stateless. If it's a value type, it's considered stateful and one instance of that marshaller will be used to marshal a specific parameter or return value. Different [shapes for the marshaller implementation][value_shapes] are expected based on whether a marshaller is stateless or stateful and whether it supports marshalling from managed to unmanaged, unmanaged to managed, or both. The .NET SDK includes analyzers and code fixers to help with implementing marshallers that conform to the require shapes.

### `MarshalMode`

The <xref:System.Runtime.InteropServices.Marshalling.MarshalMode> specified in a <xref:System.Runtime.InteropServices.Marshalling.CustomMarshallerAttribute> determines the expected marshalling support and [shape][value_shapes] for the marshaller implementation. All modes support stateless marshaller implementations. Element marshalling modes do not support stateful marshaller implementations.

| `MarshalMode` | Expected support | Can be stateful |
| --- | --- | --- |
| <xref:System.Runtime.InteropServices.Marshalling.MarshalMode.ManagedToUnmanagedIn> | Managed to unmanaged | Yes |
| <xref:System.Runtime.InteropServices.Marshalling.MarshalMode.ManagedToUnmanagedRef> | Managed to unmanaged and unmanaged to managed | Yes |
| <xref:System.Runtime.InteropServices.Marshalling.MarshalMode.ManagedToUnmanagedOut> | Unmanaged to managed | Yes |
| <xref:System.Runtime.InteropServices.Marshalling.MarshalMode.UnmanagedToManagedIn> | Unmanaged to managed | Yes |
| <xref:System.Runtime.InteropServices.Marshalling.MarshalMode.UnmanagedToManagedRef> | Managed to unmanaged and unmanaged to managed | Yes |
| <xref:System.Runtime.InteropServices.Marshalling.MarshalMode.UnmanagedToManagedOut> | Managed to unmanaged | Yes |
| <xref:System.Runtime.InteropServices.Marshalling.MarshalMode.ElementIn> | Managed to unmanaged | No |
| <xref:System.Runtime.InteropServices.Marshalling.MarshalMode.ElementRef> | Managed to unmanaged and unmanaged to managed | No |
| <xref:System.Runtime.InteropServices.Marshalling.MarshalMode.ElementOut> | Unmanaged to managed | No |

<xref:System.Runtime.InteropServices.Marshalling.MarshalMode.Default?displayProperty=nameWithType> indicates that the marshaller implementation should be used for any mode that it supports. If a marshaller implementation for a more specific `MarshalMode` is also specified, it takes precedence over `MarshalMode.Default`.

## Basic usage

We can specify <xref:System.Runtime.InteropServices.Marshalling.NativeMarshallingAttribute> on a type, pointing at an entry-point marshaller type that is either a `static` class or a `struct`.

```csharp
[NativeMarshalling(typeof(ExampleMarshaller))]
public struct Example
{
    public string Message;
    public int Flags;
}
```

`ExampleMarshaller`, the entry-point marshaller type, is marked with <xref:System.Runtime.InteropServices.Marshalling.CustomMarshallerAttribute>, pointing at a [marshaller implementation](#marshaller-implementation) type. In this example, `ExampleMarshaller` is both the entry point and the implementation. It conforms to [marshaller shapes][value_shapes] expected for custom marshalling of a value.

```csharp
[CustomMarshaller(typeof(Example), MarshalMode.Default, typeof(ExampleMarshaller))]
internal static class ExampleMarshaller
{
    public static ExampleUnmanaged ConvertToUnmanaged(Example managed)
        => throw new NotImplementedException();

    public static Example ConvertToManaged(ExampleUnmanaged unmanaged)
        => throw new NotImplementedException();

    public static void Free(ExampleUnmanaged unmanaged)
        => throw new NotImplementedException();

    internal struct ExampleUnmanaged
    {
        public IntPtr Message;
        public int Flags;
    }
}
```

The `ExampleMarshaller` in the example is a stateless marshaller that implements support for marshalling from managed to unmanaged and from unmanaged to managed. The marshalling logic is entirely controlled by your marshaller implementation. Marking fields on a struct with <xref:System.Runtime.InteropServices.MarshalAsAttribute> has no effect on the generated code.

The `Example` type can then be used in P/Invoke source generation. In the following P/Invoke example, `ExampleMarshaller` will be used to marshal the parameter from managed to unmanaged. It will also be used to marshal the return value from unmanaged to managed.

```csharp
[LibraryImport("nativelib")]
internal static partial Example ConvertExample(Example example);
```

To use a different marshaller for a specific usage of the `Example` type, specify <xref:System.Runtime.InteropServices.Marshalling.MarshalUsingAttribute> at the use site. In the following P/Invoke example, `ExampleMarshaller` will be used to marshal the parameter from managed to unmanaged. `OtherExampleMarshaller` will be used to marshal the return value from unmanaged to managed.

```csharp
[LibraryImport("nativelib")]
[return: MarshalUsing(typeof(OtherExampleMarshaller))]
internal static partial Example ConvertExample(Example example);
```

### Collections

Apply the <xref:System.Runtime.InteropServices.Marshalling.ContiguousCollectionMarshallerAttribute> to a marshaller entry-point type to indicate that it's for contiguous collections. The type must have one more type parameter than the associated managed type. The last type parameter is a placeholder and will be filled in by the source generator with the unmanaged type for the collection's element type.

For example, you can specify custom marshalling for a <xref:System.Collections.Generic.List%601>. In the following code, `ListMarshaller` is both the entry point and the implementation. It conforms to [marshaller shapes][collection_shapes] expected for custom marshalling of a collection.

```csharp
[ContiguousCollectionMarshaller]
[CustomMarshaller(typeof(List<>), MarshalMode.Default, typeof(ListMarshaller<,>))]
public unsafe static class ListMarshaller<T, TUnmanagedElement> where TUnmanagedElement : unmanaged
{
    public static byte* AllocateContainerForUnmanagedElements(List<T> managed, out int numElements)
        => throw new NotImplementedException();

    public static ReadOnlySpan<T> GetManagedValuesSource(List<T> managed)
        => throw new NotImplementedException();

    public static Span<TUnmanagedElement> GetUnmanagedValuesDestination(byte* unmanaged, int numElements)
        => throw new NotImplementedException();

    public static List<T> AllocateContainerForManagedElements(byte* unmanaged, int length)
        => throw new NotImplementedException();

    public static Span<T> GetManagedValuesDestination(List<T> managed)
        => throw new NotImplementedException();

    public static ReadOnlySpan<TUnmanagedElement> GetUnmanagedValuesSource(byte* nativeValue, int numElements)
        => throw new NotImplementedException();

    public static void Free(byte* unmanaged)
        => throw new NotImplementedException();
}
```

The `ListMarshaller` in the example is a stateless collection marshaller that implements support for marshalling from managed to unmanaged and from unmanaged to managed for a <xref:System.Collections.Generic.List%601>. In the following P/Invoke example, `ListMarshaller` will be used to marshal the parameter from managed to unmanaged and to marshal the return value from unmanaged to managed. <xref:System.Runtime.InteropServices.Marshalling.MarshalUsingAttribute.CountElementName> indicates that the `numValues` parameter should be used as the element count when marshalling the return value from unmanaged to managed.

```csharp
[LibraryImport("nativelib")]
[return: MarshalUsing(typeof(ListMarshaller<,>), CountElementName = "numValues")]
internal static partial List<int> ConvertList(
    [MarshalUsing(typeof(ListMarshaller<,>))] List<int> list,
    out int numValues);
```

## See also

- [System.Runtime.InteropServices.Marshalling APIs](xref:System.Runtime.InteropServices.Marshalling)
- [P/Invoke source generation](pinvoke-source-generation.md)
- [Disabling runtime marshalling](disabled-marshalling.md)
- Marshaller shapes
  - [Values][value_shapes]
  - [Collections][collection_shapes]

[value_shapes]:https://github.com/dotnet/runtime/blob/main/docs/design/libraries/LibraryImportGenerator/UserTypeMarshallingV2.md#value-marshaller-shapes
[collection_shapes]:https://github.com/dotnet/runtime/blob/main/docs/design/libraries/LibraryImportGenerator/UserTypeMarshallingV2.md#linear-array-like-collection-marshaller-shapes

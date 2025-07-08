---
title: Custom marshalling source generation
description: Learn about compile-time source generation for custom marshalling for interop in .NET.
ms.date: 08/09/2022
---

# Source generation for custom marshalling

.NET 7 introduces a new mechanism for customization of how a type is marshalled when using source-generated interop. The [source generator for P/Invokes](pinvoke-source-generation.md) recognizes <xref:System.Runtime.InteropServices.Marshalling.MarshalUsingAttribute> and <xref:System.Runtime.InteropServices.Marshalling.NativeMarshallingAttribute> as indicators for custom marshalling of a type.

<xref:System.Runtime.InteropServices.Marshalling.NativeMarshallingAttribute> can be applied to a type to indicate the default custom marshalling for that type. The <xref:System.Runtime.InteropServices.Marshalling.MarshalUsingAttribute> can be applied to a parameter or return value to indicate the custom marshalling for that particular usage of the type, taking precedence over any <xref:System.Runtime.InteropServices.Marshalling.NativeMarshallingAttribute> that may be on the type itself. Both of these attributes expect a <xref:System.Type>&mdash;the entry-point marshaller type&mdash;that's marked with one or more <xref:System.Runtime.InteropServices.Marshalling.CustomMarshallerAttribute> attributes. Each <xref:System.Runtime.InteropServices.Marshalling.CustomMarshallerAttribute> indicates which marshaller implementation should be used to marshal the specified managed type for the specified <xref:System.Runtime.InteropServices.Marshalling.MarshalMode>.

## Marshaller implementation

Custom marshaller implementations can either be stateless or stateful. If the marshaller type is a `static` class it's considered stateless, and the implementation methods should do no tracking of state across calls. If it's a value type, it's considered stateful and one instance of that marshaller will be used to marshal a specific parameter or return value, allowing for state to be preserved across the marshalling and unmarshalling process.

# Marshaller shapes

The set of methods that the marshalling generator expects from a custom marshaller type is referred to as the marshaller shape. Since the marshalling generator supports stateless, static custom marshaller types in .NET Standard 2.0 (which doesn't support static interface methods), there are not interface types provided that define the marshaller shapes. Instead, the shapes are documented below. The marshaller shape expected depends on the whether the marshaller is stateless or stateful, and whether it supports marshalling from managed to unmanaged, unmanaged to managed, or both (declared with `CustomMarshallerAttribute.MarshalMode`). The .NET SDK includes analyzers and code fixers to help with implementing marshallers that conform to the required shapes.

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

<xref:System.Runtime.InteropServices.Marshalling.MarshalMode.Default?displayProperty=nameWithType> indicates that the marshaller implementation should be used for any mode that it supports (assumed by the methods it implements). If a marshaller implementation for a more specific `MarshalMode` is also specified, it takes precedence over `MarshalMode.Default`.

## Basic usage

### Marshalling a single value

To create a custom marshaller for a type, you need to define an entry-point marshaller type that implements the required marshalling methods. The entry-point marshaller type can be a `static` class or a `struct`, and it must be marked with <xref:System.Runtime.InteropServices.Marshalling.CustomMarshallerAttribute>.

For example, consider a simple type that we want to marshal between managed and unmanaged code:

```csharp
public struct Example
{
    public string Message;
    public int Flags;
}
```

#### Define the marshaller type

We can create a type called `ExampleMarshaller` that is marked with <xref:System.Runtime.InteropServices.Marshalling.CustomMarshallerAttribute> to indicate that it is the entry-point marshaller type which provides custom marshalling information for the `Example` type. The first argument of the `CustomMarshallerAttribute` is the managed type that the marshaller targets. The second argument is the `MarshalMode` that the marshaller supports. The third argument is the marshaller type itself, that is, the type that implements the methods in the shape expected.

```csharp
[CustomMarshaller(typeof(Example), MarshalMode.Default, typeof(ExampleMarshaller))]
internal static unsafe class ExampleMarshaller
{
    public static ExampleUnmanaged ConvertToUnmanaged(Example managed)
    {
        return new ExampleUnmanaged()
        {
            Message = (IntPtr)Utf8StringMarshaller.ConvertToUnmanaged(managed.Message),
            Flags = managed.Flags
        };
    }

    public static Example ConvertToManaged(ExampleUnmanaged unmanaged)
    {
        return new Example()
        {
            Message = Utf8StringMarshaller.ConvertToManaged((byte*)unmanaged.Message),
            Flags = unmanaged.Flags
        };
    }

    public static void Free(ExampleUnmanaged unmanaged)
    {
        Utf8StringMarshaller.Free((byte*)unmanaged.Message);
    }

    internal struct ExampleUnmanaged
    {
        public IntPtr Message;
        public int Flags;
    }
}
```

The `ExampleMarshaller` above implements stateless marshalling from the managed `Example` type to a blittable representation in the format that the native code expects (`ExampleUnmanaged`) and back. The `Free` method is used to release any unmanaged resources allocated during the marshalling process. The marshalling logic is entirely controlled by the marshaller implementation. Marking fields on a struct with <xref:System.Runtime.InteropServices.MarshalAsAttribute> has no effect on the generated code.

Here, `ExampleMarshaller` is both the entry-point type and the implementation type. However, if necessary you can customize the marshalling for different modes by creating separate marshaller types for each mode, adding a new CustomMarshallerAttribute for each mode like in the class below. Typically this is only necessary for stateful marshallers, where the marshaller type is a `struct` that maintains state across calls. By convention, the implementation types are nested inside the entry-point marshaller type.

```csharp
[CustomMarshaller(typeof(Example), MarshalMode.ManagedToUnmanagedIn, typeof(ExampleMarshaller.ManagedToUnmanagedIn))]
[CustomMarshaller(typeof(Example), MarshalMode.ManagedToUnmanagedOut, typeof(ExampleMarshaller.UnmanagedToManagedOut))]
internal static class ExampleMarshaller
{
    internal struct ManagedToUnmanagedIn
    {
        public void FromManaged(TManaged managed) => throw new NotImplementedException();

        public TNative ToUnmanaged() => throw new NotImplementedException();

        public void Free() =>  throw new NotImplementedException()
    }

    internal struct UnmanagedToManagedOut
    {
        public void FromUnmanaged(TNative unmanaged) => throw new NotImplementedException();

        public TManaged ToManaged() => throw new NotImplementedException();

        public void Free() => throw new NotImplementedException();
    }
}
```

#### Declare which marshaller to use

Once we have created the marshaller type, we can use the <xref:System.Runtime.InteropServices.Marshalling.MarshalUsingAttribute> on the interop method signature to indicate that we want to use this marshaller for a specific parameter or return value. The <xref:System.Runtime.InteropServices.Marshalling.MarshalUsingAttribute> takes the entry-point marshaller type as an argument, in this case `ExampleMarshaller`.

```csharp
[LibraryImport("nativelib")]
[return: MarshalUsing(typeof(ExampleMarshaller))]
internal static partial Example ConvertExample(
    [MarshalUsing(typeof(ExampleMarshaller))] Example example);
```

To avoid having to specify the marshaller type for every usage of the `Example` type, we can also apply the <xref:System.Runtime.InteropServices.Marshalling.NativeMarshallingAttribute> to the `Example` type itself. This indicates that the specified marshaller should be used by default for all usages of the `Example` type in interop source generation.

```csharp
[NativeMarshalling(typeof(ExampleMarshaller))]
public struct Example
{
    public string Message;
    public int Flags;
}
```

The `Example` type can then be used in source-generated P/Invoke methods without specifying the marshaller type. In the following P/Invoke example, `ExampleMarshaller` will be used to marshal the parameter from managed to unmanaged. It will also be used to marshal the return value from unmanaged to managed.

```csharp
[LibraryImport("nativelib")]
internal static partial Example ConvertExample(Example example);
```

To use a different marshaller for a specific parameter or return value of the `Example` type, specify <xref:System.Runtime.InteropServices.Marshalling.MarshalUsingAttribute> at the use site. In the following P/Invoke example, `ExampleMarshaller` will be used to marshal the parameter from managed to unmanaged. `OtherExampleMarshaller` will be used to marshal the return value from unmanaged to managed.

```csharp
[LibraryImport("nativelib")]
[return: MarshalUsing(typeof(OtherExampleMarshaller))]
internal static partial Example ConvertExample(Example example);
```

### Marshalling Collections

#### Non-generic collections

For collections that aren't generic over the type of the element, you should create a simple marshaller type like above.

### Generic collections

To create a custom marshaller for a generic collection type, you can use the <xref:System.Runtime.InteropServices.Marshalling.ContiguousCollectionMarshallerAttribute> attribute. This attribute indicates that the marshaller is for contiguous collections, such as arrays or lists, and it provides a set of methods that the marshaller must implement to support marshalling of the collection's elements. The element type of the collection marshalled must also have a marshaller defined for it using the methods described above.

Apply the <xref:System.Runtime.InteropServices.Marshalling.ContiguousCollectionMarshallerAttribute> to a marshaller entry-point type to indicate that it's for contiguous collections. The marshaller entry-point type must have one more type parameter than the associated managed type. The last type parameter is a placeholder and will be filled in by the source generator with the unmanaged type for the collection's element type.

For example, you can specify custom marshalling for a <xref:System.Collections.Generic.List%601>. In the following code, `ListMarshaller` is both the entry point and the implementation. It conforms to [marshaller shapes][collection_shapes] expected for custom marshalling of a collection. Note that it is an incomplete example.

```csharp
[ContiguousCollectionMarshaller]
[CustomMarshaller(typeof(List<>), MarshalMode.Default, typeof(ListMarshaller<,>))]
public unsafe static class ListMarshaller<T, TUnmanagedElement> where TUnmanagedElement : unmanaged
{
    public static byte* AllocateContainerForUnmanagedElements(List<T> managed, out int numElements)
    {
        numElements = managed.Count;
        nuint collectionSizeInBytes = managed.Count * /* size of T */;
        return (byte*)NativeMemory.Alloc(collectionSizeInBytes);
    }

    public static ReadOnlySpan<T> GetManagedValuesSource(List<T> managed)
        => CollectionsMarshal.AsSpan(managed);

    public static Span<TUnmanagedElement> GetUnmanagedValuesDestination(byte* unmanaged, int numElements)
        => new Span<TUnmanagedElement>((TUnmanagedElement*)unmanaged, numElements);

    public static List<T> AllocateContainerForManagedElements(byte* unmanaged, int length)
        => new List<T>(length);

    public static Span<T> GetManagedValuesDestination(List<T> managed)
        => CollectionsMarshal.AsSpan(managed);

    public static ReadOnlySpan<TUnmanagedElement> GetUnmanagedValuesSource(byte* nativeValue, int numElements)
        => new ReadOnlySpan<TUnmanagedElement>((TUnmanagedElement*)nativeValue, numElements);

    public static void Free(byte* unmanaged)
        => NativeMemory.Free(unmanaged);
}
```

The `ListMarshaller` in the example is a stateless collection marshaller that implements support for marshalling from managed to unmanaged and from unmanaged to managed for a <xref:System.Collections.Generic.List%601>. In the following P/Invoke example, `ListMarshaller` will be used to marshal the collection container for the parameter from managed to unmanaged and to marshal the collection container for the return value from unmanaged to managed. The source generator will generate code to copy the elements from the parameter `list` to the container provided by the marshaller. Since `int` is blittable, the elements themselves do not need to be marshalled. <xref:System.Runtime.InteropServices.Marshalling.MarshalUsingAttribute.CountElementName> indicates that the `numValues` parameter should be used as the element count when marshalling the return value from unmanaged to managed.

```csharp
[LibraryImport("nativelib")]
[return: MarshalUsing(typeof(ListMarshaller<,>), CountElementName = "numValues")]
internal static partial List<int> ConvertList(
    [MarshalUsing(typeof(ListMarshaller<,>))] List<int> list,
    out int numValues);
```

When the element type of the collection is a custom type, you can specify the element marshaller for that using an additional <xref:System.Runtime.InteropServices.Marshalling.MarshalUsingAttribute> with `ElementIndirectionDepth = 1`.
The `ListMarshaller` will handle the collection container and `ExampleMarshaller` will marshal each element from unmanaged to managed and vice versa. The `ElementIndirectionDepth` indicates that the marshaller should be applied to the elements of the collection, which are one level deeper than the collection itself.

```csharp
[LibraryImport("nativelib")]
[MarshalUsing(typeof(ListMarshaller<,>))]
[MarshalUsing(typeof(ListMarshaller<,>), ElementIndirectionDepth = 1)]
internal static partial void ConvertList(
    [MarshalUsing(typeof(ListMarshaller<,>))]
    [MarshalUsing(typeof(ListMarshaller<,>), ElementIndirectionDepth = 1)]
    List<Example> list,
    out int numValues);
```

## See also

- [System.Runtime.InteropServices.Marshalling APIs](xref:System.Runtime.InteropServices.Marshalling)
- [P/Invoke source generation](pinvoke-source-generation.md)
- [Disabling runtime marshalling](disabled-marshalling.md)
- [Marshaller shapes](marshaller-shapes.md)

---
description: "Learn more about: Value Marshallers in Interop Source Generation"
title: "Custom Marshaller Shapes - Value Marshallers"
ms.date: "07/07/2025"
helpviewer_keywords:
  - "unmanaged code, exceptions"
  - "exceptions, unmanaged code"
  - "interop, exceptions"
  - "exceptions, interop"
  - "interop source generation"
  - "custom marshallers"
  - "exceptions, custom marshallers"
---

# Custom Marshaller Shapes

This document describes the different "shapes" of custom marshallers that can be used with the .NET interop source generator.

## Value Marshallers

This document describes the shapes of custom marshallers that can be used by the .NET interop source generator for marshalling types between managed and unmanaged code.

### Stateless Managed to Unmanaged

With this shape, the generated code will call `ConvertToUnmanaged` to marshal a value to native code, or `GetPinnableReference` when applicable. The generated code will call `Free` when applicable to allow the marshaller to free any unmanaged resources associated with the managed type once its lifetime ends.

```csharp
[CustomMarshaller(typeof(TManaged), MarshalMode.ManagedToUnmanagedIn, typeof(ManagedToNative))]
[CustomMarshaller(typeof(TManaged), MarshalMode.UnmanagedToManagedOut, typeof(ManagedToNative))]
static class TMarshaller
{
    public static class ManagedToNative
    {
        /// <summary>
        /// Converts a managed type to an unmanaged representation. May throw exceptions.
        /// </summary>
        public static TNative ConvertToUnmanaged(TManaged managed);

        /// <summary>
        /// Optional.
        /// Returns a pinnable reference to the unmanaged representation.
        /// The reference will be pinned and passed as a pointer to the native code.
        /// TOther should be a dereferenced type of TNative.
        /// For example, if TNative is `int*`, then TOther should be `int`.
        /// </summary>
        public static ref TNativeDereferenced GetPinnableReference(TManaged managed);

        /// <summary>
        /// Optional.
        /// Frees any unmanaged resources associated with the marshalling of the managed type.
        /// Must not throw exceptions.
        /// </summary>
        public static void Free(TNative unmanaged);
    }
}
```

### Stateless Managed->Unmanaged with Caller-Allocated Buffer

With this shape, the generator will allocate a buffer of the specified size and pass it to the `ConvertToUnmanaged` method to marshal a value to native code. The generated code will handle the lifetime of this buffer.

```csharp
[CustomMarshaller(typeof(TManaged), MarshalMode.ManagedToUnmanagedIn, typeof(ManagedToNative))]
[CustomMarshaller(typeof(TManaged), MarshalMode.UnmanagedToManagedOut, typeof(ManagedToNative))]
static class TMarshaller
{
    public static class ManagedToNative
    {
        /// <summary>
        /// The size of the buffer that will be allocated by the generator.
        /// </summary>
        public static int BufferSize { get; }

        /// <summary>
        /// Converts a managed type to an unmanaged representation using a caller-allocated buffer.
        /// </summary>
        public static TNative ConvertToUnmanaged(TManaged managed, Span<byte> callerAllocatedBuffer);

        /// <summary>
        /// Optional.
        /// Frees any unmanaged resources associated with the marshalling of the managed type.
        /// Must not throw exceptions.
        /// </summary>
        public static void Free(TNative unmanaged);
    }
}
```

### Stateless Unmanaged->Managed

```csharp
[CustomMarshaller(typeof(TManaged), MarshalMode.ManagedToUnmanagedOut, typeof(NativeToManaged))]
[CustomMarshaller(typeof(TManaged), MarshalMode.UnmanagedToManagedIn, typeof(NativeToManaged))]
static class TMarshaller
{
    public static class NativeToManaged
    {
        /// <summary>
        /// Converts an unmanaged representation to a managed type. May throw exceptions.
        /// </summary>
        public static TManaged ConvertToManaged(TNative unmanaged);

        /// <summary>
        /// Optional.
        /// Frees any unmanaged resources associated with the marshalling of the managed type.
        /// Must not throw exceptions.
        /// </summary>
        public static void Free(TNative unmanaged);
    }
}
```

### Stateless Unmanaged->Managed with Guaranteed Unmarshalling

This shape directs the generator to emit the unmarshaling code in a way that guarantees the unmarshaling will be called, even if a previous marshaller throws an exception. This is useful for types that need to be cleaned up or finalized regardless of the success of the previous operations.

```csharp
[CustomMarshaller(typeof(TManaged), MarshalMode.ManagedToUnmanagedOut, typeof(NativeToManaged))]
[CustomMarshaller(typeof(TManaged), MarshalMode.UnmanagedToManagedIn, typeof(NativeToManaged))]
static class TMarshaller
{
    public static class NativeToManaged
    {
        /// <summary>
        /// Converts an unmanaged representation to a managed type.
        /// Should not throw exceptions.
        /// </summary>
        public static TManaged ConvertToManagedFinally(TNative unmanaged);

        /// <summary>
        /// Optional.
        /// Frees any unmanaged resources associated with the marshalling of the managed type.
        /// Must not throw exceptions.
        /// </summary>
        public static void Free(TNative unmanaged);
    }
}
```

### Stateless Bidirectional

This shape allows for both managed to unmanaged and unmanaged to managed conversions, with the marshaller being stateless. The generator will use the `ConvertToUnmanaged` method for managed to unmanaged conversions and the `ConvertToManaged` method for unmanaged to managed conversions.

```csharp
[CustomMarshaller(typeof(TManaged<,,,...>), MarshalMode.ManagedToUnmanagedRef, typeof(Bidirectional))]
[CustomMarshaller(typeof(TManaged<,,,...>), MarshalMode.UnmanagedToManagedRef, typeof(Bidirectional))]
[CustomMarshaller(typeof(TManaged<,,,...>), MarshalMode.ElementRef, typeof(Bidirectional))]
static class TMarshaller<T, U, V...>
{
    public static class Bidirectional
    {
        // Include members from each of the following:
        // - One Stateless Managed->Unmanaged Value shape
        // - One Stateless Unmanaged->Managed Value shape
    }
}
```

### Stateful Managed->Unmanaged

This shape allows for stateful marshalling from managed to unmanaged. The generated code will use a unique marshaller instance for each parameter, so the marshaller can maintain state across marshalling

```csharp
[CustomMarshaller(typeof(TManaged), MarshalMode.ManagedToUnmanagedIn, typeof(ManagedToNative))]
[CustomMarshaller(typeof(TManaged), MarshalMode.UnmanagedToManagedOut, typeof(ManagedToNative))]
static class TMarshaller
{
    public struct ManagedToNative // Can be ref struct
    {
        /// <summary>
        /// Optional constructor.
        /// May throw exceptions.
        /// </summary>
        public ManagedToNative();

        /// <summary>
        /// Takes a managed type to be converted to an unmanaged representation in ToUnmanaged or GetPinnableReference.
        /// </summary>
        public void FromManaged(TManaged managed);

        /// <summary>
        /// Optional.
        /// Returns a pinnable reference to the unmanaged representation.
        /// The reference will be pinned and passed as a pointer to the native code.
        /// TOther should be a dereferenced type of TNative.
        /// For example, if TNative is `int*`, then TOther should be `int`.
        /// When applicable, this method is preferred to ToUnmanaged for marshalling.
        /// </summary>
        public ref TIgnored GetPinnableReference();

        /// <summary>
        /// Optional.
        /// Returns a pinnable reference to the unmanaged representation.
        /// The reference will be pinned and passed as a pointer to the native code.
        /// TOther should be a dereferenced type of TNative.
        /// For example, if TNative is `int*`, then TOther should be `int`.
        /// When applicable, only this method is called for the marshalling step.
        /// May throw exceptions.
        /// </summary>
        public static ref TOther GetPinnableReference(TManaged managed);

        /// <summary>
        /// Converts the managed type to an unmanaged representation.
        /// May throw exceptions.
        /// </summary>
        public TNative ToUnmanaged();

        /// <summary>
        /// Optional.
        /// In managed to unmanaged stubs, this method is called after call to the unmanaged code.
        /// Must not throw exceptions.
        /// </summary>
        public void OnInvoked();

        /// <summary>
        /// Optional.
        /// Frees any unmanaged resources associated with the marshalling of the managed type.
        /// Must not throw exceptions.
        /// </summary>
        public void Free();
    }
}
```

### Stateful Managed->Unmanaged with Caller Allocated Buffer

This shape allows for stateful marshalling from managed to unmanaged, with the generator allocating a buffer of the specified size and passing it to the `FromManaged` method. The generated code will use a unique marshaller instance for each parameter, so the marshaller can maintain state across marshalling.

```csharp
[CustomMarshaller(typeof(TManaged), MarshalMode.ManagedToUnmanagedIn, typeof(ManagedToNative))]
[CustomMarshaller(typeof(TManaged), MarshalMode.UnmanagedToManagedOut, typeof(ManagedToNative))]
static class TMarshaller
{
    public struct ManagedToNative // Can be ref struct
    {
        /// <summary>
        /// The length of the buffer that will be allocated by the generator.
        /// </summary>
        public static int BufferSize { get; }

        /// <summary>
        /// Optional constructor.
        /// May throw exceptions.
        /// </summary>
        public ManagedToNative();

        /// <summary>
        /// Takes a managed type to be converted to an unmanaged representation in ToUnmanaged or GetPinnableReference.
        /// May throw exceptions.
        /// </summary>
        public void FromManaged(TManaged managed, Span<TBuffer> buffer);

        /// <summary>
        /// Optional.
        /// Returns a pinnable reference to the unmanaged representation.
        /// The reference will be pinned and passed as a pointer to the native code.
        /// TOther should be a dereferenced type of TNative.
        /// For example, if TNative is `int*`, then TOther should be `int`.
        /// When applicable, this method is preferred to ToUnmanaged for marshalling.
        /// </summary>
        public ref TIgnored GetPinnableReference();

        /// <summary>
        /// Optional.
        /// Returns a pinnable reference to the unmanaged representation.
        /// The reference will be pinned and passed as a pointer to the native code.
        /// TOther should be a dereferenced type of TNative.
        /// For example, if TNative is `int*`, then TOther should be `int`.
        /// When applicable, only this method is called for the marshalling step.
        /// May throw exceptions.
        public static ref TOther GetPinnableReference(TManaged managed);

        /// <summary>
        /// Returns the unmanaged representation of the managed value.
        /// May throw exceptions.
        /// </summary>
        public TNative ToUnmanaged();

        /// <summary>
        /// Optional.
        /// In managed to unmanaged stubs, this method is called after call to the unmanaged code.
        /// Must not throw exceptions.
        /// </summary>
        public void OnInvoked();

        /// <summary>
        /// Optional.
        /// Frees any unmanaged resources associated with the marshalling of the managed type.
        /// Must not throw exceptions.
        /// </summary>
        public void Free();
    }
}
```

### Stateful Unmanaged->Managed

This shape allows for stateful unmarshalling from unmanaged to managed. The generated code will use a unique instance for each parameter, so the struct can maintain state across unmarshalling.

```csharp
[CustomMarshaller(typeof(TManaged), MarshalMode.ManagedToUnmanagedOut, typeof(NativeToManaged))]
[CustomMarshaller(typeof(TManaged), MarshalMode.UnmanagedToManagedIn, typeof(NativeToManaged))]
static class TMarshaller
{
    public struct NativeToManaged // Can be ref struct
    {
        /// <summary>
        /// Optional constructor.
        /// May throw exceptions.
        /// </summary>
        public NativeToManaged();

        /// <summary>
        /// Takes an unmanaged representation to be converted to a managed type in ToManaged.
        /// Should not throw exceptions.
        /// </summary>
        public void FromUnmanaged(TNative unmanaged);

        /// <summary>
        /// Returns the managed value representation of the unmanaged value.
        /// May throw exceptions.
        /// </summary>
        public TManaged ToManaged();

        /// <summary>
        /// Optional.
        /// Frees any unmanaged resources associated with the unmarshalling of the managed type.
        /// Must not throw exceptions.
        /// </summary>
        public void Free();
    }
}
```

### Stateful Unmanaged->Managed with Guaranteed Unmarshalling

This shape allows for stateful unmarshalling from unmanaged to managed, with the generator ensuring that the `ToManagedFinally` method is called even if a previous marshaller throws an exception. This is useful for types that need to be cleaned up or finalized regardless of the success of the previous operations.

```csharp
[CustomMarshaller(typeof(TManaged), MarshalMode.ManagedToUnmanagedOut, typeof(NativeToManaged))]
[CustomMarshaller(typeof(TManaged), MarshalMode.UnmanagedToManagedIn, typeof(NativeToManaged))]
static class TMarshaller
{
    public struct NativeToManaged // Can be ref struct
    {
        /// <summary>
        /// Optional constructor.
        /// May throw exceptions.
        /// </summary>
        public NativeToManaged();

        /// <summary>
        /// Takes an unmanaged representation to be converted to a managed type in ToManagedFinally.
        /// Should not throw exceptions.
        /// </summary>
        public void FromUnmanaged(TNative unmanaged);

        /// <summary>
        /// Returns the managed value representation of the unmanaged value.
        /// Should not throw exceptions.
        /// </summary>
        public TManaged ToManagedFinally();

        /// <summary>
        /// Optional.
        /// Frees any unmanaged resources associated with the unmarshalling of the managed type.
        /// Must not throw exceptions.
        /// </summary>
        public void Free();
    }
}
```

### Stateful Bidirectional

```csharp
[CustomMarshaller(typeof(TManaged), MarshalMode.ManagedToUnmanagedRef, typeof(Bidirectional))]
[CustomMarshaller(typeof(TManaged), MarshalMode.UnmanagedToManagedRef, typeof(Bidirectional))]
static class TMarshaller
{
    public struct Bidirectional // Can be ref struct
    {
        // Include members from each of the following:
        // - One Stateful Managed->Unmanaged Value shape
        // - One Stateful Unmanaged->Managed Value shape
    }
}
```

## Collection marshallers

This section describes the shapes of custom collection marshallers that the .NET interop source generator supports for marshalling collections between managed and unmanaged code. Contiguous collection marshallers are used for collections which are represented as a contiguous block of memory in their unmanaged representation, such as arrays or lists.

When the collection type being marshalled is a generic over it's element type (for example, `List<T>`), the custom marshaller type will typically have two generic parameters, one for the managed element type and one for the unmanaged element type. In cases where the collection is not generic over it's element type (for example, `StringCollection`), the marshaller may only have a single generic parameter for the unmanaged element type. The marshaller shape examples will demonstrate a marshaller for a non-generic collection `TCollection` with elements of type `TManagedElement`. Since the elements may be marshalled using different value marshallers, it must be generic over the unmanaged element type, `TUnmanagedElement`. The native representation of the collection is called `TNative` (typically this is `*TUnmanagedElement`).

### Stateless managed to unmanaged

With this shape, the generator uses static methods to marshal a managed collection to unmanaged memory. The marshaller must provide methods to allocate the unmanaged container, access managed and unmanaged elements, and optionally free unmanaged resources.

```csharp
[CustomMarshaller(typeof(TCollection), MarshalMode.ManagedToUnmanagedIn, typeof(ManagedToNative))]
[CustomMarshaller(typeof(TCollection), MarshalMode.UnmanagedToManagedOut, typeof(ManagedToNative))]
[CustomMarshaller(typeof(TCollection), MarshalMode.ElementIn, typeof(ManagedToNative))]
[ContiguousCollectionMarshaller]
static class TMarshaller<TUnmanagedElement> where TUnmanagedElement : unmanaged
{
    public static class ManagedToNative
    {
        /// <summary>
        /// Gets the uninitialized unmanaged container for the elements and assigns the number of elements to numElements.
        /// The return value is later passed to GetUnmanagedValuesDestination.
        /// </summary>
        public static TNative AllocateContainerForUnmanagedElements(TCollection managed, out int numElements);

        /// <summary>
        /// Gets a span of managed elements in the collection.
        /// The elements in this span are marshalled by the element marshaller and put into the unmanaged container.
        /// </summary>
        public static ReadOnlySpan<TManagedElement> GetManagedValuesSource(TCollection managed);

        /// <summary>
        /// Gets a span of unmanaged elements from the TNative container.
        /// The elements in this span are filled with the marshalled values from the managed collection.
        /// </summary>
        public static Span<TUnmanagedElement> GetUnmanagedValuesDestination(TNative unmanaged, int numElements);

        /// <summary>
        /// Optional. Returns a pinnable reference to the unmanaged representations of the elements.
        /// TOther should be a dereferenced type of TNative.
        /// For example, if TNative is `int*`, then TOther should be `int`.
        /// </summary>
        public static ref TOther GetPinnableReference(TManaged managed);

        /// <summary>
        /// Optional. Frees unmanaged resources.
        /// Should not throw exceptions.
        /// </summary>
        public static void Free(TNative unmanaged);
    }
}
```

### Stateless managed to unmanaged with caller-allocated buffer

The generator allocates a buffer and passes it to the marshaller for use during marshalling.

```csharp
[CustomMarshaller(typeof(TCollection), MarshalMode.ManagedToUnmanagedIn, typeof(ManagedToNative))]
[CustomMarshaller(typeof(TCollection), MarshalMode.ElementIn, typeof(ManagedToNative))]
[ContiguousCollectionMarshaller]
static class TMarshaller<TUnmanagedElement> where TUnmanagedElement : unmanaged
{
    public static class ManagedToNative
    {
        /// <summary>
        /// The length of the buffer that will be allocated by the generated code and passed to AllocateContainerForUnmanagedElements.
        /// </summary>
        public static int BufferSize { get; }

        /// <summary>
        /// Creates the unmanaged container using a caller-allocated buffer, and assigns the number of elements in the collection to numElements.
        /// The return value is later passed to GetUnmanagedValuesDestination.
        /// </summary>
        public static TNative AllocateContainerForUnmanagedElements(TCollection managed, Span<TBuffer> buffer, out int numElements);

        /// <summary>
        /// Gets a span of managed elements in the collection.
        /// The elements in this span are marshalled by the element marshaller and put into the unmanaged container.
        /// </summary>
        public static ReadOnlySpan<TManagedElement> GetManagedValuesSource(TCollection managed);

        /// <summary>
        /// Gets a span of unmanaged elements from the TNative container.
        /// The elements in this span are filled with the marshalled values from the managed collection.
        /// </summary>
        public static Span<TUnmanagedElement> GetUnmanagedValuesDestination(TNative unmanaged, int numElements);

        /// <summary>
        /// Optional. Returns a pinnable reference to the unmanaged representations of the elements.
        /// TOther should be a dereferenced type of TNative.
        /// For example, if TNative is `int*`, then TOther should be `int`.
        /// </summary>
        public static ref TOther GetPinnableReference(TManaged managed);

        /// <summary>
        /// Optional. Frees unmanaged resources.
        /// Should not throw exceptions.
        /// </summary>
        public static void Free(TNative unmanaged);
    }
}
```

### Stateless unmanaged to managed

This shape marshals from unmanaged memory to a managed collection.

```csharp
[CustomMarshaller(typeof(TCollection), MarshalMode.ManagedToUnmanagedOut, typeof(NativeToManaged))]
[CustomMarshaller(typeof(TCollection), MarshalMode.UnmanagedToManagedIn, typeof(NativeToManaged))]
[CustomMarshaller(typeof(TCollection), MarshalMode.ElementOut, typeof(NativeToManaged))]
[ContiguousCollectionMarshaller]
static class TMarshaller<TUnmanagedElement> where TUnmanagedElement : unmanaged
{
    public static class NativeToManaged
    {
        /// <summary>
        /// Allocates a new collection for unmarshalling.
        /// May throw exceptions.
        /// </summary>
        public static TCollection AllocateContainerForManagedElements(TNative unmanaged, int numElements);

        /// <summary>
        /// Gets the destination span that unmarshalled managed elements will be written to.
        /// May throw exceptions.
        /// </summary>
        public static Span<TManagedElement> GetManagedValuesDestination(TCollection managed);

        /// <summary>
        /// Gets the source span of unmanaged elements to unmarshal from.
        /// May throw exceptions.
        /// </summary>
        public static ReadOnlySpan<TUnmanagedElement> GetUnmanagedValuesSource(TNative unmanaged, int numElements);

        /// <summary>
        /// Optional. Frees unmanaged resources.
        /// Should not throw exceptions.
        /// </summary>
        public static void Free(TNative unmanaged);
    }
}
```

### Stateless unmanaged to managed with guaranteed unmarshalling

The generator ensures that unmarshalling occurs even if a previous marshaller throws an exception.

```csharp
[CustomMarshaller(typeof(TCollection), MarshalMode.ManagedToUnmanagedOut, typeof(NativeToManaged))]
[ContiguousCollectionMarshaller]
static class TMarshaller<TUnmanagedElement> where TUnmanagedElement : unmanaged
{
    public static class NativeToManaged
    {
        /// <summary>
        /// Allocates the managed container for the elements.
        /// Should not throw exceptions other than OutOfMemoryException.
        /// </summary>
        public static TCollection AllocateContainerForManagedElementsFinally(TNative unmanaged, int numElements);

        /// <summary>
        /// Gets the destination span that unmarshalled managed elements will be written to.
        /// May throw exceptions.
        /// </summary>
        public static Span<TManagedElement> GetManagedValuesDestination(TCollection managed);

        /// <summary>
        /// Gets the source span of unmanaged elements to unmarshal from.
        /// May throw exceptions.
        /// </summary>
        public static ReadOnlySpan<TUnmanagedElement> GetUnmanagedValuesSource(TNative unmanaged, int numElements);

        /// <summary>
        /// Optional. Frees unmanaged resources.
        /// Should not throw exceptions.
        /// </summary>
        public static void Free(TNative unmanaged);
    }
}
```

### Stateless bidirectional

This shape supports both managed-to-unmanaged and unmanaged-to-managed conversions.

```csharp
[CustomMarshaller(typeof(TCollection), MarshalMode.ManagedToUnmanagedRef, typeof(Bidirectional))]
[CustomMarshaller(typeof(TCollection), MarshalMode.UnmanagedToManagedRef, typeof(Bidirectional))]
[CustomMarshaller(typeof(TCollection), MarshalMode.ElementRef, typeof(Bidirectional))]
[ContiguousCollectionMarshaller]
static class TMarshaller<TUnmanagedElement> where TUnmanagedElement : unmanaged
{
    public static class Bidirectional
    {
        // Include members from each of the following:
        // - One Stateless Managed->Unmanaged Linear Collection shape
        // - One Stateless Unmanaged->Managed Linear Collection shape
    }
}
```

### Stateful managed to unmanaged

This shape allows the marshaller to maintain state across the marshalling process.

```csharp
[CustomMarshaller(typeof(TCollection), MarshalMode.ManagedToUnmanagedIn, typeof(ManagedToNative))]
[CustomMarshaller(typeof(TCollection), MarshalMode.UnmanagedToManagedOut, typeof(ManagedToNative))]
[ContiguousCollectionMarshaller]
static class TMarshaller<TUnmanagedElement> where TUnmanagedElement : unmanaged
{
    public struct ManagedToNative // Can be ref struct
    {
        /// <summary>
        /// Optional constructor.
        /// May throw exceptions.
        /// </summary>
        public ManagedToNative(); // Optional, can throw exceptions.

        /// <summary>
        /// Takes a managed collection to be converted to an unmanaged representation in ToUnmanaged or GetPinnableReference.
        /// </summary>
        public void FromManaged(TCollection collection); // Can throw exceptions.

        /// <summary>
        /// Gets the source span of managed elements to marshal.
        /// May throw exceptions.
        /// </summary>
        public ReadOnlySpan<TManagedElement> GetManagedValuesSource(); // Can throw exceptions.

        /// <summary>
        /// Gets the destination span of unmanaged elements to marshal to.
        /// May throw exceptions.
        /// </summary>
        public Span<TUnmanagedElement> GetUnmanagedValuesDestination(); // Can throw exceptions.

        /// <summary>
        /// Optional.
        /// Gets a pinnable reference to the unmanaged representation.
        /// The reference will be pinned and passed as a pointer to the native code.
        /// TOther should be a dereferenced type of TNative.
        /// For example, if TNative is `int*`, then TOther should be `int`.
        /// When applicable, this method is preferred to ToUnmanaged for marshalling.
        /// May throw exceptions.
        /// </summary>
        public ref TOther GetPinnableReference(); // Optional. Can throw exceptions.

        /// <summary>
        /// Optional.
        /// Gets a pinnable reference to the unmanaged representation.
        /// The reference will be pinned and passed as a pointer to the native code.
        /// TOther should be a dereferenced type of TNative.
        /// For example, if TNative is `int*`, then TOther should be `int`.
        /// When applicable, this method is preferred to the instance version and ToUnmanaged for marshalling.
        /// May throw exceptions.
        /// </summary>
        public static ref TOther GetPinnableReference(TCollection collection); // Optional. Can throw exceptions. Result pinnned and passed to Invoke.

        /// <summary>
        /// Converts the managed collection to an unmanaged representation.
        /// May throw exceptions.
        /// </summary>
        public TNative ToUnmanaged(); // Can throw exceptions.

        /// <summary>
        /// Optional.
        /// In managed to unmanaged stubs, this method is called after call to the unmanaged code.
        /// Must not throw exceptions.
        /// </summary>
        public void OnInvoked(); // Optional. Should not throw exceptions.
    }
}
```

### Stateful Managed->Unmanaged with Caller Allocated Buffer


```csharp
[CustomMarshaller(typeof(TCollection), MarshalMode.ManagedToUnmanagedIn, typeof(ManagedToNative))]
[ContiguousCollectionMarshaller]
static class TMarshaller<TUnmanagedElement> where TUnmanagedElement : unmanaged
{
    public struct ManagedToNative // Can be ref struct
    {
        /// <summary>
        /// The length of the buffer that will be allocated by the generated code and passed to FromManaged.
        /// </summary>
        public static int BufferSize { get; }

        /// <summary>
        /// Optional constructor.
        /// May throw exceptions.
        /// </summary>
        public ManagedToNative();

        /// <summary>
        /// Takes a managed collection to be converted to an unmanaged representation in ToUnmanaged or GetPinnableReference.
        /// The caller-allocated buffer is passed to this method.
        /// </summary>
        public void FromManaged(TCollection collection, Span<TBuffer> buffer);

        /// <summary>
        /// Gets the source span of managed elements to marshal.
        /// May throw exceptions.
        /// </summary>
        public ReadOnlySpan<TManagedElement> GetManagedValuesSource();

        /// <summary>
        /// Gets the destination span of unmanaged elements to marshal to.
        /// May throw exceptions.
        /// </summary>
        public Span<TUnmanagedElement> GetUnmanagedValuesDestination();

        /// <summary>
        /// Optional.
        /// Gets a pinnable reference to the unmanaged representation.
        /// The reference will be pinned and passed as a pointer to the native code.
        /// TOther should be a dereferenced type of TNative.
        /// For example, if TNative is `int*`, then TOther should be `int`.
        /// When applicable, this method is preferred to ToUnmanaged for marshalling.
        /// May throw exceptions.
        /// </summary>
        public ref TOther GetPinnableReference();

        /// <summary>
        /// Optional.
        /// Gets a pinnable reference to the unmanaged representation.
        /// The reference will be pinned and passed as a pointer to the native code.
        /// TOther should be a dereferenced type of TNative.
        /// For example, if TNative is `int*`, then TOther should be `int`.
        /// When applicable, this method is preferred to the instance GetPinnableReference and ToUnmanaged for marshalling.
        /// May throw exceptions.
        /// </summary>
        public static ref TOther GetPinnableReference(TCollection collection);

        /// <summary>
        /// Converts the managed collection to an unmanaged representation.
        /// May throw exceptions.
        /// </summary>
        public TNative ToUnmanaged();

        /// <summary>
        /// Optional.
        /// In managed to unmanaged stubs, this method is called after call to the unmanaged code.
        /// Must not throw exceptions.
        /// </summary>
        public void OnInvoked();
    }
}
```

### Stateful Unmanaged->Managed

This shape allows the marshaller to maintain state across the unmarshalling process.

```csharp
[CustomMarshaller(typeof(TCollection), MarshalMode.ManagedToUnmanagedOut, typeof(NativeToManaged))]
[CustomMarshaller(typeof(TCollection), MarshalMode.UnmanagedToManagedIn, typeof(NativeToManaged))]
[ContiguousCollectionMarshaller]
static class TMarshaller<TUnmanagedElement> where TUnmanagedElement : unmanaged
{
    public struct NativeToManaged // Can be ref struct
    {
        /// <summary>
        /// Optional constructor.
        /// May throw exceptions.
        /// </summary>
        public NativeToManaged();

        /// <summary>
        /// Takes an unmanaged collection to be converted to a managed representation in ToManaged.
        /// Should not throw exceptions.
        /// </summary>
        public void FromUnmanaged(TNative value);

        /// <summary>
        /// Gets the source span of unmanaged elements to unmarshal from.
        /// May throw exceptions.
        /// </summary>
        public ReadOnlySpan<TUnmanagedElement> GetUnmanagedValuesSource(int numElements);

        /// <summary>
        /// Gets the destination span that unmarshalled managed elements will be written to.
        /// May throw exceptions.
        /// </summary>
        public Span<TManagedElement> GetManagedValuesDestination(int numElements);

        /// <summary>
        /// Returns the managed value representation of the unmanaged value.
        /// May throw exceptions.
        /// </summary>
        public TCollection ToManaged();

        /// <summary>
        /// Optional. Should not throw exceptions.
        /// </summary>
        public void Free();
    }
}
```

### Stateful unmanaged to managed with guaranteed unmarshalling

```csharp
[CustomMarshaller(typeof(TCollection), MarshalMode.ManagedToUnmanagedOut, typeof(NativeToManaged))]
[ContiguousCollectionMarshaller]
static class TMarshaller<TUnmanagedElement> where TUnmanagedElement : unmanaged
{
    public struct NativeToManaged // Can be ref struct
    {
        /// <summary>
        /// Optional constructor.
        /// May throw exceptions.
        /// </summary>
        public NativeToManaged(); // Optional, can throw exceptions.

        /// <summary>
        /// Takes an unmanaged collection to be converted to a managed representation in ToManagedFinally.
        /// Should not throw exceptions.
        /// </summary>
        public void FromUnmanaged(TNative value);

        /// <summary>
        /// Gets the source span of unmanaged elements to unmarshal from.
        /// May throw exceptions.
        /// </summary>
        public ReadOnlySpan<TUnmanagedElement> GetUnmanagedValuesSource(int numElements);

        /// <summary>
        /// Gets the destination span that unmarshalled managed elements will be written to.
        /// May throw exceptions.
        /// </summary>
        public Span<TManagedElement> GetManagedValuesDestination(int numElements);

        /// <summary>
        /// Returns the managed value representation of the unmanaged value.
        /// Should not throw exceptions.
        /// </summary>
        public TCollection ToManagedFinally();

        /// <summary>
        /// Optional. Should not throw exceptions.
        /// </summary>
        public void Free();
    }
}
```

### Stateful Bidirectional

```csharp
[CustomMarshaller(typeof(TCollection), MarshalMode.ManagedToUnmanagedRef, typeof(Bidirectional))]
[CustomMarshaller(typeof(TCollection), MarshalMode.UnmanagedToManagedRef, typeof(Bidirectional))]
[ContiguousCollectionMarshaller]
static class TMarshaller<TUnmanagedElement> where TUnmanagedElement : unmanaged
{
    public struct Bidirectional // Can be ref struct
    {
        // Include members from each of the following:
        // - One Stateful Managed->Unmanaged Contiguous Collection shape
        // - One Stateful Unmanaged->Managed Contiguous Collection shape
    }
}
```

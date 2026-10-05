---
title: "Breaking change - Tensor operations reject unsupported storage layouts"
description: Learn about the breaking change in .NET 12 where multidimensional Tensor APIs reject unsupported overlap and incompatible array storage.
ms.date: 09/30/2026
ai-usage: ai-generated
ms.custom: https://github.com/dotnet/docs/issues/56290
---

# Tensor operations reject unsupported storage layouts

Starting in .NET 12, multidimensional Tensor copying and destination-taking operations reject unsupported overlapping storage layouts with <xref:System.ArgumentException> before they write output. Tensor-span constructors also validate the element type of `System.Array` storage.

The change is delivered in the [System.Numerics.Tensors](https://www.nuget.org/packages/System.Numerics.Tensors) package, including its supported target frameworks. Updating the package can affect apps that target earlier .NET versions. The separate `TensorPrimitives` APIs retain their existing overlap contract.

## Version introduced

.NET 12 Preview 1

## Previous behavior

`CopyTo`, `FlattenTo`, `TryCopyTo`, and `TryFlattenTo` documented support for overlapping source and destination storage. The `Try` methods described handling the source as if it had first been copied to temporary storage.

For example, the following source and destination refer to overlapping regions of the same array:

```csharp
int[] storage = { 1, 2, 3, 4, 5, 6 };
ReadOnlyTensorSpan<int> source = new(storage, new nint[] { 2, 2 }, new nint[] { 3, 1 });
TensorSpan<int> destination = new(storage, new nint[] { 2, 2 });
source.CopyTo(destination);
```

The documented snapshot-style contract implied that the destination would receive `[1, 2, 4, 5]`. Actual results for unsupported overlap could depend on layout and traversal order; the implementation didn't reliably meet that contract.

Constructors that took `System.Array` didn't consistently validate whether the array's element type was compatible with `T`.

## New behavior

The example throws `ArgumentException` before copying. The same unsupported overlap also throws from `TryCopyTo` and `TryFlattenTo` when their shape and capacity checks succeed.

Supported overlap remains operation-specific:

| Operation | Supported overlap |
| --- | --- |
| `CopyTo` and `TryCopyTo` | Dense source and destination with equal element counts, or exactly identical views. |
| `FlattenTo` and `TryFlattenTo` | A dense source and the destination span. |
| Destination-taking elementwise operations | Identical input/output views without repeated logical storage locations. Shifted overlap and overlapping broadcast inputs are rejected. |
| `Tensor.ResizeTo` | Dense source and destination. Unsupported strided overlap is rejected. |
| Reversal into the same view | Dense in-place reversal, or a no-op reversal. |

The `Try` copying methods still return `false`, without copying, when the destination is too short. `TryCopyTo` also returns `false` for incompatible shapes. Unsupported overlap is an invalid layout, not a capacity failure.

`Tensor.ResizeTo` and concatenation into an existing destination reject a zero-stride dimension that contains more than one logical element. Empty destinations and zero strides in singleton dimensions remain permitted.

`TensorSpan<T>` and `ReadOnlyTensorSpan<T>` constructors that take `System.Array` throw <xref:System.ArrayTypeMismatchException> for incompatible array element types. Writable tensor spans also reject covariant arrays; read-only tensor spans permit compatible reference-type covariance.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Correct copies between arbitrarily overlapping strided tensors can require temporary storage proportional to the entire tensor. Explicit rejection avoids traversal-dependent corruption without silently allocating full-tensor snapshots.

Repeated output storage locations can't represent distinct logical results. Array element-type validation prevents incompatible storage from being interpreted as `T`, and prevents writes through covariant array storage.

## Recommended action

Use nonoverlapping output storage, or explicitly snapshot the source before an overlapping copy. For the preceding example:

```csharp
int[] snapshot = new int[checked((int)source.FlattenedLength)];
source.FlattenTo(snapshot);
ReadOnlyTensorSpan<int> independentSource = new(snapshot, source.Lengths);
independentSource.CopyTo(destination);
```

The snapshot contains `[1, 2, 4, 5]`. For destination-taking elementwise operations, snapshot each overlapping input or allocate a separate result. Replace broadcast destinations with independently addressable output storage.

For a tensor span over `System.Array`, supply compatible element storage. For a writable view, use an array that isn't covariant, or copy the elements to a new `T[]`.

Don't assume that a `Try` copying method can't throw. A `false` result handles insufficient capacity or, for `TryCopyTo`, incompatible shapes. No compatibility switch restores arbitrary-overlap behavior.

## Affected APIs

- <xref:System.Numerics.Tensors.IReadOnlyTensor`2.CopyTo*?displayProperty=fullName>.
- <xref:System.Numerics.Tensors.IReadOnlyTensor`2.FlattenTo*?displayProperty=fullName>.
- <xref:System.Numerics.Tensors.IReadOnlyTensor`2.TryCopyTo*?displayProperty=fullName>.
- <xref:System.Numerics.Tensors.IReadOnlyTensor`2.TryFlattenTo*?displayProperty=fullName>.
- The corresponding copy and flatten methods on <xref:System.Numerics.Tensors.Tensor`1>, <xref:System.Numerics.Tensors.TensorSpan`1>, and <xref:System.Numerics.Tensors.ReadOnlyTensorSpan`1>.
- Destination-taking elementwise methods on <xref:System.Numerics.Tensors.Tensor>, including unary, binary, and tensor/scalar operations.
- <xref:System.Numerics.Tensors.Tensor.ResizeTo*?displayProperty=fullName> (all overloads).
- <xref:System.Numerics.Tensors.Tensor.Reverse*?displayProperty=fullName> and <xref:System.Numerics.Tensors.Tensor.ReverseDimension*?displayProperty=fullName> (overloads that take a destination).
- <xref:System.Numerics.Tensors.Tensor.Concatenate*?displayProperty=fullName> (overload that takes a destination).
- <xref:System.Numerics.Tensors.TensorSpan`1.%23ctor*> and <xref:System.Numerics.Tensors.ReadOnlyTensorSpan`1.%23ctor*> (the two overloads on each type that take `System.Array`).

## See also

- [Tensor shapes, storage, and NumPy differences](../../../../standard/tensor-shapes-and-storage.md)

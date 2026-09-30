---
title: Tensor shapes, storage, and NumPy differences
description: Understand the shape, stride, resizing, and overlapping-storage behavior of System.Numerics.Tensors and how it differs from NumPy.
ms.date: 09/30/2026
ai-usage: ai-generated
---

# Tensor shapes, storage, and NumPy differences

The [System.Numerics.Tensors](https://www.nuget.org/packages/System.Numerics.Tensors) package provides <xref:System.Numerics.Tensors.Tensor`1>, <xref:System.Numerics.Tensors.TensorSpan`1>, and <xref:System.Numerics.Tensors.ReadOnlyTensorSpan`1> for multidimensional data. Tensor shapes describe the logical dimensions; strides describe the distance, in elements, between successive positions along each dimension.

These types share many conventions with NumPy, but they aren't interchangeable. Account for the following differences when you port an algorithm.

## Empty shapes and scalar-like results

When you create a tensor from an empty shape (`[]`) without backing data, the tensor has shape `[0]` and no elements. In NumPy, shape `()` has rank zero and contains one scalar element. In particular, `np.empty(())` allocates a scalar with an uninitialized value; "empty" doesn't mean that it has no elements.

In contrast, when you omit lengths from a tensor-span constructor over existing data, the constructor infers a one-dimensional shape from the supplied array or span.

When you squeeze a tensor with shape `[1, 1]`, the result has shape `[1]`, not NumPy's rank-zero shape `()`. Both results contain one element and can broadcast as a scalar, but code that examines rank, selects axes, or indexes the result must account for the retained dimension.

When strides are omitted, any shape that contains a zero-length dimension has zero strides in every dimension. Its element count and required storage are zero, regardless of the other dimension lengths. Negative lengths remain invalid. Explicit strides must still satisfy layout validation.

## Strides and reversed data

Strides must be nonnegative. NumPy can represent a reversed view with a negative stride, for example `array[::-1]`.

To reverse the first axis, call `Tensor.ReverseDimension` with dimension `0`:

```csharp
using System.Numerics.Tensors;

Tensor<int> source = Tensor.Create(new[] { 1, 2, 3, 4 }, new nint[] { 2, 2 });
Tensor<int> reversed = Tensor.ReverseDimension<int>(source.AsReadOnlyTensorSpan(), 0);
```

The logical elements of `reversed` are `[3, 4, 1, 2]`. The allocating overload produces a new tensor; it isn't a negative-stride view over the original storage.

## Resize a tensor

`Tensor.Resize` and `Tensor.ResizeTo` fill added logical elements with `default(T)`. For example, if you grow `[1, 2]` to five `int` elements, the result contains `[1, 2, 0, 0, 0]`. NumPy's `np.resize` instead repeats the input and produces `[1, 2, 1, 2, 1]`.

If the destination is smaller, the operation discards elements after the destination's logical element count. If it's larger, the operation initializes the remaining logical destination elements even when the destination has gaps between elements. Storage outside the logical destination isn't part of the resize operation.

`Tensor.ResizeTo` and concatenation into an existing destination reject a zero-stride dimension that contains more than one logical element. Such a dimension causes multiple output positions to refer to the same storage and can't hold distinct output values. Zero strides in singleton dimensions and empty destinations don't create this conflict.

## Overlapping sources and destinations

Separate tensor objects and spans can refer to overlapping regions of the same array. Supported cases depend on both the operation and the layout:

| Operation | Supported overlap |
| --- | --- |
| `CopyTo` and `TryCopyTo` | Dense source and destination with equal element counts, or exactly identical views. Dense copies use overlap-safe span copying. |
| `FlattenTo` and `TryFlattenTo` | A dense source and the destination span. |
| Elementwise operations with a destination | An input and output with the same starting reference, lengths, and strides, provided the view has no repeated logical storage locations. Each input is checked independently. |
| `Tensor.ResizeTo` | Dense source and destination. Unsupported strided overlap is rejected. |
| Reversal into the same view | A dense view can be reversed in place. No-op reversals are also supported. |

Other unsupported overlapping layouts throw <xref:System.ArgumentException> before the operation writes output. A dense tensor alone doesn't guarantee support for every operation: for example, a shifted dense destination is supported for a copy, but not for an elementwise operation.

The `TryCopyTo` and `TryFlattenTo` methods return `false` without copying when the destination is too short. `TryCopyTo` also returns `false` for incompatible source and destination shapes. For compatible shapes with sufficient destination capacity, these methods can still throw for unsupported overlap; `Try` doesn't suppress invalid-layout exceptions.

For example, the following strided source and dense destination overlap:

```csharp
int[] storage = { 1, 2, 3, 4, 5, 6 };
ReadOnlyTensorSpan<int> source = new(storage, new nint[] { 2, 2 }, new nint[] { 3, 1 });
TensorSpan<int> destination = new(storage, new nint[] { 2, 2 });
```

To copy from this unsupported overlapping layout, first take a snapshot into independent storage:

```csharp
int[] snapshot = new int[checked((int)source.FlattenedLength)];
source.FlattenTo(snapshot);
ReadOnlyTensorSpan<int> independentSource = new(snapshot, source.Lengths);
independentSource.CopyTo(destination);
```

The snapshot contains `[1, 2, 4, 5]`. The copy writes those elements to the destination without changing the original values before they're read.

For a destination-taking elementwise operation, allocate a separate result tensor or snapshot each overlapping input before you write the output. For a broadcast destination with repeated storage locations, use independent output storage instead; an input snapshot doesn't make that destination capable of holding distinct values.

The library doesn't implicitly allocate a full-tensor snapshot to support arbitrary overlapping layouts. Nonoverlapping strided copies don't require that temporary storage.

## See also

- [Numerics in .NET](numerics.md)
- [Use SIMD and hardware intrinsics in .NET](simd.md)
- [Tensor storage-layout breaking change](../core/compatibility/core-libraries/12/tensor-storage-layout-validation.md)
- <xref:System.Numerics.Tensors>

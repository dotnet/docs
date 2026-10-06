---
title: "Breaking change - Tensor operations align equivalent shapes and empty tensors"
description: "Learn about the breaking change in .NET 11 where tensor operations use consistent shape-alignment rules."
ms.date: 10/06/2026
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/56305
---

# Tensor operations align equivalent shapes and empty tensors

Starting in .NET 11, tensor operations use consistent shape-alignment rules. Default rank-zero empty tensors and spans have an effective shape of `[0]` during computations, and operations can ignore redundant leading singleton dimensions when they align shapes.

## Version introduced

.NET 11

## Previous behavior

Tensor operations handled shapes inconsistently. Some operations required exact shape matches, while others aligned dimensions differently. As a result, equivalent shapes with redundant leading singleton dimensions, such as `[1, 1, 3]` and `[3]`, could be rejected or interpreted differently across operations.

Default empty tensors and spans retained rank-zero metadata, but operations didn't consistently treat them as vectors with an effective shape of `[0]`. Stack and concatenate operations could also interpret an axis differently based on the input ranks.

Some operations also narrowed logical element counts or offsets to `int`, which prevented native-backed tensor spans with more than `int.MaxValue` elements from being traversed correctly. The `EqualsAny`, `GreaterThanAny`, `GreaterThanOrEqualAny`, `LessThanAny`, and `LessThanOrEqualAny` operations didn't consistently inspect the full logical input length, including for empty inputs.

## New behavior

Tensor operations now use shared shape-alignment rules:

- Default rank-zero empty tensors and spans have an effective shape of `[0]` for computations. Their stored `Rank`, `Lengths`, and `Strides` don't change, and explicitly ranked empty shapes retain their dimensions.
- Operations can add or remove redundant leading singleton dimensions when they align shapes. For example, `[1, 1, 3]` aligns with `[3]`, but `[2, 1]` and `[1, 2]` remain distinct. Zero-length dimensions and non-leading singleton dimensions remain significant.
- Shape equality ignores only redundant leading singleton dimensions. It doesn't broadcast other dimensions.
- Stack and concatenate operations interpret the axis by using the first input's effective shape. Other inputs and destinations align to that shape.
- Default empty values can broadcast to `[2, 0]`. A binary operation between effective shapes `[0]` and `[0, 2]` rejects the incompatible trailing dimensions.
- Sources and destinations retain their requested shape metadata when operations align them.

Native-backed tensor spans can now be traversed with native-sized lengths and offsets, including spans with more than `int.MaxValue` logical elements. Empty views also retain a storage origin within their source. The `EqualsAny`, `GreaterThanAny`, `GreaterThanOrEqualAny`, `LessThanAny`, and `LessThanOrEqualAny` operations now inspect the full logical input range and handle empty inputs correctly.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Consistent shape rules make tensor operations more predictable and preserve explicitly requested dimensions while allowing equivalent shapes to work together. Native-sized traversal also lets operations cover the full logical range of spans backed by larger storage.

For more information, see [dotnet/runtime#135060](https://github.com/dotnet/runtime/pull/135060).

## Recommended action

Review code that depends on a tensor operation accepting or rejecting a particular shape combination. Account for default rank-zero empty values as having an effective shape of `[0]`, and for redundant leading singleton dimensions to be ignored during alignment and shape comparison. Explicit zero-length dimensions and non-leading singleton dimensions remain significant.

For stack and concatenate operations, interpret the axis relative to the first input's effective shape. If your code requires exact stored ranks or lengths, validate that metadata before calling the operation. The stored metadata of default empty values doesn't change.

## Affected APIs

- <xref:System.Numerics.Tensors.Tensor.Broadcast*>, <xref:System.Numerics.Tensors.Tensor.BroadcastTo*>, and <xref:System.Numerics.Tensors.Tensor.TryBroadcastTo*>
- Elementwise and copy operations on <xref:System.Numerics.Tensors.Tensor> that align tensor shapes or write to a caller-provided destination
- <xref:System.Numerics.Tensors.Tensor.Concatenate*>, <xref:System.Numerics.Tensors.Tensor.ConcatenateOnDimension*>, <xref:System.Numerics.Tensors.Tensor.Stack*>, and <xref:System.Numerics.Tensors.Tensor.StackAlongDimension*>
- <xref:System.Numerics.Tensors.Tensor.Reshape*>, <xref:System.Numerics.Tensors.Tensor.Split*>, <xref:System.Numerics.Tensors.Tensor.SqueezeDimension*>, <xref:System.Numerics.Tensors.Tensor.Unsqueeze*>, <xref:System.Numerics.Tensors.Tensor.PermuteDimensions*>, <xref:System.Numerics.Tensors.Tensor.SetSlice*>, <xref:System.Numerics.Tensors.Tensor.SequenceEqual*>, <xref:System.Numerics.Tensors.Tensor.ResizeTo*>, <xref:System.Numerics.Tensors.Tensor.Reverse*>, and <xref:System.Numerics.Tensors.Tensor.ReverseDimension*>
- <xref:System.Numerics.Tensors.Tensor.EqualsAny*>, <xref:System.Numerics.Tensors.Tensor.GreaterThanAny*>, <xref:System.Numerics.Tensors.Tensor.GreaterThanOrEqualAny*>, <xref:System.Numerics.Tensors.Tensor.LessThanAny*>, and <xref:System.Numerics.Tensors.Tensor.LessThanOrEqualAny*>
- <xref:System.Numerics.Tensors.Tensor.IndexOfMax*>, <xref:System.Numerics.Tensors.Tensor.IndexOfMaxMagnitude*>, <xref:System.Numerics.Tensors.Tensor.IndexOfMin*>, and <xref:System.Numerics.Tensors.Tensor.IndexOfMinMagnitude*>

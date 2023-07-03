---
title: Lifetimes and ownership in COM Interop
description: Learn how lifetimes and ownership works in COM Interop
ms.date: 06/30/2023
zone-pivot-groups: interop-types
---

# Ownership of COM parameters

## Motivation

COM Interop passes values and references to the heap across interop boundaries, and may or may not transfer ownership of references to heap memory depending on whether or not a COM method succeeds or not.
A COM method may fail at any point during execution, and it may fail after it has already allocated memory that is meant to be transfered to the caller.
It is important to make sure these failures do not lead to a memory leak or double free.
This document outlines the lifetimes and ownerships of the parameters as they are passed from across COM boundaries.

## Definitions
This documents use the follow definitions.

#### Value
A value is a piece of data with a known size representing a primitive (int, float, char), Struct (combination of values), reference to a COM interface (IFoo* in C, or IFoo in C#), reference to an array, or a reference to any value. Note a COM interface or array are not values themselves, as the concept of an array or interface requires a reference and does not make sense without one.

#### Ownership
Ownership of a value means that the owner is free change the data and references in the value, as well as data in any referenced values. Owners of a value are also responsible for cleaning up any references from the value after the value's lifetime ends, and cleanup up references that are no longer reachable from the value after the value is mutated.

References to other values that are passed across COM boundaries should be owned by either the caller or the callee, but not both. Cleaning up references to other values looks different in different languages and runtimes. In C++, the owner should `free` the reference to clean it up. In .Net, cleanup is handled by the garbage collector.

While references to other values only have one owner, interfaces can have many owners. A callee method which was not transferred ownership by the method signature convention can still take ownership of a reference to an interface by calling `AddRef` on the interface reference. Cleaning up a reference to an interface involves calling `Release` on the reference. In .Net, using built in COM and the COM source generator will handle calling `AddRef` and `Release` for you.

#### By Value and By Reference parameters

Values may be passed by value or by reference. This impacts how the value ownership is transferred.

##### By Value

Primitives and structs are passed by value.

##### By Reference

References to a value are passed by reference. <More information on how `ref` and reference types relate to by reference parameters.>

## Mutability

### Immutable Parameters

Immutable parameters (those with `in` or `[InAttribute]` in C#, or `[in]` in C++), never transfer ownership of their values. <More detail and examples of Immutable parameters.>

### Must Mutate parameters

Must Mutate parameters do not reference initialized values. Any data or references should be considered invalid, and the callee is expected to fill in the value.

### Mutable parameters

Mutable parameters contain valid values when the method is called and the callee may mutate the value of the parameter.

## Ownership transfer rule

For parameters passed by value, the callee is expected to take ownership of the value when it knows it will return a successful return value. For parameters passed by reference, the callee takes ownership of the referenced value when it knows it will return a successful return value. When the callee returns the successful return value to the caller, the caller takes back ownership of value referenced.

No transfer of ownership is expected to have taken place if the callee returns a failure return value. The caller is expected to maintain ownership of the value and is responsible for cleanup.

### Examples

The ownership transfer of the matrix of value kind, mutability, and indirection is shown below. <Each example should include a method signature in C#, and MIDL, and maybe C++>

#### By value
Struct, immutable, by value -> The caller owns the value passed in.
Struct, mutable, by value -> The callee owns the value passed in. The caller should not do anything with a copy of the struct passed in.
Struct, must mutate, by value -> Invalid scenario. Must mutate requires a reference.

Primitive, *, by value -> Nothing really matters in these cases.

Interface, *, by value -> Invalid. Interfaces require pointers.

#### By reference
Struct, immutable, pointer -> The caller owns the value referenced.
Struct, mutable, pointer -> The callee takes ownership of the value, then caller takes back ownership of the value at return
Struct, must mutate, pointer -> The callee takes ownership of the (empty) value, the caller takes ownership of the value at return

Primitive, immutable, pointer -> The caller owns the value referenced.
Primitive, _, pointer -> The callee takes ownership of the referenced value, (maybe) mutates it, and transfers it back.

Interface, *, pointer -> The interface is passed by reference to the callee. The callee may take ownership of a interface

#### By reference to reference
Struct, immutable, pointer to pointer -> The caller owns the pointer referenced and the value referenced
Struct, mutable, pointer to pointer -> The callee takes ownership of the original value of the pointer referenced, and the value referenced by it. The caller takes then ownership of the final value of the pointer and the value referenced by it.
Struct, must mutate, pointer to pointer -> The callee takes ownership of the original value of the pointer referenced, which is considered an invalid pointer. The caller then takes ownership of the final value of the pointer and the value is references.

Primitive, immutable, pointer to pointer -> The caller owns the pointer referenced and the primitive referenced.
Primitive, mutable, pointer to pointer -> The callee takes ownership of the original value of the pointer referenced, and the primitive referenced by it. The caller takes then ownership of the final value of the pointer and the primitive referenced by it.
Primitive, must mutate, pointer to pointer -> The callee takes ownership of the original value of the pointer referenced, which is considered an invalid pointer. The caller then takes ownership of the final value of the pointer and the primitive it references.

Interface, immutable, pointer to pointer -> The caller owns the pointer referenced and the interface it references.
Interface, mutable, pointer to pointer -> The callee takes ownership of the original value of the pointer referenced, and the value referenced by it. The caller takes then ownership of the final value of the pointer and the value referenced by it.
Interface, must mutate, pointer to pointer -> The callee takes ownership of the original value of the pointer referenced, which is considered an invalid pointer. The caller then takes ownership of the final value of the pointer and the value is references.


#### Arrays
Array, *, by value -> invalid scenario
Array, immutable, * -> caller keeps ownership of the value of the container of the arrays (and therefore all elements)
Array, mutable / must mutate, pointer to container -> callee takes ownership of the array and elements, mutates and cleans, and transfers ownership back.
Array, mutable / must mutate, pointer to pointer to container -> callee takes ownership of the pointer to the array, may mutate the pointer, the array, or any elements. Caller ownership of the pointer to the array at the end of the method.

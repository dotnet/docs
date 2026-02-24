---
title: Serialization lifecycle hooks
description: Learn how to use serialization lifecycle hooks in .NET Orleans to run custom logic during serialization, deserialization, and copying.
ms.date: 02/24/2026
---

# Serialization lifecycle hooks

Orleans lets you run custom logic at specific points during serialization, deserialization, and copying. The <xref:Orleans.SerializationCallbacksAttribute> attribute associates a _hook type_ with your serializable type. The Orleans code generator calls methods on the hook type at each stage of the process.

Lifecycle hooks are useful when you need to:

- **Rehydrate transient state**: Recompute cached values or restore non-serialized fields after deserialization.
- **Validate data**: Verify invariants after deserialization or before serialization to catch corruption early.
- **Log or trace**: Record serialization activity for diagnostics, using services from dependency injection.
- **Normalize data**: Ensure fields are in a consistent format before serialization (for example, trimming strings or sorting collections).

## The `SerializationCallbacksAttribute`

Apply `[SerializationCallbacks(typeof(THook))]` to a class or struct that uses `[GenerateSerializer]`. The `THook` type parameter specifies a class whose public methods are called at each lifecycle stage. The hook type is resolved from the <xref:System.IServiceProvider>, so it can use dependency injection.

The hook type can implement any combination of the following public methods:

| Method signature | Called when |
|---|---|
| `void OnSerializing(T value)` | Before the serializer writes the object's fields. |
| `void OnSerialized(T value)` | After the serializer finishes writing the object's fields. |
| `void OnDeserializing(T value)` | Before the serializer reads the object's fields (instance is created but not yet populated). |
| `void OnDeserialized(T value)` | After the serializer finishes reading the object's fields. |
| `void OnCopying(T original, T result)` | Before the copier copies the object's fields. |
| `void OnCopied(T original, T result)` | After the copier finishes copying the object's fields. |

Where `T` is the type that the attribute is applied to. All methods are optional—implement only the ones you need.

> [!NOTE]
> The copier callbacks (`OnCopying` and `OnCopied`) take two parameters: the original instance and the copy being constructed. The serialization and deserialization callbacks take a single parameter: the instance being processed.

## Basic example: rehydrating cached state

A common scenario is recomputing a value that isn't serialized. In this example, a `TemperatureReading` stores Celsius and caches the Fahrenheit conversion in a non-serialized field. The hook recomputes it after deserialization.

Define the serializable type with the `[SerializationCallbacks]` attribute:

:::code language="csharp" source="snippets/serialization-lifecycle-hooks/BasicHook.cs" id="BasicHookType":::

Then define the hook class with an `OnDeserialized` method:

:::code language="csharp" source="snippets/serialization-lifecycle-hooks/BasicHook.cs" id="BasicHookClass":::

When Orleans deserializes a `TemperatureReading`, it creates the instance, populates the `Celsius` and `Timestamp` fields, and then calls `TemperatureReadingHooks.OnDeserialized` to recompute the cached `Fahrenheit` value.

## Dependency injection in hooks

Because the hook type is resolved from the `IServiceProvider`, you can inject services into its constructor. This is useful for logging, metrics, or accessing application services during serialization.

Define a type with a hook that uses an injected logger:

:::code language="csharp" source="snippets/serialization-lifecycle-hooks/DiHook.cs" id="DiHookType":::

The hook class receives an `ILogger<T>` through constructor injection:

:::code language="csharp" source="snippets/serialization-lifecycle-hooks/DiHook.cs" id="DiHookClass":::

> [!TIP]
> Register the hook type in the dependency injection container if it has constructor parameters. Orleans resolves hook types from the `IServiceProvider`, so types with parameterless constructors are resolved automatically, while types with dependencies must be registered.

## Validation example

Hooks are a natural place to enforce data invariants. By validating in `OnDeserialized`, you catch invalid data at the point of entry rather than allowing it to propagate through the system.

Define the type:

:::code language="csharp" source="snippets/serialization-lifecycle-hooks/ValidationHook.cs" id="ValidationHookType":::

The hook validates on both serialization and deserialization:

:::code language="csharp" source="snippets/serialization-lifecycle-hooks/ValidationHook.cs" id="ValidationHookClass":::

## How it works

When the Orleans code generator encounters a type decorated with `[SerializationCallbacks(typeof(THook))]`:

1. The generated serializer stores a reference to the `THook` instance (resolved from DI).
2. During serialization, it calls `THook.OnSerializing(instance)` before writing fields and `THook.OnSerialized(instance)` after.
3. During deserialization, it calls `THook.OnDeserializing(instance)` before reading fields and `THook.OnDeserialized(instance)` after.
4. During copying, it calls `THook.OnCopying(original, copy)` before copying fields and `THook.OnCopied(original, copy)` after.

You can apply the attribute multiple times to register more than one hook type. Hooks are called in the order they are declared.

## See also

- [Custom activators with IActivator\<T>](custom-activators.md)
- [Serialization and custom serializers](serialization.md)

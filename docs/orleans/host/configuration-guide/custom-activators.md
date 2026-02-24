---
title: Custom activators with IActivator<T>
description: Learn how to control object construction during deserialization in .NET Orleans by implementing IActivator<T>.
ms.date: 02/24/2026
---

# Custom activators with IActivator\<T>

During deserialization, Orleans needs to create instances of your types before populating their fields. By default, Orleans uses a parameterless constructor (or <xref:System.Runtime.CompilerServices.RuntimeHelpers.GetUninitializedObject%2A> if no parameterless constructor exists). The <xref:Orleans.Serialization.Activators.IActivator%601> interface lets you take control of this process.

Custom activators are useful when:

- Your type requires constructor arguments (such as dependency injection services).
- You want to return instances from an object pool instead of allocating new objects.
- You need to perform initialization logic before the serializer populates the object's fields.
- Your type doesn't have a parameterless constructor.

## The IActivator\<T> interface

The `IActivator<T>` interface is defined in the `Orleans.Serialization.Activators` namespace and contains a single method:

```csharp
namespace Orleans.Serialization.Activators;

public interface IActivator<T>
{
    T Create();
}
```

The `Create` method is called by the serializer whenever it needs a new instance of `T` during deserialization. The serializer then populates the object's serialized fields after creation.

## Implement a custom activator

To implement a custom activator:

1. Create a class that implements `IActivator<T>` for your target type.
2. Decorate your activator class with the `[RegisterActivator]` attribute so Orleans discovers it automatically.
3. Decorate the target type with the `[UseActivator]` attribute to tell the code generator to use a registered activator instead of calling the constructor directly.

### Basic example

The following example demonstrates a simple custom activator. First, define the serializable type with the `[UseActivator]` attribute:

:::code language="csharp" source="snippets/custom-activators/BasicActivator.cs" id="BasicType":::

Then, implement the activator with the `[RegisterActivator]` attribute:

:::code language="csharp" source="snippets/custom-activators/BasicActivator.cs" id="BasicActivator":::

### Object pooling example

A common use case for custom activators is returning objects from a pool to reduce garbage collection pressure. Define the pooled type:

:::code language="csharp" source="snippets/custom-activators/PooledActivator.cs" id="PooledType":::

Then implement the activator that draws from an <xref:Microsoft.Extensions.ObjectPool.ObjectPool%601>:

:::code language="csharp" source="snippets/custom-activators/PooledActivator.cs" id="PooledActivator":::

### Dependency injection example

Custom activators participate in dependency injection, so you can inject services into the activator's constructor. This is useful when your serializable type needs access to services that can't be serialized. Define a type that requires an injected service:

:::code language="csharp" source="snippets/custom-activators/DiActivator.cs" id="DiType":::

Then implement the activator that resolves the service and passes it to the constructor:

:::code language="csharp" source="snippets/custom-activators/DiActivator.cs" id="DiActivator":::

## Generic activators

You can implement activators for generic types. The Orleans code generator recognizes open generic activator registrations:

:::code language="csharp" source="snippets/custom-activators/GenericActivator.cs" id="GenericType":::

:::code language="csharp" source="snippets/custom-activators/GenericActivator.cs" id="GenericActivator":::

## Important attributes

| Attribute | Applied to | Purpose |
|---|---|---|
| `[UseActivator]` | Serializable type (class or struct) | Tells the code generator that instances of this type should be created using a registered `IActivator<T>` instead of calling the constructor directly. |
| `[RegisterActivator]` | Activator implementation (class or struct) | Registers the activator with Orleans so it's automatically discovered and used during deserialization. |

Both attributes are defined in the `Orleans.Serialization` namespace.

## How it works

When Orleans deserializes a type marked with `[UseActivator]`:

1. The generated serializer requests an `IActivator<T>` from the <xref:Orleans.Serialization.Serializers.IActivatorProvider>.
2. The `IActivatorProvider` looks up the registered activator for the type. Types decorated with `[RegisterActivator]` are automatically registered during startup.
3. The activator's `Create()` method is called to produce a new instance.
4. The serializer populates the instance's serialized fields from the data stream.

If no custom activator is registered and the type doesn't have `[UseActivator]`, Orleans falls back to using the default activator, which calls the parameterless constructor or <xref:System.Runtime.CompilerServices.RuntimeHelpers.GetUninitializedObject%2A>.

## See also

- [Serialization and custom serializers](serialization.md)

---
title: Backward compatibility guidelines
description: Learn the backward compatibility guidelines in .NET Orleans.
ms.date: 07/03/2024
---

# Backward compatibility guidelines

Writing backward compatible code can be hard and difficult to test. This article discusses the guidelines for writing backward compatible code in .NET Orleans. This article covers the usage of <xref:Orleans.CodeGeneration.VersionAttribute>, and <xref:System.ObsoleteAttribute>.

## Never change the signature of existing methods

Because of how the Orleans serializer works, you should never change the signature
of existing methods.

The following example is correct:

```csharp
[Version(1)]
public interface IMyGrain : IGrainWithIntegerKey
{
    // First method
    Task MyMethod(int arg);
}
```

```csharp
[Version(2)]
public interface IMyGrain : IGrainWithIntegerKey
{
    // Method inherited from V1
    Task MyMethod(int arg);

    // New method added in V2
    Task MyNewMethod(int arg, obj o);
}
```

This is not correct:

```csharp
[Version(1)]
public interface IMyGrain : IGrainWithIntegerKey
{
    // First method
    Task MyMethod(int arg);
}
```

```csharp
[Version(2)]
public interface IMyGrain : IGrainWithIntegerKey
{
    // Method inherited from V1
    Task MyMethod(int arg, obj o);
}
```

> [!IMPORTANT]
> Do NOT make this change in your code, as it's an example of a bad practice that leads to very bad side effects.

This is an example of what can happen if you just rename the parameter names. Assume you have the following two interface versions deployed in the cluster:

```csharp
[Version(1)]
public interface IMyGrain : IGrainWithIntegerKey
{
    // return a - b
    Task<int> Subtract(int a, int b);
}
```

```csharp
[Version(2)]
public interface IMyGrain : IGrainWithIntegerKey
{
    // return b - a
    Task<int> Subtract(int b, int a);
}
```

These methods seem identical. But if the client was called with V1, and the request is
handled by a V2 activation:

```csharp
var grain = client.GetGrain<IMyGrain>(0);
var result = await grain.Subtract(5, 4); // Will return "-1" instead of expected "1"
```

This is due to how the internal Orleans serializer works.

## Avoid changing existing method logic

It can seem obvious, but you should be very careful when changing the body of an existing method.
Unless you are fixing a bug, it is better to just add a new method if you need to modify the code.

Example:

```csharp
// V1
public interface MyGrain : IMyGrain
{
    // First method
    Task MyMethod(int arg)
    {
        SomeSubRoutine(arg);
    }
}
```

```csharp
// V2
public interface MyGrain : IMyGrain
{
    // Method inherited from V1
    // Do not change the body
    Task MyMethod(int arg)
    {
        SomeSubRoutine(arg);
    }

    // New method added in V2
    Task MyNewMethod(int arg)
    {
        SomeSubRoutine(arg);
        NewRoutineAdded(arg);
    }
}
```

## Do not remove methods from grain interfaces

Unless you are sure that they're no longer used, you should not remove methods from the grain interface.
If you want to remove methods, this should be done in 2 steps:

1. Deploy V2 grains, with V1 method marked as `Obsolete`

    ```csharp
    [Version(1)]
    public interface IMyGrain : IGrainWithIntegerKey
    {
        // First method
        Task MyMethod(int arg);
    }
    ```

    ```csharp
    [Version(2)]
    public interface IMyGrain : IGrainWithIntegerKey
    {
        // Method inherited from V1
        [Obsolete]
        Task MyMethod(int arg);

        // New method added in V2
        Task MyNewMethod(int arg, obj o);
    }
    ```

2. When you are sure that no V1 calls are made (effectively V1 is no longer deployed in the running cluster), deploy V3 with V1 method removed.

    ```csharp
    [Version(3)]
    public interface IMyGrain : IGrainWithIntegerKey
    {
        // New method added in V2
        Task MyNewMethod(int arg, obj o);
    }
    ```

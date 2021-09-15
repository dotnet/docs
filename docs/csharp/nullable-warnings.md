---
title: Resolve nullable warnings
description: Enabling nullable reference types causes the compiler to issue warnings related to null safety. Learn techniques to address them.
ms.technology: csharp-null-safety
ms.date: 09/16/2021
---
# Learn techniques to resolve nullable warnings

error codes are here: https://github.com/dotnet/roslyn/blob/main/src/Compilers/CSharp/Portable/Errors/ErrorCode.cs#L1651-L1683

messages are here: https://github.com/dotnet/roslyn/blob/main/src/Compilers/CSharp/Portable/CSharpResources.resx#L5434-L5546

## Generic definitions and nullability

Correctly communicating the null state of generic types and generic methods requires special care. The extra care stems from the fact that a nullable value type and a nullable reference type are fundamentally different. An `int?` is a synonym for `Nullable<int>`, whereas `string?` is `string` with an attribute added by the compiler. The result is that the compiler can't generate correct code for `T?` without knowing if `T` is a `class` or a `struct`.

This fact doesn't mean you can't use a nullable type (either value type or reference type) as the type argument for a closed generic type. Both `List<string?>` and `List<int?>` are valid instantiations of `List<T>`.

What it does mean is that you can't use `T?` in a generic class or method declaration without constraints. For example, <xref:System.Linq.Enumerable.FirstOrDefault%60%601(System.Collections.Generic.IEnumerable%7B%60%600%7D)?displayProperty=nameWithType> won't be changed to return `T?`. You can overcome this limitation by adding either the `struct` or `class` constraint. With either of those constraints, the compiler knows how to generate code for both `T` and `T?`.

You may want to restrict the types used for a generic type argument to be non-nullable types. You can do that by adding the `notnull` constraint on that type argument. When that constraint is applied in a nullable context, the type argument must not be a nullable type.

## Late-initialized properties, Data Transfer Objects, and nullability

Indicating the nullability of properties that are late-initialized, meaning set after construction, may require special consideration to ensure that your class continues to correctly express the original design intent.

Types that contain late-initialized properties, such as Data Transfer Objects (DTOs), are often instantiated by an external library, like a database ORM (Object Relational Mapper), a deserializer, or some other component that automatically populates properties from another source.

Consider the following DTO class, prior to enabling nullable reference types, that represents a student:

```csharp
class Student
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public string VehicleRegistration { get; set; }
}
```

The design intent (indicated in this case by the `Required` attribute) suggests that in this system, the `FirstName` and `LastName` properties are **mandatory**, and therefore not null.

The `VehicleRegistration` property is **not mandatory**, so may be null.

When you enable nullable reference types, you want to indicate which properties on your DTO may be nullable, consistent with your original intent:

```csharp
class Student
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public string? VehicleRegistration { get; set; }
}
```

For this DTO, the only property that may be null is ``VehicleRegistration``.

However, the compiler raises `CS8618` warnings for both `FirstName` and `LastName`, indicating the non-nullable properties are uninitialized.

There are three options available to you that resolve the compiler warnings in a way that maintains the original intent. Any of these options are valid; you should choose the one that best suits your coding style and design requirements.

### Initialize in the constructor

The ideal way to resolve the uninitialized warnings is to initialize the properties in the constructor:

```csharp
class Student
{
    public Student(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public string? VehicleRegistration { get; set; }
}
```

This approach only works if the library that you use to instantiate the class supports passing parameters in the constructor.

A library may support passing *some* properties in the constructor, but not all. For example, EF Core supports [constructor binding](/ef/core/modeling/constructors) for normal column properties, but not navigation properties.

Check the documentation on the library that instantiates your class, to understand the extent to which it supports constructor binding.

### Property with nullable backing field

If constructor binding won't work for you, one way to deal with this problem is to have a non-nullable property with a nullable backing field:

```csharp
private string? _firstName;

[Required]
public string FirstName
{
    set => _firstName = value;
    get => _firstName
           ?? throw new InvalidOperationException("Uninitialized " + nameof(FirstName))
}
```

In this scenario, if the `FirstName` property is accessed before it has been initialized, then the code throws an `InvalidOperationException`, because the API contract has been used incorrectly.

Consider that some libraries may have special considerations when using backing fields. For example, EF Core may need to be configured to use [backing fields](/ef/core/modeling/backing-field) correctly.

### Initialize the property to null

As a terser alternative to using a nullable backing field, or if the library that instantiates your class isn't compatible with that approach, you can initialize the property to `null` directly, with the help of the null-forgiving operator (`!`):

```csharp
[Required]
public string FirstName { get; set; } = null!;

[Required]
public string LastName { get; set; } = null!;

public string? VehicleRegistration { get; set; }
```

You'll never observe an actual null value at runtime except as a result of a programming bug, by accessing the property before it has been properly initialized.

## See also

- [Working with Nullable Reference Types in EF Core](/ef/core/miscellaneous/nullable-reference-types)

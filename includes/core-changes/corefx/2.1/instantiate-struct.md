### Private fields added to built-in struct types

Private fields were added to built-in struct types in [reference assemblies](../../../../standard/assembly/reference-assemblies.md). As a result, in C#, struct types must always be instantiated with the `new` operator.

#### Change description

In .NET Core 2.0 and previous versions, some built-in struct types, for example, <xref:System.ConsoleKeyInfo>, could be instantiated without using the `new` operator in C#. This was because the [reference assemblies](../../../../standard/assembly/reference-assemblies.md) used by the C# compiler didn't contain the private fields for the structs. All private fields for .NET struct types are added to the reference assemblies starting in .NET Core 2.1.

For example, the following C# code compiles in .NET Core 2.0, but not in .NET Core 2.1:

```csharp
ConsoleKeyInfo key;    // Struct type

if (key.ToString() == "y")
{
    Console.WriteLine("Yes!");
}
```

In .NET Core 2.1, the previous code results in the following compiler error: **CS0165 - Use of unassigned local variable 'key'**

#### Version introduced

2.1

#### Recommended action

Instantiate struct types by using the `new` operator.

For example:

```csharp
ConsoleKeyInfo key = new ConsoleKeyInfo();    // Struct type

if (key.ToString() == "y")
{
    Console.WriteLine("Yes!");
}
```

#### Category

CoreFx

#### Affected APIs

- <xref:System.ConsoleKeyInfo>
- <xref:System.Memory%601?displayProperty=nameWithType>
- <xref:System.Collections.Immutable.ImmutableArray%601>

<!--

### Affected APIs

- `T:System.ConsoleKeyInfo`
- `T:System.Memory{T}`
- `T:System.Collections.Immutable.ImmutableArray{T}`

-->

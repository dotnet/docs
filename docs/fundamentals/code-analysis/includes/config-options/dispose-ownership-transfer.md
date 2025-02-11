### Configure dispose ownership transfer

The [dispose_ownership_transfer_at_constructor](../../code-quality-rule-options.md#dispose_ownership_transfer_at_constructor) and [dispose_ownership_transfer_at_method_call](../../code-quality-rule-options.md#dispose_ownership_transfer_at_method_call) options configure the transfer of dispose ownership.

For example, to specify that the rule transfers dispose ownership for arguments passed to constructors, add the following key-value pair to an *.editorconfig* file in your project:

```ini
dotnet_code_quality.CAXXXX.dispose_ownership_transfer_at_constructor = true
```

> [!NOTE]
> Replace the `XXXX` part of `CAXXXX` with the ID of the applicable rule.

#### dispose_ownership_transfer_at_constructor

Consider the following code example.

```csharp
class A : IDisposable
{
    public void Dispose() { }
}

class Test
{
    DisposableOwnerType M1()
    {
        return new DisposableOwnerType(new A());
    }
}
```

- If `dotnet_code_quality.dispose_ownership_transfer_at_constructor` is set to `true`, dispose ownership for the `new A()` allocation is transferred to the returned `DisposableOwnerType` instance.
- If `dotnet_code_quality.dispose_ownership_transfer_at_constructor` is set to `false`, `Test.M1()` has the dispose ownership for `new A()`, and results in a `CA2000` violation for a dispose leak.

#### dispose_ownership_transfer_at_method_call

Consider the following code example.

```csharp
class Test
{
    void M1()
    {
        TransferDisposeOwnership(new A());
    }
}
```

- If `dotnet_code_quality.dispose_ownership_transfer_at_method_call` is set to `true`, dispose ownership for the `new A()` allocation is transferred to the `TransferDisposeOwnership` method.
- If `dotnet_code_quality.dispose_ownership_transfer_at_method_call` is set to `false`, `Test.M1()` has the dispose ownership for `new A()`, and results in a `CA2000` violation for a dispose leak.

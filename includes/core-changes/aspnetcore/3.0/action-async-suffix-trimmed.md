### Async suffix trimmed from controller action names

As part of addressing [aspnet/AspNetCore#4849](https://github.com/aspnet/AspNetCore/issues/4849), ASP.NET Core MVC trims the suffix `Async` from action names by default. This change affects both routing and link generation.

#### Version introduced

3.0

#### Old behavior

Consider the following ASP.NET Core MVC controller:

```csharp
public class ProductController : Controller
{
    public async IActionResult ListAsync()
    {
        var model = await DbContext.Products.ToListAsync();
        return View(model);
    }
}
```

The action is routable via `Product/ListAsync`. Link generation requires specifying the `Async` suffix. For example:

```cshtml
<a asp-controller="Product" asp-action="ListAsync">List</a>
```

#### New behavior

In ASP.NET Core 3.0, the action is routable via `Product/List`. Link generation code should omit the `Async` suffix. For example:

```cshtml
<a asp-controller="Product" asp-action="List">List</a>
```

This change doesn't affect names specified using the `[ActionName]` attribute. The new behavior can be disabled by setting `MvcOptions.SuppressAsyncSuffixInActionNames` to `false` in `Startup.ConfigureServices`:

```csharp
services.AddMvc(options =>
{
   options.SuppressAsyncSuffixInActionNames = false; 
});
```

#### Reason for change

By convention, asynchronous .NET methods are suffixed with `Async`. However, when a method defines an MVC action, it's undesirable to use the `Async` suffix.

#### Recommended action

If your app depends on MVC actions preserving the name's `Async` suffix, choose one of the following mitigations:

- Use the `[ActionName]` attribute to preserve the original name.
- Disable the renaming entirely by setting `MvcOptions.SuppressAsyncSuffixInActionNames` to `false` in `Startup.ConfigureServices`:

```csharp
services.AddMvc(options =>
{
   options.SuppressAsyncSuffixInActionNames = false; 
});
```

#### Category

ASP.NET Core

#### Affected APIs

Not detectable via API analysis

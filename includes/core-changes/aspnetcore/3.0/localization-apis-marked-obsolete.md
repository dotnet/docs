### Localization: ResourceManagerWithCultureStringLocalizer and WithCulture marked obsolete

The [ResourceManagerWithCultureStringLocalizer](https://github.com/aspnet/Localization/blob/43b974482c7b703c92085c6f68b3b23d8fe32720/src/Microsoft.Extensions.Localization/ResourceManagerWithCultureStringLocalizer.cs#L18) class and [WithCulture](https://github.com/aspnet/Localization/blob/master/src/Microsoft.Extensions.Localization/ResourceManagerStringLocalizer.cs#L154-L170) interface member are often sources of confusion for users of localization, especially when creating their own `IStringLocalizer` implementation. These items give the user the impression that an `IStringLocalizer` instance is "per-language, per-resource". In reality, the instances should only be "per-resource". The language searched for is determined by the `CultureInfo.CurrentUICulture` at execution time. To eliminate the source of confusion, the APIs were marked as obsolete in ASP.NET Core 3.0 Preview 3. The APIs will be removed in a future release.

For context, see [dotnet/aspnetcore#3324](https://github.com/dotnet/aspnetcore/issues/3324). For discussion, see [dotnet/aspnetcore#7756](https://github.com/dotnet/aspnetcore/issues/7756).

#### Version introduced

3.0

#### Old behavior

Methods weren't marked as `Obsolete`.

#### New behavior

Methods are marked `Obsolete`.

#### Reason for change

The APIs represented a use case that isn't recommended. There was confusion about the design of localization.

#### Recommended action

The recommendation is to use `ResourceManagerStringLocalizer` instead. Let the culture be set by the `CurrentCulture`. If that isn't an option, create and use a copy of [ResourceManagerWithCultureStringLocalizer](https://github.com/aspnet/Localization/blob/43b974482c7b703c92085c6f68b3b23d8fe32720/src/Microsoft.Extensions.Localization/ResourceManagerWithCultureStringLocalizer.cs#L18).

#### Category

ASP.NET Core

#### Affected APIs

- [ResourceManagerWithCultureStringLocalizer](/dotnet/api/microsoft.extensions.localization.resourcemanagerwithculturestringlocalizer?view=dotnet-plat-ext-3.0&preserve-view=true)
- [ResourceManagerStringLocalizer.WithCulture](/dotnet/api/microsoft.extensions.localization.resourcemanagerstringlocalizer.withculture?view=dotnet-plat-ext-3.0&preserve-view=true)

<!--

#### Affected APIs

- `T:Microsoft.Extensions.Localization.ResourceManagerWithCultureStringLocalizer`
- `Overload:Microsoft.Extensions.Localization.ResourceManagerStringLocalizer.WithCulture`

-->

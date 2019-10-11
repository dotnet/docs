### SignInManager constructor accepts new parameter

As part of adding support for new email / confirmation flows in Identity, a new `IUserConfirmation<TUser>` argument was added to the `SignInManager` constructor. For more information, see [aspnet/AspNetCore#8356](https://github.com/aspnet/AspNetCore/issues/8356).

#### Version introduced

3.0

#### Old behavior

`SignInManager` didn't require `IUserConfirmation` when constructing.

#### New behavior

`SignInManager` requires an `IUserConfirmation`.

#### Reason for change

The motivation for the change was to add support for new email / confirmation flows.

#### Recommended action

If manually constructing a `SignInManager`, provide an implementation of `IUserConfirmation` or grab one from dependency injection to provide.

#### Category

ASP.NET Core

#### Affected APIs

<xref:Microsoft.AspNetCore.Identity.SignInManager`1.%23ctor%2A?displayProperty=nameWithType>

<!--

#### Affected APIs

`Overload:Microsoft.AspNetCore.Identity.SignInManager`1.#ctor`

-->

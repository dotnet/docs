### SignInAsync throws exception for an unauthenticated identity

By default, `SignInAsync` throws an exception for principals / identities in which `IsAuthenticated` is `false`.

#### Version introduced

3.0

#### Old behavior

`SignInAsync` accepts any principals / identities, including identities in which `IsAuthenticated` is `false`.

#### New behavior

By default, `SignInAsync` throws an exception for principals / identities in which `IsAuthenticated` is `false`. There's a new flag to suppress this behavior, but the default behavior has changed.

#### Reason for change

The old behavior was problematic because, by default, these principals were rejected by `[Authorize]` / `RequireAuthenticatedUser()`.

#### Recommended action

In ASP.NET Core 3.0 Preview 6, there's a `RequireAuthenticatedSignIn` flag on `AuthenticationOptions` that is `true` by default. Set this flag to `false` to restore the old behavior.

#### Category

ASP.NET Core

#### Affected APIs

None

<!-- 

### Affected APIs

Not detectable via API analysis

-->

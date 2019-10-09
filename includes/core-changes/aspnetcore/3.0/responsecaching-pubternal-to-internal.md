### Make "pubternal" types in ResponseCaching internal

In ASP.NET Core, "pubternal" types are declared as `public` but reside in a namespace suffixed with `.Internal`. While these types are public, they have no support policy and are subject to breaking changes. Unfortunately, accidental use of these types has been common, resulting in breaking changes to these projects and limiting our ability to maintain the framework.

In ASP.NET Core 3.0, "pubternal" types in ResponseCaching have been changed to `internal`.

In addition, a default implementation for `IResponseCachingPolicyProvider` and `IResponseCachingKeyProvider` are no longer added to services as part of the `AddResponseCaching` method.

#### Version introduced

3.0

#### Old behavior

These types were publicly visible, but unsupported.

#### New behavior

These types are now `internal`.

#### Reason for change

The `internal` scope better reflects the unsupported policy.

#### Recommended action

Copy types that are used by your app or library.

#### Category

ASP.NET Core

#### Affected APIs

- `Microsoft.AspNetCore.ResponseCaching.Internal.CachedResponse`
- `Microsoft.AspNetCore.ResponseCaching.Internal.CachedVaryByRules`
- `Microsoft.AspNetCore.ResponseCaching.Internal.IResponseCache`
- `Microsoft.AspNetCore.ResponseCaching.Internal.IResponseCacheEntry`
- `Microsoft.AspNetCore.ResponseCaching.Internal.IResponseCachingKeyProvider`
- `Microsoft.AspNetCore.ResponseCaching.Internal.IResponseCachingPolicyProvider`
- `Microsoft.AspNetCore.ResponseCaching.Internal.MemoryResponseCache`
- `Microsoft.AspNetCore.ResponseCaching.Internal.ResponseCachingContext`
- `Microsoft.AspNetCore.ResponseCaching.Internal.ResponseCachingKeyProvider`
- `Microsoft.AspNetCore.ResponseCaching.Internal.ResponseCachingPolicyProvider`
- /dotnet/api/microsoft.aspnetcore.responsecaching.responsecachingmiddleware.-ctor?view=aspnetcore-2.2

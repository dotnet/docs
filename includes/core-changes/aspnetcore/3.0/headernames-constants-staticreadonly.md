### HeaderNames constants changed to static readonly

The static [Microsoft.Net.Http.Headers.HeaderNames](/dotnet/api/microsoft.net.http.headers.headernames?view=aspnetcore-2.2) class contains string fields representing various common header names. For example, [HeaderNames.Origin](/dotnet/api/microsoft.net.http.headers.headernames.origin?view=aspnetcore-2.2). Starting in ASP.NET Core 3.0 Preview 5, the fields will change from `const` to `static readonly`.

For discussion, see [aspnet/AspNetCore#9514](https://github.com/aspnet/AspNetCore/issues/9514).

#### Version introduced

3.0

#### Old behavior

These fields used to be `const`

#### New behavior

These fields are now `static readonly`.

#### Reason for change

The change prevents the values from being embedded across assembly boundaries, allowing for value corrections as needed. It also enables faster reference equality checks.

#### Recommended action

Recompile against 3.0. Source code that used these fields as an attribute argument, a `case` in a `switch` statement, or when defining another constant can no longer do so. To work around this break, switch to using self-defined header name constants or string literals.

#### Category

ASP.NET Core

#### Affected APIs

All fields on [Microsoft.Net.Http.Headers.HeaderNames](/dotnet/api/microsoft.net.http.headers.headernames)

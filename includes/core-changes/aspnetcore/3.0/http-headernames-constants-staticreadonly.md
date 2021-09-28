### HTTP: HeaderNames constants changed to static readonly

Starting in ASP.NET Core 3.0 Preview 5, the fields in <xref:Microsoft.Net.Http.Headers.HeaderNames?displayProperty=fullName> changed from `const` to `static readonly`.

For discussion, see [dotnet/aspnetcore#9514](https://github.com/dotnet/aspnetcore/issues/9514).

#### Version introduced

3.0

#### Old behavior

These fields used to be `const`.

#### New behavior

These fields are now `static readonly`.

#### Reason for change

The change:

* Prevents the values from being embedded across assembly boundaries, allowing for value corrections as needed.
* Enables faster reference equality checks.

#### Recommended action

Recompile against 3.0. Source code using these fields in the following ways can no longer do so:

* As an attribute argument
* As a `case` in a `switch` statement
* When defining another `const`

To work around the breaking change, switch to using self-defined header name constants or string literals.

#### Category

ASP.NET Core

#### Affected APIs

<xref:Microsoft.Net.Http.Headers.HeaderNames?displayProperty=fullName>

<!-- 

#### Affected APIs

`T:Microsoft.Net.Http.Headers.HeaderNames`

-->

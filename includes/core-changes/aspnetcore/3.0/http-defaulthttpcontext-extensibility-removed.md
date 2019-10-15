### HTTP: DefaultHttpContext extensibility removed

As part of ASP.NET Core 3.0 performance improvements, the extensibility of `DefaultHttpContext` was removed. The class is now `sealed`. For more information, see [aspnet/AspNetCore#6504](https://github.com/aspnet/AspNetCore/pull/6504).

If your unit tests use `Mock<DefaultHttpContext>`, use `Mock<HttpContext>` instead. 

For discussion, see [aspnet/AspNetCore#6534](https://github.com/aspnet/AspNetCore/issues/6534).

#### Version introduced

3.0

#### Old behavior

Classes can derive from `DefaultHttpContext`.

#### New behavior

Classes can't derive from `DefaultHttpContext`.

#### Reason for change

The extensibility was provided initially to allow pooling of the `HttpContext`, but it introduced unnecessary complexity and impeded other optimizations.

#### Recommended action

If you're using `Mock<DefaultHttpContext>` in your unit tests, begin using `Mock<HttpContext>` instead. 

#### Category

ASP.NET Core

#### Affected APIs

<xref:Microsoft.AspNetCore.Http.DefaultHttpContext?displayProperty=nameWithType>

<!--

#### Affected APIs

`T:Microsoft.AspNetCore.Http.DefaultHttpContext`

-->

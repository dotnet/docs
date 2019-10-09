### Removed DefaultHttpContext extensibility

As part of ASP.NET Core 3.0 performance improvements, the extensibility of `DefaultHttpContext` was removed. The class is now `sealed`. For more information, see [aspnet/AspNetCore#6504](https://github.com/aspnet/AspNetCore/pull/6504). This extensibility was provided initially to allow pooling of the `HttpContext`, but it introduced unnecessary complexity and impeded other optimizations. As a result, this extensibility was removed.

If your units tests use `Mock<DefaultHttpContext>`, use `Mock<HttpContext>` instead. 

For discussion, see https://github.com/aspnet/AspNetCore/issues/6534.

#### Version introduced

3.0

#### Old behavior

Classes could derive from `DefaultHttpContext`.

#### New behavior

`DefaultHttpContext` is `sealed`.

#### Reason for change

Extensibility introduced unnecessary complexity and impeded other optimizations. As a result, the extensibility was removed.

#### Recommended action

If you're using `Mock<DefaultHttpContext>` in your unit tests, begin using `Mock<HttpContext>` instead. 

#### Category

ASP.NET Core

#### Affected APIs

[DefaultHttpContext](/dotnet/api/microsoft.aspnetcore.http.defaulthttpcontext)

### AllowSynchronousIO disabled in all servers

`AllowSynchronousIO` is an option in each server that enables or disables synchronous IO APIs like `HttpRequest.Body.Read`, `HttpResponse.Body.Write`, and `Stream.Flush`. These APIs have long been a source of thread starvation and app hangs. Starting in ASP.NET Core 3.0 Preview 3, these synchronous operations are disabled by default.

Affected servers:

- Kestrel
- HttpSys
- IIS in-process
- TestServer

Expect errors similar to:

- `Synchronous operations are disallowed. Call ReadAsync or set AllowSynchronousIO to true instead.`
- `Synchronous operations are disallowed. Call WriteAsync or set AllowSynchronousIO to true instead.`
- `Synchronous operations are disallowed. Call FlushAsync or set AllowSynchronousIO to true instead.`

Each server has an `AllowSynchronousIO` option that controls this behavior and the default for all of them is now `false`.

The behavior can also be overridden on a per-request basis as a temporary mitigation. For example:

```csharp
var syncIOFeature = HttpContext.Features.Get<IHttpBodyControlFeature>();
if (syncIOFeature != null)
{
    syncIOFeature.AllowSynchronousIO = true;
}
```

If you have trouble with TextWriters or other streams calling synchronous APIs in `Dispose`, call the new `DisposeAsync` API instead.

For discussion, see https://github.com/aspnet/AspNetCore/issues/7644.

#### Version introduced

3.0

#### Old behavior

`HttpRequest.Body.Read`, `HttpResponse.Body.Write`, and `Stream.Flush` were allowed by default.

#### New behavior

These synchronous APIs are disallowed by default: 

Expect errors similar to:

- `Synchronous operations are disallowed. Call ReadAsync or set AllowSynchronousIO to true instead.`
- `Synchronous operations are disallowed. Call WriteAsync or set AllowSynchronousIO to true instead.`
- `Synchronous operations are disallowed. Call FlushAsync or set AllowSynchronousIO to true instead.`

#### Reason for change

These synchronous APIs have long been a source of thread starvation and app hangs. Starting in ASP.NET Core 3.0 Preview 3, the synchronous operations are disabled by default.

#### Recommended action

Use the asynchronous versions of the methods. The behavior can also be overridden on a per-request basis as a temporary mitigation.

```csharp
var syncIOFeature = HttpContext.Features.Get<IHttpBodyControlFeature>();
if (syncIOFeature != null)
{
    syncIOFeature.AllowSynchronousIO = true;
}
```

#### Category

ASP.NET Core

#### Affected APIs

- [HttpRequest.Body.Read](/dotnet/api/system.io.stream.read?view=netframework-4.8)
- [HttpResponse.Body.Flush](/dotnet/api/system.io.stream.flush?view=netframework-4.8)
- [HttpResponse.Body.Write](/dotnet/api/system.io.stream.write?view=netframework-4.8)

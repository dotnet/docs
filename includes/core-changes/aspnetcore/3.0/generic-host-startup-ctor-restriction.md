### Generic host restricts Startup constructor injection

The only types the generic host supports for `Startup` class constructor injection are `IHostEnvironment`, `IWebHostEnvironment`, and `IConfiguration`. Apps using `WebHost` are unaffected.

#### Change description

Prior to ASP.NET Core 3.0, constructor injection could be used for arbitrary types in the `Startup` class's constructor. In ASP.NET Core 3.0, the web stack was replatformed onto the generic host library. You can see the change in the *Program.cs* file of the templates:

**ASP.NET Core 2.x:**

https://github.com/aspnet/AspNetCore/blob/5cb615fcbe8559e49042e93394008077e30454c0/src/Templating/src/Microsoft.DotNet.Web.ProjectTemplates/content/EmptyWeb-CSharp/Program.cs#L20-L22

**ASP.NET Core 3.0:**

https://github.com/aspnet/AspNetCore/blob/b1ca2c1155da3920f0df5108b9fedbe82efaa11c/src/ProjectTemplates/Web.ProjectTemplates/content/EmptyWeb-CSharp/Program.cs#L19-L24

`Host` uses one dependency injection (DI) container to build the app. `WebHost` uses two containers: one for the host and one for the app. As a result, the `Startup` constructor no longer supports custom service injection. Only `IHostEnvironment`, `IWebHostEnvironment`, and `IConfiguration` can be injected. This change prevents DI issues such as the duplicate creation of a singleton service.

#### Version introduced

3.0

#### Reason for change

This change is a consequence of replatforming the web stack onto the generic host library.

#### Recommended action

Inject services into the `Startup.Configure` method signature. For example:

```csharp
public void Configure(IApplicationBuilder app, IOptions<MyOptions> options)
```

#### Category

ASP.NET Core

#### Affected APIs

None

<!-- 

#### Affected APIs

Not detectable via API analysis

-->

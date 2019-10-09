### Identity UI uses static web assets feature

ASP.NET Core 3.0 introduced a static web assets feature, and Identity UI has adopted that new feature. As part of this move, there are a few API breaking changes to note.

Bootstrap 4 is the default UI framework for Identity UI. Bootstrap 3 has reached end of life and you should consider migrating to a supported version.

Framework selection is accomplished by using the `IdentityUIFrameworkVersion` property in your project file.

#### Version introduced

3.0

#### Old behavior

The default UI framework for Identity UI was **Bootstrap 3**. The UI framework could be configured using a parameter to the `AddIdentityUI` method call in `Startup.ConfigureServices`.

#### New behavior

The default UI framework for Identity UI is **Bootstrap 4**. The UI framework must be configured in your project file, instead of in the `AddIdentityUI` method call. Add the following MSBuild property to a `<PropertyGroup>` element in your project file:

```xml
<IdentityUIFrameworkVersion>Bootstrap3</IdentityUIFrameworkVersion>
```

#### Reason for change

The default UI framework was updated to reflect a new version of Bootstrap. Because the new static web assets feature is used, the UI framework configuration moved to MSBuild. The decision on which framework to embed is a build-time decision, not a runtime decision.

#### Recommended action

Review your site UI to ensure the new Bootstrap 4 components are compatible. If necessary, use the `IdentityUIFrameworkVersion` MSBuild property to revert to 3.

#### Category

ASP.NET Core

#### Affected APIs

[IdentityBuilderUIExtensions.AddDefaultUI()](/dotnet/api/microsoft.aspnetcore.identity.identitybuilderuiextensions.adddefaultui)

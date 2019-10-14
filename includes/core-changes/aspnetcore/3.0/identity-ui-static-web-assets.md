### Identity: UI uses static web assets feature

ASP.NET Core 3.0 introduced a static web assets feature, and Identity UI has adopted it.

#### Change description

As a result of Identity UI adopting the static web assets feature:

- Framework selection is accomplished by using the `IdentityUIFrameworkVersion` property in your project file.
- Bootstrap 4 is the default UI framework for Identity UI. Bootstrap 3 has reached end of life, and you should consider migrating to a supported version.

#### Version introduced

3.0

#### Old behavior

The default UI framework for Identity UI was **Bootstrap 3**. The UI framework could be configured using a parameter to the `AddIdentityUI` method call in `Startup.ConfigureServices`.

#### New behavior

The default UI framework for Identity UI is **Bootstrap 4**. The UI framework must be configured in your project file, instead of in the `AddIdentityUI` method call.

#### Reason for change

Adoption of the static web assets feature required that the UI framework configuration move to MSBuild. The decision on which framework to embed is a build-time decision, not a runtime decision.

#### Recommended action

Review your site UI to ensure the new Bootstrap 4 components are compatible. If necessary, use the `IdentityUIFrameworkVersion` MSBuild property to revert to Bootstrap 3. Add the property to a `<PropertyGroup>` element in your project file:

```xml
<IdentityUIFrameworkVersion>Bootstrap3</IdentityUIFrameworkVersion>
```

#### Category

ASP.NET Core

#### Affected APIs

<xref:Microsoft.AspNetCore.Identity.IdentityBuilderUIExtensions.AddDefaultUI(Microsoft.AspNetCore.Identity.IdentityBuilder)?displayProperty=nameWithType>

<!-- 

#### Affected APIs

`M:Microsoft.AspNetCore.Identity.IdentityBuilderUIExtensions.AddDefaultUI(Microsoft.AspNetCore.Identity.IdentityBuilder)`

-->

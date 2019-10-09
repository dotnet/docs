### Default Bootstrap version of Identity UI changed to 4

Currently, the default version of Bootstrap for Identity UI is `UIFramework.Bootstrap3`. Starting in ASP.NET Core 3.0, the default version is `UIFramework.Bootstrap4`.

#### Version introduced

3.0

#### Old behavior

The `services.AddDefaultIdentity<IdentityUser>().AddDefaultUI();` method call was the same as `services.AddDefaultIdentity<IdentityUser>().AddDefaultUI(UIFramework.Bootstrap3);`

#### New behavior

The `services.AddDefaultIdentity<IdentityUser>().AddDefaultUI();` method call is the same as `services.AddDefaultIdentity<IdentityUser>().AddDefaultUI(UIFramework.Bootstrap4);`

#### Reason for change

Bootstrap 4 was released during ASP.NET Core 3.0 timeframe.

#### Recommended action

You're impacted by this change if you use the default Identity UI and have added it in `Startup.ConfigureServices` as shown below:

```csharp
services.AddDefaultIdentity<IdentityUser>().AddDefaultUI();
```

Take one of the following actions:

- Migrate your app to use Bootstrap 4 using their [migration guide](https://getbootstrap.com/docs/4.0/migration).
- Update `Startup.ConfigureServices` to enforce usage of Bootstrap 3. For example:

    ```csharp
    services.AddDefaultIdentity<IdentityUser>().AddDefaultUI(UIFramework.Bootstrap3);
    ```

#### Category

ASP.NET Core

#### Affected APIs

None

<!-- 

### Affected APIs

Not detectable via API analysis

-->

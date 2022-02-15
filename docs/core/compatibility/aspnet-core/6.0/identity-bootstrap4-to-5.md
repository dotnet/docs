---
title: "Breaking change: Default version of Bootstrap used with Identity now 5"
description: "Learn about the breaking change in ASP.NET Core 6.0 where the default version of Bootstrap used with Identity changes from 4 to 5."
ms.date: 04/21/2021
---
# Identity default Bootstrap version of UI changed

### Identity: Default Bootstrap version of UI changed

Starting in ASP.NET Core 6.0, Identity UI defaults to using [version 5 of Bootstrap](https://getbootstrap.com/docs/5.0/getting-started/introduction/).

#### Version introduced

6.0

#### Old behavior

The `services.AddDefaultIdentity<IdentityUser>().AddDefaultUI();` method call was the same as `services.AddDefaultIdentity<IdentityUser>().AddDefaultUI(UIFramework.Bootstrap4);`

#### New behavior

The `services.AddDefaultIdentity<IdentityUser>().AddDefaultUI();` method call is the same as `services.AddDefaultIdentity<IdentityUser>().AddDefaultUI(UIFramework.Bootstrap5);`

#### Reason for change

Bootstrap 5 was released during ASP.NET Core 6.0 timeframe.

#### Recommended action

Apps are impacted by this change that use the default Identity UI and have added it in `Startup.ConfigureServices` as shown in the following code:

```csharp
services.AddDefaultIdentity<IdentityUser>().AddDefaultUI();
```

Take one of the following actions:

- Migrate the app to use Bootstrap 4 using their [migration guide](https://getbootstrap.com/docs/5.0/migration/).
- Update `Startup.ConfigureServices` to enforce usage of Bootstrap 4. For example:

    ```csharp
    services.AddDefaultIdentity<IdentityUser>().AddDefaultUI(UIFramework.Bootstrap4);
    ```

#### Category

ASP.NET Core

#### Affected APIs

None

<!-- 

#### Affected APIs

Not detectable via API analysis

-->
---
title: About authorization in .NET microservices and web applications
description: Security in .NET Microservices and Web Applications - Get an overview of the main authorization options in ASP.NET Core applications - role-based and policy-based.
author: mjrousos
ms.author: wiwagn
ms.date: 10/19/2018
---
# About authorization in .NET microservices and web applications

After authentication, ASP.NET Core Web APIs need to authorize access. This process allows a service to make APIs available to some authenticated users, but not to all. [Authorization](/aspnet/core/security/authorization/introduction) can be done based on users’ roles or based on custom policy, which might include inspecting claims or other heuristics.

Restricting access to an ASP.NET Core MVC route is as easy as applying an Authorize attribute to the action method (or to the controller’s class if all the controller’s actions require authorization), as shown in following example:

```csharp
public class AccountController : Controller
{
    public ActionResult Login()
    {
    }

    [Authorize]
    public ActionResult Logout()
    {
    }
}
```

By default, adding an Authorize attribute without parameters will limit access to authenticated users for that controller or action. To further restrict an API to be available for only specific users, the attribute can be expanded to specify required roles or policies that users must satisfy.

## Implement role-based authorization

ASP.NET Core Identity has a built-in concept of roles. In addition to users, ASP.NET Core Identity stores information about different roles used by the application and keeps track of which users are assigned to which roles. These assignments can be changed programmatically with the `RoleManager` type that updates roles in persisted storage, and the `UserManager` type that can grant or revoke roles from users.

If you're authenticating with JWT bearer tokens, the ASP.NET Core JWT bearer authentication middleware will populate a user’s roles based on role claims found in the token. To limit access to an MVC action or controller to users in specific roles, you can include a Roles parameter in the Authorize annotation (attribute), as shown in the following code fragment:

```csharp
[Authorize(Roles = "Administrator, PowerUser")]
public class ControlPanelController : Controller
{
    public ActionResult SetTime()
    {
    }

    [Authorize(Roles = "Administrator")]
    public ActionResult ShutDown()
    {
    }
}
```

In this example, only users in the Administrator or PowerUser roles can access APIs in the ControlPanel controller (such as executing the SetTime action). The ShutDown API is further restricted to allow access only to users in the Administrator role.

To require a user be in multiple roles, you use multiple Authorize attributes, as shown in the following example:

```csharp
[Authorize(Roles = "Administrator, PowerUser")]
[Authorize(Roles = "RemoteEmployee ")]
[Authorize(Policy = "CustomPolicy")]
public ActionResult API1 ()
{
}
```

In this example, to call API1, a user must:

- Be in the Administrator *or* PowerUser role, *and*

- Be in the RemoteEmployee role, *and*

- Satisfy a custom handler for CustomPolicy authorization.

## Implement policy-based authorization

Custom authorization rules can also be written using [authorization policies](https://docs.asp.net/en/latest/security/authorization/policies.html). This section provides an overview. For more information, see the [ASP.NET Authorization Workshop](https://github.com/blowdart/AspNetAuthorizationWorkshop).

Custom authorization policies are registered in the Startup.ConfigureServices method using the service.AddAuthorization method. This method takes a delegate that configures an AuthorizationOptions argument.

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("AdministratorsOnly", policy =>
        policy.RequireRole("Administrator"));
    options.AddPolicy("EmployeesOnly", policy =>
        policy.RequireClaim("EmployeeNumber"));
    options.AddPolicy("Over21", policy =>
        policy.Requirements.Add(new MinimumAgeRequirement(21)));
});
```

As shown in the example, policies can be associated with different types of requirements. After the policies are registered, they can be applied to an action or controller by passing the policy’s name as the Policy argument of the Authorize attribute (for example, `[Authorize(Policy="EmployeesOnly")]`) Policies can have multiple requirements, not just one (as shown in these examples).

In the previous example, the first AddPolicy call is just an alternative way of authorizing by role. If `[Authorize(Policy="AdministratorsOnly")]` is applied to an API, only users in the Administrator role will be able to access it.

The second <xref:Microsoft.AspNetCore.Authorization.AuthorizationOptions.AddPolicy%2A> call demonstrates an easy way to require that a particular claim should be present for the user. The <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireClaim%2A> method also optionally takes expected values for the claim. If values are specified, the requirement is met only if the user has both a claim of the correct type and one of the specified values. If you're using the JWT bearer authentication middleware, all JWT properties will be available as user claims.

The most interesting policy shown here is in the third `AddPolicy` method, because it uses a custom authorization requirement. By using custom authorization requirements, you can have a great deal of control over how authorization is performed. For this to work, you must implement these types:

- A Requirements type that derives from <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirement> and that contains fields specifying the details of the requirement. In the example, this is an age field for the sample `MinimumAgeRequirement` type.

- A handler that implements <xref:Microsoft.AspNetCore.Authorization.AuthorizationHandler%601>, where T is the type of <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirement> that the handler can satisfy. The handler must implement the <xref:Microsoft.AspNetCore.Authorization.AuthorizationHandler%601.HandleRequirementAsync%2A> method, which checks whether a specified context that contains information about the user satisfies the requirement.

If the user meets the requirement, a call to `context.Succeed` will indicate that the user is authorized. If there are multiple ways that a user might satisfy an authorization requirement, multiple handlers can be created.

In addition to registering custom policy requirements with `AddPolicy` calls, you also need to register custom requirement handlers via Dependency Injection (`services.AddTransient<IAuthorizationHandler, MinimumAgeHandler>()`).

An example of a custom authorization requirement and handler for checking a user’s age (based on a `DateOfBirth` claim) is available in the ASP.NET Core [authorization documentation](https://docs.asp.net/en/latest/security/authorization/policies.html).

## Additional resources

- **ASP.NET Core Authentication** \
  [*https://docs.microsoft.com/aspnet/core/security/authentication/identity*](/aspnet/core/security/authentication/identity)

- **ASP.NET Core Authorization** \
  [*https://docs.microsoft.com/aspnet/core/security/authorization/introduction*](/aspnet/core/security/authorization/introduction)

- **Role-based Authorization** \
  [*https://docs.microsoft.com/aspnet/core/security/authorization/roles*](/aspnet/core/security/authorization/roles)

- **Custom Policy-Based Authorization** \
  [*https://docs.microsoft.com/aspnet/core/security/authorization/policies*](/aspnet/core/security/authorization/policies)

>[!div class="step-by-step"]
>[Previous](index.md)
>[Next](developer-app-secrets-storage.md)

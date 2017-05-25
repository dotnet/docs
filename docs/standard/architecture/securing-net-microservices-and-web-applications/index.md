---
title: Securing .NET Microservices and Web Applications | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Securing .NET Microservices and Web Applications
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
ms.prod: .net-core
ms.technology: dotnet-docker
---
# Securing .NET Microservices and Web Applications

It is often necessary for resources and APIs exposed by a service to be limited to certain trusted users or clients. The first step to making these sorts of API-level trust decisions is authentication. Authentication is the process of reliably ascertaining a user’s identity.

In microservice scenarios, authentication is typically handled centrally. If you are using an API Gateway, the gateway is a good place to authenticate, as shown in Figure 11-1. If you use this approach, make sure that the individual microservices cannot be reached directly (without the API Gateway) unless additional security is in place to authenticate messages whether they come from the gateway or not.

![](./media/image1.png)

**Figure 11-1**. Centralized authentication with an API Gateway

If services can be accessed directly, an authentication service like Azure Active Directory or a dedicated authentication microservice acting as a security token service (STS) can be used to authenticate users. Trust decisions are shared between services with security tokens or cookies. (These can be shared between applications, if needed, in ASP.NET Core with [data protection services](https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/compatibility/cookie-sharing#sharing-authentication-cookies-between-applications).) This pattern is illustrated in Figure 11-2.

![](./media/image2.png)

**Figure 11-2**. Authentication by identity microservice; trust is shared using an authorization token

## Authenticating using ASP.NET Core Identity

The primary mechanism in ASP.NET Core for identifying an application’s users is the [ASP.NET Core Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity) membership system. ASP.NET Core Identity stores user information (including sign-in information, roles, and claims) in a data store configured by the developer. Typically, the ASP.NET Core Identity data store is an Entity Framework store provided in the Microsoft.AspNetCore.Identity.EntityFrameworkCore package. However, custom stores or other third-party packages can be used to store identity information in Azure Table Storage, DocumentDB, or other locations.

The following code is taken from the ASP.NET Core Web Application project template with individual user account authentication selected. It shows how to configure ASP.NET Core Identity using EntityFramework.Core in the Startup.ConfigureServices method.

```
  services.AddDbContext&lt;ApplicationDbContext&gt;(options =&gt;
  
  options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
  
  services.AddIdentity&lt;ApplicationUser, IdentityRole&gt;()
  
  .AddEntityFrameworkStores&lt;ApplicationDbContext&gt;()
  
  .AddDefaultTokenProviders();
```

Once ASP.NET Core Identity is configured, you enable it by calling app.UseIdentity in the service’s Startup.Configure method.

Using ASP.NET Code Identity enables several scenarios:

-   Create new user information using the UserManager type (userManager.CreateAsync).

-   Authenticate users using the SignInManager type. You can use signInManager.SignInAsync to sign in directly, or signInManager.PasswordSignInAsync to confirm the user’s password is correct and then sign them in.

-   Identify a user based on information stored in a cookie (which is read by ASP.NET Core Identity middleware) so that subsequent requests from a browser will include a signed-in user’s identity and claims.

ASP.NET Core Identity also supports [two-factor authentication](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/2fa).

For authentication scenarios that make use of a local user data store and that persist identity between requests using cookies (as is typical for MVC web applications), ASP.NET Core Identity is a recommended solution.

## Authenticating using external providers

ASP.NET Core also supports using [external authentication providers](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/) to let users log in via [OAuth 2.0](https://www.digitalocean.com/community/tutorials/an-introduction-to-oauth-2) flows. This means that users can log in using existing authentication processes from providers like Microsoft, Google, Facebook, or Twitter and associate those identities with an ASP.NET Core identity in your application.

To use external authentication, you include the appropriate authentication middleware in your application’s HTTP request processing pipeline. This middleware is responsible for handling requests to return URI routes from the authentication provider, capturing identity information, and making it available via the SignInManager.GetExternalLoginInfo method.

Popular external authentication providers and their associated NuGet packages are shown in the following table.

  **Provider**   **Package**
```
  Microsoft      Microsoft.AspNetCore.Authentication.MicrosoftAccount
  Google         Microsoft.AspNetCore.Authentication.Google
  Facebook       Microsoft.AspNetCore.Authentication.Facebook
  Twitter        Microsoft.AspNetCore.Authentication.Twitter

In all cases, the middleware is registered with a call to a registration method similar to app.Use{ExternalProvider}Authentication in Startup.Configure. These registration methods take an options object that contains an application ID and secret information (a password, for instance), as needed by the provider. External authentication providers require the application to be registered (as explained in [ASP.NET Core documentation](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/)) so that they can inform the user what application is requesting access to their identity.

Once the middleware is registered in Startup.Configure, you can prompt users to log in from any controller action. To do this, you create an AuthenticationProperties object that includes the authentication provider’s name and a redirect URL. You then return a Challenge response that passes the AuthenticationProperties object. The following code shows an example of this.

```
  var properties = \_signInManager.ConfigureExternalAuthenticationProperties(provider,
  
  redirectUrl);
  
  return Challenge(properties, provider);
```

The redirectUrl parameter includes the URL that the external provider should redirect to once the user has authenticated. The URL should represent an action that will sign the user in based on external identity information, as in the following simplified example:

```
  // Sign in the user with this external login provider if the user
  
  // already has a login.
  
  var result = await \_signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
  
  if (result.Succeeded)
  
  {
  
  return RedirectToLocal(returnUrl);
  
  }
  
  else
  
  {
  
  ApplicationUser newUser = new ApplicationUser
  
  {
  
  // The user object can be constructed with claims from the
  
  // external authentication provider, combined with information
  
  // supplied by the user after they have authenticated with
  
  // the external provider.
  
  UserName = info.Principal.FindFirstValue(ClaimTypes.Name),
  
  Email = info.Principal.FindFirstValue(ClaimTypes.Email)
  
  };
  
  var identityResult = await \_userManager.CreateAsync(newUser);
  
  if (identityResult.Succeeded)
  
  {
  
  identityResult = await \_userManager.AddLoginAsync(newUser, info);
  
  if (identityResult.Succeeded)
  
  {
  
  await \_signInManager.SignInAsync(newUser, isPersistent: false);
  
  }
  
  return RedirectToLocal(returnUrl);
  
  }
  
  }
```

If you choose the **Individual User Account** authentication option when you create the ASP.NET Code web application project in Visual Studio, all the code necessary to sign in with an external provider is already in the project, as shown in Figure 11-3.

![https://msdnshared.blob.core.windows.net/media/2016/10/new-web-app.png](./media/image3.png){width="4.915095144356956in" height="3.8503094925634294in"}

[[[[[]{#_Toc481090338 .anchor}]{#_Toc480984696 .anchor}]{#_Toc480993193 .anchor}]{#_Toc480368314 .anchor}]{#_Toc480361444 .anchor}**Figure 11-3**. Selecting an option for using external authentication when creating a web application project

In addition to the external authentication providers listed previously, third-party packages are available that provide middleware for using many more external authentication providers. For a list, see the [AspNet.Security.OAuth.Providers](https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers/tree/dev/src) repo on GitHub.

It is also possible, of course, to create your own external authentication middleware.

## Authenticating with bearer tokens

Authenticating with ASP.NET Core Identity (or Identity plus external authentication providers) works well for many web application scenarios in which storing user information in a cookie is appropriate. In other scenarios, though, cookies are not a natural means of persisting and transmitting data.

For example, in an ASP.NET Core Web API that exposes RESTful endpoints that might be accessed by Single Page Applications (SPAs), by native clients, or even by other Web APIs, you typically want to use bearer token authentication instead. These types of applications do not work with cookies, but can easily retrieve a bearer token and include it in the authorization header of subsequent requests. To enable token authentication, ASP.NET Core supports several options for using [OAuth 2.0](https://oauth.net/2/) and [OpenID Connect](http://openid.net/connect/).

### Authenticating with an OpenID Connect or OAuth 2.0 Identity provider

If user information is stored in Azure Active Directory or another identity solution that supports OpenID Connect or OAuth 2.0, you can use the Microsoft.AspNetCore.Authentication.OpenIdConnect package to authenticate using the OpenID Connect workflow. For example, to [authenticate against Azure Active Directory](https://azure.microsoft.com/en-us/resources/samples/active-directory-dotnet-webapp-openidconnect-aspnetcore/), an ASP.NET Core web application can use middleware from that package as shown in the following example:

```
  // Configure the OWIN pipeline to use OpenID Connect auth
  
  app.UseOpenIdConnectAuthentication(new OpenIdConnectOptions
  
  {
  
  ClientId = Configuration\["AzureAD:ClientId"\],
  
  Authority = String.Format(Configuration\["AzureAd:AadInstance"\],
  
  Configuration\["AzureAd:Tenant"\]),
  
  ResponseType = OpenIdConnectResponseType.IdToken,
  
  PostLogoutRedirectUri = Configuration\["AzureAd:PostLogoutRedirectUri"\]
  
  });
```

The configuration values are Azure Active Directory values that are created when your application is [registered as an Azure AD client](https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-authentication-scenarios#basics-of-registering-an-application-in-azure-ad). A single client ID can be shared among multiple microservices in an application if they all need to authenticate users authenticated via Azure Active Directory.

Note that when you use this workflow, the ASP.NET Core Identity middleware is not needed, because all user information storage and authentication is handled by Azure Active Directory.

### Issuing security tokens from an ASP.NET Core service

If you prefer to issue security tokens for local ASP.NET Core Identity users rather than using an external identity provider, you can take advantage of some good third-party libraries.

[IdentityServer4](https://github.com/IdentityServer/IdentityServer4) and [OpenIddict](https://github.com/openiddict/openiddict-core) are OpenID Connect providers that integrate easily with ASP.NET Core Identity to let you issue security tokens from an ASP.NET Core service. The [IdentityServer4 documentation](https://identityserver4.readthedocs.io/en/release/) has in-depth instructions for using the library. However, the basic steps to using IdentityServer4 to issue tokens are as follows.

1.  You call app.UseIdentityServer in the Startup.Configure method to add IdentityServer4 to the application’s HTTP request processing pipeline. This lets the library serve requests to OpenID Connect and OAuth2 endpoints like /connect/token.

2.  You configure IdentityServer4 in Startup.ConfigureServices by making a call to services.AddIdentityServer.

3.  You configure identity server by providing the following data:

-   The [credentials](https://identityserver4.readthedocs.io/en/release/topics/crypto.html) to use for signing.

-   The [Identity and API resources](https://identityserver4.readthedocs.io/en/release/topics/resources.html) that users might request access to:

<!-- -->

-   API resources represent protected data or functionality that a user can access with an access token. An example of an API resource would be a web API (or set of APIs) that requires authorization.

-   Identity resources represent information (claims) that are given to a client to identify a user. The claims might include the user name, email address, and so on.

<!-- -->

-   The [clients](https://identityserver4.readthedocs.io/en/release/configuration/clients.html) that will be connecting in order to request tokens.

-   The storage mechanism for user information, such as [ASP.NET Core Identity](https://identityserver4.readthedocs.io/en/release/quickstarts/6_aspnet_identity.html) or an alternative.

When you specify clients and resources for IdentityServer4 to use, you can pass an IEnumerable&lt;T&gt; collection of the appropriate type to methods that take in-memory client or resource stores. Or for more complex scenarios, you can provide client or resource provider types via Dependency Injection.

A sample configuration for IdentityServer4 to use in-memory resources and clients provided by a custom IClientStore type might look like the following example:

```
  // Add IdentityServer services
  
  services.AddSingleton&lt;IClientStore, CustomClientStore&gt;();
  
  services.AddIdentityServer()
  
  .AddSigningCredential("CN=sts")
  
  .AddInMemoryApiResources(MyApiResourceProvider.GetAllResources())
  
  .AddAspNetIdentity&lt;ApplicationUser&gt;();
```

### Consuming security tokens

Authenticating against an OpenID Connect endpoint or issuing your own security tokens covers some scenarios. But what about a service that simply needs to limit access to those users who have valid security tokens that were provided by a different service?

For that scenario, authentication middleware that handles JWT tokens is available in the Microsoft.AspNetCore.Authentication.JwtBearer package. JWT stands for "[JSON Web Token](https://tools.ietf.org/html/rfc7519)" and is a common security token format (defined by RFC 7519) for communicating security claims. A simple example of how to use middleware to consume such tokens might look like the following example. This code must precede calls to ASP.NET Core MVC middleware (app.UseMvc).

```
  app.UseJwtBearerAuthentication(new JwtBearerOptions()
  
  {
  
  Audience = "http://localhost:5001/",
  
  Authority = "http://localhost:5000/",
  
  AutomaticAuthenticate = true
  
  });
```

The parameters in this usage are:

-   Audience represents the receiver of the incoming token or the resource that the token grants access to. If the value specified in this parameter does not match the aud parameter in the token, the token will be rejected.

-   Authority is the address of the token-issuing authentication server. The JWT bearer authentication middleware uses this URI to get the public key that can be used to validate the token's signature. The middleware also confirms that the iss parameter in the token matches this URI.

-   AutomaticAuthenticate is a Boolean value that indicates whether the user defined by the token should be automatically signed in.

Another parameter, RequireHttpsMetadata, is not used in this example. It is useful for testing purposes; you set this parameter to false so that you can test in environments where you do not have certificates. In real-world deployments, JWT bearer tokens should always be passed only over HTTPS.

With this middleware in place, JWT tokens are automatically extracted from authorization headers. They are then deserialized, validated (using the values in the Audience and Authority parameters), and stored as user information to be referenced later by MVC actions or authorization filters.

The JWT bearer authentication middleware can also support more advanced scenarios, such as using a local certificate to validate a token if the authority is not available. For this scenario, you can specify a TokenValidationParameters object in the JwtBearerOptions object.

### Additional resources

-   **Sharing cookies between applications**\
    [*https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/compatibility/cookie-sharing\#sharing-authentication-cookies-between-applications*](https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/compatibility/cookie-sharing#sharing-authentication-cookies-between-applications)

-   **Introduction to Identity**\
    [*https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity*](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity)

-   **Rick Anderson. Two-factor authentication with SMS**\
    [*https://docs.microsoft.com/en-us/aspnet/core/security/authentication/2fa*](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/2fa)

-   **Enabling authentication using Facebook, Google and other external providers**\
    [*https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/*](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/)

-   **Michell Anicas. An Introduction to OAuth 2**\
    [*https://www.digitalocean.com/community/tutorials/an-introduction-to-oauth-2*](https://www.digitalocean.com/community/tutorials/an-introduction-to-oauth-2)

-   **AspNet.Security.OAuth.Providers** (GitHub repo for ASP.NET OAuth providers.\
    [*https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers/tree/dev/src*](https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers/tree/dev/src)

-   **Danny Strockis. Integrating Azure AD into an ASP.NET Core web app**\
    [*https://azure.microsoft.com/en-us/resources/samples/active-directory-dotnet-webapp-openidconnect-aspnetcore/*](https://azure.microsoft.com/en-us/resources/samples/active-directory-dotnet-webapp-openidconnect-aspnetcore/)

-   **IdentityServer4. Official documentation**\
    [*https://identityserver4.readthedocs.io/en/release/*](https://identityserver4.readthedocs.io/en/release/)

# About authorization in .NET microservices and web applications

After authentication, ASP.NET Core Web APIs need to authorize access. This process allows a service to make APIs available to some authenticated users, but not to all. [Authorization](https://docs.microsoft.com/en-us/aspnet/core/security/authorization/introduction) can be done based on users’ roles or based on custom policy, which might include inspecting claims or other heuristics.

Restricting access to an ASP.NET Core MVC route is as easy as applying an Authorize attribute to the action method (or to the controller’s class if all the controller’s actions require authorization), as shown in following example:

```
  public class AccountController : Controller
  
  {
  
  public ActionResult Login()
  
  {
  
  }
  
  **\[Authorize\]**
  
  public ActionResult Logout()
  
  {
  
  }
```

By default, adding an Authorize attribute without parameters will limit access to authenticated users for that controller or action. To further restrict an API to be available for only specific users, the attribute can be expanded to specify required roles or policies that users must satisfy.

## Implementing role-based authorization

ASP.NET Core Identity has a built-in concept of roles. In addition to users, ASP.NET Core Identity stores information about different roles used by the application and keeps track of which users are assigned to which roles. These assignments can be changed programmatically with the RoleManager type (which updates roles in persisted storage) and UserManager type (which can assign or unassign users from roles).

If you are authenticating with JWT bearer tokens, the ASP.NET Core JWT bearer authentication middleware will populate a user’s roles based on role claims found in the token. To limit access to an MVC action or controller to users in specific roles, you can include a Roles parameter in the Authorize header, as shown in the following example:

```
  **\[Authorize(Roles = "Administrator, PowerUser")\]**
  
  public class ControlPanelController : Controller
  
  {
  
  public ActionResult SetTime()
  
  {
  
  }
  
  **\[Authorize(Roles = "Administrator")\]**
  
  public ActionResult ShutDown()
  
  {
  
  }
  
  }
```

In this example, only users in the Administrator or PowerUser roles can access APIs in the ControlPanel controller (such as executing the SetTime action). The ShutDown API is further restricted to allow access only to users in the Administrator role.

To require a user be in multiple roles, you use multiple Authorize attributes, as shown in the following example:

```
  **\[Authorize(Roles = "Administrator, PowerUser")\]**
  
  **\[Authorize(Roles = "RemoteEmployee ")\]**
  
  **\[Authorize(Policy = "CustomPolicy")\]**
  
  public ActionResult API1 ()
  
  {
  
  }
```

In this example, to call API1, a user must:

-   Be in the Adminstrator *or* PowerUser role, *and*

-   Be in the RemoteEmployee role, *and*

-   Satisfy a custom handler for CustomPolicy authorization.

## Implementing policy-based authorization

Custom authorization rules can also be written using [authorization policies](https://docs.asp.net/en/latest/security/authorization/policies.html). In this section we provide an overview. More detail is available in the online [ASP.NET Authorization Workshop](https://github.com/blowdart/AspNetAuthorizationWorkshop).

Custom authorization policies are registered in the Startup.ConfigureServices method using the service.AddAuthorization method. This method takes a delegate that configures an AuthorizationOptions argument.

```
  services.AddAuthorization(options =&gt;
  
  {
  
  options.AddPolicy("AdministratorsOnly", policy =&gt;
  
  policy.RequireRole("Administrator"));
  
  options.AddPolicy("EmployeesOnly", policy =&gt;
  
  policy.RequireClaim("EmployeeNumber"));
  
  options.AddPolicy("Over21", policy =&gt;
  
  policy.Requirements.Add(new MinimumAgeRequirement(21)));
  
  });
```

As shown in the example, policies can be associated with different types of requirements. After the policies are registered, they can be applied to an action or controller by passing the policy’s name as the Policy argument of the Authorize attribute (for example, \[Authorize(Policy="EmployeesOnly")\]) Policies can have multiple requirements, not just one (as shown in these examples).

In the previous example, the first AddPolicy call is just an alternative way of authorizing by role. If \[Authorize(Policy="AdministratorsOnly")\] is applied to an API, only users in the Administrator role will be able to access it.

The second AddPolicy call demonstrates an easy way to require that a particular claim should be present for the user. The RequireClaim method also optionally takes expected values for the claim. If values are specified, the requirement is met only if the user has both a claim of the correct type and one of the specified values. If you are using the JWT bearer authentication middleware, all JWT properties will be available as user claims.

The most interesting policy shown here is in the third AddPolicy method, because it uses a custom authorization requirement. By using custom authorization requirements, you can have a great deal of control over how authorization is performed. For this to work, you must implement these types:

-   A Requirements type that derives from IAuthorizationRequirement and that contains fields specifying the details of the requirement. In the example, this is an age field for the sample MinimumAgeRequirement type.

-   A handler that implements AuthorizationHandler&lt;T&gt;, where T is the type of IAuthorizationRequirement that the handler can satisfy. The handler must implement the HandleRequirementAsync method, which checks whether a specified context that contains information about the user satisfies the requirement.

If the user meets the requirement, a call to context.Succeed will indicate that the user is authorized. If there are multiple ways that a user might satisfy an authorization requirement, multiple handlers can be created.

In addition to registering custom policy requirements with AddPolicy calls, you also need to register custom requirement handlers via Dependency Injection (services.AddTransient&lt;IAuthorizationHandler, MinimumAgeHandler&gt;()).

An example of a custom authorization requirement and handler for checking a user’s age (based on a DateOfBirth claim) is available in the ASP.NET Core [authorization documentation](https://docs.asp.net/en/latest/security/authorization/policies.html).

### Additional resources

-   **ASP.NET Core Authentication**\
    [*https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity*](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity)

-   **ASP.NET Core Authorization**\
    [*https://docs.microsoft.com/en-us/aspnet/core/security/authorization/introduction*](https://docs.microsoft.com/en-us/aspnet/core/security/authorization/introduction)

-   **Role based Authorization**\
    [*https://docs.microsoft.com/en-us/aspnet/core/security/authorization/roles*](https://docs.microsoft.com/en-us/aspnet/core/security/authorization/roles)

-   **Custom Policy-Based Authorization**\
    [*https://docs.microsoft.com/en-us/aspnet/core/security/authorization/policies*](https://docs.microsoft.com/en-us/aspnet/core/security/authorization/policies)

[[[[[[[[[[[[[[[]{#_Toc481772662 .anchor}]{#_Toc481767905 .anchor}]{#_Toc481764329 .anchor}]{#_Toc481762962 .anchor}]{#_Toc481693900 .anchor}]{#_Toc481597881 .anchor}]{#_Toc481506754 .anchor}]{#_Toc481506322 .anchor}]{#_Toc481492129 .anchor}]{#_Toc481490305 .anchor}]{#_Toc481090343 .anchor}]{#_Toc480984701 .anchor}]{#_Toc480993198 .anchor}]{#_Toc480368319 .anchor}]{#_Toc480361449 .anchor}

# Storing application secrets safely during development

To connect with protected resources and other services, ASP.NET Core applications typically need to use connection strings, passwords, or other credentials that contain sensitive information. These sensitive pieces of information are called *secrets*. It is a best practice to not include secrets in source code and certainly not to store secrets in source control. Instead, you should use the ASP.NET Core configuration model to read the secrets from more secure locations.

You should separate the secrets for accessing development and staging resources from those used for accessing production resources, because different individuals will need access to those different sets of secrets. To store secrets used during development, common approaches are to either store secrets in environment variables or by using the ASP.NET Core Secret Manager tool. For more secure storage in production environments, microservices can store secrets in an Azure Key Vault.

## Storing secrets in environment variables

One way to keep secrets out of source code is for developers to set string-based secrets as [environment variables](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets#environment-variables) on their development machines. When you use environment variables to store secrets with hierarchical names (those nested in configuration sections), create a name for the environment variables that includes the full hierarchy of the secret’s name, delimited with colons (:).

For example, setting an environment variable Logging:LogLevel:Default to Debug would be equivalent to a configuration value from the following JSON file:

```
  {
  
  "Logging": {
  
  "LogLevel": {
  
  "Default": "Debug"
  
  }
  
  }
  
  }
```

To access these values from environment variables, the application just needs to call AddEnvironmentVariables on its ConfigurationBuilder when constructing an IConfigurationRoot object.

Note that environment variables are generally stored as plain text, so if the machine or process with the environment variables is compromised, the environment variable values will be visible.

## Storing secrets using the ASP.NET Core Secret Manager

The ASP.NET Core [Secret Manager](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets#secret-manager) tool provides another method of keeping secrets out of source code. To use the Secret Manager tool, include a tools reference (DotNetCliToolReference) to the Microsoft.Extensions.SecretManager.Tools package in your project file. Once that dependency is present and has been restored, the dotnet user-secrets command can be used to set the value of secrets from the command line. These secrets will be stored in a JSON file in the user’s profile directory (details vary by OS), away from source code.

Secrets set by the Secret Manager tool are organized by the UserSecretsId property of the project that is using the secrets. Therefore, you must be sure to set the UserSecretsId property in your project file (as shown in the snippet below). The actual string used as the ID is not important as long as it is unique in the project.

```
  &lt;PropertyGroup&gt;
  
  &lt;UserSecretsId&gt;UniqueIdentifyingString&lt;/UserSecretsId&gt;
  
  &lt;/PropertyGroup&gt;
```

Using secrets stored with Secret Manager in an application is accomplished by calling AddUserSecrets&lt;T&gt; on the ConfigurationBuilder instance to include secrets for the application in its configuration. The generic parameter T should be a type from the assembly that the UserSecretId was applied to. Usually using AddUserSecrets&lt;Startup&gt; is fine.

# Using Azure Key Vault to protect secrets at production time

Secrets stored as environment variables or stored by the Secret Manager tool are still stored locally and unencrypted on the machine. A more secure option for storing secrets is [Azure Key Vault](https://azure.microsoft.com/en-us/services/key-vault/), which provides a secure, central location for storing keys and secrets.

The Microsoft.Extensions.Configuration.AzureKeyVault package allows an ASP.NET Core application to read configuration information from Azure Key Vault. To start using secrets from an Azure Key Vault, you follow these steps:

1.  Register your application as an Azure AD application. (Access to key vaults is managed by Azure AD.) This can be done through the Azure management portal.

Alternatively, if you want your application to authenticate using a certificate instead of a password or client secret, you can use the [New-AzureRmADApplication](https://docs.microsoft.com/en-us/powershell/resourcemanager/azurerm.resources/v3.3.0/new-azurermadapplication) PowerShell cmdlet. The certificate that you register with Azure Key Vault needs only your public key. (Your application will use the private key.)

1.  Give the registered application access to the key vault by creating a new service principal. You can do this using the following PowerShell commands:

\$sp = New-AzureRmADServicePrincipal -ApplicationId "&lt;Application ID guid&gt;"

Set-AzureRmKeyVaultAccessPolicy -VaultName "&lt;VaultName&gt;" -ServicePrincipalName \$sp.ServicePrincipalNames\[0\] -PermissionsToSecrets all -ResourceGroupName "&lt;KeyVault Resource Group&gt;"

1.  Include the key vault as a configuration source in your application by calling the IConfigurationBuilder.AddAzureKeyVault extension method when you create an IConfigurationRoot instance. Note that calling AddAzureKeyVault will require the application ID that was registered and given access to the key vault in the previous steps.

Currently, the .NET Standard Library and.NET Core support getting configuration information from an Azure Key Vault using a client ID and client secret. .NET Framework applications can use an overload of IConfigurationBuilder.AddAzureKeyVault that takes a certificate in place of the client secret. As of this writing, work is [in progress](https://github.com/aspnet/Configuration/issues/605) to make that overload available in .NET Standard and .NET Core. Until the AddAzureKeyVault overload that accepts a certificate is available, ASP.NET Core applications can access an Azure Key Vault with certificate-based authentication by explicitly creating a KeyVaultClient object, as shown in the following example:

```
  // Configure Key Vault client
  
  var kvClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(async
  
  (authority, resource, scope) =&gt;
  
  {
  
  var cert = // Get certificate from local store/file/key vault etc. as needed
  
  // From the Microsoft.IdentityModel.Clients.ActiveDirectory pacakge
  
  var authContext = new AuthenticationContext(authority,
  
  TokenCache.DefaultShared);
  
  var result = await authContext.AcquireTokenAsync(resource,
  
  // From the Microsoft.Rest.ClientRuntime.Azure.Authentication pacakge
  
  new ClientAssertionCertificate("{Application ID}", cert));
  
  return result.AccessToken;
  
  }));
  
  // Get configuration values from Key Vault
  
  var builder = new ConfigurationBuilder()
  
  .SetBasePath(env.ContentRootPath)
  
  // Other configuration providers go here.
  
  .AddAzureKeyVault("{KeyValueUri}", kvClient,
  
  new DefaultKeyVaultSecretManager());
```

In this example, the call to AddAzureKeyVault comes at the end of configuration provider registration. It is a best practice to register Azure Key Vault as the last configuration provider so that it has an opportunity to override configuration values from previous providers, and so that no configuration values from other sources override those from the key vault.

### Additional resources

-   **Using Azure Key Vault to protect application secrets***\
    <https://docs.microsoft.com/en-us/azure/guidance/guidance-multitenant-identity-keyvault>*

-   **Safe storage of app secrets during development**\
    [*https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets*](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets)

-   **Configuring data protection**\
    [*https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/configuration/overview*](https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/configuration/overview)

-   **Key management and lifetime**\
    [*https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/configuration/default-settings\#data-protection-default-settings*](https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/configuration/default-settings#data-protection-default-settings)

-   **Microsoft.Extensions.Configuration.DockerSecrets.** GitHub repo.\
    *<https://github.com/aspnet/Configuration/tree/dev/src/Microsoft.Extensions.Configuration.DockerSecrets> *

>[!div class="step-by-step"]
[Previous] (../implementing-resilient-applications/health-monitoring.md)
[Next] (../key-takeaways/index.md)

---
title: GitHub Copilot modernization scenarios and skills
description: "Complete reference of all scenarios and built-in upgrade skills available in GitHub Copilot modernization for .NET, organized by domain."
ms.topic: reference
ms.date: 04/06/2026
ai-usage: ai-assisted

#customer intent: As a developer, I want to see all the scenarios and skills that GitHub Copilot modernization supports so that I can understand which upgrade tasks the agent can handle for me.

---

# Scenarios and skills reference

GitHub Copilot modernization for .NET helps you modernize through _scenarios_ and _skills_:

- **Scenarios** are end-to-end managed workflows for major upgrade goals, such as upgrading from .NET Framework to .NET 10. Scenarios coordinate the full lifecycle: assessment, planning, and task-by-task execution.
- **Skills** are focused capabilities for specific upgrade tasks, such as converting EF6 to EF Core or replacing WCF with CoreWCF. Skills activate automatically when the agent encounters relevant code during an upgrade.

The agent supports both C# and Visual Basic projects.

> [!TIP]
> You don't need to memorize names. Describe what you want (_"upgrade to .NET 10"_, _"upgrade my EF6 code"_, _"replace Newtonsoft.Json"_) and the agent loads the right scenario and skills automatically. You can also ask: _"What can you help me with?"_

## Scenarios

Scenarios are the agent's top-level upgrade workflows. When you start a conversation, the agent identifies the best scenario for your goal and walks you through it step by step.

| Scenario | What it does | Example prompt |
|---|---|---|
| [**.NET version upgrade**](#net-version-upgrade) | Upgrades projects from any older .NET version to .NET 8 or later. | _"Upgrade my solution to .NET 10"_ |
| [**SDK-style conversion**](#sdk-style-conversion) | Converts legacy project files to modern SDK-style format. | _"Convert my projects to SDK-style"_ |
| [**Newtonsoft.Json upgrade**](#newtonsoftjson-upgrade) | Replaces Newtonsoft.Json with System.Text.Json across a solution. | _"Upgrade from Newtonsoft.Json"_ |
| [**SqlClient upgrade**](#sqlclient-upgrade) | Upgrades System.Data.SqlClient to Microsoft.Data.SqlClient. | _"Update SqlClient to the modern package"_ |
| [**Azure Functions upgrade**](#azure-functions-upgrade) | Upgrades Azure Functions from in-process to isolated worker model. | _"Upgrade my Azure Functions"_ |
| [**Semantic Kernel to Agents**](#semantic-kernel-to-microsoft-agent-framework) | Upgrades from SK Agents to Microsoft Agent Framework. | _"Upgrade my SK agents"_ |

For an end-to-end walkthrough, see [Core concepts](concepts.md).

### .NET version upgrade

The most common scenario. Upgrades your projects from any older .NET variant to the latest:

| Source                       | Target          |
|------------------------------|-----------------|
| .NET Framework (any version) | .NET 8 or later |
| .NET Core 1.x–3.x            | .NET 8 or later |
| .NET 5 or later              | .NET 8 or later |

The agent analyzes your dependency graph, checks NuGet compatibility, identifies breaking changes, and creates a task plan using the best strategy for your solution (bottom-up, top-down, or all-at-once). If your projects need format conversions, the agent handles them automatically as part of the upgrade.

### SDK-style conversion

Converts legacy `.csproj` and `.vbproj` files to the modern SDK-style format without changing target frameworks. The agent handles the conversion automatically during version upgrades. Run this scenario independently if needed.

### Newtonsoft.Json upgrade

Replaces `Newtonsoft.Json` with `System.Text.Json` across your solution. Handles custom converters, `[JsonProperty]` attributes, `JObject`/`JArray` usage, and serialization settings.

### SqlClient upgrade

Upgrades from `System.Data.SqlClient` to `Microsoft.Data.SqlClient`. Handles the `Encrypt=true` default behavior change and connection string differences.

### Azure Functions upgrade

Upgrades Azure Functions from the in-process hosting model to the isolated worker model with `Program.cs` and `HostApplicationBuilder`. Includes Application Insights upgrade.

### Semantic Kernel to Microsoft Agent Framework

Upgrades from Semantic Kernel Agents (`ChatCompletionAgent`, `OpenAIAssistantAgent`) to [Microsoft Agent Framework](/agent-framework/overview/). Updates packages and API patterns.  

## Upgrade skills: common

General-purpose upgrade skills that apply across project types.

| Skill | What it does |
|---|---|
| **Converting to SDK-style** | Converts legacy project files to modern SDK-style format. Uses topological ordering for multi-project solutions. |
| **Upgrading Autofac to .NET DI** | Removes Autofac entirely and upgrades all registrations to built-in ASP.NET Core dependency injection. |
| **Integrating Autofac with .NET** | Keeps Autofac as the DI container but modernizes its ASP.NET Core integration. |
| **Upgrading cryptography namespaces** | Fixes the `System.Security.Cryptography` namespace split for types like `X509Certificate2` and `SignedCms`. |
| **Upgrading Newtonsoft to System.Text.Json** | Full upgrade from `Newtonsoft.Json`. Handles converters, attributes, dynamic types, and settings. |
| **Upgrading Semantic Kernel to Agents** | Upgrades Semantic Kernel agent APIs to the Microsoft Agents AI Framework. |
| **Upgrading to MSMQ.Messaging** | Upgrades from `System.Messaging` (.NET Framework only) to `MSMQ.Messaging` for .NET Core. |
| **Converting to Central Package Management** | Converts per-project NuGet package versioning to centralized package management using `Directory.Packages.props`. |
| **Modernizing C# version** | Upgrades C# code to use newer language features (C# 7.0 through 15). Batches mechanical changes through `dotnet format` and uses LLM judgment for semantic transformations. |
| **Upgrading C# nullable references** | Enables nullable reference types and systematically resolves all CS86xx warnings. Covers rollout strategies, annotation guidance, and framework-specific considerations. |

## Upgrade skills: data access

Skills for upgrading data access layers, including Entity Framework, LINQ to SQL, and SQL client libraries.

| Skill | What it does |
|---|---|
| **Upgrading EDMX to Code-First** | Converts EF6 Database-First (`.edmx`) models to EF Core Code-First. Scaffolds entities from the database. |
| **Upgrading EF DbContext** | Registers `DbContext` in ASP.NET Core dependency injection. Handles both EF6 to EF Core and existing EF Core patterns. |
| **Upgrading EF6 Code-First to EF Core** | Upgrades EF6 Code-First to EF Core. Swaps packages, updates namespaces, and replaces `EntityTypeConfiguration` and `DbModelBuilder`. |
| **Upgrading to Microsoft.Data.SqlClient** | Upgrades from `System.Data.SqlClient`. Handles the `Encrypt=true` default change and connection string differences. |

## Upgrade skills: web and ASP.NET

Skills for upgrading ASP.NET Framework applications to ASP.NET Core.

### ASP.NET Framework upgrade

| Skill | What it does |
|---|---|
| **Upgrading ASP.NET Framework to Core** | Comprehensive upgrade from ASP.NET Framework (MVC/WebAPI) to ASP.NET Core, including controllers, views, middleware, authentication, and configuration. |
| **Upgrading ASP.NET Identity** | Upgrades ASP.NET MVC Identity to ASP.NET Core Identity, including `IdentityDbContext`, `UserManager`, `SignInManager`, and auth middleware. |
| **Upgrading Global.asax** | Converts `Global.asax` lifecycle events (`Application_Start`, `Application_Error`) to ASP.NET Core `Program.cs` and middleware. |
| **Upgrading OWIN to middleware** | Replaces OWIN/Katana middleware (`IAppBuilder`, `OwinMiddleware`) with ASP.NET Core equivalents. |
| **Upgrading OWIN Cookie Authentication** | Upgrades OWIN cookie authentication middleware to ASP.NET Core cookie authentication. |
| **Upgrading OWIN OAuth to JWT** | Upgrades OWIN OAuth bearer token authentication to ASP.NET Core JWT bearer authentication. |
| **Upgrading OWIN OpenID Connect** | Upgrades OWIN OpenID Connect middleware to ASP.NET Core OpenID Connect authentication. |

### MVC features

| Skill | What it does |
|---|---|
| **Upgrading MVC authentication** | Upgrades ASP.NET MVC authentication to ASP.NET Core Identity and authentication middleware. |
| **Upgrading MVC bundling** | Converts `System.Web.Optimization` bundling to direct `<script>`/`<link>` tags or modern bundlers. |
| **Upgrading MVC configuration** | Upgrades `web.config` and `app.config` settings to the ASP.NET Core configuration system (`appsettings.json`, environment variables). |
| **Upgrading MVC content negotiation** | Upgrades content negotiation patterns and formatters to ASP.NET Core. |
| **Upgrading MVC controllers** | Upgrades MVC and WebAPI controllers to ASP.NET Core controller patterns. |
| **Upgrading MVC dependency injection** | Upgrades DI container registrations to ASP.NET Core's built-in dependency injection. |
| **Upgrading MVC filters** | Converts global MVC filters (`FilterConfig`, `GlobalFilters`) to ASP.NET Core middleware and filter pipeline. |
| **Upgrading MVC HTTP pipeline** | Upgrades HTTP modules and handlers to ASP.NET Core middleware. |
| **Upgrading MVC HttpContext** | Upgrades `System.Web.HttpContext` usage to ASP.NET Core `HttpContext`. |
| **Upgrading MVC logging** | Upgrades logging to `Microsoft.Extensions.Logging`. |
| **Upgrading MVC model binding** | Upgrades model binding patterns to ASP.NET Core model binding. |
| **Upgrading MVC Razor views** | Upgrades Razor views, layouts, and view components to ASP.NET Core Razor. |
| **Upgrading MVC routing** | Converts `RouteCollection` routing to ASP.NET Core endpoint routing (`MapControllerRoute`, attribute routing). |
| **Upgrading MVC session state** | Upgrades session state to ASP.NET Core distributed session. |
| **Upgrading MVC static files** | Upgrades static file handling to ASP.NET Core's static files middleware. |
| **Upgrading MVC System.Web adapters** | Uses System.Web adapters for incremental upgrade from ASP.NET Framework to ASP.NET Core. |
| **Upgrading MVC validation** | Upgrades validation attributes and patterns to ASP.NET Core validation. |

### WCF

| Skill | What it does |
|---|---|
| **Upgrading WCF to CoreWCF** | Upgrades server-side WCF services to [CoreWCF](https://github.com/CoreWCF/CoreWCF) for .NET 6+. Converts hosting, bindings, behavior extensions, and async contracts. |

## Upgrade skills: cloud and Azure

| Skill | What it does |
|---|---|
| **Upgrading Azure Functions Startup** | Upgrades Azure Functions from the in-process `Startup` class to isolated worker model with `Program.cs`. |
| **Upgrading Azure Functions to v2** | Upgrades Azure Functions to the v2 hosting pattern using `IHostApplicationBuilder`. |
| **Upgrading Azure Key Vault** | Upgrades legacy Azure Key Vault SDK to the modern `Azure.Security.KeyVault` libraries. |
| **Upgrading Azure Service Bus** | Upgrades legacy Azure Service Bus SDK to the modern `Azure.Messaging.ServiceBus` library. |
| **Upgrading Azure Storage** | Upgrades legacy Azure Storage SDK to the modern `Azure.Storage` libraries. |

## Upgrade skills: libraries

| Skill | What it does |
|---|---|
| **Upgrading ADAL to MSAL** | Upgrades Azure Active Directory Authentication Library (ADAL) to Microsoft Authentication Library (MSAL). |
| **Upgrading ASP.NET SignalR** | Upgrades ASP.NET SignalR to ASP.NET Core SignalR. |
| **Upgrading Bond interfaces** | Upgrades Microsoft Bond serialization to modern alternatives. |
| **Upgrading Data EDM to OData** | Upgrades `Data.Edm` types to OData libraries. |
| **Upgrading Data OData to OData Core** | Upgrades `Microsoft.Data.OData` to `Microsoft.OData.Core`. |
| **Upgrading Data Services client** | Upgrades WCF Data Services client to the modern OData client. |
| **Upgrading PowerShell SDK** | Upgrades PowerShell modules from Windows PowerShell 5.1 to PowerShell 7+ with the `Microsoft.PowerShell.SDK` package. |
| **Upgrading SPA Services to SPA Proxy** | Upgrades `Microsoft.AspNetCore.SpaServices` to the SPA Proxy hosting model. |
| **Upgrading System.Spatial** | Upgrades `Microsoft.Spatial` and `System.Spatial` to modern spatial alternatives. |
| **Upgrading WebAPI CORS** | Upgrades `System.Web.Http.Cors` to ASP.NET Core CORS middleware. |
| **Upgrading WebAPI OData** | Upgrades WebAPI OData to ASP.NET Core OData. |

## When skills activate

The agent loads skills progressively as your upgrade session unfolds:

| When | What happens |
|---|---|
| **Session start** | The agent loads the matching scenario and any skills that are immediately relevant to your codebase. |
| **During execution** | As the agent works through tasks, it loads extra specialized skills on demand when it encounters specific upgrade patterns, such as EDMX files, WCF services, or OWIN middleware. |
| **On request** | You can ask the agent to use any skill at any time. For example, _"help me upgrade WCF to CoreWCF"_ or _"use the EF6 upgrade skill."_ |

You don't need to manage skill loading. The agent handles it automatically. Just describe what you need.

## Create your own skills

Create custom skills to teach the agent patterns specific to your codebase, such as internal framework upgrades, coding conventions, or custom upgrade workflows.

Place skills in your repository (`.github/skills/`) or user profile (`%UserProfile%/.copilot/skills/`), and the agent picks them up automatically.

For more information about creating custom skills, see [Apply custom upgrade instructions](how-to-custom-upgrade-instructions.md).

## Related content

- [What is GitHub Copilot modernization?](overview.md)
- [Core concepts](concepts.md)
- [Upgrade a .NET app with GitHub Copilot modernization](how-to-upgrade-with-github-copilot.md)
- [Apply custom upgrade instructions](how-to-custom-upgrade-instructions.md)

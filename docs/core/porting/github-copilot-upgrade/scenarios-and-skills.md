---
title: GitHub Copilot upgrade scenarios and skills
description: "Complete reference of all scenarios and built-in upgrade skills available in GitHub Copilot upgrade for .NET, organized by domain."
ms.topic: reference
ms.date: 08/13/2026
ai-usage: ai-assisted

#customer intent: As a developer, I want to see all the scenarios and skills that GitHub Copilot upgrade supports so that I can understand which upgrade tasks the agent can handle for me.

---

# Scenarios and skills reference

GitHub Copilot upgrade for .NET helps you upgrade and modernize through _scenarios_ and _skills_:

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
| [**.NET Framework version upgrade**](#net-framework-version-upgrade) | Upgrades .NET Framework projects to .NET Framework 4.8.1, without moving to modern .NET. | _"Upgrade to .NET Framework 4.8.1"_ |
| [**SDK-style conversion**](#sdk-style-conversion) | Converts legacy project files to modern SDK-style format. | _"Convert my projects to SDK-style"_ |
| [**Visual Studio extension SDK-style conversion**](#visual-studio-extension-sdk-style-conversion) | Converts VSIX/VSSDK extension projects to SDK-style format. | _"Convert my VSIX project to SDK-style"_ |
| [**NuGet package upgrade**](#nuget-package-upgrade) | Upgrades specific NuGet packages and fixes the resulting breaking changes. | _"Upgrade Serilog to the latest version"_ |
| [**Newtonsoft.Json upgrade**](#newtonsoftjson-upgrade) | Replaces Newtonsoft.Json with System.Text.Json across a solution. | _"Upgrade from Newtonsoft.Json"_ |
| [**SqlClient upgrade**](#sqlclient-upgrade) | Upgrades System.Data.SqlClient to Microsoft.Data.SqlClient. | _"Update SqlClient to the modern package"_ |
| [**Azure Functions upgrade**](#azure-functions-upgrade) | Upgrades Azure Functions from in-process to isolated worker model. | _"Upgrade my Azure Functions"_ |
| [**Azure migration**](#azure-migration) | Starts an app modernization session to move an application to Azure services. | _"Migrate my app to Azure"_ |
| [**ARM64 migration**](#arm64-migration) | Adds ARM64 support so your app runs on Apple Silicon, Windows on ARM, and cloud ARM64 hardware. | _"Make my app run on ARM64"_ |
| [**Semantic Kernel to Agents**](#semantic-kernel-to-microsoft-agent-framework) | Upgrades from SK Agents to Microsoft Agent Framework. | _"Upgrade my SK agents"_ |
| [**Aspire integration**](#aspire-integration) | Adds [Aspire](https://aspire.dev) support for inner-loop and Azure deployment. | _"Add Aspire to my app"_ |
| [**Aspire version upgrade**](#aspire-version-upgrade) | Upgrades existing Aspire applications to newer versions. | _"Upgrade my Aspire version"_ |
| [**WebForms-to-Blazor upgrade**](#webforms-to-blazor-upgrade) | Upgrades ASP.NET Web Forms applications to Blazor Server. | _"Upgrade my Web Forms app to Blazor"_ |
| [**WinForms feature adoption**](#winforms-feature-adoption) | Adopts modern Windows Forms features such as dark mode, async APIs, and MVVM. | _"Add dark mode to my WinForms app"_ |

For an end-to-end walkthrough, see [Core concepts](concepts.md).

### .NET version upgrade

The most common scenario. Upgrades your projects from any older .NET variant to the latest:

[!INCLUDE[supported-upgrade-paths](./includes/supported-upgrade-paths.md)]

The agent analyzes your dependency graph, checks NuGet compatibility, identifies breaking changes, and creates a task plan using the best strategy for your solution (bottom-up, top-down, or all-at-once). If your projects need format conversions, the agent handles them automatically as part of the upgrade. To help you pick an appropriate target, the agent also explains release status and support lifecycle (LTS versus STS).

When the upgrade finishes, the agent can generate a report and suggest follow-on work, such as Aspire integration, an EF6-to-EF Core upgrade, WinForms feature adoption, or ARM64 migration.

### .NET Framework version upgrade

Upgrades .NET Framework projects to .NET Framework 4.8.1 (`net481`) and keeps them on full .NET Framework. Choose this scenario when you want the latest .NET Framework version but aren't ready to move to modern .NET. The agent preserves your existing project format, legacy or SDK-style, unless you explicitly ask for SDK-style conversion.

### SDK-style conversion

Converts legacy `.csproj`, `.vbproj`, and `.fsproj` files to the modern SDK-style format without changing target frameworks. The agent handles the conversion automatically during version upgrades. Run this scenario independently if needed.

### Visual Studio extension SDK-style conversion

Converts Visual Studio extension (VSIX/VSSDK) projects from the legacy project format to SDK-style. The agent handles VSSDK-specific concerns, including package references, the VSIX manifest, VSCT command tables, project capabilities, and the solution deploy markers that F5 debugging depends on.

### NuGet package upgrade

Upgrades one or more NuGet packages to a target version, or to the latest supported version, across a project, folder, solution, or the whole repository. The agent detects breaking API changes introduced by the new version and fixes the affected code.

### Newtonsoft.Json upgrade

Replaces `Newtonsoft.Json` with `System.Text.Json` across your solution. Handles custom converters, `[JsonProperty]` attributes, `JObject`/`JArray` usage, and serialization settings.

### SqlClient upgrade

Upgrades from `System.Data.SqlClient` to `Microsoft.Data.SqlClient`. Handles the `Encrypt=true` default behavior change and connection string differences.

### Azure Functions upgrade

Upgrades Azure Functions from the in-process hosting model to the isolated worker model with `Program.cs` and `HostApplicationBuilder`. Includes Application Insights upgrade.

### Azure migration

Starts an app modernization session that moves your application to Azure cloud services. Use this scenario when you ask to migrate to Azure, review Azure migration options, or begin app modernization work.

### ARM64 migration

Adds ARM64 support to your projects so they run on Apple Silicon, Windows on ARM, Linux and Alpine ARM64, and cloud ARM64 hardware such as AWS Graviton and Azure Ampere. The agent targets ARM64 runtime identifiers (`win-arm64`, `linux-arm64`, `linux-musl-arm64`, `osx-arm64`), fixes x86 and x64 assumptions, resolves missing ARM64 native NuGet assets, and guards x86 hardware intrinsics.

### Semantic Kernel to Microsoft Agent Framework

Upgrades from Semantic Kernel Agents (`ChatCompletionAgent`, `OpenAIAssistantAgent`) to [Microsoft Agent Framework](/agent-framework/overview/). Updates packages, namespaces, agent creation, tool registration, thread management, and invocation patterns.

### Aspire integration

Adds [Aspire](https://aspire.dev) support to existing applications for inner-loop development and Azure deployment readiness. Sets up the Aspire CLI, checks target framework compatibility, maps communication between your services, and delegates AppHost wiring to the Aspire CLI agent.

### Aspire version upgrade

Upgrades existing Aspire applications to newer versions of Aspire. Handles package updates, configuration changes, and breaking API changes between Aspire versions. When your solution contains Aspire projects, the agent prefers this scenario for target framework upgrades too, because the Aspire version determines the required target framework.

### WebForms-to-Blazor upgrade

Upgrades ASP.NET Web Forms applications to Blazor Server. Converts Web Forms pages, controls, and code-behind to Blazor components, and handles project setup (side-by-side or in-place), the `Routes` component, `App.razor` interactive server render modes, and static asset migration.

### WinForms feature adoption

Adopts modern Windows Forms features in applications that already target .NET 8 or later, including dark mode (`Application.SetColorMode`), async APIs (`Control.InvokeAsync`, `Form.ShowAsync`, `Form.ShowDialogAsync`, and `TaskDialog.ShowDialogAsync`), and MVVM patterns. Dark mode and the async APIs require .NET 9 or later. In .NET 9, `Form.ShowAsync` and `Form.ShowDialogAsync` are experimental, so opt in by suppressing warning `WFO5002`. The agent often suggests this scenario after a .NET version upgrade completes.

## Upgrade skills: common

General-purpose upgrade skills that apply across project types.

| Skill | What it does |
|---|---|
| **Building projects** | Selects and runs the right build tool for your solution, then validates the build after each change. |
| **Converting to SDK-style** | Converts legacy project files to modern SDK-style format, including `packages.config` to `PackageReference`. Uses topological ordering for multi-project solutions. |
| **Converting to Central Package Management** | Converts per-project NuGet package versioning to centralized package management using `Directory.Packages.props`. |
| **Managing target frameworks** | Adds, removes, replaces, and upgrades target frameworks, including conversion between single-targeting and multi-targeting. |
| **Managing package references** | Adds, removes, and updates `PackageReference`, `ProjectReference`, and `FrameworkReference` items. Supports Central Package Management. |
| **Managing legacy .NET packages** | Manages NuGet packages in .NET Framework 4.x projects that use `packages.config` or `PackageReference` in non-SDK-style project files. |
| **Modifying project properties** | Updates MSBuild properties such as `TargetFramework`, `LangVersion`, `Nullable`, `OutputType`, and `TreatWarningsAsErrors` in project files and `Directory.Build.props`. |
| **Modernizing C# version** | Upgrades C# code to use newer language features. Batches mechanical changes through `dotnet format` and uses LLM judgment for semantic transformations. |
| **Upgrading C# nullable references** | Enables nullable reference types and systematically resolves all CS86xx warnings. Covers rollout strategies, annotation guidance, and framework-specific considerations. |

## Upgrade skills: data access

Skills for upgrading data access layers, including Entity Framework, LINQ to SQL, and SQL client libraries.

| Skill | What it does |
|---|---|
| **Upgrading EDMX to Code-First** | Converts EF6 Database-First and Model-First (`.edmx`) models to EF Core Code-First. Scaffolds entities from the database. |
| **Upgrading EF DbContext** | Moves `DbContext` registration from `Global.asax` or `Startup` into ASP.NET Core dependency injection. Handles both EF6 and EF Core patterns. |
| **Upgrading EF6 Code-First to EF Core** | Upgrades EF6 Code-First to EF Core. Swaps packages, updates namespaces, and replaces `EntityTypeConfiguration` and `DbModelBuilder`. |
| **Upgrading LINQ to SQL to EF Core** | Upgrades LINQ to SQL (`System.Data.Linq`) data access to Entity Framework Core, including DBML entity mapping and stored procedures. |
| **Upgrading to Microsoft.Data.SqlClient** | Upgrades from `System.Data.SqlClient`. Handles the `Encrypt=true` default change and connection string differences. |

## Upgrade skills: desktop

Skills for Windows Forms applications, used during upgrades and when you adopt modern WinForms features.

| Skill | What it does |
|---|---|
| **Building WinForms applications** | Structures WinForms projects with Designer-compatible patterns and separates `InitializeComponent` from application code. |
| **Creating WinForms custom controls** | Creates custom controls and user controls for modern WinForms, including custom rendering and composite controls. |
| **Managing WinForms async APIs** | Adopts `Control.InvokeAsync`, `Form.ShowAsync`, `Form.ShowDialogAsync`, and `TaskDialog.ShowDialogAsync` in place of `Control.Invoke` and `BeginInvoke`. |
| **Managing WinForms data binding** | Implements data binding with `BindingSource`, `INotifyPropertyChanged`, validation, and master-detail scenarios. |
| **Managing WinForms Designer code** | Governs `.Designer.cs` structure and `InitializeComponent` patterns. Fixes Designer load failures and round-trip issues. |
| **Managing WinForms high-DPI layout** | Builds DPI-aware layouts with `TableLayoutPanel` and `FlowLayoutPanel`, and configures Per Monitor V2 DPI awareness. |
| **Managing WinForms MVVM** | Implements MVVM in WinForms with view models, `INotifyPropertyChanged`, commands, and `DataContext`. |
| **Managing WinForms rendering** | Implements custom painting with GDI and GDI+, including `OnPaint` overrides and owner-drawn controls. |

## Upgrade skills: testing

| Skill | What it does |
|---|---|
| **Generating an upgrade test baseline** | Generates behavior-locking tests before an upgrade for projects with compatibility risks. Uses the external `dotnet-test` plugin. |
| **Managing dotnet-test installation** | Installs the external `dotnet-test` plugin when you select AI test generation but the test-generation agent isn't loaded. |

## Upgrade skills: web and ASP.NET

Skills for upgrading ASP.NET Framework applications to ASP.NET Core.

### ASP.NET Framework upgrade

| Skill | What it does |
|---|---|
| **Upgrading ASP.NET Framework to Core** | Orchestrates the upgrade from ASP.NET Framework (MVC and Web API) to ASP.NET Core, and defines the order the other web skills run in. |
| **Upgrading ASP.NET Identity** | Upgrades ASP.NET MVC Identity to ASP.NET Core Identity, including `IdentityDbContext`, `UserManager`, `SignInManager`, auth middleware, and OWIN cleanup. |
| **Upgrading Global.asax** | Converts `Global.asax` lifecycle events (`Application_Start`, `Application_Error`) to ASP.NET Core `Program.cs` and middleware. |
| **Upgrading OWIN to ASP.NET Core** | Replaces OWIN/Katana middleware (`IAppBuilder`, `OwinMiddleware`), authentication, pipeline components, and SignalR 2.x with ASP.NET Core equivalents. |
| **Scaffolding a YARP proxy project** | Creates a new ASP.NET Core project with a YARP reverse proxy alongside an existing .NET Framework app, for incremental side-by-side upgrades. |

### MVC features

| Skill | What it does |
|---|---|
| **Upgrading MVC authentication** | Upgrades Forms Authentication, membership providers, Windows Authentication, token-based auth, authorization rules, and anti-forgery tokens to ASP.NET Core. |
| **Upgrading MVC bundling** | Converts `System.Web.Optimization` bundling to direct `<script>` and `<link>` tags or modern bundlers. |
| **Upgrading MVC configuration** | Upgrades `web.config` settings to the ASP.NET Core configuration system, including `appsettings.json`, `IConfiguration`, and `IOptions`. |
| **Upgrading MVC content negotiation** | Converts `MediaTypeFormatter` subclasses to input and output formatters, and replaces `IContentNegotiator` with `OutputFormatterSelector`. |
| **Upgrading MVC controllers** | Upgrades MVC and Web API controllers and action results to ASP.NET Core patterns, including `HttpResponseMessage` and `IHttpActionResult` returns. |
| **Upgrading MVC dependency injection** | Upgrades `DependencyResolver` registrations to ASP.NET Core built-in DI or a modernized third-party container. |
| **Upgrading MVC filters** | Converts global MVC filters (`GlobalFilters`, `FilterConfig`, `HandleErrorAttribute`) to ASP.NET Core exception handling middleware and the filter pipeline. |
| **Upgrading MVC HTTP pipeline** | Upgrades `IHttpModule`, `IHttpHandler`, and `.ashx` handlers to ASP.NET Core middleware and endpoints. |
| **Upgrading MVC HttpContext** | Upgrades `HttpContext.Current`, `HttpRequest`, `HttpResponse`, and `HttpServerUtility` usage to ASP.NET Core equivalents. |
| **Upgrading MVC logging** | Upgrades `System.Diagnostics.Trace`, log4net, NLog, ELMAH, and `customErrors` to ASP.NET Core logging, error middleware, and health checks. |
| **Upgrading MVC model binding** | Upgrades binding source attributes, custom model binders, value providers, and over-posting protection to ASP.NET Core. |
| **Upgrading MVC Razor views** | Converts HTML helpers to tag helpers, child actions to view components, and updates layout infrastructure. |
| **Upgrading MVC routing** | Converts `RouteCollection` routing to ASP.NET Core endpoint routing (`MapControllerRoute`, attribute routing). |
| **Upgrading MVC session state** | Converts `HttpSessionState` to `ISession` with a distributed cache backend, and moves `TempData` to the cookie-based provider. |
| **Upgrading MVC static files** | Moves `Content/`, `Scripts/`, and `App_Data/` into `wwwroot/`, configures static files middleware, and replaces `VirtualPathProvider` with `IFileProvider`. |
| **Upgrading MVC System.Web adapters** | Installs `Microsoft.AspNetCore.SystemWebAdapters` compatibility shims so `System.Web` patterns keep working during an incremental upgrade. |
| **Upgrading MVC validation** | Upgrades data annotations, custom `ValidationAttribute` classes, `ModelState` handling, unobtrusive client validation, and FluentValidation integration. |

### WCF

| Skill | What it does |
|---|---|
| **Upgrading WCF to CoreWCF** | Upgrades server-side WCF services to [CoreWCF](https://github.com/CoreWCF/CoreWCF) for .NET 6+. Converts hosting, configuration, bindings, behavior extensions, and APM-style contracts. |

### Web Forms and Blazor Server

| Skill | What it does |
|---|---|
| **Upgrading Web Forms to Blazor Server** | Handles the full upgrade: Blazor project setup (side-by-side or in-place), the `Routes` component, `App.razor` interactive server render modes, and static asset migration. |
| **Managing Blazor Server authentication** | Solves Blazor Server auth problems with ASP.NET Core Identity, such as a null `HttpContext` during WebSocket circuits and cookie operations that fail silently in component handlers. |
| **Managing Blazor Server data access** | Solves Blazor Server data and state problems, such as a null `Session` in WebSocket circuits, `DbContext` threading errors, and lost wizard or cart state. |

## Upgrade skills: cloud

| Skill | What it does |
|---|---|
| **Upgrading Azure Functions Startup** | Upgrades Azure Functions from in-process startup hooks (`FunctionsStartup`, `IFunctionsHostBuilder`) to the isolated worker model with `Program.cs`. |
| **Upgrading Azure Functions to v2** | Upgrades Azure Functions to the v2 isolated worker pattern using `IHostApplicationBuilder` and Application Insights. |

## Upgrade skills: libraries

Most library skills are deprecation-driven: they activate when a package is flagged as obsolete or deprecated and must be replaced, not when a still-supported package needs a routine version bump.

| Skill | What it does |
|---|---|
| **Upgrading ADAL to MSAL** | Upgrades the deprecated Azure Active Directory Authentication Library (ADAL) to Microsoft Authentication Library (MSAL). |
| **Upgrading ASP.NET SignalR** | Upgrades the obsolete `Microsoft.AspNet.SignalR` to `Microsoft.AspNetCore.SignalR`. |
| **Upgrading Autofac to .NET DI** | Removes Autofac entirely and upgrades all registrations, lifetimes, and modules to built-in ASP.NET Core dependency injection. |
| **Integrating Autofac with .NET** | Keeps Autofac as the DI container but modernizes its ASP.NET Core integration and moves setup into `Program.cs`. |
| **Upgrading Azure Key Vault** | Upgrades the deprecated `Microsoft.Azure.KeyVault` SDK to the `Azure.Security.KeyVault` client libraries. |
| **Upgrading Azure Service Bus** | Upgrades the deprecated `WindowsAzure.ServiceBus` to `Azure.Messaging.ServiceBus`. |
| **Upgrading Azure Storage** | Upgrades the deprecated `WindowsAzure.Storage` to the modern Azure SDK storage libraries, such as `Azure.Storage.Blobs` and `Azure.Data.Tables`. |
| **Upgrading Bond interfaces** | Upgrades the obsolete `Microsoft.Bond.Interfaces` package to the unified `Bond.CSharp` SDK. |
| **Upgrading Cosmos DB bulk executor** | Upgrades the deprecated `Microsoft.Azure.CosmosDB.BulkExecutor` library to built-in bulk support in the `Microsoft.Azure.Cosmos` SDK. |
| **Upgrading cryptography namespaces** | Fixes the `System.Security.Cryptography` namespace split. Adds the correct `using` statements and NuGet packages for types such as `X509Certificate2` and `SignedCms`. |
| **Upgrading Data EDM to OData** | Upgrades the obsolete `Microsoft.Data.Edm` to `Microsoft.OData.Edm` for OData v4. |
| **Upgrading Data OData to OData Core** | Upgrades the obsolete `Microsoft.Data.OData` to `Microsoft.OData.Core` for OData v4 serialization. |
| **Upgrading Data Services client** | Upgrades the obsolete `Microsoft.Data.Services.Client` (WCF Data Services) to `Microsoft.OData.Client`. |
| **Upgrading DocumentDB to Cosmos DB** | Upgrades the deprecated `Microsoft.Azure.DocumentDB` SDK (V2) to the `Microsoft.Azure.Cosmos` SDK (V3). |
| **Upgrading Newtonsoft to System.Text.Json** | Full upgrade from `Newtonsoft.Json`. Handles converters, attributes, dynamic types, and settings. |
| **Upgrading OWIN Cookie Authentication** | Upgrades `Microsoft.Owin.Security.Cookies` to ASP.NET Core cookie authentication. |
| **Upgrading OWIN OAuth to JWT** | Upgrades `Microsoft.Owin.Security.OAuth` bearer authentication to ASP.NET Core JWT bearer authentication. |
| **Upgrading OWIN OpenID Connect** | Upgrades `Microsoft.Owin.Security.OpenIdConnect` to ASP.NET Core OpenID Connect authentication. |
| **Upgrading PowerShell SDK** | Upgrades PowerShell modules from Windows PowerShell 5.1 reference assemblies to the cross-platform `Microsoft.PowerShell.SDK` package for PowerShell 7+. |
| **Upgrading RazorEngine to RazorLight** | Upgrades the deprecated RazorEngine to RazorLight for Razor template rendering outside of MVC. |
| **Upgrading Semantic Kernel to Agents** | Upgrades `Microsoft.SemanticKernel.Agents` to Microsoft Agent Framework (`Microsoft.Agents.AI`), including tool registration and thread management. |
| **Upgrading SPA Services to SPA Proxy** | Upgrades the obsolete `Microsoft.AspNetCore.SpaServices.Extensions` to `Microsoft.AspNetCore.SpaProxy` for Angular and React SPAs. |
| **Upgrading System.Spatial** | Upgrades the obsolete `System.Spatial` to `Microsoft.Spatial` for OData v4. |
| **Upgrading to MSMQ.Messaging** | Upgrades from `System.Messaging` (.NET Framework only) to `MSMQ.Messaging` for modern .NET. |
| **Upgrading WebAPI CORS** | Upgrades `Microsoft.AspNet.WebApi.Cors` to ASP.NET Core CORS middleware. |
| **Upgrading WebAPI OData** | Upgrades `Microsoft.AspNet.WebApi.OData` to `Microsoft.AspNetCore.OData`. |

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

- [What is GitHub Copilot upgrade?](overview.md)
- [Core concepts](concepts.md)
- [Upgrade a .NET app with GitHub Copilot upgrade](how-to-upgrade-with-github-copilot.md)
- [Apply custom upgrade instructions](how-to-custom-upgrade-instructions.md)

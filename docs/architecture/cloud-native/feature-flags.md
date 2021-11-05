---
title: Feature flags
description: Implement feature flags in cloud-native applications leveraging Azure App Config
author: robvet
ms.date: 05/13/2020
---

# Feature flags

In chapter 1, we affirmed that cloud native is much about speed and agility. Users expect rapid responsiveness, innovative features, and zero downtime. `Feature flags` are a modern deployment technique that helps increase agility for cloud-native applications. They enable you to deploy new features into a production environment, but restrict their availability. With the flick of a switch, you can activate a new feature for specific users without restarting the app or deploying new code. They separate the release of new features from their code deployment.

Feature flags are built upon conditional logic that control visibility of functionality for users at run time. In modern cloud-native systems, it's common to deploy new features into production early, but test them with a limited audience. As confidence increases, the feature can be incrementally rolled out to wider audiences.

Other use cases for feature flags include:

- Restrict premium functionality to specific customer groups willing to pay higher subscription fees.
- Stabilize a system by quickly deactivating a problem feature, avoiding the risks of a rollback or immediate hotfix.
- Disable an optional feature with high resource consumption during peak usage periods.
- Conduct `experimental feature releases` to small user segments to validate feasibility and popularity.

Feature flags also promote `trunk-based` development. It's a source-control branching model where developers collaborate on features in a single branch. The approach minimizes the risk and complexity of merging large numbers of long-running feature branches. Features are unavailable until activated.

## Implementing feature flags

At its core, a feature flag is a reference to a simple `decision object`. It returns a Boolean state of `on` or `off`. The flag typically wraps a block of code that encapsulates a feature capability. The state of the flag determines whether that code block executes for a given user. Figure 10-11 shows the implementation.

```csharp
if (featureFlag) {
    // Run this code block if the featureFlag value is true
} else {
    // Run this code block if the featureFlag value is false
}
```

**Figure 10-11** - Simple feature flag implementation.

Note how this approach separates the decision logic from the feature code.

In chapter 1, we discussed the `Twelve-Factor App`. The guidance recommended keeping configuration settings external from application executable code. When needed, settings can be read in from the external source. Feature flag configuration values should also be independent from their codebase. By externalizing flag configuration in a separate repository, you can change flag state without modifying and redeploying the application.

[Azure App Configuration](/azure/azure-app-configuration/overview) provides a centralized repository for feature flags. With it, you define different kinds of feature flags and manipulate their states quickly and confidently. You add the App Configuration client libraries to your application to enable feature flag functionality. Various programming language frameworks are supported.

Feature flags can be easily implemented in an [ASP.NET Core service](/azure/azure-app-configuration/use-feature-flags-dotnet-core). Installing the .NET Feature Management libraries and App Configuration provider enable you to declaratively add feature flags to your code. They enable `FeatureGate` attributes so that you don't have to manually write if statements across your codebase.

Once configured in your Startup class, you can add feature flag functionality at the controller, action, or middleware level. Figure 10-12 presents controller and action implementation:

```csharp
[FeatureGate(MyFeatureFlags.FeatureA)]
public class ProductController : Controller
{
    ...
}
```

```csharp
[FeatureGate(MyFeatureFlags.FeatureA)]
public IActionResult UpdateProductStatus()
{
    return ObjectResult(ProductDto);
}
```

**Figure 10-12** - Feature flag implementation in a controller and action.

If a feature flag is disabled, the user will receive a 404 (Not Found) status code with no response body.

Feature flags can also be injected directly into C# classes. Figure 10-13 shows feature flag injection:

```csharp
public class ProductController : Controller
{
    private readonly IFeatureManager _featureManager;

    public ProductController(IFeatureManager featureManager)
    {
        _featureManager = featureManager;
    }
}
```

**Figure 10-13** - Feature flag injection into a class.

The Feature Management libraries manage the feature flag lifecycle behind the scenes. For example, to minimize high numbers of calls to the configuration store, the libraries cache flag states for a specified duration. They can guarantee the immutability of flag states during a request call. They also offer a `Point-in-time snapshot`. You can reconstruct the history of any key-value and provide its past value at any moment within the previous seven days.

>[!div class="step-by-step"]
>[Previous](devops.md)
>[Next](infrastructure-as-code.md)

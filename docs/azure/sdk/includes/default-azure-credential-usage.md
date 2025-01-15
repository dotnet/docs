
`DefaultAzureCredential` is the most approachable way to get started with the Azure Identity library, but that convenience also introduces certain tradeoffs. For example, the specific credential in the [chain](/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet) that will succeed and be used for request authentication is not 100% deterministic. In a production environment, this unpredictability can introduce significant and sometimes subtle problems.

For example, consider the following hypothetical sequence of events:

1. An organization's security team mandates all apps use managed identity to authenticate to Azure resources.
1. For months, a .NET app hosted on an Azure Virtual Machine (VM) successfully uses `DefaultAzureCredential` to authenticate via managed identity.
1. Without telling the support team, a developer installs the Azure CLI on that VM and runs the `az login` command to sign-in to Azure.
1. Due to a separate configuration change in the Azure environment, authentication via the original managed identity unexpectedly begins to fail silently.
1. `DefaultAzureCredential` skips the failed `ManagedIdentityCredential` and searches for the next available credential, which is the Azure CLI credentials.
1. The team is unaware of the hidden authentication failure because logging is disabled by default.

`DefaultAzureCredential` also introduces the following challenges in some scenarios:

- **Debugging challenges**: When authentication fails, it can be difficult to identify and [debug the offending credential](/dotnet/azure/sdk/authentication/credential-chains?tabs=dac#debug-a-chained-credential). Enable logging to see the sequential progression and success or failure status of each credential.
- **Performance overhead**: Sequential credential attempts can introduce performance overhead into the developer inner loop. For example, managed identity is unavailable on a local development machine. Consequently, `ManagedIdentityCredential` always fails locally, unless explicitly disabled via its corresponding `Exclude`-prefixed property.

To prevent these types of subtle issues or silent failures in production apps, strongly consider moving from `DefaultAzureCredential` to one of the following deterministic solutions:

- A specific `TokenCredential` implementation, such as `ManagedIdentityCredential`. See the [**Derived** list](/dotnet/api/azure.core.tokencredential?view=azure-dotnet&preserve-view=true#definition) for options.
- A pared-down `ChainedTokenCredential` implementation optimized for the Azure environment in which your app runs. `ChainedTokenCredential` essentially creates a specific allow-list of acceptable credential options, such as `ManagedIdentity` for production and `VisualStudioCredential` for development.

For example, consider the following `DefaultAzureCredential` configuration:

:::code language="csharp" source="../snippets/authentication/credential-chains/Program.cs" id="snippet_Dac" highlight="6,7":::

Replace the preceding code with the following `ChainedTokenCredential` implementation to intentionally specify your desired credentials:

:::code language="csharp" source="../snippets/authentication/credential-chains/Program.cs" id="snippet_Ctc" highlight="6-8":::

In this example, `ManagedIdentityCredential` would be automatically discovered in production, while `VisualStudioCredential` would work in local development environments.


`DefaultAzureCredential` is the easiest way to get started with the Azure Identity library, but with that convenience comes certain tradeoffs. Perhaps the most significant tradeoff is the credential chain's indeterministic behavior - that is, the specific credential in the [chain](/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet) that will succeed and be used for request authentication can't be guaranteed ahead of time. In a production environment, this unpredictability can introduce significant and sometimes subtle problems. Once you deploy your app to Azure, you should understand the app's authentication requirements.

For example, consider the following hypothetical sequence of events:

1. An organization's security team mandates that all apps use managed identity to authenticate to Azure resources.
1. For months, a .NET app hosted on an Azure Virtual Machine (VM) successfully uses `DefaultAzureCredential` to authenticate via managed identity.
1. Unbeknownst to the support team, a developer installs the Azure CLI on that VM and runs the `az login` command to sign-in to Azure.
1. Authentication via the original managed identity unexpectedly begins to fail due to changes in the Azure environment.
1. `DefaultAzureCredential` skips `ManagedIdentityCredential` and searches for the next available credential, which is the Azure CLI credentials.
1. Because logging is disabled by default, nobody is aware of this failure, as `DefaultAzureCredential` recovers gracefully.

`DefaultAzureCredential` can also introduce the following challenges:

- **Debugging challenges**: When authentication fails, it can be challenging to debug and identify the offending credential. You must enable logging to see the progression from one credential to the next and the success/failure status of each. For more information, see [Debug a chained credential](#debug-a-chained-credential).
- **Performance overhead**: The process of sequentially trying multiple credentials can introduce performance overhead. For example, when running on a local development machine, managed identity is unavailable. Consequently, `ManagedIdentityCredential` always fails in the local development environment, unless explicitly disabled via its corresponding `Exclude`-prefixed property.

To prevent these types of subtle issues or silent failures in production apps, strongly consider moving from `DefaultAzureCredential` to one of the following solutions:

- A specific `TokenCredential` implementation, such as `ManagedIdentityCredential`. See the [**Derived** list](/dotnet/api/azure.core.tokencredential?view=azure-dotnet&preserve-view=true#definition) for options.
- A pared-down `ChainedTokenCredential` implementation optimized for the Azure environment in which your app runs. `ChainedTokenCredential` essentially creates a specific allow-list of acceptable credential options, such as `ManagedIdentity` for production and `VisualStudioCredential` for development.

Consider the following `DefaultAzureCredential` example:

:::code language="csharp" source="../snippets/authentication/credential-chains/Program.cs" id="snippet_Dac" highlight="6":::

Replace the preceding code with the following `ChainedTokenCredential` implementation, specifying your desired credentials:

:::code language="csharp" source="../snippets/authentication/credential-chains/Program.cs" id="snippet_Dac" highlight="snippet_Ctc":::
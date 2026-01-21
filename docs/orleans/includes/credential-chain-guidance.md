<!-- Azure credential chain guidance -->

> [!TIP]
> While <xref:Azure.Identity.DefaultAzureCredential> is convenient for getting started, consider replacing it with a specific credential like <xref:Azure.Identity.ManagedIdentityCredential> once deployed to Azure. This approach improves debuggability, performance, and predictability. For more information, see [Usage guidance for DefaultAzureCredential](/dotnet/azure/sdk/authentication/credential-chains#usage-guidance-for-defaultazurecredential).

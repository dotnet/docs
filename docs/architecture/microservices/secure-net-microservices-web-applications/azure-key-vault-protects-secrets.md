---
title: Using Azure Key Vault to protect secrets at production time
description: Security in .NET Microservices and Web Applications - Azure Key Vault is an excellent way to handle application secrets that are completely controlled by administrators. Administrators can even assign and revoke development values without developers having to handle them.
author: mjrousos
ms.date: 01/30/2020
---
# Use Azure Key Vault to protect secrets at production time

Secrets stored as environment variables or stored by the Secret Manager tool are still stored locally and unencrypted on the machine. A more secure option for storing secrets is [Azure Key Vault](https://azure.microsoft.com/services/key-vault/), which provides a secure, central location for storing keys and secrets.

The **Azure.Extensions.AspNetCore.Configuration.Secrets** package allows an ASP.NET Core application to read configuration information from Azure Key Vault. To start using secrets from an Azure Key Vault, you follow these steps:

1. Register your application as an Azure AD application. (Access to key vaults is managed by Azure AD.) This can be done through the Azure management portal.\

   Alternatively, if you want your application to authenticate using a certificate instead of a password or client secret, you can use the [New-AzADApplication](/powershell/module/az.resources/new-azadapplication) PowerShell cmdlet. The certificate that you register with Azure Key Vault needs only your public key. Your application will use the private key.

2. Give the registered application access to the key vault by creating a new service principal. You can do this using the following PowerShell commands:

   ```powershell
   $sp = New-AzADServicePrincipal -ApplicationId "<Application ID guid>"
   Set-AzKeyVaultAccessPolicy -VaultName "<VaultName>" -ServicePrincipalName $sp.ServicePrincipalNames[0] -PermissionsToSecrets all -ResourceGroupName "<KeyVault Resource Group>"
   ```

3. Include the key vault as a configuration source in your application by calling the AzureKeyVaultConfigurationExtensions.AddAzureKeyVault extension method when you create an <xref:Microsoft.Extensions.Configuration.IConfigurationRoot> instance.

Note that calling `AddAzureKeyVault` requires the application ID that was registered and given access to the key vault in the previous steps. Or you can firstly running the Azure CLI command: `az login`, then using an overload of `AddAzureKeyVault` that takes a DefaultAzureCredential in place of the client.

> [!IMPORTANT]
> We recommend that you register Azure Key Vault as the last configuration provider, so it can override configuration values from previous providers.

## Additional resources

- **Using Azure Key Vault to protect application secrets** \
  [https://docs.microsoft.com/azure/architecture/multitenant-identity](/azure/architecture/multitenant-identity)

- **Safe storage of app secrets during development** \
  [https://docs.microsoft.com/aspnet/core/security/app-secrets](/aspnet/core/security/app-secrets)

- **Configuring data protection** \
  [https://docs.microsoft.com/aspnet/core/security/data-protection/configuration/overview](/aspnet/core/security/data-protection/configuration/overview)

- **Data Protection key management and lifetime in ASP.NET Core** \
  [https://docs.microsoft.com/aspnet/core/security/data-protection/configuration/default-settings](/aspnet/core/security/data-protection/configuration/default-settings)

>[!div class="step-by-step"]
>[Previous](developer-app-secrets-storage.md)
>[Next](../key-takeaways.md)

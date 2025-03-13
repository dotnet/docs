---
ms.topic: include
ms.date: 03/11/2025
---

## Set the app environment variables

At runtime, certain credentials from the [Azure Identity library](/dotnet/api/azure.identity?view=azure-dotnet&preserve-view=true), such as `DefaultAzureCredential`, `EnvironmentCredential`, and `ClientSecretCredential`, search for service principal information by convention in the environment variables. There are multiple ways to configure environment variables when working with .NET, depending on your tooling and environment.

Regardless of the approach you choose, configure the following environment variables for a service principal:

- `AZURE_CLIENT_ID`: Used to identify the registered app in Azure.
- `AZURE_TENANT_ID`: The ID of the Microsoft Entra tenant.
- `AZURE_CLIENT_SECRET`: The secret credential that was generated for the app.

### [Visual Studio](#tab/visual-studio)

In Visual Studio, environment variables can be set in the `launchsettings.json` file in the `Properties` folder of your project. These values are pulled in automatically when the app starts. However, these configurations don't travel with your app during deployment, so you need to set up environment variables on your target hosting environment.

```json
"profiles": {
    "SampleProject": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "https://localhost:7177;http://localhost:5177",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "AZURE_CLIENT_ID": "<your-client-id>",
        "AZURE_TENANT_ID":"<your-tenant-id>",
        "AZURE_CLIENT_SECRET": "<your-client-secret>"
      }
    },
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "AZURE_CLIENT_ID": "<your-client-id>",
        "AZURE_TENANT_ID":"<your-tenant-id>",
        "AZURE_CLIENT_SECRET": "<your-client-secret>"
      }
    }
  }
```

### [Visual Studio Code](#tab/vs-code)

In Visual Studio Code, environment variables can be set in the `launch.json` file of your project. These values are pulled in automatically when the app starts. However, these configurations don't travel with your app during deployment, so you need to set up environment variables on your target hosting environment.

```json
"configurations": [
{
    "env": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "AZURE_CLIENT_ID": "<your-client-id>",
        "AZURE_TENANT_ID":"<your-tenant-id>",
        "AZURE_CLIENT_SECRET": "<your-client-secret>"
    }
}
```

### [Windows](#tab/windows)

You can set environment variables for Windows from the command line. However, the values are accessible to all apps running on that operating system and could cause conflicts, so use caution with this approach. Environment variables can be set at the user or system level.

```bash
# Set user environment variables
setx ASPNETCORE_ENVIRONMENT "Development"
setx AZURE_CLIENT_ID "<your-client-id>"
setx AZURE_TENANT_ID "<your-tenant-id>"
setx AZURE_CLIENT_SECRET "<your-client-secret>"

# Set system environment variables - requires running as admin
setx ASPNETCORE_ENVIRONMENT "Development" /m
setx AZURE_CLIENT_ID "<your-client-id>" /m
setx AZURE_TENANT_ID "<your-tenant-id>" /m
setx AZURE_CLIENT_SECRET "<your-client-secret>" /m
```

PowerShell can also be used to set environment variables at the user or system level:

```powershell
# Set user environment variables
[Environment]::SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development", "User")
[Environment]::SetEnvironmentVariable("AZURE_CLIENT_ID", "<your-client-id>", "User")
[Environment]::SetEnvironmentVariable("AZURE_TENANT_ID", "<your-tenant-id>", "User")
[Environment]::SetEnvironmentVariable("AZURE_CLIENT_SECRET", "<your-client-secret>", "User")

# Set system environment variables - requires running as admin
[Environment]::SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development", "Machine")
[Environment]::SetEnvironmentVariable("AZURE_CLIENT_ID", "<your-client-id>", "Machine")
[Environment]::SetEnvironmentVariable("AZURE_TENANT_ID", "<your-tenant-id>", "Machine")
[Environment]::SetEnvironmentVariable("AZURE_CLIENT_SECRET", "<your-client-secret>", "Machine")
```

---

---
title: Storing application secrets safely during development
description: .NET Microservices Architecture for Containerized .NET Applications | Storing application secrets safely during development
keywords: Docker, Microservices, ASP.NET, Container
author: mjrousos
ms.author: wiwagn
ms.date: 05/26/2017
ms.prod: .net-core
ms.technology: dotnet-docker
ms.topic: article
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Storing application secrets safely during development

To connect with protected resources and other services, ASP.NET Core applications typically need to use connection strings, passwords, or other credentials that contain sensitive information. These sensitive pieces of information are called *secrets*. It is a best practice to not include secrets in source code and certainly not to store secrets in source control. Instead, you should use the ASP.NET Core configuration model to read the secrets from more secure locations.

You should separate the secrets for accessing development and staging resources from those used for accessing production resources, because different individuals will need access to those different sets of secrets. To store secrets used during development, common approaches are to either store secrets in environment variables or by using the ASP.NET Core Secret Manager tool. For more secure storage in production environments, microservices can store secrets in an Azure Key Vault.

## Storing secrets in environment variables

One way to keep secrets out of source code is for developers to set string-based secrets as [environment variables](https://docs.microsoft.com/aspnet/core/security/app-secrets#environment-variables) on their development machines. When you use environment variables to store secrets with hierarchical names (those nested in configuration sections), create a name for the environment variables that includes the full hierarchy of the secret’s name, delimited with colons (:).

For example, setting an environment variable Logging:LogLevel:Default to Debug would be equivalent to a configuration value from the following JSON file:

```json
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

The ASP.NET Core [Secret Manager](https://docs.microsoft.com/aspnet/core/security/app-secrets#secret-manager) tool provides another method of keeping secrets out of source code. To use the Secret Manager tool, include a tools reference (DotNetCliToolReference) to the Microsoft.Extensions.SecretManager.Tools package in your project file. Once that dependency is present and has been restored, the dotnet user-secrets command can be used to set the value of secrets from the command line. These secrets will be stored in a JSON file in the user’s profile directory (details vary by OS), away from source code.

Secrets set by the Secret Manager tool are organized by the UserSecretsId property of the project that is using the secrets. Therefore, you must be sure to set the UserSecretsId property in your project file (as shown in the snippet below). The actual string used as the ID is not important as long as it is unique in the project.

```xml
<PropertyGroup>
    <UserSecretsId>UniqueIdentifyingString</UserSecretsId>
</PropertyGroup>
```

Using secrets stored with Secret Manager in an application is accomplished by calling AddUserSecrets&lt;T&gt; on the ConfigurationBuilder instance to include secrets for the application in its configuration. The generic parameter T should be a type from the assembly that the UserSecretId was applied to. Usually using AddUserSecrets&lt;Startup&gt; is fine.


>[!div class="step-by-step"]
[Previous] (authorization-net-microservices-web-applications.md)
[Next] (azure-key-vault-protects-secrets.md)

---
title: The Dapr secrets building block
description: A description of the secrets building block, its features, benefits, and how to apply it
author: edwinvw
ms.date: 02/17/2021
---

# The Dapr secrets building block

Enterprise applications require secrets. Common examples include:

- A database connection string that contains a username and password.
- An API key for calling an external web API.
- A client certificate for authenticating to an external system.

Secrets must be carefully managed so that they're never disclosed outside of the application.

Not long ago, it was popular to store application secrets in a configuration file inside the application codebase. .NET developers will fondly recall the *web.config* file. While simple to implement, integrating secrets to along with code was far from secure. A common misstep was to include the file when pushing to a public GIT repository, exposing the secrets to the world.

A widely accepted methodology for constructing modern distributed applications is [The Twelve-Factor App](https://12factor.net/). It describes a set of principles and best practices. Its third factor prescribes that *configuration and secrets be externalized outside of the code base.*

To address this concern, the .NET Core platform includes a [Secret Manager](/aspnet/core/security/app-secrets#secret-manager) feature that stores sensitive data in a physical folder outside of the project tree. While secrets are outside of source control, this feature doesn't encrypt data. It's designed for **development purposes** only.

A more modern and secure practice is to isolate secrets in a secrets management tool like **Hashicorp Vault** or **Azure Key Vault**.  These tools enable you to store secrets externally, vary credentials across environments, and reference them from application code. However, each tool has its complexities and learning curve.

Dapr offers a building block that simplifies managing secrets.

## What it solves

The Dapr [secrets building block](https://docs.dapr.io/developing-applications/building-blocks/secrets/secrets-overview/) abstracts away the complexity of working with secrets and secret management tools.

- It hides the underlying plumbing through a unified interface.
- It supports various *pluggable* secret store components, which can vary between development and production.
- Applications don't require direct dependencies on secret store libraries.
- Developers don't require detailed knowledge of each secret store.

Dapr handles all of the above concerns.

Access to the secrets is secured through authentication and authorization. Only an application with sufficient rights can access secrets. Applications running in Kubernetes can also use its built-in secrets management mechanism.

## How it works

Applications use the secrets building block in two ways:

- Retrieve a secret directly from the application block.
- Reference a secret indirectly from a Dapr component configuration.

Retrieving secrets directly is covered first. Referencing a secret from a Dapr component configuration file is addressed in a later section.

The application interacts with a Dapr sidecar when using the secrets building block. The sidecar exposes the secrets API. The API can be called with either HTTP or gRPC. Use the following URL to call the HTTP API:

```http
http://localhost:<dapr-port>/v1.0/secrets/<store-name>/<name>?<metadata>
```

The URL contains the following segments:

- `<dapr-port>` specifies the port number upon which the Dapr sidecar is listening.
- `<store-name>` specifies the name of the Dapr secret store.
- `<name>` specifies  the name of the secret to retrieve.
- `<metadata>` provides additional information for the secret. This segment is optional and metadata properties differ per secret store. For more information on metadata properties, see the [secrets API reference]([Secrets API reference | Dapr Docs](https://docs.dapr.io/reference/api/secrets_api/)).

 > [!NOTE]
 > The above URL represents the native Dapr API call available to any development platform that supports HTTP or gRPC. Popular platforms like .NET, Java, and Go have their own custom APIs.

The JSON response contains the key and value of the secret.

Figure 10-1 shows how Dapr handles a request for the secrets API:

![Diagram of retrieving a secret using the Dapr secrets API.](media/secrets/secrets-flow.png)

**Figure 10-1**. Retrieving a secret with the Dapr secrets API.

1. The service calls the Dapr secrets API, along with the name of the secret store, and secret to retrieve.
1. The Dapr sidecar retrieves the specified secret from the secret store.
1. The Dapr sidecar returns the secret information back to the service.

Some secret stores support storing multiple key/value pairs in a single secret. For those scenarios, the response would contain multiple key/value pairs in a single JSON response as in the following example:

```http
GET http://localhost:3500/v1.0/secrets/secret-store/interestRates?metadata.version_id=3
```

```json
{
  "tier1-percentage": "2.5",
  "tier2-percentage": "3.8",
  "tier3-percentage": "5.1"
}
```

The Dapr secrets API also offers an operation to retrieve all the secrets the application has access to:

```http
http://localhost:<dapr-port>/v1.0/secrets/<store-name>/bulk
```

## Use the Dapr .NET SDK

For .NET developers, the Dapr .NET SDK streamlines Dapr secret management. Consider the `DaprClient.GetSecretAsync` method. It enables you to retrieve a secret directly from any Dapr secret store with minimal effort. Here's an example of fetching a connection string secret for a SQL Server database:

```csharp
var metadata = new Dictionary<string, string> { ["version_id"] = "3" };
Dictionary<string, string> secrets = await daprClient.GetSecretAsync("secret-store", "eshopsecrets", metadata);
string connectionString = secrets["customerdb"];
```

Arguments for the `GetSecretAsync` method include:

- The name of the Dapr secret store component ('secret-store')
- The secret to retrieve ('eshopsecrets')
- Optional metadata key/value pairs ('version_id=3')

The method responds with a dictionary object as a secret can contain multiple key/value pairs. In the example above, the secret named `customerdb` is referenced from the collection to return a connection string.

The Dapr .NET SDK also features a .NET configuration provider. It loads specified secrets into the underlying [.NET Core configuration API](../../core/extensions/configuration.md). The running application can then reference secrets from the `IConfiguration` dictionary that is registered in ASP.NET Core dependency injection.

The secrets configuration provider is available from the [Dapr.Extensions.Configuration](https://www.nuget.org/packages/Dapr.Extensions.Configuration) NuGet package. The provider can be registered in the `Program.cs` of an ASP.NET Web API application:  

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration(config =>
        {
            var daprClient = new DaprClientBuilder().Build();
            var secretDescriptors = new List<DaprSecretDescriptor>
            {
                new DaprSecretDescriptor("eshopsecrets")
            };
            config.AddDaprSecretStore("secret-store", secretDescriptors, daprClient);
        })
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
```

The above example loads the `eshopsecrets` secrets collection into the .NET configuration system at startup. Registering the provider requires an instance of `DaprClient` to invoke the secrets API on the Dapr sidecar. The other arguments include the name of the secret store and a `DaprSecretDescriptor` object with the name of the secret.

Once loaded, you can retrieve secrets directly from application code:

```csharp
public void GetCustomer(IConfiguration config)
{
    var connectionString = config["eshopsecrets"]["customerdb"];
}
```

## Secret store components

The secrets building block supports several secret store components. At the time of writing, the following secret stores are available:

- Environment Variables
- Local file
- Kubernetes secrets
- AWS Secrets Manager
- Azure Key Vault
- GCP Secret Manager
- HashiCorp Vault

> [!IMPORTANT]
> The environment variables and local file components are designed for development workloads only.

The following sections show how to configure a secret store.

### Configuration

You configure a secret store using a Dapr component configuration file. The typical structure of the file is shown below:

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: [component name]
  namespace: [namespace]
spec:
  type: secretstores.[secret store type]
  version: [secret store version]
  metadata:
  - name: [property name]
    value: [property value]
```

All Dapr component configuration files require a `name` along with an optional `namespace` value. Additionally, the `type` field in the `spec` section specifies the type of secret store component. The properties in the `metadata` section differ per secret store.

### Indirectly consume Dapr secrets

As mentioned earlier in this chapter, applications can also consume secrets by referencing them in component configuration files. Consider a [state management component](state-management.md) that uses Redis cache for storing state:

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: eshop-basket-statestore
  namespace: eshop
spec:
  type: state.redis
  version: v1
  metadata:
  - name: redisHost
    value: localhost:6379
  - name: redisPassword
    value: e$h0p0nD@pr
```

The above configuration file contains a **clear-text** password for connecting to the Redis server. **Hardcoded** passwords are always a bad idea. Pushing this configuration file to a public repository would expose the password. Storing the password in a secret store would dramatically improve this scenario.

The following examples demonstrate this using several different secret stores.

### Local file

The local file component is designed for development scenarios. It stores secrets on the local filesystem inside a JSON file. Here's an example named `eshop-secrets.json`. It contains a single secret - a password for Redis:

```json
{
  "eShopRedisPassword": "e$h0p0nD@pr"
}
```

You place this file in a `components` folder that you specify when running the Dapr application.

The following secret store configuration file consumes the JSON file as a secret store. It's also placed in the `components` folder:

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: eshop-local-secret-store
  namespace: eshop
spec:
  type: secretstores.local.file
  version: v1
  metadata:
  - name: secretsFile
    value: ./components/eshop-secrets.json
  - name: nestedSeparator
    value: ":"
```

The component type is `secretstore.local.file`. The `secretsFile` metadata element specifies the path to the secrets file.

> [!IMPORTANT]
> The path to a secrets file can be a absolute or relative path. The relative path is based on the folder in which the application starts. In the example, the `components` folder is a sub-folder of the directory that contains the .NET application.

From the application folder, start the Dapr application specifying the `components` path as a command-line argument:

```console
dapr run --app-id basket-api --components-path ./components dotnet run
```

> [!NOTE]
> This above example applies to running Dapr in self-hosted mode. For Kubernetes hosting, consider using volume mounts.

The `nestedSeparator` in a Dapr configuration file specifies a character to *flatten* a JSON hierarchy. Consider the following snippet:

```json
{
    "redisPassword": "some password",
    "connectionStrings": {
        "customerdb": "some connection string",
        "productdb": "some connection string"
    }
}
```

Using a colon as a separator, you can retrieve the `customerdb` connection-string using the key `connectionStrings:customerdb`.

> [!NOTE]
> The colon `:` is the default separator value.

In the next example, a state management configuration file references the local secret store component to obtain the password for connecting to the Redis server:

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: eshop-basket-statestore
  namespace: eshop
spec:
  type: state.redis
  version: v1
  metadata:
  - name: redisHost
    value: localhost:6379
  - name: redisPassword
    secretKeyRef:
      name: eShopRedisPassword
      key: eShopRedisPassword
auth:
  secretStore: eshop-local-secret-store
```

The `secretKeyRef` element references the secret containing the password. It replaces the earlier *clear-text* value. The secret name and the key name, `eShopRedisPassword`, reference the secret. The name of the secret management component `eshop-local-secret-store` is found in the `auth` metadata element.

You might wonder why `eShopRedisPassword` is identical for both the name and key in the secret reference. In the local file secret store, secrets aren't identified with a separate name. The scenario will be different in the next example using Kubernetes secrets.

### Kubernetes secret

This second example focuses on a Dapr application running in Kubernetes. It uses the standard secrets mechanism that Kubernetes offers. Use the Kubernetes CLI (`kubectl`) to create a secret named `eshop-redis-secret` that contains the password:

```console
kubectl create secret generic eshopsecrets --from-literal=redisPassword=e$h0p0nD@pr -n eshop
```

Once created, you can reference the secret in the component configuration file for state management:

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: eshop-basket-statestore
  namespace: eshop
spec:
  type: state.redis
  version: v1
  metadata:
  - name: redisHost
    value: redis:6379
  - name: redisPassword
    secretKeyRef:
      name: eshopsecrets
      key: redisPassword
auth:
  secretStore: kubernetes
```

The `secretKeyRef` element specifies the name of the Kubernetes secret and the secret's key, `eshopsecrets`, and `redisPassword` respectively. The `auth` metadata section instructs Dapr to use the Kubernetes secrets management component.

> [!NOTE]
> Auth is the default value when using Kubernetes secrets and can be omitted.

In a production setting, secrets are typically created as part of an automated CI/CD pipeline. Doing so ensures only people with sufficient permissions can access and change the secrets. Developers create configuration files without knowing the actual value of the secrets.

### Azure Key Vault

The next example is geared toward a real-world production scenario. It uses **Azure Key Vault** as the secret store. Azure Key Vault is a managed Azure service that enables secrets to be stored securely in the cloud.

For this example to work, the following prerequisites must be satisfied:

- You've secured administrative access to an Azure subscription.
- You've provisioned an Azure Key Vault named `eshopkv` that holds a secret named `redisPassword` that contains the password for connecting to the Redis server.
- You've created [service principal](/azure/active-directory/develop/howto-create-service-principal-portal) in Azure Active Directory.
- You've installed an X509 certificate for this service principal (containing both the public and private key) on the local filesystem.

> [!NOTE]
> A service principal is an identity that can be used by an application to authenticate an Azure service. The service principal uses a X509 certificate. The application uses this certificate as a credential to authenticate itself.

The [Dapr Azure Key Vault secret store documentation](https://docs.dapr.io/operations/components/setup-secret-store/supported-secret-stores/azure-keyvault/) provides step-by-step instructions to create and configure a Key Vault environment.

#### Use Key Vault when running in self-hosted mode

Consuming Azure Key Vault in Dapr self-hosted mode requires the following configuration file:

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: eshop-azurekv-secret-store
  namespace: eshop
spec:
  type: secretstores.azure.keyvault
  version: v1
  metadata:
  - name: vaultName
    value: eshopkv
  - name: spnTenantId
    value: "619926af-a7c3-4e95-93ed-4ecc4e3e652b"
  - name: spnClientId
    value: "6cf48032-6c38-43be-9d6f-2a43ce736b09"
  - name: spnCertificateFile
    value : "azurekv-spn-cert.pfx"
```

The secret store type is `secretstores.azure.keyvault`. The `metadata` element to configure access to Key Vault requires the following properties:

- The `vaultName` contains the name of the Azure Key Vault.
- The `spnTenantId` contains the *tenant ID* of the service principal used to authenticate against the Key Vault.
- The `spnClientId` contains the *app ID* of the service principal used to authenticate against the Key Vault.
- The `spnCertificateFile` contains the path to the certificate file for the service principal to authenticate against the Key Vault.

> [!TIP]
> You can copy the service principal information from the Azure portal or Azure CLI .

Now the application can retrieve the Redis password from the Azure Key Vault.

#### Use Key Vault when running on Kubernetes

Consuming Azure Key Vault with Dapr and Kubernetes also requires a service principal to authenticate against the Azure Key Vault.

First, create a *Kubernetes secret* that contains a certificate file using the kubectl CLI tool:

```console
kubectl create secret generic [k8s_spn_secret_name] --from-file=[pfx_certificate_file_local_path] -n eshop
```

The command requires two command-line arguments:

- `[k8s_spn_secret_name]` is the secret name in Kubernetes secret store.
- `[pfx_certificate_file_local_path]` is the path of X509 certificate file.

Once created, you can reference the Kubernetes secret in the secret store component configuration file:

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: eshop-azurekv-secret-store
  namespace: eshop
spec:
  type: secretstores.azure.keyvault
  version: v1
  metadata:
  - name: vaultName
    value: [your_keyvault_name]
  - name: spnTenantId
    value: "619926af-a7c3-4e95-93ed-4ecc4e3e652b"
  - name: spnClientId
    value: "6cf48032-6c38-43be-9d6f-2a43ce736b09"
  - name: spnCertificate
    secretKeyRef:
      name: [k8s_spn_secret_name]
      key: [pfx_certificate_file_local_name]
auth:
    secretStore: kubernetes
```

At this point, an application running in Kubernetes can retrieve the Redis password from the Azure Key Vault.

> [!IMPORTANT]
> It's critical to keep the X509 certificate file for the service principal in a safe place. It's best to place it in a well-known folder outside the source-code repository. The configuration file can then reference the certificate file from this well-known folder. On a local development machine, you're responsible for copying the certificate to the folder. For automated deployments, the pipeline will copy the certificate to the machine where the application is deployed. It's a best practice to use a different service principal per environment. Doing so prevents the service principal from a DEVELOPMENT environment to access secrets in a PRODUCTION environment.

When running in  Azure Kubernetes Service (AKS), it's preferable to use an [Azure Managed Identity](/azure/active-directory/managed-identities-azure-resources/overview) for authenticating against Azure Key Vault. Managed identities are outside of the scope of this book, but explained in the [Azure Key Vault with managed identities](https://docs.dapr.io/operations/components/setup-secret-store/supported-secret-stores/azure-keyvault-managed-identity/) documentation.

### Scope secrets

Secret scopes allow you to control which secrets your application can access. You configure scopes in a Dapr sidecar configuration file. The [Dapr configuration documentation](https://docs.dapr.io/operations/configuration/configuration-overview/) provides instructions for scoping secrets.

Here's an example of a Dapr sidecar configuration file that contains secret scopes:

```yml
apiVersion: dapr.io/v1alpha1
kind: Configuration
metadata:
  name: dapr-config
  namespace: eshop
spec:
  tracing:
    samplingRate: "1"
  secrets:
    scopes:
      - storeName: eshop-azurekv-secret-store
        defaultAccess: allow
        deniedSecrets: ["redisPassword", "apiKey"]
```

You specify scopes per secret store. In the above example, the secret store is named `eshop-azurekv-secret-store`. You configure access to secrets using the following properties:

| Property         | Value               | Description                                                                                                                       |
|------------------|---------------------|-----------------------------------------------------------------------------------------------------------------------------------|
| `defaultAccess`  | `allow` or `deny`   | Allows or denies access to *all* secrets in the specified secret store. This property is optional with a default value of `allow`. |
| `allowedSecrets` | List of secret keys | Secrets specified in the array will be accessible. This property is optional.                                                     |
| `deniedSecrets`  | List of secret keys | Secrets specified in the array will NOT be accessible. This property is optional.                                                 |

The `allowedSecrets` and `deniedSecrets` properties take precedence over the `defaultAccess` property. Imagine specifying `defaultAccess: allowed` and an `allowedSecrets` list. In this case, only the secrets in the `allowedSecrets` list would be accessible by the application.

## Reference application: eShopOnDapr

The eShopOnDapr reference application uses the secrets building block for two secrets:

- The password for connecting to the Redis cache.
- The API-key for using the Twilio Sendgrid API. The application uses Twillio to send emails using a Dapr output binding (as described in the [bindings building block chapter](bindings.md)).

When running the application using Docker Compose, the **local file** secret store is used. The component configuration file `eshop-secretstore.yaml` is found in the `dapr/components` folder of the eShopOnDapr repository:

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: eshop-secretstore
  namespace: eshop
spec:
  type: secretstores.local.file
  version: v1
  metadata:
  - name: secretsFile
    value: ./components/eshop-secretstore.json
```

The configuration file references the local store file `eshop-secretstore.json` located in the same folder:

```json
{
    "redisPassword": "**********",
    "sendgridAPIKey": "**********"
}
```

The `components` folder is specified in the command-line and mounted as a local folder inside the Dapr sidecar container. Here's a snippet from the `docker-compose.override.yml` file in the repository root that specifies the volume mount:

```yaml
  ordering-backgroundtasks-dapr:
    command: ["./daprd",
      "-app-id", "ordering-backgroundtasks",
      "-app-port", "80",
      "-dapr-grpc-port", "50004",
      "-components-path", "/components",
      "-config", "/configuration/eshop-config.yaml"
      ]
    volumes:
      - "./dapr/components/:/components"
      - "./dapr/configuration/:/configuration"
```

> [!NOTE]
> The Docker Compose override file contains environmental specific configuration values.

The `/components` volume mount and `--components-path` command-line argument are passed into the `daprd` startup command.

Once configured, other component configuration files can also reference the secrets. Here's an example of the Publish/Subscribe component configuration consuming secrets:

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: pubsub
  namespace: eshop
spec:
  type: pubsub.redis
  version: v1
  metadata:
  - name: redisHost
    value: redis:6379
  - name: redisPassword
    secretKeyRef:
      name: redisPassword
auth:
  secretStore: eshop-secretstore
```

In the preceding example, the local Redis store is used to reference secrets.

## Summary

The Dapr secrets building block provides capabilities for storing and retrieving sensitive configuration settings like passwords and connection-strings. It keeps secrets private and prevents them from being accidentally disclosed.

The building block supports several different secret stores and hides their complexity with the Dapr secrets API.

The Dapr .NET SDK provides a `DaprClient` object to retrieve secrets. It also includes a .NET configuration provider that adds secrets to the .NET Core configuration system. Once loaded, you can consume these secrets in your .NET code.

You can use secret scopes to control access to specific secrets.

## References

- [Beyond the Twelve-Factor Application](https://tanzu.vmware.com/content/blog/beyond-the-twelve-factor-app)

>[!div class="step-by-step"]
>[Previous](observability.md)
>[Next](summary.md)

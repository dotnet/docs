## Create the AI service

# [Azure OpenAI](#tab/azure-openai)

Choose of the options below to create an Azure OpenAI service.

### Use the Azure Developer CLI

[!INCLUDE [deploy-azd](includes/deploy-azd.md)]

### Use the Azure portal or Azure CLI

1. To provision an Azure OpenAI service using another tool such as the Azure portal or Azure CLI, complete the steps in the [Create and deploy an Azure OpenAI Service resource](/azure/ai-services/openai/how-to/create-resource?pivots=cli) article.

1. Assign the `Azure AI Developer` role to the account you used to sign-in to Visual Studio or the Azure CLI. The sample app uses a secretless approach to connect to the Azure OpenAI service using Microsoft Entra ID and `DefaultAzureCredential`.

1. In your project directory, set the Azure OpenAI deployment model name and endpoint as user secrets:

    ```csharp
    dotnet user-secrets init
    dotnet user-secrets set AZURE_OPENAI_ENDPOINT <your-openai-key>
    dotnet user-secrets set AZURE_OPENAI_GPT_NAME <your-openai-gpt-name>
    ```

# [OpenAI](#tab/openai)

If you plan to use an OpenAI Model, this quickstart assumes you already have a service setup and available. You'll need the access key and AI service endpoint  to connect your code.

---
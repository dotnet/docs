## Create the AI service

# [Azure Developer CLI](#tab/azd)

[!INCLUDE [deploy-azd](deploy-azd.md)]

# [Azure CLI](#tab/azure-cli)

1. To provision an Azure OpenAI service and model using the Azure CLI, complete the steps in the [Create and deploy an Azure OpenAI Service resource](/azure/ai-services/openai/how-to/create-resource?pivots=cli) article.

1. From a terminal or command prompt, navigate to the root of your project directory.

1. Run the following commands to configure your Azure OpenAI endpoint and model name for the sample app:

    ```bash
    dotnet user-secrets init
    dotnet user-secrets set AZURE_OPENAI_ENDPOINT <your-azure-openai-endpoint>
    dotnet user-secrets set AZURE_OPENAI_GPT_NAME <your-azure-openai-model-name>
    ```

# [Azure Portal](#tab/azure-portal)

1. To provision an Azure OpenAI service and model using the Azure portal, complete the steps in the [Create and deploy an Azure OpenAI Service resource](/azure/ai-services/openai/how-to/create-resource?pivots=web-portal) article.

1. From a terminal or command prompt, navigate to the root of your project directory.

1. Run the following commands to configure your Azure OpenAI endpoint and model name for the sample app:

    ```bash
    dotnet user-secrets init
    dotnet user-secrets set AZURE_OPENAI_ENDPOINT <your-openai-key>
    dotnet user-secrets set AZURE_OPENAI_GPT_NAME <your-azure-openai-model-name>
    ```

---

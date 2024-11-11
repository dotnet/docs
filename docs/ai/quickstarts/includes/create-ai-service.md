## Create the AI service

# [Use the Azure Developer CLI](#tab/azd)

[!INCLUDE [deploy-azd](deploy-azd.md)]

# [Azure CLI](#tab/azure-cli)

1. To provision an Azure OpenAI service and model using the Azure CLI, complete the steps in the [Create and deploy an Azure OpenAI Service resource](/azure/ai-services/openai/how-to/create-resource?pivots=cli) article.

1. From a terminal or command prompt, navigate to the root of your project directory.

1. Run the following commands to configure your OpenAI API key as a secret for the sample app:

    ```bash
    dotnet user-secrets init
    dotnet user-secrets set OpenAIKey <your-openai-key>
    ```

# [Azure Portal](#tab/azure-portal)

1. To provision an Azure OpenAI service and model using the Azure portal, complete the steps in the [Create and deploy an Azure OpenAI Service resource](/azure/ai-services/openai/how-to/create-resource?pivots=web-portal) article.

1. From a terminal or command prompt, navigate to the root of your project directory.

1. Run the following commands to configure your OpenAI API key as a secret for the sample app:

    ```bash
    dotnet user-secrets init
    dotnet user-secrets set OpenAIKey <your-openai-key>
    ```

---

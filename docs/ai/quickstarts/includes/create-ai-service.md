## Create the AI service

1. To provision an Azure OpenAI service and model, complete the steps in the [Create and deploy an Azure OpenAI Service resource](/azure/ai-services/openai/how-to/create-resource) article.

1. From a terminal or command prompt, navigate to the root of your project directory.

1. Run the following commands to configure your Azure OpenAI endpoint and model name for the sample app:

    ```bash
    dotnet user-secrets init
    dotnet user-secrets set AZURE_OPENAI_ENDPOINT <your-Azure-OpenAI-endpoint>
    dotnet user-secrets set AZURE_OPENAI_GPT_NAME <your-Azure-OpenAI-model-name>
    ```

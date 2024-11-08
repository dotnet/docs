
## Create the app

1. In an empty directory on your computer, use the `dotnet new` command to create a new console app:

    ```dotnetcli
    dotnet new console -o ExtensionsAI
    ```

1. Change directory into the app folder:

    ```dotnetcli
    cd ExtensionsAI
    ```

1. Install the required packages:

    <!-- markdownlint-disable MD023 -->
    # [Azure OpenAI](#tab/azure-openai)

    ```bash
    dotnet add package OpenAI
    dotnet add package Microsoft.Extensions.AI
    dotnet add package Microsoft.Extensions.Configuration
    dotnet add package Microsoft.Extensions.Configuration.UserSecrets
    ```

    # [OpenAI](#tab/openai)

    ```bash
    dotnet add package Azure.AI.OpenAI
    dotnet add package Microsoft.Extensions.AI
    dotnet add package Microsoft.Extensions.Configuration
    dotnet add package Microsoft.Extensions.Configuration.UserSecrets
    ```

    ---

1. Open the app in Visual Studio code or your editor of choice

    ```bash
    code .
    ```

## Build the app

The app uses the [`Microsoft.Extensions.AI`](https://www.nuget.org/packages/Microsoft.Extensions.AI) package to send and receive requests to the OpenAI service.

1. In the **Program.cs** file, add the following code to connect and authenticate to the AI model:

    # [Azure OpenAI](#tab/azure-openai)

    > [!NOTE]
    > `DefaultAzureCredential` searches for credentials from your local environment and tooling. If you are not using the `azd` template to provision the Azure OpenAI resource, assign the `Azure AI Developer` role manually to the account you used to sign-in to Visual Studio or the Azure CLI.

    :::code language="csharp" source="../../snippets/prompt-completion/extensions-ai/azure-openai/program.cs" range="6-8":::

    # [OpenAI](#tab/openai)

    :::code language="csharp" source="../../snippets/prompt-completion/extensions-ai/openai/program.cs" range="5-7":::

    ---

1. Add the following code to create an `IChatClient` service configured to connect to the AI Model:

    # [Azure OpenAI](#tab/azure-openai)

    :::code language="csharp" source="../../snippets/prompt-completion/extensions-ai/azure-openai/program.cs" range="10-12":::

    # [OpenAI](#tab/openai)

    :::code language="csharp" source="../../snippets/prompt-completion/extensions-ai/openai/program.cs" range="10-11":::

    ---

     The `OpenAI` and `Azure.AI.OpenAI` libraries implement types defined in the `Microsoft.Extensions.AI` library, which enables you to code using the `IChatClient` interface abstraction. This abstraction allows you to change the underlying AI provider to other services by updating only a few lines of code, such as Ollama or Azure Inference models.

1. Use the `CompleteAsync` function to send a `prompt` to the model to generate a response.

    :::code language="csharp" source="../../snippets/prompt-completion/extensions-ai/openai/program.cs" range="14-22":::

Customize the text content of the `benefits.md` file or the length of the summary to see the differences in the responses.

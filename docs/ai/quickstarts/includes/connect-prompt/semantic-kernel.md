## Create the app

1. In an empty directory on your computer, use the `dotnet new` command to create a new console app:

    ```dotnetcli
    dotnet new console -o SemanticKernelAI
    ```

1. Change directory into the app folder:

    ```dotnetcli
    cd SemanticKernelAI
    ```

1. Install the required packages:

    ```bash
    dotnet add package Microsoft.SemanticKernel
    dotnet add package Microsoft.Extensions.Configuration
    dotnet add package Microsoft.Extensions.Configuration.UserSecrets
    ```

1. Open the app in Visual Studio code or your editor of choice

    ```bash
    code .
    ```

[!INCLUDE [create-ai-service](includes/create-ai-service.md)]

## Add the app code

The app uses the [`Microsoft.SemanticKernel`](https://www.nuget.org/packages/Microsoft.SemanticKernel) package to send and receive requests to the OpenAI service.

1. In the **Program.cs** file, add the following code to connect and authenticate to the AI model.
    <!-- markdownlint-disable MD023 -->
    # [Azure OpenAI](#tab/azure-openai)

    :::code language="csharp" source="../../snippets/prompt-completion/semantic-kernel/azure-openai/program.cs" range="6-14":::

    > [!NOTE]
    > `DefaultAzureCredential` searches for credentials from  your local tooling. If you are not using the `azd` template to provision the Azure OpenAI resource, you'll need to assign the `Azure AI Developer` role to the account you used to sign-in to Visual Studio or the Azure CLI.

    # [OpenAI](#tab/openai)

    :::code language="csharp" source="../../snippets/prompt-completion/semantic-kernel/openai/program.cs" range="5-13":::

    ---

1. Read the `benefits.md` file content and use it to create a `prompt` for model. The prompt instructs the model to summarize the file text content.

    :::code language="csharp" source="../../snippets/prompt-completion/semantic-kernel/openai/program.cs" range="15-20":::

1. Call the `InvokePromptAsync` function to send the `prompt` to the model to generate a response.

    :::code language="csharp" source="../../snippets/prompt-completion/semantic-kernel/openai/program.cs" range="22-24":::

    Customize the text content of the `benefits.md` file or the length of the summary to see the differences in the responses.
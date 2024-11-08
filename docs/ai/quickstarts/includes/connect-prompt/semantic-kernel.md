In this quickstart, get started with AI by creating a .NET console chat app to connect to and prompt an OpenAI or Azure OpenAI model. The app runs locally and uses the [Semantic Kernel](/semantic-kernel/overview/) SDK.

## Prerequisites

# [Azure OpenAI](#tab/azure-openai)

[!INCLUDE [azure-openai-prereqs](includes/prerequisites-azure-openai.md)]

# [OpenAI](#tab/openai)

[!INCLUDE [openai-prereqs](includes/prerequisites-openai.md)]

---

## Get the sample project

[!INCLUDE [clone-sample-repo](includes/clone-sample-repo.md)]

## Try the hiking benefits sample

# [OpenAI](#tab/openai)

1. From a terminal or command prompt, navigate to the `src\quickstarts\semantic-kernel\openai\01-HikeBenefitsSummary` directory.

1. Run the following commands to configure your OpenAI API key as a secret for the sample app:

    ```bash
    dotnet user-secrets init
    dotnet user-secrets set OpenAIKey <your-openai-key>
    ```

1. Use the `dotnet run` command to run the app:

    ```dotnetcli
    dotnet run
    ```

# [Azure OpenAI](#tab/azure-openai)

1. From a terminal or command prompt, navigate to the `src\quickstarts\semantic-kernel\azure-openai\01-HikeBenefitsSummary` directory.

    > [!NOTE]
    > The Azure OpenAI scenario assumes the use of `azd` to provision an Azure OpenAI resource and configure essential permissions. Your can also [provision an Azure OpenAI resource](/azure/ai-services/openai/how-to/create-resource) using another tool such as the Azure portal or Azure CLI.

1. Run the `azd up` command to provision the Azure OpenAI resource using the [Azure Developer CLI](/developer/azure-developer-cli/overview). `azd` provisions the Azure OpenAI resources and configures permissions for you.

1. Use the `dotnet run` command to run the app:

    ```dotnetcli
    dotnet run
    ```

---

## Explore the code

The app uses the [`Microsoft.SemanticKernel`](https://www.nuget.org/packages/Microsoft.SemanticKernel) package to send and receive requests to the OpenAI service.

The **Program.cs** file contains all of the app code. The first several lines of code set configuration values and get the OpenAI Key that was previously set using the `dotnet user-secrets` command. The `Kernel` class facilitates the requests and responses and registers an `OpenAIChatCompletion` service.

# [OpenAI](#tab/openai)

:::code language="csharp" source="./snippets/prompt-completion/semantic-kernel/openai/program.cs" range="5-13":::

# [Azure OpenAI](#tab/azure-openai)

> [!NOTE]
> `DefaultAzureCredential` searches for credentials from  your local tooling. If you are not using the `azd` template to provision the Azure OpenAI resource, you'll need to assign the `Azure AI Developer` role to the account you used to sign-in to Visual Studio or the Azure CLI.

:::code language="csharp" source="./snippets/prompt-completion/semantic-kernel/azure-openai/program.cs" range="6-14":::

---

Once the `Kernel` is created, the app code reads the `benefits.md` file content and uses it to create a `prompt` for model. The prompt instructs the model to summarize the file text content.

:::code language="csharp" source="./snippets/prompt-completion/semantic-kernel/openai/program.cs" range="15-20":::

The `InvokePromptAsync` function sends the `prompt` to the model to generate a response.

:::code language="csharp" source="./snippets/prompt-completion/semantic-kernel/openai/program.cs" range="22-24":::

Customize the text content of the `benefits.md` file or the length of the summary to see the differences in the responses.

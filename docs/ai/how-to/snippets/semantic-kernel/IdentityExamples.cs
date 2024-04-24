using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

class IdentityExamples
{
    public static async Task Examples()
    {
        await ManagedIdentityExample();
    }

    static async Task ManagedIdentityExample()
    {
        // <tokenCredential>
        // Initialize a DefaultAzureCredential.
        // This credential type will try several authentication flows in order until one is available.
        // Will pickup Visual Studio or Azure CLI credentials in local environments.
        // Will pickup managed identity credentials in production deployments.
        TokenCredential credentials = new DefaultAzureCredential(
            new DefaultAzureCredentialOptions
            {
                // If using a user-assigned identity specify either:
                // ManagedIdentityClientId or ManagedIdentityResourceId.
                // e.g.: ManagedIdentityClientId = "myIdentityClientId".
            }
        );
        // </tokenCredential>

        // <kernelBuild>
        // Retrieve the endpoint and deployment obtained from the Azure OpenAI deployment.
        // Must use the deployment name not the underlying model name.
        IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        string endpoint = config["AZURE_OPENAI_ENDPOINT"]!;
        string deployment = config["AZURE_OPENAI_GPT_NAME"]!;

        // Build a Kernel that includes the Azure OpenAI Chat Completion Service.
        // Include the previously created token credential.
        Kernel kernel = Kernel
            .CreateBuilder()
            .AddAzureOpenAIChatCompletion(deployment, endpoint, credentials)
            .Build();
        // </kernelBuild>

        // <invokePrompt>
        // Use the Kernel to invoke prompt completion through Azure OpenAI.
        // The Kernel response will be null if the model can't be reached.
        string? result = await kernel.InvokePromptAsync<string>("Please list three Azure services");
        Console.WriteLine($"Output: {result}");

        // Continue sending and receiving messages between the user and AI.
        // ...
        // </invokePrompt>
    }
}

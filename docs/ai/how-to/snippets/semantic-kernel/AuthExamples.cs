using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

class AuthExamples
{
    public static void Examples()
    {
        OpenAIAuthExample();
        AoaiApiKeyAuthExample();
        AoaiTokenAuthExample();
    }

    static (Kernel, IChatCompletionService) OpenAIAuthExample()
    {
        // <openai-auth>
        // === Retrieve the secrets saved when signing up for OpenAI ===
        var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        var model = config["OPENAI_GPT_NAME"];
        var key = config["OPENAI_API_KEY"];

        // === Create a Kernel containing the OpenAI Chat Completion Service ===
        var kernel = Kernel.CreateBuilder()
            .AddOpenAIChatCompletion(model, key)
            .Build();

        // === Alternatively, directly create the OpenAI Chat Completion Service ===
        var service = new OpenAIChatCompletionService(model, key);
        // </openai-auth>
        
        return (kernel, service);
    }

    static (Kernel, IChatCompletionService) AoaiApiKeyAuthExample()
    {
        // <aoai-api-key-auth>
        // === Retrieve the secrets obtained from the Azure deployment ===
        // Must use the deployment name not the underlying model name
        var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        var endpoint = config["AZURE_OPENAI_ENDPOINT"];
        var deployment = config["AZURE_OPENAI_GPT_NAME"];
        var key = config["AZURE_OPENAI_KEY"];

        // === Create a Kernel containing the AOAI Chat Completion Service ===
        var kernel = Kernel.CreateBuilder()
            .AddAzureOpenAIChatCompletion(deployment, endpoint, key)
            .Build();

        // === Alternatively, directly create the AOAI Chat Completion Service ===
        var service = new AzureOpenAIChatCompletionService(deployment, endpoint, key);
        // </aoai-api-key-auth>

        return (kernel, service);
    }

        static (Kernel, IChatCompletionService) AoaiTokenAuthExample()
    {
        // <aoai-token-auth>
        // === Retrieve the secrets obtained from the Azure deployment ===
        // Must use the deployment name not the underlying model name
        var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        var endpoint = config["AZURE_OPENAI_ENDPOINT"];
        var deployment = config["AZURE_OPENAI_GPT_NAME"];

        // === Create a TokenCredential instance, e.g. DefaultAzureCredential, ManagedIdentityCredential, EnvironmentCredential, etc.
        TokenCredential credentials = new DefaultAzureCredential(new DefaultAzureCredentialOptions
        {
            // Credential options, e.g., TenantID, ManagedIdentityClientId, etc.
        });

        // === Create a Kernel containing the AOAI Chat Completion Service ===
        var kernel = Kernel.CreateBuilder()
            .AddAzureOpenAIChatCompletion(deployment, endpoint, credentials)
            .Build();

        // === Alternatively, directly create the AOAI Chat Completion Service ===
        var service = new AzureOpenAIChatCompletionService(deployment, endpoint, credentials);
        // </aoai-token-auth>

        return (kernel, service);
    }
}
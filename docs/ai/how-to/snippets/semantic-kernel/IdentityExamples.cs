using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.AzureAISearch;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.Connectors.Redis;
using Microsoft.SemanticKernel.Memory;
using Microsoft.SemanticKernel.Plugins.Memory;
using StackExchange.Redis;

// Supress warning about AzureAISearchMemoryStore still being in evaluation
#pragma warning disable SKEXP0020

// Suppress warning about MemoryStore still being in evaluation
#pragma warning disable SKEXP0001

// Suppress warning about MemoryBuilder extensions still being in evaluation
#pragma warning disable SKEXP0010

// Supress warning about TextMemoryPlugin still being in evaluation
#pragma warning disable SKEXP0050

class IdentityExamples
{
    public static async Task Examples()
    {
        await ManagedIdentityExample();
        await AiSearchExample();
        await RedisKeyVaultExample();
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

    static async Task AiSearchExample()
    {
        TokenCredential credentials = new DefaultAzureCredential();

        // <aiStore>
        // Retrieve the endpoint obtained from the Azure AI Search deployment.
        // Retrieve the endpoint and deployments obtained from the Azure OpenAI deployment.
        // Must use the deployment name not the underlying model name.
        IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        string searchEndpoint = config["AZURE_AISEARCH_ENDPOINT"]!;
        string openAiEndpoint = config["AZURE_OPENAI_ENDPOINT"]!;
        string embeddingModel = config["AZURE_OPENAI_EMBEDDING_NAME"]!;

        // The Semantic Kernel SDK provides a connector extension for Azure AI Search.
        // Initialize an AzureAISearchMemoryStore using your managed identity credentials.
        IMemoryStore memoryStore = new AzureAISearchMemoryStore(searchEndpoint, credentials);

        // Build a SemanticMemoryStore with Azure AI Search as the store.
        // Must also include a text embedding generation service.
        ISemanticTextMemory memory = new MemoryBuilder()
            .WithAzureOpenAITextEmbeddingGeneration(embeddingModel, openAiEndpoint, credentials)
            .WithMemoryStore(memoryStore)
            .Build();
        // </aiStore>

        // <addMemory>
        // Build a Kernel, include a chat completion service.
        string chatModel = config["AZURE_OPENAI_GPT_NAME"]!;
        Kernel kernel = Kernel
            .CreateBuilder()
            .AddAzureOpenAIChatCompletion(chatModel, openAiEndpoint, credentials)
            .Build();

        // Import the semantic memory store as a TextMemoryPlugin.
        // The TextMemoryPlugin enable recall via prompt expressions.
        kernel.ImportPluginFromObject(new TextMemoryPlugin(memory));
        // </addMemory>

        // <useMemory>
        // Must configure the memory collection, number of memories to recall, and relevance score.
        // The {{...}} syntax represents an expression to Semantic Kernel.
        // For more information on this syntax see:
        // https://learn.microsoft.com/semantic-kernel/prompts/prompt-template-syntax
        string memoryCollection = config["AZURE_OPENAI_MEMORY_NAME"]!;
        string? result = await kernel.InvokePromptAsync<string>(
            "{{recall 'where did I grow up?'}}",
            new()
            {
                [TextMemoryPlugin.CollectionParam] = memoryCollection,
                [TextMemoryPlugin.LimitParam] = "2",
                [TextMemoryPlugin.RelevanceParam] = "0.79",
            }
        );
        Console.WriteLine($"Output: {result}");
        // </useMemory>
    }

    static async Task RedisKeyVaultExample()
    {
        TokenCredential credentials = new DefaultAzureCredential();

        // <vaultConfig>
        // User secrets let you provide connection strings when testing locally
        // For more info see: https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .AddAzureKeyVault(new Uri("{vaultURI}"), credentials)
            .Build();

        // Retrieve the Redis connection string obtained from the Key Vault.
        string redisConnectionString = config["AZURE_REDIS_CONNECT_STRING"]!;
        // </vaultConfig>

        // <redisStore>
        // Use the connection string to connect to the database
        IDatabase database = (
            await ConnectionMultiplexer.ConnectAsync(redisConnectionString)
        ).GetDatabase();

        // The Semantic Kernel SDK provides a connector extension for Redis.
        // Initialize an RedisMemoryStore using your managed identity credentials.
        IMemoryStore memoryStore = new RedisMemoryStore(database);

        // Retrieve the endpoint and deployments obtained from the Azure OpenAI deployment.
        // Must use the deployment name not the underlying model name.
        string openAiEndpoint = config["AZURE_OPENAI_ENDPOINT"]!;
        string embeddingModel = config["AZURE_OPENAI_EMBEDDING_NAME"]!;

        // Build a SemanticMemoryStore with Azure AI Search as the store.
        // Must also include a text embedding generation service.
        ISemanticTextMemory memory = new MemoryBuilder()
            .WithAzureOpenAITextEmbeddingGeneration(embeddingModel, openAiEndpoint, credentials)
            .WithMemoryStore(memoryStore)
            .Build();
        // </redisStore>
    }

    static async Task RedisAppSettingsExample()
    {
        // <appSettingsConfig>
        // User secrets let you provide connection strings when testing locally
        // For more info see: https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables()
            .Build();

        // Retrieve the Redis connection string obtained from the app settings.
        // App settings are prefixed with "APPSETTING_"
        string redisConnectionString = config["APPSETTING_AZURE_REDIS_CONNECT_STRING"]!;
        // </appSettingsConfig>
    }
}

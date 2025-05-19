---
title: Tutorial - Integrate OpenAI with the RAG pattern and vector search using Azure Cosmos DB for MongoDB
description: Create a simple recipe app using the RAG pattern and vector search using Azure Cosmos DB for MongoDB.
ms.date: 11/24/2024
ms.topic: tutorial
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: alexwolfmsft
ms.author: alexwolf
---

# Implement Azure OpenAI with RAG using vector search in a .NET app

This tutorial explores integration of the RAG pattern using Open AI models and vector search capabilities in a .NET app. The sample application performs vector searches on custom data stored in Azure Cosmos DB for MongoDB and further refines the responses using generative AI models, such as GPT-35 and GPT-4. In the sections that follow, you'll set up a sample application and explore key code examples that demonstrate these concepts.

## Prerequisites

- [.NET 8.0 installed](https://dotnet.microsoft.com/)
- An [Azure Account](https://azure.microsoft.com/free)
- An [Azure Cosmos DB for MongoDB vCore](/azure/cosmos-db/mongodb/vcore/introduction) service
- An [Azure Open AI](/azure/ai-services/openai/overview) service
  - Deploy `text-embedding-ada-002` model for embeddings
  - Deploy `gpt-35-turbo` model for chat completions

## App overview

The Cosmos Recipe Guide app allows you to perform vector and AI driven searches against a set of recipe data. You can search directly for available recipes or prompt the app with ingredient names to find related recipes. The app and the sections ahead guide you through the following workflow to demonstrate this type of functionality:

1. Upload sample data to an Azure Cosmos DB for MongoDB database.
1. Create embeddings and a vector index for the uploaded sample data using the Azure OpenAI `text-embedding-ada-002` model.
1. Perform vector similarity search based on the user prompts.
1. Use the Azure OpenAI `gpt-35-turbo` completions model to compose more meaningful answers based on the search results data.

    :::image type="content" source="../media/get-started-app-chat-template/contoso-recipes.png" alt-text="A screenshot showing the running sample app.":::

## Get started

1. Clone the following GitHub repository:

    ```bash
    git clone https://github.com/microsoft/AzureDataRetrievalAugmentedGenerationSamples.git
    ```

1. In the _C#/CosmosDB-MongoDBvCore_ folder, open the **CosmosRecipeGuide.sln** file.

1. In the _appsettings.json_ file, replace the following config values with your Azure OpenAI and Azure CosmosDB for MongoDb values:

    ```json
    "OpenAIEndpoint": "https://<your-service-name>.openai.azure.com/",
    "OpenAIKey": "<your-API-key>",
    "OpenAIEmbeddingDeployment": "<your-ADA-deployment-name>",
    "OpenAIcompletionsDeployment": "<your-GPT-deployment-name>",
    "MongoVcoreConnection": "<your-Mongo-connection-string>"
    ```

1. Launch the app by pressing the **Start** button at the top of Visual Studio.

## Explore the app

When you run the app for the first time, it connects to Azure Cosmos DB and reports that there are no recipes available yet. Follow the steps displayed by the app to begin the core workflow.

1. Select **Upload recipe(s) to Cosmos DB** and press <kbd>Enter</kbd>. This command reads sample JSON files from the local project and uploads them to the Cosmos DB account.

    The code from the _Utility.cs_ class parses the local JSON files.

    ``` C#
    public static List<Recipe> ParseDocuments(string Folderpath)
    {
        List<Recipe> recipes = new List<Recipe>();

        Directory.GetFiles(Folderpath)
            .ToList()
            .ForEach(f =>
            {
                var jsonString= System.IO.File.ReadAllText(f);
                Recipe recipe = JsonConvert.DeserializeObject<Recipe>(jsonString);
                recipe.id = recipe.name.ToLower().Replace(" ", "");
                ret.Add(recipe);
            }
        );

        return recipes;
    }
    ```

    The `UpsertVectorAsync` method in the _VCoreMongoService.cs_ file uploads the documents to Azure Cosmos DB for MongoDB.

    ```C#
    public async Task UpsertVectorAsync(Recipe recipe)
        {
            BsonDocument document = recipe.ToBsonDocument();

            if (!document.Contains("_id"))
            {
                Console.WriteLine("UpsertVectorAsync: Document does not contain _id.");
                throw new ArgumentException("UpsertVectorAsync: Document does not contain _id.");
            }

            string? _idValue = document["_id"].ToString();

            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("_id", _idValue);
                var options = new ReplaceOptions { IsUpsert = true };
                await _recipeCollection.ReplaceOneAsync(filter, document, options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: UpsertVectorAsync(): {ex.Message}");
                throw;
            }
        }
    ```

1. Select **Vectorize the recipe(s) and store them in Cosmos DB**.

    The JSON items uploaded to Cosmos DB do not contain embeddings and therefore are not optimized for RAG via vector search. An embedding is an information-dense, numerical representation of the semantic meaning of a piece of text. Vector searches are able to find items with contextually similar embeddings.

    The `GetEmbeddingsAsync` method in the _OpenAIService.cs_ file creates an embedding for each item in the database.

    ```C#
    public async Task<float[]?> GetEmbeddingsAsync(dynamic data)
    {
        try
        {
            EmbeddingsOptions options = new EmbeddingsOptions(data)
            {
                Input = data
            };

            var response = await _openAIClient.GetEmbeddingsAsync(openAIEmbeddingDeployment, options);

            Embeddings embeddings = response.Value;
            float[] embedding = embeddings.Data[0].Embedding.ToArray();

            return embedding;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"GetEmbeddingsAsync Exception: {ex.Message}");
            return null;
        }
    }
    ```

    The `CreateVectorIndexIfNotExists` in the _VCoreMongoService.cs_ file creates a vector index, which enables you to perform vector similarity searches.

    ```C#
    public void CreateVectorIndexIfNotExists(string vectorIndexName)
    {
        try
        {
            //Find if vector index exists in vectors collection
            using (IAsyncCursor<BsonDocument> indexCursor = _recipeCollection.Indexes.List())
            {
                bool vectorIndexExists = indexCursor.ToList().Any(x => x["name"] == vectorIndexName);
                if (!vectorIndexExists)
                {
                    BsonDocumentCommand<BsonDocument> command = new BsonDocumentCommand<BsonDocument>(
                        BsonDocument.Parse(@"
                            { createIndexes: 'Recipe',
                                indexes: [{
                                name: 'vectorSearchIndex',
                                key: { embedding: 'cosmosSearch' },
                                cosmosSearchOptions: {
                                    kind: 'vector-ivf',
                                    numLists: 5,
                                    similarity: 'COS',
                                    dimensions: 1536 }
                                }]
                            }"));

                    BsonDocument result = _database.RunCommand(command);
                    if (result["ok"] != 1)
                    {
                        Console.WriteLine("CreateIndex failed with response: " + result.ToJson());
                    }
                }
            }
        }
        catch (MongoException ex)
        {
            Console.WriteLine("MongoDbService InitializeVectorIndex: " + ex.Message);
            throw;
        }
    }
    ```

1. Select the **Ask AI Assistant (search for a recipe by name or description, or ask a question)** option in the application to run a user query.

   The user query is converted to an embedding using the Open AI service and the embedding model. The embedding is then sent to Azure Cosmos DB for MongoDB and is used to perform a vector search. The `VectorSearchAsync` method in the _VCoreMongoService.cs_ file performs a vector search to find vectors that are close to the supplied vector and returns a list of documents from Azure Cosmos DB for MongoDB vCore.

    ```C#
    public async Task<List<Recipe>> VectorSearchAsync(float[] queryVector)
        {
            List<string> retDocs = new List<string>();
            string resultDocuments = string.Empty;

            try
            {
                //Search Azure Cosmos DB for MongoDB vCore collection for similar embeddings
                //Project the fields that are needed
                BsonDocument[] pipeline = new BsonDocument[]
                {
                    BsonDocument.Parse(
                        @$"{{$search: {{
                                cosmosSearch:
                                    {{ vector: [{string.Join(',', queryVector)}],
                                       path: 'embedding',
                                       k: {_maxVectorSearchResults}}},
                                       returnStoredSource:true
                                    }}
                                }}"),
                    BsonDocument.Parse($"{{$project: {{embedding: 0}}}}"),
                };

                var bsonDocuments = await _recipeCollection
                    .Aggregate<BsonDocument>(pipeline).ToListAsync();

                var recipes = bsonDocuments
                    .ToList()
                    .ConvertAll(bsonDocument =>
                        BsonSerializer.Deserialize<Recipe>(bsonDocument));
                return recipes;
            }
            catch (MongoException ex)
            {
                Console.WriteLine($"Exception: VectorSearchAsync(): {ex.Message}");
                throw;
            }
        }
    ```

   The `GetChatCompletionAsync` method generates an improved chat completion response based on the user prompt and the related vector search results.

    ``` C#
    public async Task<(string response, int promptTokens, int responseTokens)> GetChatCompletionAsync(string userPrompt, string documents)
    {
        try
        {
            ChatMessage systemMessage = new ChatMessage(
                ChatRole.System, _systemPromptRecipeAssistant + documents);
            ChatMessage userMessage = new ChatMessage(
                ChatRole.User, userPrompt);

            ChatCompletionsOptions options = new()
            {
                Messages =
                {
                    systemMessage,
                    userMessage
                },
                MaxTokens = openAIMaxTokens,
                Temperature = 0.5f, //0.3f,
                NucleusSamplingFactor = 0.95f,
                FrequencyPenalty = 0,
                PresencePenalty = 0
            };

            Azure.Response<ChatCompletions> completionsResponse =
                await openAIClient.GetChatCompletionsAsync(openAICompletionDeployment, options);
            ChatCompletions completions = completionsResponse.Value;

            return (
                response: completions.Choices[0].Message.Content,
                promptTokens: completions.Usage.PromptTokens,
                responseTokens: completions.Usage.CompletionTokens
            );

        }
        catch (Exception ex)
        {
            string message = $"OpenAIService.GetChatCompletionAsync(): {ex.Message}";
            Console.WriteLine(message);
            throw;
        }
    }
    ```

   The app also uses prompt engineering to ensure Open AI service limits and formats the response for supplied recipes.

    ```C#
    //System prompts to send with user prompts to instruct the model for chat session
    private readonly string _systemPromptRecipeAssistant = @"
        You are an intelligent assistant for Contoso Recipes.
        You are designed to provide helpful answers to user questions about
        recipes, cooking instructions provided in JSON format below.

        Instructions:
        - Only answer questions related to the recipe provided below.
        - Don't reference any recipe not provided below.
        - If you're unsure of an answer, say ""I don't know"" and recommend users search themselves.
        - Your response  should be complete.
        - List the Name of the Recipe at the start of your response followed by step by step cooking instructions.
        - Assume the user is not an expert in cooking.
        - Format the content so that it can be printed to the Command Line console.
        - In case there is more than one recipe you find, let the user pick the most appropriate recipe.";
     ```

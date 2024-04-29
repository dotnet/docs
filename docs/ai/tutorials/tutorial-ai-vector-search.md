---
title: Tutorial - Integrate OpenAI with the RAG pattern and vector search using Azure Cosmos DB for MongoDB
description: Create a simple recipe app using the RAG pattern and vector search using Azure Cosmos DB for MongoDB.
ms.date: 04/26/2024
ms.topic: tutorial
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
author: alexwolfmsft
ms.author: alexwolf
---

# Use RAG and vector search with Azure Cosmos DB for MongoDB

This tutorial explores the integration of the RAG pattern using Open AI models and vector search capabilities. The sample application performs vector searches against custom data stored in Cosmos DB for MongoDB and further refines the responses using generative AI models, such as GPT-35 and GPT-4. In the sections ahead, you'll setup a sample application and explore key code examples that demonstrates these concepts.

## Prerequsites

- [.NET 8.0 installed]()
- An Azure Account
- Azure Cosmos DB for MongoDB vCore Account
- Azure Open AI Service
    - Deploy text-davinci-003 model for embeddings
    - Deploy gpt-35-turbo model for chat completions

## App overview

The Cosmos Recipe Guide app allows you to perform vector and AI driven searches against a set of recipe data. You can search directly for available recipes or prompt the app with ingredient names to find related recipes. The app guides you through the following workflow to demonstrate this type of functionality:

1. Upload sample data to an Azure Cosmos DB for MongoDB database
1. Create embeddings from the uploaded sample data using an Azure OpenAI embeddings model (text-embedding-ada-003)
1. Create a vector index on the generated embeddings
1. Perform vector similarity search based on the user prompts
1. Use an Azure OpenAI completions model (GPT-35) to compose a more meaningful answer based on the search results data

The sections ahead explore these steps in more detail.

## Get started

1. Clone the following GitHub repository:

    ```bash
    git clone https://github.com/microsoft/AzureDataRetrievalAugmentedGenerationSamples.git
    ```

1. In the **C#/CosmosDB-MongoDBvCore** folder, open the **CosmosRecipeGuide.sln** file.

1. In the _appsettings.json_ file, replace the following config values with your Azure OpenAI and Azure CosmosDB for MongoDb values:

    ```json
    "OpenAIEndpoint": "https://<your-service-name>.openai.azure.com/",
    "OpenAIKey": "<your-api-key>",
    "OpenAIEmbeddingDeployment": "<your-ada-deployment-name>",
    "OpenAIcompletionsDeployment": "<your-gpt-deployment-name>",
    "MongoVcoreConnection": "<your-mongo-connection-string>"
    ```

1. Launch the app by pressing the start button at the top of Visual Studio.

## Explore the app

When you run the app for the first time, it connects to Cosmos DB and report that there are no recipes available yet. To begin, follow the steps displayed by the app.

1. Select **Upload Documents to Cosmos DB:** and hit enter. This option reads documents from the local project and uploads the JSON files to the Cosmos DB NoSQL account.

    The code from the _Utility.cs_ class parses the local JSON files:

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

    The `UpsertVectorAsync` method in the _VCoreMongoService.cs_ file uploads the documents to Azure Cosmos DB for MongoDB;

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

1. Select **Vectorize and Upload Recipes to Azure Cosmos DB for MongoDB vCore:**.

    The JSON data uploaded to Cosmos DB is not optimized for efficient integration with Open AI. To use the RAG pattern, the app must be able to find contextually relevant recipes from Cosmos DB. The `CreateVectorIndexIfNotExists` in the _VCoreMongoService.cs_ file creates an embedding for each item in the database to utilize the vector search capability in Azure Cosmos DB for MongoDB vCore.

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
                            cosmosSearchOptions: { kind: 'vector-ivf', numLists: 5, similarity: 'COS', dimensions: 1536 } 
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

1. Select the **Perform Search:** option in the application to run a user query. 

    The user query is converted to an embedding using the Open AI service. The embedding is then sent to Azure Cosmos DB for MongoDB vCore to perform a vector search. The `VectorSearchAsync` method in the _VCoreMongoService.cs_ file performs a vector search to find vectors that are close to the supplied vector and returns a list of documents from Azure Cosmos DB for MongoDB vCore.

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
                    BsonDocument.Parse($"{{$search: {{cosmosSearch: {{ vector: [{string.Join(',', queryVector)}], path: 'embedding', k: {_maxVectorSearchResults}}}, returnStoredSource:true}}}}"),
                    BsonDocument.Parse($"{{$project: {{embedding: 0}}}}"),
                };

                var bsonDocuments = await _recipeCollection.Aggregate<BsonDocument>(pipeline).ToListAsync();

                var recipes = bsonDocuments.ToList().ConvertAll(bsonDocument => BsonSerializer.Deserialize<Recipe>(bsonDocument)); 
                return recipes;
            }
            catch (MongoException ex)
            {
                Console.WriteLine($"Exception: VectorSearchAsync(): {ex.Message}");
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
        - Only answer questions related to the recipe provided below,
        - Don't reference any recipe not provided below.
        - If you're unsure of an answer, you can say ""I don't know"" or ""I'm not sure"" and recommend users search themselves.        
        - Your response  should be complete. 
        - List the Name of the Recipe at the start of your response folowed by step by step cooking instructions
        - Assume the user is not an expert in cooking.
        - Format the content so that it can be printed to the Command Line console;
        - In case there are more than one recipes you find let the user pick the most appropiate recipe.";
     ```

    The `GetChatCompletionAsync` method generates a chat completion based on the prompt and the vector search results:

    ``` C#
    public async Task<(string response, int promptTokens, int responseTokens)> GetChatCompletionAsync(string userPrompt, string documents)
    {

        try
        {

            ChatMessage systemMessage = new ChatMessage(ChatRole.System, _systemPromptRecipeAssistant + documents);
            ChatMessage userMessage = new ChatMessage(ChatRole.User, userPrompt);


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

            Azure.Response<ChatCompletions> completionsResponse = await openAIClient.GetChatCompletionsAsync(openAICompletionDeployment, options);

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

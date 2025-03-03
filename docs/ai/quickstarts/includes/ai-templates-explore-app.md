The sample app you created is a Blazor Interactive Server web app preconfigured with common AI and data services. The app handles the following concerns for you:

- Includes essential `Microsoft.Extensions.AI` packages and other dependencies in the `csproj` file to help you get started working with AI.
- Creates various AI services and registers them for dependency injection in the `Program.cs` file:
  - An `IChatClient` service to chat back and forth with the generative AI model
  - An `IEmbeddingGenerator` service that's used to generate embeddings, which are essential for vector search functionality
  - A `JsonVectorStore` to act as an in-memory vector store
- Registers a SQLite database context service to handle ingesting documents. The app is preconfigured to ingest whatever documents you add to the `Data` folder of the project, including the provided example files.
- Provides a complete chat UI using Blazor components. The UI handles rich formatting for the AI responses and provides features such as citations for response data.

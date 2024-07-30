---
author: alexwolfmsft
ms.author: alexwolf
ms.date: 07/29/2024
ms.topic: include
---

AI applications often use data vector databases and services to improve relevancy and provide customized functionality. Many of these services provide a native SDK for .NET, while others provide a REST service you can connect to through custom code. Semantic Kernel provides an extensible component model that enables you to use different vector stores without needing to learn each SDK.

Semantic Kernel provides connectors for the following vector databases and services:

- [Vector Database in Azure Cosmos DB for NoSQL](https://github.com/microsoft/semantic-kernel/tree/main/dotnet/src/Connectors/Connectors.Memory.AzureCosmosDBNoSQL)
- [Vector Database in vCore-based Azure Cosmos DB for MongoDB](https://github.com/microsoft/semantic-kernel/tree/main/dotnet/src/Connectors/Connectors.Memory.AzureCosmosDBMongoDB)
- [Azure AI Search](https://github.com/microsoft/semantic-kernel/tree/main/dotnet/src/Connectors/Connectors.Memory.AzureAISearch)
- [Azure PostgreSQL Server](https://github.com/microsoft/semantic-kernel/tree/main/dotnet/src/Connectors/Connectors.Memory.Postgres)
- [Azure SQL Database](https://github.com/kbeaugrand/SemanticKernel.Connectors.Memory.SqlServer)
- [Chroma](https://github.com/microsoft/semantic-kernel/tree/main/dotnet/src/Connectors/Connectors.Memory.Chroma)
- [DuckDB](https://github.com/microsoft/semantic-kernel/tree/main/dotnet/src/Connectors/Connectors.Memory.DuckDB)
- [Milvus](https://github.com/microsoft/semantic-kernel/tree/main/dotnet/src/Connectors/Connectors.Memory.Milvus)
- [MongoDB Atlas Vector Search](https://github.com/microsoft/semantic-kernel/tree/main/dotnet/src/Connectors/Connectors.Memory.MongoDB)
- [Pinecone](https://github.com/microsoft/semantic-kernel/tree/main/dotnet/src/Connectors/Connectors.Memory.Pinecone)
- [Postgres](https://github.com/microsoft/semantic-kernel/tree/main/dotnet/src/Connectors/Connectors.Memory.Postgres)
- [Qdrant](https://github.com/microsoft/semantic-kernel/tree/main/dotnet/src/Connectors/Connectors.Memory.Qdrant)
- [Redis](https://github.com/microsoft/semantic-kernel/tree/main/dotnet/src/Connectors/Connectors.Memory.Redis)
- [Sqlite](https://github.com/microsoft/semantic-kernel/tree/main/dotnet/src/Connectors/Connectors.Memory.Sqlite)
- [Weaviate](https://github.com/microsoft/semantic-kernel/tree/main/dotnet/src/Connectors/Connectors.Memory.Weaviate)

 Visit the documentation for each respective service to discover .NET SDK and API support.

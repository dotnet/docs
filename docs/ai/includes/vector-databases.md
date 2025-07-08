---
author: alexwolfmsft
ms.author: alexwolf
ms.date: 07/29/2024
ms.topic: include
---

AI applications often use data vector databases and services to improve relevancy and provide customized functionality. Many of these services provide a native SDK for .NET, while others offer a REST service you can connect to through custom code. Semantic Kernel provides an extensible component model that enables you to use different vector stores without needing to learn each SDK.

Semantic Kernel provides connectors for the following vector databases and services:

| Vector service                | Semantic Kernel connector | .NET SDK |
|-------------------------------|---------------------------|----------|
| Azure AI Search               | [Microsoft.SemanticKernel.Connectors.AzureAISearch](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.AzureAISearch)        | [Azure.Search.Documents](https://www.nuget.org/packages/Azure.Search.Documents/)        |
| Azure Cosmos DB for NoSQL     | [Microsoft.SemanticKernel.Connectors.AzureCosmosDBNoSQL](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.AzureCosmosDBNoSQL)        | [Microsoft.Azure.Cosmos](https://www.nuget.org/packages/Microsoft.Azure.Cosmos/)        |
| Azure Cosmos DB for MongoDB   | [Microsoft.SemanticKernel.Connectors.AzureCosmosDBMongoDB](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.AzureCosmosDBMongoDB)        | [MongoDb.Driver](https://www.nuget.org/packages/MongoDB.Driver)        |
| Azure PostgreSQL Server       | [Microsoft.SemanticKernel.Connectors.Postgres](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.Postgres)                  | [Npgsql](https://www.nuget.org/packages/Npgsql/)        |
| Azure SQL Database            | [Microsoft.SemanticKernel.Connectors.SqlServer](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.SqlServer)                | [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient)        |
| Chroma                        | [Microsoft.SemanticKernel.Connectors.Chroma](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.Chroma)                        | NA        |
| DuckDB                        | [Microsoft.SemanticKernel.Connectors.DuckDB](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.DuckDB)                        | [DuckDB.NET.Data.Full](https://www.nuget.org/packages/DuckDB.NET.Data.Full)        |
| Milvus                        | [Microsoft.SemanticKernel.Connectors.Milvus](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.Milvus)                    | [Milvus.Client](https://www.nuget.org/packages/Milvus.Client)         |
| MongoDB Atlas Vector Search   | [Microsoft.SemanticKernel.Connectors.MongoDB](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.MongoDB)                 | [MongoDb.Driver](https://www.nuget.org/packages/MongoDB.Driver)       |
| Pinecone                      | [Microsoft.SemanticKernel.Connectors.Pinecone](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.Pinecone)            | [REST API](https://docs.pinecone.io/reference/api/introduction)       |
| Postgres                      | [Microsoft.SemanticKernel.Connectors.Postgres](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.Postgres)            | [Npgsql](https://www.nuget.org/packages/Npgsql/)        |
| Qdrant                        | [Microsoft.SemanticKernel.Connectors.Qdrant](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.Qdrant)               | [Qdrant.Client](https://www.nuget.org/packages/Qdrant.Client)         |
| Redis                         | [Microsoft.SemanticKernel.Connectors.Redis](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.Redis)                    |  [StackExchange.Redis](https://www.nuget.org/packages/StackExchange.Redis)       |
| Weaviate                      | [Microsoft.SemanticKernel.Connectors.Weaviate](https://www.nuget.org/packages/Microsoft.SemanticKernel.Connectors.Weaviate)            | [REST API](https://weaviate.io/developers/weaviate/api/rest)       |

To discover .NET SDK and API support, visit the documentation for each respective service.

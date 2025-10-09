---
title: Data ingestion
description: Introduction to data ingestion
author: luisquintanilla
ms.author: luquinta
ms.date: 11/11/2025
ms.topic: concept-article
---

# Data Ingestion

## What is data ingestion?

Data ingestion is the process of collecting, reading, and preparing data from different sources such as files, databases, APIs, or cloud services so it can be used in downstream applications. In practice, this follows the familiar Extract-Transform-Load (ETL) workflow:

- **Extract** data from its original source, whether that is a PDF, Word document, audio file, or web API.
- **Transform** the data by cleaning, chunking, enriching, or converting formats.
- **Load** the data into a destination like a database, vector store, or AI model for retrieval and analysis.

For AI and machine learning scenarios, especially Retrieval-Augmented Generation (RAG), data ingestion is not just about moving data. It is about making data usable for intelligent applications. This means representing documents in a way that preserves their structure and meaning, splitting them into manageable chunks, enriching them with metadata or embeddings, and storing them so they can be retrieved quickly and accurately.

## Why data ingestion matters for AI applications

Imagine you're building a RAG-powered chatbot to help employees find information across your company's vast collection of documents. These documents might include PDFs, Word files, PowerPoint presentations, and web pages scattered across different systems. 

Your chatbot needs to understand and search through thousands of documents to provide accurate, contextual answers. But raw documents aren't suitable for AI systems. You need to transform them into a format that preserves meaning while making them searchable and retrievable.

This is where data ingestion becomes critical. You need to extract text from different file formats, break large documents into smaller chunks that fit within AI model limits, enrich the content with metadata, generate embeddings for semantic search, and store everything in a way that enables fast retrieval. Each step requires careful consideration of how to preserve the original meaning and context.

## What is Microsoft.Extensions.DataIngestion?

Microsoft.Extensions.DataIngestion provides foundational .NET components for data ingestion. It enables developers to read, process, and prepare documents for AI and machine learning workflows, especially Retrieval-Augmented Generation (RAG) scenarios.

With these building blocks, developers can create robust, flexible, and intelligent data ingestion pipelines tailored for their application needs:

- **Unified document representation:** Represent any file type (PDF, Image, Microsoft Word, etc.) in a consistent format that works well with large language models.
- **Flexible data ingestion:** Read documents from both cloud services and local sources using multiple built-in readers, making it easy to bring in data from wherever it lives.
- **Built-in AI enhancements:** Automatically enrich content with summaries, sentiment analysis, keyword extraction, privacy-focused PII removal, and classification, preparing your data for intelligent workflows.
- **Customizable chunking strategies:** Split documents into chunks using token-based, section-based, or semantic-aware approaches, so you can optimize for your retrieval and analysis needs.
- **Production-ready storage:** Store processed chunks in popular vector databases and document stores, with support for embedding generation, making your pipelines ready for real-world scenarios.
- **End-to-end pipeline composition:** Chain together readers, processors, chunkers, and writers with the DocumentPipeline API, reducing boilerplate and making it easy to build, customize, and extend complete workflows.

All of these components are open and extensible by design. You can add custom logic, new connectors, and extend the system to support emerging AI scenarios. By standardizing how documents are represented, processed, and stored, .NET developers can build reliable, scalable, and maintainable data pipelines without reinventing the wheel for every project.

### Building on stable foundations

![Data Ingestion Architecture Diagram](../media/data-ingestion/DataIngestion.png)

These new data ingestion abstractions are built on top of proven and extensible components in the .NET ecosystem, ensuring reliability, interoperability, and seamless integration with existing AI workflows:

- **Microsoft.ML.Tokenizers:** Tokenizers provide the foundation for chunking documents based on tokens. This enables precise splitting of content, which is essential for preparing data for large language models and optimizing retrieval strategies.
- **Microsoft.Extensions.AI:** This set of libraries powers enrichment transformations using large language models. It enables features like summarization, sentiment analysis, keyword extraction, and embedding generation, making it easy to enhance your data with intelligent insights.
- **Microsoft.Extensions.VectorData:** This set of libraries offers a consistent interface for storing processed chunks in a wide variety of vector stores, including Qdrant, Azure SQL, CosmosDB, MongoDB, ElasticSearch, and many more. This ensures your data pipelines are ready for production and can scale across different storage backends.

In addition to familiar patterns and tools, these abstractions build on already extensible components. Plug-in capability and interoperability are paramount, so as the rest of the .NET AI ecosystem grows, the capabilities of the data ingestion components grow as well. This approach empowers developers to easily integrate new connectors, enrichments, and storage options, keeping their pipelines future-ready and adaptable to evolving AI scenarios.

## Data ingestion building blocks

The Microsoft.Extensions.DataIngestion library is built around several key components that work together to create a complete data processing pipeline. Let's explore each component and how they fit together.

### Documents and Document Readers

At the foundation of the library is the `Document` type, which provides a unified way to represent any file format without losing important information. The `Document` is Markdown-centric because large language models work best with Markdown formatting.

The `DocumentReader` abstraction handles loading documents from various sources, whether local files or remote URIs. The library includes several built-in readers:

- **Azure Document Intelligence**
- **LlamaParse**
- **MarkItDown**
- **Markdown**

This design means you can work with documents from different sources using the same consistent API, making your code more maintainable and flexible.

```csharp
// TODO: Add code snippet
```

### Document Processing

Document processors apply transformations at the document level to enhance and prepare content. The library currently supports:

- **Image processing** to extract text and descriptions from images within documents
- **Table processing** to preserve tabular data structure and make it searchable

### Chunks and Chunking Strategies

Once you have a document loaded, you typically need to break it down into smaller pieces called chunks. Chunks represent subsections of a document that can be efficiently processed, stored, and retrieved by AI systems. This chunking process is essential for retrieval-augmented generation scenarios where you need to find the most relevant pieces of information quickly.

The library provides several chunking strategies to fit different use cases:

- **Token-based chunking** splits text based on token counts, ensuring chunks fit within model limits
- **Section-based chunking** splits on headers and natural document boundaries  
- **Semantic-aware chunking** preserves complete thoughts and ideas across chunk boundaries

These chunking strategies build on the Microsoft.ML.Tokenizers library to intelligently split text into appropriately sized pieces that work well with large language models. The right chunking strategy depends on your document types and how you plan to retrieve information.

```csharp
// TODO: Add code snippet
```

### Chunk Processing and Enrichment

After documents are split into chunks, you can apply processors to enhance and enrich the content. Chunk processors work on individual pieces and can perform:

- **Content enrichment** including automatic summaries, sentiment analysis, and keyword extraction
- **PII removal** for privacy-focused content sanitization using large language models  
- **Classification** for automated content categorization based on predefined categories

These processors use Microsoft.Extensions.AI to leverage large language models for intelligent content transformation, making your chunks more useful for downstream AI applications.

### Document Writer and Storage

The `DocumentWriter` stores processed chunks into a data store for later retrieval. Using Microsoft.Extensions.AI and Microsoft.Extensions.VectorData, the library provides abstractions and implementations that support storing chunks in any vector store supported by Microsoft.Extensions.VectorData.

This includes popular options like Azure SQL Server, CosmosDB, PostgreSQL, MongoDB, and many others. The writer can also automatically generate embeddings for your chunks using Microsoft.Extensions.AI, making them ready for semantic search and retrieval scenarios.

### Document Processing Pipeline

The `DocumentPipeline` API allows you to chain together the various data ingestion components into a complete workflow. You can combine:

- **Readers** to load documents from various sources
- **Processors** to transform and enrich document content  
- **Chunkers** to break documents into manageable pieces
- **Writers** to store the final results in your chosen data store

This pipeline approach reduces boilerplate code and makes it easy to build, test, and maintain complex data ingestion workflows.

```csharp
//TODO: Add code snippet
```
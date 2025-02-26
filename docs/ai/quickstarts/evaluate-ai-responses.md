---
title: Quickstart - Evaluate an AI app's responses
description:
ms.date: 02/25/2025
ms.topic: quickstart
ms.custom: devx-track-dotnet, devx-track-dotnet-ai
---

# Evaluate an AI app's responses

In this quickstart, you create a .NET console app to ... The app uses the <xref:Microsoft.Extensions.AI> and [Microsoft.Extensions.AI.Evaluations](https://www.nuget.org/packages/Microsoft.Extensions.AI.Evaluations) libraries.

[!INCLUDE [clone-sample-repo](includes/clone-sample-repo.md)]

## Create the app

Complete the following steps to create a .NET console app that can accomplish the following:

- ...
- ...

1. In an empty directory on your computer, use the `dotnet new` command to create a new console app:

    ```dotnetcli
    dotnet new console -o VectorDataAI
    ```

1. Change directory into the app folder:

    ```dotnetcli
    cd VectorDataAI
    ```

1. Install the required packages:

    ```bash
    dotnet add package Microsoft.Extensions.AI.Evaluations --prerelease
    ...
    ```

    For more information about these packages, see [The Microsoft.Extensions.AI.Evaluation libraries](../conceptual/evaluation-libraries.md).

1. Open the app in Visual Studio Code (or your editor of choice).

    ```bash
    code .
    ```

:::zone target="docs" pivot="azure-openai"

[!INCLUDE [create-ai-service](includes/create-ai-service.md)]

:::zone-end

:::zone target="docs" pivot="openai"

## Configure the app

1. Navigate to the root of your .NET project from a terminal or command prompt.

1. Run the following commands to configure your OpenAI API key as a secret for the sample app:

    ```bash
    dotnet user-secrets init
    dotnet user-secrets set OpenAIKey <your-openai-key>
    dotnet user-secrets set ModelName <your-openai-model-name>
    ```

    > [!NOTE]
    > For the `ModelName` value, you need to specify an OpenAI text embedding model such as `text-embedding-3-small` or `text-embedding-3-large` to generate embeddings for vector search in the sections that follow.

:::zone-end

## Add the app code

1. ...

## Clean up resources



## Next steps


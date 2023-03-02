---
title: Deploy a model in an ASP.NET Core Web API
description: Serve an ML.NET sentiment analysis machine learning model using an ASP.NET Core Web API
ms.date: 03/02/2023
author: luisquintanilla
ms.author: luquinta
ms.custom: mvc,how-to
ms.topic: how-to
#Customer intent: As a developer, I want to use my ML.NET Machine Learning model through the internet using an ASP.NET Core Web API
---

# Deploy a model in an ASP.NET Core Web API

Learn how to serve a pre-trained ML.NET machine learning model on the web using an ASP.NET Core Web API. Serving a model over a web API enables predictions via standard HTTP methods.

## Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/#download) with the **ASP.NET and web development workload**.
- PowerShell.
- Pre-trained model. Use the [ML.NET Sentiment Analysis tutorial](../tutorials/sentiment-analysis.md) to build your own model or download this [pre-trained sentiment analysis machine learning model](https://github.com/dotnet/samples/blob/main/machine-learning/models/sentimentanalysis/sentiment_model.zip)

## Create ASP.NET Core Web API project

1. Start Visual Studio 2022 and select **Create a new project**. 
1. In the **Create a new project** dialog:
  - Enter `Web API` in the search box.
  - Select the **ASP.NET Core Web API** template and selsect **Next**.
1. In the **Configure your project** dialog:
  - Name your project **SentimentAnalysisWebAPI**.
  - Select **Next**.
1. In the **Additional information** dialog:
    - Uncheck **Do not use top-level statements**
    - Select **Create**. 

1. Install the following NuGet packages:

- [Microsoft.ML](https://www.nuget.org/packages/Microsoft.ML)
- [Microsoft.Extensions.ML](https://www.nuget.org/packages/Microsoft.Extensions.ML/)

For more details on installing NuGet packages in Visual Studio, see the [Install and use a NuGet package in Visual Studio](/nuget/quickstart/install-and-use-a-package-in-visual-studio#nuget-package-manager) guide.

### Add model to ASP.NET Core Web API project

1. Copy your pre-built model to your *SentimentAnalysisWebAPI* project directory. 
1. Configure your project to copy your model file to the output directory. In Solution Explorer: 

- Right-click the model zip file and select **Properties**. 
- Under Advanced, change the value of Copy to Output Directory to **Copy if newer**.

## Create data models

You need to create some classes to define the schema of your model input and output. 

> [!NOTE]
> The properties of your input and output schema classes depend on the dataset columns used to train your model as well as the machine learning task (regression, classification, etc.).

In your *Program.cs* file:

1. Add the following using statements:

    ```csharp
    using Microsoft.ML.Data;
    using Microsoft.Extensions.ML;
    ```

1. At the bottom of the file, add the following classes:

**Model input**

For this model, the input contains a single property `SentimentText` which is a string that represents a user comment. 

```csharp
public class ModelInput
{
    public string SentimentText;
}
```

**Model output**

Once the model evaluates the input, it outputs a prediction with three properties: `Sentiment`, `Probability`, and `Score`. In this case, the `Sentiment` is the predicted sentiment of the user comment and the `Probability` and `Score` are confidence measures for the prediction.  

```csharp
public class ModelOutput
{
    [ColumnName("PredictedLabel")]
    public bool Sentiment { get; set; }

    public float Probability { get; set; }

    public float Score { get; set; }
}
```

## Register PredictionEnginePool for use in the application

To make a single prediction, you have to create a [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602). [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) is not thread-safe. Additionally, you have to create an instance of it everywhere it is needed within your application. As your application grows, this process can become unmanageable. For improved performance and thread safety, use a combination of dependency injection and the `PredictionEnginePool` service, which creates an [`ObjectPool`](xref:Microsoft.Extensions.ObjectPool.ObjectPool%601) of [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) objects for use throughout your application.

The following link provides more information if you want to learn more about [dependency injection in ASP.NET Core](/aspnet/core/fundamentals/dependency-injection).

1. Add the following code to your *Program.cs* file:

    ```csharp
    builder.Services.AddPredictionEnginePool<ModelInput, ModelOutput>()
        .FromFile(modelName: "SentimentAnalysisModel", filePath: "sentiment_model.zip", watchForChanges: true);
    ```

At a high level, this code initializes the objects and services automatically for later use when requested by the application instead of having to manually do it.

Machine learning models are not static. As new training data becomes available, the model is retrained and redeployed. One way to get the latest version of the model into your application is to restart or redeploy your application. However, this introduces application downtime. The `PredictionEnginePool` service provides a mechanism to reload an updated model without restarting or redeploying your application.

Set the `watchForChanges` parameter to `true`, and the `PredictionEnginePool` starts a [`FileSystemWatcher`](xref:System.IO.FileSystemWatcher) that listens to the file system change notifications and raises events when there is a change to the file. This prompts the `PredictionEnginePool` to automatically reload the model.

The model is identified by the `modelName` parameter so that more than one model per application can be reloaded upon change.

> [!TIP]
> Alternatively, you can use the `FromUri` method when working with models stored remotely. Rather than watching for file changed events, `FromUri` polls the remote location for changes. The polling interval defaults to 5 minutes. You can increase or decrease the polling interval based on your application's requirements. In the code sample below, the `PredictionEnginePool` polls the model stored at the specified URI every minute.
>
>```csharp
>services.AddPredictionEnginePool<SentimentData, SentimentPrediction>()
>   .FromUri(
>       modelName: "SentimentAnalysisModel",
>       uri:"https://github.com/dotnet/samples/raw/main/machine-learning/models/sentimentanalysis/sentiment_model.zip",
>       period: TimeSpan.FromMinutes(1));
>```

## Map predict endpoint

To process your incoming HTTP requests, create an endpoint.

Replace the `/` endpoint with the following:

```csharp
var predictionHandler =
    async (PredictionEnginePool<ModelInput, ModelOutput> predictionEnginePool, ModelInput input) =>
        await Task.FromResult(predictionEnginePool.Predict(modelName: "SentimentAnalysisModel", input));

app.MapPost("/predict", predictionHandler);
```

The `/predict` endpoint accepts HTTP POST requests and uses the prediction engine pool to return a prediction using the provided input.  

Once you're done, your *Program.cs* should look like the following:

```csharp
using Microsoft.ML.Data;
using Microsoft.Extensions.ML;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPredictionEnginePool<ModelInput, ModelOutput>()
    .FromFile(modelName: "SentimentAnalysisModel", filePath: "sentiment_model.zip", watchForChanges: true);

var app = builder.Build();

var predictionHandler =
    async (PredictionEnginePool<ModelInput, ModelOutput> predictionEnginePool, ModelInput input) =>
        await Task.FromResult(predictionEnginePool.Predict(modelName: "SentimentAnalysisModel", input));

app.MapPost("/predict", predictionHandler);

app.Run();

public class ModelInput
{
    public string SentimentText;
}

public class ModelOutput
{
    [ColumnName("PredictedLabel")]
    public bool Sentiment { get; set; }

    public float Probability { get; set; }

    public float Score { get; set; }
}
```

## Test web API locally

Once everything is set up, it's time to test the application.

1. Run the application.
1. Open PowerShell and enter the following code where PORT is the port your application is listening on.

    ```powershell
    Invoke-RestMethod "https://localhost:<PORT>/predict" -Method Post -Body (@{SentimentText="This was a very bad steak"} | ConvertTo-Json) -ContentType "application/json"
    ```

    If successful, the output should look similar to the text below:

    ```powershell
    sentiment probability score
    --------- ----------- -----
    False         0.5     0
    ```

Congratulations! You have successfully served your model to make predictions over the internet using an ASP.NET Core Web API.

## Next Steps

- [Deploy to Azure](/aspnet/core/tutorials/publish-to-azure-webapp-using-vs#deploy-the-app-to-azure)

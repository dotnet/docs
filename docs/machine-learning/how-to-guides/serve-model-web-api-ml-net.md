---
title: Deploy a model in an ASP.NET Core Web API
description: Serve ML.NET sentiment analysis machine learning model over the internet using ASP.NET Core Web API
ms.date: 09/11/2019
author: luisquintanilla
ms.author: luquinta
ms.custom: mvc,how-to
#Customer intent: As a developer, I want to use my ML.NET Machine Learning model through the internet using an ASP.NET Core Web API
---

# Deploy a model in an ASP.NET Core Web API

Learn how to serve a pre-trained ML.NET machine learning model on the web using an ASP.NET Core Web API. Serving a model over a web API enables predictions via standard HTTP methods.

> [!NOTE]
> `PredictionEnginePool` service extension is currently in preview.

## Prerequisites

- [Visual Studio 2017 15.6 or later](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2017) with the ".NET Core cross-platform development" workload installed.
- Powershell.
- Pre-trained model. Use the [ML.NET Sentiment Analysis tutorial](../tutorials/sentiment-analysis.md) to build your own model or download this [pre-trained sentiment analysis machine learning model](https://github.com/dotnet/samples/blob/master/machine-learning/models/sentimentanalysis/sentiment_model.zip)

## Create ASP.NET Core Web API project

1. Open Visual Studio 2017. Select **File > New > Project** from the menu bar. In the New Project dialog, select the **Visual C#** node followed by the **Web** node. Then select the **ASP.NET Core Web Application** project template. In the **Name** text box, type "SentimentAnalysisWebAPI" and then select the **OK** button.

1. In the window that displays the different types of ASP.NET Core Projects, select **API** and the select the **OK** button.

1. Create a directory named *MLModels* in your project to save your pre-built machine learning model files:

    In Solution Explorer, right-click on your project and select Add > New Folder. Type "MLModels" and hit Enter.

1. Install the **Microsoft.ML NuGet Package**:

    In Solution Explorer, right-click on your project and select **Manage NuGet Packages**. Choose "nuget.org" as the Package source, select the Browse tab, search for **Microsoft.ML**, select that package in the list, and select the Install button. Select the **OK** button on the **Preview Changes** dialog and then select the **I Accept** button on the License Acceptance dialog if you agree with the license terms for the packages listed.

1. Install the **Microsoft.Extensions.ML Nuget Package**:

    In Solution Explorer, right-click on your project and select **Manage NuGet Packages**. Choose "nuget.org" as the Package source, select the Browse tab, search for **Microsoft.Extensions.ML**, select that package in the list, and select the Install button. Select the **OK** button on the **Preview Changes** dialog and then select the **I Accept** button on the License Acceptance dialog if you agree with the license terms for the packages listed.

### Add model to ASP.NET Core Web API project

1. Copy your pre-built model to the *MLModels* directory
1. In Solution Explorer, right-click the model zip file and select Properties. Under Advanced, change the value of Copy to Output Directory to Copy if newer.

## Create data models

You need to create some classes for your input data and predictions. Add a new class to your project:

1. Create a directory named *DataModels* in your project to save your data models:

    In Solution Explorer, right-click on your project and select Add > New Folder. Type "DataModels" and hit **Enter**.

2. In Solution Explorer, right-click the *DataModels* directory, and then select Add > New Item.
3. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *SentimentData.cs*. Then, select the **Add** button. The *SentimentData.cs* file opens in the code editor. Add the following using statement to the top of *SentimentData.cs*:

    ```csharp
    using Microsoft.ML.Data;
    ```
    
    Remove the existing class definition and add the following code to the **SentimentData.cs** file:
    
    ```csharp
    public class SentimentData
    {
        [LoadColumn(0)]
        public string SentimentText;

        [LoadColumn(1)]
        [ColumnName("Label")]
        public bool Sentiment;
    }
    ```

4. In Solution Explorer, right-click the *DataModels* directory, and then select **Add > New Item**.
5. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *SentimentPrediction.cs*. Then, select the Add button. The *SentimentPrediction.cs* file opens in the code editor. Add the following using statement to the top of *SentimentPrediction.cs*:

    ```csharp
    using Microsoft.ML.Data;
    ```
    
    Remove the existing class definition and add the following code to the *SentimentPrediction.cs* file:
    
    ```csharp
    public class SentimentPrediction : SentimentData
    {

        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }

        public float Probability { get; set; }

        public float Score { get; set; }
    }
    ```

    `SentimentPrediction` inherits from `SentimentData`. This makes it easier to see the original data in the `SentimentText` property along with the output generated by the model. 

## Register PredictionEnginePool for use in the application

To make a single prediction, you have to create a [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602). [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) is not thread-safe. Additionally, you have to create an instance of it everywhere it is needed within your application. As your application grows, this process can become unmanageable. For improved performance and thread safety, use a combination of dependency injection and the `PredictionEnginePool` service, which creates an [`ObjectPool`](xref:Microsoft.Extensions.ObjectPool.ObjectPool%601) of [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) objects for use throughout your application.

The following link provides more information if you want to learn more about [dependency injection in ASP.NET Core](https://docs.microsoft.com/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.1).

1. Open the *Startup.cs* class and add the following using statement to the top of the file:

    ```csharp
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.ML;
    using SentimentAnalysisWebAPI.DataModels;
    ```

2. Add the following code to the *ConfigureServices* method:

    ```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        services.AddPredictionEnginePool<SentimentData, SentimentPrediction>()
            .FromFile(modelName: "SentimentAnalysisModel", filePath:"MLModels/sentiment_model.zip", watchForChanges: true);
    }
    ```

At a high level, this code initializes the objects and services automatically for later use when requested by the application instead of having to manually do it. 

Machine learning models are not static. As new training data becomes available, the model is retrained and redeployed. One way to get the latest version of the model into your application is to redeploy the entire application. However, this introduces application downtime. The `PredictionEnginePool` service provides a mechanism to reload an updated model without taking your application down. 

Set the `watchForChanges` parameter to `true`, and the `PredictionEnginePool` starts a [`FileSystemWatcher`](xref:System.IO.FileSystemWatcher) that listens to the file system change notifications and raises events when there is a change to the file. This prompts the `PredictionEnginePool` to automatically reload the model.

The model is identified by the `modelName` parameter so that more than one model per application can be reloaded upon change. 

> [!TIP]
> Alternatively, you can use the `FromUri` method when working with models stored remotely. Rather than watching for file changed events, `FromUri` polls the remote location for changes. The polling interval defaults to 5 minutes. You can increase or decrease the polling interval based on your application's requirements. In the code sample below, the model polls the specified URI every minute.
```csharp
builder.Services.AddPredictionEnginePool<SentimentData, SentimentPrediction>()
    .FromUri(
        modelName: "SentimentAnalysisModel", 
        uri:"https://github.com/dotnet/samples/raw/master/machine-learning/models/sentimentanalysis/sentiment_model.zip", 
        period: TimeSpan.FromMinutes(1));
```

## Create Predict controller

To process your incoming HTTP requests, create a controller.

1. In Solution Explorer, right-click the *Controllers* directory, and then select **Add > Controller**.
1. In the **Add New Item** dialog box, select **API Controller Empty** and select **Add**.
1. In the prompt change the **Controller Name** field to *PredictController.cs*. Then, select the Add button. The *PredictController.cs* file opens in the code editor. Add the following using statement to the top of *PredictController.cs*:

    ```csharp
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.ML;
    using SentimentAnalysisWebAPI.DataModels;
    ```

    Remove the existing class definition and add the following code to the *PredictController.cs* file:
    
    ```csharp
    public class PredictController : ControllerBase
    {
        private readonly PredictionEnginePool<SentimentData, SentimentPrediction> _predictionEnginePool;

        public PredictController(PredictionEnginePool<SentimentData,SentimentPrediction> predictionEnginePool)
        {
            _predictionEnginePool = predictionEnginePool;
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] SentimentData input)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            SentimentPrediction prediction = _predictionEnginePool.Predict(modelName: "SentimentAnalysisModel", example: input);

            string sentiment = Convert.ToBoolean(prediction.Prediction) ? "Positive" : "Negative";

            return Ok(sentiment);
        }
    }
    ```

This code assigns the `PredictionEnginePool` by passing it to the controller's constructor which you get via dependency injection. Then, the `Predict` controller's `Post` method uses the `PredictionEnginePool` to make predictions using the `SentimentAnalysisModel` registered in the `Startup` class and returns the results back to the user if successful.

## Test web API locally

Once everything is set up, it's time to test the application.

1. Run the application.
1. Open Powershell and enter the following code where PORT is the port your application is listening on.

    ```powershell
    Invoke-RestMethod "https://localhost:<PORT>/api/predict" -Method Post -Body (@{SentimentText="This was a very bad steak"} | ConvertTo-Json) -ContentType "application/json"
    ```

    If successful, the output should look similar to the text below:
    
    ```powershell
    Negative
    ```

Congratulations! You have successfully served your model to make predictions over the internet using an ASP.NET Core Web API.

## Next Steps

- [Deploy to Azure](/aspnet/core/tutorials/publish-to-azure-webapp-using-vs#deploy-the-app-to-azure)

---
title: Deploy a model in an ASP.NET Core Web API
description: Serve ML.NET sentiment analysis machine learning model over the internet using ASP.NET Core Web API
ms.date: 08/20/2019
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

To make a single prediction, use [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602). In order to use [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) in your application you must create it when it's needed. In that case, a best practice to consider is dependency injection.

The following link provides more information if you want to learn about [dependency injection in ASP.NET Core](/aspnet/core/fundamentals/dependency-injection).

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
            .FromFile("MLModels/sentiment_model.zip");
    }
    ```

At a high level, this code initializes the objects and services automatically when requested by the application instead of having to manually do it.

> [!WARNING]
> [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) is not thread-safe. For improved performance and thread safety, use the `PredictionEnginePool` service, which creates an [`ObjectPool`](xref:Microsoft.Extensions.ObjectPool.ObjectPool%601) of `PredictionEngine` objects for application use. Read the following blog post to learn more about [creating and using `PredictionEngine` object pools in ASP.NET Core](https://devblogs.microsoft.com/cesardelatorre/how-to-optimize-and-run-ml-net-models-on-scalable-asp-net-core-webapis-or-web-apps/).  

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

            SentimentPrediction prediction = _predictionEnginePool.Predict(input);

            string sentiment = Convert.ToBoolean(prediction.Prediction) ? "Positive" : "Negative";

            return Ok(sentiment);
        }
    }
    ```

This code assigns the `PredictionEnginePool` by passing it to the controller's constructor which you get via dependency injection. Then, the `Predict` controller's `Post` method uses the `PredictionEnginePool` to make predictions and return the results back to the user if successful.

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

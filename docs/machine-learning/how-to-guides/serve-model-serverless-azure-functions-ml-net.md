---
title: "How-To: Deploy ML.NET machine learning model to Azure Functions"
description: Serve ML.NET sentiment analysis machine learning model for prediction over the internet using Azure Functions
ms.date: 04/29/2019
author: luisquintanilla
ms.author: luquinta
ms.custom: mvc, how-to
#Customer intent: As a developer, I want to use my ML.NET Machine Learning model to make predictions through the internet using Azure Functions
---

# How-To: Deploy ML.NET machine learning model to Azure Functions

Learn how to deploy a pre-trained ML.NET machine learning model for predictions over HTTP through an Azure Functions serverless environment.

## Prerequisites

- [Visual Studio 2017 15.6 or later](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2017) with the ".NET Core cross-platform development" workload and "Azure development" installed.
- [Azure Functions Tools](/azure/azure-functions/functions-develop-vs#check-your-tools-version)
- Powershell
- Pre-trained model
    - Use the [ML.NET Sentiment Analysis tutorial](../tutorials/sentiment-analysis.md) to build your own model.
    
    or 
    
    - Download this [pre-trained sentiment analysis machine learning model](https://github.com/dotnet/samples/blob/master/machine-learning/models/sentimentanalysis/sentiment_model.zip)

## Create Azure Functions Project

1. Open Visual Studio 2017. Select **File** > **New** > **Project** from the menu bar. In the **New Project** dialog, select the **Visual C#** node followed by the **Cloud** node. Then select the **Azure Functions** project template. In the **Name** text box, type "SentimentAnalysisFunctionsApp" and then select the **OK** button.
1. In the **New Project** dialog, open the dropdown above the project options and select **Azure Functions v2 (.NET Core)**. Then, select the **Http trigger** project and then select the **OK** button.
1. Create a directory named *MLModels* in your project to save your model:

    In **Solution Explorer**, right-click on your project and select **Add** > **New Folder**. Type "MLModels" and hit Enter.

1. Install the **Microsoft.ML NuGet Package**:

    In Solution Explorer, right-click on your project and select **Manage NuGet Packages**. Choose "nuget.org" as the Package source, select the Browse tab, search for **Microsoft.ML**, select that package in the list, and select the **Install** button. Select the **OK** button on the **Preview Changes** dialog and then select the **I Accept** button on the **License Acceptance** dialog if you agree with the license terms for the packages listed.

## Add Pre-built Model To Project

1. Copy your pre-built model to the *MLModels* folder.
1. In Solution Explorer, right-click your pre-built model file and select **Properties**. Under **Advanced**, change the value of **Copy to Output Directory** to **Copy if newer**.

## Create Function to Analyze Sentiment

Create a class to predict sentiment. Add a new class to your project:

1. In **Solution Explorer**, right-click the project, and then select **Add** > **New Item**.

1. In the **Add New Item** dialog box, select **Azure Function** and change the **Name** field to *AnalyzeSentiment.cs*. Then, select the **Add** button.

1. In the **New Azure Function** dialog box, select **Http Trigger**. Then, select the **OK** button.

    The *AnalyzeSentiment.cs* file opens in the code editor. Add the following `using` statement to the top of *GitHubIssueData.cs*:

    ```csharp
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Microsoft.ML;
    using SentimentAnalysisFunctionsApp.DataModels;
    ```

## Create Data Models

You need to create some classes for your input data and predictions. Add a new class to your project:

1. Create a directory named *DataModels* in your project to save your data models:
    In Solution Explorer, right-click on your project and select **Add > New Folder**. Type "DataModels" and hit Enter.
2. In Solution Explorer, right-click the *DataModels* directory, and then select **Add > New Item**.
3. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *SentimentData.cs*. Then, select the **Add** button. The *SentimentData.cs* file opens in the code editor. Add the following using statement to the top of *SentimentData.cs*:

    ```csharp
    using Microsoft.ML.Data;
    ```

    Remove the existing class definition and add the following code to the *SentimentData.cs* file:
    
    ```csharp
    public class SentimentData
    {
        [LoadColumn(0)]
        public bool Label { get; set; }
        [LoadColumn(1)]
        public string Text { get; set; }
    }
    ```

4. In Solution Explorer, right-click the *DataModels* directory, and then select **Add > New Item**.
5. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *SentimentPrediction.cs*. Then, select the **Add** button. The *SentimentPrediction.cs* file opens in the code editor. Add the following using statement to the top of *SentimentPrediction.cs*:

    ```csharp
    using Microsoft.ML.Data;
    ```

    Remove the existing class definition and add the following code to the *SentimentPrediction.cs* file:

    ```csharp
    public class SentimentPrediction : SentimentData
    {
        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }
    }
    ```

`SentimentPrediction` inherits from `SentimentData` which provides access to the original data in the `Text` property as well as the output generated by the model.

## Load the model into the function

Insert the following code inside the *AnalyzeSentiment* class:

```csharp
// Define MLContext
static MLContext _mlContext;

// Define model
static ITransformer _model;

// Define model's DataViewSchema
static DataViewSchema _modelSchema;

// Define PredictionEngine
static PredictionEngine<SentimentData, SentimentPrediction> _predictionEngine;

// AnalyzeSentiment class constructor
static AnalyzeSentiment()
{
    // Create MLContext
    _mlContext = new MLContext();

    // Load Model
    _model = _mlContext.Model.Load("MLModels/sentiment_model.zip", out _modelSchema);

    // Create Prediction Engine
    _predictionEngine = _mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(_model);
}
```

The constructor contains initialization logic for the [`MLContext`](xref:Microsoft.ML.MLContext), model and [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) so that it can be shared throughout the lifecycle of the function instance. This approach reduces the need to load the model from disk each time the `Run` method executes. 

## Use the model to make predictions

Replace the existing implementation of *Run* method in *AnalyzeSentiment* class with the following code:

```csharp
public static async Task<IActionResult> Run(
[HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
ILogger log)
{
    log.LogInformation("C# HTTP trigger function processed a request.");

    //Parse HTTP Request Body
    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    SentimentData data = JsonConvert.DeserializeObject<SentimentData>(requestBody);
    
    //Make Prediction
    SentimentPrediction prediction = _predictionEngine.Predict(data);

    //Convert prediction to string
    string isToxic = Convert.ToBoolean(prediction.Prediction) ? "Toxic" : "Not Toxic";

    //Return Prediction
    return (ActionResult)new OkObjectResult(isToxic);
}
```

When the `Run` method executes, the incoming data from the HTTP request is deserialized and used as input for the [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602). The [`Predict`](xref:Microsoft.ML.PredictionEngineBase%602.Predict*) method is then called to generate a prediction and return the result to the user. 

## Test Locally

Now that everything is set up, it's time to test the application:

1. Run the application
1. Open PowerShell and enter the code into the prompt where PORT is the port your application is running on. Typically the port is 7071.

    ```powershell
    Invoke-RestMethod "http://localhost:<PORT>/api/AnalyzeSentiment" -Method Post -Body (@{Text="This is a very rude movie"} | ConvertTo-Json) -ContentType "application/json"
    ```

    If successful, the output should look similar to the text below:
    
        ```powershell
        Toxic
        ```

Congratulations! You have successfully served your model to make predictions over the internet using an Azure Function.

## Next Steps

- [Deploy to Azure](/azure/azure-functions/functions-develop-vs#publish-to-azure)

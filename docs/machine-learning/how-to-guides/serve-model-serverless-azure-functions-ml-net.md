---
title: Deploy ML.NET Model to Azure Functions
description: Serve ML.NET sentiment analysis machine learning model for prediction over the internet using Azure Functions
ms.date: 03/08/2019
ms.custom: mvc,how-to
#Customer intent: As a developer, I want to use my ML.NET Machine Learning model to make predictions through the internet using Azure Functions
---

# How-To: Use ML.NET Model in Azure Functions

This how-to shows how individual predictions can be made using a pre-built ML.NET machine learning model through the internet in a serverless environment such as Azure Functions.

## Prerequisites

- [Visual Studio 2017 15.6 or later](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=button+cta&utm_content=download+vs2017) with the ".NET Core cross-platform development" workload and "Azure development" installed. 
- [Azure Functions Tools](https://docs.microsoft.com/en-us/azure/azure-functions/functions-develop-vs#check-your-tools-version)
- Pre-trained model. 
    - Build Your Own [sentiment analysis machine learning model]()
    - Download this [pre-trained sentiment analysis machine learning model]()

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
using Microsoft.ML.Core.Data;
using Microsoft.ML.Data;
```

### Create Data Models

Create classes to define machine learning model's input and outputs. Add the following code to the *AnalyzeSentiment.cs* file under the *AnalyzeSentiment* class definition. 

```csharp
public class SentimentData
{
    [LoadColumn(0)]
    public bool Label { get; set; }
    [LoadColumn(1)]
    public string Text { get; set; }
}

public class SentimentPrediction
{
    [ColumnName("PredictedLabel")]
    public bool Prediction { get; set; }
}
```

### Add Prediction Logic

Replace the existing implementation of *Run* method in *AnalyzeSentiment* class with the following code:

```csharp
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function,"post", Route = null)] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        //Create Context
        MLContext mlContext = new MLContext();

        //Load Model
        using (var fs = File.OpenRead("MLModels/sentiment_model.zip"))
        {
            model = mlContext.Model.Load(fs);
        }

        //Parse HTTP Request Body
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        SentimentData data = JsonConvert.DeserializeObject<SentimentData>(requestBody);

        //Create Prediction Engine
        PredictionEngine<SentimentData, SentimentPrediction> predictionEngine = model.CreatePredictionEngine<SentimentData, SentimentPrediction>(mlContext);

        //Make Prediction
        SentimentPrediction prediction = predictionEngine.Predict(data);

        //Convert prediction to string
        string isToxic = Convert.ToBoolean(prediction.Prediction) ? "Toxic" : "Not Toxic";

        //Return Prediction
        return (ActionResult)new OkObjectResult(isToxic);
    }
}
```

## Test Locally

Now that everything is set up, it's time to test the application:

1. Run the application
1. Open PowerShell and enter the code into the prompt where PORT is the port your application is running on. Typically the port is 7071. 

```powershell
Invoke-RestMethod "http://localhost:<PORT>/api/predict" -Method Post -Body (@{Text="This is a very rude movie"} | ConvertTo-Json) -ContentType "application/json"
```

## Next Steps

- [Deploy to Azure](https://docs.microsoft.com/en-us/azure/azure-functions/functions-develop-vs#publish-to-azure)
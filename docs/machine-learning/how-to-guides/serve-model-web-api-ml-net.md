---
title: Serve Machine Learning Model In ASP.NET Core Web API
description: Serve ML.NET sentiment analysis machine learning model over the internet using ASP.NET Core Web API
ms.date: 03/05/2019
ms.custom: mvc,how-to
#Customer intent: As a developer, I want to use my ML.NET Machine Learning model through the internet using an ASP.NET Core Web API
---

# How-To: Serve Machine Learning Model Through ASP.NET Core Web API

This how-to shows how to serve a pre-built ML.NET machine learning model to the web using an ASP.NET Core Web API. By doing so it allows for users to access the API for prediction purposes via standard HTTP methods.

> [!NOTE]
> This topic refers to ML.NET, which is currently in Preview, and material may be subject to change. For more information, visit [the ML.NET introduction](https://www.microsoft.com/net/learn/apps/machine-learning-and-ai/ml-dotnet).

This how-to and related sample are currently using **ML.NET version 0.10**. For more information, see the release notes at the [dotnet/machinelearning github repo](https://github.com/dotnet/machinelearning/tree/master/docs/release-notes)n

## Prerequisites

- [Visual Studio 2017 15.6 or later](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=button+cta&utm_content=download+vs2017) with the ".NET Core cross-platform development" workload installed.
- Powershell.
- Pre-trained model.
    - Use the [ML.NET Sentiment Analysis tutorial](../tutorials/sentiment-analysis.md) to build your own model.
    - Download this [pre-trained sentiment analysis machine learning model](https://github.com/dotnet/samples/blob/master/machine-learning/models/sentimentanalysis/sentiment_model.zip)

## Create ASP.NET Core Web API Project

1. Open Visual Studio 2017. Select **File > New > Project** from the menu bar. In the New Project dialog, select the **Visual C#** node followed by the **Web** node. Then select the **ASP.NET Core Web Application** project template. In the **Name** text box, type "SentimentAnalysisWebAPI" and then select the **OK** button.
1. In the window that displays the different types of ASP.NET Core Projects, select **API** and the select the **OK** button.
1. Create a directory named *MLModels* in your project to save your pre-built machine learning model files:

    In Solution Explorer, right-click on your project and select Add > New Folder. Type "MLModels" and hit Enter.

1. Install the **Microsoft.ML NuGet Package**:

    In Solution Explorer, right-click on your project and select **Manage NuGet Packages**. Choose "nuget.org" as the Package source, select the Browse tab, search for **Microsoft.ML**, select that package in the list, and select the Install button. Select the **OK** button on the **Preview Changes** dialog and then select the **I Accept** button on the License Acceptance dialog if you agree with the license terms for the packages listed.

### Add Model to ASP.NET Core Web API Project

1. Copy your pre-built model to the *MLModels* directory
1. In Solution Explorer, right-click the model zip file and select Properties. Under Advanced, change the value of Copy to Output Directory to Copy if newer.

## Build Data Models

You need to create some classes for your input data and predictions. Add a new class to your project:

1. Create a directory named *DataModels* in your project to save your data models:

    In Solution Explorer, right-click on your project and select Add > New Folder. Type "DataModels" and hit **Enter**.

2. In Solution Explorer, right-click the *DataModels* directory, and then select Add > New Item.
3. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *SentimentData.cs*. Then, select the **Add** button. The *SentimentData.cs* file opens in the code editor. Add the following using statement to the top of *SentimentData.cs*:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.Data;
```

Remove the existing class definition and add the following code to the **SentimentData.cs** file:

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
5. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *SentimentPrediction.cs*. Then, select the Add button. The *SentimentPrediction.cs* file opens in the code editor. Add the following using statement to the top of *SentimentPrediction.cs*:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.Data;
```

Remove the existing class definition and add the following code to the *SentimentPrediction.cs* file:

```csharp
public class SentimentPrediction
{
    [ColumnName("PredictedLabel")]
    public bool Prediction { get; set; }
}
```

## Create Prediction Service

To organize and re-use the prediction logic throughout the entire application, create a prediction service.

1. Create a directory named *Services* in your project to hold services to be used by the application:

    In Solution Explorer, right-click on your project and select **Add > New Folder**. Type "Services" and hit **Enter**.

1. In Solution Explorer, right-click the *Services* directory, and then select **Add > New Item**.
1. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *PredictionService.cs*. Then, select the **Add** button. The *PredictionService.cs* file opens in the code editor. Add the following using statement to the top of *PredictionService.cs*:

```csharp
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML;
using Microsoft.ML.Core.Data;
using SentimentAnalysisWebAPI.DataModels;
```

Remove the existing class definition and add the following code to the *PredictionService.cs* file:

```csharp
public class PredictionService
{
    private readonly PredictionEngine<SentimentData, SentimentPrediction> _predictionEngine;
    public PredictionService(PredictionEngine<SentimentData,SentimentPrediction> predictionEngine)
    {
        _predictionEngine = predictionEngine;
    }

    public string Predict(SentimentData input)
    {
        // Make a prediction
        SentimentPrediction prediction = _predictionEngine.Predict(input);

        //If prediction is true then it is toxic. If it is false, the it is not.
        string isToxic = Convert.ToBoolean(prediction.Prediction) ? "Toxic" : "Not Toxic";

        return isToxic;

    }
}
```

## Register Predictions Service for Use in Application

To use the prediction service in your application you will have to create it every time it is needed. In that case, a best practice to consider is ASP.NET Core dependency injection.

The following link provides more information if you want to learn about [dependency injection](https://docs.microsoft.com/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.1).

1. Open the *Startup.cs* class and add the following using statement to the top of the file:

```csharp
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ML;
using Microsoft.ML.Core.Data;
using SentimentAnalysisWebAPI.DataModels;
using SentimentAnalysisWebAPI.Services;
```

1. Add the following lines of code to the *ConfigureServices* method:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

    services.AddSingleton<MLContext>();
    services.AddSingleton<PredictionEngine<SentimentData, SentimentPrediction>>((ctx) =>
    {
        MLContext mlContext = ctx.GetRequiredService<MLContext>();
        string modelFilePathName = "MLModels/sentiment_model.zip";

        //Load model from file
        ITransformer model;
        using (var stream = File.OpenRead(modelFilePathName))
        {
            model = mlContext.Model.Load(stream);
        }

        // Return prediction engine
        return model.CreatePredictionEngine<SentimentData, SentimentPrediction>(mlContext);
    });
    services.AddSingleton<PredictionService>();
}
```

At a high level, this code initializes the objects and services automatically when requested by the application instead of having to manually do it.

## Create Predict Controller

To process your incoming HTTP requests, you need to create a controller.

1. In Solution Explorer, right-click the *Controllers* directory, and then select **Add > Controller**.
1. In the **Add New Item** dialog box, select **API Controller Empty** and select **Add**.
1. In the prompt change the **Controller Name** field to *PredictController.cs*. Then, select the Add button. The *PredictController.cs* file opens in the code editor. Add the following using statement to the top of *PredictController.cs*:

```csharp
using Microsoft.AspNetCore.Mvc;
using SentimentAnalysisWebAPI.DataModels;
using SentimentAnalysisWebAPI.Services;
```

Remove the existing class definition and add the following code to the *PredictController.cs* file:

```csharp
public class PredictController : ControllerBase
{

    private readonly PredictionService _predictionService;

    public PredictController(PredictionService predictionService)
    {
        _predictionService = predictionService; //Define prediction service
    }

    [HttpPost]
    public ActionResult<string> Post([FromBody]SentimentData input)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest();
        }
        return Ok(_predictionService.Predict(input));
    }

}
```

This is assigning the Prediction service by passing it to the controller's constructor which you get via dependency injection. Then, in the POST method of this controller the Prediction service is being used to make predictions and return the results back to the user if successful.

## Test Web API Locally

Once everything is set up, it's time to test the application.

1. Run the application.
1. Open Powershell and enter the following code where PORT is the port your application is listening on.

```powershell
Invoke-RestMethod "https://localhost:<PORT>/api/predict" -Method Post -Body (@{Text="This is a very rude movie"} | ConvertTo-Json) -ContentType "application/json"
```

If successful, the output should look similar to the text below:

```powershell
Toxic
```

Congratulations! You have successfully served your model to make predictions over the internet using an ASP.NET Core API.

## Next Steps

- [Deploy to Azure](/aspnet/core/tutorials/publish-to-azure-webapp-using-vs?view=aspnetcore-2.1#deploy-the-app-to-azure)
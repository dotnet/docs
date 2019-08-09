---
title: 'Tutorial: Analyze website comments - binary classification'
description: This tutorial shows you how to create a Razor Pages application that classifies sentiment from website comments and takes the appropriate action. The binary sentiment classifier uses Model Builder in Visual Studio.
ms.date: 08/09/2019
ms.topic: tutorial
ms.custom: mvc
#Customer intent: As a developer, I want to use Model Builder to apply a binary classification task so that I can understand how to use sentiment prediction to take appropriate action.
---

# Tutorial: Analyze website comments in a web application

Learn how to analyze sentiment from comments in real-time inside a web application

In this tutorial, you learn how to:
> [!div class="checklist"]
> * Create a Razor Pages application
> * Prepare and understand the data
> * Choose a scenario
> * Load the data
> * Train the model
> * Evaluate the model
> * Use the model for predictions

> [!NOTE]
> Model Builder is currently in Preview.

## Pre-requisites

For a list of pre-requisites and installation instructions, visit the [Model Builder installation guide](../how-to-guides/install-model-builder.md).

## Create a Razor Pages application

1. Create a **ASP.NET Core Razor Pages Application** called "SentimentAnalysisRazorPages".
1. Install the *Microsoft.Extensions.ML* NuGet package:

    - In **Solution Explorer**, right-click the project and select **Manage NuGet Packages**. 
    - Choose "nuget.org" as the Package source. 
    - Select the **Browse** tab and search for **Microsoft.Extensions.ML**. 
    - Select the package in the list, and select the **Install** button. 
    - Select the **OK** button on the **Preview Changes** dialog and then select the **I Accept** button on the **License Acceptance** dialog if you agree with the license terms for the packages listed. 

## Prepare and understand the data

1. Download the [`wikipedia-detox-250-line-data.tsv`](https://raw.githubusercontent.com/dotnet/machinelearning/master/test/data/wikipedia-detox-250-line-data.tsv) dataset.

    When the web page opens, right-click anywhere on the page and select **Save as**.

## Choose a scenario

To train your model, you need to select from the list of available machine learning scenarios provided by Model Builder. In this case, the scenario is `Price Prediction`.

1. In **Solution Explorer**, right-click the *SentimentAnalysisRazorPages* project, and select **Add** > **Machine Learning**.
1. In the scenario step of the Model Builder tool, select *Sentiment Analysis* scenario.

## Load the data

Model Builder accepts data from two sources, a SQL Server database or a local file in csv or tsv format.

1. In the data step of the Model Builder tool, select *File* from the data source dropdown.
1. Select the button next to the *Select a file* text box and use File Explorer to browse and select the *wikipedia-detox-250-line-data.tsv* file.
1. Choose *fare_amount* in the *Label or Column to Predict* dropdown and navigate to the train step of the Model Builder tool.

## Train the model

The machine learning task used to train the price prediction model in this tutorial is regression. During the model training process, Model Builder trains separate models using different regression algorithms and settings to find the best performing model for your dataset.

The time required for the model to train is proportionate to the amount of data. Use this chart as guidance to select an adequate value for the `Time to train (seconds)` field:

*Dataset Size  | Dataset Type       | Avg. Time to train*
------------- | ------------------ | --------------
0 - 10 Mb     | Numeric and Text   | 10 sec
10 - 100 Mb   | Numeric and Text   | 10 min
100 - 500 Mb  | Numeric and Text   | 30 min
500 - 1 Gb    | Numeric and Text   | 60 min
1 Gb+         | Numeric and Text   | 3 hour+

1. Because the training data file is less than 10MB, use 10 seconds as the value for *Time to train (seconds)*.
2. Select *Start Training*.

Throughout the training process, progress data is displayed in the `Progress` section of the train step.

- Status displays the completion status of the training process.
- Best accuracy displays the accuracy of the best performing model found by Model Builder so far. Higher accuracy means the model predicted more correctly on test data.
- Best algorithm displays the name of the best performing algorithm performed found by Model Builder so far.
- Last algorithm displays the name of the algorithm most recently used by Model Builder to train the model.

Once training is complete, navigate to the evaluate step.

## Evaluate the model

The result of the training step will be one model which had the best performance. In the evaluate step of the Model Builder tool, the output section, will contain the algorithm used by the best performing model in the *Best Model* entry along with metrics in *Best Model Quality (RSquared)*. Additionally, a summary table containing top five models and their metrics.

If you're not satisfied with your accuracy metrics, some easy ways to try and improve model accuracy are to increase the amount of time to train the model or use more data. Otherwise, navigate to the code step.

## Add the code to make predictions

Two projects will be created as a result of the training process.

- SentimentAnalysisRazorPagesML.ConsoleApp: A .NET Core Console application that contains the model training and consumption code.
- SentimentAnalysisRazorPagesML.Model: A .NET Standard class library containing the data models that define the schema of input and output model data as well as the persisted version of the best performing model during training.

### Reference Model Builder projects

1. In the code step of the Model Builder tool, select **Add Projects** to add the auto-generated projects to the solution.
1. Right-click *SentimentAnalysisRazorPages* project. Then, **Add > Reference**. Choose the **Projects > Solution** node and from the list, check the *SentimentAnalysisRazorPagesML.Model* project and select OK.

### Configure the PredictionEngine pool

1. Open the *Startup.cs* file in the *SentimentAnalysisRazorPages* project.
1. Add the following using statements to reference the *Microsoft.ML* NuGet package and *SentimentAnalysisRazorPagesML.Model* project:

```csharp
using Microsoft.Extensions.ML;
using SampleModelBuilderWebAppML.Model.DataModels;
```

1. Create a global variable to store the location of the model file.

```csharp
private readonly string _modelPath;
```

1. The model file is stored in the build directory alongside the assembly files of your application. To make it easier to access, create a helper method called `GetAbsolutePath` after the `Configure` method

```csharp
public static string GetAbsolutePath(string relativePath)
{
    FileInfo _dataRoot = new FileInfo(typeof(Program).Assembly.Location);
    string assemblyFolderPath = _dataRoot.Directory.FullName;

    string fullPath = Path.Combine(assemblyFolderPath, relativePath);
    return fullPath;
}
```

1. Use the `GetAbsolutePath` method in the constructor of the `Startup` class to set the `_modelPath`.

```csharp
_modelPath = GetAbsolutePath("MLModel.zip");
```

1. Configure the `PredictionEnginePool` for your application in the `ConfigureServices` method:

```csharp
services.AddPredictionEnginePool<ModelInput, ModelOutput>().FromFile(_modelPath);
```

### Create sentiment analysis handler

1. Open the `Index.cshtml.cs` file located in the `Pages` directory and add the following using statements:

```csharp
using Microsoft.Extensions.ML;
using SampleModelBuilderWebAppML.Model.DataModels;
```

In order to use the `PredictionEnginePool` configured in the `Startup` class, you have to inject it into the constructor of the model where you want to use it. 

1. Add a variable to reference the `PredictionEnginePool` inside the `IndexModel`class.

```csharp
private readonly PredictionEnginePool<ModelInput, ModelOutput> _predictionEnginePool;
```

1. Create a constructor and inject the `PredictionEnginePool` into the `IndexModel` class.

```csharp
public IndexModel(PredictionEnginePool<ModelInput,ModelOutput> predictionEnginePool)
{
    _predictionEnginePool = predictionEnginePool;
}
```

1. Create a method handler that uses the `PredictionEnginePool` to make predictions from user input received from the web page.

    Below the `OnGet` method, create a new method called `OnGetAnalyzeSentiment`

    ```csharp
    public IActionResult OnGetAnalyzeSentiment([FromQuery] string text)
    {

    }
    ```

    Add the following code to inside the `OnGetAnalyzeSentiment` method to create a new `ModelInput`

    ```csharp
    var input = new ModelInput { SentimentText = text };
    ``` 

    Use the `PredictionEnginePool` to predict sentiment.

    ```csharp
    var prediction = _predictionEnginePool.Predict(input);
    ```

    The prediction needs to be converted to a percentage between 0-100. Use the sigmoid function to do so.

    $
    y = \frac{1}{1+x^n}
    $

    ```csharp
    float percentage = 100 * (1.0f / (1.0f + (float) Math.Exp(-prediction.Score)));
    ```

    Finally, return the percentage back to the web page.

    ```csharp
    return Content(percentage.ToString("0.0"));
    ```

### Configure the web page

The results will be displayed on the `Index` web page.

Open the `Index` file in the `Pages` directory and replace the existing HTML code with the following: 

```html
<div class="text-center">
    <h2>Live Sentiment</h2>

    <p><textarea id="Message" cols="45" placeholder="Type any text like a short product review"></textarea></p>

    <div class="sentiment">
        <h4>Your sentiment is...</h4>
        <p>😡🙁😐😃😍</p>

        <div class="marker">
            <div id="markerPosition" style="left: 50%;">
                <div>▲</div>
                <label id="markerValue">50.0%</label>
            </div>
        </div>
    </div>
</div>
```

Next, add code to style the HTML by adding the following code to the end of the `site.css` page in the `wwwroot\css` directory:

```css
/* Style for sentiment display */

.sentiment {
    background-color: #eee;
    position: relative;
    display: inline-block;
    padding: 1rem;
    padding-bottom: 0;
    border-radius: 1rem;
}

.sentiment h4 {
    font-size: 16px;
    text-align: center;
    margin: 0;
    padding: 0;
}

.sentiment p {
    font-size: 50px;
}

.sentiment .marker {
    position: relative;
    left: 22px;
    width: calc(100% - 68px);
}

.sentiment .marker > div {
    transition: 0.3s ease-in-out;
    position: absolute;
    margin-left: -30px;
    text-align: center;
}

.sentiment .marker > div > div {
    font-size: 50px;
    line-height: 20px;
    color: green;
}

.sentiment .marker > div label {
    font-size: 30px;
    color: gray;
}
```

After that, add code to send inputs from the web page to the `OnGetAnalyzeSentiment` handler

In the `site.js` file located in the `wwwroot\js` directory, create a function called `getSentiment` to make a GET request with the user input to the `OnGetAnalyzeSentiment` handler.

```js
function getSentiment(userInput) {
    return fetch(`Index?handler=AnalyzeSentiment&text=${userInput}`)
        .then((response) => {
            return response.text();
        })
}
```

Below that, add another function called `updateMarker` to dynamically update the position of the marker on the web page as sentiment is predicted.

```js
function updateMarker(sentiment) {
    $("#markerPosition").attr("style", `left:${sentiment}%`);
    $("#markerValue").text(sentiment);
}
```

Create an event handler function called `updateSentiment` to get the input from the user, send it to the `OnGetAnalyzeSentiment` function using the `getSentiment` function and update the marker with the `updateMarker` function.

```js
function updateSentiment() {

    var userInput = $("#Message").val();

    getSentiment(userInput)
        .then((sentiment) => {
            updateMarker(sentiment);
        });
}
```

Finally, register the handler and bind it to the `textarea` element with the `id=Message` attribute.

```js
$("#Message").on('input paste', updateSentiment)
```

## Run the application

Now that your application is set up, run the application which should launch in your browser.

INSERT SCREENSHOT / GIF


If you need to reference the generated projects at a later time inside of another solution, you can find them inside the `C:\Users\%USERNAME%\AppData\Local\Temp\MLVSTools` directory.

## Next steps

In this tutorial, you learned how to:
> [!div class="checklist"]
> * Create a Razor Pages application
> * Prepare and understand the data
> * Choose a scenario
> * Load the data
> * Train the model
> * Evaluate the model
> * Use the model for predictions

### Additional Resources

To learn more about topics mentioned in this tutorial, visit the following resources:

- [Model Builder Scenarios](../automate-training-with-model-builder.md#scenarios)
- [Model Builder Data Formats](../automate-training-with-model-builder.md#data-formats)
- [Regression](../resources/glossary#binary-classification)
- [Binary Classification Model Metrics](../resources/metrics.md#metrics-for-binary-classification)
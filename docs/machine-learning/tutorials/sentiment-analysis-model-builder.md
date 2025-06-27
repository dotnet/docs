---
title: 'Tutorial: Analyze sentiment - Text Classification'
description: This tutorial shows you how to create a Razor Pages application that classifies sentiment from website comments and takes the appropriate action. The classification uses the Text Classification scenario in the Model Builder Visual Studio extension.
ms.date: 11/10/2022
author: luisquintanilla
ms.author: luquinta
ms.topic: tutorial
ms.custom: mvc,mlnet-tooling
#Customer intent: As a developer, I want to use Model Builder to apply a binary classification task so that I can understand how to use sentiment prediction to take appropriate action.
---

# Tutorial: Analyze sentiment of website comments in a web application using ML.NET Model Builder

Learn how to analyze sentiment from comments in real time inside a web application.

This tutorial shows you how to create an ASP.NET Core Razor Pages application that classifies sentiment from website comments in real time.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Create an ASP.NET Core Razor Pages application
> - Prepare and understand the data
> - Choose a scenario
> - Load the data
> - Train the model
> - Evaluate the model
> - Use the model for predictions

You can find the source code for this tutorial at the [dotnet/machinelearning-samples](https://github.com/dotnet/machinelearning-samples) repository.

## Prerequisites

For a list of prerequisites and installation instructions, visit the [Model Builder installation guide](../how-to-guides/install-model-builder.md).

## Create a Razor Pages application

Create an **ASP.NET Core Razor Pages Application**.

1. In Visual Studio open the **Create a new project** dialog.
1. In the "Create a new project" dialog, select the **ASP.NET Core Web App** project template.
1. In the **Name** text box, type "SentimentRazor" and select **Next**.
1. In the Additional information dialog, leave all the defaults as is and select **Create**.

## Prepare and understand the data

Download [Wikipedia detox dataset](https://raw.githubusercontent.com/dotnet/machinelearning/main/test/data/wikipedia-detox-250-line-data.tsv). When the webpage opens, right-click on the page, select **Save As** and save the file anywhere on your computer.

Each row in the *wikipedia-detox-250-line-data.tsv* dataset represents a different review left by a user on Wikipedia. The first column represents the sentiment of the text (0 is non-toxic, 1 is toxic), and the second column represents the comment left by the user. The columns are separated by tabs. The data looks like the following:

| Sentiment | SentimentText                                                       |
|:---------:|:-------------------------------------------------------------------:|
| 1         | ==RUDE== Dude, you are rude upload that carl picture back, or else. |
| 1         | == OK! ==  IM GOING TO VANDALIZE WILD ONES WIKI THEN!!!             |
| 0         | I hope this helps.                                                  |

## Create a Model Builder config file

When first adding a machine learning model to the solution it will prompt you to create an `mbconfig` file. The `mbconfig` file keeps track of everything you do in Model Builder to allow you to reopen the session.

1. In **Solution Explorer**, right-click the *SentimentRazor* project, and select **Add** > **Machine Learning Model**.
1. In the dialog, name the Model Builder project **SentimentAnalysis.mbconfig**, and select **Add**.

## Choose a scenario

:::image type="content" source="../media/model-builder-scenarios-2-0.png" alt-text="Model Builder Scenario Screen" lightbox="../media/model-builder-scenarios-2-0.png":::

To train your model, you need to select from the list of available machine learning scenarios provided by Model Builder.

For this sample, the task is text classification. In the *Scenario* step of the Model Builder extension, select the **Text classification** scenario.

## Select an environment

Model Builder can train on different environments depending on the selected scenario.

Select **Local (GPU)** as your environment and click the **Next step** button.

> [!NOTE]
> This scenario uses deep learning techniques which work best in GPU environments. If you don't have a GPU, choose the Local (CPU) environment but note that the expected time to train will be significantly longer. For more information on using GPUs with Model Builder, see the [GPU support in Model Builder guide](../how-to-guides/install-gpu-model-builder.md).

## Load the data

Model Builder accepts data from two sources, a SQL Server database or a local file in `csv` or `tsv` format.

1. In the data step of the Model Builder tool, select **File** from the data source options.
1. Select the button next to the **Select a file** text box and use File Explorer to browse and select the *wikipedia-detox-250-line-data.tsv* file.
1. Choose **Sentiment** from the **Column to predict (Label)** dropdown.
1. Choose **SentimentText** from the **Text Column** dropdown.
1. Select the **Next step** button to move to the next step in Model Builder.

## Train the model

The machine learning task used to train the sentiment analysis model in this tutorial is text classification. During the model training process, Model Builder trains a text classification model for your dataset using the [NAS-BERT](https://arxiv.org/abs/2105.14444) neural network architecture.

1. Select **Start Training**.
1. Once training is complete, the results from the training process are displayed in the *Training results* section of the *Train* screen.
    In addition to providing training results, three code-behind files are created under the *SentimentAnalysis.mbconfig* file.

    - *SentimentAnalysis.consumption.cs* -  This file contains the `ModelInput` and `ModelOutput` schemas as well as the `Predict` function generated for consuming the model.
    - *SentimentAnalysis.training.cs* - This file contains the training pipeline (data transforms, trainer, trainer hyperparameters) chosen by Model Builder to train the model. You can use this pipeline for re-training your model.
    - **SentimentAnalysis.mlnet* - This file contains metadata and configuration details for an ML.NET model.

1. Select the **Next step** button to move to the next step.

## Evaluate the model

The result of the training step will be one model that has the best performance. In the evaluate step of the Model Builder tool, the output section will contain the trainer used by the best-performing model in the as well as evaluation metrics.

If you're not satisfied with your evaluation metrics, some easy ways to try to improve model performance are to use more data.

Otherwise, select the **Next step** button to move to the *Consume* step in Model Builder.

## Add consumption project templates (Optional)

In the *Consume* step, Model Builder provides project templates that you can use to consume the model. This step is optional and you can choose the method that best fits your needs for using the model.

- Console application
- Web API

## Add the code to make predictions

### Configure the PredictionEngine pool

To make a single prediction, you have to create a <xref:Microsoft.ML.PredictionEngine%602>. <xref:Microsoft.ML.PredictionEngine%602> is not thread-safe. Additionally, you have to create an instance of it everywhere it's needed within your application. As your application grows, this process can become unmanageable. For improved performance and thread safety, use a combination of dependency injection and the `PredictionEnginePool` service, which creates an <xref:Microsoft.Extensions.ObjectPool.ObjectPool%601> of <xref:Microsoft.ML.PredictionEngine%602> objects for use throughout your application.

1. Install the *Microsoft.Extensions.ML* NuGet package:

    1. In **Solution Explorer**, right-click the project and select **Manage NuGet Packages**.
    1. Choose "nuget.org" as the Package source.
    1. Select the **Browse** tab and search for **Microsoft.Extensions.ML**.
    1. Select the package in the list, and select **Install**.
    1. Select the **OK** button on the **Preview Changes** dialog
    1. Select the **I Accept** button on the **License Acceptance** dialog if you agree with the license terms for the packages listed.

1. Open the *Program.cs* file in the *SentimentRazor* project.
1. Add the following `using` directives to reference the *Microsoft.Extensions.ML* NuGet package and *SentimentRazorML.Model* project:

    ```csharp
    using Microsoft.Extensions.ML;
    using static SentimentRazor.SentimentAnalysis;
    ```

1. Configure the <xref:Microsoft.Extensions.ML.PredictionEnginePool%602> for your application in the *Program.cs* file:

    ```csharp
    builder.Services.AddPredictionEnginePool<ModelInput, ModelOutput>()
        .FromFile("SentimentAnalysis.mlnet");
    ```

### Create sentiment analysis handler

Predictions will be made inside the main page of the application. Therefore, a method that takes the user input and uses the <xref:Microsoft.Extensions.ML.PredictionEnginePool%602> to return a prediction needs to be added.

1. Open the *Index.cshtml.cs* file located in the *Pages* directory and add the following `using` directives:

    ```csharp
    using Microsoft.Extensions.ML;
    using static SentimentRazor.SentimentAnalysis;
    ```

    In order to use the <xref:Microsoft.Extensions.ML.PredictionEnginePool%602> configured in the *Program.cs* file, you have to inject it into the constructor of the model where you want to use it.

1. Add a variable to reference the <xref:Microsoft.Extensions.ML.PredictionEnginePool%602> inside the `IndexModel` class inside the *Pages/Index.cshtml.cs* file.

    ```csharp
    private readonly PredictionEnginePool<ModelInput, ModelOutput> _predictionEnginePool;
    ```

1. Modify the constructor in the `IndexModel` class and inject the <xref:Microsoft.Extensions.ML.PredictionEnginePool%602> service into it.

    ```csharp
    public IndexModel(ILogger<IndexModel> logger, PredictionEnginePool<ModelInput, ModelOutput> predictionEnginePool)
    {
        _logger = logger;
        _predictionEnginePool = predictionEnginePool;
    }
    ```

1. Create a method handler that uses the `PredictionEnginePool` to make predictions from user input received from the web page.

    1. Below the `OnGet` method, create a new method called `OnGetAnalyzeSentiment`

        ```csharp
        public IActionResult OnGetAnalyzeSentiment([FromQuery] string text)
        {

        }
        ```

    1. Inside the `OnGetAnalyzeSentiment` method, return *Neutral* sentiment if the input from the user is blank or null.

        ```csharp
        if (String.IsNullOrEmpty(text)) return Content("Neutral");
        ```

    1. Given a valid input, create a new instance of `ModelInput`.

        ```csharp
        var input = new ModelInput { SentimentText = text };
        ```

    1. Use the <xref:Microsoft.Extensions.ML.PredictionEnginePool%602> to predict sentiment.

        ```csharp
        var prediction = _predictionEnginePool.Predict(input);
        ```

    1. Convert the predicted `bool` value into toxic or not toxic with the following code.

        ```csharp
        var sentiment = Convert.ToBoolean(prediction.PredictedLabel) ? "Toxic" : "Not Toxic";
        ```

    1. Finally, return the sentiment back to the web page.

        ```csharp
        return Content(sentiment);
        ```

### Configure the web page

The results returned by the `OnGetAnalyzeSentiment` will be dynamically displayed on the `Index` web page.

1. Open the *Index.cshtml* file in the *Pages* directory and replace its contents with the following code:

    ```cshtml
    @page
    @model IndexModel
    @{
        ViewData["Title"] = "Home page";
    }

    <div class="text-center">
        <h2>Live Sentiment</h2>

        <p><textarea id="Message" cols="45" placeholder="Type any text like a short review"></textarea></p>

        <div class="sentiment">
            <h4>Your sentiment is...</h4>
            <p>😡 😐 😍</p>

            <div class="marker">
                <div id="markerPosition" style="left: 45%;">
                    <div>▲</div>
                    <label id="markerValue">Neutral</label>
                </div>
            </div>
        </div>
    </div>
    ```

1. Next, add css styling code to the end of the *site.css* page in the *wwwroot\css* directory:

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

1. After that, add code to send inputs from the web page to the `OnGetAnalyzeSentiment` handler.

    1. In the *site.js* file located in the *wwwroot\js* directory, create a function called `getSentiment` to make a GET HTTP request with the user input to the `OnGetAnalyzeSentiment` handler.

        ```javascript
        function getSentiment(userInput) {
            return fetch(`Index?handler=AnalyzeSentiment&text=${userInput}`)
                .then((response) => {
                    return response.text();
                })
        }
        ```

    1. Below that, add another function called `updateMarker` to dynamically update the position of the marker on the web page as sentiment is predicted.

        ```javascript
        function updateMarker(markerPosition, sentiment) {
            $("#markerPosition").attr("style", `left:${markerPosition}%`);
            $("#markerValue").text(sentiment);
        }
        ```

    1. Create an event handler function called `updateSentiment` to get the input from the user, send it to the `OnGetAnalyzeSentiment` function using the `getSentiment` function and update the marker with the `updateMarker` function.

        ```javascript
        function updateSentiment() {

            var userInput = $("#Message").val();

            getSentiment(userInput)
                .then((sentiment) => {
                    switch (sentiment) {
                        case "Not Toxic":
                            updateMarker(100.0, sentiment);
                            break;
                        case "Toxic":
                            updateMarker(0.0, sentiment);
                            break;
                        default:
                            updateMarker(45.0, "Neutral");
                    }
                });
        }
        ```

    1. Finally, register the event handler and bind it to the `textarea` element with the `id=Message` attribute.

        ```javascript
        $("#Message").on('change input paste', updateSentiment)
        ```

## Run the application

Now that your application is set up, run the application, which should launch in your browser.

When the application launches, enter *This model doesn't have enough data!* into the text area. The predicted sentiment displayed should be *Toxic*.

![Running window with the predicted sentiment window](./media/sentiment-analysis-model-builder/web-app.png)

> [!NOTE]
> <xref:Microsoft.Extensions.ML.PredictionEnginePool%602> creates multiple instances of <xref:Microsoft.ML.PredictionEngine%602>. Because of the size of the model, the first time you use it to make a prediction, it can take a couple of seconds. Subsequent predictions should be instantaneous.

## Next steps

In this tutorial, you learned how to:
> [!div class="checklist"]
>
> - Create an ASP.NET Core Razor Pages application
> - Prepare and understand the data
> - Choose a scenario
> - Load the data
> - Train the model
> - Evaluate the model
> - Use the model for predictions

### Additional Resources

To learn more about topics mentioned in this tutorial, visit the following resources:

- [Model Builder Scenarios](../automate-training-with-model-builder.md#scenario)
- [Text Classification Model Metrics](../resources/metrics.md#evaluation-metrics-for-multi-class-classification-and-text-classification)

---
title: 'Tutorial: Train a movie recommendation model using Model Builder'
description: Learn how to train a recommendation model to recommend movies using Model Builder
author: luisquintanilla
ms.author: luquinta
ms.date: 10/20/2021
ms.topic: tutorial
ms.custom: mlnet-tooling
#Customer intent: As a non-developer, I want to use Model Builder to automatically train a model to recommend movies.
---

# Train a recommendation model using Model Builder

Learn how to train a recommendation model using Model Builder to recommend movies.

In this tutorial, you:

> [!div class="checklist"]
>
> - Prepare and understand the data
> - Create a Model Builder config file
> - Choose a scenario
> - Load the data
> - Train the model
> - Evaluate the model
> - Consume the model

> [!NOTE]
> Model Builder is currently in Preview.

## Prerequisites

For a list of pre-requisites and installation instructions, visit the [Model Builder installation guide](../how-to-guides/install-model-builder.md).

## Create a C# Class Library

Create a **C# Class Library** called "MovieRecommender".

## Prepare and understand the data

There are several ways to approach recommendation problems, such as recommending a list of movies or recommending a list of related products, but in this case you will predict what rating (1-5) a user will give to a particular movie and recommend that movie if it's higher than a defined threshold (the higher the rating, the higher the likelihood of a user liking a particular movie).

Right click on [*recommendation-ratings-train.csv*](https://raw.githubusercontent.com/dotnet/machinelearning-samples/main/samples/csharp/getting-started/MatrixFactorization_MovieRecommendation/Data/recommendation-ratings-train.csv) and select "Save Link (or Target) As..."

Each row in the dataset contains information regarding a movie rating.

| userId | movieId | rating | timestamp |
| --- | --- | --- | --- |
| 1 | 1 | 4 | 964982703 |

- **userId**: The ID of the user
- **movieId** The ID of the movie
- **rating**: The rating the user made to the movie
- **timestamp**: The timestamp the review was made

## Create a Model Builder config file

When first adding Model Builder to the solution it will prompt you to create an `mbconfig` file. The `mbconfig` file keeps track of everything you do in Model Builder to allow you to reopen the session.

1. In Solution Explorer, right-click the **MovieRecommender** project, and select **Add > Machine Learning Model...**.
1. In the dialog, name the Model Builder project **MovieRecommender**, and click **Add**.

## Choose a scenario

![Model Builder Scenarios](../media/model-builder-scenarios.png)

To train your model, you need to select from the list of available machine learning scenarios provided by Model Builder.

For this sample, the task is image classification. In the scenario step of the Model Builder tool, select the **Recommendation** scenario.

## Select an environment

Model Builder can run the training on different environments depending on the scenario that was selected.

Select **Local** as your environment and click the **Next step** button.

## Load the data

1. In the data step of the Model Builder tool, select the button next to the **Select a folder** text box.
1. Use File Explorer to browse and select the downloaded file - **recommendation-ratings-train.csv**.
1. Select the **Next step** button to move to the next step in the Model Builder tool.
1. Once the data is loaded, in the **Column to predict** dropdown select **Rating**.
1. For the **User column** dropdown select **userId**.
1. For the **Item column** dropdown select **movieId**.

## Train the model

The machine learning algorithm used to train the recommendation model is Matrix Factorization. During the model training process, Model Builder uses different settings for the algorithm to find the best performing model for your dataset.

The time required for the model to train is proportional to the amount of data. Model Builder automatically selects a default value for **Time to train (seconds)** based on the size of your data source.

1. Model Builder sets the value of **Time to train (seconds)** to 60 seconds. Training for a longer period of time allows Model Builder to explore a larger number of algorithms and combination of parameters in search of the best model.
1. Click **Start Training**.

Throughout the training process, progress data is displayed in the `Training results` section of the train step.

- Status displays the completion status of the training process.
- Best quality the R Squared of the best performing model found by Model Builder so far. The lower R Squared means the model predicted more correctly on test data.
- Best algorithm displays the name of the best performing algorithm performed found by Model Builder so far.
- Last algorithm displays the name of the algorithm most recently used by Model Builder to train the model.

Once training is complete the `mbconfig` file will have the generated model called `MovieRecommender.zip` after training and two C# files with it:

- **MovieRecommender.consumption.cs**: This file has a public method `Predict` that loads the model and creates a [PredictionEngine](xref:Microsoft.ML.PredictionEngine%602) to make predictions. [PredictionEngine](xref:Microsoft.ML.PredictionEngine%602) is a convenience API for making predictions on a single data instance.
- **MovieRecommender.training.cs**: This file consists of the training pipeline that Model Builder came up with to build the best model including any hyperparameters that it used.

Click the **Next step** button to navigate to the evaluate step.

## Evaluate the model

The result of the training step will be one model which had the best performance. In the evaluate step of the Model Builder tool, in the **Best model** section, will contain the algorithm used by the best performing model in the *Model* entry along with metrics for that model in *RSquared*.

Additionally, in the **Output** window of Visual Studio, there will be a summary table containing top models and their metrics.

In this section you can also test your model by performing a single prediction. It provides you with text boxes to input values for each of your feature columns and you can select the **Predict** button to get a prediction using the best model. By default this will be filled in by the first row in your dataset.

## (Optional) Consume the model

This step will have project templates that you can use to consume the model. This step is optional and you can choose the method that best suits your needs on how to serve the model.

- Console App
- Web API

### Console App

When adding a console app to your solution, you will be prompted to name the project.

1. Select **Add to solution** for the console template.
1. Name the console project **MovieRecommender_Console**.
1. Click **Add to solution** to add the project to your current solution.
1. Run the application.

    The output generated by the program should look similar to the snippet below:

    ```bash
    UserId: 1
    MovieId: 1
    Rating: 4

    Predicted Rating: 4.577113
    ```

### Web API

When adding a web API to your solution, you will be prompted to name the project.

1. Select **Add to solution** for the Web API template.
1. Name the Web API project **MovieRecommender_WebApi**.
1. Click *Add to solution** to add the project to your current solution.
1. Run the application.
1. Open PowerShell and enter the following code where PORT is the port your application is listening on.

    ```powershell
    $body = @{
        UserId=1.0
        MovieId=1.0
    }

    Invoke-RestMethod "https://localhost:<PORT>/predict" -Method Post -Body ($body | ConvertTo-Json) -ContentType "application/json"
    ```

1. If successful, the output should look similar to the text below. The **score** output will be the predicted rating for the requested user ID and movie ID.

    ```powershell
    score
    -----
    4.577113
    ```

Congratulations! You've successfully built a machine learning model to categorize the risk of health violations using Model Builder. You can find the source code for this tutorial at the [dotnet/machinelearning-samples](https://github.com/dotnet/machinelearning-samples/tree/main/samples/modelbuilder/MatrixFactorization_MovieRecommendation) GitHub repository.

## Additional resources

To learn more about topics mentioned in this tutorial, visit the following resources:

- [Model Builder Scenarios](../automate-training-with-model-builder.md#scenario)
- [Movie Recommendation in the ML.NET API](./movie-recommendation.md)

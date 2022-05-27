---
title: 'Tutorial: Classify health violations with Model Builder'
description: This tutorial illustrates how to build a multiclass classification model using ML.NET Model Builder to classify restaurant health violation severity in San Francisco.
author: luisquintanilla
ms.author: luquinta
ms.date: 09/20/2021
ms.topic: tutorial
ms.custom: mvc,mlnet-tooling
#Customer intent: As a non-developer, I want to use Model Builder to automatically generate a model to classify violation severity using Model Builder.
---

# Tutorial: Classify the severity of restaurant health violations with Model Builder

Learn how to build a multiclass classification model using Model Builder to categorize the risk level of restaurant violations found during health inspections.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Prepare and understand the data
> - Create a Model Builder config file
> - Choose a scenario
> - Load data from a database
> - Train the model
> - Evaluate the model
> - Use the model for predictions

> [!NOTE]
> Model Builder is currently in Preview.

## Prerequisites

For a list of prerequisites and installation instructions, visit the [Model Builder installation guide](../how-to-guides/install-model-builder.md).

## Model Builder multiclass classification overview

This sample creates a C# .NET Core console application that categorizes the risk of health violations using a machine learning model built with Model Builder. You can find the source code for this tutorial at the [dotnet/machinelearning-samples](https://github.com/dotnet/machinelearning-samples/tree/main/samples/modelbuilder/MulticlassClassification_RestaurantViolations) GitHub repository.

## Create a console application

1. Create a **C# .NET Core console application** called "RestaurantViolations".

## Prepare and understand the data

> The data set used to train and evaluate the machine learning model is originally from the [San Francisco Department of Public Health Restaurant Safety Scores](https://www.sfdph.org/dph/EH/Food/score/default.asp). For convenience, the dataset has been condensed to only include the columns relevant to train the model and make predictions. Visit the following website to learn more about the [dataset](https://data.sfgov.org/Health-and-Social-Services/Restaurant-Scores-LIVES-Standard/pyih-qa8i?row_index=0).

[Download the Restaurant Safety Scores dataset](https://github.com/dotnet/machinelearning-samples/raw/main/samples/modelbuilder/MulticlassClassification_RestaurantViolations/RestaurantScores.zip) and unzip it.

Each row in the dataset contains information regarding violations observed during an inspection from the Health Department and a risk assessment of the threat those violations present to public health and safety.

| InspectionType | ViolationDescription | RiskCategory |
| --- | --- | --- |
| Routine - Unscheduled | Inadequately cleaned or sanitized food contact surfaces | Moderate Risk |
| New Ownership | High risk vermin infestation | High Risk |
| Routine - Unscheduled | Wiping cloths not clean or properly stored or inadequate sanitizer | Low Risk |

- **InspectionType**: the type of inspection. This can either be a first-time inspection for a new establishment, a routine inspection, a complaint inspection, and many other types.
- **ViolationDescription**: a description of the violation found during inspection.
- **RiskCategory**: the risk severity a violation poses to public health and safety.

The `label` is the column you want to predict. When performing a classification task, the goal is to assign a category (text or numerical). In this classification scenario, the severity of the violation is assigned the value of low, moderate, or high risk. Therefore, the **RiskCategory** is the label. The `features` are the inputs you give the model to predict the `label`. In this case, the **InspectionType** and **ViolationDescription** are used as features or inputs to predict the **RiskCategory**.

## Create Model Builder Config File

When first adding Model Builder to the solution it will prompt you to create an `mbconfig` file. The `mbconfig` file keeps track of everything you do in Model Builder to allow you to reopen the session.

1. In **Solution Explorer**, right-click the *RestaurantViolations* project, and select **Add** > **Machine Learning Model...**.
1. Name the `mbconfig` project **RestaurantViolationsPrediction**, and click the **Add** button.

## Choose a scenario

![Model Builder wizard in Visual Studio](../media/model-builder-scenarios.png)

To train your model, select from the list of available machine learning scenarios provided by Model Builder. In this case, the scenario is *Data classification*.

1. For this sample, the task is multiclass classification. In the *Scenario* step of Model Builder, select the **Data classification** scenario.

## Load the data

Model Builder accepts data from a SQL Server database or a local file in `csv`, `tsv`, or `txt` format.

1. In the data step of the Model Builder tool, select **SQL Server** from the data source type selection.
1. Select the **Choose data source** button.
    1. In the **Choose Data Source** dialog, select **Microsoft SQL Server Database File**.
    1. Uncheck the **Always use this selection** checkbox and click **Continue**.
    1. In the **Connection Properties** dialog, select **Browse** and select the downloaded *RestaurantScores.mdf* file.
    1. Select **OK**.
1. Choose **Violations** from the **Table** dropdown.
1. Choose **RiskCategory** in the **Column to predict (Label)** dropdown.
1. Leave the default selections in **Advanced data options**.
1. Click the **Next step** button to move to the train step in Model Builder.

## Train the model

The machine learning task used to train the issue classification model in this tutorial is multiclass classification. During the model training process, Model Builder trains separate models using different multiclass classification algorithms and settings to find the best performing model for your dataset.

The time required for the model to train is proportional to the amount of data. Model Builder automatically selects a default value for **Time to train (seconds)** based on the size of your data source.

1. Model Builder sets the value of **Time to train (seconds)** to 60 seconds. Training for a longer period of time allows Model Builder to explore a larger number of algorithms and combination of parameters in search of the best model.
1. Click **Start Training**.

Throughout the training process, progress data is displayed in the `Training results` section of the train step.

- Status displays the completion status of the training process.
- Best accuracy displays the accuracy of the best performing model found by Model Builder so far. Higher accuracy means the model predicted more correctly on test data.
- Best algorithm displays the name of the best performing algorithm performed found by Model Builder so far.
- Last algorithm displays the name of the algorithm most recently used by Model Builder to train the model.

Once training is complete the `mbconfig` file will have the generated model called `RestaurantViolationsPrediction.zip` after training and two C# files with it:

- **RestaurantViolationsPrediction.consumption.cs**: This file has a public method that will load the model and create a prediction engine with it and return the prediction.
- **RestaurantViolationsPrediction.training.cs**: This file consists of the training pipeline that Model Builder came up with to build the best model including any hyperparameters that it used.

Click the **Next step** button to navigate to the evaluate step.

## Evaluate the model

The result of the training step will be one model which had the best performance. In the evaluate step of the Model Builder tool, in the **Best model** section, will contain the algorithm used by the best performing model in the *Model* entry along with metrics for that model in *Accuracy*.

Additionally, in the **Output** window of Visual Studio, there will be a summary table containing top models and their metrics.

This section will also allow you to test your model by performing a single prediction. It will offer text boxes to fill in values and you can click the **Predict** button to get a prediction from the best model. By default this will be filled in by a random row in your dataset.

## (Optional) Consume the model

This step will have project templates that you can use to consume the model. This step is optional and you can choose the method that best suits your needs on how to serve the model.

- Console App
- Web API

### Console App

When adding a console app to your solution, you will be prompted to name the project.

1. Name the console project **RestaurantViolationsPrediction_Console**.
1. Click **Add to solution** to add the project to your current solution.
1. Run the application.

    The output generated by the program should look similar to the snippet below:

    ```bash
    InspectionType: Routine - Unscheduled
    ViolationDescription: Moderate risk food holding temperature

    Predicted RiskCategory: Moderate Risk
    ```

### Web API

When adding a web API to your solution, you will be prompted to name the project.

1. Name the Web API project **RestaurantViolationsPrediction_API**.
1. Click *Add to solution** to add the project to your current solution.
1. Run the application.
1. Open PowerShell and enter the following code where PORT is the port your application is listening on.

    ```powershell
    $body = @{
        InspectionType="Reinspection/Followup"
        ViolationDescription="Inadequately cleaned or sanitized food contact surfaces"
    }

    Invoke-RestMethod "https://localhost:<PORT>/predict" -Method Post -Body ($body | ConvertTo-Json) -ContentType "application/json"
    ```

1. If successful, the output should look similar to the text below. The output has the predicted **RiskCategory** as _Moderate Risk_ and it has the scores of each of the input labels - _Low Risk_, _High Risk_, and _Moderate Risk_.

    ```powershell
    prediction    score
    ----------    -----
    Moderate Risk {0.055566575, 0.058012854, 0.88642055}
    ```

Congratulations! You've successfully built a machine learning model to categorize the risk of health violations using Model Builder. You can find the source code for this tutorial at the [dotnet/machinelearning-samples](https://github.com/dotnet/machinelearning-samples/tree/main/samples/modelbuilder/MulticlassClassification_RestaurantViolations) GitHub repository.

## Additional resources

To learn more about topics mentioned in this tutorial, visit the following resources:

- [Model Builder Scenarios](../automate-training-with-model-builder.md#scenario)
- [Multiclass Classification](../resources/glossary.md#multiclass-classification)
- [Multiclass Classification Model Metrics](../resources/metrics.md#evaluation-metrics-for-multi-class-classification)

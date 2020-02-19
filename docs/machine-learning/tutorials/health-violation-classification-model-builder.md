---
title: 'Tutorial: Classify health violations with Model Builder'
description: This tutorial illustrates how to build a multiclass classification model using ML.NET Model Builder to classify restaurant health violation severity in San Francisco.
author: luisquintanilla
ms.author: luquinta
ms.date: 11/21/2019
ms.topic: tutorial
ms.custom: mvc
#Customer intent: As a non-developer, I want to use Model Builder to automatically generate a model to classify violation severity using Model Builder.
---

# Tutorial: Classify the severity of restaurant health violations with Model Builder

Learn how to build a multiclass classification model using Model Builder to categorize the risk level of restaurant violations found during health inspections.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Prepare and understand the data
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

This sample creates a C# .NET Core console application that categorizes the risk of health violations using a machine learning model built with Model Builder. You can find the source code for this tutorial at the [dotnet/machinelearning-samples](https://github.com/dotnet/machinelearning-samples/tree/master/samples/modelbuilder/MulticlassClassification_RestaurantViolations) GitHub repository.

## Create a console application

1. Create a **C# .NET Core console application** called "RestaurantViolations". Make sure **Place solution and project in the same directory** is **unchecked** (VS 2019), or **Create directory for solution** is **checked** (VS 2017).

## Prepare and understand the data

> The data set used to train and evaluate the machine learning model is originally from the [San Francisco Department of Public Health Restaurant Safety Scores](https://www.sfdph.org/dph/EH/Food/score/default.asp). For convenience, the dataset has been condensed to only include the columns relevant to train the model and make predictions. Visit the following website to learn more about the [dataset](https://data.sfgov.org/Health-and-Social-Services/Restaurant-Scores-LIVES-Standard/pyih-qa8i?row_index=0).

[Download the Restaurant Safety Scores dataset](https://github.com/luisquintanilla/machinelearning-samples/raw/AB1608219/samples/modelbuilder/MulticlassClassification_RestaurantViolations/RestaurantScores.zip) and unzip it.

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

## Choose a scenario

![Model Builder wizard in Visual Studio](./media/sentiment-analysis-model-builder/model-builder-screen.png)

To train your model, select from the list of available machine learning scenarios provided by Model Builder. In this case, the scenario is *Issue Classification*.

1. In **Solution Explorer**, right-click the *RestaurantViolations* project, and select **Add** > **Machine Learning**.
1. For this sample, the scenario is multiclass classification. In the *Scenario* step of Model Builder, select the **Issue Classification** scenario.

## Load the data

Model Builder accepts data from a SQL Server database or a local file in `csv` or `tsv` format.

1. In the data step of the Model Builder tool, select **SQL Server** from the data source dropdown.
1. Select the button next to the **Connect to SQL Server database** text box.
    1. In the **Choose Data** dialog, select **Microsoft SQL Server Database File**.
    1. Uncheck the **Always use this selection** checkbox and select **Continue**.
    1. In the **Connection Properties** dialog, select **Browse** and select the downloaded *RestaurantScores.mdf* file.
    1. Select **OK**.
1. Choose **Violations** from the **Table Name** dropdown.
1. Choose **RiskCategory** in the **Column to Predict (Label)** dropdown.
1. Leave the default column selections, **InspectionType** and **ViolationDescription**, checked in the **Input Columns (Features)** dropdown.
1. Select the **Train** link to move to the next step in Model Builder.

## Train the model

The machine learning task used to train the issue classification model in this tutorial is multiclass classification. During the model training process, Model Builder trains separate models using different multiclass classification algorithms and settings to find the best performing model for your dataset.

The time required for the model to train is proportional to the amount of data. Model Builder automatically selects a default value for **Time to train (seconds)** based on the size of your data source.

1. Although Model Builder sets the value of **Time to train (seconds)** to 10 seconds, increase it to 30 seconds. Training for a longer period of time allows Model Builder to explore a larger number of algorithms and combination of parameters in search of the best model.
1. Select **Start Training**.

    Throughout the training process, progress data is displayed in the `Progress` section of the train step.

    - **Status** displays the completion status of the training process.
    - **Best accuracy** displays the accuracy of the best performing model found by Model Builder so far. Higher accuracy means the model predicted more correctly on test data.
    - **Best algorithm** displays the name of the best-performing algorithm found by Model Builder so far.
    - **Last algorithm** displays the name of the algorithm most recently used by Model Builder to train the model.

1. Once training is complete, select the **Evaluate** link to move to the next step.

## Evaluate the model

The result of the training step is the one model that had the best performance. In the evaluate step of Model Builder, the output section contains the algorithm used by the best performing model in the **Best Model** entry along with metrics in **Best Model Accuracy**. Additionally, a summary table containing up to five models that were explored and their metrics is displayed.

If you're not satisfied with your accuracy metrics, some easy ways to try to improve model accuracy are to increase the amount of time to train the model or use more data. Otherwise, select the **code** link to move to the final step in Model Builder.

## Add the code to make predictions

Two projects are created as a result of the training process.

- RestaurantViolationsML.ConsoleApp: A C# .NET Core Console application that contains the model training and sample consumption code.
- RestaurantViolationsML.Model: A .NET Standard class library containing the data models that define the schema of input and output model data, the saved version of the best performing model during training, and a helper class called `ConsumeModel` to make predictions.

1. In the code step of Model Builder, select **Add Projects** to add the autogenerated projects to the solution.
1. Open the *Program.cs* file in the *RestaurantViolations* project.
1. Add the following using statement to reference the *RestaurantViolationsML.Model* project:

    [!code-csharp [ProgramUsings](~/machinelearning-samples/samples/modelbuilder/MulticlassClassification_RestaurantViolations/RestaurantViolations/Program.cs#L2)]

1. To make a prediction on new data using the model, create a new instance of the `ModelInput` class inside the `Main` method of your application. Notice that the risk category is not part of the input. This is because the model generates the prediction for it.

    [!code-csharp [TestData](~/machinelearning-samples/samples/modelbuilder/MulticlassClassification_RestaurantViolations/RestaurantViolations/Program.cs#L11-L15)]

1. Use the `Predict` method from the `ConsumeModel` class. The `Predict` method loads the trained model, creates a [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) for the model, and uses it to make predictions on new data.

    [!code-csharp [Prediction](~/machinelearning-samples/samples/modelbuilder/MulticlassClassification_RestaurantViolations/RestaurantViolations/Program.cs#L17-L24)]

1. Run the application.

    The output generated by the program should look similar to the snippet below:

    ```bash
    Inspection Type: Complaint
    Violation Description: Inadequate sewage or wastewater disposal
    Risk Category: Moderate Risk
    ```

If you need to reference the generated projects at a later time inside of another solution, you can find them inside the `C:\Users\%USERNAME%\AppData\Local\Temp\MLVSTools` directory.

Congratulations! You've successfully built a machine learning model to categorize the risk of health violations using Model Builder. You can find the source code for this tutorial at the [dotnet/machinelearning-samples](https://github.com/dotnet/machinelearning-samples/tree/master/samples/modelbuilder/MulticlassClassification_RestaurantViolations) GitHub repository.

## Additional resources

To learn more about topics mentioned in this tutorial, visit the following resources:

- [Model Builder Scenarios](../automate-training-with-model-builder.md#scenarios)
- [Multiclass Classification](../resources/glossary.md#multiclass-classification)
- [Multiclass Classification Model Metrics](../resources/metrics.md#evaluation-metrics-for-multi-class-classification)

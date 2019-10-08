---
title: 'Tutorial: Classifiy restaurant violations with Model Builder'
description: This tutorial illustrates how to build a multiclass classification model using ML.NET Model Builder to classify resturant violation severity in San Francisco.
author: luisquintanilla
ms.author: luquinta
ms.date: 10/08/2019
ms.topic: tutorial
ms.custom: mvc
#Customer intent: As a non-developer, I want to use Model Builder to automatically generate a model to classify violation severity using Model Builder.
---

# Tutorial: Classify severity of restaurant violations with Model Builder

In this tutorial, you learn how to:
> [!div class="checklist"]
>
> - Prepare and understand the data
> - Choose a scenario
> - Load the data
> - Train the model
> - Evaluate the model
> - Use the model for predictions

> [!NOTE]
> Model Builder is currently in Preview.

## Pre-requisites

For a list of pre-requisites and installation instructions, visit the [Model Builder installation guide](../how-to-guides/install-model-builder.md).

## Create a console application

1. Create a **.NET Core Console Application** called "RestaurantViolationClassification".

## Prepare and understand the data

The data set used to train and evaluate the machine learning model is originally from the [San Francisco Department of Public Health Restaurant Safety Scores](https://www.sfdph.org/dph/EH/Food/score/default.asp).

1. Download the [dataset](https://data.sfgov.org/api/views/pyih-qa8i/rows.csv?accessType=DOWNLOAD) and save it anywhere on your computer.

1. Open the **Restaurant_Scores_-_LIVES_Standard.csv** data set

    The provided data set contains several prefixed columns.
    
    The columns with the *business* prefix contain information about the business such as the address and phone number. These set of columns are not relevant for training a model. To make it more concrete, the phone number or zip code of an establishment does not determine what the severity of a violation is. 

    The columns with the *inspection* prefix contain formation about individual inspections conducted on the business. A subset of these columns is relevant for building the model. The columns of interest are:

    - **inspection_id** the unique ID associated with a specific violation
    - **inspection_type** the type of inspection. This can either be a first-time inspection for a new establishment, a routine inspection, a complaint inspection, and many other types.
    - **violation_description** a description of the violation encountered. This description corresponds to the **inspection_id**.

The `label` is the column you want to predict. When performing a classification task, the goal is to assign a category (text or numerical). In this classification scenario, the severity of violation is assigned the value of low, medium or high risk. Therefore, the **risk_category** is the label. The identified `features` are the inputs you give the model to predict the `label`. In this case, the **inspection_id**, **inspection_type** and **violation_description** are used as features or inputs to predict the **risk_category**.

## Choose a scenario

![Model Builder wizard in Visual Studio](./media/sentiment-analysis-model-builder/model-builder-screen.png)

To train your model, you need to select from the list of available machine learning scenarios provided by Model Builder. In this case, the scenario is `Issue Classification`.

1. In **Solution Explorer**, right-click the *RestaurantViolationClassification* project, and select **Add** > **Machine Learning**.
1. For this sample, the scenario is sentiment analysis. In the *scenario* step of the Model Builder tool, select the **Issue Classification** scenario.

## Load the data

Model Builder accepts data from two sources, a SQL Server database or a local file in `csv` or `tsv` format.

1. In the data step of the Model Builder tool, select **File** from the data source dropdown.
1. Select the button next to the **Select a file** text box and use File Explorer to browse and select the *Restaurant_Scores_-_LIVES_Standard.csv* file.
1. Choose **risk_category** in the **Column to Predict (Label)** dropdown.
1. Expand the *Input Columns (Features)* dropdown and uncheck all of the columns except for the **inspection_id**, **inspection_type** and **violation_description** columns.
1. Select the **Train** link to move to the next step in the Model Builder tool.

## Train the model

The machine learning task used to train the issue classification model in this tutorial is multiclass classification. During the model training process, Model Builder trains separate models using different multiclass classification algorithms and settings to find the best performing model for your dataset.

The time required for the model to train is proportionate to the amount of data. Model Builder automatically selects a default value for **Time to train (seconds)** based on the size of your data source.

1. Although Model Builder sets the value of **Time to train (seconds)** to 10 seconds, increase it to 30 seconds. Training for a longer period of time allows Model Builder to explore a larger number of algorithms and combination of parameters in search of the best model.
1. Select **Start Training**.

    Throughout the training process, progress data is displayed in the `Progress` section of the train step.

    - Status displays the completion status of the training process.
    - Best accuracy displays the accuracy of the best performing model found by Model Builder so far. Higher accuracy means the model predicted more correctly on test data.
    - Best algorithm displays the name of the best performing algorithm performed found by Model Builder so far.
    - Last algorithm displays the name of the algorithm most recently used by Model Builder to train the model.

1. Once training is complete, select the **evaluate** link to move to the next step.

## Evaluate the model

The result of the training step will be one model which had the best performance. In the evaluate step of the Model Builder tool, the output section, will contain the algorithm used by the best performing model in the **Best Model** entry along with metrics in **Best Model Accuracy**. Additionally, a summary table containing top five models and their metrics.

If you're not satisfied with your accuracy metrics, some easy ways to try and improve model accuracy are to increase the amount of time to train the model or use more data. Otherwise, select the **code** link to move to the final step in the Model Builder tool.

## Add the code to make predictions

Two projects will be created as a result of the training process.

- RestaurantViolationClassificationML.ConsoleApp: A .NET Core Console application that contains the model training and sample consumption code.
- RestaurantViolationClassificationML.Model: A .NET Standard class library containing the data models that define the schema of input and output model data, the saved version of the best performing model during training and a helper class called `ConsumeModel` to make predictions.

1. In the code step of the Model Builder tool, select **Add Projects** to add the auto-generated projects to the solution.
1. Open the *Program.cs* file in the *RestaurantViolationClassification* project.
1. Add the following using statement to reference the *RestaurantViolationClassificationML.Model* project:

    ```csharp
    using System;
    using RestaurantViolationClassificationML.Model;
    ```

1. To make a prediction on new data using the model, create a new instance of the `ModelInput` class inside the `Main` method of your application. Notice that the fare amount is not part of the input. This is because the model will generate the prediction for it. 

    ```csharp
    // Create sample data
    ModelInput input = new ModelInput
    {
        Inspection_id= "80137_20161005_103149",
        Inspection_type ="Routine - Unscheduled",
        Violation_description= "Wiping cloths not clean or properly stored or inadequate sanitizer"
    };
    ```

1. Use the `Predict` method from the `ConsumeModel` class. The `Predict` method loads the trained model, create a [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) for the model and uses it to make predictions on new data. 

    ```csharp
    // Make prediction
    ModelOutput result = ConsumeModel.Predict(input);

    // Print Prediction
    Console.WriteLine($"Risk Category: {result.Prediction}");
    Console.ReadKey();
    ```

1. Run the application.

    The output generated by the program should look similar to the snippet below:

    ```bash
    Risk Category: Low Risk
    ```

If you need to reference the generated projects at a later time inside of another solution, you can find them inside the `C:\Users\%USERNAME%\AppData\Local\Temp\MLVSTools` directory.

## Next Steps

In this tutorial, you learned how to:
> [!div class="checklist"]
>
> - Prepare and understand the data
> - Choose a scenario
> - Load the data
> - Train the model
> - Evaluate the model
> - Use the model for predictions

### Additional Resources

To learn more about topics mentioned in this tutorial, visit the following resources:

- [Model Builder Scenarios](../automate-training-with-model-builder.md#scenarios)
- [Multiclass Classification](../resources/glossary.md#multiclass-classification)
- [Multiclass Classification Model Metrics](../resources/metrics.md#metrics-for-multi-class-classification)




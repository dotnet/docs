---
title: 'Tutorial: Predict prices using regression with Model Builder'
description: This tutorial illustrates how to build a regression model using ML.NET Model Builder to predict prices, specifically, New York City taxi fares.
author: luisquintanilla
ms.author: luquinta
ms.date: 09/20/2021
ms.topic: tutorial
ms.custom: mvc, mlnet-tooling
#Customer intent: As a non-developer, I want to use Model Builder to automatically generate a model to predict prices using Model Builder.
---

# Tutorial: Predict prices using regression with Model Builder

Learn how to use ML.NET Model Builder to build a regression model to predict prices.  The .NET console app that you develop in this tutorial predicts taxi fares based on historical New York taxi fare data.

The Model Builder price prediction template can be used for any scenario requiring a numerical prediction value. Example scenarios include: house price prediction, demand prediction, and sales forecasting.

In this tutorial, you learn how to:
> [!div class="checklist"]
>
> - Prepare and understand the data
> - Create a Model Builder Config file
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

1. Create a **C# .NET Core Console Application** called "TaxiFarePrediction". Make sure **Place solution and project in the same directory** is **unchecked** (VS 2019).

## Prepare and understand the data

1. Create a directory named *Data* in your project to store the data set files.

1. The data set used to train and evaluate the machine learning model is originally from the NYC TLC Taxi Trip data set.

    1. To download the data set, navigate to the [taxi-fare-train.csv download link](https://raw.githubusercontent.com/dotnet/machinelearning/main/test/data/taxi-fare-train.csv).

    1. When the page loads, right-click anywhere on the page and select **Save as**.

    1. Use the **Save As Dialog** to save the file in the *Data* folder you created at the previous step.

1. In **Solution Explorer**, right-click the *taxi-fare-train.csv* file and select **Properties**. Under **Advanced**, change the value of **Copy to Output Directory** to **Copy if newer**.

Each row in the `taxi-fare-train.csv` data set contains details of trips made by a taxi.

1. Open the **taxi-fare-train.csv** data set

    The provided data set contains the following columns:

    - **vendor_id:** The ID of the taxi vendor is a feature.
    - **rate_code:** The rate type of the taxi trip is a feature.
    - **passenger_count:** The number of passengers on the trip is a feature.
    - **trip_time_in_secs:** The amount of time the trip took. You want to predict the fare of the trip before the trip is completed. At that moment you don't know how long the trip would take. Thus, the trip time is not a feature and you'll exclude this column from the model.
    - **trip_distance:** The distance of the trip is a feature.
    - **payment_type:** The payment method (cash or credit card) is a feature.
    - **fare_amount:** The total taxi fare paid is the label.

The `label` is the column you want to predict. When performing a regression task, the goal is to predict a numerical value. In this price prediction scenario, the cost of a taxi ride is being predicted. Therefore, the **fare_amount** is the label. The identified `features` are the inputs you give the model to predict the `label`. In this case, the rest of the columns with the exception of **trip_time_in_secs** are used as features or inputs to predict the fare amount.

## Create Model Builder Config File

When first adding Model Builder to the solution it will prompt you to create an `mbconfig` file. The `mbconfig` file keeps track of everything you do in Model Builder to allow you to reopen the session.

1. In **Solution Explorer**, right-click the *TaxiFarePrediction* project, and select **Add** > **Machine Learning Model...**.
1. Name the `mbconfig` project **TaxiFarePrediction**, and click the **Add** button.

## Choose a scenario

![Model Builder wizard in Visual Studio](../media/model-builder-scenarios.png)

To train your model, you need to select from the list of available machine learning scenarios provided by Model Builder. In this case, the scenario is `Value prediction`.

1. In the scenario step of the Model Builder tool, select *Value prediction* scenario.

## Select the environment

Model Builder can run the training on different environments depending on the scenario that was selected.

1. Confirm the `Local (CPU)` item is selected, and click the **Next step** button.

## Load the data

Model Builder accepts data from two sources, a SQL Server database or a local file in csv or tsv format.

1. In the data step of the Model Builder tool, select *File* from the data source type selection.
1. Select the **Browse** button next to the text box and use File Explorer to browse and select the *taxi-fare-test.csv* in the *Data* directory
1. Choose *fare_amount* in the **Column to predict (Label)** dropdown.
1. Click the **Advanced data options** link.
1. In the **Column settings** tab, select the **Purpose** dropdown for the *trip_time_in_secs* column, and select **Ignore** to exclude it as a feature during training. Click the **Save** button to close the dialog.
1. Click the **Next step** button.

## Train the model

The machine learning task used to train the price prediction model in this tutorial is regression. During the model training process, Model Builder trains separate models using different regression algorithms and settings to find the best performing model for your dataset.

The time required for the model to train is proportionate to the amount of data. Model Builder automatically selects a default value for **Time to train (seconds)** based on the size of your data source.

1. Leave the default value as is for *Time to train (seconds)* unless you prefer to train for a longer time.
2. Select *Start Training*.

Throughout the training process, progress data is displayed in the `Training results` section of the train step.

- Status displays the completion status of the training process.
- Best accuracy displays the accuracy of the best performing model found by Model Builder so far. Higher accuracy means the model predicted more correctly on test data.
- Best algorithm displays the name of the best performing algorithm performed found by Model Builder so far.
- Last algorithm displays the name of the algorithm most recently used by Model Builder to train the model.

Once training is complete the `mbconfig` file will have the generated model called `TaxiFarePrediction.zip` after training and two C# files with it:

- **TaxiFare.consumption.cs**: This file has a public method that will load the model and create a prediction engine with it and return the prediction.
- **TaxiFare.training.cs**: This file consists of the training pipeline that Model Builder came up with to build the best model including any hyperparameters that it used.

Click the **Next step** button to navigate to the evaluate step.

## Evaluate the model

The result of the training step will be one model which had the best performance. In the evaluate step of the Model Builder tool, in the **Best model** section, will contain the algorithm used by the best performing model in the *Model* entry along with metrics for that model in *RSquared*.

Additionally, in the **Output** window of Visual Studio, there will be a summary table containing top models and their metrics.

This section will also allow you to test your model by performing a single prediction. It will offer text boxes to fill in values and you can click the **Predict** button to get a prediction from the best model. By default this will be filled in by a random row in your dataset.

If you're not satisfied with your accuracy metrics, some easy ways to try and improve model accuracy are to increase the amount of time to train the model or use more data. Otherwise, click **Next step** to navigate to the consume step.

## (Optional) Consume the model

This step will have project templates that you can use to consume the model. This step is optional and you can choose the method that best suits your needs on how to serve the model.

- Console App
- Web API

### Console App

When adding a console app to your solution, you will be prompted to name the project.

1. Name the console project **TaxiFare_Console**.
1. Click **Add to solution** to add the project to your current solution.
1. Run the application.

    The output generated by the program should look similar to the snippet below:

    ```bash
    Predicted Fare: 15.020833
    ```

### Web API

When adding a web API to your solution, you will be prompted to name the project.

1. Name the Web API project **TaxiFare_API**.
1. Click *Add to solution** to add the project to your current solution.
1. Run the application.
1. Open PowerShell and enter the following code where PORT is the port your application is listening on.

    ```powershell
    $body = @{
        Vendor_id="CMT"
        Rate_code=1.0
        Passenger_count=1.0
        Trip_distance=3.8
        Payment_type="CRD"
    }

    Invoke-RestMethod "https://localhost:<PORT>/predict" -Method Post -Body ($body | ConvertTo-Json) -ContentType "application/json"
    ```

1. If successful, the output should look similar to the text below:

    ```powershell
    score
    -----
    15.020833
    ```

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

- [Model Builder Scenarios](../automate-training-with-model-builder.md#scenario)
- [Regression](../resources/glossary.md#regression)
- [Regression Model Metrics](../resources/metrics.md#evaluation-metrics-for-regression-and-recommendation)
- [NYC TLC Taxi Trip data set](https://www1.nyc.gov/site/tlc/about/tlc-trip-record-data.page)

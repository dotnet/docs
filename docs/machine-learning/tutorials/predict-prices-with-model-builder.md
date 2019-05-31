---
title: 'Predict prices using regression with Model Builder'
description: This tutorial illustrates how to build a regression model using ML.NET Model Builder to predict prices, specifically, New York City taxi fares.
author: luisquintanilla
ms.author: luquinta
ms.date: 05/31/2019
ms.topic: tutorial
ms.custom: mvc
#Customer intent: As a non-developer, I want to use Model Builder to automatically generate a model to predict prices using Model Builder. 
---

# Predict prices using regression with Model Builder

This tutorial illustrates how to build a [regression model](../resources/glossary.md#regression) using ML.NET Model Builder to predict prices, specifically, New York City taxi fares. The regression machine learning task can be utilized in various scenarios where the target or label to predict is numerical.

In this tutorial, you learn how to:
> [!div class="checklist"]
> * Prepare and understand the data
> * Choose a scenario
> * Load the data
> * Train the model
> * Evaluate the model
> * Use the model for predictions

## Pre-requisites

For a list of pre-requisites and installation instructions, visit the [Model Builder installation guide](../how-to-guides/install-model-builder.md).

## Create a console application

1. Create a **.NET Core Console Application** called "TaxiFarePrediction".

1. Create a directory named *Data* in your project to store the data set files.

1. Install the **Microsoft.ML** NuGet Package:

    In **Solution Explorer**, right-click the *TaxiFarePrediction* project and select **Manage NuGet Packages**. Choose "nuget.org" as the Package source, select the **Browse** tab, search for **Microsoft.ML**, select the package in the list, and select the **Install** button. Select the **OK** button on the **Preview Changes** dialog and then select the **I Accept** button on the **License Acceptance** dialog if you agree with the license terms for the packages listed.

## Prepare and Understand the Data

1. Download the [taxi-fare-train.csv](https://github.com/dotnet/machinelearning/blob/master/test/data/taxi-fare-train.csv) and data set and save it to the *Data* folder you've created at the previous step. THis data set will be used to train and evaluate the machine learning model. This data sets is originally from the [NYC TLC Taxi Trip data set](http://www.nyc.gov/html/tlc/html/about/trip_record_data.shtml).

1. In **Solution Explorer**, right-click the *taxi-fare-train.csv* file and select **Properties**. Under **Advanced**, change the value of **Copy to Output Directory** to **Copy if newer**.

1. Open the **taxi-fare-train.csv** data set and look at column headers in the first row. Take a look at each of the columns. Understand the data and decide which columns are **features** and which one is the **label**.

The `label` is the column you want to predict. The identified `Features`are the inputs you give the model to predict the `Label`.

The provided data set contains the following columns:

* **vendor_id:** The ID of the taxi vendor is a feature.
* **rate_code:** The rate type of the taxi trip is a feature.
* **passenger_count:** The number of passengers on the trip is a feature.
* **trip_time_in_secs:** The amount of time the trip took. You want to predict the fare of the trip before the trip is completed. At that moment you don't know how long the trip would take. Thus, the trip time is not a feature and you'll exclude this column from the model.
* **trip_distance:** The distance of the trip is a feature.
* **payment_type:** The payment method (cash or credit card) is a feature.
* **fare_amount:** The total taxi fare paid is the label.

In this case, the label is the **fare_amount** column.

## Choose a scenario

1. In **Solution Explorer**, right-click the *TaxiFarePrediction* project, and select **Add** > **Machine Learning**.
1. In the scenario step of the Model Builder tool, select *Price Prediction* scenario.

## Load the data

1. In the data step of the Model Builder tool, select *File* from the data source dropdown.
1. Select the button next to the *Select a file* text box and use File Explorer to browse and select the *taxi-fare-test.csv* in the *Data* directory
1. Choose *fare_amount* in the *Label or Column to Predict* dropdown and navigate to the train step of the Model Builder tool.

## Train the model

The machine learning task used to train the price prediction model in this tutorial is regression. ML.NET supports various regression algorithms. During the model training process, Model Builder will train separate models using different regression algorithms and hyper-parameters to try and train the best performing model for your dataset.

Depending on the data size, give it enough time to train. Use this chart as guidance:

*Dataset Size  | Dataset Type       | Avg. Time to train*
------------- | ------------------ | --------------
0 - 10 Mb     | Numeric and Text   | 10 sec
10 - 100 Mb   | Numeric and Text   | 10 min
100 - 500 Mb  | Numeric and Text   | 30 min
500 - 1 Gb    | Numeric and Text   | 60 min
1 Gb+         | Numeric and Text   | 3 hour+

1. Because the training data file is more than 10MB, use 600 seconds (10 minutes) as the value for *Time to train (seconds)*.
2. Select *Start Training*.

## Evaluate the model

The result of the training step will be one model which had the best performance. In the evaluate step of the Model Builder tool, the output section, will contain the algorithm used by the best performing model in the *Best Model* entry along with metrics in *Best Model Quality (RSquared)*. Additionally, a summary table containing top five models and their metrics. Visit the following link to learn more about [evaluating model metrics](https://docs.microsoft.com/en-us/dotnet/machine-learning/resources/metrics).

If you're not satisfied with your accuracy metrics, an easy way to try and improve model accuracy is to increase the amount of time to train the model.

## Use the model for predictions

Two projects will be created in `C:\Users\%USERNAME%\AppData\Local\Temp\MLVSTools` directory.

- TaxiFarePredictionML.ConsoleApp: The console application containing the model training code.
- TaxiFarePredictionML.Model: A class library containing the data models that define the schema of input and output model data as well as the persisted version of the best performing model during training.

1. In the code section of the Model Builder tool, select **Added Projects** to add the projects to the solution.
2. In solution explorer, right-click the *TaxiFarePrediction* project. Then, select **Add > Existing Item**. For file type drop down, select `All Files`, navigate to the *TaxiFarePredictionML.Model* project directory and select the `MLModel.zip` file. Then right-click the recently added `MLModel.zip` file and select *Properties*. For the Copy to Output Directory option, select *Copy if Newer* from the dropdown.
3. Right-click *TaxiFarePrediction* project. Then, **Add > Reference**. Choose the **Projects > Solution** node and from the list, check the *TaxiFarePredictionML.Model* project and select OK.

4. Open the *Program.cs* file in the *TaxiFarePrediction* project.
5. Add the following using statements:

    ```csharp
    using System;
    using Microsoft.ML;
    using TaxiFarePredictionML.Model.DataModels;
    ```

6. Add the `ConsumeModel` method to the `Program` class. The `ConsumeModel` will create a `PredictionEngine` based on the model generated by Model Builder to make predictions on new data and print them out to the console.

    ```csharp
    static ModelOutput ConsumeModel(ModelInput input)
    {
        // 1. Load the model
        MLContext mlContext = new MLContext();
        ITransformer mlModel = mlContext.Model.Load("MLModel.zip", out var modelInputSchema);

        // 2. Create PredictionEngine
        var predictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

        

        // 3. Use PredictionEngine to use model on input data
        ModelOutput result = predictionEngine.Predict(input);

        // 4. Return prediction result
        return result;
    }
    ```

7. Add the following code to the `Main` method and run the application.

    ```csharp
    // Create sample data
    ModelInput input = new ModelInput()
    {
        Vendor_id = "CMT",
        Rate_code = 1,
        Passenger_count = 1,
        Trip_time_in_secs = 1271,
        Trip_distance = 3.8f,
        Payment_type = "CRD"
    };

    // Make prediction
    ModelOutput prediction = ConsumeModel(input);

    // Print Prediction
    Console.WriteLine($"Predicted Fare: {prediction.Score}");
    Console.ReadKey();
    ```

    The output generated by the program should look similar to the snippet below:

    ```bash
    Predicted Fare: 16.82245
    ```

## Next Steps

In this tutorial, you learn how to:
> [!div class="checklist"]
> * Prepare and understand the data
> * Choose a scenario
> * Load the data
> * Train the model
> * Evaluate the model
> * Use the model for predictions

- [Deploy a model to Azure Functions](https://docs.microsoft.com/en-us/dotnet/machine-learning/how-to-guides/serve-model-serverless-azure-functions-ml-net)
- [Deploy a model to a Web API](https://docs.microsoft.com/en-us/dotnet/machine-learning/how-to-guides/serve-model-web-api-ml-net)
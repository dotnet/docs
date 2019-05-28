---
title: Predict prices with Model Builder
description: Discover how to automatically generate a model to predict prices using Model Builder
author: luisquintanilla
ms.date: 05/28/2019
ms.custom: tutorial
#Customer intent: As a non-developer, I want to use Model Builder to automatically generate a model to predict prices using Model Builder. 
---
# Predict prices using Model Builder

Intro para about scenario and using Model Builder to solve problem

## Create Project

- **File** > **New Project**
- In New Project Prompt, **Visual C#** > **.NET Core** node and select *Console App*. In the *Name* field, type *MLModelBuilderTest*.
- Download data to *Data* folder. Then, right-click data file, select *Properties*. Set the Copy to Output Directory option to *Copy if newer*.
- Instructions to install **Microsoft.ML** NuGet package.

## Build Model

- Right-click *MLModelBuilderTest* project, then **Add** > **Machine Learning**.

## Select Scenario

This scenario will predict prices. Select *Price Prediction* scenario

## Add Data

- In the data source dropdown, select *File*.
- Select the file in the *Data* directory
- Select *fare_amount* as the Label or Column to Predict.

## Train

Depending on the data size, give it enough time to train. Use this chart as guidance:

*Dataset Size  | Dataset Type       | Avg. Time to train*
------------- | ------------------ | --------------
0 - 10 Mb     | Numeric and Text   | 10 sec
10 - 100 Mb   | Numeric and Text   | 10 min 
100 - 500 Mb  | Numeric and Text   | 30 min 
500 - 1 Gb    | Numeric and Text   | 60 min 
1 Gb+         | Numeric and Text   | 3 hour+ 

In this case, we'll use 10 seconds.

Select *Start Training*.

## Evaluate

This step provides a summary of the training process.

## Code

Two projects will be created in `C:\Users\%USERNAME%\AppData\Local\Temp\MLVSTools` directory.

1. ConsoleApp - The console app contains the training code
1. Model - Contains the data models that define the schema of input and output model data as well as the persisted version of the best performing model during training.

- In this section, select **Added Projects** to add the projects to the solution.
- Right-click `MLModelBuilderTest` project. Then, **Add > Existing Item**. For file type drop down, select `All Files` and navigate to the `MLModelBuilderTestML.Model` directory and select the `MLModel.zip` file. Then right-click the recently added `MLModel.zip` file and select *Properties*. For the Copy to Output Directory option, select *Copy if Newer* from the dropdown.
- Right-click `MLModelBuilderTest` project. Then, **Add > Reference**. Select the **Projects > Solution** node and from the list, check the *MLModelBuilderTestML.Model* project.
- Add the following usings to *Program.cs* in `MLModelBuilderTest` project.

```csharp
using System;
using Microsoft.ML;
using MLModelBuilderTestML.Model.DataModels;
```

- Copy the `ConsumeModel` method into the *Program.cs* file in `MLModelBuilderTest` project.

```csharp
static void ConsumeModel()
{
    // Load the model
    MLContext mlContext = new MLContext();
    ITransformer mlModel = mlContext.Model.Load("MLModel.zip", out var modelInputSchema);
    var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

    // Use the code below to add input data
    var input = new ModelInput()
    {
        Vendor_id = "CMT",
        Rate_code = 1,
        Passenger_count = 1,
        Trip_time_in_secs = 1271,
        Trip_distance = 3.8f,
        Payment_type = "CRD"
    };
    // input.

    // Try model on sample data
    ModelOutput result = predEngine.Predict(input);

    // Print prediction
    Console.WriteLine(result.Score);
}
```

Add the following code to the `Main` method:

```csharp
ConsumeModel();
Console.ReadKey();
```

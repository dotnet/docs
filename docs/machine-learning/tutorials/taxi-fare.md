---
title: Use ML.NET to Predict New York Taxi Fares (Regression).
description: Learn how to use ML.NET in a regression scenario.
ms.prod: dotnet-ml
ms.devlang: dotnet
ms.author: johalex
author: aditidugar
ms.date: 05/07/2018
ms.topic: tutorial
manager: wpickett
ms.custom: mvc
#Customer intent: As a < type of user >, I want < what? > so that < why? >.
---
# Tutorial: Use ML.NET to Predict New York Taxi Fares (Regression)

This tutorial illustrates how to use ML.NET to build a [regression model](../resources/glossary.md#regression) for predicting New York City taxi fares.

In this tutorial, you learn how to:
> [!div class="checklist"]
> * Understand the problem 
> * Select the appropriate machine learning task
> * Prepare and understand your data
> * Create a learning pipeline
> * Load and transform your data
> * Choose a learning algorithm
> * Train the model
> * Evaluate the model
> * Use the model for predictions

## Prerequisites
* [Visual Studio 2017 15.6 or later](https://aka.ms/vsdownload?utm_source=mscom&utm_campaign=msdocs) with the ".NET Core cross-platform development" workload installed.

* The [NYC TLC Taxi Trip data set](http://www.nyc.gov/html/tlc/html/about/trip_record_data.shtml). The Taxi Trip data set trains the machine learning model and can be used to evaluate how accurate your model is.

## Understand the problem

This problem is centered around **predicting the fare of a taxi trip in New York City**. At first glance, it may seem to depend simply on the distance traveled. However, taxi vendors in New York charge varying amounts for other factors such as additional passengers or paying with a credit card instead of cash.

## Select the appropriate machine learning task

To predict the taxi fare, you first select the appropriate machine learning task. You are looking to predict a real value (a double that represents price) based on the other factors in the dataset. You choose a [**regression**](../resources/glossary.md#regression) task.

The process of training the model identifies which factors in the dataset are most influential when predicting the final fare price.

## Create a console application

1. Launch Visual Studio 2017. Create a new C# **Console App (.NET Core)** project named "TaxiFarePrediction."

2. Create a directory named Data in your project's *bin* directory.

3. Install the ML.NET NuGet Package

    Click on the **Tools** menu, then select **NuGet Package Manager**, and choose **Package Manager Console**. Type "Install-Package Microsoft.ML" at the prompt.

    ```console
    PM > Install-Package Microsoft.ML
    ```

### Preparing and understanding your data
Download the [taxitrip-train.csv and taxitrip-test.csv data sets](https://github.com/dotnet/machinelearning/tree/master/test/data) and save them to the Data folder previously created.

Open the **taxitrip-train.csv** data set in the code editor and look at column headers in the first row. Take a look at each of the columns. Understand the data and decide which columns are **features** and which is the **label**.

The **label** is the identifier of the column you are trying to predict. The identified **features** are used to predict the label.

* **vendor_id:** The ID of the taxi vendor is a feature.
* **rate_code:** The rate type of the taxi trip is a feature.
* **passenger_count:** The number of passengers on the trip is a feature.
* **trip_time_in_secs:** The amount of time the trip took. You won't know how long the trip takes until after it is completed. You exclude this column from the model.
* **trip_distance:** The distance of the trip is a feature.
* **payment_type:** The payment method (cash or credit card) is a feature.
* **fare_amount:** The total taxi fare paid is the label.

### Create classes and define paths

Add the following `using` statements to the top of Program.cs:

[!code-csharp[AddUsings](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#1 "Add necessary usings")]

You define variables to hold your datapath (the dataset that trains your model), your testdatapath (the dataset that evaluates your model), and your modelpath (where you store the trained model). Add the following code to the line right above `Main` to specify the recently downloaded files:

[!code-csharp[InitializePaths](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#2 "Define variables to store the data file paths")]

Next, create classes for the input data and the predictions:

1.  In **Solution Explorer**, select the TaxiFarePredicion project, and then on the **Project** menu, select **Add Class**.
1.  In the **Add New Item** dialog box, change the **Name** to `TaxiTrip.cs`, and then click **Add**.
1. Add the following `using` statements:

[!code-csharp[AddUsings](../../../samples/machine-learning/tutorials/TaxiFarePrediction/TaxiTrip.cs#1 "Add necessary usings")]

Add two classes into this file. `TaxiTrip`, the input data set class, has definitions for each of the columns discovered above and a `Label` attribute for the fare_amount column that you are predicting. Add the following code to the file:

[!code-csharp[DefineTaxiTrip](../../../samples/machine-learning/tutorials/TaxiFarePrediction/TaxiTrip.cs#2 "Define the taxi trip class")]

The `TaxiTripFarePrediction` class is used for prediction after the model has been trained. It has a single float (fare_amount) and a `Score` `ColumnName` attribute. Add the following code into the file below the `TaxiTrip` class:

[!code-csharp[DefineFarePrediction](../../../samples/machine-learning/tutorials/TaxiFarePrediction/TaxiTrip.cs#3 "Define the fare predictions class")]

Now go back to the **Program.cs** file. In `Main`, replace the `Console.WriteLine("Hello World!")` with the following code:

```csharp
PredictionModel<TaxiTrip, TaxiTripFarePrediction> model = Train();
```

The `Train()` function trains your model. Create that function just below `Main`, using the following code:

```csharp
public static PredictionModel<TaxiTrip, TaxiTripFarePrediction> Train()
{

}
```

## Create a learning pipeline

Now create the learning pipeline. The learning pipeline loads all of the data and algorithms necessary to train the model. Copy the following code into the `Train()` method:

```csharp
var pipeline = new LearningPipeline();
```

## Load and transform your data

Next, load your data into the pipeline. Point to the datapath created initially and specify the delimiter of the .csv file (,). Copy the following code into the `Train()` method underneath the last step:

```csharp
pipeline.Add(new TextLoader<TaxiTrip>(DataPath, useHeader: true, separator: ","));
```

Copy the "fare_amount" column into a new column called "Label" using the `ColumnCopier()` function. This column is the **Label**.

```csharp
pipeline.Add(new ColumnCopier(("fare_amount", "Label")));
```

Conduct some **feature engineering** to transform the data so that it can be used effectively for machine learning. The algorithm that trains the model requires **numeric** features, you transform the categorical data (`vendor_id`, `rate_code`, and `payment_type`) into numbers. the `CategoricalOneHotVectorizer()` function assigns a numeric key to the values in each of these columns. Transform your data by adding this code:

```csharp
pipeline.Add(new CategoricalOneHotVectorizer("vendor_id",
                                             "rate_code",
                                             "payment_type"));
```

The last step in data preparation combines all of your **features** into one vector using the `ColumnConcatenator()` function. This necessary step helps the algorithm easily process your features. Add the following code following what you wrote in the last step:

```csharp
pipeline.Add(new ColumnConcatenator("Features",
                                    "vendor_id",
                                    "rate_code",
                                    "passenger_count",
                                    "trip_distance",
                                    "payment_type"));
```

Notice that the "trip_time_in_secs" column isn't included. You already determined that it isn't a useful prediction feature.

> [!NOTE]
> These steps must be added to Pipeline in the order specified above for successful execution.

## Choose a learning algorithm

After adding the data to the pipeline and transforming it into the correct input format, you select a learning algorithm (**learner**). The learning algorithm trains the model. You chose a **regression task** for this problem, so you add a learner called `FastTreeRegressor()` to the pipeline that utilizes **gradient boosting**.

Gradient boosting is a machine learning technique for regression problems. It builds each regression tree in a step-wise fashion. It uses a pre-defined loss function to measure the error in each step and correct for it in the next. The result is a prediction model that is actually an ensemble of weaker prediction models. Learn more about [gradient boosting](https://docs.microsoft.com/en-us/azure/machine-learning/studio-module-reference/boosted-decision-tree-regression) from Azure Machine Learning.

Add the following code into the `Train()` method following the data processing code added in the last step:

```csharp
pipeline.Add(new FastTreeRegressor());
```

You added all the preceding steps to the pipeline as individual statements, but C# has a handy collection initialization syntax that makes it simpler to create and initialize the pipeline:

[!code-csharp[CreatePipeline](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#3 "Create and initialize the learning pipeline")]

## Train the model

The final step is to train the model. Until this point, nothing in the pipeline has been executed. The `pipeline.Train<T_Input, T_Output>()` function takes in the pre-defined `TaxiTrip` class type and outputs a `TaxiTripFarePrediction` type. Add this final piece of code into the `Train()` function:

[!code-csharp[TrainMOdel](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#4 "Train your model")]

And that's it! You have successfully trained a machine learning model that can predict taxi fares in NYC. Now take a look to understand how accurate your model is and learn how to consume it.

## Save the model

Before you go onto the next step, save your model to a .zip file by adding the following code at the end of your `Train()` function:

[!code-csharp[SaveModel](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#5 "Save the model asynchronously and return the model")]

Adding the `await` statement to the `model.WriteAsync()` call means that the `Train()` method must be changed to an async method that returns a `Task`. Modify the signature of `Train` as shown in the following code:

[!code-csharp[AsyncTraining](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#6 "Make the Train method async and return a task.")]

Changing the return type of the `Train` method means you have to add an `await` to the codde that calls `Train` in the `Method` as shown in the following code:

[!code-csharp[AwaitTraining](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#7 "Await the Train method")]

Adding an `await` in your `Main` method means the `Main` method must have the `async` modifier and return a `Task`:

[!code-csharp[AsyncMain](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#8 "Make the Main method async and return a task.")]

You'll also need to add the following using statement at the top of the file:

[!code-csharp[UsingTasks](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#9 "Add System.Threading.Tasks. to your usings.")]

## Evaluate the model

Evaluation is the process of checking how well the model works. It is important that your model makes good predictions on data that it didn't use when it was trained. One way to do this is by splitting the data into train and test datasets, as you did in this tutorial. Now that you have trained the model on the train data, you will see how well it performs on the test data.

Now go back to your `Main` function and add the following code beneath the call to the `Train()`method:

[!code-csharp[Evaluate](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#10 "Evaluate the model.")]

The `Evaluate()` function evaluates your model. Create that function below `Train()`. Add the following code:

[!code-csharp[EvaluateMethod](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#11 "Define the Evaluate method.")]

Load the test data using the `TextLoader()` function. Add the following code into the `Evaluate()` method:

[!code-csharp[LoadTestData](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#12 "Load the test data.")]

Add the following code to evaluate the model and produce the metrics for it:

[!code-csharp[EvaluateAndMeasure](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#13 "Evaluate the model and its predictions.")]

RMS is one metric for evaluating regression problems. The lower it is, the better your model. Add the following code into the `Evaluate()` function to print the RMS for your model.

[!code-csharp[DisplayRMS](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#14 "Display the RMS metric.")]

RSquared is another metric for evaluating regression problems. RSquared will be a value between 0 and 1. The closer you are to 1, the better your model. Add the following code into the `Evaluate()` function to print the RSquared value for your model.

[!code-csharp[DisplayRSquared](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#15 "Display the RSquared metric.")]

## Use the model for predictions

After the `Evaluate()` function, create a class to house test scenarios that you can use to make sure your model is working correctly. Define a class to hold test data with the following code:

```csharp
static class TestTrips
{

}
```

This tutorial uses one test trip within this class. Later you can add other scenarios to experiment with this sample. Add the following code into the `TestTrips` class:

[!code-csharp[TestData](../../../samples/machine-learning/tutorials/TaxiFarePrediction/TestTrips.cs#1 "Create aq trip to predict its cost.")]

This trip's actual fare is 29.5, but use 0 as a placeholder. The machine learning algorithm will predict the fare.

Add the following code in your `Main` function. It tests out your model using the `TestTrip` data:

[!code-csharp[Predict](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#16 "Try a prediction.")]

Run the program to see the predicted taxi fare for your test case.

Congratulations! You have now successfully built a machine learning model for predicting taxi fares, evaluated its accuracy, and tested it.

## Next steps

In this tutorial, you learned how to:
> [!div class="checklist"]
> * Understand the problem 
> * Select the appropriate machine learning task
> * Prepare and understand your data
> * Create a learning pipeline
> * Load and transform your data
> * Choose a learning algorithm
> * Train the model
> * Evaluate the model
> * Use the model for predictions

Check out our GitHub repository to continue learning and find more samples.
> [!div class="nextstepaction"]
> [GitHub Repository](https://github.com/dotnet/machinelearning/)

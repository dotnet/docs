---
title: Use ML.NET to predict New York Taxi Fares (Regression)
description: Learn how to use ML.NET in a regression scenario.
author: aditidugar
ms.date: 05/21/2018
ms.topic: tutorial
ms.custom: mvc
#Customer intent: As a developer, I want to use ML.NET so that I can train and build a model in a regression scenario to predict New York taxi fares.
---
# Tutorial: Use ML.NET to predict New York Taxi Fares (Regression)

> [!NOTE]
> This topic refers to ML.NET, which is currently in Preview, and material may be subject to change. For more information, visit [the ML.NET introduction](https://www.microsoft.com/net/learn/apps/machine-learning-and-ai/ml-dotnet).

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

* [Visual Studio 2017 15.6 or later](https://www.visualstudio.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=button+cta&utm_content=download+vs2017) with the ".NET Core cross-platform development" workload installed.

## Understand the problem

This problem is centered around **predicting the fare of a taxi trip in New York City**. At first glance, it may seem to depend simply on the distance traveled. However, taxi vendors in New York charge varying amounts for other factors such as additional passengers or paying with a credit card instead of cash.

## Select the appropriate machine learning task

To predict the taxi fare, you first select the appropriate machine learning task. You are looking to predict a real value (a double that represents price) based on the other factors in the dataset. You choose a [**regression**](../resources/glossary.md#regression) task.

The process of training the model identifies which factors in the dataset are most influential when predicting the final fare price.

## Create a console application

1. Open Visual Studio 2017. Select **File** > **New** > **Project** from the menu bar. In the **New Project** dialog, select the **Visual C#** node followed by the **.NET Core** node. Then select the **Console App (.NET Core)** project template. In the **Name** text box, type "TaxiFarePrediction" and then select the **OK** button.

2. Create a directory named *Data* in your project to save your data set files:

    In **Solution Explorer**, right-click on your project and select **Add** > **New Folder**. Type "Data" and hit Enter.

3. Install the **Microsoft.ML NuGet Package**:

    In Solution Explorer, right-click on your project and select **Manage NuGet Packages**. Choose "nuget.org" as the Package source, select the Browse tab, search for **Microsoft.ML**, select that package in the list, and select the **Install** button. Select the **OK** button on the **Preview Changes** dialog and then select the **I Accept** button on the **License Acceptance** dialog if you agree with the license terms for the packages listed.

### Prepare and understand your data

1. Download the [taxi-fare-train.csv](https://github.com/dotnet/machinelearning/blob/master/test/data/taxi-fare-train.csv) and the [taxi-fare-test.csv](https://github.com/dotnet/machinelearning/blob/master/test/data/taxi-fare-test.csv) data sets and save them to the *Data* folder previously created. The Taxi Trip data set trains the machine learning model and can be used to evaluate how accurate your model is. These data sets are originally from the [NYC TLC Taxi Trip data set](http://www.nyc.gov/html/tlc/html/about/trip_record_data.shtml).

2. In Solution Explorer, right-click each of the \*.csv files and select **Properties**. Under **Advanced**, change the value of **Copy to Output Directory** to **Always**.

3. Open the **taxi-fare-train.csv** data set in the code editor and look at column headers in the first row. Take a look at each of the columns. Understand the data and decide which columns are **features** and which is the **label**.

The **label** is the identifier of the column you are trying to predict. The identified **features** are used to predict the label.

* **vendor_id:** The ID of the taxi vendor is a feature.
* **rate_code:** The rate type of the taxi trip is a feature.
* **passenger_count:** The number of passengers on the trip is a feature.
* **trip_time_in_secs:** The amount of time the trip took. You won't know how long the trip takes until after it is completed. You exclude this column from the model.
* **trip_distance:** The distance of the trip is a feature.
* **payment_type:** The payment method (cash or credit card) is a feature.
* **fare_amount:** The total taxi fare paid is the label.

### Create classes and define paths

Add the following additional `using` statements to the top of the *Program.cs* file:

[!code-csharp[AddUsings](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#1 "Add necessary usings")]

You need to create three global variables to hold the paths to the recently downloaded files and to save the model:

* `_datapath` has the path to the data set used to train the model.
* `_testdatapath` has the path to the data set used to evaluate the model.
* `_modelpath` has the path where the trained model is stored.

Add the following code to the line right above `Main` to specify the recently downloaded files:

[!code-csharp[InitializePaths](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#2 "Define variables to store the data file paths")]

Next, create classes for the input data and the predictions:

1. In **Solution Explorer**, right-click the project, and then select **Add** > **New Item**.
1. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *TaxiTrip.cs*. Then, select the **Add** button.
1. Add the following `using` statements to the new file:

[!code-csharp[AddUsings](../../../samples/machine-learning/tutorials/TaxiFarePrediction/TaxiTrip.cs#1 "Add necessary usings")]

Remove the existing class definition and add the following code, which has two classes `TaxiTrip` and `TaxiTripFarePrediction`, to the *TaxiTrip.cs* file:

[!code-csharp[DefineTaxiTrip](../../../samples/machine-learning/tutorials/TaxiFarePrediction/TaxiTrip.cs#2 "Define the taxi trip and fare predictions classes")]

`TaxiTrip` is the input data set class and has definitions for each of the data set columns. The `TaxiTripFarePrediction` class is used for prediction after the model has been trained. It has a single float (`fare_amount`) and a `Store` [ColumnName](xref:Microsoft.ML.Runtime.Api.ColumnNameAttribute) attribute applied.

Now go back to the **Program.cs** file. In `Main`, replace the `Console.WriteLine("Hello World!")` with the following code:

```csharp
PredictionModel<TaxiTrip, TaxiTripFarePrediction> model = Train();
```

The `Train` method trains your model. Create that function just below `Main`, using the following code:

```csharp
public static PredictionModel<TaxiTrip, TaxiTripFarePrediction> Train()
{

}
```

## Create a learning pipeline

The learning pipeline loads all of the data and algorithms necessary to train the model. Add the following code into the `Train()` method:

```csharp
var pipeline = new LearningPipeline();
```

## Load and transform your data

Next, load your data into the pipeline. Point to the `_datapath` created initially and specify the delimiter of the .csv file (,). Add the following code into the `Train()` method underneath the last step:

```csharp
pipeline.Add(new TextLoader<TaxiTrip>(_datapath, useHeader: true, separator: ","));
```

Copy the `fare_amount` column into a new column called "Label" using the `ColumnCopier()` function. This column is the **Label**.

```csharp
pipeline.Add(new ColumnCopier(("fare_amount", "Label")));
```

Conduct some **feature engineering** to transform the data so that it can be used effectively for machine learning. The algorithm that trains the model requires **numeric** features, you transform the categorical data (`vendor_id`, `rate_code`, and `payment_type`) into numbers. The `CategoricalOneHotVectorizer()` function assigns a numeric key to the values in each of these columns. Transform your data by adding this code:

```csharp
pipeline.Add(new CategoricalOneHotVectorizer("vendor_id",
                                             "rate_code",
                                             "payment_type"));
```

The last step in data preparation combines all of your **features** into one vector using the `ColumnConcatenator()` function. This necessary step helps the algorithm easily process your features. Add the following code:

```csharp
pipeline.Add(new ColumnConcatenator("Features",
                                    "vendor_id",
                                    "rate_code",
                                    "passenger_count",
                                    "trip_distance",
                                    "payment_type"));
```

Notice that the `trip_time_in_secs` column isn't included. You already determined that it isn't a useful prediction feature.

> [!NOTE]
> These steps must be added to Pipeline in the order specified above for successful execution.

## Choose a learning algorithm

After adding the data to the pipeline and transforming it into the correct input format, you select a learning algorithm (**learner**). The learning algorithm trains the model. You chose a **regression task** for this problem, so you add a learner called `FastTreeRegressor()` to the pipeline that utilizes **gradient boosting**.

Gradient boosting is a machine learning technique for regression problems. It builds each regression tree in a step-wise fashion. It uses a pre-defined loss function to measure the error in each step and correct for it in the next. The result is a prediction model that is actually an ensemble of weaker prediction models. For more information about gradient boosting, see [Boosted Decision Tree Regression](https://docs.microsoft.com/azure/machine-learning/studio-module-reference/boosted-decision-tree-regression).

Add the following code into the `Train()` method following the data processing code added in the last step:

```csharp
pipeline.Add(new FastTreeRegressor());
```

You added all the preceding steps to the pipeline as individual statements, but C# has a handy collection initialization syntax that makes it simpler to create and initialize the pipeline. Replace the code you added so far to the `Train()` method with the following code:

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

Changing the return type of the `Train` method means you have to add an `await` to the code that calls `Train` in the `Main` method as shown in the following code:

[!code-csharp[AwaitTraining](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#7 "Await the Train method")]

Adding an `await` in your `Main` method means the `Main` method must have the `async` modifier and return a `Task`:

[!code-csharp[AsyncMain](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#8 "Make the Main method async and return a task.")]

You also need to add the following using statement at the top of the file:

[!code-csharp[UsingTasks](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#9 "Add System.Threading.Tasks. to your usings.")]

Because the `async Main` method is a new feature in C# 7.1 and the default language version of the project is C# 7.0, you need to change the language version to C# 7.1 or higher.
To do that, right-click on the project node in **Solution Explorer** and select **Properties**. Select the **Build** tab and select the **Advanced** button. In the dropdown, select  **C# 7.1** (or a higher version). Select the **OK** button.

## Evaluate the model

Evaluation is the process of checking how well the model works. It's important that your model makes good predictions on data that it didn't use when it was trained. One way to do this is by splitting the data into train and test datasets, as you did in this tutorial. Now that you've trained the model on the train data, you can see how well it performs on the test data.

Go back to your `Main` function and add the following code beneath the call to the `Train()`method:

[!code-csharp[Evaluate](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#10 "Evaluate the model.")]

The `Evaluate()` function evaluates your model. Create that function below `Train()`. Add the following code:

```csharp
private static void Evaluate(PredictionModel<TaxiTrip, TaxiTripFarePrediction> model)
{

}
```

Load the test data using the `TextLoader()` function. Add the following code into the `Evaluate()` method:

[!code-csharp[LoadTestData](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#12 "Load the test data.")]

Add the following code to evaluate the model and produce the metrics for it:

[!code-csharp[EvaluateAndMeasure](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#13 "Evaluate the model and its predictions.")]

RMS is one metric for evaluating regression problems. The lower it is, the better your model. Add the following code into the `Evaluate()` function to print the RMS for your model.

[!code-csharp[DisplayRMS](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#14 "Display the RMS metric.")]

RSquared is another metric for evaluating regression problems. RSquared will be a value between 0 and 1. The closer you are to 1, the better your model. Add the following code into the `Evaluate()` function to print the RSquared value for your model.

[!code-csharp[DisplayRSquared](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#15 "Display the RSquared metric.")]

## Use the model for predictions

Next, create a class to house test scenarios that you can use to make sure your model is working correctly:

1. In **Solution Explorer**, right-click the project, and then select **Add** > **New Item**.
1. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *TestTrips.cs*. Then, select the **Add** button.
1. Modify the class to be static like in the following example:

[!code-csharp[StaticClass](../../../samples/machine-learning/tutorials/TaxiFarePrediction/TestTrips.cs#1 "Change class to be a static class.")]

This tutorial uses one test trip within this class. Later you can add other scenarios to experiment with this sample. Add the following code into the `TestTrips` class:

[!code-csharp[TestData](../../../samples/machine-learning/tutorials/TaxiFarePrediction/TestTrips.cs#2 "Create aq trip to predict its cost.")]

This trip's actual fare is 29.5, but use 0 as a placeholder. The machine learning algorithm will predict the fare.

Add the following code in your `Main` function. It tests out your model using the `TestTrip` data:

[!code-csharp[Predict](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#16 "Try a prediction.")]

Run the program to see the predicted taxi fare for your test case.

Congratulations! You've now successfully built a machine learning model for predicting taxi fares, evaluated its accuracy, and tested it. You can find the source code for this tutorial at the [dotnet/samples](https://github.com/dotnet/samples/tree/master/machine-learning/tutorials/TaxiFarePrediction) repository.

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
> [dotnet/machinelearning GitHub repository](https://github.com/dotnet/machinelearning/)

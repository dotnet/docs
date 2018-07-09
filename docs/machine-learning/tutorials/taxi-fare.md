---
title: Use ML.NET to predict New York taxi fares (regression)
description: Learn how to use ML.NET in a regression scenario.
author: aditidugar
ms.author: johalex
ms.date: 06/18/2018
ms.topic: tutorial
ms.custom: mvc
#Customer intent: As a developer, I want to use ML.NET so that I can train and build a model in a regression scenario to predict New York taxi fares.
---
# Tutorial: Use ML.NET to predict New York taxi fares (regression)

> [!NOTE]
> This topic refers to ML.NET, which is currently in Preview, and material may be subject to change. For more information, visit [the ML.NET introduction](https://www.microsoft.com/net/learn/apps/machine-learning-and-ai/ml-dotnet).

This tutorial illustrates how to use ML.NET to build a [regression model](../resources/glossary.md#regression) for predicting New York City taxi fares.

In this tutorial, you learn how to:
> [!div class="checklist"]
> * Understand the problem
> * Select the appropriate machine learning task
> * Prepare and understand the data
> * Create a learning pipeline
> * Load and transform the data
> * Choose a learning algorithm
> * Train the model
> * Evaluate the model
> * Use the model for predictions

## Prerequisites

* [Visual Studio 2017 15.6 or later](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=button+cta&utm_content=download+vs2017) with the ".NET Core cross-platform development" workload installed.

## Understand the problem

This problem is centered around **predicting the fare of a taxi trip in New York City**. At first glance, it may seem to depend simply on the distance traveled. However, taxi vendors in New York charge varying amounts for other factors such as additional passengers or paying with a credit card instead of cash.

## Select the appropriate machine learning task

To predict the taxi fare, you first select the appropriate machine learning task. You are looking to predict a real value (a double that represents price) based on the other factors in the dataset. You choose a [**regression**](../resources/glossary.md#regression) task.

## Create a console application

1. Open Visual Studio 2017. Select **File** > **New** > **Project** from the menu bar. In the **New Project** dialog, select the **Visual C#** node followed by the **.NET Core** node. Then select the **Console App (.NET Core)** project template. In the **Name** text box, type "TaxiFarePrediction" and then select the **OK** button.

2. Create a directory named *Data* in your project to save the data set files:

    In **Solution Explorer**, right-click the project and select **Add** > **New Folder**. Type "Data" and hit Enter.

3. Install the **Microsoft.ML NuGet Package**:

    In **Solution Explorer**, right-click the project and select **Manage NuGet Packages**. Choose "nuget.org" as the Package source, select the **Browse** tab, search for **Microsoft.ML**, select that package in the list, and select the **Install** button. Select the **OK** button on the **Preview Changes** dialog and then select the **I Accept** button on the **License Acceptance** dialog if you agree with the license terms for the packages listed.

## Prepare and understand the data

1. Download the [taxi-fare-train.csv](https://github.com/dotnet/machinelearning/blob/master/test/data/taxi-fare-train.csv) and the [taxi-fare-test.csv](https://github.com/dotnet/machinelearning/blob/master/test/data/taxi-fare-test.csv) data sets and save them to the *Data* folder you've created at the previous step. We use these data sets to train the machine learning model and then evaluate how accurate the model is. These data sets are originally from the [NYC TLC Taxi Trip data set](http://www.nyc.gov/html/tlc/html/about/trip_record_data.shtml).

2. In **Solution Explorer**, right-click each of the \*.csv files and select **Properties**. Under **Advanced**, change the value of **Copy to Output Directory** to **Always**.

3. Open the **taxi-fare-train.csv** data set and look at column headers in the first row. Take a look at each of the columns. Understand the data and decide which columns are **features** and which one is the **label**.

The **label** is the identifier of the column you want to predict. The identified **features** are used to predict the label.

The provided data set contains the following columns:

* **vendor_id:** The ID of the taxi vendor is a feature.
* **rate_code:** The rate type of the taxi trip is a feature.
* **passenger_count:** The number of passengers on the trip is a feature.
* **trip_time_in_secs:** The amount of time the trip took. You want to predict the fare of the trip before the trip is completed. At that moment you don't know how long the trip would take. Thus, the trip time is not a feature and you'll exclude this column from the model.
* **trip_distance:** The distance of the trip is a feature.
* **payment_type:** The payment method (cash or credit card) is a feature.
* **fare_amount:** The total taxi fare paid is the label.

## Create data classes

Create classes for the input data and the predictions:

1. In **Solution Explorer**, right-click the project, and then select **Add** > **New Item**.
1. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *TaxiTrip.cs*. Then, select the **Add** button.
1. Add the following `using` directives to the new file:

   [!code-csharp[AddUsings](../../../samples/machine-learning/tutorials/TaxiFarePrediction/TaxiTrip.cs#1 "Add necessary usings")]

Remove the existing class definition and add the following code, which has two classes `TaxiTrip` and `TaxiTripFarePrediction`, to the *TaxiTrip.cs* file:

[!code-csharp[DefineTaxiTrip](../../../samples/machine-learning/tutorials/TaxiFarePrediction/TaxiTrip.cs#2 "Define the taxi trip and fare predictions classes")]

`TaxiTrip` is the input data class and has definitions for each of the data set columns. Use the [Column](xref:Microsoft.ML.Runtime.Api.ColumnAttribute) attribute to specify the indices of the source columns in the data set.

The `TaxiTripFarePrediction` class is used to represent predicted results. It has a single float (`FareAmount`) field with a `Score` [ColumnName](xref:Microsoft.ML.Runtime.Api.ColumnNameAttribute) attribute applied. The **Score** column is the special column in ML.NET. The model outputs predicted values into that column.

## Define data and model paths

Go back to the *Program.cs* file and add three fields to hold the paths to the files with data sets and the file to save the model:

* `_datapath` contains the path to the file with the data set used to train the model.
* `_testdatapath` contains the path to the file with the data set used to evaluate the model.
* `_modelpath` contains the path to the file where the trained model is stored.

Add the following code right above the `Main` method to specify those paths:

[!code-csharp[InitializePaths](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#2 "Define variables to store the data file paths")]

To make the preceding code compile, add the following `using` directives at the top of the *Program.cs* file:

[!code-csharp[AddUsingsForPaths](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#17 "Using statements for path definitions")]

## Create a learning pipeline

Add the following additional `using` directives to the top of the *Program.cs* file:

[!code-csharp[AddUsings](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#1 "Add necessary usings")]

In `Main`, replace the `Console.WriteLine("Hello World!")` with the following code:

```csharp
PredictionModel<TaxiTrip, TaxiTripFarePrediction> model = Train();
```

The `Train` method trains the model. Create that method just below `Main`, using the following code:

```csharp
public static PredictionModel<TaxiTrip, TaxiTripFarePrediction> Train()
{

}
```

The learning pipeline loads all of the data and algorithms necessary to train the model. Add the following code into the `Train` method:

```csharp
var pipeline = new LearningPipeline();
```

## Load and transform data

The first step that the learning pipeline performs is loading data from the training data set. In our case, training data set is stored in the text file with a path defined by the `_datapath` field. That file contains the header with the column names, so the first row should be ignored while loading data. Columns in the file are separated by the comma (","). Add the following code into the `Train` method:

```csharp
pipeline.Add(new TextLoader(_datapath).CreateFrom<TaxiTrip>(useHeader: true, separator: ','));
```

In the next steps we refer to the columns by the names defined in the `TaxiTrip` class.

When the model is trained and evaluated, the values in the **Label** column are considered as correct values to be predicted. As we want to predict the taxi trip fare, copy the `FareAmount` column into the **Label** column. To do that, use <xref:Microsoft.ML.Transforms.ColumnCopier> and add the following code:

```csharp
pipeline.Add(new ColumnCopier(("FareAmount", "Label")));
```

The algorithm that trains the model requires **numeric** features, so you have to transform the categorical data (`VendorId`, `RateCode`, and `PaymentType`) values into numbers. To do that, use <xref:Microsoft.ML.Transforms.CategoricalOneHotVectorizer>, which assigns different numeric key values to the different values in each of the columns, and add the following code:

```csharp
pipeline.Add(new CategoricalOneHotVectorizer("VendorId",
                                             "RateCode",
                                             "PaymentType"));
```

The last step in data preparation combines all of the feature columns into the **Features** column using the <xref:Microsoft.ML.Transforms.ColumnConcatenator> transformation class. This step is necessary as a learner processes only features from the **Features** column. Add the following code:

```csharp
pipeline.Add(new ColumnConcatenator("Features",
                                    "VendorId",
                                    "RateCode",
                                    "PassengerCount",
                                    "TripDistance",
                                    "PaymentType"));
```

Notice that the `TripTime` column, which corresponds to the `trip_time_in_secs` column in the data set file, isn't included. You already determined that it isn't a useful prediction feature.

> [!NOTE]
> These steps must be added to the pipeline in the order specified above for successful execution.

## Choose a learning algorithm

After adding the data to the pipeline and transforming it into the correct input format, you select a learning algorithm (**learner**). The learner trains the model. You chose a **regression task** for this problem, so you add a <xref:Microsoft.ML.Trainers.FastTreeRegressor> learner, which is one of the regression learners provided by ML.NET.

<xref:Microsoft.ML.Trainers.FastTreeRegressor> learner utilizes gradient boosting. Gradient boosting is a machine learning technique for regression problems. It builds each regression tree in a step-wise fashion. It uses a pre-defined loss function to measure the error in each step and correct for it in the next. The result is a prediction model that is actually an ensemble of weaker prediction models. For more information about gradient boosting, see [Boosted Decision Tree Regression](/azure/machine-learning/studio-module-reference/boosted-decision-tree-regression).

Add the following code into the `Train` method following the data processing code added in the previous step:

```csharp
pipeline.Add(new FastTreeRegressor());
```

You added all the preceding steps to the pipeline as individual statements, but C# has a handy collection initialization syntax that makes it simpler to create and initialize the pipeline. Replace the code you added so far to the `Train` method with the following code:

[!code-csharp[CreatePipeline](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#3 "Create and initialize the learning pipeline")]

## Train the model

The final step is to train the model. Until this point, nothing in the pipeline has been executed. The `pipeline.Train<TInput, TOutput>` method produces the model that takes in an instance of the `TInput` type and outputs an instance of the `TOutput` type. Add the following code into the `Train` method:

[!code-csharp[TrainMOdel](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#4 "Train your model")]

And that's it! You have successfully trained a machine learning model that can predict taxi fares in NYC. Now let's take a look to understand how accurate the model is and learn how to use it to predict taxi fare values.

### Save the model

Before you go onto the next step, save the model to a .zip file by adding the following code at the end of the `Train` method:

[!code-csharp[SaveModel](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#5 "Save the model asynchronously and return the model")]

Adding the `await` statement to the `model.WriteAsync` call means that the `Train` method must be changed to an async method that returns a task. Modify the signature of `Train` as shown in the following code:

[!code-csharp[AsyncTraining](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#6 "Make the Train method async and return a task.")]

Changing the return type of the `Train` method means you have to add an `await` to the code that calls `Train` in the `Main` method as shown in the following code:

[!code-csharp[AwaitTraining](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#7 "Await the Train method")]

Using `await` in the `Main` method means the `Main` method must have the `async` modifier and return a `Task`:

[!code-csharp[AsyncMain](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#8 "Make the Main method async and return a task.")]

You also need to add the following `using` directive at the top of the file:

[!code-csharp[UsingTasks](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#9 "Add System.Threading.Tasks. to your usings.")]

Because the `async Main` method is the feature added in C# 7.1 and the default language version of the project is C# 7.0, you need to change the language version to C# 7.1 or higher. To do that, right-click the project node in **Solution Explorer** and select **Properties**. Select the **Build** tab and select the **Advanced** button. In the dropdown, select  **C# 7.1** (or a higher version). Select the **OK** button.

## Evaluate the model

Evaluation is the process of checking how well the model predicts label values. It's important that the model makes good predictions on data that was not used to train the model. One way to do this is to split the data into train and test data sets, as it's done in this tutorial. Now that you've trained the model on the train data, you can see how well it performs on the test data.

Go back to the `Main` method and add the following code beneath the call to the `Train`method:

[!code-csharp[Evaluate](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#10 "Evaluate the model.")]

The `Evaluate` method evaluates the model. To create that method, add the following code below the `Train` method:

```csharp
private static void Evaluate(PredictionModel<TaxiTrip, TaxiTripFarePrediction> model)
{

}
```

Add the following code into the `Evaluate` method to setup loading of the test data:

[!code-csharp[LoadTestData](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#12 "Load the test data.")]

Add the following code to evaluate the model and produce the evaluation metrics:

[!code-csharp[EvaluateAndMeasure](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#13 "Evaluate the model and its predictions.")]

[RMS](../resources/glossary.md##root-of-mean-squared-error-rmse) is one of the evaluation metrics of the regression model. The lower it is, the better the model is. Add the following code into the `Evaluate` method to display the RMS value:

[!code-csharp[DisplayRMS](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#14 "Display the RMS metric.")]

[RSquared](../resources/glossary.md#coefficient-of-determination) is another evaluation metric of the regression models. RSquared takes values between 0 and 1. The closer its value is to 1, the better the model is. Add the following code into the `Evaluate` method to display the RSquared value:

[!code-csharp[DisplayRSquared](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#15 "Display the RSquared metric.")]

## Use the model for predictions

Next, create a class to house test scenarios that you can use to make sure the model is working correctly:

1. In **Solution Explorer**, right-click the project, and then select **Add** > **New Item**.
1. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *TestTrips.cs*. Then, select the **Add** button.
1. Modify the class to be static like in the following example:

   [!code-csharp[StaticClass](../../../samples/machine-learning/tutorials/TaxiFarePrediction/TestTrips.cs#1 "Change class to be a static class.")]

This tutorial uses one test trip within this class. Later you can add other scenarios to experiment with the model. Add the following code into the `TestTrips` class:

[!code-csharp[TestData](../../../samples/machine-learning/tutorials/TaxiFarePrediction/TestTrips.cs#2 "Create aq trip to predict its cost.")]

This trip's actual fare is 29.5. Use 0 as a placeholder, as the model will predict the fare.

To predict the fare of the specified trip, go back to the *Program.cs* file and add the following code into the `Main` method:

[!code-csharp[Predict](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#16 "Try a prediction.")]

Run the program to see the predicted taxi fare for your test case.

Congratulations! You've now successfully built a machine learning model for predicting taxi trip fares, evaluated its accuracy, and used it to make predictions. You can find the source code for this tutorial at the [dotnet/samples](https://github.com/dotnet/samples/tree/master/machine-learning/tutorials/TaxiFarePrediction) repository.

## Next steps

In this tutorial, you learned how to:
> [!div class="checklist"]
> * Understand the problem
> * Select the appropriate machine learning task
> * Prepare and understand the data
> * Create a learning pipeline
> * Load and transform the data
> * Choose a learning algorithm
> * Train the model
> * Evaluate the model
> * Use the model for predictions

Advance to the next tutorial to learn more.
> [!div class="nextstepaction"]
> [Iris clustering](iris-clustering.md)

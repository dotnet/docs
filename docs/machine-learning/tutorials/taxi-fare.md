---
title: Use ML.NET to predict New York taxi fares (regression)
description: Learn how to use ML.NET in a regression scenario.
author: aditidugar
ms.author: johalex
ms.date: 11/06/2018
ms.topic: tutorial
ms.custom: mvc
#Customer intent: As a developer, I want to use ML.NET so that I can train and build a model in a regression scenario to predict New York taxi fares.
---
# Tutorial: Use ML.NET to predict New York taxi fares (regression)

> [!NOTE]
> This topic refers to ML.NET, which is currently in Preview, and material may be subject to change. For more information, see the [ML.NET introduction](https://www.microsoft.com/net/learn/apps/machine-learning-and-ai/ml-dotnet).

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

This problem is about predicting the fare of a taxi trip in New York City. At first glance, it may seem to depend simply on the distance traveled. However, taxi vendors in New York charge varying amounts for other factors such as additional passengers or paying with a credit card instead of cash.

## Select the appropriate machine learning task

You want to predict the price value, which is a real value, based on the other factors in the data set. To do that you choose a [regression](../resources/glossary.md#regression) machine learning task.

## Create a console application

1. Open Visual Studio 2017. Select **File** > **New** > **Project** from the menu bar. In the **New Project** dialog, select the **Visual C#** node followed by the **.NET Core** node. Then select the **Console App (.NET Core)** project template. In the **Name** text box, type "TaxiFarePrediction" and then select the **OK** button.

1. Create a directory named *Data* in your project to store the data set and model files:

    In **Solution Explorer**, right-click the project and select **Add** > **New Folder**. Type "Data" and hit Enter.

1. Install the **Microsoft.ML** NuGet Package:

    In **Solution Explorer**, right-click the project and select **Manage NuGet Packages**. Choose "nuget.org" as the Package source, select the **Browse** tab, search for **Microsoft.ML**, select that package in the list, and select the **Install** button. Select the **OK** button on the **Preview Changes** dialog and then select the **I Accept** button on the **License Acceptance** dialog if you agree with the license terms for the packages listed.

## Prepare and understand the data

1. Download the [taxi-fare-train.csv](https://github.com/dotnet/machinelearning/blob/master/test/data/taxi-fare-train.csv) and the [taxi-fare-test.csv](https://github.com/dotnet/machinelearning/blob/master/test/data/taxi-fare-test.csv) data sets and save them to the *Data* folder you've created at the previous step. We use these data sets to train the machine learning model and then evaluate how accurate the model is. These data sets are originally from the [NYC TLC Taxi Trip data set](http://www.nyc.gov/html/tlc/html/about/trip_record_data.shtml).

1. In **Solution Explorer**, right-click each of the \*.csv files and select **Properties**. Under **Advanced**, change the value of **Copy to Output Directory** to **Copy if newer**.

1. Open the **taxi-fare-train.csv** data set and look at column headers in the first row. Take a look at each of the columns. Understand the data and decide which columns are **features** and which one is the **label**.

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

`TaxiTrip` is the input data class and has definitions for each of the data set columns. Use the <xref:Microsoft.ML.Runtime.Api.ColumnAttribute> attribute to specify the indices of the source columns in the data set.

The `TaxiTripFarePrediction` class represents predicted results. It has a single float field, `FareAmount`, with a `Score` <xref:Microsoft.ML.Runtime.Api.ColumnNameAttribute> attribute applied. In case of the regression task the **Score** column contains predicted label values.

> [!NOTE]
> Use the `float` type to represent floating-point values in the input and prediction data classes.

## Define data and model paths

Add the following additional `using` statements to the top of the *Program.cs* file:
[!code-csharp[AddUsings](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#1 "Add necessary usings")]

You need to create three fields to hold the paths to the files with data sets and the file to save the model, and a global variable for the `TextLoader`:

* `_trainDataPath` contains the path to the file with the data set used to train the model.
* `_testDataPath` contains the path to the file with the data set used to evaluate the model.
* `_modelPath` contains the path to the file where the trained model is stored.
* `_textLoader` is the <xref:Microsoft.ML.Runtime.Data.TextLoader> used to load and transform the datasets.

Add the following code right above the `Main` method to specify those paths and for the `_textLoader` variable:

[!code-csharp[InitializePaths](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#2 "Define variables to store the data file paths")]

When building a model with ML .NET you start by creating an ML Context. This is comparable conceptually to using `DbContext` in Entity Framework. The environment provides a context for your machine learning job that can be used for exception tracking and logging.

### Initialize variables in Main

Create a variable called `mlContext` and initialize it with a new instance of `MLContext`.  Replace the `Console.WriteLine("Hello World!")` line with the following code in the `Main` method:

[!code-csharp[CreateMLContext](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#3 "Create the ML Context")]

Next, to setup for data loading initialize the `_textLoader` global variable in order to reuse it.  Notice that we are using a `TextReader`. When you create a `TextLoader` using a `TextReader`, you pass in the context needed and the <xref:Microsoft.ML.Runtime.Data.TextLoader.Arguments> class which enables customization. Specify the data schema by passing an array of <xref:Microsoft.ML.Runtime.Data.TextLoader.Column> objects to the `TextReader` containing all the column names and their types. We defined the data schema previously when we created our `TaxiTrip` class.

The `TextReader` class returns a fully initialized <xref:Microsoft.ML.Runtime.Data.TextLoader>  

To initialize the `_textLoader` global variable in order to reuse it for the needed datasets, add the following code after the  `mlContext` initialization:

[!code-csharp[initTextLoader](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#4 "Initialize the TextLoader")]

Add the following as the next line of code in the `Main` method to call the `Train` method:

[!code-csharp[Train](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#5 "Train your model")]

The `Train` method executes the following tasks:

* Loads the data.
* Extracts and transforms the data.
* Trains the model.
* Saves the model as .zip file.
* Returns the model.

The `Train` method trains the model. Create that method just below `Main`, using the following code:

```csharp
public static ITransformer Train(MLContext mlContext, string dataPath)
{

}
```

We are passing two parameters into the `Train` method; an `MLContext` for the context (`mlContext`), and a string for the dataset path (`dataPath`). We're going to reuse this method for loading datasets.

## Load and transform data

We'll load the data using the `_textLoader` global variable with the `dataPath` parameter. It returns a
<xref:Microsoft.ML.Runtime.Data.IDataView>. As the input and output of Transforms, a `DataView` is the fundamental data pipeline type, comparable to `IEnumerable` for `LINQ`.

In ML.NET, data is similar to a SQL view. It is lazily evaluated, schematized, and heterogenous. The object is the first part of the pipeline, and loads the data. For this tutorial, it loads a dataset with taxi trip information useful to predict fares. This is used to create the model, and train it.

 Add the following code as the first line of the `Train` method:

[!code-csharp[LoadTrainData](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#6 "loading training dataset")]

In the next steps we refer to the columns by the names defined in the `TaxiTrip` class.

When the model is trained and evaluated, by default, the values in the **Label** column are considered as correct values to be predicted. As we want to predict the taxi trip fare, copy the `FareAmount` column into the **Label** column. To do that, use the `CopyColumnsEstimator` transformation class, and add the following code:

[!code-csharp[CopyColumnsEstimator](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#7 "Use the CopyColumnsEstimator")]

The algorithm that trains the model requires **numeric** features, so you have to transform the categorical data (`VendorId`, `RateCode`, and `PaymentType`) values into numbers. To do that, use the `OneHotEncodingEstimator` transformation class, which assigns different numeric key values to the different values in each of the columns, and add the following code:

[!code-csharp[OneHotEncodingEstimator](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#8 "Use the OneHotEncodingEstimator")]

The last step in data preparation combines all of the feature columns into the **Features** column using the `ColumnConcatenatingEstimator` transformation class. By default, a learning algorithm processes only features from the **Features** column. Add the following code:

[!code-csharp[ColumnConcatenatingEstimator](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#9 "Use the ColumnConcatenatingEstimator")]

## Choose a learning algorithm

After adding the data to the pipeline and transforming it into the correct input format, we select a learning algorithm (**learner**). The learner trains the model. We chose a **regression** task for this problem, so we use a `FastTreeRegressionTrainer` learner, which is one of the regression learners provided by ML .NET.

The `FastTreeRegressionTrainer` learner utilizes gradient boosting. Gradient boosting is a machine learning technique for regression problems. It builds each regression tree in a step-wise fashion. It uses a pre-defined loss function to measure the error in each step and correct for it in the next. The result is a prediction model that is actually an ensemble of weaker prediction models. For more information about gradient boosting, see [Boosted Decision Tree Regression](/azure/machine-learning/studio-module-reference/boosted-decision-tree-regression).

Add the following code into the `Train` method to add the `FastTreeRegressionTrainer` to the data processing code added in the previous step:

[!code-csharp[FastTreeRegressionTrainer](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#10 "Add the FastTreeRegressionTrainer")]

## Train the model

The final step is to train the model. We train the model, <xref:Microsoft.ML.Runtime.Data.TransformerChain>, based on the dataset that has been loaded and transformed. Once the estimator has been defined, we train the model using the <xref:Microsoft.ML.Runtime.Data.EstimatorChain%601.Fit%2A> while providing the already loaded training data. This returns a model to use for predictions. `pipeline.Fit()` trains the pipeline and returns a `Transformer` based on the `DataView` passed in. The experiment is not executed until this happens.

[!code-csharp[TrainModel](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#11 "Train the model")]

And that's it! You have successfully trained a machine learning model that can predict taxi fares in NYC. Now let's take a look to understand how accurate the model is and learn how to use it to predict taxi fare values.

### Save the model

At this point, you have a model of type <xref:Microsoft.ML.Runtime.Data.TransformerChain> that can be integrated into any of your existing or new .NET applications. To save the model to a .zip file, add the following code at the end of the `Train` method:

[!code-csharp[SaveModel](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#12 "Save the model as a .zip file and return the model")]

## Save the model as a .zip file

Create the `SaveModelAsFile` method, just after the `Train` method, using the following code:

```csharp
private static void SaveModelAsFile(MLContext mlContext, ITransformer model)
{

}
```

The `SaveModelAsFile` method executes the following tasks:

* Saves the model as a .zip file.

We need to create a method to save the model so that it can be reused and consumed in other applications. The `ITransformer` has a <xref:Microsoft.ML.Runtime.Data.TransformerChain%601.SaveTo(Microsoft.ML.Runtime.IHostEnvironment,System.IO.Stream)> method that takes in the `_modelPath` global field, and a <xref:System.IO.Stream>. Since we want to save this as a zip file, we'll create the `FileStream` immediately before calling the `SaveTo` method. Add the following code to the `SaveModelAsFile` method as the next line:

[!code-csharp[SaveToMethod](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#13 "Add the SaveTo Method")]

We could also display where the file was written by writing a console message with the `_modelPath`, using the following code:

```csharp
Console.WriteLine("The model is saved to {0}", _modelPath);
```

## Evaluate the model

Evaluation is the process of checking how well the model predicts label values. It's important that the model makes good predictions on data that was not used to train the model. One way to do this is to split the data into training and test data sets, as it's done in this tutorial. Now that you've trained the model on the training data, you can see how well it performs on the test data.

The `Evaluate` method evaluates the model. To create that method, add the following code below the `Train` method:

```csharp
private static void Evaluate(MLContext mlContext, ITransformer model)
{

}
```
The `Evaluate` method executes the following tasks:

* Loads the test dataset.
* Creates the regression evaluator.
* Evaluates the model and creates metrics.
* Displays the metrics.

Add a call to the new method from the `Main` method, right under the `Train` method call, using the following code:

[!code-csharp[CallEvaluate](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#14 "Call the Evaluate method")]

We'll load the test dataset using the previously initialized  `_textLoader` global variable with the `_testDataPath` global field. You can evaluate the model using this dataset as a quality check. Add the following code to the `Evaluate` method:

[!code-csharp[LoadTestDataset](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#15 "Load the test dataset")]

Next, we'll use the machine learning `model` parameter (a transformer) to input the features and return predictions. Add the following code to the `Evaluate` method as the next line:

[!code-csharp[PredictWithTransformer](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#16 "Predict using the Transformer")]

The `RegressionContext.Evaluate` method computes the quality metrics for the `PredictionModel` using the specified dataset. It returns a <xref:Microsoft.ML.Runtime.Data.RegressionEvaluator.Result> object contains the overall metrics computed by regression evaluators. To display these to determine the quality of the model, you need to get the metrics first. Add the following code as the next line in the `Evaluate` method:

[!code-csharp[ComputeMetrics](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#17 "Compute Metrics")]

Add the following code to evaluate the model and produce the evaluation metrics:

```csharp
Console.WriteLine();
Console.WriteLine($"*************************************************");
Console.WriteLine($"*       Model quality metrics evaluation         ");
Console.WriteLine($"*------------------------------------------------");
```

[RSquared](../resources/glossary.md#coefficient-of-determination) is another evaluation metric of the regression models. RSquared takes values between 0 and 1. The closer its value is to 1, the better the model is. Add the following code into the `Evaluate` method to display the RSquared value:

[!code-csharp[DisplayRSquared](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#18 "Display the RSquared metric.")]

[RMS](../resources/glossary.md##root-of-mean-squared-error-rmse) is one of the evaluation metrics of the regression model. The lower it is, the better the model is. Add the following code into the `Evaluate` method to display the RMS value:

[!code-csharp[DisplayRMS](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#19 "Display the RMS metric.")]

## Use the model for predictions


## Predict the test data outcome with the model and a single comment

Create the `TestSinglePrediction` method, just after the `Evaluate` method, using the following code:

```csharp
private static void TestSinglePrediction(MLContext mlContext)
{

}
```

The `TestSinglePrediction` method executes the following tasks:

* Creates a single comment of test data.
* Predicts fare amount based on test data.
* Combines test data and predictions for reporting.
* Displays the predicted results.

Add a call to the new method from the `Main` method, right under the `Evaluate` method call, using the following code:

[!code-csharp[CallTestSinglePrediction](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#20 "Call the TestSinglePrediction method")]

Since we want to load the model from the zip file we saved, we'll create the `FileStream` immediately before calling the `Load` method. Add the following code to the `TestSinglePrediction` method as the next line:

[!code-csharp[LoadTheModel](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#21 "Load the model")]

While the `model` is a `transformer` that operates on many rows of data, a very common production scenario is a need for predictions on individual examples. The <xref:Microsoft.ML.Runtime.Data.PredictionFunction%602> is a wrapper that is returned from the `MakePredictionFunction` method. Let's add the following code to create the `PredictionFunction` as the first line in the `Predict` Method:

[!code-csharp[MakePredictionFunction](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#22 "Create the PredictionFunction")]
  
This tutorial uses one test trip within this class. Later you can add other scenarios to experiment with the model. Add a trip to test the trained model's prediction of cost in the `Predict` method by creating an instance of `TaxiTrip`:

[!code-csharp[PredictionData](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#23 "Create test data for single prediction")]

 We can use that to predict the fare based on a single instance of the taxi trip data. To get a prediction, use <xref:Microsoft.ML.Runtime.Data.PredictionFunction%602.Predict(%600)> on the data. Note that the input data is a string and the model includes the featurization. Your pipeline is in sync during training and prediction. You didn’t have to write preprocessing/featurization code specifically for predictions, and the same API takes care of both batch and one-time predictions.

[!code-csharp[Predict](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#24 "Create a prediction of taxi fare")]

To display the predicted fare of the specified trip, add the following code into the `Main` method:

[!code-csharp[Predict](../../../samples/machine-learning/tutorials/TaxiFarePrediction/Program.cs#25 "Display the prediction.")]

Run the program to see the predicted taxi fare for your test case.

Congratulations! You've now successfully built a machine learning model for predicting taxi trip fares, evaluated its accuracy, and used it to make predictions. You can find the source code for this tutorial at the [dotnet/samples](https://github.com/dotnet/samples/tree/master/machine-learning/tutorials/TaxiFarePrediction) GitHub repository.

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

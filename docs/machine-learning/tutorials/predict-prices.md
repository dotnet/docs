---
title: 'Tutorial: Predict prices using regression'
description: This tutorial illustrates how to build a regression model using ML.NET to predict prices, specifically, New York City taxi fares.
ms.date: 11/11/2021
ms.topic: tutorial
ms.custom: mvc, title-hack-0516
recommendations: false
#Customer intent: As a developer, I want to use ML.NET so that I can train and build a model in a regression scenario to predict prices.
---
# Tutorial: Predict prices using regression with ML.NET

This tutorial illustrates how to build a [regression model](../resources/glossary.md#regression) using ML.NET to predict prices, specifically, New York City taxi fares.

In this tutorial, you learn how to:
> [!div class="checklist"]
>
> * Prepare and understand the data
> * Load and transform the data
> * Choose a learning algorithm
> * Train the model
> * Evaluate the model
> * Use the model for predictions

## Prerequisites

* [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) with the ".NET Desktop Development" workload installed.

## Create a console application

1. Create a C# **Console Application** called "TaxiFarePrediction".

1. Choose .NET 6 as the framework to use. Click the **Create** button.

1. Create a directory named *Data* in your project to store the data set and model files.

1. Install the **Microsoft.ML** and **Microsoft.ML.FastTree** NuGet Package:

    [!INCLUDE [mlnet-current-nuget-version](../../../includes/mlnet-current-nuget-version.md)]

    In **Solution Explorer**, right-click the project and select **Manage NuGet Packages**. Choose "nuget.org" as the Package source, select the **Browse** tab, search for **Microsoft.ML**, select the package in the list, and select the **Install** button. Select the **OK** button on the **Preview Changes** dialog and then select the **I Accept** button on the **License Acceptance** dialog if you agree with the license terms for the packages listed. Do the same for the **Microsoft.ML.FastTree** NuGet package.

## Prepare and understand the data

1. Download the [taxi-fare-train.csv](https://github.com/dotnet/machinelearning/blob/main/test/data/taxi-fare-train.csv) and the [taxi-fare-test.csv](https://github.com/dotnet/machinelearning/blob/main/test/data/taxi-fare-test.csv) data sets and save them to the *Data* folder you've created at the previous step. We use these data sets to train the machine learning model and then evaluate how accurate the model is. These data sets are originally from the [NYC TLC Taxi Trip data set](https://www1.nyc.gov/site/tlc/about/tlc-trip-record-data.page).

1. In **Solution Explorer**, right-click each of the \*.csv files and select **Properties**. Under **Advanced**, change the value of **Copy to Output Directory** to **Copy if newer**.

1. Open the **taxi-fare-train.csv** data set and look at column headers in the first row. Take a look at each of the columns. Understand the data and decide which columns are **features** and which one is the **label**.

The `label` is the column you want to predict. The identified `Features`are the inputs you give the model to predict the `Label`.

The provided data set contains the following columns:

* **vendor_id:** The ID of the taxi vendor is a feature.
* **rate_code:** The rate type of the taxi trip is a feature.
* **passenger_count:** The number of passengers on the trip is a feature.
* **trip_time_in_secs:** The amount of time the trip took. You want to predict the fare of the trip before the trip is completed. At that moment, you don't know how long the trip would take. Thus, the trip time is not a feature and you'll exclude this column from the model.
* **trip_distance:** The distance of the trip is a feature.
* **payment_type:** The payment method (cash or credit card) is a feature.
* **fare_amount:** The total taxi fare paid is the label.

## Create data classes

Create classes for the input data and the predictions:

1. In **Solution Explorer**, right-click the project, and then select **Add** > **New Item**.
1. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *TaxiTrip.cs*. Then, select the **Add** button.
1. Add the following `using` directives to the new file:

   [!code-csharp[AddUsings](./snippets/predict-prices/csharp/TaxiTrip.cs#1 "Add necessary usings")]

Remove the existing class definition and add the following code, which has two classes `TaxiTrip` and `TaxiTripFarePrediction`, to the *TaxiTrip.cs* file:

[!code-csharp[DefineTaxiTrip](./snippets/predict-prices/csharp/TaxiTrip.cs#2 "Define the taxi trip and fare predictions classes")]

`TaxiTrip` is the input data class and has definitions for each of the data set columns. Use the <xref:Microsoft.ML.Data.LoadColumnAttribute> attribute to specify the indices of the source columns in the data set.

The `TaxiTripFarePrediction` class represents predicted results. It has a single float field, `FareAmount`, with a `Score` <xref:Microsoft.ML.Data.ColumnNameAttribute> attribute applied. In case of the regression task, the **Score** column contains predicted label values.

> [!NOTE]
> Use the `float` type to represent floating-point values in the input and prediction data classes.

### Define data and model paths

Add the following additional `using` statements to the top of the *Program.cs* file:

[!code-csharp[AddUsings](./snippets/predict-prices/csharp/Program.cs#1 "Add necessary usings")]

You need to create three fields to hold the paths to the files with data sets and the file to save the model:

* `_trainDataPath` contains the path to the file with the data set used to train the model.
* `_testDataPath` contains the path to the file with the data set used to evaluate the model.
* `_modelPath` contains the path to the file where the trained model is stored.

Add the following code right below the usings section to specify those paths and for the `_textLoader` variable:

[!code-csharp[InitializePaths](./snippets/predict-prices/csharp/Program.cs#2 "Define variables to store the data file paths")]

All ML.NET operations start in the [MLContext class](xref:Microsoft.ML.MLContext). Initializing `mlContext` creates a new ML.NET environment that can be shared across the model creation workflow objects. It's similar, conceptually, to `DBContext` in Entity Framework.

### Initialize variables

Replace the `Console.WriteLine("Hello World!")` line with the following code to declare and initialize the `mlContext` variable:

[!code-csharp[CreateMLContext](./snippets/predict-prices/csharp/Program.cs#3 "Create the ML Context")]

Add the following as the next line of code to call the `Train` method:

[!code-csharp[Train](./snippets/predict-prices/csharp/Program.cs#5 "Train your model")]

The `Train()` method executes the following tasks:

* Loads the data.
* Extracts and transforms the data.
* Trains the model.
* Returns the model.

The `Train` method trains the model. Create that method just below using the following code:

```csharp
ITransformer Train(MLContext mlContext, string dataPath)
{

}
```

## Load and transform data

ML.NET uses the [IDataView interface](xref:Microsoft.ML.IDataView) as a flexible, efficient way of describing numeric or text tabular data. `IDataView` can load either text files or in real time (for example, SQL database or log files). Add the following code as the first line of the `Train()` method:

[!code-csharp[LoadTrainData](./snippets/predict-prices/csharp/Program.cs#6 "loading training dataset")]

As you want to predict the taxi trip fare, the `FareAmount` column is the `Label` that you will predict (the output of the model). Use the `CopyColumnsEstimator` transformation class to copy `FareAmount`, and add the following code:

[!code-csharp[CopyColumnsEstimator](./snippets/predict-prices/csharp/Program.cs#7 "Use the CopyColumnsEstimator")]

The algorithm that trains the model requires **numeric** features, so you have to transform the categorical data (`VendorId`, `RateCode`, and `PaymentType`) values into numbers (`VendorIdEncoded`, `RateCodeEncoded`, and `PaymentTypeEncoded`). To do that, use the [OneHotEncodingTransformer](xref:Microsoft.ML.Transforms.OneHotEncodingTransformer) transformation class, which assigns different numeric key values to the different values in each of the columns, and add the following code:

[!code-csharp[OneHotEncodingEstimator](./snippets/predict-prices/csharp/Program.cs#8 "Use the OneHotEncodingEstimator")]

The last step in data preparation combines all of the feature columns into the **Features** column using the `mlContext.Transforms.Concatenate` transformation class. By default, a learning algorithm processes only features from the **Features** column. Add the following code:

[!code-csharp[ColumnConcatenatingEstimator](./snippets/predict-prices/csharp/Program.cs#9 "Use the ColumnConcatenatingEstimator")]

## Choose a learning algorithm

This problem is about predicting a taxi trip fare in New York City. At first glance, it may seem to depend simply on the distance traveled. However, taxi vendors in New York charge varying amounts for other factors such as additional passengers or paying with a credit card instead of cash. You want to predict the price value, which is a real value, based on the other factors in the dataset. To do that, you choose a [regression](../resources/glossary.md#regression) machine learning task.

Append the [FastTreeRegressionTrainer](xref:Microsoft.ML.Trainers.FastTree.FastTreeRegressionTrainer) machine learning task to the data transformation definitions by adding the following as the next line of code in `Train()`:

[!code-csharp[FastTreeRegressionTrainer](./snippets/predict-prices/csharp/Program.cs#10 "Add the FastTreeRegressionTrainer")]

## Train the model

Fit the model to the training `dataview` and return the trained model by adding the following line of code in the `Train()` method:

[!code-csharp[TrainModel](./snippets/predict-prices/csharp/Program.cs#11 "Train the model")]

The [Fit()](xref:Microsoft.ML.Trainers.FastTree.FastTreeRegressionTrainer.Fit%28Microsoft.ML.IDataView,Microsoft.ML.IDataView%29) method trains your model by transforming the dataset and applying the training.

Return the trained model with the following line of code in the `Train()` method:

[!code-csharp[ReturnModel](./snippets/predict-prices/csharp/Program.cs#12 "Return the model")]

## Evaluate the model

Next, evaluate your model performance with your test data for quality assurance and validation. Create the `Evaluate()` method, just after `Train()`, with the following code:

```csharp
void Evaluate(MLContext mlContext, ITransformer model)
{

}
```

The `Evaluate` method executes the following tasks:

* Loads the test dataset.
* Creates the regression evaluator.
* Evaluates the model and creates metrics.
* Displays the metrics.

Add a call to the new method right under the `Train` method call, using the following code:

[!code-csharp[CallEvaluate](./snippets/predict-prices/csharp/Program.cs#14 "Call the Evaluate method")]

Load the test dataset using the [LoadFromTextFile()](xref:Microsoft.ML.TextLoaderSaverCatalog.LoadFromTextFile%2A) method. Evaluate the model using this dataset as a quality check by adding the following code in the `Evaluate` method:

[!code-csharp[LoadTestDataset](./snippets/predict-prices/csharp/Program.cs#15 "Load the test dataset")]

Next, transform the `Test` data by adding the following code to `Evaluate()`:

[!code-csharp[PredictWithTransformer](./snippets/predict-prices/csharp/Program.cs#16 "Predict using the Transformer")]

The [Transform()](xref:Microsoft.ML.ITransformer.Transform%2A) method makes predictions for the test dataset input rows.

The `RegressionContext.Evaluate` method computes the quality metrics for the `PredictionModel` using the specified dataset. It returns a <xref:Microsoft.ML.Data.RegressionMetrics> object that contains the overall metrics computed by regression evaluators.

To display these to determine the quality of the model, you need to get the metrics first. Add the following code as the next line in the `Evaluate` method:

[!code-csharp[ComputeMetrics](./snippets/predict-prices/csharp/Program.cs#17 "Compute Metrics")]

Once you have the prediction set, the [Evaluate()](xref:Microsoft.ML.RegressionCatalog.Evaluate%2A) method assesses the model, which compares the predicted values with the actual `Labels` in the test dataset and returns metrics on how the model is performing.

Add the following code to evaluate the model and produce the evaluation metrics:

```csharp
Console.WriteLine();
Console.WriteLine($"*************************************************");
Console.WriteLine($"*       Model quality metrics evaluation         ");
Console.WriteLine($"*------------------------------------------------");
```

[RSquared](../resources/glossary.md#coefficient-of-determination) is another evaluation metric of the regression models. RSquared takes values between 0 and 1. The closer its value is to 1, the better the model is. Add the following code into the `Evaluate` method to display the RSquared value:

[!code-csharp[DisplayRSquared](./snippets/predict-prices/csharp/Program.cs#18 "Display the RSquared metric.")]

[RMS](../resources/glossary.md#root-of-mean-squared-error-rmse) is one of the evaluation metrics of the regression model. The lower it is, the better the model is. Add the following code into the `Evaluate` method to display the RMS value:

[!code-csharp[DisplayRMS](./snippets/predict-prices/csharp/Program.cs#19 "Display the RMS metric.")]

## Use the model for predictions

Create the `TestSinglePrediction` method, just after the `Evaluate` method, using the following code:

```csharp
void TestSinglePrediction(MLContext mlContext, ITransformer model)
{

}
```

The `TestSinglePrediction` method executes the following tasks:

* Creates a single comment of test data.
* Predicts fare amount based on test data.
* Combines test data and predictions for reporting.
* Displays the predicted results.

Add a call to the new method right under the `Evaluate` method call, using the following code:

[!code-csharp[CallTestSinglePrediction](./snippets/predict-prices/csharp/Program.cs#20 "Call the TestSinglePrediction method")]

Use the `PredictionEngine` to predict the fare by adding the following code to `TestSinglePrediction()`:

[!code-csharp[MakePredictionEngine](./snippets/predict-prices/csharp/Program.cs#22 "Create the PredictionFunction")]

The [PredictionEngine](xref:Microsoft.ML.PredictionEngine%602) is a convenience API, which allows you to perform a prediction on a single instance of data. [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) is not thread-safe. It's acceptable to use in single-threaded or prototype environments. For improved performance and thread safety in production environments, use the `PredictionEnginePool` service, which creates an [`ObjectPool`](xref:Microsoft.Extensions.ObjectPool.ObjectPool%601) of [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) objects for use throughout your application. See this guide on how to [use `PredictionEnginePool` in an ASP.NET Core Web API](../how-to-guides/serve-model-web-api-ml-net.md#register-predictionenginepool-for-use-in-the-application).

> [!NOTE]
> `PredictionEnginePool` service extension is currently in preview.

This tutorial uses one test trip within this class. Later you can add other scenarios to experiment with the model. Add a trip to test the trained model's prediction of cost in the `TestSinglePrediction()` method by creating an instance of `TaxiTrip`:

[!code-csharp[PredictionData](./snippets/predict-prices/csharp/Program.cs#23 "Create test data for single prediction")]

Next, predict the fare based on a single instance of the taxi trip data and pass it to the `PredictionEngine` by adding the following as the next lines of code in the `TestSinglePrediction()` method:

[!code-csharp[Predict](./snippets/predict-prices/csharp/Program.cs#24 "Create a prediction of taxi fare")]

The [Predict()](xref:Microsoft.ML.PredictionEngine%602.Predict%2A) function makes a prediction on a single instance of data.

To display the predicted fare of the specified trip, add the following code into the `TestSinglePrediction` method:

[!code-csharp[Predict](./snippets/predict-prices/csharp/Program.cs#25 "Display the prediction.")]

Run the program to see the predicted taxi fare for your test case.

Congratulations! You've now successfully built a machine learning model for predicting taxi trip fares, evaluated its accuracy, and used it to make predictions. You can find the source code for this tutorial at the [dotnet/samples](https://github.com/dotnet/samples/tree/main/machine-learning/tutorials/TaxiFarePrediction) GitHub repository.

## Next steps

In this tutorial, you learned how to:

> [!div class="checklist"]
>
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

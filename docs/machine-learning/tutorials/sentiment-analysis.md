---
title: Use ML.NET in a sentiment analysis binary classification scenario
description: Discover how to use ML.NET in a binary classification scenario to understand how to use sentiment prediction to take the appropriate action.
ms.date: 12/20/2018
ms.topic: tutorial
ms.custom: mvc, seodec18
#Customer intent: As a developer, I want to use ML.NET to apply a binary classification task so that I can understand how to use sentiment prediction to take appropriate action.
---
# Tutorial: Use ML.NET in a sentiment analysis binary classification scenario

> [!NOTE]
> This topic refers to ML.NET, which is currently in Preview, and material may be subject to change. For more information, visit [the ML.NET introduction](https://www.microsoft.com/net/learn/apps/machine-learning-and-ai/ml-dotnet).

This sample tutorial illustrates using ML.NET to create a sentiment classifier via a .NET Core console application using C# in Visual Studio 2017.

In this tutorial, you learn how to:
> [!div class="checklist"]
> * Understand the problem
> * Select the appropriate machine learning task
> * Prepare your data
> * Create the learning pipeline
> * Load a classifier
> * Train the model
> * Evaluate the model with a different dataset
> * Predict a single instance of test data outcome with the model
> * Predict the test data outcomes with a loaded model

## Sentiment analysis sample overview

The sample is a console app that uses ML.NET to train a model that classifies and predicts sentiment as either positive or negative. It also evaluates the model with a second dataset for quality analysis. The sentiment datasets are from the WikiDetox project.

## Prerequisites

* [Visual Studio 2017 15.6 or later](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=button+cta&utm_content=download+vs2017) with the ".NET Core cross-platform development" workload installed.

* The [Wikipedia detox line data tab separated file (wikiPedia-detox-250-line-data.tsv)](https://github.com/dotnet/machinelearning/blob/master/test/data/wikipedia-detox-250-line-data.tsv).
* The [Wikipedia detox line test tab separated file (wikipedia-detox-250-line-test.tsv)](https://github.com/dotnet/machinelearning/blob/master/test/data/wikipedia-detox-250-line-test.tsv).

## Machine learning workflow

This tutorial follows a machine learning workflow that enables the process to move in an orderly fashion.

The workflow phases are as follows:

1. **Understand the problem**
2. **Prepare your data**
   * **Load the data**
   * **Extract features (Transform your data)**
3. **Build and train** 
   * **Train the model**
   * **Evaluate the model**
4. **Run**
   * **Model consumption**

### Understand the problem

You first need to understand the problem, so you can break it down to parts that can support building and training the model. Breaking the problem down allows you to predict and evaluate the results.

The problem for this tutorial is to understand incoming website comment sentiment to take the appropriate action.

You can break down the problem to the sentiment text and sentiment value for the data you want to train the model with, and a predicted sentiment value that you can evaluate and then use operationally.

You then need to **determine** the sentiment, which helps you with the machine learning task selection.

## Select the appropriate machine learning task

With this problem, you know the following facts:

Training data: website comments can be toxic (1) or not toxic (0) (**sentiment**).
Predict the **sentiment** of a new website comment, either toxic or not toxic, such as in the following examples:

* Please refrain from adding nonsense to Wikipedia.
* He is the best, and the article should say that.

The classification machine learning task is best suited for this scenario.

### About the classification task

Classification is a machine learning task that uses data to **determine** the category, type, or class of an item or row of data. For example, you can use classification to:

* Identify sentiment as positive or negative.
* Classify email as spam, junk, or good.
* Determine whether a patient's lab sample is cancerous.
* Categorize customers by their propensity to respond to a sales campaign.

Classification tasks are frequently one of the following types:

* Binary: either A or B.
* Multiclass: multiple categories that can be predicted by using a single model.

## Create a console application

1. Open Visual Studio 2017. Select **File** > **New** > **Project** from the menu bar. In the **New Project** dialog, select the **Visual C#** node followed by the **.NET Core** node. Then select the **Console App (.NET Core)** project template. In the **Name** text box, type "SentimentAnalysis" and then select the **OK** button.

2. Create a directory named *Data* in your project to save your data set files:

    In **Solution Explorer**, right-click on your project and select **Add** > **New Folder**. Type "Data" and hit Enter.

3. Install the **Microsoft.ML NuGet Package**:

    In Solution Explorer, right-click on your project and select **Manage NuGet Packages**. Choose "nuget.org" as the Package source, select the Browse tab, search for **Microsoft.ML**, select that package in the list, and select the **Install** button. Select the **OK** button on the **Preview Changes** dialog and then select the **I Accept** button on the **License Acceptance** dialog if you agree with the license terms for the packages listed.

### Prepare your data

1. Download the [WikiPedia detox-250-line-data.tsv](https://github.com/dotnet/machinelearning/blob/master/test/data/wikipedia-detox-250-line-data.tsv) and the [wikipedia-detox-250-line-test.tsv](https://github.com/dotnet/machinelearning/blob/master/test/data/wikipedia-detox-250-line-test.tsv) data sets and save them to the *Data* folder previously created. The first dataset trains the machine learning model and the second can be used to evaluate how accurate your model is.

2. In Solution Explorer, right-click each of the \*.tsv files and select **Properties**. Under **Advanced**, change the value of **Copy to Output Directory** to **Copy if newer**.

### Create classes and define paths

Add the following additional `using` statements to the top of the *Program.cs* file:

[!code-csharp[AddUsings](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#1 "Add necessary usings")]

You need to create three global fields to hold the paths to the recently downloaded files, and a global variable for the `TextLoader`:

* `_trainDataPath` has the path to the dataset used to train the model.
* `_testDataPath` has the path to the dataset used to evaluate the model.
* `_modelPath` has the path where the trained model is saved.
* `_textLoader` is the <xref:Microsoft.ML.Runtime.Data.TextLoader> used to load and transform the datasets.

Add the following code to the line right above the `Main` method to specify those paths and the `_textLoader` variable:

[!code-csharp[Declare global variables](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#2 "Declare global variables")]

You need to create some classes for your input data and predictions. Add a new class to your project:

1. In **Solution Explorer**, right-click the project, and then select **Add** > **New Item**.

1. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *SentimentData.cs*. Then, select the **Add** button.

    The *SentimentData.cs* file opens in the code editor. Add the following `using` statement to the top of *SentimentData.cs*:

[!code-csharp[AddUsings](../../../samples/machine-learning/tutorials/SentimentAnalysis/SentimentData.cs#1 "Add necessary usings")]

Remove the existing class definition and add the following code, which has two classes `SentimentData` and `SentimentPrediction`, to the *SentimentData.cs* file:

[!code-csharp[DeclareTypes](../../../samples/machine-learning/tutorials/SentimentAnalysis/SentimentData.cs#2 "Declare data record types")]

`SentimentData` is the input dataset class and has a `float` (`Sentiment`) that has a value for sentiment of either positive or negative, and a string for the comment (`SentimentText`). Both fields have `Column` attributes attached to them. This attribute describes the order of each field in the data file, and which is the `Label` field. `SentimentPrediction` is the class used for prediction after the model has been trained. It has a single boolean (`Sentiment`) and a `PredictedLabel` `ColumnName` attribute. The `Label` is used to create and train the model, and it's also used with a second dataset to evaluate the model. The `PredictedLabel` is used during prediction and evaluation. For evaluation, an input with training data, the predicted values, and the model are used.

When building a model with ML.NET you start by creating an `MLContext`. This is comparable conceptually to using `DbContext` in Entity Framework. The environment provides a context for your ML job that can be used for exception tracking and logging.

### Initialize variables in Main

Create a variable called `mlContext` and initialize it with a new instance of `MLContext`.  Replace the `Console.WriteLine("Hello World!")` line with the following code in the `Main` method:

[!code-csharp[CreateMLContext](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#3 "Create the ML Context")]

Next, to setup for data loading initialize the `_textLoader` global variable in order to reuse it.  Notice that you're using a `TextReader`. When you create a `TextLoader` using a `TextReader`, you pass in the context needed and the <xref:Microsoft.ML.Runtime.Data.TextLoader.Arguments> class which enables customization.

 Specify the data schema by passing an array of <xref:Microsoft.ML.Runtime.Data.TextLoader.Column> objects to the loader containing all the column names and their types. You defined the data schema previously when you created our `SentimentData` class. For our schema, the first column (Label) is a <xref:System.Boolean> (the prediction) and the second column (SentimentText) is the feature of type text/string used for predicting the sentiment.
The `TextReader` class returns a fully initialized <xref:Microsoft.ML.Runtime.Data.TextLoader>  

To initialize the `_textLoader` global variable in order to reuse it for the needed datasets, add the following code after the  `mlContext` initialization:

[!code-csharp[initTextReader](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#4 "Initialize the TextReader")]

Add the following as the next line of code in the `Main` method:

[!code-csharp[Train](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#5 "Train your model")]

The `Train` method executes the following tasks:

* Loads the data.
* Extracts and transforms the data.
* Trains the model.
* Predicts sentiment based on test data.
* Returns the model.

Create the `Train` method, just after the `Main` method, using the following code:

```csharp
 public static ITransformer Train(MLContext mlContext, string dataPath)
{

}
```

Notice that two parameters are passed into the Train method; a `MLContext` for the context (`mlContext`), and a <xref:System.String> for the dataset path (`dataPath`). You're going to use this method more than once for training and testing.

## Load the data

You'll load the data using the `_textLoader` global variable with the `dataPath` parameter. It returns a
<xref:Microsoft.ML.Runtime.Data.IDataView>. As the input and output of `Transforms`, a `DataView` is the fundamental data pipeline type, comparable to `IEnumerable` for `LINQ`.

In ML.NET, data is similar to a SQL view. It is lazily evaluated, schematized, and heterogenous. The object is the first part of the pipeline, and loads the data. For this tutorial, it loads a dataset with comments and corresponding toxic or non toxic sentiment. This is used to create the model, and train it.

 Add the following code as the first line of the `Train` method:

[!code-csharp[LoadTrainData](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#6 "loading training dataset")]

## Extract and transform the data

Pre-processing and cleaning data are important tasks that occur before a dataset is used effectively for machine learning. Raw data is often noisy and unreliable, and may be missing values. Using data without these modeling tasks can produce misleading results.

ML.NET's transform pipelines compose a custom set of transforms that are applied to your data before training or testing. The transforms' primary purpose is data [featurization](../resources/glossary.md#feature-engineering). Machine learning algorithms understand [featurized](../resources/glossary.md#feature) data, so the next step is to transform our textual data into a format that our ML algorithms recognize. That format is a [numeric vector](../resources/glossary.md#numerical-feature-vector).

Next, call `mlContext.Transforms.Text.FeaturizeText` which featurizes the text column (`SentimentText`) column into a numeric vector called `Features` used by the machine learning algorithm. This is a wrapper call that returns an <xref:Microsoft.ML.Runtime.Data.EstimatorChain%601> that will effectively be a pipeline. Name this `pipeline` as you will then append the trainer to the `EstimatorChain`. Add this as the next line of code:

[!code-csharp[TextFeaturizingEstimator](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#7 "Add a TextFeaturizingEstimator")]

This is the preprocessing/featurization step. Using additional components available in ML.NET can enable better results with your model.

## Choose a learning algorithm

To add the trainer, call the `mlContext.Transforms.Text.FeaturizeText` wrapper method which returns a <xref:Microsoft.ML.Trainers.FastTree.FastTreeBinaryClassificationTrainer> object. This is a decision tree learner you'll use in this pipeline. The `FastTreeBinaryClassificationTrainer` is appended to the `pipeline` and accepts the featurized `SentimentText` (`Features`) and the `Label` input parameters to learn from the historic data.

Add the following code to the `Train` method:

[!code-csharp[FastTreeBinaryClassificationTrainer](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#8 "Add a FastTreeBinaryClassificationTrainer")]

## Train the model

You train the model, <xref:Microsoft.ML.Data.TransformerChain%601>, based on the dataset that has been loaded and transformed. Once the estimator has been defined, you train your model using the <xref:Microsoft.ML.Runtime.Data.EstimatorChain%601.Fit%2A> while providing the already loaded training data. This returns a model to use for predictions. `pipeline.Fit()` trains the pipeline and returns a `Transformer` based on the `DataView` passed in. The experiment is not executed until this happens.

Add the following code to the `Train` method:

[!code-csharp[TrainModel](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#9 "Train the model")]

### Save and Return the model trained to use for evaluation

At this point, you have a model of type <xref:Microsoft.ML.Data.TransformerChain%601> that can be integrated into any of your existing or new .NET applications. Return the model at the end of the `Train` method.

[!code-csharp[ReturnModel](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#10 "Return the model")]

## Evaluate the model

Now that you've created and trained the model, you need to evaluate it with a different dataset for quality assurance and validation. In the `Evaluate` method, the model created in `Train` is passed in to be evaluated. Create the `Evaluate` method, just after `Train`, as in the following code:

```csharp
public static void Evaluate(MLContext mlContext, ITransformer model)
{

}
```

The `Evaluate` method executes the following tasks:

* Loads the test dataset.
* Creates the binary evaluator.
* Evaluates the model and create metrics.
* Displays the metrics.

Add a call to the new method from the `Main` method, right under the `Train` method call, using the following code:

[!code-csharp[CallEvaluate](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#11 "Call the Evaluate method")]

You'll load the test dataset using the previously initialized  `_textLoader` global variable with the `_testDataPath` global field. You can evaluate the model using this dataset as a quality check. Add the following code to the `Evaluate` method:

[!code-csharp[LoadTestDataset](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#12 "Load the test dataset")]

Next, you'll use the machine learning `model` parameter (a transformer) to input the features and return predictions. Add the following code to the `Evaluate` method as the next line:

[!code-csharp[PredictWithTransformer](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#13 "Predict using the Transformer")]

The `BinaryClassificationContext.Evaluate` method computes the quality metrics for the `PredictionModel` using the specified dataset. It returns a `BinaryClassificationEvaluator.CalibratedResult` object contains the overall metrics computed by binary classification evaluators. To display these to determine the quality of the model, you need to get the metrics first. Add the following code as the next line in the `Evaluate` method:

[!code-csharp[ComputeMetrics](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#14 "Compute Metrics")]

### Displaying the metrics for model validation

Use the following code to display the metrics, share the results, and then act on them:

[!code-csharp[DisplayMetrics](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#15 "Display selected metrics")]

To save your model to a .zip file before returning, add the following code to call the `SaveModelAsFile` method as the next line in `TrainFinalModel`:

[!code-csharp[SaveModel](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#23 "Save the model")]

## Save the model as a.zip file

Create the `SaveModelAsFile` method, just after the `Evaluate` method, using the following code:

```csharp
private static void SaveModelAsFile(MLContext mlContext, ITransformer model)
{

}
```

The `SaveModelAsFile` method executes the following tasks:

* Saves the model as a .zip file.

Next, create a method to save the model so that it can be reused and consumed in other applications. The `ITransformer` has a <xref:Microsoft.ML.Data.TransformerChain%601.SaveTo(Microsoft.ML.Runtime.IHostEnvironment,System.IO.Stream)> method that takes in the `_modelPath` global field, and a <xref:System.IO.Stream>. To save this as a zip file, you'll create the `FileStream` immediately before calling the `SaveTo` method. Add the following code to the `SaveModelAsFile` method as the next line:

[!code-csharp[SaveToMethod](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#24 "Add the SaveTo Method")]

You could also display where the file was written by writing a console message with the `_modelPath`, using the following code:

```csharp
Console.WriteLine("The model is saved to {0}", _modelPath);
```

## Predict the test data outcome with the model and a single comment

Create the `Predict` method, just after the `Evaluate` method, using the following code:

```csharp
private static void Predict(MLContext mlContext, ITransformer model)
{

}
```

The `Predict` method executes the following tasks:

* Creates a single comment of test data.
* Predicts sentiment based on test data.
* Combines test data and predictions for reporting.
* Displays the predicted results.

Add a call to the new method from the `Main` method, right under the `Evaluate` method call, using the following code:

[!code-csharp[CallPredict](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#16 "Call the Predict method")]

While the `model` is a `transformer` that operates on many rows of data, a very common production scenario is a need for predictions on individual examples. The <xref:Microsoft.ML.Runtime.Data.PredictionFunction%602> is a wrapper that is returned from the `MakePredictionFunction` method. Let's add the following code to create the PredictionFunction as the first line in the `Predict` Method:

[!code-csharp[MakePredictionFunction](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#17 "Create the PredictionFunction")]
  
Add a comment to test the trained model's prediction in the `Predict` method by creating an instance of `SentimentData`:

[!code-csharp[PredictionData](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#18 "Create test data for single prediction")]


 You can use that to predict the Toxic or Non Toxic sentiment of a single instance of the comment data. To get a prediction, use <xref:Microsoft.ML.Runtime.Data.PredictionFunction%602.Predict(%600)> on the data. Note that the input data is a string and the model includes the featurization. Your pipeline is in sync during training and prediction. You didn’t have to write preprocessing/featurization code specifically for predictions, and the same API takes care of both batch and one-time predictions.

[!code-csharp[Predict](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#19 "Create a prediction of sentiment")]

### Model operationalization: prediction

Display `SentimentText` and corresponding sentiment prediction in order to share the results and act on them accordingly. This is called operationalization, using the returned data as part of the operational policies. Create a display for the results using the following <xref:System.Console.WriteLine?displayProperty=nameWithType> code:

[!code-csharp[OutputPrediction](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#20 "Display prediction output")]

## Predict the test data outcomes with the saved model

Create the `PredictWithModelLoadedFromFile` method, just before the `SaveModelAsFile` method, using the following code:

```csharp
public static void PredictWithModelLoadedFromFile(MLContext mlContext)
{

}
```

The `PredictWithModelLoadedFromFile` method executes the following tasks:

* Creates batch test data.
* Predicts sentiment based on test data.
* Combines test data and predictions for reporting.
* Displays the predicted results.

Add a call to the new method from the `Main` method, right under the `Predict` method call, using the following code:

[!code-csharp[CallPredictModelLoaded](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#25 "Call the PredictWithModelLoadedFromFile method")]

Add some comments to test the trained model's predictions in the `PredictWithModelLoadedFromFile` method:

[!code-csharp[PredictionData](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#26 "Create test data for predictions")]

Load the model
[!code-csharp[LoadTheModel](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#27 "Load the model")]

Now that you have a model, you can use that to predict the Toxic or Non Toxic sentiment of the comment data using the <xref:Microsoft.ML.Core.Data.ITransformer.Transform(Microsoft.ML.Runtime.Data.IDataView)> method. To get a prediction, use `Predict` on new data. Note that the input data is a string and the model includes the featurization. Your pipeline is in sync during training and prediction. You didn’t have to write preprocessing/featurization code specifically for predictions, and the same API takes care of both batch and one-time predictions. Add the following code to the `PredictWithModelLoadedFromFile` method for the predictions:

[!code-csharp[Predict](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#28 "Create predictions of sentiments")]

### Model operationalization: prediction

Display `SentimentText` and corresponding sentiment prediction in order to share the results and act on them accordingly. This is called operationalization, using the returned data as part of the operational policies. Create a header for the results using the following <xref:System.Console.WriteLine?displayProperty=nameWithType> code:

[!code-csharp[OutputHeaders](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#29 "Display prediction outputs")]

Before displaying the predicted results, combine the sentiment and prediction together to see the original comment with its predicted sentiment. The following code uses the <xref:System.Linq.Enumerable.Zip%2A> method to make that happen, so add that code next:

[!code-csharp[BuildTuples](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#30 "Build the pairs of sentiment data and predictions")]

Now that you've combined the `SentimentText` and `Sentiment` into a class, you can display the results using the <xref:System.Console.WriteLine?displayProperty=nameWithType> method:

[!code-csharp[DisplayPredictions](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#31 "Display the predictions")]

Because inferred tuple element names are a new feature in C# 7.1 and the default language version of the project is C# 7.0, you need to change the language version to C# 7.1 or higher.
To do that, right-click on the project node in **Solution Explorer** and select **Properties**. Select the **Build** tab and select the **Advanced** button. In the dropdown, select  **C# 7.1** (or a higher version). Select the **OK** button.

## Results

Your results should be similar to the following. As the pipeline processes, it displays messages. You may see warnings, or processing messages. These have been removed from the following results for clarity.

```console
Model quality metrics evaluation
--------------------------------
Accuracy: 94.44%
Auc: 98.77%
F1Score: 94.74%
=============== End of model evaluation ===============

=============== Prediction Test of model with a single sample and test dataset ===============

Sentiment: This is a very rude movie | Prediction: Toxic | Probability: 0.5297049
=============== End of Predictions ===============

=============== New iteration of Model ===============
=============== Create and Train the Model ===============
=============== End of training ===============


The model is saved to: C:\Tutorial\SentimentAnalysis\bin\Debug\netcoreapp2.0\Data\Model.zip

=============== Prediction Test of loaded model with a multiple samples ===============

Sentiment: This is a very rude movie | Prediction: Toxic | Probability: 0.4585565
Sentiment: He is the best, and the article should say that. | Prediction: Not Toxic | Probability: 0.9924279

```

Congratulations! You've now successfully built a machine learning model for classifying and predicting messages sentiment. You can find the source code for this tutorial at the [dotnet/samples](https://github.com/dotnet/samples/tree/master/machine-learning/tutorials/SentimentAnalysis) repository.

## Next steps

In this tutorial, you learned how to:
> [!div class="checklist"]
> * Understand the problem
> * Select the appropriate machine learning task
> * Prepare your data
> * Create the learning pipeline
> * Load a classifier
> * Train the model
> * Evaluate the model with a different dataset
> * Predict the test data outcomes with the model

Advance to the next tutorial to learn more
> [!div class="nextstepaction"]
> [Taxi Fare Predictor](taxi-fare.md)

---
title: Use ML.NET in a GitHub issue multiclass classification scenario
description: Discover how to use ML.NET in a multiclass classification scenario to classify GitHub issues to assign them to a given area.
ms.date: 01/24/2019
ms.topic: tutorial
ms.custom: mvc
#Customer intent: As a developer, I want to use ML.NET to apply a multiclass classification task so that I can understand how to classify GitHGub issues to assign them to a given area.
---
# Tutorial: Use ML.NET in a multiclass classification scenario to classify GitHub issues.

This sample tutorial illustrates using ML.NET to create a GitHub issue classifier via a .NET Core console application using C# in Visual Studio 2017.

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

> [!NOTE]
> This topic refers to ML.NET, which is currently in Preview, and material may be subject to change. For more information, visit [the ML.NET introduction](https://www.microsoft.com/net/learn/apps/machine-learning-and-ai/ml-dotnet).

## GitHub issue sample overview

The sample is a console app that uses ML.NET to train a model that classifies and predicts the Area label for a GitHub issue. It also evaluates the model with a second dataset for quality analysis. The issue datasets are from the dotnet/corefx GitHub repo.

## Prerequisites

* [Visual Studio 2017 15.6 or later](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=button+cta&utm_content=download+vs2017) with the ".NET Core cross-platform development" workload installed.

* The [Github issues tab separated file (issues_train.tsv)](https://raw.githubusercontent.com/dotnet/samples/master/machine-learning/tutorials/GitHubIssueClassification/Data/issues_train.tsv).
* The [Github issues test tab separated file (issues_test.tsv)](https://raw.githubusercontent.com/dotnet/samples/master/machine-learning/tutorials/GitHubIssueClassification/Data/issues_test.tsv).

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

You first need to understand the problem, so you can break it down to parts that can support building and training the model. Breaking  down the problem allows you to predict and evaluate the results.

The problem for this tutorial is to understand what area incoming GitHub issues belong to in order to label them correctly for prioritization and scheduling.

You can break down the problem to the following:

* the issue title text
* the issue description text
* an area value for the model training data
* a predicted area value that you can evaluate and then use operationally

You then need to **determine** the area, which helps you with the machine learning task selection.

## Select the appropriate machine learning task

With this problem, you know the following facts:

Training data:

GitHub issues can be labeled in several areas (**Area**) as in the following examples:

* area-System.Numerics
* area-System.Xml
* area-Infrastructure
* area-System.Linq
* area-System.IO

Predict the **Area** of a new GitHub Issue such as in the following examples:

* Contract.Assert vs Debug.Assert
* Make fields readonly in System.Xml

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

For this type of problem, use a Multiclass classification task, since your issue category prediction can be one of multiple categories (multiclass) rather than just two (binary).

## Create a console application

### Create a project

1. Open Visual Studio 2017. Select **File** > **New** > **Project** from the menu bar. In the **New Project** dialog, select the **Visual C#** node followed by the **.NET Core** node. Then select the **Console App (.NET Core)** project template. In the **Name** text box, type "SentimentAnalysis" and then select the **OK** button.

2. Create a directory named *Data* in your project to save your data set files:

    In **Solution Explorer**, right-click on your project and select **Add** > **New Folder**. Type "Data" and hit Enter.

3. Install the **Microsoft.ML NuGet Package**:

    In Solution Explorer, right-click on your project and select **Manage NuGet Packages**. Choose "nuget.org" as the Package source, select the Browse tab, search for **Microsoft.ML**, select that package in the list, and select the **Install** button. Select the **OK** button on the **Preview Changes** dialog and then select the **I Accept** button on the **License Acceptance** dialog if you agree with the license terms for the packages listed.

### Prepare your data

1. Download the [issues_train.tsv](https://raw.githubusercontent.com/dotnet/samples/master/machine-learning/tutorials/GitHubIssueClassification/Data/issues_train.tsv) and the [issues_test.tsv](https://raw.githubusercontent.com/dotnet/samples/master/machine-learning/tutorials/GitHubIssueClassification/Data/issues_test.tsv) data sets and save them to the *Data* folder previously created. The first dataset trains the machine learning model and the second can be used to evaluate how accurate your model is.

2. In Solution Explorer, right-click each of the \*.tsv files and select **Properties**. Under **Advanced**, change the value of **Copy to Output Directory** to **Copy if newer**.

### Create classes and define paths

Add the following additional `using` statements to the top of the *Program.cs* file:

[!code-csharp[AddUsings](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#AddUsings)]

You need to create three global fields to hold the paths to the recently downloaded files, and a global variable for the `TextLoader`:

* `_trainDataPath` has the path to the dataset used to train the model.
* `_testDataPath` has the path to the dataset used to evaluate the model.
* `_modelPath` has the path where the trained model is saved.
* `_mlContext` is the <xref:Microsoft.ML.MLContext> that provides processing context.
* `_trainingDataView` is the <xref:Microsoft.ML.Data.IDataView> used to process the training dataset.
* `_predEngine` is the <xref:Microsoft.ML.PredictionEngine%602> used for single predictions.
* `_reader` is the <xref:Microsoft.ML.Data.TextLoader> used to load and transform the datasets.

Add the following code to the line right above the `Main` method to specify those paths and the other variables:

[!code-csharp[DeclareGlobalVariables](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#DeclareGlobalVariables)]

You need to create some classes for your input data and predictions. Add a new class to your project:

1. In **Solution Explorer**, right-click the project, and then select **Add** > **New Item**.

1. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *GitHubIssueData.cs*. Then, select the **Add** button.

    The *GitHubIssueData.cs* file opens in the code editor. Add the following `using` statement to the top of *GitHubIssueData.cs*:

[!code-csharp[AddUsings](../../../samples/machine-learning/tutorials/GitHubIssueClassification/GitHubIssueData.cs#AddUsings)]

Remove the existing class definition and add the following code, which has two classes `GitHubIssue` and `IssuePrediction`, to the *GitHubIssueData.cs* file:

[!code-csharp[DeclareTypes](../../../samples/machine-learning/tutorials/GitHubIssueClassification/GitHubIssueData.cs#DeclareTypes)]

`GitHubIssue` is the input dataset class and has the following <xref:System.String> fields:

* `ID` contains a value for the GitHub issue ID
* `Area` contains a value for the `Area` label
* `Title` contains the GitHub issue title
* `Description` contains the GitHub issue description

`IssuePrediction` is the class used for prediction after the model has been trained. It has a single `string` (`Area`) and a `PredictedLabel` `ColumnName` attribute. The `Label` is used to create and train the model, and it's also used with a second dataset to evaluate the model. The `PredictedLabel` is used during prediction and evaluation. For evaluation, an input with training data, the predicted values, and the model are used.

When building a model with ML.NET, you start by creating an <xref:Microsoft.ML.MLContext>. This is comparable conceptually to using `DbContext` in Entity Framework. The environment provides a context for your ML job that can be used for exception tracking and logging.

### Initialize variables in Main

Initialize the `_mlContext` global variable  with a new instance of `MLContext` with a random seed (`seed: 0`) for repeatable/deterministic results across multiple trainings.  Replace the `Console.WriteLine("Hello World!")` line with the following code in the `Main` method:

[!code-csharp[CreateMLContext](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#CreateMLContext)]

## Load the data

Next, initialize the `_trainingDataView` <xref:Microsoft.ML.Data.IDataView> global variable and load the data with the `_trainDataPath` parameter.

 As the input and output of `Transforms`, a `DataView` is the fundamental data pipeline type, comparable to `IEnumerable` for `LINQ`.

In ML.NET, data is similar to a `SQL view`. It is lazily evaluated, schematized, and heterogenous. The object is the first part of the pipeline, and loads the data. For this tutorial, it loads a dataset with issue titles, descriptions, and corresponding area GitHub label. The `DataView` is used to create and train the model.

Since your previously created `GitHubIssue` data model type matches the dataset schema, you can combine the initialization, mapping, and dataset loading into one line of code.

The first part of the line (`CreateTextReader<GitHubIssue>(hasHeader: true)`) creates a <xref:Microsoft.ML.Data.TextLoader> by inferencing the dataset schema from the `GitHubIssue` data model type and using the dataset header.

You defined the data schema previously when you created the `GitHubIssue` class. For your schema:

* the first column `ID` (GitHub Issue ID)
* the second column `Area` (the prediction for training)
* the third column `Title` (GitHub issue title) is the first [feature](../resources/glossary.md##feature)  used for predicting the `Area`
* the fourth column  `Description` is the second feature used for predicting the `Area`

The second part of the line  (`.Read(_trainDataPath)`) uses <xref:Microsoft.ML.Data.TextLoader.Read%2A> method to load the training text file using `_trainDataPath` into the `IDataView` (`_trainingDataView`) global variable.  

To initialize and load the `_trainingDataView` global variable in order to use it for the pipeline, add the following code after the  `mlContext` initialization:

[!code-csharp[LoadTrainData](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#LoadTrainData)]


Add the following as the next line of code in the `Main` method:

[!code-csharp[CallProcessData](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#CallProcessData)]

The `ProcessData` method executes the following tasks:

* Extracts and transforms the data.
* Returns the processing pipeline.

Create the `ProcessData` method, just after the `Main` method, using the following code:

```csharp
public static EstimatorChain<ITransformer> ProcessData()
{

}
```

## Extract and transform the data

Pre-processing and cleaning data are important tasks that occur before a dataset is used effectively for machine learning. Raw data is often noisy and unreliable, and may be missing values. Using data without these modeling tasks can produce misleading results.

ML.NET's transform pipelines compose a custom set of transforms that are applied to your data before training or testing. The transforms' primary purpose is data [featurization](../resources/glossary.md#feature-engineering). Machine learning algorithms understand [featurized](../resources/glossary.md#feature) data, so the next step is to transform our textual data into a format that our ML algorithms recognize. That format is a [numeric vector](../resources/glossary.md#numerical-feature-vector).

In the next steps, we refer to the columns by the names defined in the `GitHubIssue` class.

When the model is trained and evaluated, by default, the values in the **Label** column are considered as correct values to be predicted. As we want to predict the Area GitHub label for a `GitHubIssue`, copy the `Area` column into the **Label** column. To do that, use the `MLContext.Transforms.Conversion.MapValueToKey`, which is a wrapper for the <xref:Microsoft.ML.ConversionsExtensionsCatalog.MapValueToKey%2A> transformation class.  The `MapValueToKey` returns an <xref:Microsoft.ML.Data.EstimatorChain%601> that will effectively be a pipeline. Name this `pipeline` as you will then append the trainer to the `EstimatorChain`. Add this as the next line of code:

[!code-csharp[MapValueToKey](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#MapValueToKey)]

The algorithm that trains the model requires **numeric** features, so you have Next, call `mlContext.Transforms.Text.FeaturizeText` which featurizes the text (`Title` and `Description`) columns into a numeric vector for each called `TitleFeaturized` and `DescriptionFeaturized`. Featurizing assigns different numeric key values to the different values in each of the columns and is used by the machine learning algorithm.
Append the featurization for both columns to the pipeline with the following code:

[!code-csharp[FeaturizeText](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#FeaturizeText)]

The last step in data preparation combines all of the feature columns into the **Features** column using the `Concatenate` transformation class. By default, a learning algorithm processes only features from the **Features** column. Append this transformation to the pipeline with the following code:

[!code-csharp[Concatenate](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#Concatenate)]

 Next, append a <xref:Microsoft.ML.Data.EstimatorChain`1.AppendCacheCheckpoint%2A> to cache the DataView so when you iterate over the data multiple times using the cache might get better performance, as with the following code

[!code-csharp[AppendCache](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#AppendCache)]

Return the pipeline at the end of the `ProcessData` method.

[!code-csharp[ReturnPipeline](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#ReturnPipeline)]

This step handles preprocessing/featurization. Using additional components available in ML.NET can enable better results with your model.

## Build and train the model

Add the following call to the `BuildAndTrainModel`method as the next line of code in the `Main` method:

[!code-csharp[CallBuildAndTrainModel](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#CallBuildAndTrainModel)]

The `BuildAndTrainModel` method executes the following tasks:

* Creates the training algorithm class.
* Trains the model.
* Predicts area based on training data.
* Saves the model to a `.zip` file.
* Returns the model.

Create the `BuildAndTrainModel` method, just after the `Main` method, using the following code:

```csharp
public static void BuildAndTrainModel()
{

}
```

Notice that two parameters are passed into the BuildAndTrainModel method; an `IDataView` for the training dataset (`trainingDataView`), and a <xref:Microsoft.ML.Data.EstimatorChain%601> for the processing pipeline created in ProcessData (`pipeline`).

 Add the following code as the first line of the `BuildAndTrainModel` method:

### Choose a trainer algorithm

To add the trainer algorithm, call the `mlContext.Transforms.Text.FeaturizeText` wrapper method which returns a <xref:Microsoft.ML.Trainers.SdcaMultiClassTrainer> object. This is a decision tree learner you'll use in this pipeline. The `SdcaMultiClassTrainer` is appended to the `pipeline` and accepts the featurized `Title` and `Description` (`Features`) and the `Label` input parameters to learn from the historic data.

Add the following code to the `BuildAndTrainModel` method:

[!code-csharp[SdcaMultiClassTrainer](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#SdcaMultiClassTrainer)]

Now that you've created a trainer algorithm, append it to the `pipeline`. You also need to map the label to the value to return to its original readable state. Do both of those actions with the following code:

[!code-csharp[AddTrainer](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#AddTrainer)]

### Train the model

You train the model, <xref:Microsoft.ML.Data.TransformerChain%601>, based on the dataset that has been loaded and transformed. Once the estimator has been defined, you train your model using the <xref:Microsoft.ML.Data.EstimatorChain%601.Fit%2A> while providing the already loaded training data. This returns a model to use for predictions. `trainingPipeline.Fit()` trains the pipeline and returns a `Transformer` based on the `DataView` passed in. The experiment is not executed until this happens.

Add the following code to the `BuildAndTrainModel` method:

[!code-csharp[TrainModel](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#TrainModel)]

While the `model` is a `transformer` that operates on many rows of data, a very common production scenario is a need for predictions on individual examples. The <xref:Microsoft.ML.PredictionEngine%602> is a wrapper that is returned from the `CreatePredictionEngine` method. Let's add the following code to create the `PredictionEngine` as the next line in the `BuildAndTrainModel` Method:

[!code-csharp[CreatePredictionEngine](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#CreatePredictionEngine)]

Add a GitHub issue to test the trained model's prediction in the `Predict` method by creating an instance of `GitHubIssue`:

[!code-csharp[CreateTestIssue1](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#CreateTestIssue1)]

You can use that to predict the `Area` label of a single instance of the issue data. To get a prediction, use <xref:Microsoft.ML.PredictionEngine%602.Predict%2A> on the data. Note that the input data is a string and the model includes the featurization. Your pipeline is in sync during training and prediction. You didn’t have to write preprocessing/featurization code specifically for predictions, and the same API takes care of both batch and one-time predictions.

[!code-csharp[Predict](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#Predict)]

### Model operationalization: prediction

Display `GitHubIssue` and corresponding `Area` label prediction in order to share the results and act on them accordingly. This is called operationalization, using the returned data as part of the operational policies. Create a display for the results using the following <xref:System.Console.WriteLine?displayProperty=nameWithType> code:

[!code-csharp[OutputPrediction](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#OutputPrediction)]

### Save and return the model trained to use for evaluation

At this point, you have a model of type <xref:Microsoft.ML.Data.TransformerChain%601> that can be integrated into any of your existing or new .NET applications. To save your trained model to a .zip file, add the following code to call the `SaveModelAsFile` method as the next line in `BuildAndTrainModel`:

[!code-csharp[CallSaveModel](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#CallSaveModel)]

Return the model at the end of the `BuildAndTrainModel` method.

[!code-csharp[ReturnModel](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#ReturnModel)]

## Save the model as a.zip file

Create the `SaveModelAsFile` method, just after the `BuildAndTrainModel` method, using the following code:

```csharp
private static void SaveModelAsFile(MLContext mlContext, ITransformer model)
{

}
```

The `SaveModelAsFile` method executes the following tasks:

* Saves the model as a .zip file.

Next, create a method to save the model so that it can be reused and consumed in other applications. The `ITransformer` has a <xref:Microsoft.ML.Data.TransformerChain%601.SaveTo(Microsoft.ML.IHostEnvironment,System.IO.Stream)> method that takes in the `_modelPath` global field, and a <xref:System.IO.Stream>. To save this as a zip file, you'll create the `FileStream` immediately before calling the `SaveTo` method. Add the following code to the `SaveModelAsFile` method as the next line:

[!code-csharp[SaveModel](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#SaveModel)]

You could also display where the file was written by writing a console message with the `_modelPath`, using the following code:

```csharp
Console.WriteLine("The model is saved to {0}", _modelPath);
```

## Evaluate the model

Now that you've created and trained the model, you need to evaluate it with a different dataset for quality assurance and validation. In the `Evaluate` method, the model created in `BuildAndTrainModel` is passed in to be evaluated. Create the `Evaluate` method, just after `BuildAndTrainModel`, as in the following code:

```csharp
public static void Evaluate()
{

}
```

The `Evaluate` method executes the following tasks:

* Loads the test dataset.
* Creates the multiclass evaluator.
* Evaluates the model and create metrics.
* Displays the metrics.

Add a call to the new method from the `Main` method, right under the `BuildAndTrainModel` method call, using the following code:

[!code-csharp[CallEvaluate](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#CallEvaluate)]

As you did previously with the training dataset, you can combine the initialization, mapping, and test dataset loading into one line of code. You can evaluate the model using this dataset as a quality check. Add the following code to the `Evaluate` method:

[!code-csharp[LoadTestDataset](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#LoadTestDataset)]

The `MulticlassClassificationContext.Evaluate` is a wrapper for the <xref:Microsoft.ML.MulticlassClassificationContext.Evaluate%2A> method that computes the quality metrics for the model using the specified dataset. It returns a <xref:Microsoft.ML.Data.MultiClassClassifierMetrics> object that contains the overall metrics computed by multiclass classification evaluators.
To display these to determine the quality of the model, you need to get the metrics first.
Notice the use of the `Transform` method of the machine learning `_trainedModel` global variable (a transformer) to input the features and return predictions. Add the following code to the `Evaluate` method as the next line:

[!code-csharp[Evaluate](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#Evaluate)]

The following metrics are evaluated for multiclass classification:

* Micro Accuracy - Every sample-class pair contributes equally to the accuracy metric.  You want Micro Accuracy to be as close to 1 as possible.

* Macro Accuracy - Every class contributes equally to the accuracy metric. Minority classes are given equal weight as the larger classes. You want Macro Accuracy to be as close to 1 as possible.

* Log-loss - see [Log Loss](../resources/glossary.md#log-loss). You want Log-loss to be as close to zero as possible.

* Log-loss reduction - Ranges from [-inf, 100], where 100 is perfect predictions and 0 indicates mean predictions. You want Log-loss reduction to be as close to zero as possible.

### Displaying the metrics for model validation

Use the following code to display the metrics, share the results, and then act on them:

[!code-csharp[DisplayMetrics](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#DisplayMetrics)]

## Predict the test data outcome with the saved model

Add a call to the new method from the `Main` method, right under the `Evaluate` method call, using the following code:

[!code-csharp[CallPredictIssue](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#CallPredictIssue)]

Create the `PredictIssue` method, just after the `Evaluate` method, using the following code:

```csharp
private static void PredictIssue()
{

}
```

The `PredictIssue` method executes the following tasks:

* Creates a single issue of test data.
* Predicts Area based on test data.
* Combines test data and predictions for reporting.
* Displays the predicted results.

First, load the model that you saved previously with the following code:

[!code-csharp[LoadModel](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#LoadModel)]

Add a GitHub issue to test the trained model's prediction in the `Predict` method by creating an instance of `GitHubIssue`:

[!code-csharp[AddTestIssue](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#AddTestIssue)]

[!code-csharp[CreatePredictionEngine](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#CreatePredictionEngine)]
  
Now that you have a model, you can use that to predict the Area GitHub label of a single instance of the GitHub issue data. To get a prediction, use <xref:Microsoft.ML.PredictionEngine%602.Predict%2A> on the data. Note that the input data is a string and the model includes the featurization. Your pipeline is in sync during training and prediction. You didn’t have to write preprocessing/featurization code specifically for predictions, and the same API takes care of both batch and one-time predictions. Add the following code to the `PredictIssue` method for the predictions:

[!code-csharp[PredictIssue](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#CreatePredictionEngine)]

### Model operationalization: prediction

Display `Area` in order to categorize the issue and act on it accordingly. This is called operationalization, using the returned data as part of the operational policies. Create a display for the results using the following <xref:System.Console.WriteLine?displayProperty=nameWithType> code:

[!code-csharp[DisplayResults](../../../samples/machine-learning/tutorials/GitHubIssueClassification/Program.cs#DisplayResults)]

## Results

Your results should be similar to the following. As the pipeline processes, it displays messages. You may see warnings, or processing messages. These have been removed from the following results for clarity.

```console
=============== Single Prediction just-trained-model - Result: area-System.Net ===============
The model is saved to C:\Users\johalex\dotnet-samples\samples\machine-learning\tutorials\GitHubIssueClassification\bin\Debug\netcoreapp2.0\..\..\..\Models\model.zip
*************************************************************************************************************
*       Metrics for Multi-class Classification model - Test Data
*------------------------------------------------------------------------------------------------------------
*       MicroAccuracy:    0.74
*       MacroAccuracy:    0.687
*       LogLoss:          .932
*       LogLossReduction: 63.852
*************************************************************************************************************
=============== Single Prediction - Result: area-System.Data ===============
```

Congratulations! You've now successfully built a machine learning model for classifying and predicting an Area label for a GitHub issue. You can find the source code for this tutorial at the [dotnet/samples](https://github.com/dotnet/samples/tree/master/machine-learning/tutorials/GitHubIssueClassification) repository.

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

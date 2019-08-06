---
title: 'Tutorial: Analyze website comments - text classification with TensorFlow'
description: This tutorial shows you how to create a .NET Core console application that classifies sentiment from website comments using a pre-trained TensorFlow model and takes the appropriate action. The binary sentiment classifier uses C# in Visual Studio.
ms.date: 07/31/2019
ms.topic: tutorial
ms.custom: mvc
#Customer intent: As a developer, I want to use ML.NET to apply a binary classification task using a pre-trained TensorFlow model so that I can understand how to use sentiment prediction to take appropriate action.
---
# Tutorial: Analyze sentiment of website comments with binary classification using TensorFlow in ML.NET

This tutorial shows you how to create a .NET Core console application that classifies sentiment from website comments using a pre-trained TensorFlow model and takes the appropriate action. The binary sentiment classifier uses C# in Visual Studio.

In this tutorial, you learn how to:
> [!div class="checklist"]
> * Prepare data
> * Load the data
> * Reuse and tune the pre-trained model
> * Use the model to make a prediction
> * See the results

You can find the source code for this tutorial at the [dotnet/samples](https://github.com/dotnet/samples/tree/master/machine-learning/tutorials/TextClassificationTF) repository.

## Prerequisites

* [Visual Studio 2017 15.6 or later](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019) with the ".NET Core cross-platform development" workload installed.

* [The sentiment_analysis machine learning model Zip file](https://github.com/dotnet/machinelearning-testdata/blob/master/Microsoft.ML.TensorFlow.TestModels/sentiment_model)

## Create a console application

1. Create a **.NET Core Console Application** called "TextClassificationTF".

2. Create a directory named *Data* in your project to save your data set files.

3. Install the **Microsoft.ML NuGet Package**:

    In Solution Explorer, right-click on your project and select **Manage NuGet Packages**. Choose "nuget.org" as the package source, and then select the **Browse** tab. Search for **Microsoft.ML**, select the package you want, and then select the **Install** button. Proceed with the installation by agreeing to the the license terms for the package you choose. Repeat these steps for **Microsoft.ML.TensorFlow**.

> [!NOTE]
> The model for this tutorial is from the [dotnet/machinelearning-testdata](https://github.com/dotnet/machinelearning-testdata/tree/master/Microsoft.ML.TensorFlow.TestModels/sentiment_model) GitHub repo. The model is in 'SavedModel' format. For further explanation on the `sentiment_model`, see [](https://github.com/dotnet/machinelearning-testdata/blob/master/Microsoft.ML.TensorFlow.TestModels/sentiment_model/README.md)

### Prepare your data

1. Download the [sentiment_model zip file](), and unzip.

2. Copy the contents of the innermost `sentiment_model` directory just unzipped into your *TextClassificationTF* project `sentiment_model` directory. This directory contains the model and additional support files needed for this tutorial, as shown in the following image:

   ![sentiment_model directory contents](./media/text-classification-tf/sentiment-model-files.png)

3. In Solution Explorer, right-click each of the files in the `sentiment_model` directory and subdirectory and select **Properties**. Under **Advanced**, change the value of **Copy to Output Directory** to **Copy if newer**.

### Create classes and define paths

   [!code-csharp[LoadData](~/samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#LoadData "loading dataset")]

1. Add the following additional `using` statements to the top of the *Program.cs* file:

   [!code-csharp[AddUsings](../../../samples/machine-learning/tutorials/TextClassificationTF/Program.cs#AddUsings "Add necessary usings")]

2. Create two global fields to hold the recently downloaded dataset file path and the saved model file path:

    * `MaxSentenceLength` has the length of the fixed vector.
    * `_modelPath` has the path where the trained model is saved.

3. Add the following code to the line right above the `Main` method to specify the maximum length:

   [!code-csharp[DeclareGlobalVariables](../../../samples/machine-learning/tutorials/TextClassificationTF/Program.cs#DeclareGlobalVariables "Declare global variables")]

4. Next, create classes for your input data and predictions. Add a new class to your project:

    * In **Solution Explorer**, right-click the project, and then select **Add** > **New Item**.

    * In the **Add New Item** dialog box, select **Class** and change the **Name** field to *IMDBData.cs*. Then, select the **Add** button.

5. The *IMDBData.cs* file opens in the code editor. Add the following `using` statement to the top of *IMDBData.cs*:

   [!code-csharp[AddUsings](../../../samples/machine-learning/tutorials/TextClassificationTF/IMDBData.cs#AddUsings "Add necessary usings")]

6. Remove the existing class definition and add the following code, which has two classes `IMDBSentiment` and `IMDBPrediction`, to the *IMDBData.cs* file:

   [!code-csharp[DeclareTypes](../../../samples/machine-learning/tutorials/TextClassificationTF/IMDBData.cs#DeclareTypes "Declare data record types")]

### How the data was prepared

The input dataset class, `IMDBSentiment`, has a `string` for user comments (`SentimentText`) and an `integer` array (`VariableLengthFeatures`)  In addition, the `VariableLengthFeatures` property has a [VectorType](xref:Microsoft.ML.Data.VectorTypeAttribute.%23ctor%2A) attribute to designate the vector type.  All of the vector elements must be the same type. In data sets with a large number of columns, loading multiple columns as a single vector reduces the number of data passes when you apply data transformations.

`IMDBPrediction` is the prediction class used after the model training. `IMDBPrediction` has a single `float` array (`Prediction`) and a `VectorType` attribute.

### Adding context

The [MLContext class](xref:Microsoft.ML.MLContext) is a starting point for all ML.NET operations. Initializing `mlContext` creates a new ML.NET environment that can be shared across the model creation workflow objects. It's similar, conceptually, to `DBContext` in Entity Framework.

1. Replace the `Console.WriteLine("Hello World!")` line in the `Main` method with the following code to declare and initialize the mlContext variable:

   [!code-csharp[CreateMLContext](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#CreateMLContext "Create the ML Context")]

1. Add the following as the next line of code in the `Main()` method:

   [!code-csharp[CallReuseAndTuneSentimentModel](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#CallReuseAndTuneSentimentModel)]

### Create an intermediate features class

1. Create a utility class called `IntermediateFeatures` to hold intermediate data that will be used by the CustomMapping Estimator in a later step. Add this after the `Main()` method:

[!code-csharp[DeclareIntermediateFeatures](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#DeclareIntermediateFeatures)]

## Reuse and tune pre-trained model

1. Create the `ReuseAndTuneSentimentModel()` method, just before the `IntermediateFeatures` utility class, using the following code:

    ```csharp
    public static ITransformer ReuseAndTuneSentimentModel(MLContext mlContext)
    {

    }
    ```

    The `ReuseAndTuneSentimentModel()` method executes the following tasks:

    * Loads the data
    * Extracts and transforms the data.
    * Scores the TensorFlow model.
    * Tunes (retrains) the model.
    * Returns the model.

1. Create an instance of `IMDBSentiment` called `trainData` and pass it to the `Prediction Engine` by adding the following as the next lines of code in the `ReuseAndTuneSentimentModel()` method:

[!code-csharp[CreateTrainData](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#CreateTrainData)]

### Load the data

Data in ML.NET is represented as an [IDataView class](xref:Microsoft.ML.IDataView). `IDataView` is a flexible, efficient way of describing tabular data (numeric and text). Data can be loaded from a text file or in real time (for example, SQL database or log files) to an `IDataView` object.

1. Load the in-memory collection into an [`IDataView`](xref:Microsoft.ML.IDataView) with the [`LoadFromEnumerable`](xref:Microsoft.ML.DataOperationsCatalog.LoadFromEnumerable%2A) method:

[!code-csharp[LoadTrainData](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#LoadTrainData)]

### Extract and transform the data

1. Create a dictionary to convert words into the integer indexes using the [`LoadFromTextFile`](xref:Microsoft.ML.TextLoaderSaverCatalog.LoadFromTextFile%2A) method to load data from a file, as seen in the following table:

|Word     |Index    |
|---------|---------|
|kids     |  362    |
|want     |  181    |
|wrong    |  355    |
|effects  |  302    |
|feeling  |  547    |

This code will function as a lookup map to assist with mapping text to integer vectors in later steps so add it next to the `ReuseAndTuneSentimentModel` method:

[!code-csharp[CreateLookupMap](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#CreateLookupMap)]

1. Append the `TensorFlowTransform` to the `pipeline` with the following line of code:

[!code-csharp[LoadTensorFlowModel](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#LoadTensorFlowModel)]

   The `LoadTensorFlowModel` is a convenience method that allows the `TensorFlow` model to be loaded once and then creates the `TensorFlowEstimator` using `ScoreTensorFlowModel`. `Prediction` returns a probability for sentiment of a given text, and all of those probabilities must add up to 1.

GetModelSchema gets the DataViewSchema for the complete model. the DataViewSchema object includes every node in the TensorFlow model . In this tutorial, you use it to explore the TensorFlow model schema with the following lines:

[!code-csharp[GetModelSchema](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#GetModelSchema)]

The schema is output to the console:

```console
=============== TensorFlow Model Schema ===============
Name: Features, Type: System.Int32, Shape: (-1, 600)
Name: Prediction/Softmax, Type: System.Int32, Shape: (-1, 600)
```

Machine learning algorithms understand [featurized](../resources/glossary.md#feature) data, and when dealing with deep neural networks you must adapt the images to the format expected by the network. That format is a [numeric vector](../resources/glossary.md#numerical-feature-vector).

Add an `Action` to resize the features as input to a `CustomMapping` transform with the next lines of code:

[!code-csharp[ResizeFeatures](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#ResizeFeatures)]

   The [ResizeFeaturesAction](xref:System.Action%602) delegate resizes the integer vector to a fixed length vector for required model inputs. This will be used later by the CustomMapping transform.

[!code-csharp[TokenizeIntoWords](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#TokenizeIntoWords)]

   The [TokenizeIntoWords](xref:Microsoft.ML.TextCatalog.TokenizeIntoWords%2A) transform uses spaces to parse the text/string into words. It creates a new column and splits each input string to a vector of substrings based on the user defined separator. Space is also a default value for the 'separators' argument if it is not specified.

[!code-csharp[MapValue](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#MapValue)]

   The [MapValue](Microsoft.ML.ConversionsExtensionsCatalog.MapValue%2A) transform maps each word to an integer which is an index in the dictionary `lookupMap` that you previously created.

Add a `CustomMappingEstimator` to transform the data as the model expects the input feature vector to be a fixed length vector.

[!code-csharp[CustomMapping](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#CustomMapping)]

The `ScoreTensorFlowModel` extracts specified outputs (the `sentiment_analysis model`'s sentiment prediction features (`Prediction`)), and scores a dataset using the pre-trained `TensorFlow` model:

[!code-csharp[ScoreTensorFlowModel](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#ScoreTensorFlowModel)]

The [CopyColumns](xref:Microsoft.ML.TransformExtensionsCatalog.CopyColumns%2A) transform retrieves the `Prediction` from TensorFlow and copies to the `Features` column.

[!code-csharp[CopyColumns](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#CopyColumns)]

The `Fit()` method trains your model by transforming the dataset and applying the training. Fit the model to the training dataset and return the trained model by adding the following as the next line of code in the `ReuseAndTuneSentimentModel()` method:

[!code-csharp[TrainModel](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#TrainModel)]

Return the trained model by adding the following as the last line of code in the `ReuseAndTuneSentimentModel()` method:

[!code-csharp[ReturnModel](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#ReturnModel)]

## Use the model to make a prediction

```csharp
    public static void PredictSentiment(MLContext mlContext, ITransformer model)
    {

    }
```

Add the following code to create the `PredictionEngine` as the first line in the `PredictSentiment()` Method:

[!code-csharp[CreatePredictionEngine](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#CreatePredictionEngine)]

The [PredictionEngine](xref:Microsoft.ML.PredictionEngine%602) is a convenience API, which allows you to pass in and then perform a prediction on a single instance of data.

Add a comment to test the trained model's prediction in the `Predict()` method by creating an instance of `IMDBSentiment`:

[!code-csharp[CreateTestData](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#CreateTestData)]

Pass the test comment data to the `Prediction Engine` by adding the following as the next lines of code in the `PredictSentiment()` method:

[!code-csharp[Predict](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#Predict)]

The [Predict()](xref:Microsoft.ML.PredictionEngine%602.Predict%2A) function makes a prediction on a single row of data.

Display sentiment prediction and confidence using the following code:

[!code-csharp[DisplayPredictions](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#DisplayPredictions)]

## Results

Your results should be similar to the following. During processing, messages are displayed. You may see warnings, or processing messages. These have been removed from the following results for clarity.

```console
   Number of classes: 2
   Is sentiment/review positive ? Yes
   Prediction Confidence: 0.65
```

Congratulations! You've now successfully built a machine learning model for classifying and predicting messages sentiment by reusing a pre-trained `TensorFlow` model in ML.NET..

You can find the source code for this tutorial at the [dotnet/samples](https://github.com/dotnet/samples/tree/master/machine-learning/tutorials/TextClassificationTF) repository.


In this tutorial, you learned how to:
> [!div class="checklist"]
> * Prepare data
> * Load the data
> * Reuse and tune the pre-trained model
> * Use the model to make a prediction
> * See the results
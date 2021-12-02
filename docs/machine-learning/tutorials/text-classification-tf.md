---
title: 'Tutorial: Analyze review sentiment using a TensorFlow model'
description: This tutorial shows you how to use a pre-trained TensorFlow model to classify sentiment in website comments. The binary sentiment classifier is a C# console application developed using Visual Studio.
ms.date: 11/11/2021
ms.topic: tutorial
ms.custom: mvc
#Customer intent: As a developer, I want to use ML.NET to make inferences with a pre-trained TensorFlow model.
---
# Tutorial: Analyze sentiment of movie reviews using a pre-trained TensorFlow model in ML.NET

This tutorial shows you how to use a pre-trained TensorFlow model to classify sentiment in website comments. The binary sentiment classifier is a C# console application developed using Visual Studio.

The TensorFlow model used in this tutorial was trained using movie reviews from the IMDB database. Once you have finished developing the application, you will be able to supply movie review text and the application will tell you whether the review has positive or negative sentiment.

In this tutorial, you learn how to:
> [!div class="checklist"]
>
> * Load a pre-trained TensorFlow model
> * Transform website comment text into features suitable for the model
> * Use the model to make a prediction

You can find the source code for this tutorial at the [dotnet/samples](https://github.com/dotnet/samples/tree/main/machine-learning/tutorials/TextClassificationTF) repository.

## Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) with the ".NET Desktop Development" workload installed.

## Setup

### Create the application

1. Create a C# **Console Application** called "TextClassificationTF". Click the **Next** button.

2. Choose .NET 6 as the framework to use. Click the **Create** button.

3. Create a directory named *Data* in your project to save your data set files.

4. Install the **Microsoft.ML NuGet Package**:

    [!INCLUDE [mlnet-current-nuget-version](../../../includes/mlnet-current-nuget-version.md)]

    In Solution Explorer, right-click on your project and select **Manage NuGet Packages**. Choose "nuget.org" as the package source, and then select the **Browse** tab. Search for **Microsoft.ML**, select the package you want, and then select the **Install** button. Proceed with the installation by agreeing to the license terms for the package you choose. Repeat these steps for **Microsoft.ML.TensorFlow**, **Microsoft.ML.SampleUtils** and **SciSharp.TensorFlow.Redist**.

### Add the TensorFlow model to the project

> [!NOTE]
> The model for this tutorial is from the [dotnet/machinelearning-testdata](https://github.com/dotnet/machinelearning-testdata/tree/main/Microsoft.ML.TensorFlow.TestModels/sentiment_model) GitHub repo. The model is in TensorFlow SavedModel format.

1. Download the [sentiment_model zip file](https://github.com/dotnet/samples/blob/main/machine-learning/models/textclassificationtf/sentiment_model.zip?raw=true), and unzip.

    The zip file contains:

    * `saved_model.pb`: the TensorFlow model itself. The model takes a fixed length (size 600) integer array of features representing the text in an IMDB review string, and outputs two probabilities which sum to 1: the probability that the input review has positive sentiment, and the probability that the input review has negative sentiment.
    * `imdb_word_index.csv`: a mapping from individual words to an integer value. The mapping is used to generate the input features for the TensorFlow model.

2. Copy the contents of the innermost `sentiment_model` directory into your *TextClassificationTF* project `sentiment_model` directory. This directory contains the model and additional support files needed for this tutorial, as shown in the following image:

   ![sentiment_model directory contents](./media/text-classification-tf/sentiment-model-files.png)

3. In Solution Explorer, right-click each of the files in the `sentiment_model` directory and subdirectory and select **Properties**. Under **Advanced**, change the value of **Copy to Output Directory** to **Copy if newer**.

### Add using statements and global variables

1. Add the following additional `using` statements to the top of the *Program.cs* file:

   [!code-csharp[AddUsings](./snippets/text-classification-tf/csharp/Program.cs#AddUsings "Add necessary usings")]

1. Create a global variable right after the using statements to hold the saved model file path.

   [!code-csharp[DeclareGlobalVariables](./snippets/text-classification-tf/csharp/Program.cs#DeclareGlobalVariables "Declare global variables")]

    * `_modelPath` is the file path of the trained model.

### Model the data

Movie reviews are free form text. Your application converts the text into the input format expected by the model in a number of discrete stages.

The first is to split the text into separate words and use the provided mapping file to map each word onto an integer encoding. The result of this transformation is a variable length integer array with a length corresponding to the number of words in the sentence.

|Property| Value|Type|
|-------------|-----------------------|------|
|ReviewText|this film is really good|string|
|VariableLengthFeatures|14,22,9,66,78,... |int[]|

The variable length feature array is then resized to a fixed length of 600. This is the length that the TensorFlow model expects.

|Property| Value|Type|
|-------------|-----------------------|------|
|ReviewText|this film is really good|string|
|VariableLengthFeatures|14,22,9,66,78,... |int[]|
|Features|14,22,9,66,78,... |int[600]|

1. Create a class for your input data at the bottom of the **Program.cs** file:

    [!code-csharp[MovieReviewClass](./snippets/text-classification-tf/csharp/Program.cs#MovieReviewClass "Declare movie review type")]

    The input data class, `MovieReview`, has a `string` for user comments (`ReviewText`).

1. Create a class for the variable length features after the `MovieReview` class:

    [!code-csharp[VariableLengthFeatures](./snippets/text-classification-tf/csharp/Program.cs#VariableLengthFeatures "Declare variable length features type")]

    The `VariableLengthFeatures` property has a [VectorType](xref:Microsoft.ML.Data.VectorTypeAttribute.%23ctor%2A) attribute to designate it as a vector.  All of the vector elements must be the same type. In data sets with a large number of columns, loading multiple columns as a single vector reduces the number of data passes when you apply data transformations.

    This class is used in the `ResizeFeatures` action. The names of its properties (in this case only one) are used to indicate which columns in the DataView can be used as the _input_ to the custom mapping action.

1. Create a class for the fixed length features, after the `VariableLength` class:

    [!code-csharp[FixedLengthFeatures](./snippets/text-classification-tf/csharp/Program.cs#FixedLengthFeatures)]

    This class is used in the `ResizeFeatures` action. The names of its properties (in this case only one) are used to indicate which columns in the DataView can be used as the _output_ of the custom mapping action.

    Note that the name of the property `Features` is determined by the TensorFlow model. You cannot change this property name.

1. Create a class for the prediction after the `FixedLength` class:

    [!code-csharp[Prediction](./snippets/text-classification-tf/csharp/Program.cs#Prediction "Declare prediction class")]

    `MovieReviewSentimentPrediction` is the prediction class used after the model training. `MovieReviewSentimentPrediction` has a single `float` array (`Prediction`) and a `VectorType` attribute.

1. Create another class to hold configuration values, such as the feature vector length:

    [!code-csharp[Config](./snippets/text-classification-tf/csharp/Program.cs#FeatureConfig "Declare config class")]

### Create the MLContext, lookup dictionary, and action to resize features

The [MLContext class](xref:Microsoft.ML.MLContext) is a starting point for all ML.NET operations. Initializing `mlContext` creates a new ML.NET environment that can be shared across the model creation workflow objects. It's similar, conceptually, to `DBContext` in Entity Framework.

1. Replace the `Console.WriteLine("Hello World!")` line with the following code to declare and initialize the mlContext variable:

   [!code-csharp[CreateMLContext](./snippets/text-classification-tf/csharp/Program.cs#CreateMLContext "Create the ML Context")]

1. Create a dictionary to encode words as integers by using the [`LoadFromTextFile`](xref:Microsoft.ML.TextLoaderSaverCatalog.LoadFromTextFile%2A) method to load mapping data from a file, as seen in the following table:

    |Word     |Index    |
    |---------|---------|
    |kids     |  362    |
    |want     |  181    |
    |wrong    |  355    |
    |effects  |  302    |
    |feeling  |  547    |

    Add the code below to create the lookup map:

    [!code-csharp[CreateLookupMap](./snippets/text-classification-tf/csharp/Program.cs#CreateLookupMap)]

1. Add an `Action` to resize the variable length word integer array to an integer array of fixed size, with the next lines of code:

   [!code-csharp[ResizeFeatures](./snippets/text-classification-tf/csharp/Program.cs#ResizeFeatures)]

## Load the pre-trained TensorFlow model

1. Add code to load the TensorFlow model:

    [!code-csharp[LoadTensorFlowModel](./snippets/text-classification-tf/csharp/Program.cs#LoadTensorFlowModel)]

    Once the model is loaded, you can extract its input and output schema. The schemas are displayed for interest and learning only. You do not need this code for the final application to function:

    [!code-csharp[GetModelSchema](./snippets/text-classification-tf/csharp/Program.cs#GetModelSchema)]

    The input schema is the fixed-length array of integer encoded words. The output schema is a float array of probabilities indicating whether a review's sentiment is negative, or positive . These values sum to 1, as the probability of being positive is the complement of the probability of the sentiment being negative.

## Create the ML.NET pipeline

1. Create the pipeline and split the input text into words using [TokenizeIntoWords](xref:Microsoft.ML.TextCatalog.TokenizeIntoWords%2A) transform to break the text into words as the next line of code:

   [!code-csharp[TokenizeIntoWords](./snippets/text-classification-tf/csharp/Program.cs#TokenizeIntoWords)]

   The [TokenizeIntoWords](xref:Microsoft.ML.TextCatalog.TokenizeIntoWords%2A) transform uses spaces to parse the text/string into words. It creates a new column and splits each input string to a vector of substrings based on the user-defined separator.

1. Map the words onto their integer encoding using the lookup table that you declared above:

    [!code-csharp[MapValue](./snippets/text-classification-tf/csharp/Program.cs#MapValue)]

1. Resize the variable length integer encodings to the fixed-length one required by the model:

    [!code-csharp[CustomMapping](./snippets/text-classification-tf/csharp/Program.cs#CustomMapping)]

1. Classify the input with the loaded TensorFlow model:

    [!code-csharp[ScoreTensorFlowModel](./snippets/text-classification-tf/csharp/Program.cs#ScoreTensorFlowModel)]

    The TensorFlow model output is called `Prediction/Softmax`. Note that the name `Prediction/Softmax` is determined by the TensorFlow model. You cannot change this name.

1. Create a new column for the output prediction:

    [!code-csharp[SnippetCopyColumns](./snippets/text-classification-tf/csharp/Program.cs#SnippetCopyColumns)]

    You need to copy the `Prediction/Softmax` column into one with a name that can be used as a property in a C# class: `Prediction`. The `/` character is not allowed in a C# property name.

## Create the ML.NET model from the pipeline

1. Add the code to create the model from the pipeline:

    [!code-csharp[SnippetCreateModel](./snippets/text-classification-tf/csharp/Program.cs#SnippetCreateModel)]

    An ML.NET model is created from the chain of estimators in the pipeline by calling the `Fit` method. In this case, we are not fitting any data to create the model, as the TensorFlow model has already been previously trained. We supply an empty data view object to satisfy the requirements of the `Fit` method.

## Use the model to make a prediction

1. Add the `PredictSentiment` method above the `MovieReview` class:

    ```csharp
    void PredictSentiment(MLContext mlContext, ITransformer model)
    {

    }
    ```

1. Add the following code to create the `PredictionEngine` as the first line in the `PredictSentiment()` method:

    [!code-csharp[CreatePredictionEngine](./snippets/text-classification-tf/csharp/Program.cs#CreatePredictionEngine)]

    The [PredictionEngine](xref:Microsoft.ML.PredictionEngine%602) is a convenience API, which allows you to perform a prediction on a single instance of data. [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) is not thread-safe. It's acceptable to use in single-threaded or prototype environments. For improved performance and thread safety in production environments, use the `PredictionEnginePool` service, which creates an [`ObjectPool`](xref:Microsoft.Extensions.ObjectPool.ObjectPool%601) of [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) objects for use throughout your application. See this guide on how to [use `PredictionEnginePool` in an ASP.NET Core Web API](../how-to-guides/serve-model-web-api-ml-net.md#register-predictionenginepool-for-use-in-the-application).

    > [!NOTE]
    > `PredictionEnginePool` service extension is currently in preview.

1. Add a comment to test the trained model's prediction in the `Predict()` method by creating an instance of `MovieReview`:

    [!code-csharp[CreateTestData](./snippets/text-classification-tf/csharp/Program.cs#CreateTestData)]

1. Pass the test comment data to the `Prediction Engine` by adding the next lines of code in the `PredictSentiment()` method:

    [!code-csharp[Predict](./snippets/text-classification-tf/csharp/Program.cs#Predict)]

1. The [Predict()](xref:Microsoft.ML.PredictionEngine%602.Predict%2A) function makes a prediction on a single row of data:

    |Property| Value|Type|
    |-------------|-----------------------|------|
    |Prediction|[0.5459937, 0.454006255]|float[]|

1. Display sentiment prediction using the following code:

    [!code-csharp[DisplayPredictions](./snippets/text-classification-tf/csharp/Program.cs#DisplayPredictions)]

1. Add a call to `PredictSentiment` after calling the `Fit()` method:

    [!code-csharp[CallPredictSentiment](./snippets/text-classification-tf/csharp/Program.cs#CallPredictSentiment)]

## Results

Build and run your application.

Your results should be similar to the following. During processing, messages are displayed. You may see warnings, or processing messages. These messages have been removed from the following results for clarity.

```console
Number of classes: 2
Is sentiment/review positive ? Yes
```

Congratulations! You've now successfully built a machine learning model for classifying and predicting messages sentiment by reusing a pre-trained `TensorFlow` model in ML.NET.

You can find the source code for this tutorial at the [dotnet/samples](https://github.com/dotnet/samples/tree/main/machine-learning/tutorials/TextClassificationTF) repository.

In this tutorial, you learned how to:
> [!div class="checklist"]
>
> * Load a pre-trained TensorFlow model
> * Transform website comment text into features suitable for the model
> * Use the model to make a prediction

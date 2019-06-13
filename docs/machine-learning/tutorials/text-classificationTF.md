---
title: 'Tutorial: Analyze website comments - text classification with TensorFlow'
description: This tutorial shows you how to create a .NET Core console application that classifies sentiment from website comments using a pre-trained TensorFlow model and takes the appropriate action. The binary sentiment classifier uses C# in Visual Studio.
ms.date: 05/30/2019
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

## Create a console application

1. Create a **.NET Core Console Application** called "TextClassificationTF".

2. Create a directory named *Data* in your project to save your data set files.

3. Install the **Microsoft.ML NuGet Package**:

    In Solution Explorer, right-click on your project and select **Manage NuGet Packages**. Choose "nuget.org" as the package source, and then select the **Browse** tab. Search for **Microsoft.ML**, select the package you want, and then select the **Install** button. Proceed with the installation by agreeing to the the license terms for the package you choose. Repeat these steps for **Microsoft.ML.TensorFlow v0.12.0**.

> [!NOTE]
> The datasets for this tutorial are from the 

### Create classes and define paths

1. Add the following additional `using` statements to the top of the *Program.cs* file:

    [!code-csharp[AddUsings](../../../samples/machine-learning/tutorials/TextClassificationTF/Program.cs#AddUsings "Add necessary usings")]

2. Create two global fields to hold the recently downloaded dataset file path and the saved model file path:

    * `MaxSentenceLength` has the length of the fixed vector.

3. Add the following code to the line right above the `Main` method to specify the maximum length:

    [!code-csharp[DeclareGlobalVariables](../../../samples/machine-learning/tutorials/TextClassificationTF/Program.cs#DeclareGlobalVariables "Declare global variables")]

4. Next, create classes for your input data and predictions. Add a new class to your project:

    - In **Solution Explorer**, right-click the project, and then select **Add** > **New Item**.

    - In the **Add New Item** dialog box, select **Class** and change the **Name** field to *IMDBData.cs*. Then, select the **Add** button.

5. The *IMDBData.cs* file opens in the code editor. Add the following `using` statement to the top of *IMDBData.cs*:

    [!code-csharp[AddUsings](../../../samples/machine-learning/tutorials/TextClassificationTF/IMDBData.cs#AddUsings "Add necessary usings")]

6. Remove the existing class definition and add the following code, which has two classes `IMDBSentiment` and `IMDBPrediction`, to the *IMDBData.cs* file:

    [!code-csharp[DeclareTypes](../../../samples/machine-learning/tutorials/TextClassificationTF/IMDBData.cs#DeclareTypes "Declare data record types")]

### How the data was prepared

The input dataset class, `IMDBSentiment`, has a `string` for user comments (`SentimentText`) and an `integer` array (`VariableLengthFeatures`)  In addition, the `VariableLengthFeatures` property has a [VectorType](xref:Microsoft.ML.Data.VectorTypeAttribute.%23ctor%2A) attribute to designate the vector type.

`IMDBPrediction` is the prediction class used after the model training. `SentimentPrediction` has a single `float` array (`Prediction`) and a `VectorType` attribute.

The [MLContext class](xref:Microsoft.ML.MLContext) is a starting point for all ML.NET operations. Initializing `mlContext` creates a new ML.NET environment that can be shared across the model creation workflow objects. It's similar, conceptually, to `DBContext` in Entity Framework.

## Load the data

Data in ML.NET is represented as an [IDataView class](xref:Microsoft.ML.IDataView). `IDataView` is a flexible, efficient way of describing tabular data (numeric and text). Data can be loaded from a text file or in real time (for example, SQL database or log files) to an `IDataView` object.

You prepare the application, and then load data:

1. Replace the `Console.WriteLine("Hello World!")` line in the `Main` method with the following code to declare and initialize the mlContext variable:

    [!code-csharp[CreateMLContext](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#CreateMLContext "Create the ML Context")]

2. Add the following as the next line of code in the `Main()` method:

    [!code-csharp[CallReuseAndTuneSentimentModel](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#CallReuseAndTuneSentimentModel)]

3. Create the `ReuseAndTuneSentimentModel()` method, just after the `Main()` method, using the following code:

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

    [!code-csharp[DownloadModel](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#DownloadModel)]

    [!code-csharp[CreateTrainData](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#CreateTrainData)]

    [!code-csharp[LoadTrainData](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#LoadTrainData)]

    [!code-csharp[CreateLookupMap](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#CreateLookupMap)]

    [!code-csharp[LoadTensorFlowModel](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#LoadTensorFlowModel)]

    [!code-csharp[GetModelSchema](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#GetModelSchema)]

    [!code-csharp[ResizeFeatures](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#ResizeFeatures)]

    [!code-csharp[TokenizeIntoWords](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#TokenizeIntoWords)]

    [!code-csharp[MapValue](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#MapValue)]

    [!code-csharp[CustomMapping](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#CustomMapping)]

    [!code-csharp[ScoreTensorFlowModel](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#ScoreTensorFlowModel)]

    [!code-csharp[CopyColumns](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#CopyColumns)]

    [!code-csharp[TrainModel](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#TrainModel)]

    [!code-csharp[ReturnModel](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#ReturnModel)]

```csharp
    public static string DownloadTensorFlowSentimentModel()
    {

    }
```

    [!code-csharp[DeclareDownloadPath](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#DeclareDownloadPath)]

    [!code-csharp[CheckModelDir](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#CheckModelDir)]

    [!code-csharp[CheckVariableDir](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#CheckVariableDir)]

    [!code-csharp[DownloadModel](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#DownloadModel)]

    [!code-csharp[ReturnModelPath](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#ReturnModelPath)]

```csharp
    private static string Download(string baseGitPath, string dataFile)
    {

    }
```

    [!code-csharp[DownloadDataFile](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#DownloadDataFile)]

```csharp
    public static void PredictSentiment(MLContext mlContext, ITransformer model)
    {

    }
```

    [!code-csharp[CreatePredictionEngine](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#CreatePredictionEngine)]

    [!code-csharp[CreateTestData](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#CreateTestData)]

    [!code-csharp[Predict](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#Predict)]

    [!code-csharp[DisplayPredictions](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#DisplayPredictions)]

    [!code-csharp[DeclareIntermediateFeatures](~/samples/machine-learning/tutorials/TextClassificationTF/Program.cs#DeclareIntermediateFeatures)]

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
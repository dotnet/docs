---
title: 'Tutorial: Analyze website comments - binary classification'
description: This tutorial shows you how to create a .NET Core console application that classifies sentiment from website comments and takes the appropriate action. The binary sentiment classifier uses C# in Visual Studio.
ms.date: 11/04/2021
ms.topic: tutorial
ms.custom: mvc
recommendations: false
#Customer intent: As a developer, I want to use ML.NET to apply a binary classification task so that I can understand how to use sentiment prediction to take appropriate action.
---
# Tutorial: Analyze sentiment of website comments with binary classification in ML.NET

This tutorial shows you how to create a .NET Core console application that classifies sentiment from website comments and takes the appropriate action. The binary sentiment classifier uses C# in Visual Studio 2022.

In this tutorial, you learn how to:
> [!div class="checklist"]
>
> - Create a console application
> - Prepare data
> - Load the data
> - Build and train the model
> - Evaluate the model
> - Use the model to make a prediction
> - See the results

You can find the source code for this tutorial at the [dotnet/samples](https://github.com/dotnet/samples/tree/main/machine-learning/tutorials/SentimentAnalysis) repository.

## Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/).

- [UCI Sentiment Labeled Sentences dataset](https://archive.ics.uci.edu/ml/machine-learning-databases/00331/sentiment%20labelled%20sentences.zip) (ZIP file)

## Create a console application

1. Create a C# **Console Application** called "SentimentAnalysis". Click the **Next** button.

2. Choose .NET 6 as the framework to use. Click the **Create** button.

3. Create a directory named *Data* in your project to save your data set files.

4. Install the **Microsoft.ML NuGet Package**:

    [!INCLUDE [mlnet-current-nuget-version](../../../includes/mlnet-current-nuget-version.md)]

    In Solution Explorer, right-click on your project and select **Manage NuGet Packages**. Choose "nuget.org" as the package source, and then select the **Browse** tab. Search for **Microsoft.ML**, select the package you want, and then select the **Install** button. Proceed with the installation by agreeing to the license terms for the package you choose.

## Prepare your data

> [!NOTE]
> The datasets for this tutorial are from the 'From Group to Individual Labels using Deep Features', Kotzias et. al,. KDD 2015, and hosted at the UCI Machine Learning Repository - Dua, D. and Karra Taniskidou, E. (2017). UCI Machine Learning Repository [http://archive.ics.uci.edu/ml]. Irvine, CA: University of California, School of Information and Computer Science.

1. Download [UCI Sentiment Labeled Sentences dataset ZIP file](https://archive.ics.uci.edu/ml/machine-learning-databases/00331/sentiment%20labelled%20sentences.zip), and unzip.

2. Copy the `yelp_labelled.txt` file into the *Data* directory you created.

3. In Solution Explorer, right-click the `yelp_labeled.txt` file and select **Properties**. Under **Advanced**, change the value of **Copy to Output Directory** to **Copy if newer**.

### Create classes and define paths

1. Add the following additional `using` statements to the top of the *Program.cs* file:

   [!code-csharp[AddUsings](./snippets/sentiment-analysis/csharp/Program.cs#AddUsings "Add necessary usings")]

1. Add the following code to the line right below the `using` statements, to create a field to hold the recently downloaded dataset file path:

   [!code-csharp[Declare global variables](./snippets/sentiment-analysis/csharp/Program.cs#DeclareGlobalVariables "Declare global variables")]

1. Next, create classes for your input data and predictions. Add a new class to your project:

   - In **Solution Explorer**, right-click the project, and then select **Add** > **New Item**.

   - In the **Add New Item** dialog box, select **Class** and change the **Name** field to *SentimentData.cs*. Then, select the **Add** button.

1. The *SentimentData.cs* file opens in the code editor. Add the following `using` statement to the top of *SentimentData.cs*:

   [!code-csharp[AddUsings](./snippets/sentiment-analysis/csharp/SentimentData.cs#AddUsings "Add necessary usings")]

1. Remove the existing class definition and add the following code, which has two classes `SentimentData` and `SentimentPrediction`, to the *SentimentData.cs* file:

   [!code-csharp[DeclareTypes](./snippets/sentiment-analysis/csharp/SentimentData.cs#DeclareTypes "Declare data record types")]

### How the data was prepared

The input dataset class, `SentimentData`, has a `string` for user comments (`SentimentText`) and a `bool` (`Sentiment`) value of either 1 (positive) or 0 (negative) for sentiment. Both fields have [LoadColumn](xref:Microsoft.ML.Data.LoadColumnAttribute.%23ctor%28System.Int32%29) attributes attached to them, which describes the data file order of each field.  In addition, the `Sentiment` property has a [ColumnName](xref:Microsoft.ML.Data.ColumnNameAttribute.%23ctor%2A) attribute to designate it as the `Label` field. The following example file doesn't have a header row, and looks like this:

|SentimentText                         |Sentiment (Label) |
|--------------------------------------|----------|
|Waitress was a little slow in service.|    0     |
|Crust is not good.                    |    0     |
|Wow... Loved this place.              |    1     |
|Service was very prompt.              |    1     |

`SentimentPrediction` is the prediction class used after model training. It inherits from `SentimentData` so that the input `SentimentText` can be displayed along with the output prediction. The `Prediction` boolean is the value that the model predicts when supplied with new input `SentimentText`.

The output class `SentimentPrediction` contains two other properties calculated by the model: `Score` - the raw score calculated by the model, and `Probability` - the score calibrated to the likelihood of the text having positive sentiment.

For this tutorial, the most important property is `Prediction`.

## Load the data

Data in ML.NET is represented as an [IDataView interface](xref:Microsoft.ML.IDataView). `IDataView` is a flexible, efficient way of describing tabular data (numeric and text). Data can be loaded from a text file or in real time (for example, SQL database or log files) to an `IDataView` object.

The [MLContext class](xref:Microsoft.ML.MLContext) is a starting point for all ML.NET operations. Initializing `mlContext` creates a new ML.NET environment that can be shared across the model creation workflow objects. It's similar, conceptually, to `DBContext` in Entity Framework.

You prepare the app, and then load data:

1. Replace the `Console.WriteLine("Hello World!")` line with the following code to declare and initialize the mlContext variable:

    [!code-csharp[CreateMLContext](./snippets/sentiment-analysis/csharp/Program.cs#CreateMLContext "Create the ML Context")]

2. Add the following as the next line of code:

    [!code-csharp[CallLoadData](./snippets/sentiment-analysis/csharp/Program.cs#CallLoadData)]

3. Create a `LoadData()` method at the bottom of the `Program.cs` file using the following code:

    ```csharp
    TrainTestData LoadData(MLContext mlContext)
    {

    }
    ```

    The `LoadData()` method executes the following tasks:

    - Loads the data.
    - Splits the loaded dataset into train and test datasets.
    - Returns the split train and test datasets.

4. Add the following code as the first line of the `LoadData()` method:

    [!code-csharp[LoadData](./snippets/sentiment-analysis/csharp/Program.cs#LoadData "loading dataset")]

    The [LoadFromTextFile()](xref:Microsoft.ML.TextLoaderSaverCatalog.LoadFromTextFile%60%601%28Microsoft.ML.DataOperationsCatalog,System.String,System.Char,System.Boolean,System.Boolean,System.Boolean,System.Boolean%29) method defines the data schema and reads in the file. It takes in the data path variables and returns an `IDataView`.

### Split the dataset for model training and testing

When preparing a model, you use part of the dataset to train it and part of the dataset to test the model's accuracy.

1. To split the loaded data into the needed datasets, add the following code as the next line in the `LoadData()` method:

    [!code-csharp[SplitData](./snippets/sentiment-analysis/csharp/Program.cs#SplitData "Split the Data")]

    The previous code uses the [TrainTestSplit()](xref:Microsoft.ML.DataOperationsCatalog.TrainTestSplit%2A) method to split the loaded dataset into train and test datasets and return them in the <xref:Microsoft.ML.DataOperationsCatalog.TrainTestData> class. Specify the test set percentage of data with the `testFraction`parameter. The default is 10%, in this case you use 20% to evaluate more data.

2. Return the `splitDataView` at the end of the `LoadData()` method:

    [!code-csharp[ReturnSplitData](./snippets/sentiment-analysis/csharp/Program.cs#ReturnSplitData)]

## Build and train the model

1. Add the following call to the `BuildAndTrainModel`method below the call to the `LoadData` method:

    [!code-csharp[CallBuildAndTrainModel](./snippets/sentiment-analysis/csharp/Program.cs#CallBuildAndTrainModel)]

    The `BuildAndTrainModel()` method executes the following tasks:

    - Extracts and transforms the data.
    - Trains the model.
    - Predicts sentiment based on test data.
    - Returns the model.

2. Create the `BuildAndTrainModel()` method, below the `LoadData()` method, using the following code:

    ```csharp
    ITransformer BuildAndTrainModel(MLContext mlContext, IDataView splitTrainSet)
    {

    }
    ```

### Extract and transform the data

1. Call `FeaturizeText` as the next line of code:

    [!code-csharp[FeaturizeText](./snippets/sentiment-analysis/csharp/Program.cs#FeaturizeText "Featurize the text")]

    The `FeaturizeText()` method in the previous code converts the text column (`SentimentText`) into a numeric key type `Features` column used by the machine learning algorithm and adds it as a new dataset column:

    |SentimentText                         |Sentiment |Features              |
    |--------------------------------------|----------|----------------------|
    |Waitress was a little slow in service.|    0     |[0.76, 0.65, 0.44, …] |
    |Crust is not good.                    |    0     |[0.98, 0.43, 0.54, …] |
    |Wow... Loved this place.              |    1     |[0.35, 0.73, 0.46, …] |
    |Service was very prompt.              |    1     |[0.39, 0, 0.75, …]    |

### Add a learning algorithm

This app uses a classification algorithm that categorizes items or rows of data. The app categorizes website comments as either positive or negative, so use the binary classification task.

Append the machine learning task to the data transformation definitions by adding the following as the next line of code in `BuildAndTrainModel()`:

[!code-csharp[SdcaLogisticRegressionBinaryTrainer](./snippets/sentiment-analysis/csharp/Program.cs#AddTrainer "Add a SdcaLogisticRegressionBinaryTrainer")]

The [SdcaLogisticRegressionBinaryTrainer](xref:Microsoft.ML.Trainers.SdcaLogisticRegressionBinaryTrainer) is your classification training algorithm. This is appended to the `estimator` and accepts the featurized `SentimentText` (`Features`) and the `Label` input parameters to learn from the historic data.

### Train the model

Fit the model to the `splitTrainSet` data and return the trained model by adding the following as the next line of code in the `BuildAndTrainModel()` method:

[!code-csharp[TrainModel](./snippets/sentiment-analysis/csharp/Program.cs#TrainModel "Train the model")]

The [Fit()](xref:Microsoft.ML.Trainers.MatrixFactorizationTrainer.Fit%28Microsoft.ML.IDataView,Microsoft.ML.IDataView%29) method trains your model by transforming the dataset and applying the training.

### Return the model trained to use for evaluation

 Return the model at the end of the `BuildAndTrainModel()` method:

[!code-csharp[ReturnModel](./snippets/sentiment-analysis/csharp/Program.cs#ReturnModel "Return the model")]

## Evaluate the model

After your model is trained, use your test data to validate the model's performance.

1. Create the `Evaluate()` method, just after `BuildAndTrainModel()`, with the following code:

    ```csharp
    void Evaluate(MLContext mlContext, ITransformer model, IDataView splitTestSet)
    {

    }
    ```

    The `Evaluate()` method executes the following tasks:

    - Loads the test dataset.
    - Creates the BinaryClassification evaluator.
    - Evaluates the model and creates metrics.
    - Displays the metrics.

2. Add a call to the new method below the `BuildAndTrainModel` method call using the following code:

    [!code-csharp[CallEvaluate](./snippets/sentiment-analysis/csharp/Program.cs#CallEvaluate "Call the Evaluate method")]

3. Transform the `splitTestSet` data by adding the following code to `Evaluate()`:

    [!code-csharp[PredictWithTransformer](./snippets/sentiment-analysis/csharp/Program.cs#TransformData "Predict using the Transformer")]

    The previous code uses the [Transform()](xref:Microsoft.ML.ITransformer.Transform%2A) method to make predictions for multiple provided input rows of a test dataset.

4. Evaluate the model by adding the following as the next line of code in the `Evaluate()` method:

    [!code-csharp[ComputeMetrics](./snippets/sentiment-analysis/csharp/Program.cs#Evaluate "Compute Metrics")]

Once you have the prediction set (`predictions`), the [Evaluate()](xref:Microsoft.ML.BinaryClassificationCatalog.Evaluate%2A) method assesses the model, which compares the predicted values with the actual `Labels` in the test dataset and returns a [CalibratedBinaryClassificationMetrics](xref:Microsoft.ML.Data.CalibratedBinaryClassificationMetrics) object on how the model is performing.

### Displaying the metrics for model validation

Use the following code to display the metrics:

[!code-csharp[DisplayMetrics](./snippets/sentiment-analysis/csharp/Program.cs#DisplayMetrics "Display selected metrics")]

- The `Accuracy` metric gets the accuracy of a model, which is the proportion of correct predictions in the test set.

- The `AreaUnderRocCurve` metric indicates how confident the model is correctly classifying the positive and negative classes. You want the `AreaUnderRocCurve` to be as close to one as possible.

- The `F1Score` metric gets the model's F1 score, which is a measure of balance between [precision](../resources/glossary.md#precision) and [recall](../resources/glossary.md#recall).  You want the `F1Score` to be as close to one as possible.

### Predict the test data outcome

1. Create the `UseModelWithSingleItem()` method, just after the `Evaluate()` method, using the following code:

    ```csharp
    void UseModelWithSingleItem(MLContext mlContext, ITransformer model)
    {

    }
    ```

    The `UseModelWithSingleItem()` method executes the following tasks:

    - Creates a single comment of test data.
    - Predicts sentiment based on test data.
    - Combines test data and predictions for reporting.
    - Displays the predicted results.

2. Add a call to the new method right under the `Evaluate()` method call using the following code:

    [!code-csharp[CallUseModelWithSingleItem](./snippets/sentiment-analysis/csharp/Program.cs#CallUseModelWithSingleItem "Call the UseModelWithSingleItem method")]

3. Add the following code to create as the first line in the `UseModelWithSingleItem()` Method:

    [!code-csharp[CreatePredictionEngine](./snippets/sentiment-analysis/csharp/Program.cs#CreatePredictionEngine1 "Create the PredictionEngine")]

    The [PredictionEngine](xref:Microsoft.ML.PredictionEngine%602) is a convenience API, which allows you to perform a prediction on a single instance of data. [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) is not thread-safe. It's acceptable to use in single-threaded or prototype environments. For improved performance and thread safety in production environments, use the `PredictionEnginePool` service, which creates an [`ObjectPool`](xref:Microsoft.Extensions.ObjectPool.ObjectPool%601) of [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) objects for use throughout your application. See this guide on how to [use `PredictionEnginePool` in an ASP.NET Core Web API](../how-to-guides/serve-model-web-api-ml-net.md#register-predictionenginepool-for-use-in-the-application).

    > [!NOTE]
    > `PredictionEnginePool` service extension is currently in preview.

4. Add a comment to test the trained model's prediction in the `UseModelWithSingleItem()` method by creating an instance of `SentimentData`:

    [!code-csharp[PredictionData](./snippets/sentiment-analysis/csharp/Program.cs#CreateTestIssue1 "Create test data for single prediction")]

5. Pass the test comment data to the [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) by adding the following as the next lines of code in the `UseModelWithSingleItem()` method:

    [!code-csharp[Predict](./snippets/sentiment-analysis/csharp/Program.cs#Predict "Create a prediction of sentiment")]

    The [Predict()](xref:Microsoft.ML.PredictionEngine%602.Predict%2A) function makes a prediction on a single row of data.

6. Display `SentimentText` and corresponding sentiment prediction using the following code:

    [!code-csharp[OutputPrediction](./snippets/sentiment-analysis/csharp/Program.cs#OutputPrediction "Display prediction output")]

## Use the model for prediction

### Deploy and predict batch items

1. Create the `UseModelWithBatchItems()` method, just after the `UseModelWithSingleItem()` method, using the following code:

    ```csharp
    void UseModelWithBatchItems(MLContext mlContext, ITransformer model)
    {

    }
    ```

    The `UseModelWithBatchItems()` method executes the following tasks:

    - Creates batch test data.
    - Predicts sentiment based on test data.
    - Combines test data and predictions for reporting.
    - Displays the predicted results.

2. Add a call to the new method right under the `UseModelWithSingleItem()` method call using the following code:

    [!code-csharp[CallPredictModelBatchItems](./snippets/sentiment-analysis/csharp/Program.cs#CallUseModelWithBatchItems "Call the CallUseModelWithBatchItems method")]

3. Add some comments to test the trained model's predictions in the `UseModelWithBatchItems()` method:

    [!code-csharp[PredictionData](./snippets/sentiment-analysis/csharp/Program.cs#CreateTestIssues "Create test data for predictions")]

### Predict comment sentiment

Use the model to predict the comment data sentiment using the [Transform()](xref:Microsoft.ML.ITransformer.Transform%2A) method:

[!code-csharp[Predict](./snippets/sentiment-analysis/csharp/Program.cs#Prediction "Create predictions of sentiments")]

### Combine and display the predictions

Create a header for the predictions using the following code:

[!code-csharp[OutputHeaders](./snippets/sentiment-analysis/csharp/Program.cs#AddInfoMessage "Display prediction outputs")]

Because `SentimentPrediction` is inherited from `SentimentData`, the `Transform()` method populated `SentimentText` with the predicted fields. As the ML.NET process processes, each component adds columns, and this makes it easy to display the results:

[!code-csharp[DisplayPredictions](./snippets/sentiment-analysis/csharp/Program.cs#DisplayResults "Display the predictions")]

## Results

Your results should be similar to the following. During processing, messages are displayed. You may see warnings, or processing messages. These have been removed from the following results for clarity.

```console
Model quality metrics evaluation
--------------------------------
Accuracy: 83.96%
Auc: 90.51%
F1Score: 84.04%

=============== End of model evaluation ===============

=============== Prediction Test of model with a single sample and test dataset ===============

Sentiment: This was a very bad steak | Prediction: Negative | Probability: 0.1027377
=============== End of Predictions ===============

=============== Prediction Test of loaded model with a multiple samples ===============

Sentiment: This was a horrible meal | Prediction: Negative | Probability: 0.1369192
Sentiment: I love this spaghetti. | Prediction: Positive | Probability: 0.9960636
=============== End of predictions ===============

=============== End of process ===============
Press any key to continue . . .

```

Congratulations! You've now successfully built a machine learning model for classifying and predicting messages sentiment.

Building successful models is an iterative process. This model has initial lower quality as the tutorial uses small datasets to provide quick model training. If you aren't satisfied with the model quality, you can try to improve it by providing larger training datasets or by choosing different training algorithms with different [hyper-parameters](../resources/glossary.md#hyperparameter) for each algorithm.

You can find the source code for this tutorial at the [dotnet/samples](https://github.com/dotnet/samples/tree/main/machine-learning/tutorials/SentimentAnalysis) repository.

## Next steps

In this tutorial, you learned how to:
> [!div class="checklist"]
>
> - Create a console application
> - Prepare data
> - Load the data
> - Build and train the model
> - Evaluate the model
> - Use the model to make a prediction
> - See the results

Advance to the next tutorial to learn more
> [!div class="nextstepaction"]
> [Issue Classification](github-issue-classification.md)

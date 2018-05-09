---
title: Use ML.NET in a sentiment analysis classification scenario
description: Discover how to use ML.NET in a classification scenario to understand how to use sentiment prediction to take the appropriaste action.
ms.date: 05/07/2018
ms.custom: mvc
#Customer intent: As a developer, I want to use ML.NET to apply a binary classification task so that I can understand how to use sentiment prediction to take appropriaste action.
---
# Tutorial: Use the ML.NET APIs in a sentiment analysis classification scenario

This sample tutorial illustrates using the ML.NET API to create a sentiment classifier via a .NET Core console application using C# in Visual Studio 2017.

In this tutorial, you learn how to:
> [!div class="checklist"]
> * Understand the problem
> * Create the learning pipeline
> * Load a classifier
> * Train the model
> * Predict the model
> * Evaluate the model with a different dataset

## Sentiment analysis sample overview

The sample is a console app that uses the ML.NET API to train a model that classifies and predicts sentiment as either positive or negative. It also evaluates the model with a second dataset for quality analysis. The sentiment datasets are from University of California, Irvine (UCI) and are automatically downloaded and unzipped into a data directory.

Prediction and evaluation results are displayed accordingly so that analysis and action can be taken.

Sentiment analysis is either positive or negative. So, you can use classification to train the model, for prediction, and for evaluation.

## Machine learning workflow

This tutorial follows a machine learning workflow that enables the process to move in an orderly fashion.

The workflow phases are as follows:

1. **Understand the problem**
2. **Ingest the data**
3. **Data preprocess and feature engineering**
4. **Train and predict the model**
5. **Evaluate the model**
6. **Model operationalization**

### Understand the problem

You first need to understand the problem, so you can break it down to parts that can support building and training the model. Breaking the problem down you to predict and evaluate the results.

The problem for this tutorial is to understand incoming website comment sentiment to take the appropriate action.

You can break down the problem to the sentiment text and sentiment value for the data you want to train the model with, and a predicted sentiment value that you can evaluate and then use operationally.

You then need to **determine** the sentiment, which helps you with the machine learning model selection.

With this problem, you know the following facts:

Training data: website comments can be positive or negative (**sentiment**).
Predict the **sentiment** of a new website comment, either positive or negative.

## Prerequisites

[Visual Studio 2017 15.6 or later](https://www.visualstudio.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=button+cta&utm_content=download+vs2017) with the ".NET Core cross-platform development" workload installed.

[The UCI Sentiment Labeled Sentences dataset zip file](https://archive.ics.uci.edu/ml/machine-learning-databases/00331/sentiment%20labelled%20sentences.zip)

## Create a console application

1. Open Visual Studio 2017. Select **File** > **New** > **Project** from the menu bar. In the *New Project** dialog, select the **Visual C#** node followed by the **.NET Core** node. Then select the **Console App (.NET Core)** project template. In the **Name** text box, type "SentimentAnalysis" and then select the **OK** button.

2. Create a directory named Data in your project's *bin* directory:

    In Solution Explorer, click on the **Solutions and Folders** icon. Right-click on the *bin* folder, select **Add** > **New Folder**. Type "Data" and hit Enter. Click again on the **Solutions and Folders** icon to return to the solution view.

3. Install the **Microsoft ML.NET NuGet Package**:

    In Solution Explorer, right-click on your project and select **Manage NuGet Packages**. Choose "nuget.org" as the Package source, select the Browse tab, search for **Microsoft ML.NET**, select that package in the list, and select the **Install** button. If prompted to select a package management format, select **PackageReference in project file**.

4. Download [The UCI Sentiment Labeled Sentences dataset zip file (see citations in the following note)](https://archive.ics.uci.edu/ml/machine-learning-databases/00331/sentiment%20labelled%20sentences.zip), and unzip into the *data* directory you created.

> [!NOTE]
> The datasets this tutorial uses are from the 'From Group to Individual Labels using Deep Features', Kotzias et. al,. KDD 2015, and hosted at the UCI Machine Learning Repository - Dua, D. and Karra Taniskidou, E. (2017). UCI Machine Learning Repository [http://archive.ics.uci.edu/ml]. Irvine, CA: University of California, School of Information and Computer Science.

### Housekeeping

Add the following `using` statements to the top of the *Program.cs* file:

[!code-csharp[AddUsings](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#1 "Add necessary usings")]

You need to create two global variables to hold the path to the recently downloaded files:

* `_datapath` has the path to the dataset used to train the model.
* `_testdatapath` has the path to the dataset used to evaluate the model.

Add the following code to the line right above the `Main` method:

[!code-csharp[Declare file variables](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#2 "Declare variables to store data files")]

You need to create some classes for your input data and predictions. Add a new class to your project:

1. In **Solution Explorer**, select the SentimentAnalysis project, and then on the **Project** menu, select **Add Class**.

2. In the **Add New Item** dialog box, change the **Name** field to "SentimentData.cs", and then select the **Add** button.

    The *SentimentData.cs* file opens in the code editor. Add the following `using` statements to the top of *SentimentData.cs*:

[!code-csharp[AddUsings](../../../samples/machine-learning/tutorials/SentimentAnalysis/SentimentData.cs#1 "Add necessary usings")]

Add the following code, which has two classes `SentimentData` and `SentimentPrediction`, to the *SentimentData.cs* file:

[!code-csharp[DeclareTypes](../../../samples/machine-learning/tutorials/SentimentAnalysis/SentimentData.cs#2 "Declare data record types")]

`SentimentData` is the input dataset class and has a string for the comment (`SentimentText`), a `float` (`Sentiment`) that has a value for sentiment of either positive or negative. Both fields have `Column` attributes attached to them. This attribute describes the order of each field in the data file, and which is the `Label` field. `SentimentPrediction` is the class used for prediction after the model has been trained. It has a single boolean (`Sentiment`) and a `PredictedLabel` `ColumnName` attribute. The `Label` is used to create and train the model, and it's also used with a second dataset to evaluate the model. The `PredictedLabel` is used during prediction and evaluation. For evaluation, an input with training data, the predicted values, and the model are used.

In the *Program.cs* file, replace the `Console.WriteLine("Hello World!")` line with the following code in the `Main` method:

[!code-csharp[TrainAndPredict](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#3 "Train and predict your model")]

The `TrainAndPredict` method executes the following tasks:

* Load or ingest the data.
* Preprocess and featurize the data.
* Train the model.
* Predict sentiment based on test data. 

Create the `TrainAndPredict` method, just after the `Main` method, using the following code:

[!code-csharp[DeclareTrainAndPredict](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#4 "Declare the TrainAndPredict model")]

## Ingest the data

Initialize a new instance of <xref:Microsoft.ML.LearningPipeline> that will include the data loading, data processing/featurization, and model. Add the following code as the first line of the `TrainAndPredict` method:

[!code-csharp[LearningPipeline](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#5 "Create a learning pipeline")]

The <xref:Microsoft.ML.TextLoader%601> object is the first part of the pipeline, and loads the training file data.

[!code-csharp[TextLoader](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#6 "Add a text loader to the pipeline")]

## Data preprocess and feature engineering

Pre-processing and cleaning data are important tasks that occur before a dataset is used effectively for machine learning. Raw data is often noisy and unreliable, and may be missing values. Using data without these modeling tasks can produce misleading results. ML.NET's transform pipelines allow you to compose a custom set of transforms that are applied to your data before training or testing. The transforms' primary purpose is for data featurization. A transform pipeline's advantage is that after transform pipeline definition, save the pipeline to apply it to test data.

Apply a <xref:Microsoft.ML.Transforms.TextFeaturizer> to convert the `SentimentText` column into a numeric vector called `Features` used by the machine learning algorithm. This is the preprocessing/featurization step. Using additional components available in ML.NET can enable better results with your model. Add `TextFeaturizer` to the pipeline as the next line of code:

[!code-csharp[TextFeaturizer](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#7 "Add a TextFeaturizer to the pipeline")]

### About the classification model

Classification is a machine learning method that uses data to **determine** the category, type, or class of an item or row of data. For example, you can use classification to:

* Identify sentiment as positive or negative.
* Classify email filters as spam, junk, or good.
* Determine whether a patient's lab sample is cancerous.
* Categorize customers by their propensity to respond to a sales campaign.

Classification tasks are frequently one of the following types:

* Binary: either A or B.
* Multiclass: multiple categories that can be predicted by using a single model.

The <xref:Microsoft.ML.Trainers.FastTreeBinaryClassifier> object is a decision tree learner you'll use in this pipeline. Similar to the featurization step, trying out different learners available in ML.NET and changing their parameters leads to different results. For tuning, you can set hyperparameters like <xref:Microsoft.ML.Trainers.FastTreeBinaryClassifier.NumTrees>, <xref:Microsoft.ML.Trainers.FastTreeBinaryClassifier.NumLeaves>, and <xref:Microsoft.ML.Trainers.FastTreeBinaryClassifier.MinDocumentsInLeafs>. These hyperparameters are set before anything affects the model and are model specific. They're used to tune the decision tree for performance, so larger values can negatively impact performance.

Add the following code to the `TrainAndPredict` method:

[!code-csharp[BinaryClassifier](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#8 "Add a fast binary tree classifier")]

## Train the model

You train the model, <xref:Microsoft.ML.PredictionModel%602>, based on the dataset that has been loaded and transformed. `pipeline.Train<SentimentData, SentimentPrediction>()` trains the pipeline (loads the data, trains the featurizer and learner). The experiment is not executed until this happens.

Add the following code to the `TrainAndPredict` method:

[!code-csharp[TrainModel](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#9 "Train the model")]

## Predict the model

Add some comments to test the trained model's predictions in the `TrainAndPredict` method:

[!code-csharp[PredictionData](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#10 "CVreate test data for predictions")]

Now that you have a model, you can use that to predict the positive or negative sentiment of the comment data using the <xref:Microsoft.ML.PredictionModel.Predict%2A?displayProperty=nameWithType> method. To get a prediction, use `Predict` on new data. Note that the input data is a string and the model includes the featurization. Your pipeline is in sync during training and prediction. You didn’t have to write preprocessing/featurization code specifically for predictions, and the same API takes care of both batch and one-time predictions.

[!code-csharp[Predict](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#11 "Create predictions of sentiments")]

### Model operationalization: prediction

Display `SentimentText` and corresponding sentiment prediction in order to share the results and act on them accordingly. This is called operationalization, using the returned data as part of the operational policies. Create a header for the results using the following <xref:System.Console.WriteLine?displayProperty=nameWithType> code:

[!code-csharp[OutputHeaders](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#12 "Display prediction outputs")]

Before displaying the predicted results, combine the sentiment and prediction together to see the original comment with its predicted sentiment. The following code uses the <xref:System.Linq.Enumerable.Zip%2A> method to make that happen, so add that code next:

[!code-csharp[BuildTuples](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#13 "Build the pairs of sentiment data and predictions")]

Now that you've combined the `SentimentText` and `Sentiment` into a class, you can display the results using the <xref:System.Console.WriteLine?displayProperty=nameWithType> method:

[!code-csharp[DisplayPredictions](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#14 "Display the predictions")]

#### Return the model trained to use for evaluation

Return the model at the end of the `TrainAndPredict` method. At this point, you could then save it to a zip file or continue to work with it. For this tutorial, you're going to work with it, so add the following code to the next line in `TrainAndPredict`:

[!code-csharp[ReturnModel](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#15 "Return the model")]

## Evaluate the model

Now that you've created and trained the model, you need to evaluate it with a different dataset for quality assurance and validation. In the `Evaluate` method, the model created in `TrainAndPredict` is passed in to be evaluated. Create the `Evaluate` method, just after `TrainAndPredict`, as in the following code:

[!code-csharp[Evaluate](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#16 "Evaluate your model")]

Add a call to the new method from the `Main` method, right under the `TrainAndPredict` method call, using the following code:

[!code-csharp[CallEvaluate](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#17 "Call the Evaluate method")]

The <xref:Microsoft.ML.TextLoader%601> class loads the new test dataset with the same schema. You can evaluate the model using this dataset as a quality check. Add that next to the `Evaluate` method call, using the following code:

[!code-csharp[LoadText](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#18 "Load the test dataset")]

The <xref:Microsoft.ML.Models.BinaryClassificationEvaluator> object computes the quality metrics for the `PredictionModel` using the specified dataset. To see those metrics, add the evaluator as the next line in the `Evaluate` method, with the following code:

[!code-csharp[BinaryEvaluator](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#19 "Create the binary evaluator")]

The <xref:Microsoft.ML.Models.BinaryClassificationMetrics> contains the overall metrics computed by binary classification evaluators. To display these to determine the quality of the model, we need to get the metrics first. Add the following code:

[!code-csharp[CreateMetrics](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#20 "Evaluate the model and create metrics")]

### Displaying the metrics for model validation

Use the following code to display the metrics, share the results, and act on them accordingly:

[!code-csharp[DisplayMetrics](../../../samples/machine-learning/tutorials/SentimentAnalysis/Program.cs#21 "Display selected metrics")]

## Results

Your results should be similar to the following. As the pipeline processes, it displays messages. You may see warnings, or processing messages. These have been removed from the following results for clarity.

```cmd
Sentiment Predictions
---------------------
Sentiment: Contoso's 11 is a wonderful experience | Prediction: Positive
Sentiment:The acting in this movie is really bad | Prediction: Negative
Sentiment: Joe versus the Volcano Coffee Company is a great film. | Prediction: Positive


PredictionModel quality metrics evaluation
------------------------------------------
Accuracy: 67.30%
Auc: 73.78%
F1Score: 65.25%
Press any key to continue . . .
```

## Next steps

In this tutorial, you learned how to:
> [!div class="checklist"]
> * Understand the problem
> * Create the learning pipeline
> * Load a classifier
> * Train the model
> * Predict the model
> * Evaluate the model with a different dataset

Advance to the next tutorial to learn more
> [!div class="nextstepaction"]
> [Taxi Fare Predictor](taxi-fare.md)

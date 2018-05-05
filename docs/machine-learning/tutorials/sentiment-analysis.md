---
title: Use ML.NET in a classification scenario
description: Discover how to use ML.NET in a classification scenario.
ms.prod: dotnet-ml
ms.devlang: dotnet
ms.author: johalex
author: jralexander
ms.date: 05/07/2018
ms.topic: conceptual
manager: wpickett
ms.custom: mvc
#Customer intent: As a developer, I want to use ML.NET to apply a binary classification task so that I can understand how to use sentiment prediction to take appropriaste action.
---
# Walkthrough: Use the ML.NET API in a sentiment analysis classification scenario

This sample walkthrough illustrates using the ML.NET API to create a sentiment classifer via a .NET Core console application using C# in Visual Studio 2017. 

In this tutorial, you learn how to:
> [!div class="checklist"]
> * Understand the problem
> * Create the learning pipeline
> * Load a classifier
> * Train  the model 
> * Predict the model
> * Evaluate the model with a different dataset

## Sentiment analysis sample overview

The sample is a console app that uses the ML.NET API to train a model that classifies and predicts sentiment as either positive or negative. It also evaluates the model with a second dataset for quality analysis. The sentiment datasets are from UCI and are automatically downloaded and unzipped into a data directory.

Prediction and evaluation results are displayed accordingly so that analysis and action can be taken. 

Sentiment analysis is either positive or negative, and so we can use classification to train our model, for prediction, and for evaluation. 

## Machine Learning workflow

This walkthrough follows a machine learning workflow that enables the process to move in an orderly fashion.

The workflow phases are as follows:

1. **Understand the problem**
2. **Ingest the data**
3. **Data Preprocess and feature engineering**
4. **Train and predict the model**
5. **Evaluate the model**
6. **Model operationalization**

### Understand the problem

We need to understand the problem in order to break it down to parts that can support building and training our model, which enables us to predict and evaluate the results.

Our problem is a need to understand incoming website comment sentiment in order to take appropriate action.

We can break down the problem to the sentiment text and sentiment value for the data we want to train the model with, and a predicted sentiment value that we can evaluate and then use operationally.

We need to **determine** the sentiment, which helps us in our Machine Learning model selection. 

In our problem, we know the following:

Training data: Website comments can be positive or negative (**sentiment**).
 Predict the **sentiment** of a new website comment, either positive or negative.

## Prerequisites

[Visual Studio 2017 15.6 or later](https://aka.ms/vsdownload?utm_source=mscom&utm_campaign=msdocs) with the ".NET Core cross-platform development" workload installed.

[The UCI Sentiment Labeled Sentences dataset zip file](https://archive.ics.uci.edu/ml/machine-learning-databases/00331/sentiment%20labelled%20sentences.zip)

## Create a console application

1. Launch Visual Studio 2017. Create a new C# **Console App (.NET Core)** project named "SentimentAnalysis".

2. Create a directory named Data in your project's bin directory.

3. Install the **Microsoft ML.NET NuGet Package**. You can either:

    a. In Solution Explorer, right-click **References** and choose **Manage NuGet Packages**. Choose "nuget.org" as the Package source, select the Browse tab, search for **Microsoft ML.NET**, select that package in the list, and select Install.  If prompted to select a package management format, select **PackageReference in project file**.
    
    b. Click on the **Tools** menu, then select **NuGet Package Manager**, and choose **Package Manager Console**. Type "Install-Package Microsoft.ML" at the prompt. 

4. Download [The UCI Sentiment Labeled Sentences dataset zip file (citations below)](https://archive.ics.uci.edu/ml/machine-learning-databases/00331/sentiment%20labelled%20sentences.zip), and unzip into the data directory you just created.

> [!NOTE]
> The datasets this tutorial uses are from the 'From Group to Individual Labels using Deep Features', Kotzias et. al,. KDD 2015, and hosted at the UCI Machine Learning Repository - Dua, D. and Karra Taniskidou, E. (2017). UCI Machine Learning Repository [http://archive.ics.uci.edu/ml]. Irvine, CA: University of California, School of Information and Computer Science.

### Housekeeping

Add the following `using` statements to the top of Program.cs:

```csharp

using System;
using Microsoft.ML.Models;
using Microsoft.ML.Runtime;
using Microsoft.ML.Runtime.Api;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ML;

```

We have a couple of global variables to hold our datapath (The dataset we'll use to train our model.), and our testdatapath (The dataset we'll use to evaluate our model.). We need to add these to be able to access our recently downloaded files. Add the following code to the line right above Main:

```csharp

const string _dataPath = @"..\..\data\sentiment labelled sentences\imdb_labelled.txt";
const string _testDataPath = @"..\..\data\sentiment labelled sentences\yelp_labelled.txt";

```

We need to create some classes for our input data and our predictions. Let's add a new class to our project.

1.  In **Solution Explorer**, select the SentimentAnalysis project, and then on the **Project** menu, select **Add Class**.  
  
2.  In the **Add New Item** dialog box, change the **Name** to `SentimentData.cs`, and then click **Add**.  
  
     The SentimentData.cs file opens in the code editor.  Add the following `using` statements to the top of SentimentData.cs:

```csharp

using Microsoft.ML.Runtime.Api;

```

We have two classes to add. SentimentData, our input dataset class, has a string for the comment (SentimentText), It has a boolean (Sentiment) that has a value for sentiment of either positive or negative, and a `Label` `ColumnName` attribute. . SentimentPrediction is our class used for prediction after the model has been trained. It has a single boolean (Sentiment), and a `PredictedLabel` `ColumnName` attribute. The `Label` is used to create, and train the model, and it's also used (with a second dataset) to evaluate the model.  The `PredictedLabel` is used during prediction and evaluation. For evaluation, an input with training data, the predicted values, and the model are used. 

Let's add the following two classes to the SentimentData.cs file: 

```csharp

public class SentimentData
{

    public string SentimentText;
    [ColumnName("Label")]
    public float Sentiment;

}

public class SentimentPrediction
{
    [ColumnName("PredictedLabel")]
    public bool Sentiment;
}

```

In Main, replace the `Console.WriteLine("Hello World!")` with the following code:

```csharp

 var model = TrainAndPredict();

```

The TrainAndPredict function is what we use to load or ingest our data, preprocess and featurize our data, train our model, and then predict sentiment based on test data. Let's create that function, just below Main, using the following function code:

```csharp

public static PredictionModel<SentimentData, SentimentPrediction> TrainAndPredict()
{

}

```

## Ingest the data

We create a <xref:Microsoft.ML.LearningPipeline> which will include the data loading, data processing/featurization, and model. Add the following code as the first line of the TrainAndPredict function:

```csharp
var pipeline = new LearningPipeline();
```

The <xref:Microsoft.ML.TextLoader> is the first part of the pipeline, and loads the training file data.

```csharp
pipeline.Add(new TextLoader<SentimentData>(_dataPath, header: false, sep: "tab"));
```

## Data Preprocess and feature engineering

Pre-processing and cleaning data are important tasks that occur before a dataset is used effectively for machine learning. Raw data is often noisy and unreliable, and may be missing values. Using data without these modeling tasks can produce misleading results. ML.NET's transform pipelines allow you to compose a custom set of transforms that are applied to your data before training and/or testing. The transforms' primary purpose is for data featurization. A transform pipelines' advantage is that after transform pipeline definition, save the pipeline to apply it to test data.

 We then apply a <xref:Microsoft.ML.Transforms.TextFeaturizer> to convert the SentimentText column into a numeric vector called Features then used by the machine learning algorithm. This is our preprocessing/featurization step. Using additional components available in ML.NET can enable better results with your model.  Add TextFeaturizer to the pipeline as the next line of code:

```csharp

pipeline.Add(new TextFeaturizer("Features", "SentimentText"));

```

### About the Classification model

Classification is a machine learning method that uses data to **determine** the category, type, or class of an item or row of data.

For example, you can use classification to:

* Identify sentiment as positive or negative.
* Classify email filters as spam, junk, or good.
* Determine whether a patient's lab sample is cancerous.
* Categorize customers by their propensity to respond to a sales campaign.

Classification tasks are frequently organized by whether a classification is binary (either A or B) or multiclass (multiple categories that can be predicted by using a single model). The <xref:Microsoft.ML.Trainers.FastTreeBinaryClassifier> is a decision tree learner we will use in this pipeline. Similar to the featurization step, trying out different learners available in ML.NET and changing their parameters will lead to different results.
For tuning, we can set hyperparameters like <xref:Microsoft.ML.Trainers.FastTreeBinaryClassifier.NumTrees>,<xref:Microsoft.ML.Trainers.FastTreeBinaryClassifier.NumLeaves>, and <xref:Microsoft.ML.Trainers.FastTreeBinaryClassifier.MinDocumentsInLeafs>. These are set before anything affects the model, and are model specific.  The hyperparameters are used to tune the decision tree for performance, so larger values can negatively impact performance.

```csharp

pipeline.Add(new FastTreeBinaryClassifier() { NumLeaves = 5, NumTrees = 5, MinDocumentsInLeafs = 2 });

```

## Train the model

We train our model, <xref:Microsoft.ML.PredictionModel`2>, based on the dataset that has been loaded and transformed. pipeline.Train<SentimentData, SentimentPrediction>() trains the pipeline (loads the data, trains the featurizer and learner). The experiment is not executed until this happens. 

```csharp

PredictionModel<SentimentData, SentimentPrediction> model = pipeline.Train<SentimentData, SentimentPrediction>();

```
## Predict the model

We need to add some comments to test the trained model's predictions.

```csharp

 IEnumerable<SentimentData> sentiments = new[]
             {
                new SentimentData
                {
                    SentimentText = "Contoso's 11 is a wonderful experience",
                    Sentiment = 0
                },
                new SentimentData
                {
                    SentimentText = "Stinks",
                    Sentiment = 0
                },
                new SentimentData
                {
                    SentimentText = "Joe versus the Volcano Coffee Company is a great film.",
                    Sentiment = 0
                }
            };

```

Now that we have a model, we use that to predict (<xref:Microsoft.ML.PredictionModel`2.Predict(System.Collections.Generic.IEnumerable{`0}>) the positive or negative sentiment of the comment data. To get a prediction, we use model.Predict() on new data. Note that the input data is a string and the model includes the featurization, our pipeline is in sync during training and prediction. We didn’t have to write preprocessing/featurization code specifically for predictions, and the same API takes care of both batch and one-time predictions.

```csharp

IEnumerable<SentimentPrediction> predictions = model.Predict(sentiments);

```

### Model operationalization: prediction

Display SentimentText and corresponding sentiment prediction in order to share the results and act on them accordingly. That is operationalization, using the returned data as part of the operational policies. Let's create a header for the results using the following <xref:System.Console.WriteLine> code:

```csharp

Console.WriteLine();
Console.WriteLine("Sentiment Predictions");
Console.WriteLine("---------------------");

```

Before we can display the predicted results, let's combine the sentiment and prediction together, in order to see the orignal comment with its' predicted sentiment. The following code uses the <xref:System.Linq.Enumerable.Zip> method to make that happen, so let's add that next:

```csharp

var sentimentsAndPredictions = sentiments.Zip(predictions, (sentiment, prediction) => new { sentiment, prediction });

```

Now that we have combined the SentimentText and Sentiment into a class, we can display the results using <xref:System.Console.WriteLine>

```csharp

foreach (var item in sentimentsAndPredictions)
{
    Console.WriteLine($"Sentiment: {item.sentiment.SentimentText} | Prediction: {(item.prediction.Sentiment ? "Positive" : "Negative")}");
}
Console.WriteLine();

```

#### Return the model we trained to use for evaluation

Let's return the model at the end of our function. At this point, we could then save it to a zip file or continue to work with it. For this tutorial, we are going to work with it, so add the following code to the next line in TrainAndPredict:  

```csharp

return model;

```

## Evaluate the model

Now that we've created and trained our model, we need to evaluate it with a different dataset for quality assurance and validation. In the Evaluate function, the model created in TrainAndPredict is passed in to be evaluated. Let's create the Evaluate method, just after TrainAndPredict, as in the following code:

```csharp

public static void Evaluate(PredictionModel<SentimentData, SentimentPrediction> model)
{

}

```

Now that we've created the Evaluate method, let's add it to Main, right under the TrainAndPredict function, using the following code:

```csharp

Evaluate(model);

```
 
The <xref:Microsoft.ML.TextLoader> loads our new test dataset with the same schema. We can evaluate our model using this dataset as a quality check. Let's add that next to the Evaluate function, using the following code:

```csharp

var testData = new TextLoader<SentimentData>(_testDataPath, header: false, sep: "tab");

```

The <xref:Microsoft.ML.Models.BinaryClassificationEvaluator> computes the quality metrics for the PredictionModel using the specified dataset. We want to see those metrics, so let's add it as the next line in the Evaluate method, with the following code:

```csharp

var evaluator = new BinaryClassificationEvaluator();

```

The <xref:Microsoft.ML.Models.BinaryClassificationMetrics> contains the overall metrics computed by binary classification evaluators. We want to display these to determine the quality of our model, so we need to get the metrics first. Lets add the following code

```csharp

BinaryClassificationMetrics metrics = evaluator.Evaluate(model, testData);

```

### Displaying our metrics for model validation 

We want to display the metrics in order to share the results and act on them accordingly by using the following <xref:System.Console.WriteLine> code:


```csharp
            Console.WriteLine();
            Console.WriteLine("PredictionModel quality metrics evaluation");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
            Console.WriteLine($"Auc: {metrics.Auc:P2}");
            Console.WriteLine($"F1Score: {metrics.F1Score:P2}");
```
## Results

Your results should be similar to the following (As the pipeline processes, it displays messages. You may see warnings, or processing messages. These have been removed from the following results for clarity.):

```cmd

Sentiment Predictions
---------------------
Sentiment: Contoso's 11 is a wonderful experience | Prediction: Positive
Sentiment: Stinks | Prediction: Negative
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
> * Train  the model 
> * Predict the model
> * Evaluate the model with a different dataset

Advance to the next article to learn more
> [!div class="nextstepaction"]
> [Next steps button](flight-delay.md)
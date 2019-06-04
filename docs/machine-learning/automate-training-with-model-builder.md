---
title: What is Model Builder and how does it work?
description: How to use the ML.NET Model Builder to automatically train a machine learning model
author: natke
ms.date: 05/29/2019
ms.custom: overview
#Customer intent: As a developer, I want to use Model Builder to automatically train a model using a visual interface. 
---
# What is Model Builder & how does it work?

Model Builder is a user interface that runs in Visual Studio. Model Builder automatically trains custom ML.NET machine learning models that can be deployed in your application. 

You don't need machine learning expertise to use Model Builder. All you need is some data, and a problem to solve.

Model Builder uses automated machine learning (AutoML) to evaluate different models. It chooses the best model for your scenario, without any manual tuning.

Once the optimal model is selected, Model Builder generates code to add the model to your application.

**Video or animated gif of the model builder interface**

## Scenarios

You can bring many different scenarios to Model Builder, for it to generate a machine learning model for your application.

A scenario is a description of the type of prediction you want to make on your data. For example: predict future product sales volume based on historical sales data.

In Model Builder, you need to map your scenario onto an **ML.NET task**. Model Builder currently supports **regression** (predict numbers) and **classification** (predict categories) tasks.

Here are some example scenarios, with the corresponding task.

|||
|-|-|
|Forecast sales|regression|
|Predict prices|regression|
|Predict time to failure|regression|
|Detect email spam|classification|
|Work out whether customer feedback is good or bad|classification|
|Detect fraudulent credit card transactions|classification|

## Data

Once you have mapped your scenario onto a task, Model Builder asks you to provide a training dataset. The data is used to train, evaluate, and choose the best model for your scenario. A training dataset is a table of rows of training examples, and columns of attributes. Each row has:
- a **label** (the attribute that you want to predict)
- **features** (attributes that are used as inputs to predict the label).

For the house-price prediction scenario, the features could be:
- the square footage of the house
- the number of bedrooms and bathrooms
- the zip code.

The label is the historical house price for that row of square footage, bedroom, and bathroom values and zip code. 

**Diagram**

The data you provide must be stored in a file (.csv or .tsv with a header row), or in a SQL server database.

Model Builder will make a best guess at the label in your dataset. If it is not correct, then you can select a different column.

If you don't have your own data yet, try out these datasets:

|Data|Label|Features|
|-|-|-|
|[taxi fare prediction](https://github.com/dotnet/machinelearning-samples/blob/master/datasets/taxi-fare-train.csv)|Fare|Trip time, distance, and others|
|[product sales forecasting](https://github.com/dotnet/machinelearning-samples/blob/master/samples/csharp/getting-started/AnomalyDetection_Sales/SpikeDetection/Data/product-sales.csv)|Product Sales|Month|
|[website comment sentiment analysis](https://github.com/dotnet/machinelearning-samples/blob/master/samples/csharp/getting-started/BinaryClassification_SentimentAnalysis/SentimentAnalysis/Data/wikiDetoxAnnotated40kRows.tsv)|Label (0 when negative sentiment, 1 when positive)|Comment, Year, ...|
|[credit card fraud detection](https://github.com/dotnet/machinelearning-samples/blob/master/samples/csharp/getting-started/BinaryClassification_CreditCardFraudDetection/CreditCardFraudDetection.Trainer/assets/input/creditcardfraud-dataset.zip)|Amount, V1-V28 (anonymized features|Class (1 when fraudulent, 0 otherwise)|
|[issue classification](https://github.com/dotnet/machinelearning-samples/blob/master/samples/csharp/end-to-end-apps/MulticlassClassification-GitHubLabeler/GitHubLabeler/Data/corefx-issues-train.tsv)|Area|Title, Description|

Model Builder currently places the following limitations on the data that it imports:
* A limit of 1 GB on the training dataset.
* SQL Server has a limit of 100-K rows for training
* Microsoft SQL Server Data Tools for Visual Studio 2017 isn't supported.

## Train

Once you have provided the task and the data, Model Builder trains the model.

Training in Model Builder is the process of trying different algorithms and settings, and evaluating how accurately they perform.

You can provide a training time. In general, training for a longer time produces a more accurate model. More training time is also required as the size of the training dataset increases. The following table gives some training time guidelines for datasets of increasing size.

Dataset Size  | Dataset Type       | Avg. Time to train
------------- | ------------------ | --------------
0 - 10 Mb     | Numeric and Text   | 10 sec
10 - 100 Mb   | Numeric and Text   | 10 min 
100 - 500 Mb  | Numeric and Text   | 30 min 
500 - 1 Gb    | Numeric and Text   | 60 min 
1 Gb+         | Numeric and Text   | 3 hour+ 

## Evaluate

Model Builder by splits the training data into a training set and a test set. The training data (80%) is used to train your model and the test data (20%) is used to evaluate your model. 

### Regression (predicting numbers)

The default metric for regression problems is **RSquared**. 1 is the best possible value. The closer **RSquared** is to 1, the better your model is.

Other metrics reported, such as absolute-loss, squared-loss, and RMS loss can be used to understand your model, and compare it with other regression models. 

### Classification (predicting categories)

The default metric for classification problems is **accuracy**. **Accuracy** defines the proportion of correct predictions your model makes over the test dataset. The **closer to 100%, the better it is**. 

Other metrics reported such as AUC (Area under the curve), which measures the true positive rate vs. the false positive rate should be greater than 0.50, for models to be acceptable. 

Additional metrics such as F1 score can be used to control the balance between precision and recall. 

When there are more than two categories, are two types of accuracy:
- Micro-accuracy: the fraction of predictions that are correct across all instances.
- Macro-accuracy: the average accuracy at the class level

## Improve model performance

* Train for a longer period of time. With more time, the automated machine learning engine to try more algorithms and settings.

* Add more data. Sometimes the amount of data is not sufficient to train a high-quality machine learning model. 

* Add better data. For classification tasks, make sure that the training set is balanced across the categories.

## Generated Code + Model

After the evaluation phase, Model Builder outputs a model file, and code that you can use to add the model to your application.

In addition, Model Builder outputs the code that generated the model, so that you can understand the steps used to generate the model. 

## What's next?

Try the [Predict prices with Model Builder tutorial](tutorials/predict-prices-with-model-builder.md)

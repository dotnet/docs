---
title: What is Model Builder and how does it work?
description: How to use the ML.NET Model Builder to automatically train a machine learning model
author: natke
ms.date: 06/26/2019
ms.custom: overview
#Customer intent: As a developer, I want to use Model Builder to automatically train a model using a visual interface.
---
# What is Model Builder and how does it work?

ML.NET Model Builder is an easy-to-understand graphical Visual Studio extension to build, train, and deploy custom machine learning models.

Model Builder uses automated machine learning (AutoML) to explore different machine learning algorithms and settings to help you find the one that best suits your scenario.

You don't need machine learning expertise to use Model Builder. All you need is some data, and a problem to solve. Model Builder generates the code to add the model to your .NET application.

![Model Builder Visual Studio extension user interface animation](media/ml-dotnet-model-builder.gif)

> [!NOTE]
> Model Builder is currently in Preview.

## Scenarios

You can bring many different scenarios to Model Builder, to generate a machine learning model for your application.

A scenario is a description of the type of prediction you want to make on your data. For example:
- predict future product sales volume based on historical sales data
- classify sentiments as positive or negative based on customer reviews
- detect whether a banking transaction is fraudulent
- route customer feedback issues to the correct team in your company

In Model Builder, you need to map your scenario onto an [ML.NET task](resources/tasks.md). You can use Model Builder for **regression** (predicting numbers) and **classification** (predicting categories).

### Which machine learning scenario is right for me?

Model Builder comes with templates for sentiment analysis, issue classification, price prediction, and custom scenarios. These templates can be used as a starting point for your specific ML.NET scenario.

#### Sentiment analysis (binary classification)

Sentiment analysis can be used to predict positive or negative sentiment of customer feedback. It is an example of the binary classification task.

Binary classification is used to categorize data into two classes (yes/no; pass/fail; true/false; positive/negative). It can be used to answer questions such as:

- Is this email spam? (spam detection)
- Which applicants may be eligible for membership? (application screening)
- Which accounts may not pay their invoices on time? (risk mitigation)
- Is this credit card transaction fraudulent? (fraud detection)

If your scenario requires classification into two categories, you can use this template with your own dataset.

#### Issue classification (multiclass classification)

Issue classification can be used to categorize customer feedback (for example, on GitHub) issues using the issue title and description. It is an example of the multi-class classification task.

Multiclass classification can be used to categorize data into three or more classes. It can be used to answer questions such as:

- To which department should I route a support ticket? (support ticket routing)
- What is the priority of a customer issue? (customer issue prioritization)
- What category does a product belong to? (product classification)
- What type of document? (document/email classification)

You can use the issue classification template for your scenario if you want to categorize data into three or more categories.

#### Price prediction (regression)

Price prediction can be used to predict house prices using location, size, and other characteristics of the house. It is an example of the regression task.

Regression is used to predict numbers. It can be used to answer questions such as:

- What price will a house sell for? (price prediction)
- After how much time will a mechanical part require maintenance? (predictive maintenance)
- What is the moisture content in this dryer? (machine monitoring)
- What will the total annual sales for this region be? (sales forecasting)

You can use the price prediction template for your scenario if you want to predict a numerical value with your own dataset.

#### Custom scenario (choose your task)

The custom scenario allows you to choose your own task. Pick the scenario that makes the most sense for your problem.

The custom scenario allows you to choose your own machine learning task. In the previous templates, the machine learning task was fixed to the scenario: binary classification, multi-class classification, or regression. In this template, you can choose the ML task you want to use on your data.

## Data

Once you have mapped your scenario onto a task, Model Builder asks you to provide a dataset. The data is used to train, evaluate, and choose the best model for your scenario. You also need to choose the output you want to predict.

### Choose the output to predict (label)

A dataset is a table of rows of training examples, and columns of attributes. Each row has:
- a **label** (the attribute that you want to predict)
- **features** (attributes that are used as inputs to predict the label).

For the house-price prediction scenario, the features could be:
- the square footage of the house
- the number of bedrooms and bathrooms
- the zip code

The label is the historical house price for that row of square footage, bedroom, and bathroom values and zip code.

![Table showing rows and columns of house price data with features consisting of size rooms zip code and price label](media/model-builder-data.png)

### Data formats

Model Builder places the following limitations on the data:

- Data must be stored in a file (.csv or .tsv with a header row), or in a SQL server database.
- A limit of 1 GB on the training dataset
- SQL server has a limit of 100,000 rows for training
- Data from SQL server is copied from the server to your local machine before training

### Example datasets

If you don't have your own data yet, try out one of these datasets:

|Scenario|ML Task|Data|Label|Features|
|-|-|-|-|-|
|Price prediction|regression|[taxi fare data](https://github.com/dotnet/machinelearning-samples/blob/master/datasets/taxi-fare-train.csv)|Fare|Trip time, distance|
|Anomaly detection|binary classification|[product sales data](https://github.com/dotnet/machinelearning-samples/blob/master/samples/csharp/getting-started/AnomalyDetection_Sales/SpikeDetection/Data/product-sales.csv)|Product Sales|Month|
|Sentiment analysis|binary classification|[website comment data](https://github.com/dotnet/machinelearning-samples/blob/master/samples/csharp/getting-started/BinaryClassification_SentimentAnalysis/SentimentAnalysis/Data/wikiDetoxAnnotated40kRows.tsv)|Label (0 when negative sentiment, 1 when positive)|Comment, Year|
|Fraud detection|binary classification|[credit card data](https://github.com/dotnet/machinelearning-samples/blob/master/samples/csharp/getting-started/BinaryClassification_CreditCardFraudDetection/CreditCardFraudDetection.Trainer/assets/input/creditcardfraud-dataset.zip)|Class (1 when fraudulent, 0 otherwise)|Amount, V1-V28 (anonymized features)|
|Text classification|multiclass classification|[GitHub issue data](https://github.com/dotnet/machinelearning-samples/blob/master/samples/csharp/end-to-end-apps/MulticlassClassification-GitHubLabeler/GitHubLabeler/Data/corefx-issues-train.tsv)|Area|Title, Description|

## Train

Once you select your scenario, data, and label, Model Builder trains the model.

### What is training?

Training is an automatic process by which Model Builder teaches your model how to answer questions for your scenario. Once trained, your model can make predictions with input data that it has not seen before. For example, if you are predicting house prices and a new house comes on the market, you can predict its sale price.

Because Model Builder uses automated machine learning (AutoML), it does not require any input or tuning from you during training.

### How long should I train for?

You can provide a training time. In general, training for a longer time produces a more accurate model. More training time is also required as the size of the training dataset increases. The following table gives some training time guidelines for datasets of increasing size.

Dataset Size  | Dataset Type       | Avg. Time to train
------------- | ------------------ | --------------
0 - 10 Mb     | Numeric and Text   | 10 sec
10 - 100 Mb   | Numeric and Text   | 10 min
100 - 500 Mb  | Numeric and Text   | 30 min
500 - 1 Gb    | Numeric and Text   | 60 min
1 Gb+         | Numeric and Text   | 3 hour+

The exact time to train also depends on:

- the type of columns that is, text vs numeric
- the type of machine learning task (regression or classification)
- the number of rows used for training
- the number of feature columns used for training

Model Builder has been tested for scale with a 1-TB dataset, but building a high-quality model for that size of dataset can take up to four days!

## Evaluate

Evaluation is the process of using the trained model to make predictions with new test data, and then measuring how good the predictions are.

Model Builder splits the training data into a training set and a test set. The training data (80%) is used to train your model and the test data (20%) is held back to evaluate your model.  The metrics used for evaluation depend on the ML task. For more information, see [model evaluation metrics](resources/metrics.md).

### Sentiment analysis (binary classification)

The default metric for binary classification problems is **accuracy**. Accuracy defines the proportion of correct predictions your model makes over the test dataset. The **closer to 100%, the better it is**.

Other metrics reported such as AUC (Area under the curve), which measures the true positive rate vs. the false positive rate, should be greater than 0.50 for models to be acceptable.

Additional metrics such as F1 score can be used to control the balance between precision (ratio of correct predictions to the total predictions of that class) and recall (proportion of correct predictions to the total actual members of that class).

### Issue classification (multiclass classification)

The default metric for multiclass classification problems is **micro accuracy**. The **closer to 100%, the better it is**.

For problems where data is categorized into multiple classes there are two types of accuracy:

- Micro-accuracy: the fraction of predictions that are correct across all instances. In the issue classification scenario, micro-accuracy is the proportion of incoming issues that get assigned to the correct category.
- Macro-accuracy: the average accuracy at the class level. In the issue classification scenario, the accuracy is measured for each category, and then the category accuracies are averaged. For this metric, all classes are given equal weight. For perfectly balanced datasets (where there are an equal number of examples of each category), micro-accuracy and macro-accuracy are the same.

### Price prediction (regression)

The default metric for regression problems is **RSquared**. 1 is the best possible value. The closer RSquared is to 1, the better your model is.

Other metrics reported, such as absolute-loss, squared-loss, and RMS loss can be used to understand your model, and compare it with other regression models.

## Improve

If your model performance score is not as good as you want it to be, you can:

* Train for a longer period of time. With more time, the automated machine learning engine to try more algorithms and settings.

* Add more data. Sometimes the amount of data is not sufficient to train a high-quality machine learning model.

* Balance your data. For classification tasks, make sure that the training set is balanced across the categories. For example, if you have four classes for 100 training examples, and the two first classes (tag1 and tag2) are used for 90 records, but the other two (tag3 and tag4) are only used on the remaining 10 records, the lack of balanced data may cause your model to struggle to correctly predict tag3 or tag4.

## Code

After the evaluation phase, Model Builder outputs a model file, and code that you can use to add the model to your application. ML.NET models are saved as a zip file. The code to load and use your model is added as a new project in your solution. Model Builder also adds a sample console app that you can run to see your model in action.

In addition, Model Builder outputs the code that generated the model, so that you can understand the steps used to generate the model. You can also use the model training code to retrain your model with new data.

## What's next?

Try [price prediction or any regression scenario](tutorials/predict-prices-with-model-builder.md)

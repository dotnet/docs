---
title: Machine learning tasks
description: Explore the different machine learning tasks supported in ML.NET.
ms.date: 06/04/2018
author: aditidugar
---
# Machine learning tasks

When building a machine learning model, you first need to define what you are hoping to achieve with your data. After, you can pick the right machine learning task for your situation. The following list describes the different machine learning tasks that you can choose from and some common use cases. 

> [!NOTE]
> ML.NET is currently in Preview. Not all machine learning tasks are currently supported. To submit a request for a certain task, open an issue in the [dotnet/machinelearning repository](https://github.com/dotnet/machinelearning/issues).

> [!NOTE]
> Currently, ML.NET does not support machine learning tasks with images. Support will be added in future releases. 

## Binary classification

A [supervised machine learning](glossary.md#supervised-machine-learning) task that is used to predict which of two classes (categories) an instance of data belongs to. The input of a classification algorithm is a set of labeled examples, where each label is an integer of either 0 or 1. The output of a binary classification algorithm is a classifier, which you can use to predict the class of new unlabeled instances. Examples of binary classification scenarios include:

* [Understanding sentiment of Twitter comments](../tutorials/sentiment-analysis.md) as either "positive" or "negative".
* Diagnosing whether a patient has a certain disease or not.
* Making a decision to mark an email as "spam" or not.

For more information, see the [Binary classification](https://en.wikipedia.org/wiki/Binary_classification) article on Wikipedia.

## Multiclass classification

A [supervised machine learning](glossary.md#supervised-machine-learning) task that is used to predict the class (category) of an instance of data. The input of a classification algorithm is a set of labeled examples. Each label is an integer between 0 and k-1, where k is the number of classes. The output of a classification algorithm is a classifier, which you can use to predict the class of new unlabeled instances. Examples of multi-class classification scenarios include:

* Determining the breed of a dog as a "Siberian Husky", "Golden Retriever", "Poodle", etc.
* Understanding movie reviews as "positive", "neutral", or "negative".
* Categorizing hotel reviews as "location", "price", "cleanliness", etc.

For more information, see the [Multiclass classification](https://en.wikipedia.org/wiki/Multiclass_classification) article on Wikipedia.

## Regression

A [supervised machine learning](glossary.md#supervised-machine-learning) task that is used to predict the value of the label from a set of related features. The label can be of any real value and is not from a finite set of values as in classification tasks. Regression algorithms model the dependency of the label on its related features to determine how the label will change as the values of the features are varied. The input of a regression algorithm is a set of examples with labels of known values. The output of a regression algorithm is a function, which you can use to predict the label value for any new set of input features. Examples of regression scenarios include:

* Predicting house prices based on house attributes such as number of bedrooms, location, or size.
* Predicting future stock prices based on historical data and current market trends.
* Predicting sales of a product based on advertising budgets.

> [!NOTE]
> Currently, ML.NET is still building support for regression tasks that involve time series.

## Clustering

An [unsupervised machine learning](glossary.md#unsupervised-machine-learning) task that is used to group instances of data into clusters that contain similar characteristics. Clustering can also be used to identify relationships in a dataset that you might not logically derive by browsing or simple observation. The inputs and outputs of a clustering algorithm depends on the methodology chosen. You can take a distribution, centroid, connectivity, or density-based approach. ML.NET currently supports a centroid-based approach using K-Means clustering. Examples of clustering scenarios include:

* Understanding segments of hotel guests based on habits and characteristics of hotel choices.
* Identifying customer segments and demographics to help build targeted advertising campaigns.
* Categorizing inventory based on manufacturing metrics.

## Anomaly detection (*coming soon*)

## Ranking (*coming soon*)

## Recommendation (*coming soon*)


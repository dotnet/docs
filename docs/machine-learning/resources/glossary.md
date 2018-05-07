---
title: Machine Learning Glossary
description: A glossary of machine learning terms.
author: jralexander
ms.author: johalex
ms.date: 05/07/2018
ms.topic: conceptual
ms.prod: dotnet-ml
ms.devlang: dotnet
manager: wpickett
---
# Machine learning glossary

The following list is a compilation of important machine learning terms that are useful as you build your custom models.

## Accuracy

The proportion of true results to total cases. Ranges from 0 (least accurate) to 1 (most accurate). Accuracy is only one evaluation measure used to score performance of your model and should be considered in conjunction with [precision](#precision) and [recall](#recall).

## Area under the curve (AUC)

A value that represents the area under the curve when false positives are plotted on the x-axis and true positives are plotted on the y-axis. Ranges from 0.5 (worst) to 1 (best).

## Binary classification

A [classification](#classification) case where the [label](#label) is only one out of two classes. For more information, see the [Binary classification](https://en.wikipedia.org/wiki/Binary_classification) article on Wikipedia.

## Classification

When the data are being used to predict a category, [supervised learning](#supervised-learning) is also called classification. [Binary classification](#binary-classification) refers to predicting only two categories (for example assigning an image as a picture of either a 'cat' or a 'dog'). [Multiclass classification](#multiclass-classification) refers to predicting multiple categories (for example, when classifying an image as a specific breed of dog).

## Coefficient of determination

A single number that indicates how well data fits a model. A value of 1 means that the model exactly matches the data. A value of 0 means that the data is random or otherwise cannot be fit to the model. This is often referred to as r<sup>2</sup>, R<sup>2</sup>, or r-squared.

## Feature

A measurable property of the phenomenon being measured, typically a numeric (double value). Multiple features are referred to as a **Feature vector** and typically stored as `double[]`. Features define the important characteristics about the phenomenon being measured. For more information see the [Feature](https://en.wikipedia.org/wiki/Feature_(machine_learning)) article on Wikipedia.

## Feature engineering

Feature engineering is the process of developing software that converts other data types (records, objects, …) into feature vectors. The resulting software performs Feature Extraction. For more information see the [Feature engineering](https://en.wikipedia.org/wiki/Feature_engineering) article on Wikipedia.

## F-score

A measure of a test's accuracy that balances [precision](#precision) and [recall](#recall).

## Hyperparameter

Parameters of machine learning algorithms. Examples include the number of trees to learn in a decision forest or the step size in a gradient descent algorithm. These parameters are called *Hyperparameters* because the process of learning is the process of identifying the right parameters of the prediction function. For example, the coefficients in a linear model or the comparison points in a tree. The process of finding those parameters is governed by the Hyperparameters. For more information see the [Hyperparameter](https://en.wikipedia.org/wiki/Hyperparameter) article on Wikipedia.

## Label

The element to be predicted with the machine learning model. For example, the breed of dog or a future stock price.

## Log loss

Loss refers to an algorithm and task-specific measure of accuracy of the model on the training data. Log loss is the logarithm of the same quantity.

## Mean absolute error (MAE)

An evaluation metric that averages all the model errors, where error is the predicted value distance from the true value.

## Model

Traditionally, the parameters for the prediction function. For example, the weights in a linear model or the split points in a tree. In ML.NET, a model contains all the information necessary to predict the label of a domain object (for example, image or text). This means that ML.NET models include the featurization steps necessary as well as the parameters for the prediction function.

## Multiclass classification

A [classification](#classification) case where the [label](#label) is one out of three or more classes. For more information, see the [Multiclass classification](https://en.wikipedia.org/wiki/Multiclass_classification) article on Wikipedia.

## N-grams

A feature extraction scheme for text data. Any sequence of N words turns into a [feature](#feature).

## Numerical feature vectors

A feature vector consisting only of numerical values. This is similar to double[].

## Pipeline

All of the operations needed to fit a model to a dataset. A pipeline consists of data import, transformation, featurization, and learning steps. Once a pipeline is trained, it turns into a model.

## Precision

The proportion of true results to positive results.

## Recall

The fraction of all correct results over all results.

## Regression

A supervised machine learning task where the output is a real value, for example, double. Examples include forecasting and predicting stock prices.

## Relative absolute error

An evaluation metric that represents the error as a percentage of the true value.

## Relative squared error

An evaluation metric that normalizes the total squared error by dividing by the predicted values' total squared error.

## Root of mean squared error (RMSE)

An evaluation metric that measures the average of the squares of the errors, and then takes the root of that value.

## Supervised machine learning

A subclass of machine learning in which a model is desired which predicts the label for yet-unseen data. Examples include classification, regression, and structured prediction. For more information see the  [Supervised learning](https://en.wikipedia.org/wiki/Supervised_learning) article on Wikipedia.

## Training

The process of identifying a model for a given training data set. For a linear model, this means finding the weights. For a tree, it involves the identifying the split points.

## Transform

A pipeline component that transforms data. For example, from text to vector of numbers.

## Unsupervised machine learning

A subclass of machine learning in which a model is desired which finds hidden (or latent) structure in the data. Examples include clustering, topic modeling, and dimensionality reduction. For more information see the [Unsupervised learning](https://en.wikipedia.org/wiki/Unsupervised_learning) article on Wikipedia.

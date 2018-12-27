---
title: Machine learning glossary - ML.NET
description: A glossary of important machine learning terms that are useful as you build your custom models in ML.NET.
ms.custom: seodec18
ms.date: 12/20/2018
---
# Machine learning glossary of important terms

The following list is a compilation of important machine learning terms that are useful as you build your custom models in ML.NET.

## Accuracy

In [classification](#classification), accuracy is the number of correctly classified items divided by the total number of items in the test set. Ranges from 0 (least accurate) to 1 (most accurate). Accuracy is one of evaluation metrics of the performance of your model. Consider it in conjunction with [precision](#precision), [recall](#recall), and [F-score](#f-score).

Related ML.NET API: <xref:Microsoft.ML.Legacy.Models.BinaryClassificationMetrics.Accuracy?displayProperty=nameWithType>.

## Area under the curve (AUC)

In [binary classification](#binary-classification), an evaluation metric that is the value of the area under the curve that plots the true positives rate (on the y-axis) against the false positives rate (on the x-axis). Ranges from 0.5 (worst) to 1 (best). Also known as the area under the ROC curve, i.e., receiver operating characteristic curve. For more information, see the [Receiver operating characteristic](https://en.wikipedia.org/wiki/Receiver_operating_characteristic) article on Wikipedia.

## Binary classification

A [classification](#classification) case where the [label](#label) is only one out of two classes. For more information, see the [Binary classification](tasks.md#binary-classification) section of the [Machine learning tasks](tasks.md) topic.

## Classification

When the data is used to predict a category, [supervised machine learning](#supervised-machine-learning) task is called classification. [Binary classification](#binary-classification) refers to predicting only two categories (for example, classifying an image as a picture of either a 'cat' or a 'dog'). [Multiclass classification](#multiclass-classification) refers to predicting multiple categories (for example, when classifying an image as a picture of a specific breed of dog).

## Coefficient of determination

In [regression](#regression), an evaluation metric that indicates how well data fits a model. Ranges from 0 to 1. A value of 0 means that the data is random or otherwise cannot be fit to the model. A value of 1 means that the model exactly matches the data. This is often referred to as r<sup>2</sup>, R<sup>2</sup>, or r-squared.

## Feature

A measurable property of the phenomenon being measured, typically a numeric (double) value. Multiple features are referred to as a **Feature vector** and typically stored as `double[]`. Features define the important characteristics of the phenomenon being measured. For more information, see the [Feature](https://en.wikipedia.org/wiki/Feature_(machine_learning)) article on Wikipedia.

## Feature engineering

Feature engineering is the process that involves defining a set of [features](#feature) and developing software that produces feature vectors from available phenomenon data, i.e., feature extraction. For more information, see the [Feature engineering](https://en.wikipedia.org/wiki/Feature_engineering) article on Wikipedia.

## F-score

In [classification](#classification), an evaluation metric that balances [precision](#precision) and [recall](#recall).

## Hyperparameter

A parameter of a machine learning algorithm. Examples include the number of trees to learn in a decision forest or the step size in a gradient descent algorithm. Values of *Hyperparameters* are set before training the model and govern the process of finding the parameters of the prediction function, for example, the comparison points in a decision tree or the weights in a linear regression model. For more information, see the [Hyperparameter](https://en.wikipedia.org/wiki/Hyperparameter_(machine_learning)) article on Wikipedia.

## Label

The element to be predicted with the machine learning model. For example, the breed of dog or a future stock price.

## Log loss

In [classification](#classification), an evaluation metric that characterizes the accuracy of a classifier. The smaller log loss is, the more accurate a classifier is.

## Mean absolute error (MAE)

In [regression](#regression), an evaluation metric that is the average of all the model errors, where model error is the distance between the predicted [label](#label) value and the correct label value.

## Model

Traditionally, the parameters for the prediction function. For example, the weights in a linear regression model or the split points in a decision tree. In ML.NET, a model contains all the information necessary to predict the [label](#label) of a domain object (for example, image or text). This means that ML.NET models include the featurization steps necessary as well as the parameters for the prediction function.

## Multiclass classification

A [classification](#classification) case where the [label](#label) is one out of three or more classes. For more information, see the [Multiclass classification](tasks.md#multiclass-classification) section of the [Machine learning tasks](tasks.md) topic.

## N-gram

A feature extraction scheme for text data: any sequence of N words turns into a [feature](#feature) value.

## Numerical feature vector

A [feature](#feature) vector consisting only of numerical values. This is similar to `double[]`.

## Pipeline

All of the operations needed to fit a model to a data set. A pipeline consists of data import, transformation, featurization, and learning steps. Once a pipeline is trained, it turns into a model.

## Precision

In [classification](#classification), the precision for a class is the number of items correctly predicted as belonging to that class divided by the total number of items predicted as belonging to the class.

Related ML.NET API: <xref:Microsoft.ML.Legacy.Models.BinaryClassificationMetrics.NegativePrecision?displayProperty=nameWithType>, <xref:Microsoft.ML.Legacy.Models.BinaryClassificationMetrics.PositivePrecision?displayProperty=nameWithType>.

## Recall

In [classification](#classification), the recall for a class is the number of items correctly predicted as belonging to that class divided by the total number of items that actually belong to the class.

## Regression

A [supervised machine learning](#supervised-machine-learning) task where the output is a real value, for example, double. Examples include predicting stock prices. For more information, see the [Regression](tasks.md#regression) section of the [Machine learning tasks](tasks.md) topic.

## Relative absolute error

In [regression](#regression), an evaluation metric that is the sum of all absolute errors divided by the sum of distances between correct [label](#label) values and the average of all correct label values.

## Relative squared error

In [regression](#regression), an evaluation metric that is the sum of all squared absolute errors divided by the sum of squared distances between correct [label](#label) values and the average of all correct label values.

## Root of mean squared error (RMSE)

In [regression](#regression), an evaluation metric that is the square root of the average of the squares of the errors.

## Supervised machine learning

A subclass of machine learning in which a desired model predicts the label for yet-unseen data. Examples include classification, regression, and structured prediction. For more information, see the  [Supervised learning](https://en.wikipedia.org/wiki/Supervised_learning) article on Wikipedia.

## Training

The process of identifying a [model](#model) for a given training data set. For a linear model, this means finding the weights. For a tree, it involves the identifying the split points.

## Transform

A [pipeline](#pipeline) component that transforms data. For example, from text to vector of numbers.

## Unsupervised machine learning

A subclass of machine learning in which a desired model finds hidden (or latent) structure in data. Examples include clustering, topic modeling, and dimensionality reduction. For more information, see the [Unsupervised learning](https://en.wikipedia.org/wiki/Unsupervised_learning) article on Wikipedia.

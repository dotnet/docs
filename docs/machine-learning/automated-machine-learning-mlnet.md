---
title: What is Automated Machine Learning (AutoML)?
description: Learn what automated machine learning is and its different components in ML.NETs
ms.date: 11/01/2022
ms.topic: overview
ms.custom: mvc
---

# What is Automated Machine Learning (AutoML)?

In this article, you learn what Automated Machine Learning (AutoML) is and its different components in ML.NET.  

Automated Machine Learning (AutoML) automates the model building process by making it easier to find the best algorithm for your scenario and dataset.

## Load data

When you load data into ML.NET, you usually have to define the schema. With AutoML, you can use data in a file to infer the schema. It does so by loading a subset of your data and using the data to determine what the data types are.

For a more customized data loading experiences, see [Load data from files and other sources](how-to-guides/load-data-ml-net.md)

## Data cleaning and preparation

Raw data is often messy and incomplete. Machine learning algorithms expect input (features) to be represented as numbers. Similarly, the value to predict (label), especially when it's categorical data, has to be encoded. Therefore one of the goals of data cleaning and preparation is to get the data into the format expected by machine learning algorithms.

Which transforms you apply to your data depend on the type of data you're working with (text, categorical, numerical, images).  

The process of taking raw input data and converting it into numerical data is often referred to as featurization. AutoML

## Model training

## Supported scenarios

- Classification
- Regression

For more information on machine learning tasks, [see machine learning tasks in ML.NET](resources/tasks.md)

## Experiments

To train models in ML.NET, you create an experiment.

An experiment is a collection of trials.

## Sweepable Pipelines

## Model evaluation

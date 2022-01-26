---
title: "How-To: Improve your ML.NET model"
description: Learn how to improve your ML.NET model
ms.date: 12/01/2021
author: luisquintanilla
ms.author: luquinta
ms.custom: mvc
ms.topic: how-to
#Customer intent: As a developer, I want to improve my ML.NET model.
---

# Improve your ML.NET model

Learn how to improve your ML.NET model.

## Reframe the problem

Sometimes, improving a model may have nothing to do with the data or techniques used to train the model. Instead, it may just be that the wrong question is being asked. Consider looking at the problem from different angles and leverage the data to extract latent indicators and hidden relationships in order to refine the question.

## Provide more data samples

Like humans, the more training algorithms get, the likelihood of better performance increases. One way to improve model performance is to provide more training data samples to the algorithms. The more data it learns from, the more cases it is able to correctly identify.

## Add context to the data

The meaning of a single data point can be difficult to interpret. Building context around the data points helps algorithms as well as subject matter experts better make decisions. For example, the fact that a house has three bedrooms does not on its own give a good indication of its price. However, if you add context and now know that it is in a suburban neighborhood outside of a major metropolitan area where average age is 38, average household income is $80,000 and schools are in the top 20th percentile then the algorithm has more information to base its decisions on. All of this context can be added as input to the machine learning model as features.

## Use meaningful data and features

Although more data samples and features can help improve the accuracy of the model, they may also introduce noise since not all data and features are meaningful. Therefore, it is important to understand which features are the ones that most heavily impact decisions made by the algorithm. Using techniques like Permutation Feature Importance (PFI) can help identify those salient features and not only help explain the model but also use the output as a feature selection method to reduce the amount of noisy features going into the training process.

For more information about using PFI, see [Explain model predictions using Permutation Feature Importance](../how-to-guides/explain-machine-learning-model-permutation-feature-importance-ml-net.md).

## Cross-validation

Cross-validation is a training and model evaluation technique that splits the data into several partitions and trains multiple algorithms on these partitions. This technique improves the robustness of the model by holding out data from the training process. In addition to improving performance on unseen observations, in data-constrained environments it can be an effective tool for training models with a smaller dataset.

Visit the following link to learn [how to use cross validation in ML.NET](../how-to-guides/train-machine-learning-model-cross-validation-ml-net.md)

## Hyperparameter tuning

Training machine learning models is an iterative and exploratory process. For example, what is the optimal number of clusters when training a model using the K-Means algorithm? The answer depends on many factors such as the structure of the data. Finding that number would require experimenting with different values for k and then evaluating performance to determine which value is best. The practice of tuning these parameters to find an optimal model is known as hyper-parameter tuning.

## Choose a different algorithm

Machine learning tasks like regression and classification contain various algorithm implementations. It may be the case that the problem you are trying to solve and the way your data is structured does not fit well into the current algorithm. In such case, consider using a different algorithm for your task to see if it learns better from your data.

The following link provides more [guidance on which algorithm to choose](../how-to-choose-an-ml-net-algorithm.md).

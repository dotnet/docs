---
title: How to choose an ML.NET algorithm
description: Learn how to choose an ML.NET algorithm for your machine learning model
author: natke
ms.topic: overview
ms.date: 06/05/2019
---

# How to choose an ML.NET algorithm

For each [ML.NET task](resources/tasks.md), there are multiple training algorithms to choose from. Which one to choose depends on the problem you are trying to solve, the characteristics of your data, and the compute and storage resources you have available. It is important to note that training a machine learning model is an iterative process. You might need to try multiple algorithms to find the one that works best.

Algorithms operate on **features**. Features are numerical values computed from your input data. They are optimal inputs for machine learning algorithms. You transform your raw input data into features using one or more [data transforms](resources/transforms.md). For example, text data is transformed into a set of word counts and word combination counts. Once the features have been extracted from a raw data type using data transforms, they are referred to as **featurized**. For example, featurized text, or featurized image data.

## Trainer = Algorithm + Task

An algorithm is the math that executes to produce a **model**. Different algorithms produce models with different characteristics. 

With ML.NET, the same algorithm can be applied to different tasks. For example, Stochastic Dual Coordinated Ascent can be used for Binary Classification, Multiclass Classification, and Regression. The difference is in how the output of the algorithm is interpreted to match the task. 

For each algorithm/task combination, ML.NET provides a component that executes the training algorithm and does the interpretation. These components are called trainers. For example, the <xref:Microsoft.ML.Trainers.SdcaRegressionTrainer> uses the **StochasticDualCoordinatedAscent** algorithm applied to the **Regression** task.

## Linear algorithms

Linear algorithms produce a model that calculates **scores** from a linear combination of the input data and a set of **weights**. The weights are parameters of the model estimated during training.

Linear algorithms work well for features that are [linearly separable](https://en.wikipedia.org/wiki/Linear_separability).

Before training with a linear algorithm, the features should be normalized. This prevents one feature having more influence over the result than others.

In general linear algorithms are scalable and fast, cheap to train, cheap to predict. They scale by the number of features and approximately by the size of the training data set.

Linear algorithms make multiple passes over the training data. If your dataset fits into memory, then adding a [cache checkpoint](xref:Microsoft.ML.LearningPipelineExtensions.AppendCacheCheckpoint*) to your ML.NET pipeline before appending the trainer, will make the training run faster.

**Linear Trainers**

|Algorithm|Properties|Trainers|
|---------|----------|--------|
|Averaged perceptron|Best for text classification|<xref:Microsoft.ML.Trainers.AveragedPerceptronTrainer>|
|Stochastic dual coordinated ascent|Tuning not needed for good default performance|<xref:Microsoft.ML.Trainers.SdcaLogisticRegressionBinaryTrainer> <xref:Microsoft.ML.Trainers.SdcaNonCalibratedBinaryTrainer> <xref:Microsoft.ML.Trainers.SdcaMaximumEntropyMulticlassTrainer> <xref:Microsoft.ML.Trainers.SdcaNonCalibratedMulticlassTrainer> <xref:Microsoft.ML.Trainers.SdcaRegressionTrainer>|
|L-BFGS|Use when number of features is large. Produces logistic regression training statistics, but doesn't scale as well as the AveragedPerceptronTrainer|<xref:Microsoft.ML.Trainers.LbfgsLogisticRegressionBinaryTrainer> <xref:Microsoft.ML.Trainers.LbfgsMaximumEntropyMulticlassTrainer> <xref:Microsoft.ML.Trainers.LbfgsPoissonRegressionTrainer>|
|Symbolic stochastic gradient descent|Fastest and most accurate linear binary classification trainer. Scales well with number of processors|<xref:Microsoft.ML.Trainers.SymbolicSgdLogisticRegressionBinaryTrainer>|

## Decision tree algorithms

Decision tree algorithms create a model that contains a series of decisions: effectively a flow chart through the data values.

Features do not need to be linearly separable to use this type of algorithm. And features do not need to be normalized, because the individual values in the feature vector are used independently in the decision process.

Decision tree algorithms are generally very accurate.

Except for Generalized Additive Models (GAMs), tree models can lack explainability when the number of features is large.

Decision tree algorithms take more resources and do not scale as well as linear ones do. They do perform well on datasets that can fit into memory.

Boosted decision trees are an ensemble of small trees where each tree scores the input data and passes the score onto the next tree to produce a better score, and so on, where each tree in the ensemble improves on the previous.

**Decision tree trainers**

|Algorithm|Properties|Trainers|
|---------|----------|--------|
|Light gradient boosted machine|Fastest and most accurate of the binary classification tree trainers. Highly tunable|<xref:Microsoft.ML.Trainers.LightGbm.LightGbmBinaryTrainer> <xref:Microsoft.ML.Trainers.LightGbm.LightGbmMulticlassTrainer> <xref:Microsoft.ML.Trainers.LightGbm.LightGbmRegressionTrainer> <xref:Microsoft.ML.Trainers.LightGbm.LightGbmRankingTrainer>|
|Fast tree|Use for featurized image data. Resilient to unbalanced data. Highly tunable | <xref:Microsoft.ML.Trainers.FastTree.FastTreeBinaryTrainer> <xref:Microsoft.ML.Trainers.FastTree.FastTreeRegressionTrainer> <xref:Microsoft.ML.Trainers.FastTree.FastTreeTweedieTrainer> <xref:Microsoft.ML.Trainers.FastTree.FastTreeRankingTrainer>|
|Fast forest|Works well with noisy data|<xref:Microsoft.ML.Trainers.FastTree.FastForestBinaryTrainer> <xref:Microsoft.ML.Trainers.FastTree.FastForestRegressionTrainer>|
|Generalized additive model (GAM)|Best for problems that perform well with tree algorithms but where explainability is a priority|<xref:Microsoft.ML.Trainers.FastTree.GamBinaryTrainer> <xref:Microsoft.ML.Trainers.FastTree.GamRegressionTrainer>|

## Matrix factorization

|Properties|Trainers|
|----------|--------|
|Best for sparse categorical data, with large datasets|<xref:Microsoft.ML.Trainers.FieldAwareFactorizationMachineTrainer>|

## Meta algorithms

These trainers create a multi-class trainer from a binary trainer. Use with <xref:Microsoft.ML.Trainers.AveragedPerceptronTrainer>, <xref:Microsoft.ML.Trainers.LbfgsLogisticRegressionBinaryTrainer>, <xref:Microsoft.ML.Trainers.SymbolicSgdLogisticRegressionBinaryTrainer>, <xref:Microsoft.ML.Trainers.LightGbm.LightGbmBinaryTrainer>, <xref:Microsoft.ML.Trainers.FastTree.FastTreeBinaryTrainer>, <xref:Microsoft.ML.Trainers.FastTree.FastForestBinaryTrainer>, <xref:Microsoft.ML.Trainers.FastTree.GamBinaryTrainer>.

|Algorithm|Properties|Trainers|
|---------|----------|--------|
|One versus all|This multiclass classifier trains one binary classifier for each class, which distinguishes that class from all other classes. Is limited in scale by the number of classes to categorize|[OneVersusAllTrainer\<BinaryClassificationTrainer>](xref:Microsoft.ML.Trainers.OneVersusAllTrainer) |
|Pairwise coupling|This multiclass classifier trains a binary classification algorithm on each pair of classes. Is limited in scale by the number of classes, as each combination of two classes must be trained.|[PairwiseCouplingTrainer\<BinaryClassificationTrainer>](xref:Microsoft.ML.Trainers.PairwiseCouplingTrainer)|

## K-Means

|Properties|Trainers|
|----------|--------|
|Use for clustering|<xref:Microsoft.ML.Trainers.KMeansTrainer>|

## Principal component analysis

|Properties|Trainers|
|----------|--------|
|Use for anomaly detection|<xref:Microsoft.ML.Trainers.RandomizedPcaTrainer>|

## Naive Bayes

|Properties|Trainers|
|----------|--------|
|Use this multi-class classification trainer when the features are independent, and the training dataset is small.|<xref:Microsoft.ML.Trainers.NaiveBayesMulticlassTrainer>|

## Prior Trainer

|Properties|Trainers|
|----------|--------|
|Use this binary classification trainer to baseline the performance of other trainers. To be effective, the metrics of the other trainers should be better than the prior trainer. |<xref:Microsoft.ML.Trainers.PriorTrainer>|

---
title: How to choose an ML.NET algorithm
description: Learn how to choose an ML.NET algorithm for your machine learning model
ms.topic: overview
ms.date: 03/31/2021
---

# How to choose an ML.NET algorithm

For each [ML.NET task](resources/tasks.md), there are multiple training algorithms to choose from. Which one to choose depends on the problem you are trying to solve, the characteristics of your data, and the compute and storage resources you have available. It is important to note that training a machine learning model is an iterative process. You might need to try multiple algorithms to find the one that works best.

Algorithms operate on **features**. Features are numerical values computed from your input data. They are optimal inputs for machine learning algorithms. You transform your raw input data into features using one or more [data transforms](resources/transforms.md). For example, text data is transformed into a set of word counts and word combination counts. Once the features have been extracted from a raw data type using data transforms, they are referred to as **featurized**. For example, featurized text, or featurized image data.

## Trainer = Algorithm + Task

An algorithm is the math that executes to produce a **model**. Different algorithms produce models with different characteristics.

With ML.NET, the same algorithm can be applied to different tasks. For example, Stochastic Dual Coordinate Ascent can be used for Binary Classification, Multiclass Classification, and Regression. The difference is in how the output of the algorithm is interpreted to match the task.

For each algorithm/task combination, ML.NET provides a component that executes the training algorithm and makes the interpretation. These components are called trainers. For example, the <xref:Microsoft.ML.Trainers.SdcaRegressionTrainer> uses the **StochasticDualCoordinatedAscent** algorithm applied to the **Regression** task.

## Linear algorithms

Linear algorithms produce a model that calculates **scores** from a linear combination of the input data and a set of **weights**. The weights are parameters of the model estimated during training.

Linear algorithms work well for features that are [linearly separable](https://en.wikipedia.org/wiki/Linear_separability).

Before training with a linear algorithm, the features should be normalized. This prevents one feature from having more influence over the result than others.

In general, linear algorithms are scalable, fast, cheap to train, and cheap to predict. They scale by the number of features and approximately by the size of the training data set.

Linear algorithms make multiple passes over the training data. If your dataset fits into memory, then adding a [cache checkpoint](xref:Microsoft.ML.LearningPipelineExtensions.AppendCacheCheckpoint%2A) to your ML.NET pipeline before appending the trainer will make the training run faster.

### Averaged perceptron

Best for text classification.

|Trainer|Task|ONNX Exportable|
|---------|----------|----------|
|<xref:Microsoft.ML.Trainers.AveragedPerceptronTrainer>|Binary classification|Yes|

### Stochastic dual coordinated ascent

Tuning not needed for good default performance.

|Trainer|Task|ONNX Exportable|
|---------|----------|----------|
|<xref:Microsoft.ML.Trainers.SdcaLogisticRegressionBinaryTrainer>|Binary classification|Yes|
|<xref:Microsoft.ML.Trainers.SdcaNonCalibratedBinaryTrainer>|Binary classification|Yes|
|<xref:Microsoft.ML.Trainers.SdcaMaximumEntropyMulticlassTrainer>|Multiclass classification|Yes|
|<xref:Microsoft.ML.Trainers.SdcaNonCalibratedMulticlassTrainer>|Multiclass classification|Yes|
|<xref:Microsoft.ML.Trainers.SdcaRegressionTrainer>|Regression|Yes|

### L-BFGS

Use when number of features is large. Produces logistic regression training statistics, but doesn't scale as well as the AveragedPerceptronTrainer.

|Trainer|Task|ONNX Exportable|
|---------|----------|----------|
|<xref:Microsoft.ML.Trainers.LbfgsLogisticRegressionBinaryTrainer>|Binary classification|Yes|
|<xref:Microsoft.ML.Trainers.LbfgsMaximumEntropyMulticlassTrainer>|Multiclass classification|Yes|
|<xref:Microsoft.ML.Trainers.LbfgsPoissonRegressionTrainer>|Regression|Yes|

### Symbolic stochastic gradient descent

Fastest and most accurate linear binary classification trainer. Scales well with number of processors.

|Trainer|Task|ONNX Exportable|
|---------|----------|----------|
|<xref:Microsoft.ML.Trainers.SymbolicSgdLogisticRegressionBinaryTrainer>|Binary classification|Yes|

### Online gradient descent

Implements the standard (non-batch) stochastic gradient descent, with a choice of loss functions, and an option to update the weight vector using the average of the vectors seen over time.

|Trainer|Task|ONNX Exportable|
|---------|----------|----------|
|<xref:Microsoft.ML.Trainers.OnlineGradientDescentTrainer>|Regression|Yes|

## Decision tree algorithms

Decision tree algorithms create a model that contains a series of decisions: effectively a flow chart through the data values.

Features do not need to be linearly separable to use this type of algorithm. And features do not need to be normalized, because the individual values in the feature vector are used independently in the decision process.

Decision tree algorithms are generally very accurate.

Except for Generalized Additive Models (GAMs), tree models can lack explainability when the number of features is large.

Decision tree algorithms take more resources and do not scale as well as linear ones do. They do perform well on datasets that can fit into memory.

Boosted decision trees are an ensemble of small trees where each tree scores the input data and passes the score onto the next tree to produce a better score, and so on, where each tree in the ensemble improves on the previous.

### Light gradient boosted machine

Fastest and most accurate of the binary classification tree trainers. Highly tunable.

|Trainer|Task|ONNX Exportable|
|---------|----------|----------|
|<xref:Microsoft.ML.Trainers.LightGbm.LightGbmBinaryTrainer>|Binary classification|Yes|
|<xref:Microsoft.ML.Trainers.LightGbm.LightGbmMulticlassTrainer>|Multiclass classification|Yes|
|<xref:Microsoft.ML.Trainers.LightGbm.LightGbmRegressionTrainer>|Regression|Yes|
|<xref:Microsoft.ML.Trainers.LightGbm.LightGbmRankingTrainer>|Ranking|No|

### Fast tree

Use for featurized image data. Resilient to unbalanced data. Highly tunable.

|Trainer|Task|ONNX Exportable|
|---------|----------|----------|
|<xref:Microsoft.ML.Trainers.FastTree.FastTreeBinaryTrainer>|Binary classification|Yes|
|<xref:Microsoft.ML.Trainers.FastTree.FastTreeRegressionTrainer>|Regression|Yes|
|<xref:Microsoft.ML.Trainers.FastTree.FastTreeTweedieTrainer>|Regression|Yes|
|<xref:Microsoft.ML.Trainers.FastTree.FastTreeRankingTrainer>|Ranking|No|

### Fast forest

Works well with noisy data.

|Trainer|Task|ONNX Exportable|
|---------|----------|----------|
|<xref:Microsoft.ML.Trainers.FastTree.FastForestBinaryTrainer>|Binary classification|Yes|
|<xref:Microsoft.ML.Trainers.FastTree.FastForestRegressionTrainer>|Regression|Yes|

### Generalized additive model (GAM)

Best for problems that perform well with tree algorithms but where explainability is a priority.

|Trainer|Task|ONNX Exportable|
|---------|----------|----------|
|<xref:Microsoft.ML.Trainers.FastTree.GamBinaryTrainer>|Binary classification|No|
|<xref:Microsoft.ML.Trainers.FastTree.GamRegressionTrainer>|Regression|No|

## Matrix factorization

### Matrix Factorization

Used for [collaborative filtering](https://en.wikipedia.org/wiki/Collaborative_filtering) in recommendation.

|Trainer|Task|ONNX Exportable|
|---------|----------|----------|
|<xref:Microsoft.ML.Trainers.MatrixFactorizationTrainer>|Recommendation|No|

### Field Aware Factorization Machine

 Best for sparse categorical data, with large datasets.

|Trainer|Task|ONNX Exportable|
|---------|----------|----------|
|<xref:Microsoft.ML.Trainers.FieldAwareFactorizationMachineTrainer>|Binary classification|No|

## Meta algorithms

These trainers create a multiclass trainer from a binary trainer. Use with <xref:Microsoft.ML.Trainers.AveragedPerceptronTrainer>, <xref:Microsoft.ML.Trainers.LbfgsLogisticRegressionBinaryTrainer>, <xref:Microsoft.ML.Trainers.SymbolicSgdLogisticRegressionBinaryTrainer>, <xref:Microsoft.ML.Trainers.LightGbm.LightGbmBinaryTrainer>, <xref:Microsoft.ML.Trainers.FastTree.FastTreeBinaryTrainer>, <xref:Microsoft.ML.Trainers.FastTree.FastForestBinaryTrainer>, <xref:Microsoft.ML.Trainers.FastTree.GamBinaryTrainer>.

### One versus all

This multiclass classifier trains one binary classifier for each class, which distinguishes that class from all other classes. Is limited in scale by the number of classes to categorize.

|Trainer|Task|ONNX Exportable|
|---------|----------|----------|
|<xref:Microsoft.ML.Trainers.OneVersusAllTrainer>|Multiclass classification|Yes|

### Pairwise coupling

This multiclass classifier trains a binary classification algorithm on each pair of classes. Is limited in scale by the number of classes, as each combination of two classes must be trained.

|Trainer|Task|ONNX Exportable|
|---------|----------|----------|
|<xref:Microsoft.ML.Trainers.PairwiseCouplingTrainer>|Multiclass classification|No|

## K-Means

Used for clustering.

|Trainer|Task|ONNX Exportable|
|---------|----------|----------|
|<xref:Microsoft.ML.Trainers.KMeansTrainer>|Clustering|Yes|

## Principal component analysis

Used for anomaly detection.

|Trainer|Task|ONNX Exportable|
|---------|----------|----------|
|<xref:Microsoft.ML.Trainers.RandomizedPcaTrainer>|Anomaly detection|No|

## Naive Bayes

Use this multi-class classification algorithm when the features are independent, and the training dataset is small.

|Trainer|Task|ONNX Exportable|
|---------|----------|----------|
|<xref:Microsoft.ML.Trainers.NaiveBayesMulticlassTrainer>|Multiclass classification|Yes|

## Prior Trainer

Use this binary classification algorithm to baseline the performance of other trainers. To be effective, the metrics of the other trainers should be better than the prior trainer.

|Trainer|Task|ONNX Exportable|
|---------|----------|----------|
|<xref:Microsoft.ML.Trainers.PriorTrainer>|Binary classification|Yes|

## Support vector machines

Support vector machines (SVMs) are an extremely popular and well-researched class of supervised learning models, which can be used in linear and non-linear classification tasks.

Recent research has focused on ways to optimize these models to efficiently scale to larger training sets.

### Linear SVM

Predicts a target using a linear binary classification model trained over boolean labeled data. Alternates between stochastic gradient descent steps and projection steps.

|Trainer|Task|ONNX Exportable|
|---------|----------|----------|
|<xref:Microsoft.ML.Trainers.LinearSvmTrainer>|Binary classification|Yes|

### Local Deep SVM

Predicts a target using a non-linear binary classification model. Reduces the prediction time cost; the prediction cost grows logarithmically with the size of the training set, rather than linearly, with a tolerable loss in classification accuracy.

|Trainer|Task|ONNX Exportable|
|---------|----------|----------|
|<xref:Microsoft.ML.Trainers.LdSvmTrainer>|Binary classification|Yes|

## Ordinary least squares

Ordinary least squares (OLS) is one of the most commonly used techniques in linear regression.

Ordinary least squares refers to the loss function, which computes error as the sum of the square of distance from the actual value to the predicted line, and fits the model by minimizing the squared error. This method assumes a strong linear relationship between the inputs and the dependent variable.

|Trainer|Task|ONNX Exportable|
|---------|----------|----------|
|<xref:Microsoft.ML.Trainers.OlsTrainer>|Regression|Yes|

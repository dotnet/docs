---
title: How to choose an ML.NET algorithm
description: Learn how to choose an ML.NET algorithm for your machine learning model
author: natke
ms.topic: overview
ms.date: 04/20/1029
---

# How to choose an ML.NET algorithm

Learn how to choose the best ML.NET algorithm for your application. 

For each [ML.NET task](resources/tasks.md), there are multiple training algorithms to choose from. Which one to choose depends on the problem you are trying to solve, the characteristics of your data, and the compute and storage resources you have available. It is important to note that training a machine learning model is an iterative process. You might need to try multiple algorithms to find the one that works best.

Algorithms operate on **features**. Features are numerical values computed from your input data. They are optimal inputs for machine learning algorithms. You transform your raw input data into features using one or more [data transforms](resources/transforms.md). For example, text data is transformed into a set of word counts and word combination counts. 

## Trainer = Algorithm + Task

With ML.NET, the same algorithm can be applied to different tasks. For example, Stochastic Descent Coordinated Ascent can be used for Binary Classification, Multiclass Classification, and Regression. The difference is in how the output of the algorithm is interpreted to match the task. 

For each algorithm/task combination, ML.NET provides a component that executes the training algorithm and does the interpretation. These components are called trainers. For example, the following trainers all use the Stochastic Descent Coordinated Ascent algorithm:

1. Regression

    Regression trainers produce ...

    - <xref:Microsoft.ML.Trainers.SdcaRegressionTrainer>

1. Binary Classification

    - <xref:Microsoft.ML.Trainers.SdcaNonCalibratedBinaryTrainer>
    - <xref:Microsoft.ML.Trainers.SdcaLogisticRegressionBinaryTrainer>

        Binary classification trainers produce ...

1. Multiclass Classification

    - <xref:Microsoft.ML.Trainers.SdcaNonCalibratedMulticlassTrainer>
    - <xref:Microsoft.ML.Trainers.SdcaMaximumEntropyMulticlassTrainer>

       Multiclass classification trainers produce ...

You will notice that there are more variants than just algorithm/task too. Hold that thought: we will cover that later in this article.

## Algorithm types

An algorithm is the math that executes to produce a **model**. Different algorithms produce models with different characteristics. 

- Linear

    Linear algorithms produce a model that calculates **scores** from a linear combination of the input data and a set of **weights**. The weights are parameters of the model estimated during training.

    Linear algorithms work well for features that are [linearly separable](https://en.wikipedia.org/wiki/Linear_separability).

    Before training with a linear algorithm, the features should be normalized. This prevents one feature having more influence over the result than others.

    In general linear algorithms are scalable and fast, cheap to train, cheap to predict. They scale by the number of features and approximately by the size of the training data set.

    You should always add a [cache checkpoint](xref:Microsoft.ML.LearningPipelineExtensions.AppendCacheCheckpoint*) to your ML.NET pipeline before appending the trainer. Linear algorithms make multiple passes over the training data. Adding a cache checkpoint will increase the training efficiency.

    - Regularization

        Regularization penalizes a linear model for being too complicated. There are two types of regularization:

        - $L-1$ regularization zeros weights for insignificant features. The size of the saved model may become smaller after this type of regularization.
        - $L-2$ regularization minimizes weight range for insignificant features, This is a more general process and is less sensitive to outliers.

        Some linear trainers perform both types of regularization, and some do neither, and some are configurable. The type(s) of regularization for each trainer is noted in the [trainer index](#trainer-index) below.

    - Calibration

        Calibration is the process of mapping a raw score onto a class membership, for binary and multiclass classification. Some ML.NET trainers have a `NonCalibrated` suffix. These algorithms produce a raw score that then must be mapped to a class probability. If you are able to use the raw score in your application, the non calibrated versions execute more efficiently.

- Boosted tree

    Decision tree algorithms create a model that contains a series of decisions: effectively a flow chart through the data values.

    Features do not need to be linearly separable to use this type of algorithm. And features do not need to be normalized, because the individual values in the feature vector are used independently in the decision process.

    Decision tree algorithms are generally very accurate.

    Depending on the number of features, tree models can lack explainability.

    Decision tree algorithms take more resources and do not scale as well as linear ones do. They do perform well on datasets that can fit into memory.

    Boosted decision trees are an ensemble of small trees where each tree scores the input data and passes the score onto the next tree to produce a better score, and so on, where each tree in the ensemble improves on the previous.

    These algorithms scale to 30000-100000 features and memory-bound for the size of the training set.

- Generalized additive model (GAM)

    Like decision tree algorithms, generalized additive model (GAM) algorithms also use trees.

    They bridge the gap between the explainability of linear models and tree models. 

- Matrix Factorization

    Matrix factorization algorithms handle large sparse data sets where there are categories involved.

- Ensemble

    Ensemble algorithms try multiple algorithms and return the one with the best results.

## Trainer Index

|Task|Trainer|Type|Properties|
|----|---------|----|----------|
|Binary Classification|<xref:Microsoft.ML.Trainers.AveragedPerceptronTrainer>|Linear| Works best with featurized text. Does not have l1-reg, does have l2-reg|
||<xref:Microsoft.ML.Trainers.LbfgsLogisticRegressionBinaryTrainer>|| Stores training data in memory. Doesn't scale as well as the AveragedPerceptronTrainer but produces proper logistic regression training statistics. Does not make multiple passes over data; has parameter to constrain weights to be positive only (bias is adjusted to make weights positive)|
||<xref:Microsoft.ML.Trainers.LinearSvmTrainer>|| This trainer does not perform regularization |
||<xref:Microsoft.ML.Trainers.SdcaLogisticRegressionBinaryTrainer>|| Auto-tunes hyper-parameters (l1, l2-regularization), so good performance out of the box |
||<xref:Microsoft.ML.Trainers.SdcaNonCalibratedBinaryTrainer>|| Autotunes hyper-parameters (l1, l2-regularization), so good performance out of the box. Slightly faster than the SdcaLogisticRegressionBinaryTrainer because it is uncalibrated |
||<xref:Microsoft.ML.Trainers.SymbolicSgdLogisticRegressionBinaryTrainer>|| Fastest and most accurate linear binary classification trainer. Scales well with number of processors. Performs l-2 regularization |
||<xref:Microsoft.ML.Trainers.LightGbm.LightGbmBinaryTrainer>|Boosted decision tree| Fastest and most accurate of the binary classifition tree trainers. Highly tunable |
||<xref:Microsoft.ML.Trainers.FastTree.FastTreeBinaryTrainer>|| Resilient to unbalanced data. Highly tunable |
||<xref:Microsoft.ML.Trainers.FastTree.FastForestBinaryTrainer>|||
||<xref:Microsoft.ML.Trainers.FastTree.GamBinaryTrainer>|GAM| Can control for bias in a model |
||<xref:Microsoft.ML.Trainers.FieldAwareFactorizationMachineTrainer>|| Gives independent treatment of one-hot encoded raw inputs. Can accept many feature columns |
|Multiclass Classification|<xref:Microsoft.ML.Trainers.LightGbm.LightGbmMulticlassTrainer>|Linear||
||<xref:Microsoft.ML.Trainers.SdcaMaximumEntropyMulticlassTrainer>|||
||<xref:Microsoft.ML.Trainers.SdcaNonCalibratedMulticlassTrainer>|||
||<xref:Microsoft.ML.Trainers.LbfgsMaximumEntropyMulticlassTrainer>|||
||<xref:Microsoft.ML.Trainers.NaiveBayesMulticlassTrainer>|Naive Bayes|Input features must <xref:System.Single> values that are interpreted as boolean values (greater than 0 being true, and less than or equal to zero being false|
||<xref:Microsoft.ML.Trainers.OneVersusAllTrainer>|Ensemble||Takes a binary classifier and trains all values within a class against all values not in that class, for all classes. Does not scale well with number of classes|
||<xref:Microsoft.ML.Trainers.PairwiseCouplingTrainer>||Similar to the OneVersusAllTrainer but takes pairs of classes at a time|
|Regression|<xref:Microsoft.ML.Trainers.LbfgsPoissonRegressionTrainer>|Linear||
||<xref:Microsoft.ML.Trainers.LightGbm.LightGbmRegressionTrainer>|||
||<xref:Microsoft.ML.Trainers.SdcaRegressionTrainer>|||
||<xref:Microsoft.ML.Trainers.OnlineGradientDescentTrainer>|||
||<xref:Microsoft.ML.Trainers.FastTree.FastTreeRegressionTrainer>|Boosted decision tree|Squared loss|
||<xref:Microsoft.ML.Trainers.FastTree.FastTreeTweedieTrainer>||Tweedie loss|
||<xref:Microsoft.ML.Trainers.FastTree.FastForestRegressionTrainer>||squared loss|
||<xref:Microsoft.ML.Trainers.FastTree.GamRegressionTrainer>|GAM||
|Clustering|<xref:Microsoft.ML.Trainers.KMeansTrainer>|K Means|Can also use it as a featurizer and then combined with a tree algorithm |
|Anomaly Detection|<xref:Microsoft.ML.Trainers.RandomizedPcaTrainer>|Principal Component Analysis||
|Ranking|<xref:Microsoft.ML.Trainers.LightGbm.LightGbmRankingTrainer>|Linear||
||<xref:Microsoft.ML.Trainers.FastTree.FastTreeRankingTrainer>|Boosted decision tree| Gives better performance than Light GBM|

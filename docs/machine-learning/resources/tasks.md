---
title: Machine learning tasks
description: Explore the different machine learning tasks and associated tasks that are supported in ML.NET.
ms.date: 07/01/2021
---
# Machine learning tasks in ML.NET

A machine learning task is the type of prediction or inference being made, based on the problem or question that is being asked, and the available data. For example, the classification task assigns data to categories, and the clustering task groups data according to similarity.

Machine learning tasks rely on patterns in the data rather than being explicitly programmed.

This article describes the different machine learning tasks that you can choose from in ML.NET and some common use cases.

Once you have decided which task works for your scenario, then you need to choose the best algorithm to train your model. The available algorithms are listed in the section for each task.

## Binary classification

A [supervised machine learning](glossary.md#supervised-machine-learning) task that is used to predict which of two classes (categories) an instance of data belongs to. The input of a classification algorithm is a set of labeled examples, where each label is an integer of either 0 or 1. The output of a binary classification algorithm is a classifier, which you can use to predict the class of new unlabeled instances. Examples of binary classification scenarios include:

* [Understanding sentiment of Twitter comments](../tutorials/sentiment-analysis.md) as either "positive" or "negative".
* Diagnosing whether a patient has a certain disease or not.
* Making a decision to mark an email as "spam" or not.
* Determining if a photo contains a particular item or not, such as a dog or fruit.

For more information, see the [Binary classification](https://en.wikipedia.org/wiki/Binary_classification) article on Wikipedia.

### Binary classification trainers

You can train a binary classification model using the following algorithms:

* <xref:Microsoft.ML.Trainers.AveragedPerceptronTrainer>
* <xref:Microsoft.ML.Trainers.SdcaLogisticRegressionBinaryTrainer>
* <xref:Microsoft.ML.Trainers.SdcaNonCalibratedBinaryTrainer>
* <xref:Microsoft.ML.Trainers.SymbolicSgdLogisticRegressionBinaryTrainer>
* <xref:Microsoft.ML.Trainers.LbfgsLogisticRegressionBinaryTrainer>
* <xref:Microsoft.ML.Trainers.LightGbm.LightGbmBinaryTrainer>
* <xref:Microsoft.ML.Trainers.FastTree.FastTreeBinaryTrainer>
* <xref:Microsoft.ML.Trainers.FastTree.FastForestBinaryTrainer>
* <xref:Microsoft.ML.Trainers.FastTree.GamBinaryTrainer>
* <xref:Microsoft.ML.Trainers.FieldAwareFactorizationMachineTrainer>
* <xref:Microsoft.ML.Trainers.PriorTrainer>
* <xref:Microsoft.ML.Trainers.LinearSvmTrainer>

### Binary classification inputs and outputs

For best results with binary classification, the training data should be balanced (that is, equal numbers of positive and negative training data). Missing values should be handled before training.

The input label column data must be <xref:System.Boolean>.
The input features column data must be a fixed-size vector of <xref:System.Single>.

These trainers output the following columns:

| Output Column Name | Column Type | Description|
| -- | -- | -- |
| `Score` | <xref:System.Single> | The raw score that was calculated by the model|
| `PredictedLabel` | <xref:System.Boolean> | The predicted label, based on the sign of the score. A negative score maps to `false` and a positive score maps to `true`.|

## Multiclass classification

A [supervised machine learning](glossary.md#supervised-machine-learning) task that is used to predict the class (category) of an instance of data. The input of a classification algorithm is a set of labeled examples. Each label normally starts as text. It is then run through the TermTransform, which converts it to the Key (numeric) type. The output of a classification algorithm is a classifier, which you can use to predict the class of new unlabeled instances. Examples of multi-class classification scenarios include:

* Categorizing flights as "early", "on time", or "late".
* Understanding movie reviews as "positive", "neutral", or "negative".
* Categorizing hotel reviews as "location", "price", "cleanliness", etc.

For more information, see the [Multiclass classification](https://en.wikipedia.org/wiki/Multiclass_classification) article on Wikipedia.

>[!NOTE]
>One vs all upgrades any [binary classification learner](#binary-classification) to act on multiclass datasets. More information on [Wikipedia](https://en.wikipedia.org/wiki/Multiclass_classification#One-vs.-rest).

### Multiclass classification trainers

You can train a multiclass classification model using the following training algorithms:

* <xref:Microsoft.ML.Trainers.LightGbm.LightGbmMulticlassTrainer>
* <xref:Microsoft.ML.Trainers.SdcaMaximumEntropyMulticlassTrainer>
* <xref:Microsoft.ML.Trainers.SdcaNonCalibratedMulticlassTrainer>
* <xref:Microsoft.ML.Trainers.LbfgsMaximumEntropyMulticlassTrainer>
* <xref:Microsoft.ML.Trainers.NaiveBayesMulticlassTrainer>
* <xref:Microsoft.ML.Trainers.OneVersusAllTrainer>
* <xref:Microsoft.ML.Trainers.PairwiseCouplingTrainer>

### Multiclass classification inputs and outputs

The input label column data must be [key](xref:Microsoft.ML.Data.KeyDataViewType) type.
The feature column must be a fixed size vector of <xref:System.Single>.

This trainer outputs the following:

| Output Name | Type | Description|
| -- | -- | -- |
| `Score` | Vector of <xref:System.Single> | The scores of all classes. Higher value means higher probability to fall into the associated class. If the i-th element has the largest value, the predicted label index would be i. Note that i is zero-based index. |
| `PredictedLabel` | [key](xref:Microsoft.ML.Data.KeyDataViewType) type | The predicted label's index. If its value is i, the actual label would be the i-th category in the key-valued input label type. |

## Regression

A [supervised machine learning](glossary.md#supervised-machine-learning) task that is used to predict the value of the label from a set of related features. The label can be of any real value and is not from a finite set of values as in classification tasks. Regression algorithms model the dependency of the label on its related features to determine how the label will change as the values of the features are varied. The input of a regression algorithm is a set of examples with labels of known values. The output of a regression algorithm is a function, which you can use to predict the label value for any new set of input features. Examples of regression scenarios include:

* Predicting house prices based on house attributes such as number of bedrooms, location, or size.
* Predicting future stock prices based on historical data and current market trends.
* Predicting sales of a product based on advertising budgets.

### Regression trainers

You can train a regression model using the following algorithms:

* <xref:Microsoft.ML.Trainers.LbfgsPoissonRegressionTrainer>
* <xref:Microsoft.ML.Trainers.LightGbm.LightGbmRegressionTrainer>
* <xref:Microsoft.ML.Trainers.SdcaRegressionTrainer>
* <xref:Microsoft.ML.Trainers.OlsTrainer>
* <xref:Microsoft.ML.Trainers.OnlineGradientDescentTrainer>
* <xref:Microsoft.ML.Trainers.FastTree.FastTreeRegressionTrainer>
* <xref:Microsoft.ML.Trainers.FastTree.FastTreeTweedieTrainer>
* <xref:Microsoft.ML.Trainers.FastTree.FastForestRegressionTrainer>
* <xref:Microsoft.ML.Trainers.FastTree.GamRegressionTrainer>

### Regression inputs and outputs

The input label column data must be <xref:System.Single>.

The trainers for this task output the following:

| Output Name | Type | Description|
| -- | -- | -- |
| `Score` | <xref:System.Single> | The raw score that was predicted by the model |

## Clustering

An [unsupervised machine learning](glossary.md#unsupervised-machine-learning) task that is used to group instances of data into clusters that contain similar characteristics. Clustering can also be used to identify relationships in a dataset that you might not logically derive by browsing or simple observation. The inputs and outputs of a clustering algorithm depends on the methodology chosen. You can take a distribution, centroid, connectivity, or density-based approach. ML.NET currently supports a centroid-based approach using K-Means clustering. Examples of clustering scenarios include:

* Understanding segments of hotel guests based on habits and characteristics of hotel choices.
* Identifying customer segments and demographics to help build targeted advertising campaigns.
* Categorizing inventory based on manufacturing metrics.

### Clustering trainer

You can train a clustering model using the following algorithm:

* <xref:Microsoft.ML.Trainers.KMeansTrainer>

### Clustering inputs and outputs

The input features data must be <xref:System.Single>. No labels are needed.

This trainer outputs the following:

| Output Name | Type | Description|
| -- | -- | -- |
| `Score` | vector of <xref:System.Single> | The distances of the given data point to all clusters' centriods |
| `PredictedLabel` | [key](xref:Microsoft.ML.Data.KeyDataViewType) type | The closest cluster's index predicted by the model. |

## Anomaly detection

This task creates an anomaly detection model by using Principal Component Analysis (PCA). PCA-Based Anomaly Detection helps you build a model in scenarios where it is easy to obtain training data from one class, such as valid transactions, but difficult to obtain sufficient samples of the targeted anomalies.

An established technique in machine learning, PCA is frequently used in exploratory data analysis because it reveals the inner structure of the data and explains the variance in the data. PCA works by analyzing data that contains multiple variables. It looks for correlations among the variables and determines the combination of values that best captures differences in outcomes. These combined feature values are used to create a more compact feature space called the principal components.

Anomaly detection encompasses many important tasks in machine learning:

* Identifying transactions that are potentially fraudulent.
* Learning patterns that indicate that a network intrusion has occurred.
* Finding abnormal clusters of patients.
* Checking values entered into a system.

Because anomalies are rare events by definition, it can be difficult to collect a representative sample of data to use for modeling. The algorithms included in this category have been especially designed to address the core challenges of building and training models by using imbalanced data sets.

### Anomaly detection trainer

You can train an anomaly detection model using the following algorithm:

* <xref:Microsoft.ML.Trainers.RandomizedPcaTrainer>

### Anomaly detection inputs and outputs

The input features must be a fixed-sized vector of <xref:System.Single>.

This trainer outputs the following:

| Output Name | Type | Description|
| -- | -- | -- |
| `Score` | <xref:System.Single> | The non-negative, unbounded score that was calculated by the anomaly detection model |
| `PredictedLabel` | <xref:System.Boolean> | A true/false value representing whether the input is an anomaly (PredictedLabel=true) or not (PredictedLabel=false) |

## Ranking

A ranking task constructs a ranker from a set of labeled examples. This example set consists of instance groups that can be scored with a given criteria. The ranking labels are { 0, 1, 2, 3, 4 } for each instance.  The ranker is trained to rank new instance groups with unknown scores for each instance. ML.NET ranking learners are [machine learned ranking](https://en.wikipedia.org/wiki/Learning_to_rank) based.

### Ranking training algorithms

You can train a ranking model with the following algorithms:

* <xref:Microsoft.ML.Trainers.LightGbm.LightGbmRankingTrainer>
* <xref:Microsoft.ML.Trainers.FastTree.FastTreeRankingTrainer>

### Ranking input and outputs

The input label data type must be [key](xref:Microsoft.ML.Data.KeyDataViewType)
type or <xref:System.Single>. The value of the label determines relevance, where
higher values indicate higher relevance. If the label is a
[key](xref:Microsoft.ML.Data.KeyDataViewType) type, then the key index is the
relevance value, where the smallest index is the least relevant. If the label is a
<xref:System.Single>, larger values indicate higher relevance.

The feature data must be a fixed size vector of <xref:System.Single> and input row group
column must be [key](xref:Microsoft.ML.Data.KeyDataViewType) type.

This trainer outputs the following:

| Output Name | Type | Description|
| -- | -- | -- |
| `Score` | <xref:System.Single> | The unbounded score that was calculated by the model to determine the prediction |

## Recommendation

A recommendation task enables producing a list of recommended products or services. ML.NET uses [Matrix factorization (MF)](https://en.wikipedia.org/wiki/Matrix_factorization_%28recommender_systems%29), a [collaborative filtering](https://en.wikipedia.org/wiki/Collaborative_filtering) algorithm for recommendations when you have historical product rating data in your catalog. For example, you have historical movie rating data for your users and want to recommend  other movies they are likely to watch next.

### Recommendation training algorithms

You can train a recommendation model with the following algorithm:

* <xref:Microsoft.ML.Trainers.MatrixFactorizationTrainer>

## Forecasting

The forecasting task use past time-series data to make predictions about future behavior. Scenarios applicable to forecasting include weather forecasting, seasonal sales predictions, and predictive maintenance,

### Forecasting trainers

You can train a forecasting model with the following algorithm:

<xref:Microsoft.ML.TimeSeriesCatalog.ForecastBySsa%2A>

## Image Classification

A [supervised machine learning](glossary.md#supervised-machine-learning) task that is used to predict the class (category) of an image. The input is a set of labeled examples. Each label normally starts as text. It is then run through the TermTransform, which converts it to the Key (numeric) type. The output of the image classification algorithm is a classifier, which you can use to predict the class of new images. The image classification task is a type of multiclass classification. Examples of image classification scenarios include:

* Determining the breed of a dog as a "Siberian Husky", "Golden Retriever", "Poodle", etc.
* Determining if a manufacturing product is defective or not.
* Determining what types of flowers as "Rose", "Sunflower", etc.

### Image classification trainers

You can train an image classification model using the following training algorithms:

* <xref:Microsoft.ML.Vision.ImageClassificationTrainer>

### Image classification inputs and outputs

The input label column data must be [key](xref:Microsoft.ML.Data.KeyDataViewType) type.
The feature column must be a variable-sized vector of <xref:System.Byte>.

This trainer outputs the following columns:

| Output Name | Type | Description|
| -- | -- | -- |
| `Score` | <xref:System.Single> | The scores of all classes.Higher value means higher probability to fall into the associated class. If the i-th element has the largest value, the predicted label index would be i.Note that i is zero-based index. |
| `PredictedLabel` | [Key](xref:Microsoft.ML.Data.KeyDataViewType) type | The predicted label's index. If its value is i, the actual label would be the i-th category in the key-valued input label type. |

## Object Detection

A [supervised machine learning](glossary.md#supervised-machine-learning) task that is used to predict the class (category) of an image but also gives a bounding box to where that category is within the image. Instead of classifying a single object in an image, object detection can detect multiple objects within an image. Examples of object detection include:

* Detecting cars, signs, or people on images of a road.
* Detecting defects on images of products.
* Detecting areas of concern on X-Ray images.

Object detection model training is currently only available in [Model Builder](../automate-training-with-model-builder.md) using Azure Machine Learning.

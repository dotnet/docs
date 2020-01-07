---
title: Data transformations
description: Explore the feature engineering components supported in ML.NET.
author: natke
ms.author: nakersha
ms.date: 04/02/2019
---

# Data transformations

Data transformations are used to:

- prepare data for model training
- apply an imported model in TensorFlow or ONNX format
- post-process data after it has been passed through a model

The transformations in this guide return classes that implement the [IEstimator](xref:Microsoft.ML.IEstimator%601) interface. Data transformations can be chained together. Each transformation both expects and produces data of specific types and formats, which are specified in the linked reference documentation.

Some data transformations require training data to calculate their parameters. For example: the <xref:Microsoft.ML.NormalizationCatalog.NormalizeMeanVariance%2A> transformer calculates the mean and variance of the training data during the `Fit()` operation, and uses those parameters in the `Transform()` operation.

Other data transformations don't require training data. For example: the <xref:Microsoft.ML.ImageEstimatorsCatalog.ConvertToGrayscale%2A> transformation can perform the `Transform()` operation without having seen any training data during the `Fit()` operation.

## Column mapping and grouping

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.TransformExtensionsCatalog.Concatenate%2A> | Concatenate one or more input columns into a new output column |
| <xref:Microsoft.ML.TransformExtensionsCatalog.CopyColumns%2A> | Copy and rename one or more input columns |
| <xref:Microsoft.ML.TransformExtensionsCatalog.DropColumns%2A> | Drop one or more input columns |
| <xref:Microsoft.ML.TransformExtensionsCatalog.SelectColumns%2A> | Select one or more columns to keep from the input data |

## Normalization and scaling

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.NormalizationCatalog.NormalizeMeanVariance%2A> | Subtract the mean (of the training data) and divide by the variance (of the training data) |
| <xref:Microsoft.ML.NormalizationCatalog.NormalizeLogMeanVariance%2A> | Normalize based on the logarithm of the training data |
| <xref:Microsoft.ML.NormalizationCatalog.NormalizeLpNorm%2A> | Scale input vectors by their [lp-norm](https://en.wikipedia.org/wiki/Lp_space#The_p-norm_in_finite_dimensions), where p is 1, 2 or infinity. Defaults to the l2 (Euclidean distance) norm |
| <xref:Microsoft.ML.NormalizationCatalog.NormalizeGlobalContrast%2A> | Scale each value in a row by subtracting the mean of the row data and divide by either the standard deviation or l2-norm (of the row data), and multiply by a configurable scale factor (default 2) |
| <xref:Microsoft.ML.NormalizationCatalog.NormalizeBinning%2A> | Assign the input value to a bin index and divide by the number of bins to produce a float value between 0 and 1. The bin boundaries are calculated to evenly distribute the training data across bins |
| <xref:Microsoft.ML.NormalizationCatalog.NormalizeSupervisedBinning%2A> | Assign the input value to a bin based on its correlation with label column |
| <xref:Microsoft.ML.NormalizationCatalog.NormalizeMinMax%2A> | Scale the input by the difference between the minimum and maximum values in the training data |

## Conversions between data types

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.ConversionsExtensionsCatalog.ConvertType%2A> | Convert the type of an input column to a new type |
| <xref:Microsoft.ML.ConversionsExtensionsCatalog.MapValue%2A> | Map values to keys (categories) based on the supplied dictionary of mappings |
| <xref:Microsoft.ML.ConversionsExtensionsCatalog.MapValueToKey%2A> | Map values to keys (categories) by creating the mapping from the input data |
| <xref:Microsoft.ML.ConversionsExtensionsCatalog.MapKeyToValue%2A> | Convert keys back to their original values |
| <xref:Microsoft.ML.ConversionsExtensionsCatalog.MapKeyToVector%2A> | Convert keys back to vectors of original values |
| <xref:Microsoft.ML.ConversionsCatalog.MapKeyToBinaryVector%2A> | Convert keys back to a binary vector of original values |
| <xref:Microsoft.ML.ConversionsExtensionsCatalog.Hash%2A> | Hash the value in the input column |

## Text transformations

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.TextCatalog.FeaturizeText%2A> | Transform a text column into a float array of normalized ngrams and char-grams counts |
| <xref:Microsoft.ML.TextCatalog.TokenizeIntoWords%2A> | Split one or more text columns into individual words |
| <xref:Microsoft.ML.TextCatalog.TokenizeIntoCharactersAsKeys%2A> | Split one or more text columns into individual characters floats over a set of topics |
| <xref:Microsoft.ML.TextCatalog.NormalizeText%2A> | Change case, remove diacritical marks, punctuation marks, and numbers |
| <xref:Microsoft.ML.TextCatalog.ProduceNgrams%2A> | Transform text column into a bag of counts of ngrams (sequences of consecutive words)|
| <xref:Microsoft.ML.TextCatalog.ProduceWordBags%2A> | Transform text column into a bag of counts of ngrams vector |
| <xref:Microsoft.ML.TextCatalog.ProduceHashedNgrams%2A> | Transform text column into a vector of hashed ngram counts |
| <xref:Microsoft.ML.TextCatalog.ProduceHashedWordBags%2A> | Transform text column into a bag of hashed ngram counts |
| <xref:Microsoft.ML.TextCatalog.RemoveDefaultStopWords%2A>  | Remove default stop words for the specified language from input columns |
| <xref:Microsoft.ML.TextCatalog.RemoveStopWords%2A> | Removes specified stop words from input columns |
| <xref:Microsoft.ML.TextCatalog.LatentDirichletAllocation%2A> | Transform a document (represented as a vector of floats) into a vector of floats over a set of topics |
| <xref:Microsoft.ML.TextCatalog.ApplyWordEmbedding%2A> | Convert vectors of text tokens into sentence vectors using a pre-trained model |

## Image transformations

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.ImageEstimatorsCatalog.ConvertToGrayscale%2A> | Convert an image to grayscale |
| <xref:Microsoft.ML.ImageEstimatorsCatalog.ConvertToImage%2A> | Convert a vector of pixels to <xref:Microsoft.ML.Transforms.Image.ImageDataViewType> |
| <xref:Microsoft.ML.ImageEstimatorsCatalog.ExtractPixels%2A> | Convert pixels from input image into a vector of numbers |
| <xref:Microsoft.ML.ImageEstimatorsCatalog.LoadImages%2A> | Load images from a folder into memory |
| <xref:Microsoft.ML.ImageEstimatorsCatalog.ResizeImages%2A> | Resize images |
| <xref:Microsoft.ML.OnnxCatalog.DnnFeaturizeImage%2A> | Applies a pre-trained deep neural network (DNN) model to transform an input image into a feature vector |

## Categorical data transformations

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.CategoricalCatalog.OneHotEncoding%2A> | Convert one or more text columns into [one-hot](https://en.wikipedia.org/wiki/One-hot) encoded vectors |
| <xref:Microsoft.ML.CategoricalCatalog.OneHotHashEncoding%2A> | Convert one or more text columns into hash-based one-hot encoded vectors |

## Time series data transformations

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.TimeSeriesCatalog.DetectAnomalyBySrCnn%2A> | Detect anomalies in the input time series data using the Spectral Residual (SR) algorithm |
| <xref:Microsoft.ML.TimeSeriesCatalog.DetectChangePointBySsa%2A> | Detect change points in time series data using singular spectrum analysis (SSA) |
| <xref:Microsoft.ML.TimeSeriesCatalog.DetectIidChangePoint%2A> | Detect change points in independent and identically distributed (IID) time series data using adaptive kernel density estimations and martingale scores |
| <xref:Microsoft.ML.TimeSeriesCatalog.ForecastBySsa%2A> | Forecast time series data using singular spectrum analysis (SSA) |
| <xref:Microsoft.ML.TimeSeriesCatalog.DetectSpikeBySsa%2A> | Detect spikes in time series data using singular spectrum analysis (SSA) |
| <xref:Microsoft.ML.TimeSeriesCatalog.DetectIidSpike%2A> | Detect spikes in independent and identically distributed (IID) time series data using adaptive kernel density estimations and martingale scores |

## Missing values

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.ExtensionsCatalog.IndicateMissingValues%2A> | Create a new boolean output column, the value of which is true when the value in the input column is missing |
| <xref:Microsoft.ML.ExtensionsCatalog.ReplaceMissingValues%2A> | Create a new output column, the value of which is set to a default value if the value is missing from the input column, and the input value otherwise |

## Feature selection

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.FeatureSelectionCatalog.SelectFeaturesBasedOnCount%2A> | Select features whose non-default values are greater than a threshold |
| <xref:Microsoft.ML.FeatureSelectionCatalog.SelectFeaturesBasedOnMutualInformation%2A> | Select the features on which the data in the label column is most dependent |

## Feature transformations

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.KernelExpansionCatalog.ApproximatedKernelMap%2A> | Map each input vector onto a lower dimensional feature space, where inner products approximate a kernel function, so that the features can be used as inputs to the linear algorithms |
| <xref:Microsoft.ML.PcaCatalog.ProjectToPrincipalComponents%2A> | Reduce the dimensions of the input feature vector by applying the Principal Component Analysis algorithm |

## Explainability transformations

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.ExplainabilityCatalog.CalculateFeatureContribution%2A> | Calculate contribution scores for each element of a feature vector |

## Calibration transformations

| Transform | Definition |
| --- | --- |
|<xref:Microsoft.ML.BinaryClassificationCatalog.CalibratorsCatalog.Platt%28System.String%2CSystem.String%2CSystem.String%29> | Transforms a binary classifier raw score into a class probability using logistic regression with parameters estimated using the training data |
| <xref:Microsoft.ML.BinaryClassificationCatalog.CalibratorsCatalog.Platt%28System.Double%2CSystem.Double%2CSystem.String%29> | Transforms a binary classifier raw score into a class probability using logistic regression with fixed parameters |
| <xref:Microsoft.ML.BinaryClassificationCatalog.CalibratorsCatalog.Naive%2A> | Transforms a binary classifier raw score into a class probability by assigning scores to bins, and calculating the probability based on the distribution among the bins |
| <xref:Microsoft.ML.BinaryClassificationCatalog.CalibratorsCatalog.Isotonic%2A> | Transforms a binary classifier raw score into a class probability by assigning scores to bins, where the position of boundaries and the size of bins are estimated using the training data  |

## Deep learning transformations

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.OnnxCatalog.ApplyOnnxModel%2A> | Transform the input data with an imported ONNX model |
| <xref:Microsoft.ML.TensorflowCatalog.LoadTensorFlowModel%2A> | Transform the input data with an imported TensorFlow model |

## Custom transformations

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.CustomMappingCatalog.CustomMapping%2A> | Transform existing columns onto new ones with a user-defined mapping |

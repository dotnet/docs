---
title: Data transformations | ML.NET
description: Explore the feature engineering components supported in ML.NET.
author: natke
ms.author: nakersha
ms.date: 04/02/2019
---

# Data transformations

Data transformations are used to prepare data for model training. The transformations in this guide return classes that implement the [IEstimator](xref:Microsoft.ML.IEstimator`1) interface. Data transformations may also be chained together. When chained, the specific data transformation class determines the data type and format the transformer expects from the previous element in the chain, and also the data type and format the transformation produces.

Some data transformations require training data to calculate their parameters. For example: the <xref:Microsoft.ML.NormalizationCatalog.NormalizeMeanVariance%2A> transformer calculates the mean and variance of the training data during the `Fit()` operation, and uses those parameters in the `Transform()` operation. 

Other data transformations don't require training data. For example: the <xref:Microsoft.ML.ImageEstimatorsCatalog.ConvertToGrayscale*> transformation can perform the `Transform()` operation without having seen any training data during the `Fit()` operation.

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
| <xref:Microsoft.ML.ConversionsExtensionsCatalog.MapValue*> | Map values to keys (categories) based on the supplied dictionary of mappings |
| <xref:Microsoft.ML.ConversionsExtensionsCatalog.MapValueToKey*> | Map values to keys (categories) by creating the mapping from the input data |
| <xref:Microsoft.ML.ConversionsExtensionsCatalog.MapKeyToValue*> | Convert keys back to their original values |
| <xref:Microsoft.ML.ConversionsExtensionsCatalog.MapKeyToVector*> | Convert keys back to vectors of original values |
| <xref:Microsoft.ML.ConversionsCatalog.MapKeyToBinaryVector*> | Convert keys back to a binary vector of original values |
| <xref:Microsoft.ML.ConversionsExtensionsCatalog.Hash*> | Hash the value in the input column |

## Text transformations

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.TextCatalog.FeaturizeText*> | Transform a text column into a float array of normalized ngrams and char-grams counts | 
| <xref:Microsoft.ML.TextCatalog.TokenizeIntoWords*> | Split one or more text columns into individual words |
| <xref:Microsoft.ML.TextCatalog.TokenizeIntoCharactersAsKeys*> | Split one or more text columns into individual characters floats over a set of topics |
| <xref:Microsoft.ML.TextCatalog.NormalizeText*> | Change case, remove diacritical marks, punctuation marks and numbers |
| <xref:Microsoft.ML.TextCatalog.ProduceNgrams*> | Transform text column into a bag of counts of ngrams (sequences of consecutive words)|
| <xref:Microsoft.ML.TextCatalog.ProduceWordBags*> | Transform text column into a bag of counts of ngrams vector |
| <xref:Microsoft.ML.TextCatalog.ProduceHashedNgrams*> | Transform text column into a vector of hashed ngram counts |
| <xref:Microsoft.ML.TextCatalog.ProduceHashedWordBags*> | Transform text column into a bag of hashed ngram counts |
| <xref:Microsoft.ML.TextCatalog.RemoveDefaultStopWords*>  | Remove default stop words for the specified language from input columns |
| <xref:Microsoft.ML.TextCatalog.RemoveStopWords*> | Removes specified stop words from input columns |
| <xref:Microsoft.ML.TextCatalog.LatentDirichletAllocation*> | Transform a document (represented as a vector of floats) into a vector of floats over a set of topics |
| <xref:Microsoft.ML.TextCatalog.ApplyWordEmbedding*> | Convert vectors of text tokens into sentence vectors using a pre-trained model |

## Image transformations

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.ImageEstimatorsCatalog.ConvertToGrayscale*> | Convert an image to grayscale |
| <xref:Microsoft.ML.ImageEstimatorsCatalog.ConvertToImage*> | Convert a vector of pixels to <xref:Microsoft.ML.Transforms.Image.ImageDataViewType> |
| <xref:Microsoft.ML.ImageEstimatorsCatalog.ExtractPixels*> | Convert pixels from input image into a vector of numbers |
| <xref:Microsoft.ML.ImageEstimatorsCatalog.LoadImages*> | Load images from a folder into memory |
| <xref:Microsoft.ML.ImageEstimatorsCatalog.ResizeImages*> | Resize images |

## Categorical data transformations

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.CategoricalCatalog.OneHotEncoding*> | Convert one or more text columns into [one-hot](https://en.wikipedia.org/wiki/One-hot) encoded vectors |
| <xref:Microsoft.ML.CategoricalCatalog.OneHotHashEncoding*> | Convert one more text columns into hash-based one-hot encoded vectors |

## Missing values

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.ExtensionsCatalog.IndicateMissingValues*> | Create a new boolean output column, the value of which is true when the value in the input column is missing |
| <xref:Microsoft.ML.ExtensionsCatalog.ReplaceMissingValues*> | Create a new output column, the value of which is set to a default value if the value is missing from the input column, and the input value otherwise |

## Feature selection

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.FeatureSelectionCatalog.SelectFeaturesBasedOnCount*> | Select features whose non-default values are greater than a threshold |
| <xref:Microsoft.ML.FeatureSelectionCatalog.SelectFeaturesBasedOnMutualInformation*> | Select the features on which the data in the label column is most dependent |

## Custom transformations

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.CustomMappingCatalog.CustomMapping*> | Transform existing columns onto new ones with a user-defined mapping |

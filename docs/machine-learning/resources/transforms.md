---
title: Machine learning data transforms - ML.NET
description: Explore the feature engineering components supported in ML.NET.
author: JRAlexander
ms.custom: seodec18
ms.date: 01/14/2019
---
# Machine learning data transforms - ML.NET

The following tables contain information about all of the data transforms supported in ML.NET.

> [!NOTE]
> ML.NET is currently in Preview. Not all data transforms are currently supported. To submit a request for a certain transform, open an issue in the [dotnet/machinelearning](https://github.com/dotnet/machinelearning/issues) GitHub repository.

## Combiners and segregators

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.Transforms.GroupTransform> | Groups values of a scalar column into a vector based on a contiguous group ID. |
| <xref:Microsoft.ML.Transforms.UngroupTransform> | Un-groups vector columns into sequences of rows, inverse of Group transform. |

## Conversions 

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.Transforms.Conversions.HashingTransformer> | Hashes either single valued columns or vector columns. For vector columns, it hashes each slot separately. It can hash either text values or key values. |
| <xref:Microsoft.ML.Transforms.Conversions.HashJoiningTransform> | Converts multiple column values into hashes. This transform accepts both numeric and text inputs, both single and vector-valued columns. |
| <xref:Microsoft.ML.Transforms.Conversions.KeyToBinaryVectorMappingTransformer> | Converts a key to a binary vector column. |
| <xref:Microsoft.ML.Transforms.Conversions.KeyToValueMappingTransformer > | Utilizes KeyValues metadata to map key indices to the corresponding values in the KeyValues metadata. |
| <xref:Microsoft.ML.Transforms.Conversions.KeyToVectorMappingTransformer> | Converts a key to a vector column. |
| <xref:Microsoft.ML.Transforms.Conversions.TypeConvertingTransformer> | Changes underlying column type provided the type can be converted. |
| <xref:Microsoft.ML.Transforms.Conversions.ValueToKeyMappingTransformer> | Converts input values (words, numbers, etc.) to index in a dictionary. |


## Deep learning

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.Transforms.OnnxTransform> | Provides data to an existing ONNX model and returns the score (prediction). |
| <xref:Microsoft.ML.Transforms.TensorFlowTransform> | Can either score with pretrained TensorFlow model or retrain TensorFlow model. |

## Feature extraction

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.Transforms.Text.CustomStopWordsRemovingTransform> | Removes specified list of stop words by comparing individual tokens (case-insensitive comparison) to the stopwords.| 
| <xref:Microsoft.ML.ImageAnalytics.ImageGrayscaleTransform> | Takes one or more ImageType columns and converts them to a greyscale representation of the same image.|
| <xref:Microsoft.ML.ImageAnalytics.ImageLoaderTransform> | Takes one or more ReadOnlyMemory columns and loads them as an ImageType. |
| <xref:Microsoft.ML.ImageAnalytics.ImagePixelExtractorTransform> | Takes one or more ImageType columns and converts them into a vector representation.|
| <xref:Microsoft.ML.ImageAnalytics.ImageResizerTransform> | Takes one or more ImageType columns and resizes them to  the provided height and width.|
| <xref:Microsoft.ML.Transforms.Text.LatentDirichletAllocationTransformer> | Implements LightLDA, a state-of-the-art implementation of Latent Dirichlet Allocation.|
| <xref:Microsoft.ML.Transforms.LoadTransform> | Loads specific transforms from the specified model file. Allows for 'cherry picking' transforms from a serialized chain, or to apply a pre-trained transform to a different (but still compatible) data view. |
| <xref:Microsoft.ML.Transforms.Text.NgramExtractingTransformer> | Produces a bag of counts of ngrams (sequences of consecutive values of length 1-n) in a given vector of keys. It does so by building a dictionary of ngrams and using the id in the dictionary as the index in the bag. | 
| <xref:Microsoft.ML.Transforms.Text.NgramExtractorTransform> | Turns a collection of tokenized text (vector of ReadOnlyMemory), or vectors of keys into numerical feature vectors. The feature vectors are counts of ngrams (sequences of consecutive tokens -words or keys- of length 1-n). | 
| <xref:Microsoft.ML.Transforms.Text.NgramHashExtractingTransformer> | Turns a collection of tokenized text (vector of ReadOnlyMemory) into numerical feature vectors using hashing. | 
| <xref:Microsoft.ML.Transforms.Text.NgramHashingTransformer> | Produces a bag of counts of ngrams (sequences of consecutive words of length 1-n) in a given text. | 
| <xref:Microsoft.ML.Transforms.Categorical.OneHotEncodingTransformer> | Converts the categorical value into an indicator array by building a dictionary of categories based on the data and using the id in the dictionary as the index in the array |
| <xref:Microsoft.ML.Transforms.Projections.PcaTransform> | Computes the projection of the feature vector onto a low-rank subspace. |
| <xref:Microsoft.ML.Transforms.Text.SentimentAnalyzingTransformer> | Uses a pretrained sentiment model to score input strings. |
| <xref:Microsoft.ML.Transforms.Text.StopWordsRemovingTransformer> | Removes language-specific list of stop words (most common words) by comparing individual tokens (case-insensitive comparison) to the stopwords. |
| <xref:Microsoft.ML.Transforms.Categorical.TermLookupTransformer> | Maps text values columns to new columns using a map dataset provided through its arguments. |
| <xref:Microsoft.ML.Transforms.Text.WordBagBuildingTransformer> | Produces a bag of counts of ngrams (sequences of consecutive words) in a given text. It does so by building a dictionary of ngrams and using the id in the dictionary as the index in the bag. |
| <xref:Microsoft.ML.Transforms.Text.WordHashBagProducingTransformer> | Produces a bag of counts of ngrams (sequences of consecutive words of length 1-n) in a given text. It does so by hashing each ngram and using the hash value as the index in the bag. |
| <xref:Microsoft.ML.Transforms.Text.WordTokenizingTransformer> | Splits the text into words using the separator character(s). |


## Image model featurizers

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.Transforms.AlexNetExtension> | This is an extension method to be used with the <xref:Microsoft.ML.Transforms.DnnImageFeaturizerEstimator> in order to use a pretrained [AlexNet](https://en.wikipedia.org/wiki/AlexNet) model. The NuGet containing this extension is also guaranteed to include the binary model file. | 
| <xref:Microsoft.ML.Transforms.ResNet18Extension> | This is an extension method to be used with the <xref:Microsoft.ML.Transforms.DnnImageFeaturizerEstimator> to use a pretrained ResNet18 model. The NuGet containing this extension is also guaranteed to include the binary model file. |
| <xref:Microsoft.ML.Transforms.ResNet50Extension> | This is an extension method to be used with the <xref:Microsoft.ML.Transforms.DnnImageFeaturizerEstimator> to use a pretrained ResNet50model. The NuGet containing this extension is also guaranteed to include the binary model file. |
| <xref:Microsoft.ML.Transforms.ResNet101Extension> | This is an extension method to be used with the <xref:Microsoft.ML.Transforms.DnnImageFeaturizerEstimator> to use a pretrained ResNet101 model. The NuGet containing this extension is also guaranteed to include the binary model file. |

## Label parsing

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.Transforms.LabelConvertTransform> |  Converts labels. |
| <xref:Microsoft.ML.Transforms.LabelIndicatorTransform> | Remaps multiclass labels to binary True, False labels, primarily for use with OVA.|

## Missing values

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.Transforms.MissingValueDroppingTransformer> | Drops missing values from columns. |
| <xref:Microsoft.ML.Transforms.MissingValueIndicatorTransform> | Creates a boolean output column with the same number of slots as the input column, where the output value is true if the value in the input column is missing. |
| <xref:Microsoft.ML.Transforms.MissingValueReplacingTransformer> | Handle missing values by replacing them with either the default value or the mean/min/max value (for non-text columns only). |

## Normalization

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.Transforms.Projections.LpNormalizingTransformer> | Lp-Norm (vector/row-wise) normalization transform. |
| <xref:Microsoft.ML.Transforms.Normalizers.MeanVarDblAggregator> | Computes the mean and variance for a vector valued column. It tracks the current mean and the M2 (sum of squared diffs of the values from the mean), the number of NaNs and the number of non-zero elements. |
| <xref:Microsoft.ML.Transforms.Normalizers.MeanVarSngAggregator> | Computes the mean and variance for a vector valued column. It tracks the current mean and the M2 (sum of squared diffs of the values from the mean), the number of NaNs and the number of non-zero elements. |
| <xref:Microsoft.ML.Transforms.Normalizers.MinMaxDblAggregator> | Tracks min, max, number of non-sparse values (vCount) and number of ProcessValue() calls (trainCount) for a vector valued column. |
| <xref:Microsoft.ML.Transforms.Normalizers.MinMaxSngAggregator> | Tracks min, max, number of non-sparse values (vCount) and number of ProcessValue() calls (trainCount) for a vector valued column. |
| <xref:Microsoft.ML.Transforms.Normalizers.NormalizeTransform> | Standardizes feature ranges. |
| <xref:Microsoft.ML.Transforms.Normalizers.NormalizingTransformer> |Standardizes feature ranges. |

## Onnx

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.Transforms.OnnxTransform> | Scores pre-trained ONNX models which use the ONNX standard v1.2 |

## Preprocessing
| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.Transforms.BootstrapSamplingTransformer> | Approximates bootstrap sampling using Poisson sampling. |
| <xref:Microsoft.ML.Transforms.Projections.RandomFourierFeaturizingTransformer> | Produces random Fourier feature. |
| <xref:Microsoft.ML.Transforms.Text.TokenizingByCharactersTransformer> | Character-oriented tokenizer where text is considered a sequence of characters. |
| <xref:Microsoft.ML.Transforms.Projections.VectorWhiteningTransformer> | Simplfies optimization to assist with identifying weights. |

## Row Filters

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.Transforms.RowShufflingTransformer> | Shuffles a randomized cursor attempt to perform using a pool of a given number of rows.  |
| <xref:Microsoft.ML.Transforms.SkipFilter> | Allows limiting input to a subset of rows by skipping a number of rows. |
| <xref:Microsoft.ML.Transforms.SkipTakeFilter> | Allows limiting input to a subset of rows at an optional offset. Can be used to implement data paging. When created with SkipTakeFilter.SkipArguments behaves as `SkipFilter`.
| <xref:Microsoft.ML.Transforms.TakeFilter> | Allows limiting input to a subset of rows by taking N first rows. |


## Schema

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.Transforms.ColumnCopyingTransformer> | Duplicates columns from the dataset.|
| <xref:Microsoft.ML.Transforms.ColumnSelectingTransformer> | Selects a set of columns to drop or keep from a given input. |
| <xref:Microsoft.ML.Transforms.FeatureSelection.SlotsDroppingTransformer> | Drops slots from columns.|
| <xref:Microsoft.ML.Transforms.OptionalColumnTransform> | Creates a new column with the specified type and default values. |
| <xref:Microsoft.ML.Transforms.RangeFilter> | Filters a dataview on a column of type Single, Double or Key (contiguous). Keeps the values that are in the specified min/max range. NaNs are always filtered out. If the input is a Key type, the min/max are considered percentages of the number of values. |

## TensorFlow

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.Transforms.TensorFlowTransform> | Either scores with pretrained TensorFlow model or retrains TensorFlow model. |

## Text processing and featurization

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.Transforms.Text.TextNormalizingTransformer> | A text normalization transform that allows normalizing text case, removing diacritical marks, punctuation marks and/or numbers. The transform operates on text input as well as vector of tokens/text (vector of ReadOnlyMemory). |
| <xref:Microsoft.ML.Transforms.Text.TokenizingByCharactersTransformer> | Character-oriented tokenizer where text is considered a sequence of characters. |

## Time series

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.TimeSeriesProcessing.ExponentialAverageTransform> | Takes a weighted average of the values: ExpAvg(y_t) = a * y_t + (1-a) * ExpAvg(y_(t-1)). |
| <xref:Microsoft.ML.TimeSeriesProcessing.IidChangePointDetector> | Implements the change point detector transform for an i.i.d. sequence (random sample) based on adaptive kernel density estimation and martingales. |
| <xref:Microsoft.ML.TimeSeriesProcessing.IidSpikeDetector> | Implements the spike detector transform for an i.i.d. sequence (random sample) based on adaptive kernel density estimation. |
| <xref:Microsoft.ML.TimeSeriesProcessing.MovingAverageTransform> | Provides a weighted average of the sliding window values. |
| <xref:Microsoft.ML.TimeSeriesProcessing.PercentileThresholdTransform> | Decides whether the time-series current value belongs to the sliding window top values percentile. |
| <xref:Microsoft.ML.TimeSeriesProcessing.PValueTransform> | Computes the series current value empirical p-value based on the other values in the sliding window. |
| <xref:Microsoft.ML.TimeSeriesProcessing.SlidingWindowTransform> | Outputs a sliding window on a time series of type Single. |
| <xref:Microsoft.ML.TimeSeriesProcessing.SsaChangePointDetector> | Implements the change point detector transform based on Singular Spectrum modeling of the time-series. |
| <xref:Microsoft.ML.TimeSeriesProcessing.SsaSpikeDetector> | Implements the spike detector transform based on Singular Spectrum modeling of the time-series. |

## Miscellaneous

| Transform | Definition |
| --- | --- |
| <xref:Microsoft.ML.Transforms.CompositeTransformer> | Creates a Composite DataTransform. |
| <xref:Microsoft.ML.Transforms.CustomMappingTransformer%602> | Generates additional columns to the provided `IDataView`. It doesn't change the number of rows and can be seen as a result of application of the user's function to every row of the input data.|
| <xref:Microsoft.ML.Transforms.GenerateNumberTransform> | Adds a column with a generated number sequence. |
| <xref:Microsoft.ML.Transforms.ProduceIdTransform> | Produces a column with the cursor's ID as a column. |
| <xref:Microsoft.ML.Transforms.RandomNumberGenerator> | Generates a random number. |
| <xref:Microsoft.ML.Transforms.ScoringTransformer> | Combines information from multiple predictive models to generate a new model in the pipeline by using the scores from an already trained model. |

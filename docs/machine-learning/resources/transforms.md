# Machine learning transforms

The following tables contains all of the supported data transforms in ML.NET and a description of their functionality.

## Text featurization
| Transform | Definition |
| --- | --- |

## Text pre-processing
| Transform | Definition |
| --- | --- |

## Categorical
| Transform | Definition |
| --- | --- |
 
## Label parsing
| Transform | Definition |
| --- | --- |
 
## Missing Values            
| Transform | Definition |
| --- | --- |

## Normalization
| Transform | Definition |
| --- | --- |

## Schema
| Transform | Definition |
| --- | --- |

## Uncategorized
| Transform | Definition |
| --- | --- |
| ApproximateBootstrapSampler |	Approximate bootstrap sampling.|
| BinaryPredictionScoreColumnsRenamer | For binary prediction, it renames the PredictedLabel and Score columns to include the name of the positive class.|
| BinNormalizer	| The values are assigned into equidensity bins and a value is mapped to its bin_number/number_of_bins. |
| CategoricalHashOneHotVectorizer | Encodes the categorical variable with hash-based encoding. |
| CategoricalOneHotVectorizer | Encodes the categorical variable with one-hot encoding based on term dictionary. |
| CharacterTokenizer | Character-oriented tokenizer where text is considered a sequence of characters. |
| ColumnConcatenator | Concatenates two columns of the same item type. |
| ColumnCopier | Duplicates columns from the dataset.|
| ColumnDropper	| Drops columns from the dataset. |
| ColumnSelector | Selects a set of columns, dropping all others. |
| ColumnTypeConverter | Converts a column to a different type, using standard conversions. |
| CombinerByContiguousGroupId | Groups values of a scalar column into a vector, by a contiguous group ID. |
| ConditionalNormalizer	| Normalize the columns only if needed. |
| DataCache	| Caches using the specified cache option. |
| DatasetScorer	| Score a dataset with a predictor model. |
| DatasetTransformScorer | Score a dataset with a transform model. |
| Dictionarizer	| Converts input values (words, numbers, etc.) to index in a dictionary. |
| FeatureCombiner | Combines all the features into one feature column. |
| FeatureSelectorByCount | Selects the slots for which the count of non-default values is greater than or equal to a threshold. |
| FeatureSelectorByMutualInformation | Selects the top k slots across all specified columns ordered by their mutual information with the label column. |
| GlobalContrastNormalizer | Performs a global contrast normalization on input values: Y = (s * X - M) / D, where s is a scale, M is mean and D is either L2 norm or standard deviation. | 
| HashConverter	| Converts column values into hashes. This transform accepts both numeric and text inputs, both single and vector-valued columns. This is a part of the Dracula transform. |
| KeyToTextConverter | KeyToValueTransform utilizes KeyValues metadata to map key indices to the corresponding values in the KeyValues metadata. |
| LabelColumnKeyBooleanConverter | Transforms the label to either key or bool (if needed) to make it suitable for classification. |
| LabelIndicator | Label remapper used by OVA. |
| LabelToFloatConverter	| Transforms the label to float to make it suitable for regression. |
| LogMeanVarianceNormalizer | Normalizes the data based on the computed mean and variance of the logarithm of the data. |
| LpNormalizer | Normalize vectors (rows) individually by rescaling them to unit norm (L2, L1 or LInf). Performs the following operation on a vector X: Y = (X - M) / D, where M is mean and D is either L2 norm, L1 norm or LInf norm. |
| ManyHeterogeneousModelCombiner | Combines a sequence of TransformModels and a PredictorModel into a single PredictorModel. |
| MeanVarianceNormalizer | Normalizes the data based on the computed mean and variance of the data. |
| MinMaxNormalizer | Normalizes the data based on the observed minimum and maximum values of the data. | 
| MissingValueHandler | Handle missing values by replacing them with either the default value or the mean/min/max value (for non-text columns only). An indicator column can optionally be concatenated, if theinput column type is numeric. |
| MissingValueIndicator	| Create a boolean output column with the same number of slots as the input column, where the output value is true if the value in the input column is missing. |
| MissingValuesDropper | Removes NAs from vector columns. |
| MissingValuesRowDropper | Filters out rows that contain missing values. |
| MissingValueSubstitutor | Create an output column of the same type and size of the input column, where missing values are replaced with either the default value or the mean/min/max value (for non-text columns only). |
| ModelCombiner	| Combines a sequence of TransformModels into a single model. |
| NGramTranslator | Produces a bag of counts of ngrams (sequences of consecutive values of length 1-n) in a given vector of keys. It does so by building a dictionary of ngrams and using the id in the dictionary as the index in the bag. | 
| NoOperation | Does nothing. |
| OptionalColumnCreator	| If the source column does not exist after deserialization, create a column with the right type and default values. | 
| PredictedLabelColumnOriginalValueConverter | Transforms a predicted label column to its original values, unless it is of type bool. |
| RandomNumberGenerator	| Adds a column with a generated number sequence. |
| RowRangeFilter | Filters a dataview on a column of type Single, Double or Key (contiguous). Keeps the values that are in the specified min/max range. NaNs are always filtered out. If the input is a Key type, the min/max are considered percentages of the number of values. |
| RowSkipAndTakeFilter | Allows limiting input to a subset of rows at an optional offset. Can be used to implement data paging. |
| RowSkipFilter	| Allows limiting input to a subset of rows by skipping a number of rows. |
| RowTakeFilter	| Allows limiting input to a subset of rows by taking N first rows. |
| ScoreColumnSelector | Selects only the last score columns and the extra columns specified in the arguments. |
| Scorer | Turn the predictor model into a transform model. |
| Segregator | Un-groups vector columns into sequences of rows, inverse of Group transform. |
| SentimentAnalyzer | Uses a pretrained sentiment model to score input strings. |
| SupervisedBinNormalizer | Similar to BinNormalizer, but calculates bins based on correlation with the label column, not equi-density. The new value is bin_number / number_of_bins. |
| TextFeaturizer | A transform that turns a collection of text documents into numerical feature vectors. The feature vectors are normalized counts of (word and/or character) ngrams in a given tokenized text. |
| TextToKeyConverter | Converts input values (words, numbers, etc.) to index in a dictionary. |
| TrainTestDatasetSplitter | Split the dataset into train and test sets. |
| TreeLeafFeaturizer | Trains a tree ensemble, or loads it from a file, then maps a numeric feature vector to three outputs: 1. A vector containing the individual tree outputs of the tree ensemble. 2. A vector indicating the leaves that the feature vector falls on in the tree ensemble. 3. A vector indicating the paths that the feature vector falls on in the tree ensemble. If a both a model file and a trainer are specified - will use the model file. If neither are specified, will train a default FastTree model. This can handle key labels by training a regression model towards their optionally permuted indices. |
| TwoHeterogeneousModelCombiner	| Combines a TransformModel and a PredictorModel into a single PredictorModel. |
| WordTokenizer	| The input to this transform is text, and the output is a vector of text containing the words (tokens) in the original text. The separator is space, but can be specified as any other character (or multiple characters) if needed. |
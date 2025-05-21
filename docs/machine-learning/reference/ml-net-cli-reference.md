---
title: ML.NET CLI Command Reference
description: Overview, samples, and reference for the auto-train command in the ML.NET CLI tool.
ms.date: 06/12/2022
ms.custom: mlnet-tooling
ms.topic: article
---

# The ML.NET CLI command reference

The `classification`, `regression`, and `recommendation` commands are the main commands provided by the ML.NET CLI tool. These commands allow you to generate good quality ML.NET models for classification, regression, and recommendation models using automated machine learning (AutoML) as well as the example C# code to run/score that model. In addition, the C# code to train the model is generated for you to research the algorithm and settings of the model.

> [!NOTE]
> This article refers to ML.NET CLI and ML.NET AutoML, which are currently in preview, and material is subject to change.

## Overview

Example usage:

```console
mlnet regression --dataset "cars.csv" --label-col price
```

The `mlnet` ML task commands (`classification`, `regression`, `recommendation`, and `forecasting`) generate the following assets:

- A serialized model .zip ("best model") ready to use.
- C# code to run/score that generated model.
- C# code with the training code used to generate that model.

The first two assets can directly be used in your end-user apps (ASP.NET Core web app, services, desktop app and more) to make predictions with the model.

The third asset, the training code, shows you what ML.NET API code was used by the CLI to train the generated model, so you can investigate the specific algorithm and settings of the model.

## Examples

The simplest CLI command for a classification problem (AutoML infers most of the configuration from the provided data):

```console
mlnet classification --dataset "customer-feedback.tsv" --label-col Sentiment
```

Another simple CLI command for a regression problem:

``` console
mlnet regression --dataset "cars.csv" --label-col Price
```

Create and train a classification model with a train dataset, a test dataset, and further customization explicit arguments:

```console
mlnet classification --dataset "/MyDataSets/Population-Training.csv" --test-dataset "/MyDataSets/Population-Test.csv" --label-col "InsuranceRisk" --cache on --train-time 600
```

## Command options

The `mlnet` ML task commands (`classification`, `regression`, `recommendation`, `forecasting`, and `train`) train multiple models based on the provided dataset and ML.NET CLI options. These commands also select the best model, save the model as a serialized .zip file, and generate related C# code for scoring and training.

### Classification options

Running `mlnet classification` will train a classification model. Choose this command if you want an ML Model to categorize data into 2 or more classes (e.g. sentiment analysis).

```console
mlnet classification

--dataset <path> (REQUIRED)

--label-col <col> (REQUIRED)

--cache <option>

--has-header (Default: true)

--ignore-cols <cols>

--log-file-path <path>

--name <name>

-o, --output <path>

--test-dataset <path>

--train-time <time> (Default: 30 minutes, in seconds)

--validation-dataset <path>

-v, --verbosity <v>

-?, -h, --help
```

### Regression options

Running `mlnet regression` will train a regression model. Choose this command if you want an ML Model to predict a numeric value (e.g. price prediction).

```console
mlnet regression

--dataset <path> (REQUIRED)

--label-col <col> (REQUIRED)

--cache <option>

--has-header (Default: true)

--ignore-cols <cols>

--log-file-path <path>

--name <name>

-o, --output <path>

--test-dataset <path>

--train-time <time> (Default: 30 minutes, in seconds)

--validation-dataset <path>

-v, --verbosity <v>

-?, -h, --help

```

### Recommendation options

Running `mlnet recommendation` will train a recommendation model. Choose this command if you want an ML Model to recommend items to users based on ratings (e.g. product recommendation).

```console
mlnet recommendation

--dataset <path> (REQUIRED)

--item-col <col> (REQUIRED)

--rating-col <col> (REQUIRED)

--user-col <col> (REQUIRED)

--cache <option>

--has-header (Default: true)

--log-file-path <path>

--name <name>

-o, --output <path>

--test-dataset <path>

--train-time <time> (Default: 30 minutes, in seconds)

--validation-dataset <path>

-v, --verbosity <v>

-?, -h, --help
```

Invalid input options cause the CLI tool to emit a list of valid inputs and an error message.

### Forecasting options

Running `mlnet forecasting` will train a time series forecasting model. Choose this command if you want an ML Model to forecast a value based on historical data (for example, sales forecasting).

```console
mlnet forecasting

--dataset <dataset> (REQUIRED)

--horizon <horizon> (REQUIRED)

--label-col <label-col> (REQUIRED)

--time-col <time-col> (REQUIRED)

--cache <Auto|Off|On>

--has-header

--log-file-path <log-file-path>

--name <name>

-o, --output <output>

--test-dataset <test-dataset>

--train-time <train-time>

-v, --verbosity <verbosity>

```

### Train options

Running `mlnet train` will train a model based on an "mbconfig" file generated from Model Builder. For this command to work, the training data must be in the same directory as the "mbconfig" file.

```console
-training-config <training-config> (REQUIRED)

--log-file-path <log-file-path>

-v, --verbosity <verbosity>
```

## Dataset

`--dataset | -d` (string)

This argument provides the filepath to either one of the following options:

- *A: The whole dataset file:* If using this option and the user is not providing `--test-dataset` and `--validation-dataset`, then cross-validation (k-fold, etc.) or automated data split approaches will be used internally for validating the model. In that case, the user will just need to provide the dataset filepath.

- *B: The training dataset file:* If the user is also providing datasets for model validation (using `--test-dataset` and optionally `--validation-dataset`), then the `--dataset` argument means to only have the "training dataset". For example, when using an 80% - 20% approach to validate the quality of the model and to obtain accuracy metrics, the "training dataset" will have 80% of the data and the "test dataset" would have 20% of the data.

## Test dataset

`--test-dataset | -t` (string)

File path pointing to the test dataset file, for example when using an 80% - 20% approach when making regular validations to obtain accuracy metrics.

If using `--test-dataset`, then `--dataset` is also required.

The `--test-dataset` argument is optional unless the --validation-dataset is used. In that case, the user must use the three arguments.

## Validation dataset

`--validation-dataset | -v` (string)

File path pointing to the validation dataset file. The validation dataset is optional, in any case.

If using a `validation dataset`, the behavior should be:

- The `test-dataset` and `--dataset` arguments are also required.

- The `validation-dataset` dataset is used to estimate prediction error for model selection.

- The `test-dataset` is used for assessment of the generalization error of the final chosen model. Ideally, the test set should be kept in a “vault,” and be brought out only at the end of the data analysis.

Basically, when using a `validation dataset` plus the `test dataset`, the validation phase is split into two parts:

1. In the first part, you just look at your models and select the best performing approach using the validation data (=validation)
2. Then you estimate the accuracy of the selected approach (=test).

Hence, the separation of data could be 80/10/10 or 75/15/10. For example:

- `training-dataset` file should have 75% of the data.
- `validation-dataset` file should have 15% of the data.
- `test-dataset` file should have 10% of the data.

In any case, those percentages will be decided by the user using the CLI who will provide the files already split.

## Label column

`--label-col` (int or string)

With this argument, a specific objective/target column (the variable that you want to predict) can be specified by using the column's name set in the dataset's header or the column's numeric index in the dataset's file (the column index values start at 0).

This argument is used for *classification* and *regression* problems.

## Item column

`--item-col` (int or string)

The item column has the list of items that users rate (items are recommended to users). This column can be specified by using the column's name set in the dataset's header or the column's numeric index in the dataset's file (the column index values start at 0).

This argument is used only for the *recommendation* task.

## Rating column

`--rating-col` (int or string)

The rating column has the list of ratings that are given to items by users. This column can be specified by using the column's name set in the dataset's header or the column's numeric index in the dataset's file (the column index values start at 0).

This argument is used only for the *recommendation* task.

## User column

`--user-col` (int or string)

The user column has the list of users that give ratings to items. This column can be specified by using the column's name set in the dataset's header or the column's numeric index in the dataset's file (the column index values start at 0).

This argument is used only for the *recommendation* task.

## Ignore columns

`--ignore-columns` (string)

With this argument, you can ignore existing columns in the dataset file so they are not loaded and used by the training processes.

Specify the columns names that you want to ignore. Use ', ' (comma with space) or ' ' (space) to separate multiple column names. You can use quotes for column names containing whitespace (e.g. "logged in").

Example:

`--ignore-columns email, address, id, logged_in`

## Has header

`--has-header` (bool)

Specify if the dataset file(s) have a header row.
Possible values are:

- `true`
- `false`

The ML.NET CLI will try to detect this property if this argument is not specified by the user.

## Train time

`--train-time` (string)

By default, the maximum exploration or train time is 30 minutes.

This argument sets the maximum time (in seconds) for the process to explore multiple trainers and configurations. The configured time limit might be exceeded if it's too short (say 2 seconds) for a single iteration. In this case, the actual time is the required time to produce one model configuration in a single iteration.

The time needed for iterations can vary depending on the size of the dataset.

## Cache

`--cache` (string)

If you use caching, the whole training dataset will be loaded in-memory.

For small and medium datasets, using cache can drastically improve the training performance, meaning the training time can be shorter than when you don't use cache.

However, for large datasets, loading all the data in memory can impact negatively since you might get out of memory. When training with large dataset files and not using cache, ML.NET will be streaming chunks of data from the drive when it needs to load more data while training.

You can specify the following values:

`on`: Forces cache to be used when training.
`off`: Forces cache not to be used when training.
`auto`: Depending on AutoML heuristics, the cache will be used or not. Usually, small/medium datasets will use cache and large datasets won't use cache if you use the `auto` choice.

If you don't specify the `--cache` parameter, then the cache `auto` configuration will be used by default.

## Name

`--name` (string)

The name for the created output project or solution. If no name is specified, the name `sample-{mltask}` is used.

The ML.NET model file (.ZIP file) will get the same name, as well.

## Output path

`--output | -o` (string)

Root location/folder to place the generated output. The default is the current directory.

## Verbosity

`--verbosity | -v` (string)

Sets the verbosity level of the standard output.

Allowed values are:

- `q[uiet]`
- `m[inimal]`  (by default)
- `diag[nostic]` (logging information level)

By default, the CLI tool should show some minimum feedback (`minimal`) when working, such as mentioning that it is working and if possible how much time is left or what % of the time is completed.

## Help

`-h |--help`

Prints out help for the command with a description for each command's parameter.

## See also

- [How to install the ML.NET CLI tool](../how-to-guides/install-ml-net-cli.md)
- [Overview of the ML.NET CLI](../automate-training-with-cli.md)
- [Tutorial: Analyze sentiment using the ML.NET CLI](../tutorials/sentiment-analysis-cli.md)
- [Telemetry in ML.NET CLI](../resources/ml-net-cli-telemetry.md)

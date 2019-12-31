---
title: ML.NET CLI Command Reference
description: Overview, samples, and reference for the auto-train command in the ML.NET CLI tool.
ms.date: 12/18/2019
---

# The ML.NET CLI command reference

The `auto-train` command is the main command provided by the ML.NET CLI tool. The command allows you to generate a good quality ML.NET model using automated machine learning (AutoML) as well as the the example C# code to run/score that model. In addition, the C# code to train the model is generated for you to research the algorithm and settings of the model.

> [!NOTE]
> This topic refers to ML.NET CLI and ML.NET AutoML, which are currently in Preview, and material may be subject to change.

## Overview

Example usage:

```console
mlnet auto-train --task regression --dataset "cars.csv" --label-column-name price
```

The `mlnet auto-train` command generates the following assets:

- A serialized model .zip ("best model") ready to use.
- C# code to run/score that generated model.
- C# code with the training code used to generate that model.

The first two assets can directly be used in your end-user apps (ASP.NET Core web app, services, desktop app and more) to make predictions with the model.

The third asset, the training code, shows you what ML.NET API code was used by the CLI to train the generated model, so you can investigate the specific algorithm and settings of the model.

## Examples

The simplest CLI command for a binary classification problem (AutoML infers most of the configuration from the provided data):

```console
mlnet auto-train --task binary-classification --dataset "customer-feedback.tsv" --label-column-name Sentiment
```

Another simple CLI command for a regression problem:

``` console
mlnet auto-train --task regression --dataset "cars.csv" --label-column-name Price
```

Create and train a binary-classification model with a train dataset, a test dataset, and further customization explicit arguments:

```console
mlnet auto-train --task binary-classification --dataset "/MyDataSets/Population-Training.csv" --test-dataset "/MyDataSets/Population-Test.csv" --label-column-name "InsuranceRisk" --cache on --max-exploration-time 600
```

## Command options

`mlnet auto-train` trains multiple models based on the provided dataset and finally selects the best model, saves it as a serialized .zip file plus generates related C# code for scoring and training.

```console
mlnet auto-train

--task | --mltask | -T <value>

--dataset | -d <value>

[
 [--validation-dataset | -v <value>]
  --test-dataset | -t <value>
]

--label-column-name | -n <value>
|
--label-column-index | -i <value>

[--ignore-columns | -I <value>]

[--has-header | -h <value>]

[--max-exploration-time | -x <value>]

[--verbosity | -V <value>]

[--cache | -c <value>]

[--name | -N <value>]

[--output-path | -o <value>]

[--help | -h]

```

Invalid input options cause the CLI tool to emit a list of valid inputs and an error message.

## Task

`--task | --mltask | -T` (string)

A single string providing the ML problem to solve. For instance, any of the following tasks (The CLI will eventually support all tasks supported in AutoML):

- `regression` - Choose if the ML Model will be used to predict a numeric value
- `binary-classification` - Choose if the ML Model result has two possible categorical boolean values (0 or 1).
- `multiclass-classification` - Choose if the ML Model result has multiple categorical possible values.

Only one ML task should be provided in this argument.

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

## Label column name

`--label-column-name | -n` (string)

With this argument, a specific objective/target column (the variable that you want to predict) can be specified by using the column's name set in the dataset's header.

This argument is used only for supervised ML tasks such as a *classification problem*. It cannot be used for unsupervised ML Tasks such as *clustering*.

## Label column index

`--label-column-index | -i` (int)

With this argument, a specific objective/target column (the variable that you want to predict) can be specified by using the column's numeric index in the dataset's file (The column index values start at 1).

*Note:* If the user is also using the `--label-column-name`, the `--label-column-name` is the one being used.

This argument is used only for supervised ML task such as a *classification problem*. It cannot be used for unsupervised ML Tasks such as *clustering*.

## Ignore columns

`--ignore-columns | -I` (string)

With this argument, you can ignore existing columns in the dataset file so they are not loaded and used by the training processes.

Specify the columns names that you want to ignore. Use ', ' (comma with space) or ' ' (space) to separate multiple column names. You can use quotes for column names containing whitespace (e.g. "logged in").

Example:

`--ignore-columns email, address, id, logged_in`

## Has header

`--has-header | -h` (bool)

Specify if the dataset file(s) have a header row.
Possible values are:

- `true`
- `false`

The by default value is `true` if this argument is not specified by the user.

In order to use the `--label-column-name` argument, you need to have a header in the dataset file and `--has-header` set to `true` (which is by default).

## Max exploration time

`--max-exploration-time | -x` (string)

By default, the maximum exploration time is 30 minutes.

This argument sets the maximum time (in seconds) for the process to explore multiple trainers and configurations. The configured time may be exceeded if the provided time is too short (say 2 seconds) for a single iteration. In this case, the actual time is the required time to produce one model configuration in a single iteration.

The needed time for iterations can vary depending on the size of the dataset.

## Cache

`--cache | -c` (string)

If you use caching, the whole training dataset will be loaded in-memory.

For small and medium datasets, using cache can drastically improve the training performance, meaning the training time can be shorter than when you don't use cache.

However, for large datasets, loading all the data in memory can impact negatively since you might get out of memory. When training with large dataset files and not using cache, ML.NET will be streaming chunks of data from the drive when it needs to load more data while training.

You can specify the following values:

`on`: Forces cache to be used when training.
`off`: Forces cache not to be used when training.
`auto`: Depending on AutoML heuristics, the cache will be used or not. Usually, small/medium datasets will use cache and large datasets won't use cache if you use the `auto` choice.

If you don't specify the `--cache` parameter, then the cache `auto` configuration will be used by default.

## Name

`--name | -N` (string)

The name for the created output project or solution. If no name is specified, the name `sample-{mltask}` is used.

The ML.NET model file (.ZIP file) will get the same name, as well.

## Output path

`--output-path | -o` (string)

Root location/folder to place the generated output. The default is the current directory.

## Verbosity

`--verbosity | -V` (string)

Sets the verbosity level of the standard output.

Allowed values are:

- `q[uiet]`
- `m[inimal]`  (by default)
- `diag[nostic]` (logging information level)

By default, the CLI tool should show some minimum feedback (minimal) when working, such as mentioning that it is working and if possible how much time is left or what % of the time is completed.

## Help

`-h|--help`

Prints out help for the command with a description for each command's parameter.

## See also

- [How to install the ML.NET CLI tool](../how-to-guides/install-ml-net-cli.md)
- [Overview of the ML.NET CLI](../automate-training-with-cli.md)
- [Tutorial: Analyze sentiment using the ML.NET CLI](../tutorials/sentiment-analysis-cli.md)
- [Telemetry in ML.NET CLI](../resources/ml-net-cli-telemetry.md)

---
title: ML.NET metrics
description: Understand the metrics that are used to evaluate the performance of an ML.NET model
ms.date: 04/29/2019
author: natke
---
# Model evaluation metrics in ML.NET

## Metrics for Binary Classification

| Metrics   |      Description      |  Look for |
|-----------|-----------------------|-----------|
| **Accuracy** |  [Accuracy](https://en.wikipedia.org/wiki/Accuracy_and_precision#In_binary_classification) is the proportion of correct predictions with a test data set. It is the ratio of number of correct predictions to the total number of input samples. It works well only if there are similar number of samples belonging to each class.| **The closer to 1.00, the better**. But exactly 1.00 indicates an issue (commonly: label/target leakage, over-fitting, or testing with training data). When the test data is unbalanced (where most of the instances belong to one of the classes), the dataset is very small, or scores approach 0.00 or 1.00, then accuracy doesn’t really capture the effectiveness of a classifier and you need to check additional metrics. |
| **AUC** |    [aucROC](https://en.wikipedia.org/wiki/Receiver_operating_characteristic) or *Area under the curve*: This is measuring the area under the curve created by sweeping the true positive rate vs. the false positive rate.  |   **The closer to 1.00, the better**. It should be greater than 0.50 for a model to be acceptable; a model with AUC of 0.50 or less is worthless. |
| **AUCPR** | [aucPR](https://www.coursera.org/lecture/ml-classification/precision-recall-curve-rENu8) or *Area under the curve of a Precision-Recall curve*: Useful measure of success of prediction when the classes are very imbalanced (highly skewed datasets). |  **The closer to 1.00, the better**. High scores close to 1.00 show that the classifier is returning accurate results (high precision), as well as returning a majority of all positive results (high recall). |
| **F1-score** | [F1 score](https://en.wikipedia.org/wiki/F1_score) also known as *balanced F-score or F-measure*. It's the harmonic mean of the precision and recall. F1 Score is helpful when you want to seek a balance between Precision and Recall.| **The closer to 1.00, the better**.  An F1 score reaches its best value at 1.00 and worst score at 0.00. It tells you how precise your classifier is. |

For further details on binary classification metrics read the following articles:

- [Accuracy, Precision, Recall or F1?](https://towardsdatascience.com/accuracy-precision-recall-or-f1-331fb37c5cb9)
- [Binary Classification Metrics class](xref:Microsoft.ML.Data.BinaryClassificationMetrics)
- [The Relationship Between Precision-Recall and ROC Curves](http://pages.cs.wisc.edu/~jdavis/davisgoadrichcamera2.pdf)

## Metrics for Multi-class Classification

| Metrics   |      Description      |  Look for |
|-----------|-----------------------|-----------|
| **Micro-Accuracy** |  [Micro-average Accuracy](xref:Microsoft.ML.Data.MulticlassClassificationMetrics.MicroAccuracy) aggregates the contributions of all classes to compute the average metric. It is the fraction of instances predicted correctly. The micro-average does not take class membership into account. Basically, every sample-class pair contributes equally to the accuracy metric. | **The closer to 1.00, the better**. In a multi-class classification task, micro-accuracy is preferable over macro-accuracy if you suspect there might be class imbalance (i.e you may have many more examples of one class than of other classes).|
| **Macro-Accuracy** | [Macro-average Accuracy](xref:Microsoft.ML.Data.MulticlassClassificationMetrics.MacroAccuracy) is the average accuracy at the class level. The accuracy for each class is computed and the macro-accuracy is the average of these accuracies. Basically, every class contributes equally to the accuracy metric. Minority classes are given equal weight as the larger classes. The macro-average metric gives the same weight to each class, no matter how many instances from that class the dataset contains. |  **The closer to 1.00, the better**.  It computes the metric independently for each class and then takes the average (hence treating all classes equally) |
| **Log-loss**| [Logarithmic loss](http://wiki.fast.ai/index.php/Log_Loss) measures the performance of a classification model where the prediction input is a probability value between 0.00 and 1.00. Log-loss increases as the predicted probability diverges from the actual label. | **The closer to 0.00, the better**. A perfect model would have a log-loss of 0.00. The goal of our machine learning models is to minimize this value.|
| **Log-Loss Reduction** | [Logarithmic loss reduction](xref:Microsoft.ML.Data.MulticlassClassificationMetrics.LogLossReduction) can be interpreted as the advantage of the classifier over a random prediction.| **Ranges from -inf and 1.00, where 1.00 is perfect predictions and 0.00 indicates mean predictions**. For example, if the value equals 0.20, it can be interpreted as "the probability of a correct prediction is 20% better than random guessing"|

Micro-accuracy is generally better aligned with the business needs of ML predictions. If you want to select a single metric for choosing the quality of a multiclass classification task, it should usually be micro-accuracy.

Example, for a support ticket classification task: (maps incoming tickets to support teams)

- Micro-accuracy -- how often does an incoming ticket get classified to the right team?
- Macro-accuracy -- for an average team, how often is an incoming ticket correct for their team?

Macro-accuracy overweights small teams in this example; a small team which gets only 10 tickets per year counts as much as a large team with 10k tickets per year. Micro-accuracy in this case correlates better with the business need of, "how much time/money can the company save by automating my ticket routing process".

For further details on multi-class classification metrics read the following articles:

- [Micro- and Macro-average of Precision, Recall and F-Score](http://rushdishams.blogspot.com/2011/08/micro-and-macro-average-of-precision.html)
- [Multiclass Classification with Imbalanced Dataset](https://towardsdatascience.com/machine-learning-multiclass-classification-with-imbalanced-data-set-29f6a177c1a)

## Metrics for Regression

| Metrics   |      Description      |  Look for |
|-----------|-----------------------|-----------|
| **R-Squared** |  [R-squared (R2)](https://en.wikipedia.org/wiki/Coefficient_of_determination), or *Coefficient of determination* represents the predictive power of the model as a value between -inf and 1.00. 1.00 means there is a perfect fit, and the fit can be arbitrarily poor so the scores can be negative. A score of 0.00 means the model is guessing the expected value for the label. R2 measures how close the actual test data values are to the predicted values. | **The closer to 1.00, the better quality**. However, sometimes low R-squared values (such as 0.50) can be entirely normal or good enough for your scenario and high R-squared values are not always good and be suspicious. |
| **Absolute-loss** |  [Absolute-loss](https://en.wikipedia.org/wiki/Mean_absolute_error) or *Mean absolute error (MAE)* measures how close the predictions are to the actual outcomes. It is the average of all the model errors, where model error is the absolute distance between the predicted label value and the correct label value. This prediction error is calculated for each record of the test data set. Finally, the mean value is calculated for all recorded absolute errors.| **The closer to 0.00, the better quality.** Note that the mean absolute error uses the same scale as the data being measured (is not normalized to specific range). Absolute-loss, Squared-loss, and RMS-loss can only be used to make comparisons between models for the same dataset or dataset with a similar label value distribution. |
| **Squared-loss** |  [Squared-loss](https://en.wikipedia.org/wiki/Mean_squared_error) or *Mean Squared Error (MSE)*, also called *Mean Squared Deviation (MSD)*, tells you how close a regression line is to a set of test data values. It does this by taking the distances from the points to the regression line (these distances are the errors E) and squaring them. The squaring gives more weight to larger differences. | It is always non-negative, and **values closer to 0.00 are better**. Depending on your data, it may be impossible to get a very small value for the mean squared error.|
| **RMS-loss** |  [RMS-loss](https://en.wikipedia.org/wiki/Root-mean-square_deviation) or *Root Mean Squared Error (RMSE)* (also called *Root Mean Square Deviation, RMSD*), measures the difference between values predicted by a model and the values actually observed from the environment that is being modeled. RMS-loss is the square root of Squared-loss and has the same units as the label, similar to the absolute-loss though giving more weight to larger differences. Root mean square error is commonly used in climatology, forecasting, and regression analysis to verify experimental results. | It is always non-negative, and **values closer to 0.00 are better**. RMSD is a measure of accuracy, to compare forecasting errors of different models for a particular dataset and not between datasets, as it is scale-dependent.|

For further details on regression metrics, read the following articles:

- [Regression Analysis: How Do I Interpret R-squared and Assess the Goodness-of-Fit?](https://blog.minitab.com/blog/adventures-in-statistics-2/regression-analysis-how-do-i-interpret-r-squared-and-assess-the-goodness-of-fit)
- [How To Interpret R-squared in Regression Analysis](https://statisticsbyjim.com/regression/interpret-r-squared-regression)
- [R-Squared Definition](https://www.investopedia.com/terms/r/r-squared.asp)
- [Mean Squared Error Definition](https://www.statisticshowto.datasciencecentral.com/mean-squared-error/)
- [What are Mean Squared Error and Root Mean Squared Error?](https://www.vernier.com/til/1014/)

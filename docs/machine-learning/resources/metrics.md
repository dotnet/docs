---
title: ML.NET metrics
description: Understand the metrics that are used to evaluate the performance of an ML.NET model
ms.date: 12/17/2019
---
# Evaluate your ML.NET model with metrics

Understand the metrics used to evaluate an ML.NET model.

Evaluation metrics are specific to the type of machine learning task that a model performs.

For example, for the classification task, the model is evaluated by measuring how well a predicted category matches the actual category. And for clustering, evaluation is based on how close clustered items are to each other, and how much separation there is between the clusters.

## Evaluation metrics for Binary Classification

| Metrics   |      Description      |  Look for |
|-----------|-----------------------|-----------|
| **Accuracy** |  [Accuracy](https://en.wikipedia.org/wiki/Accuracy_and_precision#In_binary_classification) is the proportion of correct predictions with a test data set. It is the ratio of number of correct predictions to the total number of input samples. It works well if there are similar number of samples belonging to each class.| **The closer to 1.00, the better**. But exactly 1.00 indicates an issue (commonly: label/target leakage, over-fitting, or testing with training data). When the test data is unbalanced (where most of the instances belong to one of the classes), the dataset is small, or scores approach 0.00 or 1.00, then accuracy doesn't really capture the effectiveness of a classifier and you need to check additional metrics. |
| **AUC** |    [aucROC](https://en.wikipedia.org/wiki/Receiver_operating_characteristic) or *Area under the curve* measures the area under the curve created by sweeping the true positive rate vs. the false positive rate.  |   **The closer to 1.00, the better**. It should be greater than 0.50 for a model to be acceptable. A model with AUC of 0.50 or less is worthless. |
| **AUCPR** | aucPR or *Area under the curve of a Precision-Recall curve*: Useful measure of success of prediction when the classes are imbalanced (highly skewed datasets). |  **The closer to 1.00, the better**. High scores close to 1.00 show that the classifier is returning accurate results (high precision), and returning a majority of all positive results (high recall). |
| **F1-score** | [F1 score](https://en.wikipedia.org/wiki/F1_score) also known as *balanced F-score or F-measure*. It's the harmonic mean of the precision and recall. F1 Score is helpful when you want to seek a balance between Precision and Recall.| **The closer to 1.00, the better**.  An F1 score reaches its best value at 1.00 and worst score at 0.00. It tells you how precise your classifier is. |

For further details on binary classification metrics read the following articles:

- [Accuracy, Precision, Recall, or F1?](https://towardsdatascience.com/accuracy-precision-recall-or-f1-331fb37c5cb9)
- [Binary Classification Metrics class](xref:Microsoft.ML.Data.BinaryClassificationMetrics)
- [The Relationship Between Precision-Recall and ROC Curves](http://pages.cs.wisc.edu/~jdavis/davisgoadrichcamera2.pdf)

## Evaluation metrics for Multi-class Classification

| Metrics   |      Description      |  Look for |
|-----------|-----------------------|-----------|
| **Micro-Accuracy** |  [Micro-average Accuracy](xref:Microsoft.ML.Data.MulticlassClassificationMetrics.MicroAccuracy) aggregates the contributions of all classes to compute the average metric. It is the fraction of instances predicted correctly. The micro-average does not take class membership into account. Basically, every sample-class pair contributes equally to the accuracy metric. | **The closer to 1.00, the better**. In a multi-class classification task, micro-accuracy is preferable over macro-accuracy if you suspect there might be class imbalance (i.e you may have many more examples of one class than of other classes).|
| **Macro-Accuracy** | [Macro-average Accuracy](xref:Microsoft.ML.Data.MulticlassClassificationMetrics.MacroAccuracy) is the average accuracy at the class level. The accuracy for each class is computed and the macro-accuracy is the average of these accuracies. Basically, every class contributes equally to the accuracy metric. Minority classes are given equal weight as the larger classes. The macro-average metric gives the same weight to each class, no matter how many instances from that class the dataset contains. |  **The closer to 1.00, the better**.  It computes the metric independently for each class and then takes the average (hence treating all classes equally) |
| **Log-loss**| Logarithmic loss measures the performance of a classification model where the prediction input is a probability value between 0.00 and 1.00. Log-loss increases as the predicted probability diverges from the actual label. | **The closer to 0.00, the better**. A perfect model would have a log-loss of 0.00. The goal of our machine learning models is to minimize this value.|
| **Log-Loss Reduction** | [Logarithmic loss reduction](xref:Microsoft.ML.Data.MulticlassClassificationMetrics.LogLossReduction) can be interpreted as the advantage of the classifier over a random prediction.| **Ranges from -inf and 1.00, where 1.00 is perfect predictions and 0.00 indicates mean predictions**. For example, if the value equals 0.20, it can be interpreted as "the probability of a correct prediction is 20% better than random guessing"|

Micro-accuracy is generally better aligned with the business needs of ML predictions. If you want to select a single metric for choosing the quality of a multiclass classification task, it should usually be micro-accuracy.

Example, for a support ticket classification task: (maps incoming tickets to support teams)

- Micro-accuracy&mdash;how often does an incoming ticket get classified to the right team?
- Macro-accuracy&mdash;for an average team, how often is an incoming ticket correct for their team?

Macro-accuracy overweights small teams in this example; a small team that gets only 10 tickets per year counts as much as a large team with 10k tickets per year. Micro-accuracy in this case correlates better with the business need of, "how much time/money can the company save by automating my ticket routing process".

For further details on multi-class classification metrics read the following articles:

- [Micro- and Macro-average of Precision, Recall, and F-Score](https://rushdishams.blogspot.com/2011/08/micro-and-macro-average-of-precision.html)
- [Multiclass Classification with Imbalanced Dataset](https://towardsdatascience.com/machine-learning-multiclass-classification-with-imbalanced-data-set-29f6a177c1a)

## Evaluation metrics for Regression and Recommendation

Both the regression and recommendation tasks predict a number. In the case of regression, the number can be any output property that is influenced by the input properties. For recommendation, the number is usually a rating value (between 1 and 5 for example), or a yes/no recommendation (represented by 1 and 0 respectively).

| Metric   |      Description      |  Look for |
|----------|-----------------------|-----------|
| **R-Squared** |  [R-squared (R2)](https://en.wikipedia.org/wiki/Coefficient_of_determination), or *Coefficient of determination* represents the predictive power of the model as a value between -inf and 1.00. 1.00 means there is a perfect fit, and the fit can be arbitrarily poor so the scores can be negative. A score of 0.00 means the model is guessing the expected value for the label. A negative R2 value indicates the fit does not follow the trend of the data and the model performs worse than random guessing. This is only possible with non-linear regression models or constrained linear regression. R2 measures how close the actual test data values are to the predicted values. | **The closer to 1.00, the better quality**. However, sometimes low R-squared values (such as 0.50) can be entirely normal or good enough for your scenario and high R-squared values are not always good and be suspicious. |
| **Absolute-loss** |  [Absolute-loss](https://en.wikipedia.org/wiki/Mean_absolute_error) or *Mean absolute error (MAE)* measures how close the predictions are to the actual outcomes. It is the average of all the model errors, where model error is the absolute distance between the predicted label value and the correct label value. This prediction error is calculated for each record of the test data set. Finally, the mean value is calculated for all recorded absolute errors.| **The closer to 0.00, the better quality.** The mean absolute error uses the same scale as the data being measured (is not normalized to specific range). Absolute-loss, Squared-loss, and RMS-loss can only be used to make comparisons between models for the same dataset or dataset with a similar label value distribution. |
| **Squared-loss** |  [Squared-loss](https://en.wikipedia.org/wiki/Mean_squared_error) or *Mean Squared Error (MSE)*, also called *Mean Squared Deviation (MSD)*, tells you how close a regression line is to a set of test data values by taking the distances from the points to the regression line (these distances are the errors E) and squaring them. The squaring gives more weight to larger differences. | It is always non-negative, and **values closer to 0.00 are better**. Depending on your data, it may be impossible to get a very small value for the mean squared error.|
| **RMS-loss** |  [RMS-loss](https://en.wikipedia.org/wiki/Root-mean-square_deviation) or *Root Mean Squared Error (RMSE)* (also called *Root Mean Square Deviation, RMSD*), measures the difference between values predicted by a model and the values observed from the environment that is being modeled. RMS-loss is the square root of Squared-loss and has the same units as the label, similar to the absolute-loss though giving more weight to larger differences. Root mean square error is commonly used in climatology, forecasting, and regression analysis to verify experimental results. | It is always non-negative, and **values closer to 0.00 are better**. RMSD is a measure of accuracy, to compare forecasting errors of different models for a particular dataset and not between datasets, as it is scale-dependent.|

For further details on regression metrics, read the following articles:

- [Regression Analysis: How Do I Interpret R-squared and Assess the Goodness-of-Fit?](https://blog.minitab.com/blog/adventures-in-statistics-2/regression-analysis-how-do-i-interpret-r-squared-and-assess-the-goodness-of-fit)
- [How To Interpret R-squared in Regression Analysis](https://statisticsbyjim.com/regression/interpret-r-squared-regression)
- [R-Squared Definition](https://www.investopedia.com/terms/r/r-squared.asp)
- [The Coefficient of Determination and the Assumptions of Linear Regression Models](https://programmathically.com/the-coefficient-of-determination-and-linear-regression-assumptions/)
- [Mean Squared Error Definition](https://en.wikipedia.org/wiki/Mean_squared_error)
- [What are Mean Squared Error and Root Mean Squared Error?](https://www.vernier.com/til/1014/)

## Evaluation metrics for Clustering

| Metric   |      Description      |  Look for |
|----------|-----------------------|-----------|
|**Average Distance**|Average of the distance between data points and the center of their assigned cluster. The average distance is a measure of proximity of the data points to cluster centroids. It's a measure of how 'tight' the cluster is.|Values closer to **0** are better. The closer to zero the average distance is, the more clustered the data is. Note though, that this metric will decrease if the number of clusters is increased, and in the extreme case (where each distinct data point is its own cluster) it will be equal to zero.
|**Davies Bouldin Index**|The average ratio of within-cluster distances to between-cluster distances. The tighter the cluster, and the further apart the clusters are, the lower this value is.|Values closer to **0** are better. Clusters that are farther apart and less dispersed will result in a better score.|
|**Normalized Mutual Information**|Can be used when the training data used to train the clustering model also comes with ground truth labels (that is, supervised clustering). The Normalized Mutual Information metric measures whether similar data points get assigned to the same cluster and disparate data points get assigned to different clusters. Normalized mutual information is a value between 0 and 1|Values closer to **1** are better|

## Evaluation metrics for Ranking

| Metric   |      Description      |  Look for |
|----------|-----------------------|-----------|
|**Discounted Cumulative Gains**|Discounted cumulative gain (DCG) is a measure of ranking quality. It is derived from two assumptions. One: Highly relevant items are more useful when appearing higher in ranking order. Two: Usefulness tracks relevance that is, the higher the relevance, the more useful an item. Discounted cumulative gain is calculated for a particular position in the ranking order. It sums the relevance grading divided by the logarithm of the ranking index up to the position of interest. It is calculated using $\sum_{i=0}^{p} \frac {rel_i} {\log_{e}{i+1}}$ Relevance gradings are provided to a ranking training algorithm as ground truth labels. One DCG value is provided for each position in the ranking table, hence the name Discounted Cumulative **Gains**. |**Higher values are better**|
|**Normalized Discounted Cumulative Gains**|Normalizing DCG allows the metric to be compared for ranking lists of different lengths|**Values closer to 1 are better**|

## Evaluation metrics for Anomaly Detection

| Metric   |      Description      |  Look for |
|----------|-----------------------|-----------|
|**Area Under ROC Curve**|Area under the receiver operator curve measures how well the model separates anomalous and usual data points.|**Values closer to 1 are better**. Only values greater than 0.5 demonstrate effectiveness of the model. Values of 0.5 or below indicate that the model is no better than randomly allocating the inputs to anomalous and usual categories|
|**Detection Rate At False Positive Count**|Detection rate at false positive count is the ratio of the number of correctly identified anomalies to the total number of anomalies in a test set, indexed by each false positive. That is, there is a value for detection rate at false positive count for each false positive item.|**Values closer to 1 are better**. If there are no false positives, then this value is 1|

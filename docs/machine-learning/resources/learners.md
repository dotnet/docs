# Learning Algorithms
The following table will help you understand the different learning algorithms (learners) included in ML.NET and the [machine learning tasks](tasks.md) that they can be used for. Click on the checkbox for a corresponding learner name for more in-depth explanations on each of these learning methods.

> [!NOTE]
> ML.NET is currently in Preview. Not all learning algorithms are currently supported. To submit a request for a certain learner, please open an issue in the [dotnet/machinelearning repository](https://github.com/dotnet/machinelearning/issues).

| Learner Name | Binary classification | Multiclass classification | Regression | Ranking | Clustering | Anomaly Detection |
| --- |:---:|:---:|:---:|:---:|:---:|:---:|
| Averaged Perceptron |[:heavy_check_mark:](xref:Microsoft.ML.Trainers.AveragedPerceptronBinaryClassifier)||||||
| FastForest|[:heavy_check_mark:](xref:Microsoft.ML.Trainers.FastForestBinaryClassifier)||[:heavy_check_mark:](xref:Microsoft.ML.Trainers.FastForestRegressor)||||
| FastTree |[:heavy_check_mark:](xref:Microsoft.ML.Trainers.FastTreeBinaryClassifier)||[:heavy_check_mark:](xref:Microsoft.ML.Trainers.FastTreeRegressor)|[:heavy_check_mark:](xref:Microsoft.ML.Trainers.FastTreeRanker)|||
| Generalized Additive Models |[:heavy_check_mark:](xref:Microsoft.ML.Trainers.GeneralizedAdditiveModelBinaryClassifier)||[:heavy_check_mark:](xref:Microsoft.ML.Trainers.GeneralizedAdditiveModelRegressor)||||
| K-Means++ |||||[:heavy_check_mark:](xref:Microsoft.ML.Trainers.KMeansPlusPlusClusterer)||
| Linear SVM |[:heavy_check_mark:](xref:Microsoft.ML.Trainers.LinearSvmBinaryClassifier)||||||
| Logistic Regressor |[:heavy_check_mark:](xref:Microsoft.ML.Trainers.LogisticRegressionBinaryClassifier)|[:heavy_check_mark:](xref:Microsoft.ML.Trainers.LogisticRegressionClassifier)|||||
| Naïve Bayes ||[:heavy_check_mark:](xref:Microsoft.ML.Trainers.NaiveBayesClassifier)|||||
| Online Gradient Descent |||[:heavy_check_mark:](xref:Microsoft.ML.Trainers.OnlineGradientDescentRegressor)||||
| Ordinary Least Squares |||:heavy_check_mark:||||
| PCA Anomaly Detector ||||||[:heavy_check_mark:](xref:Microsoft.ML.Trainers.PcaAnomalyDetector)
| Poisson Regression |||[:heavy_check_mark:](xref:Microsoft.ML.Trainers.PoissonRegressor)||||
| Stochastic Dual Coordinate Ascent |[:heavy_check_mark:](xref:Microsoft.ML.Trainers.StochasticDualCoordinateAscentBinaryClassifier)|[:heavy_check_mark:](xref:Microsoft.ML.Trainers.StochasticDualCoordinateAscentClassifier)|[:heavy_check_mark:](xref:Microsoft.ML.Trainers.StochasticDualCoordinateAscentRegressor)||||
| Stochastic Gradient Descent |[:heavy_check_mark:](xref:Microsoft.ML.Trainers.StochasticGradientDescentBinaryClassifier)||||||
| Tweedie FastTree |||:heavy_check_mark:||||

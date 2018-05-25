# Machine Learning Tasks
After understanding what you are hoping to achieve with your data, you will need to pick the right machine learning task for your situation. Below, you can find an explanation of different machine learning tasks and some common use cases. 

> [!NOTE]
> ML.NET is currently in Preview. All machine learning tasks are not currently supported. To submit a request for a certain task, please open an issue on our [GitHub repository](https://github.com/dotnet/machinelearning/issues).

## Binary Classification
A supervised machine learning task that is used to predict which of two classes an instance of data belongs to. The input of a classification algorithm is a set of labeled examples. Each example is represented as a feature vector, and each label is an integer of value of 0 or 1. The output of a binary classification algorithm is a classifier, which can be used to predict the label of new unlabeled instances. Examples of binary classification scenarios include:

* Understanding sentiment of Twitter comments as either "positive" or "negative"
* Diagnosing whether a medical patient has a certain disease or not
* Making a decision to send an email to a "spam" folder or not

## Multi-class Classification
A supervised machine learning task that is used to predict the category of an instance of data. The input of a classification algorithm is a set of labeled examples. Each example is represented as a feature vector, and each label is an integer between 0 and k-1, where k is the number of classes. The output of a classification algorithm is a classifier, which can be used to predict the label of a new unlabeled instance. Examples of multi-class classification scenarios include:

* Determining the breed of a dog as a "Siberian Husky", "Golden Retriever", "Poodle", etc.
* Understanding movie reviews as "positive", "neutral", or "negative"
* Categorizing hotel reviews as "location", "price", "cleanliness", etc.

> [!NOTE]
> Currently, ML.NET does not support classification tasks for images. Support will be added in a future release. 

## Regression
A supervised machine learning task that is used to predict the value of a continuous dependent variable from a set of related independent variables. Regression algorithms model this relationship to determine how the typical values of dependent variables change as the values of the independent variables are varied. The input of a regression algorithm is a set of examples with dependent variables of known values. The output of a regression algorithm is a function, which can be used to predict the value of a new data instance whose dependent variables are not known. Examples of regression scenarios include:

* Predicting house prices based on house attributes such as number of bedrooms, location, size, etc.
* Predicting future stock prices based on historical data and current market trends
* Predicting sales of a product based on advertising budgets

> [!NOTE]
> Currently, ML.NET does not support regression tasks that involve time series. Support will be added in a future release. 

## Clustering
An unsupervised machine learning task that is used to groups cases in a dataset into cluster that contain similar characteristics. Clustering can also be used to identify relationships in a dataset that you might not logically derive by browsing or simple observation. The inputs and outputs of a clustering algorithm depends on methodology chosen. You can take a distribution, centroid, connectivity, or density-based approach. ML.NET currently supports a centroid-based approach using [K-Means]() clustering. Examples of clustering scenarios include:

* Defining segments of hotel guests based on habits and characteristics of hotel choices
* Identifying ways to build targeted ad campaigns based on customer demographics
* Categorizing inventory based on manufacturing metrics

## Anomaly detection (*coming soon*)

## Ranking (*coming soon*)

## Recommendation (*coming soon*)


# Machine Learning Introduction

## Rule-based vs Machine learning

Rule-based solutions should be used if:
- problem statement is fairly simple
- rules are simple and can be codified
- rules do not change frequently
- few or no training data set

## Supervised learning

 - models can make predictions after seeing lots of data with the correct answers and then discovering the connections between the elements in the data that produce the correct answers
 - a __regression model__ predicts a numeric value. Example: future house price. Input data: square footage, zip code, # of bedrooms. Output: the price of the house
 - a __classification model__ predicts the likelihood that something belongs to a category. Example: predict if an email is spam
 - classification models are divided into two groups: binary classification and multiclass classification
 - supervised machine learning is based on the following core concepts:
    - Data: datasets are made up of individual examples that contain __features__ and a __label__. 
    - Model: a complex collection of numbers that define the mathematical relationship from specific input feature patterns to specific output label values
    - Training: the model finds the best solution by comparing its predicted value to the label's actual value. Based on the difference between the predicted and actual values — defined as the __loss__ — the model gradually updates its solution.
    - Evaluating: 
    - Inference: make predictions on unlabeled dataset

## Unsupervised learning

- unsupervised learning models make predictions by being given data that does not contain any correct answers. An unsupervised learning model's goal is to identify meaningful patterns among the data.
-  unsupervised learning model employs a technique called __clustering__ (example: clustering images of cats and dogs). Clustering differs from classification because the categories aren't defined by you. 
- other algorithms for unsupervised learning are __association__ (example: you buy shampoo and get a recommandation for conditioner) and __anomaly detections__(example: a credit card is being used in 2 different cities in a matter of minutes). __Dimensionality reduction__ is used to find latent or significant features in your data. Is generally used as a preprocess step.

## Reinforcement learning

- reinforcement learning models make predictions by getting __rewards__ or __penalties__ based on __actions__ performed within an environment. A reinforcement learning system generates a __policy__ that defines the best strategy for getting the most rewards.

## Generative AI

- generative AI is a class of models that creates content from user input. For example, generative AI can create unique images, music compositions, and jokes; it can summarize articles, explain how to perform a task, or edit a photo.
-  generative models learn patterns in data with the goal to produce new but similar data

## Solution categories

|Use case|Problem|
|--------|-------|
|Image data                        |Convolutional Neural Networks|
|Complex textual data              |Recurrent Neural Networks|
|Sequential or time series data    |Recurrent Neural Networks|
|Linear x-variables                |Linear and logistic regression, PCA|
|Twisted data(S-curves, Swiss Rols)|Manifold learning|
|Large numbers of x-variables      |Decision trees|

## Machine learning frameworks
- scikit-learn - easy to use for regression, classification, clustering
- XGBoost for boosting scikit-learn
- pytorch  - high level abstraction for deep neural networks
- tensorflow - end to end soluton for deep neural networks
- keras - hight level neural networks api running on top of tensorflow

## ML Cheatsheets

![](images/overview/cheatsheet1.png) 
![](images/overview/cheatsheet2.png) 
![](images/overview/cheatsheet3.png) 
![](images/overview/scikit_learn_cheatsheet2.png) 
![](images/overview/scikit_learn_cheatsheet.png) 


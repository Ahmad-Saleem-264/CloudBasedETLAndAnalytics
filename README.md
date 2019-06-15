The aim of the project was to combine data of githiub and stackoverflow and unravel the interesting analytics. Following two datasets were used
libraries.io data set: www.kaggle.com/librariesdotio/libraries-io
stackoverflow data set: www.kaggle.com/stackoverflow/stackoverflow

libraries.io contains all the information regarding a program library created for any programming language including but not limited to its creation date, any updates, any issues the user might have faced, their popularity, etc.

stackoverflow data set contains questions faced by the programming community. The data set contains everything related to questions. The answers, up votes, and etc.

The main idea was to analyze the trends regarding programming languages and the main reason behind merging these two data sets is that the data from stackoverflow adds to the information of languages and libraries in the data from labraries.io.

The data was fetched from google big query and transformed and loaded into azure sql warehouse using data factory. The data was further cleaned and transformed using sql and custom scripts. PowerBi was used to create to create the visualizations. PowerBI graphs were hosted on powerbi.com and the powerbi was connected to azure and graphs were getting live data from azure warehouse




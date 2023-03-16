from audioop import mul
import csv
from turtle import color
import pandas as pd
from pydataset import data
import numpy as np
import matplotlib.pyplot as plt
import matplotlib.pyplot as mp
from matplotlib import pyplot as plt

# the program imports a data set 'Maternal Health Risk Data set.csv' and prints uses the matplotlib library to plot graphs as required by the course instructor.

file = pd.read_csv('Maternal Health Risk Data set.csv')
print (file)
Diastolic_BP=file['DiastolicBP']
Systolic_BP=file['SystolicBP']
Age = file['Age']
Bs = file['BS']
Bs = round(Bs, 0)
Body_Temp = file['BodyTemp']
Body_Temp = round(Body_Temp)    
HeartRate = file ['HeartRate']
RiskLevel =file['RiskLevel']    


#1
file = file.head()
multiple = pd.DataFrame(file, columns=["RiskLevel", "SystolicBP", "DiastolicBP"])
multiple.plot(x="RiskLevel", y=["SystolicBP", "DiastolicBP"],color = ['red' ,'cyan'] ,kind="bar", figsize=(9, 8))
plt.ylabel("Blood Pressure")
mp.show()

#2
multiple_1 = pd.DataFrame(file, columns=["BodyTemp", "SystolicBP", "DiastolicBP"])
multiple_1.plot(x="BodyTemp", y=["SystolicBP", "DiastolicBP"],color = ['red' ,'cyan'] ,kind="bar", figsize=(9, 8))
plt.ylabel("Blood Pressure")
mp.show()

#9
plt.bar(Body_Temp, HeartRate, color = 'g', width = 0.5, label = "Body temp")
plt.xlabel('Body Temperature')
plt.ylabel('Heart Rate')
plt.title('Body temperature against heart rate')
plt.legend()
plt.show()

#8
plt.bar(Body_Temp, Bs, color = 'g', width = 0.5, label = "Body temp")
plt.xlabel('Body Temperature')
plt.ylabel('Blood Sugar')
plt.title('Body temperature against Blood sugar')
plt.legend()
plt.show()

#7a
plt.figure(figsize=(20,20))
plt.bar(Systolic_BP, Bs, color = 'cyan',  label = "Systolic blood pressure")
plt.xlabel('Systolic blood pressure')
plt.ylabel('Blood Sugar')
plt.title('Blood pressure against Blood sugar')
plt.legend(loc = 'upper right')
plt.show()

#7b
plt.figure(figsize=(12,12))
plt.bar(Diastolic_BP, Bs, color = 'red', label = "Diastolic blood pressure")
plt.xlabel('Diastolic blood pressure')
plt.ylabel('Blood Sugar')
plt.title('Heart rate against Blood sugar')
plt.legend(loc = 'upper right')
plt.show()

#6
plt.figure(figsize=(12,12))
plt.bar(HeartRate, Bs, color = 'orange',  label = "Heart rate")
plt.xlabel('Heart Rate')
plt.ylabel('Blood Sugar')
plt.title('Heart rate against Blood sugar')
plt.legend()
plt.show()

#4a
RiskLevel.sort_values()
plt.scatter(Age, RiskLevel, color = 'black' )
plt.xlabel('Age')
plt.ylabel('Risk Level')
plt.title('Age against Risk Level')
plt.legend()
plt.show()

#4b  
plt.bar(Age - 0.2, Diastolic_BP,color = 'red' ,width= 0.4, label = 'Diastolic blood pressure')
plt.bar(Age + 0.2, Systolic_BP, color = 'cyan',width= 0.4, label = 'Systolic blood pressure')

plt.xlabel('Age')
plt.ylabel('Blood pressure')
plt.title('Age against Blood pressure')
plt.legend()
plt.show()
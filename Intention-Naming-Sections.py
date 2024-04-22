# -*- coding: utf-8 -*-
"""
Created on Sat Feb 24 01:24:47 2024

@author: Ramona
"""

import pandas as pd
from openai import OpenAI

api_key = "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"
client = OpenAI(api_key=api_key)
frequentPatterns = pd.read_csv('G:/Other computers/My Laptop/Intention Mining/Logs/BP-Meets-IoT2021/sim_21d1p/StrategyNamesList-toBeUsed.csv')
#frequentPatterns = pd.read_csv('G:/Other computers/My Laptop/Intention Mining/Logs/BP-Meets-IoT2021/sim_21d1p/StrategyNamesList-toBeUsed.csv',header=None)


sections = pd.read_csv('G:/Other computers/My Laptop/Intention Mining/Logs/BP-Meets-IoT2021/sim_21d1p/map-sections.csv',header=None)
sectionsList =sections.values.tolist()
namedIntentionsList=[]
for row in sectionsList:
  currentRow=[]
  if not any(row[1] in item for item in namedIntentionsList):
    activityList=frequentPatterns[frequentPatterns["PatternTypeName"] == row[2]]
    if row[2] !="CompleteStrategy":
      response = client.chat.completions.create(
                          model="gpt-3.5-turbo",
                          messages=[
                            {
                              "role": "system",
                              "content": "You will be provided by a set of three items where the third one represent the strategy that was used to accomplish the target intention and you need to guess the target intention which represents the second item in the set. So if the strategy of the activities used is " +
                               str(row[2]) + " where this is the activities list ( [" + 
                              str(activityList) +" ]) then what would be the Intention which indicates the intention of doing these activities. ( your response  should be a single clear expressive verb only)"
                            },
                          { "role": "user",
                           "content": " " + str("<" + row[0] +", "+ row[1] +", "+ row[2]+">") + " "
                            }
                          ],
                          temperature=0.8,
                          max_tokens=64,
                          top_p=1
                        )
      item=[row[1],  response.choices[0].message.content]
      namedIntentionsList.append(item)
    # for existingItem in sectionsList:
    #     if existingItem[1] == row[1]:
    #        existingItem[1] = response.choices[0].message.content
    #     if existingItem[0] == row[1]:
    #        existingItem[0] = response.choices[0].message.content
    #row[1]=  row[1].replace( row[1], response.choices[0].message.content)

    # print(" " + str("<" + row[0] +", "+ row[1] +", "+ row[2]+">") + " ")
    # print(activityList)
    # print(response.choices[0].message.content)
#print(sectionsList)   
print(namedIntentionsList)
for intention in namedIntentionsList:
    for row in sectionsList:
        if row[0].lower() == intention[0].lower():
            row[0]= intention[1]
        if row[1].lower() == intention[0].lower():
             row[1]= intention[1]
        
        
        
             
pd.DataFrame(sectionsList).to_csv("G:/Other computers/My Laptop/Intention Mining/Logs/BP-Meets-IoT2021/sim_21d1p/SectionsNamesList.csv")
    
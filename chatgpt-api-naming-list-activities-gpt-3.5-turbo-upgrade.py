# -*- coding: utf-8 -*-
"""
Created on Fri Feb 23 03:01:11 2024

@author: Ramona
"""

# -*- coding: utf-8 -*-
"""
Created on Tue Oct 31 01:45:20 2023

@author: Ramona
"""

import pandas as pd

from openai import OpenAI

api_key = "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"
client = OpenAI(api_key=api_key)


allevents = pd.read_csv('G:/Other computers/My Laptop/Intention Mining/Logs/BP-Meets-IoT2021/sim_21d1p/PrefixSpan_filteredFrequentPatterns-toBeUsed.csv')
strategyNames =[]
for row in allevents.values.tolist():
    cleanedRowActivity = [x for x in row if x == x]
   #print(cleanedRowActivity)
    strategyName =[]
    strategyName.append((cleanedRowActivity))
    for i in range((10)):
       
        
        response = client.chat.completions.create(
          model="gpt-3.5-turbo",
          messages=[
            {
              "role": "system",
              "content": "You will be provided by a list of activities and your task is to give me a short single specific name that describes this list of activities combined together without adding a new activity to the list:"
            },
            {
              "role": "user",
              "content": " " + str(cleanedRowActivity ) + " "
            }
          ],
          temperature=0.8,
          max_tokens=64,
          top_p=1
        )
        
        print(response.choices[0].message.content)
        activity_name = response.choices[0].message.content#response.choices[0].text.strip()
        print("############################################")
        print("Activity List:", cleanedRowActivity)
        print("Generated Activity Name:", activity_name)
        print("############################################")
        strategyName.append((activity_name))
    strategyNames.append(strategyName)
pd.DataFrame(strategyNames).to_csv("G:/Other computers/My Laptop/Intention Mining/Logs/BP-Meets-IoT2021/sim_21d1p/StrategyNamesList.csv")
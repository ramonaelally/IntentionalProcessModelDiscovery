# -*- coding: utf-8 -*-
"""
Created on Mon Aug 14 23:58:18 2023

@author: Ramona
"""

# -*- coding: utf-8 -*-
"""
Created on Sun Apr 17 22:52:07 2022

@author: Ramona
"""

# -*- coding: utf-8 -*-
"""
Created on Sun Jan  9 00:22:24 2022

@author: Ramona
"""

# -*- coding: utf-8 -*-
"""
Created on Sat Jan  8 23:06:20 2022

@author: Ramona
"""
import pandas as pd
allevents = pd.read_csv('G:/Other computers/My Laptop/Intention Mining/Logs/BP-Meets-IoT2021/sim_21d1p/EventLog_1person-Coding-Modified.csv',usecols= ["ActivityName", "ResourceId", "Timestamp","Transition","EventId","CaseName","TraceId","Value","Position","Day"])



frames = [allevents]
result = pd.concat(frames)


result["Timestamp"] = pd.to_datetime(result["Timestamp"])


result = result.sort_values(by="TraceId")
allevents_list = allevents.values.tolist()

all_transactions=[]
traceId=0
current_row=[]
previousValue=''
currentCase =''
for i,row in enumerate(allevents_list):
  
          
          if(traceId == row[6] ):
                  
                  if previousValue !=row[0]:
                   current_row.append(row[0])
          else:
              previousValue=''
              all_transactions.append(current_row)
              current_row=[]
              if previousValue !=row[0]:
                   current_row.append(row[0])
          previousValue =row[0]        
          traceId = row[6]
          
  
          
   
#print(all_transactions)  
print(len(all_transactions))  
pd.DataFrame(all_transactions).to_csv("G:/Other computers/My Laptop/Intention Mining/Logs/BP-Meets-IoT2021/sim_21d1p/all_transactions_sequences.csv")


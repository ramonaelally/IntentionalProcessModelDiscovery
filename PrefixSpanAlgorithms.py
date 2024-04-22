from prefixspan import PrefixSpan

sequences = [
    ['A', 'B', 'C', 'D'],
    ['A', 'B', 'D'],
    ['B', 'C', 'A', 'D'],
    ['C', 'D']
]




from csv import reader

import pandas as pd
allevents = pd.read_csv('G:/Other computers/My Laptop/Intention Mining/Logs/BP-Meets-IoT2021/sim_21d1p/all_transactions_sequences.csv')



frames = [allevents]
result = pd.concat(frames)
result=result.iloc[: , 1:]
#print(result)
#res = result.to_string(header=False,index=False,index_names=False).split('\n')
all_transactions=[]
traceId=0
current_row=[]

for index, row in result.iterrows():
  #print(row)
                
  res=row.dropna().to_string(header=False,index=False).split('\n')
  # Adding a comma in between each value of list
  res = [','.join(ele.split()) for ele in res]  
  #current_row.append(res)
  all_transactions.append(res)

#print(all_transactions)
ps = PrefixSpan(all_transactions)
result = ps.frequent(1)  # Minimum support threshold

# for pattern, support in result:
#     print(pattern, support)

#Filter out patterns with less than three items
# filtered_result = [(support,pattern ) for  support,pattern in result if len(pattern) >= 2]
# pd.DataFrame(filtered_result).to_csv("G:/Other computers/My Laptop/Intention Mining/Logs/BP-Meets-IoT2021/sim_21d1p/PrefixSpan_frequentPatterns-temp.csv")

# # Filter out patterns with less than three items and get unique patterns
# unique_patterns = set()
# filtered_result = []
# for pattern, support in result:
#     if len(support) >= 3 and tuple(support) not in unique_patterns:
#         filtered_result.append((pattern, support))
#         unique_patterns.add(tuple(support))

# # Filter out patterns with less than three items and get unique patterns
# unique_patterns = set()
# filtered_result = []
# for support, event in result:
#     sorted_event = sorted(event)
#     unique_items = [item for item in sorted_event if sorted_event.count(item) == 1]
#     if len(unique_items) >= 1:
#         unique_event = tuple(unique_items)
#         if unique_event not in unique_patterns:
#             filtered_result.append((support, unique_event))
#             unique_patterns.add(unique_event)
            


def is_subset_with_additional(itemset, candidate_sets):
    for c in candidate_sets:
        if set(itemset[0:(len(itemset))]).issubset(set(c)):
            #if itemset[1] == "wash_dishes": print (itemset[0:(len(itemset))])
        #if set(itemset).issubset(set(c)):
            return True
    return False

# Filter out patterns with less than three items and get unique patterns
unique_patterns = []
for support, event in result:
    sorted_event = sorted(event)
    unique_items = list(event) #list(dict.fromkeys(event))  # Remove duplicate items while preserving order
    #print(unique_items)
    if len(unique_items) >= 2:
        add_pattern = True
        
        # Check if the pattern is a subset with an additional item of any existing pattern
        if is_subset_with_additional(unique_items, [pattern for _, pattern in unique_patterns]):
            add_pattern = False
            #if unique_items[1] == "wash_dishes": print (unique_items)
        
        if add_pattern:
            #unique_patterns = [p for p in unique_patterns if not set(unique_items[:-1]).issubset(set(p[1][:-1]))]
            unique_patterns.append((support, unique_items))
            

# def is_subset_with_additional(itemset, candidate_sets):
#     for c in candidate_sets:
#         if set(itemset[:-1]).issubset(set(c)):
#             return True
#     return False

# def is_subset(itemset, candidate_sets):
#     for c in candidate_sets:
#         if set(itemset).issubset(set(c)):
#             return True
#     return False


            
pd.DataFrame(unique_patterns).to_csv("G:/Other computers/My Laptop/Intention Mining/Logs/BP-Meets-IoT2021/sim_21d1p/PrefixSpan_frequentPatterns.csv")

# Python3 program to find whether an array
# is subset of another array

# Return true if arr2[] is a subset of arr1[]


def isSubset(arr1, m, arr2, n):

	# Create a Frequency Table using STL
	frequency = {}

	# Increase the frequency of each element
	# in the frequency table.
	for i in range(0, m):
		if arr1[i] in frequency:
			frequency[arr1[i]] = frequency[arr1[i]] + 1
		else:
			frequency[arr1[i]] = 1

	# Decrease the frequency if the
	# element was found in the frequency
	# table with the frequency more than 0.
	# else return 0 and if loop is
	# completed return 1.
	for i in range(0, n):
		if (frequency[arr2[i]] > 0):
			frequency[arr2[i]] -= 1
		else:
			return False

	return True


# # Driver Code
# if __name__ == '__main__':

# 	arr1 = [11, 1, 13, 21, 3, 7]
# 	arr2 = [11, 3, 7, 1]

# 	m = len(arr1)
# 	n = len(arr2)

# 	if (isSubset(arr1, m, arr2, n)):
# 		print("arr2[] is subset of arr1[] ")
# 	else:
# 		print("arr2[] is not a subset of arr1[] ")

# # This code is contributed by akhilsaini




# filteredPatterns=[]
# for support, item in unique_patterns:
#     print(item)
#    # print((is_subset_with_additional(item,filteredPatterns)))
#     #print(((is_subset_with_additional(filteredPatterns,item))))
#     print(filteredPatterns)
#     if not (is_subset_with_additional(item,[pattern for _, pattern in filteredPatterns])):
#         # if   item not in filteredPatterns :
#         #      filteredPatterns.append((support, item))
#         # else:
#         if len (filteredPatterns)==0:
#             filteredPatterns.append((support, item))
#         else:
#          isFound=False
#          for filteredSupport, filteredItem in filteredPatterns:
#             # if isSubset(filteredItem,len(filteredItem),item, len(item)):
#             #     filteredPatterns.remove(filteredItem)
            
#            if all(x in filteredItem for x in item):
#                 isFound=True
#                 break;

#            # if  (is_subset_with_additional(filteredItem, item) and filteredSupport == support):
#            if isFound:
#             filteredPatterns.remove(filteredItem)
#             filteredPatterns.append((support, item))
#            else:
#               filteredPatterns.append((support, item))
def is_subset(sublist, superlist):
    return set(sublist).issubset(set(superlist))

def remove_subsets(arrays):
    filtered = []
    for current_list in arrays:
        is_subset_of_another = any(is_subset(current_list, other_list) for other_list in arrays if other_list != current_list)
        if not is_subset_of_another:
            filtered.append(current_list)
    return filtered

filtered_data = remove_subsets([pattern for _, pattern in unique_patterns])

pd.DataFrame(filtered_data).to_csv("G:/Other computers/My Laptop/Intention Mining/Logs/BP-Meets-IoT2021/sim_21d1p/PrefixSpan_filteredFrequentPatterns.csv")
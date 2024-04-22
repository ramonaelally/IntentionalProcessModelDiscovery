# -*- coding: utf-8 -*-
"""
Created on Sat Feb 24 04:12:28 2024

@author: Ramona
"""


import networkx as nx
import matplotlib.pyplot as plt
import matplotlib.patches as patches
import pandas as pd
# Define the directed graph
G = nx.DiGraph()
df = pd.read_csv('G:/Other computers/My Laptop/Intention Mining/Logs/BP-Meets-IoT2021/sim_21d1p/SectionsNamesList.csv',header=None,skiprows=1)
data = [(row[1], row[2], row[3]) for index, row in df.iterrows()]
print (data)
# Define the data
# data = [
# ("Intention8","Intention0","Bed Preparation"),
# ("Intention3","Intention1","Hydration Routine"),
# ("Intention10","Intention1","Hydration Routine"),
# ("Intention6","Intention1","Hydration Routine"),
# ("Intention7","Intention10","Ventilation"),
# ("Intention8","Intention11","Outdoor Dressing and Food Preparation"),
# ("Intention13","Intention12","Fitness Routine"),
# ("Intention1","Intention13","Managing window settings"),
# ("Intention8","Intention14","Outdoor Dress Up and Walk"),
# ("Intention0","Intention16","Completed End Strategy"),
# ("Intention1","Intention16","Completed End Strategy"),
# ("Intention1","Intention2","Housekeeping"),
# ("Intention0","Intention3","Clothing Routine"),
# ("Intention7","Intention3","Clothing Routine"),
# ("Intention1","Intention4","Computer Usage  Routine"),
# ("Intention0","Intention5","Encountering"),
# ("Intention4","Intention6","Meal Preparation and Eating"),
# ("Intention5","Intention6","Meal Preparation and Eating"),
# ("Intention12","Intention7","Hygiene routine"),
# ("Intention1","Intention7","Hygiene routine"),
# ("Intention11","Intention7","Hygiene routine"),
# ("Intention15","Intention7","Hygiene routine"),
# ("Intention7","Intention8","Chair Relaxation"),
# ("Intention2","Intention8","Chair Relaxation"),
# ("Intention9","Intention8","Chair Relaxation"),
# ("Intention6","Intention9","Kitchen Chores"),
# ("Intention14","Intention9","Kitchen Chores")
# ]

# Add nodes and edges to the graph
for intention_from, intention_to, strategy in data:
    G.add_node(intention_from, shape='oval')
    G.add_node(intention_to, shape='oval')
    G.add_edge(intention_from, intention_to, label=strategy)

# Use spring_layout with increased iterations
#pos = nx.spring_layout(G, iterations=5000)
pos = nx.kamada_kawai_layout(G)

# Set a larger figure size
plt.figure(figsize=(20, 12))

# Set the width and height of the nodes
node_width = 0.3
node_height = 0.1

# Draw oval-shaped nodes with explicit width and height
for node, (x, y) in pos.items():
    ellipse = patches.Ellipse((x, y), width=node_width, height=node_height, edgecolor='saddlebrown', facecolor='mediumaquamarine', angle=0)
    plt.gca().add_patch(ellipse)

    # Calculate the center coordinates of the ellipse
    center_x = x
    center_y = y

    # Draw labels in the center of the ellipse
    plt.text(center_x, center_y, node, ha='center', va='center', fontsize=16, color='black')

# Draw longer edges
nx.draw_networkx_edges(G, pos, width=1.0, alpha=1, arrowsize=20)

# Draw edge labels in the middle of the two nodes
for edge in G.edges():
    x, y = (pos[edge[0]] + pos[edge[1]]) / 2 - 0.02 # Calculate the midpoint
    #print("######")
    label = G[edge[0]][edge[1]]['label']
    #print(label)
    #print(x,y)
    #print("###")
    plt.text(x, y, label, ha='center', va='center', fontsize=14, color='saddlebrown')
    




# # Draw longer edges
# for edge in G.edges():
#     x0, y0 = pos[edge[0]] 
#     x1, y1 = pos[edge[1]]  
    
#     # Calculate the midpoint
#     x_mid = (x0 + x1) / 2
#     y_mid = (y0 + y1) / 2
    
#     # Draw the edge with annotation for the label
#     plt.annotate("", xy=(x1, y1), xytext=(x0, y0), arrowprops=dict(arrowstyle="->", connectionstyle="arc3", lw=1.5), alpha=0.8)
#     #plt.annotate("", xy=(x1, y1), xytext=(x0, y0), arrowprops=dict(arrowstyle="->", connectionstyle="arc3,rad=0.1", lw=1.5), alpha=0.5)

#     # Add the label
#     label = G[edge[0]][edge[1]]['label']
#     plt.text(x_mid, y_mid, label, ha='center', va='center', fontsize=10, color='black')

# # Draw longer edges with a little offset
# for edge in G.edges():
#     x0, y0 = pos[edge[0]]+0.01
#     x1, y1 = pos[edge[1]]+0.01
    
#     # Calculate the edge offset
#     offset = 0.2
    
#     # Draw the edge
#     plt.arrow(x0, y0, (x1 - x0) * (1 - offset), (y1 - y0) * (1 - offset), head_width=0.01, head_length=0.01, fc='black', ec='black')
    
#     # Add the label
#     label = G[edge[0]][edge[1]]['label']
#     plt.text((x0 + x1) / 2, (y0 + y1) / 2, label, ha='center', va='center', fontsize=10, color='black')

# # Draw edges with arrows
# for edge in G.edges():
#     x0, y0 = pos[edge[0]]
#     x1, y1 = pos[edge[1]]

#     # Calculate the label position
#     label_pos = ((x0 + x1) / 2, (y0 + y1) / 2)

#     # Add the label outside the nodes using connectionstyle
#     label = G[edge[0]][edge[1]]['label']
#     plt.annotate(label, xy=(x0, y0), xytext=(x1, y1),
#                  arrowprops=dict(arrowstyle="->", connectionstyle="arc3,rad=.01", mutation_scale=2))


# Show the graph
plt.axis('off')
plt.show()

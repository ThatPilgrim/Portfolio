import random
import math
import time

# The answer to the Equation is a factor of 10 once.

inside = 0
outside = 0
iterations = 1000000*10

#INSERT CODE TO SEED THE RANDOM NUMBER GENERATOR HERE
random.seed(int(round(time.time()*1000)))

for i in range(iterations):
    # select two random numbers between 0 and 1
    x = random.uniform(0,1)
    y = random.uniform(0,1)
    
    # calculate distance from origin
    origin_distance = math.sqrt (x**2 + y**2)

    # increment the appropriate counter
    if origin_distance <=1 :
        inside +=1
    else: 
        outside +=1    

# calculate the value of Pi 
    pi = 4 * (inside / (inside + outside))

# print result
print (pi)



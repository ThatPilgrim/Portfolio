#COMMENTS BELOW ARE FOR QUESTIONS ASKED BY THE INSTRUCTOR
#ADD COMMENTS AS APPROPRIATE AS WELL AS THE DATA DICTIONARY
#PART 2: 11
#PART 3: CORRECTLY REPRESENTED - 0.15, 0.16
#        INCORRECTLY REPRESENTED - 0.14(written as 0.1399...) , 0.11(written as 0.10999...)

#Numbers are stored as binary digits(0s and 1s). Not all numbers can be represented in binary with a finite set of numbers.

#PART 4: The error is better with the decimal package.
#The decimal package apporoximates the numbers which reduces the numbers after the decimal point and therefore the chances of error
#(during addition).

import decimal
from decimal import Decimal

sum = 0
toAdd = .1

#ENTER NUMBER OF ITERATIONS HERE
max = 100

for i in range (0, max, 1):
        sum = sum + toAdd
        print(sum, i)
        
#ADD A PRINT STATEMENT HERE THAT PRINTS (WHEN THE LOOP IS FINISHED) THE NUMBER OF ITERATIONS, THE NUMBER YOU ADDED, THE SUM YOU CALCULATED
#,AND THE DIFFERENCE BETWEEN THE CORRECT RESULT AND YOUR SUM

#To print the number of iterations
print ('The number of iterations is',max)

#To print the number added
print ('The number added is', toAdd)

#To print the summ calculated
print ('The sum calculated is', sum)

#T0 THE DIFFERENCE BETWEEN THE CORRECT RESULT AND YOUR SUM
x = 10 - sum
print ("The difference is", x)


#New Loop
summ = Decimal('0.0')
toAddd = Decimal ('.1')

#NUMBER OF ITERATIONS   
maxx = 1000

for i in range (0, maxx, 1):
        summ = summ + toAddd
        print(summ, i)

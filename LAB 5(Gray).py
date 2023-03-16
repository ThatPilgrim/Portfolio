#Code ot put an image in grey scale
import matplotlib.pyplot 
import numpy as np

myImage = matplotlib.pyplot.imread('flower.png')


height=myImage.shape[0]
width=myImage.shape[1]

for x in range(0, height-1):   
   for y in range(0,width-1):
     r = myImage[x,y,0]
     b = myImage[x,y,1]
     g = myImage[x,y,2]
     grey_scale = (r+b+g) / 3
     myImage[x,y] = grey_scale




imgplot = matplotlib.pyplot.imshow(myImage, cmap = 'gray')
matplotlib.pyplot.show()
#imgplot = matplotlib.pyplot.imshow(myImage [100:650 , 350:950])

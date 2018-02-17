# Spiking-Neural-Network-Simple-Classifier
this project was my final project of Computational Neural science course in University of Tehran in Computer science department. it's very simple with just one layer of spiking neurons and two neurons that classify the learned objects. it uses Intensity to latency coding model and STDP learning 

the program is written in C# with a simple UI that you can see the neurons learn objects, it can learn two object unsupervised , but you can increase the number of objects wich it could learn by adding more classifiering neurons.
At the beginning it uses a very simple gabor filter which is a 3*3 matrix for detecting lines in 0 , 45 , 90 and 135 degrees orientations.
then there are four types of neurons in responding to corelated oriantation.
there is two type of datasets one made by windows paint and another downloaded from http://www.vision.caltech.edu 
you can find them in the root folder of project
it can learn and then classify these two datasets very well , but has problems with other type of images. 
I think it could be much better, I just spend two days working on it :)

# SyncVR-Assignment
Fibonacci assigment by Luca Ruiters
![Simple Quiz](https://2cano.tech/wp-content/uploads/2021/09/Fibonizer_01.jpg) 

# Instructions
Everything you need to know on how to play this assignment will be shown at the start when you press play. To summarize, as the user you participate in a quiz about the Fibonacci sequence. You will have to enter as many Fibonacci numbers in the correct order. When you're stuck use a hint (this will show the next number and a simple formula).

# Design Choices
To get started, I had to find a way to make the Fibonacci sequence more fun. Just clicking a button to see the next number isn't much fun. To make it more challenging and fun, I implemented a quiz-like system. The user has to "guess" the next number.

To prevent users from being completely stuck. I have added a hint button. The hint button will show you the following number and a formula to calculate the number after. To prevent users from just spamming the hint button, I added a small cooldown to it.

Another mechanic I added is shrinking numbers; this will make it more challenging since you will have to use the previous numbers to calculate the next. This also gives you the feeling of time pressure without actually having any time limit.

While all the mechanics above are fun, without any feedback the game still feels boring. I added some audio effects to make it more engaging. When you "guess" the correct number, a crowd clap as encouragement.

Last but not least, I added a simple welcome screen to tell the user how to play the experience. Which can be seen in the image below.
![Welcome Screen](https://2cano.tech/wp-content/uploads/2021/09/Fibonizer_02.jpg)

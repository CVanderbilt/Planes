# Planes

## Introduction
Inspired by SNES game [U.N. Squadron](https://es.wikipedia.org/wiki/U.N._Squadron).It is a 2D side scroller plane shooter that features different types of enemies, including a boss fight (kind of). It was the first project I did on my own, withouth following a tutorial, turned out being a great learning experience but the code structure is non existent.  

### How it works
The player controlls a plane that can move side-ways as well as up and down, the environment is moving from left to right creating the ilusion of movement (I didnt add a moving background but enemies like turrets are supposed to be static but are steadily moving to the left, creating this illusion).  
The player shoots projectiles which, instead of being instantiated by creating objects they are preloaded and activated or deactivated when needed (polling)
If the player crashes with an enemy or its hitted by an enemy projectile it will loose a live (shown as a healthbar), and like in the U.N. Squadron game, during a brief period of time it will be vulnerable to die withing only one attack (two consecutive hits and the player is dead, even if the health bar was full).

See demo [here](https://drive.google.com/file/d/17w908gKJeiXT_ek3UJBFH5gc5xkCnGVI/view?usp=drive_link)
### Animations
Player animations are really simple. The plane has three sprites, going up, going down and idle, the player projectiles are not animated. 
The enemies are made with the same sprite, which is an alien looking space ship that rotates, the different enemies that we can have are:
* Turret: Made by one of the base alien ship placed as a base with another ship resized and reverted so that it looks like a cannon. The cannon points to the player.
* Chopper: This is the base sprite as it was, with the animation untouched so it rotates. However it moves like a helicopter, never changing the direction it is facing so it is actually pointing up.
* Planes: This is also the basic sprite but I choose specific frames and reverted the direction. The sprites change to make the animation of a loop when changing directions, kind of like in the original game.
* Asteroid boss: Made up by thre large asteroids, they have regular turrets in them and a new sprite that is a missile turret which throws homing missiles to the player and it can only be destroyed by destroying the asteroid after killing each turret.

### Level Design
The game's level is designed with waves of enemies instantiated every five seconds. Each wave is composed of prefab enemy configurations, with various movements:

- Turrets: Appear static, moving from right to left at a constant speed as the plane advances.
![alt text](https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExNDI1NTBtOTd4ZjA2cG50dG9ta3Q2N3B2N3NpYXc3MHYyeWZvaDJhNSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/NYArk1UlfRCH0l5a8I/giphy.gif "SampleAnimation")
- Choppers: Follow pre-set paths using nodes in straight lines, despawning after reaching the last node.
![alt text](https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExczBqdzJod2RwaHcxYzl4MnZkc3BhYmRhajBpZXd2cm9yaXhwcHh3OCZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/DxfY7cLLtFlpnpk8Wk/giphy.gif "SampleAnimation")
- Planes: Follow specified curves and turns, offering various movement patterns.
![alt text](https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExN3E1d2QzY284OWlvMzJ2ZDI0NHg0YnJzYXhteXI2dGNqNHQwbXU3dSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/1uaK5D6txKpBjgtHNK/giphy.gif "SampleAnimation")
- Asteroid Boss: Moves to a defined destination and remains there. It consists of large asteroids with rotating and orbiting parts.
![alt text](https://media.giphy.com/media/v1.Y2lkPTc5MGI3NjExeXlqNG5neGV6djNyMGMyczEwb242eWJhMXd1eWg4YjAzN2R0aTFkNSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/W9RcrerJBA8y7LKOj3/giphy.gif "SampleAnimation")

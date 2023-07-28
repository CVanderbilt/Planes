# Planes

## Introduction
Planes is a 2D side-scrolling plane shooter game, inspired by the SNES game [U.N. Squadron](https://es.wikipedia.org/wiki/U.N._Squadron). It features various enemy types, including a boss fight. This project was my first solo endeavor, providing an excellent learning experience, although the code structure is still a work in progress.

![alt text](https://drive.google.com/file/d/1zi93IClCxb0DSpAtWPzPd9dBNXqf5_HY/view?usp=drive_link "Demo")

### How it Works
In the game, the player controls a plane that can move sideways, up, and down. The environment moves from left to right, creating an illusion of movement. Projectiles are preloaded and activated or deactivated when needed (polling) instead of instantiating objects. Colliding with enemies or enemy projectiles depletes the player's health, rendering them vulnerable to being defeated with a single attack for a brief period.

### Animations
Player animations are basic, featuring three sprites: going up, going down, and idle. Enemy animations are also simplistic, using the same sprite of an alien-looking spaceship that rotates. Different enemy types are created from variations of this sprite.

### Level Design
The game's level is designed with waves of enemies instantiated every five seconds. Each wave is composed of prefab enemy configurations, with various movements:
- Turrets: Appear static, moving from right to left at a constant speed as the plane advances.
![alt text](https://drive.google.com/file/d/1F4Ag-KtJj7E2mcrVB-VDgFS-24Vh6A3_/view?usp=drive_link "SampleAnimation")
- Choppers: Follow pre-set paths using nodes in straight lines, despawning after reaching the last node.
![alt text](https://drive.google.com/file/d/1w2kCBOmblFi8puVC0Os5TKea8CpoTEGq/view?usp=drive_link "SampleAnimation")
- Planes: Follow specified curves and turns, offering various movement patterns.
![alt text](https://drive.google.com/file/d/1qOOg9QY8Q8O2MnRF3GjUpPl4TUaj60xM/view?usp=drive_link "SampleAnimation")
- Asteroid Boss: Moves to a defined destination and remains there. It consists of large asteroids with rotating and orbiting parts.
![alt text](https://drive.google.com/file/d/1KamKfZffhWK559rKb3OGHJy-tF5u5xOt/view?usp=drive_link "SampleAnimation")

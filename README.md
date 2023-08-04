# Planes

## Introduction
Inspired by SNES game [U.N. Squadron](https://es.wikipedia.org/wiki/U.N._Squadron).It is a 2D side scroller plane shooter that features different types of enemies, including a boss fight (kind of). It was the first project I did on my own, withouth following a tutorial, turned out being a great learning experience but the code structure is non existent.  

### How it works
The player controlls a plane that can move side-ways as well as up and down, the environment is moving from left to right creating the ilusion of movement (I didnt add a moving background but enemies like turrets are supposed to be static but are steadily moving to the left, creating this illusion).  
The player shoots projectiles which, instead of being instantiated by creating objects they are preloaded and activated or deactivated when needed (polling)
If the player crashes with an enemy or its hitted by an enemy projectile it will loose a live (shown as a healthbar), and like in the U.N. Squadron game, during a brief period of time it will be vulnerable to die withing only one attack (two consecutive hits and the player is dead, even if the health bar was full).

<div class="ndfHFb-c4YZDc-aTv5jf" style="left: 12px; top: 167.5px; width: 874px; height: 486px;"><div class="ndfHFb-c4YZDc-aTv5jf-AHe6Kc"></div><div class="ndfHFb-c4YZDc-aTv5jf-bVEB4e"><div class="ndfHFb-c4YZDc-aTv5jf-NziyQe-LgbsSe ndfHFb-c4YZDc-LgbsSe" role="button" data-tooltip-unhoverable="true" data-tooltip-delay="500" data-tooltip-class="ndfHFb-c4YZDc-tk3N6e-suEOdc" data-tooltip-align="b,c" data-tooltip-offset="-6" aria-label="Reproducir planes_victory.mov" data-tooltip="Reproducir" aria-hidden="false" tabindex="0" style="user-select: none;"><div class="ndfHFb-c4YZDc-aTv5jf-NziyQe-Bz112c"></div></div><img src="https://lh3.googleusercontent.com/u/0/drive-viewer/AITFw-zRB18XuM7cJleVisl-LPbuthP_N-56fLfOeyR_fGYFHy1VvJibad9VN8qWYy9FOESraTT7rJpKCsmwHaaj0ZEbLFCGhw=w1920-h1080-k-pd" class="ndfHFb-c4YZDc-aTv5jf-bVEB4e-RJLb9c" alt="Mostrando miniatura del vídeo planes_victory.mov"></div><div class="ndfHFb-c4YZDc-aTv5jf-uquGtd" tabindex="0" title="Reproductor de vídeo" style="visibility: hidden;"><iframe id="drive-viewer-video-player-object-0" src="https://youtube.googleapis.com/embed/?status=ok&amp;hl=es&amp;allow_embed=0&amp;ps=docs&amp;partnerid=30&amp;autoplay=0&amp;abd=0&amp;public=true&amp;docid=17w908gKJeiXT_ek3UJBFH5gc5xkCnGVI&amp;el=leaf&amp;title=planes_victory.mov&amp;BASE_URL=https%3A%2F%2Fdrive.google.com%2Fu%2F0%2F&amp;iurl=https%3A%2F%2Fdrive.google.com%2Fu%2F0%2Fvt%3Fauthuser%3D0%26id%3D17w908gKJeiXT_ek3UJBFH5gc5xkCnGVI%26s%3DAMedNnoAAAAAZMzzK-WUFGyGpgrO2D29zgQjIlVuG7-C&amp;cc3_module=1&amp;reportabuseurl=https%3A%2F%2Fdrive.google.com%2Fu%2F0%2Fabuse%3Fauthuser%3D0%26id%3D17w908gKJeiXT_ek3UJBFH5gc5xkCnGVI&amp;token=1&amp;plid=V0QXeChSmjGUNw&amp;timestamp=1691145995478&amp;length_seconds=74&amp;BASE_YT_URL=https%3A%2F%2Fdrive.google.com%2Fu%2F0%2F&amp;cc_load_policy=1&amp;authuser=0&amp;wmode=window&amp;override_hl=1&amp;enablecastapi=0&amp;pipable=1&amp;enablepostapi=1&amp;postid=drive-viewer-video-player-object-0&amp;origin=https%3A%2F%2Fdrive.google.com" frameborder="0" width="100%" height="100%" allowfullscreen="true" mozallowfullscreen="true" webkitallowfullscreen="true" allow="autoplay" title="Reproductor de vídeo"></iframe></div></div>

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
![alt text](https://dribbble.s3.amazonaws.com/direct-uploads/3d827b8a-4c69-4789-891c-5ec3bc338cc0/planes_boss.gif?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAIJUPYEOE5MYHCRCQ%2F20230803%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20230803T161851Z&X-Amz-Expires=900&X-Amz-SignedHeaders=host&X-Amz-Signature=44d5d17d12a8175ad27e15c69995c1bcb72e349b12c0fc118413944d8e6b0e2e "SampleAnimation")

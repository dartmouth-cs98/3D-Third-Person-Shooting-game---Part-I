# Hack Technology / Project Attempted

## What you built? 

Player control and shooting/attack control parts of a 3D Third Person Shooting game running on Unity.

#### Implemented features include:
- main camera and aiming camera setup (with Cinemachine)
- character moving with face direction
- mouse and WSAD keyinput setup for walk, sprint, jump, punch and shoot
- firing and aiming mouse input setup
- weapon pick-up
- punch damage
- animation controls for standing, walking, sprinting shooting and reloading, as well as walk while shooting
- cross fire sign canvas
- primitive damage system (tested on a wood cabin in the environment)
- weapon shooting effect
- built-in weapon ammunition and meg count, reloading time

Here's the Youtube link on test run:
https://youtu.be/sWg6y70MfJc

## What you learned

All features mentioned above work well, as seen in the testing video.

Need to improve: 
1. The moving range of the cursor is too big, which rotates the camera too much/too wide.
2. To improve the above condition, I set the cursor state to be locked. However, console would pop up null-referrence errors when left click (which is the firing trigger), while in the game everything runs fine.
3. Animations don't fit the character the best. I chose a cartoon mouse for fun but the weapon, a AKM appears to be too long for the little mouse to hold properly. I tried to tune the weapon's position relative to its hand, but when it fits one animation (like walking), it won't fit in for holding the rifle up.
4. The transition between cinemachine cameras (Third person controlled and aiming camera) is too damped and too slow. I couldn't figure out how to tune this even after tuning the damp time and transition time down on the TPC camera.

## Author

Yuchuan Ma

## Acknowledgments

This project followed tutorials by WITS Gaming on Youtube and made minor changes by myself.
Source: https://www.youtube.com/watch?v=tSkKIqvDTEM&list=PLA-xaldQ72ryGL-DyIGasa0qa6mIMcic6

#### Assets sources:
The terrain and weapons were accessed from Unity Asset store.
- terrain is from "Flooded Ground"
Animations and main character model accessed from www.mixamo.com

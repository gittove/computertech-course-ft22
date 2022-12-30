# computertech-course-ft22

This space shooter was created with a data-oriented fashion by using Unity Entites 0.51

The bullet spawning + behavior, asteroid spawning + behavior and collision checking is done using Unity's ECS.

However, the asteroid spawner is an example of one of the objects using a hybrid solution of MonoBehavior and ECS. The asteroid spawning is done in Entities, while updating the spawner's location is done in MonoBehavior.

This is done by Converting and Injecting a game object to an entity, instead of Converting and Destroying. This allows me to create an entity, but keep the original gameobject and still run MonoBehaviour on it.

Out of curiousity, I used Entities physics system to check for collision to measure how performative it is. Results are; the game runs in ~180-220FPS.

I got started on an Octree solution for collisionchecking, but also came to the conclusion that it was too unrealistic for this assignment scope to get it working in the ECS framework, unfortunately.
It was a good ride!:)

I decided to run the camera and player behavior in MonoBehaviour, because there is little to gain from setting up code that only runs on a single instance in ECS.

## how to play!!!!

Right click and mouse - rotate around

WASD - move around

Space - shoot bullets

ESC - exit application
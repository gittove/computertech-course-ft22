# computertech-course-ft22

This space shooter was created with a data-oriented fashion by using Unity Entites 0.51

The bullet spawning + behavior, asteroid behavior and collision checking is done using Unity's ECS.

Out of curiousity, I used Entities physics system to check for collision to measure how performative it is. Results are; the game runs in ~180-220FPS.
I got started on an Octree solution for collisionchecking, but also came to the conclusion that it was too unrealistic for this assignment scope to get it working in the ECS framework, unfortunately.
It was a good ride!:)

I decided to run the camera and player behavior in MonoBehaviour, because there is little to gain from setting up code that only runs on a single instance in ECS.
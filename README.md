# Valkyrie-TechTest

## Main Challenge was to choose one of three options

I started with the Ball on a rope challenge. However, after looking at how to implement it using HingeJoints I realised I was lacking much programming examples. This spurred me onto attempt the other two challenges. Which ultimately lost me time to truly polish the overall experience, but I felt as a potential programmer and developer it would be more valuable for Valkyrie to see more programming orientated examples. 

---

# Considering Each Challenge

Due to the my knowledge of Unity Engine, I quickly knew which packages or components I needed to make use of for each challenge. Almost all of the challenges I was confronted with things I was never given the opportunity to use. This made the challenge not only difficult based on the deadline proposed meant for only one of them, but also extremely exciting. I felt I came out of this technical test having a lot of new tools to add to my belt. 

---

# Fitness Challenge
Having explored finally packages like Animation Rigging using the constraint aims and the two bone IK to handle looking towards the camera while doing animations but also pointing in the direction of the mouse click. 


## Positives 
I was quickly able to pull some animations to switch between from mixamo and get it setup relatively fast using simple custom inputs within the input manager.



## Blockers
Even though I had the mouse raycasting and relocating the Inverse Kinematics target position. I ran into a problem with preventing it from overriding the animation for the bones used with the IK constraints. I could have potentially avoided this if I used the Aim constraint and had perhaps different bounds for when to change the "Aim Axis". However, otherwise it wasn't giving an overall intended result. I was surprised that the IK overrides the animation as from my understanding it is supposed to avoid doing so. Even though I set the 'Rig2' weight to 0 when no longer pressed. (This is why the arm drops as it's no longer being accessed to target the IK target)

---

# Cube Wave Challenge

When looking at this challenge I instantly knew I would be requiring the ECS Frameworks called DOTS. This is due to the requirement to spawn 1 million cubes within the scene, usually using the monobehaviour and gameobject methods would be much to heavy of a process. However, thanks to using ECS I was able to achieve this still with a fair margin of graphical power to spare (Even though I am using a laptop). This is due to the fact that ECS process takes advantage of multi-threaded processing, Thus saving a lot of power on the GPU.  

## Positives
I had been aiming to try the DOTS package and often felt intimidated by the ever changing environment around the development. Couple that with the scarce documentation and it was something I wanted to attempt but was reluctent to spend time doing. But thanks to the need for such a powerful process I finally got my hands dirty and managed to sucessfully spawn what would have seemed unimaginable amount of cubes. I approached this by getting a rough understanding from research and then translating a monobehavioral class for moving a box on a sine wave to implementing that using the DOTS Math library. This helped me understand how things translated little by little. (Granted it did take me quite a few attempts and I most definitely have a lot more to learn when it comes to DOTS)

## Blockers
I ran into quite a few problems finding documentation on the DOTS packages and frameworks due to them often becoming depricated and outdate as they're actively being updated regulary. This meant a lot of my time was spent extensively researching for solutions to updated libraries. 


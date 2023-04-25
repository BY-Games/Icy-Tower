# Icy-Tower

This game is a demonstration of the concept of platform games. In this game, the player needs to jump on platforms to reach the highest point possible.

The game has three levels.  

## Level 1: 
Two different sizes of platforms (big and medium) make this an easy level to help the player understand the game's mechanics. To complete the level, the player needs to jump on 50 platforms.
![Alt text](Assets/Images/lvl1.jpg)

## Level 2:
The game introduces a variant of small platforms, making it a little bit more challenging. To complete the level, the player needs to jump on 50 platforms.
![Alt text](Assets/Images/lvl2.jpg)

## Level 3: 
This level includes moving platforms, forcing the player to think quickly or fall. There's no end to this level, and it finishes when the player falls.

![Alt text](Assets/Images/lvl3.jpg)

## Features  
### Camera Movement
The camera moves with the player using the [LateUpdate()]() method, checking if the player keeps jumping.

### The Player 
The player has one main script, [InputMover.cs](). This script enables the player to move and jump using the arrow keys and space bar. The player's movement is controlled by applying a force to their feet, and they can jump by applying a vertical force. The script includes a Rigidbody2D component to handle physics and uses an Animator component to control movement animations. The player's ability to jump depends on whether or not they are touching the ground. 

## World Building
The [RandomPlatform.cs]() script randomly generates platforms in the game. The script uses three arrays of GameObjects (lvl1, lvl2, and lvl3) to store the platform prefabs for each level. Each level has a different number of platforms that can be spawned (platformCount), and once a certain number of platforms have been spawned (platformCountToSwitch), the game switches to the next level.

The script starts by calling the StartCoroutine method to run the SpawnPlatforms method. This method uses a while loop to continuously spawn platforms until the desired number of platforms have been spawned.

The script selects the appropriate level array (levelToUse) based on the current game level. It then selects a platform prefab from that level array (prefabIndex) and spawns an instance of that platform at a random position (spawnPosition). The script then updates numOfPlatforms and currentPlatformCount, which keep track of the number of platforms that have been spawned overall and the number of platforms that have been spawned in the current level, respectively.

The script also checks whether the spawned platform is a level 3 platform and, if so, attaches a MovingPlatform script to it. This script is used to move the platform horizontally across the screen.

Finally, the script checks whether the current level has ended and, if so, updates the level and platform counts accordingly.

The [Wall.cs]() script generates walls on either side of the player as they move forward in the game.




# How to Play
The game ends when the player falls off the platforms and out of the camera's view.
[CameraBottomBorder.sc](    )

# Controls
Right arrow: move to the right.
Left arrow: move to the left.
Space bar: jump.
# Editor version
2021.3.18f1
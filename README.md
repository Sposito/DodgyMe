# DodgyMe
### Zombie Killer Infinite Runner

<img src="https://github.com/Sposito/DodgyMe/assets/4186852/76ae6604-adc1-4379-8250-c60fd4e1ef0b" width="640">    

Play it [Here!](http://sposito.github.io/dodgyme/)

---
## Overview
DodgyMe is a concept game developed using Unity, featuring a simple yet engaging infinite runner gameplay. The primary objective is to hit the zombies while dodging the hens and blockades. You can control the player character using the arrow keys or the A and D keys.


## Game Description
In DodgyMe, the player navigates through a procedurally generated environment filled with obstacles and enemies. The game was developed with the unique constraint of using only Unity's Cube Primitive, demonstrating creativity and resourcefulness in game design. The minimalist cubic art style, enhanced by Blender modeling, gives the game a unique aesthetic.

## Controls
- Move left: A or Left Arrow Key
- Move right: D or Right Arrow Key

---
## Project Structure
The project is organized into several directories and files, each serving a specific purpose in the game's development:

### Core Scripts
The core functionality of DodgyMe is implemented through several C# scripts, each managing different aspects of the game. Below is an overview of the key scripts and how they connect to form the game's structure.

#### PlayerController.cs
The `PlayerController` script manages player input and controls the movement of the player character. It handles the player's lateral movement (left and right) using the keyboard inputs. This script ensures the player can dodge obstacles and position themselves to hit zombies.

#### LevelController.cs
The `LevelController` script is responsible for the procedural generation of the game level. It continuously spawns road segments and obstacles ahead of the player as they progress through the game. The script also manages the game's difficulty by gradually increasing the speed and frequency of obstacles.

- **Key Responsibilities:**
  - Spawning road segments and obstacles.
  - Managing the player's speed and increasing difficulty.
  - Handling game state, including scoring and game over conditions.

#### SteerController.cs
Although simpler in functionality, the `SteerController` script tracks the player's position and movement direction. This information can be used to adjust the player's orientation and provide visual feedback.

#### InputHandler.cs
The `InputHandler` script processes player inputs and translates them into in-game actions. It uses swipe detection (via `TKLSwipeDetector`) to handle inputs, which can then be used by the `LevelController` to move the player or trigger other game events.

#### ZombieController.cs
The `ZombieController` script manages the behavior of zombie enemies. It extends the `MobController` class and includes specific functionality for zombies, such as playing hit sounds and increasing the player's score when a zombie is hit.

#### UpdateScore.cs
The `UpdateScore` script handles the game's scoring system. It updates the score displayed on the UI based on the player's actions in the game. It can differentiate between the current score and the maximum score achieved.

### Spawner Scripts
The game includes spawner scripts that manage the creation of various game objects:

- **ObstacleSpawner.cs (assumed as part of LevelController.cs):** Manages the spawning of obstacles such as hens and blockades.
- **LevelController.cs:** Also handles the spawning of road segments and manages the procedural generation of the game environment.

### ProjectSettings
This directory holds various configuration files that define project-wide settings, such as input management, audio settings, graphics settings, and quality settings.

### Packages
Contains the manifest file for managing project dependencies and Unity packages.

---
## Key Features
- **Minimalist Cubic Aesthetic:** The game features a unique art style using Unity's Cube Primitive for all models, enhanced with Blender modeling for a consistent cubic look.
- **Procedural Generation:** The game environment is procedurally generated, providing a unique experience each time you play.
- **Engaging Gameplay:** Simple controls combined with challenging mechanics make for an engaging infinite runner experience.

## How to Run the Game
1. Clone the repository to your local machine.
2. Open the project in Unity.
3. Load the main scene from the `Assets/Scenes` directory.
4. Press the Play button in Unity to start the game.

## Future Improvements
- Adding more variety to obstacles and enemies.
- Implementing power-ups and special abilities for the player.
- Enhancing the visual effects and animations.

DodgyMe showcases a unique approach to game development with its minimalist design and engaging gameplay. Enjoy running over zombies while dodging obstacles in this infinite runner!

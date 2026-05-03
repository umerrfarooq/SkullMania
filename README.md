# SkullMania

SkullMania is a 2D Unity platformer built around responsive movement, state-driven player logic, and a clear win-condition loop. The player moves through a designed level, collects keys, avoids hazards, and reaches the chest once the score requirement is met.

## Overview

The gameplay loop is intentionally compact: explore the level, collect Gold Keys to raise your score, survive spikes and recover with potions, and open the Chest to win. The project separates movement, animation, health, scoring, and game-state handling so the experience stays maintainable and easy to extend.

## Key Features

- State-driven player behavior with a PlayerStateMachine and PlayerStateFactory
- Health system with damage cooldowns and healing pickups
- Score-based progression tied to the win condition
- Game manager controls for start, pause, restart, and quit flows
- Win and game over UI states for clear end-of-run feedback
- Level boundary clamping to keep the player inside the playable space
- Animator-driven character feedback through PlayerAnimator

## Gameplay Rules

| Objective         | Behavior                                   |
| ----------------- | ------------------------------------------ |
| Collect Gold Keys | Each key grants 25 score                   |
| Open the Chest    | Requires at least 75 score to win          |
| Survive Hazards   | Spikes deal damage; potions restore health |

## Controls

| Input                 | Action            |
| --------------------- | ----------------- |
| A / D or Left / Right | Move horizontally |
| Space                 | Jump              |
| Space in mid-air      | Double jump       |
| Escape                | Pause or resume   |

## Project Structure

```text
Assets/
├── Scripts/
│   ├── PlayerStateMachine.cs
│   ├── PlayerBaseState.cs
│   ├── PlayerStateFactory.cs
│   ├── IdleState.cs
│   ├── WalkingState.cs
│   ├── JumpingState.cs
│   ├── DoubleJumpState.cs
│   └── FallingState.cs
├── PlayerMovement.cs
├── playerhealth.cs
├── GameManager.cs
├── PlayerAnimator.controller
├── Sprites/
├── Decor/
├── Plattle/
├── Scenes/
│   └── SampleScene.unity
└── TextMesh Pro/
```

## Required Tags

| Tag     | Purpose                                        |
| ------- | ---------------------------------------------- |
| Ground  | Ground detection                               |
| Spike   | Applies damage to the player                   |
| KeyGold | Collectible that increases score               |
| Chest   | Win trigger after reaching the score threshold |
| Potion  | Restores health                                |

## Getting Started

### Prerequisites

- Unity 2021.3 LTS or later
- TextMeshPro package installed through Package Manager if it is not already included

### Run the Project

1. Open the repository in Unity Hub
2. Load Assets/Scenes/SampleScene.unity
3. Enter Play Mode in the Unity Editor

## Building

1. Open File > Build Settings
2. Add SampleScene to the build list
3. Choose a target platform such as PC, Android, or WebGL
4. Click Build

## License

This project is intended for educational and personal use. Feel free to fork it and adapt it for your own experiments.

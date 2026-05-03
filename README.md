# 💀 SkullMania

A 2D platformer game built with **Unity**, featuring player movement, a health system, collectibles, hazards, and full game state management (Start, Pause, Game Over, Win).

---

## 🎮 Gameplay Overview

You play as a skull-themed character navigating a 2D level. Your goal is to **collect Gold Keys** to build up your score and then **open the Chest** to win — all while avoiding spikes and staying alive.

| Objective | Detail |
|---|---|
| 🗝️ Collect Gold Keys | Each key gives **+25 score** |
| 📦 Open the Chest | Requires **≥ 75 score** — triggers a Win! |
| ❤️ Survive | Avoid spikes; pick up Potions to heal |

---

## 🕹️ Controls

| Input | Action |
|---|---|
| `A` / `D` or `←` / `→` | Move left / right |
| `Space` | Jump |
| `Space` (mid-air) | Double Jump |
| `Escape` | Pause / Resume |

---

## ⚙️ Features

- **State Machine Architecture** — Player states (Idle, Walking, Jumping, Double Jump, Falling) are managed via a clean `PlayerStateMachine` with a `PlayerStateFactory`
- **Health System** — 100 HP max; spikes deal 25 damage (with a 1s cooldown); potions heal +10 HP
- **Score System** — TextMeshPro live score display; score gates the win condition
- **Game Manager** — Handles Start Panel, Pause Panel, Restart, and Quit
- **Game Over / Win Panels** — Triggered on death or chest collection
- **Boundary Clamping** — Player is kept within the defined level bounds at all times
- **Animated Player** — Uses a Unity Animator Controller (`PlayerAnimator`) tied to state transitions

---

## 📁 Project Structure

```
Assets/
├── Scripts/                  # State machine scripts
│   ├── PlayerStateMachine.cs
│   ├── PlayerBaseState.cs
│   ├── PlayerStateFactory.cs
│   ├── IdleState.cs
│   ├── WalkingState.cs
│   ├── JumpingState.cs
│   ├── DoubleJumpState.cs
│   └── FallingState.cs
├── PlayerMovement.cs         # Core movement, scoring & win/lose logic
├── playerhealth.cs           # Health, damage cooldown, healing
├── GameManager.cs            # Start, pause, restart & quit
├── PlayerAnimator.controller # Animator for player states
├── Sprites/                  # 2D art assets
├── Decor/                    # Environment decorations
├── Plattle/                  # Platform assets
├── Scenes/
│   └── SampleScene.unity     # Main game scene
└── TextMesh Pro/             # TMP assets
```

---

## 🏷️ Required Tags

Make sure the following tags are defined in your Unity project:

| Tag | Used For |
|---|---|
| `Ground` | Grounded detection |
| `Spike` | Deal 25 damage to player |
| `KeyGold` | Collectible — grants +25 score |
| `Chest` | Win trigger (needs ≥ 75 score) |
| `Potion` | Heal the player by +10 HP |

---

## 🚀 Getting Started

### Prerequisites
- **Unity 2021.3 LTS** or later (2D project template)
- **TextMeshPro** package (install via Package Manager if not already included)

### Running the Game
1. Clone the repository
2. Open the project in Unity Hub
3. Open `Assets/Scenes/SampleScene.unity`
4. Press **Play** in the Unity Editor

---

## 🏗️ Building

1. Go to **File → Build Settings**
2. Add `SampleScene` to the build
3. Select your target platform (PC, Android, WebGL, etc.)
4. Click **Build**

---

## 📜 License

This project is for educational/personal use. Feel free to fork and build upon it.

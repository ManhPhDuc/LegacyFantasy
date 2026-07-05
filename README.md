What I Learned
Through this project, I practiced:

Building a complete Unity 2D gameplay loop
Organizing C# scripts by responsibility
Working with Unity physics and collision detection
Using Animator for player and enemy animation
Creating simple UI systems for HP, score, win, and game over states
Managing audio through an AudioManager
Building and publishing a Unity WebGL game
Preparing a game project for GitHub and portfolio presentation

# LegacyFantasy

**LegacyFantasy** is a 2D platformer prototype developed with **Unity** and **C#**.  
This project was created as a personal learning project to practice core Unity gameplay programming, 2D physics, animation, UI, audio, and WebGL deployment.

The game is playable in the browser through a Unity WebGL build.

---

## Play Demo

Play the WebGL demo here:

**Itch.io:** `PASTE_YOUR_ITCH_IO_LINK_HERE`

---

## Project Overview

LegacyFantasy is a simple 2D side-scrolling platformer where the player can move, jump, attack enemies, collect coins, take damage, and reach a win condition.

The main purpose of this project is to demonstrate practical Unity development skills for an intern-level Unity Developer position.

---

## Features

- 2D player movement
- Jumping system
- Rigidbody2D-based gameplay
- Enemy patrol behavior
- Player attack system
- Enemy damage and death handling
- Player HP system
- HP UI display
- Coin collection
- Score system
- Win condition
- Game over UI
- Background music and sound effects
- Camera follow
- Unity WebGL build for browser play

---

## Tech Stack

- **Engine:** Unity
- **Language:** C#
- **Platform:** WebGL
- **Unity Systems Used:**
  - Rigidbody2D
  - Collider2D
  - Animator
  - Tilemap
  - Canvas UI
  - AudioSource
  - Prefabs
  - Scene Management

---

## Main Scripts

Some of the main scripts in this project include:

```text
AudioManager.cs
CameraFollow.cs
Coin.cs
DamageDealer.cs
EnemyDeathHandler.cs
EnemyHitFeedback.cs
EnemyPatrol.cs
GameOverUI.cs
Health.cs
PlayerAttack.cs
PlayerController.cs
PlayerDeathHandler.cs
PlayerHealthUI.cs
ScoreManager.cs
WinTrigger.cs
WinUI.cs

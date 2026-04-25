# Quantum Roll

A 3D Unity mini-game where you roll a player sphere, collect pickups, avoid a chasing enemy, and use portal teleporters to outmaneuver danger.

## Game Summary

- Objective: collect 12 pickups to win.
- Lose condition: collide with the enemy.
- Win/Lose feedback: on-screen message, audio cues, and a retry button.
- Extra mechanics: rotating pickups, enemy pathfinding with NavMesh, and linked portal teleporters.

## Tech Stack

- Engine: Unity 2022.3.62f3 (LTS)
- Language: C#
- Render Pipeline: Universal Render Pipeline (URP)
- Input: Unity Input System package
- AI Navigation: Unity NavMesh Agent

## Controls

The Player action map supports multiple devices. In normal desktop play:

- Move: WASD or Arrow Keys
- Alternative devices: gamepad left stick / joystick stick

Notes:

- A Look and Fire action exists in the input actions asset, but movement is the primary gameplay input used by the current scripts.

## Scenes

- Main playable scene (enabled in Build Settings): Assets/Scenes/mimigame.unity
- Sample scene (disabled): Assets/Scenes/SampleScene.unity

## Core Gameplay Flow

1. Player moves using physics force on a Rigidbody.
2. Pickups rotate and can be collected by trigger collision.
3. Each pickup increments score and plays SFX/VFX.
4. Enemy continuously pathfinds toward the player.
5. If score reaches 12, the player wins and enemy is removed.
6. If enemy collides with player, player loses.
7. Retry button reloads the current scene.

## Scripts

- Assets/Scripts/PlayerController.cs
	- Handles movement input, scoring, win/loss state, pickup collection, audio/VFX, and retry button binding.
- Assets/Scripts/EnemyMovement.cs
	- Drives enemy chasing behavior through NavMeshAgent destination updates.
- Assets/Scripts/PortalTeleporter.cs
	- Teleports player Rigidbody between linked portals with a cooldown to prevent instant re-teleport loops.
- Assets/Scripts/CameraController.cs
	- Maintains a fixed camera offset that follows the player in LateUpdate.
- Assets/Scripts/Rotator.cs
	- Rotates pickup objects continuously.

## Project Setup

### Requirements

- Unity Hub
- Unity Editor 2022.3.62f3 installed

### Open and Run

1. Open Unity Hub.
2. Add this project folder.
3. Open with Unity 2022.3.62f3.
4. Open scene: Assets/Scenes/mimigame.unity.
5. Press Play in the Editor.

## Build

1. In Unity, go to File > Build Settings.
2. Confirm Assets/Scenes/mimigame.unity is enabled.
3. Choose target platform.
4. Click Build or Build And Run.

## Repository Layout

- Assets/
	- Scenes/: Unity scenes
	- Scripts/: gameplay logic
	- Input/: InputActions.inputactions
	- Prefabs/, Material/, Animations/, Settings/: game content and configuration
- Packages/
	- Unity package manifest and lock file
- ProjectSettings/
	- engine/project configuration

## Future Improvements

- Add UI for pause and in-game restart hotkey.
- Add multiple levels and progressive enemy difficulty.
- Add score persistence and timer-based ranking.
- Expand portal mechanic with directional momentum transfer.

## Troubleshooting

- If movement does not respond:
	- Verify Player Input is connected to Assets/Input/InputActions.inputactions.
	- Confirm the Player object has Rigidbody and PlayerController components.
- If enemy does not chase:
	- Ensure enemy has a NavMeshAgent and the scene has baked NavMesh data.
- If retry button does not appear:
	- Check that a UI object named Retry Button exists in the active scene and is wired correctly.

## License

No license file is currently included. Add a LICENSE file if you plan to distribute or open-source this project.

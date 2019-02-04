# NeuroZomBunny
## Documentation
Unity project: neurozombunny  
Main Scene: Assets/Scenes/room1.unity  
Unity version: 2018.3.1f1 Personal  
Google Unity VR SDK version: 1.190.1  

#### Server
A websocket that transmits data from the NeuroSleeve predictions to the game. Messages are strings containing one of the selected spells. The game can receive 3 spells: “Pink”, “Blue” and “Yellow” that represents the color of the enemy that you can damage with this spell.

#### SampleServer
A sample server is provided in Assets/SampleServer that sends spells every 2 seconds in a consequent manner. It is used to emulate real server when its not available. To start the server, run:

```
node server.js
```

The port it’s running is 4242.
As the game is running on other device than a server, we need to expose this sample server to the internet if you’re running it locally. Use https://ngrok.com/download for that:

```
./ngrok http 4242
```

It will output an address similar to this: http://9ec3b90c.ngrok.io . Remember your id (NGROK_ID=9ec3b90c for this example) as we will use it later in the installation section.

#### Installation

Project url: https://github.com/thatsmesasha/neurozombunny.git

Run in the terminal:

```
git clone https://github.com/thatsmesasha/neurozombunny.git
```

Now you can open created folder “neurozombunny” as Unity Project. Open scene room1.

#### Scene Hierarchy
- _Environment_ - the room’s setup
- _Lights_ - main lights
- _WeaponManager_ - changes the current spell based on websocket messages. In its script component set UrlToRefresh to the websocket url. If you are using sample server, paste “ws://<NGROK_ID>.ngrok.io” with <NGROK_ID> substituted for your id.
- _ScoreManager_ - regulates and displays score in the game
- _EnemyManager_ - spawns enemies in the specified location
  - _SpawnPoints_ - contains labeled spawn points for enemies
  - _Enemies_ - contains all possible enemies
- _GvrControllerMain_ - controller emulator if you don’t run on the VR device
- _GvrEditorEmulator_ - camera emulator for VR
- _GvrEventSystem_ - used for controller input
- _GvrInstantPreview_ - allows to play the game from Unity directly on the device
- _ShootRay_ - used as part of LightBeam weapon
- _FireSpiritInstance_ - used as part of FireSpirit weapon
- _HUDCanvas_ - UI for health and score
  - _HealthBar_ - displays hearts (hp)
  - _Score_ - displays score as text
- _Player_ - main component that describes player behavior
  - _MainCamera_ - player sees from this component
    - _Canvas_ - UI wrapper
      - _DamageImage_ - used for displaying that the player got damaged by blinking
  - _GvrControllerPointer_
    - _Weapon_ - user’s weapon
      - _Sphere_ - part of the weapon, displays what spell is currently used by color, must be tagged as ShootingStart
      - _AvailableWeapons_ - spells that user can select from
    - _Laser_ - GVR component that determines where controller is looking
      - _Reticle_ - point where controller is pointing, must be tagged as ShootingEnd

#### Assets/Scripts
- Player
  - PlayerShooting
    - Attach to the gameobject Weapon
    - CurrentEnemyType: which spell is currently in use, copies it from WeaponManager
    - Sphere: drag and drop the gameobject Sphere
    - Weapons: drag and drop children of the gameobject AvailableWeapons
    - ChangeSphereSpeed: speed of color change of the Sphere
    - WeaponManager: drag and drop the gameobject WeaponManager
  - PlayerHealth
    - Attach to the gameobject Player
    - StartingHealth: max health (1 hp for half heart)
    - CurrentHealth: current health of the player, it will change during the game
    - HeartContainers: drag and drop consequently children of the gameobject HealthBar
    - HeartSprites: drag and drop the sprites Assets/Sprites/HalfHeart and Assets/Sprites/FullHeart
    - DamageImage: drag and drop the gameobject DamageImage
    - FlashSpeed: speed of the red flash when the player is hit
    - FlashColor: color of the flash when the player is hit
  - Weapons - specific usage scripts of different spells
  - Weapons/IWeapon - interface that all weapon scripts need to implement
- Enemy
  - Attach all to the enemy gameobject, examples in the children of the gameobject Enemies
  - EnemyMovement - Follows player while the player and the enemy is alive
  - EnemyAttack
    - TimeBetweenAttacks: the player will be able to make only one attack in this period of time
    - AttackDamage: the damage that the player can do with this attack
  - EnemyHealth
    - StartingHealth: max health
    - CurrentHealth: current health of the enemy, it will change during the game
    - SinkSpeed: speed of the enemy sinking through the floor after he dies
    - ScoreValue: score that will be added to the total score if the player kills this enemy
    - DeathClip: audio played when the enemy is killed
    - Type: color of the enemy
- Managers
  - WeaponManager
    - Attach to the gameobject WeaponManager
    - UrlToRefresh: websocket url that sends spell name to which it wants to switch
    - CurrentEnemyType: current spell, will change during the game
  - ScoreManager
    - Attach to the gameobject ScoreManager
    - Text: drag and drop the gameobject Score
  - EnemyManager
    - Attach to EnemyManager for each enemy type that will be spawned
    - PlayerHealth: drag and drop the gameobject Player
    - Enemy: drag and drop the enemy gameobject
    - SpawnTime: duration between spawns
    - SpawnDelay: delay in the start of the game to spawn first enemy
    - SpawnPoints: drag and drop the spawnpoint gameobjects, currently using just one spawnpoint per enemy type stored as children of the gameobject SpawnPoints, but if used more, it will choose randomly between the spawnpoints

Spells scripts specific for different spells: Assets/Scripts/Player/Weapons

## GVR useful information

#### Setup

Configure project: https://developers.google.com/vr/develop/unity/get-started-android

Hierarchy in the scene and editor viewer: https://developers.google.com/vr/develop/unity/controller-support
https://developers.google.com/vr/reference/unity/prefab/GvrEditorEmulator

Download and install Daydream Elements unity package:
https://developers.google.com/vr/elements/overview

Add arm model to simulate arm movement:
https://developers.google.com/vr/elements/arm-model

#### Tips
Screen Overlay UI in VR doesn’t work - you need to use World Space UI.

3D object needs to have component MeshCollider in order to be seen by GvrControllerPointer and be able to interact with Raycasts of the controller. 2D (UI) objects need to have  GvrPointerGraphicRaycaster component. For enabling raycasting, check this: https://developers.google.com/vr/reference/unity/class/GvrPointerInputModule#classGvrPointerInputModule

#### Errors and solutions

Can play in Editor, but not on the Daydream:
Check all settings listed in Get Started guide (especially XR Settings). Check if in the Console there is message “Connected to Instant Preview”. If not, there maybe a problem with adb. This program is located at <location of android sdk>/platform-tools/adb. Check that this path is in $PATH. Ensure that `adb reverse --list` outputs connected port. Relaunch Unity after this steps.

Metafile missing from Microsoft Visual C#:
Exit Unity, delete Library folder inside the project, open project again. It can reset some settings, so go through configuring project again (check Setup section).

Cannot hit objects with raycasting:
Check if GvrPointerPhysicsRaycaster component of Main Camera has RaycasterEventMask set to specific level that shootable objects will have or Everything to be able to shoot all objects. Check if the enemies are with selected level. Check the distance that the controller can reach to in Laser &rarr; GvrLaserVisual &rarr; MaxLaserDistance. Check tips for additional info about raycasting.

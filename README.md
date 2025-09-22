## Tower Defense Game
This is a 2.5D tower defense game where you defend your castle from swarming slimes. Good Luck!

## Starting the Project
I start every project by doing the general mechanics and ideas. Thus, it gets easy to move on.
The main idea was to create a scene where enemies spawn in a corner of the map and move to the other corner to damage our castle. In order to implement this idea, I created a waypoint system where enemies can follow a certain path. With this system, another level could be created with ease.

## Moving the Character
I used the translate method to move my player and enemies. This allows me to manage enemies' movement with precision.

## Functionality of Player
The player has a range and an attack speed, which determine how they kill enemies. I implemented this using the EnemyCheckInRange and RangeAttack functions. EnemyCheckInRange uses Unity’s Physics.OverlapSphere function to scan for enemies within a sphere around the player.

## Projectiles
The Projectile script controls a projectile that targets the closest enemy, moves toward it at a defined speed, and applies damage on collision. When the projectile hits an object tagged as “Enemy,” it calls the enemy’s enemyTookDamage() method, instantiates a visual effect at the impact point, and destroys both the effect after 2 seconds and the projectile itself. If the target is destroyed or becomes null before impact, the projectile automatically destroys itself to prevent errors.

## Player and Enemy Datas
The PlayerData ScriptableObject stores all the configurable stats for a player, including the player’s name, sprite, selected weapon, maximum health, movement speed, base damage, attack speed, and attack range, allowing these values to be easily modified in the inspector without changing code. Similarly, an EnemyData ScriptableObject can hold enemy-specific stats such as name, sprite, health, damage, movement speed, and attack range, enabling flexible setup of different enemy types and making it simple to adjust gameplay balance or add new characters by editing the asset values directly.

## Spawn Manager
ScriptableObjects were really useful for creating a modular spawn manager in my project. For example, I created a Wave ScriptableObject that defines how many enemies should spawn in a given wave. By simply changing its values, anyone can easily design new waves and plug them into the spawn manager with minimal effort.

## Upgrade System

The player’s stats (attack, attack speed, movement speed, health) can be upgraded dynamically, with the upgrade cost increasing after each purchase.

## Audio and UI Managers
These Managers have not been used for much since the project is early in stage, in the future, both will be used as intended.

##Optimization
For optimization, sprite batching is used to reduce draw calls and improve performance.
In some areas of the game, a ticking system is used instead of the default Update() method to create less frequent updates. This approach is applied, for example, to UI updates and enemy behaviors.

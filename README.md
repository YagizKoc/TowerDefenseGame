##Tower Defense Game
This is a 2.5D tower defense game where you defend your castle from swarming slimes. Good Luck!

##Starting the Project
I start every project with doing the general meachanics and ideas. Thus it get easy to move on.
So main idea was creating a scene where enemies spawn in a corner of a map and get to other corner to damage our castle. In order to implement this idea i created a waypoint system where enemies can follow a certain path. With this system onether level could get created with ease.

##Moving the Character
I used translate method to move my player and enemies. This allows me to manage enemies movement with precision.

##Functionalty of Player
The player has a range and an attack speed, which determine how they kill enemies. I implemented this using the EnemyCheckInRange and RangeAttack functions. EnemyCheckInRange uses Unity’s Physics.OverlapSphere function to scan for enemies within a sphere around the player.

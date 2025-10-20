# Lab9

How the Object Pooler is implemented

The object pooler takes 1 bullet and it uses that one bullet for 30 bullets



How Builder Pattern

The interface is called Enemy IEnemyBuilder. It takes a base enemy class with different enemy stats. The main ones are Speed, and health and enemy prefab model. It is used with oneShot and threeShot. They both use this interface to give it a set contract they all have. and then the builder lets me configure and construct the enemies with these things.

These will be then created with the OneShot/ThreeShot and then gets called by another class called EnemyBuilder then it creates the Enemy.





How Observer Pattern for Score System



The enemy class doesn't know the score system is there it is just a tool for the score tracker script to observe any changes. Whenever an enemy notifies a hit, all observers automatically react. This will then raise the score in debug.






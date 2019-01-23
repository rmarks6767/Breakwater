# Breakwater
## Overview
Breakwater is an open-world top-down 2D game with the goal of the player becoming a prominent figure in the world either through trade, plunder, or loyalty to the crown. Essentially, this is a game that focuses on colonial survival with a heavy focus on naval combat and exploration. 
### References/Inspiration
Rimworld, FTL, Sea of Theives, Stardew Valley

## Core Mechanics
### Gameplay Routes
To maximize the amount of freedom that player’s have, the game will be tailored for three different play styles or gameplay routes that have different types of tasks to complete.
#### Pirate Route
Build or buy a boat and form/hire a crew and sail the sea in search of treasure and loot and amass an armada and eventually form a nation.
#### Imperial Route
Start the game as an expendable naval soldier for one of the already established factions and accomplish quests to eventually make your way up to higher ranks.
#### Trade Route
Buy and sell goods from an owned shop in order to profit from neighboring settlements.  You can buy and sell shops and order ships to make deliveries to other places.
Although there are three routes of gameplay it does not mean you can’t mix them. Become a corrupt admiral or a black market dealer, there are many possibilities.

## NPC's
Take on the base of society, performing tasks and various things, which might include having a set routine that they complete based on time of year, day, week, etc.

## Combat
Combat is split between naval and land combat. Naval combat will mainly uses mounted weapons while land combat employs all types of weapons.

## Economy
The premise of having an in-game economy is to purchase or plunder resources in one region of the world, and then sell them for the highest price possible through dynamic pricing. There are also luxury items that are more rare, and require more skill to obtain. Additonally, based on your actions in the world, governing bodies can and will impose tarriffs on certain items.

## Building
Buidling allows the player to set up a settlement or base at a location of their choosing, and each of the three routes allows for their own unique attributes.
### Plunder (Pirate) Route
Building your very own pirate cove can give the player many advantages towards their plundering endeavours, such as a safe place for the player and their crew to rest as well as a place to store and make gold.
### Trade (Mogul) Route
Building is the one of the main focuses of the trade branch, building trade ports, farms, mines, fisheries, and more to make money. This is probably going to be the players main source of income and seeing as money is what gives them power most of the game will be spent doing this.
### Imperial (Soldier) Path
Building for the imperial path is how the player conquer new islands or take over islands that are already occupied. Factions will often give out settlement contracts that will have the player escort a group of settlers to an island untouched by man. When arriving the player is tasked with building up a small village that can sustain itself. Or after taking control of an island you are tasked with repairing the village so that new settlers can occupy the old village.
The building mechanic is heavily inspired by games like Stardew Valley in which you can do place individual fences, furniture, and paths, but the buildings are pre-built structures with fully customizable interiors.

## What Everything Does
### Chunk.cs
Creates a chunk system for the world using the chunk's world x1, x2, y1, and y2 coordinates. This chunk system renders the chunk that the player is in, defined by the dimensions of the screen, and the 8 adjacent chunks.
### ChunkLoader.cs
Loads the chunks.
### Circle.cs
Creates a circle.
### CollisionSystem.cs
List all of the entities that exist in the player space.
### CoordinateMath.cs
Originally used rectanges to check if a given set of points contained a point within it. Used for collision detection. ~~Now uses ellipses :tm:~~ Now uses lots and lots of cirlces.
### Drawer.cs
Draws the map and the entities
### Entities.cs
Renders all of the entities in the game (player, enemies, buildings, ships, etc.)
### FindPath.cs
Path-finding algorithm that the NPC's will utilize to move about the world.
### Game1.cs
Main game loop
### Grid.cs
Breaks up the playable world into a grid.
### ICollidable.cs
Collision detectiom.
### Player.cs
Everything about the player.
### Pointer.cs
Points to things.
### Program.cs
Main entry point for the application. Initializes the terrain generator.
### QuadTree.cs
Creates a quad tree, which is used for compartmentalizing entity locations, and collisions.
### Screen.cs
Renders the stuff on screen I assume.
### TerrainGenerator.cs
Generates the terrain.

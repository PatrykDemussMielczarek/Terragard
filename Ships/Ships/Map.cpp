#include "stdafx.h"
#include "Map.h"


Map::Map()
{
}


Map::~Map()
{
}

void Map::RenderMap() {
	for (int x = 0; x < SizeX; x++)
	{
		for (int y = 0; y < SizeY; y++)
		{
			if( HitCoords[x][y] == 66 ) SeeMap[y][x] = 176;
			else SeeMap[y][x] = HitCoords[x][y];
		} 
	}
}

void Map::PrintMap() {
	for (int x = 0; x < SizeX; x++)
	{
		for (int y = 0; y < SizeY; y++)
		{
			cout << SeeMap[y][x];
		}
		cout << endl;
	}
}

void Map::GenerateHitCoords() {
	for (int x = 0; x < SizeX; x++)
	{
		for (int y = 0; y < SizeY; y++)
		{
			HitCoords[y][x] = 66;
		} 
	}
}


bool Map::GameEnded(Ship *ships) { 
	int destroyed = 0;
	for (int i = 0; i < 3; i++) { 
		if (ships[i].GetDestroyed()) {
			destroyed++;
		}
		else return false;
	} 
	if (destroyed >= 3) return true;
	else return false;
}

void Map::SetShips(bool Player, int x1, int y1, int x2, int y2, int x3, int y3) {
	if (Player) {
		PlayerShips[0] = Ship(x1, y1);
		PlayerShips[1] = Ship(x2, y2);
		PlayerShips[2] = Ship(x3, y3);
	}
	else {
		EnemyShips[0] = Ship(x1, y1);
		EnemyShips[1] = Ship(x2, y2);
		EnemyShips[2] = Ship(x3, y3);
	}
}

void Map::SetHitCoords(int x, int y, char character) {
	if((x >= 0 && x <= SizeX) && (y >= 0 && y <= SizeY)) HitCoords[x][y] = character;
}

Ship* Map::GetEnemyShips() {
	return EnemyShips;
}

Ship* Map::GetPlayerShips() { 
	return PlayerShips;
}
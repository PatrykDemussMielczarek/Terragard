#pragma once
#include "Ship.h"

class Map
{
private: 
	int SizeX = 9;
	int SizeY = 9;
	char SeeMap[9][9];
	char HitCoords[9][9]; 
	Ship PlayerShips[3];
	Ship EnemyShips[3];


public:
	bool GameEnded(Ship *ships);

	void SetShips(bool Player, int x1, int y1, int x2, int y2, int x3, int y3);
	void RenderMap();
	void PrintMap();
	void GenerateHitCoords();

	Ship* GetEnemyShips();
	Ship* GetPlayerShips();

	void SetHitCoords(int x, int y, char character);
	Map();
	~Map();
};


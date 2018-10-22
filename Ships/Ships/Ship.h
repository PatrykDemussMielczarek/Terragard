#pragma once
 
class Ship 
{
private: 
	int Length;
	int StartingCoordX;
	int StartingCoordY;
	int Direction;
	int Destroyed;

public:

	bool GetDestroyed();
	int GetCoordX();
	int GetCoordY();

	bool GetHit(int x, int y);

	void DestroyShip();

	Ship(int StartingCoordX_ = 0, int StartingCoordY_ = 0, int Length_ = 1, int Direction_ = 0, bool Destroyed_ = false);
	~Ship();
};


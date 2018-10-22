#include "stdafx.h"
#include "Ship.h"


Ship::Ship(int StartingCoordX_, int StartingCoordY_, int Length_, int Direction_, bool Destroyed_)
{
	StartingCoordX = StartingCoordX_;
	StartingCoordY = StartingCoordY_;
	Length = Length_;
	Direction = Direction_; 
	Destroyed = Destroyed_;
}
 
Ship::~Ship()
{
}

bool Ship::GetDestroyed() {
	return Destroyed;
}

int Ship::GetCoordX() {
	return StartingCoordX;
}

int Ship::GetCoordY() {
	return StartingCoordY;
}

bool Ship::GetHit(int x, int y) {
	bool output = false;
	if (GetCoordX() == x && GetCoordY() == y) {
		output = true;
	}
	return output;
}

void Ship::DestroyShip() {
	Destroyed = true;
}
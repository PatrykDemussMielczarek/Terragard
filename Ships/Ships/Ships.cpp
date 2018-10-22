// Ships.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "Map.h"
#include "Ship.h"
#include <string>

int main()
{
	Map map1; 
	map1.SetShips(false, 0, 0, 1, 1, 2, 2);
	map1.SetShips(true, 5, 5, 6, 6, 7, 7);
	map1.GenerateHitCoords();

	bool PlayerTurn = true;

	string Input;
	char InputX = 0;
	char InputY = 0;  

	while (!map1.GameEnded(map1.GetEnemyShips()) && !map1.GameEnded(map1.GetPlayerShips()))
	{
		system("cls");
		map1.RenderMap();
		map1.PrintMap(); 
		  
		if (PlayerTurn) {  
			cin >> Input;  

			InputX = Input[0];
			InputY = Input[1];
 
			if (InputX >= 97 && InputX <= 122) {
				InputX -= 97;
			}
			else if (InputX >= 65 && InputX <= 90) {
				InputX -= 65;
			} 
			/*if (InputX >= 49 && InputX <= 58) {
				InputX -= 49;
			}

			if (InputY >= 97 && InputY <= 122) {
				InputY -= 97;
			}
			else if (InputY >= 65 && InputY <= 90) {
				InputY -= 65;
			} */
			if (InputY >= 49 && InputY <= 58) {
				InputY -= 49;
			}  


			bool anyHit = false;
			for (int i = 0; i < 3; i++) {
				if (!map1.GetEnemyShips()[i].GetDestroyed() && map1.GetEnemyShips()[i].GetHit(InputX, InputY)) {
					i = 3;
					map1.GetEnemyShips()[i].DestroyShip();
					anyHit = true;
				}
			}
			if (anyHit) map1.SetHitCoords(InputX, InputY, 'O');
			else map1.SetHitCoords(InputX, InputY, 'X');


			PlayerTurn = false;
		}
		else{   
			InputX = 0;
			InputY = 0;

			PlayerTurn = true;
		} 
	}
	if (map1.GameEnded(map1.GetEnemyShips())) cout << "WIN";
	else if (map1.GameEnded(map1.GetPlayerShips())) cout << "LOSE";

	system("pause");
    return 0;
}
 
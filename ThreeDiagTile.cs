using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Three Diagonal Tile", menuName = "Three Diagonal Tile", order = 363)]
public class ThreeDiagTile : ScriptableObject
{

    //0 = leftup + rightup + rightdown, 
    //1 = rightup + rightdown + leftdown, 
    //2 = rightdown + leftdown + leftup, 
    //3 = leftdown + leftup + rightup

    [SerializeField]
    private Sprite[] threeDiagonalTiles = default;

    public Tile SelectTile(int posX, int posY)
    {
        Tile temp = ScriptableObject.CreateInstance<Tile>();

        if (GameStats.map[posX - 1, posY + 1] == 1 &&
            GameStats.map[posX + 1, posY + 1] == 1 &&
            GameStats.map[posX + 1, posY - 1] == 1)
            temp.sprite = threeDiagonalTiles[0];
        else if (GameStats.map[posX + 1, posY + 1] == 1 &&
                 GameStats.map[posX + 1, posY - 1] == 1 &&
                 GameStats.map[posX - 1, posY - 1] == 1)
            temp.sprite = threeDiagonalTiles[1];
        else if (GameStats.map[posX + 1, posY - 1] == 1 &&
                 GameStats.map[posX - 1, posY - 1] == 1 &&
                 GameStats.map[posX - 1, posY + 1] == 1)
            temp.sprite = threeDiagonalTiles[2];
        else temp.sprite = threeDiagonalTiles[3];

        return temp;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


[CreateAssetMenu(fileName = "Three Wall Tile", menuName = "Three Wall Tile", order = 360)]
public class ThreeWallTile : ScriptableObject
{
    //The walls are:
    //0 = left + up + right, 1 = right + up + down, 2 = right + down + left, 3 = left + up + down
    [SerializeField]
    private Sprite[] tiles = default;


    public Tile SelectTile(int posX, int posY)
    {
        Tile temp = ScriptableObject.CreateInstance<Tile>();

        if (GameStats.map[posX - 1, posY] == 1 &&
            GameStats.map[posX, posY +1] == 1 &&
            GameStats.map[posX + 1, posY] == 1)
            temp.sprite = tiles[0];
        else if (GameStats.map[posX + 1, posY] == 1 &&
            GameStats.map[posX, posY +1] == 1 &&
            GameStats.map[posX, posY -1] == 1)
            temp.sprite = tiles[1];
        else if (GameStats.map[posX + 1, posY] == 1 &&
            GameStats.map[posX, posY - 1] == 1 &&
            GameStats.map[posX - 1, posY] == 1)
            temp.sprite = tiles[2];
        else temp.sprite = tiles[3];

        return temp;
    }
}


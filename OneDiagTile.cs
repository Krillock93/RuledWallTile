using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "One Diagonal Tile", menuName = "One Diagonal Tile", order = 361)]
public class OneDiagTile : ScriptableObject
{

    //0 = up + left, 1 = up + right, 2 = down + right, 3 = down + left
    [SerializeField]
    private Sprite[] oneDiagonalTiles = default;

    public Tile SelectTile(int posX, int posY)
    {
        Tile temp = ScriptableObject.CreateInstance<Tile>();

        if (GameStats.map[posX -1, posY + 1] == 1)
            temp.sprite = oneDiagonalTiles[0];
        else if (GameStats.map[posX + 1, posY + 1] == 1)
            temp.sprite = oneDiagonalTiles[1];
        else if (GameStats.map[posX + 1, posY - 1] == 1)
            temp.sprite = oneDiagonalTiles[2];
        else temp.sprite = oneDiagonalTiles[3];

        return temp;
    }
}
